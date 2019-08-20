using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Minishop_ver_0._0._0.Areas.SK_AREA.Models.ViewModel
{
    public class ProdMaintainWashViewModel
    {
        [DisplayName("產品ID")]
        public int ProductID { get; set; }

        [DisplayName("產品名稱")]
        public string ProductName { get; set; }

        public IEnumerable<List_for_ProdMaintainWashViewModel> L_for_PMWVM { get; set; }
    }
}