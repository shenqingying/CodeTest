using Sonluk.MES.MES.Base;
using Sonluk.UI.Model.MES.SY_GZZX_SBHService;
using Sonluk.UI.Model.MES.SY_PFDHService;
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
    public partial class frmZJ_CC : baseview
    {
        ZBCFUN_ZJLOT_PRT _dataList;

        public ZBCFUN_ZJLOT_PRT DataList
        {
            get { return _dataList; }
            set { _dataList = value; }
        }
        MES_SY_GZZX_SBH[] _shblist;

        public MES_SY_GZZX_SBH[] Shblist
        {
            get { return _shblist; }
            set { _shblist = value; }
        }
        ZSL_BCT304_LOT[] _pldhList;

        public ZSL_BCT304_LOT[] PldhList
        {
            get { return _pldhList; }
            set { _pldhList = value; }
        }
        ZSL_BCT304_LOT _currpldh;

        public ZSL_BCT304_LOT Currpldh
        {
            get { return _currpldh; }
            set { _currpldh = value; }
        }
        string _sbbh;

        public string Sbbh
        {
            get { return _sbbh; }
            set { _sbbh = value; }
        }
        public frmZJ_CC()
        {
            InitializeComponent();
            //int margin = 15;
            //int h = 21;
            for (int i = 0; i < 20; i++)
            {
                Button btn = new Button();
                this.factory.configButton(btn, new Size(60, 60), new Point(20 + rect.Width / 12 * (i % 12), 140 + i / 12 * 75), (i + 1).ToString() + "#", (i + 1) * 10);
                //btn.Tag = (i + 1) * 10;
                //btn.UseVisualStyleBackColor = true;
                btn.Click += new System.EventHandler(this.btn_Click);
                this.Controls.Add(btn);
                if (i == 0)
                {
                    btn_Click(btn, new EventArgs());

                }
            }
        }
        public frmZJ_CC(MES_SY_GZZX_SBH[] model,Rigth_Type rtype)
        {
            InitializeComponent();
            Currpldh = new ZSL_BCT304_LOT();
            Shblist = model;
            RigthType = rtype;
            //int margin = 15;
            //int h = 21;
            for (int i = 0; i < Shblist.Length; i++)
            {
                Button btn = new Button();
                this.factory.configButton(btn, new Size(60, 60), new Point(20 + rect.Width / 12 * (i % 12), 165 + i / 12 * 75), Shblist[i].SBMS, Shblist[i].SBBH);
                //btn.Tag = (i + 1) * 10;
                //btn.UseVisualStyleBackColor = true;
                btn.Click += new System.EventHandler(this.btn_Click);
                this.Controls.Add(btn);
                if (i == Shblist.Length - 1)
                {
                    btn_Click(btn, new EventArgs());

                }
            }
            dybutton.Select();
           
        }

        private void dybutton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(pfdhtextBox.Text))
            {
                ShowMeg(q(Msg_Type.msgpfdhnoempty));//"配方单号不能为空"
                return;
            }
            if (string.IsNullOrEmpty(pldhtextBox.Text))
            {
                ShowMeg(q(Msg_Type.msgpldhnoempty));//"配料单号不能为空"
                return;
            }
            if (string.IsNullOrEmpty(Convert.ToString(scbzcomboBox.SelectedValue)))
            {
                ShowMeg(q(Msg_Type.msgscbznoempty));//"生产班组不能为空"
                return;
            }
            if (string.IsNullOrEmpty(Convert.ToString(slcomboBox.SelectedValue)))
            {
                ShowMeg(q(Msg_Type.msgslnoempty));//"数量不能为空"
                return;
            }
            if (string.IsNullOrEmpty(thtextBox.Text))
            {
                ShowMeg(q(Msg_Type.msgthnoempty));//"桶号信息不能为空"
                return;
            }
            //if (string.IsNullOrEmpty(Convert.ToString(gdcomboBox.SelectedValue)))
            //{
            //    ShowMeg("工单信息不能为空");
            //    return;
            //}
            if (string.IsNullOrEmpty(gdtextBox.Text.Trim()))
            {
                ShowMeg(q(Msg_Type.msggdnomepty));//"工单信息不能为空"
                return;
            }
            ZSL_BCT304_CT model = new ZSL_BCT304_CT();
            model.PLDH = pldhtextBox.Text;
            model.PFDH = pfdhtextBox.Text;
            model.SBBH = Sbbh;
            model.SCBZID = Convert.ToInt32(scbzcomboBox.SelectedValue);
            model.MTSLID = Convert.ToInt32(slcomboBox.SelectedValue);
            model.TH = Convert.ToInt32(thtextBox.Text.Trim());
            model.ERPNO = gdtextBox.Text.Trim();
            model.THGG = radioButton1.Checked == true ? radioButton1.Text : radioButton2.Text;
            frmZJprint form = new frmZJprint(model);
            form.isRefresh = isprintSuccess;
            show(form);
            
        }
        public void isprintSuccess(bool issuccess)
        {
            if (issuccess != false)
            {
                RefreshBypldh(Currpldh);
            }
        }
        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string sbbh = Convert.ToString(btn.Tag);
            Sbbh = sbbh;
            foreach (Control c in this.Controls)
            {
                if (c is Button)
                {
                    Button btn1 = (Button)c;
                    if (Convert.ToString(c.Tag) == sbbh)
                    {
                        btn1.BackColor = Color.Red;
                    }
                    else
                    {
                        btn1.UseVisualStyleBackColor = true;
                    }

                }


            }
            chtextBox.Text = btn.Text.Trim();
            RefreshSBH(sbbh);
          
           


        }
      
        public void Configui(ZBCFUN_ZJLOT_PRT res)
        {
            if (res.MES_RETURN.TYPE.Equals("S"))
            {
                DataList = res;
                PldhList = res.ET_PLDH;
                pfdhtextBox.Text = res.ES_LOT.PFDH;                
                thtextBox.Text = Convert.ToString(res.ES_LOT.TH);
                jrljtstextBox.Text = Convert.ToString(res.ES_LOT.TLJTS);
                //gdcomboBox.DataSource = res.ET_POLIST;
                //gdcomboBox.DisplayMember = "AUFNR";
                //gdcomboBox.ValueMember = "AUFNR";
                pfdhljtstextBox.Text = Convert.ToString(res.ES_LOT.PFLJTS);
                pldhljtstextBox.Text = Convert.ToString(res.ES_LOT.PLLJTS);
                pldhtextBox.Text = res.ES_LOT.PLDH;
               
                scbzcomboBox.DataSource = GetDictionaryMX(12);
                scbzcomboBox.DisplayMember = "MXNAME";
                scbzcomboBox.ValueMember = "ID";

                slcomboBox.DataSource = GetDictionaryMX(13);
                slcomboBox.DisplayMember = "MXNAME";
                slcomboBox.ValueMember = "ID";
                scbzcomboBox.SelectedValue = res.ES_LOT.SCBZID;
                slcomboBox.SelectedValue = res.ES_LOT.MTSLID;
                Currpldh.PLDH = pldhtextBox.Text;
                Currpldh.PFDH = pfdhtextBox.Text;
                 if (DataList.ET_POLIST.Length == 0)
                {
                    //frmZJ_Find_GD form = new frmZJ_Find_GD(DataList.ET_POLIST);
                    //show(form);
                    gdtextBox.BackColor = Color.Red;
                    gdtextBox.Clear();
                    gdwltextBox.Clear();
                }
                else if (DataList.ET_POLIST.Length == 1)
                {
                    gdtextBox.Text = DataList.ET_POLIST[0].AUFNR;
                    gdtextBox.BackColor = Color.White;
                    gdwltextBox.Text = DataList.ET_POLIST[0].MATNR + "/" + DataList.ET_POLIST[0].MAKTX;
                }
                 else if (DataList.ET_POLIST.Length > 1)
                 {
                    gdtextBox.BackColor = Color.Red;
                    gdtextBox.Clear();
                    gdwltextBox.Clear();
                 }                            
            }
            else
            {
                ShowMeg(res.MES_RETURN.MESSAGE);
            }
            
        }
      

        private void scbzbutton_Click(object sender, EventArgs e)
        {
            frmModifyMX form = new frmModifyMX(12);
            show(form);
            Configui(DataList);
        }

        private void slglbutton_Click(object sender, EventArgs e)
        {
            frmModifyMX form = new frmModifyMX(13);
            show(form);
            Configui(DataList);
        }




        private void pldhtextBox_Click(object sender, EventArgs e)
        {
            pushPL();
        }

        private void pldhtextBox_KeyDown(object sender, KeyEventArgs e)
        {
            
            pushPL();
        }
        private void gdtextBox_KeyDown(object sender, KeyEventArgs e)
        {
            pushGD();
        }
        private void gdtextBox_Click(object sender, EventArgs e)
        {
            pushGD();
        }
        public void pushGD()
        {
            if (DataList.ET_POLIST.Length > 0)
            {
                frmZJ_Find_GD form = new frmZJ_Find_GD(DataList.ET_POLIST);
                form.block = refreshGD;
                show(form);
            }
            else
            {
                ShowMeg(q(Msg_Type.msggdnone));//"没有工单请联系管理员"
                return;
            }
        }
        public void refreshGD(int row )
        {
            gdtextBox.Text = DataList.ET_POLIST[row].AUFNR;
            gdtextBox.BackColor = Color.White;
            gdwltextBox.Text = DataList.ET_POLIST[row].MATNR + "/" + DataList.ET_POLIST[row].MAKTX;
        }
        public void pushPL()
        {
            frmChangePLDH form = new frmChangePLDH(PldhList,Sbbh,pldhtextBox.Text.Trim());
            form.sendSelectRow = BlockLOTlIST;
            show(form);
        }
        public void BlockLOTlIST(ZSL_BCT304_LOT list)
        {
            Currpldh = list;
            RefreshBypldh(Currpldh);
        }
        public void RefreshBypldh(ZSL_BCT304_LOT list)
        {
           
            ZSL_BCT304_CT model = new ZSL_BCT304_CT();
            model.SBBH = Sbbh;
            model.PLDH = list.PLDH;
            model.PFDH = list.PFDH;
            ZBCFUN_ZJLOT_PRT res = ServicModel.SY_PFDH.GET_ZJINFO_BYPLDH(model, getToken());            
            Configui(res);
        }
        public void RefreshSBH(string sbh)
        {
            ZSL_BCT304_CT model = new ZSL_BCT304_CT();
            model.SBBH = sbh;
            model.WERKS = getGC("value");
            //model.ARBPL = getUserInfo("gzzxvalue");
            ZBCFUN_ZJLOT_PRT res = ServicModel.SY_PFDH.GET_ZJINFO_INIT(model, getToken());
            Configui(res);
        }

        private void frmZJ_CC_Shown(object sender, EventArgs e)
        {


        }

        private void rebutton_Click(object sender, EventArgs e)
        {
            RefreshBypldh(Currpldh);
        }

        private void rzbutton_Click(object sender, EventArgs e)
        {
            
            //string gzzx = ini.IniReadValue(ini.Section_UserInfo, "gzzxvalue");
            frmLotLog form = new frmLotLog(RigthType, getUserInfo("gzzxvalue"),"",11);
            show(form);
        }

       

       
       
    }
}
