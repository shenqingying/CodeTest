using Sonluk.WX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sonluk.WX.APPCLASS;
using Sonluk.UI.Model.BC.BarCodeService;
using Sonluk.UI.Model.CRM.BC_CHTTService;
using Sonluk.UI.Model.CRM.BC_CHTT_FAKEService;
using Sonluk.UI.Model.CRM.BC_PMLISTService;
using Sonluk.UI.Model.CRM.KH_KHService;
using Sonluk.UI.Model.CRM.BC_FXCHService;

namespace Sonluk.WX.Areas.CRM.Controllers
{
    public class FCHController : Controller
    {
        //
        // GET: /CRM/FCH/
        CRMModels crmModels = new CRMModels();
        AppClass appClass = new AppClass();
        string token = "";
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SAPXXTB()    //信息同步
        {
            return View();
        }

        public ActionResult SelectBarCode()    //
        {
            return View();
        }

        public ActionResult SelectBarCode_KH()    //
        {
            return View();
        }

        public ActionResult ScanCH()      //扫描分销商和箱码，然后保存关联关系
        {
            return View();
        }

        public ActionResult ScanCH_WX()
        {
            return View();
        }

        public ActionResult UpdateScanCH()
        {
            return View();
        }

        public ActionResult FXCH_CX()
        {
            return View();
        }

        public ActionResult FXCH_CX_WX()
        {
            return View();
        }

        public ActionResult FXCH_Report()
        {
            return View();
        }

        public ActionResult ScanCH_FX()
        {
            return View();
        }

        public ActionResult ScanFAHUO()      //沈阳中转库发货
        {
            return View();
        }

        [HttpPost]
        public ActionResult ScanFAHUO_JHDPart(string VBELN)
        {
            token = appClass.CRM_Gettoken();
            MODEL_ZBCFUN_JHD_READ data = crmModels.BarCode.JHD_READ(VBELN, token);
            ViewBag.data = data;
            CRM_BC_FXCHMX cx_fxch = new CRM_BC_FXCHMX();
            cx_fxch.VBELN = VBELN;
            CRM_BC_FXCHMX[] FXCHdata = crmModels.BC_FXCH.ReadMXbyParam(cx_fxch, token);
            ViewBag.FXCHdata = FXCHdata;
            return View();
        }

        [HttpPost]
        public ActionResult ScanFAHUO_JHDMXPart(string data)
        {
            token = appClass.CRM_Gettoken();
            ZSL_BCST014 model = Newtonsoft.Json.JsonConvert.DeserializeObject<ZSL_BCST014>(data);
            ViewBag.data = model;
            int amount = 0;
            for (int i = 0; i < model.TM.Length; i++)
            {
                amount += model.TM[i].SCANED;
            }


            MODEL_ZBCFUN_JHZ_READ JHZmodel = new MODEL_ZBCFUN_JHZ_READ();
            //if (model.MATNR.Length == 10)
            //    model.MATNR = "00000000" + model.MATNR;
            JHZmodel.IV_MATNR = model.MATNR;
            JHZmodel.IV_SL = Convert.ToInt32(model.LGMNG) - amount;
            MODEL_ZBCFUN_JHZ_READ JHZdata = crmModels.BarCode.JHZ_READ(JHZmodel, token);
            ViewBag.amount = amount;
            ViewBag.JHZdata = JHZdata;
            return View();
        }

        [HttpPost]
        public string Data_TongBuSAP_CH()         //更新昨天到今天的发货数据
        {
            token = appClass.CRM_Gettoken();

            try
            {
                string yesterday = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
                MODEL_ZBCFUN_DLV_GET SAPdata = crmModels.BarCode.GET_ZBCFUN_DLV_GET_CRM(yesterday, "C", token);        //获取SAP数据
                if (SAPdata.ET_TTXX.Length == 0)
                {
                    return "没有需要同步的信息";
                }
                int delete = crmModels.BC_CHTT_FAKE.TTMXDelete(token);        //把FAKE表的数据清光
                if (delete != 0)
                {
                    return "出货抬头同步发生异常，请重试";
                }
                for (int i = 0; i < SAPdata.ET_TTXX.Length; i++)       //抬头新增
                {
                    CRM_BC_CHTT TTmodel = new CRM_BC_CHTT();
                    TTmodel.VBELN = SAPdata.ET_TTXX[i].VBELN;
                    TTmodel.WERKS = SAPdata.ET_TTXX[i].WERKS;
                    TTmodel.POSNR = SAPdata.ET_TTXX[i].POSNR;
                    TTmodel.MATNR = SAPdata.ET_TTXX[i].MATNR;
                    TTmodel.KUNAG = SAPdata.ET_TTXX[i].KUNAG;
                    TTmodel.LGORT = SAPdata.ET_TTXX[i].LGORT;
                    TTmodel.WADAT_IST = SAPdata.ET_TTXX[i].WADAT_IST;
                    TTmodel.XGR = SAPdata.ET_TTXX[i].XGR;

                    int id = crmModels.BC_CHTT_FAKE.TTCreate(TTmodel, token);
                    if (id == 0)
                        return "出货抬头同步失败，请重试";
                }
                for (int i = 0; i < SAPdata.ET_HXMXX.Length; i++)      //行项目新增
                {
                    Sonluk.UI.Model.CRM.BC_CHTT_FAKEService.CRM_BC_CHMX MXmodel = new Sonluk.UI.Model.CRM.BC_CHTT_FAKEService.CRM_BC_CHMX();
                    MXmodel.VBELN = SAPdata.ET_HXMXX[i].VBELN;
                    MXmodel.POSNR = SAPdata.ET_HXMXX[i].POSNR;
                    MXmodel.TPM = SAPdata.ET_HXMXX[i].TPM;
                    MXmodel.DXM = SAPdata.ET_HXMXX[i].DXM;
                    MXmodel.NHM = SAPdata.ET_HXMXX[i].NHM;
                    MXmodel.CHARG = SAPdata.ET_HXMXX[i].CHARG;
                    MXmodel.LWEDT = SAPdata.ET_HXMXX[i].LWEDT;
                    MXmodel.QXBS = SAPdata.ET_HXMXX[i].QXBS;

                    int id = crmModels.BC_CHTT_FAKE.MXCreate(MXmodel, token);
                    if (id == 0)
                        return "出货行项目同步失败，请重试";
                }

                int error = crmModels.BC_CHTT.Modify(token);      //数据更新

                if (error == 0)
                    return "同步完成";
                else
                    return "同步失败，请重试";
            }
            catch (Exception e)
            {
                return e.Message;
            }


        }

        [HttpPost]
        public string Data_SelectMATNRbyCP(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_BC_PMLIST model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_BC_PMLIST>(cxdata);
            model.PM = model.PM.ToUpper();
            CRM_BC_PMLIST[] data = crmModels.BC_PMLIST.SelectMATNRbyCHARGandPM(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_SelectKHbyMCP(string cxdata)         //根据Matnr、Charg、喷码找到发给哪个客户
        {
            token = appClass.CRM_Gettoken();
            CRM_BC_PMLIST model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_BC_PMLIST>(cxdata);
            model.PM = model.PM.ToUpper();
            CRM_BC_KH[] data = crmModels.BC_PMLIST.SelectKHbyMCP(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_SelectKHbyDXM(string cxdata)      //根据大箱码找到发给哪个客户
        {
            token = appClass.CRM_Gettoken();
            CRM_BC_PMLIST model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_BC_PMLIST>(cxdata);
            CRM_BC_KH[] data = crmModels.BC_PMLIST.SelectKHbyDXM(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_SelectKHbyNHM(string cxdata)      //根据内盒码找到发给哪个客户
        {
            token = appClass.CRM_Gettoken();
            Sonluk.UI.Model.CRM.BC_PMLISTService.CRM_BC_CHMX model = Newtonsoft.Json.JsonConvert.DeserializeObject<Sonluk.UI.Model.CRM.BC_PMLISTService.CRM_BC_CHMX>(cxdata);
            CRM_BC_KH[] data = crmModels.BC_PMLIST.SelectKHbyNHM(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }




        [HttpPost]
        public string Data_TongBuSAPCH_ByKH()              //更新今天某客户的发货数据
        {
            token = appClass.CRM_Gettoken();
            WebMSG msg = new WebMSG();
            //return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            int staffid = appClass.CRM_GetStaffid();
            CRM_KH_KHList[] KHdata = crmModels.KH_KH.ReadBySTAFFID(appClass.CRM_GetStaffid(), token);
            if (KHdata.Length == 0)
            {
                msg.KEY = 1;
                msg.MSG = "没有需要同步的客户";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }

            //CRM_KH_KHList[] KHdata = new CRM_KH_KHList[1];
            //KHdata[0] = new CRM_KH_KHList();
            //KHdata[0].SAPSN = "100016";


            MODEL_ZBCFUN_DLV_GET SAPdata = crmModels.BarCode.GET_ZBCFUN_DLV_GET2(Newtonsoft.Json.JsonConvert.SerializeObject(KHdata), token);        //获取SAP数据
            if (SAPdata.ET_TTXX.Length == 0)
            {
                msg.KEY = 1;
                msg.MSG = "没有需要同步的信息";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
            int delete = crmModels.BC_CHTT_FAKE.TTMXDelete(token);        //把FAKE表的数据清光
            if (delete != 0)
            {
                msg.KEY = 0;
                msg.MSG = "出货抬头同步发生异常，请重试";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
            for (int i = 0; i < SAPdata.ET_TTXX.Length; i++)       //抬头新增
            {
                CRM_BC_CHTT TTmodel = new CRM_BC_CHTT();
                TTmodel.VBELN = SAPdata.ET_TTXX[i].VBELN;
                TTmodel.WERKS = SAPdata.ET_TTXX[i].WERKS;
                TTmodel.POSNR = SAPdata.ET_TTXX[i].POSNR;
                TTmodel.MATNR = SAPdata.ET_TTXX[i].MATNR;
                TTmodel.KUNAG = SAPdata.ET_TTXX[i].KUNAG;
                TTmodel.LGORT = SAPdata.ET_TTXX[i].LGORT;
                TTmodel.WADAT_IST = SAPdata.ET_TTXX[i].WADAT_IST;
                TTmodel.XGR = SAPdata.ET_TTXX[i].XGR;

                int id = crmModels.BC_CHTT_FAKE.TTCreate(TTmodel, token);
                if (id == 0)
                {
                    msg.KEY = 0;
                    msg.MSG = "出货抬头同步失败，请重试";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }
            }
            for (int i = 0; i < SAPdata.ET_HXMXX.Length; i++)      //行项目新增
            {
                Sonluk.UI.Model.CRM.BC_CHTT_FAKEService.CRM_BC_CHMX MXmodel = new Sonluk.UI.Model.CRM.BC_CHTT_FAKEService.CRM_BC_CHMX();
                MXmodel.VBELN = SAPdata.ET_HXMXX[i].VBELN;
                MXmodel.POSNR = SAPdata.ET_HXMXX[i].POSNR;
                MXmodel.TPM = SAPdata.ET_HXMXX[i].TPM;
                MXmodel.DXM = SAPdata.ET_HXMXX[i].DXM;
                MXmodel.NHM = SAPdata.ET_HXMXX[i].NHM;
                MXmodel.CHARG = SAPdata.ET_HXMXX[i].CHARG;
                MXmodel.LWEDT = SAPdata.ET_HXMXX[i].LWEDT;
                MXmodel.QXBS = SAPdata.ET_HXMXX[i].QXBS;

                int id = crmModels.BC_CHTT_FAKE.MXCreate(MXmodel, token);
                if (id == 0)
                {
                    msg.KEY = 0;
                    msg.MSG = "出货行项目同步失败，请重试";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }
            }

            int error = crmModels.BC_CHTT.Modify(token);      //数据更新

            if (error == 0)
            {
                msg.KEY = 1;
                msg.MSG = "同步完成";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
            else
            {
                msg.KEY = 0;
                msg.MSG = "同步失败，请重试";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }


        }

        [HttpPost]
        public string Data_Verify_IfHaveKHRight(string CRMID)         //校验当前人员是否有该客户的操作权限
        {
            token = appClass.CRM_Gettoken();

            int count = crmModels.BC_FXCH.Verify_IfHaveKHRight(appClass.CRM_GetStaffid(), CRMID, token);
            if (count == 0)           //没有该客户的权限
            {
                WebMSG msg = new WebMSG();
                msg.KEY = 0;
                msg.MSG = "当前用户没有该客户的权限";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
            else               //有该客户的权限
            {
                CRM_Report_KHModel model = new CRM_Report_KHModel();
                model.CRMID = CRMID;
                model.ISACTIVE = 3;
                CRM_KH_KHList[] data = crmModels.KH_KH.Report(model, appClass.CRM_GetStaffid(), token);
                if (data.Length == 0)
                {
                    WebMSG msg = new WebMSG();
                    msg.KEY = 0;
                    msg.MSG = "找不到该客户";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }
                else
                {
                    return Newtonsoft.Json.JsonConvert.SerializeObject(data[0]);
                }

            }
        }

        [HttpPost]
        public string Data_VerifyBarCode(string barcode)
        {
            token = appClass.CRM_Gettoken();




            WebMSG msg = new WebMSG();

            DXM[] dxm = Newtonsoft.Json.JsonConvert.DeserializeObject<DXM[]>(barcode);






            //for (int i = 0; i < dxm.Length; i++)
            //{
            int i = dxm.Length - 1;
            if (dxm[i].Dxm.Length == 15)    //箱码
            {
                int count = crmModels.BC_FXCH.ReadCountByDXM(dxm[i].Dxm, "", token);
                if (count != 0)
                {
                    msg.KEY = 0;
                    msg.MSG = "该条码已经发货：" + dxm[i].Dxm;
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }

                Sonluk.UI.Model.CRM.BC_CHTTService.CRM_BC_CHMX[] MXdata = crmModels.BC_CHTT.SelectCHMXbyDXM(dxm[i].Dxm, "", token);
                if (MXdata.Length == 0)
                {
                    msg.KEY = 0;
                    msg.MSG = "找不到条码：" + dxm[i].Dxm;
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }


                //校验当前人员对应的客户有没有发这箱货的权限
                int a = crmModels.BC_FXCH.Verify_IfHaveCHRight(appClass.CRM_GetStaffid(), dxm[i].Dxm, "", token);
                if (a == 0)
                {
                    msg.KEY = 0;
                    msg.MSG = "当前人员的客户没有发这箱货的权限：" + dxm[i].Dxm;
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }

            }
            else if (dxm[i].Dxm.Length == 12)    //托码
            {
                int count = crmModels.BC_FXCH.ReadCountByDXM("", dxm[i].Dxm, token);
                if (count != 0)
                {
                    msg.KEY = 0;
                    msg.MSG = "该条码已经发货：" + dxm[i].Dxm;
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }

                Sonluk.UI.Model.CRM.BC_CHTTService.CRM_BC_CHMX[] MXdata = crmModels.BC_CHTT.SelectCHMXbyDXM("", dxm[i].Dxm, token);
                if (MXdata.Length == 0)
                {
                    msg.KEY = 0;
                    msg.MSG = "找不到条码：" + dxm[i].Dxm;
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }

                //校验当前人员对应的客户有没有发这箱货的权限
                int a = crmModels.BC_FXCH.Verify_IfHaveCHRight(appClass.CRM_GetStaffid(), "", dxm[i].Dxm, token);
                if (a == 0)
                {
                    msg.KEY = 0;
                    msg.MSG = "当前人员的客户没有发这托货的权限：" + dxm[i].Dxm;
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }
            }






            //}
            msg.KEY = 1;
            msg.MSG = "没有重复";
            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
        }


        [HttpPost]
        public string Data_VerifyBarCode_FX(string barcode)
        {
            token = appClass.CRM_Gettoken();




            WebMSG msg = new WebMSG();

            DXM[] dxm = Newtonsoft.Json.JsonConvert.DeserializeObject<DXM[]>(barcode);






            //for (int i = 0; i < dxm.Length; i++)
            //{
            int i = dxm.Length - 1;
            if (dxm[i].Dxm.Length == 15)    //箱码
            {
                //int count = crmModels.BC_FXCH.ReadCountByDXM(dxm[i].Dxm, "", token);
                //if (count != 0)
                //{
                //    msg.KEY = 0;
                //    msg.MSG = "该条码已经发货：" + dxm[i].Dxm;
                //    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                //}

                Sonluk.UI.Model.CRM.BC_CHTTService.CRM_BC_CHMX[] MXdata = crmModels.BC_CHTT.SelectCHMXbyDXM(dxm[i].Dxm, "", token);
                if (MXdata.Length == 0)
                {
                    msg.KEY = 0;
                    msg.MSG = "找不到条码：" + dxm[i].Dxm;
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }


                //校验当前人员对应的客户有没有发这箱货的权限
                int a = crmModels.BC_FXCH.Verify_IfHaveCHRight(appClass.CRM_GetStaffid(), dxm[i].Dxm, "", token);
                if (a == 0)
                {
                    msg.KEY = 0;
                    msg.MSG = "当前人员的客户没有发这箱货的权限：" + dxm[i].Dxm;
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }

            }
            else if (dxm[i].Dxm.Length == 12)    //托码
            {
                //int count = crmModels.BC_FXCH.ReadCountByDXM("", dxm[i].Dxm, token);
                //if (count != 0)
                //{
                //    msg.KEY = 0;
                //    msg.MSG = "该条码已经发货：" + dxm[i].Dxm;
                //    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                //}

                Sonluk.UI.Model.CRM.BC_CHTTService.CRM_BC_CHMX[] MXdata = crmModels.BC_CHTT.SelectCHMXbyDXM("", dxm[i].Dxm, token);
                if (MXdata.Length == 0)
                {
                    msg.KEY = 0;
                    msg.MSG = "找不到条码：" + dxm[i].Dxm;
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }

                //校验当前人员对应的客户有没有发这箱货的权限
                int a = crmModels.BC_FXCH.Verify_IfHaveCHRight(appClass.CRM_GetStaffid(), "", dxm[i].Dxm, token);
                if (a == 0)
                {
                    msg.KEY = 0;
                    msg.MSG = "当前人员的客户没有发这托货的权限：" + dxm[i].Dxm;
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }
            }






            //}
            msg.KEY = 1;
            msg.MSG = "没有重复";
            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
        }


        [HttpPost]
        public string Data_Insert_FXCH(string DXM, string CRMID)
        {
            token = appClass.CRM_Gettoken();




            WebMSG msg = new WebMSG();

            DXM[] dxm = Newtonsoft.Json.JsonConvert.DeserializeObject<DXM[]>(DXM);


            //把扫进来的码统一转换成内盒码，然后看看有没有重复的码
            List<DXM> result = new List<DXM>();
            for (int i = 0; i < dxm.Length; i++)
            {
                if (dxm[i].Dxm.Length == 12)    //托码
                {
                    Sonluk.UI.Model.CRM.BC_CHTTService.CRM_BC_CHMX model = new Sonluk.UI.Model.CRM.BC_CHTTService.CRM_BC_CHMX();
                    model.TPM = dxm[i].Dxm;
                    Sonluk.UI.Model.CRM.BC_CHTTService.CRM_BC_CHMX[] MXdata = crmModels.BC_CHTT.ReadMXbyParam(model, token);
                    for (int j = 0; j < MXdata.Length; j++)
                    {
                        //result[result.Count] = new DXM();
                        DXM temp = new DXM();
                        temp.Dxm = MXdata[j].NHM;
                        result.Add(temp);
                    }
                }
                else if (dxm[i].Dxm.Length == 15)    //箱码
                {
                    Sonluk.UI.Model.CRM.BC_CHTTService.CRM_BC_CHMX model = new Sonluk.UI.Model.CRM.BC_CHTTService.CRM_BC_CHMX();
                    model.DXM = dxm[i].Dxm;
                    Sonluk.UI.Model.CRM.BC_CHTTService.CRM_BC_CHMX[] MXdata = crmModels.BC_CHTT.ReadMXbyParam(model, token);
                    for (int j = 0; j < MXdata.Length; j++)
                    {
                        //result[result.Count] = new DXM();
                        //result[result.Count].Dxm = MXdata[j].NHM;
                        DXM temp = new DXM();
                        temp.Dxm = MXdata[j].NHM;
                        result.Add(temp);
                    }
                }
                else
                {
                    //result[result.Count] = new DXM();
                    //result[result.Count].Dxm = dxm[i].Dxm;
                    DXM temp = new DXM();
                    temp.Dxm = dxm[i].Dxm;
                    result.Add(temp);
                }
            }

            List<DXM> checkdata = result.Distinct(new DXM.TravelTrafficInfoComparer()).ToList();
            if (result.Count != checkdata.Count)
            {
                msg.KEY = 0;
                msg.MSG = "请勿重复输入";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }



            for (int i = 0; i < dxm.Length; i++)
            {
                if (dxm[i].Dxm.Length == 15)    //箱码
                {
                    int count = crmModels.BC_FXCH.ReadCountByDXM(dxm[i].Dxm, "", token);
                    if (count != 0)
                    {
                        msg.KEY = 0;
                        msg.MSG = "该条码已经发货：" + dxm[i].Dxm;
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }

                    Sonluk.UI.Model.CRM.BC_CHTTService.CRM_BC_CHMX[] MXdata = crmModels.BC_CHTT.SelectCHMXbyDXM(dxm[i].Dxm, "", token);
                    if (MXdata.Length == 0)
                    {
                        msg.KEY = 0;
                        msg.MSG = "找不到条码：" + dxm[i].Dxm;
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }


                    //校验当前人员对应的客户有没有发这箱货的权限
                    int a = crmModels.BC_FXCH.Verify_IfHaveCHRight(appClass.CRM_GetStaffid(), dxm[i].Dxm, "", token);
                    if (a == 0)
                    {
                        msg.KEY = 0;
                        msg.MSG = "当前人员的客户没有发这箱货的权限：" + dxm[i].Dxm;
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }

                }
                else if (dxm[i].Dxm.Length == 12)    //托码
                {
                    int count = crmModels.BC_FXCH.ReadCountByDXM("", dxm[i].Dxm, token);
                    if (count != 0)
                    {
                        msg.KEY = 0;
                        msg.MSG = "该条码已经发货：" + dxm[i].Dxm;
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }

                    Sonluk.UI.Model.CRM.BC_CHTTService.CRM_BC_CHMX[] MXdata = crmModels.BC_CHTT.SelectCHMXbyDXM("", dxm[i].Dxm, token);
                    if (MXdata.Length == 0)
                    {
                        msg.KEY = 0;
                        msg.MSG = "找不到条码：" + dxm[i].Dxm;
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }

                    //校验当前人员对应的客户有没有发这箱货的权限
                    int a = crmModels.BC_FXCH.Verify_IfHaveCHRight(appClass.CRM_GetStaffid(), "", dxm[i].Dxm, token);
                    if (a == 0)
                    {
                        msg.KEY = 0;
                        msg.MSG = "当前人员的客户没有发这箱货的权限：" + dxm[i].Dxm;
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                }


                int samecount = 0;
                for (int j = 0; j < dxm.Length; j++)
                {
                    if (dxm[i].Dxm == dxm[j].Dxm)
                    {
                        samecount++;
                    }
                }
                if (samecount > 1)
                {
                    msg.KEY = 0;
                    msg.MSG = "该条码重复：" + dxm[i].Dxm;
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }



            }


            CRM_BC_FXCHTT TTmodel = new CRM_BC_FXCHTT();
            CRM_KH_KH KHmodel = crmModels.KH_KH.ReadByCRMID(CRMID, token);
            TTmodel.KHID = KHmodel.KHID;
            TTmodel.SDFID = crmModels.KH_KH.ReadByCRMID(KHmodel.PKHID.ToString(), token).KHID;
            TTmodel.BEIZ = "";
            TTmodel.CJR = appClass.CRM_GetStaffid();
            int TTid = crmModels.BC_FXCH.TTCreate(TTmodel, token);
            if (TTid == 0)
            {
                msg.KEY = 0;
                msg.MSG = "保存失败";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
            for (int j = 0; j < dxm.Length; j++)
            {
                Sonluk.UI.Model.CRM.BC_CHTTService.CRM_BC_CHMX[] MXdata = null;

                if (dxm[j].Dxm.Length == 15)       //箱码
                {
                    MXdata = crmModels.BC_CHTT.SelectCHMXbyDXM(dxm[j].Dxm, "", token);
                }
                else if (dxm[j].Dxm.Length == 12)     //托码
                {
                    MXdata = crmModels.BC_CHTT.SelectCHMXbyDXM("", dxm[j].Dxm, token);
                }




                for (int i = 0; i < MXdata.Length; i++)
                {
                    CRM_BC_FXCHMX MXmodel = new CRM_BC_FXCHMX();
                    MXmodel.FXCHTTID = TTid;
                    MXmodel.TPM = MXdata[i].TPM;
                    MXmodel.DXM = MXdata[i].DXM;
                    MXmodel.NHM = MXdata[i].NHM;
                    MXmodel.CHARG = MXdata[i].CHARG;
                    MXmodel.LWEDT = MXdata[i].LWEDT;
                    int MXid = crmModels.BC_FXCH.MXCreate(MXmodel, token);
                    if (MXid == 0)
                    {
                        msg.KEY = 0;
                        msg.MSG = "保存失败,请联系管理员";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                }
            }
            msg.KEY = 1;
            msg.MSG = "保存成功";
            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
        }

        [HttpPost]
        public string Data_Insert_FXCH_FX(string TPM, string DXM, string CRMID)
        {
            token = appClass.CRM_Gettoken();
            WebMSG msg = new WebMSG();

            if (TPM.Length != 12)
            {
                msg.KEY = 0;
                msg.MSG = "托盘码格式错误";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
            //先看看这个托盘码在不在数据库里
            Sonluk.UI.Model.CRM.BC_CHTTService.CRM_BC_CHMX[] model = crmModels.BC_CHTT.ReadDXMbyTPM(TPM, token);           //这个model是根据传进来的托码在发货表里面找到的数据
            if (model.Length == 0)
            {
                msg.KEY = 0;
                msg.MSG = "找不到托盘码";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }

            DXM[] dxm = Newtonsoft.Json.JsonConvert.DeserializeObject<DXM[]>(DXM);

            //把扫进来的码统一转换成内盒码，然后看看有没有重复的码
            List<DXM> result = new List<DXM>();
            for (int i = 0; i < dxm.Length; i++)
            {
                if (dxm[i].Dxm.Length != 15)
                {
                    msg.KEY = 0;
                    msg.MSG = "箱码格式错误";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }
                Sonluk.UI.Model.CRM.BC_CHTTService.CRM_BC_CHMX modeltmp = new Sonluk.UI.Model.CRM.BC_CHTTService.CRM_BC_CHMX();
                modeltmp.DXM = dxm[i].Dxm;
                Sonluk.UI.Model.CRM.BC_CHTTService.CRM_BC_CHMX[] MXdata = crmModels.BC_CHTT.ReadMXbyParam(modeltmp, token);
                for (int j = 0; j < MXdata.Length; j++)
                {
                    //result[result.Count] = new DXM();
                    //result[result.Count].Dxm = MXdata[j].NHM;
                    DXM temp = new DXM();
                    temp.Dxm = MXdata[j].NHM;
                    result.Add(temp);
                }

            }

            List<DXM> checkdata = result.Distinct(new DXM.TravelTrafficInfoComparer()).ToList();
            if (result.Count != checkdata.Count)
            {
                msg.KEY = 0;
                msg.MSG = "请勿重复输入";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }



            for (int i = 0; i < dxm.Length; i++)
            {

                //int count = crmModels.BC_FXCH.ReadCountByDXM(dxm[i].Dxm, "", token);
                //if (count != 0)
                //{
                //    msg.KEY = 0;
                //    msg.MSG = "该条码已经发货：" + dxm[i].Dxm;
                //    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                //}

                Sonluk.UI.Model.CRM.BC_CHTTService.CRM_BC_CHMX[] MXdata = crmModels.BC_CHTT.SelectCHMXbyDXM(dxm[i].Dxm, "", token);
                if (MXdata.Length == 0)
                {
                    msg.KEY = 0;
                    msg.MSG = "找不到条码：" + dxm[i].Dxm;
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }


                //校验当前人员对应的客户有没有发这箱货的权限
                int a = crmModels.BC_FXCH.Verify_IfHaveCHRight(appClass.CRM_GetStaffid(), dxm[i].Dxm, "", token);
                if (a == 0)
                {
                    msg.KEY = 0;
                    msg.MSG = "当前人员的客户没有发这箱货的权限：" + dxm[i].Dxm;
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }





                int samecount = 0;
                for (int j = 0; j < dxm.Length; j++)
                {
                    if (dxm[i].Dxm == dxm[j].Dxm)
                    {
                        samecount++;
                    }
                }
                if (samecount > 1)
                {
                    msg.KEY = 0;
                    msg.MSG = "该条码重复：" + dxm[i].Dxm;
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }



            }




            CRM_BC_FXCHTT TTmodel = new CRM_BC_FXCHTT();
            CRM_KH_KH KHmodel = crmModels.KH_KH.ReadByCRMID(CRMID, token);
            TTmodel.KHID = KHmodel.KHID;
            TTmodel.SDFID = crmModels.KH_KH.ReadByCRMID(KHmodel.PKHID.ToString(), token).KHID;
            TTmodel.BEIZ = "";
            TTmodel.CJR = appClass.CRM_GetStaffid();
            int TTid = crmModels.BC_FXCH.TTCreate(TTmodel, token);
            if (TTid == 0)
            {
                msg.KEY = 0;
                msg.MSG = "保存失败";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
            for (int j = 0; j < model.Length; j++)
            {
                int count = 0;
                for (int i = 0; i < dxm.Length; i++)
                {
                    if (model[j].DXM == dxm[i].Dxm)
                    {
                        count++;
                    }
                }
                if (count > 0)
                {
                    continue;
                }
                Sonluk.UI.Model.CRM.BC_CHTTService.CRM_BC_CHMX[] MXdata = null;


                MXdata = crmModels.BC_CHTT.SelectCHMXbyDXM(model[j].DXM, "", token);





                for (int i = 0; i < MXdata.Length; i++)
                {
                    CRM_BC_FXCHMX MXmodel = new CRM_BC_FXCHMX();
                    MXmodel.FXCHTTID = TTid;
                    MXmodel.TPM = MXdata[i].TPM;
                    MXmodel.DXM = MXdata[i].DXM;
                    MXmodel.NHM = MXdata[i].NHM;
                    MXmodel.CHARG = MXdata[i].CHARG;
                    MXmodel.LWEDT = MXdata[i].LWEDT;
                    int MXid = crmModels.BC_FXCH.MXCreate(MXmodel, token);
                    if (MXid == 0)
                    {
                        msg.KEY = 0;
                        msg.MSG = "保存失败,请联系管理员";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                }
            }
            msg.KEY = 1;
            msg.MSG = "保存成功";
            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);


        }

        [HttpPost]
        public string Data_Select_FXCHTT(int FXCHTTID)
        {
            token = appClass.CRM_Gettoken();
            CRM_BC_FXCHTTList data = crmModels.BC_FXCH.ReadTTbyTTID(FXCHTTID, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Delete_FXCHTT(int FXCHTTID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.BC_FXCH.TTDelete(FXCHTTID, token);
            WebMSG msg = new WebMSG();
            if (i > 0)
            {
                msg.KEY = 1;
                msg.MSG = "删除成功！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
            else
            {
                msg.KEY = 0;
                msg.MSG = "删除失败！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
        }

        [HttpPost]
        public string Data_Insert_FXCHMX(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_BC_FXCHMX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_BC_FXCHMX>(data);
            int i = crmModels.BC_FXCH.MXCreate(model, token);
            WebMSG msg = new WebMSG();
            if (i > 0)
            {
                msg.KEY = 1;
                msg.MSG = "新增成功！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
            else
            {
                msg.KEY = 0;
                msg.MSG = "新增失败！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
        }

        [HttpPost]
        public string Data_Select_FXCHMX(int FXCHTTID)
        {
            token = appClass.CRM_Gettoken();
            CRM_BC_FXCHMX[] data = crmModels.BC_FXCH.ReadMXbyTTID(FXCHTTID, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Select_FXCHMXbyparam(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_BC_FXCHMX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_BC_FXCHMX>(cxdata);
            CRM_BC_FXCHMX[] data = crmModels.BC_FXCH.ReadMXbyParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Delete_FXCHMX(int FXCHMXID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.BC_FXCH.MXDelete(FXCHMXID, token);
            WebMSG msg = new WebMSG();
            if (i > 0)
            {
                msg.KEY = 1;
                msg.MSG = "删除成功！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
            else
            {
                msg.KEY = 0;
                msg.MSG = "删除失败！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
        }

        [HttpPost]
        public string Data_Delete_FXCHMXbyDXM(string DXM)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.BC_FXCH.MXDeleteByDXM(DXM, token);
            WebMSG msg = new WebMSG();
            if (i > 0)
            {
                msg.KEY = 1;
                msg.MSG = "删除成功！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
            else
            {
                msg.KEY = 0;
                msg.MSG = "删除失败！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
        }


        [HttpPost]
        public string Data_Select_FXCH_CX(string cxdata)
        {
            token = appClass.CRM_Gettoken();

            CRM_BC_FXCHParam model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_BC_FXCHParam>(cxdata);
            model.STAFFID = appClass.CRM_GetStaffid();
            CRM_BC_FXCHTTList[] data = crmModels.BC_FXCH.ReadTTbyParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Select_FXCHreport(string barcode)
        {
            token = appClass.CRM_Gettoken();
            CRM_BC_FXCHParam model = new CRM_BC_FXCHParam();
            model.Barcode = barcode;
            CRM_BC_FXCHTTList[] data = crmModels.BC_FXCH.Report(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string JHD_READ(string VBELN)
        {
            token = appClass.CRM_Gettoken();
            MODEL_ZBCFUN_JHD_READ data = crmModels.BarCode.JHD_READ(VBELN, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string JHD_UPDATE(string data)
        {
            token = appClass.CRM_Gettoken();
            ZSL_BCT110[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<ZSL_BCT110[]>(data);
            MES_RETURN result = crmModels.BarCode.JHD_UPDATE(model, appClass.CRM_GetStaffid(), token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_CHTT_ReadMXByParam(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            Sonluk.UI.Model.CRM.BC_CHTTService.CRM_BC_CHMX cxmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<Sonluk.UI.Model.CRM.BC_CHTTService.CRM_BC_CHMX>(cxdata);
            Sonluk.UI.Model.CRM.BC_CHTTService.CRM_BC_CHMX[] data = crmModels.BC_CHTT.ReadMXbyParam(cxmodel, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Insert_FXCH_ZZK(string JHD)
        {
            token = appClass.CRM_Gettoken();
            WebMSG msg = new WebMSG();

            MODEL_ZBCFUN_JHD_READ JHDdata = Newtonsoft.Json.JsonConvert.DeserializeObject<MODEL_ZBCFUN_JHD_READ>(JHD);

            //把扫进来的码统一转换成内盒码，然后看看有没有重复的码

            for (int i = 0; i < JHDdata.ET_ItemData.Length; i++)
            {
                List<DXM> result = new List<DXM>();
                for (int j = 0; j < JHDdata.ET_ItemData[i].TM.Length; j++)
                {
                    if (JHDdata.ET_ItemData[i].TM[j].Barcode.Length == 12)    //托码
                    {
                        //展开成内盒码进行校验
                        Sonluk.UI.Model.CRM.BC_CHTTService.CRM_BC_CHMX model = new Sonluk.UI.Model.CRM.BC_CHTTService.CRM_BC_CHMX();
                        model.TPM = JHDdata.ET_ItemData[i].TM[j].Barcode;
                        model.KUNAG = JHDdata.ES_HeadData.ZZKGGKH;
                        Sonluk.UI.Model.CRM.BC_CHTTService.CRM_BC_CHMX[] MXdata = crmModels.BC_CHTT.ReadMXbyParam(model, token);
                        for (int k = 0; k < MXdata.Length; k++)
                        {
                            //result[result.Count] = new DXM();
                            DXM temp = new DXM();
                            temp.Dxm = MXdata[k].NHM;
                            result.Add(temp);
                        }

                        //看看是不是已经发货了的条码
                        CRM_BC_FXCHMX cxmodel = new CRM_BC_FXCHMX();
                        cxmodel.TPM = JHDdata.ET_ItemData[i].TM[j].Barcode;
                        CRM_BC_FXCHMX[] FHdata = crmModels.BC_FXCH.ReadMXbyParam(cxmodel, token);
                        if (FHdata.Length != 0)
                        {
                            msg.KEY = 0;
                            msg.MSG = JHDdata.ET_ItemData[i].POSNR + "行项目该物流码已发货：" + JHDdata.ET_ItemData[i].TM[j].Barcode;
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }

                    }
                    else if (JHDdata.ET_ItemData[i].TM[j].Barcode.Length == 15)    //箱码
                    {
                        Sonluk.UI.Model.CRM.BC_CHTTService.CRM_BC_CHMX model = new Sonluk.UI.Model.CRM.BC_CHTTService.CRM_BC_CHMX();
                        model.DXM = JHDdata.ET_ItemData[i].TM[j].Barcode;
                        model.KUNAG = JHDdata.ES_HeadData.ZZKGGKH;
                        Sonluk.UI.Model.CRM.BC_CHTTService.CRM_BC_CHMX[] MXdata = crmModels.BC_CHTT.ReadMXbyParam(model, token);
                        for (int k = 0; k < MXdata.Length; k++)
                        {
                            //result[result.Count] = new DXM();
                            DXM temp = new DXM();
                            temp.Dxm = MXdata[k].NHM;
                            result.Add(temp);
                        }

                        //看看是不是已经发货了的条码
                        CRM_BC_FXCHMX cxmodel = new CRM_BC_FXCHMX();
                        cxmodel.DXM = JHDdata.ET_ItemData[i].TM[j].Barcode;
                        CRM_BC_FXCHMX[] FHdata = crmModels.BC_FXCH.ReadMXbyParam(cxmodel, token);
                        if (FHdata.Length != 0)
                        {
                            msg.KEY = 0;
                            msg.MSG = JHDdata.ET_ItemData[i].POSNR + "行项目该物流码已发货：" + JHDdata.ET_ItemData[i].TM[j].Barcode;
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                    }
                    else if (JHDdata.ET_ItemData[i].TM[j].Barcode.Length == 18)    //内盒码
                    {
                        DXM temp = new DXM();
                        temp.Dxm = JHDdata.ET_ItemData[i].TM[j].Barcode;
                        result.Add(temp);

                        //看看是不是已经发货了的条码
                        CRM_BC_FXCHMX cxmodel = new CRM_BC_FXCHMX();
                        cxmodel.NHM = JHDdata.ET_ItemData[i].TM[j].Barcode;
                        CRM_BC_FXCHMX[] FHdata = crmModels.BC_FXCH.ReadMXbyParam(cxmodel, token);
                        if (FHdata.Length != 0)
                        {
                            msg.KEY = 0;
                            msg.MSG = JHDdata.ET_ItemData[i].POSNR + "行项目该物流码已发货：" + JHDdata.ET_ItemData[i].TM[j].Barcode;
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                    }


                }
                List<DXM> checkdata = result.Distinct(new DXM.TravelTrafficInfoComparer()).ToList();
                if (result.Count != checkdata.Count)
                {
                    msg.KEY = 0;
                    msg.MSG = JHDdata.ET_ItemData[i].POSNR + "行项目的物流码重复";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }
            }



            List<ZSL_BCT110> RFCmodel = new List<ZSL_BCT110>();

            for (int i = 0; i < JHDdata.ET_ItemData.Length; i++)
            {
                for (int j = 0; j < JHDdata.ET_ItemData[i].TM.Length; j++)
                {
                    Sonluk.UI.Model.CRM.BC_CHTTService.CRM_BC_CHMX[] MXdata = null;
                    if (JHDdata.ET_ItemData[i].TM[j].Barcode.Length == 12)    //托码
                    {
                        Sonluk.UI.Model.CRM.BC_CHTTService.CRM_BC_CHMX model = new Sonluk.UI.Model.CRM.BC_CHTTService.CRM_BC_CHMX();
                        model.TPM = JHDdata.ET_ItemData[i].TM[j].Barcode;
                        model.KUNAG = JHDdata.ES_HeadData.ZZKGGKH;
                        MXdata = crmModels.BC_CHTT.ReadMXbyParam(model, token);
                    }
                    else if (JHDdata.ET_ItemData[i].TM[j].Barcode.Length == 15)    //箱码
                    {
                        Sonluk.UI.Model.CRM.BC_CHTTService.CRM_BC_CHMX model = new Sonluk.UI.Model.CRM.BC_CHTTService.CRM_BC_CHMX();
                        model.DXM = JHDdata.ET_ItemData[i].TM[j].Barcode;
                        model.KUNAG = JHDdata.ES_HeadData.ZZKGGKH;
                        MXdata = crmModels.BC_CHTT.ReadMXbyParam(model, token);
                    }
                    else if (JHDdata.ET_ItemData[i].TM[j].Barcode.Length == 18)    //内盒码
                    {
                        Sonluk.UI.Model.CRM.BC_CHTTService.CRM_BC_CHMX model = new Sonluk.UI.Model.CRM.BC_CHTTService.CRM_BC_CHMX();
                        model.NHM = JHDdata.ET_ItemData[i].TM[j].Barcode;
                        model.KUNAG = JHDdata.ES_HeadData.ZZKGGKH;
                        MXdata = crmModels.BC_CHTT.ReadMXbyParam(model, token);
                    }
                    else
                    {
                        MXdata = new UI.Model.CRM.BC_CHTTService.CRM_BC_CHMX[0];
                    }

                    for (int k = 0; k < MXdata.Length; k++)
                    {
                        ZSL_BCT110 temp = new ZSL_BCT110();
                        temp.VBELN = MXdata[k].VBELN;
                        temp.POSNR = MXdata[k].POSNR;
                        temp.NHM = MXdata[k].NHM;
                        temp.DXM = MXdata[k].DXM;
                        temp.TPM = MXdata[k].TPM;
                        temp.VBELNN = JHDdata.ET_ItemData[i].VBELN;
                        temp.POSNRN = JHDdata.ET_ItemData[i].POSNR;
                        temp.MATNR = JHDdata.ET_ItemData[i].MATNR;
                        temp.KUNAG = JHDdata.ES_HeadData.KUNAG;
                        temp.LGORT = JHDdata.ET_ItemData[i].LGORT;
                        temp.WERKS = JHDdata.ET_ItemData[i].WERKS;
                        RFCmodel.Add(temp);

                    }



                }

            }
            //调用过账接口
            MES_RETURN RFCresult = crmModels.BarCode.JHD_UPDATE(RFCmodel.ToArray(), appClass.CRM_GetStaffid(), token);
            if (RFCresult.TYPE == "E")
            {
                msg.KEY = 0;
                msg.MSG = RFCresult.MESSAGE;
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }



            CRM_BC_FXCHTT TTmodel = new CRM_BC_FXCHTT();
            CRM_KH_KH KHmodel = crmModels.KH_KH.ReadBySAPSN(JHDdata.ES_HeadData.KUNAG.TrimStart('0'), token);
            TTmodel.KHID = KHmodel.KHID;
            TTmodel.SDFID = crmModels.KH_KH.ReadByCRMID(KHmodel.PKHID.ToString(), token).KHID;
            TTmodel.KUNAG = JHDdata.ES_HeadData.KUNAG;
            TTmodel.NAMEG = JHDdata.ES_HeadData.NAMEG;
            TTmodel.VBELN = JHDdata.ES_HeadData.VBELN;
            TTmodel.ZZKGGKH = JHDdata.ES_HeadData.ZZKGGKH;
            TTmodel.BEIZ = "";
            TTmodel.CJR = appClass.CRM_GetStaffid();
            int TTid = crmModels.BC_FXCH.TTCreate(TTmodel, token);
            if (TTid == 0)
            {
                msg.KEY = 0;
                msg.MSG = "保存失败";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }


            for (int i = 0; i < JHDdata.ET_ItemData.Length; i++)
            {
                for (int j = 0; j < JHDdata.ET_ItemData[i].TM.Length; j++)
                {
                    Sonluk.UI.Model.CRM.BC_CHTTService.CRM_BC_CHMX[] MXdata = null;
                    if (JHDdata.ET_ItemData[i].TM[j].Barcode.Length == 12)    //托码
                    {
                        Sonluk.UI.Model.CRM.BC_CHTTService.CRM_BC_CHMX model = new Sonluk.UI.Model.CRM.BC_CHTTService.CRM_BC_CHMX();
                        model.TPM = JHDdata.ET_ItemData[i].TM[j].Barcode;
                        model.KUNAG = JHDdata.ES_HeadData.ZZKGGKH;
                        MXdata = crmModels.BC_CHTT.ReadMXbyParam(model, token);
                    }
                    else if (JHDdata.ET_ItemData[i].TM[j].Barcode.Length == 15)    //箱码
                    {
                        Sonluk.UI.Model.CRM.BC_CHTTService.CRM_BC_CHMX model = new Sonluk.UI.Model.CRM.BC_CHTTService.CRM_BC_CHMX();
                        model.DXM = JHDdata.ET_ItemData[i].TM[j].Barcode;
                        model.KUNAG = JHDdata.ES_HeadData.ZZKGGKH;
                        MXdata = crmModels.BC_CHTT.ReadMXbyParam(model, token);
                    }
                    else if (JHDdata.ET_ItemData[i].TM[j].Barcode.Length == 18)    //内盒码
                    {
                        Sonluk.UI.Model.CRM.BC_CHTTService.CRM_BC_CHMX model = new Sonluk.UI.Model.CRM.BC_CHTTService.CRM_BC_CHMX();
                        model.NHM = JHDdata.ET_ItemData[i].TM[j].Barcode;
                        model.KUNAG = JHDdata.ES_HeadData.ZZKGGKH;
                        MXdata = crmModels.BC_CHTT.ReadMXbyParam(model, token);
                    }
                    else
                    {
                        MXdata = new UI.Model.CRM.BC_CHTTService.CRM_BC_CHMX[0];
                    }

                    for (int k = 0; k < MXdata.Length; k++)
                    {
                        CRM_BC_FXCHMX MXmodel = new CRM_BC_FXCHMX();
                        MXmodel.FXCHTTID = TTid;
                        MXmodel.TPM = MXdata[k].TPM;
                        MXmodel.DXM = MXdata[k].DXM;
                        MXmodel.NHM = MXdata[k].NHM;
                        MXmodel.CHARG = MXdata[k].CHARG;
                        MXmodel.LWEDT = MXdata[k].LWEDT;
                        MXmodel.VBELN = JHDdata.ET_ItemData[i].VBELN;
                        MXmodel.POSNR = JHDdata.ET_ItemData[i].POSNR;
                        MXmodel.MATNR = JHDdata.ET_ItemData[i].MATNR;
                        MXmodel.MAKTX = JHDdata.ET_ItemData[i].MAKTX;
                        int MXid = crmModels.BC_FXCH.MXCreate(MXmodel, token);
                        if (MXid == 0)
                        {
                            msg.KEY = 0;
                            msg.MSG = "保存失败,请联系管理员";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                    }



                }

            }



            msg.KEY = 1;
            msg.MSG = "登记成功";
            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
        }

        [HttpPost]
        public string JHZ_READ(string MATNR, int amount)
        {
            token = appClass.CRM_Gettoken();
            MODEL_ZBCFUN_JHZ_READ model = new MODEL_ZBCFUN_JHZ_READ();
            model.IV_MATNR = MATNR;
            model.IV_SL = amount;
            MODEL_ZBCFUN_JHZ_READ JHZdata = crmModels.BarCode.JHZ_READ(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(JHZdata);
        }




    }
}
