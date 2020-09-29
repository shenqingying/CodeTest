using Sonluk.UI.Model.BARCODE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sonluk.PC.Models
{
    public class BarCodingModels
    {
        SY_CODING _SY_CODING;

        public SY_CODING SY_CODING
        {
            get
            {
                if (_SY_CODING == null)
                {
                    _SY_CODING = new SY_CODING();
                }
                return _SY_CODING;
            }
            set { _SY_CODING = value; }
        }
    }
}