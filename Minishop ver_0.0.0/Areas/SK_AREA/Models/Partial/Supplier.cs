using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Minishop_ver_0._0._0.Areas.SK_AREA.Models
{
    [MetadataType(typeof(SupplierMetadata))]
    public partial class Supplier
    {
        public class SupplierMetadata
        {
            [DisplayName("供應商編號")]
            public int SupplierID { get; set; }

            [DisplayName("供應商名稱")]
            [Required(ErrorMessage ="必填")]
            public string SupplierName { get; set; }

            [DisplayName("手機")]
            [RegularExpression(@"(\d{4})-(\d{6})",ErrorMessage="Form => 0900-000000")]
            [Required(ErrorMessage = "必填")]
            public string Phone { get; set; }

            [DisplayName("傳真")]
            [RegularExpression(@"(\d{2})-(\d{4})-(\d{4})", ErrorMessage = "Format => 02-0000-0000")]
            public string Fax { get; set; }

            [DisplayName("電子郵件")]
            [RegularExpression(@"([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})",ErrorMessage = "Format => xxx@xxx.com")]
            [Required(ErrorMessage = "必填")]
            public string Email { get; set; }

            [DisplayName("地址")]
            [Required(ErrorMessage = "必填")]
            public string Address { get; set; }

            [DisplayName("創建時間")]
            public Nullable<System.DateTime> CreateDate { get; set; }
        }
       
    }
}