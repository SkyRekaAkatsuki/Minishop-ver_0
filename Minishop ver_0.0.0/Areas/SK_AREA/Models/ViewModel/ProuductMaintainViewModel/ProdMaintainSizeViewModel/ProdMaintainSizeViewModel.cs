using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Minishop_ver_0._0._0.Areas.SK_AREA.Models.ViewModel.ProuductMaintainViewModel.ProdMaintainSizeViewModel
{
    public class ProdMaintainSizeViewModel
    {
        [DisplayName("商品編號")]
        public int ProductID { get; set; }

        [DisplayName("商品名稱")]
        public string ProductName { get; set; }

        public IEnumerable<List_for_ProdMaintainSizeViewModel> L_for_PMSVM { get; set; }
    }
}