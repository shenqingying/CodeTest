using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_FB_ES_REPCASE
    {
        private string _RtId;

        public string RtId
        {
            get { return _RtId; }
            set { _RtId = value; }
        }
        private string _lstFillDate;

        public string LstFillDate
        {
            get { return _lstFillDate; }
            set { _lstFillDate = value; }
        }
    }
}
