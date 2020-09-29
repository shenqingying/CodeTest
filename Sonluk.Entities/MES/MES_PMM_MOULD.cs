using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_PMM_MOULD
    {
        public string MID { get; set; }
        public string GC { get; set; }                               //搜索条件
        public string GCMS { get; set; }            //GC中文
        public string GZZXBH { get; set; }                           //搜索条件
        public string GZZXMS { get; set; }          //GZZXBH中文
        public int WLLBID { get; set; }             
        public string WLLBNAME { get; set; }        //WLLBID中文
        public string WLH { get; set; }                              //搜索条件（WLH和WLMS）
        public string WLMS { get; set; }            //WLH中文
        public string SBBH { get; set; }                             //搜索条件
        public string SBMS { get; set; }            //SBBH中文
        public int TYPEID { get; set; }                                                       //电池型号
        public string MXNAME { get; set; }          //TYPEID中文
        public string MATCHCODE { get; set; }
        public string MATCHCODENAME { get; set; }   //MATCHCODE代码  //搜索条件
        public string MATCHCODEREMARK { get; set; } //MATCHCODE说明
        public string MOULD { get; set; }                            //搜索条件
        public int CAVE { get; set; }                                //搜索条件
        public string STATUS { get; set; }                           //搜索条件
        public int CASENUM { get; set; }
        public decimal CASEWET { get; set; }
        public int ISFIM { get; set; }
        public int ISNPA { get; set; }
        public string NOTES { get; set; }
    }
}
