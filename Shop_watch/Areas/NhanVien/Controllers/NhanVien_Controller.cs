using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop_watch.Models;

namespace Shop_watch.Areas.NhanVien.Controllers
{
    public class NhanVien_Controller : Controller
    {
        private Shop_watchEntities db = new Shop_watchEntities();
        // GET: Admin/Home_Login_
        public ActionResult Index()
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("login", "Home_admin_");
            }
            return View();
        }
        public ActionResult login(Tai_khoan_Ad t)
        {
            var dataUser = db.Tai_khoan_Ad.Where(n => n.Email == t.Email && n.Mat_khau == t.Mat_khau && n.Trang_thai == 1).FirstOrDefault();
            {
                if (dataUser != null)
                {
                    Session["TenNguoiDang"] = dataUser.Ho_ten;
                    Session["NguoiDang"] = dataUser.Email;
                    Session["User"] = dataUser;
                    return RedirectToAction("Index", "San_pham_");
                }

                else
                {
                    if (db.Tai_khoan_Ad.Where(n => n.Email == t.Email && n.Mat_khau != t.Mat_khau && n.Trang_thai == 1).FirstOrDefault() != null)
                    {
                        ViewBag.Error = "mật khẩu không đúng";
                    }
                    else
                    {
                        if (db.Tai_khoan_Ad.Where(n => n.Email == t.Email && n.Mat_khau == t.Mat_khau && n.Trang_thai != 1).FirstOrDefault() != null)
                        {
                            ViewBag.Error = "Rất tiếc, tài khoản của bạn đã hết hạn sử dụng";
                        }
                        else
                        {
                            ViewBag.Error = "Bạn chưa có tài khoản";
                        }
                    }
                }
                return View();
            }

        }
    }
}