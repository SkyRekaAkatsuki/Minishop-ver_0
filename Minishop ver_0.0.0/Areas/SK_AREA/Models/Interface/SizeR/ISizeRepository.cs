using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Minishop_ver_0._0._0.Areas.SK_AREA.Models.Interface.SizeR
{
    public interface ISizeRepository
    {
        Size GetById(int id);
        IEnumerable<Size> GetAll();
        void Create(Size _size);
        void Update(Size _size);
        void Delete(Size _size);
    }
}