using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Minishop_ver_0._0._0.Areas.SK_AREA.Models.Interface.ProductR
{
    public class ProductRepository : IProductRepository
    {
        FancyStoreEntities db = new FancyStoreEntities();

        public void Create(Product _product)
        {
            db.Products.Add(_product);
            db.SaveChanges();
        }

        public void Delete(Product _product)
        {
            db.Products.Remove(_product);
            db.SaveChanges();
        }

        public IEnumerable<Product> GetAll()
        {
            return db.Products;
        }

        public Product GetById(int id)
        {
            return db.Products.Find(id);
        }

        public void Update(Product _product)
        {
            db.Entry(_product).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}