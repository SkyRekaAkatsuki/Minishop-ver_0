using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Minishop_ver_0._0._0.Areas.SK_AREA.Models.ViewModel.ProuductMaintainViewModel.ProdMaintainPhotoViewModel
{
    public class ProdMaintainPhotoViewModel
    {
        [DisplayName("商品名稱")]
        public string ProductName { get; set; }

        [DisplayName("商品編號")]
        public int ProductID { get; set; }

        [DisplayName("照片編號'")]
        public int PhotoID { get; set; }

        [DisplayName("商品照片")]
        public byte[] Photo1 { get; set; }

        [DisplayName("創建時間")]
        public Nullable<System.DateTime> CreateDate { get; set; }

        public int ProductPhotoID { get; set; }
    }
}