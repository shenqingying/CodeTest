using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.EM
{
    public class EM_SY_MANUALPATH_SELECT
    {
        EM_SY_MANUAL _EM_SY_MANUAL;

        public EM_SY_MANUAL EM_SY_MANUAL
        {
            get { return _EM_SY_MANUAL; }
            set { _EM_SY_MANUAL = value; }
        }
        EM_SY_MANUALBB _EM_SY_MANUALBB;

        public EM_SY_MANUALBB EM_SY_MANUALBB
        {
            get { return _EM_SY_MANUALBB; }
            set { _EM_SY_MANUALBB = value; }
        }
        List<EM_SY_MANUALPATH> _EM_SY_MANUALPATH;

        public List<EM_SY_MANUALPATH> EM_SY_MANUALPATH
        {
            get { return _EM_SY_MANUALPATH; }
            set { _EM_SY_MANUALPATH = value; }
        }
        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
        List<MES_RETURN> _URLLIST;

        public List<MES_RETURN> URLLIST
        {
            get { return _URLLIST; }
            set { _URLLIST = value; }
        }
    }
}
