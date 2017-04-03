using IERSystem.Areas.Administrator.Models;
using IERSystem.Areas.QuanLyKetQuaPhanTich.Models;
using IERSystem.BusinessLogic.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IERSystem.BusinessLogic.TableForms
{
    public static partial class SoKQThuNghiemAPIImpl
    {

        public static void EditSoKQ(KetQuaEditedInputModel edit_inp, IERSystemModelContainer db)
        {
            var targetmodel = (from sokqm in db.SoKQThuNghiems
                               where sokqm.Id == edit_inp.Id
                               select sokqm
                              ).First();
            var i = 0;
            targetmodel.KQThuNghiemMaus.ToList().ForEach((kqtnmau) =>
            {
                kqtnmau.KetQua = edit_inp.KetQuas.ElementAt(i).KetQua;
                kqtnmau.DonVi = edit_inp.KetQuas.ElementAt(i).DonVi;
                db.KQThuNghiemMaus.Attach(kqtnmau);
                db.Entry(kqtnmau).Property(x => x.KetQua).IsModified = true;
                db.Entry(kqtnmau).Property(x => x.DonVi).IsModified = true;
                db.Entry(kqtnmau).State = EntityState.Modified;
                i++;
            });   
        }

        public static void AddKetQuaPT(SoKQThuNghiemInputModel kq_inp, IERSystemModelContainer db, DateTime today)
        {
            try
            {
                var tinhtrang_dachuyen = TinhTrangMauConverter.ToByte(TinhTrangMau.DaChuyen);
                //nthoang: Valid target_mau should have the same ki hieu as KiHieuMau and its TinhTrang is DaChuyen
                var target_mau = (from mau in db.MauLayHienTruongs
                                  where mau.Id == kq_inp.Id
                                        //&& mau.TinhTrang == tinhtrang_dachuyen
                                  select mau
                                 ).First(); //Should fetch a single one
                //nthoang: Change TinhTrang of target_mau to DaCoKQ
                //target_mau.TinhTrang = TinhTrangMauConverter.ToByte(TinhTrangMau.DaCoKQ);
                //db.MauLayHienTruongs.Attach(target_mau);
                //db.Entry(target_mau).Property(x => x.TinhTrang).IsModified = true;
                
                var newkqthunghiem = new SoKQThuNghiem()
                {
                    MaMau = kq_inp.KiHieuMau,
                    MauLayHienTruong = target_mau,
                    NgayNhanMau = target_mau.PhieuYeuCau.NgayLayMau,
                    NgayTraMau = target_mau.PhieuYeuCau.NgayHenTraKQ
                };
                foreach (var chitieu in target_mau.ChiTieuPhanTiches) {
                    var kqitem = new KQThuNghiemMau()
                    {
                        ChiTieuPhanTich = chitieu,
                        DonVi = "",
                        KetQua = "",
                        NguoiThucHien = "N/A",
                    };
                    db.KQThuNghiemMaus.Add(kqitem);
                    newkqthunghiem.KQThuNghiemMaus.Add(kqitem);
                }
                db.SoKQThuNghiems.Add(newkqthunghiem);
            }
            catch (InvalidOperationException e)
            {
                //nthoang: No target_mau satisfied condition found, return error
                throw new InvalidOperationException();
            }
        }
    }
}