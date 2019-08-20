using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Minishop_ver_0._0._0.Areas.SK_AREA.Models.Partial
{
    [MetadataType(typeof(ProductStockMetadata))]
    public partial class ProductStock
    {
        public class ProductStockMetadata
        {
            
            public int StockID { get; set; }
            public int ProductID { get; set; }
            public int ProductSizeID { get; set; }
            public int ProductColorID { get; set; }

            [DisplayName("庫存數量")]
            public int StockQTY { get; set; }

            [DisplayName("安全庫存量MinStock")]
            public int MinStock { get; set; }
            public Nullable<System.DateTime> CreateDate { get; set; }
        }
        
    }
}