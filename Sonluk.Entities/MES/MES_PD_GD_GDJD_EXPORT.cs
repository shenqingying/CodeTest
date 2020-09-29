using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_PD_GD_GDJD_EXPORT
    {
        string _GZZXBH;          //工作中心编号
        string _ERPNO;           //工单号
        string _WLH;             //物料号
        string _WLMS;            //物料描述
        string _XSNOBILL;        //销售订单号
        string _XSNOBILLMX;      //销售订单行项目
        decimal _GDCOUNT;        //工单数量
        decimal _FINISHCOUNT;    //已完成数量
        decimal _CYCOUNT;        //差异数量
        string _UNITSNAME;         //单位
        string _SBHMS;
        string _WLLBNAME;

        public string WLLBNAME
        {
            get { return _WLLBNAME; }
            set { _WLLBNAME = value; }
        }
        public string SBHMS
        {
            get { return _SBHMS; }
            set { _SBHMS = value; }
        }
        public string UNITSNAME
        {
            get { return _UNITSNAME; }
            set { _UNITSNAME = value; }
        }
       

        public string GZZXBH
        {
            get { return _GZZXBH; }
            set { _GZZXBH = value; }
        }
      

        public string ERPNO
        {
            get { return _ERPNO; }
            set { _ERPNO = value; }
        }
     

        public string WLH
        {
            get { return _WLH; }
            set { _WLH = value; }
        }
      

        public string WLMS
        {
            get { return _WLMS; }
            set { _WLMS = value; }
        }
       

        public string XSNOBILL
        {
            get { return _XSNOBILL; }
            set { _XSNOBILL = value; }
        }
      

        public string XSNOBILLMX
        {
            get { return _XSNOBILLMX; }
            set { _XSNOBILLMX = value; }
        }
      

        public decimal GDCOUNT
        {
            get { return _GDCOUNT; }
            set { _GDCOUNT = value; }
        }
      

        public decimal FINISHCOUNT
        {
            get { return _FINISHCOUNT; }
            set { _FINISHCOUNT = value; }
        }
      

        public decimal CYCOUNT
        {
            get { return _CYCOUNT; }
            set { _CYCOUNT = value; }
        }
      

      
        
    }
}
