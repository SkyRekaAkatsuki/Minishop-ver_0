using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Minishop_ver_0._0._0.Areas.SK_AREA.Models.Partial
{
    [MetadataType(typeof(ProductMetadata))]
    public partial class Product
    {
        public class ProductMetadata
        {
            [DisplayName("產品ID")]
            public int ProductID { get; set; }

            [DisplayName("產品名稱")]
            public string ProductName { get; set; }


            public string Desctiption { get; set; }
            public int CategorySID { get; set; }
            public int UnitPrice { get; set; }
            public Nullable<int> SupplierID { get; set; }
            public Nullable<System.DateTime> ProductInDate { get; set; }
            public Nullable<System.DateTime> ProductOutDate { get; set; }
            public Nullable<System.DateTime> CreateDate { get; set; }
        }
        
    }
}