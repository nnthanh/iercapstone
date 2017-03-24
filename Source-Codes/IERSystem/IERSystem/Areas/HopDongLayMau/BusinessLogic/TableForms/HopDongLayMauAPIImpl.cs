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

    public static partial class HopDongLayMauAPIImpl
    {
        public static void CreateModel(YeuCauLayMauInputModel input_request, IERSystemModelContainer db)
        {
            var today_dep = DateTime.Now.Date;
            var encoded_inp_req = HopDongLayMauEncoding.Encode(input_request, db, today_dep);
            var yeucaulaymau_model = convertToModel(input_request, db, today_dep);
            db.PhieuYeuCaus.Add(yeucaulaymau_model);
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