using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Minishop_ver_0._0._0.Areas.SK_AREA.Models.Interface.ShippingR
{
    public class ShippingRepository : IShippingRepository
    {
        FancyStoreEntities db = new FancyStoreEntities();

        public void Create(Shipping _shipping)
        {
            db.Shippings.Add(_shipping);
            db.SaveChanges();
        }

        public void Delete(Shipping _shipping)
        {
            db.Shippings.Remove(_shipping);
            db.SaveChanges();
        }

        public IEnumerable<Shipping> GetAll()
        {
            return db.Shippings;
        }

        public Shipping GetById(int id)
        {
            return db.Shippings.Find(id);
        }

        public void Update(Shipping _shipping)
        {
            db.Entry(_shipping).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}