using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Sonluk.MES.MES.Base;
using Sonluk.UI.Model.MES.SY_GCService;
using Sonluk.UI.Model.MES.SY_GZZX_SBHService;
using Sonluk.UI.Model.MES.SY_GZZXService;
using Sonluk.UI.Model.MES.SY_TYPEMXService;
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
    public partial class frmTM_bdLimit : baseview
    {
        List<MES_TM_TMINFO_LIST> _list;

        public List<MES_TM_TMINFO_LIST> List
        {
            get { return _list; }
            set { _list = value; }
        }
        List<MES_TM_TMINFO_LIST> _choiceList;

        public List<MES_TM_TMINFO_LIST> ChoiceList
        {
            get { return _choiceList; }
            set { _choiceList = value; }
        }

        public frmTM_bdLimit()
        {
            InitializeComponent();
            List = new List<MES_TM_TMINFO_LIST>();
            JLdataGridView.AutoGenerateColumns = false;
            MES_SY_GC gcmodel = new MES_SY_GC();
            gcmodel.STAFFID = Convert.ToInt32(getUserInfo("staffid"));

            MES_SY_GC[] gcArr = ServicModel.SY_GC.SELECT_BY_ROLE(gcmodel, getToken());
            for (int i = 0; i < gcArr.Length; i++)
            {
                gcArr[i].GCMS = gcArr[i].GC + "-" + gcArr[i].GCMS;
            }
            List<MES_SY_GC> gcList = gcArr.ToList();
            MES_SY_GC choiceModel = new MES_SY_GC();
            choiceModel.GCMS = q(Msg_Type.titlechoice);//"==请选择==";
            choiceModel.GC = "0";
            gcList.Insert(0, choiceModel);
            gccomboBox.DisplayMember = "GCMS";
            gccomboBox.ValueMember = "GC";
            gccomboBox.DataSource = gcList;
            if (gcList.Count == 2)
            {
                gccomboBox.SelectedValue = gcList[1].GC;
            }
            scrqdateTimePicker.Value =  DateTime.Now;
            jlrqfromdateTimePicker.Value = DateTime.Now;
            jlrqtodateTimePicker.Value = DateTime.Now;
            //monthCalendar1.Visible = false;
            //monthCalendar2.Visible = false;
            //monthCalendar3.Visible = false;

        }

        private void gccomboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            object obj = cb.SelectedValue;
            if (obj is string)
            {
                MES_SY_GZZX gzzxmodel = new MES_SY_GZZX();
                gzzxmodel.GC = Convert.ToString(obj);
                gzzxmodel.STAFFID = Convert.ToInt32(getUserInfo("staffid"));
                //gzzxmodel.WLLB = Gzzxlb; 
                //gzzxmodel.WLLBNAME = Wllb;
                MES_SY_GZZX[] list = ServicModel.SY_GZZX.SELECT_BY_ROLE(gzzxmodel, getToken());
                gzzxcomboBox.SelectedValue = "";
                gzzxcomboBox.SelectedText = "";
                for (int i = 0; i < list.Length; i++)
                {
                    list[i].GZZXMS = list[i].GZZXMS + "-" + list[i].GZZXBH;
                }
                List<MES_SY_GZZX> gzzzlist = list.ToList();
                MES_SY_GZZX model = new MES_SY_GZZX();
                model.GZZXBH = "0";
                model.GZZXMS = q(Msg_Type.titlechoice);//"==请选择==";
                gzzzlist.Insert(0, model);

                gzzxcomboBox.DataSource = gzzzlist;
                gzzxcomboBox.ValueMember = "GZZXBH";
                gzzxcomboBox.DisplayMember = "GZZXMS";
                if (gzzzlist.Count == 2)
                {
                    gzzxcomboBox.SelectedValue = gzzzlist[1].GZZXBH;
                }

                MES_SY_TYPEMX typeModel = new MES_SY_TYPEMX();
                typeModel.TYPEID = 4;
                typeModel.GC = Convert.ToString(obj);
                MES_SY_TYPEMXLIST[] wllbArr = ServicModel.SY_TYPEMX.SELECT(typeModel, getToken());
                List<MES_SY_TYPEMXLIST> wllblist = wllbArr.ToList();
                MES_SY_TYPEMXLIST choicwllb = new MES_SY_TYPEMXLIST();
                choicwllb.ID = 0;
                choicwllb.MXNAME = q(Msg_Type.titlechoice);//"==请选择==";
                wllblist.Insert(0, choicwllb);
                wllbcomboBox1.DataSource = wllblist;
                wllbcomboBox1.DisplayMember = "MXNAME";
                wllbcomboBox1.ValueMember = "ID";


            }
        }

        private void gzzxcomboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            object obj = cb.SelectedValue;
            if (obj is string)
            {
                MES_SY_GZZX_SBH model = new MES_SY_GZZX_SBH();
                model.GZZXBH = Convert.ToString(gzzxcomboBox.SelectedValue);
                model.GC = Convert.ToString(gccomboBox.SelectedValue);
                //model.WLLB = Gzzxlb;
                //model.WLLBNAME = Wllb;

                MES_SY_GZZX_SBH[] list = ServicModel.SY_GZZX_SBH.SELECT(model, getToken());
                List<MES_SY_GZZX_SBH> sbhlist = list.ToList();
                MES_SY_GZZX_SBH model1 = new MES_SY_GZZX_SBH();
                model1.SBBH = "0";
                model1.SBMS = q(Msg_Type.titlechoice);//"==请选择==";
                sbhlist.Insert(0, model1);

                sbhcomboBox.DataSource = sbhlist;
                sbhcomboBox.ValueMember = "SBBH";
                sbhcomboBox.DisplayMember = "SBMS";
                if (sbhlist.Count == 2)
                {
                    sbhcomboBox.SelectedValue = sbhlist[1].SBBH;
                }

            }
        }

        private void wlbmtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //judge.isNum(wlbmtextBox,e);
        }

        private void xsddtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //judge.isNum(xsddtextBox, e);
        }

        private void thtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //judge.isNum(thtextBox, e);
        }

        private void cxbutton_Click(object sender, EventArgs e)
        {
            //MES_SY_TYPEMXLIST[] wllbArr = ServicModel.SY_TYPEMX.SELECT(typeModel, getToken());
            //List<MES_SY_TYPEMXLIST> wllblist = wllbArr.ToList();
            //MES_SY_TYPEMXLIST choicwllb = new MES_SY_TYPEMXLIST();
            //choicwllb.ID = 0;
            //choicwllb.MXNAME = "==请选择==";
            //wllblist.Insert(0, choicwllb);
            if (Convert.ToString(gccomboBox.SelectedValue).Equals("0") || gccomboBox.SelectedValue == null)
            {
                //ShowMeg("工厂信息不能为空");
                ShowMeg(q(Msg_Type.msggcnoempty));
                return;
            }
            if (Convert.ToString(gzzxcomboBox.SelectedValue).Equals("0") || gzzxcomboBox.SelectedValue == null)
            {
                //ShowMeg("工作中心不能为空");
                ShowMeg(q(Msg_Type.msggzzxnoempty));
                return;
            }


            MES_TM_TMINFO model = new MES_TM_TMINFO();
            if (!Convert.ToString(gccomboBox.SelectedValue).Equals("0"))
            {
                model.GC = Convert.ToString(gccomboBox.SelectedValue);
            }
            if (gzzxcomboBox.SelectedValue != null)
            {
                if (!Convert.ToString(gzzxcomboBox.SelectedValue).Equals("0"))
                {
                    model.GZZXBH = Convert.ToString(gzzxcomboBox.SelectedValue);
                }
               
            }
            if (!Convert.ToString(sbhcomboBox.SelectedValue).Equals("0"))
            {
                model.SBBH = Convert.ToString(sbhcomboBox.SelectedValue);
            }
            if (!string.IsNullOrEmpty(tmtextBox.Text.Trim()))
            {
                if (tmtextBox.Text.Trim().Length == 12)// && tmtextBox.Text.Trim().ToUpper().StartsWith("P"))
                {
                    model.TM = tmtextBox.Text.Trim();
                }
                else
                {
                    //ShowMeg("条码格式是P开头的12位信息,请核对");
                    ShowMeg(q(Msg_Type.msgtmstartwithP));
                    return;
                }
               
            }
            if (!string.IsNullOrEmpty(wlbmtextBox.Text.Trim()))
            {
                model.WLH = wlbmtextBox.Text.Trim();
            }
            if (!string.IsNullOrEmpty(xsddtextBox.Text.Trim()))
            {
                model.NOBILL = xsddtextBox.Text.Trim();
            }
            
            if (!string.IsNullOrEmpty(thtextBox.Text.Trim()))
            {
                if (judge.IsNumber(thtextBox.Text.Trim()))
                {
                    model.TH = Convert.ToInt32(thtextBox.Text.Trim());
                }
                else
                {
                    //ShowMeg("桶号必须是数字");
                    ShowMeg(q(Msg_Type.msgthisdigital));
                    return;
                }
                              
            }
            if (!string.IsNullOrEmpty(erptextBox.Text.Trim()))
            {
                if (erptextBox.Text.Trim().Length == 8)
                {
                    model.ERPNO = erptextBox.Text.Trim();
                }
                else
                {
                    //ShowMeg("ERP工单是有效的8位信息");
                    ShowMeg(q(Msg_Type.msgerpdglengtheigth));
                    return;
                }
                
            }
            if (!string.IsNullOrEmpty(rwdtextBox.Text.Trim())  )
            {
                if (rwdtextBox.Text.Trim().Length == 11)
                {
                    model.RWBH = rwdtextBox.Text.Trim().ToUpper();
                }
                else
                {
                    //ShowMeg("任务单是有效的11位信息");
                    ShowMeg(q(Msg_Type.msgrwdlengtheleven));
                    return;
                }
               
            }
            if (!string.IsNullOrEmpty(pctextBox.Text.Trim()))
            {
                model.PC = Convert.ToString(pctextBox.Text.Trim());
            }
            //if (!string.IsNullOrEmpty(scrqtextBox.Text.Trim()))
            //{
            //    if (judge.IsDate(scrqtextBox.Text.Trim()))
            //    {
            //        model.SCDATE = scrqtextBox.Text.Trim();
            //    }
            //    else
            //    {
            //        ShowMeg("生产日期不是有效的时间格式");
            //        return;
            //    }
            //}
            //if (!string.IsNullOrEmpty(jlrqfromtextBox.Text.Trim()))
            //{
            //      if (judge.IsDate(jlrqfromtextBox.Text.Trim()))
            //    {
            //        model.JLKSTIME = Convert.ToDateTime(jlrqfromtextBox.Text.Trim()).ToString("yyyy-MM-dd");
            //    }
            //    else
            //    {
            //        ShowMeg("记录开始日期不是有效的时间格式");
            //        return;
            //    }
            //}
            //if (!string.IsNullOrEmpty(jlrqtotextBox.Text.Trim()))
            //{
            //    if (judge.IsDate(jlrqtotextBox.Text.Trim()))
            //    {
            //        model.JLJSTIME = Convert.ToDateTime(jlrqtotextBox.Text.Trim()).ToString("yyyy-MM-dd"); 
            //    }
            //    else
            //    {
            //        ShowMeg("记录结束日期不是有效的时间格式");
            //        return;
            //    }
            //}
           
            if (!string.IsNullOrEmpty(scrqtextBox.Text.Trim()))
            {
                if (judge.IsDate(scrqtextBox.Text.Trim()))
                {
                    model.SCDATE = scrqtextBox.Text.Trim();
                }
                else
                {
                    //ShowMeg("生产日期不是正确的日期格式");
                    ShowMeg(q(Msg_Type.msgscrqformat));
                }
            }
            if (!string.IsNullOrEmpty(jlrqfromtextBox.Text.Trim()))
            {
                if (judge.IsDate(jlrqfromtextBox.Text.Trim()))
                {
                    model.JLKSTIME = jlrqfromtextBox.Text.Trim();
                }
                else
                {
                    //ShowMeg("记录开始日期不是正确的日期格式");
                    ShowMeg(q(Msg_Type.msgjlksrqformat));
                }
            }
            if (!string.IsNullOrEmpty(jlrqtotextBox.Text.Trim()))
            {
                if (judge.IsDate(jlrqtotextBox.Text.Trim()))
                {
                    model.JLJSTIME = jlrqtotextBox.Text.Trim();
                }
                else
                {
                    //ShowMeg("记录结束日期不是正确的日期格式");
                    ShowMeg(q(Msg_Type.msgjljsrqformat));
                }
            }
            if (!string.IsNullOrEmpty(jlrqfromtextBox.Text.Trim()) && !string.IsNullOrEmpty(jlrqtotextBox.Text.Trim()))
            {
                TimeSpan midtine = DateTime.Parse(jlrqfromtextBox.Text.Trim()) - DateTime.Parse(jlrqtotextBox.Text.Trim());
                if (midtine.Days > 0)
                {
                    //ShowMeg("记录开始日期不能大于记录结束日期");
                    ShowMeg(q(Msg_Type.msgksgtjs));
                }
            }
            if (MaccheckBox.Checked)
            {
                model.MAC = DeviceInfo.GetNetCardMAC().Substring(0, 17);
            }
            //model.WLLBNAME = "素电";
            model.WLLB = Convert.ToInt32(wllbcomboBox1.SelectedValue);
            model.MOULD = mjtextBox1.Text.Trim();
            model.CLPBDM = clpbtextBox1.Text.Trim();
            SELECT_MES_TM_TMINFO_BYTM res = ServicModel.TM_TMINFO.SELECT(model, getToken());
            if (res.MES_RETURN.TYPE.Equals("S"))
            {
                JLdataGridView.DataSource = res.MES_TM_TMINFO_LIST.ToList();
                List = res.MES_TM_TMINFO_LIST.ToList();
                JLdataGridView.ClearSelection();
                Type type = JLdataGridView.GetType();
                PropertyInfo pi = type.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
                pi.SetValue(JLdataGridView, true, null);
            }
            else
            {
                ShowMeg(res.MES_RETURN.MESSAGE);
            }
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            //scrqtextBox.Text = Convert.ToDateTime(monthCalendar1.SelectionStart.ToShortDateString()).ToString("yyyy-MM-dd");
            //monthCalendar1.Visible = false;
        }

        private void monthCalendar2_DateSelected(object sender, DateRangeEventArgs e)
        {
            //jlrqfromtextBox.Text = Convert.ToDateTime(monthCalendar2.SelectionStart.ToShortDateString()).ToString("yyyy-MM-dd");
            //monthCalendar2.Visible = false;
        }

        private void monthCalendar3_DateSelected(object sender, DateRangeEventArgs e)
        {
            //jlrqtotextBox.Text = Convert.ToDateTime(monthCalendar3.SelectionStart.ToShortDateString()).ToString("yyyy-MM-dd");
            //monthCalendar3.Visible = false;
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            //monthCalendar1.Visible = true;
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            //monthCalendar2.Visible = true;
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            //monthCalendar3.Visible = true;
        }

        private void qxbutton_Click(object sender, EventArgs e)
        {
            if (List.Count == 0)
            {
                //ShowMeg("没有条码数据点击无效");
                ShowMeg(q(Msg_Type.msgnotmclickinvalid));
                return;
            }
            SetAllRowChecked(CheckBoxType.all);
        }

        private void qcbutton_Click(object sender, EventArgs e)
        {
            if (List.Count == 0)
            {
                //ShowMeg("没有条码数据点击无效");
                ShowMeg(q(Msg_Type.msgnotmclickinvalid));
                return;
            }
            SetAllRowChecked(CheckBoxType.none);
        }

        private void fxbutton_Click(object sender, EventArgs e)
        {
            if (List.Count == 0)
            {
                //ShowMeg("没有条码数据点击无效");
                ShowMeg(q(Msg_Type.msgnotmclickinvalid));
                return;
            }
            SetAllRowChecked(CheckBoxType.reverse);
        }

        private void dybutton_Click(object sender, EventArgs e)
        {
            if (List.Count == 0)
            {
                //ShowMeg("没有物料凭证数据点击无效");
                ShowMeg(q(Msg_Type.msgnowlpzclickinvalid));
                return;
            }
            ChoiceList = new List<MES_TM_TMINFO_LIST>();

            List<MES_TM_TMINFO_LIST> nodes = (List<MES_TM_TMINFO_LIST>)JLdataGridView.DataSource;
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
                //ShowMeg("请选择你要打印的数据");
                ShowMeg(q(Msg_Type.msgchoiceprintdata));
                return;
            }
            for (int i = 0; i < ChoiceList.Count; i++)
            {
                if (ChoiceList[i].TMSX == 0)
                {
                    //ShowMeg("条码" + ChoiceList[i].TM + "的条码属性异常无法打印");
                    ShowMeg(string.Format(q(Msg_Type.msgtmexceptnoprint), ChoiceList[i].TM));
                    return;
                }
            }


            for (int i = 0; i < ChoiceList.Count; i++)
            {
                Print_Type ptype = (Print_Type)ChoiceList[i].TMSX;
                
                switch (ptype)
                {
                    case Print_Type.none:
                        break;
                    case Print_Type.rk:
                        RigthType = Rigth_Type.gangketl_cc;
                        break;
                    case Print_Type.lot:
                        RigthType = Rigth_Type.gangketl_cc;
                        break;
                    case Print_Type.zjlot:
                        RigthType = Rigth_Type.zhengjicc;
                        break;
                    case Print_Type.fujilot:
                        RigthType = Rigth_Type.fujitl;
                        break;
                    case Print_Type.zxlot:
                        RigthType = Rigth_Type.zhuxiancc;
                        break;
                    case Print_Type.bblot:
                        RigthType = Rigth_Type.baobiaocc;
                        break;
                    case Print_Type.zfsd:
                        RigthType = Rigth_Type.zhuxiancc;
                        break;
                    case Print_Type.wlrk:
                        RigthType = Rigth_Type.wlrkdy;
                        break;
                    case Print_Type.zswllot:
                        RigthType = Rigth_Type.zswllotdy;
                        break;
                    default:
                        break;
                }
                PrintInfoByTM(ChoiceList[i].TM, ChoiceList[i].GC, 1, RigthType, ptype);
            }
           


        }
        private void button1_Click(object sender, EventArgs e)
        {
           
            
            frmPrintTM form = new frmPrintTM();
            show(form);
        }
        private void dcbutton_Click(object sender, EventArgs e)
        {
            if (List.Count == 0)
            {
                //ShowMeg("没有物料凭证数据点击无效");
                ShowMeg(q(Msg_Type.msgnowlpzclickinvalid));
                return;
            }
            ChoiceList = new List<MES_TM_TMINFO_LIST>();

            List<MES_TM_TMINFO_LIST> nodes = (List<MES_TM_TMINFO_LIST>)JLdataGridView.DataSource;
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
                //ShowMeg("请选择你要导出的数据");
                ShowMeg(q(Msg_Type.msgchoiceexportdata));
                return;
            }

            PrintExcel(ChoiceList);
            //string[] headStr = { "条码","工厂","工作中心","工作中心描述","设备号","物料编码","物料描述","批次","销售订单","项目","桶(幢)号","配方号","配料单号","供应商编码","简称","材料厂家","工艺路线","电池型号","电池等级","日期唛","商标产地","生产日期","班次","开始日期","结束日期","记录日期","记录人","备注" };
            //MES_TM_TMINFO_LIST node = new MES_TM_TMINFO_LIST();
            //string[] contentStr = { node.TM, node.GC, node.GZZXBH, node.GZZXMS, node.SBHMS, node.WLH, node.WLMS, node.PC, node.NOBILL, node.NOBILLMX, node.TH.ToString(), node.PFDH, node.PLDH, node.GYS, node.GYSMS, node.CLCJ, node.GYLX, node.DCXHMS, node.DCDJMS, node.RQM, node.SBCDMS, node.SCDATE, node.BCMS, node.KSTIME, node.JSTIME, node.JLTIME, node.JLRMS, node.REMARK };
        }
        public void PrintExcel(List<MES_TM_TMINFO_LIST> list)
        {
            //FileStream file = new FileStream( @"../../EXCEL/查询打印导出模版.xlsx", FileMode.Open, FileAccess.Read);
            IWorkbook excel = new XSSFWorkbook();//创建.xls文件

            ISheet sheet = excel.CreateSheet("sheet1"); //创建sheet
            //IWorkbook workbook = new XSSFWorkbook(file);
            //ISheet sheet = workbook.GetSheetAt(0);
            IRow row = sheet.CreateRow(0);//创建行对象，填充表头
            //string[] headStr = { "条码", "工厂", "工作中心", "工作中心描述", "设备号", "物料编码", "物料描述", "批次", "销售订单", "项目", "桶(幢)号", "配方号", "配料单号", "供应商编码", "简称", "材料厂家", "工艺路线", "电池型号", "电池等级", "日期唛", "商标产地", "生产日期", "班次", "开始日期", "结束日期", "记录日期", "记录人", "备注" };
            string[] headStr = q(Msg_Type.fieldtmInfoArr_zs).Split(',');//{"工厂","条码","生产日期","班次","工作中心","工作中心描述","设备号","任务编号","物料号","物料描述","批次","材料厂家","工艺路线","供应商","供应商描述","供应商批次","产品状态","配方单号","配料单号","桶号","数量",	"开始时间","结束时间","锌粉产地","电池等级","电池型号","托盘码","商标产地","备注","记录人","记录时间","销售订单编号","销售订单明细","物料类别","物料组","物料组描述","视比重","规格","适用生产线","适用产品规格","ERP单号","单位"	,"电池板数","每板数量","余数","日期唛","下道工序","暂放电池类别","库存地点","库存地点名称","采购订单号","采购订单明细","存放天数","模具名称","类型","无腔号","颜色","材料配比代码"};


            for (int i = 0; i < headStr.Length; i++)
            {
                row.CreateCell(i).SetCellValue(headStr[i]);
            }


            //填充内容，j从1开始，屏蔽掉第一列，循环读取
            for (int i = 0; i < ChoiceList.Count; i++)
            {
                //IRow row = sheet.CreateRow(i+1);
                row = sheet.CreateRow(i + 1);
                MES_TM_TMINFO_LIST node = ChoiceList[i];

                //string[] contentStr = { node.TM, node.GC, node.GZZXBH, node.GZZXMS, node.SBHMS, node.WLH, node.WLMS, node.PC, node.NOBILL, node.NOBILLMX, node.TH.ToString(), node.PFDH, node.PLDH, node.GYS, node.GYSMS, node.CLCJ, node.GYLX, node.DCXHMS, node.DCDJMS, node.RQM, node.SBCDMS, node.SCDATE, node.BCMS, node.KSTIME, node.JSTIME, node.JLTIME, node.JLRMS, node.REMARK };
                string[] contentStr = { node.GC, node.TM, node.SCDATE, node.BCMS, node.GZZXBH, node.GZZXMS, node.SBHMS, node.RWBH, node.WLH, node.WLMS, node.PC, node.CLCJ, node.GYLX, node.GYS, node.GYSMS, node.GYSPC, node.CPZTNAME, node.PFDH, node.PLDH, Convert.ToString(node.TH), Convert.ToString(node.SL),node.KSTIME,node.JSTIME,node.XFCDNAME,node.DCDJMS,node.DCXHMS,node.TPM,node.SBCDMS,node.REMARK,node.JLRMS,node.JLTIME,node.NOBILL,node.NOBILLMX,node.WLLBNAME,node.WLGROUP,node.WLGROUPNAME,node.SBZ,node.SIZENAME,node.SYSCX,node.SYCPGG,node.ERPNO,node.UNITSNAME,Convert.ToString(node.DCSLBS),Convert.ToString(node.DCSLMBSL),Convert.ToString(node.DCSLYS),node.RQM,node.XDGXNAME,node.ZFDCLBNAME,node.KCDD,node.KCDDNAME,node.CGBILL,node.CGBILLMX,Convert.ToString (node.CFTS),node.MOULD,node.CPTYPENAME,node.WQH,node.MFQCOLORNAME,node.CLPBDM };
                //int a = contentStr.Length;
                //int b = headStr.Length;
                for (int j = 0; j < contentStr.Length; j++)
                {
                    if (j == 20)//数量字段 数值类型
                    {
                        row.CreateCell(j).SetCellValue(Convert.ToDouble(contentStr[j]));
                    }
                    else
                    {
                        row.CreateCell(j).SetCellValue(contentStr[j]);
                    }
                    

                }


            }

            ////写入文件
            //string DesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            //string path = DesktopPath + @"\委外库存标识信息Excel" + DateTime.Now.ToString("yyyyMMdd") + ".xls";
            ////string path = DesktopPath + @"\委外库存标识" + DateTime.Now.ToShortDateString() + ".xls";
            ////string path = DesktopPath + @"\1.xls";
            //FileStream xlsfile = new FileStream(path, FileMode.OpenOrCreate);
            //excel.Write(xlsfile);
            //xlsfile.Close();
          

            SaveFileDialog Sfd = new SaveFileDialog();
            Sfd.Filter = "Excel文件(*.xlsx)|*.xlsx";
            Sfd.FileName = q(Msg_Type.titletmxx) + DateTime.Now.ToString("yyyyMMddHHmmss");//"条码信息" 
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


        enum CheckBoxType
        {
            all = 1,
            none = 2,
            reverse
        }
        private void SetAllRowChecked(CheckBoxType type)
        {

            int count = Convert.ToInt32(this.JLdataGridView.Rows.Count.ToString());
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

        private void scrqdateTimePicker_CloseUp(object sender, EventArgs e)
        {
            //gzrqfromtextBox.Text = dateTimePicker1.Text.Trim();
            scrqtextBox.Text = scrqdateTimePicker.Text.Trim();
        }

        private void jlrqfromdateTimePicker_CloseUp(object sender, EventArgs e)
        {
            jlrqfromtextBox.Text = jlrqfromdateTimePicker.Text.Trim();
        }

        private void jlrqtodateTimePicker_CloseUp(object sender, EventArgs e)
        {
            jlrqtotextBox.Text = jlrqtodateTimePicker.Text.Trim();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowMeg(q(Msg_Type.msgmacaddress) + DeviceInfo.GetNetCardMAC().Substring(0, 17));//"本机地址为"
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

        private void xsddtextBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (Convert.ToInt32(xsddtextBox.Tag) == 0)
            {
                xsddtextBox.SelectAll();
                xsddtextBox.Tag = 1;
            }
        }

        private void xsddtextBox_Leave(object sender, EventArgs e)
        {
            xsddtextBox.Tag = 0;
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

        private void thtextBox_Leave(object sender, EventArgs e)
        {
            thtextBox.Tag = 0;
        }

        private void thtextBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (Convert.ToInt32(thtextBox.Tag) == 0)
            {
                thtextBox.SelectAll();
                thtextBox.Tag = 1;
            }
        }

        private void rwdtextBox_Leave(object sender, EventArgs e)
        {
            rwdtextBox.Tag = 0;
        }

        private void erptextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            judge.isNum(erptextBox,e);
        }

        private void erptextBox_Leave(object sender, EventArgs e)
        {
            erptextBox.Tag = 0;
        }

        private void rwdtextBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (Convert.ToInt32(rwdtextBox.Tag) == 0)
            {
                rwdtextBox.SelectAll();
                rwdtextBox.Tag = 1;
            }
        }

        private void erptextBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (Convert.ToInt32(erptextBox.Tag) == 0)
            {
                erptextBox.SelectAll();
                erptextBox.Tag = 1;
            }
        }

        private void JLdataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {

                if (this.JLdataGridView.CurrentCell.OwningColumn.Name.Equals("TM"))
                {
                    string tm = Convert.ToString(this.JLdataGridView.CurrentRow.Cells["TM"].Value);
                    if (!string.IsNullOrEmpty(tm))
                    {
                        PrintView(tm);
                    }
                    else
                    {
                        ShowMeg(q(Msg_Type.msgtmnoempty));//"条码不能为空"
                    }

                }
            }
        }

        private void wllbcomboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

      
       
       
    }
}
