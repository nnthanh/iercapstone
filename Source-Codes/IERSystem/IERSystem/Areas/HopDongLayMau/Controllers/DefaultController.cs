using IERSystem.Areas.Administrator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace IERSystem.Areas.HopDongLayMau.Controllers
{
    public class DefaultController : Controller
    {
        private IERSystemDBContext db = new IERSystemDBContext();

        // GET: HopDongLayMau/Default
        public async Task<string> Index()
        {
            try {
                var test = Tests.HDLayMau_SNhanMauTest.CreateTest();
                BusinessLogic.HopDongLayMauAPIImpl.Create(test[0], db);
                await db.SaveChangesAsync();
                Console.WriteLine("OK");
            } catch (System.Data.Entity.Infrastructure.DbUpdateException e) {
                Console.WriteLine(e.Message);
            }
            return "Hello World";
        }
    }
}