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
    public class Binh_luanController : Controller
    {
        private Shop_watchEntities db = new Shop_watchEntities();

        // GET: Admin/Binh_luan
        public ActionResult Index()
        {
            var binh_luan = db.Binh_luan.Include(b => b.San_pham);
            return View(binh_luan.ToList());
        }

        // GET: Admin/Binh_luan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Binh_luan binh_luan = db.Binh_luan.Find(id);
            if (binh_luan == null)
            {
                return HttpNotFound();
            }
            return View(binh_luan);
        }

        // GET: Admin/Binh_luan/Create
        public ActionResult Create()
        {
            ViewBag.Id_san_pham = new SelectList(db.San_pham, "Id_san_pham", "Ten_san_pham");
            return View();
        }

        // POST: Admin/Binh_luan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_binh_luan,Id_san_pham,Id_tai_khoan_kh,Noi_dung,Ngay_tao,Id_tai_khoan_Ad,Tra_loi_binh_luan,Ngay_cap_nhat")] Binh_luan binh_luan)
        {
            if (ModelState.IsValid)
            {
                db.Binh_luan.Add(binh_luan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_san_pham = new SelectList(db.San_pham, "Id_san_pham", "Ten_san_pham", binh_luan.Id_san_pham);
            return View(binh_luan);
        }

        // GET: Admin/Binh_luan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Binh_luan binh_luan = db.Binh_luan.Find(id);
            if (binh_luan == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_san_pham = new SelectList(db.San_pham, "Id_san_pham", "Ten_san_pham", binh_luan.Id_san_pham);
            return View(binh_luan);
        }

        // POST: Admin/Binh_luan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_binh_luan,Id_san_pham,Id_tai_khoan_kh,Noi_dung,Ngay_tao,Id_tai_khoan_Ad,Tra_loi_binh_luan,Ngay_cap_nhat")] Binh_luan binh_luan)
        {
            if (ModelState.IsValid)
            {
                binh_luan.Ngay_cap_nhat = DateTime.Now;
                binh_luan.Id_tai_khoan_Ad = Convert.ToInt32(Session["IdUser"]);
                db.Entry(binh_luan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_san_pham = new SelectList(db.San_pham, "Id_san_pham", "Ten_san_pham", binh_luan.Id_san_pham);
            return View(binh_luan);
        }

        // GET: Admin/Binh_luan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Binh_luan binh_luan = db.Binh_luan.Find(id);
            if (binh_luan == null)
            {
                return HttpNotFound();
            }
            return View(binh_luan);
        }

        // POST: Admin/Binh_luan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Binh_luan binh_luan = db.Binh_luan.Find(id);
            db.Binh_luan.Remove(binh_luan);
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
