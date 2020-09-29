using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_ORDER_MX
    {
        int _ORDERMXID;

        public int ORDERMXID
        {
            get { return _ORDERMXID; }
            set { _ORDERMXID = value; }
        }
        int _ORDERTTID;

        public int ORDERTTID
        {
            get { return _ORDERTTID; }
            set { _ORDERTTID = value; }
        }
        int _PRODUCTID;

        public int PRODUCTID
        {
            get { return _PRODUCTID; }
            set { _PRODUCTID = value; }
        }
        string _CPPH;

        public string CPPH
        {
            get { return _CPPH; }
            set { _CPPH = value; }
        }
        string _CPMC;

        public string CPMC
        {
            get { return _CPMC; }
            set { _CPMC = value; }
        }
        string _DDDW;

        public string DDDW
        {
            get { return _DDDW; }
            set { _DDDW = value; }
        }
        int _DDSL;

        public int DDSL
        {
            get { return _DDSL; }
            set { _DDSL = value; }
        }
        int _RATE;

        public int RATE
        {
            get { return _RATE; }
            set { _RATE = value; }
        }
        string _BZDW;

        public string BZDW
        {
            get { return _BZDW; }
            set { _BZDW = value; }
        }
        int _BZSL;

        public int BZSL
        {
            get { return _BZSL; }
            set { _BZSL = value; }
        }
        double _PRICE;

        public double PRICE
        {
            get { return _PRICE; }
            set { _PRICE = value; }
        }
        double _AMOUNT;

        public double AMOUNT
        {
            get { return _AMOUNT; }
            set { _AMOUNT = value; }
        }
        int _KYSL;

        public int KYSL
        {
            get { return _KYSL; }
            set { _KYSL = value; }
        }
        string _BEIZ;

        public string BEIZ
        {
            get { return _BEIZ; }
            set { _BEIZ = value; }
        }
        int _ISACTIVE;

        public int ISACTIVE
        {
            get { return _ISACTIVE; }
            set { _ISACTIVE = value; }
        }
        string _CPLXDES;

        public string CPLXDES
        {
            get { return _CPLXDES; }
            set { _CPLXDES = value; }
        }
        string _CPXLDES;

        public string CPXLDES
        {
            get { return _CPXLDES; }
            set { _CPXLDES = value; }
        }
        string _CPXHDES;

        public string CPXHDES
        {
            get { return _CPXHDES; }
            set { _CPXHDES = value; }
        }
        string _CODE;

        public string CODE
        {
            get { return _CODE; }
            set { _CODE = value; }
        }

        //为适用与大润发订单系统，追加一下字段

        string _StoreNum;

        public string StoreNum
        {
            get { return _StoreNum; }
            set { _StoreNum = value; }
        }
        string _KHPO;

        public string KHPO
        {
            get { return _KHPO; }
            set { _KHPO = value; }
        }
        string _OrderItem;

        public string OrderItem
        {
            get { return _OrderItem; }
            set { _OrderItem = value; }
        }
        string _BarCode;

        public string BarCode
        {
            get { return _BarCode; }
            set { _BarCode = value; }
        }
        string _ProdNum;

        public string ProdNum
        {
            get { return _ProdNum; }
            set { _ProdNum = value; }
        }
        string _ProdName;

        public string ProdName
        {
            get { return _ProdName; }
            set { _ProdName = value; }
        }
        string _ProdSpec;

        public string ProdSpec
        {
            get { return _ProdSpec; }
            set { _ProdSpec = value; }
        }
        string _OrderUnit;

        public string OrderUnit
        {
            get { return _OrderUnit; }
            set { _OrderUnit = value; }
        }

        string _SAPORDER;

        public string SAPORDER
        {
            get { return _SAPORDER; }
            set { _SAPORDER = value; }
        }

        int _OrderSrc;

        public int OrderSrc
        {
            get { return _OrderSrc; }
            set { _OrderSrc = value; }
        }

        int _XGR;

        public int XGR
        {
            get { return _XGR; }
            set { _XGR = value; }
        }
        string _XGSJ;

        public string XGSJ
        {
            get { return _XGSJ; }
            set { _XGSJ = value; }
        }

        string _FItem;

        public string FItem
        {
            get { return _FItem; }
            set { _FItem = value; }
        }
        int _ISCF;

        public int ISCF
        {
            get { return _ISCF; }
            set { _ISCF = value; }
        }
        int _ISCXP;

        public int ISCXP
        {
            get { return _ISCXP; }
            set { _ISCXP = value; }
        }
        string _GC;

        public string GC
        {
            get { return _GC; }
            set { _GC = value; }
        }
        string _KCDD;

        public string KCDD
        {
            get { return _KCDD; }
            set { _KCDD = value; }
        }

        string _KCDDMS;

        public string KCDDMS
        {
            get { return _KCDDMS; }
            set { _KCDDMS = value; }
        }

        int _SonCount;

        public int SonCount
        {
            get { return _SonCount; }
            set { _SonCount = value; }
        }

        int _ReadyForSAP;

        public int ReadyForSAP
        {
            get { return _ReadyForSAP; }
            set { _ReadyForSAP = value; }
        }

        int _LB;

        public int LB
        {
            get { return _LB; }
            set { _LB = value; }
        }

        string _JHD;

        public string JHD
        {
            get { return _JHD; }
            set { _JHD = value; }
        }

        string _OrderSrcDES;

        public string OrderSrcDES
        {
            get { return _OrderSrcDES; }
            set { _OrderSrcDES = value; }
        }

        string _MDMC;

        public string MDMC
        {
            get { return _MDMC; }
            set { _MDMC = value; }
        }

        string _FuntionTYPE;

        public string FuntionTYPE
        {
            get { return _FuntionTYPE; }
            set { _FuntionTYPE = value; }
        }
        int _STAFFID;

        public int STAFFID
        {
            get { return _STAFFID; }
            set { _STAFFID = value; }
        }

        string _OrderSrcSTR;

        public string OrderSrcSTR
        {
            get { return _OrderSrcSTR; }
            set { _OrderSrcSTR = value; }
        }
        string _ORDERSTSTR;

        public string ORDERSTSTR
        {
            get { return _ORDERSTSTR; }
            set { _ORDERSTSTR = value; }
        }
        string _OrderDate_BEGIN;

        public string OrderDate_BEGIN
        {
            get { return _OrderDate_BEGIN; }
            set { _OrderDate_BEGIN = value; }
        }
        string _OrderDate_END;

        public string OrderDate_END
        {
            get { return _OrderDate_END; }
            set { _OrderDate_END = value; }
        }

        string _MDMCID;

        public string MDMCID
        {
            get { return _MDMCID; }
            set { _MDMCID = value; }
        }

        string _KHNAME;

        public string KHNAME
        {
            get { return _KHNAME; }
            set { _KHNAME = value; }
        }







    }
}
