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
    public partial class frmPrintList : basefrm
    {
        int _index;

        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }
        string _printStyle;

        public string PrintStyle
        {
            get { return _printStyle; }
            set { _printStyle = value; }
        }
        public frmPrintList()
        {
            InitializeComponent();
          
        }
        public frmPrintList(int index,string printStyle)
        {
            InitializeComponent();
            PrintStyle = printStyle;
            Index = index;
            List<string> printArr = publics.PrintPublic.GetLocalPrinters();
            for (int i = 0; i < printArr.Count; i++)
            {

                Button btn = new Button();
                factory.configButton(btn, new Size(260, 60), new Point(120 + 800 / 2 * (i % 2), 20 + i / 2 * 80), printArr[i], i+1);
                btn.FlatStyle = FlatStyle.Popup;
                btn.Click += new System.EventHandler(this.btn_Click);

                //this.Controls.Add(btn);
                this.panel1.Controls.Add(btn);
            }
            
        }
        public delegate void Block();
        public Block block;

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string printname = btn.Text.Trim();
            if (block != null)
            {
                ini.IniWriteValue(ini.Section_Print, PrintStyle, btn.Text.Trim());
                if (string.IsNullOrEmpty(ini.IniReadValue(ini.Section_Print, "LOT")))
                {
                    //ShowMeg("绑定成功,请继续绑定LOT表打印机");
                    ShowMeg(q(Msg_Type.msgbindsuccess) + "," + q(Msg_Type.msgpleasebindLot));
                }
                else if (string.IsNullOrEmpty(ini.IniReadValue(ini.Section_Print, "A5")))
                {
                    //ShowMeg("绑定成功,请继续绑定A5纸打印机");
                    ShowMeg(q(Msg_Type.msgbindsuccess) + "," + q(Msg_Type.msgpleasebindA5));
                }
                else
                {
                    //ShowMeg("绑定成功");
                    ShowMeg(q(Msg_Type.msgbindsuccess));
                }

               
                block();
                this.Close();
                
            }
        }

    }
}
