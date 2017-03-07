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
        public static void CreateModel(YeuCauLayMauInputModel input_request, IERSystemModelContainer db)
        {
            var today_dep = DateTime.Now.Date;
            var encoded_inp_req = HopDongLayMauEncoding.Encode(input_request, db, today_dep);
            var yeucaulaymau_model = encoded_inp_req.ToModel(today_dep);
            db.PhieuYeuCaus.Add(yeucaulaymau_model);
        }

    }
}