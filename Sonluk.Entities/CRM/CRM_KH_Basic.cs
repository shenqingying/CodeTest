using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_KH_Basic
    {
        CRM_KH_KH _CRM_KH_KH;

        public CRM_KH_KH CRM_KH_KH
        {
            get { return _CRM_KH_KH; }
            set { _CRM_KH_KH = value; }
        }
        List<CRM_KH_DZ> _CRM_KH_DZArr;

        public List<CRM_KH_DZ> CRM_KH_DZArr
        {
            get { return _CRM_KH_DZArr; }
            set { _CRM_KH_DZArr = value; }
        }
        List<CRM_KH_LXR> _CRM_KH_LXRArr;

        public List<CRM_KH_LXR> CRM_KH_LXRArr
        {
            get { return _CRM_KH_LXRArr; }
            set { _CRM_KH_LXRArr = value; }
        }
        List<CRM_KH_KHQTXX> _CRM_KH_KHQTXXArr;

        public List<CRM_KH_KHQTXX> CRM_KH_KHQTXXArr
        {
            get { return _CRM_KH_KHQTXXArr; }
            set { _CRM_KH_KHQTXXArr = value; }
        }
        List<CRM_KH_GXQY> _CRM_KH_GXQYArr;

        public List<CRM_KH_GXQY> CRM_KH_GXQYArr
        {
            get { return _CRM_KH_GXQYArr; }
            set { _CRM_KH_GXQYArr = value; }
        }
        IList<CRM_KH_GROUP_KH> _CRM_KH_GROUP_KHArr;

        public IList<CRM_KH_GROUP_KH> CRM_KH_GROUP_KHArr
        {
            get { return _CRM_KH_GROUP_KHArr; }
            set { _CRM_KH_GROUP_KHArr = value; }
        }
        
    }
}
