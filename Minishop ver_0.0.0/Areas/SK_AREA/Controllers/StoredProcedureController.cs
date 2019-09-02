using Minishop_ver_0._0._0.Areas.SK_AREA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Minishop_ver_0._0._0.Areas.SK_AREA.Controllers
{
    public class StoredProcedureController : Controller
    {
        FancyStoreEntities db = new FancyStoreEntities();

        // GET: SK_AREA/StoredProcedure
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TransProdTable()
        {
            var _temp = db.sk_fn_reTable_P(1);
            return View(_temp);
        }

        public ActionResult TransProdColor_INNERJOIN_Photo()
        {
            var _temp = db.sk_sp_innerjoinTable(null);
            return View(_temp);
        }
    }
}