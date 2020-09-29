using Sonluk.MES.MES.Base;
using Sonluk.UI.Model.MES.PD_SCRWService;
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
    public partial class frmFJprint : basefrm
    {
        MES_TM_CZR_SELECT_CZR_NOW _crzlist;

        public MES_TM_CZR_SELECT_CZR_NOW Crzlist
        {
            get { return _crzlist; }
            set { _crzlist = value; }
        }
        MES_PD_SCRW_LIST _MES_PD_SCRW_LIST;
        
        public MES_PD_SCRW_LIST MES_PD_SCRW_LIST
        {
            get { return _MES_PD_SCRW_LIST; }
            set { _MES_PD_SCRW_LIST = value; }
        }
        MES_SY_CZR_BYGH _MES_SY_CZR_BYGH;

        public MES_SY_CZR_BYGH MES_SY_CZR_BYGH
        {
            get { return _MES_SY_CZR_BYGH; }
            set { _MES_SY_CZR_BYGH = value; }
        }
      
        public frmFJprint()
        {
            InitializeComponent();
        }
        public frmFJprint(MES_PD_SCRW_LIST model)
        {
            InitializeComponent();
            MES_PD_SCRW_LIST = model;
            chtextBox.Text = MES_PD_SCRW_LIST.SBH;
            bzrichTextBox.Text = MES_PD_SCRW_LIST.REMARK;
            
            thtextBox.Text = MES_PD_SCRW_LIST.TH.ToString();
            //tlsjtextBox.Text = Convert.ToDateTime(MES_PD_SCRW_LIST.TLSJ).ToString("yyyy-MM-dd hh:mm");
            tlsjtextBox.Text = Convert.ToDateTime(MES_PD_SCRW_LIST.TLSJ).ToString("yyyy-MM-dd HH:mm"); ;
            ccsjtextBox.Text = Convert.ToDateTime(ServicModel.PUBLIC_FUNC.GET_TIME(getToken())).ToString("yyyy-MM-dd HH:mm");
            cpztcomboBox.DataSource = GetDictionaryMX(9);
            cpztcomboBox.DisplayMember = "MXNAME";
            cpztcomboBox.ValueMember = "ID";
            slcomboBox.DataSource = GetDictionaryMX(11);
            slcomboBox.DisplayMember = "MXNAME";
            slcomboBox.ValueMember = "ID";
            PrintType = Print_Type.lot;
            RigthType = Rigth_Type.fujicc;

            MES_TM_CZR czr_model = new MES_TM_CZR();
            czr_model.SBBH = model.SBBH;
            czr_model.GC = model.GC;
            czr_model.CZLB = 2;
            Crzlist = SelectCZR(czr_model);

            czrtextBox.Text = Crzlist.CZR;




            SMtextBox.Select();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tlsjtextBox.Text.Trim()))
            {
                ShowMeg(q(Msg_Type.msgtlsjnoempty));//"投料时间不能为空"
                return;
            }
            if (judge.IsDate(tlsjtextBox.Text.Trim()) == false)
            {
                ShowMeg(q(Msg_Type.msgtlsjformat));//"投料时间必须是日期格式"
                return;
            }
            if (string.IsNullOrEmpty(ccsjtextBox.Text.Trim()))
            {
                ShowMeg(q(Msg_Type.msgccsjnoempty));//"产出时间不能为空"
                return;
            }
            if (judge.IsDate(ccsjtextBox.Text.Trim()) == false)
            {
                ShowMeg(q(Msg_Type.msgccsjformat));//"产出时间必须是日期格式"
                return;
            }
            if (string.IsNullOrEmpty(Convert.ToString(cpztcomboBox.SelectedValue)))
            {
                ShowMeg(q(Msg_Type.msgcpztnoempty));//"产品状态不能为空并且是选择的"
                return;
            }
            if (string.IsNullOrEmpty(sbztextBox.Text.Trim()))
            {
                ShowMeg(q(Msg_Type.msgsbznoempty));//"视比重信息不能为空"
                return;
            }
            if (string.IsNullOrEmpty(Convert.ToString(slcomboBox.SelectedValue)))
            {
                ShowMeg(q(Msg_Type.msgslnoempey));//"数量不能为空并且是选择的"
                return;
            }
            if (string.IsNullOrEmpty(czrtextBox.Text.Trim()))
            {
                ShowMeg(q(Msg_Type.msgczrnotempty));//"操作人员不能为空"
                return;
            }
          
            if (string.IsNullOrEmpty(zsnumericUpDown.Value.ToString()))
            {
                if (Convert.ToInt32(zsnumericUpDown.Value) == 0)
                {
                    ShowMeg(q(Msg_Type.msgprintnoempty));//"打印份数必须大于0"
                   
                    return;
                }
                ShowMeg(q(Msg_Type.msgprintnoempty));//"打印份数不能为空"
                return ;
            }
            

             //public SELECT_MES_PD_SCRW UPDATE_FJCC(MES_PD_SCRW model, string ptoken)
            MES_PD_SCRW model = new MES_PD_SCRW();
            model.GC = MES_PD_SCRW_LIST.GC;
            model.RWBH = MES_PD_SCRW_LIST.RWBH;
            model.CCSJ = ccsjtextBox.Text.Trim();
            model.TLSJ = tlsjtextBox.Text.Trim();
            model.SBBH = MES_PD_SCRW_LIST.SBBH;
            model.GZZXBH = MES_PD_SCRW_LIST.GZZXBH;
            //model.TMCOUNT = Convert.ToInt32(zsnumericUpDown.Value);
            model.TMCOUNT = 1;
            model.REMARK = bzrichTextBox.Text.Trim();
            model.CPZT = Convert.ToInt32(cpztcomboBox.SelectedValue);
            model.SBZ = sbztextBox.Text;
            model.JLR = Convert.ToInt32(getUserInfo("staffid"));
            model.SIZE = Convert.ToInt32(slcomboBox.SelectedValue);
            //model.CZRGH = czrtextBox.Text.Trim();
            //model.CZRGH = MES_SY_CZR_BYGH.GH;
            model.TMSX = (int)Print_Type.fujilot;
            model.TMLB = 1;
            model.MAC = DeviceInfo.GetNetCardMAC().Substring(0, 17);
            SELECT_MES_PD_SCRW res = ServicModel.PD_SCRW.UPDATE_FJCC(model,getToken());
            if (res.MES_RETURN.TYPE.Equals("S"))
            {
                string tm = res.TMINFO.SELECT_MES_TM_TMINFO_PRINT[0].MES_TM_TMINFO_LIST.TM;
                Sonluk.UI.Model.MES.TM_TMINFOService.SELECT_MES_TM_TMINFO_PRINT tmList = ServicModel.TM_TMINFO.SELECT_BYID_CHILD(model.GC,tm,getToken());
                if (tmList.MES_RETURN.TYPE.Equals("S"))
                {
                    List<Sonluk.UI.Model.MES.TM_TMINFOService.SELECT_MES_TM_TMINFO_PRINT> tmArr = new List<UI.Model.MES.TM_TMINFOService.SELECT_MES_TM_TMINFO_PRINT>();
                    tmArr.Add(tmList);

                    PrintInfo(Convert.ToInt32(zsnumericUpDown.Value), res.TMINFO.SELECT_MES_TM_TMINFO_PRINT[0].MES_TM_TMINFO_LIST.SIZENAME, "", tmArr.ToArray(),RigthType,Print_Type.fujilot);
                    this.Close();
                   
                }
                else
                {
                    ShowMeg(tmList.MES_RETURN.MESSAGE);
                    return;
                }
               
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
                MES_TM_CZR model = new MES_TM_CZR();
                model.SBBH = MES_PD_SCRW_LIST.SBBH;
                model.GC = MES_PD_SCRW_LIST.GC;
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

                //MES_SY_CZR_BYGH model = ServicModel.TM_CZR.GET_RYNAME(SMtextBox.Text.Trim(), getToken());
                //if (string.IsNullOrEmpty(model.NAME))
                //{
                //    ShowMeg("查不到人员信息");
                //    return;
                //}
                //else
                //{

                //    MES_SY_CZR_BYGH = model;
                //    czrtextBox.Text =  model.NAME;
                //    SMtextBox.Clear();
                //}

            }
        }

        private void czrtextBox_Click(object sender, EventArgs e)
        {
            frmManagerRY fomr = new frmManagerRY(Crzlist, MES_PD_SCRW_LIST, 2);
            //push(fomr);
            show(fomr);
            MES_TM_CZR czr_model = new MES_TM_CZR();
            czr_model.SBBH = MES_PD_SCRW_LIST.SBBH;
            czr_model.GC = MES_PD_SCRW_LIST.GC;
            czr_model.CZLB = 2;
            Crzlist = SelectCZR(czr_model);
            czrtextBox.Text = Crzlist.CZR;
        }

    }
}
