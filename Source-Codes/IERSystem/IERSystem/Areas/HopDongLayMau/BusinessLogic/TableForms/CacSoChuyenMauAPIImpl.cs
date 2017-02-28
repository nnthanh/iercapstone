using IERSystem.Areas.Administrator.Models;
using IERSystem.Areas.HopDongLayMau.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace IERSystem.BusinessLogic.TableForms
{
    public static partial class CacSoChuyenMauAPIImpl
    {
        //public static void Create(YeuCauLayMauInputModel request, IERSystemModelContainer db) {
        //    //nthoang Check if this year request is newer than the currently recorded years in CacSoChuyenMaus
        //    try {
        //        CacSoChuyenMau query_cacsonhanmau_row = queryCacSoChuyenMau_Row(request, db);

        //        //nthoang Query Success: Found the row with current year, so this is not the new year
        //        //Create new row for SoChuyenMau
        //        var new_sochuyenmau_rows = createNewSoChuyenMauList(request);
        //        foreach (var row in new_sochuyenmau_rows) {
        //            //nthoang: Fix The SoChuyenMau back relation link to CacSoNhanMaus (OneToMany)
        //            row.CacSoChuyenMau = query_cacsonhanmau_row;
        //        }

        //        //nthoang Update the SoChuyenMaus DB with newly added row
        //        //This should also update the query_cacsochuyenmau_row OneToMany link
        //        db.SoChuyenMaus.AddRange(new_sochuyenmau_rows);

        //        //nthoang: InvalidOpExc is thrown for row with current Year not found. This is the new year
        //    } catch (InvalidOperationException e) {
        //        //nthoang Update the CacSoNhanMus DB with newly added row
        //        //This should also add new rows with back OneToMany link to SoNhanMaus
        //        db.CacSoChuyenMaus.Add(new CacSoChuyenMau {
        //            Nam = request.NgayTaoHD.Year,
        //            //nthoang See CacSoNhanMau model for reason why we disable From (and To) property
        //            //From = request.NgayTaoHD,
        //            //Create a list of SoChuyenMau rows from request using handy method and assign to SoNhanMaus
        //            SoChuyenMaus = createNewSoChuyenMauList(request)
        //        });
        //    }
        //}

        //private static CacSoChuyenMau queryCacSoChuyenMau_Row(YeuCauLayMauInputModel request, IERSystemModelContainer db) {
        //    //nthoang: Find the row contains the current Year from CacSoChuyenMaus
        //    //The rows in CacSoNhanMaus should have unique Year columns
        //    return db.CacSoChuyenMaus.First((itemrow) => itemrow.Year == request.NgayTaoHD.Year);
        //}

        ////nthoang: Handy method to create new list of SoChuyenMau rows from request.MauHienTruongs
        //private static ICollection<SoChuyenMau> createNewSoChuyenMauList(YeuCauLayMauInputModel request) {
        //    var result = request.MauLayHienTruongs.Select((sample) =>
        //        new SoChuyenMau() {
        //            MaKH = request.MaDon,
        //            MaMau = sample.MaMau,
        //            NgayGiaoMau = request.NgayTaoHD,
        //            //TODO nthoang: Upsert PhieuYeuCau CacSoChuyenMau: Currently only use String to describe multiple ChiTieuPhanTich
        //            ChiTieuThuNghiem = sample.ChiTieuPhanTich,
        //            NgayTraKQ = request.NgayDuKienTraMau,
        //        }
        //    ).ToList();
        //    return result;
        //}
    }
}