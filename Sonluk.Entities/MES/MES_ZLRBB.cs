using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_ZLRBB
    {
        //主线
        public string BC { get; set; }      //班次
        public int BCID { get; set; }
        public int ZJHQR { get; set; }      //正极环嵌入
        public int KX { get; set; }         //刻线
        public int FKJTB { get; set; }      //封口剂涂布
        public int GMZCR { get; set; }      //隔膜纸插入
        public int DJYZR { get; set; }      //电解液注入
        public int XGZR { get; set; }       //锌膏注入
        public int FKCX { get; set; }       //封口成型
        public int DDMTB { get; set; }      //导电膜涂布
        public Single SDCL { get; set; }    //素电产量(万只)

        //商标机
        public int VYX { get; set; }        //1.0V以下
        public int VZ { get; set; }         //1.0~1.595(1.60)V
        public int VYS { get; set; }        //1.595(1.60)V以上
        public int SDZYXCCD { get; set; }   //设定值以下吹出电
        public int WGBL { get; set; }       //外观不良

        //伏值以下（VYX）详细数据
        public int ID { get; set; }
        public int HD { get; set; }         //黑点
        public int TTBL { get; set; }       //烫头不良
        public int LKCK { get; set; }       //裂口穿孔
        public int TTP { get; set; }        //烫头破
        public int CP { get; set; }         //插破
        public int CXBL { get; set; }       //成型不良
        public int HT { get; set; }         //黑头
        public int WXG { get; set; }        //无（缺）锌膏
        public int YC { get; set; }         //溢出
        public int TDXC { get; set; }       //铜钉斜插
        public int TPLS { get; set; }       //脱皮拉丝
        public int KXBL { get; set; }       //刻线不良
        public int DGX { get; set; }        //底盖斜
        public int TDTH { get; set; }       //铜钉脱焊
        public int RJZRBL { get; set; }     //热胶注入不良
        public int WBDL { get; set; }       //外部短路
        public int YYBM { get; set; }       //原因不明
        public int QT { get; set; }         //其它

        //通用
        public string JLTXR { get; set; }   //填写人
        public int JLTXRID { get; set; }
        public string JLTXRGH { get; set; } //填写人工号
        public string BZ { get; set; }      //备注
        public int RI { get; set; }
        public string DATE { get; set; }    //日期
        public string SDLINE { get; set; }  //生产线
        public int SDLINEID { get; set; }
        public int LB { get; set; }         //1主线，2主线的商标机，3商标机无日期（已弃用），4商标机的商标机
        public int ISACTION { get; set; }   //审核状态
        public int CJRID { get; set; }      //STAFFID
        public int ISDELETE { get; set; }   //删除状态
    }
}
