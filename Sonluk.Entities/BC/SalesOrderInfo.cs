using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.BC
{
    public class SalesOrderInfo
    {
        private List<ZSL_SDS013> t_dd;

        public List<ZSL_SDS013> T_dd
        {
            get { return t_dd; }
            set { t_dd = value; }
        }

        private List<ZSL_SDS015> t_dd_1;

        public List<ZSL_SDS015> T_dd_1
        {
            get { return t_dd_1; }
            set { t_dd_1 = value; }
        }
    }
}
