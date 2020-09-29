using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sonluk.UI.Model.OA;

namespace Sonluk.Models
{
    public class OAModels
    {
        private Pending _Pending;
        private Flow _Flow;
        public Pending Pending
        {
            get
            {
                if (_Pending == null)
                    _Pending = new Pending();
                return _Pending;
            }
            set { _Pending = value; }
        }

        public Flow Flow
        {
            get
            {
                if (_Flow == null)
                    _Flow = new Flow();
                return _Flow;
            }
            set { _Flow = value; }
        }
    }
}