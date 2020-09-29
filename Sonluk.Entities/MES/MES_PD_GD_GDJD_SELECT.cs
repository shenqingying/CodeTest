using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_PD_GD_GDJD_SELECT
    {
        List<MES_PD_GD_GDJD_EXPORT> _MES_PD_GD_GDJD_EXPORT;

        public List<MES_PD_GD_GDJD_EXPORT> MES_PD_GD_GDJD_EXPORT
        {
            get { return _MES_PD_GD_GDJD_EXPORT; }
            set { _MES_PD_GD_GDJD_EXPORT = value; }
        }
        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }

        ZBCFUN_GDRKS_READ _ZBCFUN_GDRKS_READ;

        public ZBCFUN_GDRKS_READ ZBCFUN_GDRKS_READ
        {
            get { return _ZBCFUN_GDRKS_READ; }
            set { _ZBCFUN_GDRKS_READ = value; }
        }
        
    }
}
