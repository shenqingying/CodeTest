using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.EM
{
    public class EM_SY_SBBHDEVICETYPESELECT
    {
        List<EM_SY_SBBHDEVICETYPELIST> _SBBHDEVICETYPEnodeList;

        public List<EM_SY_SBBHDEVICETYPELIST> SBBHDEVICETYPEnodeList
        {
            get { return _SBBHDEVICETYPEnodeList; }
            set { _SBBHDEVICETYPEnodeList = value; }
        }
        List<EM_SY_DEVICETYPE> _EM_SY_DEVICETYPEList;

        public List<EM_SY_DEVICETYPE> EM_SY_DEVICETYPEList
        {
            get { return _EM_SY_DEVICETYPEList; }
            set { _EM_SY_DEVICETYPEList = value; }
        }
        List<EM_SY_DEVICEDETAILDOC> _EM_SY_DEVICEDETAILDOCList;

        public List<EM_SY_DEVICEDETAILDOC> EM_SY_DEVICEDETAILDOCList
        {
            get { return _EM_SY_DEVICEDETAILDOCList; }
            set { _EM_SY_DEVICEDETAILDOCList = value; }
        }
        List<EM_SY_MANUALPATH> _EM_SY_MANUALPATHList;

        public List<EM_SY_MANUALPATH> EM_SY_MANUALPATHList
        {
            get { return _EM_SY_MANUALPATHList; }
            set { _EM_SY_MANUALPATHList = value; }
        }
        MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
