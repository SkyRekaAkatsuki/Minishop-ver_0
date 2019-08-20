using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Minishop_ver_0._0._0.Areas.SK_AREA.Models.Interface.ColorR
{
    public interface IColorRepository
    {
        Color GetById(int id);
        IEnumerable<Color> GetAll();
        void Create(Color _color);
        void Update(Color _color);
        void Delete(Color _color);
    }
}