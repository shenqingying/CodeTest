using Sonluk.MES.MES.Base;
using Sonluk.UI.Model.MES.PD_TLGLService;
using Sonluk.UI.Model.MES.TM_CZRService;
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
    public partial class frmUpdateTM : basefrm
    {
        MES_PD_TL_LIST _MES_PD_TL_LIST;

        public MES_PD_TL_LIST MES_PD_TL_LIST
        {
            get { return _MES_PD_TL_LIST; }
            set { _MES_PD_TL_LIST = value; }
        }
        MES_TM_TMINFO_LIST _resList;

        public MES_TM_TMINFO_LIST ResList
        {
            get { return _resList; }
            set { _resList = value; }
        }
        string _gh;

        public string Gh
        {
            get { return _gh; }
            set { _gh = value; }
        }
        public frmUpdateTM()
        {
            InitializeComponent();
        }
        public frmUpdateTM(MES_PD_TL_LIST list)
        {
            InitializeComponent();
            MES_PD_TL_LIST = list;
            ytmtextBox.Text = list.TM;
            ytmwllbtextBox.Text = list.WLLBNAME;
            tlsstextBox.Text = list.TLRQ;
        }
        public delegate void Block(string rwbh);
        public Block block;
        private void qrbutton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mbmtextBox.Text.Trim()))
            {
                ShowMeg(q(Msg_Type.msgnotmreplacesure));//"没有条码无法进行替换确认"
                smtextBox.Select();
                return;
            }
            if (string.IsNullOrEmpty(czrtextBox.Text.Trim()))
            {
                ShowMeg(q(Msg_Type.msgscangh));//"请扫描工号"
                smtextBox.Select();
                return;
            }
            if (MessageBox.Show(q(Msg_Type.msgwhetherreplacetmtlxx),q(Msg_Type.msgtitle), MessageBoxButtons.OKCancel) == DialogResult.OK)//"是否替换条码投料信息", "消息框"
            {
                MES_PD_TL_UPDATE_TLTMTH_IN model = new MES_PD_TL_UPDATE_TLTMTH_IN();
                model.GH = Gh;
                model.GHNAME = czrtextBox.Text.Trim().ToUpper();
                model.STAFFID = Convert.ToInt32(getUserInfo("staffid")); ;
                model.TM = ResList.TM;
                model.TMTLID = MES_PD_TL_LIST.ID;
                MES_RETURN_UI res = ServicModel.PD_TLGL.UPDATE_TLTMTH(model, getToken());
                if (res.TYPE.Equals("S"))
                {
                    if (block != null)
                    {
                        block(MES_PD_TL_LIST.RWBH);
                        this.Close();
                    }

                }
                else
                {
                    ShowMeg(res.MESSAGE);
                }
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
                            //string a = getToken();
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
                            model.GC = MES_PD_TL_LIST.GC;
                            model.TM = smtextBox.Text.Trim();
                            model.RWBH = MES_PD_TL_LIST.RWBH;
                            SELECT_MES_TM_TMINFO_BYTM res = ReadphTM(model, 0);
                            if (res.MES_RETURN.TYPE.Equals("S"))
                            {
                                ResList = res.MES_TM_TMINFO_LIST[0];
                                mbmtextBox.Text = res.MES_TM_TMINFO_LIST[0].TM;
                                mbmwllbtextBox.Text = res.MES_TM_TMINFO_LIST[0].WLLBNAME;
                                
                            }
                            else
                            {
                                ShowMeg(res.MES_RETURN.MESSAGE);
                               
                            }
                           
                            break;
                        }
                       
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
