using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sonluk.WX.APPCLASS
{
    public class AppClass
    {
        public static object GetSession(string name)
        {
            if (HttpContext.Current.Session[name] == null)
                return "";
            else
                return HttpContext.Current.Session[name];
        }
        /// <summary>
        /// 设置session
        /// </summary>
        /// <param name="name">session 名</param>
        /// <param name="val">session 值</param>
        public static void SetSession(string name, object val)
        {
            HttpContext.Current.Session.Remove(name);
            HttpContext.Current.Session.Add(name, val);
        }


        public string CRM_Gettoken()
        {
            if (HttpContext.Current.Session["token"] == null)
                return "";
            else
                return HttpContext.Current.Session["token"].ToString();
        }
        public int CRM_GetStaffid()
        {
            if (HttpContext.Current.Session["STAFFID"] == null)
                return 0;
            else
                return Convert.ToInt32(HttpContext.Current.Session["STAFFID"]);
        }

        public string CRM_GetStaffName()
        {
            if (HttpContext.Current.Session["NAME"] == null)
                return "";
            else
                return Convert.ToString(HttpContext.Current.Session["NAME"]);
        }

    }
}