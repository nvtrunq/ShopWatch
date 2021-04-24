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
    public class San_pham_Controller : Controller
    {
        private Shop_watchEntities db = new Shop_watchEntities();

        // GET: Admin/San_pham_
        public ActionResult Index()
        {

            if (Session["User"] == null)
            {
                return RedirectToAction("login", "Home_admin_");
            }
            return View(db.San_pham.ToList());
        }

        // GET: Admin/San_pham_/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            San_pham san_pham = db.San_pham.Find(id);
            if (san_pham == null)
            {
                return HttpNotFound();
            }
            return View(san_pham);
        }

        // GET: Admin/San_pham_/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/San_pham_/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_san_pham,Ten_san_pham,Hinh_anh,Loai_san_pham,Gia_goc,Gia_sale,So_luong,Nguoi_cap_nhat,Ngay_Cap_nhat,Mo_ta_ngan,Mo_ta_dai,Chu_thich,Trang_thai")] San_pham san_pham)
        {
            if (ModelState.IsValid)
            {
                if (san_pham.Gia_sale == null)
                {
                    san_pham.Gia_sale = 0;
                }
                san_pham.Trang_thai = 1;
                san_pham.Nguoi_cap_nhat = Session["NguoiDang"].ToString();
                san_pham.Ngay_Cap_nhat = DateTime.Now;
                db.San_pham.Add(san_pham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(san_pham);
        }

        // GET: Admin/San_pham_/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            San_pham san_pham = db.San_pham.Find(id);
            if (san_pham == null)
            {
                return HttpNotFound();
            }
            return View(san_pham);
        }

        // POST: Admin/San_pham_/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_san_pham,Ten_san_pham,Hinh_anh,Loai_san_pham,Gia_goc,Gia_sale,So_luong,Nguoi_cap_nhat,Ngay_Cap_nhat,Mo_ta_ngan,Mo_ta_dai,Chu_thich,Trang_thai")] San_pham san_pham)
        {
            if (ModelState.IsValid)
            {
                san_pham.Nguoi_cap_nhat= Session["NguoiDang"].ToString();
                db.Entry(san_pham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(san_pham);
        }

        // GET: Admin/San_pham_/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            San_pham san_pham = db.San_pham.Find(id);
            if (san_pham == null)
            {
                return HttpNotFound();
            }
            return View(san_pham);
        }

        // POST: Admin/San_pham_/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            San_pham san_pham = db.San_pham.Find(id);
            db.San_pham.Remove(san_pham);
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
