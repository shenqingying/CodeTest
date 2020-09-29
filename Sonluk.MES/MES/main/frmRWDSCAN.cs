using Sonluk.MES.MES.Base;
using Sonluk.UI.Model.MES;
using Sonluk.UI.Model.MES.PD_GDService;
using Sonluk.UI.Model.MES.PD_SCRWService;
using Sonluk.UI.Model.MES.SY_GCService;
using Sonluk.UI.Model.MES.SY_GZZX_SBHService;
using Sonluk.UI.Model.MES.SY_GZZX_WLLBService;
using Sonluk.UI.Model.MES.SY_GZZXService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sonluk.MES.MES.main
{
    public partial class frmRWDSCAN : basefrm
    {
        List<MES_SY_GC> staffgclist = new List<MES_SY_GC>();
        public frmRWDSCAN()
        {
            InitializeComponent();
            MES_SY_GC gcmodel = new MES_SY_GC();
            gcmodel.STAFFID = Convert.ToInt32(getUserInfo("staffid"));

            MES_SY_GC[] gcArr = ServicModel.SY_GC.SELECT_BY_ROLE(gcmodel, getToken());
            for (int i = 0; i < gcArr.Length; i++)
            {
                gcArr[i].GCMS = gcArr[i].GC + "-" + gcArr[i].GCMS;
            }
            List<MES_SY_GC> gcList = gcArr.ToList();
            staffgclist = gcList;
            MES_SY_GC choiceModel = new MES_SY_GC();
            choiceModel.GCMS = q(Msg_Type.titlechoice);//"==请选择==";
            choiceModel.GC = "0";
            gcList.Insert(0, choiceModel);
            gccomboBox.DisplayMember = "GCMS";
            gccomboBox.ValueMember = "GC";
            gccomboBox.DataSource = gcList;
            gclabel.Visible = false;
            gccomboBox.Visible = false;
            //if (gcList.Count == 2)
            //{
            //    gccomboBox.SelectedValue = gcList[1].GC;
            //}
            //if (gcArr.Length == 1)
            //{
            //    gclabel.Visible = false;
            //    gccomboBox.Visible = false;
            //}
            //else
            //{
            //    gclabel.Visible = true;
            //    gccomboBox.Visible = true;
            //}

        }

        private void smtextBox_KeyDown(object sender, KeyEventArgs e)
        {                      
            if (e.KeyCode == Keys.Enter)
            {
                ScanTM();
            }
        }
        public void ScanTM()
        {
            TM_Type type = TMtype(smtextBox.Text.Trim());
            switch (type)
            {             
                case TM_Type.rwd:
                    ChangeRW();
                    break;
                case TM_Type.gd:
                    SCANGD();
                    break;
                case TM_Type.tpm:
                    SCANTPM();
                    break;
                case TM_Type.sbbh:
                    SCANSBBH();
                    break;
                default:
                    //MessageBox.Show("你扫描的是无效的条码！！", "消息框");
                    ShowMeg(q(Msg_Type.msgscantminvalid));
                    break;
            }
            smtextBox.Clear();
            smtextBox.Select();
        }
        public delegate void Block(MES_PD_SCRW_LIST list,int rigthID,string gc,string gzzx,int wllb,Form form1,string smText);
        public Block block;
        public void SCANTPM()
        {
            ZBCFUN_CPBZ_READ res = ServicModel.PD_GD.get_CPBZ_READ(smtextBox.Text.Trim().ToUpper(),getToken());
            if (res.MES_RETURN.TYPE.Equals("S"))
            {
                if (res.ET_RT.Length > 0 && res.ET_RT != null)
                {
                     MES_SY_GZZX_WLLB wllbModel = new MES_SY_GZZX_WLLB();
                    wllbModel.WLLBID = res.ES_HEADER.WLLB;
                    wllbModel.GC = res.ES_HEADER.WERKS;
                    wllbModel.GZZXBH = res.ET_RT[0].ARBPL;
                    MES_SY_GZZX_WLLB_SELECT wllbRes = ServicModel.SY_GZZX_WLLB.SELECT(wllbModel, getToken());

                    MES_SY_GC gc_model = new MES_SY_GC();
                    gc_model.GC = res.ES_HEADER.WERKS;
                    MES_SY_GC[] gc_res = ServicModel.SY_GC.read(gc_model, getToken());
                    MES_SY_GZZX gzzxmodel = new MES_SY_GZZX();
                    gzzxmodel.GZZXBH = res.ET_RT[0].ARBPL;
                    gzzxmodel.GC = res.ES_HEADER.WERKS;
                    MES_SY_GZZX[] gzzx_res = ServicModel.SY_GZZX.SELECT(gzzxmodel, getToken());


                    ini.IniWriteValue(ini.Section_UserInfo, "gzzxvalue",  res.ET_RT[0].ARBPL);
                    ini.IniWriteValue(ini.Section_UserInfo, "gzzxtext", gzzx_res[0].GZZXMS);
                    ini.IniWriteValue(ini.Section_GC, "value", res.ES_HEADER.WERKS);
                    ini.IniWriteValue(ini.Section_GC, "text", gc_res[0].GCMS);

                    if (wllbRes.MES_RETURN.TYPE.Equals("S"))
                    {
                        if (wllbRes.MES_SY_GZZX_WLLB != null && wllbRes.MES_SY_GZZX_WLLB.Length == 1)
                        {
                            if (block != null)
                            {
                                block(new MES_PD_SCRW_LIST(), wllbRes.MES_SY_GZZX_WLLB[0].RIGHTID, res.ES_HEADER.WERKS, res.ET_RT[0].ARBPL, res.ES_HEADER.WLLB,this,smtextBox.Text.Trim().ToUpper());
                                //this.Close();
                            }
                           
                        }
                        else
                        {
                            //ShowMeg("获取工单对应权限异常,请联系管理员");
                            ShowMeg(q(Msg_Type.msggdroleexcept));
                        }
                       
                    }
                }
                //res.ES_HEADER.WERKS
            }
            else
            {
                ShowMeg(res.MES_RETURN.MESSAGE);
            }
        }
        public void SCANGD()
        {
            //if (gccomboBox.SelectedValue.Equals("0"))
            //{
            //    //&&  gccomboBox.SelectedValue.Equals("0")
            //    //ShowMeg("请选择工单对应的工厂");
            //    ShowMeg(q(Msg_Type.msggdgc));
            //    return;
            //}                       
            //string gc =  Convert.ToString(gccomboBox.SelectedValue);


            //ZBCFUN_GDJGXX_READ sap_res = ServicModel.PD_GD.get_GDJGXX_BYERPNO_GC(gc, smtextBox.Text.Trim().ToUpper(), getToken());
            ZBCFUN_GDJGXX_READ sap_res = ServicModel.PD_GD.get_GDJGXX_BYERPNO(smtextBox.Text.Trim().ToUpper(), getToken());
            if (!sap_res.MES_RETURN.TYPE.Equals("S"))
            {
                ShowMeg(sap_res.MES_RETURN.MESSAGE);
                return;
            }
            MES_PD_GD gdmodel = new MES_PD_GD();
            gdmodel.ERPNO = smtextBox.Text.Trim().ToUpper();
            gdmodel.JLR = Convert.ToInt32(getUserInfo("staffid")); 
            SELECT_MES_PD_GD res = ServicModel.PD_GD.SELECT_BY_ERPNO_SYNC(gdmodel, getToken());
            if (res.MES_RETURN.TYPE.Equals("S"))
            {
                if (res.MES_PD_GD_LIST.Length == 1)
                {
                    MES_PD_GD_LIST node = res.MES_PD_GD_LIST[0];
                    if (node.WLLBNAME.Equals("成品"))
                    {
                        //ShowMeg("成品请扫描<生产入库标识>");
                        ShowMeg(q(Msg_Type.msgcpscanrkbs));
                        return;

                    }
                    if (block != null)
                    {
                        MES_SY_GZZX_WLLB wllbModel = new MES_SY_GZZX_WLLB();
                        wllbModel.WLLBID = node.WLLB;
                        wllbModel.GC = node.GC;
                        wllbModel.GZZXBH = node.GZZXBH;
                        MES_SY_GZZX_WLLB_SELECT wllbRes = ServicModel.SY_GZZX_WLLB.SELECT(wllbModel, getToken());

                        MES_SY_GC gc_model = new MES_SY_GC();
                        gc_model.GC = node.GC;
                        MES_SY_GC[] gc_res = ServicModel.SY_GC.read(gc_model, getToken());
                        MES_SY_GZZX gzzxmodel = new MES_SY_GZZX();
                        gzzxmodel.GZZXBH = node.GZZXBH;
                        gzzxmodel.GC = node.GC;
                        MES_SY_GZZX[] gzzx_res = ServicModel.SY_GZZX.SELECT(gzzxmodel, getToken());



                        ini.IniWriteValue(ini.Section_UserInfo, "gzzxvalue", node.GZZXBH);
                        ini.IniWriteValue(ini.Section_UserInfo, "gzzxtext", gzzx_res[0].GZZXMS);
                        ini.IniWriteValue(ini.Section_GC, "value", node.GC);
                        ini.IniWriteValue(ini.Section_GC, "text", gc_res[0].GCMS);




                        if (wllbRes.MES_RETURN.TYPE.Equals("S"))
                        {
                            if (wllbRes.MES_SY_GZZX_WLLB != null && wllbRes.MES_SY_GZZX_WLLB.Length == 1)
                            {
                                block(new MES_PD_SCRW_LIST(), wllbRes.MES_SY_GZZX_WLLB[0].RIGHTID, node.GC, node.GZZXBH, node.WLLB, this, smtextBox.Text.Trim().ToUpper());
                                //this.Close();
                            }
                            else
                            {
                                //ShowMeg("获取工单对应权限异常,请联系管理员");
                                ShowMeg(q(Msg_Type.msggdroleexcept));
                            }

                        }
                        else
                        {
                            ShowMeg(wllbRes.MES_RETURN.MESSAGE);
                        }

                    }

                }
                else
                {
                    //ShowMeg("工单获取的工单信息异常，请联系管理员");
                    ShowMeg(q(Msg_Type.msggdroleexcept));
                }
              
                
            }
            else
            {
                ShowMeg(res.MES_RETURN.MESSAGE);
            }
        }
        public void ChangeRW()
        {
            MES_PD_SCRW model = new MES_PD_SCRW();
            model.RWBH = smtextBox.Text.Trim().ToUpper();
            model.STAFFID = Convert.ToInt32(getUserInfo("staffid"));
            //model.ZPRQ = DateTime.Now.ToString("yyyy-MM-dd");
            SELECT_MES_PD_SCRW res = ServicModel.PD_SCRW.SELECT_BY_ROLE(model, getToken());
            if (res.MES_RETURN.TYPE.Equals("S"))
            {
               
                if (res.MES_PD_SCRW_LIST.Length == 1)
                {
                    if (res.MES_PD_SCRW_LIST[0].WLLBNAME.Equals("成品"))
                    {
                        //ShowMeg("成品请扫描<生产入库标识>");
                        ShowMeg(q(Msg_Type.msgcpscanrkbs));
                        return;
                    }
                    MES_SY_GZZX_WLLB wllbModel = new MES_SY_GZZX_WLLB();
                    wllbModel.WLLBID = res.MES_PD_SCRW_LIST[0].WLLB;
                    wllbModel.GC = res.MES_PD_SCRW_LIST[0].GC;
                    wllbModel.GZZXBH = res.MES_PD_SCRW_LIST[0].GZZXBH;
                   
                  
                    //ini.IniWriteValue(ini.Section_GC, "text", Convert.ToString(gccomboBox.Text.Trim()));
                    MES_SY_GC gc_model = new MES_SY_GC();
                    gc_model.GC = res.MES_PD_SCRW_LIST[0].GC;
                    MES_SY_GC[] gc_res = ServicModel.SY_GC.read(gc_model,getToken());
                    ini.IniWriteValue(ini.Section_UserInfo, "gzzxvalue", res.MES_PD_SCRW_LIST[0].GZZXBH);
                    ini.IniWriteValue(ini.Section_UserInfo, "gzzxtext", res.MES_PD_SCRW_LIST[0].GZZXNAME);
                    ini.IniWriteValue(ini.Section_GC, "value", res.MES_PD_SCRW_LIST[0].GC);
                    ini.IniWriteValue(ini.Section_GC, "text",   gc_res[0].GCMS);
                    MES_SY_GZZX_WLLB_SELECT wllbRes = ServicModel.SY_GZZX_WLLB.SELECT(wllbModel, getToken());
                    if (wllbRes.MES_RETURN.TYPE.Equals("S"))
                    {
                        if (wllbRes.MES_SY_GZZX_WLLB != null && wllbRes.MES_SY_GZZX_WLLB.Length == 1)
                        {
                            if (block != null)
                            {

                                block(res.MES_PD_SCRW_LIST[0],wllbRes.MES_SY_GZZX_WLLB[0].RIGHTID,"","",0,this,smtextBox.Text.Trim().ToUpper());
                                //this.Close();

                            }
                        }
                        else
                        {
                            //ShowMeg("获取任务单权限异常,请联系管理员");
                            ShowMeg(q(Msg_Type.msgrwdroleexcept));
                        }
                       
                    }
                    else
                    {
                        ShowMeg(wllbRes.MES_RETURN.MESSAGE);
                    }
                   
                }
                else
                {
                    //ShowMeg("获得任务单异常,请联系管理员");
                    ShowMeg(q(Msg_Type.msgrwdroleexcept));
                }
            }
            else
            {
                ShowMeg(res.MES_RETURN.MESSAGE);
            }
        }
        public void SCANSBBH()
        {
           MES_SY_GZZX_SBH model = new MES_SY_GZZX_SBH();
            model.SBBH = smtextBox.Text.Trim();
           MES_SY_GZZX_SBH[] sbhREs = ServicModel.SY_GZZX_SBH.SELECT(model,getToken());
           if (sbhREs.Length == 1)
           {
               MES_SY_GZZX_SBH res = sbhREs[0];
               ini.IniWriteValue(ini.Section_UserInfo, "gzzxvalue", res.GZZXBH);
               ini.IniWriteValue(ini.Section_UserInfo, "gzzxtext", res.GZZXMS);
               ini.IniWriteValue(ini.Section_GC, "value", res.GC);
               MES_SY_GC gcmodel = new MES_SY_GC();
               gcmodel.GC = res.GC;
               MES_SY_GC[] gcres = ServicModel.SY_GC.read(gcmodel, getToken());
               if (gcres.Length == 1)
               {
                   ini.IniWriteValue(ini.Section_GC, "text", gcres[0].GCMS);

                   MES_PD_SCRW rwmodel = new MES_PD_SCRW();
                   rwmodel.SBBH = smtextBox.Text.Trim(); ;
                   

                   //DateTime currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                   //DateTime dt = DateTime.Now;
                   //dt = dt.AddHours(-4);
                   //string a = ServicModel.PUBLIC_FUNC.GET_TIME(getToken());
                   DateTime sy_dt = Convert.ToDateTime(ServicModel.PUBLIC_FUNC.GET_TIME(getToken())).AddHours(-4);
                   //sy_dt = sy_dt.AddHours(-4);
                   //string currentTime = dt.ToString("yyyy-MM-dd");
                   rwmodel.ZPRQ = sy_dt.ToString("yyyy-MM-dd");

                   SELECT_MES_PD_SCRW Smodel = ServicModel.PD_SCRW.SELECT_LAST(rwmodel, getToken());
                   if (Smodel.MES_RETURN.TYPE == "E")
                   {
                      ShowMeg(Smodel.MES_RETURN.MESSAGE);
                   }
                   else
                   {
                       MES_SY_GZZX_WLLB wllbModel = new MES_SY_GZZX_WLLB();
                       wllbModel.WLLBID = Smodel.MES_PD_SCRW_LIST[0].WLLB;
                       wllbModel.GC = Smodel.MES_PD_SCRW_LIST[0].GC;
                       wllbModel.GZZXBH = Smodel.MES_PD_SCRW_LIST[0].GZZXBH;
                       MES_SY_GZZX_WLLB_SELECT wllbRes = ServicModel.SY_GZZX_WLLB.SELECT(wllbModel, getToken());
                       if (wllbRes.MES_RETURN.TYPE.Equals("S"))
                       {
                           if (wllbRes.MES_SY_GZZX_WLLB != null && wllbRes.MES_SY_GZZX_WLLB.Length == 1)
                           {
                               if (block != null)
                               {

                                   block(Smodel.MES_PD_SCRW_LIST[0], wllbRes.MES_SY_GZZX_WLLB[0].RIGHTID, "", "", 0, this, smtextBox.Text.Trim().ToUpper());
                                   //this.Close();

                               }
                           }
                           else
                           {
                               //ShowMeg("扫描设备号获取任务单权限异常,请联系管理员");
                               ShowMeg(q(Msg_Type.msgrwdroleexcept));
                           }

                       }
                       else
                       {
                           ShowMeg(wllbRes.MES_RETURN.MESSAGE);
                       }
                   }
            


               }
               else
               {
                   //ShowMeg("扫描的条码得到的不是唯一的工厂名字");
                   ShowMeg(q(Msg_Type.msgtmnoonly));
               }
               
           }
           else
           {
               //ShowMeg("扫描的条码不是正确设备号");
               ShowMeg(q(Msg_Type.msgscantmnosbh));
           }
        }

        private void smtextBox_MouseDown(object sender, MouseEventArgs e)
        {
            //InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(CultureInfo.GetCultureInfo("en-US"));
        }

        private void temp()
        {
            //ZBCFUN_GDJGXX_READ res = ServicModel.PD_GD.get_GDJGXX_BYERPNO(smtextBox.Text.Trim().ToUpper(), getToken());
            //if (res.MES_RETURN.TYPE.Equals("S"))
            //{
            //    if (res.ES_HEADER != null)
            //    {
            //        if (res.ES_HEADER.WLDL.Equals("成品"))
            //        {
            //            ShowMeg("成品请扫描<生产入库标识>");
            //            return;
            //        }
            //    }
            //    if (block != null)
            //    {
            //        MES_SY_GZZX_WLLB wllbModel = new MES_SY_GZZX_WLLB();
            //        wllbModel.WLLBID = res.ES_HEADER.WLLB;
            //        wllbModel.GC = res.ES_HEADER.WERKS;
            //        wllbModel.GZZXBH = res.ES_HEADER.ARBPL;
            //        MES_SY_GZZX_WLLB_SELECT wllbRes = ServicModel.SY_GZZX_WLLB.SELECT(wllbModel, getToken());

            //        MES_SY_GC gc_model = new MES_SY_GC();
            //        gc_model.GC = res.ES_HEADER.WERKS;
            //        MES_SY_GC[] gc_res = ServicModel.SY_GC.read(gc_model, getToken());
            //        MES_SY_GZZX gzzxmodel = new MES_SY_GZZX();
            //        gzzxmodel.GZZXBH = res.ES_HEADER.ARBPL;
            //        gzzxmodel.GC = res.ES_HEADER.WERKS;
            //        MES_SY_GZZX[] gzzx_res = ServicModel.SY_GZZX.SELECT(gzzxmodel, getToken());



            //        ini.IniWriteValue(ini.Section_UserInfo, "gzzxvalue", res.ES_HEADER.ARBPL);
            //        ini.IniWriteValue(ini.Section_UserInfo, "gzzxtext", gzzx_res[0].GZZXMS);
            //        ini.IniWriteValue(ini.Section_GC, "value", res.ES_HEADER.WERKS);
            //        ini.IniWriteValue(ini.Section_GC, "text", gc_res[0].GCMS);




            //        if (wllbRes.MES_RETURN.TYPE.Equals("S"))
            //        {
            //            if (wllbRes.MES_SY_GZZX_WLLB != null && wllbRes.MES_SY_GZZX_WLLB.Length == 1)
            //            {
            //                block(new MES_PD_SCRW_LIST(), wllbRes.MES_SY_GZZX_WLLB[0].RIGHTID, res.ES_HEADER.WERKS, res.ES_HEADER.ARBPL, res.ES_HEADER.WLLB, this, smtextBox.Text.Trim().ToUpper());
            //                //this.Close();
            //            }
            //            else
            //            {
            //                ShowMeg("获取工单对应权限异常,请联系管理员");
            //            }

            //        }
            //        else
            //        {
            //            ShowMeg(wllbRes.MES_RETURN.MESSAGE);
            //        }

            //    }
            //}
            //else
            //{
            //    ShowMeg(res.MES_RETURN.MESSAGE);
            //}
        }
    }
}
