using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_KH_GXQY
    {
        int _GXQYID;
        /// <summary>
        /// 管辖区域ID
        /// </summary>
        public int GXQYID
        {
            get { return _GXQYID; }
            set { _GXQYID = value; }
        }
        int _KHID;

        /// <summary>
        /// 客户ID
        /// </summary>
        public int KHID
        {
            get { return _KHID; }
            set { _KHID = value; }
        }
        int _GXQYLX;
        /// <summary>
        /// 管辖区域类型
        /// </summary>
        public int GXQYLX
        {
            get { return _GXQYLX; }
            set { _GXQYLX = value; }
        }
        int _GXQYMC;
        /// <summary>
        /// 管辖区域名称
        /// </summary>
        public int GXQYMC
        {
            get { return _GXQYMC; }
            set { _GXQYMC = value; }
        }
        int _ISACTIVE;
        /// <summary>
        /// 状态
        /// </summary>
        public int ISACTIVE
        {
            get { return _ISACTIVE; }
            set { _ISACTIVE = value; }
        }
        string _BEIZ;
        /// <summary>
        /// 备注
        /// </summary>
        public string BEIZ
        {
            get { return _BEIZ; }
            set { _BEIZ = value; }
        }

    }
}
