using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Minishop_ver_0._0._0.Areas.SK_AREA.Models.ViewModel.ProuductMaintainViewModel.ProdMaintainSizeViewModel
{

    public class List_for_ProdMaintainSizeViewModel
    {
        [DisplayName("產品尺寸序列號")]
        public int ProductSizeID { get; set; }

        [DisplayName("尺寸序列號")]
        public int SizeID { get; set; }

        [DisplayName("尺寸大小")]
        public string SizeName { get; set; }
    }
}