using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.FIVES
{
    public class FIVES_SY_CHECKPOINT_CREATE
    {
        FIVES_SY_CHECKPOINT _FIVES_SY_CHECKPOINT;

        public FIVES_SY_CHECKPOINT FIVES_SY_CHECKPOINT
        {
            get { return _FIVES_SY_CHECKPOINT; }
            set { _FIVES_SY_CHECKPOINT = value; }
        }
        List<FIVES_SY_DICT> _GW;

        public List<FIVES_SY_DICT> GW
        {
            get { return _GW; }
            set { _GW = value; }
        }


        List<FIVES_SY_CHECKDETAILS> _CHECKDETAI;

        public List<FIVES_SY_CHECKDETAILS> CHECKDETAI
        {
            get { return _CHECKDETAI; }
            set { _CHECKDETAI = value; }
        }
        List<FIVES_CHECK_INFODETAILList> _LASTCHECKINFODETAIL;

        public List<FIVES_CHECK_INFODETAILList> LASTCHECKINFODETAIL
        {
            get { return _LASTCHECKINFODETAIL; }
            set { _LASTCHECKINFODETAIL = value; }
        }
        MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
        FIVES_SY_STAFF_DEPList _FIVES_SY_STAFF_DEPList;

        public FIVES_SY_STAFF_DEPList FIVES_SY_STAFF_DEPList
        {
            get { return _FIVES_SY_STAFF_DEPList; }
            set { _FIVES_SY_STAFF_DEPList = value; }
        }

        List<FIVES_SY_RELATIONSHIPBINDList> _GWLIST;

        public List<FIVES_SY_RELATIONSHIPBINDList> GWLIST
        {
            get { return _GWLIST; }
            set { _GWLIST = value; }
        }
        List<FIVES_SY_RELATIONSHIPBINDList> _MXLIST;

        public List<FIVES_SY_RELATIONSHIPBINDList> MXLIST
        {
            get { return _MXLIST; }
            set { _MXLIST = value; }
        }
        List<FIVES_SY_DICT> _PFLIST;

        public List<FIVES_SY_DICT> PFLIST
        {
            get { return _PFLIST; }
            set { _PFLIST = value; }
        }
        List<FIVES_SY_RELATIONSHIPBINDList> _FLlist;

        public List<FIVES_SY_RELATIONSHIPBINDList> FLlist
        {
            get { return _FLlist; }
            set { _FLlist = value; }
        }
        string _jydStr;

        public string JydStr
        {
            get { return _jydStr; }
            set { _jydStr = value; }
        }

    }
}
