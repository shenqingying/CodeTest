using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.FIVES
{
    public class FIVES_CHECK_INFO_INFODETAIL
    {
        FIVES_CHECK_INFO _FIVES_CHECK_INFO;

        public FIVES_CHECK_INFO FIVES_CHECK_INFO
        {
            get { return _FIVES_CHECK_INFO; }
            set { _FIVES_CHECK_INFO = value; }
        }
        List<FIVES_CHECK_INFODETAIL> _FIVES_CHECK_INFODETAIL;

        public List<FIVES_CHECK_INFODETAIL> FIVES_CHECK_INFODETAIL
        {
            get { return _FIVES_CHECK_INFODETAIL; }
            set { _FIVES_CHECK_INFODETAIL = value; }
        }
        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
