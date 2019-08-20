using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Minishop_ver_0._0._0.Areas.SK_AREA.Models.Interface.ProductStockR
{
    public interface IProductStockRepository
    {
        ProductStock GetById(int id);
        IEnumerable<ProductStock> GetAll();
        void Create(ProductStock _productstock);
        void Update(ProductStock _productstock);
        void Delete(ProductStock _productstock);
    }
}