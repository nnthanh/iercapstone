using IERSystem.Areas.BaoGiaChiTieu.Models;
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
        public static List<MauBaoGiaInputModel> ParseUploadSheetData(HttpPostedFileBase file) {
            if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName)) {
                var workbook = new XSSFWorkbook(file.InputStream);
                //nthoang: Import BaoGiaChiTieu: sheet name must be Sheet1
                var sheet = workbook.GetSheet("Sheet1");
                var firstrownum = 2;
                var lastrownum = sheet.LastRowNum;
                
                var maubaogia_inps = new List<MauBaoGiaInputModel>();
                string nhomchitieu, chitieu;
                decimal dongia;
                for (int i = firstrownum; i <= lastrownum; i++) {
                    var cur_row = sheet.GetRow(i);
                    var nhomchitieu_cell = cur_row.GetCell(0, MissingCellPolicy.RETURN_BLANK_AS_NULL);
                    var chitieu_cell = cur_row.GetCell(1, MissingCellPolicy.RETURN_BLANK_AS_NULL);
                    var dongia_cell = cur_row.GetCell(2, MissingCellPolicy.RETURN_BLANK_AS_NULL);
                    //nthoang: Import BaoGiaChiTieu: empty string cell as BLANK
                    nhomchitieu = (nhomchitieu_cell == null) ? "BLANK" : nhomchitieu_cell.ToString();
                    chitieu = (chitieu_cell == null) ? "BLANK" : chitieu_cell.ToString();
                    try {
                        //nthoang: Import BaoGiaChiTieu: empty numeric cell as 0
                        dongia = (dongia_cell == null) ? 0 : decimal.Parse(dongia_cell.ToString());
                    } catch (Exception e) {
                        //nthoang: Import BaoGiaChiTieu: error numeric cell as 0
                        dongia = 0;
                    }
                    maubaogia_inps.Add(new MauBaoGiaInputModel() {
                        NhomChiTieu = nhomchitieu,
                        DonGia = dongia,
                        TenChiTieu = chitieu
                    });
                }
                //nthoang: Import BaoGiaChiTieu Return populated list as success
                return maubaogia_inps;
            } else {
                //nthoang: Import BaoGiaChiTieu Return empty List as error
                return new List<MauBaoGiaInputModel>();
            }
        }
    }
}