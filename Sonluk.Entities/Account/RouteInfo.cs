using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.Account
{
    public class RouteInfo
    {
        private string _Area;
        private string _Controller;
        private string _Action;
        private string _Auth;

        public string Area
        {
            get { return _Area; }
            set { _Area = value; }
        }
        public string Controller
        {
            get { return _Controller; }
            set { _Controller = value; }
        }
        public string Action
        {
            get { return _Action; }
            set { _Action = value; }
        }
        public string Auth
        {
            get { return _Auth; }
            set { _Auth = value; }
        }
    }
}
