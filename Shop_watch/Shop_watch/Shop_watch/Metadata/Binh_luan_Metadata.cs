using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Shop_watch.Models
{
    [MetadataType(typeof(Binh_luan.Metadata))]
    public partial class Binh_luan
    {
        sealed class Metadata
        {
            [Display(Name = "ID bình luận")]
            public int Id_binh_luan { get; set; }
            [Display(Name = "ID sản phẩm")]
            public Nullable<int> Id_san_pham { get; set; }
            [Display(Name = "ID tài khoản khách hàng")]
            public Nullable<int> Id_tai_khoan_kh { get; set; }
            [Display(Name = "Nội dung")]
            [AllowHtml]
            [DataType(DataType.MultilineText)]
            public string Noi_dung { get; set; }
            [Display(Name = "Ngày tạo")]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}")]
            public Nullable<System.DateTime> Ngay_tao { get; set; }
            [Display(Name = "ID tài khoản admin")]
            public Nullable<int> Id_tai_khoan_Ad { get; set; }
            [Display(Name = "Trả lời bình luận")]
            [AllowHtml]
            [DataType(DataType.MultilineText)]
            public string Tra_loi_binh_luan { get; set; }
            [Display(Name = "Ngày cập nhật")]
            public Nullable<System.DateTime> Ngay_cap_nhat { get; set; }
        }
    }
}