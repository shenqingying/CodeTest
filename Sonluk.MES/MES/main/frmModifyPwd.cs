using Sonluk.MES.MES.Base;
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
    public partial class frmModifyPwd : basefrm
    {
        public frmModifyPwd()
        {
            InitializeComponent();
            oldpwdtextBox.Select();
            usernametextBox1.Text = getUserInfo("username");

        }
        public delegate void Block();
        public Block block;
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(usernametextBox1.Text.Trim()))
            {
                ShowMeg(q(Msg_Type.msgaccountnoempty));//"帐号不能为空"
                return;
            }
            if (string.IsNullOrEmpty(oldpwdtextBox.Text.Trim()))
            {
                ShowMeg(q(Msg_Type.msgoldpwdnoempty));//"旧密码不能为空"
                return;
            }
            if (string.IsNullOrEmpty(newpwdtextBox.Text.Trim()))
            {
                ShowMeg(q(Msg_Type.msgnewpwdnoempty));//"新密码不能为空"
                return;
            }
            if (string.IsNullOrEmpty(comfirmpwdtextBox.Text.Trim()))
            {
                ShowMeg(q(Msg_Type.msgcqpwdnoempty));//"确认密码不能为空"
                return;
            }
            if (oldpwdtextBox.Text.Trim().Equals(newpwdtextBox.Text.Trim()))
            {
                ShowMeg(q(Msg_Type.msgnpwdnqopwd));//"新密码不能与旧密码相同"
                return;
            }
            if (!newpwdtextBox.Text.Trim().Equals(comfirmpwdtextBox.Text.Trim()))
            {
                ShowMeg(q(Msg_Type.msgnpwdnqcpwd));//"新密码与确认密码不相同"
                return;
            }
            //int STAFFID, string OLDPW, string NEWPW, string ptoken)
          
            MES_RETURN_UI res = ServicModel.SY_STAFF.UPDATE_STAFFPW(Convert.ToInt32(getUserInfo("staffid")), oldpwdtextBox.Text.Trim(), newpwdtextBox.Text.Trim(), getToken());
            if (res.TYPE.Equals("S"))
            {
                if (MessageBox.Show(q(Msg_Type.msgbindthenrestart), q(Msg_Type.msgtitle), MessageBoxButtons.OK) == DialogResult.OK)//"绑定成功,点击重新启动程序" 
                {
                    Application.Exit();
                    System.Diagnostics.Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
                }
                //ShowMeg("修改成功",2000);
                //frmLogin form = new frmLogin();
                //push(form);
                //if (block != null)
                //{
                //    block();
                //    this.Close();
                //}
                
            }
            else
            {
                ShowMeg(res.MESSAGE);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
