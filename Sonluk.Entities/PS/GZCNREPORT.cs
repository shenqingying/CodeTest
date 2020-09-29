using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.PS
{
    public class GZCNREPORT
    {
        List<ZSL_GZCN> _ET_GZCN_PAST;

        public List<ZSL_GZCN> ET_GZCN_PAST
        {
            get { return _ET_GZCN_PAST; }
            set { _ET_GZCN_PAST = value; }
        }
        List<ZSL_GZCN> _ET_GZCN_ED;

        public List<ZSL_GZCN> ET_GZCN_ED
        {
            get { return _ET_GZCN_ED; }
            set { _ET_GZCN_ED = value; }
        }
        List<ZSL_GZCN> _ET_GZCN_SJ;

        public List<ZSL_GZCN> ET_GZCN_SJ
        {
            get { return _ET_GZCN_SJ; }
            set { _ET_GZCN_SJ = value; }
        }
        string _ES_DATE;

        public string ES_DATE
        {
            get { return _ES_DATE; }
            set { _ES_DATE = value; }
        }
        string _ES_INTERVAL;

        public string ES_INTERVAL
        {
            get { return _ES_INTERVAL; }
            set { _ES_INTERVAL = value; }
        }
        PS_MSG _PS_MSG;

        public PS_MSG PS_MSG
        {
            get { return _PS_MSG; }
            set { _PS_MSG = value; }
        }
    }
}
