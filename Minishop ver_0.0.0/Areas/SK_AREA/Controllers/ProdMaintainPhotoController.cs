using Minishop_ver_0._0._0.Areas.SK_AREA.Models;
using Minishop_ver_0._0._0.Areas.SK_AREA.Models.ViewModel.ProuductMaintainViewModel.ProdMaintainPhotoViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Minishop_ver_0._0._0.Areas.SK_AREA.Controllers
{
    public class ProdMaintainPhotoController : Controller
    {
        FancyStoreEntities db = new FancyStoreEntities();

        // GET: SK_AREA/ProdMaintainPhoto
        public ActionResult Index(int pid)
        {
            if (HttpContext.Request.Cookies["IsLogin"].Value == "Admin")
            {
                var _temp = db.Products.Find(pid);

                ProdMaintainPhotoViewModel _PMPVM = new ProdMaintainPhotoViewModel();

                _PMPVM.ProductID = _temp.ProductID;
                _PMPVM.ProductName = _temp.ProductName;

                return View(_PMPVM);
            }
            else
            {
                RedirectToAction("PermissionError", "ProductMaintain");
            }
            return View();
        }

        public ActionResult PhotoJson(int pid)
        {
            var _temp = db.ProductPhotoes.Where(W => W.ProductID == pid).OrderBy(O => O.ProductID);

            List<ProdMaintainPhotoViewModel> _list = new List<ProdMaintainPhotoViewModel>();

            foreach (var _data in _temp)
            {
                ProdMaintainPhotoViewModel _PMPVM = new ProdMaintainPhotoViewModel();

                _PMPVM.PhotoID = (int)_data.PhotoID;
                _PMPVM.ProductID = _data.ProductID;
                _PMPVM.CreateDate = _data.CreateDate;
                _PMPVM.ProductPhotoID = _data.ProductPhotoID;

                _list.Add(_PMPVM);
            }

            return Json(_list, JsonRequestBehavior.AllowGet);
        }

        //讀DB 二進位資料
        public ActionResult GetImageByte(int photoid)
        {
            Photo ph = db.Photos.Find(photoid);
            byte[] img = ph.Photo1;

            return File(img, "image/jpeg");
        }

        public ActionResult UploadImg(string Parm)
        {
            HttpPostedFileBase fileBase = Request.Files[0];

            var phid = 0;

            try
            {
                //將圖檔轉成2進位資料
                var imgSize = fileBase.ContentLength;
                byte[] imgByte = new byte[imgSize];
                fileBase.InputStream.Read(imgByte, 0, imgSize);

                Photo ph = new Photo
                {
                    Photo1 = imgByte,
                    CreateDate = DateTime.Now
                };

                db.Photos.Add(ph);
                db.SaveChanges();

                phid = ph.PhotoID;
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    Status = false,
                    photoid = phid,
                    Message = ex.ToString(),
                });
            }

            return Json(
                new
                {
                    Status = true,
                    photoid = phid,
                    Message = "上傳成功=> " + phid
                });
        }
        
        public ActionResult afterImgCreateProdPhoto(int pid,int phid)
        {
            ProductPhoto _pp = new ProductPhoto();

            _pp.PhotoID = phid;
            _pp.ProductID = pid;
            _pp.CreateDate = DateTime.Now;

            db.ProductPhotoes.Add(_pp);
            db.SaveChanges();

            return Json(new
            {
                Status = true,
                Message = "連動成功!!"
            });
        }

        public ActionResult Delete(int ppid,int phid)
        {
            bool S = false;
            try
            {
                var _tempppid = db.ProductPhotoes.Find(ppid);
                db.ProductPhotoes.Remove(_tempppid);
                db.SaveChanges();
                S = true;
                if (S)
                {
                    var _tempphid = db.Photos.Find(phid);
                    db.Photos.Remove(_tempphid);
                    db.SaveChanges();
                    return Json(new
                    {
                        Status = true,
                        Message = "圖檔刪除成功"
                    });
                }
                else
                {
                    return Json(new
                    {
                        Status = true,
                        Message = "圖檔刪除失敗"
                    });
                }
            }
            catch
            {
                return Json(new
                {
                    Status = true,
                    Meassage = "圖檔關聯刪除失敗"
                });
            }
            

        }
    }
}