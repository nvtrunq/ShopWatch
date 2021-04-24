using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Shop_watch.Models
{
    [MetadataType(typeof(Tin_tuc.Metadata))]
    public partial class Tin_tuc
    {
        sealed class Metadata
        {
            [Display(Name ="ID tin tức")]
            public int Id_Tintuc { get; set; }
            [Display(Name = "Tên tin tức")]
            [Required(ErrorMessage ="Tên tin tức không được để trống")]
            public string Ten_tin_tuc { get; set; }
            [Display(Name = "Nội dung")]
            [AllowHtml]
            [DataType(DataType.MultilineText)]
            [Required(ErrorMessage ="Nội dung tin tức không được để trống")]
            public string Noi_dung { get; set; }
            [Display(Name = "Hình ảnh")]
            public string Hinh_anh { get; set; }
            [Display(Name = "Người cập nhật")]
            public string Nguoi_cap_nhat { get; set; }
            [Display(Name = "Ngày cập nhật")]
            public Nullable<System.DateTime> Ngay_Cap_nhat { get; set; }
            [Display(Name = "Chú thích")]
            [AllowHtml]
            [DataType(DataType.MultilineText)]
            public string Chu_thich { get; set; }
            [Display(Name = "Trạng thái")]
            public Nullable<byte> Trang_thai { get; set; }
        }
    }
}