using Minishop_ver_0._0._0.Areas.SK_AREA.Models;
using Minishop_ver_0._0._0.Areas.SK_AREA.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Minishop_ver_0._0._0.Areas.SK_AREA.Controllers
{
    public class ProdMaintainWashController : Controller
    {
        FancyStoreEntities db = new FancyStoreEntities();

        // GET: SK_AREA/ProdMaintainWash
        [HttpGet]
        public ActionResult Index(int pid)
        {
            if (HttpContext.Request.Cookies["IsLogin"].Value == "Admin")
            {
                var _pid = db.Products.Find(pid);
                ProdMaintainWashViewModel _PMWVM = new ProdMaintainWashViewModel();

                _PMWVM.ProductID = _pid.ProductID;
                _PMWVM.ProductName = _pid.ProductName;


                List<List_for_ProdMaintainWashViewModel> _ListLFPMVM = new List<List_for_ProdMaintainWashViewModel>();
                var _pwtable = db.ProductWashings.Where(W => W.ProductID == _pid.ProductID);
                foreach (var _data in _pwtable)
                {
                    List_for_ProdMaintainWashViewModel _LFPMVM = new List_for_ProdMaintainWashViewModel();
                    _LFPMVM.ProductWashingID = _data.ProductWashingID;
                    _LFPMVM.WashingName = _data.Washing.WashingName;

                    _ListLFPMVM.Add(_LFPMVM);
                }

                ViewBag.WashSelect = new SelectList(db.Washings, "WashingID", "WashingName");

                _PMWVM.L_for_PMWVM = _ListLFPMVM;

                return View(_PMWVM);
            }
            else
            {
                RedirectToAction("PermissionError", "ProductMaintain");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int pid, int wid)
        {
            try
            {
                if(db.ProductWashings.Any(A=>A.ProductID == pid && A.WashingID == wid))
                {
                    return Json(new
                    {
                        Status = false,
                        Message = "洗滌條件重覆選取 !",
                    });
                }

                ProductWashing _PW = new ProductWashing()
                {
                    WashingID = wid,
                    ProductID = pid,
                };

                db.ProductWashings.Add(_PW);
                db.SaveChanges();

                return Json(new
                {
                    Status = true,
                    Message = "清洗方式新增成功",
                });

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public ActionResult WashReload(int pid)
        {
            var _temp = db.ProductWashings.Where(W=>W.ProductID == pid).Select(S => new
            {
                S.ProductWashingID,
                S.Washing.WashingName,
            });

            return Json(_temp, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int pwid)
        {
            var _temp = db.ProductWashings.Find(pwid);

            db.ProductWashings.Remove(_temp);
            db.SaveChanges();

            return Json(new
            {
                State = true,
                Message = "刪除成功!!",
            });
        }
    }
}