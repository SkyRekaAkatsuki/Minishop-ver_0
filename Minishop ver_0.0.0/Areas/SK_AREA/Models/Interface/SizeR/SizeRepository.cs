using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Minishop_ver_0._0._0.Areas.SK_AREA.Models.Interface.SizeR
{
    public class SizeRepository : ISizeRepository
    {
        FancyStoreEntities db = new FancyStoreEntities();

        public void Create(Size _size)
        {
            db.Sizes.Add(_size);
            db.SaveChanges();
        }

        public void Delete(Size _size)
        {
            db.Sizes.Remove(_size);
            db.SaveChanges();
        }

        public IEnumerable<Size> GetAll()
        {
            return db.Sizes;
        }

        public Size GetById(int id)
        {
            return db.Sizes.Find(id);
        }

        public void Update(Size _size)
        {
            db.Entry(_size).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}