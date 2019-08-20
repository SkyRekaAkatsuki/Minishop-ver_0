using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Text;
using System.Security.Cryptography;

namespace Minishop_ver_0._0._0.Areas.SK_AREA.Models.Cs_Library.DataService
{
    public class ValidateService
    {
        #region 電子郵件格式驗證
        public bool IsValidEmail(string Email)
        {
            if (string.IsNullOrWhiteSpace(Email))
            {
                return false;
            }
            else
            {
                return Regex.IsMatch(Email, @"([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})", RegexOptions.IgnoreCase);
            }
        }
        #endregion

        #region 電話格式驗證
        public bool IsValidPhone(string Phone)
        {
            if (string.IsNullOrWhiteSpace(Phone))
            {
                return false;
            }
            else
            {
                return Regex.IsMatch(Phone, @"(\(?\d{3,4}\)?)?[\s-]?\d{7,8}[\s-]?\d{0,4}");
            }
        }
        #endregion

        #region GUID雜湊
        public byte[] SHAcode(string Pas, string Guid)
        {
            string _code = Pas + Guid;
            byte[] _Tobytecode = Encoding.Unicode.GetBytes(_code);
            SHA256Managed _sha256 = new SHA256Managed();
            byte[] _turncode = _sha256.ComputeHash(_Tobytecode);
            return _turncode;
        }
        #endregion

    }
}