using Sonluk.MES.MES.Base;
using Sonluk.UI.Model.MES.PMM_MOULDService;
using Sonluk.UI.Model.MES.SY_TYPEMXService;
using Sonluk.UI.Model.MES.TM_TMINFOService;
using Sonluk.UI.Model.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sonluk.MES.MES.main
{
    public partial class frmTM_INFO_UPDATE : basefrm
    {
        MES_TM_TMINFO_LIST _MES_TM_TMINFO_LIST;

        public MES_TM_TMINFO_LIST MES_TM_TMINFO_LIST
        {
            get { return _MES_TM_TMINFO_LIST; }
            set { _MES_TM_TMINFO_LIST = value; }
        }
        public frmTM_INFO_UPDATE()
        {
            InitializeComponent();

          
            smtextBox.Select();
        }

        private void smtextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TM_Type type = TMtype(smtextBox.Text.Trim().ToUpper());
                if (type == TM_Type.ph)
                {
                    ConfigUI(smtextBox.Text.Trim().ToUpper());
                   
                }else{
                    //ShowMeg("扫描的不是有效条码");
                    ShowMeg(q(Msg_Type.msgscantminvalid));
                }
            }
        }
        private void ClearUI()
        {
            tmtextBox1.Clear();
            wlhtextBox2.Clear();
            wllbtextBox.Clear();
            wlmstextBox.Clear();
            kssjtextBox.Clear();
            jssjtextBox.Clear();
            //bztextBox.Clear();
            bzrichTextBox1.Clear();
            sltextBox.Clear();
            xsddtextBox.Clear();
            xsxmtextBox.Clear();
            gyspctextBox.Clear();
            thtextBox.Clear();
            pctextBox.Clear();
            //hgxtextBox5.Clear();
            bstextBox3.Clear();
            mbsltextBox2.Clear();
            wstextBox1.Clear();
            bbpmtextBox.Clear();
            scdatetextBox.Clear();
            //ystextBox.Clear();
            wqhtextBox.Clear();
            clpbtextBox.Clear();
            sbcdcomboBox.DataSource = new List<MES_SY_TYPEMXLIST>();
            cpztcomboBox.DataSource = new List<MES_SY_TYPEMXLIST>();
            dcxhcomboBox.DataSource = new List<MES_SY_TYPEMXLIST>();
            dcdjcomboBox.DataSource = new List<MES_SY_TYPEMXLIST>();
            zflbcomboBox.DataSource = new List<MES_SY_TYPEMXLIST>();
            bccomboBox.DataSource = new List<MES_SY_TYPEMXLIST>(); 
            hgxcomboBox.DataSource = new List<MES_SY_TYPEMXLIST>();
            yscomboBox.DataSource = new List<MES_SY_TYPEMXLIST>();
            cptypecomboBox.DataSource = new List<MES_SY_TYPEMXLIST>();
        }
        private void ConfigUI(string tm)
        {
            ClearUI();
            CancleTextboxzswllot();
            CancleTextboxzswlbsk();
            MES_TM_TMINFO_SELECT_BY_UPDATEROLE_IN model = new MES_TM_TMINFO_SELECT_BY_UPDATEROLE_IN();

            model.STAFFID = Convert.ToInt32(getUserInfo("staffid"));
            model.TM = tm;
            SELECT_MES_TM_TMINFO_BYTM res = ServicModel.TM_TMINFO.SELECT_BY_UPDATEROLE(model, getToken());
            if (res.MES_RETURN.TYPE.Equals("S"))
            {
                if (res.MES_TM_TMINFO_LIST.Length == 1)
                {
                    MES_SY_TYPEMXLIST zfsdnode = new MES_SY_TYPEMXLIST();
                    zfsdnode.ID = 0;
                    zfsdnode.MXNAME = q(Msg_Type.titlechoice);//"==请选择==";
                    MES_TM_TMINFO_LIST = res.MES_TM_TMINFO_LIST[0];
                    string gc = MES_TM_TMINFO_LIST.GC;
                    //MES_TM_TMINFO_LIST.MOULD
                    cpztcomboBox.DataSource = GetDictionaryMX(9, gc);
                    cpztcomboBox.DisplayMember = "MXNAME";
                    cpztcomboBox.ValueMember = "ID";

                    List<MES_SY_TYPEMXLIST> dcxhlist = GetDictionaryMX(6, gc).ToList();
                    dcxhlist.Insert(0, zfsdnode);
                    dcxhcomboBox.DataSource = dcxhlist;
                    dcxhcomboBox.DisplayMember = "MXNAME";
                    dcxhcomboBox.ValueMember = "ID";
                    int bcID = 5;
                    if (res.MES_TM_TMINFO_LIST[0].WLLBNAME.Equals("正极粉"))
                    {
                        bcID = 12;
                    }
                    List<MES_SY_TYPEMXLIST> bclist = GetDictionaryMX(bcID, gc).ToList();
                    bclist.Insert(0, zfsdnode);
                    bccomboBox.DataSource = bclist;
                    bccomboBox.DisplayMember = "MXNAME";
                    bccomboBox.ValueMember = "ID";


                    //scbzcomboBox.DataSource = GetDictionaryMX(12);
                    //scbzcomboBox.DisplayMember = "MXNAME";
                    //scbzcomboBox.ValueMember = "ID";
                  
                    List<MES_SY_TYPEMXLIST> dcdjlist = GetDictionaryMX(7, gc).ToList();
                    dcdjlist.Insert(0, zfsdnode);
                    dcdjcomboBox.DataSource = dcdjlist;
                    dcdjcomboBox.DisplayMember = "MXNAME";
                    dcdjcomboBox.ValueMember = "ID";

                    List<MES_SY_TYPEMXLIST> sbcdlist = GetDictionaryMX(15, gc).ToList();
                    sbcdlist.Insert(0, zfsdnode);
                    sbcdcomboBox.DataSource = sbcdlist;
                    sbcdcomboBox.DisplayMember = "MXNAME";
                    sbcdcomboBox.ValueMember = "ID";
               
                    List<MES_SY_TYPEMXLIST> zfsdlist = GetDictionaryMX(17, gc).ToList();                   
                    zfsdlist.Insert(0, zfsdnode);
                    zflbcomboBox.DataSource = zfsdlist;
                    zflbcomboBox.DisplayMember = "MXNAME";
                    zflbcomboBox.ValueMember = "ID";

                    List<MES_SY_TYPEMXLIST> hdgxlist = GetDictionaryMX(19, gc).ToList();
                    hdgxlist.Insert(0, zfsdnode);
                    hgxcomboBox.DisplayMember = "MXNAME";
                    hgxcomboBox.ValueMember = "ID";
                    hgxcomboBox.DataSource = hdgxlist;

                    List<MES_SY_TYPEMXLIST> yslist = GetDictionaryMX(33, gc).ToList();
                    yslist.Insert(0, zfsdnode);
                    yscomboBox.DisplayMember = "MXNAME";
                    yscomboBox.ValueMember = "ID";
                    yscomboBox.DataSource = yslist;

                    List<MES_SY_TYPEMXLIST> cptypelist = GetDictionaryMX(32, gc).ToList();
                    cptypelist.Insert(0, zfsdnode);
                    cptypecomboBox.DisplayMember = "MXNAME";
                    cptypecomboBox.ValueMember = "ID";
                    cptypecomboBox.DataSource = cptypelist;
                    
                    
                    tmtextBox1.Text  = MES_TM_TMINFO_LIST.TM;
                    wlhtextBox2.Text = MES_TM_TMINFO_LIST.WLH;
                    wllbtextBox.Text = MES_TM_TMINFO_LIST.WLLBNAME;
                    wlmstextBox.Text = MES_TM_TMINFO_LIST.WLMS;
                    dcxhcomboBox.SelectedValue = MES_TM_TMINFO_LIST.DCXH;
                    dcdjcomboBox.SelectedValue = MES_TM_TMINFO_LIST.DCDJ;
                    kssjtextBox.Text = MES_TM_TMINFO_LIST.KSTIME;
                    jssjtextBox.Text = MES_TM_TMINFO_LIST.JSTIME;
                    cpztcomboBox.SelectedValue = MES_TM_TMINFO_LIST.CPZT;
                    //bztextBox.Text = MES_TM_TMINFO_LIST.REMARK;                  
                    bzrichTextBox1.Text = MES_TM_TMINFO_LIST.REMARK;    
                    xsddtextBox.Text = MES_TM_TMINFO_LIST.NOBILL;
                    xsxmtextBox.Text = MES_TM_TMINFO_LIST.NOBILLMX;
                    gyspctextBox.Text = MES_TM_TMINFO_LIST.GYSPC;
                    thtextBox.Text = MES_TM_TMINFO_LIST.TH.ToString();
                    pctextBox.Text = MES_TM_TMINFO_LIST.PC;
                    clpbtextBox.Text = MES_TM_TMINFO_LIST.CLPBDM;
                    zflbcomboBox.SelectedValue = MES_TM_TMINFO_LIST.ZFDCLB;
                    cptypecomboBox.SelectedValue = MES_TM_TMINFO_LIST.CPTYPE;
                    bccomboBox.SelectedValue = MES_TM_TMINFO_LIST.BC;
                    if (MES_TM_TMINFO_LIST.DCSLYS != 0)
                    {
                        wstextBox1.Text = MES_TM_TMINFO_LIST.DCSLYS.ToString();
                    }
                    if (MES_TM_TMINFO_LIST.DCSLMBSL != 0)
                    {
                        mbsltextBox2.Text = MES_TM_TMINFO_LIST.DCSLMBSL.ToString();
                    }
                    if (MES_TM_TMINFO_LIST.DCSLBS != 0)
                    {
                        bstextBox3.Text = MES_TM_TMINFO_LIST.DCSLBS.ToString();
                    }
                    hgxcomboBox.SelectedValue = MES_TM_TMINFO_LIST.XDGX;
                    bbpmtextBox.Text = MES_TM_TMINFO_LIST.RQM;
                    scdatetextBox.Text = MES_TM_TMINFO_LIST.SCDATE;
                    sbcdcomboBox.SelectedValue = MES_TM_TMINFO_LIST.SBCD;
                    sltextBox.Text = MES_TM_TMINFO_LIST.SL.ToString();
                    //ystextBox.Text = MES_TM_TMINFO_LIST.MFQCOLORNAME;
                    yscomboBox.SelectedValue = MES_TM_TMINFO_LIST.MFQCOLOR;
                    wqhtextBox.Text = MES_TM_TMINFO_LIST.WQH;
                    if (MES_TM_TMINFO_LIST.TMSX == 622)// zswlbsk = 622  物料标识卡
                    {
                        
                        ReadOnlyTextboxzswlbsk();
                    }
                    else if (MES_TM_TMINFO_LIST.TMSX == 621)//zswllot = 621, 物料lot表
                    {
                        sltextBox.ReadOnly = true;
                        bccomboBox.Enabled = false;
                        scdatetextBox.ReadOnly = true;
                        Sonluk.UI.Model.MES.TM_GLService.MES_TM_GL glmodel = new Sonluk.UI.Model.MES.TM_GLService.MES_TM_GL();
                        glmodel.LB = 1;
                        glmodel.XCTM = MES_TM_TMINFO_LIST.TM;
                        Sonluk.UI.Model.MES.TM_GLService.MES_TM_GL_SELECT glres = ServicModel.TM_GL.SELECT(glmodel, getToken());
                        if (glres.MES_RETURN.TYPE.Equals("S"))
                        {
                            if (glres.MES_TM_GL.Length>0)
                            {
                                if (glres.MES_TM_GL[0].SCTMRESDUESL > 0) { ReadOnlyTextboxzswllot(); } else
                                {
                                   
                                }
                            }
                            else
                            {
                                cptypecomboBox.Enabled = true;
                            }
                           
                        }
                        else
                        {
                            ShowMeg(glres.MES_RETURN.MESSAGE);
                        }
                       
                    }




                }
                else
                {
                    //ShowMeg("条码数据异常");
                    ShowMeg(q(Msg_Type.msgtmexcept));
                    
                }
                
            }
            else
            {
                ShowMeg(res.MES_RETURN.MESSAGE);
            }
            smtextBox.Clear();
        }
        public void ReadOnlyTextboxzswlbsk()
        {
            tmtextBox1.ReadOnly = true;
            wlhtextBox2.ReadOnly = true;
            wllbtextBox.ReadOnly = true;
            wlmstextBox.ReadOnly = true;
            kssjtextBox.ReadOnly = true;
            jssjtextBox.ReadOnly = true;
            sltextBox.ReadOnly = true;
            xsddtextBox.ReadOnly = true;
            xsxmtextBox.ReadOnly = true;
            gyspctextBox.ReadOnly = true;
            thtextBox.ReadOnly = true;
            bstextBox3.ReadOnly = true;
            mbsltextBox2.ReadOnly = true;
            wstextBox1.ReadOnly = true;
            bbpmtextBox.ReadOnly = true;
            scdatetextBox.ReadOnly = true;
            sbcdcomboBox.Enabled = false;          
            dcxhcomboBox.Enabled = false;
            dcdjcomboBox.Enabled = false;
            zflbcomboBox.Enabled = false;
            bccomboBox.Enabled = false;
            hgxcomboBox.Enabled = false;
            cpztcomboBox.Enabled = true;
        }
        public void CancleTextboxzswlbsk()
        {
            //tmtextBox1.ReadOnly = false;
            //wlhtextBox2.ReadOnly = false;
            //wllbtextBox.ReadOnly = false;
            //wlmstextBox.ReadOnly = false;
            kssjtextBox.ReadOnly = false;
            jssjtextBox.ReadOnly = false;           
            sltextBox.ReadOnly = false;
            xsddtextBox.ReadOnly = false;
            xsxmtextBox.ReadOnly = false;
            gyspctextBox.ReadOnly = false;
            thtextBox.ReadOnly = false;         
            bstextBox3.ReadOnly = false;
            mbsltextBox2.ReadOnly = false;
            wstextBox1.ReadOnly = false;
            bbpmtextBox.ReadOnly = false;
            scdatetextBox.ReadOnly = false;           
            sbcdcomboBox.Enabled = true;          
            dcxhcomboBox.Enabled = true;
            dcdjcomboBox.Enabled = true;
            zflbcomboBox.Enabled = true;
            bccomboBox.Enabled = true;
            hgxcomboBox.Enabled = true;
            cptypecomboBox.Enabled = false;
        }
        public void ReadOnlyTextboxzswllot()
        {
            tmtextBox1.ReadOnly = true;
            wlhtextBox2.ReadOnly = true;
            wllbtextBox.ReadOnly = true;
            wlmstextBox.ReadOnly = true;
            kssjtextBox.ReadOnly = true;
            jssjtextBox.ReadOnly = true;          
            xsddtextBox.ReadOnly = true;
            xsxmtextBox.ReadOnly = true;
            gyspctextBox.ReadOnly = true;
            thtextBox.ReadOnly = true;
            pctextBox.ReadOnly = true;
            bstextBox3.ReadOnly = true;
            mbsltextBox2.ReadOnly = true;
            wstextBox1.ReadOnly = true;
            bbpmtextBox.ReadOnly = true;
            scdatetextBox.ReadOnly = true;         
            sbcdcomboBox.Enabled = false;
            cpztcomboBox.Enabled = false;
            dcxhcomboBox.Enabled = false;
            dcdjcomboBox.Enabled = false;
            zflbcomboBox.Enabled = false;
            bccomboBox.Enabled = false;
            hgxcomboBox.Enabled = false;
            wqhtextBox.ReadOnly = true;
            clpbtextBox.ReadOnly = true;
          
        }
        public void CancleTextboxzswllot()
        {
            //tmtextBox1.ReadOnly = false;
            //wlhtextBox2.ReadOnly = false;
            //wllbtextBox.ReadOnly = false;
            //wlmstextBox.ReadOnly = false;
            kssjtextBox.ReadOnly = false;
            jssjtextBox.ReadOnly = false;          
            xsddtextBox.ReadOnly = false;
            xsxmtextBox.ReadOnly = false;
            gyspctextBox.ReadOnly = false;
            thtextBox.ReadOnly = false;
            pctextBox.ReadOnly = false;
            bstextBox3.ReadOnly = false;
            mbsltextBox2.ReadOnly = false;
            wstextBox1.ReadOnly = false;
            bbpmtextBox.ReadOnly = false;
            scdatetextBox.ReadOnly = false;          
            sbcdcomboBox.Enabled = true;
            cpztcomboBox.Enabled = true;
            dcxhcomboBox.Enabled = true;
            dcdjcomboBox.Enabled = true;
            zflbcomboBox.Enabled = true;
            bccomboBox.Enabled = true;
            hgxcomboBox.Enabled = true;
            wqhtextBox.ReadOnly = true;
            clpbtextBox.ReadOnly = false;
            bccomboBox.Enabled = true;
            scdatetextBox.ReadOnly = false;


        }
        private void qxbutton_Click(object sender, EventArgs e)
        {
            MES_TM_TMINFO model = new MES_TM_TMINFO();         
          
            if (!string.IsNullOrEmpty(kssjtextBox.Text.Trim()))
            {
                if (judge.IsDate(kssjtextBox.Text.Trim()) && kssjtextBox.Text.Trim().Length == 19)
                {

                }
                else
                {
                    //ShowMeg("开始时间不是有效的日期格式");
                    ShowMeg(q(Msg_Type.msgkssjformat));
                    return;
                }
            }
            if (!string.IsNullOrEmpty(jssjtextBox.Text.Trim()))
            {
                if (judge.IsDate(jssjtextBox.Text.Trim()) && jssjtextBox.Text.Trim().Length == 19)
                {

                }
                else
                {
                    //ShowMeg("结束时间不是有效的日期格式");
                    ShowMeg(q(Msg_Type.msgjssjformat));
                    return;
                }
            }
            if (!string.IsNullOrEmpty(jssjtextBox.Text.Trim()) && !string.IsNullOrEmpty(kssjtextBox.Text.Trim()))
            {
                TimeSpan midtine = DateTime.Parse(jssjtextBox.Text.Trim()) - DateTime.Parse(kssjtextBox.Text.Trim());
                if (midtine.TotalMinutes < 0)
                {
                    //ShowMeg("开始时间不能大于结束时间");
                    ShowMeg(q(Msg_Type.msgksgtjs));
                    return;
                }
                else if (midtine.TotalMinutes == 0)
                {
                    //ShowMeg("开始时间不能等于结束时间");
                    //return;
                }
            }
            if (string.IsNullOrEmpty(scdatetextBox.Text.Trim()))
            {
                 //ShowMeg("生产日期不能为空");
                ShowMeg(q(Msg_Type.msgscdatenoempty));
                 return;
            }
            if (!judge.IsDate(scdatetextBox.Text.Trim()))
            {
                 //ShowMeg("生产日期不是有效的日期格式");
                ShowMeg(q(Msg_Type.msgscdateformat));
                 return;
            }
            model.SCDATE = Convert.ToDateTime(scdatetextBox.Text.Trim()).ToString("yyyy-MM-dd");
            if (dcdjcomboBox.SelectedValue != null)
            {
                model.DCDJ = Convert.ToInt32(dcdjcomboBox.SelectedValue);
            }
            if (dcxhcomboBox.SelectedValue != null)
            {
                model.DCXH = Convert.ToInt32(dcxhcomboBox.SelectedValue);
            }
            if (cpztcomboBox.SelectedValue != null)
            {
                model.CPZT = Convert.ToInt32(cpztcomboBox.SelectedValue);
            }
            if (!string.IsNullOrEmpty(sltextBox.Text.Trim()))
            {
                model.SL = Convert.ToDecimal(sltextBox.Text.Trim());
            }
            if (!Convert.ToString(zflbcomboBox.SelectedValue).Equals("0"))
            {
                model.ZFDCLB = Convert.ToInt32(zflbcomboBox.SelectedValue);
            }
           
            if (string.IsNullOrEmpty(thtextBox.Text.Trim()))
            {
                model.TH = 0;
            }
            else
            {
                model.TH = Convert.ToInt32(thtextBox.Text.Trim());
            }
            if (MES_TM_TMINFO_LIST.GC == BranchGC)
            {
                if (MES_TM_TMINFO_LIST.TMSX == 622 || MES_TM_TMINFO_LIST.TMSX == 621)
                {

                }
                else
                {
                    if (!bzrichTextBox1.Text.Contains(ZXVerifyStr))
                    {
                        ShowMeg("工厂" + MES_TM_TMINFO_LIST.GC + "必须有\"" + ZXVerifyStr + "\"信息");//8020工厂特有暂不翻译
                        return;
                    }
                    else
                    {
                       
                    }
                }
                
            }
            model.PC = pctextBox.Text.Trim();
            model.KSTIME = kssjtextBox.Text.Trim();
            model.JSTIME = jssjtextBox.Text.Trim();
            //model.REMARK = bztextBox.Text.Trim();
            model.REMARK = bzrichTextBox1.Text.Trim(); 
            model.TM = tmtextBox1.Text.Trim();
            model.NOBILL = xsddtextBox.Text.Trim();
            model.NOBILLMX = xsxmtextBox.Text.Trim();
            model.JLR = Convert.ToInt32(getUserInfo("staffid"));
            model.GYSPC = gyspctextBox.Text.Trim();
            model.RQM = bbpmtextBox.Text.Trim();
            model.XDGX = Convert.ToInt32(hgxcomboBox.SelectedValue);
            model.BC = Convert.ToInt32(bccomboBox.SelectedValue);
            model.WQH = wqhtextBox.Text.Trim();
            model.MFQCOLOR = Convert.ToInt32(yscomboBox.SelectedValue);
            model.CLPBDM = clpbtextBox.Text.Trim();
            model.CPTYPE = Convert.ToInt32(cptypecomboBox.SelectedValue);
            if (!string.IsNullOrEmpty(bstextBox3.Text.Trim()))
            {
                model.DCSLBS = Convert.ToInt32(bstextBox3.Text.Trim());
            }
            if (!string.IsNullOrEmpty(mbsltextBox2.Text.Trim()))
            {
                model.DCSLMBSL = Convert.ToInt32(mbsltextBox2.Text.Trim());
            }            
            if (!string.IsNullOrEmpty(wstextBox1.Text.Trim()))
            {
                model.DCSLYS = Convert.ToInt32(wstextBox1.Text.Trim());
            }
           
            model.SBCD = Convert.ToInt32(sbcdcomboBox.SelectedValue);
            //model.XDGXNAME = 
            MES_RETURN_UI res = ServicModel.TM_TMINFO.UPDATE(model,getToken());
            if (res.TYPE.Equals("S"))
            {
                PrintType = (Print_Type)res.TMSX;
                if (PrintType == 0)
                {
                    ShowMeg(q(Msg_Type.msgtmsxempty));//"条码属性缺失,请联系管理员"
                    return;
                }
                switch (PrintType)
                {
                    case Print_Type.none:                       
                        break;
                    case Print_Type.rk:
                        RigthType = Rigth_Type.gangketl_cc;
                        break;
                    case Print_Type.lot:
                        RigthType = Rigth_Type.gangketl_cc;
                        break;
                    case Print_Type.zjlot:
                        RigthType = Rigth_Type.zhengjicc;
                        break;
                    case Print_Type.fujilot:
                        RigthType = Rigth_Type.fujitl;
                        break;
                    case Print_Type.zxlot:
                        RigthType = Rigth_Type.zhuxiancc;
                        break;
                    case Print_Type.bblot:
                        RigthType = Rigth_Type.baobiaocc;
                        break;
                    case Print_Type.zfsd:
                        RigthType = Rigth_Type.zhuxiancc;
                        break;
                    case Print_Type.wlrk:
                        RigthType = Rigth_Type.wlrkdy;
                        break;
                    default:
                       
                        break;
                }
                if (PrintType == Print_Type.none)
                {
                    ShowMeg(q(Msg_Type.msgprintdataexpect));//"获得打印数据异常,请联系管理员"
                }
                else
                {
                    PrintInfoByTM(res.TM, res.GC, 1, RigthType, PrintType);
                    ClearUI();
                }
                
            }
            else
            {
                ShowMeg(res.MESSAGE);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sltextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            judge.isNum(sltextBox, e);
        }

        private void xsddtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            judge.isNum(xsddtextBox, e);
        }

        private void xsxmtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            judge.isNum(xsxmtextBox, e);
        }

        private void thtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            judge.isNum(thtextBox, e);
        }

      

        private void wstextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            judge.isNum(wstextBox1, e);
        }

        private void mbsltextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            judge.isNum(mbsltextBox2, e);
        }

        private void bstextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            judge.isNum(bstextBox3, e);
        }
        public void calculator()
        {
            try
            {
                long res = 0;
                if (!string.IsNullOrEmpty(bstextBox3.Text.Trim()) && !string.IsNullOrEmpty(mbsltextBox2.Text.Trim()))
                {
                    res = Convert.ToInt64(bstextBox3.Text.Trim()) * Convert.ToInt64(mbsltextBox2.Text.Trim());
                }
                if (!string.IsNullOrEmpty(wstextBox1.Text.Trim()))
                {
                    res += Convert.ToInt64(wstextBox1.Text.Trim());
                }
                sltextBox.Text = res.ToString();
            }
            catch (Exception e)
            {
                ShowMeg(e.Message);
            }

        }

        private void bstextBox3_TextChanged(object sender, EventArgs e)
        {
            calculator();
        }

        private void mbsltextBox2_TextChanged(object sender, EventArgs e)
        {
            calculator();
        }

        private void wstextBox1_TextChanged(object sender, EventArgs e)
        {
            calculator();
        }

        private void wqhtextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void wqhtextBox_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(MES_TM_TMINFO_LIST.MID))
            {
                MES_PMM_MOULD model = new MES_PMM_MOULD();
                model.MID = MES_TM_TMINFO_LIST.MID;
                MES_PMM_MOULD_SELECT res = ServicModel.PMM_MOULD.SELECT_ALL(model, getToken());
                if (res.MES_RETURN.TYPE.Equals("S"))
                {
                    if (res.MES_PMM_MOULD.Length == 1)
                    {
                        frmZSLotSub form = new frmZSLotSub(1, wqhtextBox.Text.Trim(), res.MES_PMM_MOULD[0].CAVE);
                        form.block = SubBackContent;
                        show(form);
                    }
                }
            }
           
          
        }
        public void SubBackContent(string content)
        {
            wqhtextBox.Text = content;
        }
        public void ConfigWllotInfo()
        {
            if (!string.IsNullOrEmpty(jssjtextBox.Text.Trim()))
            {
                if (judge.IsDate(jssjtextBox.Text.Trim()) && jssjtextBox.Text.Trim().Length == 19)
                {

                }
                else
                {
                    //ShowMeg("结束时间不是有效的日期格式");
                    //ShowMeg(q(Msg_Type.msgjssjformat));
                    return;
                }
            }
            else
            {
                return;
            }
            string _workdayAM = "07:30";
            string _workdayPM = "19:30";
            TimeSpan dspWorkingDayAM = DateTime.Parse(_workdayAM).TimeOfDay;
            TimeSpan dspWorkingDayPM = DateTime.Parse(_workdayPM).TimeOfDay;
            //string time1 = "2017-2-17 8:10:00";
            List<MES_SY_TYPEMXLIST> bclist = GetDictionaryMX(5, MES_TM_TMINFO_LIST.GC).ToList();
            DateTime t1 = Convert.ToDateTime(jssjtextBox.Text.Trim());
            TimeSpan dspNow = t1.TimeOfDay;
            int bcindex = 0;
            bool isSubday = false;
            if (dspNow >= dspWorkingDayAM && dspNow <= dspWorkingDayPM)
            {
                bcindex = bclist.FindIndex(p => p.MXNAME == "日班");

            }
            else
            {
                if (dspNow < dspWorkingDayAM)
                {
                    isSubday = true;
                }
                bcindex = bclist.FindIndex(p => p.MXNAME == "夜班");

            }
            if (bcindex == -1)
            {
                //ShowMeg("获取班次信息异常请联系管理员");
                return;
            }
            bccomboBox.SelectedValue = bclist[bcindex].ID;
            if (isSubday)
            {
                t1 = t1.AddDays(-1);
            }
            //info.SCDATE = t1.ToString("yyyy-MM-dd");
            scdatetextBox.Text = t1.ToString("yyyy-MM-dd");
        }

        private void jssjtextBox_Leave(object sender, EventArgs e)
        {
            if (MES_TM_TMINFO_LIST.TMSX == 621)
            {
                ConfigWllotInfo();
            }
        }

        private void jssjtextBox_TextChanged(object sender, EventArgs e)
        {
            if (MES_TM_TMINFO_LIST.TMSX == 621)
            {
                ConfigWllotInfo();
            }
        }
    }
}
