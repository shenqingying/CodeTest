using Sonluk.UI.Model.MES.TM_TMINFOService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sonluk.PC.Models.WMS
{
    public class PrintTM
    {
        MES_TM_TMINFO_LIST _TMTT;
        List<MES_TM_TMINFO_LIST> _TMMX;

        public List<MES_TM_TMINFO_LIST> TMMX { get => _TMMX; set => _TMMX = value; }
        public MES_TM_TMINFO_LIST TMTT { get => _TMTT; set => _TMTT = value; }
    }
}