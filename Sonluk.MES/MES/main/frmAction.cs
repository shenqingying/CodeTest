using Sonluk.MES.MES.Base;
using Sonluk.MES.MES.publics;
using Sonluk.UI.Model.MES.MES_LoginService;
using Sonluk.UI.Model.MES.PD_SCRWService;
using Sonluk.UI.Model.MES.SY_GCService;
using Sonluk.UI.Model.MES.SY_GZZX_SBHService;
using Sonluk.UI.Model.MES.SY_GZZXService;
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
    public partial class frmAction : basefrm
    {
        string _btntext;

        public string Btntext
        {
            get { return _btntext; }
            set { _btntext = value; }
        }
        public frmAction()
        {
            InitializeComponent();
          
        }
        public frmAction(CRM_JURISDICTION_GROUP[] nodes)
        {
            InitializeComponent();
            JList = nodes;
            int btnWidth = rect.Width > 880 ? 220:180;
            int magr = (rect.Width - btnWidth * 4) / 5;
            //根据权限动态生成按钮并添加事件
            for (int i = 0; i < JList[0].CRM_HG_RIGHTList.Length; i++)
            {
                Button btn = new Button();
                //magr + rect.Width / 4 * (i % 4)
                factory.configButton(btn, new Size(btnWidth, 90), new Point(magr + (magr + btnWidth)*(i%4), i / 4 * 100), JList[0].CRM_HG_RIGHTList[i].RIGHTNAME, JList[0].CRM_HG_RIGHTList[i].RIGHTID);
                btn.FlatStyle = FlatStyle.Popup;
                btn.Click += new System.EventHandler(this.btn_Click);
                //this.Controls.Add(btn);
                panel1.Controls.Add(btn);
            }
            //
            Label xxLabel = new Label();
            string ip =  new OperationConfig().valueItem("RemoteAddress").Split('/')[2];
            factory.configLabel(xxLabel, new Size(rect.Width, 21), new Point(15, 15), new Font(q(Msg_Type.fonttype), 12), string.Format(q(Msg_Type.frmActionTitle), getUserInfo("username"), ip));//"当前帐号:" + getUserInfo("username") + "，服务器地址:" + ip)
            this.Controls.Add(xxLabel);
            //Label ipLabel = new Label();
            //OperationConfig oCinfig = new OperationConfig();
            //factory.configLabel(ipLabel, new Size(300, 21), new Point(15, 35), new Font(q(Msg_Type.fonttype), 12), "当前服务器:" + oCinfig.valueItem("RemoteAddress"));
            //ipLabel.BringToFront();
            //this.Controls.Add(ipLabel);
            

        }

        /// <summary>
        /// 动态按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int tag = Convert.ToInt32(btn.Tag);
            Rigth_Type type =(Rigth_Type)tag;
            if (type == Rigth_Type.wlrkdy)
            {
                frmWLKC_N form = new frmWLKC_N(type);
                push(form,this);                            
            }
            else if (type == Rigth_Type.zhujizhengjitl)
            {
                MES_SY_GC gcmodel = new MES_SY_GC();
                gcmodel.STAFFID = Convert.ToInt32(getUserInfo("staffid"));
                MES_SY_GC[] gcList = ServicModel.SY_GC.SELECT_BY_ROLE(gcmodel, getToken());
                if (gcList.Length > 1)
                {
                    showGZZX(btn.Text, type);
                }
                else if (gcList.Length == 1)
                {
                    MES_SY_GZZX_SBH model = new MES_SY_GZZX_SBH();
                    model.GC = gcList[0].GC;
                    model.STAFFID = Convert.ToInt16(getUserInfo("staffid"));
                    model.WLLBNAME = "素电";
                    MES_SY_GZZX_SBH[] list = ServicModel.SY_GZZX_SBH.SELECT_BY_STAFFID(model, getToken());
                    frmFindSBH form = new frmFindSBH(list, q(Msg_Type.choiceCX), type,true);
                    push(form,this);
                }
                else
                {
                    ShowMeg(q(Msg_Type.accountnotgcrole));
                }
            }
            else if (type == Rigth_Type.tmbd)
            {
                frmTM_bd form = new frmTM_bd();
                push(form,this);
            }
            else if (type == Rigth_Type.tmbdLimit)
            {
                frmTM_bdLimit form = new frmTM_bdLimit();
                push(form,this);
            }
            else if (type == Rigth_Type.sgsm)
            {
                frmSGSM form = new frmSGSM();
                push(form,this);
            }
            else if (type == Rigth_Type.tbprint)
            {                   
                frmPrintTM form = new frmPrintTM();
                show(form);
            }
            else if (type == Rigth_Type.tmInfoUpdate)
            {
                frmTM_INFO_UPDATE form = new frmTM_INFO_UPDATE();
                show(form);
            }
            else if (type == Rigth_Type.configSetting)
            {
                frmConfigView form = new frmConfigView();
                push(form,this);
               
            }
            else if (type == Rigth_Type.rwdsm)
            {
                frmRWDSCAN form = new frmRWDSCAN();
                form.block = RWDSCAN;
                show(form);
            }
            else if (type  == Rigth_Type.sudianfangong)
            {
                int[] arr = {7};
                frmSGSM_Puls form = new frmSGSM_Puls(arr);
                push(form,this);
            }
            else if (type == Rigth_Type.zhengjicc)
            {
                showGZZX(btn.Text, type);
            }
            else if (type == Rigth_Type.fujicc)
            {
                 showGZZX(btn.Text, type);
            }
            else if (type == Rigth_Type.fujitl)
            {
                showGZZX(btn.Text, type);
            }
            else if (type == Rigth_Type.zswllotdy)
            {
                frmZSLotprint form = new frmZSLotprint();
                //show(form);
                int ScreenWidth = Screen.PrimaryScreen.WorkingArea.Width;
                int ScreenHeight = Screen.PrimaryScreen.WorkingArea.Height;
                //计算窗体显示的坐标值，可以根据需要微调几个像素

                form.StartPosition = FormStartPosition.CenterScreen;

                //this.Visible = false;

                form.Show();
            }
            else
            {
                MES_SY_GC gcmodel = new MES_SY_GC();
                gcmodel.STAFFID = Convert.ToInt32(getUserInfo("staffid"));
                MES_SY_GC[] gcList = ServicModel.SY_GC.SELECT_BY_ROLE(gcmodel, getToken());
                if (gcList.Length == 1)
                {
                     MES_SY_GZZX gzzxmodel = new MES_SY_GZZX();
                     gzzxmodel.GC = gcList[0].GC;
                     gzzxmodel.STAFFID = Convert.ToInt32(getUserInfo("staffid"));
                    //gzzxmodel.WLLB = Gzzxlb;
                     gzzxmodel.WLLBNAME = GetwllbRightTypeString(type);
                     MES_SY_GZZX[] list = ServicModel.SY_GZZX.SELECT_BY_ROLE(gzzxmodel, getToken());
                     if (list.Length == 1)
                     {
                         MES_SY_GZZX_SBH model = new MES_SY_GZZX_SBH();

                         model.GZZXBH = list[0].GZZXBH;
                        
                         model.GC = gzzxmodel.GC;
                         //model.WLLB = Gzzxlb;
                         model.WLLBNAME = GetwllbRightTypeString(type);
                         MES_SY_GZZX_SBH[] sbhlist = ServicModel.SY_GZZX_SBH.SELECT(model, getToken());
                         frmFindSBH form = new frmFindSBH(sbhlist, list[0].GZZXMS, type,true);
                         push(form,this);
                     }
                     else
                     {
                         showGZZX(btn.Text, type);
                     }
                }else{
                    showGZZX(btn.Text, type);
                }
                
            }    
        }
        public void RWDSCAN(MES_PD_SCRW_LIST rw,int rigthID,string gc,string gzzx,int wllb,Form form1,string tmText)
        {
            form1.Close();
            form1.Hide();
            if (string.IsNullOrEmpty(gc))
            {
                bool isValid = true;
                if (rigthID == 0)
                {
                    isValid = false;
                }
                else
                {
                    RigthType = (Rigth_Type)rigthID;
                    if (RigthType == Rigth_Type.fujitl)
                    {
                        //frmFujiTL fjtlform = new frmFujiTL(Smodel.MES_PD_SCRW_LIST, sbList[0].SBMS, sbList[0].SBBH);

                        //push(fjtlform);
                    }
                    else if (RigthType == Rigth_Type.gangketl_cc || RigthType == Rigth_Type.jidiantitl_cc || RigthType == Rigth_Type.mfqqingxi || RigthType == Rigth_Type.gmgtl_cc || RigthType == Rigth_Type.fujifengkoujitl_cc || RigthType == Rigth_Type.zhengjifengkoujitl_cc)
                    {
                        //frmTL2  form = new frmTL2(Smodel.MES_PD_SCRW_LIST[0], model.SBBH, RigthType);
                        //push(form);
                        frmTL2_1 form = new frmTL2_1(rw, rw.SBBH, RigthType);
                        push(form,this);
                    }
                    else if (RigthType == Rigth_Type.ddjtl_cc)
                    {
                        frmTL2_2 form = new frmTL2_2(rw, rw.SBBH, RigthType);
                        push(form,this);
                    }
                    else if (RigthType == Rigth_Type.zhuxiancc)
                    {
                        frmZX_CC form = new frmZX_CC(rw, rw.SBBH, RigthType);
                        push(form,this);
                    }
                    else if (RigthType == Rigth_Type.baobiaocc || RigthType == Rigth_Type.dczztl_cc)
                    {
                        //frmBaobiao form = new frmBaobiao(rw, rw.SBBH, RigthType, rw.SBH,tmText);
                        frmBaobiao form = new frmBaobiao(rw, rw.SBBH, RigthType, rw.SBH);
                        push(form,this);
                    }
                    else if (RigthType == Rigth_Type.baozhuangcc)
                    {
                        frmBaozhuang form = new frmBaozhuang(new MES_PD_SCRW_LIST(), rw.SBBH, RigthType, rw.SBH);
                        push(form,this);

                    }
                    else if (RigthType == Rigth_Type.zhuxiantl || RigthType == Rigth_Type.zhujizhengjitl)
                    {

                        frmZX_TL form = new frmZX_TL(rw, rw.SBBH, RigthType); ;
                        push(form,this);
                    }

                }

                if (isValid)
                {

                }
                else
                {
                    ShowMeg(q(Msg_Type.rwdexcept));//"获取任务单信息异常,请联系管理员"
                }
            }
            else
            {
                //扫描工单string gc,string gzzx,int wllb
                MES_SY_GZZX_SBH model = new MES_SY_GZZX_SBH();
                model.GZZXBH = gzzx;
                model.GC = gc;               
                model.WLLB = wllb;
                MES_SY_GZZX_SBH[] list = ServicModel.SY_GZZX_SBH.SELECT(model, getToken());

                if (rigthID != 0)
                {
                    RigthType = (Rigth_Type)rigthID;
                    if (list.Length != 0)
                    {
                        frmFindSBH form = new frmFindSBH(list, gzzx, RigthType,tmText);
                        push(form,this);
                    }
                    else
                    {
                        ShowMeg(gzzx + q(Msg_Type.sbhempty));//对应的设备号为空
                    }
                   
                }
                else
                {
                    ShowMeg(q(Msg_Type.rolegdexcept));//工单对应的权限异常,请联系管理员
                }

            }
           
           
        }
        public void showGZZX(string tt, Rigth_Type type)
        {
            frmFindGZZX form = new frmFindGZZX(tt, type);
            form.getSBHinfo = pushSBH;
            show(form);
            form.Close();
        }

        public void pushSBH(MES_SY_GZZX_SBH[] list, string gzzxtext,Form form1,Rigth_Type type)
        {
            form1.Close();
            form1.Hide();
            
            if (type == Rigth_Type.gangketl_cc ||type == Rigth_Type.zhuxiantl || type == Rigth_Type.fujitl || type == Rigth_Type.zhuxiancc || type == Rigth_Type.baobiaocc || type == Rigth_Type.baozhuangcc || type == Rigth_Type.jidiantitl_cc || type == Rigth_Type.mfqqingxi || type == Rigth_Type.gmgtl_cc || type == Rigth_Type.fujifengkoujitl_cc || type == Rigth_Type.dczztl_cc || type == Rigth_Type.ddjtl_cc || type == Rigth_Type.zhengjifengkoujitl_cc)
            {
                frmFindSBH form = new frmFindSBH(list, gzzxtext, type,true);
                push(form,this);
            }
            else if (type == Rigth_Type.zhengjicc)
            {
                frmZJ_CC zjccform = new frmZJ_CC(list,type);
                push(zjccform,this);
            }
            else if (type == Rigth_Type.fujicc)
            {
                frmFujiCC_N zjccform = new frmFujiCC_N(list, type);
                push(zjccform,this);
            }
            else if (type == Rigth_Type.zhujizhengjitl)
            {
                frmFindSBH form = new frmFindSBH(list, gzzxtext, type,true);
                push(form,this);
            }         
        }

        private void frmAction_Shown(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(getPrinter(key_A5)) || string.IsNullOrEmpty(getPrinter(key_lot)))
            {
                frmBindPrint_1 form = new frmBindPrint_1();
                show(form);
            }
            else
            {
                if (ini.IniReadValue(ini.Section_Configuration, "showRWD").Equals("true"))
                {
                    frmRWDSCAN form = new frmRWDSCAN();
                    form.block = RWDSCAN;
                    show(form);
                } 
            }

        }

    }
}
