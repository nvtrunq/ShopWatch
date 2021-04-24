using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Shop_watch.Models
{
    [MetadataType(typeof(San_pham.Metadata))]
    public partial class San_pham
    {
        sealed class Metadata
        {
            [Display(Name ="ID sản phẩm")]
            public int Id_san_pham { get; set; }
            [Display(Name = "Tên sản phẩm")]
            [Required(ErrorMessage ="Tên sản phẩm không được để trống")]
            public string Ten_san_pham { get; set; }
            [Display(Name = "Hình ảnh")]
            public string Hinh_anh { get; set; }
            [Display(Name = "Loại sản phẩm")]
            public Nullable<byte> Loai_san_pham { get; set; }
            [Display(Name = "Giá gốc")]
            [Required(ErrorMessage ="Giá sản phẩm không được để trống")]
            public int Gia_goc { get; set; }
            [Display(Name = "Giá Sale")]
            public Nullable<int> Gia_sale { get; set; }
            [Display(Name = "Số lượng")]
            public Nullable<int> So_luong { get; set; }
            [Display(Name = "Người cập nhật")]
            public string Nguoi_cap_nhat { get; set; }
            [Display(Name = "Ngày cập nhật")]
            [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy HH:mm:ss}")]
            public Nullable<System.DateTime> Ngay_Cap_nhat { get; set; }
            [Display(Name = "Mô tả ngắn")]
            [AllowHtml]
            [DataType(DataType.MultilineText)]
            public string Mo_ta_ngan { get; set; }
            [Display(Name = "Mô tả dài")]
            [AllowHtml]
            [DataType(DataType.MultilineText)]
            public string Mo_ta_dai { get; set; }
            [Display(Name = "Chú thích")]
            [AllowHtml]
            [DataType(DataType.MultilineText)]
            public string Chu_thich { get; set; }
            [Display(Name = "Trạng thái")]
            public Nullable<byte> Trang_thai { get; set; }
        }
    }
}