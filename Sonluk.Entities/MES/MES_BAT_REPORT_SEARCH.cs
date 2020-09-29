using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_BAT_REPORT_SEARCH
    {
        public string ERPNO { get; set; } //生产订单号
        public string XSNOBILL { get; set; } //销售订单号
        public string XSNOBILLMX { get; set; } //销售订单项目
    }
}
