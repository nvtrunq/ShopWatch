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
    public class Don_hangController : Controller
    {
        private Shop_watchEntities db = new Shop_watchEntities();

        // GET: Admin/Don_hang
        public ActionResult Index()
        {
            return View(db.Don_hang.ToList());
        }

        // GET: Admin/Don_hang/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Don_hang don_hang = db.Don_hang.Find(id);
            if (don_hang == null)
            {
                return HttpNotFound();
            }
            return View(don_hang);
        }

        // GET: Admin/Don_hang/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Don_hang/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_don_hang,Id_san_pham,Id_tai_khoan_Kh,Thanh_tien,Trang_thai,So_luong,Ngay_tao,Id_nguoi_cap_nhat,Ngay_cap_nhat,Chu_thich")] Don_hang don_hang)
        {
            if (ModelState.IsValid)
            {
                db.Don_hang.Add(don_hang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(don_hang);
        }

        // GET: Admin/Don_hang/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Don_hang don_hang = db.Don_hang.Find(id);
            if (don_hang == null)
            {
                return HttpNotFound();
            }
            return View(don_hang);
        }

        // POST: Admin/Don_hang/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_don_hang,Id_san_pham,Id_tai_khoan_Kh,Thanh_tien,Trang_thai,So_luong,Ngay_tao,Id_nguoi_cap_nhat,Ngay_cap_nhat,Chu_thich")] Don_hang don_hang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(don_hang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(don_hang);
        }

        // GET: Admin/Don_hang/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Don_hang don_hang = db.Don_hang.Find(id);
            if (don_hang == null)
            {
                return HttpNotFound();
            }
            return View(don_hang);
        }

        // POST: Admin/Don_hang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Don_hang don_hang = db.Don_hang.Find(id);
            db.Don_hang.Remove(don_hang);
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
