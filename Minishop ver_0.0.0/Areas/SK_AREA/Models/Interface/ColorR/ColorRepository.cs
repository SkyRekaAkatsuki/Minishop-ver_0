using Minishop_ver_0._0._0.Areas.SK_AREA.Models.Interface.ColorR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Minishop_ver_0._0._0.Areas.SK_AREA.Models.Interface.ColorR
{
    public class ColorRepository : IColorRepository
    {
        FancyStoreEntities db = new FancyStoreEntities();

        public void Create(Color _color)
        {
            db.Colors.Add(_color);
            db.SaveChanges();
        }

        public void Delete(Color _color)
        {
            db.Colors.Remove(_color);
            db.SaveChanges();
        }

        public IEnumerable<Color> GetAll()
        {
            return db.Colors;
        }

        public Color GetById(int id)
        {
            return db.Colors.Find(id);
        }

        public void Update(Color _color)
        {
            db.Entry(_color).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}