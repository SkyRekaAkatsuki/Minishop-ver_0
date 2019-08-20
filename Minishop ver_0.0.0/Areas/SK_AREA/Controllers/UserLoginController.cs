using Minishop_ver_0._0._0.Areas.SK_AREA.Models;
using Minishop_ver_0._0._0.Areas.SK_AREA.Models.Cs_Library.DataService;
using Minishop_ver_0._0._0.Areas.SK_AREA.Models.Cs_Library.UserMember;
using Minishop_ver_0._0._0.Areas.SK_AREA.Models.ViewModel;
using Minishop_ver_0._0._0.Areas.SK_AREA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Minishop_ver_0._0._0.Areas.SK_AREA.Controllers
{
    public class UserLoginController : Controller
    {
        FancyStoreEntities db = new FancyStoreEntities();

        // GET: SK_AREA/UserLogin
        public ActionResult Index()
        {
            if (Request.Cookies["IsLogin"] != null)
            {
                return RedirectToAction("IndexFirstLoadRAM", "SeOmiseRAM", new { area = "SK_AREA" });
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register(RegisterViewModel form)
        {
            UserDataService _uds = new UserDataService();
            ValidateService _dvs = new ValidateService();

            if (_uds.CheckUserData(form.UserName) || _uds.CheckEmailData(form.Email))
            {
                return Json("註冊資料重複");
            }
            if(_dvs.IsValidEmail(form.Email) || _dvs.IsValidPhone(form.Phone))
            {
                string _guid = Guid.NewGuid().ToString("N");

                User _usertable = new User();

                _usertable.UserName = form.UserName;
                _usertable.UserPassword = _dvs.SHAcode(form.UserPassword, _guid);
                _usertable.Email = form.Email;
                _usertable.Phone = form.Phone;
                _usertable.GUID = _guid;
                _usertable.RegistrationDate = DateTime.Now;
                _usertable.RegionID = form.RegionID;
                _usertable.Enabled = true;
                _usertable.Address = form.Address;
                _usertable.Gender = form.Gender;

                if (_uds.AddNewUser(_usertable))
                {
                    return Json("成功");
                }
                else
                {
                    return Json("失敗");
                }
            }
            else
            {
                return Json("資料格式不正確");
            }

        }

        public ActionResult ReturnCity()
        {
            UserDataService _uds = new UserDataService();
            return Json(_uds.CityJson(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult ReturnRegion(int? cid = 3)
        {
            UserDataService _uds = new UserDataService();
            return Json(_uds.RegionJson(cid), JsonRequestBehavior.AllowGet);
        }
    }
}