using Sonluk.MES.MES.Base;
using Sonluk.UI.Model.MES.PD_SCRWService;
using Sonluk.UI.Model.MES.SY_GZZX_SBHService;
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
    public partial class frmFujiCC_NN : baseview
    {
        MES_SY_GZZX_SBH[] _sbhlist;
        List<FJCClist> _fjcclist;
        List<int> _indexList;

        public List<int> IndexList
        {
            get { return _indexList; }
            set { _indexList = value; }
        }

        public List<FJCClist> Fjcclist
        {
            get { return _fjcclist; }
            set { _fjcclist = value; }
        }

        
        public MES_SY_GZZX_SBH[] Sbhlist
        {
            get { return _sbhlist; }
            set { _sbhlist = value; }
        }
        public frmFujiCC_NN()
        {
            InitializeComponent();
            
            for (int i = 0; i < 4; i++)
            {
                Panel p1 = new Panel();
                p1.Location = new Point(i % 2 * (totalpanel.Bounds.Width / 2), i / 2 * 300);
                p1.Size = new Size(totalpanel.Bounds.Width / 2, 300);
                Label sbh_lb = new Label();
                Label th_lb =  new Label();
                Label pf_lb =  new Label();
                Label pl_lb =  new Label();
                Label cd_lb =  new Label();
                Label zf_lb =  new Label();
                Button qd_btn = new Button();
                Button lot_btn = new Button();
                factory.configLabel(sbh_lb,new Size(100,35),new Point(30,30),new Font(q(Msg_Type.fonttype),29),"G"+(i+1).ToString());
                factory.configLabel(th_lb, new Size(400, 20), new Point(100, 70), "桶号:++++++++" + i.ToString());
                factory.configLabel(pf_lb, new Size(400, 20), new Point(100, 70 + 31), "配方单号:++++++++" + i.ToString());
                factory.configLabel(pl_lb, new Size(400, 20), new Point(100, 70 + 31 * 2 ), "配料单号:++++++++" + i.ToString());
                factory.configLabel(cd_lb, new Size(400, 20), new Point(100, 70 + 31 * 3 ), "锌粉产地:++++++++" + i.ToString());
                factory.configLabel(zf_lb, new Size(400, 20), new Point(100, 70 + 31 * 4 ), "锌粉批号:++++++++" + i.ToString());
                qd_btn.FlatStyle = FlatStyle.Popup;
                lot_btn.FlatStyle = FlatStyle.Popup;
                factory.configButton(qd_btn,new Size(130,50),new Point(100,70 + 31 * 4 + 40),"任务清单",i*10  + 1);
                factory.configButton(lot_btn, new Size(130, 50), new Point(270, 70 + 31 * 4 + 40), "打印Lot表", i * 10  + 2);
                qd_btn.Click += new System.EventHandler(this.btn_Click);
                lot_btn.Click += new System.EventHandler(this.btn_Click);   
                if (i%4 == 0 || i%4 == 3)
                {
                    p1.BackColor =  Color.FromArgb(146,208,80);
                }else{
                    p1.BackColor = Color.FromArgb(252,228,214);
                }
                p1.Tag = 100 + i;
                p1.Controls.Add(sbh_lb);
                p1.Controls.Add(th_lb);
                p1.Controls.Add(pf_lb);
                p1.Controls.Add(pl_lb);
                p1.Controls.Add(cd_lb);
                p1.Controls.Add(zf_lb);
                p1.Controls.Add(qd_btn);
                p1.Controls.Add(lot_btn);
                totalpanel.Controls.Add(p1);
            }


        }
        public frmFujiCC_NN(MES_SY_GZZX_SBH[] model, Rigth_Type rtype)
        {
            InitializeComponent();
            //Point a = zybutton.Location;
            RigthType = rtype;
            configUI_N(model);
            this.timer1.Start();
        }
        /// <summary>
        /// 废弃
        /// </summary>
        /// <param name="model"></param>
        public void configUI(MES_SY_GZZX_SBH[] model)
        {            
            totalpanel.Controls.Clear();         
            Fjcclist = new List<FJCClist>();
            IndexList = new List<int>();
            Sbhlist = model;
            gctextBox.Text = getGC("text");
            gzzxtextBox.Text = getUserInfo("gzzxtext");
            rqtextBox.Text = Convert.ToDateTime(ServicModel.PUBLIC_FUNC.GET_TIME(getToken())).ToString("yyyy-MM-dd");
            for (int i = 0; i < Sbhlist.Length; i++)
            {
                FJCClist list = new FJCClist();
                MES_PD_SCRW pd_scrw = new MES_PD_SCRW();
                pd_scrw.SBBH = Sbhlist[i].SBBH;
                pd_scrw.GC = getGC("value");
                //pd_scrw.GZZXBH = getUserInfo("gzzxvalue");
                pd_scrw.ZPRQ = GetSystemDate(Date_Type.hour, 0, "yyyy-MM-dd"); //DateTime.Now.ToString("yyyy-MM-dd");
                SELECT_MES_PD_SCRW Smodel = ServicModel.PD_SCRW.SELECT(pd_scrw, getToken());
                if (Smodel.MES_RETURN.TYPE.Equals("S"))
                {
                    
                    list.RwArr = Smodel;

                }
                else
                {
                    list.RwArr = new SELECT_MES_PD_SCRW();
                }
                list.SbStruct = Sbhlist[i];
                Fjcclist.Add(list);

            }
            for (int i = 0; i < Fjcclist.Count; i++)
            {
                
                Panel p1 = new Panel();
                p1.Location = new Point(i % 3 * (400), i / 3 * (rect.Height * 4 / 10 ) - 20*(i/3));
                p1.Size = new Size(400, rect.Height * 4 / 10 - 20);
                if (Fjcclist[i].RwArr.MES_PD_SCRW_LIST == null)
                {
                    Label sbh_lb = new Label();
                    Label lb = new Label();
                    factory.configLabel(sbh_lb, new Size(60, 35), new Point(10, 10), new Font(q(Msg_Type.fonttype), 29), Fjcclist[i].SbStruct.SBMS);
                    factory.configLabel(lb, new Size(300, 35), new Point(20, 120), new Font(q(Msg_Type.fonttype), 20),"设备没有派单任务");
                    p1.Controls.Add(lb);
                    p1.Controls.Add(sbh_lb);
                    p1.BorderStyle = BorderStyle.FixedSingle;
                    p1.BackColor = Color.FromArgb(252, 228, 214);
                    totalpanel.Controls.Add(p1);

                }
                else
                {
                    int flag = 0;
                    int finish = 0;
                    bool isRw = false;
                    for (int j = 0; j < Fjcclist[i].RwArr.MES_PD_SCRW_LIST.Length; j++)
                    {
                        if (Fjcclist[i].RwArr.MES_PD_SCRW_LIST[j].ISACTION == 1)
                        {
                            flag = j;
                            isRw = true;
                            break;
                        }
                        else if (Fjcclist[i].RwArr.MES_PD_SCRW_LIST[j].ISACTION == 2)
                        {
                            finish++;
                        }
                       
                    }
                    if (isRw == false)
                    {
                        for (int j = 0; j < Fjcclist[i].RwArr.MES_PD_SCRW_LIST.Length; j++)
                        {
                            if (Fjcclist[i].RwArr.MES_PD_SCRW_LIST[j].ISACTION == 0)
                            {
                                flag = j;
                                break;
                            }                                                 
                        }
                    }
                    IndexList.Add(flag);
                    MES_PD_SCRW_LIST data = Fjcclist[i].RwArr.MES_PD_SCRW_LIST[flag];
                    Label sbh_lb = new Label();
                    sbh_lb.Tag = i * 10 + 3;
                    p1.Controls.Add(sbh_lb);
                    factory.configLabel(sbh_lb, new Size(60, 35), new Point(10, 10), new Font(q(Msg_Type.fonttype), 29), data.SBH.ToString());
                    Button qd_btn = new Button();
                    qd_btn.FlatStyle = FlatStyle.Popup;
                    qd_btn.Click += new System.EventHandler(this.btn_Click);
                    int magrin = p1.Size.Height / 9;
                    int magrin1 = p1.Size.Height / 15;
                    int btnheight = 0;
                    if (p1.Size.Height > 225)
                    {
                        btnheight = p1.Size.Height - 50 - 30;
                    }
                    else
                    {
                         btnheight = p1.Size.Height - 50 - 10;
                    }
                    
                    factory.configButton(qd_btn, new Size(130, 50), new Point(20, btnheight), "任务清单", i * 10 + 1);
                    p1.Controls.Add(qd_btn);
                    p1.BackColor = Color.FromArgb(252, 228, 214);
                    if (Fjcclist[i].RwArr.MES_PD_SCRW_LIST.Length == finish)
                    {
                        Label lb = new Label();
                        factory.configLabel(lb, new Size(300, 35), new Point(20, 120), new Font(q(Msg_Type.fonttype), 20), "今天的任务已经完成");
                        p1.Controls.Add(lb);
                    }
                    else
                    {                                               
                        Label th_lb = new Label();
                        Label pf_lb = new Label();
                        //Label pl_lb = new Label();
                        //Label cd_lb = new Label();
                        //Label zf_lb = new Label();
                        Label zt_lb = new Label();                       
                        th_lb.Tag = i * 10 + 4;
                        pf_lb.Tag = i * 10 + 5;
                        //pl_lb.Tag = i * 10 + 6;
                        //cd_lb.Tag = i * 10 + 7;
                        //zf_lb.Tag = i * 10 + 8;

                        
                        Button lot_btn = new Button();
                        
                        if (data.ISACTION == 0)
                        {
                            lot_btn.Enabled = false;
                        }
                       
                        //ShowMeg(p1.Size.Height.ToString());
                        factory.configLabel(th_lb, new Size(400, 20), new Point(70, magrin1), new Font(q(Msg_Type.fonttype), 22),"桶号:" + data.TH);
                        factory.configLabel(pf_lb, new Size(400, 20), new Point(70, magrin1 + magrin * 1), new Font(q(Msg_Type.fonttype), 22), "配方单号:" + data.PFDH);
                        //factory.configLabel(pl_lb, new Size(400, 20), new Point(70, magrin1 + magrin * 2), "配料单号:" + data.PLDH);
                        //factory.configLabel(cd_lb, new Size(400, 20), new Point(70, magrin1 + magrin * 3), "锌粉产地:" + data.XFCDNAME);
                        //factory.configLabel(zf_lb, new Size(400, 20), new Point(70, magrin1 + magrin * 4), "锌粉批号:" + data.XFPC);
                        string zt = "";
                       
                        if (data.ISACTION == 0)
                        {
                            zt = "未投料";
                            zt_lb.ForeColor = Color.Red;

                        }
                        else if (data.ISACTION == 1)
                        {
                            zt = "已投料";
                            p1.BackColor = Color.FromArgb(146, 208, 80);
                        }
                        else if (data.ISACTION == 2)
                        {
                            zt = "已产出";

                        }
                        factory.configLabel(zt_lb, new Size(400, 20), new Point(70, magrin1 + magrin * 5), "投料状态:" + zt);

                        lot_btn.FlatStyle = FlatStyle.Popup;//10 + 31 * 5 + 40

                        //factory.configButton(lot_btn, new Size(130, 50), new Point(170, 10 + 31 * 5 + 40), "打印LOT表", i * 10 + 2);  
                        factory.configButton(lot_btn, new Size(130, 50), new Point(170, btnheight), "打印LOT表", i * 10 + 2);
                        lot_btn.Click += new System.EventHandler(this.btn_Click);                       
                        p1.Controls.Add(zt_lb);
                       
                        p1.Controls.Add(th_lb);
                        p1.Controls.Add(pf_lb);
                        //p1.Controls.Add(pl_lb);
                        //p1.Controls.Add(cd_lb);
                        //p1.Controls.Add(zf_lb);
                        
                        p1.Controls.Add(lot_btn);
                       
                    }
                    p1.BorderStyle = BorderStyle.FixedSingle;
                    p1.Tag = 100 + i;
                    totalpanel.Controls.Add(p1);
                }
               
          
            }
            //for (int i = 0; i < Sbhlist.Length; i++)
            //{
            //    FJCClist list = new FJCClist();
            //    MES_PD_SCRW pd_scrw = new MES_PD_SCRW();
            //    pd_scrw.SBBH = Sbhlist[i].SBBH;
            //    pd_scrw.GC = getGC("value");
            //    pd_scrw.GZZXBH = getUserInfo("gzzxvalue");
            //    SELECT_MES_PD_SCRW Smodel = ServicModel.PD_SCRW.SELECT(pd_scrw, getToken());
            //    if (Smodel.MES_RETURN.TYPE.Equals("S"))
            //    {
            //        list.SbStruct = Sbhlist[i];
            //        list.RwArr = Smodel;
            //        Fjcclist.Add(list);
            //    }
            //}
            //for (int i = 0; i < Fjcclist.Count; i++)
            //{
            //    int flag = 0;
            //    int length = 0;
            //    for (int j = 0; j < Fjcclist[i].RwArr.MES_PD_SCRW_LIST.Length; j++)
            //    {
            //        if (Fjcclist[i].RwArr.MES_PD_SCRW_LIST[j].ISACTION == 1)
            //        {
            //            flag = j;
                        
            //            break;
            //        }
            //        if (Fjcclist[i].RwArr.MES_PD_SCRW_LIST[j].ISACTION == 0)
            //        {
            //            length++;
            //        }

            //    }
            //    if (flag == 0)
            //    {
            //        if (length < Fjcclist[i].RwArr.MES_PD_SCRW_LIST.Length && length != 0)
            //        {
            //            for (int j = 0; j < Fjcclist[i].RwArr.MES_PD_SCRW_LIST.Length; j++)
            //            {
            //                if (Fjcclist[i].RwArr.MES_PD_SCRW_LIST[j].ISACTION == 2)
            //                {
            //                    flag = j;

            //                }

            //            }
            //            if (Fjcclist[i].RwArr.MES_PD_SCRW_LIST.Length - 1 == flag)
            //            {
            //                flag = Fjcclist[i].RwArr.MES_PD_SCRW_LIST.Length - 1;
            //            }
            //            else
            //            {
            //                flag += 1;
            //            }

            //        }
            //        else
            //        {
            //            flag = 0;
            //        }
            //    }
            //    IndexList.Add(flag);
            //    Panel p1 = new Panel();
            //    p1.Location = new Point(i % 3 * (totalpanel.Bounds.Width / 3), i / 3 * 350);
            //    p1.Size = new Size(totalpanel.Bounds.Width / 3, 350);
            //    Label sbh_lb = new Label();
            //    Label th_lb = new Label();
            //    Label pf_lb = new Label();
            //    Label pl_lb = new Label();
            //    Label cd_lb = new Label();
            //    Label zf_lb = new Label();
            //    Label zt_lb = new Label();
            //    sbh_lb.Tag = i * 10 + 3;
            //    th_lb.Tag = i * 10 + 4;
            //    pf_lb.Tag = i * 10 + 5;
            //    pl_lb.Tag = i * 10 + 6;
            //    cd_lb.Tag = i * 10 + 7;
            //    zf_lb.Tag = i * 10 + 8;

            //    Button qd_btn = new Button();
            //    Button lot_btn = new Button();
            //    MES_PD_SCRW_LIST data = Fjcclist[i].RwArr.MES_PD_SCRW_LIST[flag];
            //    //if (data.ISACTION == 0)
            //    //{
            //    //    lot_btn.Enabled = false;
            //    //}
            //    factory.configLabel(sbh_lb, new Size(100, 35), new Point(30, 30), new Font(q(Msg_Type.fonttype), 29), data.SBH.ToString());
            //    factory.configLabel(th_lb, new Size(400, 20), new Point(100, 70), "桶号:" + data.TH);
            //    factory.configLabel(pf_lb, new Size(400, 20), new Point(100, 70 + 31), "配方单号:" + data.PFDH);
            //    factory.configLabel(pl_lb, new Size(400, 20), new Point(100, 70 + 31 * 2), "配料单号:" + data.PLDH);
            //    factory.configLabel(cd_lb, new Size(400, 20), new Point(100, 70 + 31 * 3), "锌粉产地:" + data.XFCDNAME);
            //    factory.configLabel(zf_lb, new Size(400, 20), new Point(100, 70 + 31 * 4), "锌粉批号:" + data.XFPC);
            //    string zt = "";
            //    p1.BackColor = Color.FromArgb(252, 228, 214);
            //    if (data.ISACTION == 0)
            //    {
            //        zt = "未投料";
            //        zt_lb.ForeColor = Color.Red;
                   
            //    }
            //    else if (data.ISACTION == 1)
            //    {
            //        zt = "已投料";
            //        p1.BackColor = Color.FromArgb(146, 208, 80);
            //    }
            //    else if (data.ISACTION == 2)
            //    {
            //        zt = "已产出";
                   
            //    }
            //    factory.configLabel(zt_lb, new Size(400, 20), new Point(100, 70 + 31 * 5), "投料状态:" + zt);
            //    qd_btn.FlatStyle = FlatStyle.Popup;
            //    lot_btn.FlatStyle = FlatStyle.Popup;
            //    factory.configButton(qd_btn, new Size(130, 50), new Point(100, 70 + 31 * 5 + 40), "任务清单", i * 10 + 1);
            //    factory.configButton(lot_btn, new Size(130, 50), new Point(270, 70 + 31 * 5 + 40), "打印LOT表", i * 10 + 2);
            //    qd_btn.Click += new System.EventHandler(this.btn_Click);
            //    lot_btn.Click += new System.EventHandler(this.btn_Click);
            //    //if (i % 4 == 0 || i % 4 == 3)
            //    //{
            //    //    p1.BackColor = Color.FromArgb(146, 208, 80);
            //    //}
            //    //else
            //    //{
                    
            //        p1.BorderStyle = BorderStyle.FixedSingle;
            //    //}
            //    p1.Tag = 100 + i;
            //    p1.Controls.Add(zt_lb);
            //    p1.Controls.Add(sbh_lb);
            //    p1.Controls.Add(th_lb);
            //    p1.Controls.Add(pf_lb);
            //    p1.Controls.Add(pl_lb);
            //    p1.Controls.Add(cd_lb);
            //    p1.Controls.Add(zf_lb);
            //    p1.Controls.Add(qd_btn);
            //    p1.Controls.Add(lot_btn);
            //    totalpanel.Controls.Add(p1);
            //}
        }
        public void configUI_N(MES_SY_GZZX_SBH[] model)
        {
            totalpanel.Controls.Clear();
            Fjcclist = new List<FJCClist>();
            IndexList = new List<int>();
            Sbhlist = model;
            gctextBox.Text = getGC("text");
            gzzxtextBox.Text = getUserInfo("gzzxtext");
            rqtextBox.Text = Convert.ToDateTime(ServicModel.PUBLIC_FUNC.GET_TIME(getToken())).ToString("yyyy-MM-dd");
            for (int i = 0; i < Sbhlist.Length; i++)
            {
                FJCClist list = new FJCClist();
                MES_PD_SCRW pd_scrw = new MES_PD_SCRW();
                pd_scrw.SBBH = Sbhlist[i].SBBH;
                pd_scrw.GC = getGC("value");
                //pd_scrw.GZZXBH = getUserInfo("gzzxvalue");
                pd_scrw.ZPRQ = GetSystemDate(Date_Type.hour, 0, "yyyy-MM-dd"); //DateTime.Now.ToString("yyyy-MM-dd");
                SELECT_MES_PD_SCRW Smodel = ServicModel.PD_SCRW.SELECT(pd_scrw, getToken());
                if (Smodel.MES_RETURN.TYPE.Equals("S"))
                {
                    list.RwArr = Smodel;
                }
                else
                {
                    list.RwArr = new SELECT_MES_PD_SCRW();
                }
                list.SbStruct = Sbhlist[i];
                Fjcclist.Add(list);

            }
            for (int i = 0; i < Fjcclist.Count; i++)
            {

                Panel p1 = new Panel();
                p1.Location = new Point(i % 3 * (400), i / 3 * (rect.Height * 4 / 10) - 20 * (i / 3));
                p1.Size = new Size(400, rect.Height * 4 / 10 - 20);

                int magrin = p1.Size.Height / 9;
                int magrin1 = p1.Size.Height / 15;
                int btnheight = 0;
                if (p1.Size.Height > 225)
                {
                    btnheight = p1.Size.Height - 50 - 30;
                }
                else
                {
                    btnheight = p1.Size.Height - 50 - 10;
                }


                Label lb_sbh = new Label();
                lb_sbh.Tag = 1 + i*100;
                Label lb_th = new Label();
                lb_th.Tag = 2  + i*100;
                Label lb_pfdh = new Label();
                lb_pfdh.Tag = 3 + i * 100;
                //Label lb_pldh = new Label();
                //lb_pldh.Tag = 4 + i * 100;
                //Label lb_xfcd = new Label();
                //lb_xfcd.Tag = 5 + i * 100;
                //Label lb_xfph = new Label();
                //lb_xfph.Tag = 6 + i * 100;
                Label lb_tlzt = new Label();
                lb_tlzt.Tag = 7 + i * 100;
                Label lb_rwNone = new Label();
                lb_rwNone.Tag = 8 + i * 100;
                Label lb_rwFinish = new Label();
                lb_rwFinish.Tag = 9 + i * 100;
                Button btn_rwqd = new Button();
                //btn_rwqd.Tag = 10 + i * 100;
                Button btn_dylot = new Button();
                //btn_dylot.Tag = 11 + i * 100;
                factory.configLabel(lb_sbh, new Size(100, 40), new Point(10, magrin1*3/2), new Font(q(Msg_Type.fonttype), 32), Fjcclist[i].SbStruct.SBMS);
                factory.configLabel(lb_th, new Size(200, 40), new Point(100, magrin1 * 3/ 2), new Font(q(Msg_Type.fonttype), 32), "桶号:");
                factory.configLabel(lb_pfdh, new Size(400, 50), new Point(10, magrin1* 2 + 75), new Font(q(Msg_Type.fonttype), 35), "配方单号:");
                //factory.configLabel(lb_pldh, new Size(400, 20), new Point(70, magrin1 + magrin * 2), "配料单号:");
                //factory.configLabel(lb_xfcd, new Size(400, 20), new Point(70, magrin1 + magrin * 3), "锌粉产地:");
                //factory.configLabel(lb_xfph, new Size(400, 20), new Point(70, magrin1 + magrin * 4), "锌粉批号:");
                factory.configLabel(lb_tlzt, new Size(400, 30), new Point(10, magrin1 + magrin * 5),new Font(q(Msg_Type.fonttype),22), "投料状态:");
                factory.configLabel(lb_rwNone, new Size(300, 35), new Point(20, 120), new Font(q(Msg_Type.fonttype), 20), "设备没有派单任务");
                factory.configLabel(lb_rwFinish, new Size(300, 35), new Point(20, 120), new Font(q(Msg_Type.fonttype), 20), "今天的任务已经完成");
                factory.configButton(btn_rwqd, new Size(130, 50), new Point(20, btnheight), "任务清单", 10 + i * 100);
                btn_rwqd.Click += new System.EventHandler(this.btn_Click);
                btn_rwqd.FlatStyle = FlatStyle.Popup;
                factory.configButton(btn_dylot, new Size(130, 50), new Point(170, btnheight), "打印LOT表", 11 + i * 100);
                btn_dylot.Click += new System.EventHandler(this.btn_Click);
                btn_dylot.FlatStyle = FlatStyle.Popup;
                p1.Controls.Add(lb_sbh);
                p1.Controls.Add(lb_th);
                p1.Controls.Add(lb_pfdh);
                //p1.Controls.Add(lb_pldh);
                //p1.Controls.Add(lb_xfcd);
                //p1.Controls.Add(lb_xfph);
                p1.Controls.Add(lb_tlzt);
                p1.Controls.Add(lb_rwNone);
                p1.Controls.Add(lb_rwFinish);
                p1.Controls.Add(btn_rwqd);
                p1.Controls.Add(btn_dylot);
                p1.Tag = 1000 + i;
                p1.BackColor = Color.FromArgb(252, 228, 214);
                p1.BorderStyle = BorderStyle.FixedSingle;
                totalpanel.Controls.Add(p1);
                if (Fjcclist[i].RwArr.MES_PD_SCRW_LIST == null)
                {
                    lb_th.Visible = false;
                    lb_pfdh.Visible = false;
                    //lb_pldh.Visible = false;
                    //lb_xfcd.Visible = false;
                    //lb_xfph.Visible = false;
                    lb_tlzt.Visible = false;
                    lb_rwFinish.Visible = false;
                    btn_dylot.Visible = false;
                    btn_rwqd.Visible = false;
                    IndexList.Add(-2);
                }
                else
                {                   
                    if (Fjcclist[i].RwArr.MES_PD_SCRW_LIST.Length == Fjcclist[i].RwArr.MES_PD_SCRW_LIST.Count(p => p.ISACTION == 2))
                    {
                        lb_th.Visible = false;
                        lb_pfdh.Visible = false;
                        //lb_pldh.Visible = false;
                        //lb_xfcd.Visible = false;
                        //lb_xfph.Visible = false;
                        lb_tlzt.Visible = false;
                        lb_rwNone.Visible = false;
                        btn_dylot.Visible = false;
                        IndexList.Add(-1);
                        continue;
                    };
                    int action1Index = Fjcclist[i].RwArr.MES_PD_SCRW_LIST.ToList().FindIndex(p => p.ISACTION == 1);
                    if (action1Index >= 0)
                    {
                        p1.BackColor = Color.FromArgb(146, 208, 80);
                        MES_PD_SCRW_LIST[] data = Fjcclist[i].RwArr.MES_PD_SCRW_LIST;
                        lb_rwNone.Visible = false;
                        lb_rwFinish.Visible = false;
                        lb_th.Text = lb_th.Text + data[action1Index].TH.ToString();
                        lb_pfdh.Text = lb_pfdh.Text + data[action1Index].PFDH;
                        //lb_pldh.Text = lb_pldh.Text + data[action1Index].PLDH;
                        //lb_xfcd.Text = lb_xfcd.Text + data[action1Index].XFCDNAME;
                        //lb_xfph.Text = lb_xfph.Text + data[action1Index].XFPC;
                        lb_tlzt.Text = lb_tlzt.Text + "已投料";
                        IndexList.Add(action1Index);
                        continue;
                    }
                    int action0Index = Fjcclist[i].RwArr.MES_PD_SCRW_LIST.ToList().FindIndex(p => p.ISACTION == 0);
                    if (action0Index >= 0)
                    {
                        MES_PD_SCRW_LIST[] data = Fjcclist[i].RwArr.MES_PD_SCRW_LIST;
                        lb_rwNone.Visible = false;
                        lb_rwFinish.Visible = false;
                        btn_dylot.Enabled = false;
                        lb_th.Text = lb_th.Text + data[action0Index].TH.ToString();
                        lb_pfdh.Text = lb_pfdh.Text + data[action0Index].PFDH;
                        //lb_pldh.Text = lb_pldh.Text + data[action0Index].PLDH;
                        //lb_xfcd.Text = lb_xfcd.Text + data[action0Index].XFCDNAME;
                        //lb_xfph.Text = lb_xfph.Text + data[action0Index].XFPC;
                        lb_tlzt.Text = lb_tlzt.Text + "未投料";
                        lb_tlzt.ForeColor = Color.Red;
                        IndexList.Add(action0Index);
                        continue;
                    }                  
                }

            


            }
          
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int index = Convert.ToInt32(btn.Tag) % 100;//任务清单 = 10   打印lot = 11

            int row = Convert.ToInt32(btn.Tag) / 100;//数组第几个元素
            int indexL = IndexList[row];
            if (indexL == -1)
            {
                indexL = 0;
            }
            MES_PD_SCRW_LIST model = Fjcclist[row].RwArr.MES_PD_SCRW_LIST[indexL];
           
            if (index == 11)
            {
                if (model.ISACTION == 0)
                {
                    ShowMeg("投料还没完成请耐心等待");
                    return;
                }
                timer1.Stop();
                frmFJprint form = new frmFJprint(model);
                show(form);
                RefreshZn();
                //configUI(Sbhlist);
                timer1.Start();
                //configUI(Sbhlist);
                //this.Refresh();

            }
            else if (index == 10)
            {
                string sbhh = model.SBBH;
                string sbh = model.SBH;
                SELECT_MES_PD_SCRW res = GetRWbySBBH(sbhh);
                if (res.MES_RETURN.TYPE.Equals("S"))
                {
                    timer1.Stop();
                    frmSelectRWList_N form = new frmSelectRWList_N(res.MES_PD_SCRW_LIST, sbh);
                    show(form);
                    timer1.Start();
                }
                else
                {
                    MessageBox.Show(res.MES_RETURN.MESSAGE, "消息框");
                }
            }
           
        }
        public void RefreshZn()
        {
            Fjcclist.Clear();
            IndexList.Clear();
            for (int i = 0; i < Sbhlist.Length; i++)
            {
                FJCClist list = new FJCClist();
                MES_PD_SCRW pd_scrw = new MES_PD_SCRW();
                pd_scrw.SBBH = Sbhlist[i].SBBH;
                pd_scrw.GC = getGC("value");
                //pd_scrw.GZZXBH = getUserInfo("gzzxvalue");
                pd_scrw.ZPRQ = GetSystemDate(Date_Type.hour, 0, "yyyy-MM-dd"); //DateTime.Now.ToString("yyyy-MM-dd");
                SELECT_MES_PD_SCRW Smodel = ServicModel.PD_SCRW.SELECT(pd_scrw, getToken());
                if (Smodel.MES_RETURN.TYPE.Equals("S"))
                {
                    list.RwArr = Smodel;
                }
                else
                {
                    list.RwArr = new SELECT_MES_PD_SCRW();
                }
                list.SbStruct = Sbhlist[i];
                Fjcclist.Add(list);

            }
            for (int i = 0; i < Fjcclist.Count; i++)
            {                          
                if (Fjcclist[i].RwArr.MES_PD_SCRW_LIST == null)
                {                   
                    IndexList.Add(-2);
                    continue;
                }
                else
                {
                    if (Fjcclist[i].RwArr.MES_PD_SCRW_LIST.Length == Fjcclist[i].RwArr.MES_PD_SCRW_LIST.Count(p => p.ISACTION == 2))
                    {                      
                        IndexList.Add(-1);
                        continue;
                    };
                    int action1Index = Fjcclist[i].RwArr.MES_PD_SCRW_LIST.ToList().FindIndex(p => p.ISACTION == 1);
                    if (action1Index >= 0)
                    {                       
                        IndexList.Add(action1Index);
                        continue;
                    }
                    int action0Index = Fjcclist[i].RwArr.MES_PD_SCRW_LIST.ToList().FindIndex(p => p.ISACTION == 0);
                    if (action0Index >= 0)
                    {                       
                        IndexList.Add(action0Index);
                        continue;
                    }
                }
            }
            int panelCount = 0;
            foreach (Control p1 in totalpanel.Controls)
            {
                if (p1 is Panel)
                {
                    foreach (Control item in p1.Controls)
                    {
                        if (Fjcclist[panelCount].RwArr.MES_PD_SCRW_LIST == null)
                        {
                            p1.BackColor = Color.FromArgb(252, 228, 214);
                            if (Convert.ToInt32(item.Tag) == 1 + panelCount * 100)
                            {
                                //item.Visible = false;
                                item.Visible = true;
                            }
                            else if (Convert.ToInt32(item.Tag) == 2 + panelCount * 100)
                            {
                                item.Visible = false;
                            }
                            else if (Convert.ToInt32(item.Tag) == 3 + panelCount * 100)
                            {
                                item.Visible = false;
                            }
                            else if (Convert.ToInt32(item.Tag) == 4 + panelCount * 100)
                            {
                                item.Visible = false;
                            }
                            else if (Convert.ToInt32(item.Tag) == 5 + panelCount * 100)
                            {
                                item.Visible = false;
                            }
                            else if (Convert.ToInt32(item.Tag) == 6 + panelCount * 100)
                            {
                                item.Visible = false;
                            }
                            else if (Convert.ToInt32(item.Tag) == 7 + panelCount * 100)
                            {
                                item.Visible = false;
                            }
                            else if (Convert.ToInt32(item.Tag) == 8 + panelCount * 100)
                            {
                                item.Visible = true;
                            }
                            else if (Convert.ToInt32(item.Tag) == 9 + panelCount * 100)
                            {
                                item.Visible = false;
                            }
                            else if (Convert.ToInt32(item.Tag) == 10 + panelCount * 100)
                            {
                                item.Visible = false;
                            }
                            else if (Convert.ToInt32(item.Tag) == 11 + panelCount * 100)
                            {
                                item.Visible = false;
                            }                           
                           
                            break;
                        }
                        else
                        {
                            if (Fjcclist[panelCount].RwArr.MES_PD_SCRW_LIST.Length == Fjcclist[panelCount].RwArr.MES_PD_SCRW_LIST.Count(p => p.ISACTION == 2))
                            {
                                p1.BackColor = Color.FromArgb(252, 228, 214);
                                if (Convert.ToInt32(item.Tag) == 1 + panelCount * 100)
                                {
                                    item.Visible = true;
                                }
                                else if (Convert.ToInt32(item.Tag) == 2 + panelCount * 100)
                                {
                                    item.Visible = false;
                                }
                                else if (Convert.ToInt32(item.Tag) == 3 + panelCount * 100)
                                {
                                    item.Visible = false;
                                }
                                else if (Convert.ToInt32(item.Tag) == 4 + panelCount * 100)
                                {
                                    item.Visible = false;
                                }
                                else if (Convert.ToInt32(item.Tag) == 5 + panelCount * 100)
                                {
                                    item.Visible = false;
                                }
                                else if (Convert.ToInt32(item.Tag) == 6 + panelCount * 100)
                                {
                                    item.Visible = false;
                                }
                                else if (Convert.ToInt32(item.Tag) == 7 + panelCount * 100)
                                {
                                    item.Visible = false;
                                }
                                else if (Convert.ToInt32(item.Tag) == 8 + panelCount * 100)
                                {
                                    item.Visible = false;
                                }
                                else if (Convert.ToInt32(item.Tag) == 9 + panelCount * 100)
                                {
                                    item.Visible = true;
                                }
                                else if (Convert.ToInt32(item.Tag) == 10 + panelCount * 100)
                                {
                                    item.Visible = true;
                                }
                                else if (Convert.ToInt32(item.Tag) == 11 + panelCount * 100)
                                {
                                    item.Visible = false;
                                }                                     
                               
                                continue;
                            };
                            int action1Index = Fjcclist[panelCount].RwArr.MES_PD_SCRW_LIST.ToList().FindIndex(p => p.ISACTION == 1);
                            if (action1Index >= 0)
                            {
                                p1.BackColor = Color.FromArgb(146, 208, 80);
                                MES_PD_SCRW_LIST[] data = Fjcclist[panelCount].RwArr.MES_PD_SCRW_LIST;                               
                                if (Convert.ToInt32(item.Tag) == 1 + panelCount * 100)
                                {
                                    item.Visible = true;
                                }
                                else if (Convert.ToInt32(item.Tag) == 2 + panelCount * 100)
                                {
                                    Label lb = (Label)item;
                                    lb.Visible = true;
                                    lb.Text = "桶号:" + data[action1Index].TH.ToString();
                                }
                                else if (Convert.ToInt32(item.Tag) == 3 + panelCount * 100)
                                {
                                    Label lb = (Label)item;
                                    lb.Visible = true;
                                    lb.Text = "配方单号:" + data[action1Index].PFDH;
                                }
                                else if (Convert.ToInt32(item.Tag) == 4 + panelCount * 100)
                                {
                                    Label lb = (Label)item;
                                    lb.Visible = true;
                                    lb.Text = "配料单号:" + data[action1Index].PLDH;
                                }
                                else if (Convert.ToInt32(item.Tag) == 5 + panelCount * 100)
                                {
                                    Label lb = (Label)item;
                                    lb.Visible = true;
                                    lb.Text = "锌粉产地:" + data[action1Index].XFCDNAME;
                                }
                                else if (Convert.ToInt32(item.Tag) == 6 + panelCount * 100)
                                {
                                    Label lb = (Label)item;
                                    lb.Visible = true;
                                    lb.Text = "锌粉批号:" + data[action1Index].XFPC;
                                }
                                else if (Convert.ToInt32(item.Tag) == 7 + panelCount * 100)
                                {
                                    Label lb = (Label)item;
                                    lb.Visible = true;
                                    lb.Text = "投料状态:已投料";
                                    lb.ForeColor = Color.Black;
                                }
                                else if (Convert.ToInt32(item.Tag) == 8 + panelCount * 100)
                                {
                                    item.Visible = false;
                                }
                                else if (Convert.ToInt32(item.Tag) == 9 + panelCount * 100)
                                {
                                    item.Visible = false;
                                }
                                else if (Convert.ToInt32(item.Tag) == 10 + panelCount * 100)
                                {
                                    Button btn = (Button)item;
                                    btn.Enabled = true;
                                    btn.Visible = true;
                                }
                                else if (Convert.ToInt32(item.Tag) == 11 + panelCount * 100)
                                {
                                    Button btn = (Button)item;
                                    btn.Enabled = true;
                                    btn.Visible = true;
                                }
                                continue;
                            }
                            int action0Index = Fjcclist[panelCount].RwArr.MES_PD_SCRW_LIST.ToList().FindIndex(p => p.ISACTION == 0);
                            if (action0Index >= 0)
                            {
                                p1.BackColor = Color.FromArgb(252, 228, 214);
                                MES_PD_SCRW_LIST[] data = Fjcclist[panelCount].RwArr.MES_PD_SCRW_LIST;
                               
                                if (Convert.ToInt32(item.Tag) == 1 + panelCount * 100)
                                {
                                    item.Visible = true;
                                }
                                else if (Convert.ToInt32(item.Tag) == 2 + panelCount * 100)
                                {
                                    Label lb = (Label)item;
                                    lb.Visible = true;
                                    lb.Text = "桶号:" + data[action0Index].TH.ToString();
                                }
                                else if (Convert.ToInt32(item.Tag) == 3 + panelCount * 100)
                                {
                                    Label lb = (Label)item;
                                    lb.Visible = true;
                                    lb.Text = "配方单号:" + data[action0Index].PFDH;
                                }
                                else if (Convert.ToInt32(item.Tag) == 4 + panelCount * 100)
                                {
                                    Label lb = (Label)item;
                                    lb.Visible = true;
                                    lb.Text = "配料单号:" + data[action0Index].PLDH;
                                }
                                else if (Convert.ToInt32(item.Tag) == 5 + panelCount * 100)
                                {
                                    Label lb = (Label)item;
                                    lb.Visible = true;
                                    lb.Text = "锌粉产地:" + data[action0Index].XFCDNAME;
                                }
                                else if (Convert.ToInt32(item.Tag) == 6 + panelCount * 100)
                                {
                                    Label lb = (Label)item;
                                    lb.Visible = true;
                                    lb.Text = "锌粉批号:" + data[action0Index].XFPC;
                                }
                                else if (Convert.ToInt32(item.Tag) == 7 + panelCount * 100)
                                {
                                    Label lb = (Label)item;
                                    lb.Visible = true;
                                    lb.Text = "投料状态:未投料";
                                    lb.ForeColor = Color.Red;
                                }
                                else if (Convert.ToInt32(item.Tag) == 8 + panelCount * 100)
                                {
                                    item.Visible = false;
                                }
                                else if (Convert.ToInt32(item.Tag) == 9 + panelCount * 100)
                                {
                                    item.Visible = false;
                                }
                                else if (Convert.ToInt32(item.Tag) == 10 + panelCount * 100)
                                {
                                    item.Visible = true;
                                }
                                else if (Convert.ToInt32(item.Tag) == 11 + panelCount * 100)
                                {
                                    Button btn = (Button)item;
                                    btn.Visible = true;
                                    btn.Enabled = false;
                                }
                                continue;
                            }
                        }
                    }
                 
                    panelCount++;
                }
            }
            
         

        }


        public class FJCClist
        {
            MES_SY_GZZX_SBH _sbStruct;

            public MES_SY_GZZX_SBH SbStruct
            {
                get { return _sbStruct; }
                set { _sbStruct = value; }
            }
            SELECT_MES_PD_SCRW _RwArr;

            public SELECT_MES_PD_SCRW RwArr
            {
                get { return _RwArr; }
                set { _RwArr = value; }
            }
        }

        private void sxbutton_Click(object sender, EventArgs e)
        {
            RefreshZn();
        }

        private void frmFujiCC_Load(object sender, EventArgs e)
        {

        }

        private void frmFujiCC_Shown(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            RefreshZn();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RefreshZn();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            RefreshZn();
        }
       
    }
}
