using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Shop_watch.Models;

namespace Shop_watch.Controllers
{
    public class HomeController : Controller
    {
        private Shop_watchEntities db = new Shop_watchEntities();
        public ActionResult Index()
        {
            ViewBag.ListImage = db.San_pham.Where(n => n.Trang_thai == 1);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Blog()
        {
            ViewBag.ListImage = db.Tin_tuc.Where(n => n.Trang_thai == 1);
            return View();
        }
        public ActionResult Cart()
        {
            ViewBag.Message = "Your cart page.";
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Tai_khoan_Kh t)
        {
            var use = db.Tai_khoan_Kh.Where(n => n.Email == t.Email && n.Mat_khau == t.Mat_khau && n.Trang_thai == 1).FirstOrDefault();
            if(use != null)
            {
                Session["Id_use"] = use.Id_Tai_khoan_kh;
                Session["Ten"] = use.Ho_ten;
                Session["gioitinh"] = use.Gioi_tinh;
                Session["ngaysinh"] = use.Ngay_sinh;
                Session["diachi"] = use.Dia_chi;
                Session["email"] = use.Email;
                Session["sdt"] = use.So_dien_thoai;
                Session["ha"] = use.Hinh_anh;
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult product()
        {
            ViewBag.ListImage = db.San_pham.Where(n =>n.Loai_san_pham == 1 && n.Trang_thai == 1);
            return View();
        }
        public ActionResult xemgiohang()
        {
            if (Session["Id_use"] == null)
            {
                return RedirectToAction("Login");
            }
            int Id = Int32.Parse(Session["Id_use"].ToString());
            ViewBag.ListImage = db.Don_hang.Where(n => n.Id_tai_khoan_Kh == Id && n.Trang_thai == 1).ToList();
            return View();
        }

        public ActionResult DatHang(int id)
        {
            Don_hang don = db.Don_hang.Find(id);
            int Id_Tai_khoan_kh = don.Id_tai_khoan_Kh.Value; // value  là lấy ra giá trị
            ViewBag.Ho_ten = db.Tai_khoan_Kh.Where(n => n.Id_Tai_khoan_kh == Id_Tai_khoan_kh).ToList();
            return View(don);
        }
        [HttpPost]
        public ActionResult DatHang(Don_hang don)
        {
            if (ModelState.IsValid)
            {
                don.Trang_thai = 2;
                db.Entry(don).State = EntityState.Modified; //Xác nhận cập lại số lượng đơn hàng
                db.SaveChanges();
                return RedirectToAction("xemgiohang");
            }
            return View();
        }
        [HttpPost]
        public ActionResult CapNhatSoLuong(Don_hang don_Hang)
        {
            if (ModelState.IsValid)
            {
                int id = don_Hang.Id_san_pham.Value;
                var tongTien = db.San_pham.Where(n => n.Id_san_pham == id).FirstOrDefault();
                if(tongTien.Gia_sale == 0)
                {
                    don_Hang.Thanh_tien = tongTien.Gia_goc * don_Hang.So_luong;
                }
                else
                {
                    if(tongTien.Gia_sale != 0)
                    {
                        don_Hang.Thanh_tien = tongTien.Gia_sale * don_Hang.So_luong;
                    }
                }
                db.Entry(don_Hang).State = EntityState.Modified; //Xác nhận cập lại số lượng đơn hàng
                db.SaveChanges();
                return RedirectToAction("xemgiohang");
            }
            return View(don_Hang);
        }
        public ActionResult XoaDonHang(int id)
        {
            Don_hang don_hang = db.Don_hang.Find(id);
            db.Don_hang.Remove(don_hang);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult themVaoGio(int Id, Don_hang don_Hang)
        {
            if (Session["Id_use"] == null)
            {
                return RedirectToAction("Login");
            }
            don_Hang.Id_san_pham = Id;
            don_Hang.Id_tai_khoan_Kh = Convert.ToInt32(Session["Id_use"]);
            don_Hang.So_luong = 1;
            don_Hang.Trang_thai = 1;
            don_Hang.Ngay_tao = DateTime.Now;
            var TongTien = db.San_pham.Where(n => n.Id_san_pham == Id).FirstOrDefault();
            if (TongTien.Gia_sale == 0)
            {
                don_Hang.Thanh_tien = TongTien.Gia_goc * don_Hang.So_luong;
            }
            else
            {
                if (TongTien.Gia_sale != 0)
                {
                    don_Hang.Thanh_tien = TongTien.Gia_sale * don_Hang.So_luong;
                }
            }
            db.Don_hang.Add(don_Hang);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult baby_g()
        {
            ViewBag.ListImage = db.San_pham.Where(n => n.Loai_san_pham == 2 && n.Trang_thai == 1);
            ViewBag.Message = "Your category page.";

            return View();
        }
        public ActionResult saleWatch()
        {
            ViewBag.Wsales = db.San_pham.Where(n => n.Gia_sale != 0 && n.Trang_thai == 1);
            return View();
        }
         public ActionResult single_blog()
        {
            ViewBag.ListImage = db.Tin_tuc.Where(n => n.Trang_thai == 1);
            return View();
        }
        public ActionResult single_product(int id)
        {
            ViewBag.binhLuan = db.Binh_luan.Where(n=>n.Id_san_pham==id).ToList();
            San_pham san_Pham = db.San_pham.Find(id);
            return View(san_Pham);
        }
        //public ActionResult product_sale()
        //{
        //    ViewBag.ListImage = db.San_pham.Where(n => n.Gia_sale==0);
        //    ViewBag.Message = "Your category page.";

        //    return View(); 
        //}
        [HttpPost]
        public ActionResult BinhLuan(int id,Binh_luan cmt)
        {
            if (Session["Id_use"] == null)
            {
                return RedirectToAction("Login");
            }
            cmt.Id_san_pham = id;
            cmt.Id_tai_khoan_kh = Convert.ToInt32(Session["Id_use"]);
            cmt.Ngay_tao = DateTime.Now;
            db.Binh_luan.Add(cmt);
            db.SaveChanges();
            return RedirectToAction("/single_product/" + id);
        }
        // cái này là HttpGet: nó sẽ hiển thị lên cho người dùng xem
        public ActionResult DangKyTKKH()
        {
            return View();
        }
        //HttpPost nghĩa là chúng ta sẽ xử lý các nghiệp vụ lưu tài khoản ở cái này.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangKyTKKH([Bind(Include = "Id_Tai_khoan_kh,Ho_ten,Gioi_tinh,Ngay_sinh,Dia_chi,Email,So_dien_thoai,Hinh_anh,Nguoi_cap_nhat,Ngay_cap_nhat,Trang_thai,Mat_khau")] Tai_khoan_Kh tai_khoan_Kh)
        {
            if (ModelState.IsValid)
            {
                tai_khoan_Kh.Ngay_cap_nhat = DateTime.Now;
                tai_khoan_Kh.Trang_thai = 1;
                db.Tai_khoan_Kh.Add(tai_khoan_Kh);
                db.SaveChanges();
                return RedirectToAction("Login");
            }

            return View(tai_khoan_Kh);
        }
        
        public ActionResult QlyDonHang()
        {
            if (Session["Id_use"] == null)
            {
                return RedirectToAction("Login");
            }
            int idKH = Int32.Parse(Session["Id_use"].ToString());
            var lstDonHang = db.Don_hang.Where(n => n.Id_tai_khoan_Kh == idKH && n.Trang_thai !=1).ToList();
            return View(lstDonHang);
        }
        public ActionResult XemTTKH()
        {
            ViewBag.idKH = Int32.Parse(Session["Id_use"].ToString());
            ViewBag.ten = Session["Ten"].ToString();
            ViewBag.gioitinh = Session["gioitinh"].ToString();
            ViewBag.diachi = Session["diachi"].ToString();
            ViewBag.email = Session["email"].ToString();
            ViewBag.sdt = Session["sdt"].ToString();
            ViewBag.HinhAnh = Session["ha"].ToString();
            ViewBag.ngaysinh = Session["ngaysinh"];
            return View();
        }
        public ActionResult CapNhatTT(int id)
        {
            Tai_khoan_Kh tai_Khoan_Kh = db.Tai_khoan_Kh.Find(id);
            return View(tai_Khoan_Kh);
        }
        [HttpPost]
        public ActionResult CapNhatTT( [Bind(Include = "Id_Tai_khoan_kh,Ho_ten,Gioi_tinh,Ngay_sinh,Dia_chi,Email,So_dien_thoai,Hinh_anh,Nguoi_cap_nhat,Ngay_cap_nhat,Trang_thai,Mat_khau")] Tai_khoan_Kh tai_khoan_Kh)
        {
            if(ModelState.IsValid)
            {
                tai_khoan_Kh.Ngay_cap_nhat = DateTime.Now;
                tai_khoan_Kh.Nguoi_cap_nhat = Session["Email"].ToString();
                db.Entry(tai_khoan_Kh).State = EntityState.Modified;
                db.SaveChanges();
                if(tai_khoan_Kh.Trang_thai==2)
                {
                    return View("Login");
                }
                return RedirectToAction("Index");
            }
            return View(tai_khoan_Kh);
        }
    }
}