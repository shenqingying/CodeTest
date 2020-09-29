using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_SY_TYPEMXLIST_GZZX_GW
    {
        private List<MES_SY_TYPEMXLIST> _MES_SY_TYPEMXLIST;

        public List<MES_SY_TYPEMXLIST> MES_SY_TYPEMXLIST
        {
            get { return _MES_SY_TYPEMXLIST; }
            set { _MES_SY_TYPEMXLIST = value; }
        }

        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
