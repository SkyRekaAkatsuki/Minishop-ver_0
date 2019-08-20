using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Minishop_ver_0._0._0.Areas.SK_AREA.Models.Interface.SupplierR
{
    public class SupplierRepository : ISupplierRepository
    {
        private FancyStoreEntities db = new FancyStoreEntities();

        public void Create(Supplier _supplier)
        {
            db.Suppliers.Add(_supplier);
            db.SaveChanges();
        }

        public void Delete(Supplier _supplier)
        {
            db.Suppliers.Remove(_supplier);
            db.SaveChanges();
        }

        public IEnumerable<Supplier> GetAll()
        {
            return db.Suppliers;
        }

        public Supplier GetById(int? id)
        {
            return db.Suppliers.Find(id);
        }

        public void Update(Supplier _supplier)
        {
            db.Entry(_supplier).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}