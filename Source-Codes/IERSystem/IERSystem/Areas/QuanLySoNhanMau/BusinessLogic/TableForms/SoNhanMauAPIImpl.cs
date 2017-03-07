using IERSystem.Areas.Administrator.Models;
using IERSystem.Areas.QuanLySoNhanMau.Models;
using IERSystem.BusinessLogic.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IERSystem.BusinessLogic.TableForms
{
    public static partial class SoNhanMauAPIImpl
    {
        public static void AddMauPT(MauPTAdderInputModel mauptadd_inp, IERSystemModelContainer db)
        {
            try
            {
                var today = DateTime.Now;
                //nthoang: Find the target CacSoNhanMau
                var target = db.CacSoNhanMaus.First((model) => model.Id == mauptadd_inp.CacSoNhanMauID);
                //nthoang: Filter the MauLayHienTruongs to be added
                //They should also still at KhoiTao status [1] and haven't been added to any SoNhanMau yet [2]
                var tinhtrang_khoitao = TinhTrangMauConverter.ToByte(TinhTrangMau.KhoiTao);
                var mau_tobeaddeds = (from mauht in db.MauLayHienTruongs
                                      where mauptadd_inp.MauPhanTichIDs.Contains(mauht.Id)
                                            && mauht.TinhTrang == tinhtrang_khoitao //[1]
                                            && mauht.SoNhanMau == null //[2]
                                      select mauht);

                //nthoang: Add all satisfied MauLayHienTruongs to the targeted CacSoNhanMau
                foreach (var mau_tobeadded in mau_tobeaddeds)
                {
                    //nthoang: Change all state of each queried MauLayHienTruong to be added to TinhTrangMau.DaNhan
                    mau_tobeadded.TinhTrang = TinhTrangMauConverter.ToByte(TinhTrangMau.DaNhan);
                    db.MauLayHienTruongs.Attach(mau_tobeadded);
                    db.Entry(mau_tobeadded).Property(x => x.TinhTrang).IsModified = true;
                    //nthoang: Then add new SoNhanMau entry to the model
                    target.SoNhanMaus.Add(new SoNhanMau()
                    {
                        MauLayHienTruong = mau_tobeadded,
                        NgayNhan = today,
                        NgayTraKQ = mau_tobeadded.PhieuYeuCau.NgayHenTraKQ
                    });
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