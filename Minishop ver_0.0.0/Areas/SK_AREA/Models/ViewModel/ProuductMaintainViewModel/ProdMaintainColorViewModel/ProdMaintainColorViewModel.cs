using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Minishop_ver_0._0._0.Areas.SK_AREA.Models.ViewModel.ProuductMaintainViewModel.ProdMaintainColorViewModel
{
    public class ProdMaintainColorViewModel
    {
        [DisplayName("編號")]
        public int ProductColorID { get; set; }


        [DisplayName("顏色ID")]
        [Required(ErrorMessage = "顏色要輸入")]
        public int ColorID { get; set; }

        [DisplayName("顏色")]
        public string ColorName { get; set; }

        [DisplayName("圖片ID")]
        public Nullable<int> PhotoID { get; set; }

        public Nullable<System.DateTime> CreateDate { get; set; }

        [DisplayName("商品名稱")]
        public string ProductName { get; set; }

        [DisplayName("商品編號")]
        public int ProductID { get; set; }

        [DisplayName("選擇圖檔")]
        public string PhotoFile { get; set; }
    }
}