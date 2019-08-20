using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Minishop_ver_0._0._0.Areas.SK_AREA.Models.Interface.ProductWashingR
{
    public interface IProductWashingRepository
    {
        ProductWashing GetById(int? id);
        IEnumerable<ProductWashing> GetAll();
        void Create(ProductWashing _productwashing);
        void Update(ProductWashing _productwashing);
        void Delete(ProductWashing _productwashing);
    }
}