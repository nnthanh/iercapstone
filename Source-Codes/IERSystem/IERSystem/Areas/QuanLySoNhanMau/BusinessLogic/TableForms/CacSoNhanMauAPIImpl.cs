using IERSystem.Areas.Administrator.Models;
using IERSystem.Areas.QuanLySoNhanMau.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace IERSystem.BusinessLogic.TableForms
{
    public static partial class CacSoNhanMauAPIImpl
    {
        public static void CreateModel(SoNhanMauCreateInputModel input_request, IERSystemModelContainer db)
        {
            db.CacSoNhanMaus.Add(new CacSoNhanMau()
            {
                TuNgay = new DateTime(input_request.Nam, input_request.TuThang, 1),
                DenNgay = new DateTime(input_request.Nam, input_request.DenThang, 
                    DateTime.DaysInMonth(input_request.Nam, input_request.DenThang))
            });
        }

        public static async Task<IEnumerable<CacSoNhanMauOutputModel>> CreateView(IERSystemModelContainer db)
        {
            var queried_async = await db.CacSoNhanMaus.ToListAsync();
            return queried_async.Select((cacsonhanmau_model, index) =>
            {
                return new CacSoNhanMauOutputModel()
                {
                    //nthoang: QuyenSo should start from 1
                    QuyenSo = index + 1,
                    TuNgay = cacsonhanmau_model.TuNgay.ToShortDateString(),
                    DenNgay = cacsonhanmau_model.DenNgay.ToShortDateString()
                };
            });
        }

    }
}