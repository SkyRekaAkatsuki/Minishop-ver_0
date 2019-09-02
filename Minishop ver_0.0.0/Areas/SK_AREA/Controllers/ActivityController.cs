using Minishop_ver_0._0._0.Areas.SK_AREA.Models;
using Minishop_ver_0._0._0.Areas.SK_AREA.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Minishop_ver_0._0._0.Areas.SK_AREA.Controllers
{
    public class ActivityController : Controller
    {
        FancyStoreEntities db = new FancyStoreEntities();

        // GET: SK_AREA/Activity
        public ActionResult Index()
        {
            if (HttpContext.Request.Cookies["IsLogin"].Value == "Admin")
            {
                var act = db.Activities.ToList();
                List<ActivityViewModel> activityList = new List<ActivityViewModel>();
                var dis = db.DiscountMethods;

                foreach (var item in act)
                {
                    ActivityViewModel av = new ActivityViewModel();

                    av.ActivityID = item.ActivityID;
                    av.ActivityName = item.ActivityName;
                    av.DiscountID = item.DiscountID;
                    av.BeginDate = item.BeginDate;
                    av.EndDate = item.EndDate;
                    av.CreateDate = item.CreateDate;
                    av.DiscountName = dis.Where(W => W.DiscountID == av.DiscountID).FirstOrDefault().DiscountName;

                    activityList.Add(av);
                }
                return View(activityList.OrderBy(O => O.ActivityID));
            }
            else
            {
                RedirectToAction("PermissionError", "ProductMaintain");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.temp = db.DiscountMethods;
            return View();
        }

        [HttpPost]
        public ActionResult Create(ActivityViewModel _avm)
        {
            Activity _av = new Activity()
            {
                ActivityID = _avm.ActivityID,
                ActivityName = _avm.ActivityName,
                BeginDate = _avm.BeginDate,
                EndDate = _avm.EndDate,
                DiscountID = _avm.DiscountID,
                CreateDate = DateTime.Now
            };

            db.Activities.Add(_av);
            db.SaveChanges();

            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            //活動內容更改 View 
            ActivityEditModel _AEM = new ActivityEditModel();
            var _av = db.Activities.Find(id);

            _AEM.ActivityID = _av.ActivityID;
            _AEM.ActivityName = _av.ActivityName;
            _AEM.BeginDate = _av.BeginDate;
            _AEM.EndDate = _av.EndDate;
            _AEM.DiscountID = _av.DiscountID;
            _AEM.DiscountName = db.DiscountMethods.Find(_av.DiscountID).DiscountName;
            _AEM.CreateDate = _av.CreateDate;

            //活動商品明細 View
            List<ActivityProdViewModel> _Listapvm = new List<ActivityProdViewModel>();
            var _ap = db.ActivityProducts.Where(W => W.ActivityID == id);
            List<Product> prod = db.Products.ToList();
            List<VW_EW_CategorySM> cateMS = db.VW_EW_CategorySM.ToList();
            List<Supplier> suppliers = db.Suppliers.ToList();
            List<ProductPhoto> prodPhoto = db.ProductPhotoes.ToList();

            foreach (var _data in _ap)
            {
                ActivityProdViewModel _apvm = new ActivityProdViewModel();

                _apvm.ActivityID = _data.ActivityID;
                _apvm.ProductID = _data.ProductID;
                var _pd = db.Products.Where(W => W.ProductID == _data.ProductID).FirstOrDefault();
                _apvm.ProductName = _pd.ProductName;
                _apvm.CategoryMSName = cateMS.Where(x => x.CategorySID == _pd.CategorySID).FirstOrDefault().CategoryName;
                _apvm.SupplierName = suppliers.Where(x => x.SupplierID == _pd.SupplierID).FirstOrDefault().SupplierName;

                if (prodPhoto.Any(x => x.ProductID == _data.ProductID && ((x.PhotoID == null ? 0 : x.PhotoID) > 0)))
                {
                    _apvm.PhotoID = (int)prodPhoto.Where(x => x.ProductID == _data.ProductID).FirstOrDefault().PhotoID;
                }
                //aevm.producstList
                _Listapvm.Add(_apvm);
            }

            _AEM.ProdList = _Listapvm;

            ViewBag.temp = db.DiscountMethods;
            return View(_AEM);
        }

        [HttpPost]
        public ActionResult Edit(ActivityEditModel form)
        {
            var _av = db.Activities.Find(form.ActivityID);
            _av.ActivityName = form.ActivityName;
            _av.BeginDate = form.BeginDate;
            _av.EndDate = form.EndDate;
            _av.ActivityID = form.ActivityID;
            _av.DiscountID = form.DiscountID;

            db.Entry(_av).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Edit", new { id = form.ActivityID});
        }


        //刪除活動下的Product
        public ActionResult DeleteProd(int actid, int prodid)
        {
            var av = db.ActivityProducts.Where(x => x.ActivityID == actid && x.ProductID == prodid).FirstOrDefault();

            db.ActivityProducts.Remove(av);
            db.SaveChanges();
            
            return RedirectToAction("Edit", new { id = actid });
        }

        [HttpPost]
        public ActionResult Delete(int actid = 0)
        {
            if (actid == 0)
            {
                return Json(new
                {
                    Status = false,
                    Message = "id 為 0, 無法刪除 !",
                });
            }
            else
            {
                List<ActivityProduct> ap = db.ActivityProducts.Where(x => x.ActivityID == actid).ToList();

                foreach (var item in ap)
                {
                    var apt = db.ActivityProducts.Find(item.ActivityDetailID);
                    db.ActivityProducts.Remove(apt);
                }
            }

            return Json(new
            {
                Status = true,
                Message = "刪除成功!!",
            });

        }

    }
}