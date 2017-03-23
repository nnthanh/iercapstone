using IERSystem.Areas.Administrator.Models;
using IERSystem.BusinessLogic.TableForms;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace IERSystem.Areas.HopDongLayMau.Controllers
{
    public class DefaultController : Controller
    {
        private IERSystemModelContainer db = new IERSystemModelContainer();

        // GET: HopDongLayMau/Default
        public async Task<string> Index()
        {
            try {
                var test = Tests.HDLayMau_SNhanMauTest.CreateTest();
                HopDongLayMauAPIImpl.CreateModel(test[0], db);
                await db.SaveChangesAsync();
                Console.WriteLine("OK");
            } catch (System.Data.Entity.Infrastructure.DbUpdateException e) {
                Console.WriteLine(e.Message);
            } catch (DbEntityValidationException e) {
                Console.WriteLine(e.Message);
            }
            return "Hello World";
        }
    }
}