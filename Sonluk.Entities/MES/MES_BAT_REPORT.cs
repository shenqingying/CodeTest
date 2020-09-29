using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_BAT_REPORT
    {
        //报表基础内容
        public string GC { get; set; }             //工厂
        public string ERPNO { get; set; }          //生产订单号
        public string XSNOBILL { get; set; }       //销售订单号
        public string XSNOBILLMX { get; set; }     //行项目
        public string WLH { get; set; }            //物料号
        public string WLMS { get; set; }           //物料描述
        public int COUNTZ { get; set; }            //订单数量（只）
        public string SCX { get; set; }            //生产线
        public string DATE { get; set; }           //素电日期
        public string JSDATE { get; set; }         //订单完工日期

        //电池规格                                 
        public string DCXH { get; set; }           //电池规格

        public string DCBZK { get; set; }          //电池开路电压
        public string DCMAXK { get; set; }
        public string DCMINK { get; set; }

        public string DCBZA { get; set; }          //电池尺寸A
        public string DCMAXA { get; set; }
        public string DCMINA { get; set; }

        public string DCBZB { get; set; }          //电池尺寸B
        public string DCMAXB { get; set; }
        public string DCMINB { get; set; }

        public string DCBZC { get; set; }          //电池尺寸C
        public string DCMAXC { get; set; }
        public string DCMINC { get; set; }

        public string SDLX { get; set; }           //素电类型
        public string DCFDFS { get; set; }
        public string DCMAD { get; set; }

        //电池规格抽样范围
        public string SZA { get; set; }
        public string SZB { get; set; }
        public string SZC { get; set; }
        public string SZK { get; set; }
        public string SZDXN { get; set; }

        //外观与包装
        public string GDDH { get; set; }           //工单单号
        public string COUNTX { get; set; }         //订单数量（箱）
        public string CODOWORD { get; set; }       //电池喷码
        public string SNINFO { get; set; }         //检验标准
        public string WORDSPACE { get; set; }      //喷码位置
        public string CXS { get; set; }            //检验水平（抽箱数）
        public string WG { get; set; }             //检验水平（外观）
        public string KPRQM { get; set; }          //卡片日期唛

        //抽样数
        public int SAMP1 { get; set; }             //漏液（新电）
        public int SAMP2 { get; set; }             //电池生锈
        public int SAMP3 { get; set; }             //日期唛
        public int SAMP4 { get; set; }             //电池外观
        public int PACKOPEN { get; set; }          //开箱数


        //额外参数
        public string File { get; set; }           //文件路径
        public MES_RETURN MES_RETURN { get; set; }
    }
}
