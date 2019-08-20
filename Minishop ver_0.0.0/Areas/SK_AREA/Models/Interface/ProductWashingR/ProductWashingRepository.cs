using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Minishop_ver_0._0._0.Areas.SK_AREA.Models.Interface.ProductWashingR
{
    public class ProductWashingRepository : IProductWashingRepository
    {
        FancyStoreEntities db = new FancyStoreEntities();

        public void Create(ProductWashing _productwashing)
        {
            db.ProductWashings.Add(_productwashing);
            db.SaveChanges();
        }

        public void Delete(ProductWashing _productwashing)
        {
            db.ProductWashings.Remove(_productwashing);
            db.SaveChanges();
        }

        public IEnumerable<ProductWashing> GetAll()
        {
            return db.ProductWashings;
        }

        public ProductWashing GetById(int? id)
        {
            return db.ProductWashings.Find(id);
        }

        public void Update(ProductWashing _productwashing)
        {
            throw new NotImplementedException();
        }
    }
}