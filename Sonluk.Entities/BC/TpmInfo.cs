using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.BC
{
    public class TpmInfo
    {
        private List<ZSL_BCS205> et_tpm;
        private string _O_MESSAGE;

        public string O_MESSAGE
        {
            get { return _O_MESSAGE; }
            set { _O_MESSAGE = value; }
        }

        public List<ZSL_BCS205> Et_tpm
        {
            get { return et_tpm; }
            set { et_tpm = value; }
        }

    }
}
