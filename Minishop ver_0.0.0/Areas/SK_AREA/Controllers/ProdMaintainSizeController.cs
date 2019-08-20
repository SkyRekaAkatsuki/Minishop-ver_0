using Minishop_ver_0._0._0.Areas.SK_AREA.Models;
using Minishop_ver_0._0._0.Areas.SK_AREA.Models.ViewModel.ProuductMaintainViewModel.ProdMaintainSizeViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Minishop_ver_0._0._0.Areas.SK_AREA.Controllers
{
    public class ProdMaintainSizeController : Controller
    {
        FancyStoreEntities db = new FancyStoreEntities();

        // GET: SK_AREA/ProdMaintainSize
        [HttpGet]
        public ActionResult Index(int pid)
        {
            var _pid = db.Products.Find(pid);
            ProdMaintainSizeViewModel _PMSVM = new ProdMaintainSizeViewModel();

            _PMSVM.ProductID = pid;
            _PMSVM.ProductName = _pid.ProductName;
            var _psTable = db.ProductSizes.Where(W => W.ProductID == pid);

            List<List_for_ProdMaintainSizeViewModel> _ListLFPMSVM = new List<List_for_ProdMaintainSizeViewModel>();

            foreach (var _data in _psTable)
            {
                List_for_ProdMaintainSizeViewModel _LFPMSVM = new List_for_ProdMaintainSizeViewModel();
                _LFPMSVM.ProductSizeID = _data.ProductSizeID;
                _LFPMSVM.SizeName = _data.Size.SizeName;
                _ListLFPMSVM.Add(_LFPMSVM);
            }

            _PMSVM.L_for_PMSVM = _ListLFPMSVM;
            ViewBag.SizeSelect = new SelectList(db.Sizes, "SizeID", "SizeName");
            return View(_PMSVM);
        }

       [HttpPost]
        public ActionResult SaveSize(int pid,int sid)
        {
            if (db.ProductSizes.Any(A=>A.ProductID == pid && A.SizeID == sid))
            {
                return Json(new
                {
                    State = false,
                    Message = "新增失敗,此產品已經有此尺寸!!"
                });
            }
            else
            {
                ProductSize _PW = new ProductSize();

                _PW.ProductID = pid;
                _PW.SizeID = sid;

                db.ProductSizes.Add(_PW);
                db.SaveChanges();

                return Json(new
                {
                    State = true,
                    Message = "尺寸新增成功"
                });
            }
        }

        [HttpGet]
        public ActionResult SizeReload(int pid)
        {
            var _temp = db.ProductSizes.Where(W => W.ProductID == pid).Select(S => new
            {
                S.ProductSizeID,
                S.Size.SizeName,
            });

            return Json(_temp, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int psid)
        {
            var _temp = db.ProductSizes.Find(psid);

            db.ProductSizes.Remove(_temp);
            db.SaveChanges();

            return Json(new
            {
                State = true,
                Message = "此產品尺寸刪除成功!!"
            });
        }
    }
}