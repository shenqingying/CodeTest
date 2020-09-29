using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MM
{
    public class ZSL_BCS303_CT
    {
        string _werks; //工厂
        string _lgort; //库存地点
        string _mblnr; //物料凭证编号
        string _mjahr; //物料凭证年度
        string _zeile; //物料凭证中的项目
        string _ebeln; //采购订单编号
        string _ebelp; //采购凭证的项目编号 
        string _lifnr; //供应商或债权人的帐号
        string _budat_st; //凭证中的过帐日期
        string _budat_ed; //凭证中的过帐日期
        string _matnr; //物料号 
        string _charg; //批号
        string _cpudt_st; //会计凭证输入日期
        string _cpudt_ed; //会计凭证输入日期
        string _cputm_st; //输入时间
        string _cputm_ed; //输入时间

        public string Werks
        {
            get { return _werks; }
            set { _werks = value; }
        }

        public string Lgort
        {
            get { return _lgort; }
            set { _lgort = value; }
        }

        public string Mblnr
        {
            get { return _mblnr; }
            set { _mblnr = value; }
        }      

        public string Mjahr
        {
            get { return _mjahr; }
            set { _mjahr = value; }
        }

        public string Zeile
        {
            get { return _zeile; }
            set { _zeile = value; }
        }

        public string Ebeln
        {
            get { return _ebeln; }
            set { _ebeln = value; }
        }

        public string Ebelp
        {
            get { return _ebelp; }
            set { _ebelp = value; }
        }

        public string Lifnr
        {
            get { return _lifnr; }
            set { _lifnr = value; }
        }
      
        public string Budat_st
        {
            get { return _budat_st; }
            set { _budat_st = value; }
        }
     
        public string Budat_ed
        {
            get { return _budat_ed; }
            set { _budat_ed = value; }
        }
     
        public string Matnr
        {
            get { return _matnr; }
            set { _matnr = value; }
        }
       
        public string Charg
        {
            get { return _charg; }
            set { _charg = value; }
        }
     
        public string Cpudt_st
        {
            get { return _cpudt_st; }
            set { _cpudt_st = value; }
        }
      
        public string Cpudt_ed
        {
            get { return _cpudt_ed; }
            set { _cpudt_ed = value; }
        }
     
        public string Cputm_st
        {
            get { return _cputm_st; }
            set { _cputm_st = value; }
        }
       
        public string Cputm_ed
        {
            get { return _cputm_ed; }
            set { _cputm_ed = value; }
        }





    }
}
