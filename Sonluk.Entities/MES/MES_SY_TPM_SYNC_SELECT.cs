using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_SY_TPM_SYNC_SELECT
    {
        private List<MES_SY_TPM_SYNC> _MES_SY_TPM_SYNC;

        public List<MES_SY_TPM_SYNC> MES_SY_TPM_SYNC
        {
            get { return _MES_SY_TPM_SYNC; }
            set { _MES_SY_TPM_SYNC = value; }
        }
        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
        private List<MES_SY_TPM_SYNC> _MES_SY_TPM_SYNC_DELETE;

        public List<MES_SY_TPM_SYNC> MES_SY_TPM_SYNC_DELETE
        {
            get { return _MES_SY_TPM_SYNC_DELETE; }
            set { _MES_SY_TPM_SYNC_DELETE = value; }
        }

    }
}
