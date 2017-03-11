using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IERSystem.Areas.QuanLyKetQuaPhanTich.Controllers
{
    public class FormKQController : Controller
    {
        // GET: QuanLyKetQuaPhanTich/FormKQ
        public ActionResult Index()
        {
            return View();
        }

        // GET: QuanLyKetQuaPhanTich/FormKQ/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: QuanLyKetQuaPhanTich/FormKQ/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuanLyKetQuaPhanTich/FormKQ/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: QuanLyKetQuaPhanTich/FormKQ/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: QuanLyKetQuaPhanTich/FormKQ/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: QuanLyKetQuaPhanTich/FormKQ/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: QuanLyKetQuaPhanTich/FormKQ/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
