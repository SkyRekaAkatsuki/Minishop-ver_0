using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Minishop_ver_0._0._0.Areas.SK_AREA.Models.Partial
{
    [MetadataType(typeof(ColorMetadata))]
    public partial class Color
    {
        public class ColorMetadata
        {
            [DisplayName("顏色ID")]
            public int ColorID { get; set; }

            [DisplayName("顏色")]
            public string ColorName { get; set; }

            [DisplayName("三原色的 R")]
            public Nullable<int> R { get; set; }

            [DisplayName("三原色的 G")]
            public Nullable<int> G { get; set; }

            [DisplayName("三原色的 B")]
            public Nullable<int> B { get; set; }
        }
    }
}