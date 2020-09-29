using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_KH_HZHB
    {
        string _SAPSN;
        /// <summary>
        /// CRM_KH_HZHB-SAP客户编号
        /// </summary>
        public string SAPSN
        {
            get { return _SAPSN; }
            set { _SAPSN = value; }
        }
        string _XSZZ;
        /// <summary>
        /// CRM_KH_HZHB-销售组织
        /// </summary>
        public string XSZZ
        {
            get { return _XSZZ; }
            set { _XSZZ = value; }
        }
        string _FXQD;
        /// <summary>
        /// CRM_KH_HZHB-分销渠道
        /// </summary>
        public string FXQD
        {
            get { return _FXQD; }
            set { _FXQD = value; }
        }
        string _CPZ;
        /// <summary>
        /// CRM_KH_HZHB-产品组
        /// </summary>
        public string CPZ
        {
            get { return _CPZ; }
            set { _CPZ = value; }
        }
        string _HZHBGN;
        /// <summary>
        /// CRM_KH_HZHB-合作伙伴功能
        /// </summary>
        public string HZHBGN
        {
            get { return _HZHBGN; }
            set { _HZHBGN = value; }
        }
        int _HZHBJSQ;
        /// <summary>
        /// CRM_KH_HZHB-合作伙伴计数器
        /// </summary>
        public int HZHBJSQ
        {
            get { return _HZHBJSQ; }
            set { _HZHBJSQ = value; }
        }
        string _KHID;
        /// <summary>
        /// CRM_KH_HZHB-合作伙伴的客户ID
        /// </summary>
        public string KHID
        {
            get { return _KHID; }
            set { _KHID = value; }
        }
        string _HZHBKHID;
        /// <summary>
        /// CRM_KH_HZHB-客户ID
        /// </summary>
        public string HZHBKHID
        {
            get { return _HZHBKHID; }
            set { _HZHBKHID = value; }
        }
        int _SFSAPSJ;
        /// <summary>
        /// CRM_KH_HZHB-是否SAP数据
        /// </summary>
        public int SFSAPSJ
        {
            get { return _SFSAPSJ; }
            set { _SFSAPSJ = value; }
        }
        int _ISACTIVE;
        /// <summary>
        /// CRM_KH_HZHB-状态
        /// </summary>
        public int ISACTIVE
        {
            get { return _ISACTIVE; }
            set { _ISACTIVE = value; }
        }
        string _BEIZ;
        /// <summary>
        /// CRM_KH_HZHB-备注
        /// </summary>
        public string BEIZ
        {
            get { return _BEIZ; }
            set { _BEIZ = value; }
        }

    }
}
