using Sonluk.MES.MES.Base;
using Sonluk.UI.Model.MES.PD_TLGLService;
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
    public partial class frmDeleteTM : basefrm
    {
        MES_PD_TL_LIST _MES_PD_TL_LIST;

        public MES_PD_TL_LIST MES_PD_TL_LIST
        {
            get { return _MES_PD_TL_LIST; }
            set { _MES_PD_TL_LIST = value; }
        }
        string _gh;

        public string Gh
        {
            get { return _gh; }
            set { _gh = value; }
        }
        public delegate void Block(string rwbh);
        public Block block;
        public frmDeleteTM()
        {
            InitializeComponent();
        }
        public frmDeleteTM(MES_PD_TL_LIST list)
        {
            InitializeComponent();
            MES_PD_TL_LIST = list;
            ytmtextBox.Text = list.TM;
            ytmwllbtextBox.Text = list.WLLBNAME;
            tlsstextBox.Text = list.TLRQ;
        }

        private void czrtextBox_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void qrbutton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(czrtextBox.Text.Trim()))
            {
                ShowMeg(q(Msg_Type.msgscangh));//"请扫描工号"
                smtextBox.Select();
                return;
            }
            MES_PD_TL_DELETE_IN model = new MES_PD_TL_DELETE_IN();
            model.GH = Gh;
            model.GHNAME = czrtextBox.Text.Trim().ToUpper();
            model.STAFFID = Convert.ToInt32(getUserInfo("staffid"));
            model.TMTLID = MES_PD_TL_LIST.ID;
            MES_RETURN_UI res = ServicModel.PD_TLGL.DELETE(model, getToken());
            if (res.TYPE.Equals("S"))
            {
                ShowMeg(q(Msg_Type.msgdelsuccess), 1500);//"删除成功"
                if (block != null)
                {
                    block(MES_PD_TL_LIST.RWBH);                    
                }
                this.Close();
            }
            else
            {
                ShowMeg(res.MESSAGE);
            }

        }

        private void smtextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TM_Type type = TMtype(smtextBox.Text.Trim().ToUpper());
                switch (type)
                {
                    case TM_Type.none:
                        //MessageBox.Show("你扫描的是无效的条码！！", "消息框");
                        ShowMeg(q(Msg_Type.msgscantminvalid));
                        break;
                    case TM_Type.staffno:
                        {
                            MES_RETURN_UI res = ServicModel.PUBLIC_FUNC.GET_YGNAME(smtextBox.Text.Trim().ToUpper(), getToken());
                            if (res.TYPE.Equals("S"))
                            {
                                czrtextBox.Text = res.MESSAGE;
                                Gh = smtextBox.Text.Trim().ToUpper();
                            }
                            else
                            {
                                ShowMeg(res.MESSAGE);
                            }

                            smtextBox.Clear();
                            smtextBox.Select();
                        }
                        break;
                    case TM_Type.gd:
                        //MessageBox.Show("你扫描的是无效的条码！！", "消息框");
                        ShowMeg(q(Msg_Type.msgscantminvalid));
                        break;
                    case TM_Type.ph:
                        //MessageBox.Show("你扫描的是无效的条码！！", "消息框");
                        ShowMeg(q(Msg_Type.msgscantminvalid));
                        break;
                    case TM_Type.rwd:
                        //MessageBox.Show("你扫描的是无效的条码！！", "消息框");
                        ShowMeg(q(Msg_Type.msgscantminvalid));
                        break;
                    default:
                        //MessageBox.Show("你扫描的是无效的条码！！", "消息框");
                        ShowMeg(q(Msg_Type.msgscantminvalid));
                        break;
                }
            }
        }
    }
}
