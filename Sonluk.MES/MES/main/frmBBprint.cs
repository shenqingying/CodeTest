using Sonluk.MES.MES.Base;
using Sonluk.UI.Model.MES.PD_SCRWService;
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
    public partial class frmBBprint : basefrm
    {
        
        public frmBBprint()
        {
            InitializeComponent();
        }
        public frmBBprint(MES_TM_TMINFO_INSERT_GL model, Print_Type ptype, Rigth_Type rtype,MES_PD_SCRW_LIST list)
        {
            InitializeComponent();
            RigthType = rtype;
            PrintType = ptype;
            MES_PD_SCRW scrwmodel = new MES_PD_SCRW();
            scrwmodel.RWBH = list.RWBH;
            SELECT_MES_PD_SCRW res = ServicModel.PD_SCRW.SELECT(scrwmodel, getToken());
            if (res.MES_PD_SCRW_LIST.Length == 0)
            {
                ShowMeg(q(Msg_Type.msgrwdempty));
                return;
            }
            list = res.MES_PD_SCRW_LIST[0];
            if (list == null)
            {
                ShowMeg(q(Msg_Type.msgrwdempty));
                return;
            }
            
            MES_TM_TMINFO_INSERT_GL = model;
            wlxxtextBox.Text = list.WLH + "/" + list.WLMS;

            if (!string.IsNullOrEmpty(list.XSNOBILL))
            {
               
                if (!string.IsNullOrEmpty(list.PC))
                {
                    wlsxtextBox.Text = list.XSNOBILL + "-" + list.XSNOBILLMX + "/" + list.PC;
                }
                else
                {
                    wlsxtextBox.Text = list.XSNOBILL + "-" + list.XSNOBILLMX;
                }

            }
            else
            {
                if (!string.IsNullOrEmpty(list.PC))
                {
                    wlsxtextBox.Text = list.PC;
                }
            }           
            dcxhtextBox.Text = list.DCXHNAME;
            dcdjtextBox.Text = list.DCDJNAME;
            mbsltextBox.Text = Convert.ToString(list.MPSL);
            bbpmtextBox.Text = list.RQM;

            //if (judge.IsNumber(list.XSNOBILL) == false && !string.IsNullOrEmpty(list.XSNOBILL))
            //{
            //    bzrichTextBox.Text = list.XSNOBILL + "-" + list.XSNOBILLMX;
            //}



            cpztcomboBox.DataSource = GetDictionaryMX(9);
            cpztcomboBox.DisplayMember = "MXNAME";
            cpztcomboBox.ValueMember = "ID";            
            zhtextBox.Text = Convert.ToString(ServicModel.PD_SCRW.SELECT_TH_BY_GDDH_SBBH(list.RWBH, getToken()).TH);
            List<MES_SY_TYPEMXLIST> sbcdlist = GetDictionaryMX(15).ToList();
            MES_SY_TYPEMXLIST choicllist = new MES_SY_TYPEMXLIST();
            choicllist.ID = 0;
            choicllist.MXNAME = q(Msg_Type.titlechoice);
            sbcdlist.Insert(0, choicllist);
            sbcdcomboBox.DataSource = sbcdlist;
            sbcdcomboBox.DisplayMember = "MXNAME";
            sbcdcomboBox.ValueMember = "ID";
            List<MES_SY_TYPEMXLIST> hdgxlist = GetDictionaryMX(19).ToList();
            hdgxlist.Insert(0, choicllist);
            hdgxcomboBox.DisplayMember = "MXNAME";
            hdgxcomboBox.ValueMember = "ID";
            hdgxcomboBox.DataSource = hdgxlist;
            hdgxcomboBox.SelectedValue = list.XDGX;
        }
        public delegate void Block ();
        public Block block;
        private void dybutton_Click(object sender, EventArgs e)
        {
           
            if (string.IsNullOrEmpty(bstextBox.Text.Trim()))
            {
                if (string.IsNullOrEmpty(wstextBox.Text.Trim()))
                {
                    ShowMeg(q(Msg_Type.msgbsnoempty));
                    return;
                }                                
            }
            if (Convert.ToInt32(hdgxcomboBox.SelectedValue) == 0)
            {
                 ShowMeg(q(Msg_Type.msgxdnoempty));
                 return;
            }          
            if (string.IsNullOrEmpty(mbsltextBox.Text.Trim()))
            {
                ShowMeg(q(Msg_Type.msgmbslnoempty));
                return;
            }
            
            if (Convert.ToInt32(sbcdcomboBox.SelectedValue) == 384)
            {
                 ShowMeg(q(Msg_Type.msgsbcdnoempty));
                return;
            }
            //if (string.IsNullOrEmpty(bbpmtextBox.Text.Trim()))
            //{
            //    ShowMeg("包标喷码不能为空");
            //    return;
            //}
            if (fsnumericUpDown.Value <= 0)
            {
                ShowMeg(q(Msg_Type.msgprintnoempty));
                return;
            }
            if (string.IsNullOrEmpty(bbpmtextBox.Text.Trim()))
            {
                ShowMeg(q(Msg_Type.msgbbpmnoempty));
                return;
            }
            int ws = 0;
            if (!string.IsNullOrEmpty(wstextBox.Text.Trim()))
            {
                ws += Convert.ToInt32(wstextBox.Text.Trim());

            }
            if (!string.IsNullOrEmpty(ypdctextBox.Text.Trim()))
            {
                ws += Convert.ToInt32(ypdctextBox.Text.Trim());
            }
            string remark = "";
            if (!string.IsNullOrEmpty(ypdctextBox.Text.Trim()))
            {
                remark += "[" + q(Msg_Type.titleyps) + ypdctextBox.Text.Trim() + "] " + bzrichTextBox.Text.Trim();
            }
            else
            {
                remark = bzrichTextBox.Text.Trim();
            }
            MES_TM_TMINFO_INSERT_GL.MES_TM_TMINFO.TH = Convert.ToInt32(zhtextBox.Text.Trim());
            MES_TM_TMINFO_INSERT_GL.MES_TM_TMINFO.CPZT = Convert.ToInt32(cpztcomboBox.SelectedValue);

            MES_TM_TMINFO_INSERT_GL.MES_TM_TMINFO.REMARK = remark;
            if (Convert.ToInt32(sbcdcomboBox.SelectedValue) != 0)
            {
                MES_TM_TMINFO_INSERT_GL.MES_TM_TMINFO.SBCD = Convert.ToInt32(sbcdcomboBox.SelectedValue);
            }
            else
            {
                ShowMeg(q(Msg_Type.msgsbcdnoempty));
                return;
            }
            if (string.IsNullOrEmpty(bstextBox.Text.Trim()))
            {
                MES_TM_TMINFO_INSERT_GL.MES_TM_TMINFO.DCSLBS = 0;
            }
            else
            {
                MES_TM_TMINFO_INSERT_GL.MES_TM_TMINFO.DCSLBS = Convert.ToInt32(bstextBox.Text.Trim());
            }
            MES_TM_TMINFO_INSERT_GL.MES_TM_TMINFO.XDGX = Convert.ToInt32(hdgxcomboBox.SelectedValue);
            MES_TM_TMINFO_INSERT_GL.MES_TM_TMINFO.DCSLMBSL = Convert.ToInt32(mbsltextBox.Text.Trim());
            MES_TM_TMINFO_INSERT_GL.MES_TM_TMINFO.DCSLYS = ws;
            MES_TM_TMINFO_INSERT_GL.MES_TM_TMINFO.SL = Convert.ToDecimal(hjsltextBox.Text.Trim());
            MES_TM_TMINFO_INSERT_GL.MES_TM_TMINFO.RQM = bbpmtextBox.Text.Trim();
            MES_TM_TMINFO_INSERT_GL.MES_TM_TMINFO.TMCOUNT = 1;
            MES_TM_TMINFO_INSERT_GL.MES_TM_TMINFO.TMSX = (int)Print_Type.bblot;
            MES_TM_TMINFO_INSERT_GL.MES_TM_TMINFO.TMLB = 1;
            MES_TM_TMINFO_INSERT_GL.MES_TM_TMINFO.MAC = DeviceInfo.GetNetCardMAC().Substring(0, 17);
            Sonluk.UI.Model.MES.TM_TMINFOService.MES_TM_TMINFO_INSERT_RETURN res =  ServicModel.TM_TMINFO.INSERT(MES_TM_TMINFO_INSERT_GL,0, getToken());
            if (res.MES_RETURN.TYPE.Equals("S"))
            {
                PrintInfoByTM(res.SELECT_MES_TM_TMINFO_PRINT[0].MES_TM_TMINFO_LIST.TM, MES_TM_TMINFO_INSERT_GL.MES_TM_TMINFO.GC, Convert.ToInt32(fsnumericUpDown.Value), RigthType, PrintType);
                if (block != null)
                {
                    block();
                    this.Close();
                }
                
            }
            else
            {
                ShowMeg(res.MES_RETURN.MESSAGE);
            }

        }

        private void bstextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            judge.isNum(bstextBox,e);
            
        }

        private void mbsltextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            judge.isNum(mbsltextBox, e);
          
        }

        private void wstextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            judge.isNum(wstextBox, e);
           
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
                if (!string.IsNullOrEmpty(ypdctextBox.Text.Trim()))
                {
                    res += Convert.ToInt64(ypdctextBox.Text.Trim());
                }
                hjsltextBox.Text = res.ToString();
            }
            catch (Exception e)
            {
                ShowMeg(e.Message);
                //throw new ApplicationException(e.Message);
            }
           
        }

        private void bstextBox_TextChanged(object sender, EventArgs e)
        {
            calculator();
            judge.MaxLength(bstextBox, 10);
        }

        private void mbsltextBox_TextChanged(object sender, EventArgs e)
        {
            calculator();
            judge.MaxLength(mbsltextBox, 10);
        }

        private void wstextBox_TextChanged(object sender, EventArgs e)
        {
            calculator();
            judge.MaxLength(wstextBox, 10);
        }

        private void zhtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            judge.isNum(zhtextBox, e);
        }

        private void ypdctextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            judge.isNum(ypdctextBox, e);
        }

        private void ypdctextBox_TextChanged(object sender, EventArgs e)
        {
            calculator();
        }

        private void frmBBprint_Load(object sender, EventArgs e)
        {

        }
        

    }
}
