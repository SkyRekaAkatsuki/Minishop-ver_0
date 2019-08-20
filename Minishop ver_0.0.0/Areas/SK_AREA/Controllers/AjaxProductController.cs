using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Minishop_ver_0._0._0.Areas.SK_AREA.Models;
using Newtonsoft.Json;
using Minishop_ver_0._0._0.Areas.SK_AREA.Models.Partial;
using Common.Extentions;

namespace Minishop_ver_0._0._0.Areas.SK_AREA.Controllers
{
    public class AjaxProductController : Controller
    {
        FancyStoreEntities db = new FancyStoreEntities();

        // GET: SK_AREA/AjaxProduct
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexAppend()
        {
            return View();
        }

        
        public ActionResult CategoryMiddle()
        {
            var _categorymiddle = db.CategoryMiddles.Select(S => new
            {
                S.CategoryMID,
                S.CategoryMName,
                S.CategorySmalls,
            });

            return Content(_categorymiddle.ToJsonString());
        }

        [HttpGet]
        public ActionResult CategorySmall(int id = 1)
        {
            var _categorysmall = db.CategorySmalls.Where(W => W.CategoryMID == id).ToList();

            return Content(_categorysmall.ToJsonString());
        }

        [HttpGet]
        public ActionResult Product(int id = 1)
        {
            var _product = db.Products.Where(W => W.CategorySID == id).Select(S => new
            {
                S.ProductID,
                S.ProductName,
                S.SupplierID,
                S.CategorySID,
            });

            return Content(_product.ToJsonString());
        }

        public ActionResult CategorySmallPartial(int id = 1)
        {
            var _csp = db.CategorySmalls.Where(W => W.CategoryMID == id);
            return PartialView(_csp);
        }

        public ActionResult ProductPartial(int id = 1)
        {
            var _product = db.Products.Where(W => W.CategorySID == id);

            return PartialView(_product);
        }
    }
}