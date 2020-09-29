using Sonluk.MES.MES.Base;
using Sonluk.UI.Model.MES.PD_GDService;
using Sonluk.UI.Model.MES.PD_SCRWService;
using Sonluk.UI.Model.MES.SY_GZZX_SBHService;
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
    public partial class frmZX_CC : baseview
    {
        bool showTime = false;
        List<gridview> _gridview;

        public List<gridview> Gridview
        {
            get { return _gridview; }
            set { _gridview = value; }
        }
        MES_TM_CZR_SELECT_CZR_NOW _czrList;

        public MES_TM_CZR_SELECT_CZR_NOW CzrList
        {
            get { return _czrList; }
            set { _czrList = value; }
        }
        MES_PD_SCRW_LIST _MES_PD_SCRW_LIST;

        public MES_PD_SCRW_LIST MES_PD_SCRW_LIST
        {
            get { return _MES_PD_SCRW_LIST; }
            set { _MES_PD_SCRW_LIST = value; }
        }
        string _lastDate;

        public string LastDate
        {
            get { return _lastDate; }
            set { _lastDate = value; }
        }

        public frmZX_CC()
        {
            InitializeComponent();
        }
        public frmZX_CC(MES_PD_SCRW_LIST list, string shebeihaoID,Rigth_Type rtype)
        {
            InitializeComponent();
            if (list.GC.Equals("8020"))
            {
                showTime = true;
            }
            configTable();
            RigthType = rtype;
            MES_PD_SCRW_LIST = list;
          
            //monthCalendar1.Visible = false;
            configUI(MES_PD_SCRW_LIST);
            


        }
        public void configUI(MES_PD_SCRW_LIST list)
        {
            dateTimePicker1.Text = list.ZPRQ;
            LastDate = dateTimePicker1.Text.Trim();
            gzzxtextBox.Text = list.GZZXBH + "-" + list.GZZXNAME;
            gctextBox.Text = list.GC;
            sbhtextBox.Text = list.SBH;
            pctextBox.Text = list.PC;
            dateTimePicker1.Text = Convert.ToDateTime(list.ZPRQ).ToString("yyyy-MM-dd");
            rwdtextBox.Text = list.RWBH;
            MESgdtextBox.Text = list.GDDH;
            gdtextBox.Text = list.ERPNO;
            wlxxtextBox.Text =   list.WLH + "/" + list.WLMS;
            wllbtextBox.Text = list.WLLBNAME;
            MES_TM_CZR rymodel = new MES_TM_CZR();
            rymodel.GC = list.GC;
            rymodel.RWBH = list.RWBH;
            rymodel.CZLB = 1;
            CzrList = ServicModel.TM_CZR.SELECT_CZR_NOW(rymodel, getToken());
            czrytextbox.Text = CzrList.CZR;           
            configgridviewData(list.RWBH);            
        }
        public void configTable()
        {
            //string[] cols = { "幢号","条码", "开始时间", "结束时间", "电池型号", "电池等级","记录时间","删除","打印" };
            //string[] colss = { "zh", "tm","kstime","jstime", "dcxh", "dcdj","jlsj","shanchu","dayin" };
            //string[] cols = { q(Msg_Type.fieldzh), q(Msg_Type.fieldtm), q(Msg_Type.fieldkssj), q(Msg_Type.fieldjssj), q(Msg_Type.titledcxh), q(Msg_Type.fielddcdj), q(Msg_Type.fieldjltime), q(Msg_Type.fieldprint) };
            //                                //"幢号", "条码", "开始时间", "结束时间", "电池型号", "电池等级", "记录时间", "打印"
            //string[] colss = { "zh", "tm", "kstime", "jstime", "dcxh", "dcdj", "jlsj",  "dayin" };
            string[] cols = { q(Msg_Type.fieldzh), q(Msg_Type.fieldtm), q(Msg_Type.fieldkssj), q(Msg_Type.fieldjssj),  q(Msg_Type.fieldcxh), q(Msg_Type.fielddcdj), q(Msg_Type.fieldjltime),  q(Msg_Type.fieldprint) };
            //"幢号", "条码", "开始时间", "结束时间", "电池型号", "电池等级", "记录时间", "打印"
            string[] colss = { "zh", "tm", "kstime", "jstime", "dcxh", "dcdj", "jlsj", "dayin" };
            string[] vcols = { };
            List<string> vcolsList = new List<string>();
            if (!showTime)
            {
                vcolsList.Add(q(Msg_Type.fieldkssj));
                vcolsList.Add(q(Msg_Type.fieldjssj));
                vcolsList.Add(q(Msg_Type.fieldjltime));
            }
            ConfigDataGrid(cols, colss, JLdataGridView, vcolsList.ToArray());
        }
        public void ConfigDataGrid(string[] cols, string[] colss, DataGridView datagridGiew, string[] vcols)
        {
            for (int i = 0; i < cols.Length; i++)
            {
                if (cols[i] == q(Msg_Type.fielddelete) || cols[i] == q(Msg_Type.fieldmodify) || cols[i] == q(Msg_Type.fieldprint))//"删除" "修改" "打印"
                {
                    DataGridViewButtonColumn acCode = new DataGridViewButtonColumn();
                    acCode.Name = cols[i];
                    acCode.DataPropertyName = colss[i];
                    acCode.UseColumnTextForButtonValue = true;
                    acCode.Text = cols[i];
                    acCode.HeaderText = cols[i];
                    acCode.Width = 113;
                    datagridGiew.Columns.Add(acCode);
                }
                else
                {
                    DataGridViewTextBoxColumn acCode = new DataGridViewTextBoxColumn();
                    acCode.Name = cols[i];
                    acCode.DataPropertyName = colss[i];
                    acCode.HeaderText = cols[i];

                    if (cols[i] == q(Msg_Type.fieldjltime) || cols[i] == q(Msg_Type.fieldkssj) || cols[i] == q(Msg_Type.fieldjssj))//"记录时间" "开始时间"  "结束时间"
                    {
                        acCode.Width = 190;
                        //acCode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                    else if (cols[i] == q(Msg_Type.fieldzh) ||cols[i] == q(Msg_Type.fielddcdj))//"幢号" "电池等级"
                    {
                        acCode.Width = 60;
                    }
                    else
                    {
                        acCode.Width = 120;
                    }
                    
                   
                    if (vcols.Count(p => p == cols[i]) > 0)
                    {
                        acCode.Visible = false;
                    }

                    datagridGiew.Columns.Add(acCode);

                }


            }
            datagridGiew.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            datagridGiew.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //datagridGiew.RowTemplate.Height = 35;
            datagridGiew.RowTemplate.DefaultCellStyle.Font = new Font(q(Msg_Type.fonttype), 11);
            foreach (DataGridViewColumn item in datagridGiew.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        public void configgridviewData(string rbbh)
        {
            Gridview = new List<gridview>();
            SELECT_MES_PD_SCRW_ZX_LIST res = ServicModel.PD_SCRW.SELECT_ZX_LIST(rbbh, getToken());
            if (res.MES_RETURN.TYPE.Equals("S"))
            {
                
                for (int i = 0; i < res.MES_TM_TMINFO_LIST.Length; i++)
                {
                    Sonluk.UI.Model.MES.PD_SCRWService.MES_TM_TMINFO_LIST data = res.MES_TM_TMINFO_LIST[i];
                    gridview node = new gridview();
                    node.Zh = data.TH;
                    //node.Ksrq = Convert.ToDateTime(data.KSTIME).ToString("yyyy-MM-dd");
                    //node.Kssj = Convert.ToDateTime(data.KSTIME).ToString("HH:mm");
                    //node.Jsrq = Convert.ToDateTime(data.JSTIME).ToString("yyyy-MM-dd");
                    //node.Jssj = Convert.ToDateTime(data.JSTIME).ToString("HH:mm");

                    if (!string.IsNullOrEmpty(data.KSTIME))
                    {
                        node.Kstime = Convert.ToDateTime(data.KSTIME).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    else
                    {
                        node.Kstime = "";
                    }
                    if (!string.IsNullOrEmpty(data.JSTIME))
                    {
                        node.Jstime = Convert.ToDateTime(data.JSTIME).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    else
                    {
                        node.Jstime = "";
                    }

                    node.Tm = data.TM;
                    node.Dcxh = data.DCXHMS;
                    node.Dcdj = data.DCDJMS;
                    node.Jlsj = data.JLTIME;
                    Gridview.Add(node);

                }
                Gridview = (from o in Gridview orderby o.Zh select o).ToList();
                JLdataGridView.DataSource = Gridview;
                JLdataGridView.ClearSelection();
            }
            else
            {
                ShowMeg(res.MES_RETURN.MESSAGE);
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
                    //MessageBox.Show("你扫描的是无效的条码！！", "消息框");
                    ShowMeg(q(Msg_Type.msgscantminvalid));
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
            model.ISREPLACE = 1;
            MES_RETURN_UI res = AddCzr(model);
            if (res.TYPE.Equals("S"))
            {
                _czrList = SelectCZR(model);
                czrytextbox.Text = _czrList.CZR;
            }
            else
            {
                //MessageBox.Show(res.MESSAGE, "消息框");
                ShowMeg(res.MESSAGE);
            }
            SMtextBox.Clear();
            SMtextBox.Select();
        }
     

        private void scrqtext_Click(object sender, EventArgs e)
        {
            //monthCalendar1.Visible = true;
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

            //scrqtextBox.Text = Convert.ToDateTime(monthCalendar1.SelectionStart.ToShortDateString()).ToString("yyyy-MM-dd");
            //monthCalendar1.Visible = false;
        }

        private void addsdbutton_Click(object sender, EventArgs e)
        {
            ZBCFUN_GDJGXX_READ r = ServicModel.PD_GD.SAP_GET_GDJGXX(MES_PD_SCRW_LIST.RWBH, MES_PD_SCRW_LIST.ZPRQ, MES_PD_SCRW_LIST.GC, getToken());
            if (!r.MES_RETURN.TYPE.Equals("S"))
            {
                ShowMeg(r.MES_RETURN.MESSAGE);
                SMtextBox.Select();
                return;
            }
            if (string.IsNullOrEmpty(czrytextbox.Text.Trim()))
            {
                ShowMeg(q(Msg_Type.msgczrnoempty));//"操作人员不能为空,请扫码添加操作人员"
                SMtextBox.Select();
                return;
            }
            frmZXprint form = new frmZXprint(MES_PD_SCRW_LIST,dateTimePicker1.Text.Trim());
            
            form.block = configgridviewData;
            show(form);
            SMtextBox.Select();
        }

        private void zfsddybutton_Click(object sender, EventArgs e)
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
            if (string.IsNullOrEmpty(czrytextbox.Text.Trim()))
            {
                ShowMeg(q(Msg_Type.msgczrnoempty));//"操作人员不能为空,请扫码添加操作人员"
                SMtextBox.Select();
                return;
            }
            frmZFSDprint form = new frmZFSDprint(MES_PD_SCRW_LIST, dateTimePicker1.Text.Trim());
            form.block = configgridviewData;
            show(form);


        }








        private void rwqhbutton_Click(object sender, EventArgs e)
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
            if (Smodel.MES_PD_SCRW_LIST.Length == 1)
            {
                //MessageBox.Show(_MES_PD_SCRW_LIST.SBH + "的当天任务派单只有一个", "消息框");
                ShowMeg(string.Format(q(Msg_Type.msgrwonlyone), _MES_PD_SCRW_LIST.SBH));
                SMtextBox.Select();
                return;
            }
            else
            {
                frmChange_GD form = new frmChange_GD(Smodel.MES_PD_SCRW_LIST, model.SBBH, RigthType);
                form.block = RefreshRW;
                show(form);
                //show(form);
            }
            SMtextBox.Select();
        }
        public void RefreshRW(MES_PD_SCRW_LIST list, string shebeihaoID)
        {
            MES_PD_SCRW_LIST = list;
            //monthCalendar1.Visible = false;
            configUI(MES_PD_SCRW_LIST);

           
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
            //MES_PD_SCRW model = new MES_PD_SCRW();
            //model.SBHID = SBHID;
            czrytextbox.Text = _czrList.CZR;
            //SELECT_MES_PD_SCRW Smodel = ServicModel.PD_SCRW.SELECT(model, getToken());
            SMtextBox.Select();
        }

        private void pctextBox_TextChanged(object sender, EventArgs e)
        {

        }

        public class gridview
        {
            // "zh", "ksrq", "kssj", "jsrq", "jssj", "dcxh", "dcdj","jlsj","shanchu","xiugai","dayin"
            string _tm;

            public string Tm
            {
                get { return _tm; }
                set { _tm = value; }
            }
            int _zh;

            public int Zh
            {
                get { return _zh; }
                set { _zh = value; }
            }
            string _kstime;

            public string Kstime
            {
                get { return _kstime; }
                set { _kstime = value; }
            }

            string _jstime;

            public string Jstime
            {
                get { return _jstime; }
                set { _jstime = value; }
            }


            string _dcxh;

            public string Dcxh
            {
                get { return _dcxh; }
                set { _dcxh = value; }
            }
            string _dcdj;

            public string Dcdj
            {
                get { return _dcdj; }
                set { _dcdj = value; }
            }
            string _jlsj;

            public string Jlsj
            {
                get { return _jlsj; }
                set { _jlsj = value; }
            }
            //string _shanchu;

            //public string Shanchu
            //{
            //    get { return _shanchu; }
            //    set { _shanchu = value; }
            //}

            string _dayin;

            public string Dayin
            {
                get { return _dayin; }
                set { _dayin = value; }
            }
            

        }

        private void JLdataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (this.JLdataGridView.CurrentCell.OwningColumn.Name == q(Msg_Type.fielddelete))//"删除"
                {
                    //string tm = Convert.ToString(this.JLdataGridView.CurrentRow.Cells["条码"].Value);
                    //if (MessageBox.Show("是否确认删除条码" + tm, "消息框", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    //{
                    //    MES_RETURN_UI res = ServicModel.TM_TMINFO.DELETE(tm, getToken());
                    //    if (res.TYPE.Equals("S"))
                    //    {
                    //        configgridviewData(MES_PD_SCRW_LIST.RWBH);
                    //        ShowMeg("删除成功");
                    //    }
                    //    else
                    //    {
                    //        ShowMeg(res.MESSAGE);
                    //    }
                    //}

                }
                else if (this.JLdataGridView.CurrentCell.OwningColumn.Name == q(Msg_Type.fieldprint))//"打印"
                {
                    string tm = Convert.ToString(this.JLdataGridView.CurrentRow.Cells[q(Msg_Type.fieldtm)].Value);//"条码"
                    frmPrintTM form = new frmPrintTM(tm, Rigth_Type.zhuxiancc, Print_Type.zxlot);
                    show(form);
                }
            }
            
        }

        private void frmZX_CC_Shown(object sender, EventArgs e)
        {
            JLdataGridView.ClearSelection();
            SMtextBox.Select();
        }

        private void qhsbhbutton_Click(object sender, EventArgs e)
        {
            MES_SY_GZZX_SBH model = new MES_SY_GZZX_SBH();
            model.GZZXBH = MES_PD_SCRW_LIST.GZZXBH;
            model.GC = MES_PD_SCRW_LIST.GC;
            model.WLLBNAME = GetWLLBName(RigthType);
            MES_SY_GZZX_SBH[] list = ServicModel.SY_GZZX_SBH.SELECT(model, getToken());
            frmFindSBH form = new frmFindSBH(list, MES_PD_SCRW_LIST.GZZXNAME, RigthType,true);

            push(form,this);
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
            frmZX_TL form = new frmZX_TL(MES_PD_SCRW_LIST, MES_PD_SCRW_LIST.SBBH, Rigth_Type.zhujizhengjitl); ;
            push(form,this);
            SMtextBox.Select();
        }

        private void JLdataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (this.JLdataGridView.CurrentCell.OwningColumn.Name.Equals(q(Msg_Type.fieldtm) ))//"条码"
                {
                    string tm = Convert.ToString(this.JLdataGridView.CurrentRow.Cells[q(Msg_Type.fieldtm)].Value);//"条码"
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
                                ShowMeg(q(Msg_Type.msgloadtmfail));//"读取扫描条码信息失败"
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
