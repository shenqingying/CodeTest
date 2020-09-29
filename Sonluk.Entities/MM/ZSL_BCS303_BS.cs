using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MM
{
    public class ZSL_BCS303_BS
    {
        string _mblnr; //物料凭证编号
        string _mjahr; //物料凭证年度
        string _zeile; //物料凭证中的项目
        string _line_id; //凭证行的唯一标识
        string _matnr; //物料号 
        string _maktx; //物料描述（短文本） 
        string _matkl; //物料组 
        string _wldl; //物料大类
        string _mtart; //物料类型
        string _dcxh; //标准的文本 
        string _dcdj; //标准的文本 
        string _werks; //工厂
        string _lgort; //库存地点
        string _lgobe; //仓储地点的描述 
        string _ebeln; //采购凭证号 
        string _ebelp; //采购凭证的项目编号 
        string _charg; //批号
        string _licha; //供应商的批次
        string _lifnr; //供应商或债权人的帐号
        string _sortl; //排序字段
        string _budat; //凭证中的过帐日期
        string _wwbs; //采购凭证中的项目类别
        string _zsbs; //追溯标识
        string _xcbs; //追溯标识
        string _gy; //工艺
        string _sbh; //设备号(模号)
        string _clcj; //材料厂家
        string _xs; //QM－容器编号 
        string _menge; //数量
        string _meins; //基本计量单位
        string _mat_kdauf; //已评估销售订单库存的销售订单编号 
        string _mat_kdpos; //评估销售订单库存的销售订单项目 
        string _wempf; //收货方/运达方 
        string _bwart; //移动类型（库存管理）
        string _lfbnr; //参考凭证的凭证号 
        string _lfpos; //参考凭证项目 
        string _lfbja; //参考凭证会计年度 
        string _et_return; //传出消息

        public string Et_return
        {
            get { return _et_return; }
            set { _et_return = value; }
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

        public string Line_id
        {
            get { return _line_id; }
            set { _line_id = value; }
        }
        public string Matnr
        {
            get { return _matnr; }
            set { _matnr = value; }
        }
      
        public string Maktx
        {
            get { return _maktx; }
            set { _maktx = value; }
        }
     
        public string Matkl
        {
            get { return _matkl; }
            set { _matkl = value; }
        }
     
        public string Wldl
        {
            get { return _wldl; }
            set { _wldl = value; }
        }
      
        public string Mtart
        {
            get { return _mtart; }
            set { _mtart = value; }
        }
      
        public string Dcxh
        {
            get { return _dcxh; }
            set { _dcxh = value; }
        }
     
        public string Dcdj
        {
            get { return _dcdj; }
            set { _dcdj = value; }
        }
      
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
       
        public string Lgobe
        {
            get { return _lgobe; }
            set { _lgobe = value; }
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
     
        public string Charg
        {
            get { return _charg; }
            set { _charg = value; }
        }
       
        public string Licha
        {
            get { return _licha; }
            set { _licha = value; }
        }
      
        public string Lifnr
        {
            get { return _lifnr; }
            set { _lifnr = value; }
        }
      
        public string Sortl
        {
            get { return _sortl; }
            set { _sortl = value; }
        }
      
        public string Budat
        {
            get { return _budat; }
            set { _budat = value; }
        }
      
        public string Wwbs
        {
            get { return _wwbs; }
            set { _wwbs = value; }
        }
      
        public string Zsbs
        {
            get { return _zsbs; }
            set { _zsbs = value; }
        }
     
        public string Xcbs
        {
            get { return _xcbs; }
            set { _xcbs = value; }
        }
      
        public string Gy
        {
            get { return _gy; }
            set { _gy = value; }
        }
    
        public string Sbh
        {
            get { return _sbh; }
            set { _sbh = value; }
        }
     
        public string Clcj
        {
            get { return _clcj; }
            set { _clcj = value; }
        }
     
        public string Xs
        {
            get { return _xs; }
            set { _xs = value; }
        }
     
        public string Menge
        {
            get { return _menge; }
            set { _menge = value; }
        }
     
        public string Meins
        {
            get { return _meins; }
            set { _meins = value; }
        }
      
        public string Mat_kdauf
        {
            get { return _mat_kdauf; }
            set { _mat_kdauf = value; }
        }
     
        public string Mat_kdpos
        {
            get { return _mat_kdpos; }
            set { _mat_kdpos = value; }
        }
     
        public string Wempf
        {
            get { return _wempf; }
            set { _wempf = value; }
        }
     
        public string Bwart
        {
            get { return _bwart; }
            set { _bwart = value; }
        }
    
        public string Lfbnr
        {
            get { return _lfbnr; }
            set { _lfbnr = value; }
        }
      
        public string Lfpos
        {
            get { return _lfpos; }
            set { _lfpos = value; }
        }
     
        public string Lfbja
        {
            get { return _lfbja; }
            set { _lfbja = value; }
        }

    }
}
