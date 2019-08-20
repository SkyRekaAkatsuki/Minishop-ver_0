using Minishop_ver_0._0._0.Areas.SK_AREA.Models;
using Minishop_ver_0._0._0.Areas.SK_AREA.Models.Interface.ColorR;
using Minishop_ver_0._0._0.Areas.SK_AREA.Models.Interface.ProductR;
using Minishop_ver_0._0._0.Areas.SK_AREA.Models.Interface.ProductStockR;
using Minishop_ver_0._0._0.Areas.SK_AREA.Models.Interface.ProductWashingR;
using Minishop_ver_0._0._0.Areas.SK_AREA.Models.Interface.SizeR;
using Minishop_ver_0._0._0.Areas.SK_AREA.Models.Interface.SupplierR;
using Minishop_ver_0._0._0.Areas.SK_AREA.Models.Interface.WashingR;
using Minishop_ver_0._0._0.Areas.SK_AREA.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.Drawing;

namespace Minishop_ver_0._0._0.Areas.SK_AREA.Controllers
{
    public class ProductStockController : Controller
    {
        FancyStoreEntities db = new FancyStoreEntities();
        
        ProductRepository _productRepository = new ProductRepository();
        ColorRepository _colorRepository = new ColorRepository();
        SizeRepository _sizeRepository = new SizeRepository();
        ProductStockRepository _productstockRepository = new ProductStockRepository();
        WashingRepository _washingRepository = new WashingRepository();
        SupplierRepository _supplierRepository = new SupplierRepository();
        ProductWashingRepository _productwashingRepository = new ProductWashingRepository();
        
        // GET: SK_AREA/ProductStock
        public ActionResult Index(int ? page)
        {
            TempData["page7"] = page ?? 1;

            var productstockModel = _productstockRepository.GetAll();

            List<ProductStockViewModel> _ListPSVM = new List<ProductStockViewModel>();

            foreach (var beta in productstockModel)
            {
                ProductStockViewModel _PSVM = new ProductStockViewModel();
                //ProductID
                _PSVM.ProductID = beta.ProductID;

                //ProductName
                var pn = _productRepository.GetById(beta.ProductID);
                var pn2 = pn.ProductName;
                _PSVM.ProductName = pn2;

                //ColorName
                var tempcolor = db.ProductColors.Join(db.Colors, PC => PC.ColorID, C => C.ColorID, (PC, C) => new
                {
                    ColorName = C.ColorName,
                    ColorID = C.ColorID,
                    ProductID = PC.ProductID,
                    ProductColorID = PC.ProductColorID,
                });
                var tempcolor2 = tempcolor.Where(PC => PC.ProductColorID == beta.ProductColorID).Select(C => C.ColorName);
                _PSVM.ColorName = tempcolor2.First();
                Debug.WriteLine("_PSVM.ColorName =" + _PSVM.ColorName);

                //SizeName
                var tempsize = db.ProductSizes.Join(db.Sizes, PS => PS.SizeID, S => S.SizeID, (PS, S) => new
                {
                    SizeName = S.SizeName,
                    SizeID = S.SizeID,
                    ProductID = PS.ProductID,
                    ProductSizeID = PS.ProductSizeID,
                });
                var tempsize2 = tempsize.Where(S => S.ProductSizeID == beta.ProductSizeID).Select(S => S.SizeName);
                _PSVM.SizeName = tempsize2.First();
                Debug.WriteLine("_PSVM.SizeName =" + _PSVM.SizeName);

                //StockID
                _PSVM.StockID = beta.StockID;

                //StockQTY
                _PSVM.StockQTY = beta.StockQTY;

                //MinStock
                _PSVM.MinStock = beta.MinStock;

                //SuppilerName
                var ts = _productRepository.GetById(beta.ProductID);
                var ts2 = ts.SupplierID;
                var ts3 = _supplierRepository.GetById(ts2).SupplierName;

                _PSVM.SupplierName = ts3;
                Debug.WriteLine("_PSVM.SupplierName =" + _PSVM.SupplierName);

                //訂購數量欄位
                _PSVM.OrderQTY = db.OrderDetails
                    .Where(x => x.ProductID == beta.ProductID && x.ProductColorID == beta.ProductColorID
                                  && x.ProductSizeID == beta.ProductSizeID && x.OrderHeader.OrderStatusID == 1).Select(x => x.OrderQTY).Count();

                //購物車訂購數量
                _PSVM.CartQTY = db.Carts.Where(x => x.ProductID == beta.ProductID && x.ProductColorID == beta.ProductColorID
                                  && x.ProductSizeID == beta.ProductSizeID).Select(x => x.Quantity).Count();

                //需補貨數量
                _PSVM.AddQTY = _PSVM.CartQTY + _PSVM.OrderQTY + _PSVM.MinStock - _PSVM.StockQTY;

                //讀圖片
                var tempphoto = db.ProductColors.Find(beta.ProductColorID);
                var tempphoto2 = db.Colors.Find(tempphoto.ColorID).ColorName;
                _PSVM.PhotoID = Convert.ToInt32(tempphoto.PhotoID);
                _PSVM.readimg_to_getimagebyte = tempphoto.ColorID;



                //寫入集合 List<ProductStockViewModel> _ListPSVM
                if (_PSVM.AddQTY > 0)
                {
                    _ListPSVM.Add(_PSVM);
                }
            }
            return View(_ListPSVM.ToList().ToPagedList(page ?? 1, 5));
        }
        
        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            ProductStockViewModel _PSVM = new ProductStockViewModel();
            var getidstockqty = _productstockRepository.GetById(id);

            //ProductID
            _PSVM.ProductID = getidstockqty.ProductID;

            //ProductName
            var pn = _productRepository.GetById(getidstockqty.ProductID);
            var pn2 = pn.ProductName;
            _PSVM.ProductName = pn2;

            //ColorName
            var tempcolor = db.ProductColors.Join(db.Colors, PC => PC.ColorID, C => C.ColorID, (PC, C) => new
            {
                ColorName = C.ColorName,
                ColorID = C.ColorID,
                ProductID = PC.ProductID,
                ProductColorID = PC.ProductColorID,
            });
            var tempcolor2 = tempcolor.Where(PC => PC.ProductColorID == getidstockqty.ProductColorID).Select(C => C.ColorName);
            _PSVM.ColorName = tempcolor2.First();
            Debug.WriteLine("_PSVM.ColorName =" + _PSVM.ColorName);

            //SizeName
            var tempsize = db.ProductSizes.Join(db.Sizes, PS => PS.SizeID, S => S.SizeID, (PS, S) => new
            {
                SizeName = S.SizeName,
                SizeID = S.SizeID,
                ProductID = PS.ProductID,
                ProductSizeID = PS.ProductSizeID,
            });
            var tempsize2 = tempsize.Where(S => S.ProductSizeID == getidstockqty.ProductSizeID).Select(S => S.SizeName);
            _PSVM.SizeName = tempsize2.First();
            Debug.WriteLine("_PSVM.SizeName =" + _PSVM.SizeName);

            //StockID
            _PSVM.StockID = getidstockqty.StockID;

            //StockQTY
            _PSVM.StockQTY = getidstockqty.StockQTY;

            //MinStock
            _PSVM.MinStock = getidstockqty.MinStock;

            //SuppilerName
            var ts = _productRepository.GetById(getidstockqty.ProductID);
            var ts2 = ts.SupplierID;
            var ts3 = _supplierRepository.GetById(ts2).SupplierName;

            _PSVM.SupplierName = ts3;
            Debug.WriteLine("_PSVM.SupplierName =" + _PSVM.SupplierName);

            //訂購數量欄位
            _PSVM.OrderQTY = db.OrderDetails
                .Where(x => x.ProductID == getidstockqty.ProductID && x.ProductColorID == getidstockqty.ProductColorID
                              && x.ProductSizeID == getidstockqty.ProductSizeID && x.OrderHeader.OrderStatusID == 1).Select(x => x.OrderQTY).Count();

            //購物車訂購數量
            _PSVM.CartQTY = db.Carts.Where(x => x.ProductID == getidstockqty.ProductID && x.ProductColorID == getidstockqty.ProductColorID
                              && x.ProductSizeID == getidstockqty.ProductSizeID).Select(x => x.Quantity).Count();

            //需補貨數量
            _PSVM.AddQTY = _PSVM.CartQTY + _PSVM.OrderQTY + _PSVM.MinStock - _PSVM.StockQTY;

            return View(_PSVM);
        }

        [HttpPost]
        public ActionResult Edit(ProductStockViewModel form)
        {
            ProductStock ps = _productstockRepository.GetById(form.StockID);

            ps.StockQTY = ps.StockQTY + form.AddQTY;

            _productstockRepository.Update(ps);

            return RedirectToAction("Index","ProductStock",new { area="SK_AREA", page = TempData["page7"] });
        }

        public ActionResult GetImageByte(int? id =1)
        {
            byte[] img = db.Photos.Find(id).Photo1;

            return File(img, "image/jpg");
        }
    }
}