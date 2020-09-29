using Sonluk.UI.Model.QM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sonluk.PC.Models
{
    public class QMModels
    {
        private ZSL_QMFG_RFC _ZSL_QMFG_RFC;

        public ZSL_QMFG_RFC ZSL_QMFG_RFC
        {
            get
            {
                if (_ZSL_QMFG_RFC == null)
                    _ZSL_QMFG_RFC = new ZSL_QMFG_RFC();
                return _ZSL_QMFG_RFC;
            }
            set { _ZSL_QMFG_RFC = value; }
        }
    }
}