using Sonluk.MES.MES.publics;
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
    public partial class frmMessageBox : Form
    {
        LanguageHelper languhelper = new LanguageHelper();
        int _count;

        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }
        int _jscount;

        public int Jscount
        {
            get { return _jscount; }
            set { _jscount = value; }
        }
        Timer timer1 = new Timer();
        public frmMessageBox()
        {
            InitializeComponent();
            Timer timer = new Timer();
        }
        //public frmMessageBox(string title)
        public frmMessageBox(string title,int intervalTime,int longtime,int fontSize)
        {
            InitializeComponent();
            Count = longtime;
            label1.Font = new System.Drawing.Font(languhelper.q(Base.basefrm.Msg_Type.fonttype), fontSize);//"宋体"
            Jscount = 1;
            button1.Text = languhelper.q(Base.basefrm.Msg_Type.fieldconfirm) + "（" + longtime.ToString() + "）";//"确定（" + longtime.ToString() + "）"
            label1.Text = title;
            timer1.Interval = intervalTime;//单位毫秒
            timer1.Tick += new System.EventHandler(this.timer1_Tick);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            button1.Text = languhelper.q(Base.basefrm.Msg_Type.fieldconfirm) + "（" + (Count - Jscount).ToString() + "）";// "确定（" + (Count - Jscount).ToString() + "）";

            if (Jscount == Count)
            {
                timer1.Dispose();
                this.Close();
            }


            Jscount++;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Dispose();
            this.Close();
        }
    }
}
