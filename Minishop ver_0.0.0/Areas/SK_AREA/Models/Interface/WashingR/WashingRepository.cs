using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Minishop_ver_0._0._0.Areas.SK_AREA.Models.Interface.WashingR
{
    public class WashingRepository :IWashingRepository
    {
        FancyStoreEntities db = new FancyStoreEntities();

        public void Create(Washing _washing)
        {
            db.Washings.Add(_washing);
            db.SaveChanges();
        }

        public void Delete(Washing _washing)
        {
            db.Washings.Remove(_washing);
            db.SaveChanges();
        }

        public IEnumerable<Washing> GetAll()
        {
            return db.Washings;
        }

        public Washing GetById(int id)
        {
            return db.Washings.Find(id);
        }

        public void Update(Washing _washing)
        {
            db.Entry(_washing).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}