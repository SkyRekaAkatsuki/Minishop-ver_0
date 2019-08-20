using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Minishop_ver_0._0._0.Areas.SK_AREA.Models.Cs_Library.UserMember
{
    public class UserDataService
    {
        private FancyStoreEntities db = new FancyStoreEntities();

        public static string _upid { get; set; }
        
        #region 檢查帳號是否重複
        public bool CheckUserData(string Account)
        {
            return db.Users.Any(A => A.UserName == Account);
        }
        #endregion

        #region 檢查電子郵件是否重複
        public bool CheckEmailData(string Email)
        {
            return db.Users.Any(A => A.Email == Email);
        }
        #endregion

        #region 增加新會員
        public bool AddNewUser(User _usertable)
        {
            try
            {
                db.Users.Add(_usertable);
                db.SaveChanges();
                //string _tempid = db.Users.Where(W => W.UserName == _usertable.UserName).
                //                                Select(S => S.UserID).First().ToString();
                //_upid = _tempid;
                _upid = _usertable.UserID.ToString();
                return true;
            }
            catch (Exception ex)
            {
                string _s = ex.Message;
                return false;
            }
        }
        #endregion

        #region 城市資料
        public IEnumerable<CityJson> CityJson()
        {
            return db.Cities.Select(n => new CityJson { cityid = n.CityID, cityname = n.CityName }).ToList();
        }
        #endregion

        #region 地區資料
        public IEnumerable<ReginJson> RegionJson(int? cid)
        {
            return db.Regions.Where(n => n.CityID == cid).Select(n => new ReginJson { regionid = n.RegionID, regionname = n.RegionName }).ToList();
        }
        #endregion
    }

    public class ReginJson
    {
        public int regionid { get; set; }
        public string regionname { get; set; }
    }

    public class CityJson
    {
        public int cityid { get; set; }
        public string cityname { get; set; }
    }

}