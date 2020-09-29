using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_PD_GD_GDJD_IMPORT
    {
        string _GC;            //工厂
        string _GZZXBH;        //工作中心编号
        string _SCDATE_BEGIN;  //生产日期开始
        string _SCDATE_END;    //生产日期结束
        string _WLH;           //物料号
        string _XSNOBILL;      //销售订单号
        string _XSNOBILLMX;    //销售订单项目
        string _ERPNO;         //工单号
        int _STAFFID;          //人员ID       
        string _SBBH;
        int _WLLB;

        public int WLLB
        {
            get { return _WLLB; }
            set { _WLLB = value; }
        }
        public string SBBH
        {
            get { return _SBBH; }
            set { _SBBH = value; }
        }
        string _GDDATE_BEGIN;

        public string GDDATE_BEGIN
        {
            get { return _GDDATE_BEGIN; }
            set { _GDDATE_BEGIN = value; }
        }
        string _GDDATE_END;

        public string GDDATE_END
        {
            get { return _GDDATE_END; }
            set { _GDDATE_END = value; }
        }
        int _ISGD;

        public int ISGD
        {
            get { return _ISGD; }
            set { _ISGD = value; }
        }
        public string GC
        {
            get { return _GC; }
            set { _GC = value; }
        }
       

        public string GZZXBH
        {
            get { return _GZZXBH; }
            set { _GZZXBH = value; }
        }
        

        public string SCDATE_BEGIN
        {
            get { return _SCDATE_BEGIN; }
            set { _SCDATE_BEGIN = value; }
        }
        

        public string SCDATE_END
        {
            get { return _SCDATE_END; }
            set { _SCDATE_END = value; }
        }
        

        public string WLH
        {
            get { return _WLH; }
            set { _WLH = value; }
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
        

        public string ERPNO
        {
            get { return _ERPNO; }
            set { _ERPNO = value; }
        }
        

        public int STAFFID
        {
            get { return _STAFFID; }
            set { _STAFFID = value; }
        }
    }
}
