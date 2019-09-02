using Minishop_ver_0._0._0.Areas.SK_AREA.Models;
using Minishop_ver_0._0._0.Areas.SK_AREA.Models.ViewModel.ProuductMaintainViewModel.ProdMaintainStockViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Minishop_ver_0._0._0.Areas.SK_AREA.Controllers
{
    public class ProdMaintainStockController : Controller
    {
        FancyStoreEntities db = new FancyStoreEntities();
        // GET: SK_AREA/ProdMaintainStock
        public ActionResult Index(int? pid = 1)
        {
            if (HttpContext.Request.Cookies["IsLogin"].Value == "Admin")
            {
                ProdMaintainStockViewModel _PMSVM = new ProdMaintainStockViewModel();

                var _pPK = db.Products.Find(pid);

                _PMSVM.ProductID = _pPK.ProductID;
                _PMSVM.ProductName = _pPK.ProductName;

                var _productcolor = db.ProductColors.Where(x => x.ProductID == pid).Select(x => new
                {
                    x.ProductColorID,
                    x.Color.ColorName
                });

                ViewBag.ColorSelect = new SelectList(_productcolor, "ProductColorID", "ColorName");

                var _productsize = db.ProductSizes.Where(x => x.ProductID == pid).Select(x => new
                {
                    x.ProductSizeID,
                    x.Size.SizeName
                });

                ViewBag.SizeSelect = new SelectList(_productsize, "ProductSizeID", "SizeName");

                return View(_PMSVM);
            }
            else
            {
                RedirectToAction("PermissionError", "ProductMaintain");
            }
            return View();
        }

        public ActionResult ProdStockJson(int pid)
        {
            List<ProdMaintainStockViewModel> _ListPMSVM = new List<ProdMaintainStockViewModel>();

            var _PS = db.ProductStocks.Where(x => x.ProductID == pid).OrderByDescending(x => x.StockID);
            //var c = db.ProductColors.Where(x => x.ProductID == id).Select(x => new
            //{
            //    x.ProductColorID,
            //    x.Color.ColorName
            //});
            //var s = db.ProductSizes.Where(x => x.ProductID == id).Select(x => new
            //{
            //    x.ProductSizeID,
            //    x.Size.SizeName
            //});

            foreach (var _data in _PS)
            {
                ProdMaintainStockViewModel _PMSVM = new ProdMaintainStockViewModel
                {
                    StockID = _data.StockID,
                    ProductID = _data.ProductID,
                    ProductColorID = _data.ProductColorID,
                    ProductSizeID = _data.ProductSizeID,
                    StockQTY = _data.StockQTY,
                    MinStock = _data.MinStock,
                    CreateDate = _data.CreateDate,
                    PhotoID = _data.ProductColor.PhotoID,

                    ProductColor = db.ProductColors.Where(x => x.ProductColorID == _data.ProductColorID).FirstOrDefault().Color.ColorName,
                    ProductSize = db.ProductSizes.Where(x => x.ProductSizeID == _data.ProductSizeID).FirstOrDefault().Size.SizeName,
                };

                _ListPMSVM.Add(_PMSVM);
            }

            return Json(_ListPMSVM, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CreateStockData(int pid, int psid, int pcid, int Sqty, int Mstock)
        {
            try
            {
                if (psid < 1)
                {
                    return Json(new
                    {
                        State = false,
                        Message = "產品尺寸未選擇",
                    });
                }
                else
                {
                    if (pcid < 1)
                    {
                        return Json(new
                        {
                            State = false,
                            Message = "產品顏色未選擇",
                        });
                    }
                    else
                    {
                        if(db.ProductStocks.Any(A=>A.ProductID == pid && A.ProductSizeID == psid && A.ProductColorID == pcid))
                        {
                            return Json(new
                            {
                                State = false,

                                Message = "庫存資料已存在",
                            });
                        }
                        else
                        {
                            ProductStock _PS = new ProductStock();

                            _PS.ProductID = pid;
                            _PS.ProductSizeID = psid;
                            _PS.ProductColorID = pcid;
                            _PS.StockQTY = Sqty;
                            _PS.MinStock = Mstock;
                            _PS.CreateDate = DateTime.Now;

                            db.ProductStocks.Add(_PS);
                            db.SaveChanges();

                            return Json(new
                            {
                                State = true,
                                Message = "產品新增成功",
                            });
                        }
                    }
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
        }

        [HttpPost]
        public ActionResult DeleteStockData(int StockID)
        {
            try
            {
                if (StockID == 0)
                {
                    return Json(new
                    {
                        State = false,
                        Message = "Can't Catch Stock Row, Removal failed",
                    });
                }
                else
                {
                    var _temp = db.ProductStocks.Find(StockID);

                    db.ProductStocks.Remove(_temp);
                    db.SaveChanges();

                    return Json(new
                    {
                        State = true,
                        Message = "產品庫存列移除成功!!",
                    });
                }
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    Stste = false,
                    Message = ex.ToString(),
                });
            }
        }

        [HttpPost]
        public ActionResult UpdateStockQTY(int stockID, int stockQTY, int minStock)
        {
            try
            {
                ProductStock _PS = db.ProductStocks.Find(stockID);

                _PS.StockID = stockID;
                _PS.ProductID = _PS.ProductID;
                _PS.ProductSizeID = _PS.ProductSizeID;
                _PS.ProductColorID = _PS.ProductColorID;
                _PS.StockQTY = stockQTY;
                _PS.MinStock = minStock;
                _PS.CreateDate = _PS.CreateDate;

                db.Entry(_PS).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return Json(new
                {
                    State = true,
                    Message = "庫存量改動成功!!",
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    State = false,
                    Message = ex.ToString(),
                });
            }
            
        }
    }
}