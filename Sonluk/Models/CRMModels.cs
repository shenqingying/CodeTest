using Sonluk.UI.Model.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sonluk.Models
{
    public class CRMModels
    {
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