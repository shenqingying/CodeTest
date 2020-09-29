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
    public partial class frmFujiTL_N : baseview
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
   
        public frmFujiTL_N()
        {
            InitializeComponent();
        }
        public frmFujiTL_N(MES_PD_SCRW_LIST[] model, string sbh, string sbhID)
        {
            InitializeComponent();
            //string[] cols = {  "桶号", "配方号", "配料单号", "锌粉产地", "锌粉批号","完成状态"};
            string[] cols = { q(Msg_Type.fieldth), q(Msg_Type.fieldpfh), q(Msg_Type.fieldgcpc), q(Msg_Type.fieldxfcd), q(Msg_Type.fieldtlsj), q(Msg_Type.fieldwczt) };//"桶号", "配方号", "工厂批次", "锌粉产地",  "投料时间","完成状态"
            string[] colss = { "Th", "Pfdh", "Xfpc", "Xfcd", "Tlsj", "status" };
            string[] vcol = { };
            string[] vcols = { q(Msg_Type.fieldwllbdm), q(Msg_Type.fieldtmdm), q(Msg_Type.fieldgc) };//"物料类别代码", "条码代码", "工厂" 
            SBHID = sbhID;
            DataGridBuild_N(cols, colss, jldataGridView, vcols);
            Sbh = sbh;
            Rwlist = model;
            radioButton2.Checked = true;
            
            //radioButton1.Select();
            

        }
        public void DataGridBuild_N(string[] cols, string[] colss, DataGridView datagridGiew, string[] vcols)
        {
            datagridGiew.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            for (int i = 0; i < cols.Length; i++)
            {
                DataGridViewTextBoxColumn acCode = new DataGridViewTextBoxColumn();
                acCode.Name = cols[i];
                acCode.DataPropertyName = colss[i];
                acCode.HeaderText = cols[i];

                if (cols[i] == q(Msg_Type.fieldpfh))//"配方号"
                {
                    acCode.Width = 180;
                    acCode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                else if (cols[i] == q(Msg_Type.fieldth))//"桶号"
                {
                     acCode.Width = 50;
                    //acCode.DefaultCellStyle.Font = new Font(q(Msg_Type.fonttype),4);
                    acCode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                else if (cols[i] == q(Msg_Type.fieldgcpc) || cols[i] == q(Msg_Type.fieldgyspc) )//"工厂批次"  "供应商批次"
                {
                    acCode.Width = 195;
                    acCode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                else if (cols[i] == q(Msg_Type.fieldtlsj))//"投料时间"
                {
                    acCode.Width = 100;
                    acCode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                else
                {
                    acCode.Width = 120;
                    acCode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                if (vcols.Count(p => p == cols[i]) > 0)
                {
                    acCode.Visible = false;
                }

                datagridGiew.Columns.Add(acCode);

                datagridGiew.RowTemplate.Height = 40;
                datagridGiew.RowTemplate.DefaultCellStyle.Font = new Font(q(Msg_Type.fonttype), 18);
            }

            //datagridGiew.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            foreach (DataGridViewColumn item in datagridGiew.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        
        public void ConfigData(MES_PD_SCRW_LIST[] model, string sbh)
        {
            Finish = new List<int>();
            Sbh = sbh;
            Rwlist = model;
            SBlabel4.Text = sbh;
            //sbhtextBox.Text = sbh;
            JhList = new List<GridVrid>();
            //scrqtextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            
            //monthCalendar1.BringToFront();
            //monthCalendar1.Visible = false;
            //Rwlist = model;
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

            //configDatagrid();
            if (radioButton1.Checked)
            {
                ShowList(radioType.all);
            }
            else if (radioButton2.Checked)
            {
                ShowList(radioType.unfinish);
            }
            else if (radioButton3.Checked)
            {
                ShowList(radioType.finish);
            }
            //MES_TM_CZR czr_model = new MES_TM_CZR();
            //czr_model.SBBH = Rwlist[Index].SBBH;
            //czr_model.GC = Rwlist[Index].GC;
            //czr_model.CZLB = 2;
            //Crzlist = SelectCZR(czr_model);
            //czrtextBox.Text = Crzlist.CZR;
            //jldataGridView.Columns["完成状态"].DisplayIndex = 5;
            //jldataGridView.Columns["锌粉产地"].DisplayIndex = 3;
          
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
            //configDatagrid();      
            if (radioButton1.Checked)
            {
                ShowList(radioType.all);
            }
            else if (radioButton2.Checked)
            {
                ShowList(radioType.unfinish);
            }
            else if (radioButton3.Checked)
            {
                ShowList(radioType.finish);
            }
            
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
                //node.Pldh = Rwlist[i].PLDH;
                node.Xfpc = Rwlist[i].XFPC;
                node.Xfcd = Rwlist[i].XFCDNAME;
                if (string.IsNullOrEmpty(Rwlist[i].TLSJ))
                {
                    node.Tlsj = Rwlist[i].TLSJ;
                }
                else
                {
                    node.Tlsj = Convert.ToDateTime(Rwlist[i].TLSJ).ToString("HH:mm");
                }
                //node.Gyspc = Rwlist[i].GYSPC;
                Finish.Add(Rwlist[i].ISACTION);
                JhList.Add(node);
            }

            jldataGridView.DataSource = JhList;
            jldataGridView.Columns[q(Msg_Type.fieldwczt)].DefaultCellStyle.BackColor = Color.Red;//"完成状态"
            for (int i = 0; i < Finish.Count; i++)
            {
                if (Finish[i] >= 1)
                {
                    jldataGridView.Rows[i].Cells[q(Msg_Type.fieldwczt)].Style.BackColor = Color.FromArgb(187, 255, 102);//"完成状态"
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
                    //MessageBox.Show("你扫描的是无效的条码！！", "消息框");
                    ShowMeg(q(Msg_Type.msgscantminvalid));
                    break;
                case TM_Type.staffno:
                    getCzrInfo();
                    //MessageBox.Show("你扫描的是无效的条码！！", "消息框");
                    break;
                case TM_Type.gd:
                    //MessageBox.Show("你扫描的是无效的条码！！", "消息框");
                    ShowMeg(q(Msg_Type.msgscantminvalid));
                    break;
                case TM_Type.ph:
                    getReportInfoByTm();
                    break;
                default:
                    //MessageBox.Show("你扫描的是无效的条码！！", "消息框");
                    ShowMeg(q(Msg_Type.msgscantminvalid));
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
                ShowMeg(q(Msg_Type.msgtlsuccess), 1500);//"投料成功"
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
                //MessageBox.Show(res.MESSAGE, "消息框");
                ShowMeg(res.MESSAGE);
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
            //string _pldh;

            //public string Pldh
            //{
            //    get { return _pldh; }
            //    set { _pldh = value; }
            //}
            //string _gyspc;

            //public string Gyspc
            //{
            //    get { return _gyspc; }
            //    set { _gyspc = value; }
            //}
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
            string _tlsj;

            public string Tlsj
            {
                get { return _tlsj; }
                set { _tlsj = value; }
            }

        }

        private void frmFujiTL_Shown(object sender, EventArgs e)
        {
            ConfigData(Rwlist, Sbh);
            //jldataGridView.Rows[Index].Selected = true;
           
            //jldataGridView.Columns["完成状态"].DefaultCellStyle.BackColor = Color.Red;
           
            //jldataGridView.Columns[6].InheritedStyle.SelectionBackColor = Color.Yellow;
            //for (int i = 0; i < Finish.Count; i++)
            //{
            //    if (Finish[i] >= 1)
            //    {
            //        jldataGridView.Rows[i].Cells["完成状态"].Style.BackColor = Color.FromArgb(187, 255, 102);

            //    }
            //}
            //jldataGridView.CurrentCell = jldataGridView.Rows[Index].Cells[0];
            //jldataGridView.ClearSelection();
            //ShowList(radioType.all);
            //jldataGridView.Columns["完成状态"].DisplayIndex = 5;
            //jldataGridView.Columns["锌粉产地"].DisplayIndex = 3;

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
                //MessageBox.Show("投料时间不能为空", "消息框");
                ShowMeg(q(Msg_Type.msgtlsjnoempty));
                return;
            }
            if (judge.IsDate(tlsjtextBox.Text.Trim()) == false && tlsjtextBox.Text.Length == 16)
            {
                //MessageBox.Show("投料时间的格式不正确", "消息框");
                ShowMeg(q(Msg_Type.msgtlsjformat));
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
                        ShowMeg(q(Msg_Type.fieldsbh)+Sbh + q(Msg_Type.fieldrwwc), 1500);//"设备号"  "任务完成"
                        ConfigData(res.MES_PD_SCRW_LIST, Sbh);
                        //jldataGridView.ClearSelection();
                    //}
                   
                }
                else
                {

                    ShowMeg(q(Msg_Type.filedwctl), 1500);   //"完成投料"              
                    ConfigData(res.MES_PD_SCRW_LIST, Sbh);                    
                    tlsjtextBox.Clear();
                    tlsjtextBox.BackColor = Color.FromArgb(234, 241, 246);
                }
            }
            else
            {
                //MessageBox.Show(res.MES_RETURN.MESSAGE, "消息框");
                ShowMeg(res.MES_RETURN.MESSAGE);
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
            MES_PD_SCRW model = new MES_PD_SCRW();
            model.SBBH = SBHID;
            //model.ZPRQ = DateTime.Now.ToString("yyyy-MM-dd");
            model.ZPRQ = GetSystemDate(Date_Type.hour, -4, "yyyy-MM-dd");//Convert.ToDateTime(ServicModel.PUBLIC_FUNC.GET_TIME(getToken())).ToString("yyyy-MM-dd");
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

        public enum radioType
        {
            all = 1,
            finish = 2,
            unfinish = 3
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            MES_PD_SCRW model = new MES_PD_SCRW();
            model.SBBH = SBHID;
            model.ZPRQ = Convert.ToDateTime(ServicModel.PUBLIC_FUNC.GET_TIME(getToken())).ToString("yyyy-MM-dd");
            SELECT_MES_PD_SCRW res = ServicModel.PD_SCRW.SELECT(model, getToken());
            if (res.MES_RETURN.TYPE.Equals("S"))
            {
                ConfigData(res.MES_PD_SCRW_LIST);
            }
            else
            {
                ShowMeg(res.MES_RETURN.MESSAGE);
            }
            //ShowList(radioType.all);
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            radioButton2.Checked = true;
            MES_PD_SCRW model = new MES_PD_SCRW();
            model.SBBH = SBHID;
            model.ZPRQ = Convert.ToDateTime(ServicModel.PUBLIC_FUNC.GET_TIME(getToken())).ToString("yyyy-MM-dd");
            SELECT_MES_PD_SCRW res = ServicModel.PD_SCRW.SELECT(model, getToken());
            if (res.MES_RETURN.TYPE.Equals("S"))
            {
                ConfigData(res.MES_PD_SCRW_LIST);
            }
            else
            {
                ShowMeg(res.MES_RETURN.MESSAGE);
            }
            //ShowList(radioType.unfinish);
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            radioButton3.Checked = true;
            MES_PD_SCRW model = new MES_PD_SCRW();
            model.SBBH = SBHID;
            model.ZPRQ = Convert.ToDateTime(ServicModel.PUBLIC_FUNC.GET_TIME(getToken())).ToString("yyyy-MM-dd");
            SELECT_MES_PD_SCRW res = ServicModel.PD_SCRW.SELECT(model, getToken());
            if (res.MES_RETURN.TYPE.Equals("S"))
            {
                ConfigData(res.MES_PD_SCRW_LIST);
            }
            else
            {
                ShowMeg(res.MES_RETURN.MESSAGE);
            }
            //ShowList(radioType.finish);
        }
        public void ShowList(radioType type)
        {
            JhList = new List<GridVrid>();
            Finish = new List<int>();           
            for (int i = 0; i < Rwlist.Length; i++)
            {
                switch (type)
                {
                    case radioType.all:
                        {
                            GridVrid node = new GridVrid();
                            node.Th = Rwlist[i].TH;
                            node.Pfdh = Rwlist[i].PFDH;
                            node.Xfpc = Rwlist[i].XFPC;
                            node.Xfcd = Rwlist[i].XFCDNAME;
                            if (string.IsNullOrEmpty(Rwlist[i].TLSJ))
                            {
                                node.Tlsj = Rwlist[i].TLSJ;
                            }
                            else
                            {
                                node.Tlsj = Convert.ToDateTime(Rwlist[i].TLSJ).ToString("HH:mm");
                            }
                            //node.Gyspc = Rwlist[i].GYSPC;
                            Finish.Add(Rwlist[i].ISACTION);
                            JhList.Add(node);
                        }
                        break;
                    case radioType.finish:
                        {
                            if (Rwlist[i].ISACTION >= 1)
                            {
                                 GridVrid node = new GridVrid();
                                 node.Th = Rwlist[i].TH;
                                 node.Pfdh = Rwlist[i].PFDH;
                                 node.Xfpc = Rwlist[i].XFPC;
                                 node.Xfcd = Rwlist[i].XFCDNAME;
                                 //node.Gyspc = Rwlist[i].GYSPC;
                                 if (string.IsNullOrEmpty(Rwlist[i].TLSJ))
                                 {
                                     node.Tlsj = Rwlist[i].TLSJ;
                                 }
                                 else
                                 {
                                     node.Tlsj = Convert.ToDateTime(Rwlist[i].TLSJ).ToString("HH:mm");
                                 }
                                 Finish.Add(Rwlist[i].ISACTION);
                                 JhList.Add(node);
                            }
                        }
                        break;
                    case radioType.unfinish:
                        {
                            if (Rwlist[i].ISACTION == 0)
                            {
                                 GridVrid node = new GridVrid();
                                 node.Th = Rwlist[i].TH;
                                 node.Pfdh = Rwlist[i].PFDH;
                                 node.Xfpc = Rwlist[i].XFPC;
                                 node.Xfcd = Rwlist[i].XFCDNAME;
                                 //node.Gyspc = Rwlist[i].GYSPC;
                                 if (string.IsNullOrEmpty(Rwlist[i].TLSJ))
                                 {
                                     node.Tlsj = Rwlist[i].TLSJ;
                                 }
                                 else
                                 {
                                     node.Tlsj = Convert.ToDateTime(Rwlist[i].TLSJ).ToString("HH:mm");
                                 }
                                 
                                 Finish.Add(Rwlist[i].ISACTION);
                                 JhList.Add(node);
                            }
                        }
                        break;
                    default:
                        break;
                }
               
            }

            jldataGridView.DataSource = JhList;
            jldataGridView.Columns[q(Msg_Type.fieldwczt)].DefaultCellStyle.BackColor = Color.Red;//"完成状态"
            for (int i = 0; i < Finish.Count; i++)
            {
                if (Finish[i] >= 1)
                {
                    jldataGridView.Rows[i].Cells[q(Msg_Type.fieldwczt)].Style.BackColor = Color.FromArgb(187, 255, 102);//"完成状态"
                }
            }
            jldataGridView.Columns[q(Msg_Type.fieldwczt)].DisplayIndex = 5;//"完成状态"
            jldataGridView.Columns[q(Msg_Type.fieldxfcd)].DisplayIndex = 2;//"锌粉产地"

            if (type == radioType.all)
            {
                int index = Rwlist.ToList().FindIndex(p => p.ISACTION == 0);
               
                if (index != -1)
                {
                    jldataGridView.CurrentCell = jldataGridView.Rows[Index].Cells[0];
                }
            }
            jldataGridView.ClearSelection();
            SMtextBox.Select();
        }

        private void nextrwbutton_Click(object sender, EventArgs e)
        {
            MES_PD_SCRW model = new MES_PD_SCRW();
            model.SBBH = SBHID;
            //model.ZPRQ = DateTime.Now.ToString("yyyy-MM-dd");
            string currentDay = ServicModel.PUBLIC_FUNC.GET_TIME(getToken());
            string ksDate = Convert.ToDateTime(currentDay).AddDays(1).ToString("yyyy-MM-dd");
            string jsDate = Convert.ToDateTime(currentDay).AddDays(10).ToString("yyyy-MM-dd");
            model.ZPRQKS = ksDate;
            model.ZPRQJS = jsDate;
            
            SELECT_MES_PD_SCRW res = ServicModel.PD_SCRW.SELECT(model, getToken());
            if (res.MES_RETURN.TYPE.Equals("S"))
            {
                MES_PD_SCRW_LIST[] rwlist = res.MES_PD_SCRW_LIST;
                //(from o in nodes_right orderby o.RGROUPID, o.RIGHTNO select o).ToList();
                List<MES_PD_SCRW_LIST> nodes = (from o in rwlist.ToList() orderby o.ZPRQ select o).ToList();
                if (nodes.Count > 0)
                {
                    string neardate = nodes[0].ZPRQ;
                    List<MES_PD_SCRW_LIST> requirelist = new List<MES_PD_SCRW_LIST>();
                    for (int i = 0; i < nodes.Count; i++)
                    {
                        if (nodes[i].ZPRQ.Equals(neardate))
                        {
                            requirelist.Add(nodes[i]);
                        }
                    }
                    frmNearDateRW form = new frmNearDateRW(requirelist.ToArray());
                    show(form);
                }
                else
                {
                    ShowMeg(q(Msg_Type.msgzsnorw));//"暂时没有任务指派"
                }                             
            }
            else
            {
                ShowMeg(q(Msg_Type.msgzsnorw));//"暂时没有任务指派"
            }
            SMtextBox.Select();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
