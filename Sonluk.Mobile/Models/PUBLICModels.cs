using Sonluk.UI.Model.PUBLICFUN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sonluk.Mobile.Models
{
    public class PUBLICModels
    {
        private PUBLICFUN _PUBLICFUN;

        public PUBLICFUN PUBLICFUN
        {
            get
            {
                if (_PUBLICFUN == null)
                    _PUBLICFUN = new PUBLICFUN();
                return _PUBLICFUN;
            }
            set { _PUBLICFUN = value; }
        }
    }
}