using Sonluk.MES.MES.Base;
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
    public partial class frmConfigView : baseview
    {
        public frmConfigView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmModifyPwd form = new frmModifyPwd();
            show(form);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //frmBindPrint form = new frmBindPrint(Print_Type.lot);
            frmBindPrint_1 form = new frmBindPrint_1();
            show(form);
        }

        private void frmConfigView_Load(object sender, EventArgs e)
        {
            //int a = 0;
        }

        private void frmConfigView_Shown(object sender, EventArgs e)
        {
            //int a = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmBind_Machine form = new frmBind_Machine();
            show(form);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmDefaultconfiguration form = new frmDefaultconfiguration();
            show(form);
        }
    }
}
