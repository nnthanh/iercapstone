using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IERSystem.Areas.Administrator.Models;

namespace IERSystem.Areas.Administrator.Controllers
{
    public class UpsertDBResponse
    {
        public bool IsOK { get; set; }
        public string ErrMsg { get; set; }
    }

    public class UserController : Controller
    {
        private IERSystemModelContainer db = new IERSystemModelContainer();

        // GET: /Administrator/User/
        public async Task<ActionResult> Index()
        {
            var users = db.Users.Include(u => u.RoleMaster);
            return View(await users.ToListAsync());
        }

        // GET: /Administrator/User/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: /Administrator/User/Create
        public ActionResult Create()
        {
            ViewBag.RoleMasterId = new SelectList(db.RoleMasters, "Id", "RoleName");
            return View();
        }

        // POST: /Administrator/User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create([Bind(Include="Id,Username,Password,Phone,Fullname,RoleMasterId")] User user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Users.Add(user);
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.RoleMasterId = new SelectList(db.RoleMasters, "Id", "RoleName", user.RoleMasterId);
        //    return View(user);
        //}

        [HttpPost]
        public JsonResult Create(UserInputModel input_request)
        {
            //if (ModelState.IsValid) {
            var duplicate_exists = db.Users.Any((kh) =>
                    kh.Username.Equals(input_request.username)
                );
            
            try
            {
                if (!duplicate_exists)
                {
                    db.Users.Add(new User()
                    {
                        Username = input_request.username,
                        Password = input_request.password,
                        Phone = input_request.phone,
                        Fullname = input_request.fullname,
                        RoleMasterId = input_request.rolemasterid
                    });
                    db.SaveChanges();

                    Console.WriteLine("OK");
                    return Json(new UpsertDBResponse { IsOK = true, ErrMsg = "" });
                }
                else return Json(new UpsertDBResponse { IsOK = false, ErrMsg = "" });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Json(new UpsertDBResponse { IsOK = false, ErrMsg = "" });
            }

            //} else {
            //    return Json(new UpsertDBResponse { IsOK = false, ErrMsg = "" }); 
            //}
        }

        // GET: /Administrator/User/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleMasterId = new SelectList(db.RoleMasters, "Id", "RoleName", user.RoleMasterId);
            return View(user);
        }

        // POST: /Administrator/User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="Id,Username,Password,Phone,Fullname,RoleMasterId")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.RoleMasterId = new SelectList(db.RoleMasters, "Id", "RoleName", user.RoleMasterId);
            return View(user);
        }

        // GET: /Administrator/User/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: /Administrator/User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            User user = await db.Users.FindAsync(id);
            db.Users.Remove(user);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
