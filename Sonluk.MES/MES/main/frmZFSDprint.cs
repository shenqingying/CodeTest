using Sonluk.MES.MES.Base;
using Sonluk.UI.Model.MES.PD_SCRWService;
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
    public partial class frmZFSDprint : basefrm
    {
        MES_PD_SCRW_LIST _MES_PD_SCRW_LIST;
        int index1 = 0;
        int cell1 = 0;
        public MES_PD_SCRW_LIST MES_PD_SCRW_LIST
        {
            get { return _MES_PD_SCRW_LIST; }
            set { _MES_PD_SCRW_LIST = value; }
        }
        public delegate void Block(string rwbh);
        public Block block;
        public frmZFSDprint()
        {
            InitializeComponent();
        }
        public frmZFSDprint(MES_PD_SCRW_LIST list, string scrq)
        {
            InitializeComponent();
            rkrqtextBox.Text = scrq;
            MES_PD_SCRW_LIST = list;
            scxtextBox.Text = list.SBH;
            dcxxtextBox.Text = list.DCXHNAME + "/" + list.DCDJNAME;
            zflbcomboBox.DataSource = GetDictionaryMX(17);
            zflbcomboBox.DisplayMember = "MXNAME";
            zflbcomboBox.ValueMember = "ID";
            monthCalendar1.Visible = false;
            //monthCalendar2.Visible = false;
            //monthCalendar3.Visible = false;
            MES_PD_SCRW_CCTH res = ServicModel.PD_SCRW.SELECT_ZXCCINFO(list.RWBH,0, getToken());
            if (res.MES_RETURN.TYPE.Equals("S"))
            {
                zhtextBox.Text = res.TH.ToString();               
            }
            else
            {
                ShowMeg(res.MES_RETURN.MESSAGE);
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }

        private void jldataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int index = jldataGridView.CurrentRow.Index;          
            jldataGridView.Rows[index + 1].Cells["xh"].Value = (index + 2).ToString();
            //jldataGridView.CurrentCell = jldataGridView.Rows[index + 1].Cells[0];
            //this.FirstDisplayScrollingIndex = e.RowIndex;
            //jldataGridView.FirstDisplayedScrollingRowIndex = e.RowIndex; 
            jldataGridView.FirstDisplayedScrollingRowIndex = index + 1;
        }

        private void sdzsltextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            judge.isNum(sdzsltextBox, e);
        }

        private void frmZFSDprint_Shown(object sender, EventArgs e)
        {
            jldataGridView.Rows[0].Cells["xh"].Value = "1";
            //jldataGridView.RowTemplate.Height = 35;
            //jldataGridView.RowTemplate.DefaultCellStyle.Font = new Font(q(Msg_Type.fonttype), 11);
        }
        public DataGridViewTextBoxEditingControl CellEdit = null;
        private void jldataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {            
            if ((this.jldataGridView.CurrentCellAddress.X == 3))
            {
                CellEdit = (DataGridViewTextBoxEditingControl)e.Control;
                CellEdit.SelectAll();
                CellEdit.KeyPress += Cells_KeyPress; //绑定事件
                CellEdit.TextChanged += Cells_TextChage;              
            }
            
        }
        private void Cells_TextChage(object sender, EventArgs e)
        {
            //TextBox cb = (TextBox)sender;
            //int sum = 0;
            //for (int i = 0; i < jldataGridView.Rows.Count; i++)
            //{
            //    if (!string.IsNullOrEmpty(Convert.ToString(jldataGridView.Rows[i].Cells["sdsl"].Value)))
            //    {
            //        sum += Convert.ToInt32(jldataGridView.Rows[i].Cells["sdsl"].Value);
            //    }
            //}
            ////int a = Convert.ToInt16(sender);
            //sdzsltextBox.Text = (sum + Convert.ToInt16(cb.Text)).ToString();
        }
        private void Cells_KeyPress(object sender, KeyPressEventArgs e) //自定义事件
        {
           
            if ((this.jldataGridView.CurrentCellAddress.X == 3))
            {
                if (!(e.KeyChar >= '0' && e.KeyChar <= '9'))
                e.Handled = true;
                if (e.KeyChar == '\b') e.Handled = false;
              
               
            }
        }

        private void dybutton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(zhtextBox.Text.Trim()))
            {
                ShowMeg("幢号信息不能为空");
                return;
            }
            if (string.IsNullOrEmpty(dateTimePicker1.Text.Trim()))
            {
                ShowMeg("生产开始时间不能为空");
                return;
            }
            if (string.IsNullOrEmpty(dateTimePicker2.Text.Trim()))
            {
                ShowMeg("生产结束时间不能为空");
                return;
            }
            if (!judge.IsDate(dateTimePicker1.Text.Trim()))
            {
                ShowMeg("生产开始时间不是有效的时间格式");
                return;
            }
            if (!judge.IsDate(dateTimePicker2.Text.Trim()))
            {
                ShowMeg("生产结束时间不是有效的时间格式");
                return;
            }
            TimeSpan midtine = DateTime.Parse(dateTimePicker1.Text.Trim()) - DateTime.Parse(dateTimePicker2.Text.Trim());
            if (midtine.Seconds > 0)
            {
                ShowMeg("生产开始时间不能大于结束时间");
                return;
            }
           
            if (fsnumericUpDown1.Value == 0)
            {
                ShowMeg("打印分数不能为0");
                return;
            }
            if (string.IsNullOrEmpty(cftstextBox.Text.Trim()))
            {
                ShowMeg("存放天数不能为空");
                return;
            }
            //if (string.IsNullOrEmpty(sdzsltextBox.Text.Trim()))
            //{
            //    ShowMeg("素电总数量不能为空");
            //    return;
            //}
            MES_PD_SCRW_ZXCC_INSERT model = new MES_PD_SCRW_ZXCC_INSERT();
            model.GC = MES_PD_SCRW_LIST.GC;
            model.TH = Convert.ToInt32(zhtextBox.Text.Trim());
            model.KSTIME = dateTimePicker1.Text.Trim();//scsjfromtextBox.Text.Trim();
            model.JSTIME = dateTimePicker2.Text.Trim();//scsjtotextBox.Text.Trim();
            model.JLR = Convert.ToInt16(getUserInfo("staffid"));
            model.PC = MES_PD_SCRW_LIST.PC;
            model.REMARK = bzrichTextBox.Text.Trim();            
            model.ZFDCLB = Convert.ToInt32(zflbcomboBox.SelectedValue);
            model.CFTS = Convert.ToInt32(cftstextBox.Text.Trim());
            model.RWBH = MES_PD_SCRW_LIST.RWBH;
            model.TMSX = (int)Print_Type.zfsd;
            model.TMLB = 1;
            model.MAC = DeviceInfo.GetNetCardMAC().Substring(0, 17);
            List<MES_TM_ZFDCMX> submodel = new List<MES_TM_ZFDCMX>();
            bool ispass = true;
            int index2 = 0;
            int sum = 0;
            for (int i = 0; i < jldataGridView.Rows.Count; i++)
            {
                MES_TM_ZFDCMX node = new MES_TM_ZFDCMX();
                node.JSTIME = Convert.ToString(jldataGridView.Rows[i].Cells[2].Value);
                node.KSTIME = Convert.ToString(jldataGridView.Rows[i].Cells[1].Value);
                node.SL = Convert.ToInt32(jldataGridView.Rows[i].Cells[3].Value);
                if (!string.IsNullOrEmpty(node.JSTIME) && !string.IsNullOrEmpty(node.KSTIME) &&node.SL != 0)
                {
                    TimeSpan cha = DateTime.Parse(node.KSTIME) - DateTime.Parse(node.JSTIME);
                    if (cha.TotalMinutes > 0)
                    {
                        index2 = i;
                        ispass = false;
                        break;
                    }
                    else
                    {
                        sum += Convert.ToInt32(jldataGridView.Rows[i].Cells[3].Value);
                        submodel.Add(node);
                    }
                    
                }                
            }
            if (string.IsNullOrEmpty(sdzsltextBox.Text.Trim()))
            {
                sdzsltextBox.Text = sum.ToString();
                model.SL = sum;
            }
            else
            {
                model.SL = Convert.ToInt32(sdzsltextBox.Text.Trim());
            }
            model.MES_TM_ZFDCMX = submodel.ToArray();

            for (int i = 0; i < submodel.Count; i++)
            {
                TimeSpan span = Convert.ToDateTime(model.KSTIME) - Convert.ToDateTime(submodel[i].KSTIME);
                if (span.TotalMinutes > 0 )
                {
                    ShowMeg("第" + (i + 1).ToString() + "开始时间小于抬头开始时间");
                    return;
                }
                span = Convert.ToDateTime(model.JSTIME) - Convert.ToDateTime(submodel[i].JSTIME);
                if (span.TotalMinutes < 0)
                {
                    ShowMeg("第" + (i + 1).ToString() + "结束时间大于抬头结束时间");
                    return;
                }
                //if (model.KSTIME < submodel[i].KSTIME)
                //{
                    
                //}
                //model.KSTIME submodel[i].KSTIME
            }



            if (ispass)
            {
                MES_RETURN_UI res = ServicModel.PD_SCRW.ZX_CC(model, getToken());                              
                if (res.TYPE.Equals("S"))
                {
                    PrintInfoByTM(res.TM, res.GC, Convert.ToInt32(fsnumericUpDown1.Value), Rigth_Type.zhuxiancc, Print_Type.zfsd);
                    if (block != null)
                    {
                        block(MES_PD_SCRW_LIST.RWBH);
                        this.Close();
                    }
                }
                else
                {
                    ShowMeg(res.MESSAGE);
                }              

            }
            else
            {
                ShowMeg("第" + (index2 + 1).ToString() + "行开始时间大于结束时间请检查修改");
            }
          
        }
       
        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            //string fromdate = Convert.ToString(jldataGridView.Rows[index1].Cells["kssj"].Value);
            //string todate = Convert.ToString(jldataGridView.Rows[index1].Cells["jssj"].Value);
            //if (cell1 == 1)
            //{
            //    if (!string.IsNullOrEmpty(todate))
            //    {
            //        TimeSpan midtine = Convert.ToDateTime(monthCalendar1.SelectionStart.ToShortDateString()) -DateTime.Parse(todate);
            //        if (midtine.TotalMinutes > 0)
            //        {
            //            ShowMeg("第" + (index1 + 1).ToString() + "行开始时间大于结束时间请检查修改");
            //        }
            //        else
            //        {
            //            if (!string.IsNullOrEmpty(dateTimePicker1.Text.Trim()) || judge.IsDate(dateTimePicker1.Text.Trim()))
            //            {
            //                TimeSpan midtine1 = Convert.ToDateTime(monthCalendar1.SelectionStart.ToShortDateString()) - Convert.ToDateTime(dateTimePicker1.Text.Trim());
            //                if (midtine1.TotalMinutes >= 0)
            //                {
            //                    jldataGridView.Rows[index1].Cells["kssj"].Value = Convert.ToDateTime(monthCalendar1.SelectionStart.ToShortDateString()).ToString("yyyy-MM-dd");
            //                }
            //                else
            //                {
            //                    ShowMeg("第" + (index1 + 1).ToString() + "行开始时间大于抬头开始时间请检查修改");
                                
            //                }
            //            }
            //            else
            //            {
            //                jldataGridView.Rows[index1].Cells["kssj"].Value = Convert.ToDateTime(monthCalendar1.SelectionStart.ToShortDateString()).ToString("yyyy-MM-dd");
            //            }
                        
            //        }
            //    }
            //    else
            //    {
            //        if (!string.IsNullOrEmpty(dateTimePicker1.Text.Trim()) || judge.IsDate(dateTimePicker1.Text.Trim()))
            //        {
            //            TimeSpan midtine1 = Convert.ToDateTime(monthCalendar1.SelectionStart.ToShortDateString()) - Convert.ToDateTime(dateTimePicker1.Text.Trim());
            //            if (midtine1.TotalMinutes >= 0)
            //            {



            //                jldataGridView.Rows[index1].Cells["kssj"].Value = Convert.ToDateTime(monthCalendar1.SelectionStart.ToShortDateString()).ToString("yyyy-MM-dd");
                            
            //            }
            //            else
            //            {
            //                ShowMeg("第" + (index1 + 1).ToString() + "行开始时间大于抬头开始时间请检查修改");
            //            }
            //        }
            //        else
            //        {
            //            jldataGridView.Rows[index1].Cells["kssj"].Value = Convert.ToDateTime(monthCalendar1.SelectionStart.ToShortDateString()).ToString("yyyy-MM-dd");
            //        }
            //        //jldataGridView.Rows[index1].Cells["kssj"].Value = Convert.ToDateTime(monthCalendar1.SelectionStart.ToShortDateString()).ToString("yyyy-MM-dd");
            //    }
              
            //}
            //else if (cell1 == 2)
            //{
            //    if (!string.IsNullOrEmpty(fromdate))
            //    {
            //        TimeSpan midtine = DateTime.Parse(fromdate) - Convert.ToDateTime(monthCalendar1.SelectionStart.ToShortDateString());
            //        if (midtine.TotalMinutes > 0)
            //        {
            //            ShowMeg("第" + (index1 + 1).ToString() + "行开始时间大于结束时间请检查修改");
            //        }
            //        else
            //        {
            //            if (!string.IsNullOrEmpty(dateTimePicker2.Text.Trim()) || judge.IsDate(dateTimePicker2.Text.Trim()))
            //            {
            //                TimeSpan midtine1 = Convert.ToDateTime(monthCalendar1.SelectionStart.ToShortDateString()) - Convert.ToDateTime(dateTimePicker2.Text.Trim());
            //                if (midtine1.TotalMinutes > 0)
            //                {
            //                    ShowMeg("第" + (index1 + 1).ToString() + "行结束时间大于抬头结束时间请检查修改");
                               
            //                }
            //                else
            //                {
            //                    jldataGridView.Rows[index1].Cells["jssj"].Value = Convert.ToDateTime(monthCalendar1.SelectionStart.ToShortDateString()).ToString("yyyy-MM-dd");

            //                }
            //            }
            //            else
            //            {
            //                jldataGridView.Rows[index1].Cells["jssj"].Value = Convert.ToDateTime(monthCalendar1.SelectionStart.ToShortDateString()).ToString("yyyy-MM-dd");
            //            }


                     
            //        }
            //    }
            //    else
            //    {
            //        if (!string.IsNullOrEmpty(dateTimePicker2.Text.Trim()) || judge.IsDate(dateTimePicker2.Text.Trim()))
            //        {
            //            TimeSpan midtine1 = Convert.ToDateTime(monthCalendar1.SelectionStart.ToShortDateString()) - Convert.ToDateTime(dateTimePicker2.Text.Trim());
            //            if (midtine1.TotalMinutes > 0)
            //            {
            //                ShowMeg("第" + (index1 + 1).ToString() + "行结束时间大于抬头结束时间请检查修改");                        
            //            }
            //            else
            //            {
            //                jldataGridView.Rows[index1].Cells["jssj"].Value = Convert.ToDateTime(monthCalendar1.SelectionStart.ToShortDateString()).ToString("yyyy-MM-dd");
            //            }
            //        }
            //        else
            //        {
            //            jldataGridView.Rows[index1].Cells["jssj"].Value = Convert.ToDateTime(monthCalendar1.SelectionStart.ToShortDateString()).ToString("yyyy-MM-dd");
            //        }


                   
            //    }
                
            //}
            if (cell1 == 1)
            {
                jldataGridView.Rows[index1].Cells["kssj"].Value = Convert.ToDateTime(monthCalendar1.SelectionStart.ToShortDateString()).ToString("yyyy-MM-dd");
            }
            else if (cell1 == 2)
            {
                jldataGridView.Rows[index1].Cells["jssj"].Value = Convert.ToDateTime(monthCalendar1.SelectionStart.ToShortDateString()).ToString("yyyy-MM-dd");
            }
            cell1 = 0;
            index1 = 0;
            monthCalendar1.Visible = false;
        }
       
        private void jldataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (this.jldataGridView.CurrentCellAddress.X == 1 || this.jldataGridView.CurrentCellAddress.X == 2)
                {
                    index1 = this.jldataGridView.CurrentRow.Index;
                    cell1 = this.jldataGridView.CurrentCellAddress.X;
                    monthCalendar1.Visible = true;
                }
            }
           
        }

        private void jldataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (this.jldataGridView.CurrentCellAddress.X == 4)
                {
                    if (jldataGridView.CurrentRow.Index == jldataGridView.Rows.Count - 1)
                    {
                        ShowMeg("无法删除新增行的数据");
                    }
                    else
                    {
                        jldataGridView.Rows.RemoveAt(this.jldataGridView.CurrentRow.Index);
                        for (int i = 0; i < jldataGridView.Rows.Count; i++)
                        {
                            jldataGridView.Rows[i].Cells["xh"].Value = (i + 1).ToString();
                        }
                    }

                }
            }
           

        }

        private void zhtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            judge.isNum(zhtextBox, e);
        }

        private void cftstextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            judge.isNum(cftstextBox, e);
        }

        private void jldataGridView_EditModeChanged(object sender, EventArgs e)
        {
           
        }

        private void jldataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void sdzsltextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void jldataGridView_Scroll(object sender, ScrollEventArgs e)
        {

        }

        //private void monthCalendar2_DateSelected(object sender, DateRangeEventArgs e)
        //{
        //    scsjfromtextBox.Text =  Convert.ToDateTime(monthCalendar2.SelectionStart.ToShortDateString()).ToString("yyyy-MM-dd");
        //    monthCalendar2.Visible = false;
        //}

        //private void monthCalendar3_DateSelected(object sender, DateRangeEventArgs e)
        //{
        //  scsjtotextBox.Text =  Convert.ToDateTime(monthCalendar3.SelectionStart.ToShortDateString()).ToString("yyyy-MM-dd");
        //  monthCalendar3.Visible = false;
        //}

        //private void scsjfromtextBox_Click(object sender, EventArgs e)
        //{
        //    monthCalendar2.Visible = true;
        //}

        //private void scsjtotextBox_Click(object sender, EventArgs e)
        //{
        //    monthCalendar3.Visible = true;
        //}
    }
}
