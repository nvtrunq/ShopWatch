using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Shop_watch.Models;

namespace Shop_watch.KhachHang.Controllers
{
    public class Tai_khoan_KhachhangController : Controller
    {
        private Shop_watchEntities db = new Shop_watchEntities();

        // GET: Tai_khoan_Khachhang
        public ActionResult Index()
        {
            return View(db.Tai_khoan_Kh.ToList());
        }

        // GET: Tai_khoan_Khachhang/Details/5
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

        // GET: Tai_khoan_Khachhang/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tai_khoan_Khachhang/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Tai_khoan_kh,Ho_ten,Gioi_tinh,Ngay_sinh,Dia_chi,Email,So_dien_thoai,Hinh_anh,Nguoi_cap_nhat,Ngay_cap_nhat,Trang_thai,Mat_khau")] Tai_khoan_Kh tai_khoan_Kh)
        {
            if (ModelState.IsValid)
            {
                db.Tai_khoan_Kh.Add(tai_khoan_Kh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tai_khoan_Kh);
        }

        // GET: Tai_khoan_Khachhang/Edit/5
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

        // POST: Tai_khoan_Khachhang/Edit/5
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

        // GET: Tai_khoan_Khachhang/Delete/5
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

        // POST: Tai_khoan_Khachhang/Delete/5
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
        [HttpPost]
        public ActionResult QuanLyDHKH(int id)
        {
            Don_hang don = db.Don_hang.Find(id);
            int Id_Tai_khoan_kh = don.Id_tai_khoan_Kh.Value; // value  là lấy ra giá trị
            ViewBag.Ho_ten = db.Tai_khoan_Kh.Where(n => n.Id_Tai_khoan_kh == Id_Tai_khoan_kh).ToList();
            return View(don);
        }
        public ActionResult QuanLyDHKH(Don_hang don)
        {
            if (ModelState.IsValid)
            {
                don.Trang_thai = 2;
                db.Entry(don).State = EntityState.Modified; //Xác nhận cập lại số lượng đơn hàng
                db.SaveChanges();
                return RedirectToAction("QuanLyDHKH");
            }
            return View();
        }
    }
}
