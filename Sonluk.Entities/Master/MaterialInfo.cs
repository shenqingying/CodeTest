using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.Master
{
    public class MaterialInfo
    {
        private string _SalesOrganization;             //I_VKORG	TYPE	VBAK-VKORG	                     	销售组织 
        private string _DistributionChannel; 
        private string _SerialNumber;
        private string _Description;
        private string _BarCode;
        private decimal _Conversion;
        private string _Unit;
        private string _SalesUnit;

        public string SalesOrganization
        {
            get { return _SalesOrganization; }
            set { _SalesOrganization = value; }
        }

        public string DistributionChannel
        {
            get { return _DistributionChannel; }
            set { _DistributionChannel = value; }
        }
           
        public string SerialNumber
        {
            get { return _SerialNumber; }
            set { _SerialNumber = value; }
        }
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        public string BarCode
        {
            get { return _BarCode; }
            set { _BarCode = value; }
        }
        public decimal Conversion
        {
            get { return _Conversion; }
            set { _Conversion = value; }
        }
        public string Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }
        public string SalesUnit
        {
            get { return _SalesUnit; }
            set { _SalesUnit = value; }
        }
    }
}
