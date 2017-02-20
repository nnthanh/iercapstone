using IERSystem.Areas.Administrator.Models;
using IERSystem.Areas.HopDongLayMau.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace IERSystem.ItemEncoding
{
    public static class HopDongLayMauEncoding
    {
        private static string StringifyNumberTo2Digit(int number) {
            //if (reqnumber <= 0)
            //    throw new ArgumentException("reqnumber must be positive");
            Debug.Assert(number > -1, "Request code is negative");
            //nthoang: WARNING Request Code cannot be more than 99
            Debug.Assert(number < 100, "Request code exceeds 99");
            return (number < 10) ? "0" + number.ToString() : number.ToString();
        }

        private static string StringifyNumberTo3Digit(int number) {
            //if (reqnumber <= 0)
            //    throw new ArgumentException("reqnumber must be positive");
            Debug.Assert(number > -1, "Sample code is negative");
            //nthoang: WARNING Sample Code cannot be more than 999
            Debug.Assert(number < 1000, "Sample code exceeds 999");
            return (number < 10) ? "00" + number.ToString() : 
                   (number < 100) ? "0" + number.ToString() :
                   number.ToString();
        }

        //nthoang Mã khách hàng: XXDDMM
        //nthoang Mã mẫu: AAZZZ/MM
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static YeuCauLayMauInputModel MaHoa(
            YeuCauLayMauInputModel request_inp, IERSystemDBContext db
        ) {
            if (db != null && request_inp != null) {
                var result = request_inp;
                var today_day = request_inp.NgayTaoHD.Day;
                var this_month = request_inp.NgayTaoHD.Month;
                var today_day_str = StringifyNumberTo2Digit(today_day);
                var this_month_str = StringifyNumberTo2Digit(this_month);

                //nthoang: Count the current number of today requests
                //nthoang: this is the number of current request
                var req_next_str =
                    StringifyNumberTo2Digit(
                        db.PhieuYeuCaus.Count((item) => item.NgayTaoHD.Day.Equals(today_day))
                    );

                //nthoang: retrieve samples for this month
                //nthoang: And group them by their type (first 2 letter of their encoded MaMau)
                //nthoang: Into (Sample Type, Count)
                var this_month_samples_by_type =
                        (from sample in db.MauLayHienTruongs
                         join request in db.PhieuYeuCaus on sample.PhieuYeuCau.Id equals request.Id
                         where request.NgayTaoHD.Month.Equals(this_month)
                         group sample by sample.MaMau.Substring(0, 2) into sample_type_group
                         select new { SampleType = sample_type_group.Key, Count = sample_type_group.Count() }
                        ).ToDictionary((item) => item.SampleType, (item) => item.Count);
                //nthoang: Create Count Hash for the input samples by their type (KiHieuMau)
                var samples_inp_by_type =
                        request_inp.MauLayHienTruongs
                                   .Select((item) => item.KiHieuMau)
                                   .Distinct()
                                   .ToDictionary((item) => item, (item) => 0);
                foreach (var sample in result.MauLayHienTruongs) {
                    if (this_month_samples_by_type.ContainsKey(sample.KiHieuMau)) {
                        var sample_next_by_type =
                            StringifyNumberTo3Digit(
                                this_month_samples_by_type[sample.KiHieuMau]
                                + samples_inp_by_type[sample.KiHieuMau]
                            );
                        //nthoang: Sample ID == AAZZZ/MM (Refer to QT14 - TNYVKH & KKHD.doc)
                        sample.MaMau = sample.KiHieuMau + sample_next_by_type + "/" + this_month_str;
                    } else {
                        var sample_next_by_type =
                            StringifyNumberTo3Digit(
                                samples_inp_by_type[sample.KiHieuMau]
                            );
                        //nthoang: Sample ID == AAZZZ/MM (Refer to QT14 - TNYVKH & KKHD.doc)
                        sample.MaMau = sample.KiHieuMau + sample_next_by_type + "/" + this_month_str;
                    }
                    samples_inp_by_type[sample.KiHieuMau] += 1;
                }

                //nthoang: Customer ID == Request Form ID == XXDDMM (Refer to QT14 - TNYVKH & KKHD.doc)
                result.MaDon = req_next_str + today_day_str + this_month_str;
                return result;
            } else {
                throw new ArgumentException("request and db must not be null");
            }
        }
    }
}