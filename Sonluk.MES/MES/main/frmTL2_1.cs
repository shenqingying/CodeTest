﻿using Sonluk.MES.MES.Base;
using Sonluk.UI.Model.MES.PD_GDService;
using Sonluk.UI.Model.MES.PD_SCRWService;
using Sonluk.UI.Model.MES.SY_GZZX_SBHService;
using Sonluk.UI.Model.MES.SY_TYPEMXService;
using Sonluk.UI.Model.MES.TM_CZRService;
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
    public partial class frmTL2_1 : baseview
    {
        #region property
        MES_TM_CZR_SELECT_CZR_NOW _czrList;

        public MES_TM_CZR_SELECT_CZR_NOW CzrList
        {
            get { return _czrList; }
            set { _czrList = value; }
        }
        IList<TMDataGrid> _tmlist;

        public IList<TMDataGrid> Tmlist
        {
            get { return _tmlist; }
            set { _tmlist = value; }
        }
        MES_PD_SCRW_LIST _MES_PD_SCRW_LIST;

        public MES_PD_SCRW_LIST MES_PD_SCRW_LIST
        {
            get { return _MES_PD_SCRW_LIST; }
            set { _MES_PD_SCRW_LIST = value; }
        }
        ZBCFUN_GDJGXX_READ _bomList;

        public ZBCFUN_GDJGXX_READ BomList
        {
            get { return _bomList; }
            set { _bomList = value; }
        }
        IList<int> unRequireArr;
        string _lastDate;

        public string LastDate
        {
            get { return _lastDate; }
            set { _lastDate = value; }
        }
        #endregion
        public frmTL2_1()
        {
            InitializeComponent();
            
        }
        public frmTL2_1(MES_PD_SCRW_LIST list, string shebeihaoID,Rigth_Type rtype)
        {
            InitializeComponent();
            this.Text = GetFormName(rtype);
            //if (rtype != Rigth_Type.gangketl_cc)
            //{
            //    dyrkbutton.Visible = false;
            //}
            bingLSdatagridView();
            bindBomView();
            RigthType = rtype;
            SMtextBox.Select();
            SBHID = shebeihaoID;
            Tmlist = new List<TMDataGrid>();
            this._MES_PD_SCRW_LIST = list;
           

        }
        public void InitData(MES_PD_SCRW_LIST list)
        {
            MES_TM_CZR rymodel = new MES_TM_CZR();
            rymodel.GC = list.GC;
            rymodel.RWBH = list.RWBH;
            rymodel.CZLB = 1;
            dateTimePicker1.Text = list.ZPRQ;
            _czrList = ServicModel.TM_CZR.SELECT_CZR_NOW(rymodel, getToken());
            _bomList = ServicModel.PD_GD.SAP_GET_GDJGXX(list.RWBH, list.ZPRQ, list.GC, getToken());
            unRequireArr = new List<int>();
            MES_SY_TYPEMX bcmodel = new MES_SY_TYPEMX();
            bcmodel.GC = Convert.ToString(getGC("value"));
            bcmodel.TYPEID = 5;
            List<MES_SY_TYPEMXLIST> bcArr = new List<MES_SY_TYPEMXLIST>();
            MES_SY_TYPEMXLIST[] bclist = ServicModel.SY_TYPEMX.SELECT(bcmodel, getToken());
            gzzxtextBox.Text = list.GZZXBH + "-" + list.GZZXNAME;
            czrytextBox.Text = _czrList.CZR;
            gctextBox.Text = list.GC;
            sbhtextBox.Text = list.SBH;
            pctextBox.Text = list.PC;

            MES_SY_TYPEMXLIST bcmodel1 = new MES_SY_TYPEMXLIST();
            bcmodel1.ID = 0;
            bcmodel1.MXNAME = q(Msg_Type.titlechoice);//"==请选择==";
            bcArr = bclist.ToList();
            bcArr.Insert(0, bcmodel1);

            bccomboBox.DisplayMember = "MXNAME";
            bccomboBox.ValueMember = "ID";
            bccomboBox.DataSource = bcArr;
            bccomboBox.SelectedValue = list.BC;
            MESlabel.Text = q(Msg_Type.titlemesgd) + list.GDDH;//"MES工单:"
            GDHlabel.Text = q(Msg_Type.titlegd)+list.ERPNO;//"工单号:"
            WLXXlabel.Text = q(Msg_Type.titlewlxx) + list.WLH + "/" + list.WLMS;//"物料信息:"
            WLLBlabel1.Text = q(Msg_Type.titlewllb)+list.WLLBNAME;//"物料类别:"
            rwdlabel.Text = q(Msg_Type.titlerwd)+list.RWBH;//"任务单:"
            if (_bomList.MES_RETURN.TYPE.Equals("S"))
            {
                BOMdataGridView.DataSource = getBomList(_bomList);
                BOMdataGridView.ClearSelection();
            }
            else
            {
                ShowMeg(_bomList.MES_RETURN.MESSAGE);
                //this.Close();
                BOMdataGridView.DataSource = new List<BomDataGrid>();
            }
            LSdataGridView.ReadOnly = true;           
            LastDate = dateTimePicker1.Text.Trim();
            if (RigthType == Rigth_Type.mfqqingxi)
            {
                GDHlabel.Visible = false;
                WLXXlabel.Location = GDHlabel.Location;
            }
        }
        public void RefreshRW(MES_PD_SCRW_LIST list, string shebeihaoID)
        {
            this._MES_PD_SCRW_LIST = list;
            Tmlist = new List<TMDataGrid>();
            MES_TM_CZR rymodel = new MES_TM_CZR();
            rymodel.GC = list.GC;
            rymodel.RWBH = list.RWBH;
            rymodel.CZLB = 1;
            _czrList = ServicModel.TM_CZR.SELECT_CZR_NOW(rymodel, getToken());
            _bomList = ServicModel.PD_GD.SAP_GET_GDJGXX(list.RWBH,list.ZPRQ, list.GC, getToken());
            unRequireArr = new List<int>();
            MES_SY_TYPEMX bcmodel = new MES_SY_TYPEMX();
            bcmodel.GC = Convert.ToString(getGC("value"));
            bcmodel.TYPEID = 5;
            List<MES_SY_TYPEMXLIST> bcArr = new List<MES_SY_TYPEMXLIST>();
            MES_SY_TYPEMXLIST[] bclist = ServicModel.SY_TYPEMX.SELECT(bcmodel, getToken());
            gzzxtextBox.Text = list.GZZXBH + "-" + list.GZZXNAME;
            czrytextBox.Text = _czrList.CZR;
            gctextBox.Text = list.GC;
            sbhtextBox.Text = list.SBH;
            pctextBox.Text = list.PC;
            MES_SY_TYPEMXLIST bcmodel1 = new MES_SY_TYPEMXLIST();
            bcmodel1.ID = 0;
            bcmodel1.MXNAME = q(Msg_Type.titlechoice);//"==请选择==";
            bcArr = bclist.ToList();
            bcArr.Insert(0, bcmodel1);
            bccomboBox.DisplayMember = "MXNAME";
            bccomboBox.ValueMember = "ID";
            bccomboBox.DataSource = bcArr;
            bccomboBox.SelectedValue = list.BC;
            dateTimePicker1.Text = list.ZPRQ;
            MESlabel.Text = q(Msg_Type.titlemesgd)+list.GDDH;//"MES工单:"
            GDHlabel.Text =q(Msg_Type.titlegd) +list.ERPNO;//"工单号:"
            WLXXlabel.Text = q(Msg_Type.titlewlxx)+list.WLH + "/" + list.WLMS;//"物料信息:" 
            WLLBlabel1.Text = q(Msg_Type.titlewllb)+list.WLLBNAME;//"物料类别:"
            rwdlabel.Text = q(Msg_Type.titlerwd)+list.RWBH;//"任务单:"
            if (_bomList.MES_RETURN.TYPE.Equals("S"))
            {
                BOMdataGridView.DataSource = getBomList(_bomList);
            }
            else
            {
                ShowMeg(_bomList.MES_RETURN.MESSAGE);
                BOMdataGridView.DataSource = new List<BomDataGrid>();
            }
            LSdataGridView.ReadOnly = true;
            BOMdataGridView.Columns[q(Msg_Type.fieldstatus)].DefaultCellStyle.BackColor = Color.Red;//"状态"
            for (int i = 0; i < unRequireArr.Count; i++)
            {
                BOMdataGridView.Rows[unRequireArr[i]].Cells[q(Msg_Type.fieldstatus)].Style.BackColor = Color.White;//"状态"
            }
            BOMdataGridView.ClearSelection();
            //SELECT_MES_TM_TMINFO_BYTM r = ServicModel.TM_TMINFO.SELECT_TL_LAST(MES_PD_SCRW_LIST.RWBH, getToken());
            //if (r.MES_RETURN.TYPE.Equals("S"))
            //{
            //    getTMList(r, 0); 
            //}
            //else
            //{
                Tmlist = new  List<TMDataGrid>();
                LSdataGridView.DataSource = new List<TMDataGrid>();
                LSdataGridView.ClearSelection();
                LSdataGridView.Columns[q(Msg_Type.fielddelete)].DisplayIndex = 4;//"删除"
            //}
            if (RigthType == Rigth_Type.mfqqingxi)
            {
                GDHlabel.Visible = false;
                WLXXlabel.Location = GDHlabel.Location;
            }
        }
        public void bindBomView()
        {
            string[] cols = {q(Msg_Type.fieldxh),q(Msg_Type.fieldwlxx),q(Msg_Type.fieldwllb),q(Msg_Type.fieldwllbdm),q(Msg_Type.fieldstatus) };// "序号", "物料信息", "物料类别", "物料类别代码", "状态"
            string[] colss = { "Xh", "Wlxx", "Wllb", "Wllbdm", "zt" };
            string[] vcol = {q(Msg_Type.fieldwllbdm) };//"物料类别代码"
            DataGridBuild(cols, colss, BOMdataGridView, vcol);
        }
        public void bingLSdatagridView()
        {
            string[] cols = { q(Msg_Type.fieldxh), q(Msg_Type.fieldtm), q(Msg_Type.fieldwlxx), q(Msg_Type.fieldwllb), q(Msg_Type.fielddelete), q(Msg_Type.fieldwllbdm), q(Msg_Type.fieldtmdm), q(Msg_Type.fieldgc), q(Msg_Type.fieldtltmdm) };
                                          //"序号", "条码", "物料信息", "物料类别", "删除", "物料类别代码", "条码代码", "工厂","投料条码代码"
            string[] colss = { "Xh", "Tm", "Wlxx", "Wllb", "del", "Wllbdm", "tmid", "gc","tltmid" };
            string[] vcols = { q(Msg_Type.fieldwllbdm), q(Msg_Type.fieldtmdm), q(Msg_Type.fieldgc), q(Msg_Type.fieldtltmdm) };//{ "物料类别代码", "条码代码", "工厂" ,"投料条码代码"};
            for (int i = 0; i < cols.Length; i++)
            {
                //DataGridViewButtonColumn
                if (cols[i] == "XXXXXX")
                {

                   
                }
                else if (cols[i] ==q(Msg_Type.fielddelete))// "删除" 
                {
                    DataGridViewButtonColumn acCode = new DataGridViewButtonColumn();
                    acCode.Name = cols[i];
                    acCode.UseColumnTextForButtonValue = true;
                    acCode.Text = cols[i];
                    acCode.HeaderText = cols[i];
                    acCode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    LSdataGridView.Columns.Add(acCode);
                }
                else
                {
                    DataGridViewTextBoxColumn acCode = new DataGridViewTextBoxColumn();
                    acCode.Name = cols[i];
                    acCode.DataPropertyName = colss[i];
                    acCode.HeaderText = cols[i];
                    

                    if (cols[i] == q(Msg_Type.fieldwlxx)){//"物料信息"
                        acCode.Width = 300;
                        acCode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    }
                    else
                    {
                        acCode.Width = 120;
                        acCode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }

                        
                    //判断不显示的在 全部字段里面有没有 有的话 就隐藏该字段
                    if (vcols.Count(p => p == cols[i]) > 0)
                    {
                        acCode.Visible = false;
                    }
                    LSdataGridView.Columns.Add(acCode);
                }

            }
            //LSdataGridView.RowTemplate.Height = 35;
            //LSdataGridView.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font(q(Msg_Type.fonttype), 11);
            LSdataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //LSdataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            foreach (DataGridViewColumn item in LSdataGridView.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            //LSdataGridView.Sort;
        }

        private void SMtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void scrqtextBox_TextChanged(object sender, EventArgs e)
        {
            //SCRQmonthCalendar.Visible = true;
        }

        private void ryglbutton_Click(object sender, EventArgs e)
        {
            frmManagerRY fomr = new frmManagerRY(_czrList, MES_PD_SCRW_LIST,1);
            //push(fomr);
            show(fomr);


            MES_TM_CZR rymodel = new MES_TM_CZR();
            rymodel.GC = this._MES_PD_SCRW_LIST.GC;
            rymodel.RWBH = this._MES_PD_SCRW_LIST.RWBH;
            rymodel.CZLB = 1;
            _czrList = ServicModel.TM_CZR.SELECT_CZR_NOW(rymodel, getToken());
            //MES_PD_SCRW model = new MES_PD_SCRW();
            //model.SBHID = SBHID;
            czrytextBox.Text = _czrList.CZR;
            
            //SELECT_MES_PD_SCRW Smodel = ServicModel.PD_SCRW.SELECT(model, getToken());
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
       

        private void SCRQmonthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {

            //scrqtextBox.Text = Convert.ToDateTime(SCRQmonthCalendar.SelectionStart.ToShortDateString()).ToString("yyyy-MM-dd");
            //SCRQmonthCalendar.Visible = false;
       
        }
       

        private void scrqtextBox_Click(object sender, EventArgs e)
        {
            //SCRQmonthCalendar.Visible = true;
        }
        #region  结构体
        public class BomDataGrid
        {
            string _xh;

            public string Xh
            {
                get { return _xh; }
                set { _xh = value; }
            }
            string _wlxx;

            public string Wlxx
            {
                get { return _wlxx; }
                set { _wlxx = value; }
            }
            string _wllb;

            public string Wllb
            {
                get { return _wllb; }
                set { _wllb = value; }
            }
            int _wllbdm;

            public int Wllbdm
            {
                get { return _wllbdm; }
                set { _wllbdm = value; }
            }
        }

        public class TMDataGrid
        {
            int _tltmid;

            public int Tltmid
            {
                get { return _tltmid; }
                set { _tltmid = value; }
            }
            string _gc;

            public string Gc
            {
                get { return _gc; }
                set { _gc = value; }
            }
            string _xh;

            public string Xh
            {
                get { return _xh; }
                set { _xh = value; }
            }
            string _wlxx;

            public string Wlxx
            {
                get { return _wlxx; }
                set { _wlxx = value; }
            }
            string _wllb;

            public string Wllb
            {
                get { return _wllb; }
                set { _wllb = value; }
            }
           
            string _tm;

            public string Tm
            {
                get { return _tm; }
                set { _tm = value; }
            }
            int _wllbdm;

            public int Wllbdm
            {
                get { return _wllbdm; }
                set { _wllbdm = value; }
            }
            int _tmid;

            public int Tmid
            {
                get { return _tmid; }
                set { _tmid = value; }
            }
        }
        #endregion

        private void frmTL2_Shown(object sender, EventArgs e)
        {
            
            BOMdataGridView.Columns[q(Msg_Type.fieldstatus)].DefaultCellStyle.BackColor = Color.Red;//"状态"
            //for (int i = 0; i < unRequireArr.Count; i++)
            //{
            //    BOMdataGridView.Rows[unRequireArr[i]].Cells["状态"].Style.BackColor = Color.White;
            //}
            //SELECT_MES_TM_TMINFO_BYTM r = ServicModel.TM_TMINFO.SELECT_TL_LAST(MES_PD_SCRW_LIST.RWBH, getToken());
            //if (r.MES_RETURN.TYPE.Equals("S"))
            //{
            //    getTMList(r, 0);
            //}
            InitData(MES_PD_SCRW_LIST);
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
                    break;
                case TM_Type.gd:
                    //MessageBox.Show("你扫描的是无效的条码！！", "消息框");
                    ShowMeg(q(Msg_Type.msgscantminvalid));
                    break;
                case TM_Type.ph:
                    {
                        if (RigthType == Rigth_Type.mfqqingxi)
                        {
                            getRwAndJLinfoByTm();
                        }
                        else
                        {
                            getReportInfoByTm();
                        }
                        
                    }                   
                    break;
                case TM_Type.rwd:
                    ChangeRW();
                    break;
                default:
                    //MessageBox.Show("你扫描的是无效的条码！！", "消息框");
                    ShowMeg(q(Msg_Type.msgscantminvalid));
                    break;
            }
            SMtextBox.Select();

        }

        private void getRwAndJLinfoByTm()
        {
            MES_PD_SCRW_SELECT_BY_TM model = new MES_PD_SCRW_SELECT_BY_TM();
            model.SBBH = SBHID;
            model.TM = SMtextBox.Text.Trim().ToUpper();
            model.ZPRQ = Convert.ToDateTime(ServicModel.PUBLIC_FUNC.GET_TIME(getToken())).AddHours(-4).ToString("yyyy-MM-dd");
            SELECT_MES_PD_SCRW res = ServicModel.PD_SCRW.SELECT_BY_TM(model,getToken());
            if (res.MES_RETURN.TYPE.Equals("S"))
            {
                if (res.MES_PD_SCRW_LIST.Length == 1)
                {
                     RefreshRW(res.MES_PD_SCRW_LIST[0],SBHID);
                     SMtextBox.Text = model.TM;
                     getReportInfoByTm();
                     
                     //BOMdataGridView.ClearSelection();
                }
                else if (res.MES_PD_SCRW_LIST.Length > 1)
                {
                    SMtextBox.Clear();
                    frmChange_GD form = new frmChange_GD(res.MES_PD_SCRW_LIST, model.SBBH, RigthType);
                    form.block = RefreshRW;
                    show(form);         
                    //for (int i = 0; i < BOMdataGridView.Rows.Count; i++)
                    //{
                    //    BOMdataGridView.Rows[i].Cells["状态"].Style.BackColor = Color.Red;
               
                    //}
                    //BOMdataGridView.ClearSelection();
                    //Tmlist = new List<TMDataGrid>();
                    //LSdataGridView.DataSource = Tmlist;
                    //LSdataGridView.Columns["删除"].DisplayIndex = 4;

                    //SMtextBox.Select();
                    SMtextBox.Text = model.TM;
                    getReportInfoByTm();
                }
                else if (res.MES_PD_SCRW_LIST.Length == 0)
                {
                    //ShowMeg("找不到条码" + SMtextBox.Text.Trim() + "对应的任务信息");
                    ShowMeg(string.Format(q(Msg_Type.msgtmnorw),SMtextBox.Text.Trim()));

                }
                else
                {
                    //ShowMeg("数据异常,请联系管理员");
                    ShowMeg(q(Msg_Type.msgtmexcept));
                }
                SMtextBox.Select();
               
            }
            else
            {
                ShowMeg(res.MES_RETURN.MESSAGE);
                BomList = new ZBCFUN_GDJGXX_READ();
                BOMdataGridView.DataSource = new List<BomDataGrid>();
                SMtextBox.Clear();
                SMtextBox.Select();
            }
        }
        public void getReportInfoByTm()
        {
            MES_TM_TMINFO model = new MES_TM_TMINFO();
            model.GC = this._MES_PD_SCRW_LIST.GC;
            model.TM = SMtextBox.Text.Trim().ToUpper();
            model.RWBH = this._MES_PD_SCRW_LIST.RWBH;
            model.JLR = Convert.ToInt32(getUserInfo("staffid"));
            SELECT_MES_TM_TMINFO_BYTM res = ReadphTM(model,1);
            if (res.MES_RETURN.TYPE.Equals("S"))
            {
                getTMList(res,1);
            }
            else
            {
                //MessageBox.Show(SMtextBox.Text  + res.MES_RETURN.MESSAGE, "消息框");
                ShowMeg(SMtextBox.Text + res.MES_RETURN.MESSAGE);
            }
            SMtextBox.Clear();
            SMtextBox.Select();
        }
        public void ChangeRW()
        {
            MES_PD_SCRW model = new MES_PD_SCRW();
            model.RWBH = SMtextBox.Text.Trim().ToUpper();
            model.GC = getGC("value");
            model.SBBH = SBHID;
            SELECT_MES_PD_SCRW res = ServicModel.PD_SCRW.SELECT(model,getToken());
            if (res.MES_RETURN.TYPE.Equals("S"))
            {
                MES_PD_SCRW_LIST list = res.MES_PD_SCRW_LIST[0];
                Tmlist = new List<TMDataGrid>();
                LSdataGridView.DataSource = Tmlist;
                LSdataGridView.Columns[q(Msg_Type.fielddelete)].DisplayIndex = 4;//"删除"
                this._MES_PD_SCRW_LIST = list;
                MES_TM_CZR rymodel = new MES_TM_CZR();
                rymodel.GC = list.GC;
                rymodel.RWBH = list.RWBH;
                rymodel.CZLB = 1;
                _czrList = ServicModel.TM_CZR.SELECT_CZR_NOW(rymodel, getToken());
                _bomList = ServicModel.PD_GD.SAP_GET_GDJGXX(list.RWBH,dateTimePicker1.Text.Trim(), list.GC, getToken());
                unRequireArr = new List<int>();
                MES_SY_TYPEMX bcmodel = new MES_SY_TYPEMX();
                bcmodel.GC = Convert.ToString(getGC("value"));
                bcmodel.TYPEID = 5;
                List<MES_SY_TYPEMXLIST> bcArr = new List<MES_SY_TYPEMXLIST>();
                MES_SY_TYPEMXLIST[] bclist = ServicModel.SY_TYPEMX.SELECT(bcmodel, getToken());
                gzzxtextBox.Text = list.GZZXBH + "-" + list.GZZXNAME;
                czrytextBox.Text = _czrList.CZR;
                gctextBox.Text = list.GC;
                sbhtextBox.Text = list.SBH;
                pctextBox.Text = list.PC;
                bcArr = bclist.ToList();
                MES_SY_TYPEMXLIST bcmodel1 = new MES_SY_TYPEMXLIST();
                bcmodel1.ID = 0;
                bcmodel1.MXNAME = q(Msg_Type.titlechoice);//"==请选择==";
                bcArr.Insert(0, bcmodel1);
                bccomboBox.DisplayMember = "MXNAME";
                bccomboBox.ValueMember = "ID";
                bccomboBox.DataSource = bcArr;
                bccomboBox.SelectedValue = list.BC;
                MESlabel.Text = q(Msg_Type.titlemesgd) + list.GDDH;//"MES工单:" 
                GDHlabel.Text = q(Msg_Type.titlegd) + list.ERPNO;//"工单号:"
                WLXXlabel.Text = q(Msg_Type.titlewlxx)+list.WLH + "/" + list.WLMS;//"物料信息:"
                WLLBlabel1.Text = q(Msg_Type.titlewllb)+list.WLLBNAME;//"物料类别:"
                rwdlabel.Text = q(Msg_Type.titlerwd)+list.RWBH;//"任务单:"
                if (_bomList.MES_RETURN.TYPE.Equals("S"))
                {
                    BOMdataGridView.DataSource = getBomList(_bomList);
                }
                else
                {
                    ShowMeg(_bomList.MES_RETURN.MESSAGE);                  
                    BOMdataGridView.DataSource = new List<BomDataGrid>();
                }
                //scrqtextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                LSdataGridView.ReadOnly = true;
                BOMdataGridView.Columns[q(Msg_Type.fieldstatus)].DefaultCellStyle.BackColor = Color.Red;//"状态"
                for (int i = 0; i < unRequireArr.Count; i++)
                {
                    BOMdataGridView.Rows[unRequireArr[i]].Cells[q(Msg_Type.fieldstatus)].Style.BackColor = Color.White;//"状态"
                }
                //SELECT_MES_TM_TMINFO_BYTM r = ServicModel.TM_TMINFO.SELECT_TL_LAST(MES_PD_SCRW_LIST.RWBH, getToken());
                //if (r.MES_RETURN.TYPE.Equals("S"))
                //{
                //    getTMList(r, 0);
                //}
                Tmlist = new List<TMDataGrid>();
                LSdataGridView.DataSource = new List<TMDataGrid>();
                LSdataGridView.ClearSelection();
                LSdataGridView.Columns[q(Msg_Type.fielddelete)].DisplayIndex = 4;//"删除"
                BOMdataGridView.ClearSelection();
                if (RigthType == Rigth_Type.mfqqingxi)
                {
                    GDHlabel.Visible = false;
                    WLXXlabel.Location = GDHlabel.Location;
                }
            }
            else
            {
                //MessageBox.Show(SMtextBox.Text + res.MES_RETURN.MESSAGE, "消息框");
                ShowMeg(SMtextBox.Text + res.MES_RETURN.MESSAGE);

            }
            SMtextBox.Clear();
            SMtextBox.Select();
        }
        public void getCzrInfo()
        {
            MES_TM_CZR model = new MES_TM_CZR();
            model.GC = _MES_PD_SCRW_LIST.GC;
            model.RWBH = _MES_PD_SCRW_LIST.RWBH;
            model.CZLB = 1;
            model.CZRGH = SMtextBox.Text.Trim();
            model.GWID = 0;
            MES_RETURN_UI res = AddCzr(model);
            if (res.TYPE.Equals("S"))
            {
                _czrList = SelectCZR(model);

                czrytextBox.Text = _czrList.CZR;
            }
            else
            {
                //MessageBox.Show(res.MESSAGE, "消息框");
                ShowMeg(res.MESSAGE);
            }
            SMtextBox.Clear();
            SMtextBox.Select();
        }
        public MsgReturn VerifyWLisALL()
        {
            MsgReturn msgInfo = new MsgReturn();
            msgInfo.Pass = false;
            msgInfo.Msg = q(Msg_Type.msgbomunfinish);//"生成物料的相关BOM物料不齐全,请查看需要添加的物料";
            int bomcount = 0;
            int tmcount = 0;
            ZBCFUN_GDJGXX_READ judge = BomList;
            
            //list.Where((x, i) => list.FindIndex(z => z.WLLB == x.WLLB) == i);
            //List<int> list = BomList.ET_BOM.ToList().Select(x => x.WLLB).Distinct().ToList();

            List<ET_BOM> list1 = new List<ET_BOM>();
            if (BomList.ET_BOM == null)
            {
                return msgInfo;
            }
            for (int i = 0; i < BomList.ET_BOM.Length; i++)
            {
                if (list1.Exists(x=>x.WLLB == BomList.ET_BOM[i].WLLB) == false)
                {
                    list1.Add(BomList.ET_BOM[i]);
                }
            }

            for (int i = 0; i < list1.Count; i++)
            {
                if (list1[i].ZSBS.Equals("Y"))
                {
                    bomcount++;
                    for (int j = 0; j < Tmlist.Count; j++)
                    {
                        if (list1[i].WLLB == Tmlist[j].Wllbdm)
                        {
                            tmcount++;
                        }
                    }
                }
            }
            if (tmcount >= bomcount)
            {
                msgInfo.Pass = true;

            }


            return msgInfo;
        }
        public MsgReturn VerifyContent()
        {
            MsgReturn msgInfo = new MsgReturn();
            msgInfo.Pass = true;
            if (string.IsNullOrEmpty(Convert.ToString(bccomboBox.SelectedValue)))
            {
                msgInfo.Msg = q(Msg_Type.msgbcnoempty);//"班次信息不能为空";
                msgInfo.Pass = false;
            }
            if (string.IsNullOrEmpty(czrytextBox.Text.Trim()))
            {
                msgInfo.Msg = q(Msg_Type.msgczrnotempty);//"操作人员信息不能为空";
                msgInfo.Pass = false;
            }
            //if (string.IsNullOrEmpty(scrqtextBox.Text.Trim()))
            //{
            //    msgInfo.Msg = "生产日期不能为空";               
            //    msgInfo.Pass = false;
            //}
            
            //if (judge.IsDate(scrqtextBox.Text.Trim()) == false)
            //{
            //    msgInfo.Msg = "生产日期的日期格式不是正确的日期格式";               
            //    msgInfo.Pass = false;
            //}
            //if (scrqtextBox.Text.Trim().Length != 10)
            //{
            //    msgInfo.Msg = "生产日期的日期格式不是正确的10位日期格式";
            //    msgInfo.Pass = false;
            //}

            return msgInfo;
        }

        public void CreateTM()
        {

            //if (judge.IsDate(scrqtextBox.Text.Trim()) == false)
            //{
            //    MessageBox.Show("生产日期的日期格式不正确", "消息框");
            //}
        }
        private void getTMList(SELECT_MES_TM_TMINFO_BYTM model,int first)
        {
            for (int x = 0; x < model.MES_TM_TMINFO_LIST.Length; x++)
            {
                IList<TMDataGrid> nodes = new List<TMDataGrid>();
                TMDataGrid node = new TMDataGrid();

                if (model.MES_TM_TMINFO_LIST.Length <= 0)
                {
                    //MessageBox.Show("扫描的是无效的条码", "消息框");
                    ShowMeg(q(Msg_Type.msgscantminvalid));
                    SMtextBox.Clear();
                    return;
                }

                node.Tm = model.MES_TM_TMINFO_LIST[x].TM;
                node.Wlxx = model.MES_TM_TMINFO_LIST[x].WLH + "/" + model.MES_TM_TMINFO_LIST[x].WLMS;
                node.Wllb = model.MES_TM_TMINFO_LIST[x].WLLBNAME;
                //node.Bz = model.MES_TM_TMINFO_LIST[0].REMARK;
                node.Wllbdm = model.MES_TM_TMINFO_LIST[x].WLLB;
                node.Gc = model.MES_TM_TMINFO_LIST[0].GC;
                node.Tltmid = model.MES_TM_TMINFO_LIST[x].TLTMID;
                //node.Tmid = model.MES_TM_TMINFO_LIST[0].TM;
                //bool isBom = false;
                if (_bomList.ET_BOM != null)
                {
                    for (int i = 0; i < _bomList.ET_BOM.Length; i++)
                    {

                        if (_bomList.ET_BOM[i].WLLB == node.Wllbdm)
                        {

                            BOMdataGridView.Rows[i].Cells[q(Msg_Type.fieldstatus)].Style.BackColor = Color.FromArgb(187, 255, 102);//"状态"
                        }


                    }
                }
                else
                {

                }
               
              
                //if (isBom == false)
                //{
                //    if (MessageBox.Show("你扫描的条码不是物料的BOM组成部分！！", "消息框", MessageBoxButtons.OK) == DialogResult.OK)
                //    {
                //        SMtextBox.Clear();
                //    }

                //    return;
                //}
                bool replace = false;
                if (Tmlist.Count > 0)
                {

                    for (int i = 0; i < Tmlist.Count; i++)
                    {
                        if (node.Wllbdm == Tmlist[i].Wllbdm)
                        {
                            replace = true;
                            Tmlist[i] = node;
                        }
                    }
                    if (replace == false)
                    {
                        Tmlist.Add(node);
                    }
                }
                else
                {
                    Tmlist.Add(node);
                }
                for (int i = 0; i < Tmlist.Count; i++)
                {
                    Tmlist[i].Xh = (i + 1).ToString();
                }
                if (RigthType == Rigth_Type.mfqqingxi)
                {
                    pctextBox.Text = model.MES_TM_TMINFO_LIST[x].PC;
                }
                LSdataGridView.DataSource = Tmlist.ToList();
                LSdataGridView.ClearSelection();
                LSdataGridView.Columns[q(Msg_Type.fielddelete)].DisplayIndex = 4;//"删除"

               
               
            }
            if (first == 1)
            {
                if (model.MES_TM_TMINFO_LIST.Length == 1)
                {
                    //MessageBox.Show("投料成功！！！", "消息框");
                    ShowMeg(q(Msg_Type.msgtlsuccess), 1500);//"投料成功"
                }
            }
            
           
            SMtextBox.Clear();
            SMtextBox.Select();
        }

        private List<BomDataGrid> getBomList(ZBCFUN_GDJGXX_READ model)
        {
            IList<BomDataGrid> list = new List<BomDataGrid>();
           
            for (int i = 0; i < model.ET_BOM.Length; i++)
            {
                BomDataGrid node = new BomDataGrid();
                node.Xh = model.ET_BOM[i].POSNR;
                if (!string.IsNullOrEmpty(model.ET_BOM[i].IDNRK))
                {
                    node.Wlxx = model.ET_BOM[i].IDNRK + "/" + model.ET_BOM[i].MAKTX;
                }
                else
                {
                    node.Wlxx = "";
                }
                
                node.Wllb = model.ET_BOM[i].WLLBNAME;
                node.Wllbdm = model.ET_BOM[i].WLLB;
                if (!model.ET_BOM[i].ZSBS.Equals("Y"))
                {
                    unRequireArr.Add(i);
                }
                list.Add(node);
            }
            return list.ToList();

        }

        private void qhgdbutton_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(scrqtextBox.Text.Trim()))
            //{
            //    ShowMeg("生产日期不能为空");
            //    return;
            //}
            //if (judge.IsDate(scrqtextBox.Text.Trim()) == false)
            //{
            //    ShowMeg("生产日期格式不正确");
            //    return;
            //}
            string tm = SMtextBox.Text.Trim().ToUpper();
            MES_PD_SCRW model = new MES_PD_SCRW();
            model.SBBH = _MES_PD_SCRW_LIST.SBBH;
            model.ZPRQ = dateTimePicker1.Text.Trim();
            SELECT_MES_PD_SCRW Smodel = ServicModel.PD_SCRW.SELECT(model, getToken());
            if (Smodel.MES_PD_SCRW_LIST.Length <= 1)
            {
                //MessageBox.Show(_MES_PD_SCRW_LIST.SBH + "没有可切换的任务", "消息框");
                ShowMeg(_MES_PD_SCRW_LIST.SBH + q(Msg_Type.msgnoreplacerw));
                return;
            }
            else
            {
                frmChange_GD form = new frmChange_GD(Smodel.MES_PD_SCRW_LIST, model.SBBH,RigthType);
                form.block = RefreshRW;
                show(form);
                
                //show(form);
            }
            //SMtextBox.Select();
            for (int i = 0; i < BOMdataGridView.Rows.Count; i++)
            {
                BOMdataGridView.Rows[i].Cells[q(Msg_Type.fieldstatus)].Style.BackColor = Color.Red;//"状态"
                //for (int j = 0; j < unRequireArr.Count; j++)
                //{
                //    if (i == unRequireArr[j])
                //    {
                //        BOMdataGridView.Rows[i].Cells["状态"].Style.BackColor = Color.White;
                //    }
                //}
            }
            BOMdataGridView.ClearSelection();
            //BOMdataGridView.Columns["状态"].DefaultCellStyle.BackColor = Color.Red;
            Tmlist = new List<TMDataGrid>();
            LSdataGridView.DataSource = Tmlist;
            LSdataGridView.Columns[q(Msg_Type.fielddelete)].DisplayIndex = 4;//"删除"
            SMtextBox.Select();
           
        }
        private void dyrkbutton_Click(object sender, EventArgs e)
        {
            MsgReturn msgInfo = VerifyWLisALL();
            if (msgInfo.Pass == false)
            {
                //MessageBox.Show(msgInfo.Msg, "消息框");
                ShowMeg(msgInfo.Msg);
                SMtextBox.Select();
                return;
            }
            MsgReturn msgInfo1 = VerifyContent();
            if (msgInfo1.Pass == false)
            {
                //MessageBox.Show(msgInfo1.Msg, "消息框");
                ShowMeg(msgInfo1.Msg);
                SMtextBox.Select();
                return;
            }
            if (Convert.ToInt32(bccomboBox.SelectedValue) == 0)
            {
                //MessageBox.Show("生成领用表必须输入班次信息不能为空", "消息框");
                ShowMeg(q(Msg_Type.msgbcnoemptyforlyb));
                SMtextBox.Select();
                return;
            }
            MES_TM_TMINFO_INSERT_GL model = new MES_TM_TMINFO_INSERT_GL();
            MES_TM_TMINFO info = new MES_TM_TMINFO();
            model.MES_TM_TMINFO = info;
            model.MES_TM_TMINFO.TMLB = 1;
            model.MES_TM_TMINFO.SCDATE = dateTimePicker1.Text.Trim();
            model.MES_TM_TMINFO.BC = Convert.ToInt32(bccomboBox.SelectedValue);
            model.MES_TM_TMINFO.RWBH = MES_PD_SCRW_LIST.RWBH;
            model.MES_TM_TMINFO.PC = MES_PD_SCRW_LIST.PC;
            model.MES_TM_TMINFO.JLR = Convert.ToInt32(getUserInfo("staffid"));
            model.MES_TM_TMINFO.SL = MES_PD_SCRW_LIST.BZCOUNT;
            model.MES_TM_TMINFO.MINVALUE = MES_PD_SCRW_LIST.MINVALUE;
            model.MES_TM_TMINFO.MAXVALUE = MES_PD_SCRW_LIST.MAXVALUE;
            IList<MES_TM_GL> nodes = new List<MES_TM_GL>();

            for (int i = 0; i < Tmlist.Count; i++)
            {
                MES_TM_GL node = new MES_TM_GL();
                node.XCTM = Tmlist[i].Tm;
                node.XCTMGC = Tmlist[i].Gc;
                nodes.Add(node);
            }
            model.MES_TM_GL = nodes.ToArray();

            frmPrint_N form = new frmPrint_N(model, Print_Type.rk, RigthType);
           
            show(form);

            string printToHome = ini.IniReadValue(ini.Section_Configuration, "printTohome");
            if (printToHome.Equals("true"))
            {
                zybutton.PerformClick();
            }

            SMtextBox.Select();
        }

        private void dylotbutton_Click(object sender, EventArgs e)
        {
            ZBCFUN_GDJGXX_READ r = ServicModel.PD_GD.SAP_GET_GDJGXX(MES_PD_SCRW_LIST.RWBH, MES_PD_SCRW_LIST.ZPRQ, MES_PD_SCRW_LIST.GC, getToken());
            if (!r.MES_RETURN.TYPE.Equals("S"))
            {
                ShowMeg(r.MES_RETURN.MESSAGE);
                SMtextBox.Select();
                return;
            }
            MsgReturn msgInfo = VerifyWLisALL();
            if (msgInfo.Pass == false)
            {
                //MessageBox.Show(msgInfo.Msg, "消息框");
                ShowMeg(msgInfo.Msg);
                SMtextBox.Select();
                return;
            }
            MsgReturn msgInfo1 = VerifyContent();
            if (msgInfo1.Pass == false)
            {
                //MessageBox.Show(msgInfo1.Msg, "消息框");
                ShowMeg(msgInfo1.Msg);
                SMtextBox.Select();
                return;
            }
            if (Convert.ToInt32(bccomboBox.SelectedValue) == 0)
            {
                //MessageBox.Show("生成LOT表必须输入班次信息不能为空", "消息框");
                ShowMeg(q(Msg_Type.msgbcnoemptyforlotb));
                SMtextBox.Select();
                return;
            }
            MES_TM_TMINFO_INSERT_GL model = new MES_TM_TMINFO_INSERT_GL();
            MES_TM_TMINFO info = new MES_TM_TMINFO();
            model.MES_TM_TMINFO = info;
            model.MES_TM_TMINFO.TMLB = 1;
            model.MES_TM_TMINFO.SCDATE = dateTimePicker1.Text.Trim();
            model.MES_TM_TMINFO.BC = Convert.ToInt32(bccomboBox.SelectedValue);
            model.MES_TM_TMINFO.RWBH = MES_PD_SCRW_LIST.RWBH;
            model.MES_TM_TMINFO.SL = MES_PD_SCRW_LIST.BZCOUNT;
            if (RigthType == Rigth_Type.mfqqingxi)
            {
                model.MES_TM_TMINFO.PC = pctextBox.Text.Trim();
            }
            else
            {
                model.MES_TM_TMINFO.PC = MES_PD_SCRW_LIST.PC;
            }
            
            model.MES_TM_TMINFO.JLR = Convert.ToInt32(getUserInfo("staffid"));
            model.MES_TM_TMINFO.GC = MES_PD_SCRW_LIST.GC;
            model.MES_TM_TMINFO.SL = MES_PD_SCRW_LIST.BZCOUNT;
            model.MES_TM_TMINFO.MINVALUE = MES_PD_SCRW_LIST.MINVALUE;
            model.MES_TM_TMINFO.MAXVALUE = MES_PD_SCRW_LIST.MAXVALUE;
            IList<MES_TM_GL> nodes = new List<MES_TM_GL>();

            for (int i = 0; i < Tmlist.Count; i++)
            {
                MES_TM_GL node = new MES_TM_GL();
                node.XCTM = Tmlist[i].Tm;
                node.XCTMGC = Tmlist[i].Gc;
                nodes.Add(node);
            }
            model.MES_TM_GL = nodes.ToArray();

            frmPrint_N form = new frmPrint_N(model, Print_Type.lot, RigthType);
            show(form);

            string printToHome = ini.IniReadValue(ini.Section_Configuration, "printTohome");
            if (printToHome.Equals("true"))
            {
                zybutton.PerformClick();
            }
            //this.Close();
            for (int i = 0; i < BOMdataGridView.Rows.Count; i++)
            {
                BOMdataGridView.Rows[i].Cells[q(Msg_Type.fieldstatus)].Style.BackColor = Color.Red;//"状态"
                //for (int j = 0; j < unRequireArr.Count; j++)
                //{
                //    if (i == unRequireArr[j])
                //    {
                //        BOMdataGridView.Rows[i].Cells["状态"].Style.BackColor = Color.White;
                //    }
                //}
            }
            //BOMdataGridView.Columns["状态"].DefaultCellStyle.BackColor = Color.Red;
            Tmlist = new List<TMDataGrid>();
            LSdataGridView.DataSource = Tmlist;
            LSdataGridView.Columns[q(Msg_Type.fielddelete)].DisplayIndex = 4;//"删除"
            SMtextBox.Select();
        }

        private void qhsbhbutton_Click(object sender, EventArgs e)
        {
            
            MES_SY_GZZX_SBH model = new MES_SY_GZZX_SBH();
            model.GZZXBH = Convert.ToString(getUserInfo("gzzxvalue"));
            model.GC = getGC("value");
            model.WLLBNAME = GetWLLBName(RigthType);
            MES_SY_GZZX_SBH[] list = ServicModel.SY_GZZX_SBH.SELECT(model, getToken());
            string ms = "";
            if (list.Length > 0)
            {
                ms = list[0].GZZXBH + "-" + list[0].GZZXMS;
            }
            frmFindSBH form = new frmFindSBH(list, ms,RigthType,true);

            push(form,this);
        }

        private void frmTL2_Load(object sender, EventArgs e)
        {
            //dataGridView1.ClearSelection();
            BOMdataGridView.ClearSelection();
            LSdataGridView.ClearSelection();
        }

        private void LSdataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (this.LSdataGridView.CurrentCell.OwningColumn.Name == q(Msg_Type.fielddelete))//"删除"
                {

                    int tmtmid = Convert.ToInt32(this.LSdataGridView.CurrentRow.Cells[q(Msg_Type.fieldtltmdm)].Value);//"投料条码代码"
                    //MES_RETURN_UI res = ServicModel.PD_TLGL.DELETE(tmtmid, getToken());
                    //if (res.TYPE.Equals("S"))
                    //{
                        int id = Convert.ToInt32(this.LSdataGridView.CurrentRow.Cells[q(Msg_Type.fieldxh)].Value);//"序号"
                        Tmlist.RemoveAt(id - 1);
                        for (int i = 0; i < Tmlist.Count; i++)
                        {
                            Tmlist[i].Xh = (i + 1).ToString();
                        }
                        int a = LSdataGridView.Columns.Count;
                        if (Tmlist.Count == 0)
                        {
                            LSdataGridView.DataSource = new List<TMDataGrid>();
                            LSdataGridView.Columns[q(Msg_Type.fielddelete)].DisplayIndex = 4;//"删除"


                        }
                        else
                        {
                            LSdataGridView.DataSource = Tmlist.ToArray();
                            LSdataGridView.Columns[q(Msg_Type.fielddelete)].DisplayIndex = 4;//
                        }
                        LSdataGridView.ClearSelection();


                        //BOMdataGridView.Rows[0].Cells["状态"].Style.BackColor = Color.Red;
                        //BOMdataGridView.Rows[1].Cells["状态"].Style.BackColor = Color.Red;
                        //for (int i = 0; i < unRequireArr.Count; i++)
                        //{
                        //    BOMdataGridView.Rows[unRequireArr[i]].Cells["状态"].Style.BackColor = Color.White;
                        //}
                        for (int i = 0; i < BOMdataGridView.Rows.Count; i++)
                        {
                            BOMdataGridView.Rows[i].Cells[q(Msg_Type.fieldstatus)].Style.BackColor = Color.Red;//"状态"
                            for (int j = 0; j < unRequireArr.Count; j++)
                            {
                                if (i == unRequireArr[j])
                                {
                                    BOMdataGridView.Rows[i].Cells[q(Msg_Type.fieldstatus)].Style.BackColor = Color.White;//"状态"
                                }
                            }
                        }


                        for (int i = 0; i < _bomList.ET_BOM.Length; i++)
                        {
                            for (int j = 0; j < Tmlist.Count; j++)
                            {
                                //if (_bomList.ET_BOM[i].ZSBS.Equals("Y"))
                                //{
                                //    if (_bomList.ET_BOM[i].IDNRK == Tmlist[j].Wlxx.Split('/')[0])
                                //    {

                                //        BOMdataGridView.Rows[i].Cells["状态"].Style.BackColor = Color.FromArgb(187, 255, 102);
                                //    }
                                //}
                                //else
                                //{
                                if (_bomList.ET_BOM[i].WLLB == Tmlist[j].Wllbdm)
                                {
                                    BOMdataGridView.Rows[i].Cells[q(Msg_Type.fieldstatus)].Style.BackColor = Color.FromArgb(187, 255, 102);//"状态"
                                }
                                //}


                            }

                        }





                    //}
                    //else
                    //{
                    //    MessageBox.Show(res.MESSAGE, "消息框");
                    //}


                }
            }
           

        }

        private void SCRQmonthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            //scrqtextBox.Text = Convert.ToDateTime(SCRQmonthCalendar.SelectionStart.ToShortDateString()).ToString("yyyy-MM-dd");
            //SCRQmonthCalendar.Visible = false;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(dateTimePicker1.Text.Trim()))
            //{
            //    if (!Convert.ToDateTime(dateTimePicker1.Text.Trim()).ToString("yyyy-MM-dd").Equals(LastDate))
            //    {
            //        MES_PD_SCRW model = new MES_PD_SCRW();
            //        model.SBBH = MES_PD_SCRW_LIST.SBBH;
            //        model.ZPRQ = dateTimePicker1.Text.Trim();
            //        SELECT_MES_PD_SCRW Smodel = ServicModel.PD_SCRW.SELECT(model, getToken());
            //        if (Smodel.MES_RETURN.TYPE.Equals("S"))
            //        {
            //            if (Smodel.MES_PD_SCRW_LIST.Length == 1)
            //            {
            //                LastDate = dateTimePicker1.Text.Trim();
            //                RefreshRW(Smodel.MES_PD_SCRW_LIST[0], model.SBBH);
                            
            //            }
            //            else if (Smodel.MES_PD_SCRW_LIST.Length > 1)
            //            {
            //                LastDate = dateTimePicker1.Text.Trim();
            //                frmChange_GD form = new frmChange_GD(Smodel.MES_PD_SCRW_LIST, model.SBBH, RigthType);
            //                form.block = RefreshRW;
            //                show(form);

                           
            //            }
            //            else
            //            {
            //                MessageBox.Show(_MES_PD_SCRW_LIST.SBH + "没有可切换的任务", "消息框");
            //                return;
            //            }
            //        }
            //        else
            //        {
            //            ShowMeg(Smodel.MES_RETURN.MESSAGE);
            //        }
                   
            //    }
            //}
        }

        private void rzbutton_Click(object sender, EventArgs e)
        {
            frmLotLog form = new frmLotLog(RigthType, MES_PD_SCRW_LIST.SBBH, MES_PD_SCRW_LIST.RWBH, MES_PD_SCRW_LIST.WLLB);
            show(form);
            SMtextBox.Select();
        }

        private void bccomboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            SMtextBox.Select();
        }

        private void dateTimePicker1_CloseUp(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(dateTimePicker1.Text.Trim()))
            {
                //if (!Convert.ToDateTime(dateTimePicker1.Text.Trim()).ToString("yyyy-MM-dd").Equals(LastDate))
                //{
                    MES_PD_SCRW model = new MES_PD_SCRW();
                    model.SBBH = MES_PD_SCRW_LIST.SBBH;
                    model.ZPRQ = dateTimePicker1.Text.Trim();
                    SELECT_MES_PD_SCRW Smodel = ServicModel.PD_SCRW.SELECT(model, getToken());
                    if (Smodel.MES_RETURN.TYPE.Equals("S"))
                    {
                        if (Smodel.MES_PD_SCRW_LIST.Length == 1)
                        {
                            LastDate = dateTimePicker1.Text.Trim();
                            RefreshRW(Smodel.MES_PD_SCRW_LIST[0], model.SBBH);

                        }
                        else if (Smodel.MES_PD_SCRW_LIST.Length > 1)
                        {
                            LastDate = dateTimePicker1.Text.Trim();
                            frmChange_GD form = new frmChange_GD(Smodel.MES_PD_SCRW_LIST, model.SBBH, RigthType);
                            form.block = RefreshRW;
                            show(form);


                        }
                        else
                        {
                            //MessageBox.Show(_MES_PD_SCRW_LIST.SBH + "没有可切换的任务", "消息框");
                            ShowMeg(_MES_PD_SCRW_LIST.SBH + q(Msg_Type.msgnoreplacerw));
                            return;
                        }
                    }
                    else
                    {
                        ShowMeg(Smodel.MES_RETURN.MESSAGE);
                    }
                    SMtextBox.Select();
                //}
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void gzzxtextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void czrytextBox_TextChanged(object sender, EventArgs e)
        {

        }
       


    }
}