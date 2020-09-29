using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_PD_GD_PACKINFO_SEARCH
    {
        public string GC { get; set; }         //工厂
        public string ERPNO { get; set; }      //生产订单号
        public string XSNOBILL { get; set; }   //销售订单号
        public string XSNOBILLMX { get; set; } //行项目
        public string GDDH { get; set; }       //工单单号
        public string DATE { get; set; }       //日期
        public string DATES { get; set; }      //日期范围
        public string DATEE { get; set; }      //日期范围
    }
}
