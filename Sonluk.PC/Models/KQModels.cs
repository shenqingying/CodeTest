using Sonluk.UI.Model.KQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sonluk.PC.Models
{
    public class KQModels
    {
        private KQinfo _KQinfo;

        public KQinfo KQinfo
        {
            get
            {
                if (_KQinfo == null)
                    _KQinfo = new KQinfo();
                return _KQinfo;
            }
            set { _KQinfo = value; }
        }
    }
}