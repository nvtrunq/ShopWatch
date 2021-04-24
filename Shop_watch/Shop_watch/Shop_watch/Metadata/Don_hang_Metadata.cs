using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Shop_watch.Models
{
    [MetadataType(typeof(Don_hang.Metadata))]
    public partial class Don_hang
    {
        sealed class Metadata
        {
            [Display(Name ="ID đơn hàng")]
            public int Id_don_hang { get; set; }
            [Display(Name = "ID sản phẩm")]
            public Nullable<int> Id_san_pham { get; set; }
            [Display(Name = "ID tài khoản khách hàng")]
            public Nullable<int> Id_tai_khoan_Kh { get; set; }
            [Display(Name = "Thành tiền")]
            public Nullable<decimal> Thanh_tien { get; set; }
            [Display(Name = "Trạng thái")]
            public Nullable<byte> Trang_thai { get; set; }
            [Display(Name = "Số lượng")]
            public Nullable<int> So_luong { get; set; }
            [Display(Name = "Ngày tạo")]
            public Nullable<System.DateTime> Ngay_tao { get; set; }
            [Display(Name = "ID người cập nhật")]
            public Nullable<int> Id_nguoi_cap_nhat { get; set; }
            [Display(Name = "Ngày cập nhật")]
            [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy HH:mm:ss}")]
            public Nullable<System.DateTime> Ngay_cap_nhat { get; set; }
            [Display(Name = "Chú thích")]
            [DataType(DataType.MultilineText)]
            [AllowHtml]
            public string Chu_thich { get; set; }
        }
    }
}