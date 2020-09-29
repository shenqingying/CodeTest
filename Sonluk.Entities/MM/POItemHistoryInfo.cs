using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MM
{
    public class POItemHistoryInfo
    {
        private string _PONumber;  //EBELN Purchasing Document Number	采购凭证号  
        private int _Number;       //EBELP Item Number of Purchasing Documen  项目编号
        private string _PocessID;     //VGABE Transaction/event type, purchase order history 业务处理/事件类型,采购订单的历史记录
        private int _FiscalYear;      //GJAHR Purchase Order Date 采购订单日期
        private string _MatDoc;            //BELNR Number of Material Document 物料凭证编号	
        private int _AccDocItemCount; //BUZEI Number of Line Item Within Accounting Document	会计凭证中的行项目数	
        private string _HistType;           //BEWTP Purchase Order History Category 采购订单历史分类
        private string _HistTypeDescription;
        private string _MoveType;   //BWART Movement Type (Inventory Management) 移动类型（库存管理）
        private string _PstngDate;     //BUDAT Posting Date in the Document 凭证中的过账日期
        private double _Quantity;       //MENGE Quantity 数量	
        private double _QtyInPriceUnit;       //BPMNG Quantity in purchase order price unit 使用采购订单价格单位的数量	       
        private string _ValLocCurr;   //DMBTR Amount in Local Currency 按本位币计的金额	      
        private string _ValDocCurr;     //WRBTR  Amount in Document Currency 凭证货币金额	       
        private string _Currency;       //WAERS Currency Key 货币码        
        private string _GRIRValLocCurr;  //AREWR GR/IR account clearing value in local currency 用本位币计算的GR/IR帐户结算价值	      
        private double _BlockedQty;         //WESBS Goods Receipt Blocked Stock in 用订货单位计算的收货冻结库存       
        private double _GRBlockedQty;         //BPWES Quantity in GR blocked stock in order price unit 使用订单价格单位的收货冻结库存数量       
        private string _DbCrInd;       //SHKZG Debit/Credit Indicator 借方/贷方标识

       
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

        public string PocessID
        {
            get { return _PocessID; }
            set { _PocessID = value; }
        }

        public int FiscalYear
        {
            get { return _FiscalYear; }
            set { _FiscalYear = value; }
        }
        public string MatDoc
        {
            get { return _MatDoc; }
            set { _MatDoc = value; }
        }
        public int AccDocItemCount
        {
            get { return _AccDocItemCount; }
            set { _AccDocItemCount = value; }
        }
        public string HistType
        {
            get { return _HistType; }
            set { _HistType = value; }
        }
        public string HistTypeDescription
        {
            get { return _HistTypeDescription; }
            set { _HistTypeDescription = value; }
        }
        public string MoveType
        {
            get { return _MoveType; }
            set { _MoveType = value; }
        }
        public string PstngDate
        {
            get { return _PstngDate; }
            set { _PstngDate = value; }
        }
        public double Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }
        public double QtyInPriceUnit
        {
            get { return _QtyInPriceUnit; }
            set { _QtyInPriceUnit = value; }
        }
        public string ValLocCurr
        {
            get { return _ValLocCurr; }
            set { _ValLocCurr = value; }
        }
        public string ValDocCurr
        {
            get { return _ValDocCurr; }
            set { _ValDocCurr = value; }
        }
        public string Currency
        {
            get { return _Currency; }
            set { _Currency = value; }
        }
        public string GRIRValLocCurr
        {
            get { return _GRIRValLocCurr; }
            set { _GRIRValLocCurr = value; }
        }
        public double BlockedQty
        {
            get { return _BlockedQty; }
            set { _BlockedQty = value; }
        }
        public double GRBlockedQty
        {
            get { return _GRBlockedQty; }
            set { _GRBlockedQty = value; }
        }
        public string DbCrInd
        {
            get { return _DbCrInd; }
            set { _DbCrInd = value; }
        }
    }
}
