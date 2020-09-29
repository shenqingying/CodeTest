using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sonluk.UI.Model.CRM;
using Sonluk.UI.Model.MES;

namespace Sonluk.Mobile.Models
{
    public class AccountModels
    {
        //private Access _Access;
        //private UserToken _UserToken;

        //public UserToken UserToken
        //{
        //    get
        //    {
        //        if (_UserToken == null)
        //            _UserToken = new UserToken();
        //        return _UserToken;
        //    }
        //    set { _UserToken = value; }
        //}

        //public Access Access
        //{
        //    get
        //    {
        //        if (_Access == null)
        //            _Access = new Access();
        //        return _Access;
        //    }
        //    set { _Access = value; }
        //}

        private CRM_Login _CRM_Login;

        public CRM_Login CRM_Login
        {
            get
            {
                if (_CRM_Login == null)
                    _CRM_Login = new CRM_Login();
                return _CRM_Login;
            }
            set { _CRM_Login = value; }
        }

        private RIGHT_ROLE _RIGHT_ROLE;

        public RIGHT_ROLE RIGHT_ROLE
        {
            get
            {
                if (_RIGHT_ROLE == null)
                    _RIGHT_ROLE = new RIGHT_ROLE();
                return _RIGHT_ROLE;
            }
            set { _RIGHT_ROLE = value; }
        }

        private HG_STAFF _HG_STAFF;

        public HG_STAFF HG_STAFF
        {
            get
            {
                if (_HG_STAFF == null)
                    _HG_STAFF = new HG_STAFF();
                return _HG_STAFF;
            }
            set { _HG_STAFF = value; }
        }
    }
}