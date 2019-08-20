using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Minishop_ver_0._0._0.Areas.SK_AREA.Models.ViewModel
{
    public class ProductMaintainViewModel
    {
        [DisplayName("產品ID")]
        public int ProductID { get; set; }

        public Nullable<int> PhotoID { get; set; }

        [DisplayName("產品圖示")]
        public byte[] Photo1 { get; set; }

        [DisplayName("產品名稱")]
        public string ProductName { get; set; }

        [DisplayName("產品描述")]
        public string Desctiption { get; set; }

        public int ColorID { get; set; }
        public int CategoryMID { get; set; }
        public string CategoryMName { get; set; }

        [DisplayName("分類")]
        public int CategorySID { get; set; }
        public string CategorySName { get; set; }

        [DisplayName("分類名稱")]
        public string CategroyMSName { get; set; }

        [DisplayName("供應商")]
        public int SupplierID { get; set; }

        [DisplayName("供應商")]
        public string SupplierName { get; set; }

        [DisplayName("單價")]
        [DisplayFormat(DataFormatString = "{0:C2}",ApplyFormatInEditMode = true)]
        public int UnitPrice { get; set; }

        [DisplayName("上架日期")]
        [DataType(DataType.Date)] //會有月曆
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> ProductInDate { get; set; }

        [DisplayName("下架日期")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> ProductOutDate { get; set; }
    }
}