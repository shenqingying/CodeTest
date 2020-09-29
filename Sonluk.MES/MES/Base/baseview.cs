using Sonluk.MES.MES.main;
using Sonluk.UI.Model.MES.MES_LoginService;
using Sonluk.UI.Model.MES.SY_TYPEMXService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sonluk.MES.MES.Base
{
    public partial class baseview : Sonluk.MES.MES.Base.basefrm
    {
        public baseview()
        {
            InitializeComponent();
        }

        public void zybutton_Click(object sender, EventArgs e)
        {
            string name = getUserInfo("username");
            string pwd = getUserInfo("password");
            //MES_LoginINFO loginfo = ServicModel.MES_Login.Login(getUserInfo("username"), getUserInfo("password"), "", "", 0, 1, 0);
            MES_SY_TYPEMX TYPEMX = new MES_SY_TYPEMX();
            TYPEMX.TYPEID = 26;
            TYPEMX.MXNAME = ini.IniReadValue(ini.Section_UserInfo, "langu");
            MES_SY_TYPEMXLIST[] languArr = ServicModel.SY_TYPEMX.SELECT_NOPTOKEN(TYPEMX);
            int languID = 0;
            if (languArr.Length == 1)
            {
                languID = languArr[0].ID;
            }
            MES_LoginINFO loginfo = ServicModel.MES_Login.Login_language(name, pwd, "", "", 0, 1, 0, languID);
            CRM_JURISDICTION_GROUP[] list = loginfo.JURISDICTION_GROUP;
            
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
            Sonluk.UI.Model.MES.MES_LoginService.MES_RETURN msg = loginfo.MES_RETURN;
            if (msg.TYPE.Equals("E"))
            {
                //MessageBox.Show(msg.MESSAGE, "消息框");
                ShowMeg(msg.MESSAGE);

            }
            else
            {
                frmAction form = new frmAction(list);
                push(form,this);
            }
        }
    }
}
