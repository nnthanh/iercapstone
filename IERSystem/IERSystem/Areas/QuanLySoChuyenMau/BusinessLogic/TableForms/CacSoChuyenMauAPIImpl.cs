using IERSystem.Areas.Administrator.Models;
using IERSystem.Areas.QuanLySoChuyenMau.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace IERSystem.BusinessLogic.TableForms
{
    public static partial class CacSoChuyenMauAPIImpl
    {
        public static async Task<IEnumerable<CacSoChuyenMauOutputModel>> CreateView(IERSystemModelContainer db)
        {
            var queried_async = await db.CacSoChuyenMaus.ToListAsync();
            return queried_async.Select((cacsochuyenmau_model) =>
            {
                return new CacSoChuyenMauOutputModel()
                {
                    //nthoang: QuyenSo should start from 1
                    QuyenSo = cacsochuyenmau_model.Id,
                    CreatedBy = cacsochuyenmau_model.CreatedBy,
                    TuNgay = cacsochuyenmau_model.TuNgay.ToShortDateString(),
                    DenNgay = cacsochuyenmau_model.DenNgay.ToShortDateString()
                };
            });
        }

        internal static void CreateModel(SoChuyenMauCreateInputModel cacsochuyenmau_inp, IERSystemModelContainer db)
        {
            db.CacSoChuyenMaus.Add(new CacSoChuyenMau()
            {
                UserId = cacsochuyenmau_inp.CreatedBy.Id,
                CreatedBy = cacsochuyenmau_inp.CreatedBy,
                CreatedDate = DateTime.Now,
                TuNgay = new DateTime(cacsochuyenmau_inp.Nam, cacsochuyenmau_inp.TuThang, 1),
                DenNgay = new DateTime(
                    cacsochuyenmau_inp.Nam, cacsochuyenmau_inp.DenThang, 
                    DateTime.DaysInMonth(cacsochuyenmau_inp.Nam, cacsochuyenmau_inp.DenThang))
            });
        }
    }
}