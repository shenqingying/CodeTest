using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.BC
{
    public class StorageIdentification
    {
        private Byte[] identificationPDF;
        private List<ZSL_BCS104> zsl_bcs104;
        private string et_return;

        public string ET_RETURN
        {
            get { return et_return; }
            set { et_return = value; }
        }

        public Byte[] IdentificationPDF
        {
            get { return identificationPDF; }
            set { identificationPDF = value; }
        }

        public List<ZSL_BCS104> Zsl_bcs104
        {
            get { return zsl_bcs104; }
            set { zsl_bcs104 = value; }
        }
    }
}
