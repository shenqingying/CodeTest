using Sonluk.MES.MES.Base;
using Sonluk.UI.Model.MES.TM_TMINFOService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Sonluk.MES.MES.main
{
    public partial class frmLotLog : basefrm
    {
        int _wllb;

        public int Wllb
        {
            get { return _wllb; }
            set { _wllb = value; }
        }
        string _sbhID;

        public string SbhID
        {
            get { return _sbhID; }
            set { _sbhID = value; }
        }
        string _rwbh;

        public string Rwbh
        {
            get { return _rwbh; }
            set { _rwbh = value; }
        }

        List<MES_TM_TMINFO_LIST> tM_list;

        public List<MES_TM_TMINFO_LIST> TM_list
        {
            get { return tM_list; }
            set { tM_list = value; }
        }
       
       


        public frmLotLog()
        {
            InitializeComponent();
        }

        public frmLotLog(Rigth_Type rtype,string sbbh,string rwbh,int wllb)
        {
            InitializeComponent();
            RigthType = rtype;
            SBHID = sbbh;
            Wllb = wllb;
            Rwbh = rwbh;
            
            if (string.IsNullOrEmpty(Rwbh))
            {
                allradioButton2.Checked = true;
                rwdradioButton1.Visible = false;
                allradioButton2.Location = rwdradioButton1.Location;
            }
            else
            {
                rwdradioButton1.Checked = true;
            }
            JLdataGridView.AutoGenerateColumns = false;



        }

        private void frmLotLog_Shown(object sender, EventArgs e)
        {
            if (rwdradioButton1.Checked)
            {
                ConfigTable(true);
            }
            else
            {
                ConfigTable(false);
            }                        
        }
        public void ConfigTable(bool ISrwd)
        {
            MES_TM_TMINFO model = new MES_TM_TMINFO();

            model.MAC = DeviceInfo.GetNetCardMAC().Substring(0, 17);
            if (ISrwd)
            {
                model.RWBH = Rwbh;
            }
            model.WLLB = Wllb;
            DateTime sy_dt = Convert.ToDateTime(ServicModel.PUBLIC_FUNC.GET_TIME(getToken())).AddHours(-4);
            model.JLJSTIME = sy_dt.ToString("yyyy-MM-dd");
            model.JLKSTIME = sy_dt.ToString("yyyy-MM-dd");            
            if (RigthType == Rigth_Type.zhengjicc)
            {
                model.GZZXBH = SBHID;
            }
            else
            {
                model.SBBH = SBHID;
            }

            SELECT_MES_TM_TMINFO_BYTM res = ServicModel.TM_TMINFO.SELECT(model, getToken());
            if (res.MES_RETURN.TYPE.Equals("S"))
            {
                TM_list = res.MES_TM_TMINFO_LIST.ToList();
                if (res.MES_TM_TMINFO_LIST.Length == 0)
                {
                    ShowMeg(q(Msg_Type.msgtodaynodata));//"当天没有对应的数据"
                }
                else
                {

                    JLdataGridView.DataSource = TM_list;

                    Type type = JLdataGridView.GetType();
                    PropertyInfo pi = type.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
                    pi.SetValue(JLdataGridView, true, null);
                    JLdataGridView.ClearSelection();
                }
            }
            else
            {
                ShowMeg(res.MES_RETURN.MESSAGE);
            }
            dybutton.Select();
            
        }

        private void qxbutton_Click(object sender, EventArgs e)
        {
            if (TM_list.Count == 0)
            {
                ShowMeg(q(Msg_Type.msgnodataclickinvalid));//"没有条码生成数据点击无效"
                return;
            }
            SetAllRowChecked(CheckBoxType.all);
        }

        private void qcbutton_Click(object sender, EventArgs e)
        {
            if (TM_list.Count == 0)
            {
                ShowMeg(q(Msg_Type.msgnodataclickinvalid));//"没有条码生成数据点击无效"
                return;
            }
            SetAllRowChecked(CheckBoxType.none);
        }

        private void fxbutton_Click(object sender, EventArgs e)
        {
            if (TM_list.Count == 0)
            {
                ShowMeg(q(Msg_Type.msgnodataclickinvalid));//"没有条码生成数据点击无效"
                return;
            }
            SetAllRowChecked(CheckBoxType.reverse);
        }

        private void dybutton_Click(object sender, EventArgs e)
        {
            if (TM_list.Count == 0)
            {
                ShowMeg(q(Msg_Type.msgnodataclickinvalid));//"没有条码生成数据点击无效"
                return;
            }
            if (Convert.ToInt32(numericUpDown1.Value) <= 0)
            {
                ShowMeg(q(Msg_Type.msgprintnoempty));//"打印分数必须大于1"
                return;
            }
            List<MES_TM_TMINFO_LIST> ChoiceList = new List<MES_TM_TMINFO_LIST>();

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
                ShowMeg(q(Msg_Type.msgchoiceprintdata));//"请选择你要打印的数据"
                return;
            }
            for (int i = 0; i < ChoiceList.Count; i++)
            {
                if (ChoiceList[i].TMSX == 0)
                {
                    ShowMeg(string.Format(q(Msg_Type.msgtmexceptnoprint), ChoiceList[i].TM));//"条码" + ChoiceList[i].TM + "的条码属性异常无法打印"
                    return;
                }
            }

            List<SELECT_MES_TM_TMINFO_PRINT> printArr = new List<SELECT_MES_TM_TMINFO_PRINT>();
            for (int i = 0; i < ChoiceList.Count; i++)
            {
                Print_Type ptype = (Print_Type)ChoiceList[i].TMSX;
                PrintType = ptype;
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
                    default:
                        break;
                }
               SELECT_MES_TM_TMINFO_PRINT tmInfo = ServicModel.TM_TMINFO.SELECT_BYID_CHILD(ChoiceList[i].GC, ChoiceList[i].TM, getToken());
               printArr.Add(tmInfo);
            }
            if (ChoiceList.Count(p=>p.TMSX == Convert.ToInt32(PrintType)) == ChoiceList.Count)
            {
                PrintInfo(Convert.ToInt32(numericUpDown1.Value), "", "", printArr.ToArray(), RigthType, PrintType);
                SetAllRowChecked(CheckBoxType.none);
            }
            else
            {
                ShowMeg(q(Msg_Type.msgmanytimesprint));//   "多选的条码打印有不一样的打印格式,请分开打印"
            }

          
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
            if (e.RowIndex != -1)
            {
               
                //string a = this.JLdataGridView.CurrentCell.OwningColumn.Name;
                int index =  this.JLdataGridView.CurrentRow.Index;
                if (this.JLdataGridView.CurrentCell.OwningColumn.Name == "打印")//"打印"
                {
                    PrintInfoByTM(TM_list[index].TM, TM_list[index].GC,Convert.ToInt32(numericUpDown1.Value), RigthType, (Print_Type)TM_list[index].TMSX);
                  
                   
                }
            }
        }

        private void rwdradioButton1_Click(object sender, EventArgs e)
        {
            ConfigTable(true);
        }

        private void allradioButton2_Click(object sender, EventArgs e)
        {
            ConfigTable(false);
        }

        private void allradioButton2_CheckedChanged(object sender, EventArgs e)
        {

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

    }
}
