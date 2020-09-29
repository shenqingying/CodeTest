using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sonluk.WX.Models
{
    public class DXM
    {
        public class TravelTrafficInfoComparer : IEqualityComparer<DXM>
        {
            #region IEqualityComparer<User> 成员
            public bool Equals(DXM x, DXM y)
            {
                if (x.Dxm == y.Dxm)
                    return true;
                else
                    return false;
            }

            public int GetHashCode(DXM obj)
            {
                return 0;
            }
            #endregion
        }
        string _dxm;

        public string Dxm
        {
            get { return _dxm; }
            set { _dxm = value; }
        }
    }
}