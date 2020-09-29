using Sonluk.MES.MES.Base;
using Sonluk.UI.Model.MES.PD_GDService;
using Sonluk.UI.Model.MES.PD_SCRWService;
using Sonluk.UI.Model.MES.PD_TLGLService;
using Sonluk.UI.Model.MES.SY_GCService;
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
    public partial class frmZX_TL : baseview
    {
        bool showTime = false;
        MES_PD_TL_LIST[] _jlList;

        public MES_PD_TL_LIST[] JlList
        {
            get { return _jlList; }
            set { _jlList = value; }
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
        string _lastDate;

        public string LastDate
        {
            get { return _lastDate; }
            set { _lastDate = value; }
        }
        public frmZX_TL()
        {
            InitializeComponent();
        }
        public frmZX_TL(MES_PD_SCRW_LIST list, string shebeihaoID,Rigth_Type rtype)
        {
            InitializeComponent();
            RigthType = rtype;
            //if (RigthType == Rigth_Type.zhuxiantl)
            //{
            //    sbhbutton.Visible = false;
            //    qhgdbutton.Location = sbhbutton.Location;
                
            //}
            //monthCalendar1.Visible = false;
            //scrqtextBox.Text = DateTime.Now.ToString("yyyy-MM-dd"); 
            SMtextBox.Select();
            SBHID = shebeihaoID;
            Tmlist = new List<TMDataGrid>();
            this._MES_PD_SCRW_LIST = list;
            if (MES_PD_SCRW_LIST.GC.Equals("8020"))
            {
                showTime = true;
            }
            
        }
        private List<BomDataGrid> getBomList(ZBCFUN_GDJGXX_READ model)
        {
            BOMdataGridView.DataSource = new List<BomDataGrid>();
            List<BomDataGrid> list = new List<BomDataGrid>();
            if (model.ET_BOM == null || model.ET_BOM.Length == 0)
            {
                ShowMeg(q(Msg_Type.msgrwunexistbom));//"任务对应BOM为空,请联系管理员"
                SMtextBox.Select();
                return new List<BomDataGrid>();
            }
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
        public void configBom()
        {
            string[] cols = {q(Msg_Type.fieldxh),q(Msg_Type.fieldwlxx),q(Msg_Type.fieldwllb),q(Msg_Type.fieldwllbdm) };//"序号", "物料信息", "物料类别", "物料类别代码"
            string[] colss = { "Xh", "Wlxx", "Wllb", "Wllbdm"};
            string[] vcol = {q(Msg_Type.fieldwllbdm) };//"物料类别代码" 
            ConfigDataGrid(cols, colss, BOMdataGridView, vcol);
        }
        public void ConfigJsDataGridView()
        {
            //string[] cols = {q(Msg_Type.fieldxh),q(Msg_Type.fieldtm),q(Msg_Type.fieldwlxx),q(Msg_Type.fieldwllb),q(Msg_Type.fieldtlsj),q(Msg_Type.fieldmodify),q(Msg_Type.fielddelete) };
            //                        //"序号", "条码", "物料信息", "物料类别", "投料时间", "修改", "删除"
            //string[] colss = { "xh", "tm", "wlxx", "wllb", "tlsj", "del", "xggw" };
            string[] cols = { q(Msg_Type.fieldxh), q(Msg_Type.fieldtm), q(Msg_Type.fieldwlxx), q(Msg_Type.fieldwllb), q(Msg_Type.fieldtlsj), q(Msg_Type.fieldmodify), q(Msg_Type.fielddelete) };
            //"序号", "条码", "物料信息", "物料类别", "投料时间", "修改", "删除"
            string[] colss = { "xh", "tm", "wlxx", "wllb", "tlsj",  "del", "xggw" };
            string[] vcols = {  };
            List<string> vcolsList = new List<string>();
            if (!showTime)
            {
                vcolsList.Add(q(Msg_Type.fieldtlsj));
            }



            ConfigDataGrid(cols, colss, LSdataGridView, vcolsList.ToArray());
            UpdateJSDataGrid(MES_PD_SCRW_LIST.RWBH);
        }
        public void UpdateJSDataGrid(string rwbh)
        {
            Sonluk.UI.Model.MES.PD_TLGLService.MES_PD_TL model = new Sonluk.UI.Model.MES.PD_TLGLService.MES_PD_TL();
            model.RWBH = rwbh;
            MES_PD_TL_SELECT res = ServicModel.PD_TLGL.SELECT(model, getToken());
            if (res.MES_RETURN.TYPE.Equals("S"))
            {
                List<TMDataGrid> list = new List<TMDataGrid>();
                JlList = res.MES_PD_TL_LIST;
                for (int i = 0; i < res.MES_PD_TL_LIST.Length; i++)
                {
                    TMDataGrid node = new TMDataGrid();
                    node.Xh = (res.MES_PD_TL_LIST.Length - i).ToString();
                    node.Tm = res.MES_PD_TL_LIST[i].TM;
                    node.Wlxx = res.MES_PD_TL_LIST[i].WLH + "/" + res.MES_PD_TL_LIST[i].WLMS;
                    node.Wllb = res.MES_PD_TL_LIST[i].WLLBNAME;
                    node.Tlsj = res.MES_PD_TL_LIST[i].TLRQ;
                    list.Add(node);
                }
                LSdataGridView.DataSource = list;
                LSdataGridView.ClearSelection();
            }
            else
            {
                if (res.MES_RETURN.MESSAGE.Equals("无数据"))//暂不修改
                {
                     List<TMDataGrid> list = new List<TMDataGrid>();
                     JlList = res.MES_PD_TL_LIST;
                     LSdataGridView.DataSource = list;
                     LSdataGridView.ClearSelection();
                }
                else
                {
                    ShowMeg(res.MES_RETURN.MESSAGE);
                }
            }
            SMtextBox.Select();
        }
        public void ConfigDataGrid(string[] cols, string[] colss, DataGridView datagridGiew, string[] vcols)
        {
            for (int i = 0; i < cols.Length; i++)
            {
                if (cols[i] == q(Msg_Type.fielddelete) || cols[i] == q(Msg_Type.fieldmodify))// "删除"  "修改"
                {
                    DataGridViewButtonColumn acCode = new DataGridViewButtonColumn();
                    acCode.Name = cols[i];
                    acCode.UseColumnTextForButtonValue = true;
                    acCode.Text = cols[i];       
                    acCode.HeaderText = cols[i];
                    datagridGiew.Columns.Add(acCode);
                    acCode.Width = 80;
                }
                else
                {
                    DataGridViewTextBoxColumn acCode = new DataGridViewTextBoxColumn();
                    acCode.Name = cols[i];
                    acCode.DataPropertyName = colss[i];
                    acCode.HeaderText = cols[i];

                    if (cols[i] == q(Msg_Type.fieldwlxx))// "物料信息"
                    {
                        acCode.Width = 375;
                        acCode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    }                        
                    else if (cols[i] == q(Msg_Type.fieldgdxx) ){//"工单信息"
                        acCode.Width = 300;
                        acCode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
;
                    }
                    else if (cols[i] == q(Msg_Type.fieldtlsj))// "投料时间"
                    {
                        acCode.Width = 190;
                        acCode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                    else if (cols[i] == q(Msg_Type.fieldxh))//"序号"
                    {
                        acCode.Width = 40;
                        acCode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                    else if (cols[i] == q(Msg_Type.fieldwllb))//"物料类别"
                    {                        
                        acCode.Width = 90;
                        acCode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                    else
                    {
                        acCode.Width = 120;
                        acCode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                    //if (cols[i] == "条码")
                    //{
                        //acCode.DefaultCellStyle.ForeColor = Color.Blue;
                    //}
                    if (vcols.Count(p => p == cols[i]) > 0)
                    {
                        acCode.Visible = false;
                    }

                    datagridGiew.Columns.Add(acCode);

                }
               

            }
            datagridGiew.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font(q(Msg_Type.fonttype), 11);
            //datagridGiew.RowTemplate.Height = 35;
            datagridGiew.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //datagridGiew.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            foreach (DataGridViewColumn item in datagridGiew.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        private void ryglbutton_Click(object sender, EventArgs e)
        {
            frmManagerRY fomr = new frmManagerRY(_czrList, MES_PD_SCRW_LIST, 1);
            //push(fomr);
            show(fomr);


            MES_TM_CZR rymodel = new MES_TM_CZR();
            rymodel.GC = this._MES_PD_SCRW_LIST.GC;
            rymodel.RWBH = this._MES_PD_SCRW_LIST.RWBH;
            rymodel.CZLB = 1;
            _czrList = ServicModel.TM_CZR.SELECT_CZR_NOW(rymodel, getToken());
        
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
            MES_PD_SCRW model = new MES_PD_SCRW();
            model.SBBH = _MES_PD_SCRW_LIST.SBBH;
            model.ZPRQ = dateTimePicker1.Text.Trim();
            SELECT_MES_PD_SCRW Smodel = ServicModel.PD_SCRW.SELECT(model, getToken());
            if (Smodel.MES_RETURN.TYPE.Equals("S"))
            {
                frmChange_GD form = new frmChange_GD(Smodel.MES_PD_SCRW_LIST, model.SBBH, Rigth_Type.zhuxiantl);
                form.block = RefreshRW;
                show(form);
            }
            else
            {
                ShowMeg(Smodel.MES_RETURN.MESSAGE);
            }
            //if (Smodel.MES_PD_SCRW_LIST.Length <= 1)
            //{
            //    MessageBox.Show(_MES_PD_SCRW_LIST.SBH + "没有可切换的任务", "消息框");
            //    return;
            //}
            //else
            //{
               
               
                //show(form);
            //}
            SMtextBox.Select(); 
        }
        public void RefreshRW(MES_PD_SCRW_LIST list, string shebeihaoID)
        {
            //monthCalendar1.Visible = false;
            //scrqtextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            SMtextBox.Select();
            SBHID = shebeihaoID;
            Tmlist = new List<TMDataGrid>();
            this._MES_PD_SCRW_LIST = list;
            MES_TM_CZR rymodel = new MES_TM_CZR();
            rymodel.GC = list.GC;
            rymodel.RWBH = list.RWBH;
            rymodel.CZLB = 1;
            _czrList = ServicModel.TM_CZR.SELECT_CZR_NOW(rymodel, getToken());
            _bomList = ServicModel.PD_GD.SAP_GET_GDJGXX(list.RWBH, list.ZPRQ, list.GC, getToken());
            unRequireArr = new List<int>();
            MES_SY_TYPEMX bcmodel = new MES_SY_TYPEMX();
            bcmodel.GC = Convert.ToString(getGC("value"));
            bcmodel.TYPEID = 5;
            List<MES_SY_TYPEMXLIST> bcArr = new List<MES_SY_TYPEMXLIST>();

            MES_SY_TYPEMXLIST[] bclist = ServicModel.SY_TYPEMX.SELECT(bcmodel, getToken());

            gzzxtextBox.Text = list.GZZXBH + "-" + list.GZZXNAME;

            gctextBox.Text = list.GC;
            sbhtextBox.Text = list.SBH;

            MESlabel.Text = q(Msg_Type.titlemesgd) + list.GDDH;//"MES工单:"
            GDHlabel.Text = q(Msg_Type.titlegd) + list.ERPNO;//"工单号:"
            WLXXlabel.Text = q(Msg_Type.titlewlxx) + list.WLH + "/" + list.WLMS;//"物料信息:"
            WLLBlabel1.Text = q(Msg_Type.titlewllb) + list.WLLBNAME;//"物料类别:"
            rwdlabel.Text = q(Msg_Type.titlerwd) + list.RWBH;//"任务单:"
            if (_bomList.MES_RETURN.TYPE.Equals("S"))
            {
                BOMdataGridView.DataSource = getBomList(_bomList);                
            }
            else
            {
                ShowMeg(_bomList.MES_RETURN.MESSAGE);
                //this.Close();
                BOMdataGridView.DataSource = new List<BomDataGrid>();
            }            
            BOMdataGridView.ClearSelection();
            LSdataGridView.ReadOnly = true;
            UpdateJSDataGrid(MES_PD_SCRW_LIST.RWBH);
            //getTMList(ServicModel.TM_TMINFO.SELECT_TL_LAST(MES_PD_SCRW_LIST.RWBH, getToken()));
        }
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
           //"xh", "czrgh", "czrname", "gwname", "id", "del"
            //"xh", "tm", "wlxx", "wllb", "tlsj"
            string _xh;

            public string Xh
            {
                get { return _xh; }
                set { _xh = value; }
            }
            string _tm;

            public string Tm
            {
                get { return _tm; }
                set { _tm = value; }
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
            string _tlsj;

            public string Tlsj
            {
                get { return _tlsj; }
                set { _tlsj = value; }
            }

        }

        private void frmZX_TL_Shown(object sender, EventArgs e)
        {
            MES_TM_CZR rymodel = new MES_TM_CZR();
            rymodel.GC = MES_PD_SCRW_LIST.GC;
            rymodel.RWBH = MES_PD_SCRW_LIST.RWBH;
            rymodel.CZLB = 1;
            dateTimePicker1.Text = MES_PD_SCRW_LIST.ZPRQ;
            _czrList = ServicModel.TM_CZR.SELECT_CZR_NOW(rymodel, getToken());
            _bomList = ServicModel.PD_GD.SAP_GET_GDJGXX(MES_PD_SCRW_LIST.RWBH, MES_PD_SCRW_LIST.ZPRQ, MES_PD_SCRW_LIST.GC, getToken());
            unRequireArr = new List<int>();
            MES_SY_TYPEMX bcmodel = new MES_SY_TYPEMX();
            bcmodel.GC = Convert.ToString(getGC("value"));
            bcmodel.TYPEID = 5;
            List<MES_SY_TYPEMXLIST> bcArr = new List<MES_SY_TYPEMXLIST>();

            MES_SY_TYPEMXLIST[] bclist = ServicModel.SY_TYPEMX.SELECT(bcmodel, getToken());

            gzzxtextBox.Text = MES_PD_SCRW_LIST.GZZXBH + "-" + MES_PD_SCRW_LIST.GZZXNAME;

            gctextBox.Text = MES_PD_SCRW_LIST.GC;
            sbhtextBox.Text = MES_PD_SCRW_LIST.SBH;

            MESlabel.Text = q(Msg_Type.titlemesgd) + MES_PD_SCRW_LIST.GDDH;//"MES工单:" 
            GDHlabel.Text = q(Msg_Type.titlegd) + MES_PD_SCRW_LIST.ERPNO;//"工单号:"
            WLXXlabel.Text = q(Msg_Type.titlewlxx) + MES_PD_SCRW_LIST.WLH + "/" + MES_PD_SCRW_LIST.WLMS;//"物料信息:"
            WLLBlabel1.Text = q(Msg_Type.titlewllb) + MES_PD_SCRW_LIST.WLLBNAME;//"物料类别:"
            dclabel.Text = q(Msg_Type.titledcdjandxh) + MES_PD_SCRW_LIST.DCXHNAME + "/" + MES_PD_SCRW_LIST.DCDJNAME;//"电池型号/等级:"
            rwdlabel.Text = q(Msg_Type.titlerwd) + MES_PD_SCRW_LIST.RWBH;//"任务单:"
            configBom();
            if (_bomList.MES_RETURN.TYPE.Equals("S"))
            {
                BOMdataGridView.DataSource = getBomList(_bomList);
            }
            else
            {
                ShowMeg(_bomList.MES_RETURN.MESSAGE);
                //this.Close();
                BOMdataGridView.DataSource = new List<BomDataGrid>();
            }            
            BOMdataGridView.ClearSelection();
            LSdataGridView.ReadOnly = true;
           
            LastDate = dateTimePicker1.Text.Trim();
            ConfigJsDataGridView();
            LSdataGridView.ClearSelection();
            BOMdataGridView.ClearSelection();
            button3.Text = q(Msg_Type.fieldhidden);// "隐藏";
            IShidden(true);
        }

        private void SCRQmonthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            
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
                    //MessageBox.Show("你扫描的是无效的条码！！", "消息框");
                    ShowMeg(q(Msg_Type.msgscantminvalid));
                    //getCzrInfo();
                    break;
                case TM_Type.gd:
                    //MessageBox.Show("你扫描的是无效的条码！！", "消息框");
                    ShowMeg(q(Msg_Type.msgscantminvalid));
                    break;
                case TM_Type.ph:
                    getReportInfoByTm();
                    break;
                case TM_Type.rwd:
                    CHANGERWD();
                    break;
                default:
                    //MessageBox.Show("你扫描的是无效的条码！！", "消息框");
                    ShowMeg(q(Msg_Type.msgscantminvalid));
                    break;
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
        public void getReportInfoByTm()
        {

            MES_TM_TMINFO model = new MES_TM_TMINFO();
            model.GC = this._MES_PD_SCRW_LIST.GC;
            model.TM = SMtextBox.Text.Trim().ToUpper();
            model.RWBH = this._MES_PD_SCRW_LIST.RWBH;
            model.JLR = Convert.ToInt32(getUserInfo("staffid"));
            SELECT_MES_TM_TMINFO_BYTM res = ReadphTM(model, 1);
            if (res.MES_RETURN.TYPE.Equals("S"))
            {
                ShowMeg(q(Msg_Type.msgtlsuccess), 1500);//"投料成功"
                UpdateJSDataGrid(MES_PD_SCRW_LIST.RWBH);
            }
            else
            {
                //MessageBox.Show(res.MES_RETURN.MESSAGE, "消息框");
                ShowMeg(res.MES_RETURN.MESSAGE);
            }

        }
        public void CHANGERWD()
        {
            MES_PD_SCRW model = new MES_PD_SCRW();
            model.RWBH = SMtextBox.Text.Trim().ToUpper();//.Text.Trim().ToUpper();
            model.WLLBNAME = "素电";
            model.STAFFID = Convert.ToInt32(getUserInfo("staffid"));
            //model.ZPRQ = DateTime.Now.ToString("yyyy-MM-dd");
            SELECT_MES_PD_SCRW res = ServicModel.PD_SCRW.SELECT_BY_ROLE(model, getToken());
            if (res.MES_RETURN.TYPE.Equals("S"))
            {
                if (res.MES_PD_SCRW_LIST.Length == 1)
                {
                    MES_PD_SCRW_LIST = res.MES_PD_SCRW_LIST[0];
                    MES_SY_GC gc_model = new MES_SY_GC();
                    gc_model.GC = res.MES_PD_SCRW_LIST[0].GC;
                    MES_SY_GC[] gc_res = ServicModel.SY_GC.read(gc_model, getToken());
                    ini.IniWriteValue(ini.Section_UserInfo, "gzzxvalue", res.MES_PD_SCRW_LIST[0].GZZXBH);
                    ini.IniWriteValue(ini.Section_UserInfo, "gzzxtext", res.MES_PD_SCRW_LIST[0].GZZXNAME);
                    ini.IniWriteValue(ini.Section_GC, "value", res.MES_PD_SCRW_LIST[0].GC);
                    ini.IniWriteValue(ini.Section_GC, "text", gc_res[0].GCMS);
                }
                else
                {
                    ShowMeg(q(Msg_Type.msgrwexcept));//"任务异常请联系管理员"
                    SMtextBox.Select();
                    return;
                }
              
                
            }
            else
            {
                ShowMeg(res.MES_RETURN.MESSAGE);
                SMtextBox.Select();
                return;
            }

            SBHID = MES_PD_SCRW_LIST.SBBH;
            Tmlist = new List<TMDataGrid>();
           
            MES_TM_CZR rymodel = new MES_TM_CZR();
            rymodel.GC = MES_PD_SCRW_LIST.GC;
            rymodel.RWBH = MES_PD_SCRW_LIST.RWBH;
            rymodel.CZLB = 1;
            _czrList = ServicModel.TM_CZR.SELECT_CZR_NOW(rymodel, getToken());
            _bomList = ServicModel.PD_GD.SAP_GET_GDJGXX(MES_PD_SCRW_LIST.RWBH, MES_PD_SCRW_LIST.ZPRQ, MES_PD_SCRW_LIST.GC, getToken());
            unRequireArr = new List<int>();
            MES_SY_TYPEMX bcmodel = new MES_SY_TYPEMX();
            bcmodel.GC = Convert.ToString(getGC("value"));
            bcmodel.TYPEID = 5;
            List<MES_SY_TYPEMXLIST> bcArr = new List<MES_SY_TYPEMXLIST>();
            MES_SY_TYPEMXLIST[] bclist = ServicModel.SY_TYPEMX.SELECT(bcmodel, getToken());
            gzzxtextBox.Text = MES_PD_SCRW_LIST.GZZXBH + "-" + MES_PD_SCRW_LIST.GZZXNAME;
            gctextBox.Text = MES_PD_SCRW_LIST.GC;
            sbhtextBox.Text = MES_PD_SCRW_LIST.SBH;

            MESlabel.Text = q(Msg_Type.titlemesgd) + MES_PD_SCRW_LIST.GDDH;//"MES工单:"
            GDHlabel.Text = q(Msg_Type.titlegd) + MES_PD_SCRW_LIST.ERPNO;//"工单号:"
            WLXXlabel.Text = q(Msg_Type.titlewlxx) + MES_PD_SCRW_LIST.WLH + "/" + MES_PD_SCRW_LIST.WLMS;//"物料信息:"
            WLLBlabel1.Text = q(Msg_Type.titlewllb) + MES_PD_SCRW_LIST.WLLBNAME;//"物料类别:"
            dclabel.Text = q(Msg_Type.titledcdjandxh) + MES_PD_SCRW_LIST.DCXHNAME + "/" + MES_PD_SCRW_LIST.DCDJNAME;//"电池型号/等级:"
            rwdlabel.Text = q(Msg_Type.titlerwd) + MES_PD_SCRW_LIST.RWBH;//"任务单:"
            //configBom();
            if (_bomList.MES_RETURN.TYPE.Equals("S"))
            {
                BOMdataGridView.DataSource = getBomList(_bomList);
            }
            else
            {
                ShowMeg(_bomList.MES_RETURN.MESSAGE);
                //this.Close();
                BOMdataGridView.DataSource = new List<BomDataGrid>();
            }
            //BOMdataGridView.DataSource = getBomList(_bomList);
            BOMdataGridView.ClearSelection();
            LSdataGridView.ReadOnly = true;
            dateTimePicker1.Text = MES_PD_SCRW_LIST.ZPRQ;
            LastDate = dateTimePicker1.Text.Trim();
            ConfigJsDataGridView();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
            //scrqtextBox.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); 
           
        }

        private void frmZX_TL_Load(object sender, EventArgs e)
        {
            //this.timer1.Interval = 1000;
            //this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            //this.timer1.Start();
        }

        private void LSdataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                int index = LSdataGridView.CurrentRow.Index;
                if (this.LSdataGridView.CurrentCell.OwningColumn.Name == q(Msg_Type.fielddelete))//"删除"
                {
                    MES_PD_TL_LIST model = JlList[index];
                    //if (MessageBox.Show("是否删除条码号是" + model.TM + "投料信息", "消息框", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    //{
                    //    MES_RETURN_UI delreturn = ServicModel.PD_TLGL.DELETE(model.ID, getToken());
                    //    if (delreturn.TYPE.Equals("S"))
                    //    {
                    //        UpdateJSDataGrid(MES_PD_SCRW_LIST.RWBH);
                    //    }
                    //    else
                    //    {
                    //        ShowMeg(delreturn.MESSAGE);
                    //    }
                    //}
                    frmDeleteTM form = new frmDeleteTM(model);
                    form.block = UpdateJSDataGrid;
                    show(form);


                }
                else if (this.LSdataGridView.CurrentCell.OwningColumn.Name == q(Msg_Type.fieldmodify))//"修改"
                {
                    MES_PD_TL_LIST model = JlList[index];
                    //if (MessageBox.Show("是否替换条码号是" + model.TM + "投料信息", "消息框", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    //{
                    frmUpdateTM form = new frmUpdateTM(model);
                    form.block = UpdateJSDataGrid;
                    show(form);

                    //}
                }

            }
            SMtextBox.Select();
           
        }

        private void qhsbhbutton_Click(object sender, EventArgs e)
        {
            MES_SY_GZZX_SBH model = new MES_SY_GZZX_SBH();
            //model.GZZXBH = Convert.ToString(getUserInfo("gzzxvalue"));
            model.GC = getGC("value");
            model.WLLBNAME = GetWLLBName(Rigth_Type.zhuxiantl);
            MES_SY_GZZX_SBH[] list = ServicModel.SY_GZZX_SBH.SELECT(model, getToken());
            frmFindSBH form = new frmFindSBH(list, getUserInfo("gzzxtext"), RigthType,true);
            push(form,this);
        }

        private void sbhbutton_Click(object sender, EventArgs e)
        {
            if (RigthType == Rigth_Type.zhujizhengjitl)
            {
                MES_SY_GZZX_SBH model = new MES_SY_GZZX_SBH();
                model.GC = getGC("value");
                model.STAFFID = Convert.ToInt16(getUserInfo("staffid"));
                model.WLLBNAME = "素电";
                MES_SY_GZZX_SBH[] list = ServicModel.SY_GZZX_SBH.SELECT_BY_STAFFID(model, getToken());
                frmFindSBH form = new frmFindSBH(list, q(Msg_Type.choiceCX), RigthType, true);//"选择产线"
                push(form,this);
            }
            else
            {
                MES_SY_GZZX_SBH model = new MES_SY_GZZX_SBH();
                model.GZZXBH = MES_PD_SCRW_LIST.GZZXBH;
                model.GC = MES_PD_SCRW_LIST.GC;
                //model.WLLB = Gzzxlb;
                model.WLLBNAME = "素电";
                MES_SY_GZZX_SBH[] list = ServicModel.SY_GZZX_SBH.SELECT(model, getToken());
                frmFindSBH form = new frmFindSBH(list, MES_PD_SCRW_LIST.GZZXBH  + "-"+ MES_PD_SCRW_LIST.GZZXNAME, RigthType,true);
                push(form,this);

            }
            
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

        private void button1_Click(object sender, EventArgs e)
        {
            frmZX_CC form = new frmZX_CC(MES_PD_SCRW_LIST, MES_PD_SCRW_LIST.SBBH, Rigth_Type.zhuxiancc);
            push(form,this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateJSDataGrid(MES_PD_SCRW_LIST.RWBH);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == q(Msg_Type.fieldshown))//"显示"
            {
                IShidden(true);
            }
            else
            {
                IShidden(false);
            }
            
         
        }
        public void IShidden(bool isHid)
        {

            if (isHid)
            {
                groupBox2.Size = new Size(groupBox2.Width, groupBox2.Height - 192);
                groupBox3.Size = new Size(groupBox3.Width, groupBox3.Height + 192);
                groupBox3.Location = new Point(groupBox3.Location.X, groupBox3.Location.Y - 192);
                button3.Text = q(Msg_Type.fieldhidden);//"隐藏";
            }
            else
            {
                groupBox2.Size = new Size(groupBox2.Width, groupBox2.Height + 192);
                groupBox3.Size = new Size(groupBox3.Width, groupBox3.Height - 192);
                groupBox3.Location = new Point(groupBox3.Location.X, groupBox3.Location.Y + 192);
                button3.Text = q(Msg_Type.fieldshown);//"显示";
            }
            SMtextBox.Select();
        }

        private void LSdataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (this.LSdataGridView.CurrentCell.OwningColumn.Name.Equals(q(Msg_Type.fieldtm)))//"条码"
                {
                    string tm = Convert.ToString(this.LSdataGridView.CurrentRow.Cells[q(Msg_Type.fieldtm)].Value);//"条码"
                    if (!string.IsNullOrEmpty(tm))
                    {
                        MES_TM_TMINFO TMINFOmodel = new MES_TM_TMINFO();
                        TMINFOmodel.TM = tm;
                        SELECT_MES_TM_TMINFO_BYTM tminfiRes = ServicModel.TM_TMINFO.SELECT(TMINFOmodel, getToken());
                        if (tminfiRes.MES_RETURN.TYPE.Equals("S"))
                        {
                           
                            if (tminfiRes.MES_TM_TMINFO_LIST.Length == 1)
                            {
                                Sonluk.UI.Model.MES.TM_TMINFOService.MES_TM_TMINFO_LIST tmINFO = tminfiRes.MES_TM_TMINFO_LIST[0];
                                Print_Type ptype = (Print_Type)tmINFO.TMSX;
                                Rigth_Type r;                         
                                bool isNormal = true;
                                switch (ptype)
                                {
                                    case Print_Type.none:
                                        isNormal = false;
                                        break;
                                    case Print_Type.rk:
                                        r = Rigth_Type.gangketl_cc;
                                        PrintInfoByTM_READONLY(tmINFO.TM, tmINFO.GC, 1, r, ptype);
                                        break;
                                    case Print_Type.lot:
                                        r = Rigth_Type.gangketl_cc;
                                        PrintInfoByTM_READONLY(tmINFO.TM, tmINFO.GC, 1, r, ptype);
                                        break;
                                    case Print_Type.zjlot:
                                        r = Rigth_Type.zhengjicc;
                                        PrintInfoByTM_READONLY(tmINFO.TM, tmINFO.GC, 1, r, ptype);
                                        break;
                                    case Print_Type.fujilot:
                                        r = Rigth_Type.fujitl;
                                        PrintInfoByTM_READONLY(tmINFO.TM, tmINFO.GC, 1, r, ptype);
                                        break;
                                    case Print_Type.zxlot:
                                        r = Rigth_Type.zhuxiancc;
                                        PrintInfoByTM_READONLY(tmINFO.TM, tmINFO.GC, 1, r, ptype);
                                        break;
                                    case Print_Type.bblot:
                                        r = Rigth_Type.baobiaocc;
                                        PrintInfoByTM_READONLY(tmINFO.TM, tmINFO.GC, 1, r, ptype);
                                        break;
                                    case Print_Type.zfsd:
                                        r = Rigth_Type.zhuxiancc;
                                        PrintInfoByTM_READONLY(tmINFO.TM, tmINFO.GC, 1, r, ptype);
                                        break;
                                    case Print_Type.wlrk:
                                        r = Rigth_Type.wlrkdy;
                                        PrintInfoByTM_READONLY(tmINFO.TM, tmINFO.GC, 1, r, ptype);
                                        break;
                                    case Print_Type.wlrkLot:
                                        r = Rigth_Type.wlrkdy;
                                        PrintInfoByTM_READONLY(tmINFO.TM, tmINFO.GC, 1, r, ptype);
                                        break;
                                    default:
                                        isNormal = false;
                                        break;
                                }
                                if (isNormal == false)
                                {
                                    //ShowMeg("条码属性读取异常,请联系管理员");
                                    ShowMeg(q(Msg_Type.msgtmsxecpect));
                                    SMtextBox.Select();
                                    return;
                                }
                               
                              
                            }
                            else
                            {
                                //ShowMeg("读取扫描条码信息失败");
                                ShowMeg(q(Msg_Type.msgloadtmfail));
                            }

                        }
                        else
                        {
                            ShowMeg(tminfiRes.MES_RETURN.MESSAGE);
                        }
                    }
                    else
                    {
                        ShowMeg(q(Msg_Type.msgtmnoempty));// "条码不能为空"
                    }
                    SMtextBox.Select();
                }
             
              
            }
        }
     
    }
}
