using IERSystem.Areas.HopDongLayMau.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IERSystem.Areas.HopDongLayMau.Tests
{
    public static class HDLayMau_SNhanMauTest
    {
        public static List<YeuCauLayMauInputModel> CreateTest() {
            return new List<YeuCauLayMauInputModel>() {
                new YeuCauLayMauInputModel() {
                    TenKhachHang = "as",
                    MaSoThue = "g",
                    TenDaiDien = "cfsd",
                    SoDienThoai = "123dsa",
                    SoFax = "32fwe1",
                    DiaChiLayMau = "absfsd",
                    DiaChiKhachHang = "bqwqwc",
                    NgayLayMau = new DateTime(2011,3,4),
                    NgayHenTraKQ = new DateTime(2013,3,4),
                    MauLayHienTruongs = new List<MauPTInputModel>() {
                        new MauPTInputModel() {
                            MaMauKH = "m2011",
                            KiHieuMau = "NC",
                            ViTriLayMau = "ltk",
                            SoLuong = 4,
                            DonVi = "lit",
                            MoTaMau = "desc",
                            ChiTieuPhanTich = "pH"
                        },new MauPTInputModel() {
                            MaMauKH = "m2011",
                            KiHieuMau = "NC",
                            ViTriLayMau = "lstk",
                            SoLuong = 4,
                            DonVi = "liwt",
                            MoTaMau = "ddsesc",
                            ChiTieuPhanTich = "pH CO2"
                        },new MauPTInputModel() {
                            MaMauKH = "m2011",
                            KiHieuMau = "KK",
                            ViTriLayMau = "ltk",
                            SoLuong = 5,
                            DonVi = "lidfst",
                            MoTaMau = "dessc",
                            ChiTieuPhanTich = "pH CO"
                        },new MauPTInputModel() {
                            MaMauKH = "m2011",
                            KiHieuMau = "NT",
                            ViTriLayMau = "ltk",
                            SoLuong = 5,
                            DonVi = "lit",
                            MoTaMau = "desc",
                            ChiTieuPhanTich = "pH"
                        },new MauPTInputModel() {
                            MaMauKH = "m2011",
                            KiHieuMau = "NT",
                            ViTriLayMau = "ltk",
                            SoLuong = 6,
                            DonVi = "lit",
                            MoTaMau = "desc",
                            ChiTieuPhanTich = "pH"
                        },
                    }
                }
            };
        }
    }
}