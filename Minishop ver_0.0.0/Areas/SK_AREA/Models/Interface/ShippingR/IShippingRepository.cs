using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Minishop_ver_0._0._0.Areas.SK_AREA.Models.Interface.ShippingR
{
    public interface IShippingRepository
    {
        Shipping GetById(int id);
        IEnumerable<Shipping> GetAll();
        void Create(Shipping _shipping);
        void Update(Shipping _shipping);
        void Delete(Shipping _shipping);
    }
}