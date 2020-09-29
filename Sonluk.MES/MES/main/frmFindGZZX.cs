using Sonluk.MES.MES.Base;
using Sonluk.UI.Model.MES.MES_LoginService;
using Sonluk.UI.Model.MES.SY_GCService;
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
    public partial class frmFindGZZX : basefrm
    {
        public frmFindGZZX()
        {
            InitializeComponent();
        }
        int _gzzxlb;

        public int Gzzxlb
        {
            get { return _gzzxlb; }
            set { _gzzxlb = value; }
        }
        string _wllb;

        public string Wllb
        {
            get { return _wllb; }
            set { _wllb = value; }
        }
        public frmFindGZZX(string BT,Rigth_Type type)
        {
            InitializeComponent();           
            grouplabel.Text = BT;          
            RigthType = type;
            if (RigthType == Rigth_Type.zhujizhengjitl)
            {
                gzzxcomboBox.Visible = false;
                label2.Visible = false;
            }
            Gzzxlb = 0;
            Wllb = GetWLLBName(RigthType);            
            MES_SY_GC gcmodel = new MES_SY_GC();
            gcmodel.STAFFID = Convert.ToInt32(getUserInfo("staffid"));
            MES_SY_GC[] gcList = ServicModel.SY_GC.SELECT_BY_ROLE(gcmodel, getToken());
            for (int i = 0; i < gcList.Length; i++)
            {
                gcList[i].GCMS = gcList[i].GC + "-" + gcList[i].GCMS;
            }
            gccomboBox.DisplayMember = "GCMS";
            gccomboBox.ValueMember = "GC";
            gccomboBox.DataSource = gcList;
            button1.Select();
        }
        public delegate void GetSBHinfo(MES_SY_GZZX_SBH[] list, string gzzxtext,Form form,Rigth_Type type);
        public GetSBHinfo getSBHinfo;
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(gzzxcomboBox.Text))
            {
                //MessageBox.Show("工作中心不能为空！！！", "消息框");
                ShowMeg(q(Msg_Type.msggzzxnoempty));
                return;
            }
            if (string.IsNullOrEmpty(gccomboBox.Text))
            {
                 //MessageBox.Show("工厂不能为空！！！", "消息框");
                ShowMeg(q(Msg_Type.msggcnoempty));
                return;
            }

            MES_SY_GZZX_SBH model = new MES_SY_GZZX_SBH();
            if (RigthType != Rigth_Type.zhujizhengjitl)
            {
                model.GZZXBH = Convert.ToString(gzzxcomboBox.SelectedValue);
            }            
            model.GC = Convert.ToString(gccomboBox.SelectedValue);        
            model.WLLBNAME = Wllb;            
            MES_SY_GZZX_SBH[] list = ServicModel.SY_GZZX_SBH.SELECT(model, getToken());
            if (list.Length == 0)
            {
                //MessageBox.Show("没有找到工厂是" + gccomboBox.Text + "工作中心是" + gzzxcomboBox.Text + "对应的设备号");
                ShowMeg(string.Format(q(Msg_Type.msgnosbh), gccomboBox.Text, gzzxcomboBox.Text));
                return;
            }
            else
            {
                if (gzzxcomboBox.Visible)
                {
                    ini.IniWriteValue(ini.Section_UserInfo, "gzzxvalue", Convert.ToString(gzzxcomboBox.SelectedValue));
                    ini.IniWriteValue(ini.Section_UserInfo, "gzzxtext", gzzxcomboBox.Text.Trim());
                }
                
                ini.IniWriteValue(ini.Section_GC, "value", Convert.ToString(gccomboBox.SelectedValue));
                ini.IniWriteValue(ini.Section_GC, "text", Convert.ToString(gccomboBox.Text.Trim()));
                //frmFindSBH form = new frmFindSBH(list, gzzxcomboBox.Text);
                //push(form);
                if (getSBHinfo != null)
                {
                    if (gzzxcomboBox.Visible)
                    {
                        getSBHinfo(list, Convert.ToString(gzzxcomboBox.SelectedValue), this, RigthType);
                    }
                    else
                    {
                        getSBHinfo(list, "", this, RigthType);
                    }
                   
                    //this.Close();
                }
            }
            

        }

        private void gzzxcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void gccomboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            
            
            ComboBox cb = (ComboBox)sender;
            object obj = cb.SelectedValue;
            if (obj is string)
            {
                MES_SY_GZZX gzzxmodel = new MES_SY_GZZX();
                gzzxmodel.GC = Convert.ToString(obj);
                gzzxmodel.STAFFID = Convert.ToInt32(getUserInfo("staffid"));
                gzzxmodel.WLLBNAME = Wllb;
                MES_SY_GZZX[] list = ServicModel.SY_GZZX.SELECT_BY_ROLE(gzzxmodel, getToken());
                gzzxcomboBox.SelectedValue = "";
                gzzxcomboBox.SelectedText = "";
                for (int i = 0; i < list.Length; i++)
                {
                    list[i].GZZXMS = list[i].GZZXBH + "-" + list[i].GZZXMS;
                }
                gzzxcomboBox.DataSource = list;
                gzzxcomboBox.ValueMember = "GZZXBH";
                gzzxcomboBox.DisplayMember = "GZZXMS";
            }
           
        }

        private void fhbutton_Click(object sender, EventArgs e)
        {           
        }

        private void frmFindGZZX_Load(object sender, EventArgs e)
        {

        }
    }
}
