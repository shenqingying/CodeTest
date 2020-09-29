using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.HR
{
    public class HR_KQ_BZ
    {
        private int _BZID;

        public int BZID
        {
            get { return _BZID; }
            set { _BZID = value; }
        }
        private string _BZNAME;

        public string BZNAME
        {
            get { return _BZNAME; }
            set { _BZNAME = value; }
        }
        private int _ISACTION;

        public int ISACTION
        {
            get { return _ISACTION; }
            set { _ISACTION = value; }
        }
        private string _REMARK;

        public string REMARK
        {
            get { return _REMARK; }
            set { _REMARK = value; }
        }
        private int _CJR;

        public int CJR
        {
            get { return _CJR; }
            set { _CJR = value; }
        }
        private int _XGR;

        public int XGR
        {
            get { return _XGR; }
            set { _XGR = value; }
        }
    }
}
