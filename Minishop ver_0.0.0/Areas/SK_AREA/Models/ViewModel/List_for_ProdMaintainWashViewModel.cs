using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Minishop_ver_0._0._0.Areas.SK_AREA.Models.ViewModel
{
    public class List_for_ProdMaintainWashViewModel
    {
        //ProductWashing Table
        [DisplayName("洗滌流水號")]
        public int ProductWashingID { get; set; }

        [DisplayName("商品")]
        public int ProductID { get; set; }

        [DisplayName("洗滌ID")]
        public int WashingID { get; set; }

        //Washing Table
        [DisplayName("洗滌方式")]
        public string WashingName { get; set; }
    }
}