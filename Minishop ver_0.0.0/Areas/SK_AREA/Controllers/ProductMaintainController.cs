using Minishop_ver_0._0._0.Areas.SK_AREA.Models.ViewModel;
using Minishop_ver_0._0._0.Areas.SK_AREA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace Minishop_ver_0._0._0.Areas.SK_AREA.Controllers
{
    public class ProductMaintainController : Controller
    {
        FancyStoreEntities db = new FancyStoreEntities();

        // GET: SK_AREA/ProductCreate
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductSheetPartial(int? csid = 1)
        {
            var _p = db.Products.ToList();
            var _pc = db.ProductColors.ToList();
            var _Msort = db.CategoryMiddles.ToList();
            var _Ssort = db.CategorySmalls.ToList();
            var _supply = db.Suppliers.ToList();

            List<ProductMaintainViewModel> _ListPMVM = new List<ProductMaintainViewModel>();

            foreach (var _beta in _p.Where(W=>W.CategorySID == csid))
            {
                ProductMaintainViewModel _PMVM = new ProductMaintainViewModel();

                //商品編號
                _PMVM.ProductID = _beta.ProductID;

                //商品圖示 parameter ProductID=pid,ProductColorID=cid GetImageByte(int pid, int cid)

                //var _dotphoto = db.ProductColors.Where(W => W.ProductID == _beta.ProductID).FirstOrDefault();
                //_PMVM.PhotoID = _dotphoto.PhotoID;
                //var a = _pc.Where(x => x.ProductID == _beta.ProductID).FirstOrDefault();
                //_PMVM.PhotoID = a.PhotoID;
                if (db.ProductPhotoes.Any(x => x.ProductID == _beta.ProductID && ((x.PhotoID == null ? 0 : x.PhotoID) > 0)))
                {
                    _PMVM.PhotoID = (int)db.ProductPhotoes.Where(x => x.ProductID == _beta.ProductID).FirstOrDefault().PhotoID;
                }
                //商品名稱
                _PMVM.ProductName = _beta.ProductName;

                //分類名稱
                var _dotSsort = _Ssort.Where(W => W.CategorySID == _beta.CategorySID).FirstOrDefault();
                _PMVM.CategorySName = _dotSsort.CategorySName;
                var _cmid = _Msort.Where(W => W.CategoryMID == _beta.CategorySmall.CategoryMID).FirstOrDefault();
                _PMVM.CategoryMName = _cmid.CategoryMName;
                _PMVM.CategroyMSName = _PMVM.CategoryMName + "-" + _PMVM.CategorySName;

                //供應商
                var _supplyid = _supply.Where(W => W.SupplierID == _beta.Supplier.SupplierID).FirstOrDefault();
                _PMVM.SupplierName = _supplyid.SupplierName;
                //上架日期 
                _PMVM.ProductInDate = _beta.ProductInDate;

                //下架日期
                _PMVM.ProductOutDate = _beta.ProductOutDate;

                //單價
                _PMVM.UnitPrice = _beta.UnitPrice;

                _ListPMVM.Add(_PMVM);
            }

            return PartialView(_ListPMVM.ToList());
        }

        public ActionResult CatsgoryMSelectPartialView()
        {
            var _CMPV = db.CategoryMiddles.ToList();

            List<CategoryMiddle> _Listcm = new List<CategoryMiddle>();

            foreach (var _data in _CMPV)
            {
                CategoryMiddle _cm = new CategoryMiddle();

                _cm.CategoryMID = _data.CategoryMID;
                _cm.CategoryMName = _data.CategoryMName;

                _Listcm.Add(_cm);
            }

            return PartialView(_Listcm.ToList());
        }

        public ActionResult CategorySSelectPartialView(int? cmid = 1)
        {
            var _CSPV = db.CategorySmalls.ToList();

            List<CategorySmall> _Listcs = new List<CategorySmall>();

            foreach (var _data in _CSPV.Where(W=>W.CategoryMID == cmid))
            {
                CategorySmall _cs = new CategorySmall();

                _cs.CategorySID = _data.CategorySID;
                _cs.CategorySName = _data.CategorySName;

                _Listcs.Add(_cs);
            }
            return PartialView(_Listcs.ToList());
        }

        public ActionResult GetImageByte(int? phid = 25)
        {
            byte[] img = db.Photos.Find(phid).Photo1;

            return File(img, "image/jpeg");
        }

        public ActionResult Test()
        {
            return View();
        }

        public ActionResult ReturnJsonActivity(int? pid)
        {
            var _at = db.Activities.ToList();

            var _json = _at.Select(S => new
            {
                ActivityID = S.ActivityID,
                ActivityName = S.ActivityName,
                RadioBtnView = db.ActivityProducts.Where(W => W.ActivityID == S.ActivityID && W.ProductID == pid)
            }).ToList();

            return Json(_json, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PostJsonActivityUpdate(int? prodid = null,int? actid = null)
        {
            if(prodid == null || actid == null)
            {
                return Json(new
                {
                    Status = false,
                    Message = "未選擇活動,資料未變更",
                });
            }
            try
            {
                if (db.ActivityProducts.Any(A=>A.ProductID == prodid && A.ActivityID != actid))
                {
                    var _ap = db.ActivityProducts.Where(W => W.ProductID == prodid && W.ActivityID != actid).ToList();

                    foreach(var _data in _ap)
                    {
                        var _apt = db.ActivityProducts.Find(_data.ActivityDetailID);

                        db.ActivityProducts.Remove(_apt);
                    }
                }

                //Create
                if (db.ActivityProducts.Any(A => A.ProductID == prodid && A.ActivityID == actid))
                {
                    ActivityProduct _ap = new ActivityProduct();

                    _ap.ActivityID = (int)actid;
                    _ap.ProductID = (int)prodid;
                    _ap.CreateDate = DateTime.Now;

                    db.ActivityProducts.Add(_ap);
                }
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    Status = false,
                    Message = ex.ToString(),

                });
            }

            return Json(new
            {
                Status= true,
                Message = "活動設定成功!",
            });
        }

        [HttpGet]
        public ActionResult Edit(int id = 1)
        {
            ViewBag.CateSMName = new SelectList(db.VW_EW_CategorySM, "CategorySID", "CategoryName");
            ViewBag.Supplier = new SelectList(db.Suppliers, "SupplierID", "SupplierName");

            List <ProductMaintainViewModel> _ListPMVM = new List<ProductMaintainViewModel>();
            ProductMaintainViewModel _PMVM = new ProductMaintainViewModel();
            var _pdt = db.Products.Find(id);

            _PMVM.ProductID = _pdt.ProductID;
            _PMVM.ProductName = _pdt.ProductName;
            _PMVM.Desctiption = _pdt.Desctiption;
            _PMVM.UnitPrice = _pdt.UnitPrice;
            _PMVM.CategorySID = _pdt.CategorySID;
            _PMVM.SupplierID = (int)_pdt.SupplierID;
            _PMVM.ProductInDate = _pdt.ProductInDate;
            _PMVM.ProductOutDate = _pdt.ProductOutDate;

            

            return View(_PMVM);

        }

        [HttpPost]
        public ActionResult Edit(ProductMaintainViewModel _form)
        {
            Product _P = new Product();

            _P.ProductID = _form.ProductID;
            _P.ProductName = _form.ProductName;
            _P.Desctiption = _form.Desctiption;
            _P.UnitPrice = _form.UnitPrice;
            _P.CategorySID = _form.CategorySID;
            _P.SupplierID = (int)_form.SupplierID;
            _P.ProductInDate = _form.ProductInDate;
            _P.ProductOutDate = _form.ProductOutDate;

            db.Entry(_P).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}