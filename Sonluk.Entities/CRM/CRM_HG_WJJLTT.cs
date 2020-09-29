using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_HG_WJJLTT
    {
        int _WJID;
        /// <summary>
        /// CRM_HG_WJJLTT-文件ID
        /// </summary>
        public int WJID
        {
            get { return _WJID; }
            set { _WJID = value; }
        }
        int _GSDX;
        /// <summary>
        /// CRM_HG_WJJLTT-归属对象
        /// </summary>
        public int GSDX
        {
            get { return _GSDX; }
            set { _GSDX = value; }
        }
        int _GSDXID;
        /// <summary>
        /// CRM_HG_WJJLTT-归属对象ID
        /// </summary>
        public int GSDXID
        {
            get { return _GSDXID; }
            set { _GSDXID = value; }
        }
        //int _GSDXHXM;
        ///// <summary>
        ///// CRM_HG_WJJLTT-归属对象行项目
        ///// </summary>
        //public int GSDXHXM
        //{
        //    get { return _GSDXHXM; }
        //    set { _GSDXHXM = value; }
        //}
        string _WJZT;
        /// <summary>
        /// CRM_HG_WJJLTT-文件主题
        /// </summary>
        public string WJZT
        {
            get { return _WJZT; }
            set { _WJZT = value; }
        }
        string _WJMS;
        /// <summary>
        /// CRM_HG_WJJLTT-文件描述
        /// </summary>
        public string WJMS
        {
            get { return _WJMS; }
            set { _WJMS = value; }
        }
        int _CZR;
        /// <summary>
        /// CRM_HG_WJJLTT-操作人
        /// </summary>
        public int CZR
        {
            get { return _CZR; }
            set { _CZR = value; }
        }
        string _CZSJ;
        /// <summary>
        /// CRM_HG_WJJLTT-操作时间
        /// </summary>
        public string CZSJ
        {
            get { return _CZSJ; }
            set { _CZSJ = value; }
        }
        int _ISACTIVE;
        /// <summary>
        /// CRM_HG_WJJLTT-状态
        /// </summary>
        public int ISACTIVE
        {
            get { return _ISACTIVE; }
            set { _ISACTIVE = value; }
        }	

    }
}
