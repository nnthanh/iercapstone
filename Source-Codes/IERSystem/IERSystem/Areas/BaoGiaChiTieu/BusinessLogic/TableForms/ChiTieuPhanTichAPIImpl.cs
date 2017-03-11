using IERSystem.Areas.Administrator.Models;
using IERSystem.Areas.BaoGiaChiTieu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IERSystem.BusinessLogic.TableForms
{
    public static partial class ChiTieuPhanTichAPIImpl
    {
        public static void Create(HttpPostedFileBase file, IERSystemModelContainer db)
        {
            if (file == null && db == null)
            {
                throw new ArgumentException("file and db cannot be nulls");
            }
            var maubaogia_inps = BaoGiaChiTieuSheetParser.ParseUploadSheetData(file);
            foreach (var maubaogia_inp in maubaogia_inps)
            {
                createOrUpdateBaoGiaChiTieuModel(maubaogia_inp, db);
            }
        }

        public static IEnumerable<ChiTieuPTOutputModel> GetChiTieusByNhomCT(
            ChiTieuPTInputModel chitieupt_inp, IERSystemModelContainer db)
        {
            return (from chitieu in db.ChiTieuPhanTiches
                    join nhomct in db.NhomChiTieux on chitieu.NhomChiTieuId equals nhomct.Id
                    where nhomct.TenNhom.Equals(chitieupt_inp.TenNhom)
                    select chitieu
                   ).ToList().Select((ct_model) => new ChiTieuPTOutputModel()
                   {
                        Id = ct_model.Id,
                        TenChiTieu = ct_model.TenChiTieu,
                        TenNhomChiTieu = chitieupt_inp.TenNhom,
                        TenPhuongPhap = ct_model.TenPhuongPhap
                   });
        }

        public static IEnumerable<NhomChiTieuOutputModel> GetNhomCT(IERSystemModelContainer db)
        {
            return db.NhomChiTieux.ToList().Select((item) => new NhomChiTieuOutputModel() { TenNhom = item.TenNhom });
        }

        private static void createOrUpdateBaoGiaChiTieuModel(MauBaoGiaInputModel maubaogia_inp, IERSystemModelContainer db)
        {
            try
            {
                var target_nhomct = db.NhomChiTieux.First((row) => row.TenNhom.Equals(maubaogia_inp.NhomChiTieu));
                foreach (var ct in maubaogia_inp.ChiTieus)
                {
                    var ct_model = new ChiTieuPhanTich()
                    {
                        TenChiTieu = ct.TenChiTieu,
                        TenPhuongPhap = ct.PhuongPhap,
                        ChiPhi = ct.DonGia
                    };
                    //nthoang: Set ChiTieuPhanTich.NhomChiTieu One to Many relation of the newly added ChiTieuPhanTich
                    ct_model.NhomChiTieu = target_nhomct;
                    db.ChiTieuPhanTiches.Add(ct_model);
                }
            }
            catch (InvalidOperationException e)
            {
                //nthoang: If NhomChiTieu Name is the new one
                var nhomct_new = new NhomChiTieu();
                nhomct_new.TenNhom = maubaogia_inp.NhomChiTieu;
                nhomct_new.ChiTieuPhanTiches = maubaogia_inp.ChiTieus.Select((item) =>
                    new ChiTieuPhanTich()
                    {
                        TenChiTieu = item.TenChiTieu,
                        ChiPhi = item.DonGia,
                        TenPhuongPhap = item.PhuongPhap
                    }
                ).ToList();
                db.NhomChiTieux.Add(nhomct_new);
            }
        }
    }
}