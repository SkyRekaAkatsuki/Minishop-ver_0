using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Minishop_ver_0._0._0.Areas.SK_AREA.Models.Partial
{
    [MetadataType(typeof(WashingMetadata))]
    public partial class Washing
    {
        public class WashingMetadata
        {
            [DisplayName("清洗方式ID")]
            public int WashingID { get; set; }

            [DisplayName("清洗方式")]
            public string WashingName { get; set; }
        }
        
    }
}