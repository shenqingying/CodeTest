using Sonluk.MES.MES.Base;
using Sonluk.UI.Model.MES.PD_TLGLService;
using Sonluk.UI.Model.MES.TM_TMINFOService;
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
    public partial class frmDeleteTM_TMINFO : basefrm
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

        SELECT_MES_TM_TMINFO_BYTM _SELECT_MES_TM_TMINFO_BYTM;

        public SELECT_MES_TM_TMINFO_BYTM SELECT_MES_TM_TMINFO_BYTM
        {
            get { return _SELECT_MES_TM_TMINFO_BYTM; }
            set { _SELECT_MES_TM_TMINFO_BYTM = value; }
        }
        MES_TM_TMINFO_LIST _MES_TM_TMINFO_LIST;

        public MES_TM_TMINFO_LIST MES_TM_TMINFO_LIST
        {
            get { return _MES_TM_TMINFO_LIST; }
            set { _MES_TM_TMINFO_LIST = value; }
        }

        public delegate void Block(string rwbh);
        public Block block;
        public frmDeleteTM_TMINFO()
        {
            InitializeComponent();
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
            if (string.IsNullOrEmpty(ytmtextBox.Text.Trim()))
            {
                ShowMeg(q(Msg_Type.msgscantm));//"请扫描条码"
                smtextBox.Select();
                return;
            }
            MES_TM_TMINFO_DELETE_IN model = new MES_TM_TMINFO_DELETE_IN();
            model.TM = ytmtextBox.Text.Trim();
            model.YGH = Gh;
            model.YGNAME = czrtextBox.Text.Trim();
            model.STAFFID = Convert.ToInt32(getUserInfo("staffid")); ;
            MES_RETURN_UI res = ServicModel.TM_TMINFO.DELETE_LOG(model, getToken());
            if (res.TYPE.Equals("S"))
            {
                ShowMeg(q(Msg_Type.msgdelsuccess), 1500);//"删除成功"
                ytmtextBox.Clear();
                ytmwllbtextBox.Clear();
                tlsstextBox.Clear();
                czrtextBox.Clear();
                Gh = "";

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

                           
                        }
                        break;
                    case TM_Type.gd:
                        //MessageBox.Show("你扫描的是无效的条码！！", "消息框");
                        ShowMeg(q(Msg_Type.msgscantminvalid));
                        break;
                    case TM_Type.ph:
                        {
                            MES_TM_TMINFO model = new MES_TM_TMINFO();
                            model.TM = smtextBox.Text.Trim().ToUpper();
                            model.STAFFID = Convert.ToInt32(getUserInfo("staffid"));
                            SELECT_MES_TM_TMINFO_BYTM res = ServicModel.TM_TMINFO.SELECT_BY_KCDDLimit(model, getToken());
                            if (res.MES_RETURN.TYPE.Equals("S"))
                            {
                                if (res.MES_TM_TMINFO_LIST.Length == 1)
                                {
                                    MES_TM_TMINFO_LIST = res.MES_TM_TMINFO_LIST[0];
                                    ytmtextBox.Text = MES_TM_TMINFO_LIST.TM;
                                    ytmwllbtextBox.Text = MES_TM_TMINFO_LIST.WLLBNAME;
                                    tlsstextBox.Text = MES_TM_TMINFO_LIST.SCDATE;
                                }
                                else if (res.MES_TM_TMINFO_LIST.Length == 0)
                                {
                                    ShowMeg(q(Msg_Type.msgtmnoexistorunrole));//"条码信息不存在或账号没有权限查询"
                                }
                                else
                                {
                                    ShowMeg(q(Msg_Type.msgtmexcept));//"获得的条码数据异常，请联系管理员"
                                }
                            }
                            else
                            {
                                ShowMeg(res.MES_RETURN.MESSAGE);
                            }
                        }
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
                smtextBox.Clear();
                smtextBox.Select();
            }
           
        }
    }
}
