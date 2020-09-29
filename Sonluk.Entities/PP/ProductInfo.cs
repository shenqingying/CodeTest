using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.PP
{
    public class ProductInfo
    {
        private string _SerialNumber;
        private string _Mark;
        private string _ProducingLine;
        private string _ProducingDate;
        private string _Level;
        private string _CopperNailVendor;
        private string _CopperNailPlater;
        private string _CopperNailBatch;
        private string _SealCircleVendor;
        private string _SealCircleLathe;
        private string _SealCircleBatch;
        private string _SteelShellVendor;
        private string _SteelShellBatch;
        private string _PositivePole;
        private string _NegativePole;
        private string _PackageDate;
        private string _Qualified;
        private decimal _Quantity;


        private string _Remark;
        private string _Reason;
        private string _Complain;
        private string _ComplainType;
        private string _ComplainAvailable;
        private string _Vendor;

        private string _GKCH;
        private string _ZCHF;


        public string SerialNumber
        {
            get { return _SerialNumber; }
            set { _SerialNumber = value; }
        }
        public string Mark
        {
            get { return _Mark; }
            set { _Mark = value; }
        }
        public string ProducingLine
        {
            get { return _ProducingLine; }
            set { _ProducingLine = value; }
        }

        public string ProducingDate
        {
            get { return _ProducingDate; }
            set { _ProducingDate = value; }
        }
        public string Level
        {
            get { return _Level; }
            set { _Level = value; }
        }
        public string CopperNailVendor
        {
            get { return _CopperNailVendor; }
            set { _CopperNailVendor = value; }
        }
        public string CopperNailPlater
        {
            get { return _CopperNailPlater; }
            set { _CopperNailPlater = value; }
        }
        public string CopperNailBatch
        {
            get { return _CopperNailBatch; }
            set { _CopperNailBatch = value; }
        }
        public string SealCircleVendor
        {
            get { return _SealCircleVendor; }
            set { _SealCircleVendor = value; }
        }
        public string SealCircleLathe
        {
            get { return _SealCircleLathe; }
            set { _SealCircleLathe = value; }
        }
        public string SealCircleBatch
        {
            get { return _SealCircleBatch; }
            set { _SealCircleBatch = value; }
        }
        public string SteelShellVendor
        {
            get { return _SteelShellVendor; }
            set { _SteelShellVendor = value; }
        }
        public string SteelShellBatch
        {
            get { return _SteelShellBatch; }
            set { _SteelShellBatch = value; }
        }
        public string PositivePole
        {
            get { return _PositivePole; }
            set { _PositivePole = value; }
        }
        public string NegativePole
        {
            get { return _NegativePole; }
            set { _NegativePole = value; }
        }
        public string PackageDate
        {
            get { return _PackageDate; }
            set { _PackageDate = value; }
        }
        public string Qualified
        {
            get { return _Qualified; }
            set { _Qualified = value; }
        }

        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }
        public string Reason
        {
            get { return _Reason; }
            set { _Reason = value; }
        }
        public string Complain
        {
            get { return _Complain; }
            set { _Complain = value; }
        }
        public string ComplainType
        {
            get { return _ComplainType; }
            set { _ComplainType = value; }
        }
        public string ComplainAvailable
        {
            get { return _ComplainAvailable; }
            set { _ComplainAvailable = value; }
        }
        public decimal Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }
        public string Vendor
        {
            get { return _Vendor; }
            set { _Vendor = value; }
        }

        public string GKCH
        {
            get { return _GKCH; }
            set { _GKCH = value; }
        }


        public string ZCHF
        {
            get { return _ZCHF; }
            set { _ZCHF = value; }
        }
    }
}
