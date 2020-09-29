using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.Master
{
    public class DiscountInfo
    {
        private decimal _Available;
        private decimal _Rate;

        public decimal Available
        {
            get { return _Available; }
            set { _Available = value; }
        }
        public decimal Rate
        {
            get { return _Rate; }
            set { _Rate = value; }
        }
    }
}
