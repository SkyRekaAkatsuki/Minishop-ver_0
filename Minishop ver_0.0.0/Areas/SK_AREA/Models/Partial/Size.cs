using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Minishop_ver_0._0._0.Areas.SK_AREA.Models.Partial
{
    [MetadataType(typeof(SizeMetadata))]
    public partial class Size
    {
        public class SizeMetadata
        {
            [DisplayName("產品大小ID")]
            public int SizeID { get; set; }

            [DisplayName("產品大小名稱")]
            public string SizeName { get; set; }
        }
        
    }
}