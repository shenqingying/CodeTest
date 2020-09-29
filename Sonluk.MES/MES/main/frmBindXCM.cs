using Sonluk.MES.MES.Base;
using Sonluk.UI.Model.MES.MES_WLKCBSService;
using Sonluk.UI.Model.MES.TM_TMINFOService;
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
    public partial class frmBindXCM : basefrm
    {
        List<MES_TM_TMINFO_LIST> _bindList;

        public List<MES_TM_TMINFO_LIST> BindList
        {
            get { return _bindList; }
            set { _bindList = value; }
        }

      

      
        ZSL_BCS303_BS _ZSL_BCS303_BS;

        public ZSL_BCS303_BS ZSL_BCS303_BS
        {
            get { return _ZSL_BCS303_BS; }
            set { _ZSL_BCS303_BS = value; }
        }
        List<ZSL_BCS303_BS> _XCList;

        public List<ZSL_BCS303_BS> XCList
        {
            get { return _XCList; }
            set { _XCList = value; }
        }
        int _rowIndex;

        public int RowIndex
        {
            get { return _rowIndex; }
            set { _rowIndex = value; }
        }
        bool isInit;

        public bool IsInit
        {
            get { return isInit; }
            set { isInit = value; }
        }

      
        public frmBindXCM()
        {
            InitializeComponent();
        }
        public frmBindXCM(ZSL_BCS303_BS list,int rowindex)
        {
            InitializeComponent();
            BomdataGridView.AutoGenerateColumns = false;
            dataGridView2.AutoGenerateColumns = false;
            RowIndex = rowindex;
            XCList = new List<UI.Model.MES.MES_WLKCBSService.ZSL_BCS303_BS>();
            BindList = new List<MES_TM_TMINFO_LIST>();
            ZSL_BCS303_BS = list;




            wlpzlabel.Text = q(Msg_Type.titlewlpzxmnd) +list.MBLNR + "/" + list.ZEILE + "/" + list.MJAHR;//"物料凭证/项目/年度:"
            wlxxlabel.Text = q(Msg_Type.titlewlxx)+list.MATNR + "/" + list.MAKTX;//"物料信息:"
            gyslabel.Text = q(Msg_Type.titlegysxx)+list.LIFNR + "/" + list.SORTL;//"供应商信息:"
            cglabel.Text = q(Msg_Type.titlepo) +list.EBELN + "/" + list.EBELP;//"采购订单/项目:"
            
            ZSL_BCS303_BS model = new UI.Model.MES.MES_WLKCBSService.ZSL_BCS303_BS();
            model.MBLNR = list.MBLNR;
            model.XCBS = list.XCBS;
            model.MJAHR = list.MJAHR;
            model.LINE_ID = list.LINE_ID;
            model.LIFNR = list.LIFNR;
            ZBCFUN_PURBS_READ res1 = ServicModel.MES_WLKCBS.GET_WLPZ_ZJ(model, getToken()); ;
            if (res1.MES_RETURN.TYPE.Equals("S"))
            {
                XCList = res1.ET_PURBS.ToList();
                for (int i = 0; i < res1.ET_PURBS.Length; i++)
                {
                    res1.ET_PURBS[i].MATNR = res1.ET_PURBS[i].MATNR + "/" + res1.ET_PURBS[i].MAKTX;
                }
                BomdataGridView.DataSource = res1.ET_PURBS;
                
            }
            else
            {
                ShowMeg(res1.MES_RETURN.MESSAGE);
            }

            
            MES_TM_TMINFO tmmodel = new MES_TM_TMINFO();
            string[] xcmArr = list.XCZJTM.Split(',');
            for (int j = 0; j < xcmArr.Length; j++)
            {
                tmmodel.TM = xcmArr[j];
                SELECT_MES_TM_TMINFO_BYTM res = ServicModel.TM_TMINFO.SELECT_BYTM(tmmodel, 0, getToken());
                if (res.MES_RETURN.TYPE.Equals("S"))
                {
                    for (int i = 0; i < res.MES_TM_TMINFO_LIST.Length; i++)
                    {
                        BindList.Add(res.MES_TM_TMINFO_LIST[i]);
                    }
                    for (int i = 0; i < BindList.Count; i++)
                    {
                        BindList[i].XH = i + 1;
                        BindList[i].WLMS = BindList[i].WLH + "/" + BindList[i].WLMS;
                    }
                    dataGridView2.DataSource = new List<MES_TM_TMINFO_LIST>();
                    dataGridView2.DataSource = BindList;
                    dataGridView2.ClearSelection();
                    
                }
            }
        }

        private void frmBindXCM_Shown(object sender, EventArgs e)
        {
            BomdataGridView.Columns["状态"].DefaultCellStyle.BackColor = Color.Red;//  q(Msg_Type.fieldstatus)
            BomdataGridView.ClearSelection();
            isInit = true;
            Verify();
            isInit = false;
        }

        private void SMtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            
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
            bool isY = false;
            for (int i = 0; i < BindList.Count; i++)
            {
                if (SMtextBox.Text.Trim().ToUpper() == BindList[i].TM)
                {
                    isY = true;
                }
            }
            if (isY)
            {
                ShowMeg(string.Format(q(Msg_Type.msgtmcf),SMtextBox.Text.Trim()));//
                SMtextBox.Clear();
                SMtextBox.Select();
                return;
            }


            MES_WLKCBS_GETWLZJ_IN model = new MES_WLKCBS_GETWLZJ_IN();
            model.MBLNR = ZSL_BCS303_BS.MBLNR;
            model.XCBS = ZSL_BCS303_BS.XCBS;
            model.MJAHR = ZSL_BCS303_BS.MJAHR;
            model.LINE_ID = ZSL_BCS303_BS.LINE_ID;
            model.LIFNR = ZSL_BCS303_BS.LIFNR;
            model.TM = SMtextBox.Text.Trim().ToUpper();
            SELECT_MES_TM_TMINFO_BYTM res = ServicModel.TM_TMINFO.SELECT_WLKCBS(model, getToken());
            if (res.MES_RETURN.TYPE.Equals("S"))
            {
                for (int i = 0; i < res.MES_TM_TMINFO_LIST.Length; i++)
                {
                    BindList.Add(res.MES_TM_TMINFO_LIST[i]);
                }                
                for (int i = 0; i < BindList.Count; i++)
                {
                    BindList[i].XH = i + 1;
                    BindList[i].WLMS = BindList[i].WLH + "/" + BindList[i].WLMS;
                }
                dataGridView2.DataSource = new List<MES_TM_TMINFO_LIST>();
                dataGridView2.DataSource = BindList;
                dataGridView2.ClearSelection();
                Verify();
            }
            else
            {
                ShowMeg(res.MES_RETURN.MESSAGE);
            }
            SMtextBox.Clear();
            SMtextBox.Select();

            



        }
        public void Verify()
        {
            //BomdataGridView.Columns["状态"].DefaultCellStyle.BackColor = Color.Red;
            for (int i = 0; i < BomdataGridView.Rows.Count; i++)
            {
                BomdataGridView.Rows[i].Cells["状态"].Style.BackColor = Color.Red;//q(Msg_Type.fieldstatus)

            }
            int all = 0;
            for (int i = 0; i < XCList.Count; i++)
            {
                for (int j = 0; j < BindList.Count; j++)
                {
                    if (XCList[i].WERKS == BindList[j].GC && XCList[i].CHARG == BindList[j].PC && XCList[i].WLDL == BindList[j].WLLBNAME)
                    {
                        all++;
                        BomdataGridView.Rows[i].Cells["状态"].Style.BackColor = Color.FromArgb(187, 255, 102);//q(Msg_Type.fieldstatus)
                    }
                }
            }
            if (!isInit)
            {
                if (all == XCList.Count && all > 0)
                {

                    string xcStr = BindList[0].TM;
                    for (int i = 1; i < BindList.Count; i++)
                    {
                        xcStr += "," + BindList[i].TM;
                    }
                    if (block != null)
                    {
                        block(xcStr, RowIndex);
                        this.Close();
                    }
                }
            }
          

         

        }
        public  delegate void Block(string content,int rowIndex);
        public Block block;
        private void button1_Click(object sender, EventArgs e)
        {
            int count = 0;
            for (int i = 0; i < XCList.Count; i++)
            {
                for (int j = 0; j < BindList.Count; j++)
                {
                    if (XCList[i].WERKS == BindList[j].GC && XCList[i].CHARG == BindList[j].PC && XCList[i].WLDL == BindList[j].WLLBNAME)
                    {
                        count++;
                        break;
                    }
                }
            }
            if (count != 0 && XCList.Count == count)
            {
                string xcStr = BindList[0].TM;
                for (int i = 1; i < BindList.Count; i++)
                {
                    xcStr += "," + BindList[i].TM;                    
                }
                if (block != null)
                {
                    block(xcStr, RowIndex);
                    this.Close();
                }
            }
            else if (count == 0)
            {
                if (block != null)
                {
                    block("", RowIndex);
                    this.Close();
                }
            }
            else
            {

                ShowMeg(q(Msg_Type.msgxcunfinish));//"下层信息不齐全,请检查数据在进行关联"
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (this.dataGridView2.CurrentCell.OwningColumn.Name == "删除")//q(Msg_Type.fielddelete)
                {
                    
                    int index = dataGridView2.CurrentRow.Index;
                    BindList.RemoveAt(index);
                    for (int i = 0; i < BindList.Count; i++)
                    {
                        BindList[i].XH = (i + 1);
                    }
                    int a = dataGridView2.Columns.Count;
                    if (BindList.Count == 0)
                    {
                        dataGridView2.DataSource = new List<MES_TM_TMINFO_LIST>();
                        dataGridView2.Columns["删除"].DisplayIndex = 4;//q(Msg_Type.fielddelete)


                    }
                    else
                    {
                        dataGridView2.DataSource = BindList.ToArray();
                        dataGridView2.Columns["删除"].DisplayIndex = 4;//q(Msg_Type.fielddelete)
                    }
                    dataGridView2.ClearSelection();

                    Verify();
                }
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(ZSL_BCS303_BS.TM))
            //{
            //    if (block != null)
            //    {
            //        block("", RowIndex);
            //        this.Close();
            //    }
            //}
            //else
            //{
            //    ShowMeg("已经生成条码的只能替换下层码无法删除所有关联数据");
            //}
            if (MessageBox.Show(q(Msg_Type.msgwhethercanclcz), q(Msg_Type.msgtitle), MessageBoxButtons.OKCancel) == DialogResult.OK)//"确定取消本次操作？"
            {
                this.Close();
            }  
           
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }
    }
}
