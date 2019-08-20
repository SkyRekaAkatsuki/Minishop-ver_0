using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Minishop_ver_0._0._0.Areas.SK_AREA.Models.ViewModel
{
    public partial class RegisterViewModel
    {
        [DisplayName("帳號")]
        public string UserName { get; set; }

        [DisplayName("密碼")]
        public string UserPassword { get; set; }

        [DisplayName("電子郵件")]
        public string Email { get; set; }

        [DisplayName("手機")]
        public string Phone { get; set; }

        public bool Gender { get; set; }
        
        public string Address { get; set; }

        public int CityID { get; set; }
        public string CityName { get; set; }

        public int RegionID { get; set; }
        public string RegionName { get; set; }


    }
}