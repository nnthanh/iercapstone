﻿using IERSystem.Areas.BaoGiaChiTieu.Models;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IERSystem.BusinessLogic
{
    public static class BaoGiaChiTieuSheetParser
    {
        //nthoang: TODO: WIP
        public static List<MauBaoGiaInputModel> ParseUploadSheetData(HttpPostedFileBase file) {
            if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName)) {
                var workbook = new XSSFWorkbook(file.InputStream);
                //nthoang: Import BaoGiaChiTieu: sheet name must be Sheet1
                var sheet = workbook.GetSheet("Sheet1");
                //nthoang: Starts at the 3rd row
                var firstrownum = 2;
                var lastrownum = sheet.LastRowNum + 1;
                
                var maubaogia_inps = new List<MauBaoGiaInputModel>();
                string nhomchitieu, chitieu, phuongphap;
                decimal dongia;
                for (int i = firstrownum; i < lastrownum; i++) {
                    var cur_row = sheet.GetRow(i);
                    var nhomchitieu_cell = cur_row.GetCell(0, MissingCellPolicy.RETURN_BLANK_AS_NULL);
                    var chitieu_cell = cur_row.GetCell(1, MissingCellPolicy.RETURN_BLANK_AS_NULL);
                    var phuongphap_cell = cur_row.GetCell(2, MissingCellPolicy.RETURN_BLANK_AS_NULL);
                    var dongia_cell = cur_row.GetCell(3, MissingCellPolicy.RETURN_BLANK_AS_NULL);
                    //nthoang: Import BaoGiaChiTieu: empty string cell as BLANK
                    nhomchitieu = (nhomchitieu_cell == null) ? 
                        null : nhomchitieu_cell.ToString().Replace("  ", " ").Trim();
                    chitieu = (chitieu_cell == null) ? 
                        null : chitieu_cell.ToString().Replace("  ", " ").Trim();
                    phuongphap = (phuongphap_cell == null) ? 
                        null : phuongphap_cell.ToString().Replace("  ", " ").Trim();
                    try
                    {
                        //nthoang: Import BaoGiaChiTieu: empty numeric cell as 0
                        dongia = (dongia_cell == null) ? 0 : decimal.Parse(dongia_cell.ToString());
                    }
                    catch (Exception e)
                    {
                        //nthoang: Import BaoGiaChiTieu: error numeric cell as 0
                        dongia = 0;
                    }
                    //nthoang: Parse according to null pattern (empty cell)
                    if (nhomchitieu != null && chitieu != null && phuongphap != null)
                    {
                        //the beginning of the new nhomchitieu
                        
                        //Initialize new maubaogia_inpmodel
                        var cur_maubaogia_inpmodel = new MauBaoGiaInputModel()
                        {
                            ChiTieus = new List<ChiTieuPhanTichInputModel>() {
                                new ChiTieuPhanTichInputModel() {
                                    DonGia = dongia,
                                    PhuongPhap = phuongphap,
                                    TenChiTieu = chitieu
                                }
                            },
                            NhomChiTieu = nhomchitieu
                        };
                        //Add the new maubaogia_inpmodel to the result
                        maubaogia_inps.Add(cur_maubaogia_inpmodel);
                    }
                    else if (chitieu != null && phuongphap != null)
                    {
                        //The beginning of the new phuongphap, chitieu
                        //Add to the newest maubaogia_inpmodel
                        maubaogia_inps.Last().ChiTieus.Add(new ChiTieuPhanTichInputModel()
                        {
                            DonGia = dongia,
                            PhuongPhap = phuongphap,
                            TenChiTieu = chitieu
                        });
                    }
                    else
                    {
                        //either phuongphap, chitieu is null which is an malformed input
                        //Skip this row
                    }

                }
                //nthoang: Add the last 
                //nthoang: Import BaoGiaChiTieu Return populated list as success
                return maubaogia_inps;
            } else {
                //nthoang: Import BaoGiaChiTieu Return empty List as error
                return new List<MauBaoGiaInputModel>();
            }
        }
    }
}