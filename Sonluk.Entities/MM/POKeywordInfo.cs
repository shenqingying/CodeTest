using Sonluk.Entities.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MM
{
    public class POKeywordInfo
    {
        private string _Number;              //EBELN Purchasing Document Number	采购凭证号  
        private int _Item;                   //EBELP Item Number of Purchasing Documen  项目编号
        private string _Plant;               //WERKS Plant	工厂
        private string _PlantName;
        private string _StartDate;
        private string _Date;                //BEDAT Purchase Order Date	采购订单日期
        private string _Material;            //MATNR Material Number	物料号	
        private string _MaterialDescription; //TXZ01	物料文本	
        private double _Quantity;            //MENGE Quantity	数量
        private double _DelivQty;            //WEMNG Quantity of Goods Received	收货数量	
        private string _BaseUOM;             //MEINS MEINS Base Unit of Measure	基本计量单位	
        private string _SDDoc;               //VBELN Sales and Distribution Document Number	销售和分销凭证号	
        private int _SDocItem;               //VBELP Sales document item	销售凭证项目	
        private string _StartDelivDate;
        private string _DelivDate;           //EINDT Item Delivery Date	项目交货日期	
        private string _SubjToR;             //FRGRL Release Not Yet Completely Effected	批准尚未完全生效	
        private string _DeleteInd;           //LOEKZ Asset class marked for deletion	资产类别作删除标记	
        private string _CustChngStatus;      //AESKD Customer Engineering Change Status	客户工程修改状态	
        private string _Remarks;             //ZMMEMO	备注长文本	
        private string _OldMatl;             //BISMT Old material number	旧物料号	
        private string _MatlGroup;           //MATKL Material Group	物料组	
        private string _PurGroup;            //EKGRP Purchasing Group	采购组	
        private string _NoMoreGR;            //ELIKZ Delivery Completed Indicator	交货已完成标识	
        private string _PstngDate;           //BUDAT Posting Date in the Document	凭证中的过账日期	
        private string _DocDate;             //BLDAT Document Date in Document	凭证中的凭证日期	
        private string _ReqDate;             //EDATU Schedule line date	计划行日期	
        private string _StgeLoc;             //LGORT Storage Location	库存地点	
        private string _Vendor;              //LIFNR   供应商
        private string _DisplayGRDate;
        private string _DisplayMRDate;
        private string _Function;
        private int _Status;                 //STYPE   状态
        private int _DisplayPrintMinCost;
        private string _ReleaseGroup;
        private string _Type;
        private string _Aufnr;

        public string Aufnr
        {
            get { return _Aufnr; }
            set { _Aufnr = value; }
        }
        
        
         
        public string Number
        {
            get { return _Number; }
            set { _Number = value; }
        }
        public int Item
        {
            get { return _Item; }
            set { _Item = value; }
        }

        public string Plant
        {
            get { return _Plant; }
            set { _Plant = value; }
        }
        public string PlantName
        {
            get { return _PlantName; }
            set { _PlantName = value; }
        }
        public string StartDate
        {
            get { return _StartDate; }
            set { _StartDate = value; }
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

        public double Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }


        public double DelivQty
        {
            get { return _DelivQty; }
            set { _DelivQty = value; }
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

        public string StartDelivDate
        {
            get { return _StartDelivDate; }
            set { _StartDelivDate = value; }
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
        public string DisplayGRDate
        {
            get { return _DisplayGRDate; }
            set { _DisplayGRDate = value; }
        }
        public string DisplayMRDate
        {
            get { return _DisplayMRDate; }
            set { _DisplayMRDate = value; }
        }
        public string Function
        {
            get { return _Function; }
            set { _Function = value; }
        }
        public int Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        public string ReleaseGroup
        {
            get { return _ReleaseGroup; }
            set { _ReleaseGroup = value; }
        }
        public int DisplayPrintMinCost
        {
            get { return _DisplayPrintMinCost; }
            set { _DisplayPrintMinCost = value; }
        }
        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

    }
}
