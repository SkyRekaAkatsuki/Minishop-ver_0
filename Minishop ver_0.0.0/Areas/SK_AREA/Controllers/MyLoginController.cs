using Minishop_ver_0._0._0.Areas.SK_AREA.Models;
using Minishop_ver_0._0._0.Areas.SK_AREA.Models.Cs_Library.DataService;
using Minishop_ver_0._0._0.Areas.SK_AREA.Models.Cs_Library.UserMember;
using Minishop_ver_0._0._0.Areas.SK_AREA.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Minishop_ver_0._0._0.Areas.SK_AREA.Controllers
{
    public class MyLoginController : Controller
    {
        FancyStoreEntities db = new FancyStoreEntities();

        // GET: SK_AREA/MyLogin
        public ActionResult Index()
        {
            if (Request.Cookies["IsLogin"] != null)
            {
                return RedirectToAction("IndexFirstLoadRAM", "SeOmiseRAM", new { area = "SK_AREA" });
            }
            return RedirectToAction("Login", "MyLogin", new { area = "SK_AREA" });
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel form)
        {
            ValidateService _dvs = new ValidateService();

            if (db.Users.Any(A=>A.UserName == form.UserName))
            {
                var _u = db.Users.Where(W => W.UserName == form.UserName).Select(S => new
                {
                    S.GUID,
                    S.UserPassword,
                });
                string _guid = _u.Select(S => S.GUID).First();
                byte[] _temp = _dvs.SHAcode(form.UserPassword, _guid);
                
                byte[] _pas = _u.Select(S => S.UserPassword).First();

                if (_pas.ToString() == _temp.ToString())
                {
                    Response.Cookies["IsLogin"].Value = "1";
                    Response.Cookies["IsLogin"].Expires = DateTime.Now.AddDays(7);
                    return RedirectToAction("IndexFirstLoadRAM", "SeOmiseRAM", new { area = "SK_AREA" });
                }
            }
            else
            {
                return View();
            }
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel form)
        {
            if (Request.Form.Count > 0)
            {

                ValidateService _dvs = new ValidateService();

                string _guid = Guid.NewGuid().ToString("N");

                User _usertable = new User();

                string _Pas = form.UserPassword;

                _usertable.UserName = form.UserName;
                _usertable.UserPassword = _dvs.SHAcode(_Pas, _guid);
                _usertable.Email = form.Email;
                _usertable.Phone = form.Phone;
                _usertable.GUID = _guid;
                _usertable.RegistrationDate = DateTime.Now;
                _usertable.RegionID = form.RegionID;
                _usertable.Enabled = true;
                _usertable.Address = form.Address;
                _usertable.Gender = form.Gender;

                db.Users.Add(_usertable);
                db.SaveChanges();

                return RedirectToAction("Login", "MyLogin", new { area = "SK_AREA" });
            }
            return View();
        }


    }
}