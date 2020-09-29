using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.Account
{
    public class AuthorizationInfo
    {
        private string _PurchasingGroup;
        private string _ReleaseGroup;
        private string _ReleaseCode;

       
        public string PurchasingGroup
        {
            get { return _PurchasingGroup; }
            set { _PurchasingGroup = value; }
        }

        public string ReleaseGroup
        {
            get { return _ReleaseGroup; }
            set { _ReleaseGroup = value; }
        }
        public string ReleaseCode
        {
            get { return _ReleaseCode; }
            set { _ReleaseCode = value; }
        }
    }
}
