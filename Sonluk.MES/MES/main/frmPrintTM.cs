using Sonluk.MES.MES.Base;
using Sonluk.UI.Model.MES.TM_TMINFOService;
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
    public partial class frmPrintTM : basefrm
    {
        string _tm;

        public string Tm
        {
            get { return _tm; }
            set { _tm = value; }
        }
        public frmPrintTM()
        {
            InitializeComponent();
            tmtextBox.ReadOnly = false;


            dybutton.Visible = false;

        }
        public frmPrintTM(string tm,Rigth_Type rtype,Print_Type ptype)
        {
            InitializeComponent();
            tmtextBox.Text = tm;
            Tm = tm;
            RigthType = rtype;
            PrintType = ptype;
        }

        private void dybutton_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(fsnumericUpDown.Value) > 0)
            {
                MES_TM_TMINFO TMINFOmodel = new MES_TM_TMINFO();
                TMINFOmodel.TM = tmtextBox.Text.Trim().ToUpper();
                SELECT_MES_TM_TMINFO_BYTM tminfiRes = ServicModel.TM_TMINFO.SELECT(TMINFOmodel, getToken());
                if (!tminfiRes.MES_RETURN.TYPE.Equals("S"))
                {
                    ShowMeg(tminfiRes.MES_RETURN.MESSAGE);
                    return;
                }
                if (tminfiRes.MES_TM_TMINFO_LIST != null &&tminfiRes.MES_TM_TMINFO_LIST.Length == 1)
                {
                    PrintInfoByTM(tmtextBox.Text.Trim().ToUpper(), tminfiRes.MES_TM_TMINFO_LIST[0].GC, Convert.ToInt32(fsnumericUpDown.Value), RigthType, PrintType);
                }
                else
                {
                    //ShowMeg("读取扫描条码信息失败");
                    ShowMeg(q(Msg_Type.msgloadtmfail));
                    return;
                }                
                this.Close();
            }
            else
            {
                //ShowMeg("打印份数必须大于0");
                ShowMeg(q(Msg_Type.msgprintnoempty));
            }
        }

        private void tmtextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (tmtextBox.ReadOnly == false)
            {
                if (e.KeyCode == Keys.Enter)
                {
                     if (Convert.ToInt32(fsnumericUpDown.Value) > 0)
                    {
                        string tm = tmtextBox.Text.Trim().ToUpper();
                        if (tm.Length == 12 && tm.StartsWith("P"))
                        {
                            MES_TM_TMINFO TMINFOmodel = new MES_TM_TMINFO();
                            TMINFOmodel.TM = tm;
                            SELECT_MES_TM_TMINFO_BYTM tminfiRes = ServicModel.TM_TMINFO.SELECT(TMINFOmodel, getToken());
                            if (tminfiRes.MES_RETURN.TYPE.Equals("S"))
                            {
                                if (tminfiRes.MES_TM_TMINFO_LIST.Length == 1)
                                {
                                    MES_TM_TMINFO_LIST tmINFO = tminfiRes.MES_TM_TMINFO_LIST[0];
                                    Print_Type ptype = (Print_Type)tmINFO.TMSX;
                                    PrintType = ptype;
                                    bool isNormal = true;
                                    switch (ptype)
                                    {
                                        case Print_Type.none:
                                            isNormal = false;
                                            break;
                                        case Print_Type.rk:
                                            RigthType = Rigth_Type.gangketl_cc;
                                            break;
                                        case Print_Type.lot:
                                            RigthType = Rigth_Type.gangketl_cc;
                                            break;
                                        case Print_Type.zjlot:
                                            RigthType = Rigth_Type.zhengjicc;
                                            break;
                                        case Print_Type.fujilot:
                                            RigthType = Rigth_Type.fujitl;
                                            break;
                                        case Print_Type.zxlot:
                                            RigthType = Rigth_Type.zhuxiancc;
                                            break;
                                        case Print_Type.bblot:
                                            RigthType = Rigth_Type.baobiaocc;
                                            break;
                                        case Print_Type.zfsd:
                                            RigthType = Rigth_Type.zhuxiancc;
                                            break;
                                        case Print_Type.wlrk:
                                            RigthType = Rigth_Type.wlrkdy;
                                            break;
                                        case Print_Type.wlrkLot:
                                            RigthType = Rigth_Type.wlrkdy;
                                            break;
                                        case Print_Type.zswllot:
                                            RigthType = Rigth_Type.zswllotdy;
                                            break;
                                        case Print_Type.zswlbsk:
                                            RigthType = Rigth_Type.none;
                                            break;
                                        default:
                                            isNormal = false;
                                            break;
                                    }
                                    if (isNormal == false)
                                    {
                                         //ShowMeg("条码属性读取异常,请联系管理员");
                                        ShowMeg(q(Msg_Type.msgtmsxecpect));
                                         return;
                                    }
                                    tmtextBox.Text = tmINFO.TM;
                                    PrintInfoByTM(tmINFO.TM, tmINFO.GC, Convert.ToInt32(fsnumericUpDown.Value), RigthType, ptype);
                                    tmtextBox.Clear();
                                }
                                else
                                {
                                    //ShowMeg("读取扫描条码信息失败");
                                    ShowMeg(q(Msg_Type.msgloadtmfail));
                                }

                            }
                            else
                            {
                                ShowMeg(tminfiRes.MES_RETURN.MESSAGE);
                            }
                        }
                        else
                        {
                            //ShowMeg("你扫描的是无效的条码");
                            ShowMeg(q(Msg_Type.msgscantminvalid));
                        }
                    }
                    else
                    {
                        //ShowMeg("打印份数必须大于0");
                        ShowMeg(q(Msg_Type.msgprintnoempty));
                    }
                    
                }
            }
           
        }
    }
}
