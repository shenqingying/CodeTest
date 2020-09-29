using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.SD
{
    public class SOItemInfo
    {
        private string _SONumber;          //VBELN Sales Document
        private int _Number;               //POSNR Sales Document Item
        private int _Client;               //MANDT Client
        private string _Material;          //MATNR Material Number	物料号	
        private string _MaterialEntered;   //MATWA Material entered 已输入物料号
        private decimal _Quantity;         //MENGE Quantity	数量      
        private double _ReqQty;            //KWMENG Cumulative Order Quantity in Sales Units  以销售单位表示的累计订单数量
        private string _SalesUnit;         //VRKME Sales unit 销售单位
        private string _SalesDescription;  //ARKTX Short text for sales order item 销售订单项目短文本
        private string _MatlDesc;          //ZZMAKTX  Material Description (Short Text) 物料描述（短文本）
        private string _ReqmtsType;        //BEDAE Requirements type 需求类型
        private string _MatlGroup;         //MATKL Material Group 物料组
        private string _Date;              //ERDAT Date on Which Record Was Created 记录的创建日期
        private string _RecTime;           //ERZET Entry time 输入时间
        private string _ChangedDate;       //AEDAT Changed On 更改日期
        private string _Plant;             //WERKS Plant (Own or External) 工厂(自有或外部)
        private string _ReqDate;           //EDATU Schedule line date 计划行日期
        private string _Creator;           //ERNAM Name of Person who Created the Object 创建对象的人员名称
        private string _Remarks;           //ZMMEMO	备注长文本	
        private string _RequestPallet;     //TPGB 采购-托盘隔板要求
        private string _RequestSpecific;   //TSCG 特殊采购要求
        private string _RequestShrinkFilm; //RSM 采购热缩膜要求
        private string _RequestRemarks;    //DDBZ 销售订单备注
        private string _StartDate;         //GSTRP Basic start date 基本开始日期
        private string _ProcType;          //BESKZ Procurement Type 采购类型
        private string _DelivStatus;       //LFSTA Delivery status 交货状态
        private string _PO;                //EBELN Purchasing Document Number 采购凭证号
        private int _POItem;            //EBELP Item Number of Purchasing Document 采购凭证的项目编号
        private string _Status;            //TXT04 Individual status of an object (short form) 对象的单个状态 (短form)
        private string _StatusDesc;        //TXT30 Text 文本
        private string _CurrentDate;       //SYDATUM Current Date of Application Server 日期和时间,当前(应用服务器)日期
        private string _CurrentTime;       //SYUZEIT Current Time of Application Server 日期和时间，当前应用服务器时间
        private string _Vendor;            //LIFNR Account Number of Vendor or Creditor 供应商或债权人的帐号
        private string _Flag;              //FLAG 记录标识
        private string _Type;              //AUART Sales Document Type 销售凭证类型
        private string _ProcessingRecordsStatus;  //POTAG 采购标志
        private string _ProcessingRecordsDelete;  //DELETE

        

        public int Client
        {
            get { return _Client; }
            set { _Client = value; }
        }
        public string SONumber
        {
            get { return _SONumber; }
            set { _SONumber = value; }
        }
        public int Number
        {
            get { return _Number; }
            set { _Number = value; }
        }
        public string Material
        {
            get { return _Material; }
            set { _Material = value; }
        }
        public string MaterialEntered
        {
            get { return _MaterialEntered; }
            set { _MaterialEntered = value; }
        }
        public decimal Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }
        public double ReqQty
        {
            get { return _ReqQty; }
            set { _ReqQty = value; }
        }
        public string SalesUnit
        {
            get { return _SalesUnit; }
            set { _SalesUnit = value; }
        }
        public string SalesDescription
        {
            get { return _SalesDescription; }
            set { _SalesDescription = value; }
        }
        public string MatlDesc
        {
            get { return _MatlDesc; }
            set { _MatlDesc = value; }
        }
        public string ReqmtsType
        {
            get { return _ReqmtsType; }
            set { _ReqmtsType = value; }
        }
        public string MatlGroup
        {
            get { return _MatlGroup; }
            set { _MatlGroup = value; }
        }
        public string Date
        {
            get { return _Date; }
            set { _Date = value; }
        }
        public string RecTime
        {
            get { return _RecTime; }
            set { _RecTime = value; }
        }
        public string ChangedDate
        {
            get { return _ChangedDate; }
            set { _ChangedDate = value; }
        }
        public string Plant
        {
            get { return _Plant; }
            set { _Plant = value; }
        }
        public string ReqDate
        {
            get { return _ReqDate; }
            set { _ReqDate = value; }
        }
        public string Creator
        {
            get { return _Creator; }
            set { _Creator = value; }
        }   
        public string Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value; }
        }
        public string RequestPallet
        {
            get { return _RequestPallet; }
            set { _RequestPallet = value; }
        }
        public string RequestSpecific
        {
            get { return _RequestSpecific; }
            set { _RequestSpecific = value; }
        }
        public string RequestShrinkFilm
        {
            get { return _RequestShrinkFilm; }
            set { _RequestShrinkFilm = value; }
        }
        public string RequestRemarks
        {
            get { return _RequestRemarks; }
            set { _RequestRemarks = value; }
        }
        public string StartDate
        {
            get { return _StartDate; }
            set { _StartDate = value; }
        }
        public string ProcType
        {
            get { return _ProcType; }
            set { _ProcType = value; }
        }
        public string DelivStatus
        {
            get { return _DelivStatus; }
            set { _DelivStatus = value; }
        }
        public string PO
        {
            get { return _PO; }
            set { _PO = value; }
        }
        public int POItem
        {
            get { return _POItem; }
            set { _POItem = value; }
        }
        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        public string StatusDesc
        {
            get { return _StatusDesc; }
            set { _StatusDesc = value; }
        }
        public string CurrentDate
        {
            get { return _CurrentDate; }
            set { _CurrentDate = value; }
        }
        public string CurrentTime
        {
            get { return _CurrentTime; }
            set { _CurrentTime = value; }
        }
        public string Vendor
        {
            get { return _Vendor; }
            set { _Vendor = value; }
        }
        public string Flag
        {
            get { return _Flag; }
            set { _Flag = value; }
        }
        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        public string ProcessingRecordsStatus
        {
            get { return _ProcessingRecordsStatus; }
            set { _ProcessingRecordsStatus = value; }
        }
        public string ProcessingRecordsDelete
        {
            get { return _ProcessingRecordsDelete; }
            set { _ProcessingRecordsDelete = value; }
        }

    }
}
