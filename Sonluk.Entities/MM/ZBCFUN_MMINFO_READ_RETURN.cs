using Sonluk.Entities.BC;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MM
{
    public class ZBCFUN_MMINFO_READ_RETURN
    {
        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
        private List<ZSL_BCS112> _ET_MATDATA_H;

        public List<ZSL_BCS112> ET_MATDATA_H
        {
            get { return _ET_MATDATA_H; }
            set { _ET_MATDATA_H = value; }
        }
        private List<ZSL_BCS112> _ET_MATDATA_I;

        public List<ZSL_BCS112> ET_MATDATA_I
        {
            get { return _ET_MATDATA_I; }
            set { _ET_MATDATA_I = value; }
        }

    }
}
