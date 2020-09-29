using Sonluk.MES.MES.Base;
using Sonluk.UI.Model.MES.PD_SCRWService;
using Sonluk.UI.Model.MES.SY_GZZX_SBHService;
using Sonluk.UI.Model.MES.SY_GZZXService;
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
    public partial class frmFindSBH : baseview
    {
        MES_SY_GZZX_SBH[] _sbhlist;

        public MES_SY_GZZX_SBH[] Sbhlist
        {
            get { return _sbhlist; }
            set { _sbhlist = value; }
        }
        string gzzx;

        public string Gzzx
        {
            get { return gzzx; }
            set { gzzx = value; }
        }
        string _tm;

        public string Tm
        {
            get { return _tm; }
            set { _tm = value; }
        }
        bool isFJpipeline;

        public bool IsFJpipeline
        {
            get { return isFJpipeline; }
            set { isFJpipeline = value; }
        }
        public frmFindSBH()
        {
            InitializeComponent();
        }
        public frmFindSBH(MES_SY_GZZX_SBH[] list, string gzzx, Rigth_Type rtype, string tm)
        {
            InitializeComponent();
            Tm = tm;
            Init(list, gzzx, rtype);
        }
        public frmFindSBH(MES_SY_GZZX_SBH[] list, string gzzx, Rigth_Type rtype, bool isfindFJ)
        {
            InitializeComponent();
            IsFJpipeline = isfindFJ;
            Init(list, gzzx, rtype);

        }
        public void Init(MES_SY_GZZX_SBH[] list, string gzzx, Rigth_Type rtype)
        {
            RigthType = rtype;
            Sbhlist = list;
            Gzzx = gzzx;

            if (rtype == Rigth_Type.zhujizhengjitl)
            {
                label1.Text = q(Msg_Type.fieldsdscx);//"素电生产线";
            }
            else
            {
                MES_SY_GZZX model = new MES_SY_GZZX();
                if (list.Length > 0)
                {
                    model.GC = list[0].GC;

                    model.GZZXBH = gzzx;
                    string[] sArray = model.GZZXBH.Split('-');
                    if (sArray.Length > 1)
                    {
                        label1.Text = gzzx;
                    }
                    else
                    {
                        MES_SY_GZZX[] res = ServicModel.SY_GZZX.SELECT(model, getToken());
                        if (res.Length == 0)
                        {
                            label1.Text = gzzx;
                        }
                        else
                        {
                            label1.Text = gzzx + "-" + res[0].GZZXMS;
                        }
                        
                      
                    }

                }
                else
                {
                    label1.Text = gzzx;
                }
            }
            panel1.AutoScroll = true;
            for (int i = 0; i < list.Length; i++)
            {
                Button btn = new Button();
                if (RigthType == Rigth_Type.fujitl)
                {
                    btn.Size = new Size(180, 140);
                    btn.Location = new Point(10 + rect.Width / 5 * (i % 5), 0 + i / 5 * 195);
                    btn.Font = new System.Drawing.Font(q(Msg_Type.fonttype), 40);
                }
                else
                {
                    btn.Size = new Size(90, 70);
                    btn.Location = new Point(10 + rect.Width / 10 * (i % 10), 0 + i / 10 * 85);
                    btn.Font = new System.Drawing.Font(q(Msg_Type.fonttype), 13);
                }
                btn.Text = list[i].SBMS;
                btn.Tag = list[i].SBBH;
                btn.Click += new System.EventHandler(this.btn_Click);
                btn.FlatStyle = FlatStyle.Popup;
                panel1.Controls.Add(btn);
            }


            smtextBox1.Select();
        }
        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string sbbh = Convert.ToString(btn.Tag);
            MES_PD_SCRW model = new MES_PD_SCRW();
            model.SBBH = sbbh;
            //model.ZPRQ = DateTime.Now.ToString("yyyy-MM-dd");
            model.ZPRQ = Convert.ToDateTime(ServicModel.PUBLIC_FUNC.GET_TIME(getToken())).ToString("yyyy-MM-dd");
            string sydt = "";
            SBHID = model.SBBH;
            SELECT_MES_PD_SCRW Smodel;
            switch (RigthType)
            {
                case Rigth_Type.gangketl_cc:
                    Smodel = ServicModel.PD_SCRW.SELECT_LAST(model, getToken());

                    break;
                case Rigth_Type.jidiantitl_cc:
                    Smodel = ServicModel.PD_SCRW.SELECT_LAST(model, getToken());
                    break;
                case Rigth_Type.fujitl:
                    sydt = GetSystemDate(Date_Type.hour, -4, "yyyy-MM-dd");//Convert.ToDateTime(ServicModel.PUBLIC_FUNC.GET_TIME(getToken())).AddHours(-4).ToString("yyyy-MM-dd");//系统减4个小时
                    model.ZPRQ = sydt;
                    Smodel = ServicModel.PD_SCRW.SELECT(model, getToken());
                    break;
                case Rigth_Type.fujicc:
                    sydt = GetSystemDate(Date_Type.hour, -4, "yyyy-MM-dd");//Convert.ToDateTime(ServicModel.PUBLIC_FUNC.GET_TIME(getToken())).AddHours(-4).ToString("yyyy-MM-dd");//系统减4个小时
                    model.ZPRQ = sydt;
                    Smodel = ServicModel.PD_SCRW.SELECT_LAST(model, getToken());
                    break;
                case Rigth_Type.zhengjicc:
                    Smodel = ServicModel.PD_SCRW.SELECT_LAST(model, getToken());
                    break;
                case Rigth_Type.zhuxiantl:
                    Smodel = ServicModel.PD_SCRW.SELECT(model, getToken());
                    break;
                case Rigth_Type.zhujizhengjitl:
                    Smodel = ServicModel.PD_SCRW.SELECT(model, getToken());
                    break;
                case Rigth_Type.zhuxiancc:
                    Smodel = ServicModel.PD_SCRW.SELECT_LAST(model, getToken());
                    break;
                case Rigth_Type.baobiaocc:
                    Smodel = ServicModel.PD_SCRW.SELECT_LAST(model, getToken());
                    break;
                case Rigth_Type.dczztl_cc:
                    Smodel = ServicModel.PD_SCRW.SELECT_LAST(model, getToken());
                    break;
                case Rigth_Type.baozhuangcc:
                    Smodel = ServicModel.PD_SCRW.SELECT_LAST(model, getToken());
                    break;
                case Rigth_Type.ddjtl_cc:
                    Smodel = ServicModel.PD_SCRW.SELECT_LAST(model, getToken());
                    break;
                default:
                    Smodel = ServicModel.PD_SCRW.SELECT_LAST(model, getToken());
                    break;
            }
            //如果是E的时候只有包标、组合电池、包装可以进入投料产出界面,在界面上扫描工单和托盘码生成相应的任务
            if (Smodel.MES_RETURN.TYPE == "E")
            {
                if (RigthType == Rigth_Type.baobiaocc || RigthType == Rigth_Type.dczztl_cc)
                {
                    if (string.IsNullOrEmpty(Tm))
                    {
                        frmBaobiao form = new frmBaobiao(new MES_PD_SCRW_LIST(), model.SBBH, RigthType, btn.Text);
                        push(form, this);
                    }
                    else
                    {
                        frmBaobiao form = new frmBaobiao(new MES_PD_SCRW_LIST(), model.SBBH, RigthType, btn.Text, Tm);
                        push(form, this);
                    }

                    return;
                }
                else if (RigthType == Rigth_Type.baozhuangcc)
                {
                    if (string.IsNullOrEmpty(Tm))
                    {
                        frmBaozhuang form = new frmBaozhuang(new MES_PD_SCRW_LIST(), model.SBBH, RigthType, btn.Text);
                        push(form, this);
                    }
                    else
                    {
                        frmBaozhuang form = new frmBaozhuang(new MES_PD_SCRW_LIST(), model.SBBH, RigthType, btn.Text, Tm);
                        push(form, this);
                    }

                    return;
                }
                else
                {
                    //MessageBox.Show(Smodel.MES_RETURN.MESSAGE, "消息框");
                    ShowMeg(Smodel.MES_RETURN.MESSAGE);
                    return;
                }

            }

            if (Smodel.MES_PD_SCRW_LIST.Length == 0)
            {
                //MessageBox.Show("找不到工作中心是" + Gzzx + "设备号是" + btn.Text + "对应的派单任务！！！", "消息框");
                ShowMeg(string.Format(q(Msg_Type.msgnorw), Gzzx, btn.Text));
                return;
            }
            else if (Smodel.MES_PD_SCRW_LIST.Length == 1)
            {
                if (RigthType == Rigth_Type.fujitl)
                {
                    ini.IniWriteValue(ini.Section_Machine, "fjsbh", sbbh);
                    frmFujiTL_N fjtlform = new frmFujiTL_N(Smodel.MES_PD_SCRW_LIST, btn.Text, sbbh);

                    push(fjtlform, this);
                }
                else if (RigthType == Rigth_Type.gangketl_cc || RigthType == Rigth_Type.jidiantitl_cc || RigthType == Rigth_Type.mfqqingxi || RigthType == Rigth_Type.gmgtl_cc || RigthType == Rigth_Type.fujifengkoujitl_cc || RigthType == Rigth_Type.zhengjifengkoujitl_cc)
                {
                    //frmTL2  form = new frmTL2(Smodel.MES_PD_SCRW_LIST[0], model.SBBH, RigthType);
                    //push(form);
                    frmTL2_1 form = new frmTL2_1(Smodel.MES_PD_SCRW_LIST[0], model.SBBH, RigthType);
                    push(form, this);
                }
                else if (RigthType == Rigth_Type.ddjtl_cc)
                {
                    frmTL2_2 form = new frmTL2_2(Smodel.MES_PD_SCRW_LIST[0], model.SBBH, RigthType);
                    push(form, this);
                }
                else if (RigthType == Rigth_Type.zhuxiancc)
                {
                    frmZX_CC form = new frmZX_CC(Smodel.MES_PD_SCRW_LIST[0], model.SBBH, RigthType);
                    push(form, this);
                }
                else if (RigthType == Rigth_Type.baobiaocc || RigthType == Rigth_Type.dczztl_cc)
                {
                    if (string.IsNullOrEmpty(Tm))
                    {
                        frmBaobiao form = new frmBaobiao(Smodel.MES_PD_SCRW_LIST[0], model.SBBH, RigthType, btn.Text);
                        push(form, this);
                    }
                    else
                    {
                        frmBaobiao form = new frmBaobiao(Smodel.MES_PD_SCRW_LIST[0], model.SBBH, RigthType, btn.Text, Tm);
                        push(form, this);
                    }

                }
                else if (RigthType == Rigth_Type.baozhuangcc)
                {
                    if (string.IsNullOrEmpty(Tm))
                    {
                        frmBaozhuang form = new frmBaozhuang(new MES_PD_SCRW_LIST(), model.SBBH, RigthType, btn.Text);
                        push(form, this);
                    }
                    else
                    {
                        frmBaozhuang form = new frmBaozhuang(new MES_PD_SCRW_LIST(), model.SBBH, RigthType, btn.Text, Tm);
                        push(form, this);
                    }


                }
                else if (RigthType == Rigth_Type.zhuxiantl || RigthType == Rigth_Type.zhujizhengjitl)
                {

                    frmZX_TL form = new frmZX_TL(Smodel.MES_PD_SCRW_LIST[0], model.SBBH, RigthType); ;
                    push(form, this);
                }


            }
            else if (Smodel.MES_PD_SCRW_LIST.Length > 1)//查询到的任务大于1的只有负极投料和主线投料
            {

                if (RigthType == Rigth_Type.fujitl)
                {
                    ini.IniWriteValue(ini.Section_Machine, "fjsbh", sbbh);
                    frmFujiTL_N fjtlform = new frmFujiTL_N(Smodel.MES_PD_SCRW_LIST, btn.Text, sbbh);
                    push(fjtlform, this);
                }
                else if (RigthType == Rigth_Type.zhuxiantl || RigthType == Rigth_Type.zhujizhengjitl)
                {
                    frmZX_TL form = new frmZX_TL(Smodel.MES_PD_SCRW_LIST[0], model.SBBH, RigthType);
                    push(form, this);
                }
                this.Close();
            }
        }

        private void frmFindSBH_Shown(object sender, EventArgs e)
        {
            string gzzx = Gzzx.Split('-')[0];
            if (gzzx.Equals("Z2002"))
            {
                    string sbh = ini.IniReadValue(ini.Section_Machine, "fjsbh");
                    if (!string.IsNullOrEmpty(sbh) && IsFJpipeline == true)
                    {
                        MES_PD_SCRW model = new MES_PD_SCRW();
                        model.SBBH = sbh;
                        //DateTime dt = Convert.ToDateTime(ServicModel.PUBLIC_FUNC.GET_TIME(getToken())).AddHours(-4);
                        //model.ZPRQ = Convert.ToDateTime(ServicModel.PUBLIC_FUNC.GET_TIME(getToken())).AddHours(-4).ToString("yyyy-MM-dd");
                        model.ZPRQ = GetSystemDate(Date_Type.hour, -4, "yyyy-MM-dd");
                        //model.ZPRQ = DateTime.Now.ToString("yyyy-MM-dd");
                        SELECT_MES_PD_SCRW Smodel = ServicModel.PD_SCRW.SELECT(model, getToken());
                        if (Smodel.MES_RETURN.Equals("E"))
                        {
                            ShowMeg(Smodel.MES_RETURN.MESSAGE);

                        }
                        else
                        {
                            if (Smodel.MES_PD_SCRW_LIST.Length > 0)
                            {
                                frmFujiTL_N fjtlform = new frmFujiTL_N(Smodel.MES_PD_SCRW_LIST, Smodel.MES_PD_SCRW_LIST[0].SBH, sbh);
                                push(fjtlform, this);
                            }
                            else
                            {
                                ShowMeg(q(Msg_Type.msgnodata));//"没有查询到数据"
                                return;
                            }
                            
                            //this.Close();

                        }
                    }
            }
            else
            {
                if (Sbhlist.Length == 1)
                {
                    foreach (Control ctl in panel1.Controls)
                    {
                        if (ctl is Button)
                        {
                            Button btn = (Button)ctl;
                            this.btn_Click(btn, new EventArgs());
                        }
                    }
                }
            }
           
        }

        private void smtextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                ScanTM();
            }

        }
        public void ScanTM()
        {
            if (smtextBox1.Text.Trim().Length != 10)
            {
                ShowMeg(q(Msg_Type.msgnosbh));//"扫描的不是设备号条码"
                return;
            }
            MES_SY_GZZX_SBH sbhmodel = new MES_SY_GZZX_SBH();
            sbhmodel.SBBH = smtextBox1.Text.Trim();
            MES_SY_GZZX_SBH[] sbList = ServicModel.SY_GZZX_SBH.SELECT(sbhmodel, getToken());
            if (sbList.Length == 1)
            {
                bool isGZZX_SB = false;
                for (int i = 0; i < Sbhlist.Length; i++)
                {
                    if (sbList[0].SBBH == Sbhlist[i].SBBH)
                    {
                        isGZZX_SB = true;
                        break;
                    }
                }
                if (isGZZX_SB)
                {
                    MES_PD_SCRW model = new MES_PD_SCRW();
                    model.SBBH = sbList[0].SBBH;
                    model.ZPRQ = GetSystemDate(Date_Type.hour, 0, "yyyy-MM-dd");// DateTime.Now.ToString("yyyy-MM-dd");
                    //model.GC = getGC("value");
                    //model.GZZXBH = getUserInfo("gzzxvalue");
                    SBHID = model.SBBH;

                    SELECT_MES_PD_SCRW Smodel;//SELEXT_LAST只查询最后一个任务,SELECT查询的是所有当天的任务.暂时只有负极和主线
                    switch (RigthType)
                    {
                        case Rigth_Type.gangketl_cc:
                            Smodel = ServicModel.PD_SCRW.SELECT_LAST(model, getToken());

                            break;
                        case Rigth_Type.jidiantitl_cc:
                            Smodel = ServicModel.PD_SCRW.SELECT_LAST(model, getToken());
                            break;
                        case Rigth_Type.fujitl:
                            Smodel = ServicModel.PD_SCRW.SELECT(model, getToken());
                            break;
                        case Rigth_Type.fujicc:
                            Smodel = ServicModel.PD_SCRW.SELECT_LAST(model, getToken());
                            break;
                        case Rigth_Type.zhengjicc:
                            Smodel = ServicModel.PD_SCRW.SELECT_LAST(model, getToken());
                            break;
                        case Rigth_Type.zhuxiantl:
                            Smodel = ServicModel.PD_SCRW.SELECT(model, getToken());
                            break;
                        case Rigth_Type.zhujizhengjitl:
                            Smodel = ServicModel.PD_SCRW.SELECT(model, getToken());
                            break;
                        case Rigth_Type.zhuxiancc:
                            Smodel = ServicModel.PD_SCRW.SELECT_LAST(model, getToken());
                            break;
                        case Rigth_Type.baobiaocc:
                            Smodel = ServicModel.PD_SCRW.SELECT_LAST(model, getToken());
                            break;
                        case Rigth_Type.dczztl_cc:
                            Smodel = ServicModel.PD_SCRW.SELECT_LAST(model, getToken());
                            break;
                        case Rigth_Type.baozhuangcc:
                            Smodel = ServicModel.PD_SCRW.SELECT_LAST(model, getToken());
                            break;
                        case Rigth_Type.ddjtl_cc:
                            Smodel = ServicModel.PD_SCRW.SELECT_LAST(model, getToken());
                            break;
                        default:
                            Smodel = ServicModel.PD_SCRW.SELECT_LAST(model, getToken());
                            break;
                    }
                    if (Smodel.MES_RETURN.TYPE == "E")
                    {
                        if (RigthType == Rigth_Type.baobiaocc || RigthType == Rigth_Type.dczztl_cc)
                        {
                            frmBaobiao form = new frmBaobiao(new MES_PD_SCRW_LIST(), model.SBBH, RigthType, sbList[0].SBMS);
                            push(form, this);
                            return;
                        }
                        else if (RigthType == Rigth_Type.baozhuangcc)
                        {
                            frmBaozhuang form = new frmBaozhuang(new MES_PD_SCRW_LIST(), model.SBBH, RigthType, sbList[0].SBMS);
                            push(form, this);
                            return;
                        }
                        else
                        {
                            //MessageBox.Show(Smodel.MES_RETURN.MESSAGE, "消息框");
                            ShowMeg(Smodel.MES_RETURN.MESSAGE);
                            return;
                        }

                    }
                    if (Smodel.MES_PD_SCRW_LIST.Length == 0)
                    {
                        //MessageBox.Show("找不到工作中心是" + Gzzx + "设备号是" + sbList[0].SBMS + "对应的派单任务！！！", "消息框");
                        ShowMeg(string.Format(q(Msg_Type.msgnorw), Gzzx, sbList[0].SBMS));
                        return;
                    }
                    else if (Smodel.MES_PD_SCRW_LIST.Length == 1)
                    {
                        if (RigthType == Rigth_Type.fujitl)
                        {
                            ini.IniWriteValue(ini.Section_Machine, "fjsbh", smtextBox1.Text.Trim());
                            frmFujiTL_N fjtlform = new frmFujiTL_N(Smodel.MES_PD_SCRW_LIST, sbList[0].SBMS, sbList[0].SBBH);
                            push(fjtlform, this);
                        }
                        else if (RigthType == Rigth_Type.gangketl_cc || RigthType == Rigth_Type.jidiantitl_cc || RigthType == Rigth_Type.mfqqingxi || RigthType == Rigth_Type.gmgtl_cc || RigthType == Rigth_Type.fujifengkoujitl_cc)
                        {
                            frmTL2_1 form = new frmTL2_1(Smodel.MES_PD_SCRW_LIST[0], model.SBBH, RigthType);
                            push(form, this);
                        }
                        else if (RigthType == Rigth_Type.ddjtl_cc)
                        {
                            frmTL2_2 form = new frmTL2_2(Smodel.MES_PD_SCRW_LIST[0], model.SBBH, RigthType);
                            push(form, this);
                        }
                        else if (RigthType == Rigth_Type.zhuxiancc)
                        {
                            frmZX_CC form = new frmZX_CC(Smodel.MES_PD_SCRW_LIST[0], model.SBBH, RigthType);
                            push(form, this);
                        }
                        else if (RigthType == Rigth_Type.baobiaocc || RigthType == Rigth_Type.dczztl_cc)
                        {
                            frmBaobiao form = new frmBaobiao(Smodel.MES_PD_SCRW_LIST[0], model.SBBH, RigthType, sbList[0].SBMS);
                            push(form, this);
                        }
                        else if (RigthType == Rigth_Type.baozhuangcc)
                        {
                            frmBaozhuang form = new frmBaozhuang(new MES_PD_SCRW_LIST(), model.SBBH, RigthType, sbList[0].SBMS);
                            push(form, this);

                        }
                        else if (RigthType == Rigth_Type.zhuxiantl || RigthType == Rigth_Type.zhujizhengjitl)
                        {
                            frmZX_TL form = new frmZX_TL(Smodel.MES_PD_SCRW_LIST[0], model.SBBH, RigthType); ;
                            push(form, this);
                        }


                    }
                    else if (Smodel.MES_PD_SCRW_LIST.Length > 1)
                    {
                        if (RigthType == Rigth_Type.fujitl)
                        {
                            ini.IniWriteValue(ini.Section_Machine, "fjsbh", smtextBox1.Text.Trim());
                            frmFujiTL_N fjtlform = new frmFujiTL_N(Smodel.MES_PD_SCRW_LIST, sbList[0].SBMS, sbList[0].SBBH);
                            push(fjtlform, this);
                        }
                        else if (RigthType == Rigth_Type.zhuxiantl || RigthType == Rigth_Type.zhujizhengjitl)
                        {
                            frmZX_TL form = new frmZX_TL(Smodel.MES_PD_SCRW_LIST[0], model.SBBH, RigthType);
                            push(form, this);
                        }
                        this.Close();
                    }
                }
                else
                {
                    ShowMeg(q(Msg_Type.msgsbhnomacthgzzz));//"扫描的设备号不是当前工作中心下的"
                }

            }
            else if (sbList.Length == 0)
            {
                ShowMeg(q(Msg_Type.msgscannosbh));//"扫描的不是设备号条码"
                return;
            }
            else
            {
                ShowMeg(q(Msg_Type.msgsystemerror));//"系统异常请联系管理员"
                return;
            }


        }

    }
}
