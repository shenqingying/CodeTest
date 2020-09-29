using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using Sonluk.PC.APPCLASS;
using Sonluk.PC.Areas.MES.Models;
using Sonluk.PC.Models;
using Sonluk.UI.Model.MES.MES_TPMService;
using Sonluk.UI.Model.MES.MM_CKService;
using Sonluk.UI.Model.MES.SY_GCService;
using Sonluk.UI.Model.MES.SY_STAFFService;
using Sonluk.UI.Model.MES.SY_TYPEMXService;
using Sonluk.UI.Model.MES.SY_TYPEService;
using Sonluk.UI.Model.MODEL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sonluk.PC.Areas.MES.Controllers
{
    public class TPMController : Controller
    {
        //
        // GET: /MES/TPM/
        MESModels mesModels = new MESModels();
        CRMModels crmModels = new CRMModels();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TPM_SELECT()
        {
            string token = AppClass.GetSession("token").ToString();
            AppClass.SetSession("location", 200);
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_SY_GC gclist = new MES_SY_GC();
            gclist.STAFFID = STAFFID;
            MES_SY_GC[] gc = mesModels.SY_GC.SELECT_BY_ROLE(gclist, token);
            MES_MM_CK model_ck = new MES_MM_CK();
            model_ck.STAFFID = STAFFID;
            MES_MM_CK_SELECT data_ck = mesModels.MM_CK.SELECT_BY_STAFFID(model_ck, token);
            MES_SY_TYPEMX model_gg = new MES_SY_TYPEMX();
            model_gg.TYPEID = 20;
            MES_SY_TYPEMXLIST[] data_gg = mesModels.SY_TYPEMX.SELECT(model_gg, token);

            MODLEDataGather data = new MODLEDataGather();
            data.Sy_gc = gc;
            data.MES_MM_CK_SELECT = data_ck;
            data.Sy_typemxlist = data_gg;
            ViewData.Model = data;
            //MES_SY_TYPE[] sjlb = mesModels.SY_TYPE.SELECT(token);
            //MES_SY_GC gcmc = new MES_SY_GC();
            //gcmc.STAFFID = STAFFID;
            //MES_SY_GC[] gcsj = mesModels.SY_GC.read(gcmc, token);
            //MODLEDataGather zd_data = new MODLEDataGather();

            //zd_data.Sy_type = sjlb;
            //zd_data.Sy_gc = gcsj;
            //ViewData.Model = zd_data;
            return View();
        }
        [HttpPost]
        public string GET_TPM_INFO(string GC, string CJRQ, int ISFREE, string CJR, string TPNO, string LGORT, int TPGG, int TPTYPE)//, int ISFREE, string CJRQ, string CJR)
        {
            string token = AppClass.GetSession("token").ToString();
            ZSL_BCS025 model_TMINFO = new ZSL_BCS025();
            model_TMINFO.WERKS = GC;
            model_TMINFO.TPNO = TPNO;
            model_TMINFO.LGORT = LGORT;
            model_TMINFO.TPGG = TPGG;
            model_TMINFO.ISFREE = ISFREE;
            model_TMINFO.CJRQ = CJRQ;
            model_TMINFO.CJRNAME = CJR;
            model_TMINFO.TPTYPE = TPTYPE;
            ZBCFUN_TPINFO_SELECT data = mesModels.MES_TPM.SELECT_TPM(model_TMINFO);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);

        }
        [HttpPost]
        public string INSERT_TPM_INFO(string COUNT, string data)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            string STAFFNAME = AppClass.GetSession("NAME").ToString();
            ZSL_BCS025 model_TMINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<ZSL_BCS025>(data);
            model_TMINFO.CJR = STAFFID;
            model_TMINFO.CJRNAME = STAFFNAME;
            ZBCFUN_TPINFO_INSERT i = mesModels.MES_TPM.INSERT_TPM(model_TMINFO, COUNT);
            return Newtonsoft.Json.JsonConvert.SerializeObject(i);
        }
        public ActionResult TPM_Manage()
        {
            string token = AppClass.GetSession("token").ToString();
            AppClass.SetSession("location", 201);
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_SY_GC gclist = new MES_SY_GC();
            gclist.STAFFID = STAFFID;
            MES_SY_GC[] gc = mesModels.SY_GC.SELECT_BY_ROLE(gclist, token);
            MES_MM_CK model_ck = new MES_MM_CK();
            model_ck.STAFFID = STAFFID;
            MES_MM_CK_SELECT data_ck = mesModels.MM_CK.SELECT_BY_STAFFID(model_ck, token);
            MES_SY_TYPEMX model_gg = new MES_SY_TYPEMX();
            //model_gg.TYPEID = 20;
            MES_SY_TYPEMXLIST[] data_gg = mesModels.SY_TYPEMX.SELECT(model_gg, token);

            MODLEDataGather data = new MODLEDataGather();
            data.Sy_gc = gc;
            data.MES_MM_CK_SELECT = data_ck;
            data.Sy_typemxlist = data_gg;
            ViewData.Model = data;
            return View();
        }
        [HttpPost]
        public string DELETE_TPM_INFO(string TPNO)
        {
            string token = AppClass.GetSession("token").ToString();
            ZBCFUN_TPINFO_INSERT DEL = mesModels.MES_TPM.DELETE_TPM(TPNO);
            return Newtonsoft.Json.JsonConvert.SerializeObject(DEL);
        }
        [HttpPost]
        public string DELETE_TPM_INFOPL(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            ZSL_BCS025[] model_TMINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<ZSL_BCS025[]>(datastring);
            ZBCFUN_TPINFO_INSERT DEL = new ZBCFUN_TPINFO_INSERT();
            for (int i = 0; i < model_TMINFO.Length; i++)
            {
                DEL = mesModels.MES_TPM.DELETE_TPM(model_TMINFO[i].TPNO);
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(DEL);
        }
        [HttpPost]
        public string UPDATE_TPM_INFO(string data)
        {
            ZSL_BCS025 model_TMINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<ZSL_BCS025>(data);
            ZBCFUN_TPINFO_INSERT u = mesModels.MES_TPM.UPDATE_TPM(model_TMINFO);
            return Newtonsoft.Json.JsonConvert.SerializeObject(u);
        }
        [HttpPost]
        public string EXPOST_TPMSELECT(string alldata)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            try
            {
                ZSL_BCT009[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<ZSL_BCT009[]>(alldata);
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/MES/ExportFile/托盘信息查询导出.xls", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new HSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 1;
                for (int i = 0; i < model.Length; i++)
                {
                    int cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TPNO);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].WERKS);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].LGORT);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].LGOBE);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TPGGNAME);
                    if (model[i].ISFREE == 1)
                    {
                        row.CreateCell(cellIndex++).SetCellValue("非空闲");
                    }
                    else if (model[i].ISFREE == 2)
                    {
                        row.CreateCell(cellIndex++).SetCellValue("空闲");
                    }
                    row.CreateCell(cellIndex++).SetCellValue(model[i].CJRNAME);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].CJRQ);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].CJSJ);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TPLYNAME);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].ZHYDRQ);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TPTYPENAME);
                }
                string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                FileStream file1 = new FileStream(string.Format(@"{0}/Areas/MES/ExportFile/{1}.xls", Server.MapPath("~"), now), FileMode.Create);
                workbook.Write(file1);
                file1.Close();
                rst.TYPE = "S";
                rst.MESSAGE = now;
            }
            catch
            {
                rst.TYPE = "E";
                rst.MESSAGE = "生成文件失败！";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        public ActionResult EXPORT_READ_TPMSELECT(string filename)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/MES/ExportFile/{1}.xls", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", "托盘信息查询导出.xls");
        }
        [HttpPost]
        public string POST_PRINT_TPM_LIST(string datastring)
        {
            ZSL_BCS025[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<ZSL_BCS025[]>(datastring);
            AppClass.SetSession("ZSL_BCS025", model);
            MES_RETURN_UI rst = new MES_RETURN_UI();
            rst.TYPE = "S";
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        public ActionResult TPM_PRINT()
        {
            string token = AppClass.GetSession("token").ToString();
            List<MODEL_RWQD_PRINT> rst = new List<MODEL_RWQD_PRINT>();
            ZSL_BCS025[] model_ZSL_BCS025 = (ZSL_BCS025[])Session["ZSL_BCS025"];

            for (int i = 0; i < model_ZSL_BCS025.Length; i++)
            {
                MODEL_RWQD_PRINT child_MODEL_RWQD_PRINT = new MODEL_RWQD_PRINT();
                child_MODEL_RWQD_PRINT.ZSL_BCS025 = model_ZSL_BCS025[i];
                rst.Add(child_MODEL_RWQD_PRINT);
            }
            return View(rst);
        }
        //[HttpPost]
        //public string GET_STAFF(string datastring)
        //{
        //    string token = AppClass.GetSession("token").ToString();
        //    int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
        //    MES_SY_STAFF model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_STAFF>(datastring);
        //    MES_SY_STAFF_SELECT rst_MES_SY_STAFF_SELECT = mesModels.SY_STAFF.SELECT(model, token);
        //    return Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_SY_STAFF_SELECT);
        //}
        [HttpPost]
        public string INSERT_TM_WZHM(string datastring)
        {
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            string STAFFNAME = AppClass.GetSession("NAME").ToString();
            ZSL_BCT011 model_ZSL_BCT011 = new ZSL_BCT011();
            model_ZSL_BCT011.CJR = STAFFID;
            model_ZSL_BCT011.CJRNAME = STAFFNAME;
            ZSL_BCT012[] model_ZSL_BCT012 = Newtonsoft.Json.JsonConvert.DeserializeObject<ZSL_BCT012[]>(datastring);
            ZBCFUN_TP_ZHM_GL res = mesModels.MES_TPM.INSERT_TP_WZHM(model_ZSL_BCT011, model_ZSL_BCT012);
            return Newtonsoft.Json.JsonConvert.SerializeObject(res);
        }
        [HttpPost]
        public string INSERT_TM_ZHM(string datastring)
        {
            ZSL_BCT012[] model_ZSL_BCT012 = Newtonsoft.Json.JsonConvert.DeserializeObject<ZSL_BCT012[]>(datastring);
            ZSL_BCT011 model_ZSL_BCT011 = new ZSL_BCT011();
            ZBCFUN_TP_ZHM_GL res = mesModels.MES_TPM.INSERT_TP_ZHM(model_ZSL_BCT011, model_ZSL_BCT012);
            return Newtonsoft.Json.JsonConvert.SerializeObject(res);
        }
        public ActionResult TPM_ZHMADD()
        {
            string token = AppClass.GetSession("token").ToString();
            AppClass.SetSession("location", 202);
            return View();
        }
        public ActionResult TPM_ZHNO_Manage()
        {
            string token = AppClass.GetSession("token").ToString();
            AppClass.SetSession("location", 204);
            return View();
        }
        public ActionResult TPM_ZHNO_SELECT()
        {
            string token = AppClass.GetSession("token").ToString();
            AppClass.SetSession("location", 203);
            return View();
        }
        [HttpPost]
        public string SELECT_TP_ZHNOa(string TPZHNO, string CJRQKS, string CJRQJS, string CJRNAME)
        {
            ZBCFUN_TP_ZHM_GL res = mesModels.MES_TPM.SELECT_TP_ZHNOa(TPZHNO, CJRQKS, CJRQJS, CJRNAME);
            return Newtonsoft.Json.JsonConvert.SerializeObject(res);
        }
        [HttpPost]
        public string SELECT_TP_ZHNOb(string TPZHNO)
        {
            ZBCFUN_TP_ZHM_GL res = mesModels.MES_TPM.SELECT_TP_ZHNOb(TPZHNO);
            return Newtonsoft.Json.JsonConvert.SerializeObject(res);
        }
        [HttpPost]
        public string DELETE_TP_TPNO(string TPZHNO)
        {
            ZBCFUN_TP_ZHM_GL res = mesModels.MES_TPM.DELETE_TP_TPNO(TPZHNO);
            return Newtonsoft.Json.JsonConvert.SerializeObject(res);
        }
        [HttpPost]
        public string DELETE_TP_TPZHNO(string datastring)
        {
            ZSL_BCT012 model_ZSL_BCT012 = Newtonsoft.Json.JsonConvert.DeserializeObject<ZSL_BCT012>(datastring);
            ZBCFUN_TP_ZHM_GL res = mesModels.MES_TPM.DELETE_TP_TPZHNO(model_ZSL_BCT012);
            return Newtonsoft.Json.JsonConvert.SerializeObject(res);
        }
        [HttpPost]
        public string POST_PRINT_TPMZHNO_LIST(string datastring)
        {
            ZSL_BCT011[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<ZSL_BCT011[]>(datastring);
            AppClass.SetSession("ZSL_BCT011", model);
            MES_RETURN_UI rst = new MES_RETURN_UI();
            rst.TYPE = "S";
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        public ActionResult TPM_ZHNO_PRINT()
        {
            string token = AppClass.GetSession("token").ToString();
            List<MODEL_RWQD_PRINT> rst = new List<MODEL_RWQD_PRINT>();
            ZSL_BCT011[] model_ZSL_BCT011 = (ZSL_BCT011[])Session["ZSL_BCT011"];
            for (int i = 0; i < model_ZSL_BCT011.Length; i++)
            {
                MODEL_RWQD_PRINT child_MODEL_RWQD_PRINT = new MODEL_RWQD_PRINT();
                child_MODEL_RWQD_PRINT.ZSL_BCT011 = model_ZSL_BCT011[i];
                ZBCFUN_TP_ZHM_GL res = mesModels.MES_TPM.SELECT_TP_ZHNOb(model_ZSL_BCT011[i].TPZHNO);
                child_MODEL_RWQD_PRINT.Zsl_bct012 = res.IT_TPZHNO_GL;
                rst.Add(child_MODEL_RWQD_PRINT);
            }
            return View(rst);
        }
        [HttpPost]
        public string EXPOST_TPZHNOSELECT(string alldata, string TPCOUNT)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            try
            {
                ZSL_BCT011[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<ZSL_BCT011[]>(alldata);
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/MES/ExportFile/托盘组合码信息查询导出.xls", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new HSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 1;
                for (int i = 0; i < model.Length; i++)
                {
                    int cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TPZHNO);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].CJRNAME);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].CJRQ);
                    ZBCFUN_TP_ZHM_GL res = mesModels.MES_TPM.SELECT_TP_ZHNOb(model[i].TPZHNO);
                    TPCOUNT = "";
                    for (int j = 0; j < res.IT_TPZHNO_GL.Length; j++)
                    {
                        TPCOUNT += res.IT_TPZHNO_GL[j].TPNO + "；";
                    }
                    row.CreateCell(cellIndex++).SetCellValue(TPCOUNT);
                }
                string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                FileStream file1 = new FileStream(string.Format(@"{0}/Areas/MES/ExportFile/{1}.xls", Server.MapPath("~"), now), FileMode.Create);
                workbook.Write(file1);
                file1.Close();
                rst.TYPE = "S";
                rst.MESSAGE = now;
            }
            catch
            {
                rst.TYPE = "E";
                rst.MESSAGE = "生成文件失败！";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        public ActionResult EXPORT_READ_TPMZHNOSELECT(string filename)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/MES/ExportFile/{1}.xls", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", "托盘组合码信息查询导出.xls");
        }
    }
}