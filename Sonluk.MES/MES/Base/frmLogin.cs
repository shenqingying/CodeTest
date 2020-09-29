using Sonluk.MES.MES.Base;
using Sonluk.MES.MES.main;
using Sonluk.MES.MES.model;
using Sonluk.MES.MES.publics;
using Sonluk.UI.Model.MES.MES_LoginService;
using Sonluk.UI.Model.MES.SY_GCService;
using Sonluk.UI.Model.MES.TM_TMINFOService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NAppUpdate.Framework;
using NAppUpdate.Framework.Sources;
using Sonluk.UI.Model.MES.PD_SCRWService;
using Sonluk.UI.Model.MES.SY_TYPEMXService;
namespace Sonluk.MES.MES
{
    public partial class frmLogin : basefrm
    {


        private UpdateManager updManager; //声明updateManager
        public bool firstload = true;
        public frmLogin()
        {
            InitializeComponent();
            userTextBox.Text = getUserInfo("username");
            this.StartPosition = FormStartPosition.CenterScreen;

            if (getUserInfo("username").Equals(""))
            {
                userTextBox.Select();
            }
            else
            {
                pwdTextBox.Select();
            }

            //切换服务器地址
            if (!string.IsNullOrEmpty(ini.IniReadValue(ini.Section_Remote, "address")))
            {
                OperationConfig o = new OperationConfig();
                o.modifyItem("RemoteAddress", ini.IniReadValue(ini.Section_Remote, "address") + o.valueItem("RemoteAddressName"));
            }
            List<MES_SY_TYPEMXLIST> languList = new List<MES_SY_TYPEMXLIST>();
            MES_SY_TYPEMXLIST langu1 = new MES_SY_TYPEMXLIST
            {
                MXNAME = "中文/zh",
                MAXVALUE = "zh-CN"
            };
            languList.Add(langu1);
            //MES_SY_TYPEMXLIST langu2 = new MES_SY_TYPEMXLIST();
            //langu2.MXNAME = "Tiếng việt/vi";
            //langu2.MAXVALUE = "vi-VN";
            //languList.Add(langu2);
            langucomboBox.DisplayMember = "MXNAME";
            langucomboBox.ValueMember = "MAXVALUE";
            langucomboBox.DataSource = languList;
           
            //q(Msg_Type.unamenotempty);
            //string c = "13.325";
            //string c1 = "13.3254";
            //string c2 = "13";
            //bool d = judge.IsNo_3(c);
            //bool d1 = judge.IsNo_3(c1);
            //bool d2 = judge.IsNo_3(c2);
        }

        private void loginbutton_Click(object sender, EventArgs e)
        {
            login();
        }

        private void Resetbutton_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void canclebutton_Click(object sender, EventArgs e)
        {
            printTest(Print_Type.zswlbsk);
        }

        private void GCcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void Clear()
        {
            pwdTextBox.Clear();
            pwdTextBox.Select();
        }
        private MsgReturn VerifyLoginInfo()
        {
            MsgReturn res = new MsgReturn();
            res.Pass = false;

            if (string.IsNullOrEmpty(userTextBox.Text))
            {
                //res.Msg = "用户名不能为空！！！";
                res.Msg = q(Msg_Type.unamenotempty);
                return res;
            }
            if (string.IsNullOrEmpty(pwdTextBox.Text))
            {
                //res.Msg = "密码不能为空！！！";
                res.Msg = q(Msg_Type.pwdnotempty);
                return res;
            }
            res.Pass = true;
            return res;
        }
        private void login()
        {
            MsgReturn res = VerifyLoginInfo();
            if (res.Pass == false)
            {
                //MessageBox.Show(res.Msg, "消息框");
                ShowMeg(res.Msg);
                return;
            }
            #region 登录请求相关信息
            MES_SY_TYPEMX TYPEMX = new MES_SY_TYPEMX();
            TYPEMX.TYPEID = 26;
            TYPEMX.MXNAME = Convert.ToString(langucomboBox.SelectedValue);
            MES_SY_TYPEMXLIST[] languArr = ServicModel.SY_TYPEMX.SELECT_NOPTOKEN(TYPEMX);
            int languID = 0;
            if (languArr.Length == 1)
            {
                languID = languArr[0].ID;
            }
            MES_LoginINFO loginfo = ServicModel.MES_Login.Login_language(userTextBox.Text.Trim(), pwdTextBox.Text.Trim(), "", "", 0, 1, 0, languID);
            
            



            CRM_JURISDICTION_GROUP[] list = loginfo.JURISDICTION_GROUP;
            if (list != null)
            {
                if (list.Length > 0)
                {
                    List<CRM_JURISDICTION_GROUP> nodes = new List<CRM_JURISDICTION_GROUP>();
                    for (int i = 0; i < list.Length; i++)
                    {
                        CRM_HG_RIGHTGROUP node = list[i].CRM_HG_RIGHTGROUP;
                        if (node.RGROUPID == 11)
                        {
                            nodes.Add(list[i]);
                            list = nodes.ToArray();
                            break;
                        }

                    }
                }
            }
           




            Sonluk.UI.Model.MES.MES_LoginService.MES_RETURN msg = loginfo.MES_RETURN;
            if (msg.TYPE.Equals("E"))
            {
                //MessageBox.Show(msg.MESSAGE, "消息框");
                ShowMeg(msg.MESSAGE);
                Clear();
            }
            else
            {
                if (list == null || list.Length == 0)
                {
                    ShowMeg( userTextBox.Text + q(Msg_Type.roleisnull));
                    return;
                }
                //if (list.Length == 0)
                //{
                //    ShowMeg("帐号" + userTextBox.Text + "没有对应的权限,请维护");
                //    return;
                //}

                TokenInfo tokenInfo = loginfo.TokenInfo;
                Common.token = tokenInfo.access_token;
                ini.IniWriteValue(ini.Section_UserInfo, "username", userTextBox.Text.Trim());
                ini.IniWriteValue(ini.Section_UserInfo, "password", pwdTextBox.Text.Trim());
                ini.IniWriteValue(ini.Section_UserInfo, "staffid", tokenInfo.STAFFID.ToString());
                ini.IniWriteValue(ini.Section_UserInfo, "langu", Convert.ToString(langucomboBox.SelectedValue));
                frmAction form = new frmAction(list);
                push(form, this);
            }
            #endregion
        }





        private void pwdTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            pwdTextBox.PasswordChar = '*';
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            pwdTextBox.PasswordChar = new char();
        }

        private void frmLogin_Activated(object sender, EventArgs e)
        {

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string inilangu = ini.IniReadValue(ini.Section_UserInfo, "langu");
            if (!string.IsNullOrEmpty(inilangu)) langucomboBox.SelectedValue = inilangu;
            LanguageHelper.SetLang(inilangu, this, typeof(frmLogin));
        }

        private void langucomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (firstload)
            {                
                firstload = false;
            }
            else
            {
                ComboBox combobox = (ComboBox)sender;
                if (combobox.SelectedValue.ToString() == "vi-VN")
                {
                    LanguageHelper.SetLang("vi-VN", this, typeof(frmLogin));
                }
                else if (combobox.SelectedValue.ToString() == "zh-CN")
                {
                    LanguageHelper.SetLang("zh-CN", this, typeof(frmLogin));
                }

                ini.IniWriteValue(ini.Section_UserInfo, "langu", Convert.ToString(langucomboBox.SelectedValue));
            }
           
        }

        private void frmLogin_Shown(object sender, EventArgs e)
        {
            string inilangu = ini.IniReadValue(ini.Section_UserInfo, "langu");
            if (!string.IsNullOrEmpty(inilangu)) langucomboBox.SelectedValue = inilangu;
            LanguageHelper.SetLang(inilangu, this, typeof(frmLogin));
        }

        private void pwdTextBox_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login();
            }
        }

    }
}
