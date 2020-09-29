using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_SY_TYPEMX_CHILD
    {
        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private int _ZTYPEID;

        public int ZTYPEID
        {
            get { return _ZTYPEID; }
            set { _ZTYPEID = value; }
        }
        private int _ISSHOW;

        public int ISSHOW
        {
            get { return _ISSHOW; }
            set { _ISSHOW = value; }
        }
    }
}
