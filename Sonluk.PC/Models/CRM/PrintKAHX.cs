using Sonluk.UI.Model.CRM.COST_KAHXDJMXService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sonluk.PC.Models.CRM
{
    public class PrintKAHX
    {



        CRM_COST_KAHXDJMX[] _KAHXDJMX;

        public CRM_COST_KAHXDJMX[] KAHXDJMX
        {
            get { return _KAHXDJMX; }
            set { _KAHXDJMX = value; }
        }

        KAHXDJMX_HZ[] _HZ;

        public KAHXDJMX_HZ[] HZ
        {
            get { return _HZ; }
            set { _HZ = value; }
        }

        public class KAHXDJMX_HZ
        {
            string _GNAME;

            public string GNAME
            {
                get { return _GNAME; }
                set { _GNAME = value; }
            }
            string _CWHSBH;

            public string CWHSBH
            {
                get { return _CWHSBH; }
                set { _CWHSBH = value; }
            }
            string _CBZXBH;

            public string CBZXBH
            {
                get { return _CBZXBH; }
                set { _CBZXBH = value; }
            }
            string _CWHSBHDES;

            public string CWHSBHDES
            {
                get { return _CWHSBHDES; }
                set { _CWHSBHDES = value; }
            }
            string _HXJE;

            public string HXJE
            {
                get { return _HXJE; }
                set { _HXJE = value; }
            }

            public string FKFSAPSN { get => _FKFSAPSN; set => _FKFSAPSN = value; }
            public string BEIZ { get => _BEIZ; set => _BEIZ = value; }

            string _FKFSAPSN;
            string _BEIZ;

        }








    }
}