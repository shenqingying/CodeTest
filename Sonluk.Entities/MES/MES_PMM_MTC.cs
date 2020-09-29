using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_PMM_MTC
    {
        public int MTCID { get; set; }
        public string MID { get; set; }
        public MES_PMM_MOULD MES_PMM_MOULD { get; set; }
        public int QID { get; set; }
        public string QCODE { get; set; }
        public string QNAME { get; set; }
        public List<MES_PMM_MTC_REP> MES_PMM_MTC_REP { get; set; }
        public List<MES_PMM_MTC_CAVE> MES_PMM_MTC_CAVE { get; set; }
        public DateTime DATES { get; set; }
        public DateTime DATEE { get; set; }

        public int MMSTAFF { get; set; }
        public string MMSTAFFNAME { get; set; }
        public int MMCFM { get; set; }
        public DateTime MMDATE { get; set; }

        public int WTSTAFF { get; set; }
        public string WTSTAFFNAME { get; set; }
        public int WTCFM { get; set; }
        public DateTime WTDATE { get; set; }
        public string WTNOTES { get; set; }

        public int QCSTAFF { get; set; }
        public string QCSTAFFNAME { get; set; }
        public int QCCFM { get; set; }
        public DateTime QCDATE { get; set; }
        public string QCNOTES { get; set; }

        public int TECSTAFF { get; set; }       //STAFF
        public string TECSTAFFNAME { get; set; }
        public int TECCFM { get; set; }         //CFM
        public DateTime TECDATE { get; set; }
        public string TECNOTES { get; set; }    //NOTES

        public string STATUS { get; set; }
        public int STAFFID { get; set; }
        public string OPERATE { get; set; }

        //额外搜索项
        public DateTime DATESS { get; set; }
        public DateTime DATESE { get; set; }
        public DateTime DATEES { get; set; }
        public DateTime DATEEE { get; set; }
        public int RID { get; set; }
    }
}
