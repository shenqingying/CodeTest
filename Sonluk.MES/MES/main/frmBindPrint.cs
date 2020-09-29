using Sonluk.MES.MES.Base;
using Sonluk.UI.Model.MES.SY_TYPEMXService;
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
    public partial class frmBindPrint : basefrm
    {
        string _print;

        public string Print
        {
            get { return _print; }
            set { _print = value; }
        }
        public frmBindPrint()
        {
            InitializeComponent();
        }
        public frmBindPrint(Print_Type ptype)
        {
            InitializeComponent();
            MES_SY_TYPEMXLIST[] res = GetDictionaryMX(18);
            zzcomboBox.DataSource = GetDictionaryMX(18);
            zzcomboBox.DisplayMember = "MXNAME";
            zzcomboBox.ValueMember = "ID";
            List<string> printArr = publics.PrintPublic.GetLocalPrinters();
            dyjcomboBox.DataSource = printArr;
            string a = getPrinter(key_A5); 
            switch (ptype)
            {
                case Print_Type.none:
                    //zzcomboBox.SelectedValue = 418;
                    break;
                case Print_Type.rk:
                    zzcomboBox.SelectedValue = 418;
                    dyjcomboBox.Text = getPrinter(key_A5);
                    break;
                case Print_Type.lot:
                    zzcomboBox.SelectedValue = 419;//
                    dyjcomboBox.Text = getPrinter(key_lot);
                    break;
                case Print_Type.zjlot:
                    zzcomboBox.SelectedValue = 419;
                    dyjcomboBox.Text = getPrinter(key_lot);
                    break;
                case Print_Type.fujilot:
                    zzcomboBox.SelectedValue = 419;
                    dyjcomboBox.Text = getPrinter(key_lot);
                    break;
                case Print_Type.zxlot:
                    zzcomboBox.SelectedValue = 418;
                    dyjcomboBox.Text = getPrinter(key_A5);
                    break;
                case Print_Type.bblot:
                    zzcomboBox.SelectedValue = 419;
                    dyjcomboBox.Text = getPrinter(key_lot);
                    break;
                case Print_Type.zfsd:
                    zzcomboBox.SelectedValue = 418;
                    dyjcomboBox.Text = getPrinter(key_A5);
                    break;
                case Print_Type.wlrk:
                    zzcomboBox.SelectedValue = 418;
                    dyjcomboBox.Text = getPrinter(key_A5);
                    break;
                case Print_Type.zhdc:
                    zzcomboBox.SelectedValue = 419;
                    dyjcomboBox.Text = getPrinter(key_lot);
                    break;
                default:
                    break;
            }
           

            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(dyjcomboBox.Text))
            {
                ShowMeg(q(Msg_Type.msgprintnamenoempty));//打印机名称不能为空
            }
            else
            {
                int value  =  Convert.ToInt32(zzcomboBox.SelectedValue);
                if (value == 418)
                {

                    //string contentStr = "打印格式" + "A5纸" + "绑定打印机成功";
                    string contentStr = q(Msg_Type.msgbindA5success);
                    ini.IniWriteValue(ini.Section_Print, "A5", dyjcomboBox.Text);
                    if (string.IsNullOrEmpty(ini.IniReadValue(ini.Section_Print,"Lot")))
                    {
                        ShowMeg(contentStr + "," + q(Msg_Type.msgpleasebindLot));
                        zzcomboBox.SelectedValue = 419;
                    }
                    else
                    {
                        //ShowMeg("打印机配置全部完成");
                        ShowMeg(q(Msg_Type.msgprintsettingfinish));
                    }
                    
                }
                else if (value == 419)
                {
                    //LOT
                    ini.IniWriteValue(ini.Section_Print, "LOT", dyjcomboBox.Text);
                    string contentStr = q(Msg_Type.msgbindLotsuccess);//"打印格式" + "LOT表" + "绑定打印机成功";
                    if (string.IsNullOrEmpty(ini.IniReadValue(ini.Section_Print, "A5")))
                    {
                        ShowMeg(contentStr + "," + q(Msg_Type.msgpleasebindA5));
                        zzcomboBox.SelectedValue = 418;
                    }
                    else
                    {
                        //ShowMeg("打印机配置全部完成");
                        ShowMeg(q(Msg_Type.msgprintsettingfinish));
                    }
                    
                }
                
                //this.Close();
            } 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int value = Convert.ToInt32(zzcomboBox.SelectedValue);
            if (value == 418)
            {
                //A5
                string printname =  ini.IniReadValue(ini.Section_Print, "A5");
                if (string.IsNullOrEmpty(printname))
                {
                    ShowMeg(q(Msg_Type.msgfirstbindA5));//"请先绑定A5纸对应的打印机"
                }
                else
                {
                    Print = q(Msg_Type.msgtestA5);//"A5纸打印测试";
                    printDocument1.PrinterSettings.PrinterName = printname;
                    printDocument1.Print();
                }


            }
            else if (value == 419)
            {
                //LOT
                string printname = ini.IniReadValue(ini.Section_Print, "LOT");
                if (string.IsNullOrEmpty(printname))
                {
                    ShowMeg(q(Msg_Type.msgfirstbindRM));//"请先绑定热敏纸对应的打印机"
                }
                else
                {
                    Print = q(Msg_Type.msgtestRM);//"热敏纸打印测试";
                    printDocument1.PrinterSettings.PrinterName = printname;
                    
                    printDocument1.Print();
                }
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font font = new Font(q(Msg_Type.fonttype), 25);
            Brush bru = Brushes.Blue;
            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Center;//垂直居中
            format.Alignment = StringAlignment.Center;//水平居中
            if (Print.Equals(q(Msg_Type.msgtestA5)))//"A5纸打印测试"
	        {
                e.Graphics.DrawString(Print,font,bru,new Rectangle(0,20,827,40),format);
            }
            else if (Print.Equals(q(Msg_Type.msgtestRM)))//"热敏纸打印测试"
            {
                e.Graphics.DrawString(Print, font, bru, new Rectangle(0, 0, 272, 600), format);
              
            }
            //e.Graphics.DrawString(Print,font,bru,);


           
        }
    }
}
