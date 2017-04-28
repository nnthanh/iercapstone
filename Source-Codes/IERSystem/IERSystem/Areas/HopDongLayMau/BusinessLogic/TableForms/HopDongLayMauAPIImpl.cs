using IERSystem.Areas.Administrator.Models;
using IERSystem.Areas.HopDongLayMau.Models;
using IERSystem.BusinessLogic.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;

namespace IERSystem.BusinessLogic.TableForms
{
    public class UpsertDBResponse
    {
        public bool IsOK { get; set; }
        public string ErrMsg { get; set; }
    }

    public class GetDBResponse<T>
    {
        public bool IsOK { get; set; }
        public T Data { get; set; }
    }

    public static partial class HopDongLayMauAPIImpl
    {
        public static void CreateModel(YeuCauLayMauInputModel input_request, IERSystemModelContainer db)
        {
            var today_dep = DateTime.Now.Date;
            var encoded_inp_req = HopDongLayMauEncoding.Encode(input_request, db, today_dep);
            var yeucaulaymau_model = convertToModel(input_request, db, today_dep);
            //yeucaulaymau_model.CreatedBy = (int)Session["loggedID"];
            db.PhieuYeuCaus.Add(yeucaulaymau_model);
        }
        
        public static IEnumerable<long> ModifyModel(YeuCauLayMauEditInputModel edit_request, IERSystemModelContainer db)
        {
            var result = new List<long>();
            //mau_tobeadded.TinhTrang = TinhTrangMauConverter.ToByte(TinhTrangMau.DaNhan);
            //db.MauLayHienTruongs.Attach(mau_tobeadded);
            //db.Entry(mau_tobeadded).Property(x => x.TinhTrang).IsModified = true;
            var edit_model = db.PhieuYeuCaus.Find(edit_request.Id);

            db.PhieuYeuCaus.Attach(edit_model);
            edit_model.MaSoThue = edit_request.MaSoThue;
            db.Entry(edit_model).Property(x => x.MaSoThue).IsModified = true;
            edit_model.NgayHenTraKQ = edit_request.NgayLayMau.AddDays(edit_request.NgayHenTraKQ);
            db.Entry(edit_model).Property(x => x.NgayHenTraKQ).IsModified = true;
            edit_model.NgayLayMau = edit_request.NgayLayMau;
            db.Entry(edit_model).Property(x => x.NgayLayMau).IsModified = true;
            edit_model.NoiLayMau = edit_request.DiaChiLayMau;
            db.Entry(edit_model).Property(x => x.NoiLayMau).IsModified = true;
            edit_model.SoDienThoai = edit_request.SoDienThoai;
            db.Entry(edit_model).Property(x => x.SoDienThoai).IsModified = true;
            edit_model.SoFax = edit_request.SoFax;
            db.Entry(edit_model).Property(x => x.SoFax).IsModified = true;
            edit_model.TenDaiDien = edit_request.TenDaiDien;
            db.Entry(edit_model).Property(x => x.TenDaiDien).IsModified = true;
            edit_model.TenKhachHang = edit_request.TenKhachHang;
            db.Entry(edit_model).Property(x => x.TenKhachHang).IsModified = true;
            edit_model.DiaChiKhachHang = edit_request.DiaChiKhachHang;
            db.Entry(edit_model).Property(x => x.DiaChiKhachHang).IsModified = true;
            if (edit_request.MauLayHienTruongs != null)
            {
                foreach (var edit_maupt in edit_request.MauLayHienTruongs)
                {
                    try
                    {
                        var edit_maupt_model = edit_model.MauLayHienTruongs.First((maupt_db) => maupt_db.Id == edit_maupt.Id);
                        if (edit_maupt.ModifiedState == MauPTModifiedStateConverter.ToByte(MauPTModifiedState.Edited))
                        {
                            //nthoang: Only works if edit_maupt is in khoitao
                            if (edit_maupt_model.TinhTrang == TinhTrangMauConverter.ToByte(TinhTrangMau.KhoiTao))
                            {
                                db.MauLayHienTruongs.Attach(edit_maupt_model);
                                edit_maupt_model.MaMauKH = edit_maupt.MaMauKH;
                                db.Entry(edit_maupt_model).Property(x => x.MaMauKH).IsModified = true;
                                //nthoang: Encode MaMau again using the new KiHieuMau
                                edit_maupt_model.MaMau =
                                    HopDongLayMauEncoding.ReEncodeMaMau(
                                        edit_maupt_model.MaMau, 
                                        edit_maupt.KiHieuMau, DateTime.Now, db
                                    );
                                db.Entry(edit_maupt_model).Property(x => x.MaMau).IsModified = true;
                                edit_maupt_model.MoTaMau = edit_maupt.MoTaMau;
                                db.Entry(edit_maupt_model).Property(x => x.MoTaMau).IsModified = true;
                                edit_maupt_model.SoLuong = edit_maupt.SoLuong;
                                db.Entry(edit_maupt_model).Property(x => x.SoLuong).IsModified = true;
                                edit_maupt_model.DonVi = edit_maupt.DonVi;
                                db.Entry(edit_maupt_model).Property(x => x.DonVi).IsModified = true;
                                edit_maupt_model.ViTriLayMau = edit_maupt.ViTriLayMau;
                                db.Entry(edit_maupt_model).Property(x => x.ViTriLayMau).IsModified = true;
                                //nthoang: Handle all diff in ChiTieuPhanTiches sets in both model and edit request
                                //nthoang: First case, handle every ChiTieuPhanTiches in edit request
                                var tobeadded_ctpts = new List<ChiTieuPhanTich>();
                                foreach (var edit_chitieu in edit_maupt.ChiTieuPhanTiches)
                                {
                                    var exists_target_chitieu_model = edit_maupt_model.ChiTieuPhanTiches.Any((ctpt) =>
                                        ctpt.Id == edit_chitieu.Id
                                    );

                                    if (!exists_target_chitieu_model)
                                    {
                                        //nthoang: This happens when This is the new chi tieu added in edit_maupt
                                        //nthoang: Find the info of new chitieuphantich in db
                                        //nthoang: Then add it to model

                                        //nthoang: Should always succeed
                                        var target_chitieu_model = db.ChiTieuPhanTiches.First((ctpt) =>
                                            ctpt.Id == edit_chitieu.Id
                                        );
                                        tobeadded_ctpts.Add(target_chitieu_model);
                                    }
                                }
                                foreach (var tobeadded_ctpt in tobeadded_ctpts)
                                {
                                    edit_maupt_model.ChiTieuPhanTiches.Add(tobeadded_ctpt);
                                }
                                //nthoang: Second case, handle every ChiTieuPhanTiches in model
                                var tobedeleted_ctpts = new List<ChiTieuPhanTich>();
                                foreach (var edit_chitieu in edit_maupt_model.ChiTieuPhanTiches)
                                {
                                    var exists_target_chitieu_model = edit_maupt.ChiTieuPhanTiches.Any((ctpt) =>
                                        ctpt.Id == edit_chitieu.Id
                                    );

                                    if (!exists_target_chitieu_model)
                                    {
                                        //nthoang: This happens when the chi tieu has been removed in edit_maupt
                                        //nthoang: Find the info of new chitieuphantich in db
                                        //nthoang: Then remove it from model

                                        //nthoang: Should always succeed
                                        var target_chitieu_model = db.ChiTieuPhanTiches.First((ctpt) =>
                                            ctpt.Id == edit_chitieu.Id
                                        );
                                        tobedeleted_ctpts.Add(target_chitieu_model);
                                    }
                                }
                                foreach (var tobedeleted_ctpt in tobedeleted_ctpts)
                                {
                                    edit_maupt_model.ChiTieuPhanTiches.Remove(tobedeleted_ctpt);
                                }
                                //nthoang: Add successfully added maupt id to return output
                                result.Add(edit_maupt_model.Id);
                            }
                        }
                        else if (edit_maupt.ModifiedState == MauPTModifiedStateConverter.ToByte(MauPTModifiedState.Deleted))
                        {
                            //nthoang: Only works if edit_maupt is in khoitao
                            if (edit_maupt_model.TinhTrang == TinhTrangMauConverter.ToByte(TinhTrangMau.KhoiTao))
                            {
                                var delete_maupt_model =
                                    db.MauLayHienTruongs.First((maupt_db) => maupt_db.Id == edit_maupt.Id);

                                //nthoang: Remove all associated chitieuphantich relations from delete_maupt_model
                                var all_ctpt_tobedeleteds = delete_maupt_model.ChiTieuPhanTiches.ToList();
                                foreach (var ctpt_tobedeleted in all_ctpt_tobedeleteds)
                                {
                                    delete_maupt_model.ChiTieuPhanTiches.Remove(ctpt_tobedeleted);
                                    //ctpt_tobedeleted.MauLayHienTruongs.Remove(delete_maupt_model);
                                }

                                db.MauLayHienTruongs.Remove(delete_maupt_model);
                                //nthoang: Add successfully added maupt id to return output
                                result.Add(edit_maupt_model.Id);
                            }
                        }

                    }
                    catch (InvalidOperationException e)
                    {
                        //nthoang: Skip if error found
                    }
                }
            }
            return result;
        }

        public static YeuCauLayMauEditOutputModel GetPhieuYCEdit(long id, IERSystemModelContainer db)
        {
            var target_phieuyc = db.PhieuYeuCaus.Find(id);
            if (target_phieuyc == null) return null;
            return new YeuCauLayMauEditOutputModel()
            {
                TenKhachHang = target_phieuyc.TenKhachHang,
                TenDaiDien = target_phieuyc.TenDaiDien,
                SoFax = target_phieuyc.SoFax,
                SoDienThoai = target_phieuyc.SoDienThoai,
                NgayLayMau = target_phieuyc.NgayLayMau.ToShortDateString(),
                NgayHenTraKQ = (target_phieuyc.NgayHenTraKQ - target_phieuyc.NgayLayMau).Days,
                MaSoThue = target_phieuyc.MaSoThue,
                DiaChiLayMau = target_phieuyc.DiaChiLayMau,
                DiaChiKhachHang = target_phieuyc.DiaChiKhachHang
            };
        }

        public static IEnumerable<MauPTEditOutputModel> GetMauPTsEdit(long id, IERSystemModelContainer db)
        {
            var target_phieuyc = db.PhieuYeuCaus.Find(id);
            if (target_phieuyc != null)
            {
                //nthoang: Filter result that has not been added to So Chuyen and So Nhan yet
                var result = target_phieuyc.MauLayHienTruongs.Where((mht) => {
                    var tinhtrang = TinhTrangMauConverter.ToTinhTrangMau(mht.TinhTrang);
                    return tinhtrang == TinhTrangMau.KhoiTao;
                });
                //nthoang: Map result into Output model
                return result.Select((mht) => new MauPTEditOutputModel()
                {
                    Id = mht.Id,
                    //nthoang: Using HopDongLayMauEncoding API to extract KiHieuMau from MaMau
                    KiHieuMau = HopDongLayMauEncoding.ToKiHieuMauViewString(mht.MaMau),
                    MaMauKH = mht.MaMauKH,
                    MoTaMau = mht.MoTaMau,
                    SoLuong = mht.SoLuong,
                    DonVi = mht.DonVi,
                    ViTriLayMau = mht.ViTriLayMau,
                    ChiTieuPhanTiches = mht.ChiTieuPhanTiches.Select((ctpt) =>
                    {
                        return new ChiTieuPTEditedOutputModel()
                        {
                            Id = ctpt.Id,
                            TenChiTieu = ctpt.TenChiTieu,
                            NhomChiTieu = ctpt.NhomChiTieu.TenNhom
                        };
                    })
                });
            }
            else
            {
                throw new InvalidOperationException("No Entity found with id = " + id);
            }
        }

        /// <summary>
        /// Convert InputModel to Database Model
        /// </summary>
        /// <returns>The database model</returns>
        private static PhieuYeuCau convertToModel(YeuCauLayMauInputModel input_request, IERSystemModelContainer db, DateTime today)
        {
            var req = new PhieuYeuCau();
            //nthoang: here PhieuYeuCau should already been Encoded
            Debug.Assert(input_request.MaDon != null);
            if (input_request.KhachHangMoi)
            {
                var duplicate_exists = db.KhachHangs.Any((kh) => 
                    kh.DiaChiKhachHang.Equals(input_request.DiaChiKhachHang) &&
                    kh.TenKhachHang.Equals(input_request.TenKhachHang)
                );
                if (!duplicate_exists)
                {
                    db.KhachHangs.Add(new KhachHang()
                    {
                        TenKhachHang = input_request.TenKhachHang,
                        TenDaiDien = input_request.TenDaiDien,
                        SoDienThoai = input_request.SoDienThoai,
                        SoFax = input_request.SoFax,
                        DiaChiKhachHang = input_request.DiaChiKhachHang,
                        MaSoThue = input_request.MaSoThue
                    });
                }
            }
            
            req.MaDon = input_request.MaDon;
            req.TenDaiDien = input_request.TenDaiDien;
            req.TenKhachHang = input_request.TenKhachHang;
            req.DiaChiKhachHang = input_request.DiaChiKhachHang;
            req.DiaChiLayMau = input_request.DiaChiLayMau;
            req.MaSoThue = input_request.MaSoThue;
            req.SoFax = input_request.SoFax;
            req.SoDienThoai = input_request.SoDienThoai;
            req.NgayHenTraKQ = input_request.NgayLayMau.AddDays(input_request.NgayHenTraKQ);
            req.NoiLayMau = input_request.DiaChiLayMau;
            req.NgayLayMau = input_request.NgayLayMau;
            req.NgayTaoHD = today;
            req.UserId = input_request.CreatedBy.Id;
            req.CreatedBy = input_request.CreatedBy;
            req.MauLayHienTruongs = input_request.MauLayHienTruongs.Select((elem) =>
            {
                var mapped = new MauLayHienTruong();
                mapped.MoTaMau = elem.MoTaMau;
                mapped.SoLuong = elem.SoLuong;
                mapped.DonVi = elem.DonVi;
                mapped.ViTriLayMau = elem.ViTriLayMau;
                mapped.MaMauKH = elem.MaMauKH;

                //nthoang: Here find all db instance of matched ChiTieuPhanTiches that matches the pair signature (chitieuphantich, loaimau)
                mapped.ChiTieuPhanTiches = elem.ChiTieuPhanTiches.Select((ct) =>
                {
                    //nthoang: TODO: Potential performance bottleneck
                    try
                    {
                        //Find (chitieuphantich, nhomchitieu) pair such that they are equals (chitieuphantich, loaimau)
                        var q = (from ct_model in db.ChiTieuPhanTiches
                             join nhomct in db.NhomChiTieux on ct_model.NhomChiTieuId equals nhomct.Id
                             where ct_model.TenChiTieu.Equals(ct.TenChiTieu)
                                   && nhomct.TenNhom.Equals(ct.NhomChiTieu)
                             select ct_model
                            ).First(); //nthoang: Ensure this is the only matching value here
                        return q;
                    }
                    catch (InvalidOperationException e)
                    {
                        //Cannot reach here
                        Debug.Assert(false, "Cannot reach here");
                        return null;
                    }
                }).ToList();

                //nthoang: here MauLayHienTruong should already been Encoded
                Debug.Assert(elem.MaMau != null);
                mapped.MaMau = elem.MaMau;
                //nthoang: MauLayHienTruong.TinhTrang is KhoiTao
                mapped.TinhTrang = TinhTrangMauConverter.ToByte(TinhTrangMau.KhoiTao);
                return mapped;
            }).ToArray();
            return req;
        } 

    }
}