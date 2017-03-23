using IERSystem.Areas.Administrator.Models;
using IERSystem.Areas.QuanLySoChuyenMau.Models;
using IERSystem.BusinessLogic.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IERSystem.BusinessLogic.TableForms
{
    public static partial class SoChuyenMauAPIImpl
    {
        public static void AddMauPT(MauPTAdderInputModel mauptadd_inp, IERSystemModelContainer db)
        {
            try
            {
                var today = DateTime.Now;
                //nthoang: Find the target CacSoChuyenMau
                var target = db.CacSoChuyenMaus.First((model) => model.Id == mauptadd_inp.CacSoChuyenMauID);
                //nthoang: Filter the MauLayHienTruongs to be added
                //They should also still at DaNhan status [1] and haven't been added to any SoChuyenMau yet [2]
                var tinhtrang_danhan = TinhTrangMauConverter.ToByte(TinhTrangMau.DaNhan);
                var mau_tobeaddeds = (from mauht in db.MauLayHienTruongs
                                      where mauptadd_inp.MauPhanTichIDs.Contains(mauht.Id)
                                            && mauht.TinhTrang == tinhtrang_danhan //[1]
                                            && mauht.SoChuyenMau == null //[2]
                                      select mauht);

                //nthoang: Add all satisfied MauLayHienTruongs to the targeted CacSoNhanMau
                foreach (var mau_tobeadded in mau_tobeaddeds)
                {
                    //nthoang: Change all state of each queried MauLayHienTruong to be added to TinhTrangMau.DaChuyen
                    mau_tobeadded.TinhTrang = TinhTrangMauConverter.ToByte(TinhTrangMau.DaChuyen);
                    db.MauLayHienTruongs.Attach(mau_tobeadded);
                    db.Entry(mau_tobeadded).Property(x => x.TinhTrang).IsModified = true;
                    //nthoang: Then add new SoNhanMau entry to the model
                    target.SoChuyenMaus.Add(new SoChuyenMau()
                    {
                        MauLayHienTruong = mau_tobeadded,
                        NgayGiaoMau = today,
                        NgayTraKQ = mau_tobeadded.PhieuYeuCau.NgayHenTraKQ
                    });
                    //nthoang: TODO: (SHORTCUT) add into SoKQThiNghiem also
                    SoKQThuNghiemAPIImpl.AddKetQuaPT(new Areas.QuanLyKetQuaPhanTich.Models.SoKQThuNghiemInputModel()
                    {
                        Id = mau_tobeadded.Id,
                        KiHieuMau = mau_tobeadded.MaMau,
                        //NgayNhanMau = mau_tobeadded.PhieuYeuCau.NgayLayMau.ToShortDateString(),
                        //NgayTraMau = mau_tobeadded.PhieuYeuCau.NgayHenTraKQ.ToShortDateString()
                    }, db, today);
                }
            }
            catch (InvalidOperationException e)
            {
                //nthoang: CacSoNhanMau to be targeted is not found (Not added yet)
                //throw new InvalidOperationException("target CacSoNhanMau's ID not found");
            }
            
        }
    }
}