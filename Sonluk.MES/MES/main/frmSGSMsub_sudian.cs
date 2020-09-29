using Sonluk.MES.MES.Base;
using Sonluk.UI.Model.MES.MM_CKService;
using Sonluk.UI.Model.MES.SY_GZZX_SBHService;
using Sonluk.UI.Model.MES.SY_GZZXService;
using Sonluk.UI.Model.MES.SY_MATERIAL_BZCOUNTservice;
using Sonluk.UI.Model.MES.SY_MATERIALService;
using Sonluk.UI.Model.MES.SY_TYPEMXService;
using Sonluk.UI.Model.MES.TM_TMINFOService;
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
    public partial class frmSGSMsub_sudian : basefrm
    {
        MES_SY_MATERIAL_LIST _MES_SY_MATERIAL_LIST;

        public MES_SY_MATERIAL_LIST MES_SY_MATERIAL_LIST
        {
            get { return _MES_SY_MATERIAL_LIST; }
            set { _MES_SY_MATERIAL_LIST = value; }
        }
        public frmSGSMsub_sudian()
        {
            InitializeComponent();
        }
        public frmSGSMsub_sudian(MES_SY_MATERIAL_LIST model,int tmType)
        {
            InitializeComponent();
            //monthCalendar1.Visible = false;
            //monthCalendar2.Visible = false;
            //monthCalendar3.Visible = false;
            MES_SY_MATERIAL_LIST = model;
            List<MES_SY_TYPEMXLIST> tmsxList = new List<MES_SY_TYPEMXLIST>();
            tmsxList = GetDictionaryMX(16, model.GC).ToList();

            List<MES_SY_TYPEMXLIST> tmList = new List<MES_SY_TYPEMXLIST>();
            for (int i = 0; i < tmsxList.Count; i++)
            {
                if (tmsxList[i].ID == tmType)
                {
                    MES_SY_TYPEMXLIST node = new MES_SY_TYPEMXLIST();
                    node = tmsxList[i];
                    tmList.Add(node);
                }
            }
           
            //MES_SY_TYPEMXLIST tmsxmodel = new MES_SY_TYPEMXLIST();
            //tmsxmodel.MXNAME = "==请选择==";
            //tmsxmodel.ID = 0;
            //tmList.Insert(0, tmsxmodel);
            tmsxcomboBox.DataSource = tmList;
            tmsxcomboBox.DisplayMember = "MXNAME";
            tmsxcomboBox.ValueMember = "ID";
            gctextBox.Text = model.GC;
            wlxxtextBox.Text = model.WLH + "/" + model.WLMS;
            wllbtextBox.Text = model.WLLBNAME;
            wlzxxtextBox.Text = model.WLGROUP + "/" + model.WLGROUPNAME;
            dcxhtextBox.Text = model.DCXHNAME;
            dcdjtextBox.Text = model.DCDJNAME;
            //素电 权限 ----工作中心
            MES_SY_GZZX gzzxmodel = new MES_SY_GZZX();
            gzzxmodel.GC = model.GC;
            gzzxmodel.WLLB = model.WLLB;
            MES_SY_GZZX[] list = ServicModel.SY_GZZX.SELECT(gzzxmodel, getToken());
            gzzxcomboBox.SelectedValue = "";
            gzzxcomboBox.SelectedText = "";
            for (int i = 0; i < list.Length; i++)
            {
                list[i].GZZXMS = list[i].GZZXMS + "-" + list[i].GZZXBH;
            }
            List<MES_SY_GZZX> gzzxlist = list.ToList();
            // staffid 权限 ----工作中心
            MES_SY_GZZX gzzxmodel_staff = new MES_SY_GZZX();
            gzzxmodel_staff.GC = model.GC;
            gzzxmodel_staff.STAFFID = Convert.ToInt32(getUserInfo("staffid"));
            MES_SY_GZZX[] list_staffid = ServicModel.SY_GZZX.SELECT_BY_ROLE(gzzxmodel_staff, getToken());
            for (int i = 0; i < list_staffid.Length; i++)
            {
                list_staffid[i].GZZXMS = list_staffid[i].GZZXMS + "-" + list_staffid[i].GZZXBH;
            }
            for (int i = 0; i < list_staffid.Length; i++)
            {               
                if (gzzxlist.FindIndex(p => p.GZZXBH == list_staffid[i].GZZXBH) == -1)
                {
                    gzzxlist.Add(list_staffid[i]);
                }
            }           
            MES_SY_GZZX gzzxchoicemodel = new MES_SY_GZZX();          
            gzzxchoicemodel.GZZXBH = "0";
            gzzxchoicemodel.GZZXMS = q(Msg_Type.titlechoice);//"==请选择==";
            gzzxlist.Insert(0, gzzxchoicemodel); 
            
            gzzxcomboBox.DataSource = gzzxlist;
            gzzxcomboBox.ValueMember = "GZZXBH";
            gzzxcomboBox.DisplayMember = "GZZXMS";

            List<MES_SY_TYPEMXLIST> cpztList = GetDictionaryMX(9, model.GC).ToList();
            int cpztIndex = cpztList.FindIndex(p => p.MXNAME.Equals("暂放"));           
            cpztcomboBox5.DataSource = cpztList;
            cpztcomboBox5.DisplayMember = "MXNAME";
            cpztcomboBox5.ValueMember = "ID";
            if (cpztIndex != -1)
            {
                cpztcomboBox5.SelectedValue = cpztList[cpztIndex].ID;
            }



            //I类暂放电
            List<MES_SY_TYPEMXLIST> zfsdlist = GetDictionaryMX(17).ToList();
            int zfsdIndex = zfsdlist.FindIndex(p => p.MXNAME.Equals("I类暂放电"));           
            MES_SY_TYPEMXLIST zfsdnode = new MES_SY_TYPEMXLIST();
            zfsdnode.ID = 0;
            zfsdnode.MXNAME = q(Msg_Type.titlechoice);//"==请选择==";
            zfsdlist.Insert(0, zfsdnode);
            zflbcomboBox.DataSource = zfsdlist;
            zflbcomboBox.DisplayMember = "MXNAME";
            zflbcomboBox.ValueMember = "ID";
            if (zfsdIndex != -1)
            {
                 zflbcomboBox.SelectedValue = zfsdlist[zfsdIndex + 1].ID;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tmsxcomboBox.SelectedValue) == 0)
            {
                ShowMeg(q(Msg_Type.msgchoicetmlb));//"请选择条码类别"
                return;
            }
            if (string.IsNullOrEmpty(pctextBox17.Text.Trim()))
            {
                ShowMeg(q(Msg_Type.msgpcnoempty));//"批次信息不能为空"
                return;
            }
            if (string.IsNullOrEmpty(thtextBox11.Text.Trim()))
            {
                ShowMeg(q(Msg_Type.msgthnoempty));//"桶号信息不能为空"
                return;
            }
            if (!string.IsNullOrEmpty(dateTimePicker1.Text.Trim()))
            {
                if (!judge.IsDate(dateTimePicker1.Text.Trim()))
                {
                    ShowMeg(q(Msg_Type.msgkssjformat));//"开始日期不是有效的日期格式"
                    return;
                }
            }
            if (!string.IsNullOrEmpty(dateTimePicker2.Text.Trim()))
            {
                if (!judge.IsDate(dateTimePicker2.Text.Trim()))
                {
                    ShowMeg(q(Msg_Type.msgjssjformat));//"结束日期不是有效的日期格式"
                    return;
                }
            }
            if (string.IsNullOrEmpty(bstextBox.Text.Trim()))
            {
                ShowMeg(q(Msg_Type.msgbsnoempty));//"板数信息不能为空"
                return;

            }
            if (string.IsNullOrEmpty(mbsltextBox.Text.Trim()))
            {
                ShowMeg(q(Msg_Type.msgmbslnoempty));//"每板数量不能为空"
                return;
            }
            if (!string.IsNullOrEmpty(dateTimePicker1.Text.Trim()) && !string.IsNullOrEmpty(dateTimePicker2.Text.Trim()))
            {
                TimeSpan span = Convert.ToDateTime(dateTimePicker1.Text.Trim()) - Convert.ToDateTime(dateTimePicker2.Text.Trim());
                if (span.TotalMinutes > 0)
                {
                    ShowMeg(q(Msg_Type.msgksgtjs));//"开始日期不能大于结束日期"
                    return;
                  
                    
                }
            }
            UI.Model.MES.TM_TMINFOService.MES_TM_TMINFO_INSERT_GL model1 = new UI.Model.MES.TM_TMINFOService.MES_TM_TMINFO_INSERT_GL();
            MES_TM_TMINFO model = new MES_TM_TMINFO();
            if (Convert.ToInt32(tmsxcomboBox.SelectedValue) == 374)
            {
                model.TMLB = 2;
            }
            else
            {
                model.TMLB = 1;
            }

            model.GC = gctextBox.Text;
            model.WLH = MES_SY_MATERIAL_LIST.WLH;
            model.WLMS = MES_SY_MATERIAL_LIST.WLMS;
            model.WLLB = MES_SY_MATERIAL_LIST.WLLB;
            model.WLLBNAME = MES_SY_MATERIAL_LIST.WLLBNAME;
            model.WLGROUP = MES_SY_MATERIAL_LIST.WLGROUP;
            model.UNITSID = MES_SY_MATERIAL_LIST.UNITSID;
            model.UNITSNAME = MES_SY_MATERIAL_LIST.UNITSNAME;
            if (!Convert.ToString(gzzxcomboBox.SelectedValue).Equals("0")  )
            {
                model.GZZXBH = Convert.ToString(gzzxcomboBox.SelectedValue);
                model.GZZXMS = gzzxcomboBox.Text.Trim();
            }
            else
            {
                ShowMeg(q(Msg_Type.msggzzxnoempty));//"工作中心不能为空"
                return;
            }
            if (gzzxcomboBox.SelectedValue == null)
            {
                ShowMeg(q(Msg_Type.msggzzxinvalid));//"不是有效的工作中心请核对"
                return;
            }
            if (!Convert.ToString(sbhcomboBox3.SelectedValue).Equals("0"))
            {
                model.SBBH = Convert.ToString(sbhcomboBox3.SelectedValue);
                model.SBHMS = sbhcomboBox3.Text.Trim();
            }
            else
            {
                //if (MES_SY_MATERIAL_LIST.WLLBNAME.Equals("素电"))
                //{
                //    ShowMeg("设备号不能为空");
                //    return;
                //}
                
            }
          
            if (!Convert.ToString(zflbcomboBox.SelectedValue).Equals("0"))
            {
                model.ZFDCLB = Convert.ToInt32(zflbcomboBox.SelectedValue);
            }



            model.DCDJ = MES_SY_MATERIAL_LIST.DCDJ;
            model.DCDJMS = MES_SY_MATERIAL_LIST.DCDJNAME;
            model.DCXH = MES_SY_MATERIAL_LIST.DCXH;
            model.DCXHMS = MES_SY_MATERIAL_LIST.DCXHNAME;
            model.SCDATE = dateTimePicker3.Text.Trim();
            //model.KSTIME = kssjtextBox14.Text.Trim();
            //model.JSTIME = jssjtextBox15.Text.Trim();
            //model.BC = Convert.ToInt32(bccomboBox4.SelectedValue);
            //model.BCMS = bccomboBox4.Text.Trim();
            model.PC = pctextBox17.Text.Trim();
            //model.CLCJ = clcjtextBox7.Text.Trim();
            //model.GYLX = gylxtextBox8.Text.Trim();
            //model.GYSMS = gysjctextBox10.Text.Trim();
            model.CPZT = Convert.ToInt32(cpztcomboBox5.SelectedValue);
            model.JLR = Convert.ToInt32(getUserInfo("staffid"));
            if (!string.IsNullOrEmpty(thtextBox11.Text.Trim()))
            {
                model.TH = Convert.ToInt32(thtextBox11.Text.Trim());
            }
          
            model.SL = Convert.ToInt32(hjsltextBox.Text.Trim());
            model.DCSLBS = Convert.ToInt32(bstextBox.Text.Trim());
            model.DCSLMBSL = Convert.ToInt32(mbsltextBox.Text.Trim());
            int ws = 0;
            if (!string.IsNullOrEmpty(wstextBox.Text.Trim()))
            {
                ws = Convert.ToInt32(wstextBox.Text.Trim());
            }
            model.DCSLYS = ws;
            //model.PFDH = pfdtextBox12.Text.Trim();
            //model.PLDH = pldhtextBox13.Text.Trim();
            model.KSTIME = dateTimePicker1.Text.Trim();
            model.JSTIME = dateTimePicker2.Text.Trim();
            model.REMARK = bztextBox16.Text.Trim();
            model.MAC = DeviceInfo.GetNetCardMAC().Substring(0, 17);
            //if (!Convert.ToString(kcddcomboBox.SelectedValue).Equals("0"))
            //{
            //    model.KCDD = Convert.ToString(kcddcomboBox.SelectedValue);
            //    model.KCDDNAME = kcddcomboBox.Text.Trim();
            //}
           
            model.TMCOUNT = 1;
            model.TMSX = Convert.ToInt32(tmsxcomboBox.SelectedValue);
            model1.MES_TM_TMINFO = model;
            List<MES_TM_GL> gl = new List<MES_TM_GL>();
            model1.MES_TM_GL = gl.ToArray();
            MES_TM_TMINFO_INSERT_RETURN res = ServicModel.TM_TMINFO.INSERT(model1,0, getToken());
            if (res.MES_RETURN.TYPE.Equals("S"))
            {
                Print_Type ptype = (Print_Type)Convert.ToInt32(tmsxcomboBox.SelectedValue);

                switch (ptype)
                {
                    case Print_Type.none:
                        break;
                    case Print_Type.rk:
                        RigthType = Rigth_Type.gangketl_cc;
                        break;
                    case Print_Type.lot:
                        RigthType = Rigth_Type.sgsm;
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
                    case Print_Type.zhdc:
                        RigthType = Rigth_Type.sgsm;
                        ptype = Print_Type.lot;
                        break;
                    default:
                        break;
                }
                PrintInfoByTM(res.MES_RETURN.TM,res.MES_RETURN.GC ,Convert.ToInt32(fsnumericUpDown1.Value), RigthType, ptype);
            }
            else
            {
                ShowMeg(res.MES_RETURN.MESSAGE);
            }
        }

        private void gzzxcomboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            object obj = cb.SelectedValue;
            if (obj is string)
            {
                MES_SY_GZZX_SBH model = new MES_SY_GZZX_SBH();
                model.GZZXBH = Convert.ToString(gzzxcomboBox.SelectedValue);
                model.GC = Convert.ToString(MES_SY_MATERIAL_LIST.GC);
                //model.WLLB = Gzzxlb;
                //model.WLLBNAME = Wllb;

                MES_SY_GZZX_SBH[] list = ServicModel.SY_GZZX_SBH.SELECT(model, getToken());
                List<MES_SY_GZZX_SBH> sbhlist = list.ToList();
                MES_SY_GZZX_SBH model1 = new MES_SY_GZZX_SBH();
                model1.SBBH = "0";
                model1.SBMS = q(Msg_Type.titlechoice);//"==请选择==";
                sbhlist.Insert(0, model1);
                sbhcomboBox3.DataSource = sbhlist;
                sbhcomboBox3.ValueMember = "SBBH";
                sbhcomboBox3.DisplayMember = "SBMS";
                if (sbhlist.Count == 2)
                {
                    sbhcomboBox3.SelectedValue = sbhlist[1].SBBH;
                }
              
                if (!Convert.ToString(gzzxcomboBox.SelectedValue).Equals("0"))
                {
                    MES_SY_MATERIAL_BZCOUNT bzInfo = new MES_SY_MATERIAL_BZCOUNT();
                    bzInfo.GC = MES_SY_MATERIAL_LIST.GC;
                    bzInfo.WLH = MES_SY_MATERIAL_LIST.WLH;
                    bzInfo.GZZXBH = Convert.ToString(gzzxcomboBox.SelectedValue);
                    MES_SY_MATERIAL_BZCOUNT_SELECT res = ServicModel.SY_MATERIAL_BZCOUNT.SELECT(bzInfo, getToken());
                    if (res.MES_RETURN.TYPE.Equals("S"))
                    {
                        if (res.MES_SY_MATERIAL_BZCOUNT.Length == 1)
                        {
                            bstextBox.Text = res.MES_SY_MATERIAL_BZCOUNT[0].BZBS.ToString();
                            mbsltextBox.Text = res.MES_SY_MATERIAL_BZCOUNT[0].BZCOUNT.ToString();
                        }
                        else
                        {
                            bstextBox.Clear();
                            mbsltextBox.Clear();
                        }
                      
                    }
                    else
                    {
                        ShowMeg(res.MES_RETURN.MESSAGE);
                    }
                }
              

            }
        }

        private void scrqtextBox6_Click(object sender, EventArgs e)
        {
            //monthCalendar1.Visible = true;
        }

        //private void jssjtextBox15_Click(object sender, EventArgs e)
        //{
        //    monthCalendar3.Visible = true;
        //}

        //private void kssjtextBox14_Click(object sender, EventArgs e)
        //{
        //    monthCalendar2.Visible = true;
        //}

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            //scrqtextBox6.Text = Convert.ToDateTime(monthCalendar1.SelectionStart.ToShortDateString()).ToString("yyyy-MM-dd");//monthCalendar1.SelectionStart.ToShortDateString("yyyy-MM-dd");
            //monthCalendar1.Visible = false;
            
           
        }

        //private void monthCalendar2_DateSelected(object sender, DateRangeEventArgs e)
        //{
        //    kssjtextBox14.Text = Convert.ToDateTime(monthCalendar2.SelectionStart.ToShortDateString()).ToString("yyyy-MM-dd");
        //    monthCalendar2.Visible = false;
        //}

        //private void monthCalendar3_DateSelected(object sender, DateRangeEventArgs e)
        //{
        //    jssjtextBox15.Text = Convert.ToDateTime(monthCalendar2.SelectionStart.ToShortDateString()).ToString("yyyy-MM-dd");
        //    monthCalendar3.Visible = false;
        //}

        private void thtextBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            judge.isNum(thtextBox11,e);
        }

        private void tmsxcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateSelected_1(object sender, DateRangeEventArgs e)
        {
            //scrqtextBox6.Text = Convert.ToDateTime(monthCalendar1.SelectionStart.ToShortDateString()).ToString("yyyy-MM-dd");//monthCalendar1.SelectionStart.ToShortDateString("yyyy-MM-dd");
            //monthCalendar1.Visible = false;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            judge.isNum(hjsltextBox,e);
        }

        private void sbmhtextBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void frmSGSMsub_Load(object sender, EventArgs e)
        {

        }
        public void calculator()
        {
            try
            {
                long res = 0;
                if (!string.IsNullOrEmpty(bstextBox.Text.Trim()) && !string.IsNullOrEmpty(mbsltextBox.Text.Trim()))
                {
                    res = Convert.ToInt64(bstextBox.Text.Trim()) * Convert.ToInt64(mbsltextBox.Text.Trim());
                }
                if (!string.IsNullOrEmpty(wstextBox.Text.Trim()))
                {
                    res += Convert.ToInt64(wstextBox.Text.Trim());
                }
                hjsltextBox.Text = res.ToString();
            }
            catch (Exception e)
            {
                ShowMeg(e.Message);
            }

        }

        private void bstextBox_TextChanged(object sender, EventArgs e)
        {
            calculator();
        }

        private void mbsltextBox_TextChanged(object sender, EventArgs e)
        {
            calculator();
        }

        private void wstextBox_TextChanged(object sender, EventArgs e)
        {
            calculator();
        }

        private void bstextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            judge.isNum(bstextBox, e);
        }

        private void mbsltextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            judge.isNum(mbsltextBox, e);
        }

        private void wstextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            judge.isNum(wstextBox, e);
        }

        private void bstextBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (Convert.ToInt32(bstextBox.Tag) == 0)
            {
                bstextBox.SelectAll();
                bstextBox.Tag = 1;
            }
        }

        private void bstextBox_Leave(object sender, EventArgs e)
        {
            bstextBox.Tag = 0;
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

            dateTimePicker1.Text = Convert.ToDateTime(dateTimePicker3.Text).ToString("yyyy-MM-dd HH:mm");
            dateTimePicker2.Text = Convert.ToDateTime(dateTimePicker3.Text).ToString("yyyy-MM-dd HH:mm");
        }

        private void dateTimePicker3_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void dateTimePicker3_KeyUp(object sender, KeyEventArgs e)
        {
           
        }

    }
}
