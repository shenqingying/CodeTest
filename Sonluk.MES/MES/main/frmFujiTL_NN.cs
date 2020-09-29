using Sonluk.MES.MES.Base;
using Sonluk.UI.Model.MES.PD_SCRWService;
using Sonluk.UI.Model.MES.SY_GZZX_SBHService;
using Sonluk.UI.Model.MES.TM_CZRService;
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
    public partial class frmFujiTL_NN : baseview
    {
        MES_TM_CZR_SELECT_CZR_NOW _crzlist;

        public MES_TM_CZR_SELECT_CZR_NOW Crzlist
        {
            get { return _crzlist; }
            set { _crzlist = value; }
        }
        MES_PD_SCRW_LIST[] _rwlist;

        public MES_PD_SCRW_LIST[] Rwlist
        {
            get { return _rwlist; }
            set { _rwlist = value; }
        }
        List<GridVrid> _jhList;

        public List<GridVrid> JhList
        {
            get { return _jhList; }
            set { _jhList = value; }
        }

        string _sbh;

        public string Sbh
        {
            get { return _sbh; }
            set { _sbh = value; }
        }
        int _index;

        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }
        private List<int> _finish;

        public List<int> Finish
        {
            get { return _finish; }
            set { _finish = value; }
        }
   
        public frmFujiTL_NN()
        {
            InitializeComponent();
        }
        public frmFujiTL_NN(MES_PD_SCRW_LIST[] model, string sbh, string sbhID)
        {
            InitializeComponent();
            //string[] cols = {  "桶号", "配方号", "配料单号", "锌粉产地", "锌粉批号","完成状态"};
            //string[] colss = { "Th", "Pfdh", "Pldh", "Xfcd", "Xfpc","status"};
            //string[] vcol = { };
            //string[] vcols = { "物料类别代码", "条码代码", "工厂" };
            SBHID = sbhID;
            //DataGridBuild(cols, colss, jldataGridView, vcols);

            ConfigData(model,sbh);
            


        }
        
        public void ConfigData(MES_PD_SCRW_LIST[] model, string sbh)
        {
            Finish = new List<int>();
            Sbh = sbh;
            SBlabel4.Text = sbh;
            //sbhtextBox.Text = sbh;
            JhList = new List<GridVrid>();
            //scrqtextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            Rwlist = model;
            //monthCalendar1.BringToFront();
            //monthCalendar1.Visible = false;
            Rwlist = model;
            int lenght = 0;
            for (int i = 0; i < model.Length; i++)
            {
                if (model[i].ISACTION == 0)
                {
                    Index = i;
                    break;
                }
                else
                {
                    lenght++;
                }
            }
           
            if (lenght == model.Length && Index == 0)
            {
                SMtextBox.ReadOnly = true;
            }
            else
            {
                SMtextBox.Select();
                SetCurrentTL(model[Index]);
                SMtextBox.ReadOnly = false;
            }
            

            qrtlbutton.Enabled = false;
            gzzxtextBox.Text = model[Index].GZZXBH + "-" + model[Index].GZZXNAME;
            gctextBox.Text = model[Index].GC;

            configDatagrid();

            //MES_TM_CZR czr_model = new MES_TM_CZR();
            //czr_model.SBBH = Rwlist[Index].SBBH;
            //czr_model.GC = Rwlist[Index].GC;
            //czr_model.CZLB = 2;
            //Crzlist = SelectCZR(czr_model);
            //czrtextBox.Text = Crzlist.CZR;

          
        }
        public void ConfigData(MES_PD_SCRW_LIST[] model)
        {
            Finish = new List<int>();                  
            JhList = new List<GridVrid>();
            Rwlist = model;
            Rwlist = model;
            int lenght = 0;
            for (int i = 0; i < model.Length; i++)
            {
                if (model[i].ISACTION == 0)
                {
                    Index = i;
                    break;
                }
                else
                {
                    lenght++;
                }
            }

            if (lenght == model.Length && Index == 0)
            {
                SMtextBox.ReadOnly = true;
            }
            else
            {
                SMtextBox.Select();
                SetCurrentTL(model[Index]);
                SMtextBox.ReadOnly = false;
            }
            qrtlbutton.Enabled = false;
            gzzxtextBox.Text = model[Index].GZZXBH + "-" + model[Index].GZZXNAME;
            gctextBox.Text = model[Index].GC;
            tlsjtextBox.Clear();
            configDatagrid();       
        }
        public void SetCurrentTL(MES_PD_SCRW_LIST model){
            thtextBox.Text = model.TH.ToString();
            pfhtextBox.Text = model.PFDH;
            pldhtextBox.Text = model.PLDH;
            zfcdtextBox.Text = model.XFCDNAME;
            zfphtextBox.Text = model.XFPC;

        }
        public void configDatagrid()
        {        
            for (int i = 0; i < Rwlist.Length; i++)
            {
                GridVrid node = new GridVrid();
                //node.Xh = (i+1).ToString();
                node.Th = Rwlist[i].TH;
                node.Pfdh = Rwlist[i].PFDH;
                node.Pldh = Rwlist[i].PLDH;
                node.Xfcd = Rwlist[i].XFCDNAME;
                node.Xfpc = Rwlist[i].XFPC;
                Finish.Add(Rwlist[i].ISACTION);
                JhList.Add(node);
            }

            jldataGridView.DataSource = JhList;
            jldataGridView.Columns["完成状态"].DefaultCellStyle.BackColor = Color.Red;
            for (int i = 0; i < Finish.Count; i++)
            {
                if (Finish[i] >= 1)
                {
                    jldataGridView.Rows[i].Cells["完成状态"].Style.BackColor = Color.FromArgb(187, 255, 102);
                }                   
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

            //scrqtextBox.Text = Convert.ToDateTime(monthCalendar1.SelectionStart.ToShortDateString()).ToString("yyyy-MM-dd");
            //monthCalendar1.Visible = false;
        }

        private void scrqtextBox_Click(object sender, EventArgs e)
        {
            //monthCalendar1.Visible = true;
        }

       
      
        private void SMtextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ScanTM();

            }
        }
        public void ScanTM()
        {
            TM_Type type = TMtype(SMtextBox.Text.Trim());
            switch (type)
            {
                case TM_Type.none:
                    MessageBox.Show("你扫描的是无效的条码！！", "消息框");
                    break;
                case TM_Type.staffno:
                    getCzrInfo();
                    MessageBox.Show("你扫描的是无效的条码！！", "消息框");
                    break;
                case TM_Type.gd:
                    MessageBox.Show("你扫描的是无效的条码！！", "消息框");
                    break;
                case TM_Type.ph:
                    getReportInfoByTm();
                    break;
                default:
                    MessageBox.Show("你扫描的是无效的条码！！", "消息框");
                    break;
            }

        }
        public void getReportInfoByTm()
        {
            MES_PD_TL model = new MES_PD_TL();
            model.RWBH = Rwlist[Index].RWBH;
            model.TM = SMtextBox.Text.Trim().ToUpper();
            model.JLR = Convert.ToInt32(getUserInfo("staffid"));
            MES_RETURN_UI res = ServicModel.PD_SCRW.FJTL_VERIFY(model,getToken());
            if (res.TYPE.Equals("S"))
            {
                //foreach (Control contrl in panel1.Controls)
                //{
                //    if (contrl is TextBox)
                //    {
                //        contrl.BackColor = Color.FromArgb(187, 255, 102);
                //    }
                //}
                qrtlbutton.Enabled = true;
                string datetime = ServicModel.PUBLIC_FUNC.GET_TIME(getToken());

                tlsjtextBox.Text = Convert.ToDateTime(datetime).ToString("yyyy-MM-dd HH:mm");
                tlsjtextBox.BackColor = Color.FromArgb(187, 255, 102);
                //MessageBox.Show("投料成功", "消息框");
                ShowMeg("投料成功", 1500);
            }
            else
            {
                ShowMeg(res.MESSAGE);
              
              
               
            }
            SMtextBox.Clear();
            SMtextBox.Select();
        }
        public void getCzrInfo()
        {
            MES_TM_CZR model = new MES_TM_CZR();
            model.SBBH = Rwlist[Index].SBBH;
            model.GC = Rwlist[Index].GC;
            model.CZLB = 2;
            model.CZRGH = SMtextBox.Text.Trim();
            model.GWID = 0;
            MES_RETURN_UI res = AddCzr(model);
            if (res.TYPE.Equals("S"))
            {
                Crzlist = SelectCZR(model);
                czrtextBox.Text = Crzlist.CZR;
                //czrytextBox.Text = _czrList.CZR;
            }
            else
            {
                MessageBox.Show(res.MESSAGE, "消息框");
            }
            SMtextBox.Clear();
            SMtextBox.Select();
        }
       

        public class GridVrid
        {
            // "序号", "桶号", "配方号", "配料单号", "锌粉产地","锌粉批号"
            //string _xh;

            //public string Xh
            //{
            //    get { return _xh; }
            //    set { _xh = value; }
            //}
            int _th;

            public int Th
            {
                get { return _th; }
                set { _th = value; }
            }
            string _pfdh;

            public string Pfdh
            {
                get { return _pfdh; }
                set { _pfdh = value; }
            }
            string _pldh;

            public string Pldh
            {
                get { return _pldh; }
                set { _pldh = value; }
            }
            string _xfcd;

            public string Xfcd
            {
                get { return _xfcd; }
                set { _xfcd = value; }
            }
            string _xfpc;

            public string Xfpc
            {
                get { return _xfpc; }
                set { _xfpc = value; }
            }

        }

        private void frmFujiTL_Shown(object sender, EventArgs e)
        {
           
            //jldataGridView.Rows[Index].Selected = true;
           
            jldataGridView.Columns["完成状态"].DefaultCellStyle.BackColor = Color.Red;
           
            //jldataGridView.Columns[6].InheritedStyle.SelectionBackColor = Color.Yellow;
            for (int i = 0; i < Finish.Count; i++)
            {
                if (Finish[i] >= 1)
                {
                    jldataGridView.Rows[i].Cells["完成状态"].Style.BackColor = Color.FromArgb(187, 255, 102);

                }
            }
            jldataGridView.CurrentCell = jldataGridView.Rows[Index].Cells[0];
            jldataGridView.ClearSelection();
            
            


        }

        private void ryglbutton_Click(object sender, EventArgs e)
        {
            frmManagerRY fomr = new frmManagerRY(Crzlist, Rwlist[Index],2);
            //push(fomr);
            show(fomr);
            MES_TM_CZR czr_model = new MES_TM_CZR();
            czr_model.SBBH = Rwlist[Index].SBBH;
            czr_model.GC = Rwlist[Index].GC;
            czr_model.CZLB = 2;
            Crzlist = SelectCZR(czr_model);
            czrtextBox.Text = Crzlist.CZR;
            SMtextBox.Select();
        }

        private void qrtlbutton_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(czrtextBox.Text.Trim()))
            //{
            //    MessageBox.Show("操作人不能为空", "消息框");
            //    SMtextBox.Select();
            //    return;
            //}
            if (string.IsNullOrEmpty(tlsjtextBox.Text.Trim()))
            {
                MessageBox.Show("投料时间不能为空", "消息框");
                return;
            }
            if (judge.IsDate(tlsjtextBox.Text.Trim()) == false && tlsjtextBox.Text.Length == 16)
            {
                MessageBox.Show("投料时间的格式不正确", "消息框");
                return;
            }
            MES_PD_SCRW model = new MES_PD_SCRW();
            model.GC = Rwlist[Index].GC;
            model.RWBH = Rwlist[Index].RWBH;
            model.TLSJ = tlsjtextBox.Text.Trim();
            model.GZZXBH = Rwlist[Index].GZZXBH;
            model.MAC = DeviceInfo.GetNetCardMAC().Substring(0, 17);
            //model.JLR = Convert.ToInt32(getUserInfo("staffid"));
            SELECT_MES_PD_SCRW res = ServicModel.PD_SCRW.UPDATE_FJTL(model, getToken());
            if (res.MES_RETURN.TYPE.Equals("S"))
            {
                int index = -1;
                for (int i = 0; i < res.MES_PD_SCRW_LIST.Length; i++)
                {
                    if (res.MES_PD_SCRW_LIST[i].ISACTION == 0)
                    {
                        index = i;
                    }
                }
                if (index == -1)
                {
                    //if (MessageBox.Show("设备号" + Sbh + "的派单任务已经全部完成", "消息框", MessageBoxButtons.OK) == DialogResult.OK)
                    //{
                        ShowMeg("设备号" + Sbh + "任务完成", 1500);
                        ConfigData(res.MES_PD_SCRW_LIST, Sbh);
                        jldataGridView.ClearSelection();
                    //}
                   
                }
                else
                {

                    ShowMeg("完成投料", 1500);
                    //if (MessageBox.Show("完成投料", "消息框", MessageBoxButtons.OK) == DialogResult.OK)
                    //{
                        ConfigData(res.MES_PD_SCRW_LIST, Sbh);
                        jldataGridView.ClearSelection();
                        //jldataGridView.Rows[Index].Selected = true;
                        jldataGridView.CurrentCell = jldataGridView.Rows[Index].Cells[0];
                        jldataGridView.ClearSelection();
                    //}
                        tlsjtextBox.Clear();
                        tlsjtextBox.BackColor = Color.FromArgb(234, 241, 246);
                }
            }
            else
            {
                MessageBox.Show(res.MES_RETURN.MESSAGE, "消息框");
                return;
            }
            
            
        }

        private void qhsbhbutton_Click(object sender, EventArgs e)
        {
            MES_SY_GZZX_SBH model = new MES_SY_GZZX_SBH();
            model.GZZXBH = Convert.ToString(getUserInfo("gzzxvalue"));
            model.GC = getGC("value");
            model.WLLBNAME = GetWLLBName(Rigth_Type.fujitl);
            MES_SY_GZZX_SBH[] list = ServicModel.SY_GZZX_SBH.SELECT(model, getToken());
            frmFindSBH form = new frmFindSBH(list, getUserInfo("gzzxtext"), Rigth_Type.fujitl,false);

            push(form,this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ConfigData(res.MES_PD_SCRW_LIST, Sbh);
            //jldataGridView.ClearSelection();
            ////jldataGridView.Rows[Index].Selected = true;
            //jldataGridView.CurrentCell = jldataGridView.Rows[Index].Cells[0];
            //jldataGridView.ClearSelection();
            MES_PD_SCRW model = new MES_PD_SCRW();
            model.SBBH = SBHID;
            model.ZPRQ = DateTime.Now.ToString("yyyy-MM-dd");
            SELECT_MES_PD_SCRW res = ServicModel.PD_SCRW.SELECT(model, getToken());
            if (res.MES_RETURN.TYPE.Equals("S"))
            {
                ConfigData(res.MES_PD_SCRW_LIST);
            }
            else
            {
                ShowMeg(res.MES_RETURN.MESSAGE);
            }


        }
    }
}
