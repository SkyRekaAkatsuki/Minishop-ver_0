using Common.Extentions;
using Minishop_ver_0._0._0.Areas.SK_AREA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Minishop_ver_0._0._0.Areas.SK_AREA.Models.ViewModel;

namespace Minishop_ver_0._0._0.Areas.SK_AREA.Controllers
{
    public class SeOmiseController : Controller
    {
        FancyStoreEntities db = new FancyStoreEntities();

        // GET: SK_AREA/SeOmise
        public ActionResult Index() //連續載入 一開始沒有畫面版(需點擊)
        {
            return View();
        }

        public ActionResult IndexFirstLoad() //連續載入 一開始沒有畫面版(不需點擊)
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
        public ActionResult CategorySmall(int? id = 1)
        {
            var _categorysmall = db.CategorySmalls.Where(W => W.CategoryMID == id).ToList();

            return Content(_categorysmall.ToJsonString());
        }

        [HttpGet]
        public ActionResult ProductSeOmise(int? id = 1)
        {
            var _productstockdata = db.ProductStocks.ToList();
            List<SeOmiseIndex> _Listseomise = new List<SeOmiseIndex>();
            foreach (var _data in _productstockdata)
            {
                SeOmiseIndex _seomise = new SeOmiseIndex();

                //ProductID
                _seomise.ProductID = _data.ProductID;

                //ProductName
                var _tempproductname = db.Products.Find(_data.ProductID).ProductName;
                _seomise.ProductName = _tempproductname;

                //CategorySID
                var _tempcategorysid = db.Products.Find(_data.ProductID).CategorySID;
                _seomise.CategorySID = _tempcategorysid;

                //UnitPrice
                var _tempunitprice = db.Products.Find(_data.ProductID).UnitPrice;
                _seomise.UnitPrice = _tempunitprice;
                _seomise.UnitPriceNT = (_tempunitprice.ToString("C2"));

                //ColorName
                var _tempcolorname = db.ProductColors.Find(_data.ProductColorID).ColorID;
                var _tempcolorname2 = db.Colors.Find(_tempcolorname).ColorName;
                _seomise.ColorName = _tempcolorname2;

                //Photo
                var _tempphoto = db.ProductColors.Find(_data.ProductColorID).PhotoID;
                _seomise.PhotoID = (int)_tempphoto;
                _seomise.Photo1 = db.Photos.Find(_tempphoto).Photo1;

                _Listseomise.Add(_seomise);
            }

            var _ListJsonSeOmise = _Listseomise.Where(W => W.CategorySID == id).ToList();

            return Content(_ListJsonSeOmise.ToJsonString());
    
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

        public ActionResult GetImageByte(int? id = 1)
        {
            byte[] img = db.Photos.Find(id).Photo1;

            return File(img, "image/jpg");
        }

    }
}