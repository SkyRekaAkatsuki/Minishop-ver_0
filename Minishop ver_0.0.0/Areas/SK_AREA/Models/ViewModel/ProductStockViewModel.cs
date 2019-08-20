using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;

namespace Minishop_ver_0._0._0.Areas.SK_AREA.Models.ViewModel
{
    public class ProductStockViewModel
    {
        

        //Table Product
        [DisplayName("產品ID")]
        public int ProductID { get; set; }

        [DisplayName("產品名稱")]
        public string ProductName { get; set; }

        //Table Color
        [DisplayName("顏色")]
        public string ColorName { get; set; }

        //Table Size
        [DisplayName("呎寸")]
        public string SizeName { get; set; }

        //Table ProductStock
        [DisplayName("現有庫存量")]
        public int StockQTY { get; set; }
        [DisplayName("安全庫存量")]
        public int MinStock { get; set; }

        //Table Washing
        [DisplayName("清洗方式")]
        public string WashingName { get; set; }

        //Table Supplier
        [DisplayName("供應商名稱")]
        public string SupplierName { get; set; }

        [DisplayName("已成訂單未出貨量")]
        public int OrderQTY { get; set; }

        [DisplayName("已購未訂量(在購物車中未成訂單)")]
        public int CartQTY { get; set; }

        [DisplayName("最少捕貨量")]
        public int AddQTY { get; set; }

        [DisplayName("StockID")]
        public int StockID { get; set; }

        [DisplayName("商品圖片")]
        public byte[] PhotoView { get; set; }
        //索引值 不顯示
        public int SupplierID { get; set; }
        public int ProductSizeID { get; set; }
        public int ProductColorID { get; set; }
        public int PhotoID { get; set; }
        public int ColorID { get; set; }
        public int readimg_to_getimagebyte { get; set; }
    }
}