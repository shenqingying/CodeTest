using Sonluk.MES.MES.Base;
using Sonluk.UI.Model.MES.SY_PFDHService;
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
    public partial class frmZJprint : basefrm
    {
        ZSL_BCT304_CT _ZSL_BCT304_CT;

        public ZSL_BCT304_CT ZSL_BCT304_CT
        {
            get { return _ZSL_BCT304_CT; }
            set { _ZSL_BCT304_CT = value; }
        }
        public frmZJprint()
        {
            InitializeComponent();
        }
        public frmZJprint(ZSL_BCT304_CT model)
        {
            InitializeComponent();
            PrintType = Print_Type.lot;
            RigthType = Rigth_Type.zhengjicc;
            ZSL_BCT304_CT = model;
            pldhtextBox.Text = model.PLDH;
            thtextBox.Text = model.TH.ToString();
            pfdhtextBox.Text = model.PFDH;
            cpztcomboBox.DataSource = GetDictionaryMX(9);
            cpztcomboBox.DisplayMember = "MXNAME";
            cpztcomboBox.ValueMember = "ID";
        }
        public delegate void IsRefresh(bool isSuccess);
        public IsRefresh isRefresh;
        private void dybutton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(thtextBox.Text.Trim()))
            {
                ShowMeg(q(Msg_Type.msgthnoempty));//"桶号不能为空"
                return;
            }
            //if (Convert.ToInt32(thtextBox.Text.Trim()) == 0)
            //{
            //    ShowMeg("生成条码桶号不能为0");
            //    return;
            //}
            if (string.IsNullOrEmpty(fsnumericUpDown.Value.ToString()))
            {
                if (Convert.ToInt32(fsnumericUpDown.Value) == 0)
                {
                    ShowMeg(q(Msg_Type.msgprintnoempty));//"打印分数不能必须大于0"

                    return;
                }
                ShowMeg(q(Msg_Type.msgprintnoempty));//"打印分数不能为空");
                return;
            }
            ZSL_BCT304_CT.TH = Convert.ToInt32(thtextBox.Text.Trim());
            ZSL_BCT304_CT.JLR = Convert.ToInt32(getUserInfo("staffid"));
            ZSL_BCT304_CT.CPZT = Convert.ToInt32(cpztcomboBox.SelectedValue);
            if (Convert.ToInt32(thtextBox.Text.Trim()) == 0)
            {
                ZSL_BCT304_CT.REMARK = q(Msg_Type.fieldqhpld);// "切换配料单";
            }
            else
            {
                ZSL_BCT304_CT.REMARK = bzrichTextBox.Text.Trim();
            }
            
            ZSL_BCT304_CT.TMLB = 1;
            ZSL_BCT304_CT.TMSX = (int)Print_Type.zjlot;
            ZSL_BCT304_CT.WLLBNAME = "正极粉";
            ZSL_BCT304_CT.MAC = DeviceInfo.GetNetCardMAC().Substring(0, 17);
            MES_RETURN_UI res1 = ServicModel.SY_PFDH.ZJ_CC(ZSL_BCT304_CT, getToken());
            if (res1.TYPE.Equals("S"))
            {
                if (ZSL_BCT304_CT.TH == 0)
                {
                    ShowMeg(q(Msg_Type.msgqhpldsuccess), 1500);//"配料单切换成功"
                    this.Close();
                }
                else
                {
                    SELECT_MES_TM_TMINFO_PRINT res2 = ServicModel.TM_TMINFO.SELECT_BYID_CHILD(res1.GC, res1.TM, getToken());
                    List<SELECT_MES_TM_TMINFO_PRINT> nodes = new List<SELECT_MES_TM_TMINFO_PRINT>();
                    nodes.Add(res2);
                    PrintInfo(Convert.ToInt32(fsnumericUpDown.Value), res2.MES_TM_TMINFO_LIST.SL.ToString(), "", nodes.ToArray(), RigthType, Print_Type.zjlot);
                    if (isRefresh != null)
                    {
                        isRefresh(true);
                    }
                    this.Close();
                }
               
            }
            else
            {
                ShowMeg(res1.MESSAGE);
                if (isRefresh != null)
                {
                    isRefresh(false);
                }
            }
        }

        private void thtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            judge.isNum(thtextBox, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(thtextBox.Text.Trim()))
            {
                ShowMeg(q(Msg_Type.msgthnoempty));//"桶号不能为空"
                return;
            }
            if (Convert.ToInt32(thtextBox.Text.Trim()) != 0)
            {
                ShowMeg(q(Msg_Type.msgqhpldthzero));//"切换配料单桶号必须选择是0"
                return;
            }
            ZSL_BCT304_CT.TH = Convert.ToInt32(thtextBox.Text.Trim());
            ZSL_BCT304_CT.JLR = Convert.ToInt32(getUserInfo("staffid"));
            ZSL_BCT304_CT.CPZT = Convert.ToInt32(cpztcomboBox.SelectedValue);
            ZSL_BCT304_CT.REMARK = q(Msg_Type.fieldqhpld);// "切换配料单";//bzrichTextBox.Text.Trim();
            ZSL_BCT304_CT.TMLB = 1;
            ZSL_BCT304_CT.TMSX = (int)Print_Type.zjlot;
            ZSL_BCT304_CT.WLLBNAME = "正极粉";
            ZSL_BCT304_CT.MAC = DeviceInfo.GetNetCardMAC().Substring(0, 17);
            MES_RETURN_UI res1 = ServicModel.SY_PFDH.ZJ_CC(ZSL_BCT304_CT, getToken());
            if (res1.TYPE.Equals("S"))
            {
                //SELECT_MES_TM_TMINFO_PRINT res2 = ServicModel.TM_TMINFO.SELECT_BYID_CHILD(res1.GC, res1.TM, getToken());
                //List<SELECT_MES_TM_TMINFO_PRINT> nodes = new List<SELECT_MES_TM_TMINFO_PRINT>();
                //nodes.Add(res2);               
                //if (isRefresh != null)
                //{
                //    isRefresh(true);
                //}
                //this.Close();
                ShowMeg(q(Msg_Type.msgqhpldsuccess), 1500);//"配料号切换成功"
            }
            else
            {
                ShowMeg(res1.MESSAGE);
                //if (isRefresh != null)
                //{
                //    isRefresh(false);
                //}
            }



        }
    }
}
