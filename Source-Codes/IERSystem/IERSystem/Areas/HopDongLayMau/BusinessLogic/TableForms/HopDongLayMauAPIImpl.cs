using IERSystem.Areas.Administrator.Models;
using IERSystem.Areas.HopDongLayMau.Models;
using System;
using System.Collections.Generic;
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
        //nthoang: Table Parsing using YeuCauLayMau Input here
        public static void Create(YeuCauLayMauInputModel input_request, IERSystemDBContext db) {
            upsertHopDongLayMau(input_request, db);
            TableForms.CacSoNhanMauAPIImpl.Create(input_request, db);
            TableForms.CacSoChuyenMauAPIImpl.Create(input_request, db);
            
        }

        private static void upsertHopDongLayMau(YeuCauLayMauInputModel input_request, IERSystemDBContext db) {
            var encoded_inp_req = HopDongLayMauEncoding.Encode(input_request, db);
            var yeucaulaymau_model = encoded_inp_req.ToModel();
            db.PhieuYeuCaus.Add(yeucaulaymau_model);
        }
    }
}