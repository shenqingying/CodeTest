using Sonluk.MES.MES.Base;
using Sonluk.UI.Model.MES.TM_TMINFOService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using Sonluk.UI.Model.MES;


using System.IO;
using Sonluk.UI.Model.MES.SY_TYPEMXService;
using System.Runtime.InteropServices;
using Sonluk.MES.MES.publics;
namespace Sonluk.MES.MES.main
{
    public partial class frmPrint_N : basefrm
    {
        #region
       
       
        #endregion

        private const int rk_with = 210;
        private const int rk_height = 148;
         
        public frmPrint_N()
        {
            InitializeComponent();
        }
        public frmPrint_N(MES_TM_TMINFO_INSERT_GL model, Print_Type type, Rigth_Type rtype)
        {

            InitializeComponent();
            RigthType = rtype;
            MES_TM_TMINFO_INSERT_GL = model;
            if (!string.IsNullOrEmpty(MES_TM_TMINFO_INSERT_GL.MES_TM_TMINFO.MAXVALUE))
            {
                xstextBox.MaxLength = Convert.ToInt32(MES_TM_TMINFO_INSERT_GL.MES_TM_TMINFO.MAXVALUE);
            }

            CPZTcomboBox.Visible = false;
            label5.Text = q(Msg_Type.titleslspace);//"数  量:";
            label4.Text = q(Msg_Type.titlexsspace);//"箱  数:";
            tstextBox.Visible = true;
           
            if (type == Print_Type.lot )
            {
               tstextBox.Visible = false;                               
               CPZTcomboBox.Location = tstextBox.Location;
               label5.Text = q(Msg_Type.titleztspace);//"状  态:";
               label4.Text = q(Msg_Type.titleslspace);//"数  量:";
               xstextBox.Text = model.MES_TM_TMINFO.SL == 0 ? "" : model.MES_TM_TMINFO.SL.ToString();
              
               
               MES_SY_TYPEMX TYPEMX = new MES_SY_TYPEMX();
               TYPEMX.TYPEID = 9;
               TYPEMX.GC = Convert.ToString(getGC("value"));
               CPZTcomboBox.DataSource =  ServicModel.SY_TYPEMX.SELECT( TYPEMX,getToken());
               CPZTcomboBox.Visible = true;
               CPZTcomboBox.DisplayMember = "MXNAME";
               CPZTcomboBox.ValueMember = "ID";
            }
            else if (type == Print_Type.rk)
            {                
            }
            PrintType = type;
            RigthType = rtype;
            switch (type)
            {
                case Print_Type.rk:
                    this.Text = q(Msg_Type.fielddyrkbs);//"打印入库标识";
                    break;
                case Print_Type.lot:
                    this.Text = q(Msg_Type.fielddylotB);//"打印LOT";
                    break;
                default:
                    break;
            }           
            MES_TM_TMINFO_INSERT_GL = model;
            xstextBox.Select();
            if (RigthType == Rigth_Type.gangketl_cc)
            {
                fsnumericUpDown.Value = 3;
            }
            else if (RigthType == Rigth_Type.ddjtl_cc)
            {
                fsnumericUpDown.Value = 4;
            }
            if (RigthType == Rigth_Type.jidiantitl_cc || RigthType == Rigth_Type.fujifengkoujitl_cc || RigthType == Rigth_Type.zhengjifengkoujitl_cc)
            {
                Sonluk.UI.Model.MES.PD_SCRWService.MES_PD_SCRW_CCTH res = new UI.Model.MES.PD_SCRWService.MES_PD_SCRW_CCTH();
                if (RigthType == Rigth_Type.jidiantitl_cc)
                {
                    res = ServicModel.PD_SCRW.SELECT_ZXCCINFO(MES_TM_TMINFO_INSERT_GL.MES_TM_TMINFO.RWBH, MES_TM_TMINFO_INSERT_GL.MES_TM_TMINFO.BC, getToken());
                }
                else
                {
                    res = ServicModel.PD_SCRW.SELECT_ZXCCINFO(MES_TM_TMINFO_INSERT_GL.MES_TM_TMINFO.RWBH, 0, getToken());
                }

                if (res.MES_RETURN.TYPE.Equals("S"))
                {                   
                    qshtextBox.Text = res.TH.ToString();                    
                }
                else
                {
                    ShowMeg(q(Msg_Type.msgthdataexcept)+res.MES_RETURN.MESSAGE);//"获取桶号信息报错"
                }              
            }
            else
            {
                qshtextBox.Visible = false;
                label7.Visible = false;
                richTextBox1.Width = 426;
            }
            
        }




        public delegate void Block();
        public Block block;
        private void dybutton_Click(object sender, EventArgs e)
        {
            print();          
        }
        private void print()
        {
            dybutton.Focus();
            bool mgs1 = Verify();
            if (mgs1 == false)
            {
                return;
            }
            MsgReturn mgs = GetTM();
            if (mgs.Pass == false)
            {
                //MessageBox.Show(mgs.Msg, "消息框");
                ShowMeg(mgs.Msg);
                return;
            }
            PrintInfo(Convert.ToInt32(fsnumericUpDown.Value), xstextBox.Text.Trim(), tstextBox.Text.Trim(), PrintList, RigthType, PrintType);//PrintType
            if (block != null)
            {
                block();

            }
            this.Close();
        }



        private void previewbutton_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        private void fhbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();

            
        }
        private MsgReturn GetTM()
        {
            MsgReturn msg = new MsgReturn();
            msg.Pass = false;
            msg.Msg = q(Msg_Type.msginserttmfail);//"生成条码失败！！！";            
            MES_TM_TMINFO_INSERT_RETURN res = new MES_TM_TMINFO_INSERT_RETURN();           
           res = Createbarcode(Convert.ToInt32(tmnumericUpDown.Value));         
            if (res.MES_RETURN.TYPE.Equals("S"))
            {
                PrintList = res.SELECT_MES_TM_TMINFO_PRINT; 
                msg.Pass = true;
            }
            else
            {
                msg.Msg = res.MES_RETURN.MESSAGE;
            }           
            return msg;
        }

        private MES_TM_TMINFO_INSERT_RETURN Createbarcode(int TMcount)
        {
            int flag = 0;
          
            if (RigthType == Rigth_Type.jidiantitl_cc || RigthType == Rigth_Type.fujifengkoujitl_cc || RigthType == Rigth_Type.zhengjifengkoujitl_cc)
            {
                MES_TM_TMINFO_INSERT_GL.MES_TM_TMINFO.TH = Convert.ToInt32(qshtextBox.Text.Trim());
                flag = 1;
            }           
            MES_TM_TMINFO_INSERT_GL.MES_TM_TMINFO.TMCOUNT = TMcount;
            MES_TM_TMINFO_INSERT_GL.MES_TM_TMINFO.REMARK = richTextBox1.Text.Trim();
            MES_TM_TMINFO_INSERT_GL.MES_TM_TMINFO.MAC = DeviceInfo.GetNetCardMAC().Substring(0, 17);
            if (PrintType == Print_Type.lot)
            {
                MES_TM_TMINFO_INSERT_GL.MES_TM_TMINFO.CPZT = Convert.ToInt32(CPZTcomboBox.SelectedValue);
                MES_TM_TMINFO_INSERT_GL.MES_TM_TMINFO.TMSX = (int)Print_Type.lot;
                MES_TM_TMINFO_INSERT_GL.MES_TM_TMINFO.TMLB = 1;
                MES_TM_TMINFO_INSERT_GL.MES_TM_TMINFO.SL = Convert.ToDecimal(xstextBox.Text.Trim());
            }
            else
            {
                MES_TM_TMINFO_INSERT_GL.MES_TM_TMINFO.CPZT = 80;
                MES_TM_TMINFO_INSERT_GL.MES_TM_TMINFO.TMLB = 2;
                MES_TM_TMINFO_INSERT_GL.MES_TM_TMINFO.TMSX = (int)Print_Type.rk;
                MES_TM_TMINFO_INSERT_GL.MES_TM_TMINFO.SL = Convert.ToDecimal(tstextBox.Text.Trim());
            }         
            MES_TM_TMINFO_INSERT_RETURN r = ServicModel.TM_TMINFO.INSERT(MES_TM_TMINFO_INSERT_GL,flag, getToken());
            
           
            return r;
        }
        

        public class comboxclass
        {
            string _text;

            public string Text
            {
                get { return _text; }
                set { _text = value; }
            }
            string _value;

            public string Value
            {
                get { return _value; }
                set { _value = value; }
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {            
          
            
        }
       

        private void xstextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            judge.isNum(xstextBox, e);

        }

        private void tstextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            judge.isNum(tstextBox, e);
        }


        private bool Verify()
        {
            bool judge = true;
            if (PrintType == Print_Type.rk )
            {
                if (string.IsNullOrEmpty(tstextBox.Text))
                {
                    //MessageBox.Show("产出托数不能为空", "消息框");
                    ShowMeg(q(Msg_Type.msgcctsnoempty));
                    tstextBox.Select();
                    return false;
                }
                if (string.IsNullOrEmpty(xstextBox.Text))
                {
                    //MessageBox.Show("产出箱数不能为空", "消息框");
                    ShowMeg(q(Msg_Type.msgccxsnoempty));
                    xstextBox.Select();
                    return false;;
                }
                if (string.IsNullOrEmpty(fsnumericUpDown.Value.ToString()))
                {
                    if (Convert.ToInt32(fsnumericUpDown.Value) == 0)
                    {
                        //ShowMeg("打印分数必须大于0");
                        ShowMeg(q(Msg_Type.msgprintnoempty));
                        fsnumericUpDown.Select();
                        return false;
                    }
                    //MessageBox.Show("打印分数不能为空");
                    ShowMeg(q(Msg_Type.msgprintnoempty));
                    fsnumericUpDown.Select();
                    return false; ;
                }
            }
            else if (PrintType == Print_Type.lot)
            {
                
                if (string.IsNullOrEmpty(xstextBox.Text))
                {
                    //MessageBox.Show("产出数量不能为空", "消息框");
                    ShowMeg(q(Msg_Type.msgccslnoempty));
                    xstextBox.Select();
                    return false; ;
                }
                if (!string.IsNullOrEmpty(MES_TM_TMINFO_INSERT_GL.MES_TM_TMINFO.MINVALUE))
                {
                    //int a = Convert.ToInt32(xstextBox.Text.Trim());
                    //int b = Convert.ToInt32(MES_TM_TMINFO_INSERT_GL.MES_TM_TMINFO.MINVALUE);
                    if (Convert.ToDouble(xstextBox.Text.Trim()) <= Convert.ToInt32(MES_TM_TMINFO_INSERT_GL.MES_TM_TMINFO.MINVALUE) )
                    {
                        //MessageBox.Show("产出数量不能小于" + MES_TM_TMINFO_INSERT_GL.MES_TM_TMINFO.MINVALUE , "消息框");
                        ShowMeg(string.Format(q(Msg_Type.msgccslextend), MES_TM_TMINFO_INSERT_GL.MES_TM_TMINFO.MINVALUE));
                        xstextBox.Select();
                        return false; ;
                    }
                }
               
                if (string.IsNullOrEmpty(fsnumericUpDown.Value.ToString()))
                {
                    if (Convert.ToInt32(fsnumericUpDown.Value) == 0)
                    {
                        //ShowMeg("打印分数必须大于0");
                        ShowMeg(q(Msg_Type.msgprintnoempty));
                        fsnumericUpDown.Select();
                        return false;
                    }
                    //MessageBox.Show("打印份数不能为空", "消息框");
                    ShowMeg(q(Msg_Type.msgprintnoempty));
                    fsnumericUpDown.Select();
                    return false; ;
                }
            }
            return judge;
        }

        private void TMtextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MES_TM_TMINFO model = new MES_TM_TMINFO();
                model.GC = MES_TM_TMINFO_INSERT_GL.MES_TM_TMINFO.GC;               
                SELECT_MES_TM_TMINFO_BYTM res = ServicModel.TM_TMINFO.SELECT_BYTM(model, 0, getToken());             
                if (res.MES_RETURN.TYPE.Equals("S"))
                {
                    if (res.MES_TM_TMINFO_LIST[0].TMLB != 2)
	                {
                        //ShowMeg("请扫描领用表条码");
                        ShowMeg(q(Msg_Type.msgscanlybtm));
	                } 
                }
                else
                {
                    ShowMeg(res.MES_RETURN.MESSAGE);
                }

            }
        }

        private void xstextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                print();
            }
        }

        private void fsnumericUpDown_Leave(object sender, EventArgs e)
        {
            fsnumericUpDown.Tag = 0;
        }

        private void fsnumericUpDown_MouseDown(object sender, MouseEventArgs e)
        {
            if (Convert.ToInt32(fsnumericUpDown.Tag) == 0)
            {              
                fsnumericUpDown.Select(0, fsnumericUpDown.Text.Length);
                fsnumericUpDown.Tag = 1;
            }
        }

        private void tmnumericUpDown_MouseDown(object sender, MouseEventArgs e)
        {
            if (Convert.ToInt32(tmnumericUpDown.Tag) == 0)
            {              
                tmnumericUpDown.Select(0, tmnumericUpDown.Text.Length);
                tmnumericUpDown.Tag = 1;
            }
           
        }

        private void tmnumericUpDown_Leave(object sender, EventArgs e)
        {
            tmnumericUpDown.Tag = 0;
        }

        private void qshtextBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (Convert.ToInt32(qshtextBox.Tag) == 0)
            {              
                qshtextBox.SelectAll();
                qshtextBox.Tag = 1;
            }
        }

        private void qshtextBox_Leave(object sender, EventArgs e)
        {
            qshtextBox.Tag = 0;
        }

        private void qshtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            judge.isNum(qshtextBox, e);
        }
       


    }
   


    

}
