using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Minishop_ver_0._0._0.Areas.SK_AREA.Models.Interface.SupplierR
{
    public interface ISupplierRepository
    {
        Supplier GetById(int? id);
        IEnumerable<Supplier> GetAll();
        void Create(Supplier _supplier);
        void Update(Supplier _supplier);
        void Delete(Supplier _supplier);
    }
}