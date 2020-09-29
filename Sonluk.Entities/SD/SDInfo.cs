using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.SD
{
    public class SDInfo
    {
        private string _SalesOrganization;             //I_VKORG	TYPE	VBAK-VKORG	                     	销售组织 
        private string _SalesOrganizationDescription;
        private string _DistributionChannel;           //I_VTWEG	TYPE	VBAK-VTWEG	                     	分销渠道
        private string _DistributionChannelDescription;
        private string _Division;
        private string _DivisionDescription;

        public string SalesOrganization
        {
            get { return _SalesOrganization; }
            set { _SalesOrganization = value; }
        }
        public string SalesOrganizationDescription
        {
            get { return _SalesOrganizationDescription; }
            set { _SalesOrganizationDescription = value; }
        }
        public string DistributionChannel
        {
            get { return _DistributionChannel; }
            set { _DistributionChannel = value; }
        }
        public string DistributionChannelDescription
        {
            get { return _DistributionChannelDescription; }
            set { _DistributionChannelDescription = value; }
        }
        public string Division
        {
            get { return _Division; }
            set { _Division = value; }
        }
        public string DivisionDescription
        {
            get { return _DivisionDescription; }
            set { _DivisionDescription = value; }
        }
    }
}
