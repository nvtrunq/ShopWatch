using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Shop_watch.Models
{
    [MetadataType(typeof(Tai_khoan_Kh.Metadata))]
    public partial class Tai_khoan_Kh
    {
        sealed class Metadata
        {
            [Display(Name ="ID tài khoản khách hàng")]
            public int Id_Tai_khoan_kh { get; set; }
            [Display(Name = "Họ và tên")]
            [Required(ErrorMessage ="Họ và tên không được để trống")]
            public string Ho_ten { get; set; }
            [Display(Name = "Giới tính")]
            [Required(ErrorMessage ="Giới tính không được để trống")]
            public byte Gioi_tinh { get; set; }
            [Display(Name = "Ngày sinh")]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
            [DataType(DataType.Date)]
            public Nullable<System.DateTime> Ngay_sinh { get; set; }
            [Display(Name = "Địa chỉ")]
            public string Dia_chi { get; set; }
            [Display(Name = "Email")]
            [Required(ErrorMessage = "Email không được để trống")]
            public string Email { get; set; }
            [Display(Name = "Số điện thoại")]
            [Required(ErrorMessage = "Số điện thoại không được để trống")]
            public int So_dien_thoai { get; set; }
            [Display(Name = "Hình ảnh")]
            public string Hinh_anh { get; set; }
            [Display(Name = "Người cập nhật")]
            public string Nguoi_cap_nhat { get; set; }
            [Display(Name = "Ngày cập nhật")]
            public Nullable<System.DateTime> Ngay_cap_nhat { get; set; }
            [Display(Name = "Trạng thái")]
            public Nullable<byte> Trang_thai { get; set; }
            [Display(Name = "Mật khẩu")]
            [DataType(DataType.Password)]
            [Required(ErrorMessage = "Mật khẩu không được để trống")]
            public string Mat_khau { get; set; }
        }
    }
}