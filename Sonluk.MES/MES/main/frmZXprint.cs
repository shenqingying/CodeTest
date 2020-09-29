using Sonluk.MES.MES.Base;
using Sonluk.UI.Model.MES.PD_SCRWService;
using Sonluk.UI.Model.MES.SY_MATERIALService;
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
    public partial class frmZXprint : basefrm
    {
        MES_PD_SCRW_LIST _MES_PD_SCRW_LIST;
        

        public MES_PD_SCRW_LIST MES_PD_SCRW_LIST
        {
            get { return _MES_PD_SCRW_LIST; }
            set { _MES_PD_SCRW_LIST = value; }
        }
        bool _isLR61scx;

        public bool IsLR61scx
        {
            get { return _isLR61scx; }
            set { _isLR61scx = value; }
        }
        public frmZXprint()
        {
            InitializeComponent();
        }
        private const string ZZWLGROUP = "30000006";
        public frmZXprint(MES_PD_SCRW_LIST list,string scrq)
        {
            
            InitializeComponent();
            IsLR61scx = false;
            
            MES_SY_MATERIAL mmRequest = new MES_SY_MATERIAL();
            mmRequest.WLH = list.WLH;
            if (list.WLGROUP != null)
            {
                IsLR61scx = list.WLGROUP.Equals(ZZWLGROUP) ? true : false;
            }           
            if (!IsLR61scx)
            {
                sdxtlabel17.Visible = false;
                sdxtcombobox.Visible = false;
                dyzslabel7.Location = pclabel6.Location;
                fsnumericUpDown.Location = pctextBox.Location;
                pclabel6.Location = sdxtlabel17.Location;
                pctextBox.Location = sdxtcombobox.Location;
               
              
            }
            mbsltextBox.Text = list.BZCOUNT == 0 ? "" : Convert.ToString(list.BZCOUNT);      
            
            pctextBox.Text = list.PC;
            cpztcomboBox.DataSource = GetDictionaryMX(9).ToList();
            cpztcomboBox.DisplayMember = "MXNAME";
            cpztcomboBox.ValueMember = "ID";
            MES_PD_SCRW_LIST = list;
            zhtextBox.Text = list.TH.ToString();
            scrqtextBox.Text = scrq;
            bstextBox.Text = list.BZBS == 0?"":list.BZBS.ToString();
            wlxxtextBox.Text = list.WLH + "/" + list.WLMS;
            dcxhtextBox.Text = list.DCXHNAME;
            dcdjtextBox.Text = list.DCDJNAME;
            hjsltextBox.Text = list.BZCOUNT * list.BZBS == 0 ? "" : (list.BZCOUNT * list.BZBS).ToString();
            MES_PD_SCRW_CCTH res = ServicModel.PD_SCRW.SELECT_ZXCCINFO(list.RWBH,0, getToken());
            if (res.MES_RETURN.TYPE.Equals("S"))
            {
                zhtextBox.Text = res.TH.ToString();
                kssjdateTimePicker.Text = Convert.ToDateTime(res.KSTIME).ToString("yyyy-MM-dd HH:mm:ss");
                jssjdateTimePicker.Text = Convert.ToDateTime(res.JSTIME).ToString("yyyy-MM-dd HH:mm:ss");
                //kssjtextBox.Text = res.KSTIME;
                //jssjtextBox.Text = res.JSTIME;
                
            }
            else
            {
                ShowMeg(res.MES_RETURN.MESSAGE);
            }
            List<MES_SY_TYPEMXLIST> zfsdlist = GetDictionaryMX(17).ToList();
            MES_SY_TYPEMXLIST zfsdnode = new MES_SY_TYPEMXLIST();
            zfsdnode.ID = 0;
            zfsdnode.MXNAME = q(Msg_Type.titlechoice);//"==请选择==";
            zfsdlist.Insert(0, zfsdnode);
            zflbcomboBox.DataSource = zfsdlist;
            zflbcomboBox.DisplayMember = "MXNAME";
            zflbcomboBox.ValueMember = "ID";

            List<MES_SY_TYPEMXLIST> sdxtlist = GetDictionaryMX(22).ToList();
            MES_SY_TYPEMXLIST sdxtnode = new MES_SY_TYPEMXLIST();
            sdxtnode.ID = 0;
            sdxtnode.MXNAME = q(Msg_Type.titlechoice);//"==请选择==";
            sdxtlist.Insert(0, sdxtnode);
            sdxtcombobox.DataSource = sdxtlist;
            sdxtcombobox.DisplayMember = "MXNAME";
            sdxtcombobox.ValueMember = "ID";
            if (list.GC == BranchGC)
            {
                bzrichTextBox.Text = "\n\n"+ZXVerifyStr+"";
            }
        }
        public delegate void Block(string rwbh);
        public Block block;
        private void dybutton_Click(object sender, EventArgs e)
        {
            #region verify
            if (string.IsNullOrEmpty(zhtextBox.Text.Trim()))
            {
                ShowMeg(q(Msg_Type.msgzhnoempty));//"幢号信息不能为空");
                return;
            }
            if (string.IsNullOrEmpty(kssjdateTimePicker.Text.Trim()))
            {
                ShowMeg(q(Msg_Type.msgslkssjnoempty));//"开始时间不能为空");
                return;
            }
            if (judge.IsDate(jssjdateTimePicker.Text.Trim()) == false)
            {
                //ShowMeg("开始时间不能正确的时间格式");
                ShowMeg(q(Msg_Type.msgkssjformat));
                return;
            }
            if (string.IsNullOrEmpty(jssjdateTimePicker.Text.Trim()))
            {
                ShowMeg(q(Msg_Type.msgjssjnoempty));//"结束时间不能为空");
                return;
            }
            if (judge.IsDate(jssjdateTimePicker.Text.Trim()) == false)
            {
                ShowMeg(q(Msg_Type.msgjssjformat));
                return;
            }
            TimeSpan midtine = DateTime.Parse(jssjdateTimePicker.Text.Trim()) - DateTime.Parse(kssjdateTimePicker.Text.Trim());
            if (midtine.TotalMinutes < 0)
            {
                ShowMeg(q(Msg_Type.msgksgtjs));
                return;
            }
            else if (midtine.TotalMinutes == 0)
            {
                ShowMeg(q(Msg_Type.msgkssjnqjssj));//"开始时间不能等于结束时间"
                return;
            }
          

            if (Convert.ToInt32(fsnumericUpDown.Value) <= 0)
            {
                ShowMeg(q(Msg_Type.msgprintnoempty));//"打印张数必须大于0");
                return;
            }
            if (string.IsNullOrEmpty(pctextBox.Text.Trim()))
            {
                ShowMeg(q(Msg_Type.msgpcnoempty));//"批次信息不能为空");
                return;
            }
            if (pctextBox.Text.Trim().Length > 10)
            {
                ShowMeg(q(Msg_Type.msgpclengthten));//"批次信息不能超过10位");
                return;
            }
            if (string.IsNullOrEmpty(bstextBox.Text.Trim()))
            {
                ShowMeg(q(Msg_Type.msgbsnoempty));//"板数信息不能为空");
                return;

            }
            if (string.IsNullOrEmpty(mbsltextBox.Text.Trim()))
            {
                ShowMeg(q(Msg_Type.msgmbslnoempty));//"每板数量不能为空");
                return;
            }

            if (MES_PD_SCRW_LIST.GC == BranchGC)
            {
                if (!bzrichTextBox.Text.Contains(ZXVerifyStr))
                {
                    ShowMeg("工厂" + MES_PD_SCRW_LIST.GC   + "必须有\""+ZXVerifyStr+"\"信息");
                    return;
                }
                else
                {
                   //int index = bzrichTextBox.Text.IndexOf(ZXVerifyStr) + 4;
                   //if (bzrichTextBox.Text.Length == index)
                   //{
                   //    ShowMeg(MES_PD_SCRW_LIST.GCDYMS + "必须填写\""+ZXVerifyStr+"\" 相关信息");
                   // return;
                   //}
                }
            }
            #endregion
            int ws = 0;
            if (IsLR61scx)
            {
                if (Convert.ToString(sdxtcombobox.SelectedValue).Equals("0"))
                {
                    ShowMeg(q(Msg_Type.msglr61havesdxt));//"LR61素电必须选择素电线体"
                    return;
                }
            }
           
            if (!string.IsNullOrEmpty(wstextBox.Text.Trim()))
            {
                ws = Convert.ToInt32(wstextBox.Text.Trim());
            }
          
            MES_PD_SCRW_ZXCC_INSERT model = new MES_PD_SCRW_ZXCC_INSERT();
            if (!Convert.ToString(zflbcomboBox.SelectedValue).Equals("0"))
            {
                model.ZFDCLB = Convert.ToInt32(zflbcomboBox.SelectedValue);
            }
            model.GC = MES_PD_SCRW_LIST.GC;
            model.RWBH = MES_PD_SCRW_LIST.RWBH;
            model.TH = Convert.ToInt32(zhtextBox.Text.Trim());
            model.KSTIME = kssjdateTimePicker.Text.Trim();
            model.JSTIME = jssjdateTimePicker.Text.Trim();
            model.JLR = Convert.ToInt32(getUserInfo("staffid"));
            model.CPZT = Convert.ToInt32(cpztcomboBox.SelectedValue);
            model.PC = pctextBox.Text.Trim();
            
            model.REMARK = bzrichTextBox.Text;
            model.DCSLBS = Convert.ToInt32(bstextBox.Text.Trim());
            model.DCSLMBSL = Convert.ToInt32(mbsltextBox.Text.Trim());
            model.DCSLYS = ws;
            model.SL = Convert.ToDecimal(hjsltextBox.Text.Trim());
            model.TMSX = (int)Print_Type.zxlot;
            model.TMLB = 1;
            model.MAC = DeviceInfo.GetNetCardMAC().Substring(0, 17);           
            MES_RETURN_UI res = ServicModel.PD_SCRW.ZX_CC(model,getToken());
            if (res.TYPE.Equals("S"))
            {
                PrintInfoByTM(res.TM,res.GC, Convert.ToInt32(fsnumericUpDown.Value), RigthType, Print_Type.zxlot);              
                if (block != null)
                {
                    block(model.RWBH);
                    this.Close();
                }
            }
            else
            {
                ShowMeg(res.MESSAGE);
            }
            
            
        }

        private void zhtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            judge.isNum(zhtextBox, e);
        }

        private void pctextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            
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
        private void bstextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            judge.isNum(bstextBox, e);
        }

        private void mbsltextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            judge.isNum(bstextBox, e);
        }

        private void wstextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            judge.isNum(bstextBox, e);
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

        private void zflbcomboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            object obj = cb.SelectedValue;
            if (obj is int)
            {
                int index = Convert.ToInt32(obj);
                List<MES_SY_TYPEMXLIST> list = (List<MES_SY_TYPEMXLIST>)cpztcomboBox.DataSource;
                int hgIndex = list.FindIndex(p => p.MXNAME.Equals("合格"));
                int zfIndex = list.FindIndex(p => p.MXNAME.Equals("暂放"));
                if (index == 0)
                {
                    if (hgIndex != -1)
                    {
                        cpztcomboBox.SelectedValue = list[hgIndex].ID;
                    }
                }
                else
                {
                    if (zfIndex != -1)
                    {
                        cpztcomboBox.SelectedValue = list[zfIndex].ID;
                    }
                }
               
            }
        }

        private void sdxtcombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            object obj = cb.SelectedValue;
            if (obj is int)
            {
                int Selectindex = Convert.ToInt32(obj);
                List<MES_SY_TYPEMXLIST> list = (List<MES_SY_TYPEMXLIST>)sdxtcombobox.DataSource;
                MES_SY_TYPEMXLIST node = list.Find(p => p.ID == Selectindex);
                if (node != null && node.ID != 0)
                {
                    string foot = pctextBox.Text.Substring(6);
                    string head = pctextBox.Text.Substring(0,  6);
                     //pctextBox.Text = pctextBox.Text.Replace(0,) node.MXNAME;
                    string resfoot = foot.Substring(3, foot.Length - 3);
                    resfoot = node.MXNAME + resfoot;
                    pctextBox.Text = head + resfoot;
                   
                }

            }
        }

        private void frmZXprint_Load(object sender, EventArgs e)
        {

        }

        private void sdxtlabel17_Click(object sender, EventArgs e)
        {

        }
    }
}
