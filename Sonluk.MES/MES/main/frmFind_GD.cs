using Sonluk.MES.MES.Base;
using Sonluk.MES.MES.model;
using Sonluk.UI.Model.MES.PD_SCRWService;
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
    public partial class frmFind_GD : basefrm
    {
        public frmFind_GD()
        {
            InitializeComponent();
        }
        public frmFind_GD(string BT,Rigth_Type rtype)
        {
            InitializeComponent();
            #region UI
             RigthType = rtype;
             this.GCtextBox.Location = new System.Drawing.Point(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width / 2, 245);
             this.GCtextBox.Text = getGC("text");
             this.GZZXcomboBox.Location = new System.Drawing.Point(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width / 2, 300);
             this.SBcomboBox.Location = new System.Drawing.Point(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width / 2, 355);
             this.label1.Location = new System.Drawing.Point(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width / 2 - 150, 250);
             this.label2.Location = new System.Drawing.Point(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width / 2 - 150, 305);
             this.label3.Location = new System.Drawing.Point(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width / 2 - 150, 360);
             this.button1.Location = new System.Drawing.Point(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width / 2 - 75, 430);

             //
             //BTlabel.Text = BT;
             factory.configLabel(BTlabel, new Size(rect.Width - 20, 40), new Point(10, 94),new Font(q(Msg_Type.fonttype),25), BT);
             BTlabel.TextAlign = ContentAlignment.MiddleCenter;
             MES_SY_GZZX gzzxmodel = new MES_SY_GZZX();
             gzzxmodel.GC = Convert.ToString(getGC("value"));
             string staff = getUserInfo("staffid");
             if (string.IsNullOrEmpty(staff) == false)
             {
                 gzzxmodel.STAFFID = Convert.ToInt32(staff);
             }
             else
             {
                 MessageBox.Show("得不到对应的人员信息！！！", "消息框");
             }
             MES_SY_GZZX[] list = ServicModel.SY_GZZX.SELECT_BY_ROLE(gzzxmodel, getToken());
             for (int i = 0; i < list.Length; i++)
             {
                 list[i].GZZXBH = list[i].GZZXBH + "-" + list[i].GZZXMS;
             }
             GZZXcomboBox.DataSource = list;
             GZZXcomboBox.ValueMember = "ID";
             GZZXcomboBox.DisplayMember = "GZZXBH";
            #endregion
        }

        private void GCcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            object obj = cb.SelectedValue;
            MES_SY_GZZX model = new MES_SY_GZZX();
            if (obj is string)
            {
                model.GC = Convert.ToString(obj);
                GZZXcomboBox.SelectedValue = "";
                GZZXcomboBox.SelectedText = "";
                SBcomboBox.SelectedValue = "";
                SBcomboBox.SelectedText = "";
                
            }
            MES_SY_GZZX[] list = ServicModel.SY_GZZX.SELECT(model, getToken());
            for (int i = 0; i < list.Length; i++)
            {
                list[i].GZZXBH = list[i].GZZXBH + "-" + list[i].GZZXMS;
            }
            GZZXcomboBox.DataSource = list;
            GZZXcomboBox.ValueMember = "ID";
            GZZXcomboBox.DisplayMember = "GZZXBH";
        }

        private void GZZXcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            object obj = cb.SelectedValue;
            MES_SY_GZZX_SBH model = new MES_SY_GZZX_SBH();
            if (obj is string)
            {
                model.GZZXBH = Convert.ToString(obj);
                SBcomboBox.SelectedValue = "";
                SBcomboBox.SelectedText = "";               
            }
            model.GC = getGC("value");
            MES_SY_GZZX_SBH[] list = ServicModel.SY_GZZX_SBH.SELECT(model, getToken());
            SBcomboBox.DataSource = list;
            SBcomboBox.ValueMember = "ID";
            SBcomboBox.DisplayMember = "SBMS";
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (string.IsNullOrEmpty(GZZXcomboBox.Text))
            {
                MessageBox.Show("工作中心不能为空！！！", "消息框");
                return;
            }
            if (string.IsNullOrEmpty(SBcomboBox.Text))
            {
                MessageBox.Show("设备号不能为空！！！", "消息框");
                return;
            }
            MES_PD_SCRW model = new MES_PD_SCRW();
            model.SBBH = Convert.ToString(SBcomboBox.SelectedValue);
            SBHID = model.SBBH;
            SELECT_MES_PD_SCRW Smodel = ServicModel.PD_SCRW.SELECT(model, getToken());
            if (Smodel.MES_RETURN.TYPE == "E")
            {
                MessageBox.Show(Smodel.MES_RETURN.MESSAGE, "消息框");
                return;
            }

            if (Smodel.MES_PD_SCRW_LIST.Length == 0)
            {
                MessageBox.Show("找不到工作中心是" + GZZXcomboBox.Text + "设备号是" + SBcomboBox.Text + "对应的派单任务！！！", "消息框");
                return;
            }
            else if (Smodel.MES_PD_SCRW_LIST.Length ==1)
            {
                frmTL2_1 form = new frmTL2_1(Smodel.MES_PD_SCRW_LIST[0], model.SBBH, RigthType);
                push(form,this);
            }
            else if (Smodel.MES_PD_SCRW_LIST.Length > 1)
            {
                frmChange_GD form = new frmChange_GD(Smodel.MES_PD_SCRW_LIST,model.SBBH,RigthType);
                show(form);
                this.Close();
            }
        }

       
    }
}
