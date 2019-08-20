using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Minishop_ver_0._0._0.Areas.SK_AREA.Models.ViewModel
{
    public class SeOmiseIndex
    {
        //Product
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int CategorySID { get; set; }
        public int UnitPrice { get; set; }
        public string UnitPriceNT { get; set; }

        //Color
        public int ColorID { get; set; }
        public string ColorName { get; set; }

        //ProductColor
        public int ProductColorID { get; set; }
        //public int ColorID { get; set; }
        //public int ProductID { get; set; }

        //Photo
        public int PhotoID { get; set; }
        public byte[] Photo1 { get; set; }

        //ProductPhoto
        public int ProductPhotoID { get; set; }
        //public int ProductID { get; set; }

        //ProductStock
        public int StockID { get; set; }
        public int ProductSizeID { get; set; }
        //public int ProductID { get; set; }
        //public int ProductColorID { get; set; }
    }
}