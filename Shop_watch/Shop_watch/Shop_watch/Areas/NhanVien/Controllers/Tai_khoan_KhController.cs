using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Shop_watch.Models;

namespace Shop_watch.Areas.NhanVien.Controllers
{
    public class Tai_khoan_KhController : Controller
    {
        private Shop_watchEntities db = new Shop_watchEntities();

        // GET: NhanVien/Tai_khoan_Kh
        public ActionResult Index()
        {
            return View(db.Tai_khoan_Kh.ToList());
        }

        // GET: NhanVien/Tai_khoan_Kh/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tai_khoan_Kh tai_khoan_Kh = db.Tai_khoan_Kh.Find(id);
            if (tai_khoan_Kh == null)
            {
                return HttpNotFound();
            }
            return View(tai_khoan_Kh);
        }

        // GET: NhanVien/Tai_khoan_Kh/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NhanVien/Tai_khoan_Kh/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Tai_khoan_kh,Ho_ten,Gioi_tinh,Ngay_sinh,Dia_chi,Email,So_dien_thoai,Hinh_anh,Nguoi_cap_nhat,Ngay_cap_nhat,Trang_thai,Mat_khau")] Tai_khoan_Kh tai_khoan_Kh)
        {
            if (ModelState.IsValid)
            {
                tai_khoan_Kh.Ngay_cap_nhat = DateTime.Now;
                tai_khoan_Kh.Trang_thai = 1;
                db.Tai_khoan_Kh.Add(tai_khoan_Kh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tai_khoan_Kh);
        }

        // GET: NhanVien/Tai_khoan_Kh/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tai_khoan_Kh tai_khoan_Kh = db.Tai_khoan_Kh.Find(id);
            if (tai_khoan_Kh == null)
            {
                return HttpNotFound();
            }
            return View(tai_khoan_Kh);
        }

        // POST: NhanVien/Tai_khoan_Kh/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Tai_khoan_kh,Ho_ten,Gioi_tinh,Ngay_sinh,Dia_chi,Email,So_dien_thoai,Hinh_anh,Nguoi_cap_nhat,Ngay_cap_nhat,Trang_thai,Mat_khau")] Tai_khoan_Kh tai_khoan_Kh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tai_khoan_Kh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tai_khoan_Kh);
        }

        // GET: NhanVien/Tai_khoan_Kh/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tai_khoan_Kh tai_khoan_Kh = db.Tai_khoan_Kh.Find(id);
            if (tai_khoan_Kh == null)
            {
                return HttpNotFound();
            }
            return View(tai_khoan_Kh);
        }

        // POST: NhanVien/Tai_khoan_Kh/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tai_khoan_Kh tai_khoan_Kh = db.Tai_khoan_Kh.Find(id);
            db.Tai_khoan_Kh.Remove(tai_khoan_Kh);
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
