// Json 連續載入 一開始沒有畫面版(不需點擊/效能改善)
using Common.Extentions;
using Minishop_ver_0._0._0.Areas.SK_AREA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Minishop_ver_0._0._0.Areas.SK_AREA.Models.ViewModel;
using Minishop_ver_0._0._0.Areas.SK_AREA.Models.Partial;
using CategoryMiddle = Minishop_ver_0._0._0.Areas.SK_AREA.Models.Partial.CategoryMiddle.CategoryMiddleMetadata;

namespace Minishop_ver_0._0._0.Areas.SK_AREA.Controllers
{
    public class SeOmiseRAMController : Controller
    {
        FancyStoreEntities db = new FancyStoreEntities();

        public ActionResult IndexFirstLoadRAM() 
        {
            return View();
        }

        public ActionResult CategoryMiddle()
        {
            var CategoryMiddlesTable = db.CategoryMiddles;

            var _categorymiddle = CategoryMiddlesTable.Select(S => new
            {
                S.CategoryMID,
                S.CategoryMName,
            });

            return Json(_categorymiddle, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult CategorySmall(int? id = 1)
        {
            var CategorySmallsTable = db.CategorySmalls;

            //var _categorysmall = CategorySmallsTable.Where(W => W.CategoryMID == id).ToList();

            //return Content(_categorysmall.ToJsonString());

            var _categorySmalls = CategorySmallsTable.Where(W=>W.CategoryMID == id).Select(S => new
            {
                S.CategorySID,
                S.CategorySName,
            });

            return Json(_categorySmalls, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ProductSeOmise(int? id = 1)
        {
            using (db = new FancyStoreEntities())
            {
                var _productseomise = db.ProductColors.Where(P => P.Product.CategorySID == id).Select
                (p => new {
                    p.Product.ProductID,
                    p.Product.ProductName,
                    p.ColorID,
                    p.Product.UnitPrice,
                    p.Color.ColorName,
                });

                return Json(_productseomise.ToList(), JsonRequestBehavior.AllowGet);
            }
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

        public ActionResult GetImageByte(int pid,int cid)
        {
            var PhotoTable = db.Photos;
            var ProductPhotoTable = db.ProductPhotoes;
            var ProductColorTable = db.ProductColors;


            int? _tempphoto = ProductColorTable.Where(W => W.ColorID == cid && W.ProductID == pid).Select(S => S.PhotoID).First();
            
            byte[] img = PhotoTable.Find(_tempphoto).Photo1;

            return File(img, "image/jpeg");
        }

    }
}