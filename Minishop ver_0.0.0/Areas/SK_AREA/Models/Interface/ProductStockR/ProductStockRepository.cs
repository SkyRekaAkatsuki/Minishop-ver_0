using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Minishop_ver_0._0._0.Areas.SK_AREA.Models.Interface.ProductStockR
{
    public class ProductStockRepository : IProductStockRepository
    {
        FancyStoreEntities db = new FancyStoreEntities();

        public void Create(ProductStock _productstock)
        {
            db.ProductStocks.Add(_productstock);
            db.SaveChanges();
        }

        public void Delete(ProductStock _productstock)
        {
            db.ProductStocks.Remove(_productstock);
            db.SaveChanges();
        }

        public IEnumerable<ProductStock> GetAll()
        {
            return db.ProductStocks;
        }

        public ProductStock GetById(int id)
        {
            return db.ProductStocks.Find(id);
        }

        public void Update(ProductStock _productstock)
        {
            db.Entry(_productstock).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}