using IERSystem.Areas.Administrator.Models;
using IERSystem.Areas.QuanLySoNhanMau.Models;
using IERSystem.BusinessLogic.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace IERSystem.BusinessLogic.TableForms
{
    public static partial class SoNhanMauAPIImpl
    {
        public static SoNhanMauOpenOutputModel FetchSoNhanMau(long id, IERSystemModelContainer db)
        {
            try
            {
                var target_sonhanmau = db.CacSoNhanMaus.Single((snm) => snm.Id == id);
                return new SoNhanMauOpenOutputModel()
                {
                    //nthoang: QuyenSo should start from 1
                    QuyenSo = target_sonhanmau.Id,
                    DomId = "SoNhanMau_" + (target_sonhanmau.Id).ToString(),
                    TuNgay = target_sonhanmau.TuNgay.ToShortDateString(),
                    DenNgay = target_sonhanmau.DenNgay.ToShortDateString(),
                    NoiDung = new List<SoNhanMauOpenRowOutputModel>(target_sonhanmau.SoNhanMaus.Select((snm_row) =>
                        new SoNhanMauOpenRowOutputModel()
                        {
                            Id = snm_row.Id,
                            AddedBy = snm_row.CreatedBy.Fullname,
                            MaMau = snm_row.MauLayHienTruong.MaMau,
                            MaMauKH = snm_row.MauLayHienTruong.MaMauKH,
                            MaPhieuYeuCau = snm_row.MauLayHienTruong.PhieuYeuCau.MaDon,
                            NgayNhan = snm_row.NgayNhanMau.ToShortDateString(),
                            NgayTraKQ = snm_row.NgayTraKQ.ToShortDateString(),
                            KHKyTraKQ = snm_row.KHKiNhanTraKQ,
                            KHKyTraTien = snm_row.KHKiNhanTraTien,
                            TenDiaChiKH =
                                snm_row.MauLayHienTruong.PhieuYeuCau.TenKhachHang + " / " +
                                snm_row.MauLayHienTruong.PhieuYeuCau.DiaChiKhachHang,
                            ChiTieuThuNghiem =
                                String.Join(", ", snm_row.MauLayHienTruong.ChiTieuPhanTiches.Select((item) => item.TenChiTieu))
                        }
                    ))
                };
            }
            catch (InvalidOperationException e)
            {
                throw e;
            }
        }

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
                        CreatedBy = mauptadd_inp.CreateBy,
                        UserId = mauptadd_inp.CreateBy.Id, 
                        MauLayHienTruong = mau_tobeadded,
                        NgayNhanMau = today,
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