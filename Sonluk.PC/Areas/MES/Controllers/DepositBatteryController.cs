using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using Sonluk.PC.APPCLASS;
using Sonluk.PC.Areas.MES.Models;
using Sonluk.PC.Models;
using Sonluk.UI.Model.MES.SY_GCService;
using Sonluk.UI.Model.MES.TM_TMINFOService;
using Sonluk.UI.Model.MES.TM_ZFDCMXService;
using Sonluk.UI.Model.MODEL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sonluk.PC.Areas.MES.Controllers
{
    public class DepositBatteryController : Controller
    {
        //
        // GET: /MES/DepositBattery/
        MESModels mesModels = new MESModels();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DepositBattery()
        {
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            string token = AppClass.GetSession("token").ToString();
            MODEL_Assign_WorkOrder model = new MODEL_Assign_WorkOrder();
            AppClass.SetSession("location", 153);
            MES_SY_GC model_MES_SY_GC = new MES_SY_GC();
            model_MES_SY_GC.STAFFID = STAFFID;
            MES_SY_GC[] MES_SY_GC_list = mesModels.SY_GC.SELECT_BY_ROLE(model_MES_SY_GC, token);
            model.MES_SY_GC = MES_SY_GC_list;
            ViewData.Model = model;
            return View();
        }

        public ActionResult DepositBattery_Print()
        {
            string token = AppClass.GetSession("token").ToString();
            List<SELECT_MES_TM_TMINFO_PRINT> rst = new List<SELECT_MES_TM_TMINFO_PRINT>();
            MES_TM_TMINFO_LIST[] model_MES_TM_TMINFO_LIST = (MES_TM_TMINFO_LIST[])Session["MES_TM_TMINFO_LIST"];
            for (int i = 0; i < model_MES_TM_TMINFO_LIST.Length; i++)
            {
                SELECT_MES_TM_TMINFO_PRINT child_SELECT_MES_TM_TMINFO_PRINT = new SELECT_MES_TM_TMINFO_PRINT();
                child_SELECT_MES_TM_TMINFO_PRINT = mesModels.TM_TMINFO.SELECT_BYID_CHILD(model_MES_TM_TMINFO_LIST[i].GC, model_MES_TM_TMINFO_LIST[i].TM, token);
                rst.Add(child_SELECT_MES_TM_TMINFO_PRINT);
            }
            return View(rst);
        }

        [HttpPost]
        public string GET_TM_ZFDC(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_TM_TMINFO model_MES_TM_TMINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_TM_TMINFO>(datastring);
            SELECT_MES_TM_TMINFO_BYTM rst_SELECT_MES_TM_TMINFO_BYTM = mesModels.TM_TMINFO.SELECT_ZFDC(model_MES_TM_TMINFO, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_SELECT_MES_TM_TMINFO_BYTM);
        }
        [HttpPost]
        public string GET_TM_ZFDC_BY_ROLE(string datastring)
        {
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            string token = AppClass.GetSession("token").ToString();
            MES_TM_TMINFO model_MES_TM_TMINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_TM_TMINFO>(datastring);
            model_MES_TM_TMINFO.STAFFID = STAFFID;
            SELECT_MES_TM_TMINFO_BYTM rst_SELECT_MES_TM_TMINFO_BYTM = mesModels.TM_TMINFO.SELECT_ZFDC_BY_ROLE(model_MES_TM_TMINFO, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_SELECT_MES_TM_TMINFO_BYTM);
        }
        [HttpPost]
        public string GET_ZFDCMX(string TM)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_TM_ZFDCMX_SELECT rst_MES_TM_ZFDCMX_SELECT = mesModels.TM_ZFDCMX.SELECT(TM, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_TM_ZFDCMX_SELECT);
        }

        [HttpPost]
        public string EXPORT_ZFDC(string datastring)
        {
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_RETURN_UI rst = new MES_RETURN_UI();
            try
            {
                MES_TM_TMINFO_LIST[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_TM_TMINFO_LIST[]>(datastring);
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/MES/ExportFile/暂放素电查询导出.xls", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new HSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 1;
                for (int i = 0; i < model.Length; i++)
                {
                    int cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TM);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].WLH);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].WLMS);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].GC);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].GZZXBH);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].GZZXMS);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].SBHMS);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].DCXHMS);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].DCDJMS);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].TH);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].ZFDCLBNAME);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].PC);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].CPZTNAME);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].KSTIME);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JSTIME);
                }
                string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                FileStream file1 = new FileStream(string.Format(@"{0}/Areas/MES/ExportFile/{1}.xls", Server.MapPath("~"), now + STAFFID + "4"), FileMode.Create);
                workbook.Write(file1);
                file1.Close();
                rst.TYPE = "S";
                rst.MESSAGE = now + STAFFID + "4";
            }
            catch
            {
                rst.TYPE = "E";
                rst.MESSAGE = "生产文件失败！";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }

        public ActionResult EXPORT_READ_ZFDC(string filename)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/MES/ExportFile/{1}.xls", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", "暂放素电清单.xls");
        }

        [HttpPost]
        public string DELETE_TM(string TM)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_RETURN_UI rst_MES_RETURN_UI = mesModels.TM_TMINFO.DELETE(TM, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_RETURN_UI);
        }

        [HttpPost]
        public string UPDATE_ZFDC(string datastring1, string datastring2)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            string token = AppClass.GetSession("token").ToString();
            MES_TM_TMINFO model_MES_TM_TMINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_TM_TMINFO>(datastring1);
            model_MES_TM_TMINFO.JLR = STAFFID;
            MES_RETURN_UI rst_MES_RETURN_UI = mesModels.TM_TMINFO.UPDATE_ZFDC(model_MES_TM_TMINFO, token);
            if (rst_MES_RETURN_UI.TYPE == "S")
            {
                UI.Model.MES.TM_ZFDCMXService.MES_TM_ZFDCMX model_MES_TM_ZFDCMX = new UI.Model.MES.TM_ZFDCMXService.MES_TM_ZFDCMX();
                model_MES_TM_ZFDCMX.TM = model_MES_TM_TMINFO.TM;
                rst_MES_RETURN_UI = mesModels.TM_ZFDCMX.DELETE(model_MES_TM_ZFDCMX, token);
                if (rst_MES_RETURN_UI.TYPE == "S")
                {
                    Sonluk.UI.Model.MES.TM_ZFDCMXService.MES_TM_ZFDCMX[] model_MES_TM_ZFDCMX_list = Newtonsoft.Json.JsonConvert.DeserializeObject<Sonluk.UI.Model.MES.TM_ZFDCMXService.MES_TM_ZFDCMX[]>(datastring2);
                    for (int i = 0; i < model_MES_TM_ZFDCMX_list.Length; i++)
                    {
                        model_MES_TM_ZFDCMX_list[i].TM = model_MES_TM_TMINFO.TM;
                        rst = mesModels.TM_ZFDCMX.INSERT(model_MES_TM_ZFDCMX_list[i], token);
                    }
                }
                else
                {
                    rst = rst_MES_RETURN_UI;
                }
            }
            else
            {
                rst = rst_MES_RETURN_UI;
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }

        [HttpPost]
        public string POST_PRINT_ZFDC(string datastring)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            MES_TM_TMINFO_LIST[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_TM_TMINFO_LIST[]>(datastring);
            AppClass.SetSession("MES_TM_TMINFO_LIST", model);
            rst.TYPE = "S";
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }

        [HttpPost]
        public string POST_PRINT_ZFDC_SINGEL(string datastring)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            MES_TM_TMINFO_LIST model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_TM_TMINFO_LIST>(datastring);
            MES_TM_TMINFO_LIST[] model_MES_TM_TMINFO_LIST = new MES_TM_TMINFO_LIST[1];
            model_MES_TM_TMINFO_LIST[0] = model;
            AppClass.SetSession("MES_TM_TMINFO_LIST", model_MES_TM_TMINFO_LIST);
            rst.TYPE = "S";
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
    }
}
