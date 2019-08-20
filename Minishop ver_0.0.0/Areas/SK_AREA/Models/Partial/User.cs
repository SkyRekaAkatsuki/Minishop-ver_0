using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Minishop_ver_0._0._0.Areas.SK_AREA.Models.Partial
{
    [MetadataType(typeof(UserMetadata))]
    public partial class User
    {
        public class UserMetadata
        {
            [DisplayName("帳號")]
            [Required(ErrorMessage = "請輸入帳號")]
            public string UserName { get; set; }

            [DisplayName("密碼")]
            [Required(ErrorMessage = "請輸入密碼")]
            public string UserPassword { get; set; }

            [DisplayName("電子郵件")]
            [RegularExpression(@"([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})", ErrorMessage = "Format => xxx@xxx.com")]
            [Required(ErrorMessage = "必填")]
            public string Email { get; set; }

            [DisplayName("手機")]
            [RegularExpression(@"(\d{10})", ErrorMessage = "Form => 0900000000")]
            [Required(ErrorMessage = "必填")]
            public string Phone { get; set; }

            public bool Gender { get; set; }

            [Required(ErrorMessage = "請輸入地址")]
            public string Address { get; set; }

        }
    }
}