using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Shop_watch.Models;

namespace Shop_watch.Areas.Admin.Controllers
{
    public class Tin_tucController : Controller
    {
        private Shop_watchEntities db = new Shop_watchEntities();

        // GET: Admin/Tin_tuc
        public ActionResult Index()
        {
            return View(db.Tin_tuc.ToList());
        }

        // GET: Admin/Tin_tuc/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tin_tuc tin_tuc = db.Tin_tuc.Find(id);
            if (tin_tuc == null)
            {
                return HttpNotFound();
            }
            return View(tin_tuc);
        }

        // GET: Admin/Tin_tuc/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Tin_tuc/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Tintuc,Ten_tin_tuc,Noi_dung,Hinh_anh,Nguoi_cap_nhat,Ngay_Cap_nhat,Chu_thich,Trang_thai")] Tin_tuc tin_tuc)
        {
            if (ModelState.IsValid)
            {
                tin_tuc.Ngay_Cap_nhat = DateTime.Now;
                db.Tin_tuc.Add(tin_tuc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tin_tuc);
        }

        // GET: Admin/Tin_tuc/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tin_tuc tin_tuc = db.Tin_tuc.Find(id);
            if (tin_tuc == null)
            {
                return HttpNotFound();
            }
            return View(tin_tuc);
        }

        // POST: Admin/Tin_tuc/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Tintuc,Ten_tin_tuc,Noi_dung,Hinh_anh,Nguoi_cap_nhat,Ngay_Cap_nhat,Chu_thich,Trang_thai")] Tin_tuc tin_tuc)
        {
            if (ModelState.IsValid)
            {
                tin_tuc.Nguoi_cap_nhat = "Trung";
                tin_tuc.Trang_thai = 1;
                tin_tuc.Ngay_Cap_nhat = DateTime.Now;
                db.Entry(tin_tuc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tin_tuc);
        }

        // GET: Admin/Tin_tuc/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tin_tuc tin_tuc = db.Tin_tuc.Find(id);
            if (tin_tuc == null)
            {
                return HttpNotFound();
            }
            return View(tin_tuc);
        }

        // POST: Admin/Tin_tuc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tin_tuc tin_tuc = db.Tin_tuc.Find(id);
            db.Tin_tuc.Remove(tin_tuc);
            db.SaveChanges();
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
