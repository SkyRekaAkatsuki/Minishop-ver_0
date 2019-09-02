using Minishop_ver_0._0._0.Areas.SK_AREA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using NPOI.XSSF.UserModel;
using System.IO;
using NPOI.SS.UserModel;

namespace Minishop_ver_0._0._0.Areas.SK_AREA.Controllers
{
public class ColorController : Controller
    {
        FancyStoreEntities db = new FancyStoreEntities();

        // GET: SK_AREA/Color
        public ActionResult Index(int? page)
        {
            if (HttpContext.Request.Cookies["IsLogin"].Value == "Admin")
            {
                TempData["page1"] = page ?? 1;
                //var tempcolorid = db.Colors.Select(S => S.ColorID);
                //db.Colors.Find(tempcolorid);
                return View(db.Colors.ToList().ToPagedList(page ?? 1, 5));
            }
            else
            {
                RedirectToAction("PermissionError", "ProductMaintain");
            }
            return View();
        }

        //Excel 檔案下載
        [HttpPost]
        public ActionResult Download(string downloadfile)
        {
            string[] titleList = new string[] { "顏色ID", "顏色", "三原色的 R", "三原色的 G", "三原色的 B"};
            var list = db.Colors.ToList();//獲取資料方法

            //建立工作簿
            XSSFWorkbook workbook = new XSSFWorkbook();

            //建立sheet
            ISheet sheet1 = workbook.CreateSheet("sheet1");

            //給sheet1新增第一行的頭部標題
            IRow headerrow = sheet1.CreateRow(0);

            XSSFCellStyle headStyle = (XSSFCellStyle)workbook.CreateCellStyle();
            XSSFFont font = (XSSFFont)workbook.CreateFont();
            font.FontHeightInPoints = 10;
            font.Boldweight = 700;
            headStyle.SetFont(font);
            for (int i = 0; i < titleList.Length; i++)
            {
                ICell cell = headerrow.CreateCell(i);
                cell.CellStyle = headStyle;
                cell.SetCellValue(titleList[i]);
            }

            //將資料逐步寫入sheet1各個行
            for (int i = 0; i < list.Count ; i++)
            {
                NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(i + 1);
                rowtemp.CreateCell(0).SetCellValue(list[i].ColorID);
                rowtemp.CreateCell(1).SetCellValue(Convert.ToString(list[i].ColorName));
                rowtemp.CreateCell(2).SetCellValue(Convert.ToInt32(list[i].R));
                rowtemp.CreateCell(3).SetCellValue(Convert.ToInt32(list[i].G));
                rowtemp.CreateCell(4).SetCellValue(Convert.ToInt32(list[i].B));
            }

            // 寫入到客戶端 
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            
            workbook.Write(ms);
            return this.File(ms.ToArray(), "application/vnd.ms-excel", "顏色資料表.xlsx");
        }

        //Excel 檔案上傳
        

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase uploadfile)
        {
            if (Request.Files["uploadfile"].ContentLength > 0)
            {
                string extension =
                    System.IO.Path.GetExtension(uploadfile.FileName);

                if (extension == ".xls" || extension == ".xlsx")
                {
                    string fileLocation = Server.MapPath("~/Content/") + Request.Files["uploadfile"].FileName;
                    if (System.IO.File.Exists(fileLocation)) // 驗證檔案是否存在
                    {
                        System.IO.File.Delete(fileLocation);
                    }

                    Request.Files["uploadfile"].SaveAs(fileLocation); // 存放檔案到伺服器上

                    // 建立一個工作簿
                    XSSFWorkbook excel;

                    // 檔案讀取
                    using (FileStream files = new FileStream(fileLocation, FileMode.Open, FileAccess.Read))
                    {
                        excel = new XSSFWorkbook(files); // 將剛剛的Excel 讀取進入到工作簿中
                    }

                    // Excel 的哪一個活頁簿，有兩種方式可以取得活頁簿
                    ISheet sheet = excel.GetSheetAt(0);  // 在第幾個活頁簿，饅頭建議使用，畢竟我們不知道使用者會把活頁部取神麼名字，先抓地一個在說！(從0開始計算)

                    for (int row = 1; row <= sheet.LastRowNum; row++) // 使用For 走訪所有的資料列
                    {
                        if (sheet.GetRow(row) != null) // 驗證是不是空白列
                        {
                            Color _npoi = new Color();
                            for (int c = 0; c <= sheet.GetRow(row).LastCellNum; c++) // 使用For 走訪資料欄
                            {
                                switch (c)
                                {
                                    case 0:
                                        _npoi.ColorID = 
                                            sheet.GetRow(row).GetCell(c).RowIndex;
                                        break;
                                    case 1:
                                        _npoi.ColorName = 
                                            sheet.GetRow(row).GetCell(c).StringCellValue;
                                        break;
                                    case 2:
                                        _npoi.R = 
                                            Convert.ToInt32
                                            (sheet.GetRow(row).GetCell(c).NumericCellValue);
                                        break;
                                    case 3:
                                        _npoi.G = 
                                            Convert.ToInt32
                                            (sheet.GetRow(row).GetCell(c).NumericCellValue);
                                        break;
                                    case 4:
                                        _npoi.B = 
                                            Convert.ToInt32
                                            (sheet.GetRow(row).GetCell(c).NumericCellValue);
                                        break;
                                }
                            }
                            db.Entry(_npoi).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                        }
                    } 
                }
            }
            return this.RedirectToAction("Index");
        }
    }
}