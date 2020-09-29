using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.EM
{
    public class ZSD_XBZ_MAINRESULT
    {
        EM_MISSION_IMPORT _EM_MISSION_IMPORT;

        public EM_MISSION_IMPORT EM_MISSION_IMPORT
        {
            get { return _EM_MISSION_IMPORT; }
            set { _EM_MISSION_IMPORT = value; }
        }
        List<ZSL_SDT075> _ET_TABLE;

        public List<ZSL_SDT075> ET_TABLE
        {
            get
            {
                if (_ET_TABLE == null)
                {
                    _ET_TABLE = new List<ZSL_SDT075>();
                } return _ET_TABLE;
            }
            set { _ET_TABLE = value; }
        }
        MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
        List<ZSL_SDT075_PLUS> _ET_TABLE_PLUS;

        public List<ZSL_SDT075_PLUS> ET_TABLE_PLUS
        {
            get
            {
                if (_ET_TABLE_PLUS == null)
                {
                    _ET_TABLE_PLUS = new List<ZSL_SDT075_PLUS>();
                } return _ET_TABLE_PLUS;
            }
            set { _ET_TABLE_PLUS = value; }
        }
    }
}
