using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Minishop_ver_0._0._0.Areas.SK_AREA.Models.Partial
{
    [MetadataType(typeof(CategoryMiddleMetadata))]
    public partial class CategoryMiddle
    {
        public class CategoryMiddleMetadata
        {
            public int CategoryMID { get; set; }
            public string CategoryMName { get; set; }


            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
            [JsonIgnore()]
            public virtual ICollection<CategorySmall> CategorySmalls { get; set; }
        }
    }
}