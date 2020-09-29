using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sonluk.MES.MES.model;
using Sonluk.UI.Model.MES.SY_GCService;
using Sonluk.UI.Model.MES.SY_MACHINEINFOService;
using Sonluk.UI.Model.MES.MES_LoginService;
using Sonluk.MES.MES.Base;

namespace Sonluk.MES.MES.main
{
    public partial class frmBind_Machine : basefrm
    {
       
        public frmBind_Machine()
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(ini.IniReadValue(ini.Section_Machine, "WKINFO")))
            {
                //int macStr = DeviceInfo.GetNetCardMAC().Length;
                //string a = "12345678901234567890";
                //string macStr = a.Substring(0, 17);
                //int a1 = macStr.Length;
                MactextBox.Text = DeviceInfo.GetNetCardMAC().Substring(0,17);

              
            }
            else
            {
                MactextBox.Text = ini.IniReadValue(ini.Section_Machine, "WKINFO");
                MES_SY_MACHINEINFO model = new MES_SY_MACHINEINFO();
                model.WKINFO = ini.IniReadValue(ini.Section_Machine, "WKINFO");
                MES_SY_MACHINEINFO_SELECT res = ServicModel.SY_MACHINEINFO.SELECT(model, getToken());
                if (res.MES_RETURN.TYPE.Equals("S"))
                {
                    bztextBox.Text = res.MES_SY_MACHINEINFO[0].REMARK;
                }
                else
                {
                    //ShowMeg(res.MES_RETURN.MESSAGE);
                }
            }

           
            
        }
        public frmBind_Machine(CRM_JURISDICTION_GROUP[] grouplist)
        {
            InitializeComponent();
            //JList = grouplist;
            //MES_SY_GC[] list = ServicModel.SY_GC.read(new MES_SY_GC(), getToken());
            //GCcomboBox.DataSource = list;
            //GCcomboBox.ValueMember = "ID";
            //GCcomboBox.DisplayMember = "GC";
            //label2.Visible = false;
            //GCcomboBox.Visible = false;
            //canclebutton.Visible = false;

        }


        private void bindbutton_Click(object sender, EventArgs e)
        {
            MES_SY_MACHINEINFO model = new MES_SY_MACHINEINFO();
            //model.GC = Convert.ToString(GCcomboBox.SelectedValue);
            model.WKINFO = MactextBox.Text;
            model.ISDELETE = false;
            model.REMARK = bztextBox.Text.Trim();
            MES_SY_MACHINEINFO Resmodel = InsertDB(model);
            if (Resmodel != null)
            {
                InsertLoction(Resmodel);
                //if (MessageBox.Show("绑定成功" + "设备号是" + Resmodel.MNUMBER + ",工作站编号是" + Resmodel.MNUMBER, "消息框", MessageBoxButtons.OK) == DialogResult.OK)
                // {
                //     //frmLogin form = new frmLogin();
                //     //push(form,this);
                // }
                if (MessageBox.Show(q(Msg_Type.msgbindsuccess), q(Msg_Type.msgtitle), MessageBoxButtons.OK) == DialogResult.OK)
                {
                    //frmLogin form = new frmLogin();
                    //push(form,this);
                }
            }
            else
            {
                //MessageBox.Show("绑定失败,请联系管理员", "消息框");
                ShowMeg(q(Msg_Type.msgbindfail));
            }
        }

        private MES_SY_MACHINEINFO InsertDB(MES_SY_MACHINEINFO model)
        {
            MES_SY_MACHINEINFO resmodel = new MES_SY_MACHINEINFO();
            try
            {
                resmodel = ServicModel.SY_MACHINEINFO.insert(model, getToken());
            }
            catch (Exception e)
            {
                
                throw new ApplicationException(e.Message);
            }
            return resmodel;
        }
        private void InsertLoction(MES_SY_MACHINEINFO model)
        {
             ini.IniWriteValue(ini.Section_Machine,"ID",model.ID.ToString());
             ini.IniWriteValue(ini.Section_Machine,"MNUMBER",model.MNUMBER);
             ini.IniWriteValue(ini.Section_Machine,"WKINFO",model.WKINFO);
             ini.IniWriteValue(ini.Section_Machine,"GCID",model.GC);
        }

        private void canclebutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBind_Machine_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bztextBox_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
