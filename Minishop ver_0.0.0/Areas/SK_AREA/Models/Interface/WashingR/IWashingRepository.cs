using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Minishop_ver_0._0._0.Areas.SK_AREA.Models.Interface.WashingR
{
    public interface IWashingRepository
    {
        Washing GetById(int id);
        IEnumerable<Washing> GetAll();
        void Create(Washing _washing);
        void Update(Washing _washing);
        void Delete(Washing _washing);
    }
}