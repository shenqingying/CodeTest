using Sonluk.MES.MES.Base;
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
    public partial class frmBaozhuang : baseview
    {
        #region property
        string _tpm;

        public string Tpm
        {
            get { return _tpm; }
            set { _tpm = value; }
        }
        bool _isTMP;

        public bool IsTMP
        {
            get { return _isTMP; }
            set { _isTMP = value; }
        }
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
        #endregion
        public frmBaozhuang()
        {
            InitializeComponent();
            
        }
        public frmBaozhuang(MES_PD_SCRW_LIST list, string shebeihaoID, Rigth_Type rtype, string sbh,string tpm){
            InitializeComponent();
            Tpm = tpm;
            Init(list, shebeihaoID, rtype, sbh);

            getTPMinfo(tpm);
        }
       
        public frmBaozhuang(MES_PD_SCRW_LIST list, string shebeihaoID, Rigth_Type rtype, string sbh)
        {
            InitializeComponent();
            Init(list, shebeihaoID, rtype, sbh);
           
            
            
        }
        public void Init(MES_PD_SCRW_LIST list, string shebeihaoID, Rigth_Type rtype, string sbh){
            unRequireArr = new List<int>();
            MES_PD_SCRW_LIST = list;
            this.Text = GetFormName(rtype);
            IsTMP = false;
            bingLSdatagridView();
            bingBomdatagridView();
            RigthType = rtype;
            SMtextBox.Select();
            SBHID = shebeihaoID;
            MES_SY_TYPEMX bcmodel = new MES_SY_TYPEMX();
            bcmodel.GC = Convert.ToString(getGC("value"));
            bcmodel.TYPEID = 5;
            //MES_SY_TYPEMXLIST[] bclist = ServicModel.SY_TYPEMX.SELECT(bcmodel, getToken());
            //bccomboBox.DisplayMember = "MXNAME";
            //bccomboBox.ValueMember = "ID";
            //bccomboBox.DataSource = bclist;
            //scrqtextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            Tmlist = new List<TMDataGrid>();
            if (list.RWBH == null)
            {
                gzzxtextBox.Text = getUserInfo("gzzxtext");
                gctextBox.Text = getGC("text");
                sbhtextBox.Text = sbh;
            }
            else
            {
                //this._MES_PD_SCRW_LIST = list;
                //configUI(list);
                                  
            }
        }
        public void configUI(MES_PD_SCRW_LIST list)
        {
            MES_PD_SCRW_LIST = list;
            MES_TM_CZR rymodel = new MES_TM_CZR();
            rymodel.GC = list.GC;
            rymodel.RWBH = list.RWBH;
            rymodel.CZLB = 1;
            _czrList = ServicModel.TM_CZR.SELECT_CZR_NOW(rymodel, getToken());
            _bomList = ServicModel.PD_GD.SAP_GET_GDJGXX(list.RWBH, list.ZPRQ, list.GC, getToken());
           

            //List<MES_SY_TYPEMXLIST> bcArr = new List<MES_SY_TYPEMXLIST>();

            gzzxtextBox.Text = list.GZZXBH + "-" + list.GZZXNAME;
            czrytextBox.Text = _czrList.CZR;
            gctextBox.Text = list.GC;
            sbhtextBox.Text = list.SBH;
            //pctextBox.Text = list.PC;
            //if (list.BC != 0)
            //{
            //    bccomboBox.SelectedValue = list.BC;
            //}            
            MESlabel.Text = q(Msg_Type.titlemesgd) +list.GDDH;//"MES工单:"
            GDHlabel.Text = q(Msg_Type.titlegd) +list.ERPNO;//"工单号:"
            WLXXlabel.Text = q(Msg_Type.titlewlxx) + list.WLH + "/" + list.WLMS;//物料信息:
            WLLBlabel1.Text = q(Msg_Type.titlewllb) +list.WLLBNAME;//"物料类别:"
            rwdlabel.Text = q(Msg_Type.titlerwd) +list.RWBH;//"任务单:"
            tpmlabel.Text = q(Msg_Type.titletpm) + Tpm;//
            //Tpm = SMtextBox.Text.Trim();
            //dcdjlabel.Text = "电池等级:" + list.DCDJNAME;
            //dcxhlabel1.Text = "电池型号:" + list.DCXHNAME;
            if (!string.IsNullOrEmpty(list.XSNOBILL) && !string.IsNullOrEmpty(list.XSNOBILLMX))
            {
                tskclabel1.Text = q(Msg_Type.titletskc) +list.XSNOBILL + "-" + list.XSNOBILLMX;//"特殊库存:"
            }
            else
            {
                tskclabel1.Text = q(Msg_Type.titletskc);
            }


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
            for (int i = 0; i < BOMdataGridView.Rows.Count; i++)
            {
                BOMdataGridView.Rows[i].Cells[q(Msg_Type.fieldstatus)].Style.BackColor = Color.Red;
                for (int j = 0; j < unRequireArr.Count; j++)
                {
                    if (i == unRequireArr[j])
                    {
                        BOMdataGridView.Rows[i].Cells[q(Msg_Type.fieldstatus)].Style.BackColor = Color.White;
                    }
                }
            }
            BOMdataGridView.ClearSelection();
        }
        public void bingBomdatagridView()
        {

            string[] cols = { q(Msg_Type.fieldxh), q(Msg_Type.fieldwlxx), q(Msg_Type.fieldwllb), q(Msg_Type.fieldwllbdm), q(Msg_Type.fieldstatus) };//"序号", "物料信息", "物料类别", "物料类别代码", "状态" 
            string[] colss = { "Xh", "Wlxx", "Wllb", "Wllbdm", "zt" };
            string[] vcol = { q(Msg_Type.fieldwllbdm) };
            DataGridBuild1(cols, colss, BOMdataGridView, vcol);
        }
        public void DataGridBuild1(string[] cols, string[] colss, DataGridView datagridGiew, string[] vcols)
        {
            for (int i = 0; i < cols.Length; i++)
            {
                DataGridViewTextBoxColumn acCode = new DataGridViewTextBoxColumn();
                acCode.Name = cols[i];
                acCode.DataPropertyName = colss[i];
                acCode.HeaderText = cols[i];

                if (cols[i] == q(Msg_Type.fieldwlxx)){
                    acCode.Width = 460;
                    acCode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
                   
                else if (cols[i] == q(Msg_Type.fieldgdxx)){
                    acCode.Width = 300;
                    acCode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                    
                else{
                    acCode.Width = 130;
                    acCode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                    
                if (vcols.Count(p => p == cols[i]) > 0)
                {
                    acCode.Visible = false;
                }

                datagridGiew.Columns.Add(acCode);


            }
            datagridGiew.RowTemplate.Height = 35;
            datagridGiew.RowTemplate.DefaultCellStyle.Font = new Font(q(Msg_Type.fonttype), 11);
            datagridGiew.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //datagridGiew.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            foreach (DataGridViewColumn item in datagridGiew.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        public void bingLSdatagridView()
        {
            string[] cols = { q(Msg_Type.fieldxh), q(Msg_Type.fieldtm), q(Msg_Type.fieldwlxx), q(Msg_Type.fieldwllb), q(Msg_Type.fielddelete), q(Msg_Type.fieldwllbdm), q(Msg_Type.fieldtmdm), q(Msg_Type.fieldgc), q(Msg_Type.fieldtltmdm) };
                                        // "序号", "条码", "物料信息", "物料类别", "删除", "物料类别代码", "条码代码", "工厂", "投料条码代码" 
            string[] colss = { "Xh", "Tm", "Wlxx", "Wllb", "del", "Wllbdm", "tmid", "gc","tltmid" };
            string[] vcols = { q(Msg_Type.fieldwllbdm), q(Msg_Type.fieldtmdm), q(Msg_Type.fieldgc), q(Msg_Type.fieldtltmdm) };
            for (int i = 0; i < cols.Length; i++)
            {
                //DataGridViewButtonColumn
                if (cols[i] == "XXXXXX")
                {

                   
                }
                else if (cols[i] == q(Msg_Type.fielddelete) )
                {
                    DataGridViewButtonColumn acCode = new DataGridViewButtonColumn();
                    acCode.Name = cols[i];
                    acCode.UseColumnTextForButtonValue = true;
                    acCode.Text = cols[i];
                    acCode.HeaderText = cols[i];
                    LSdataGridView.Columns.Add(acCode);
                }
                else
                {
                    DataGridViewTextBoxColumn acCode = new DataGridViewTextBoxColumn();
                    acCode.Name = cols[i];
                    acCode.DataPropertyName = colss[i];
                    acCode.HeaderText = cols[i];
                    
                    if (cols[i] == q(Msg_Type.fieldwlxx))
                        acCode.Width = 460;
                    else if (cols[i] == q(Msg_Type.fieldxh))
                    {
                        acCode.Width = 50;
                    }
                    else
                        acCode.Width = 130;
                    //判断不显示的在 全部字段里面有没有 有的话 就隐藏该字段
                    if (vcols.Count(p => p == cols[i]) > 0)
                    {
                        acCode.Visible = false;
                    }
                    LSdataGridView.Columns.Add(acCode);
                }

            }
            LSdataGridView.RowTemplate.Height = 35;
            LSdataGridView.RowTemplate.DefaultCellStyle.Font = new Font(q(Msg_Type.fonttype), 11);
            LSdataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            LSdataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            foreach (DataGridViewColumn item in LSdataGridView.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            //LSdataGridView.Sort;
        }

        private void SMtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

      

        private void ryglbutton_Click(object sender, EventArgs e)
        {
            if (IsTMP)
            {
                frmManagerRY fomr = new frmManagerRY(_czrList, MES_PD_SCRW_LIST, 1);
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
            else
            {
                ShowMeg(q(Msg_Type.msgscantpm));
            }
            SMtextBox.Clear();
            SMtextBox.Select();
        }

        private void button2_Click(object sender, EventArgs e)
        {

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
            if (MES_PD_SCRW_LIST != null)
            {
                BOMdataGridView.Columns[q(Msg_Type.fieldstatus)].DefaultCellStyle.BackColor = Color.Red;
                for (int i = 0; i < unRequireArr.Count; i++)
                {
                    BOMdataGridView.Rows[unRequireArr[i]].Cells[q(Msg_Type.fieldstatus)].Style.BackColor = Color.White;
                }
                //getTMList(ServicModel.TM_TMINFO.SELECT_TL_LAST(MES_PD_SCRW_LIST.RWBH, getToken()));
            }
           
         

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
            if (type != TM_Type.tpm)
            {
                if (!IsTMP)
                {
                    ShowMeg(q(Msg_Type.msgscantpm));
                    SMtextBox.Clear();
                    SMtextBox.Select();
                    return;
                }
            }
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
                    //getGDinfo();
                    break;
                case TM_Type.ph:
                   
                    getReportInfoByTm();
                    break;
                case TM_Type.tpm:
                    getTPMinfo(SMtextBox.Text.Trim().ToUpper());
                    break;
                default:
                    //MessageBox.Show("你扫描的是无效的条码！！", "消息框");
                    ShowMeg(q(Msg_Type.msgscantminvalid));
                    break;
            }
            SMtextBox.Clear();
            SMtextBox.Select();

        }
        public void getTPMinfo(string tpm)
        {
            MES_PD_SCRW_GET_BY_TPM model = new MES_PD_SCRW_GET_BY_TPM();
            model.JLR =Convert.ToInt32(getUserInfo("staffid"));
            model.TPM = tpm;
            model.GC = getGC("value");
            model.GZZXBH = getUserInfo("gzzxvalue");
            model.SBBH = SBHID;
            SELECT_MES_PD_SCRW res = ServicModel.PD_SCRW.GET_RWBH_BY_TPM(model,getToken());
            if (res.MES_RETURN.TYPE.Equals("S"))
            {
                IsTMP = true;
                if (!string.IsNullOrEmpty(SMtextBox.Text.Trim()))
                {
                    Tpm = SMtextBox.Text.Trim();
                }
                configUI(res.MES_PD_SCRW_LIST[0]);
            }
            else
            {
                ShowMeg(res.MES_RETURN.MESSAGE);
            }
        }
       
        public void getReportInfoByTm()
        {
            //if (IsTMP)
            //{
                MES_TM_TMINFO model = new MES_TM_TMINFO();
                model.GC = this._MES_PD_SCRW_LIST.GC;
                model.TM = SMtextBox.Text.Trim().ToUpper();
                model.RWBH = this._MES_PD_SCRW_LIST.RWBH;
                model.JLR = Convert.ToInt32(getUserInfo("staffid"));          
                SELECT_MES_TM_TMINFO_BYTM res = ReadphTM(model, 1);
                if (res.MES_RETURN.TYPE.Equals("S"))
                {
                    getTMList(res);
                }
                else
                {
                    //MessageBox.Show(SMtextBox.Text + res.MES_RETURN.MESSAGE, "消息框");
                    ShowMeg(SMtextBox.Text + res.MES_RETURN.MESSAGE);
                }
            //}
            //else
            //{
            //    ShowMeg("请先扫描托盘码");
            //}
            
            SMtextBox.Clear();
            SMtextBox.Select();

        }
        public void getCzrInfo()
        {
            //if (IsTMP == false)
            //{
            //    ShowMeg("请先扫描托盘码");
            //}
            //else
            //{
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
            //}
           
            SMtextBox.Clear();
            SMtextBox.Select();
        }
        public MsgReturn VerifyWLisALL()
        {
            MsgReturn msgInfo = new MsgReturn();
            msgInfo.Pass = false;
            if (BomList != null)
            {
                //msgInfo.Msg = "生成物料的相关BOM物料不齐全,请查看需要添加的物料";
                msgInfo.Msg = q(Msg_Type.msgbomunfinish);
                int bomcount = 0;
                int tmcount = 0;
                ZBCFUN_GDJGXX_READ judge = BomList;

                List<ET_BOM> list1 = new List<ET_BOM>();
               
                for (int i = 0; i < BomList.ET_BOM.Length; i++)
                {
                    if (list1.Exists(x => x.WLLB == BomList.ET_BOM[i].WLLB) == false)
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
            }
            else
            {
                msgInfo.Msg = q(Msg_Type.msgscantpmforgl);//"请先扫描托盘码信息带出需要关联的BOM相关信息";
            }
           
            return msgInfo;
        }
        public MsgReturn VerifyContent()
        {
            MsgReturn msgInfo = new MsgReturn();
            msgInfo.Pass = true;
            //if (string.IsNullOrEmpty(Convert.ToString(bccomboBox.SelectedValue)))
            //{
            //    msgInfo.Msg = "班次信息不能为空";
            //    msgInfo.Pass = false;
            //}
            if (string.IsNullOrEmpty(czrytextBox.Text.Trim()))
            {
                msgInfo.Msg = q(Msg_Type.msgczrnotempty);//"操作人员信息不能为空";msgczrnotempty
                msgInfo.Pass = false;
            }
          
            return msgInfo;
        }

       
        private void getTMList(SELECT_MES_TM_TMINFO_BYTM model)
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
                    SMtextBox.Select();
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
                bool isBom = false;
                for (int i = 0; i < _bomList.ET_BOM.Length; i++)
                {
                    //if (_bomList.ET_BOM[i].ZSBS.Equals("Y"))
                    //{

                    //    if (_bomList.ET_BOM[i].IDNRK == node.Wlxx.Split('/')[0])
                    //    {
                    //        isBom = true;                            
                    //        BOMdataGridView.Rows[i].Cells["状态"].Style.BackColor = Color.FromArgb(187, 255, 102);
                    //    }
                    //}
                    //else
                    //{
                        if (_bomList.ET_BOM[i].WLLB == node.Wllbdm)
                        {
                            isBom = true;
                            BOMdataGridView.Rows[i].Cells[q(Msg_Type.fieldstatus)].Style.BackColor = Color.FromArgb(187, 255, 102);
                        }
                    //}

                }
                if (isBom == false)
                {
                    if (MessageBox.Show(q(Msg_Type.msgbominvalid), q(Msg_Type.msgtitle), MessageBoxButtons.OK) == DialogResult.OK)
                    {
                        SMtextBox.Clear();
                        SMtextBox.Select();
                    }

                    return;
                }
                bool replace = false;
                if (Tmlist.Count > 0)
                {

                    for (int i = 0; i < Tmlist.Count; i++)
                    {
                        if (node.Tm == Tmlist[i].Tm)
                        {
                            replace = true;
                            
                        }
                    }
                    if (replace == false)
                    {
                        Tmlist.Add(node);
                    }
                    else
                    {
                        //ShowMeg("条码" + SMtextBox.Text + "不允许重复添加");
                        ShowMeg(string.Format(q(Msg_Type.msgtmcf), SMtextBox.Text));
                        return;
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
                LSdataGridView.DataSource = Tmlist.ToList();
                LSdataGridView.ClearSelection();
                LSdataGridView.Columns[q(Msg_Type.fielddelete)].DisplayIndex = 4;             
            }
            if (model.MES_TM_TMINFO_LIST.Length == 1)
            {
                //MessageBox.Show("投料成功！！！", "消息框");
                ShowMeg(q(Msg_Type.msgtlsuccess), 1500);
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
                node.Wlxx = model.ET_BOM[i].IDNRK + "/" + model.ET_BOM[i].MAKTX;
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
           
            MES_PD_SCRW model = new MES_PD_SCRW();
            model.SBBH = _MES_PD_SCRW_LIST.SBBH;
            
            SELECT_MES_PD_SCRW Smodel = ServicModel.PD_SCRW.SELECT(model, getToken());
            if (Smodel.MES_PD_SCRW_LIST.Length == 1)
            {
                //MessageBox.Show(_MES_PD_SCRW_LIST.SBH + "的当天任务派单只有一个", "消息框");
                ShowMeg(_MES_PD_SCRW_LIST.SBH + q(Msg_Type.msgdayrwonlyone));
                return;
            }
            else
            {
                frmChange_GD form = new frmChange_GD(Smodel.MES_PD_SCRW_LIST, model.SBBH,RigthType);
                show(form);
                this.Close();
            }
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
            //if (Convert.ToInt32(bccomboBox.SelectedValue) == 190)
            //{
            //    MessageBox.Show("生成领用表必须输入班次信息不能为空", "消息框");
            //    return;
            //}
            MES_TM_TMINFO_INSERT_GL model = new MES_TM_TMINFO_INSERT_GL();
            MES_TM_TMINFO info = new MES_TM_TMINFO();
            model.MES_TM_TMINFO = info;
            model.MES_TM_TMINFO.TMLB = 1;         
            //model.MES_TM_TMINFO.BC = Convert.ToInt32(bccomboBox.SelectedValue);
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
            //this.Close();
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
            if (!IsTMP)
            {
                //ShowMeg("请先扫描托盘码");
                ShowMeg(q(Msg_Type.msgscantpm));
            }
            else
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
                if (string.IsNullOrEmpty(Tpm))
                {
                    //ShowMeg("托盘码信息不能为空");
                    ShowMeg(q(Msg_Type.msgtpmnoempty));
                }
                //if (Convert.ToInt32(bccomboBox.SelectedValue) == 0)
                //{
                //    MessageBox.Show("生成领用表必须输入班次信息不能为空", "消息框");
                //    return;
                //}
                MES_TM_TMINFO_INSERT_GL model = new MES_TM_TMINFO_INSERT_GL();
                MES_TM_TMINFO info = new MES_TM_TMINFO();
                model.MES_TM_TMINFO = info;
                model.MES_TM_TMINFO.TMLB = 1;
                //model.MES_TM_TMINFO.BC = Convert.ToInt32(bccomboBox.SelectedValue);
                model.MES_TM_TMINFO.RWBH = MES_PD_SCRW_LIST.RWBH;
                model.MES_TM_TMINFO.PC = MES_PD_SCRW_LIST.PC;
                model.MES_TM_TMINFO.JLR = Convert.ToInt32(getUserInfo("staffid"));
                model.MES_TM_TMINFO.GC = MES_PD_SCRW_LIST.GC;
                model.MES_TM_TMINFO.SL = MES_PD_SCRW_LIST.SL;
                model.MES_TM_TMINFO.TPM = Tpm;
                model.MES_TM_TMINFO.TMCOUNT = 1;
                model.MES_TM_TMINFO.MAC = DeviceInfo.GetNetCardMAC().Substring(0, 17);
                //model.MES_TM_TMINFO.TMSX = Print_Type.
                IList<MES_TM_GL> nodes = new List<MES_TM_GL>();

                for (int i = 0; i < Tmlist.Count; i++)
                {
                    MES_TM_GL node = new MES_TM_GL();
                    node.XCTM = Tmlist[i].Tm;
                    node.XCTMGC = Tmlist[i].Gc;
                    nodes.Add(node);
                }
                model.MES_TM_GL = nodes.ToArray();
               
                Sonluk.UI.Model.MES.TM_TMINFOService.MES_TM_TMINFO_INSERT_RETURN res = ServicModel.TM_TMINFO.INSERT(model,0, getToken());
                if (res.MES_RETURN.TYPE.Equals("S"))
                {
                    //ShowMeg("关联成功", 1500);
                    ShowMeg(q(Msg_Type.msgglsuccess),1500);
                    //if (MessageBox.Show("关联成功", "消息框", MessageBoxButtons.OK) == DialogResult.OK)
                    //{                   
                    string printToHome = ini.IniReadValue(ini.Section_Configuration, "printTohome");
                    if (printToHome.Equals("true"))
                    {
                        zybutton.PerformClick();
                    }
                    IsTMP = false;
                    BomList = new ZBCFUN_GDJGXX_READ();
                    List<BomDataGrid> list = new List<BomDataGrid>();
                    BOMdataGridView.DataSource = list;
                    BomList = null;
                    Tmlist = new List<TMDataGrid>();
                    LSdataGridView.DataSource = Tmlist.ToList();
                    LSdataGridView.ClearSelection();
                    LSdataGridView.Columns[q(Msg_Type.fielddelete)].DisplayIndex = 4;
                    MES_PD_SCRW_LIST = new MES_PD_SCRW_LIST();
                    MESlabel.Text = q(Msg_Type.titlemesgd) + MES_PD_SCRW_LIST.GDDH;
                    GDHlabel.Text = q(Msg_Type.titlegd) + MES_PD_SCRW_LIST.ERPNO;
                    WLXXlabel.Text = q(Msg_Type.titlewlxx);
                    WLLBlabel1.Text = q(Msg_Type.titlewllb) + MES_PD_SCRW_LIST.WLLBNAME;
                    rwdlabel.Text = q(Msg_Type.titlerwd) + MES_PD_SCRW_LIST.RWBH;
                    tpmlabel.Text = q(Msg_Type.titletpm);//"托盘码:";
                    Tpm = SMtextBox.Text.Trim();
                    //dcdjlabel.Text = "电池等级:" + list.DCDJNAME;
                    //dcxhlabel1.Text = "电池型号:" + list.DCXHNAME;
                    if (!string.IsNullOrEmpty(MES_PD_SCRW_LIST.XSNOBILL) && !string.IsNullOrEmpty(MES_PD_SCRW_LIST.XSNOBILLMX))
                    {
                        tskclabel1.Text = q(Msg_Type.titletskc) + MES_PD_SCRW_LIST.XSNOBILL + "-" + MES_PD_SCRW_LIST.XSNOBILLMX;
                    }
                    else
                    {
                        tskclabel1.Text = q(Msg_Type.titletskc);
                    }
                    //}
                }
                else
                {
                    ShowMeg(res.MES_RETURN.MESSAGE);
                }
            }
            
            SMtextBox.Select();
        }

        private void qhsbhbutton_Click(object sender, EventArgs e)
        {
            
            MES_SY_GZZX_SBH model = new MES_SY_GZZX_SBH();
            model.GZZXBH = Convert.ToString(getUserInfo("gzzxvalue"));
            model.WLLBNAME = GetWLLBName(RigthType);
            model.GC = getGC("value");
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
            BOMdataGridView.ClearSelection();
            LSdataGridView.ClearSelection();
        }

        private void LSdataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (this.LSdataGridView.CurrentCell.OwningColumn.Name == q(Msg_Type.fielddelete))
                {

                    int tmtmid = Convert.ToInt32(this.LSdataGridView.CurrentRow.Cells[q(Msg_Type.fieldtltmdm)].Value);
                    //MES_RETURN_UI res = ServicModel.PD_TLGL.DELETE(tmtmid, getToken());
                    //if (res.TYPE.Equals("S"))
                    //{
                    int id = Convert.ToInt32(this.LSdataGridView.CurrentRow.Cells[q(Msg_Type.fieldxh)].Value);
                        Tmlist.RemoveAt(id - 1);
                        for (int i = 0; i < Tmlist.Count; i++)
                        {
                            Tmlist[i].Xh = (i + 1).ToString();
                        }
                        int a = LSdataGridView.Columns.Count;
                        if (Tmlist.Count == 0)
                        {
                            LSdataGridView.DataSource = new List<TMDataGrid>();
                            LSdataGridView.Columns[q(Msg_Type.fielddelete)].DisplayIndex = 4;


                        }
                        else
                        {
                            LSdataGridView.DataSource = Tmlist.ToArray();
                            LSdataGridView.Columns[q(Msg_Type.fielddelete)].DisplayIndex = 4;
                        }

                        for (int i = 0; i < BOMdataGridView.Rows.Count; i++)
                        {
                            BOMdataGridView.Rows[i].Cells[q(Msg_Type.fieldstatus)].Style.BackColor = Color.Red;
                            for (int j = 0; j < unRequireArr.Count; j++)
                            {
                                if (i == unRequireArr[j])
                                {
                                    BOMdataGridView.Rows[i].Cells[q(Msg_Type.fieldstatus)].Style.BackColor = Color.White;
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
                                    BOMdataGridView.Rows[i].Cells[q(Msg_Type.fieldstatus)].Style.BackColor = Color.FromArgb(187, 255, 102);
                                }
                                //}


                            }

                        }
                        LSdataGridView.ClearSelection();
                        BOMdataGridView.ClearSelection();
                    //}
                    //else
                    //{
                    //    MessageBox.Show(res.MESSAGE, "消息框");
                    //}


                }
            }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MES_SY_GZZX_SBH model = new MES_SY_GZZX_SBH();
            //model.GZZXBH = Convert.ToString(getUserInfo("gzzxvalue"));
            model.GC = getGC("value");
            model.WLLBNAME = GetWLLBName(RigthType);
            MES_SY_GZZX_SBH[] list = ServicModel.SY_GZZX_SBH.SELECT(model, getToken());
            frmFindSBH form = new frmFindSBH(list, getUserInfo("gzzxtext"), RigthType,true);

            push(form,this);
        }
    }
}
