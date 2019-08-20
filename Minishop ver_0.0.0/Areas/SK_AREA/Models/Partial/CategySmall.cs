using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Minishop_ver_0._0._0.Areas.SK_AREA.Models.Partial
{
    [MetadataType(typeof(CategorySmallMetadata))]
    public partial class CategorySmall
    {
        public class CategorySmallMetadata
        {
            public int CategorySID { get; set; }
            public string CategorySName { get; set; }
            public int CategoryMID { get; set; }

            [JsonIgnore()]
            public virtual CategoryMiddle CategoryMiddle { get; set; }
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

            [JsonIgnore()]
            public virtual ICollection<Product> Products { get; set; }
        }
    }
}