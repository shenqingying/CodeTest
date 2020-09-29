using Sonluk.UI.Model.Print;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sonluk.Models
{
    public class PrintModels
    {
        private Layout _Layout;

        public Layout Layout
        {
            get
            {
                if (_Layout == null)
                    _Layout = new Layout();
                return _Layout;
            }
            set { _Layout = value; }
        }
    }
}