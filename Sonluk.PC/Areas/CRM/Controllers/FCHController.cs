using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sonluk.PC.APPCLASS;
using Sonluk.PC.Models;
using Sonluk.UI.Model.CRM.BC_PMLISTService;
using Sonluk.UI.Model.MES.PD_GDService;
using Sonluk.UI.Model.BC.BarCodeService;

namespace Sonluk.PC.Areas.CRM.Controllers
{
    public class FCHController : Controller
    {
        //
        // GET: /CRM/FCH/
        CRMModels crmModels = new CRMModels();
        AppClass appClass = new AppClass();
        WebMSG webmsg = new WebMSG();
        string token = "";
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Insert_PM()
        {
            Session["location"] = 66;
            return View();
        }

        public ActionResult Select_PM()
        {
            Session["location"] = 67;
            return View();
        }

        public ActionResult Insert_PM_CG()
        {
            Session["location"] = 83;
            return View();
        }

        public ActionResult Select_PM_CG()
        {
            Session["location"] = 84;
            return View();
        }

        [HttpPost]
        public string Data_Insert_PM(string data, string isTuiHuo)
        {
            token = appClass.CRM_Gettoken();
            try
            {
                CRM_BC_PMLIST model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_BC_PMLIST>(data);
                model.CJR = appClass.CRM_GetStaffid();
                CRM_BC_PMLISTList[] xianyouData = crmModels.BC_PMLIST.SelectByGD(model.AUFNR, token);
                if (xianyouData.Length != 0)    //已经有该工单的数据
                {
                    if(xianyouData[0].CHARG != model.CHARG)
                    {
                        return "已存在该工单，且日期唛不一致";
                    }
                    if (xianyouData[0].PM == "" && xianyouData[xianyouData.Length - 1].PM == "")     //数据库里有该工单的信息，但箱码还未生成喷码
                    {
                        int error = crmModels.BC_PMLIST.UpdatePM(token);    //生成喷码
                        if (error != 0)
                        {
                            return "喷码生成失败，请重试";
                        }
                    }
                    else         //该工单的箱码已经生成了喷码
                    {
                        MODEL_ZBCFUN_TM_READ TMmodel = crmModels.BarCode.GET_ZBCFUN_TM_READ(model.AUFNR, "F", token);
                        if (TMmodel.ET_TM.Length == 0)
                            return "该工单没有所属箱码";

                        List<ZSL_BCT100> ET_TM = TMmodel.ET_TM.ToList();
                        //ET_TM = (from o in ET_TM orderby (o.DXM.Substring(2,o.DXM.Length-2)) select o).ToList();
                        ET_TM = ET_TM.OrderBy(u => u.TPM.Substring(2, u.TPM.Length - 2)).ThenBy(u => u.DXM.Substring(2, u.DXM.Length - 2)).ToList();

                        string PM = "";
                        if (isTuiHuo == "1")       //如果是退货的话喷码统一为ZAA
                            PM = "ZAA";
                        string TPM_temp = "";
                        int isexist = 0;       //变成1表示当前行是这回刚增进去的，所以其对应的托码整个都要增进去
                        for (int x = 0; x < ET_TM.Count; x++)                //按箱码进行循环
                        {
                            CRM_BC_PMLIST cxmodel = new CRM_BC_PMLIST();
                            if (ET_TM[x].TPM != TPM_temp)                   //当托码变化时，去数据库看下这个托码是否已经存在
                            {
                                isexist = 0;
                                cxmodel.AUFNR = model.AUFNR;
                                cxmodel.TPM = ET_TM[x].TPM;
                                cxmodel.PMTYPE = 1;
                                CRM_BC_PMLIST[] cxresult = crmModels.BC_PMLIST.SelectByModel(cxmodel, "", "", token);
                                if (cxresult.Length != 0 && isexist == 0)          //已经有这个托码了，就跳过
                                {
                                    continue;
                                }
                                else          //这个托码还没生成喷码
                                {
                                    isexist = 1;
                                    model.DXM = ET_TM[x].DXM;
                                    model.TPM = ET_TM[x].TPM;

                                    model.PM = PM;
                                    model.PMTYPE = 1;   //根据工单
                                    int i = crmModels.BC_PMLIST.Create(model, token);
                                    if (i <= 0)
                                    {
                                        return "生成失败！";
                                    }
                                }
                            }
                            else
                            {
                                if (isexist == 1)
                                {
                                    model.DXM = ET_TM[x].DXM;
                                    model.TPM = ET_TM[x].TPM;

                                    model.PM = PM;
                                    model.PMTYPE = 1;   //根据工单
                                    int i = crmModels.BC_PMLIST.Create(model, token);
                                    if (i <= 0)
                                    {
                                        return "生成失败！";
                                    }
                                }
                                else
                                    continue;
                            }

                            TPM_temp = ET_TM[x].TPM;
                        }
                    }
                }
                else        //数据库里没有该工单的数据
                {
                    MODEL_ZBCFUN_TM_READ TMmodel = crmModels.BarCode.GET_ZBCFUN_TM_READ(model.AUFNR, "F", token);
                    if (TMmodel.ET_TM.Length == 0)
                        return "该工单没有所属箱码";

                    List<ZSL_BCT100> ET_TM = TMmodel.ET_TM.ToList();
                    //ET_TM = (from o in ET_TM orderby (o.DXM.Substring(2,o.DXM.Length-2)) select o).ToList();
                    ET_TM = ET_TM.OrderBy(u => u.TPM.Substring(2, u.TPM.Length - 2)).ThenBy(u => u.DXM.Substring(2, u.DXM.Length - 2)).ToList();

                    string PM = "";
                    if (isTuiHuo == "1")       //如果是退货的话喷码统一为ZAA
                        PM = "ZAA";
                    for (int x = 0; x < ET_TM.Count; x++)
                    {
                        model.DXM = ET_TM[x].DXM;
                        model.TPM = ET_TM[x].TPM;

                        model.PM = PM;
                        model.PMTYPE = 1;   //根据工单
                        int i = crmModels.BC_PMLIST.Create(model, token);
                        if (i <= 0)
                        {
                            return "生成失败！";
                        }
                    }
                    //if (isTuiHuo == "0")       //不是退货的话需要生成喷码
                    //{
                    //    int error = crmModels.BC_PMLIST.UpdatePM(token);    //生成喷码
                    //    if (error != 0)
                    //    {
                    //        return "喷码生成失败，请重试";
                    //    }
                    //}

                }


            }
            catch (Exception e)
            {
                return e.Message;
            }


            return "生成成功！";
        }

        [HttpPost]
        public string Data_Insert_PM_CG(string data, string isTuiHuo)
        {
            token = appClass.CRM_Gettoken();
            try
            {
                CRM_BC_PMLIST model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_BC_PMLIST>(data);
                model.CJR = appClass.CRM_GetStaffid();
                CRM_BC_PMLISTList[] xianyouData = crmModels.BC_PMLIST.SelectByGD(model.AUFNR, token);
                if (xianyouData.Length != 0)    //已经有该采购订单的数据
                {
                    if(xianyouData[0].CHARG != model.CHARG)
                    {
                        return "已存在该工单，且日期唛不一致";
                    }
                    if (xianyouData[0].PM == "" && xianyouData[xianyouData.Length - 1].PM == "")     //数据库里有该采购订单的信息，但箱码还未生成喷码
                    {
                        int error = crmModels.BC_PMLIST.UpdatePM(token);    //生成喷码
                        if (error != 0)
                        {
                            return "喷码生成失败，请重试";
                        }
                    }
                    else         //该采购订单的箱码已经生成了喷码，当用户再次生码时，要跳过已经存在的，只生成数据库里没有的
                    {
                        MODEL_ZBCFUN_TM_READ TMmodel = crmModels.BarCode.GET_ZBCFUN_TM_READ(model.AUFNR, "B", token);
                        if (TMmodel.ET_TM.Length == 0)
                            return "该采购订单没有所属箱码";

                        List<ZSL_BCT100> ET_TM = TMmodel.ET_TM.ToList();
                        //ET_TM = (from o in ET_TM orderby (o.DXM.Substring(2,o.DXM.Length-2)) select o).ToList();
                        ET_TM = ET_TM.OrderBy(u => u.TPM.Substring(2, u.TPM.Length - 2)).ThenBy(u => u.DXM.Substring(2, u.DXM.Length - 2)).ToList();

                        string PM = "";
                        if (isTuiHuo == "1")       //如果是退货的话喷码统一为ZAA
                            PM = "ZAA";
                        string TPM_temp = "";
                        int isexist = 0;       //变成1表示当前行是这回刚增进去的，所以其对应的托码整个都要增进去
                        for (int x = 0; x < ET_TM.Count; x++)                //按箱码进行循环
                        {
                            CRM_BC_PMLIST cxmodel = new CRM_BC_PMLIST();
                            if (ET_TM[x].TPM != TPM_temp)                   //当托码变化时，去数据库看下这个托码是否已经存在
                            {
                                isexist = 0;
                                cxmodel.AUFNR = model.AUFNR;
                                cxmodel.TPM = ET_TM[x].TPM;
                                cxmodel.PMTYPE = 2;
                                CRM_BC_PMLIST[] cxresult = crmModels.BC_PMLIST.SelectByModel(cxmodel, "", "", token);
                                if (cxresult.Length != 0 && isexist == 0)          //已经有这个托码了，就跳过
                                {
                                    continue;
                                }
                                else          //这个托码还没生成喷码
                                {
                                    isexist = 1;
                                    model.DXM = ET_TM[x].DXM;
                                    model.TPM = ET_TM[x].TPM;

                                    model.PM = PM;
                                    model.PMTYPE = 2;   //根据采购订单
                                    int i = crmModels.BC_PMLIST.Create(model, token);
                                    if (i <= 0)
                                    {
                                        return "生成失败！";
                                    }
                                }
                            }
                            else
                            {
                                if (isexist == 1)
                                {
                                    model.DXM = ET_TM[x].DXM;
                                    model.TPM = ET_TM[x].TPM;

                                    model.PM = PM;
                                    model.PMTYPE = 2;   //根据采购订单
                                    int i = crmModels.BC_PMLIST.Create(model, token);
                                    if (i <= 0)
                                    {
                                        return "生成失败！";
                                    }
                                }
                                else
                                    continue;
                            }

                            TPM_temp = ET_TM[x].TPM;
                        }


                    }
                }
                else        //数据库里没有该采购订单的数据
                {
                    MODEL_ZBCFUN_TM_READ TMmodel = crmModels.BarCode.GET_ZBCFUN_TM_READ(model.AUFNR, "B", token);
                    if (TMmodel.ET_TM.Length == 0)
                        return "该采购订单没有所属箱码";

                    List<ZSL_BCT100> ET_TM = TMmodel.ET_TM.ToList();
                    //ET_TM = (from o in ET_TM orderby (o.DXM.Substring(2,o.DXM.Length-2)) select o).ToList();
                    ET_TM = ET_TM.OrderBy(u => u.TPM.Substring(2, u.TPM.Length - 2)).ThenBy(u => u.DXM.Substring(2, u.DXM.Length - 2)).ToList();

                    string PM = "";
                    if (isTuiHuo == "1")       //如果是退货的话喷码统一为ZAA
                        PM = "ZAA";
                    for (int x = 0; x < ET_TM.Count; x++)
                    {
                        model.DXM = ET_TM[x].DXM;
                        model.TPM = ET_TM[x].TPM;

                        model.PM = PM;
                        model.PMTYPE = 2;   //根据采购订单
                        int i = crmModels.BC_PMLIST.Create(model, token);
                        if (i <= 0)
                        {
                            return "生成失败！";
                        }
                    }
                    //if (isTuiHuo == "0")       //不是退货的话需要生成喷码
                    //{
                    //    int error = crmModels.BC_PMLIST.UpdatePM(token);    //生成喷码
                    //    if (error != 0)
                    //    {
                    //        return "喷码生成失败，请重试";
                    //    }
                    //}

                }


            }
            catch (Exception e)
            {
                return e.Message;
            }


            return "生成成功！";
        }


        [HttpPost]
        public string Data_Select_PM(string cxdata, string BEGIN_DATE, string END_DATE)
        {
            //暂时没用过
            token = appClass.CRM_Gettoken();
            CRM_BC_PMLIST model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_BC_PMLIST>(cxdata);
            model.PMTYPE = 1;
            CRM_BC_PMLIST[] data = crmModels.BC_PMLIST.SelectByModel(model, BEGIN_DATE, END_DATE, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_SelectGD(string cxdata, string BEGIN_DATE, string END_DATE)
        {
            token = appClass.CRM_Gettoken();
            CRM_BC_PMLISTList model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_BC_PMLISTList>(cxdata);
            model.PMTYPE = 1;
            CRM_BC_PMLISTList[] data = crmModels.BC_PMLIST.SelectGD(model, BEGIN_DATE, END_DATE, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_SelectGD_CG(string cxdata, string BEGIN_DATE, string END_DATE)
        {
            token = appClass.CRM_Gettoken();
            CRM_BC_PMLISTList model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_BC_PMLISTList>(cxdata);
            model.PMTYPE = 2;
            CRM_BC_PMLISTList[] data = crmModels.BC_PMLIST.SelectGD(model, BEGIN_DATE, END_DATE, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_SelectByGD(string cxdata, string BEGIN_DATE, string END_DATE)
        {
            token = appClass.CRM_Gettoken();
            CRM_BC_PMLIST model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_BC_PMLISTList>(cxdata);
            CRM_BC_PMLISTList[] data = crmModels.BC_PMLIST.SelectByGDandParam(model, BEGIN_DATE, END_DATE, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public int Delete_PM(int PMID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.BC_PMLIST.Delete(PMID, token);
            return i;
        }

        [HttpPost]
        public string Delete_PMbyGD(string aufnr)
        {
            token = appClass.CRM_Gettoken();
            CRM_BC_PMLIST cxmodel = new CRM_BC_PMLIST();
            cxmodel.AUFNR = aufnr;
            CRM_BC_PMLIST[] cxresult = crmModels.BC_PMLIST.SelectByModel(cxmodel, "", "", token);
            string type = "";
            if (cxresult[0].PMTYPE == 1)
            {
                type = "F";
            }
            else if (cxresult[0].PMTYPE == 2)
            {
                type = "B";
            }

            ZSL_BCST100 data = crmModels.BarCode.GET_ZBCFUN_PO_RECEIPT(aufnr, type, token);
            if (data.Type != "S")
            {
                webmsg.KEY = 0;
                webmsg.MSG = data.Message;
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }
            else
            {
                int i = crmModels.BC_PMLIST.DeleteByGD(aufnr, token);
                if (i < 0)
                {
                    webmsg.KEY = 0;
                    webmsg.MSG = "删除失败！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
                else
                {
                    webmsg.KEY = 1;
                    webmsg.MSG = "删除成功！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
            }


        }



        /// <summary>
        /// 根据工单号获取工单信息
        /// </summary>
        /// <param name="aufnr"></param>
        /// <returns></returns>
        [HttpPost]
        public string Data_GetGDXX(string aufnr)
        {
            token = appClass.CRM_Gettoken();
            ZBCFUN_GDJGXX_READ data = crmModels.PD_GD.get_GDJGXX_BYERPNO(aufnr, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }



        /// <summary>
        /// 根据采购单号获取工单信息
        /// </summary>
        /// <param name="aufnr"></param>
        /// <returns></returns>
        [HttpPost]
        public string Data_GetGDXX_CG(string EBELN, string EBELP)
        {
            token = appClass.CRM_Gettoken();
            while (EBELP.Length < 5)
            {
                EBELP = "0" + EBELP;
            }
            MODEL_ZBCFUN_POITEM_READ data = crmModels.BarCode.GET_ZBCFUN_POITEM_READ(EBELN, EBELP, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }



        /// <summary>
        /// 根据物料号获取该物料号的包装规格
        /// </summary>
        /// <param name="matnr"></param>
        /// <returns></returns>
        [HttpPost]
        public string Data_GetCountByMatnr(string matnr)
        {
            token = appClass.CRM_Gettoken();
            while (matnr.Length < 18)
            {
                matnr = "0" + matnr;
            }
            MODEL_ZBCFUN_MAT_GET data = crmModels.BarCode.GET_ZBCFUN_MAT_GET("", "SL01", matnr, "", token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }





        /// <summary>
        /// 根据工单获取该工单下所有的箱码
        /// </summary>
        /// <param name="aufnr"></param>
        /// <returns></returns>
        [HttpPost]
        public string Data_GetBarCodeByGD(string aufnr)
        {
            token = appClass.CRM_Gettoken();
            MODEL_ZBCFUN_TM_READ data = crmModels.BarCode.GET_ZBCFUN_TM_READ(aufnr, "F", token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }




        [HttpPost]
        public string Data_GetNewWLM()
        {
            token = appClass.CRM_Gettoken();
            MODEL_ZBCFUN_THLOG_READ data = crmModels.BarCode.GET_ZBCFUN_THLOG_READ(token);
            if (data.ET_THLOG.Length == 0)
            {
                return "没有需要更新的数据";
            }

            crmModels.BC_PMLIST.Delete_WLM(token);
            CRM_BC_WLM_TEMP model = new CRM_BC_WLM_TEMP();
            for (int i = 0; i < data.ET_THLOG.Length; i++)
            {
                model.MANDT = "";
                model.TGWLM = data.ET_THLOG[i].TGWLM;
                model.SRWLM = data.ET_THLOG[i].SRWLM;
                model.CJRQ = data.ET_THLOG[i].CJRQ;
                model.CJSJ = data.ET_THLOG[i].CJSJ;
                model.CJR = data.ET_THLOG[i].CJR;
                model.XGRQ = data.ET_THLOG[i].XGRQ;
                model.XGSJ = data.ET_THLOG[i].XGSJ;
                model.XGR = data.ET_THLOG[i].XGR;
                int id = crmModels.BC_PMLIST.Create_WLM(model, token);
                if (id == 0)
                {
                    return "没有需要更新的数据！";
                }
            }
            crmModels.BC_PMLIST.Modify_WLM(token);

            return "更新成功！";
        }

    }
}
