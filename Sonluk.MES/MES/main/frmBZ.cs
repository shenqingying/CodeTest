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
    public partial class frmBZ : baseview
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
        #endregion
        public frmBZ()
        {
            InitializeComponent();
            
        }
        public frmBZ(MES_PD_SCRW_LIST list, string shebeihaoID, Rigth_Type rtype)
        {
            InitializeComponent();
            RigthType = rtype;
            SMtextBox.Select();
            SBHID = shebeihaoID;
            Tmlist = new List<TMDataGrid>();
            this._MES_PD_SCRW_LIST = list;
            MES_TM_CZR rymodel = new MES_TM_CZR();
            rymodel.GC = list.GC;
            rymodel.RWBH = list.RWBH;
            rymodel.CZLB = 1;
            _czrList = ServicModel.TM_CZR.SELECT_CZR_NOW(rymodel, getToken());
      
            //_bomList = ServicModel.PD_GD.SAP_GET_GDJGXX(list.RWBH,, list.GC, getToken());
            unRequireArr = new List<int>();
            MES_SY_TYPEMX bcmodel = new MES_SY_TYPEMX();
            bcmodel.GC = Convert.ToString(getGC("value"));
            bcmodel.TYPEID = 5;
            List<MES_SY_TYPEMXLIST> bcArr = new List<MES_SY_TYPEMXLIST>();
            //MES_SY_TYPEMXLIST bcBlank = new MES_SY_TYPEMXLIST();
            //bcBlank.MXNAME = "空";
            //bcBlank.ID = 0;
            //bcArr.Add(bcBlank);

            MES_SY_TYPEMXLIST[] bclist = ServicModel.SY_TYPEMX.SELECT(bcmodel, getToken());
            //for (int i = 0; i < bclist.Length; i++)
            //{
            //    bcArr.Add(bclist[i]);
            //}
            gzzxtextBox.Text = list.GZZXBH + "-" + list.GZZXNAME ;
            czrytextBox.Text = _czrList.CZR;
            gctextBox.Text = list.GC;
            sbhtextBox.Text = list.SBH;
         
            MESlabel.Text = "MES工单:" + list.GDDH;
            GDHlabel.Text = "工单号:" + list.ERPNO;
            WLXXlabel.Text = "物料信息:" + list.WLH + "/" + list.WLMS;
            WLLBlabel1.Text = "物料类别:" + list.WLLBNAME;
            rwdlabel.Text = "任务单:" + list.RWBH;

            //string[] cols = { "序号", "条码", "物料信息", "物料类别","删除",  "物料类别代码", "条码代码","工厂"};
            //string[] colss = { "Xh", "Tm", "Wlxx", "Wllb","del",  "Wllbdm", "tmid" ,"gc"};
            //string[] vcols = { "物料类别代码", "条码代码" ,"工厂"};
            //DataGridBuild(cols, colss, LSdataGridView, vcols);
            BOMdataGridView.DataSource = getBomList(_bomList);
           
            //System.Timers.Timer t = new System.Timers.Timer(100);
            //t.Elapsed += new System.Timers.ElapsedEventHandler(theout);
            //t.AutoReset = false;//设置是执行一次（false）还是一直执行(true)；
            //t.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件；
           
            LSdataGridView.ReadOnly = true;
            bingLSdatagridView();
            
           
        }
        public void bingLSdatagridView()
        {
            string[] cols = { "序号", "条码", "物料信息", "物料类别", "删除", "物料类别代码", "条码代码", "工厂","投料条码代码"};
            string[] colss = { "Xh", "Tm", "Wlxx", "Wllb", "del", "Wllbdm", "tmid", "gc","tltmid" };
            string[] vcols = { "物料类别代码", "条码代码", "工厂" ,"投料条码代码"};
            for (int i = 0; i < cols.Length; i++)
            {
                //DataGridViewButtonColumn
                if (cols[i] == "XXXXXX")
                {

                   
                }
                else if (cols[i] == "删除" )
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

                    if (cols[i] == "物料信息")
                        acCode.Width = 200;
                    else
                        acCode.Width = 100;
                    //判断不显示的在 全部字段里面有没有 有的话 就隐藏该字段
                    if (vcols.Count(p => p == cols[i]) > 0)
                    {
                        acCode.Visible = false;
                    }
                    LSdataGridView.Columns.Add(acCode);
                }

            }
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
            
            BOMdataGridView.Columns["状态"].DefaultCellStyle.BackColor = Color.Red;
            for (int i = 0; i < unRequireArr.Count; i++)
            {
                BOMdataGridView.Rows[unRequireArr[i]].Cells["状态"].Style.BackColor = Color.White;
            }
           getTMList(ServicModel.TM_TMINFO.SELECT_TL_LAST(MES_PD_SCRW_LIST.RWBH, getToken()));
            //if (data.MES_RETURN.TYPE.Equals("S"))
            //{
            //     //MES_TM_TMINFO_LIST[]
                
            //    for (int i = 0; i < data.MES_TM_TMINFO_LIST.Length; i++)
            //    {
            //        TMDataGrid node = new TMDataGrid();
            //        node.Tm = data.MES_TM_TMINFO_LIST[i].TM;
            //        node.Wlxx = data.MES_TM_TMINFO_LIST[i].WLH + "/" + data.MES_TM_TMINFO_LIST[i].WLMS;
            //        node.Wllb = data.MES_TM_TMINFO_LIST[i].WLLBNAME;
            //        //node.Bz = model.MES_TM_TMINFO_LIST[0].REMARK;
            //        node.Wllbdm = data.MES_TM_TMINFO_LIST[i].WLLB;
            //        node.Gc = data.MES_TM_TMINFO_LIST[i].GC;
            //        node.Tltmid = data.MES_TM_TMINFO_LIST[i].TLTMID;
            //        //node.Tmid = model.MES_TM_TMINFO_LIST[0].TM;
            //        bool isBom = false;
            //        LSdataGridView.DataSource = data.MES_TM_TMINFO_LIST;
            //    }
            //}

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
                    break;
                case TM_Type.gd:
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
            //MES_TM_TMINFO model = new MES_TM_TMINFO();
            //model.GC = this._MES_PD_SCRW_LIST.GC;
            //model.TM = SMtextBox.Text.Trim();
            //model.RWBH = this._MES_PD_SCRW_LIST.RWBH;
            //model.JLR = Convert.ToInt32(getUserInfo("staffid"));
            //SELECT_MES_TM_TMINFO_BYTM res = ReadphTM(model,1);
            //if (res.MES_RETURN.TYPE.Equals("S"))
            //{
            //    getTMList(res);
            //}
            //else
            //{
            //    MessageBox.Show(res.MES_RETURN.MESSAGE, "消息框");
            //}

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
                MessageBox.Show(res.MESSAGE, "消息框");
            }
            SMtextBox.Clear();
        }
        public MsgReturn VerifyWLisALL()
        {
            MsgReturn msgInfo = new MsgReturn();
            msgInfo.Pass = false;
            msgInfo.Msg = "生成物料的相关BOM物料不齐全,请查看需要添加的物料";
            int bomcount = 0;
            int tmcount = 0;
            ZBCFUN_GDJGXX_READ judge = BomList;

            //list.Where((x, i) => list.FindIndex(z => z.WLLB == x.WLLB) == i);
            //List<int> list = BomList.ET_BOM.ToList().Select(x => x.WLLB).Distinct().ToList();

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
            return msgInfo;
        }
        public MsgReturn VerifyContent()
        {
            MsgReturn msgInfo = new MsgReturn();
            msgInfo.Pass = true;
           
            if (string.IsNullOrEmpty(czrytextBox.Text.Trim()))
            {
                msgInfo.Msg = "操作人员信息不能为空";
                msgInfo.Pass = false;
            }
         

            return msgInfo;
        }

        public void CreateTM()
        {

           
        }
        private void getTMList(SELECT_MES_TM_TMINFO_BYTM model)
        {
            for (int x = 0; x < model.MES_TM_TMINFO_LIST.Length; x++)
            {
                IList<TMDataGrid> nodes = new List<TMDataGrid>();
                TMDataGrid node = new TMDataGrid();

                if (model.MES_TM_TMINFO_LIST.Length <= 0)
                {
                    MessageBox.Show("扫描的是无效的条码", "消息框");
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
                bool isBom = false;
                for (int i = 0; i < _bomList.ET_BOM.Length; i++)
                {
                    if (_bomList.ET_BOM[i].ZSBS.Equals("Y"))
                    {

                        if (_bomList.ET_BOM[i].IDNRK == node.Wlxx.Split('/')[0])
                        {
                            isBom = true;
                            //BOMdataGridView.Rows[i].DefaultCellStyle.BackColor = Color.Cyan;
                            //BOMdataGridView.Columns["状态"].DefaultCellStyle.BackColor = Color.Red;
                            BOMdataGridView.Rows[i].Cells["状态"].Style.BackColor = Color.FromArgb(187, 255, 102);
                        }
                    }
                    else
                    {
                        if (_bomList.ET_BOM[i].WLLB == node.Wllbdm)
                        {
                            isBom = true;
                            BOMdataGridView.Rows[i].Cells["状态"].Style.BackColor = Color.FromArgb(187, 255, 102);
                        }
                    }

                }
                if (isBom == false)
                {
                    if (MessageBox.Show("你扫描的条码不是物料的BOM组成部分！！", "消息框", MessageBoxButtons.OK) == DialogResult.OK)
                    {
                        SMtextBox.Clear();
                    }

                    return;
                }
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
                LSdataGridView.DataSource = Tmlist.ToList();
                LSdataGridView.ClearSelection();
                LSdataGridView.Columns["删除"].DisplayIndex = 4;

               
               
            }
            if (model.MES_TM_TMINFO_LIST.Length == 1)
            {
                MessageBox.Show("投料成功！！！", "消息框");
            }
           
            SMtextBox.Clear();
        }

        private List<BomDataGrid> getBomList(ZBCFUN_GDJGXX_READ model)
        {
            IList<BomDataGrid> list = new List<BomDataGrid>();
            string[] cols = { "序号", "物料信息", "物料类别", "物料类别代码", "状态" };
            string[] colss = { "Xh", "Wlxx", "Wllb", "Wllbdm", "zt" };
            string[] vcol = { "物料类别代码" };
            DataGridBuild(cols, colss, BOMdataGridView, vcol);
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
                MessageBox.Show(_MES_PD_SCRW_LIST.SBH + "的当天任务派单只有一个", "消息框");
                return;
            }
            else
            {
                frmChange_GD form = new frmChange_GD(Smodel.MES_PD_SCRW_LIST, model.SBBH,RigthType);
                show(form);
                this.Close();
                //show(form);
            }
        }

        private void dyrkbutton_Click(object sender, EventArgs e)
        {
            MsgReturn msgInfo = VerifyWLisALL();
            if (msgInfo.Pass == false)
            {
                MessageBox.Show(msgInfo.Msg, "消息框");
                return;
            }
            MsgReturn msgInfo1 = VerifyContent();
            if (msgInfo1.Pass == false)
            {
                MessageBox.Show(msgInfo1.Msg, "消息框");
                return;
            }
          
            MES_TM_TMINFO_INSERT_GL model = new MES_TM_TMINFO_INSERT_GL();
            MES_TM_TMINFO info = new MES_TM_TMINFO();
            model.MES_TM_TMINFO = info;
            model.MES_TM_TMINFO.TMLB = 1;
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
            SMtextBox.Select();
            string printToHome = ini.IniReadValue(ini.Section_Configuration, "printTohome");
            if (printToHome.Equals("true"))
            {
                zybutton.PerformClick();
            }
            //this.Close();
        }

        private void dylotbutton_Click(object sender, EventArgs e)
        {
            MsgReturn msgInfo = VerifyWLisALL();
            if (msgInfo.Pass == false)
            {
                MessageBox.Show(msgInfo.Msg, "消息框");
                return;
            }
            MsgReturn msgInfo1 = VerifyContent();
            if (msgInfo1.Pass == false)
            {
                MessageBox.Show(msgInfo1.Msg, "消息框");
                return;
            }
           
            MES_TM_TMINFO_INSERT_GL model = new MES_TM_TMINFO_INSERT_GL();
            MES_TM_TMINFO info = new MES_TM_TMINFO();
            model.MES_TM_TMINFO = info;
            model.MES_TM_TMINFO.TMLB = 1;
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

            frmPrint_N form = new frmPrint_N(model, Print_Type.lot, RigthType);
            show(form);
            SMtextBox.Select();
            string printToHome = ini.IniReadValue(ini.Section_Configuration, "printTohome");
            if (printToHome.Equals("true"))
            {
                zybutton.PerformClick();
            }
            //this.Close();
        }

        private void qhsbhbutton_Click(object sender, EventArgs e)
        {
            
            MES_SY_GZZX_SBH model = new MES_SY_GZZX_SBH();
            model.GZZXBH = Convert.ToString(getUserInfo("gzzxvalue"));
            model.GC = getGC("value");
            model.WLLBNAME = GetWLLBName(RigthType);
            MES_SY_GZZX_SBH[] list = ServicModel.SY_GZZX_SBH.SELECT(model, getToken());
            frmFindSBH form = new frmFindSBH(list, getUserInfo("gzzxtext"),RigthType,true);

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
            if (this.LSdataGridView.CurrentCell.OwningColumn.Name == "删除")
            {
               
                int tmtmid = Convert.ToInt32(this.LSdataGridView.CurrentRow.Cells["投料条码代码"].Value);
                //MES_RETURN_UI res = ServicModel.PD_TLGL.DELETE(tmtmid, getToken());
                //if (res.TYPE.Equals("S"))
                //{
                    int id = Convert.ToInt32(this.LSdataGridView.CurrentRow.Cells["序号"].Value);
                    Tmlist.RemoveAt(id - 1);
                    for (int i = 0; i < Tmlist.Count; i++)
                    {
                        Tmlist[i].Xh = (i + 1).ToString();
                    }
                    int a = LSdataGridView.Columns.Count;
                    if (Tmlist.Count == 0)
                    {
                        LSdataGridView.DataSource = new List<TMDataGrid>();
                        LSdataGridView.Columns["删除"].DisplayIndex = 4;


                    }
                    else
                    {
                        LSdataGridView.DataSource = Tmlist.ToArray();
                        LSdataGridView.Columns["删除"].DisplayIndex = 4;
                    }
                //}
                //else
                //{
                //    MessageBox.Show(res.MESSAGE, "消息框");
                //}
               
               
            }

        }
    }
}