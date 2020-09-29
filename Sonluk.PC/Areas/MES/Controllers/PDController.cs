using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Sonluk.PC.APPCLASS;
using Sonluk.PC.Areas.MES.Models;
using Sonluk.PC.Models;
using Sonluk.UI.Model.MES.PD_GD_BOMService;
using Sonluk.UI.Model.MES.PD_GDService;
using Sonluk.UI.Model.MES.PD_SCRWService;
using Sonluk.UI.Model.MES.SY_GCService;
using Sonluk.UI.Model.MES.SY_GZZX_SBHService;
using Sonluk.UI.Model.MES.SY_GZZX_WLLBService;
using Sonluk.UI.Model.MES.SY_GZZXService;
using Sonluk.UI.Model.MES.SY_LANGUAGE_YMService;
using Sonluk.UI.Model.MES.SY_MATERIAL_GROUPService;
using Sonluk.UI.Model.MES.SY_MATERIALService;
using Sonluk.UI.Model.MES.SY_TYPEMXService;
using Sonluk.UI.Model.MES.TM_TMINFOService;
using Sonluk.UI.Model.MODEL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Sonluk.PC.Areas.MES.Controllers
{
    public class PDController : Controller
    {
        //
        // GET: /MES/PD/
        MESModels mesModels = new MESModels();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Assign_WorkOrder()
        {
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            string token = AppClass.GetSession("token").ToString();
            MODEL_Assign_WorkOrder model = new MODEL_Assign_WorkOrder();
            AppClass.SetSession("location", 110);
            MES_SY_GC model_MES_SY_GC = new MES_SY_GC();
            model_MES_SY_GC.STAFFID = STAFFID;
            MES_SY_GC[] MES_SY_GC_list = mesModels.SY_GC.SELECT_BY_ROLE(model_MES_SY_GC, token);
            int gzzxcount = 0;
            if (MES_SY_GC_list.Length == 1)
            {
                MES_SY_GZZX model_MES_SY_GZZX = new MES_SY_GZZX();
                model_MES_SY_GZZX.GC = MES_SY_GC_list[0].GC;
                model_MES_SY_GZZX.STAFFID = STAFFID;
                MES_SY_GZZX[] rst_MES_SY_GZZX = mesModels.SY_GZZX.SELECT_BY_ROLE(model_MES_SY_GZZX, token);
                model.GZXX = rst_MES_SY_GZZX;
                gzzxcount = rst_MES_SY_GZZX.Length;
            }
            else
            {
                model.GZXX = new MES_SY_GZZX[0];
            }
            if (MES_SY_GC_list.Length == 1)
            {
                MES_SY_MATERIAL_GROUP model_MES_SY_MATERIAL_GROUP = new MES_SY_MATERIAL_GROUP();
                model_MES_SY_MATERIAL_GROUP.GC = MES_SY_GC_list[0].GC;
                model_MES_SY_MATERIAL_GROUP.WLLBNAME = "密封圈";
                MES_SY_MATERIAL_GROUP_SELECT rst_MES_SY_MATERIAL_GROUP_SELECT = mesModels.SY_MATERIAL_GROUP.SELECT_USER(model_MES_SY_MATERIAL_GROUP, token);
                model.WLGROUP = rst_MES_SY_MATERIAL_GROUP_SELECT.MES_SY_MATERIAL_GROUP;
                if (rst_MES_SY_MATERIAL_GROUP_SELECT.MES_SY_MATERIAL_GROUP.Length == 1 && gzzxcount == 1)
                {
                    MES_SY_MATERIAL model_MES_SY_MATERIAL_LIST = new MES_SY_MATERIAL();
                    model_MES_SY_MATERIAL_LIST.GC = MES_SY_GC_list[0].GC;
                    model_MES_SY_MATERIAL_LIST.WLGROUP = rst_MES_SY_MATERIAL_GROUP_SELECT.MES_SY_MATERIAL_GROUP[0].WLGROUP;
                    model_MES_SY_MATERIAL_LIST.GZZXBH = model.GZXX[0].GZZXBH;
                    MES_SY_MATERIAL_SELECT rst_MES_SY_MATERIAL_SELECT = mesModels.SY_MATERIAL.SELECT_BY_GZZX(model_MES_SY_MATERIAL_LIST, token);
                    model.WL = rst_MES_SY_MATERIAL_SELECT.MES_SY_MATERIAL;
                }
                else
                {
                    model.WL = new MES_SY_MATERIAL_LIST[0];
                }
            }
            else
            {
                model.WLGROUP = new MES_SY_MATERIAL_GROUP[0];
            }
            if (MES_SY_GC_list.Length == 1)
            {
                MES_SY_TYPEMX model_MES_SY_TYPEMX = new MES_SY_TYPEMX();
                model_MES_SY_TYPEMX.GC = MES_SY_GC_list[0].GC;
                model_MES_SY_TYPEMX.TYPEID = 2;
                MES_SY_TYPEMXLIST[] rst_MES_SY_TYPEMXLIST = mesModels.SY_TYPEMX.SELECT(model_MES_SY_TYPEMX, token);
                model.DW = rst_MES_SY_TYPEMXLIST;
            }
            else
            {
                model.DW = new MES_SY_TYPEMXLIST[0];
            }
            if (MES_SY_GC_list.Length == 1 && gzzxcount == 1)
            {
                MES_SY_GZZX_WLLB model_MES_SY_GZZX_WLLB = new MES_SY_GZZX_WLLB();
                model_MES_SY_GZZX_WLLB.GC = MES_SY_GC_list[0].GC;
                model_MES_SY_GZZX_WLLB.GZZXBH = model.GZXX[0].GZZXBH;
                MES_SY_GZZX_WLLB_SELECT rst_MES_SY_GZZX_WLLB_SELECT = mesModels.SY_GZZX_WLLB.SELECT(model_MES_SY_GZZX_WLLB, token);
                model.WLLB = rst_MES_SY_GZZX_WLLB_SELECT.MES_SY_GZZX_WLLB;
            }
            else
            {
                model.WLLB = new MES_SY_GZZX_WLLB[0];
            }
            model.MES_SY_GC = MES_SY_GC_list;
            model.GZZXCOUNT = gzzxcount;
            ViewData.Model = model;
            return View();
        }

        public ActionResult CREATE_WorkOrder()
        {
            AppClass.SetSession("location", 111);
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            string token = AppClass.GetSession("token").ToString();
            MODEL_Assign_WorkOrder model = new MODEL_Assign_WorkOrder();
            MES_SY_GC model_MES_SY_GC = new MES_SY_GC();
            model_MES_SY_GC.STAFFID = STAFFID;
            MES_SY_GC[] MES_SY_GC_list = mesModels.SY_GC.SELECT_BY_ROLE(model_MES_SY_GC, token);
            int gzzxcount = 0;
            if (MES_SY_GC_list.Length == 1)
            {
                MES_SY_GZZX model_MES_SY_GZZX = new MES_SY_GZZX();
                model_MES_SY_GZZX.GC = MES_SY_GC_list[0].GC;
                model_MES_SY_GZZX.STAFFID = STAFFID;
                MES_SY_GZZX[] rst_MES_SY_GZZX = mesModels.SY_GZZX.SELECT_BY_ROLE(model_MES_SY_GZZX, token);
                model.GZXX = rst_MES_SY_GZZX;
                gzzxcount = rst_MES_SY_GZZX.Length;
            }
            else
            {
                model.GZXX = new MES_SY_GZZX[0];
            }
            if (MES_SY_GC_list.Length == 1)
            {
                MES_SY_MATERIAL_GROUP model_MES_SY_MATERIAL_GROUP = new MES_SY_MATERIAL_GROUP();
                model_MES_SY_MATERIAL_GROUP.GC = MES_SY_GC_list[0].GC;
                model_MES_SY_MATERIAL_GROUP.WLLBNAME = "密封圈";
                MES_SY_MATERIAL_GROUP_SELECT rst_MES_SY_MATERIAL_GROUP_SELECT = mesModels.SY_MATERIAL_GROUP.SELECT_USER(model_MES_SY_MATERIAL_GROUP, token);
                model.WLGROUP = rst_MES_SY_MATERIAL_GROUP_SELECT.MES_SY_MATERIAL_GROUP;
                if (rst_MES_SY_MATERIAL_GROUP_SELECT.MES_SY_MATERIAL_GROUP.Length == 1 && gzzxcount == 1)
                {
                    MES_SY_MATERIAL model_MES_SY_MATERIAL_LIST = new MES_SY_MATERIAL();
                    model_MES_SY_MATERIAL_LIST.GC = MES_SY_GC_list[0].GC;
                    model_MES_SY_MATERIAL_LIST.WLGROUP = rst_MES_SY_MATERIAL_GROUP_SELECT.MES_SY_MATERIAL_GROUP[0].WLGROUP;
                    model_MES_SY_MATERIAL_LIST.GZZXBH = model.GZXX[0].GZZXBH;
                    MES_SY_MATERIAL_SELECT rst_MES_SY_MATERIAL_SELECT = mesModels.SY_MATERIAL.SELECT_BY_GZZX(model_MES_SY_MATERIAL_LIST, token);
                    model.WL = rst_MES_SY_MATERIAL_SELECT.MES_SY_MATERIAL;
                }
                else
                {
                    model.WL = new MES_SY_MATERIAL_LIST[0];
                }
            }
            else
            {
                model.WLGROUP = new MES_SY_MATERIAL_GROUP[0];
            }
            if (MES_SY_GC_list.Length == 1)
            {
                MES_SY_TYPEMX model_MES_SY_TYPEMX = new MES_SY_TYPEMX();
                model_MES_SY_TYPEMX.GC = MES_SY_GC_list[0].GC;
                model_MES_SY_TYPEMX.TYPEID = 2;
                MES_SY_TYPEMXLIST[] rst_MES_SY_TYPEMXLIST = mesModels.SY_TYPEMX.SELECT(model_MES_SY_TYPEMX, token);
                model.DW = rst_MES_SY_TYPEMXLIST;
            }
            else
            {
                model.DW = new MES_SY_TYPEMXLIST[0];
            }
            if (MES_SY_GC_list.Length == 1 && gzzxcount == 1)
            {
                MES_SY_GZZX_WLLB model_MES_SY_GZZX_WLLB = new MES_SY_GZZX_WLLB();
                model_MES_SY_GZZX_WLLB.GC = MES_SY_GC_list[0].GC;
                model_MES_SY_GZZX_WLLB.GZZXBH = model.GZXX[0].GZZXBH;
                MES_SY_GZZX_WLLB_SELECT rst_MES_SY_GZZX_WLLB_SELECT = mesModels.SY_GZZX_WLLB.SELECT(model_MES_SY_GZZX_WLLB, token);
                model.WLLB = rst_MES_SY_GZZX_WLLB_SELECT.MES_SY_GZZX_WLLB;
            }
            else
            {
                model.WLLB = new MES_SY_GZZX_WLLB[0];
            }
            model.MES_SY_GC = MES_SY_GC_list;
            model.GZZXCOUNT = gzzxcount;
            ViewData.Model = model;
            return View();
        }


        public ActionResult ADD_GD_FROMSAP()
        {
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));

            string token = AppClass.GetSession("STAFFID").ToString();
            MODEL_Assign_WorkOrder model = new MODEL_Assign_WorkOrder();
            MES_SY_GC model_MES_SY_GC = new MES_SY_GC();
            model_MES_SY_GC.STAFFID = STAFFID;
            MES_SY_GC[] MES_SY_GC_list = mesModels.SY_GC.SELECT_BY_ROLE(model_MES_SY_GC, token);
            model.MES_SY_GC = MES_SY_GC_list;
            MES_SY_GZZX model_MES_SY_GZZX = new MES_SY_GZZX();
            ViewData.Model = model;
            return View();
        }

        public ActionResult RW_SELECT()
        {
            AppClass.SetSession("location", 150);
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            string token = AppClass.GetSession("token").ToString();
            MODEL_Assign_WorkOrder model = new MODEL_Assign_WorkOrder();
            MES_SY_GC model_MES_SY_GC = new MES_SY_GC();
            model_MES_SY_GC.STAFFID = STAFFID;
            MES_SY_GC[] MES_SY_GC_list = mesModels.SY_GC.SELECT_BY_ROLE(model_MES_SY_GC, token);
            model.MES_SY_GC = MES_SY_GC_list;
            ViewData.Model = model;
            return View();
        }

        public ActionResult RW_SELECT_ALL()
        {
            AppClass.SetSession("location", 156);
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            string token = AppClass.GetSession("token").ToString();
            MODEL_Assign_WorkOrder model = new MODEL_Assign_WorkOrder();
            MES_SY_GC model_MES_SY_GC = new MES_SY_GC();
            model_MES_SY_GC.STAFFID = STAFFID;
            MES_SY_GC[] MES_SY_GC_list = mesModels.SY_GC.SELECT_BY_ROLE(model_MES_SY_GC, token);
            model.MES_SY_GC = MES_SY_GC_list;
            ViewData.Model = model;
            return View();
        }

        public ActionResult YF_WorkOrder()
        {
            AppClass.SetSession("location", 157);
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            string token = AppClass.GetSession("token").ToString();
            MODEL_Assign_WorkOrder model = new MODEL_Assign_WorkOrder();
            MES_SY_GC model_MES_SY_GC = new MES_SY_GC();
            model_MES_SY_GC.STAFFID = STAFFID;
            MES_SY_GC[] MES_SY_GC_list = mesModels.SY_GC.SELECT_BY_ROLE(model_MES_SY_GC, token);
            model.MES_SY_GC = MES_SY_GC_list;
            ViewData.Model = model;
            return View();
        }

        [HttpPost]
        public string GET_PDINFO(string GC, string GZZXBH, string KSDATE, string JSDATE, int WLLB, string WLH, string ERPNO, string GDDH, int GDLB)
        {
            string rst = "";
            string token = Session["token"].ToString();
            MES_PD_GD model_MES_PD_GD = new MES_PD_GD();
            model_MES_PD_GD.GC = GC;
            model_MES_PD_GD.GZZXBH = GZZXBH;
            model_MES_PD_GD.KSDATE = KSDATE;
            model_MES_PD_GD.JSDATE = JSDATE;
            model_MES_PD_GD.WLLB = WLLB;
            model_MES_PD_GD.WLH = WLH;
            model_MES_PD_GD.ERPNO = ERPNO;
            model_MES_PD_GD.GDDH = GDDH;
            model_MES_PD_GD.GDLB = GDLB;
            SELECT_MES_PD_GD rst_SELECT_MES_PD_GD = mesModels.PD_GD.SELECT(model_MES_PD_GD, token);
            rst = Newtonsoft.Json.JsonConvert.SerializeObject(rst_SELECT_MES_PD_GD);
            return rst;
        }
        [HttpPost]
        public string GET_PDINFO_BY_STAFFID(string datastring)
        {
            string token = Session["token"].ToString();
            MES_PD_GD model_MES_PD_GD = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_PD_GD>(datastring);
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            model_MES_PD_GD.STAFFID = STAFFID;
            SELECT_MES_PD_GD rst_SELECT_MES_PD_GD = mesModels.PD_GD.SELECT_BY_STAFFID(model_MES_PD_GD, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_SELECT_MES_PD_GD);
        }

        [HttpPost]
        public string GET_GD_FROMSAP(string GCID, string GZZX, string KSDATE, string JSDATE, string ERPNO)
        {
            string rst = "";
            ZBCFUN_GDLIST_READ rst_ZBCFUN_GDLIST_READ = mesModels.PD_GD.SAP_GET_GDLIST(GCID, GZZX, "", ERPNO, KSDATE, JSDATE, "");
            rst = Newtonsoft.Json.JsonConvert.SerializeObject(rst_ZBCFUN_GDLIST_READ);
            return rst;
        }

        [HttpPost]
        public string POST_SAP_GD(string datastring)
        {
            string token = Session["token"].ToString();
            string rst = "";
            ZSL_BCST024_PO[] model_ZSL_BCST024_PO = Newtonsoft.Json.JsonConvert.DeserializeObject<ZSL_BCST024_PO[]>(datastring);
            MES_RETURN_UI rst_MES_RETURN_UI = mesModels.PD_GD.INSERT_FROM_SAP_GD(model_ZSL_BCST024_PO, token);
            rst = Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_RETURN_UI);
            return rst;
        }

        [HttpPost]
        public string UPDATE_PD_GD(string GDDH, string KSDATE, string JSDATE, string SL, string ISOPEN, string CHARG)
        {
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            string token = Session["token"].ToString();
            string rst = "";
            MES_PD_GD model_MES_PD_GD = new MES_PD_GD();
            model_MES_PD_GD.GDDH = GDDH;
            model_MES_PD_GD.KSDATE = KSDATE;
            model_MES_PD_GD.JSDATE = JSDATE;
            model_MES_PD_GD.SL = Convert.ToDecimal(SL);
            model_MES_PD_GD.ISOPEN = Convert.ToInt32(ISOPEN);
            model_MES_PD_GD.JLR = STAFFID;
            model_MES_PD_GD.CHARG = CHARG;
            MES_RETURN_UI rst_MES_RETURN_UI = mesModels.PD_GD.UPDATE(model_MES_PD_GD, token);
            rst = Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_RETURN_UI);
            return rst;
        }
        [HttpPost]
        public string UPDATE_PD_GD_BOM(string GDDH, string KSDATE, string JSDATE, string SL, string ISOPEN, string CHARG, string datastring)
        {
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            string token = Session["token"].ToString();
            string rst = "";
            MES_PD_GD model_MES_PD_GD = new MES_PD_GD();
            model_MES_PD_GD.GDDH = GDDH;
            model_MES_PD_GD.KSDATE = KSDATE;
            model_MES_PD_GD.JSDATE = JSDATE;
            model_MES_PD_GD.SL = Convert.ToDecimal(SL);
            model_MES_PD_GD.ISOPEN = Convert.ToInt32(ISOPEN);
            model_MES_PD_GD.JLR = STAFFID;
            model_MES_PD_GD.CHARG = CHARG;
            MES_RETURN_UI rst_MES_RETURN_UI = mesModels.PD_GD.UPDATE(model_MES_PD_GD, token);
            if (rst_MES_RETURN_UI.TYPE == "S")
            {
                MES_PD_GD_BOM[] model_MES_PD_GD_BOM = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_PD_GD_BOM[]>(datastring);
                MES_PD_GD_BOM model_MES_PD_GD_BOM_delete = new MES_PD_GD_BOM();
                model_MES_PD_GD_BOM_delete.GDDH = GDDH;
                mesModels.PD_GD_BOM.DELETE_GDDH(model_MES_PD_GD_BOM_delete, token);
                for (int i = 0; i < model_MES_PD_GD_BOM.Length; i++)
                {
                    model_MES_PD_GD_BOM[i].GDDH = GDDH;
                    mesModels.PD_GD_BOM.INSERT(model_MES_PD_GD_BOM[i], token);
                }
            }
            rst = Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_RETURN_UI);
            return rst;
        }
        [HttpPost]
        public string DELETE_PD_SCRW(string RWBH)
        {
            string token = AppClass.GetSession("token").ToString();
            string rst = "";
            MES_PD_SCRW model = new MES_PD_SCRW();
            model.RWBH = RWBH;
            MES_RETURN_UI rst_MES_RETURN_UI = mesModels.PD_SCRW.DELETE(model, token);
            rst = Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_RETURN_UI);
            return rst;
        }
        [HttpPost]
        public string GET_SCRW(string GC, string GZZXBH, string PDRQ)
        {
            string token = AppClass.GetSession("token").ToString();
            string rst = "";
            MES_PD_SCRW model_MES_PD_SCRW = new MES_PD_SCRW();
            model_MES_PD_SCRW.GC = GC;
            model_MES_PD_SCRW.GZZXBH = GZZXBH;
            model_MES_PD_SCRW.ZPRQ = PDRQ;
            MES_PD_SCRWANDPD_LIST_SELECT rst_MES_PD_SCRWANDPD_LIST_SELECT = mesModels.PD_SCRW.SELECT_SCRW_GD(model_MES_PD_SCRW, token);
            rst = Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_PD_SCRWANDPD_LIST_SELECT);
            return rst;
        }

        [HttpPost]
        public string GET_RWPD(string GDDH, string ZPRQ, string UNITSNAME, string GC, int BC, int SBFL)
        {
            string token = AppClass.GetSession("token").ToString();
            string rst = "";
            MES_PD_SCRW model_MES_PD_SCRW = new MES_PD_SCRW();
            model_MES_PD_SCRW.GDDH = GDDH;
            model_MES_PD_SCRW.ZPRQ = ZPRQ;
            model_MES_PD_SCRW.BC = BC;
            model_MES_PD_SCRW.SBFL = SBFL;
            SELECT_MES_PD_SCRW rst_SELECT_MES_PD_SCRW = mesModels.PD_SCRW.SELECT_ZPQD(model_MES_PD_SCRW, token);
            for (int i = 0; i < rst_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST.Length; i++)
            {
                rst_SELECT_MES_PD_SCRW.MES_PD_SCRW_LIST[i].UNITSNAME = UNITSNAME;
            }
            rst = Newtonsoft.Json.JsonConvert.SerializeObject(rst_SELECT_MES_PD_SCRW);
            return rst;
        }


        [HttpPost]
        public string GET_GZZX_BYGC(string GC)
        {
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            string token = AppClass.GetSession("token").ToString();
            string rst = "";
            MES_SY_GZZX model = new MES_SY_GZZX();
            model.GC = GC;
            model.STAFFID = STAFFID;
            if (GC == "")
            {
                MES_SY_GZZX[] rst_MES_SY_GZZX = new MES_SY_GZZX[0];
                rst = Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_SY_GZZX);
            }
            else
            {
                MES_SY_GZZX[] rst_MES_SY_GZZX = mesModels.SY_GZZX.SELECT_BY_ROLE(model, token);
                rst = Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_SY_GZZX);
            }
            return rst;
        }

        [HttpPost]
        public string GET_GZZX_BYGC_NOROLE(string GC)
        {
            string token = AppClass.GetSession("token").ToString();
            string rst = "";
            MES_SY_GZZX model = new MES_SY_GZZX();
            model.GC = GC;
            MES_SY_GZZX[] rst_MES_SY_GZZX = mesModels.SY_GZZX.SELECT_USER(model, token);
            rst = Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_SY_GZZX);
            return rst;
        }

        [HttpPost]
        public string DELETE_PD_GD(string GDDH)
        {
            string token = AppClass.GetSession("token").ToString();
            string rst = "";
            MES_PD_GD model = new MES_PD_GD();
            model.GDDH = GDDH;
            MES_RETURN_UI rst_MES_RETURN_UI = mesModels.PD_GD.DELETE(model, token);
            rst = Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_RETURN_UI);
            return rst;
        }


        [HttpPost]
        public string INSERT_PDRW(string datastring, string ZPRQ)
        {
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            string token = AppClass.GetSession("token").ToString();
            string rst = "";
            MES_PD_SCRW_LIST[] model_MES_PD_SCRW_LIST = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_PD_SCRW_LIST[]>(datastring);
            for (int i = 0; i < model_MES_PD_SCRW_LIST.Length; i++)
            {
                model_MES_PD_SCRW_LIST[i].ZPRQ = ZPRQ;
                model_MES_PD_SCRW_LIST[i].JLR = STAFFID;
                model_MES_PD_SCRW_LIST[i].ISACTION = 2;
            }
            MES_RETURN_UI rst_MES_RETURN_UI = mesModels.PD_SCRW.INSERT_LIST(model_MES_PD_SCRW_LIST, token);
            rst = Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_RETURN_UI);
            return rst;
        }

        [HttpPost]
        public string UPDATE_SCRW(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            string rst = "";
            MES_PD_SCRW model_MES_PD_SCRW = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_PD_SCRW>(datastring);
            MES_RETURN_UI rst_MES_RETURN_UI = mesModels.PD_SCRW.UPDATE_SCRW(model_MES_PD_SCRW, token);
            rst = Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_RETURN_UI);
            return rst;
        }

        [HttpPost]
        public string GET_WLGROUP(string datastring)
        {
            string rst = "";
            string token = AppClass.GetSession("token").ToString();
            MES_SY_MATERIAL_GROUP model_MES_SY_MATERIAL_GROUP = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_MATERIAL_GROUP>(datastring);
            MES_SY_MATERIAL_GROUP_SELECT rst_MES_SY_MATERIAL_GROUP_SELECT = mesModels.SY_MATERIAL_GROUP.SELECT_USER(model_MES_SY_MATERIAL_GROUP, token);
            rst = Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_SY_MATERIAL_GROUP_SELECT);
            return rst;
        }
        [HttpPost]
        public string GET_WL(string GC, string WLGROUP, string GZZXBH)
        {
            string rst = "";
            string token = AppClass.GetSession("token").ToString();
            MES_SY_MATERIAL model_MES_SY_MATERIAL = new MES_SY_MATERIAL();
            model_MES_SY_MATERIAL.GC = GC;
            model_MES_SY_MATERIAL.WLGROUP = WLGROUP;
            model_MES_SY_MATERIAL.GZZXBH = GZZXBH;
            MES_SY_MATERIAL_SELECT rst_MES_SY_MATERIAL_SELECT = mesModels.SY_MATERIAL.SELECT_BY_GZZX(model_MES_SY_MATERIAL, token);
            rst = Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_SY_MATERIAL_SELECT);
            return rst;
        }
        [HttpPost]
        public string GET_WL_datastring(string datastring)
        {
            string rst = "";
            string token = AppClass.GetSession("token").ToString();
            MES_SY_MATERIAL model_MES_SY_MATERIAL = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_MATERIAL>(datastring);
            MES_SY_MATERIAL_SELECT rst_MES_SY_MATERIAL_SELECT = mesModels.SY_MATERIAL.SELECT_ACTION(model_MES_SY_MATERIAL, token);
            rst = Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_SY_MATERIAL_SELECT);
            return rst;
        }
        [HttpPost]
        public string GET_WLLB(string GC, string GZZXBH)
        {
            string rst = "";
            string token = AppClass.GetSession("token").ToString();
            MES_SY_GZZX_WLLB model_MES_SY_GZZX_WLLB = new MES_SY_GZZX_WLLB();
            model_MES_SY_GZZX_WLLB.GC = GC;
            model_MES_SY_GZZX_WLLB.GZZXBH = GZZXBH;
            MES_SY_GZZX_WLLB_SELECT rst_MES_SY_GZZX_WLLB_SELECT = mesModels.SY_GZZX_WLLB.SELECT(model_MES_SY_GZZX_WLLB, token);
            rst = Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_SY_GZZX_WLLB_SELECT);
            return rst;
        }
        [HttpPost]
        public string INSERT_GD(string datastring)
        {
            string rst = "";
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            string token = AppClass.GetSession("token").ToString();
            MES_PD_GD model_MES_PD_GD = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_PD_GD>(datastring);
            model_MES_PD_GD.JLR = STAFFID;
            MES_RETURN_UI model_MES_RETURN_UI = mesModels.PD_GD.INSERT_BY_MES(model_MES_PD_GD, token);
            rst = Newtonsoft.Json.JsonConvert.SerializeObject(model_MES_RETURN_UI);
            return rst;
        }
        [HttpPost]
        public string INSERT_GD_PL(string datastring)
        {
            string rst = "";
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            string token = AppClass.GetSession("token").ToString();
            MES_PD_GD[] model_MES_PD_GD = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_PD_GD[]>(datastring);
            MES_RETURN_UI model_MES_RETURN_UI = new MES_RETURN_UI();
            for (int i = 0; i < model_MES_PD_GD.Length; i++)
            {
                model_MES_PD_GD[i].JLR = STAFFID;
                model_MES_RETURN_UI = mesModels.PD_GD.INSERT_BY_MES(model_MES_PD_GD[i], token);
                if (model_MES_RETURN_UI.TYPE != "S")
                {
                    return Newtonsoft.Json.JsonConvert.SerializeObject(model_MES_RETURN_UI);
                }
            }
            rst = Newtonsoft.Json.JsonConvert.SerializeObject(model_MES_RETURN_UI);
            return rst;
        }
        [HttpPost]
        public string INSERT_YFGD(string datastring1, string datastring2)
        {
            string rst = "";
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            string token = AppClass.GetSession("token").ToString();
            MES_PD_GD model_MES_PD_GD = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_PD_GD>(datastring1);
            model_MES_PD_GD.JLR = STAFFID;
            MES_RETURN_UI model_MES_RETURN_UI = mesModels.PD_GD.INSERT_BY_MES(model_MES_PD_GD, token);
            MES_PD_GD_BOM[] model_MES_PD_GD_BOM = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_PD_GD_BOM[]>(datastring2);
            for (int i = 0; i < model_MES_PD_GD_BOM.Length; i++)
            {
                model_MES_PD_GD_BOM[i].GDDH = model_MES_RETURN_UI.BH;
                mesModels.PD_GD_BOM.INSERT(model_MES_PD_GD_BOM[i], token);
            }
            rst = Newtonsoft.Json.JsonConvert.SerializeObject(model_MES_RETURN_UI);
            return rst;
        }
        [HttpPost]
        public string INSERT_BY_SAPGDLIST(string GC, string GZZXBH, string IV_AUFNR, string KSDATE, string JSDATE)
        {
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            string token = AppClass.GetSession("token").ToString();
            string rst = "";
            MES_RETURN_UI rst_MES_RETURN_UI = mesModels.PD_GD.INSERT_BY_SAPGDLIST(GC, GZZXBH, IV_AUFNR, KSDATE, JSDATE, STAFFID, token);
            rst = Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_RETURN_UI);
            return rst;
        }
        [HttpPost]
        public string GET_TYPEMX(int TYPEID, string GC)
        {
            string token = AppClass.GetSession("token").ToString();
            string rst = "";
            MES_SY_TYPEMX model_MES_SY_TYPEMX = new MES_SY_TYPEMX();
            model_MES_SY_TYPEMX.TYPEID = TYPEID;
            model_MES_SY_TYPEMX.GC = GC;
            MES_SY_TYPEMXLIST[] rst_MES_SY_TYPEMXLIST = mesModels.SY_TYPEMX.SELECT(model_MES_SY_TYPEMX, token);
            rst = Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_SY_TYPEMXLIST);
            return rst;
        }
        [HttpPost]
        public string GET_SBH(string GC, string GZZXBH)
        {
            string token = AppClass.GetSession("token").ToString();
            string rst = "";
            MES_SY_GZZX_SBH model_MES_SY_GZZX_SBH = new MES_SY_GZZX_SBH();
            model_MES_SY_GZZX_SBH.GC = GC;
            model_MES_SY_GZZX_SBH.GZZXBH = GZZXBH;
            MES_SY_GZZX_SBH[] rst_MES_SY_GZZX_SBH = mesModels.SY_GZZX_SBH.SELECT(model_MES_SY_GZZX_SBH, token);
            rst = Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_SY_GZZX_SBH);
            return rst;
        }

        [HttpPost]
        public string GET_SCRW_BY_ROLE(string datastring)
        {
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            string token = AppClass.GetSession("token").ToString();
            MES_PD_SCRW model_MES_PD_SCRW = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_PD_SCRW>(datastring);
            model_MES_PD_SCRW.STAFFID = STAFFID;
            SELECT_MES_PD_SCRW rst_SELECT_MES_PD_SCRW = mesModels.PD_SCRW.SELECT_BY_ROLE(model_MES_PD_SCRW, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_SELECT_MES_PD_SCRW);
        }
        [HttpPost]
        public string GET_SBFL_BY_GZZXBH(string GC, string GZZXBH)
        {
            string token = AppClass.GetSession("token").ToString();
            string rst = "";
            MES_SY_TYPEMXLIST[] rst_MES_SY_TYPEMXLIST = mesModels.SY_TYPEMX.SELECT_SBFL_BY_GZZX(GC, GZZXBH, token);
            rst = Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_SY_TYPEMXLIST);
            return rst;
        }
        [HttpPost]
        public string EXPORT_RWQD(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_RETURN_UI rst = new MES_RETURN_UI();
            try
            {
                MES_SY_LANGUAGE_TABLEZD model_MES_SY_LANGUAGE_TABLEZD = new MES_SY_LANGUAGE_TABLEZD();
                model_MES_SY_LANGUAGE_TABLEZD.YMAREA = "MES";
                model_MES_SY_LANGUAGE_TABLEZD.YMCONTROLLER = "PD";
                model_MES_SY_LANGUAGE_TABLEZD.YMVIEW = "RW_SELECT_ALL";
                model_MES_SY_LANGUAGE_TABLEZD.TABLEDM = "dc_tb_PDRW";
                model_MES_SY_LANGUAGE_TABLEZD.YMXM = "SONLUKPC";
                model_MES_SY_LANGUAGE_TABLEZD.LB = 1;
                MES_SY_LANGUAGE_TABLEZD_SELECT rst_MES_SY_LANGUAGE_TABLEZD_SELECT = mesModels.SY_LANGUAGE_YM.SELECT_TABLEZD(model_MES_SY_LANGUAGE_TABLEZD, token);
                if (rst_MES_SY_LANGUAGE_TABLEZD_SELECT.MES_RETURN.TYPE != "S")
                {
                    return Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_SY_LANGUAGE_TABLEZD_SELECT.MES_RETURN);
                }
                if (rst_MES_SY_LANGUAGE_TABLEZD_SELECT.MES_SY_LANGUAGE_TABLEZD.Length > 0)
                {
                    AppClass.SetSession("EXPORT_RWQD", rst_MES_SY_LANGUAGE_TABLEZD_SELECT.MES_SY_LANGUAGE_TABLEZD[0].TABLENAME);
                }
                else
                {
                    AppClass.SetSession("EXPORT_RWQD", "NO HEAD");
                }
                MES_PD_SCRW_LIST[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_PD_SCRW_LIST[]>(datastring);
                //FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/MES/ExportFile/生产任务导出.xls", FileMode.Open, FileAccess.Read);
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/导出模版.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 0;
                IRow rowtt = sheet.CreateRow(rowcount++);
                int cellIndex = 0;
                for (int a = 0; a < rst_MES_SY_LANGUAGE_TABLEZD_SELECT.MES_SY_LANGUAGE_TABLEZD.Length; a++)
                {
                    rowtt.CreateCell(cellIndex++).SetCellValue(rst_MES_SY_LANGUAGE_TABLEZD_SELECT.MES_SY_LANGUAGE_TABLEZD[a].TABLEZDNAME);
                }

                //IWorkbook workbook = new HSSFWorkbook(file);
                //ISheet sheet = workbook.GetSheetAt(0);
                //int rowcount = 1;
                for (int i = 0; i < model.Length; i++)
                {
                    cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].RWBH);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].WLH);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].WLMS);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].GC);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].GZZXBH);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].GZZXNAME);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].SBH);
                    row.CreateCell(cellIndex++).SetCellValue((double)model[i].SL);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].UNITSNAME);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].PFDH);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].PLDH);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TH);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].XFCDNAME);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].PC);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].GDDH);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].ERPNO);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JLRMS);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JLTIME);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TLSJ);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].CCSJ);
                }
                string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                FileStream file1 = new FileStream(string.Format(@"{0}/Areas/MES/ExportFile/{1}.xlsx", Server.MapPath("~"), now), FileMode.Create);
                workbook.Write(file1);
                file1.Close();
                rst.TYPE = "S";
                rst.MESSAGE = now;
            }
            catch
            {
                rst.TYPE = "E";
                rst.MESSAGE = "生产文件失败！";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }

        public ActionResult EXPORT_READ_RWQD(string filename)
        {
            string name = AppClass.GetSession("EXPORT_RWQD").ToString();
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/MES/ExportFile/{1}.xlsx", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", name + ".xlsx");
        }

        [HttpPost]
        public string POST_PRINT_RWQD(string datastring)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            MES_PD_SCRW_LIST model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_PD_SCRW_LIST>(datastring);
            MES_PD_SCRW_LIST[] model_list = new MES_PD_SCRW_LIST[1];
            model_list[0] = model;
            AppClass.SetSession("MES_PD_SCRW_LIST", model_list);
            rst.TYPE = "S";
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }

        [HttpPost]
        public string POST_PRINT_RWQD_LIST(string datastring)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            MES_PD_SCRW_LIST[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_PD_SCRW_LIST[]>(datastring);
            AppClass.SetSession("MES_PD_SCRW_LIST", model);
            rst.TYPE = "S";
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }

        public ActionResult RWQD_PRINT()
        {
            string token = AppClass.GetSession("token").ToString();
            List<MODEL_RWQD_PRINT> rst = new List<MODEL_RWQD_PRINT>();
            MES_PD_SCRW_LIST[] model_MES_PD_SCRW_LIST = (MES_PD_SCRW_LIST[])Session["MES_PD_SCRW_LIST"];
            for (int i = 0; i < model_MES_PD_SCRW_LIST.Length; i++)
            {
                MODEL_RWQD_PRINT child_MODEL_RWQD_PRINT = new MODEL_RWQD_PRINT();
                ZBCFUN_GDJGXX_READ model_ZBCFUN_GDJGXX_READ = mesModels.PD_GD.SAP_GET_GDJGXX(model_MES_PD_SCRW_LIST[i].RWBH, model_MES_PD_SCRW_LIST[i].ZPRQ, model_MES_PD_SCRW_LIST[i].GC, token);
                child_MODEL_RWQD_PRINT.MES_PD_SCRW_LIST = model_MES_PD_SCRW_LIST[i];
                child_MODEL_RWQD_PRINT.ZBCFUN_GDJGXX_READ = model_ZBCFUN_GDJGXX_READ;
                rst.Add(child_MODEL_RWQD_PRINT);
            }
            return View(rst);
        }

        public ActionResult BarCode(string code, string format, string width, string height, string pure)
        {
            //string code = Request.QueryString["code"];
            //string format = Request.QueryString["format"];
            //int width = Convert.ToInt32(Request.QueryString["width"].ToString());
            //int height =  Convert.ToInt32(Request.QueryString["height"].ToString());
            //int pure = Convert.ToInt32(Request.QueryString["pure"].ToString());

            Byte[] objcode = mesModels.BarCode.CreateBarCode(code, format, Convert.ToInt32(width), Convert.ToInt32(height), Convert.ToInt32(pure));

            Response.ContentType = "image/jpg";
            Response.Clear();
            Response.BufferOutput = true;
            Response.BinaryWrite(objcode);
            Response.Flush();
            return View();
        }

        [HttpPost]
        public string DELETE_RW_BY_GZZX_BC(string GC, string GZZXBH, int BC, string GDDH, string ZPRQ)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_RETURN_UI rst = mesModels.PD_SCRW.DELETE_GZZX(GC, GZZXBH, BC, GDDH, ZPRQ, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string GET_NOWTIME()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        [HttpPost]
        public string INSERT_PD_TL_BL(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            Sonluk.UI.Model.MES.PD_TLGLService.MES_PD_TL model = Newtonsoft.Json.JsonConvert.DeserializeObject<Sonluk.UI.Model.MES.PD_TLGLService.MES_PD_TL>(datastring);
            model.JLR = STAFFID;
            MES_TM_TMINFO model_MES_TM_TMINFO = new MES_TM_TMINFO();
            model_MES_TM_TMINFO.TM = model.TM;
            model_MES_TM_TMINFO.RWBH = model.RWBH;
            MES_RETURN_UI rst = new MES_RETURN_UI();
            SELECT_MES_TM_TMINFO_BYTM rst_SELECT_MES_TM_TMINFO_BYTM = mesModels.TM_TMINFO.SELECT_BYTM(model_MES_TM_TMINFO, 0, token);
            if (rst_SELECT_MES_TM_TMINFO_BYTM.MES_RETURN.TYPE == "S")
            {
                if (rst_SELECT_MES_TM_TMINFO_BYTM.MES_TM_TMINFO_LIST.Length == 1)
                {
                    rst = mesModels.PD_TLGL.INSERT(model, token);
                }
                else
                {
                    rst.TYPE = "E";
                    rst.MESSAGE = "没有查询到条码信息！";
                }
            }
            else
            {
                rst.TYPE = rst_SELECT_MES_TM_TMINFO_BYTM.MES_RETURN.TYPE;
                rst.MESSAGE = rst_SELECT_MES_TM_TMINFO_BYTM.MES_RETURN.MESSAGE;
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }

        [HttpPost]
        public string GET_ZZTHINFO(string RWBH)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_PD_SCRW_CCTH rst_MES_PD_SCRW_CCTH = mesModels.PD_SCRW.SELECT_ZXCCINFO(RWBH, 0, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_PD_SCRW_CCTH);
        }

        [HttpPost]
        public string POST_ZFDC_CC(string datastring, string datastring2)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_PD_SCRW_ZXCC_INSERT model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_PD_SCRW_ZXCC_INSERT>(datastring);
            model.JLR = STAFFID;
            Sonluk.UI.Model.MES.PD_SCRWService.MES_TM_ZFDCMX[] model2 = Newtonsoft.Json.JsonConvert.DeserializeObject<Sonluk.UI.Model.MES.PD_SCRWService.MES_TM_ZFDCMX[]>(datastring2);
            model.MES_TM_ZFDCMX = model2;
            MES_RETURN_UI rst = mesModels.PD_SCRW.ZX_CC_NOUPDATE_TIME(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string GET_GD_BOM(string datastring)
        {
            string rst = "";
            string token = AppClass.GetSession("token").ToString();
            MES_PD_GD_BOM model_MES_PD_GD_BOM = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_PD_GD_BOM>(datastring);
            MES_PD_GD_BOM_SELECT rst_MES_PD_GD_BOM_SELECT = mesModels.PD_GD_BOM.SELECT(model_MES_PD_GD_BOM, token);
            rst = Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_PD_GD_BOM_SELECT);
            return rst;
        }
    }
}
