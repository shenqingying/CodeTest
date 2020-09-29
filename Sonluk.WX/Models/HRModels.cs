using Sonluk.UI.Model.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sonluk.WX.Models
{
    public class HRModels
    {
        private SY_DEPT _SY_DEPT;

        public SY_DEPT SY_DEPT
        {
            get
            {
                if (_SY_DEPT == null)
                {
                    _SY_DEPT = new SY_DEPT();
                } return _SY_DEPT;
            }
            set { _SY_DEPT = value; }
        }
    }
}