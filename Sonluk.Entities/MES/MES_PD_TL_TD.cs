using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_PD_TL_TD
    {
        private string _TDNO;

        public string TDNO
        {
            get { return _TDNO; }
            set { _TDNO = value; }
        }
        private string _SBBH;

        public string SBBH
        {
            get { return _SBBH; }
            set { _SBBH = value; }
        }

        private string _TDREMARK;

        public string TDREMARK
        {
            get { return _TDREMARK; }
            set { _TDREMARK = value; }
        }
        private string _GC;

        public string GC
        {
            get { return _GC; }
            set { _GC = value; }
        }
        private string _GZZXBH;

        public string GZZXBH
        {
            get { return _GZZXBH; }
            set { _GZZXBH = value; }
        }
        private string _SBMS;

        public string SBMS
        {
            get { return _SBMS; }
            set { _SBMS = value; }
        }
    }
}
