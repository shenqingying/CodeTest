using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_KH_GXCS
    {
        string _CS;
        /// <summary>
        /// CRM_KH_GXCS-城市ID
        /// </summary>
        public string CS
        {
            get { return _CS; }
            set { _CS = value; }
        }
        string _KHID;
        /// <summary>
        /// CRM_KH_GXCS-客户ID
        /// </summary>
        public string KHID
        {
            get { return _KHID; }
            set { _KHID = value; }
        }
        string _XSBM;
        /// <summary>
        /// CRM_KH_GXCS-销售部门
        /// </summary>
        public string XSBM
        {
            get { return _XSBM; }
            set { _XSBM = value; }
        }
    }
}
