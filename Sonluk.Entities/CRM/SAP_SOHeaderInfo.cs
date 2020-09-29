using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    
    public class SAP_SOHeaderInfo
    {
        private string _Number;               //SAP回传的SAP编号	                     	             
        private string _SalesOrganization;    //I_VKORG	TYPE	VBAK-VKORG	                     	销售组织 
        private string _DistributionChannel;  //I_VTWEG	TYPE	VBAK-VTWEG	                     	分销渠道
        private string _Division;             //I_SPART	TYPE	VBAK-SPART	                     	产品组 
        private string _SoldToParty;          //I_KUNRG	TYPE	VBAK-KUNNR	                     	售达方 
        private string _ShipToParty;          //I_KUNN2	TYPE	VBAK-KUNNR	                     	送达方 
        private string _CustomerPO;           //I_BSTKD	TYPE	VBAK-BSTNK	                     	客户采购订单编号
        private string _CustomerPODate;       //I_BSTDK	TYPE	VBAK-BSTDK	                     	客户交货日期

        /// <summary>
        /// SAP回传的SAP编号
        /// </summary>
        public string Number
        {
            get { return _Number; }
            set { _Number = value; }
        }
        /// <summary>
        /// 销售组织
        /// </summary>
        public string SalesOrganization
        {
            get { return _SalesOrganization; }
            set { _SalesOrganization = value; }
        }
        /// <summary>
        /// 分销渠道
        /// </summary>
        public string DistributionChannel
        {
            get { return _DistributionChannel; }
            set { _DistributionChannel = value; }
        }
        /// <summary>
        /// 产品组
        /// </summary>
        public string Division
        {
            get { return _Division; }
            set { _Division = value; }
        }
        /// <summary>
        /// 售达方
        /// </summary>
        public string SoldToParty
        {
            get { return _SoldToParty; }
            set { _SoldToParty = value; }
        }
        /// <summary>
        /// 送达方
        /// </summary>
        public string ShipToParty
        {
            get { return _ShipToParty; }
            set { _ShipToParty = value; }
        }
        /// <summary>
        /// 客户采购订单编号
        /// </summary>
        public string CustomerPO
        {
            get { return _CustomerPO; }
            set { _CustomerPO = value; }
        }
        /// <summary>
        /// 客户交货日期
        /// </summary>
        public string CustomerPODate
        {
            get { return _CustomerPODate; }
            set { _CustomerPODate = value; }
        }



    }
}
