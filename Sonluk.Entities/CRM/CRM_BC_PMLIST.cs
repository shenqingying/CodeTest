using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_BC_PMLIST
    {
        int _PMID;
        /// <summary>
        /// 逻辑ID
        /// </summary>
        public int PMID
        {
            get { return _PMID; }
            set { _PMID = value; }
        }
        int _PMTYPE;

        public int PMTYPE
        {
            get { return _PMTYPE; }
            set { _PMTYPE = value; }
        }
        string _AUFNR;
        /// <summary>
        /// 工单
        /// </summary>
        public string AUFNR
        {
            get { return _AUFNR; }
            set { _AUFNR = value; }
        }
        string _MATNR;
        /// <summary>
        /// 物料号
        /// </summary>
        public string MATNR
        {
            get { return _MATNR; }
            set { _MATNR = value; }
        }
        string _MAKTX;
        /// <summary>
        /// 物料号描述
        /// </summary>
        public string MAKTX
        {
            get { return _MAKTX; }
            set { _MAKTX = value; }
        }
        string _CHARG;
        /// <summary>
        /// 日期唛
        /// </summary>
        public string CHARG
        {
            get { return _CHARG; }
            set { _CHARG = value; }
        }
        int _ZBON;
        /// <summary>
        /// 大箱内盒数
        /// </summary>
        public int ZBON
        {
            get { return _ZBON; }
            set { _ZBON = value; }
        }
        int _ZPKS;
        /// <summary>
        /// 内盒吊卡数
        /// </summary>
        public int ZPKS
        {
            get { return _ZPKS; }
            set { _ZPKS = value; }
        }
        string _DXM;
        /// <summary>
        /// 箱码
        /// </summary>
        public string DXM
        {
            get { return _DXM; }
            set { _DXM = value; }
        }
        string _TPM;
        /// <summary>
        /// 托码
        /// </summary>

        public string TPM
        {
            get { return _TPM; }
            set { _TPM = value; }
        }
        string _PM;
        /// <summary>
        /// 喷码
        /// </summary>

        public string PM
        {
            get { return _PM; }
            set { _PM = value; }
        }
        int _ISACTIVE;

        public int ISACTIVE
        {
            get { return _ISACTIVE; }
            set { _ISACTIVE = value; }
        }
        string _BEIZ;

        public string BEIZ
        {
            get { return _BEIZ; }
            set { _BEIZ = value; }
        }
        int _CJR;

        public int CJR
        {
            get { return _CJR; }
            set { _CJR = value; }
        }
        string _CJRQ;

        public string CJRQ
        {
            get { return _CJRQ; }
            set { _CJRQ = value; }
        }





    }
}
