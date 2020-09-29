using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_PMM_QR
    {
        public int QID { get; set; }
        public string QCODE { get; set; }
        public string QNAME { get; set; }
        public int QISACTION { get; set; }

        public int RID { get; set; }
        public string RCODE { get; set; }
        public string RNAME { get; set; }
        public int RISACTION { get; set; }
    }
}
