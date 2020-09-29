using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MM
{
    public class POItemInfo
    {
        private string _PONumber;  //EBELN Purchasing Document Number	采购凭证号  
        private int _Number;       //EBELP Item Number of Purchasing Documen  项目编号
        private string _Plant;     //WERKS Plant	工厂
        private string _Date;      //BEDAT Purchase Order Date	采购订单日期
        private string _Material;            //MATNR Material Number	物料号	
        private string _MaterialDescription; //TXZ01	物料文本
        private decimal _InitialQuantity;
        private decimal _Quantity;           //MENGE Quantity	数量
        private decimal _DelivQty;   //WEMNG Quantity of Goods Received	收货数量	
        private string _BaseUOM;     //MEINS MEINS Base Unit of Measure	基本计量单位	
        private string _SDDoc;       //VBELN Sales and Distribution Document Number	销售和分销凭证号	
        private int _SDocItem;       //VBELP Sales document item	销售凭证项目
        private string _InitialDelivDate; 
        private string _DelivDate;   //EINDT Item Delivery Date	项目交货日期
        private string _NewDelivDate;
        private string _SubjToR;     //FRGRL Release Not Yet Completely Effected	批准尚未完全生效	
        private string _DeleteInd;       //LOEKZ Asset class marked for deletion	资产类别作删除标记	
        private string _CustChngStatus;  //AESKD Customer Engineering Change Status	客户工程修改状态	
        private string _Remarks;         //ZMMEMO	备注长文本	
        private string _OldMatl;         //BISMT Old material number	旧物料号	
        private string _MatlGroup;       //MATKL Material Group	物料组	
        private string _PurGroup;        //EKGRP Purchasing Group	采购组	
        private string _NoMoreGR;        //ELIKZ Delivery Completed Indicator	交货已完成标识	
        private string _PstngDate;       //BUDAT Posting Date in the Document	凭证中的过账日期	
        private string _DocDate;         //BLDAT Document Date in Document	凭证中的凭证日期	
        private string _ReqDate;         //EDATU Schedule line date	计划行日期	
        private string _StgeLoc;         //LGORT Storage Location	库存地点	
        private string _Vendor;          //LIFNR Account Number of Vendor or Creditor	供应商或债权人的帐号	
        private string _ReleaseCode;

        private decimal _NetPrice;      //NETPR Net Price in Purchasing Document (in Document Currency) 采购凭证中的净价(以凭证货币计)  
        private decimal _PriceUnit;     //PEINH Price Unit 价格单位     
        private decimal _UnitPrice;
        private decimal _UnitPriceWidthTax; 
        private decimal _NetValue;      //NETWR Net Order Value in PO Currency 采购订单货币的订单净值
        private decimal _CrossVlaue;    //BRTWR Gross order value in PO currency PO货币的全部订单值
        private decimal _Tax;
        private string _TaxCode;         //MWSKZ Tax Code  销售/购买税代码
        private decimal _TaxRate;

        private int _Line;              //EETEN 计划协议计划行
        private string _DelivDate_M;    //EINDT_M 项目交货日期修改标记
        private string _Quantity_M;     //MENGE_M 数量修改标记
        private int _PcsInCtn;          //XZS箱只数
        private string _PlantName;      //NAME1 工厂名称
        private int _PcsInPal;          //TSL托只数
        private string _Aufnr;          //NPLNR 科目分配的网络号

        public string Aufnr
        {
            get { return _Aufnr; }
            set { _Aufnr = value; }
        }

        /// <summary>
        /// Add by xsw
        /// </summary>
        private string _Banfn;          //采购申请编号
        private int _Bnfpo;             //采购申请的项目编号
        ///

        private string _PrintDate;
        private string _PrintTime;
        private string _DelivDest;
        private int _DelivDestID;
        private string _ScheReq;        
        
        private int _Index;
        private int _Prev;
        private int _Next;
        private int _Thread;
        private bool _Status;
        private List<ScheduleLineInfo> _Schedule;
        private List<CustomTextInfo> _CustomText;
        private List<CustomTextInfo> _SDCustomText;        

        public string PONumber
        {
            get { return _PONumber; }
            set { _PONumber = value; }
        }

        public int Number
        {
            get { return _Number; }
            set { _Number = value; }
        }

        public string Plant
        {
            get { return _Plant; }
            set { _Plant = value; }
        }

        public string Date
        {
            get { return _Date; }
            set { _Date = value; }
        }

        public string Material
        {
            get { return _Material; }
            set { _Material = value; }
        }

        public string MaterialDescription
        {
            get { return _MaterialDescription; }
            set { _MaterialDescription = value; }
        }
        public decimal InitialQuantity
        {
            get { return _InitialQuantity; }
            set { _InitialQuantity = value; }
        }
        public decimal Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }
        public string InitialDelivDate
        {
            get { return _InitialDelivDate; }
            set { _InitialDelivDate = value; }
        }
        public decimal DelivQty
        {
            get { return _DelivQty; }
            set { _DelivQty = value; }
        }
        public string NewDelivDate
        {
            get { return _NewDelivDate; }
            set { _NewDelivDate = value; }
        }
        public string BaseUOM
        {
            get { return _BaseUOM; }
            set { _BaseUOM = value; }
        }

        public string SDDoc
        {
            get { return _SDDoc; }
            set { _SDDoc = value; }
        }

        public int SDocItem
        {
            get { return _SDocItem; }
            set { _SDocItem = value; }
        }

        public string DelivDate
        {
            get { return _DelivDate; }
            set { _DelivDate = value; }
        }

        public string SubjToR
        {
            get { return _SubjToR; }
            set { _SubjToR = value; }
        }

        public string DeleteInd
        {
            get { return _DeleteInd; }
            set { _DeleteInd = value; }
        }

        public string CustChngStatus
        {
            get { return _CustChngStatus; }
            set { _CustChngStatus = value; }
        }

        public string Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value; }
        }

        public string OldMatl
        {
            get { return _OldMatl; }
            set { _OldMatl = value; }
        }

        public string MatlGroup
        {
            get { return _MatlGroup; }
            set { _MatlGroup = value; }
        }

        public string PurGroup
        {
            get { return _PurGroup; }
            set { _PurGroup = value; }
        }

        public string NoMoreGR
        {
            get { return _NoMoreGR; }
            set { _NoMoreGR = value; }
        }

        public string PstngDate
        {
            get { return _PstngDate; }
            set { _PstngDate = value; }
        }

        public string DocDate
        {
            get { return _DocDate; }
            set { _DocDate = value; }
        }

        public string ReqDate
        {
            get { return _ReqDate; }
            set { _ReqDate = value; }
        }

        public string StgeLoc
        {
            get { return _StgeLoc; }
            set { _StgeLoc = value; }
        }

        public string Vendor
        {
            get { return _Vendor; }
            set { _Vendor = value; }
        }
        public string ReleaseCode
        {
            get { return _ReleaseCode; }
            set { _ReleaseCode = value; }
        }
        public decimal NetPrice
        {
            get { return _NetPrice; }
            set { _NetPrice = value; }
        }
        public decimal PriceUnit
        {
            get { return _PriceUnit; }
            set { _PriceUnit = value; }
        }
        public decimal UnitPrice
        {
            get { return _UnitPrice; }
            set { _UnitPrice = value; }
        }
        public decimal UnitPriceWidthTax
        {
            get { return _UnitPriceWidthTax; }
            set { _UnitPriceWidthTax = value; }
        }
        public decimal NetValue
        {
            get { return _NetValue; }
            set { _NetValue = value; }
        }
        public decimal CrossVlaue
        {
            get { return _CrossVlaue; }
            set { _CrossVlaue = value; }
        }
        public decimal Tax
        {
            get { return _Tax; }
            set { _Tax = value; }
        }
        public string TaxCode
        {
            get { return _TaxCode; }
            set { _TaxCode = value; }
        }
        public decimal TaxRate
        {
            get { return _TaxRate; }
            set { _TaxRate = value; }
        }
        public int Line
        {
            get { return _Line; }
            set { _Line = value; }
        }

        public string DelivDate_M
        {
            get { return _DelivDate_M; }
            set { _DelivDate_M = value; }
        }
        public string Quantity_M
        {
            get { return _Quantity_M; }
            set { _Quantity_M = value; }
        }

        public int PcsInCtn
        {
            get { return _PcsInCtn; }
            set { _PcsInCtn = value; }
        }


        public string Banfn
        {
            get { return _Banfn; }
            set { _Banfn = value; }
        }
        public int Bnfpo
        {
            get { return _Bnfpo; }
            set { _Bnfpo = value; }
        }

        public string PrintDate
        {
            get { return _PrintDate; }
            set { _PrintDate = value; }
        }
        public string PrintTime
        {
            get { return _PrintTime; }
            set { _PrintTime = value; }
        }
        public string DelivDest
        {
            get { return _DelivDest; }
            set { _DelivDest = value; }
        }
        public int DelivDestID
        {
            get { return _DelivDestID; }
            set { _DelivDestID = value; }
        }
        public string ScheReq
        {
            get { return _ScheReq; }
            set { _ScheReq = value; }
        }
        public int Index
        {
            get { return _Index; }
            set { _Index = value; }
        }
        public int Prev
        {
            get { return _Prev; }
            set { _Prev = value; }
        }
        public int Next
        {
            get { return _Next; }
            set { _Next = value; }
        }
        public int Thread
        {
            get { return _Thread; }
            set { _Thread = value; }
        }
        public bool Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        public List<ScheduleLineInfo> Schedule
        {
            get { return _Schedule; }
            set { _Schedule = value; }
        }
        public List<CustomTextInfo> CustomText
        {
            get { return _CustomText; }
            set { _CustomText = value; }
        }
        public List<CustomTextInfo> SDCustomText
        {
            get { return _SDCustomText; }
            set { _SDCustomText = value; }
        }

        public string PlantName
        {
            get { return _PlantName; }
            set { _PlantName = value; }
        }

        public int PcsInPal
        {
            get { return _PcsInPal; }
            set { _PcsInPal = value; }
        }

    }
}
