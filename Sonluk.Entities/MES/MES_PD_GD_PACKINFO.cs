using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_PD_GD_PACKINFO
    {
        //包装信息
        public string GDDH { get; set; }           //工单单号
        public string COUNTX { get; set; }         //订单数量（箱）
        public string CODOWORD { get; set; }       //电池喷码
        public string SNINFO { get; set; }         //检验标准
        public string WORDSPACE { get; set; }      //喷码位置
        public string CXS { get; set; }            //检验水平（抽箱数）
        public string WG { get; set; }             //检验水平（外观）
        public string KPRQM { get; set; }          //卡片日期唛
        public string INSULATION { get; set; }     //绝缘圈
        public bool ISPACK { get; set; }           //是否填写

        //辅助信息
        public string GC { get; set; }             //工厂
        public string ERPNO { get; set; }          //生产订单号
        public string XSNOBILL { get; set; }       //销售订单号
        public string XSNOBILLMX { get; set; }     //行项目
        public string WLH { get; set; }            //物料号
        public string WLMS { get; set; }           //物料描述
        public string DCXHNAME { get; set; }       //电池型号
        public string DCDJNAME { get; set; }       //电池电极
        public string JSDATE { get; set; }         //订单完工日期
        public int SL { get; set; }                //订单数量（只）
        public MES_RETURN MES_RETURN { get; set; } //返回信息
    }
}
