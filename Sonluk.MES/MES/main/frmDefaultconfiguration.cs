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
    public partial class frmDefaultconfiguration : baseview

    {
        public frmDefaultconfiguration()
        {
            InitializeComponent();
            string rwdstatus = ini.IniReadValue(ini.Section_Configuration, "showRWD");
            if (rwdstatus.Equals("true"))
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = true; 
            }
            string printToHome = ini.IniReadValue(ini.Section_Configuration, "printTohome");
            if (printToHome.Equals("true"))
            {
                radioButton3.Checked = true;
            }
            else
            {
                radioButton4.Checked = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (radioButton1.Checked)
            {
                ini.IniWriteValue(ini.Section_Configuration, "showRWD", "true");
            }
            else
            {
                ini.IniWriteValue(ini.Section_Configuration, "showRWD", "false");
            }

            if (radioButton3.Checked)
            {
                ini.IniWriteValue(ini.Section_Configuration, "printTohome", "true");
            }
            else
            {
                ini.IniWriteValue(ini.Section_Configuration, "printTohome", "false");
            }

            ShowMeg(q(Msg_Type.fieldsavesueecss), 1500);//"保存成功"
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDefaultconfiguration_Load(object sender, EventArgs e)
        {

        }
    }
}
