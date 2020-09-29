using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_SY_XTBB
    {
       
        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _NEWBB;

        public string NEWBB
        {
            get { return _NEWBB; }
            set { _NEWBB = value; }
        }

        private string _CFLJ;

        public string CFLJ
        {
            get { return _CFLJ; }
            set { _CFLJ = value; }
        }

        private int _ISACTION;

        public int ISACTION
        {
            get { return _ISACTION; }
            set { _ISACTION = value; }
        }

        private string _BBINFO;

        public string BBINFO
        {
            get { return _BBINFO; }
            set { _BBINFO = value; }
        }

        private string _SYID;

        public string SYID
        {
            get { return _SYID; }
            set { _SYID = value; }
        }

        private int _ISZXBB;

        public int ISZXBB
        {
            get { return _ISZXBB; }
            set { _ISZXBB = value; }
        }
    }
}
