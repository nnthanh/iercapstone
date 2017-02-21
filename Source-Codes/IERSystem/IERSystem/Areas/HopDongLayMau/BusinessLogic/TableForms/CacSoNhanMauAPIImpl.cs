using IERSystem.Areas.Administrator.Models;
using IERSystem.Areas.HopDongLayMau.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace IERSystem.BusinessLogic.TableForms
{
    public static partial class CacSoNhanMauAPIImpl
    {
        public static void Create(YeuCauLayMauInputModel request, IERSystemDBContext db) {
            //nthoang Check if this year request is newer than the currently recorded years in CacSoNhanMaus
            try {
                CacSoNhanMau query_cacsonhanmau_row = queryCacSoNhanMau_Row(request, db);

                //nthoang Query Success: Found the row with current year, so this is not the new year
                //Create new row for SoNhanMau
                var new_sonhanmau_rows = createNewSoNhanMauList(request);
                foreach (var row in new_sonhanmau_rows) {
                    //nthoang: Fix The SoNhanMau back relation link to CacSoNhanMaus (OneToMany)
                    row.CacSoNhanMau = query_cacsonhanmau_row;
                }

                //nthoang Update the SoNhanMaus DB with newly added row
                //This should also update the query_cacsonhanmau_row OneToMany link
                db.SoNhanMaus.AddRange(new_sonhanmau_rows);

            //nthoang: InvalidOpExc is thrown for row with current Year not found. This is the new year
            } catch (InvalidOperationException e) {
                //nthoang Update the CacSoNhanMus DB with newly added row
                //This should also add new rows with back OneToMany link to SoNhanMaus
                db.CacSoNhanMaus.Add(new CacSoNhanMau {
                    Year = request.NgayTaoHD.Year,
                    //nthoang See CacSoNhanMau model for reason why we disable From (and To) property
                    //From = request.NgayTaoHD,
                    //Create a list of SoNhanMau rows from request using handy method and assign to SoNhanMaus
                    SoNhanMaus = createNewSoNhanMauList(request)
                });
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private static CacSoNhanMau queryCacSoNhanMau_Row(YeuCauLayMauInputModel request, IERSystemDBContext db) {
            //nthoang: Find the row contains the current Year from CacSoNhanMaus
            //The rows in CacSoNhanMaus should have unique Year columns
            return db.CacSoNhanMaus.First((itemrow) => itemrow.Year == request.NgayTaoHD.Year);
        }

        //nthoang: Handy method to create new list of SoNhanMau rows from request.MauHienTruongs
        private static ICollection<SoNhanMau> createNewSoNhanMauList(YeuCauLayMauInputModel request) {
            var result = request.MauLayHienTruongs.Select((sample) =>
                new SoNhanMau() {
                    PhieuYeuCau = request.MaDon,
                    //TODO nthoang: Upsert PhieuYeuCau CacSoNhanMau: Ten/DiaChiKhachHang = TenKhachHang(Not NguoiDaiDien)/DiaChi?
                    TenDiaChiKhachHang = request.TenKhachHang + "/" + request.DiaChiKhachHang,
                    MaSo = sample.MaMau,
                    //TODO nthoang: Upsert PhieuYeuCau CacSoNhanMau: Currently only use String to describe multiple ChiTieuPhanTich
                    ChiTieuThuNghiem = sample.ChiTieuPhanTich,
                    //TODO nthoang: Upsert PhieuYeuCau CacSoNhanMau: NgayTaoHD == NgayNhan in CacSoNhanMau?
                    NgayNhan = request.NgayTaoHD,
                    NgayTraKetQua = request.NgayDuKienTraMau,
                    MaMauKH = sample.MaMauKH
                    //TODO nthoang: Upsert PhieuYeuCau CacSoNhanMau: No KHKyNhan currently                         
                }
            ).ToList();
            return result;
        }
    }
}