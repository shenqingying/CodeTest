using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.EM
{
    public class ZSD_XBZ_CHANGEINFORESULT
    {
        MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
        List<ZSL_SDT076> _ET_TABLE;

        public List<ZSL_SDT076> ET_TABLE
        {
            get { return _ET_TABLE; }
            set { _ET_TABLE = value; }
        }

     
    }
}
