using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Minishop_ver_0._0._0.Areas.SK_AREA.Models.ViewModel
{
    public class LoginViewModel
    {
        [DisplayName("帳號")]
        public string UserName { get; set; }

        [DisplayName("密碼")]
        public string UserPassword { get; set; }
    }
}