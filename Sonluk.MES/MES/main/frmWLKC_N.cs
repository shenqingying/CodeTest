using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Sonluk.MES.MES.Base;
using Sonluk.UI.Model.MES.MES_WLKCBSService;
using Sonluk.UI.Model.MES.MM_CKService;
using Sonluk.UI.Model.MES.SY_GCService;
using Sonluk.UI.Model.MES.TM_TMINFOService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Sonluk.MES.MES.main
{
    public partial class frmWLKC_N : baseview
    {
        List<ZSL_BCS303_BS> _list;

        public List<ZSL_BCS303_BS> List
        {
            get { return _list; }
            set { _list = value; }
        }

       
        List<ZSL_BCS303_BS> _choiceList;

        public List<ZSL_BCS303_BS> ChoiceList
        {
            get { return _choiceList; }
            set { _choiceList = value; }
        }
        public frmWLKC_N()
        {
            InitializeComponent();
        }
        public frmWLKC_N(Rigth_Type rtype)
        {
            InitializeComponent();
            List = new List<ZSL_BCS303_BS>();
            ChoiceList = new List<ZSL_BCS303_BS>();
            //monthCalendar1.Visible = false;
            //monthCalendar2.Visible = false;
            RigthType = rtype;
            MES_SY_GC gcmodel = new MES_SY_GC();

            JLdataGridView.AutoGenerateColumns = false;
            gcmodel.STAFFID = Convert.ToInt32(getUserInfo("staffid"));
            List<MES_SY_GC> gcList = ServicModel.SY_GC.SELECT_BY_ROLE(gcmodel, getToken()).ToList();
            for (int i = 0; i < gcList.Count; i++)
            {
                gcList[i].GCMS = gcList[i].GC + "-" + gcList[i].GCMS;
            }
            MES_SY_GC gcchoose = new MES_SY_GC();
            gcchoose.GC = "0";
            gcchoose.GCMS = q(Msg_Type.titlechoice);//"==请选择==";
            gcList.Insert(0, gcchoose);

            gccomboBox.DisplayMember = "GCMS";
            gccomboBox.ValueMember = "GC";
            gccomboBox.DataSource = gcList.ToList();

            List<MES_MM_CK> ckList = new List<MES_MM_CK>();
            MES_MM_CK ckchoise = new MES_MM_CK();
            ckchoise.CKDM = "0";
            ckchoise.CKMS = q(Msg_Type.titlechoice);//"==请选择==";
            ckList.Add(ckchoise);
            kcdfcomboBox.DataSource = ckList;
            kcdfcomboBox.DisplayMember = "CKMS";
            kcdfcomboBox.ValueMember = "CKDM";          
            //MES_MM_CK ckmodel = new MES_MM_CK();
            //ckmodel.STAFFID = Convert.ToInt32(getUserInfo("staffid"));
            //ckmodel.GC = Convert.ToString(gccomboBox.SelectedValue);
            //MES_MM_CK_SELECT ckres = ServicModel.MM_CK.SELECT_BY_STAFFID(ckmodel,getToken());
            //if (ckres.MES_RETURN.TYPE.Equals("S"))
            //{
            //    for (int i = 0; i < ckres.MES_MM_CK.Length; i++)
            //    {
            //        ckres.MES_MM_CK[i].CKMS = ckres.MES_MM_CK[i].CKDM + "-" + ckres.MES_MM_CK[i].CKMS;
            //    }
            //    kcdfcomboBox.DataSource = ckres.MES_MM_CK;
            //    kcdfcomboBox.DisplayMember = "CKMS";
            //    kcdfcomboBox.ValueMember = "CKDM";               
            //}
            slrqfromdateTimePicker.Text = DateTime.Now.ToString("yyyy-MM-dd 00:00:00");
            slrqtodateTimePicker.Text = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");

        }
        private void cxbutton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(slrqfromdateTimePicker.Text.Trim()))
            {
                //ShowMeg("输入开始时间不能为空");
                ShowMeg(q(Msg_Type.msgslkssjnoempty));
                return;
            }
            if (string.IsNullOrEmpty(slrqtodateTimePicker.Text.Trim()))
            {
                //ShowMeg("输入结束时间不能为空");
                ShowMeg(q(Msg_Type.msgsljssjnoempty));
                return;
            }
            TimeSpan slrqtspan = Convert.ToDateTime(slrqfromdateTimePicker.Text.Trim()) - Convert.ToDateTime(slrqtodateTimePicker.Text.Trim());
            if (slrqtspan.Minutes > 0)
            {
                //ShowMeg("输入开始日期不能大于输入结束日期");
                ShowMeg(q(Msg_Type.msgslksqtjs));
                return;
            }

            ZSL_BCS303_CT zModel = new ZSL_BCS303_CT();
            if (!string.IsNullOrEmpty(gzrqfromtextBox.Text.Trim()))
            {
                if (judge.IsDate(gzrqfromtextBox.Text.Trim()) == false)
                {
                    //ShowMeg("过账开始日期不是正确的日期格式");
                    ShowMeg(q(Msg_Type.msggzksformat));
                    return;
                };
                zModel.BUDAT_ST = Convert.ToDateTime(gzrqfromtextBox.Text.Trim()).ToString("yyyyMMdd");
            }
            if (!string.IsNullOrEmpty(gzrqtotextBox.Text.Trim()))
            {
                if (judge.IsDate(gzrqtotextBox.Text.Trim()) == false)
                {
                    //ShowMeg("过账结束日期不是正确的日期格式");
                    ShowMeg(q(Msg_Type.msggzjsformat));
                    return;
                }
                zModel.BUDAT_ED = Convert.ToDateTime(gzrqtotextBox.Text.Trim()).ToString("yyyyMMdd");
            }
            if (!string.IsNullOrEmpty(gzrqtotextBox.Text.Trim()) && !string.IsNullOrEmpty(gzrqtotextBox.Text.Trim()))
            {
                TimeSpan tspan = Convert.ToDateTime(gzrqtotextBox.Text.Trim()) - Convert.ToDateTime(gzrqfromtextBox.Text.Trim());
                if (tspan.Days < 0)
                {
                    //ShowMeg("过账开始日期不能大于过账结束日期");
                    ShowMeg(q(Msg_Type.msggzksqtjs));
                    return;
                }
            }
            //if (!string.IsNullOrEmpty(gzrqfromtextBox.Text.Trim()))
            //{
            //    if (judge.IsDate(gzrqfromtextBox.Text.Trim()) == false)
            //    {
            //        ShowMeg("过账开始日期不是正确的日期格式");
            //        return;
            //    };
            //    zModel.BUDAT_ST = Convert.ToDateTime(gzrqfromtextBox.Text.Trim()).ToString("yyyyMMdd");
            //}
            //if (!string.IsNullOrEmpty(gzrqtotextBox.Text.Trim()))
            //{
            //    if (judge.IsDate(gzrqtotextBox.Text.Trim()) == false)
            //    {
            //        ShowMeg("过账结束日期不是正确的日期格式");
            //        return;
            //    }
            //    zModel.BUDAT_ED = Convert.ToDateTime(gzrqtotextBox.Text.Trim()).ToString("yyyyMMdd");
            //}
           
            //if (!Convert.ToDateTime(gzrqfromdateTimePicker.Text.Trim()).ToString("yyyy-MM-dd").Equals("1900-01-01"))
            //{
            //    zModel.BUDAT_ST = Convert.ToDateTime(gzrqfromdateTimePicker.Text.Trim()).ToString("yyyyMMdd");
            //}
            //if (!Convert.ToDateTime(gzrqtodateTimePicker.Text.Trim()).ToString("yyyy-MM-dd").Equals("9998-12-31"))
            //{
            //    zModel.BUDAT_ED = Convert.ToDateTime(gzrqtodateTimePicker.Text.Trim()).ToString("yyyyMMdd");
            //}
            if (!string.IsNullOrEmpty(wlpztextBox.Text.Trim()) )
            {
                if (judge.IsNumber(wlpztextBox.Text.Trim()) && wlpztextBox.Text.Trim().Length == 10)
                {
                    zModel.MBLNR = wlpztextBox.Text.Trim();
                }
                else
                {
                    ShowMeg(q(Msg_Type.msgwlpzlengthtendigital));//"物料凭证是10位数的数字"
                    return;
                }
                
            }
            if (!string.IsNullOrEmpty(tmtextBox.Text.Trim()))
            {
                if (tmtextBox.Text.Length != 12)
                {
                    ShowMeg(q(Msg_Type.msgtmlengthtwelve));//"条码长度不正确,正确的条码长度是12位"
                    return;
                }
                else
                {
                    zModel.TM = tmtextBox.Text.Trim().ToUpper();
                }               
            }
            if (!Convert.ToString(gccomboBox.SelectedValue).Equals("0"))
            {
                zModel.WERKS = Convert.ToString(gccomboBox.SelectedValue);
            }
            else
            {
                ShowMeg(q(Msg_Type.msggcnoempty));//"工厂信息不能为空"
                return;
            }
            if (!string.IsNullOrEmpty(pctextBox.Text.Trim()))
            {
                zModel.CHARG = pctextBox.Text.Trim();
            }
            if (!string.IsNullOrEmpty(wlbmtextBox.Text.Trim()))
            {
                zModel.MATNR = wlbmtextBox.Text.Trim();
            }
            if (!string.IsNullOrEmpty(cgddtextBox.Text.Trim()))
            {
                zModel.EBELN = cgddtextBox.Text.Trim();
            }
            if (!string.IsNullOrEmpty(gystextBox.Text.Trim()))
            {
                zModel.LIFNR = gystextBox.Text.Trim();
            }

            //if (!string.IsNullOrEmpty(gzrqfromtextBox.Text.Trim()) && !string.IsNullOrEmpty(gzrqtotextBox.Text.Trim()))
            //{
            //    if (Convert.ToDateTime(gzrqfromtextBox.Text.Trim()) > Convert.ToDateTime(gzrqtotextBox.Text.Trim()))
            //    {
            //        ShowMeg("过账开始日期不能大于结束日期");
            //        return;
            //    }
            //}


            zModel.ISNOTPRINT = wdycheckBox.Checked;
            zModel.CPUDT_ST = Convert.ToDateTime(slrqfromdateTimePicker.Text).ToString("yyyyMMdd");
            zModel.CPUDT_ED = Convert.ToDateTime(slrqtodateTimePicker.Text).ToString("yyyyMMdd");
            zModel.CPUTM_ST = Convert.ToDateTime(slrqfromdateTimePicker.Text).ToString("HHmmss");
            zModel.CPUTM_ED = Convert.ToDateTime(slrqtodateTimePicker.Text).ToString("HHmmss");
            zModel.STAFFID = Convert.ToInt32(getUserInfo("staffid"));
            if (dbpzcheckBox.Checked)
            {
                zModel.DBBS = "Y";
                if (Convert.ToString(kcdfcomboBox.SelectedValue).Equals("0"))
                {
                    ShowMeg(q(Msg_Type.msgdbpzneedkcdf));//"调拨凭证必须输入库存地点"
                    return;
                }
            }
            else
            {
                zModel.DBBS = "";
            }
            if (!Convert.ToString(kcdfcomboBox.SelectedValue).Equals("0"))
            {
                zModel.LGORT = Convert.ToString(kcdfcomboBox.SelectedValue);
            }
            ZBCFUN_PURBS_READ res = ServicModel.MES_WLKCBS.GET_WLPZ(zModel, getToken());
            if (res.MES_RETURN.TYPE.Equals("S"))
            {
                if (res.ET_PURBS.Length == 0)
                {
                    
                    List = new List<ZSL_BCS303_BS>();
                    JLdataGridView.DataSource = List;
                    Type type = JLdataGridView.GetType();
                    PropertyInfo pi = type.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
                    pi.SetValue(JLdataGridView, true, null);
                    ShowMeg(q(Msg_Type.msgnodata));//"未查询到数据"
                }
                else
                {
                    List = res.ET_PURBS.ToList();
                    //for (int i = 0; i < List.Count; i++)
                    //{
                    //    List[i].QSTH = "1";
                    //}
                    JLdataGridView.DataSource = res.ET_PURBS.ToList();
                    JLdataGridView.ClearSelection();

                    Type type = JLdataGridView.GetType();
                    PropertyInfo pi = type.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
                    pi.SetValue(JLdataGridView, true, null);
                }                
            }
            else
            {
                List = new List<ZSL_BCS303_BS>();
                JLdataGridView.DataSource = List;
                Type type = JLdataGridView.GetType();
                PropertyInfo pi = type.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
                pi.SetValue(JLdataGridView, true, null);
                ShowMeg(res.MES_RETURN.MESSAGE);
            }
        }
        
        private void qxbutton_Click(object sender, EventArgs e)
        {
            if (List.Count == 0)
            {
                //ShowMeg("没有物料凭证数据点击无效");
                ShowMeg(q(Msg_Type.msgnowlpzclickinvalid));
                return;
            }
            SetAllRowChecked(CheckBoxType.all);
        }

        private void qcbutton_Click(object sender, EventArgs e)
        {
            if (List.Count == 0)
            {
                //ShowMeg("没有物料凭证数据点击无效");
                ShowMeg(q(Msg_Type.msgnowlpzclickinvalid));
                return;
            }
            SetAllRowChecked(CheckBoxType.none);
        }

        private void fxbutton_Click(object sender, EventArgs e)
        {
            if (List.Count == 0)
            {
                //ShowMeg("没有物料凭证数据点击无效");
                ShowMeg(q(Msg_Type.msgnowlpzclickinvalid));
                return;
            }
            SetAllRowChecked(CheckBoxType.reverse);
        }

        private void dybutton_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(numericUpDown1.Value)<1)
            {
                //ShowMeg("打印分数必须大于0");
                ShowMeg(q(Msg_Type.msgprintnoempty));
                return;
            }
            if (List.Count == 0)
            {
                //ShowMeg("没有物料凭证数据点击无效");
                ShowMeg(q(Msg_Type.msgprintnoempty));
                return;
            }
            ChoiceList = new List<ZSL_BCS303_BS>();
            List<ZSL_BCS303_BS> nodes1 = (List<ZSL_BCS303_BS>)JLdataGridView.DataSource;
            int count = 0;
            for (int i = 0; i < JLdataGridView.Rows.Count; i++)
            {
                if (this.JLdataGridView.Rows[i].Cells[0].EditedFormattedValue.ToString() == "True") //checkbox的是否勾选
                {
                    count++;
                    nodes1[i].JLR = Convert.ToInt32(getUserInfo("staffid"));
                    nodes1[i].TMSX = (int)Print_Type.wlrk;
                    nodes1[i].TMLB = 1;
                    nodes1[i].MAC = DeviceInfo.GetNetCardMAC().Substring(0, 17);
                    ChoiceList.Add(nodes1[i]);
                }
            }
            bool isPass = true;
            for (int i = 0; i < ChoiceList.Count; i++)
            {
                if (ChoiceList[i].XCBS.Equals("Y")&&string.IsNullOrEmpty(ChoiceList[i].XCZJTM))
                {
                    ShowMeg(ChoiceList[i].MBLNR + "-" + ChoiceList[i].ZEILE + q(Msg_Type.msgneedxcm));//"需要绑定下层码信息"
                    isPass = false;
                    break;
                }
            }


            if (isPass)
            {
                if (count == 0)
                {
                    ShowMeg(q(Msg_Type.msgatleastone));//"请至少选择一条数据"
                    return;
                }
                else
                {
                    ZBCFUN_PURBS_READ res = ServicModel.MES_WLKCBS.INSERT_TM_WLPZ(ChoiceList.ToArray(),1, getToken());
                    if (res.MES_RETURN.TYPE.Equals("S"))
                    {
                        //model.MBLNR = list.MBLNR;
                        //model.XCBS = list.XCBS;
                        //model.MJAHR = list.MJAHR;
                        //model.LINE_ID = list.LINE_ID;
                        //model.LIFNR = list.LIFNR;
                        if (res.ET_PURBS.Length > 0)
                        {
                            for (int i = 0; i < res.ET_PURBS.Length; i++)
                            {
                                for (int j = 0; j < List.Count; j++)
                                {
                                    //遍历数据表格根据物料凭证、物料凭证年度、物料凭证项
                                    if (res.ET_PURBS[i].MBLNR == List[j].MBLNR && res.ET_PURBS[i].MJAHR == List[j].MJAHR && res.ET_PURBS[i].LINE_ID == List[j].LINE_ID)
                                    {
                                        List[j].TM = res.ET_PURBS[i].TM;
                                    }
                                }
                            }
                        }
                        JLdataGridView.DataSource = new List<ZSL_BCS303_BS>();
                        JLdataGridView.DataSource = List;
                        JLdataGridView.ClearSelection();
                        Type type = JLdataGridView.GetType();
                        PropertyInfo pi = type.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
                        pi.SetValue(JLdataGridView, true, null);
                        PrintWLKC(ChoiceList, Convert.ToInt32(numericUpDown1.Value),Print_Type.wlrk);
                    


                    }
                    else
                    {
                        ShowMeg(res.MES_RETURN.MESSAGE);
                    }
                }
            }


            

        }

        private void dcbutton_Click(object sender, EventArgs e)
        {
            if (List.Count == 0)
            {
                ShowMeg(q(Msg_Type.msgnowlpzclickinvalid));//"没有物料凭证数据点击无效"
                return;
            }
            ChoiceList = new List<ZSL_BCS303_BS>();

            List<ZSL_BCS303_BS> nodes = (List<ZSL_BCS303_BS>)JLdataGridView.DataSource;
            int count = 0;
            for (int i = 0; i < JLdataGridView.Rows.Count; i++)
            {
                if (this.JLdataGridView.Rows[i].Cells[0].EditedFormattedValue.ToString() == "True") //checkbox的是否勾选
                {
                    count++;
                    ChoiceList.Add(nodes[i]);
                }
            }
            if (count == 0)
            {
                ShowMeg(q(Msg_Type.msgchoiceexportdata));//"请选择你要导出的数据"
                return;
            }
           
            PrintExcel(ChoiceList);
        }

        private void xcmthbutton_Click(object sender, EventArgs e)
        {

        }

      

        private void frmWLKC_Load(object sender, EventArgs e)
        {

        }

        private void gzrqfromtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //judge.isNum(gzrqfromtextBox, e);
        }

        private void gzrqtotextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //judge.isNum(gzrqtotextBox, e);
        }

        private void wlpztextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //judge.isNum(gzrqtotextBox, e);
        }

        private void tmtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //judge.isNum(gzrqtotextBox, e);
        }

        private void pctextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //judge.isNum(gzrqtotextBox, e);
        }

        private void wlbmtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //judge.isNum(gzrqtotextBox, e);
        }

        private void cgddtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //judge.isNum(gzrqtotextBox, e);
        }

        private void gystextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //judge.isNum(gzrqtotextBox, e);
        }

        private void gzrqfromtextBox_Click(object sender, EventArgs e)
        {
            //monthCalendar1.Visible = true;
            
        }

        private void gzrqtotextBox_Click(object sender, EventArgs e)
        {
            //monthCalendar2.Visible = true;
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            //gzrqfromtextBox.Text = Convert.ToDateTime(monthCalendar1.SelectionStart.ToShortDateString()).ToString("yyyy-MM-dd");
            //monthCalendar1.Visible = false;
        }

        private void monthCalendar2_DateChanged(object sender, DateRangeEventArgs e)
        {
            //gzrqtotextBox.Text = Convert.ToDateTime(monthCalendar2.SelectionStart.ToShortDateString()).ToString("yyyy-MM-dd");
            //monthCalendar2.Visible = false;
        }
        enum CheckBoxType
        {
            all = 1,
            none = 2,
            reverse
        }
        private void SetAllRowChecked(CheckBoxType type)
        {
           
            int count = Convert.ToInt16(this.JLdataGridView.Rows.Count.ToString());
            for (int i = 0; i < count; i++)
            {
                DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)JLdataGridView.Rows[i].Cells["cbox"];
                
                if (type == CheckBoxType.all)
                {
                    checkCell.Value = true;
                }
                else if (type == CheckBoxType.none)
                {
                    checkCell.Value = false;
                }
                else if (type == CheckBoxType.reverse)
                {
                    //Boolean flag = Convert.ToBoolean(checkCell.Value);
                    checkCell.Value = !Convert.ToBoolean(checkCell.Value);
                }
               
                continue;
            }
        }

        private void JLdataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
           

        }

        private void JLdataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex != -1)
            {
                if (this.JLdataGridView.CurrentCell.OwningColumn.Name == "XCBS")
                {
                    string content = Convert.ToString(this.JLdataGridView.CurrentRow.Cells["XCBS"].Value);
                    int index = this.JLdataGridView.CurrentRow.Index;
                    if (content.Equals("Y"))
                    {
                        frmBindXCM form = new frmBindXCM(List[index], index);
                        form.block = UpdateXCM;
                        show(form);
                    }
                }
            }
           
        }
        public void UpdateXCM(string xcmStr, int rowIndex)
        {
            JLdataGridView.DataSource = List;
            List[rowIndex].XCZJTM = xcmStr;
            JLdataGridView.DataSource = new List<ZSL_BCS303_BS>();
            JLdataGridView.DataSource = List;
            //JLdataGridView.ClearSelection();
            Type type = JLdataGridView.GetType();
            PropertyInfo pi = type.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(JLdataGridView, true, null);
        }
        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            //gzrqfromtextBox.Text = Convert.ToDateTime(monthCalendar1.SelectionStart.ToShortDateString()).ToString("yyyy-MM-dd");
            //monthCalendar1.Visible = false;
        }

        private void monthCalendar2_DateSelected(object sender, DateRangeEventArgs e)
        {
            //gzrqtotextBox.Text = Convert.ToDateTime(monthCalendar2.SelectionStart.ToShortDateString()).ToString("yyyy-MM-dd");
            //monthCalendar2.Visible = false;
        }

        private void gzrqfromtextBox_TextChanged(object sender, EventArgs e)
        {
            //if (gzrqfromtextBox.Text.Length == 0)
            //{
            //     monthCalendar1.Visible = false;
            //}
        }

        private void gzrqtotextBox_TextChanged(object sender, EventArgs e)
        {
            //if (gzrqtotextBox.Text.Length == 0)
            //{
            //    monthCalendar2.Visible = false;
            //}
        }
        public DataGridViewTextBoxEditingControl CellEdit = null;
        private void JLdataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int a = this.JLdataGridView.CurrentCellAddress.X;
            if ((this.JLdataGridView.CurrentCellAddress.X == 7) || (this.JLdataGridView.CurrentCellAddress.X == 8) || (this.JLdataGridView.CurrentCellAddress.X == 9 || this.JLdataGridView.CurrentCellAddress.X == 11 || this.JLdataGridView.CurrentCellAddress.X == 12))
            {
                CellEdit = (DataGridViewTextBoxEditingControl)e.Control;
                //CellEdit.SelectAll();
                CellEdit.KeyPress += Cells_KeyPress; //绑定事件
              
            }
        }
        private void Cells_KeyDown(object sender, KeyPressEventArgs e) //自定义事件
        { 

        }
        private void Cells_KeyPress(object sender, KeyPressEventArgs e) //自定义事件
        {
            if (CellEdit.Text.Length > 8)
            {
                ShowMeg(q(Msg_Type.msglengthqteigth));//"输入长度不能大于8位"
                return;
            }
            if ((this.JLdataGridView.CurrentCellAddress.X == 7) || (this.JLdataGridView.CurrentCellAddress.X == 8) || (this.JLdataGridView.CurrentCellAddress.X == 9) || (this.JLdataGridView.CurrentCellAddress.X == 11))
            {
                //if (!(e.KeyChar >= '0' && e.KeyChar <= '9')) e.Handled = true;
                //if (e.KeyChar == '\b') e.Handled = false;
                //judge.isNum(CellEdit, e);
                e.Handled = false;
            }
        }
        public void PrintExcel(List<ZSL_BCS303_BS> list)
        {

            IWorkbook excel = new XSSFWorkbook();//创建.xls文件
            ISheet sheet = excel.CreateSheet("sheet1"); //创建sheet           
            IRow row = sheet.CreateRow(0);//创建行对象，填充表头
            string[] headStr = q(Msg_Type.fieldwlkcArr).Split(',');//{ "物料凭证", "项目", "年度", "条码", "下层码", "托数", "托数量", "箱数", "物料编码", "物料描述", "工厂", "库存地点", "库存地点描述", "采购订单", "项目", "批次", "销售订单","项目", "供应商编码", "简称", "过账日期", "工艺", "设备(模)号", "材料厂家" };
            for (int i = 0; i < headStr.Length; i++)
            {
                row.CreateCell(i).SetCellValue(headStr[i]);
            }           
            //填充内容，j从1开始，屏蔽掉第一列，循环读取
            for (int i = 0; i < ChoiceList.Count; i++)
            {
                row = sheet.CreateRow(i + 1);
                ZSL_BCS303_BS node = ChoiceList[i];                
                string[] content = { node.MBLNR, node.ZEILE, node.MJAHR, node.TM, node.XCZJTM, node.TS.ToString(), node.MENGE, node.XS.ToString(), node.MATNR, node.MAKTX, node.WERKS, node.LGORT, node.LGOBE, node.EBELN, node.EBELP, node.CHARG, node.MAT_KDAUF, node.MAT_KDPOS, node.LIFNR, node.SORTL, node.BUDAT, node.GY, node.SBH, node.CLCJ };
                for (int j = 0; j < content.Length; j++)
                {
                    row.CreateCell(j).SetCellValue(content[j]);                   
                }               
            }
            SaveFileDialog Sfd = new SaveFileDialog();
            Sfd.Filter = "Excel文件(*.xlsx)|*.xlsx";
            Sfd.FileName = q(Msg_Type.titlewlrkdc) + DateTime.Now.ToString("yyyyMMddHHmmss");//"物流入库导出"
            
            if (Sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileStream file3 = new FileStream(Sfd.FileName, FileMode.Create);
                excel.Write(file3);
                file3.Close();
                //MessageBox.Show("成功导出为Excel！");
                ShowMeg(q(Msg_Type.msgexportsuccess));
            }
            //MessageBox.Show("Excel文件已导出到桌面", "提示");
        }

        private void gccomboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            object obj = cb.SelectedValue;
            MES_MM_CK ckmodel = new MES_MM_CK();
            if (obj is string)
            {
                ckmodel.STAFFID = Convert.ToInt32(getUserInfo("staffid"));
                ckmodel.GC = Convert.ToString(gccomboBox.SelectedValue);
            }
            else
            {

            }
            MES_MM_CK_SELECT ckres = ServicModel.MM_CK.SELECT_BY_STAFFID(ckmodel, getToken());
            if (ckres.MES_RETURN.TYPE.Equals("S"))
            {
                for (int i = 0; i < ckres.MES_MM_CK.Length; i++)
                {
                    ckres.MES_MM_CK[i].CKMS = ckres.MES_MM_CK[i].CKDM + "-" + ckres.MES_MM_CK[i].CKMS;
                }
                List<MES_MM_CK> ckList = ckres.MES_MM_CK.ToList();

                MES_MM_CK ckchoise = new MES_MM_CK();
                ckchoise.CKDM = "0";
                ckchoise.CKMS = q(Msg_Type.titlechoice);// "==请选择==";
                ckList.Insert(0, ckchoise);
                kcdfcomboBox.DataSource = ckList;
                kcdfcomboBox.DisplayMember = "CKMS";
                kcdfcomboBox.ValueMember = "CKDM";

            }
        }

     
        private void gzrqtodateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void srsjfromdateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void srsjtodateTimePicker4_ValueChanged(object sender, EventArgs e)
        {

        }

        private void gzrqfromdateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_Leave(object sender, EventArgs e)
        {
            //monthCalendar1.Visible = false;
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    monthCalendar1.Visible = true;
        //}

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    monthCalendar2.Visible = true;
        //}

        //private void monthCalendar1_DateSelected_1(object sender, DateRangeEventArgs e)
        //{
        //     gzrqfromtextBox.Text = monthCalendar1.SelectionStart.ToString("yyyy-MM-dd");
        //     monthCalendar1.Visible = false;
        //}

        //private void monthCalendar2_DateChanged_1(object sender, DateRangeEventArgs e)
        //{
        //    gzrqtotextBox.Text = monthCalendar2.SelectionStart.ToString("yyyy-MM-dd");
        //    monthCalendar2.Visible = false;
        //}

        //private void monthCalendar1_Leave_1(object sender, EventArgs e)
        //{
        //    monthCalendar1.Visible = false;
        //}

        //private void monthCalendar2_Leave(object sender, EventArgs e)
        //{
        //    monthCalendar2.Visible = false;
        //}

        private void frmWLKC_Click(object sender, EventArgs e)
        {
            
        }

        private void frmWLKC_MouseClick(object sender, MouseEventArgs e)
        {
         
        }

        private void dateTimePicker1_CloseUp(object sender, EventArgs e)
        {
            gzrqfromtextBox.Text = dateTimePicker1.Text.Trim();
        }

        private void dateTimePicker2_CloseUp(object sender, EventArgs e)
        {
            gzrqtotextBox.Text = dateTimePicker2.Text.Trim();
        }

        private void frmWLKC_Shown(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(numericUpDown1.Value) < 1)
            {
                ShowMeg(q(Msg_Type.msgprintnoempty));//"打印分数必须大于0"
                return;
            }
            if (List.Count == 0)
            {
                ShowMeg(q(Msg_Type.msgnowlpzclickinvalid));//"没有物料凭证数据点击无效"
                return;
            }
            ChoiceList = new List<ZSL_BCS303_BS>();
            List<ZSL_BCS303_BS> nodes1 = (List<ZSL_BCS303_BS>)JLdataGridView.DataSource;
          
            for (int i = 0; i < JLdataGridView.Rows.Count; i++)
            {
                if (this.JLdataGridView.Rows[i].Cells[0].EditedFormattedValue.ToString() == "True") //checkbox的是否勾选
                {
                    //count++;
                    //nodes1[i].JLR = Convert.ToInt32(getUserInfo("staffid"));
                    //nodes1[i].TMSX = (int)Print_Type.wlrk;
                    //nodes1[i].TMLB = 1;

                    ChoiceList.Add(nodes1[i]);
                }
            }
            if (ChoiceList.Count == 0)
            {
                ShowMeg(q(Msg_Type.msgatleastone));//"请至少选择一条数据"
                return;
            }
          
            for (int i = 0; i < ChoiceList.Count; i++)
            {
                ChoiceList[i].JLR = Convert.ToInt32(getUserInfo("staffid"));
                ChoiceList[i].TMSX = (int)Print_Type.wlrkLot;
                ChoiceList[i].TMLB = 1;
                ChoiceList[i].MAC = DeviceInfo.GetNetCardMAC().Substring(0, 17);
                bool b = judge.IsNo(ChoiceList[i].MTSL);
                if (!judge.IsNumber(ChoiceList[i].MTSL) && !string.IsNullOrEmpty(ChoiceList[i].MTSL))
                {
                    if (!judge.IsNo(ChoiceList[i].MTSL))
                    {
                        ShowMeg(string.Format(q(Msg_Type.msgmtslnodigital)));//ChoiceList[i].TM + "每托数量不是数字,请校验"
                        return;
                    }
                   
                }
                if (string.IsNullOrEmpty(ChoiceList[i].TM))
                {
                    ShowMeg(string.Format(q(Msg_Type.msgfirstcreate), ChoiceList[i].MBLNR, ChoiceList[i].ZEILE));//"请首先生成" + ChoiceList[i].MBLNR + "-" + ChoiceList[i].ZEILE  + "的条码"
                    return;
                }
                else
                {
                    Sonluk.UI.Model.MES.TM_TMINFOService.SELECT_MES_TM_TMINFO_PRINT tmInfo = ServicModel.TM_TMINFO.SELECT_BYID_CHILD(ChoiceList[i].WERKS, ChoiceList[i].TM, getToken());
                    if (!tmInfo.MES_RETURN.TYPE.Equals("S"))
                    {
                        ShowMeg(ChoiceList[i].MBLNR + "-" + ChoiceList[i].ZEILE + q(Msg_Type.msgcreatetmexpect) + tmInfo.MES_RETURN.MESSAGE);//"生成的条码异常,"
                        return;
                    }
                    if (string.IsNullOrEmpty(ChoiceList[i].TS.ToString()) ||ChoiceList[i].TS == 0)
                    {
                        ShowMeg(string.Format(q(Msg_Type.msgcctmtsnoempty), ChoiceList[i].TM));//"条码" + ChoiceList[i].TM + "托数不能为0"
                        return;
                    }
                    else
                    {

                        if (ChoiceList[i].QSTH == null)
                        {
                            ShowMeg(q(Msg_Type.msgqsthqtone));//"起始托号必须大于1"
                            return;
                        }
                    }
                    
                }
               
            }

          






            ZBCFUN_PURBS_READ res = ServicModel.MES_WLKCBS.INSERT_TM_WLPZ(ChoiceList.ToArray(), 2, getToken());
            if (res.MES_RETURN.TYPE.Equals("S"))
            {
                PrintWLKCLot(res.ET_PURBS.ToList(), Convert.ToInt32(numericUpDown1.Value), Print_Type.wlrkLot);
            }
            else
            {
                ShowMeg(res.MES_RETURN.MESSAGE);
            }





           
        }

        private void JLdataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            string content = Convert.ToString(this.JLdataGridView.CurrentRow.Cells["XCBS"].Value);
        }

        private void smbutton_Click(object sender, EventArgs e)
        {
            //if (Convert.ToInt32(numericUpDown1.Value) < 1)
            //{
            //    ShowMeg("打印分数必须大于0");
            //    return;
            //}
            if (List.Count == 0)
            {
                ShowMeg(q(Msg_Type.msgnowlpzclickinvalid));//"没有物料凭证数据点击无效"
                return;
            }

            ChoiceList = new List<ZSL_BCS303_BS>();
            List<ZSL_BCS303_BS> nodes1 = (List<ZSL_BCS303_BS>)JLdataGridView.DataSource;
         
            int count = 0;
            for (int i = 0; i < JLdataGridView.Rows.Count; i++)
            {
                if (this.JLdataGridView.Rows[i].Cells[0].EditedFormattedValue.ToString() == "True") //checkbox的是否勾选
                {
                    count++;
                    nodes1[i].JLR = Convert.ToInt32(getUserInfo("staffid"));
                    nodes1[i].TMSX = (int)Print_Type.wlrk;
                    nodes1[i].TMLB = 1;
                    nodes1[i].MAC = DeviceInfo.GetNetCardMAC().Substring(0, 17);
                    ChoiceList.Add(nodes1[i]);
                }
            }

            int existCount = ChoiceList.Count(p => p.TM.Length == 12);
            if (existCount == ChoiceList.Count)
            {
                ShowMeg(q(Msg_Type.msgchoicerowalreadytm));//"选择的数据行都已存在条码"
                return;
            }


            bool isPass = true;
            for (int i = 0; i < ChoiceList.Count; i++)
            {
                if (ChoiceList[i].XCBS.Equals("Y") && string.IsNullOrEmpty(ChoiceList[i].XCZJTM))
                {
                    ShowMeg(ChoiceList[i].MBLNR + "-" + ChoiceList[i].ZEILE + q(Msg_Type.msgneedxcm));//"需要绑定下层码信息"
                    isPass = false;
                    break;
                }
            }


            if (isPass)
            {
                if (count == 0)
                {
                    ShowMeg(q(Msg_Type.msgatleastone));//"请至少选择一条数据"
                    return;
                }
                else
                {
                    ZBCFUN_PURBS_READ res = ServicModel.MES_WLKCBS.INSERT_TM_WLPZ(ChoiceList.ToArray(),1, getToken());
                    if (res.MES_RETURN.TYPE.Equals("S"))
                    {
                        //model.MBLNR = list.MBLNR;
                        //model.XCBS = list.XCBS;
                        //model.MJAHR = list.MJAHR;
                        //model.LINE_ID = list.LINE_ID;
                        //model.LIFNR = list.LIFNR;
                        if (res.ET_PURBS.Length > 0)
                        {
                            for (int i = 0; i < res.ET_PURBS.Length; i++)
                            {
                                for (int j = 0; j < List.Count; j++)
                                {
                                    //遍历数据表格根据物料凭证、物料凭证年度、物料凭证项
                                    if (res.ET_PURBS[i].MBLNR == List[j].MBLNR && res.ET_PURBS[i].MJAHR == List[j].MJAHR && res.ET_PURBS[i].LINE_ID == List[j].LINE_ID)
                                    {
                                        List[j].TM = res.ET_PURBS[i].TM;
                                    }
                                }
                            }
                        }
                        JLdataGridView.DataSource = new List<ZSL_BCS303_BS>();
                        JLdataGridView.DataSource = List;
                        JLdataGridView.ClearSelection();
                        Type type = JLdataGridView.GetType();
                        PropertyInfo pi = type.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
                        pi.SetValue(JLdataGridView, true, null);
                        //PrintWLKC(ChoiceList, Convert.ToInt32(numericUpDown1.Value), Print_Type.wlrk);
                        ShowMeg(q(Msg_Type.msgcreatetmsuccess), 1500);//"生码成功"


                    }
                    else
                    {
                        ShowMeg(res.MES_RETURN.MESSAGE);
                    }
                }
            }
        }

        private void wlpztextBox_Click(object sender, EventArgs e)
        {
            //wlpztextBox.SelectAll();
        }
      
        private void tmtextBox_Click(object sender, EventArgs e)
        {

            if (Convert.ToInt32(tmtextBox.Tag) == 0)
            {
                tmtextBox.SelectAll();
                tmtextBox.Tag = 1;
            }
           
           
        }

        private void pctextBox_Click(object sender, EventArgs e)
        {
            //pctextBox.SelectAll();
        }

        private void wlbmtextBox_Click(object sender, EventArgs e)
        {
            //wlbmtextBox.SelectAll();
        }

        private void cgddtextBox_Click(object sender, EventArgs e)
        {
            //cgddtextBox.SelectAll();
        }

        private void gystextBox_Click(object sender, EventArgs e)
        {
            //gystextBox.SelectAll();
        }

        private void tmtextBox_DoubleClick(object sender, EventArgs e)
        {

        }

        private void wlpztextBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (Convert.ToInt32(wlpztextBox.Tag) == 0)
            {
                wlpztextBox.SelectAll();
                wlpztextBox.Tag = 1;
            }

        }

        private void wlpztextBox_Leave(object sender, EventArgs e)
        {
            wlpztextBox.Tag = 0;
        }

        private void tmtextBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (Convert.ToInt32(tmtextBox.Tag) == 0)
            {
                tmtextBox.SelectAll();
                tmtextBox.Tag = 1;
            }
        }

        private void tmtextBox_Leave(object sender, EventArgs e)
        {
            tmtextBox.Tag = 0;
        }

        private void pctextBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (Convert.ToInt32(pctextBox.Tag) == 0)
            {
                pctextBox.SelectAll();
                pctextBox.Tag = 1;
            }
        }

        private void pctextBox_Leave(object sender, EventArgs e)
        {
            pctextBox.Tag = 0;
        }

        private void wlbmtextBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (Convert.ToInt32(wlbmtextBox.Tag) == 0)
            {
                wlbmtextBox.SelectAll();
                wlbmtextBox.Tag = 1;
            }
        }

        private void wlbmtextBox_Leave(object sender, EventArgs e)
        {
            wlbmtextBox.Tag = 0;
        }

        private void cgddtextBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (Convert.ToInt32(cgddtextBox.Tag) == 0)
            {
                cgddtextBox.SelectAll();
                cgddtextBox.Tag = 1;
            }
        }

        private void cgddtextBox_Leave(object sender, EventArgs e)
        {
            cgddtextBox.Tag = 0;
        }

        private void gystextBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (Convert.ToInt32(gystextBox.Tag) == 0)
            {
                gystextBox.SelectAll();
                gystextBox.Tag = 1;
            }
        }

        private void gystextBox_Leave(object sender, EventArgs e)
        {
            gystextBox.Tag = 0;
        }

        private void cgddtextBox_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void delbutton_Click(object sender, EventArgs e)
        {
            frmDeleteTM_TMINFO form = new frmDeleteTM_TMINFO();          
            show(form);
        }
       
    }
}
