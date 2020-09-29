using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.FICO
{
    public class FICO_FM_ElectricInvoice
    {
        public int ID { get; set; }
        public string FPDM { get; set; }
        public string FPHM { get; set; }
        public string KPRQ { get; set; }
        public string JYM { get; set; }
        public decimal AMOUNT { get; set; }
        public string PZBH { get; set; }
        public string BEIZ { get; set; }
        public int ISACTIVE { get; set; }
        public string BXR { get; set; }
        public int CJR { get; set; }
        public string CJSJ { get; set; }
        public int XGR { get; set; }
        public string XGSJ { get; set; }
        public string KJND { get; set; }
        public string CJRDES { get; set; }
        public string XGRDES { get; set; }
        public string BEGIN_AMOUNT { get; set; }
        public string END_AMOUNT { get; set; }
        public string BEGIN_CJSJ { get; set; }
        public string END_CJSJ { get; set; }
        public string BEGIN_KPRQ { get; set; }
        public string END_KPRQ { get; set; }
        public string SELECT_CJR { get; set; }
        public string GS { get; set; }
        public string GSNAME { get; set; }
        public string SELECT_GS { get; set; }

    }
}
