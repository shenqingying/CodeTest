using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.SD
{
    public class SOHeaderInfo
    {
        private string _Number;
        private string _SalesOrganization;    //I_VKORG	TYPE	VBAK-VKORG	                     	销售组织 
        private string _DistributionChannel;  //I_VTWEG	TYPE	VBAK-VTWEG	                     	分销渠道
        private string _Division;             //I_SPART	TYPE	VBAK-SPART	                     	产品组 
        private string _SoldToParty;          //I_KUNRG	TYPE	VBAK-KUNNR	                     	售达方 
        private string _ShipToParty;          //I_KUNN2	TYPE	VBAK-KUNNR	                     	送达方 
        private string _CustomerPO;           //I_BSTKD	TYPE	VBAK-BSTNK	                     	客户采购订单编号
        private string _CustomerPODate;       //I_BSTDK	TYPE	VBAK-BSTDK	                     	客户交货日期

        
        public string Number
        {
            get { return _Number; }
            set { _Number = value; }
        }
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
        public string Division
        {
            get { return _Division; }
            set { _Division = value; }
        }
        public string SoldToParty
        {
            get { return _SoldToParty; }
            set { _SoldToParty = value; }
        }
        public string ShipToParty
        {
            get { return _ShipToParty; }
            set { _ShipToParty = value; }
        }
        public string CustomerPO
        {
            get { return _CustomerPO; }
            set { _CustomerPO = value; }
        }
        public string CustomerPODate
        {
            get { return _CustomerPODate; }
            set { _CustomerPODate = value; }
        }



    }
}
