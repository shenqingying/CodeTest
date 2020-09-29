using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Sonluk.PC.APPCLASS;
using Sonluk.PC.Models;
using Sonluk.UI.Model.CRM.CRM_LoginService;
using Sonluk.UI.Model.MES.MM_CKService;
using Sonluk.UI.Model.MES.PMM_MOULDService;
using Sonluk.UI.Model.MES.SY_GZZX_SBHService;
using Sonluk.UI.Model.MES.TM_CZRService;
using Sonluk.UI.Model.MES.TM_TMINFOService;
using Sonluk.UI.Model.MES.ZS_QJ_QJJLService;
using Sonluk.UI.Model.MES.ZS_SY_CLPBService;
using Sonluk.UI.Model.MES.ZS_SY_JLService;
using Sonluk.UI.Model.MES.ZS_SY_TLService;
using Sonluk.UI.Model.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sonluk.PC.Areas.MES.Controllers
{
    public class ZSController : Controller
    {
        //
        // GET: /MES/ZS/

        string FileSavePath = System.Configuration.ConfigurationManager.AppSettings["HRFile"];

        MESModels mesModels = new MESModels();
        CRMModels crmModels = new CRMModels();
        public ActionResult CLPB_MANAGE()
        {
            AppClass.SetSession("location", 10100);
            return View();
        }

        public ActionResult ZS_TL_MANAGE()
        {
            AppClass.SetSession("location", 10101);
            return View();
        }
        public ActionResult ZS_MFQQJ_MANAGE()
        {
            ActionResult target;
            target = RedirectToAction("SignIn", "Public", new { area = "CRM" });
            if (Request.Cookies["token"] == null)
            {
                target = RedirectToAction("SignIn", "Public", new { area = "CRM" });
            }
            else
            {
                if (string.IsNullOrEmpty(Request.Cookies["token"].Value))
                {
                    target = RedirectToAction("SignIn", "Public", new { area = "CRM" });
                }
                else
                {
                    string token = Request.Cookies["token"].Value;
                    AppClass.SetSession("token", token);
                    TokenInfo rst = crmModels.CRM_Login.get_ptokeninfo_language(token);
                    Response.Cookies["token"].Value = rst.access_token;
                    Response.Cookies["token"].Expires = DateTime.Now.AddDays(10);
                    Session["STAFFID"] = rst.STAFFID;
                    string name = crmModels.HG_STAFF.ReadBySTAFFID(rst.STAFFID, rst.access_token).STAFFNAME;
                    AppClass.SetSession("NAME", crmModels.HG_STAFF.ReadBySTAFFID(rst.STAFFID, token).STAFFNAME);
                    return View();
                }
            }
            AppClass.SetSession("location", 10102);
            return target;
        }
        public ActionResult ZS_KCSELECT_MANAGE()
        {
            AppClass.SetSession("location", 10103);
            return View();
        }
        public ActionResult ZS_MFQQJ_SBLIST()
        {
            ActionResult target;
            target = RedirectToAction("SignIn", "Public", new { area = "CRM" });
            if (Request.Cookies["token"] == null)
            {
                target = RedirectToAction("SignIn", "Public", new { area = "CRM" });
            }
            else
            {
                if (string.IsNullOrEmpty(Request.Cookies["token"].Value))
                {
                    target = RedirectToAction("SignIn", "Public", new { area = "CRM" });
                }
                else
                {
                    string token = Request.Cookies["token"].Value;
                    AppClass.SetSession("token", token);
                    TokenInfo rst = crmModels.CRM_Login.get_ptokeninfo_language(token);
                    Response.Cookies["token"].Value = rst.access_token;
                    Response.Cookies["token"].Expires = DateTime.Now.AddDays(10);
                    Session["STAFFID"] = rst.STAFFID;
                    string name = crmModels.HG_STAFF.ReadBySTAFFID(rst.STAFFID, rst.access_token).STAFFNAME;
                    AppClass.SetSession("NAME", crmModels.HG_STAFF.ReadBySTAFFID(rst.STAFFID, token).STAFFNAME);
                    return View();
                }
            }
            AppClass.SetSession("location", 10104);
            return target;
        }
        public ActionResult ZS_TEST()
        {
            return View();
        }
        public ActionResult ZS_KCMXSELECT_MANAGE()
        {
            AppClass.SetSession("location", 10103);
            return View();
        }
        public ActionResult ZS_SY_JL_SELECT_MANAGE()
        {
            AppClass.SetSession("location", 10106);
            return View();
        }
        public ActionResult ZS_SY_JL_DELETE_MANAGE()
        {
            AppClass.SetSession("location", 10107);
            return View();
        }
        public ActionResult TM_FH_SELECT_MANAGE()
        {
            AppClass.SetSession("location", 10108);
            return View();
        }
        public ActionResult CLPB_MANAGE_SELECT()
        {
            AppClass.SetSession("location", 10110);
            return View();
        }
        public ActionResult ZS_QJ_ERRORJL_SELECT()
        {
            AppClass.SetSession("location", 10111);
            return View();
        }
        public ActionResult ZS_MFQFG_MANAGE()
        {
            ActionResult target;
            target = RedirectToAction("SignIn", "Public", new { area = "CRM" });
            if (Request.Cookies["token"] == null)
            {
                target = RedirectToAction("SignIn", "Public", new { area = "CRM" });
            }
            else
            {
                if (string.IsNullOrEmpty(Request.Cookies["token"].Value))
                {
                    target = RedirectToAction("SignIn", "Public", new { area = "CRM" });
                }
                else
                {
                    string token = Request.Cookies["token"].Value;
                    AppClass.SetSession("token", token);
                    TokenInfo rst = crmModels.CRM_Login.get_ptokeninfo_language(token);
                    Response.Cookies["token"].Value = rst.access_token;
                    Response.Cookies["token"].Expires = DateTime.Now.AddDays(10);
                    Session["STAFFID"] = rst.STAFFID;
                    string name = crmModels.HG_STAFF.ReadBySTAFFID(rst.STAFFID, rst.access_token).STAFFNAME;
                    AppClass.SetSession("NAME", crmModels.HG_STAFF.ReadBySTAFFID(rst.STAFFID, token).STAFFNAME);
                    return View();
                }
            }
            AppClass.SetSession("location", 10112);
            return target;
        }

        public ActionResult ZS_SCJDSELECT()
        {
            AppClass.SetSession("location", 10113);
            return View();
        }
        public ActionResult ZS_SCJDSELECTMX()
        {
            return View();
        }
        public ActionResult ZS_JCJLSELECT()
        {
            AppClass.SetSession("location", 10115);
            return View();
        }
        public ActionResult ZS_JCJLSELECTMX()
        {
            AppClass.SetSession("location", 10115);
            return View();
        }
        public ActionResult ZS_JCJLMANAGE()
        {
            AppClass.SetSession("location", 10116);
            return View();
        }




        [HttpPost]
        public string ZS_SY_CLPB_SELECT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_ZS_SY_CLPB model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_ZS_SY_CLPB>(datastring);
            model.STAFFID = STAFFID;
            MES_ZS_SY_CLPB_SELECT result = mesModels.ZS_SY_CLPB.SELECT(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        public string ZS_SY_CLPB_INSERT(string datastring, string datastring1)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_ZS_SY_CLPB model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_ZS_SY_CLPB>(datastring);
            model.CJR = STAFFID;
            MES_RETURN_UI rst = mesModels.ZS_SY_CLPB.INSERT(model, token);
            if (rst.TYPE == "S")
            {
                MES_ZS_SY_CLPB_WL[] model_wl = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_ZS_SY_CLPB_WL[]>(datastring1);
                for (int a = 0; a < model_wl.Length; a++)
                {
                    model_wl[a].CLPBID = Convert.ToInt32(rst.MESSAGE);
                    model_wl[a].CJR = STAFFID;
                    mesModels.ZS_SY_CLPB.INSERT_WL(model_wl[a], token);
                }
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string ZS_SY_CLPB_DELETE(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_ZS_SY_CLPB model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_ZS_SY_CLPB>(datastring);
            model.XGR = STAFFID;
            model.LB = 1;
            MES_RETURN_UI rst = mesModels.ZS_SY_CLPB.UPDATE(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string ZS_SY_CLPB_UPDATE(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_ZS_SY_CLPB model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_ZS_SY_CLPB>(datastring);
            model.XGR = STAFFID;
            model.LB = 2;
            MES_RETURN_UI rst = mesModels.ZS_SY_CLPB.UPDATE(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string ZS_SY_CLPB_WL_SELECT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_ZS_SY_CLPB_WL model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_ZS_SY_CLPB_WL>(datastring);
            MES_ZS_SY_CLPB_WL_SELECT result = mesModels.ZS_SY_CLPB.SELECT_WL(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        public string ZS_SY_CLPB_WL_INSERT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_ZS_SY_CLPB_WL model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_ZS_SY_CLPB_WL>(datastring);
            model.CJR = STAFFID;
            MES_RETURN_UI result = mesModels.ZS_SY_CLPB.INSERT_WL(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        public string ZS_SY_CLPB_WL_UPDATE(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_ZS_SY_CLPB_WL model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_ZS_SY_CLPB_WL>(datastring);
            model.XGR = STAFFID;
            MES_RETURN_UI result = mesModels.ZS_SY_CLPB.UPDATE_WL(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        public string ZS_SY_TL_SELECT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_ZS_SY_TL model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_ZS_SY_TL>(datastring);
            model.STAFFID = STAFFID;
            try
            {
                if (model.TLTIMES != "")
                {
                    Convert.ToDateTime(model.TLTIMES);
                }
            }
            catch (Exception)
            {
                MES_ZS_SY_TL_SELECT rst = new MES_ZS_SY_TL_SELECT();
                Sonluk.UI.Model.MES.ZS_SY_TLService.MES_RETURN child_MES_RETURN_UI = new Sonluk.UI.Model.MES.ZS_SY_TLService.MES_RETURN();
                child_MES_RETURN_UI.TYPE = "E";
                child_MES_RETURN_UI.MESSAGE = "开始日期格式错误";
                rst.MES_RETURN = child_MES_RETURN_UI;
                return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
            }
            try
            {
                if (model.TLTIMEE != "")
                {
                    Convert.ToDateTime(model.TLTIMEE);
                }
            }
            catch (Exception)
            {
                MES_ZS_SY_TL_SELECT rst = new MES_ZS_SY_TL_SELECT();
                Sonluk.UI.Model.MES.ZS_SY_TLService.MES_RETURN child_MES_RETURN_UI = new Sonluk.UI.Model.MES.ZS_SY_TLService.MES_RETURN();
                child_MES_RETURN_UI.TYPE = "E";
                child_MES_RETURN_UI.MESSAGE = "结束日期格式错误";
                rst.MES_RETURN = child_MES_RETURN_UI;
                return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
            }
            MES_ZS_SY_TL_SELECT result = mesModels.ZS_SY_TL.SELECT(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        public string ZS_SY_TL_INSERT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_ZS_SY_TL model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_ZS_SY_TL>(datastring);
            model.CJR = STAFFID;
            MES_RETURN_UI result = mesModels.ZS_SY_TL.INSERT(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        public string ZS_SY_TL_UPDATE(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_ZS_SY_TL model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_ZS_SY_TL>(datastring);
            model.XGR = STAFFID;
            MES_RETURN_UI result = mesModels.ZS_SY_TL.UPDATE(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        public string GET_TIME_NOW()
        {
            string token = AppClass.GetSession("token").ToString();
            if (token == "")
            {
                if (Request.Cookies["token"] != null)
                {
                    if (!string.IsNullOrEmpty(Request.Cookies["token"].Value))
                    {
                        token = Request.Cookies["token"].Value;
                    }
                }
            }
            return mesModels.PUBLIC_FUNC.GET_TIME(token);
        }
        [HttpPost]
        public string EXPOST_ZS_SY_CLPB(string datastring)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_ZS_SY_CLPB model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_ZS_SY_CLPB>(datastring);
            model.STAFFID = STAFFID;
            MES_ZS_SY_CLPB_SELECT result = mesModels.ZS_SY_CLPB.SELECT(model, token);
            if (result.MES_RETURN.TYPE == "E")
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(result.MES_RETURN);
            }
            try
            {
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/导出模版.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 0;
                string tt = "材料配比代码,原材料代码,原材料代码描述,配比代码,配比代码描述,备注";
                string[] ttlist = tt.Split(',');
                IRow rowtt = sheet.CreateRow(rowcount++);
                int cellIndex = 0;
                for (int a = 0; a < ttlist.Length; a++)
                {
                    rowtt.CreateCell(cellIndex++).SetCellValue(ttlist[a]);
                }
                MES_ZS_SY_CLPB[] datalist = result.MES_ZS_SY_CLPB;
                for (int i = 0; i < datalist.Length; i++)
                {
                    cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].YCLPBDM);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].YCLDMNAME);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].YCLDMREMARK);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].PBDMNAME);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].PBDMREMARK);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].REMARK);
                }
                string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                FileStream file1 = new FileStream(string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), now), FileMode.Create);
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
        [HttpPost]
        public string EXPOST_ZS_SY_JL_SELECT_MX(string datastring)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_ZS_SY_JL_MX[] datalist = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_ZS_SY_JL_MX[]>(datastring);
            try
            {
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/导出模版.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 0;
                string tt = "记录ID,明细ID,抬头文本,记录时间,状态,工厂,源库存地点,源库存地点描述,目标库存地点,目标库存地点描述,客户,客户名称,物料标识卡条码,物料LOT表条码,物料编码,物料描述,批次,模具号,数量,单位,取消标识,修改人,修改时间,操作人,设备描述";
                string[] ttlist = tt.Split(',');
                IRow rowtt = sheet.CreateRow(rowcount++);
                int cellIndex = 0;
                for (int a = 0; a < ttlist.Length; a++)
                {
                    rowtt.CreateCell(cellIndex++).SetCellValue(ttlist[a]);
                }
                for (int i = 0; i < datalist.Length; i++)
                {
                    cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].JLID);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].JLMXID);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].JLMS);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].CJTIME);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].JLMXLBNAME);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].GC);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].KCDD);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].KCDDNAME);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].KCDDMB);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].KCDDNAMEMB);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].KHNO);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].KHMS);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].FTM);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].TM);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].WLH);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].WLMS);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].FPC);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].MOULD);
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(datalist[i].SL));
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].UNITSNAME);
                    if (datalist[i].ISQX == 0)
                    {
                        row.CreateCell(cellIndex++).SetCellValue("");
                    }
                    else
                    {
                        row.CreateCell(cellIndex++).SetCellValue("X");
                    }
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].XGRNAME);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].XGTIME);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].CZRNAME);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].SBMS);
                }
                string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                FileStream file1 = new FileStream(string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), now), FileMode.Create);
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
        [HttpPost]
        public string EXPOST_ZS_TM_FH_SELECT(string datastring)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_TM_TMINFO_LIST[] result = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_TM_TMINFO_LIST[]>(datastring);
            DataTable result1 = Newtonsoft.Json.JsonConvert.DeserializeObject<DataTable>(datastring);
            try
            {
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/导出模版.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 0;
                string tt = "工厂,LOT表条码,生产日期,班次,工作中心,工作中心描述,设备号,物料编码,物料描述,产品状态,数量,单位,电池型号,备注,模具,是否全检,类型,无腔号,颜色,材料配比代码,开始时间,结束时间,全检标记,全检次数,最近全检时间,返工次数,最近返工时间,返工标记,退货标记,报废标记,标识卡条码,批次,工厂,库存地点,客户,客户名称,出库时间";
                string[] ttlist = tt.Split(',');
                IRow rowtt = sheet.CreateRow(rowcount++);
                int cellIndex = 0;
                for (int a = 0; a < ttlist.Length; a++)
                {
                    rowtt.CreateCell(cellIndex++).SetCellValue(ttlist[a]);
                }
                MES_TM_TMINFO_LIST[] datalist = result;
                for (int i = 0; i < datalist.Length; i++)
                {
                    cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].GC);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].TM);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].SCDATE);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].BCMS);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].GZZXBH);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].GZZXMS);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].SBHMS);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].WLH);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].WLMS);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].CPZTNAME);
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(datalist[i].SL));
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].UNITSNAME);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].DCXHMS);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].REMARK);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].MOULD);
                    if (Convert.ToInt32(result1.Rows[i]["BFCOUNT"]) == 0)
                    {
                        row.CreateCell(cellIndex++).SetCellValue("否");
                    }
                    else
                    {
                        row.CreateCell(cellIndex++).SetCellValue("是");
                    }
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].CPTYPENAME);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].WQH);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].MFQCOLORNAME);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].CLPBDM);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].KSTIME);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].JSTIME);
                    if (datalist[i].QJCOUNT > 0)
                    {
                        row.CreateCell(cellIndex++).SetCellValue("X");
                    }
                    else
                    {
                        row.CreateCell(cellIndex++).SetCellValue("");
                    }
                    row.CreateCell(cellIndex++).SetCellValue(result1.Rows[i]["QJCOUNT"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(result1.Rows[i]["QJLASTTIME"].ToString());
                    if (datalist[i].FGCOUNT > 0)
                    {
                        row.CreateCell(cellIndex++).SetCellValue("X");
                    }
                    else
                    {
                        row.CreateCell(cellIndex++).SetCellValue("");
                    }
                    row.CreateCell(cellIndex++).SetCellValue(result1.Rows[i]["FGCOUNT"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(result1.Rows[i]["FGLASTTIME"].ToString());
                    if (Convert.ToInt32(result1.Rows[i]["THCOUNT"]) > 0)
                    {
                        row.CreateCell(cellIndex++).SetCellValue("X");
                    }
                    else
                    {
                        row.CreateCell(cellIndex++).SetCellValue("");
                    }
                    if (Convert.ToInt32(result1.Rows[i]["BFCOUNT"]) > 0)
                    {
                        row.CreateCell(cellIndex++).SetCellValue("X");
                    }
                    else
                    {
                        row.CreateCell(cellIndex++).SetCellValue("");
                    }
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].FTM);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].FTMPC);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].KCDDGC);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].KCDDNAME);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].KHNO);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].KHMS);
                    row.CreateCell(cellIndex++).SetCellValue(result1.Rows[i]["FHTIME"].ToString());
                }
                string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                FileStream file1 = new FileStream(string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), now), FileMode.Create);
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
        [HttpPost]
        public string EXPOST_ZS_SY_TL(string datastring)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_ZS_SY_TL model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_ZS_SY_TL>(datastring);
            model.STAFFID = STAFFID;
            try
            {
                if (model.TLTIMES != "")
                {
                    Convert.ToDateTime(model.TLTIMES);
                }
            }
            catch (Exception)
            {
                rst.TYPE = "E";
                rst.MESSAGE = "开始日期格式错误";
                return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
            }
            try
            {
                if (model.TLTIMEE != "")
                {
                    Convert.ToDateTime(model.TLTIMEE);
                }
            }
            catch (Exception)
            {
                rst.TYPE = "E";
                rst.MESSAGE = "结束日期格式错误";
                return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
            }
            MES_ZS_SY_TL_SELECT result = mesModels.ZS_SY_TL.SELECT(model, token);
            if (result.MES_RETURN.TYPE == "E")
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(result.MES_RETURN);
            }
            try
            {
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/导出模版.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 0;
                string tt = "工厂,投料物料,投料物料描述,投料批次,投料时间,备注";
                string[] ttlist = tt.Split(',');
                IRow rowtt = sheet.CreateRow(rowcount++);
                int cellIndex = 0;
                for (int a = 0; a < ttlist.Length; a++)
                {
                    rowtt.CreateCell(cellIndex++).SetCellValue(ttlist[a]);
                }
                MES_ZS_SY_TL[] datalist = result.MES_ZS_SY_TL;
                for (int i = 0; i < datalist.Length; i++)
                {
                    cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].GC);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].WLH);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].WLMS);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].TLPC);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].TLTIME);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].REMARK);
                }
                string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                FileStream file1 = new FileStream(string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), now), FileMode.Create);
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
        public ActionResult EXPORT_DOWNLOAD(string filename, string filenameout)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", filenameout + ".xlsx");
        }

        [HttpPost]
        public string SY_GZZX_SSBH_SELECT_LB_MFQQJSBBH(string datastring)
        {
            //int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            string token = Session["token"].ToString();
            if (token == "")
            {
                if (Request.Cookies["token"] != null)
                {
                    if (!string.IsNullOrEmpty(Request.Cookies["token"].Value))
                    {
                        token = Request.Cookies["token"].Value;
                    }
                }
            }
            MES_SY_GZZX_SBH model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_GZZX_SBH>(datastring);
            //model.STAFFID = STAFFID;
            MES_SY_GZZX_SBH_SELECT data = mesModels.SY_GZZX_SBH.SELECT_LB(model, token);
            if (data.MES_RETURN.TYPE == "S")
            {
                if (data.MES_SY_GZZX_SBH.Length > 0)
                {
                    Response.Cookies["MFQQJSBBH"].Value = model.SBBH;
                    Response.Cookies["MFQQJSBBH"].Expires = DateTime.Now.AddDays(30);
                }
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }
        [HttpPost]
        public string GET_YGNAME(string GH)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = Session["token"].ToString();
            if (token == "")
            {
                if (Request.Cookies["token"] != null)
                {
                    if (!string.IsNullOrEmpty(Request.Cookies["token"].Value))
                    {
                        token = Request.Cookies["token"].Value;
                    }
                }
            }
            rst = mesModels.PUBLIC_FUNC.GET_YGNAME(GH, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string SET_CZR(string datastring)
        {
            string token = Session["token"].ToString();
            if (token == "")
            {
                if (Request.Cookies["token"] != null)
                {
                    if (!string.IsNullOrEmpty(Request.Cookies["token"].Value))
                    {
                        token = Request.Cookies["token"].Value;
                    }
                }
            }
            MES_TM_CZR model_MES_TM_CZR = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_TM_CZR>(datastring);
            MES_RETURN_UI model_MES_RETURN_UI = mesModels.TM_CZR.INSERT(model_MES_TM_CZR, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(model_MES_RETURN_UI);
        }
        [HttpPost]
        public string GET_CZR(string datastring)
        {
            string token = Session["token"].ToString();
            if (token == "")
            {
                if (Request.Cookies["token"] != null)
                {
                    if (!string.IsNullOrEmpty(Request.Cookies["token"].Value))
                    {
                        token = Request.Cookies["token"].Value;
                    }
                }
            }
            MES_TM_CZR model_MES_TM_CZR = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_TM_CZR>(datastring);
            MES_TM_CZR_SELECT_CZR_NOW rst_MES_TM_CZR_SELECT_CZR_NOW = mesModels.TM_CZR.SELECT_CZR_NOW(model_MES_TM_CZR, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_TM_CZR_SELECT_CZR_NOW);
        }
        [HttpPost]
        public string GET_TMINFO(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_TM_TMINFO model_MES_TM_TMINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_TM_TMINFO>(datastring);
            SELECT_MES_TM_TMINFO_BYTM rst_SELECT_MES_TM_TMINFO_BYTM = mesModels.TM_TMINFO.SELECT(model_MES_TM_TMINFO, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_SELECT_MES_TM_TMINFO_BYTM);
        }
        [HttpPost]
        public string TM_TMINFO_SELECT_KC(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_TM_TMINFO model_MES_TM_TMINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_TM_TMINFO>(datastring);
            model_MES_TM_TMINFO.STAFFID = STAFFID;
            SELECT_MES_TM_TMINFO_BYTM rst_SELECT_MES_TM_TMINFO_BYTM = mesModels.TM_TMINFO.SELECT_KC(model_MES_TM_TMINFO, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_SELECT_MES_TM_TMINFO_BYTM);
        }
        [HttpPost]
        public string GET_TMINFO_QJ(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            if (token == "")
            {
                if (Request.Cookies["token"] != null)
                {
                    if (!string.IsNullOrEmpty(Request.Cookies["token"].Value))
                    {
                        token = Request.Cookies["token"].Value;
                    }
                }
            }
            MES_TM_TMINFO model_MES_TM_TMINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_TM_TMINFO>(datastring);
            SELECT_MES_TM_TMINFO_BYTM rst_SELECT_MES_TM_TMINFO_BYTM = mesModels.TM_TMINFO.SELECT(model_MES_TM_TMINFO, token);
            if (rst_SELECT_MES_TM_TMINFO_BYTM.MES_RETURN.TYPE == "S")
            {
                for (int a = 0; a < rst_SELECT_MES_TM_TMINFO_BYTM.MES_TM_TMINFO_LIST.Length; a++)
                {
                    if (rst_SELECT_MES_TM_TMINFO_BYTM.MES_TM_TMINFO_LIST[a].KSTIME != "")
                    {
                        rst_SELECT_MES_TM_TMINFO_BYTM.MES_TM_TMINFO_LIST[a].KSTIME = Convert.ToDateTime(rst_SELECT_MES_TM_TMINFO_BYTM.MES_TM_TMINFO_LIST[a].KSTIME).ToString("yy.MM.dd HH:mm");
                    }
                    if (rst_SELECT_MES_TM_TMINFO_BYTM.MES_TM_TMINFO_LIST[a].JSTIME != "")
                    {
                        rst_SELECT_MES_TM_TMINFO_BYTM.MES_TM_TMINFO_LIST[a].JSTIME = Convert.ToDateTime(rst_SELECT_MES_TM_TMINFO_BYTM.MES_TM_TMINFO_LIST[a].JSTIME).ToString("yy.MM.dd HH:mm");
                    }
                }
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_SELECT_MES_TM_TMINFO_BYTM);
        }
        [HttpPost]
        public string ZS_QJ_QJJL_QJSB_SELECT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            //int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            if (token == "")
            {
                if (Request.Cookies["token"] != null)
                {
                    if (!string.IsNullOrEmpty(Request.Cookies["token"].Value))
                    {
                        token = Request.Cookies["token"].Value;
                    }
                }
            }
            MES_ZS_QJ_QJSB model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_ZS_QJ_QJSB>(datastring);
            MES_ZS_QJ_QJSB_SELECT result = mesModels.ZS_QJ_QJJL.SELECT_QJSB(model, token);
            if (result.MES_RETURN.TYPE == "S")
            {
                for (int a = 0; a < result.MES_ZS_QJ_QJSB.Length; a++)
                {
                    if (result.MES_ZS_QJ_QJSB[a].TMKSTIME != "")
                    {
                        result.MES_ZS_QJ_QJSB[a].TMKSTIME = Convert.ToDateTime(result.MES_ZS_QJ_QJSB[a].TMKSTIME).ToString("yy.MM.dd HH:mm");
                    }
                    if (result.MES_ZS_QJ_QJSB[a].TMJSTIME != "")
                    {
                        result.MES_ZS_QJ_QJSB[a].TMJSTIME = Convert.ToDateTime(result.MES_ZS_QJ_QJSB[a].TMJSTIME).ToString("yy.MM.dd HH:mm");
                    }
                }
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        public string ZS_QJ_QJJL_QJSB_INSERT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            if (token == "")
            {
                if (Request.Cookies["token"] != null)
                {
                    if (!string.IsNullOrEmpty(Request.Cookies["token"].Value))
                    {
                        token = Request.Cookies["token"].Value;
                    }
                }
            }
            //int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_ZS_QJ_QJSB model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_ZS_QJ_QJSB>(datastring);
            //model.JLR = STAFFID;
            MES_RETURN_UI result = mesModels.ZS_QJ_QJJL.INSERT_QJSB(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        public string ZS_QJ_ERRORJL_INSERT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            if (token == "")
            {
                if (Request.Cookies["token"] != null)
                {
                    if (!string.IsNullOrEmpty(Request.Cookies["token"].Value))
                    {
                        token = Request.Cookies["token"].Value;
                    }
                }
            }
            //int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_ZS_QJ_ERRORJL model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_ZS_QJ_ERRORJL>(datastring);
            //model.CJR = STAFFID;
            MES_RETURN_UI result = mesModels.ZS_QJ_QJJL.INSERT_ERRORJL(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        public string GET_ZS_QJ_ERRORJL_SELECT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_ZS_QJ_ERRORJL model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_ZS_QJ_ERRORJL>(datastring);
            model.STAFFID = STAFFID;
            MES_ZS_QJ_ERRORJL_SELECT result = mesModels.ZS_QJ_QJJL.SELECT_ERRORJL(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        public string ZS_SY_JL_INSERT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            if (token == "")
            {
                if (Request.Cookies["token"] != null)
                {
                    if (!string.IsNullOrEmpty(Request.Cookies["token"].Value))
                    {
                        token = Request.Cookies["token"].Value;
                    }
                }
            }
            //int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_ZS_SY_JL model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_ZS_SY_JL>(datastring);
            //model.CJR = STAFFID;
            MES_RETURN_UI result = mesModels.ZS_SY_JL.INSERT(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        public string ZS_SY_JL_UPDATE(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_ZS_SY_JL model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_ZS_SY_JL>(datastring);
            model.XGR = STAFFID;
            MES_RETURN_UI result = mesModels.ZS_SY_JL.UPDATE(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        public string ZS_SY_JL_INSERTMX(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            if (token == "")
            {
                if (Request.Cookies["token"] != null)
                {
                    if (!string.IsNullOrEmpty(Request.Cookies["token"].Value))
                    {
                        token = Request.Cookies["token"].Value;
                    }
                }
            }
            //int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_ZS_SY_JL_MX model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_ZS_SY_JL_MX>(datastring);
            MES_RETURN_UI result = mesModels.ZS_SY_JL.INSERT_MX(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        public string ZS_SY_JLMX_SELECT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_ZS_SY_JL_MX model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_ZS_SY_JL_MX>(datastring);
            model.STAFFID = STAFFID;
            MES_ZS_SY_JL_MX_SELECT result = mesModels.ZS_SY_JL.SELECT_MX(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        public string SELECT_QJSB()
        {
            string token = AppClass.GetSession("token").ToString();
            MES_ZS_QJ_QJSB model = new MES_ZS_QJ_QJSB();
            model.LB = 1;
            try
            {
                MES_ZS_QJ_QJSB_SELECT data = mesModels.ZS_QJ_QJJL.SELECT_QJSB(model, token);

                //if(data.MES_ZS_QJ_QJSB.Length > 0)
                //{
                //    for(int i = 0;i<data.MES_ZS_QJ_QJSB.Length;i++)
                //    {
                //        if(data.MES_ZS_QJ_QJSB[i].TMKSTIME is DateTime)
                //        {

                //        }
                //        data.MES_ZS_QJ_QJSB[i].TMSTR = Convert.ToDateTime(data.MES_ZS_QJ_QJSB[i].TMKSTIME).ToString("yyyy-MM-dd HH:mm") + "-" + Convert.ToDateTime(data.MES_ZS_QJ_QJSB[i].TMJSTIME).ToString("yyyy-MM-dd HH:mm");
                //    }
                //}
                if (data.MES_RETURN.TYPE == "S")
                {
                    for (int a = 0; a < data.MES_ZS_QJ_QJSB.Length; a++)
                    {
                        if (data.MES_ZS_QJ_QJSB[a].QJZT == 0)
                        {
                            data.MES_ZS_QJ_QJSB[a].ISFREE = 1;
                            data.MES_ZS_QJ_QJSB[a].SCSMTM = "";
                            data.MES_ZS_QJ_QJSB[a].KSTIME = "";
                            data.MES_ZS_QJ_QJSB[a].MOULD = "";
                            data.MES_ZS_QJ_QJSB[a].WLH = "";
                            data.MES_ZS_QJ_QJSB[a].WLMS = "";
                            data.MES_ZS_QJ_QJSB[a].TMKSTIME = "";
                            data.MES_ZS_QJ_QJSB[a].TMJSTIME = "";
                            data.MES_ZS_QJ_QJSB[a].CZRGH = "";
                            data.MES_ZS_QJ_QJSB[a].CZRNAME = "";
                        }
                    }
                }


                return Newtonsoft.Json.JsonConvert.SerializeObject(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }
        [HttpPost]
        public string SELECT_QJSB_ByIsFree(int ISFREE)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_ZS_QJ_QJSB model = new MES_ZS_QJ_QJSB();
            model.LB = 1;
            try
            {
                MES_ZS_QJ_QJSB_SELECT data = mesModels.ZS_QJ_QJJL.SELECT_QJSB(model, token);
                if (data.MES_RETURN.TYPE == "S")
                {
                    for (int a = 0; a < data.MES_ZS_QJ_QJSB.Length; a++)
                    {
                        if (data.MES_ZS_QJ_QJSB[a].QJZT == 0)
                        {
                            data.MES_ZS_QJ_QJSB[a].ISFREE = 1;
                            data.MES_ZS_QJ_QJSB[a].SCSMTM = "";
                            data.MES_ZS_QJ_QJSB[a].KSTIME = "";
                            data.MES_ZS_QJ_QJSB[a].MOULD = "";
                            data.MES_ZS_QJ_QJSB[a].WLH = "";
                            data.MES_ZS_QJ_QJSB[a].WLMS = "";
                            data.MES_ZS_QJ_QJSB[a].TMKSTIME = "";
                            data.MES_ZS_QJ_QJSB[a].TMJSTIME = "";
                            data.MES_ZS_QJ_QJSB[a].CZRGH = "";
                            data.MES_ZS_QJ_QJSB[a].CZRNAME = "";
                        }
                    }
                }
                var query = (from c in data.MES_ZS_QJ_QJSB where c.ISFREE == ISFREE select c).ToList<MES_ZS_QJ_QJSB>();

                MES_ZS_QJ_QJSB[] nnModel = new MES_ZS_QJ_QJSB[query.Count];
                int i = 0;
                foreach (var Temp in query)
                {
                    MES_ZS_QJ_QJSB TempModel = new MES_ZS_QJ_QJSB();
                    TempModel.SBBH = Temp.SBBH;
                    TempModel.GZZXBH = Temp.GZZXBH;
                    TempModel.ISFREE = Temp.ISFREE;
                    TempModel.MOULD = Temp.MOULD;
                    TempModel.WLH = Temp.WLH;
                    TempModel.WLMS = Temp.WLMS;
                    TempModel.SBMS = Temp.SBMS;
                    TempModel.KSTIME = Temp.KSTIME;
                    TempModel.TMKSTIME = Temp.TMKSTIME;
                    TempModel.CZRNAME = Temp.CZRNAME;
                    TempModel.SBFLNAME = Temp.SBFLNAME;
                    TempModel.CZLB = Temp.CZLB;
                    //    TempModel.TMSTR = Convert.ToDateTime(Temp.TMKSTIME).ToString("yyyy-MM-dd HH:mm") + "-" + Convert.ToDateTime(Temp.TMJSTIME).ToString("yyyy-MM-dd HH:mm");
                    nnModel[i] = TempModel;
                    i++;
                }
                data.MES_ZS_QJ_QJSB = nnModel;

                return Newtonsoft.Json.JsonConvert.SerializeObject(data);

            }
            catch (Exception e)
            {
                return e.Message;
            }

        }
        [HttpPost]
        public string SELECT_QJSB_ByIsFreeAnd(int ISFREE)
        {

            string token = AppClass.GetSession("token").ToString();
            MES_ZS_QJ_QJSB model = new MES_ZS_QJ_QJSB();
            model.LB = 1;

            int Temp_CZLB;

            if (ISFREE == 0)
            {
                Temp_CZLB = 1;
            }
            //if (ISFREE == 3)
            //{
            //    Temp_CZLB = 2;
            //}
            else
            {
                Temp_CZLB = 2;
            }
            try
            {
                MES_ZS_QJ_QJSB_SELECT data = mesModels.ZS_QJ_QJJL.SELECT_QJSB(model, token);
                if (data.MES_RETURN.TYPE == "S")
                {
                    for (int a = 0; a < data.MES_ZS_QJ_QJSB.Length; a++)
                    {
                        if (data.MES_ZS_QJ_QJSB[a].QJZT == 0)
                        {
                            data.MES_ZS_QJ_QJSB[a].ISFREE = 1;
                            data.MES_ZS_QJ_QJSB[a].SCSMTM = "";
                            data.MES_ZS_QJ_QJSB[a].KSTIME = "";
                            data.MES_ZS_QJ_QJSB[a].MOULD = "";
                            data.MES_ZS_QJ_QJSB[a].WLH = "";
                            data.MES_ZS_QJ_QJSB[a].WLMS = "";
                            data.MES_ZS_QJ_QJSB[a].TMKSTIME = "";
                            data.MES_ZS_QJ_QJSB[a].TMJSTIME = "";
                            data.MES_ZS_QJ_QJSB[a].CZRGH = "";
                            data.MES_ZS_QJ_QJSB[a].CZRNAME = "";
                        }
                    }
                }
                var query = (from c in data.MES_ZS_QJ_QJSB where c.ISFREE == 0 && c.CZLB == Temp_CZLB select c).ToList<MES_ZS_QJ_QJSB>();
                MES_ZS_QJ_QJSB[] nnModel = new MES_ZS_QJ_QJSB[query.Count];
                int i = 0;
                foreach (var Temp in query)
                {
                    MES_ZS_QJ_QJSB TempModel = new MES_ZS_QJ_QJSB();
                    TempModel.SBBH = Temp.SBBH;
                    TempModel.GZZXBH = Temp.GZZXBH;
                    TempModel.ISFREE = Temp.ISFREE;
                    TempModel.MOULD = Temp.MOULD;
                    TempModel.WLH = Temp.WLH;
                    TempModel.WLMS = Temp.WLMS;
                    TempModel.SBMS = Temp.SBMS;
                    TempModel.KSTIME = Temp.KSTIME;
                    TempModel.TMKSTIME = Temp.TMKSTIME;
                    TempModel.TMJSTIME = Temp.TMJSTIME;
                    TempModel.CZRNAME = Temp.CZRNAME;
                    TempModel.SBFLNAME = Temp.SBFLNAME;
                    TempModel.CZLB = Temp.CZLB;
                    //     TempModel.TMSTR = Convert.ToDateTime(Temp.TMKSTIME).ToString("yyyy-MM-dd HH:mm") + "-" + Convert.ToDateTime(Temp.TMJSTIME).ToString("yyyy-MM-dd HH:mm");
                    nnModel[i] = TempModel;
                    i++;
                }
                data.MES_ZS_QJ_QJSB = nnModel;

                return Newtonsoft.Json.JsonConvert.SerializeObject(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }
        [HttpPost]
        public string Data_Select_CK_ROLE(string GC)
        {
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            string token = Session["token"].ToString();

            MES_MM_CK model_ck = new MES_MM_CK();
            model_ck.STAFFID = STAFFID;
            model_ck.GC = GC;
            MES_MM_CK_SELECT data_ck = mesModels.MM_CK.SELECT_BY_STAFFID(model_ck, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data_ck);
            return s;
        }
        [HttpPost]
        public string MES_TM_TMINFO_SELECT_LIST(string datastring)
        {
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            string token = Session["token"].ToString();
            MES_TM_TMINFO model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_TM_TMINFO>(datastring);
            model.STAFFID = STAFFID;
            List<MES_TM_TMINFO_LIST> model_list = new List<MES_TM_TMINFO_LIST>();
            SELECT_MES_TM_TMINFO_BYTM rst = mesModels.TM_TMINFO.SELECT_LIST(model_list.ToArray(), model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string MES_TM_TMINFO_SELECT_LIST_datatable(string datastring)
        {
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            string token = Session["token"].ToString();
            MES_TM_TMINFO model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_TM_TMINFO>(datastring);
            model.STAFFID = STAFFID;
            List<MES_TM_TMINFO_LIST> model_list = new List<MES_TM_TMINFO_LIST>();
            SELECT_MES_TM_TMINFO_BYTM rst = mesModels.TM_TMINFO.SELECT_LIST_datatable(model_list.ToArray(), model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string IMPORT_READ_ZS_TM_SELECT()
        {
            SELECT_MES_TM_TMINFO_BYTM rst = new SELECT_MES_TM_TMINFO_BYTM();
            Sonluk.UI.Model.MES.TM_TMINFOService.MES_RETURN child_MES_RETURN = new UI.Model.MES.TM_TMINFOService.MES_RETURN();
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            try
            {
                var file = Request.Files[0];
                string year = DateTime.Now.Year.ToString();
                string month = DateTime.Now.Month.ToString();
                string gotname = Path.GetFileName(file.FileName);
                string savePath = FileSavePath + @"\excel\" + year + @"\" + month + @"\" + gotname;
                if (Directory.Exists(FileSavePath + @"\excel\" + year + @"\" + month) == false)
                {
                    Directory.CreateDirectory(FileSavePath + @"\excel\" + year + @"\" + month);
                }
                file.SaveAs(savePath);
                FileInfo fi = new FileInfo(savePath);
                if (fi.Exists == true)
                {
                    DataTable data1 = ExcelToDataTable(savePath, 0, true);
                    System.IO.File.Delete(savePath);
                    if (data1 != null)
                    {
                        if (data1.Columns.Contains("条码") == false)
                        {
                            child_MES_RETURN.TYPE = "E";
                            child_MES_RETURN.MESSAGE = "条码字段不存在，请检查模版！";
                            rst.MES_RETURN = child_MES_RETURN;
                            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                        }
                        for (int a = 0; a < data1.Rows.Count; a++)
                        {
                            if (data1.Rows[a]["条码"].ToString().Trim() != "")
                            {
                                if (data1.Rows[a]["条码"].ToString().Length != 12)
                                {
                                    child_MES_RETURN.TYPE = "E";
                                    child_MES_RETURN.MESSAGE = "第" + (a + 2) + "行条码格式不正确！";
                                    rst.MES_RETURN = child_MES_RETURN;
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                                }
                                if (data1.Rows[a]["条码"].ToString().Trim().Substring(0, 1) != "P")
                                {
                                    child_MES_RETURN.TYPE = "E";
                                    child_MES_RETURN.MESSAGE = "第" + (a + 2) + "行条码格式不正确！";
                                    rst.MES_RETURN = child_MES_RETURN;
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                                }
                                MES_TM_TMINFO model_MES_TM_TMINFO = new MES_TM_TMINFO();
                                model_MES_TM_TMINFO.TM = data1.Rows[a]["条码"].ToString();
                                SELECT_MES_TM_TMINFO_BYTM rst_SELECT_MES_TM_TMINFO_BYTM = mesModels.TM_TMINFO.SELECT_ALL(model_MES_TM_TMINFO, token);
                                if (rst_SELECT_MES_TM_TMINFO_BYTM.MES_RETURN.TYPE != "S")
                                {
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(rst_SELECT_MES_TM_TMINFO_BYTM.MES_RETURN);
                                }
                                if (rst_SELECT_MES_TM_TMINFO_BYTM.MES_TM_TMINFO_LIST.Length == 0)
                                {
                                    child_MES_RETURN.TYPE = "E";
                                    child_MES_RETURN.MESSAGE = "条码" + data1.Rows[a]["条码"].ToString() + "不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(child_MES_RETURN);
                                }
                                if (rst_SELECT_MES_TM_TMINFO_BYTM.MES_TM_TMINFO_LIST[0].MID == "" || rst_SELECT_MES_TM_TMINFO_BYTM.MES_TM_TMINFO_LIST[0].TMLB == 2)
                                {
                                    child_MES_RETURN.TYPE = "E";
                                    child_MES_RETURN.MESSAGE = "条码" + data1.Rows[a]["条码"].ToString() + "不是正确的物料LOT表！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(child_MES_RETURN);
                                }
                            }
                        }
                        List<MES_TM_TMINFO_LIST> model_list = new List<MES_TM_TMINFO_LIST>();
                        for (int a = 0; a < data1.Rows.Count; a++)
                        {
                            if (data1.Rows[a]["条码"].ToString().Trim() != "")
                            {
                                MES_TM_TMINFO_LIST child_MES_TM_TMINFO_LIST = new MES_TM_TMINFO_LIST();
                                child_MES_TM_TMINFO_LIST.TM = data1.Rows[a]["条码"].ToString().Trim();
                                model_list.Add(child_MES_TM_TMINFO_LIST);
                            }

                        }
                        MES_TM_TMINFO model = new MES_TM_TMINFO();
                        model.LB = 1;
                        model.STAFFID = STAFFID;
                        rst = mesModels.TM_TMINFO.SELECT_LIST_datatable(model_list.ToArray(), model, token);
                        return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                    }
                    child_MES_RETURN.TYPE = "E";
                    child_MES_RETURN.MESSAGE = "文件读取失败！";
                    rst.MES_RETURN = child_MES_RETURN;
                    return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                }
                else
                {
                    child_MES_RETURN.TYPE = "E";
                    child_MES_RETURN.MESSAGE = "文件读取失败！";
                    rst.MES_RETURN = child_MES_RETURN;
                    return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                }
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                rst.MES_RETURN = child_MES_RETURN;
                return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
            }
        }
        [HttpPost]
        public string IMPORT_READ_ZS_JL_TM_SELECT()
        {
            MES_ZS_SY_JL_MX_SELECT rst = new MES_ZS_SY_JL_MX_SELECT();
            Sonluk.UI.Model.MES.ZS_SY_JLService.MES_RETURN child_MES_RETURN = new UI.Model.MES.ZS_SY_JLService.MES_RETURN();
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            try
            {
                var file = Request.Files[0];
                string year = DateTime.Now.Year.ToString();
                string month = DateTime.Now.Month.ToString();
                string gotname = Path.GetFileName(file.FileName);
                string savePath = FileSavePath + @"\excel\" + year + @"\" + month + @"\" + gotname;
                if (Directory.Exists(FileSavePath + @"\excel\" + year + @"\" + month) == false)
                {
                    Directory.CreateDirectory(FileSavePath + @"\excel\" + year + @"\" + month);
                }
                file.SaveAs(savePath);
                FileInfo fi = new FileInfo(savePath);
                if (fi.Exists == true)
                {
                    DataTable data1 = ExcelToDataTable(savePath, 0, true);
                    System.IO.File.Delete(savePath);
                    if (data1 != null)
                    {
                        if (data1.Columns.Contains("条码") == false)
                        {
                            child_MES_RETURN.TYPE = "E";
                            child_MES_RETURN.MESSAGE = "条码字段不存在，请检查模版！";
                            rst.MES_RETURN = child_MES_RETURN;
                            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                        }
                        for (int a = 0; a < data1.Rows.Count; a++)
                        {
                            if (data1.Rows[a]["条码"].ToString().Trim() != "")
                            {
                                if (data1.Rows[a]["条码"].ToString().Length != 12)
                                {
                                    child_MES_RETURN.TYPE = "E";
                                    child_MES_RETURN.MESSAGE = "第" + (a + 2) + "行条码格式不正确！";
                                    rst.MES_RETURN = child_MES_RETURN;
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                                }
                                if (data1.Rows[a]["条码"].ToString().Trim().Substring(0, 1) != "P")
                                {
                                    child_MES_RETURN.TYPE = "E";
                                    child_MES_RETURN.MESSAGE = "第" + (a + 2) + "行条码格式不正确！";
                                    rst.MES_RETURN = child_MES_RETURN;
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                                }
                                MES_TM_TMINFO model_MES_TM_TMINFO = new MES_TM_TMINFO();
                                model_MES_TM_TMINFO.TM = data1.Rows[a]["条码"].ToString();
                                SELECT_MES_TM_TMINFO_BYTM rst_SELECT_MES_TM_TMINFO_BYTM = mesModels.TM_TMINFO.SELECT_ALL(model_MES_TM_TMINFO, token);
                                if (rst_SELECT_MES_TM_TMINFO_BYTM.MES_RETURN.TYPE != "S")
                                {
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(rst_SELECT_MES_TM_TMINFO_BYTM.MES_RETURN);
                                }
                                if (rst_SELECT_MES_TM_TMINFO_BYTM.MES_TM_TMINFO_LIST.Length == 0)
                                {
                                    child_MES_RETURN.TYPE = "E";
                                    child_MES_RETURN.MESSAGE = "条码" + data1.Rows[a]["条码"].ToString() + "不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(child_MES_RETURN);
                                }
                                if (rst_SELECT_MES_TM_TMINFO_BYTM.MES_TM_TMINFO_LIST[0].MID == "" || rst_SELECT_MES_TM_TMINFO_BYTM.MES_TM_TMINFO_LIST[0].TMLB == 2)
                                {
                                    child_MES_RETURN.TYPE = "E";
                                    child_MES_RETURN.MESSAGE = "条码" + data1.Rows[a]["条码"].ToString() + "不是正确的物料LOT表！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(child_MES_RETURN);
                                }
                            }
                        }
                        string TM = "";
                        for (int a = 0; a < data1.Rows.Count; a++)
                        {
                            if (data1.Rows[a]["条码"].ToString().Trim() != "")
                            {
                                if (TM != "")
                                {
                                    TM = TM + ",";
                                }
                                TM = TM + data1.Rows[a]["条码"].ToString().Trim();
                            }
                        }
                        MES_ZS_SY_JL_MX model = new MES_ZS_SY_JL_MX();
                        model.TM = TM;
                        model.LB = 5;
                        rst = mesModels.ZS_SY_JL.SELECT_MX(model, token);
                        return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                    }
                    child_MES_RETURN.TYPE = "E";
                    child_MES_RETURN.MESSAGE = "文件读取失败！";
                    rst.MES_RETURN = child_MES_RETURN;
                    return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                }
                else
                {
                    child_MES_RETURN.TYPE = "E";
                    child_MES_RETURN.MESSAGE = "文件读取失败！";
                    rst.MES_RETURN = child_MES_RETURN;
                    return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                }
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                rst.MES_RETURN = child_MES_RETURN;
                return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
            }
        }
        public DataTable ExcelToDataTable(string fileName, int sheetName, bool isFirstRowColumn)
        {
            FileStream fs = null;
            ISheet sheet = null;
            IWorkbook workbook = null;
            DataTable data = new DataTable();
            int startRow = 0;
            try
            {
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                if (fileName.IndexOf(".xlsx") > 0) // 2007版本
                    workbook = new XSSFWorkbook(fs);
                else if (fileName.IndexOf(".xls") > 0) // 2003版本
                    workbook = new HSSFWorkbook(fs);


                sheet = workbook.GetSheetAt(sheetName);

                if (sheet != null)
                {
                    IRow firstRow = sheet.GetRow(0);
                    int cellCount = firstRow.LastCellNum; //一行最后一个cell的编号 即总的列数

                    if (isFirstRowColumn)
                    {
                        for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                        {
                            ICell cell = firstRow.GetCell(i);
                            if (cell != null)
                            {
                                string cellValue = cell.StringCellValue;
                                if (cellValue != null)
                                {
                                    DataColumn column = new DataColumn(cellValue);
                                    data.Columns.Add(column);
                                }
                            }
                        }
                        startRow = sheet.FirstRowNum + 1;
                    }
                    else
                    {
                        startRow = sheet.FirstRowNum;
                    }

                    //最后一列的标号
                    int rowCount = sheet.LastRowNum;
                    for (int i = startRow; i <= rowCount; ++i)
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue; //没有数据的行默认是""　　　　　　

                        DataRow dataRow = data.NewRow();
                        for (int j = row.FirstCellNum; j < cellCount; ++j)
                        {
                            if (row.GetCell(j) != null) //同理，没有数据的单元格都默认是""
                                dataRow[j] = row.GetCell(j).ToString();
                        }
                        data.Rows.Add(dataRow);
                    }
                }

                return data;
            }
            catch
            {
                //MessageBox.Show("Exception: " + ex.Message);
                return null;
            }
        }
        [HttpPost]
        public string EXPOST_ZS_KCSELECT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));

            MES_RETURN_UI rst = new MES_RETURN_UI();
            MES_TM_TMINFO model_MES_TM_TMINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_TM_TMINFO>(datastring);
            model_MES_TM_TMINFO.STAFFID = STAFFID;
            SELECT_MES_TM_TMINFO_BYTM result = mesModels.TM_TMINFO.SELECT_KC(model_MES_TM_TMINFO, token);
            if (result.MES_RETURN.TYPE == "E")
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(result.MES_RETURN);
            }
            try
            {
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/导出模版.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 0;
                string tt = "工厂,库存地点,物料编码,物料描述,模具号,是否全检,全检标记,批次,材料配比代码,合格数量,暂放数量,不合格数量,库存单位,记录日期,入库日期";
                string[] ttlist = tt.Split(',');
                IRow rowtt = sheet.CreateRow(rowcount++);
                int cellIndex = 0;
                for (int a = 0; a < ttlist.Length; a++)
                {
                    rowtt.CreateCell(cellIndex++).SetCellValue(ttlist[a]);
                }
                MES_TM_TMINFO_KCHZ[] datalist = result.MES_TM_TMINFO_KCHZ;
                for (int i = 0; i < datalist.Length; i++)
                {
                    cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].KCDDGC);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].KCDD);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].WLH);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].WLMS);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].MOULD);
                    if (datalist[i].ISFIM == 1)
                    {
                        row.CreateCell(cellIndex++).SetCellValue("是");
                    }
                    else
                    {
                        row.CreateCell(cellIndex++).SetCellValue("否");
                    }
                    if (datalist[i].QJCOUNT > 0)
                    {
                        row.CreateCell(cellIndex++).SetCellValue("X");
                    }
                    else
                    {
                        row.CreateCell(cellIndex++).SetCellValue("");
                    }
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].PC);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].CLPBDM);
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(datalist[i].HGSL));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(datalist[i].ZFSL));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(datalist[i].NOHGSL));
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].UNITSNAME);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].JLTIME);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].YKDATE);
                }
                string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                FileStream file1 = new FileStream(string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), now), FileMode.Create);
                workbook.Write(file1);
                file1.Close();
                rst.TYPE = "S";
                rst.MESSAGE = now;
                AppClass.SetSession("EXPOST_ZS_KCSELECT", "库存台账导出");
            }
            catch
            {
                rst.TYPE = "E";
                rst.MESSAGE = "生成文件失败！";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string EXPOST_ZS_SCJD(string datastring)
        {
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            string token = Session["token"].ToString();
            MES_RETURN_UI rst = new MES_RETURN_UI();
            MES_TM_TMINFO model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_TM_TMINFO>(datastring);
            model.STAFFID = STAFFID;
            List<MES_TM_TMINFO_LIST> model_list = new List<MES_TM_TMINFO_LIST>();
            SELECT_MES_TM_TMINFO_BYTM result = mesModels.TM_TMINFO.SELECT_LIST_datatable(model_list.ToArray(), model, token);
            if (result.MES_RETURN.TYPE == "E")
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(result.MES_RETURN);
            }
            try
            {
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/导出模版.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 0;
                string tt = "工厂,工作中心,班次,模具号,物料编码,物料描述,物料类别,报废标记,条码数量,库存单位";
                string[] ttlist = tt.Split(',');
                IRow rowtt = sheet.CreateRow(rowcount++);
                int cellIndex = 0;
                for (int a = 0; a < ttlist.Length; a++)
                {
                    rowtt.CreateCell(cellIndex++).SetCellValue(ttlist[a]);
                }
                DataTable datalist = result.DATALIST;
                double sl = 0;
                for (int i = 0; i < datalist.Rows.Count; i++)
                {
                    cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["GC"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["GZZXMS"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["BCMS"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["MOULD"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["WLH"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["WLMS"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["WLLBNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["BFBJ"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(datalist.Rows[i]["SL"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["UNITSNAME"].ToString());
                    sl = sl + Convert.ToDouble(datalist.Rows[i]["SL"].ToString());
                }
                //cellIndex = 0;
                //IRow row1 = sheet.CreateRow(rowcount++);
                //row1.CreateCell(cellIndex++).SetCellValue("");
                //row1.CreateCell(cellIndex++).SetCellValue("");
                //row1.CreateCell(cellIndex++).SetCellValue("");
                //row1.CreateCell(cellIndex++).SetCellValue("");
                //row1.CreateCell(cellIndex++).SetCellValue("");
                //row1.CreateCell(cellIndex++).SetCellValue("");
                //row1.CreateCell(cellIndex++).SetCellValue("");
                //row1.CreateCell(cellIndex++).SetCellValue("");
                //row1.CreateCell(cellIndex++).SetCellValue(sl);
                //row1.CreateCell(cellIndex++).SetCellValue("");
                string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                FileStream file1 = new FileStream(string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), now), FileMode.Create);
                workbook.Write(file1);
                file1.Close();
                rst.TYPE = "S";
                rst.MESSAGE = now;
                AppClass.SetSession("EXPOST_ZS_SCJD", "注塑车间生产进度导出");
            }
            catch
            {
                rst.TYPE = "E";
                rst.MESSAGE = "生成文件失败！";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string EXPOST_ZS_SCJDMX(string datastring)
        {
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            string token = Session["token"].ToString();
            MES_RETURN_UI rst = new MES_RETURN_UI();
            MES_TM_TMINFO model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_TM_TMINFO>(datastring);
            model.STAFFID = STAFFID;
            List<MES_TM_TMINFO_LIST> model_list = new List<MES_TM_TMINFO_LIST>();
            SELECT_MES_TM_TMINFO_BYTM result = mesModels.TM_TMINFO.SELECT_LIST_datatable(model_list.ToArray(), model, token);
            if (result.MES_RETURN.TYPE == "E")
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(result.MES_RETURN);
            }
            try
            {
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/导出模版.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 0;
                string tt = "工厂,工作中心,生产日期,班次,物料编码,物料描述,模具号,物料类别,物料LOT表条码,物料标识卡条码,产品状态,类型,设备号,开始时间,结束时间,条码数量,单位,报废标记,备注";
                string[] ttlist = tt.Split(',');
                IRow rowtt = sheet.CreateRow(rowcount++);
                int cellIndex = 0;
                for (int a = 0; a < ttlist.Length; a++)
                {
                    rowtt.CreateCell(cellIndex++).SetCellValue(ttlist[a]);
                }
                DataTable datalist = result.DATALIST;
                double sl = 0;
                for (int i = 0; i < datalist.Rows.Count; i++)
                {
                    cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["GC"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["GZZXMS"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["SCDATE"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["BCMS"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["WLH"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["WLMS"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["MOULD"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["WLLBNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["TM"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["FTM"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["CPZTNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["CPTYPENAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["SBHMS"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["KSTIMESTRING"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["JSTIMESTRING"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(datalist.Rows[i]["SL"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["UNITSNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["BFBJ"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["REMARK"].ToString());
                    sl = sl + Convert.ToDouble(datalist.Rows[i]["SL"].ToString());
                }
                //cellIndex = 0;
                //IRow row1 = sheet.CreateRow(rowcount++);
                //row1.CreateCell(cellIndex++).SetCellValue("");
                //row1.CreateCell(cellIndex++).SetCellValue("");
                //row1.CreateCell(cellIndex++).SetCellValue("");
                //row1.CreateCell(cellIndex++).SetCellValue("");
                //row1.CreateCell(cellIndex++).SetCellValue("");
                //row1.CreateCell(cellIndex++).SetCellValue("");
                //row1.CreateCell(cellIndex++).SetCellValue("");
                //row1.CreateCell(cellIndex++).SetCellValue("");
                //row1.CreateCell(cellIndex++).SetCellValue("");
                //row1.CreateCell(cellIndex++).SetCellValue("");
                //row1.CreateCell(cellIndex++).SetCellValue("");
                //row1.CreateCell(cellIndex++).SetCellValue("");
                //row1.CreateCell(cellIndex++).SetCellValue("");
                //row1.CreateCell(cellIndex++).SetCellValue("");
                //row1.CreateCell(cellIndex++).SetCellValue("");
                //row1.CreateCell(cellIndex++).SetCellValue(sl);
                //row1.CreateCell(cellIndex++).SetCellValue("");
                //row1.CreateCell(cellIndex++).SetCellValue("");
                //row1.CreateCell(cellIndex++).SetCellValue("");
                string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                FileStream file1 = new FileStream(string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), now), FileMode.Create);
                workbook.Write(file1);
                file1.Close();
                rst.TYPE = "S";
                rst.MESSAGE = now;
                AppClass.SetSession("EXPOST_ZS_SCJDMX", "注塑车间生产进度导出");
            }
            catch
            {
                rst.TYPE = "E";
                rst.MESSAGE = "生成文件失败！";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        public ActionResult EXPORT_DOWNLOAD_Session(string filename, string sessionname)
        {
            string name = AppClass.GetSession(sessionname).ToString();
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", name + ".xlsx");
        }
        [HttpPost]
        public string EXPOST_ZS_KCMXSELECT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));

            MES_RETURN_UI rst = new MES_RETURN_UI();
            MES_TM_TMINFO model_MES_TM_TMINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_TM_TMINFO>(datastring);
            model_MES_TM_TMINFO.STAFFID = STAFFID;
            SELECT_MES_TM_TMINFO_BYTM result = mesModels.TM_TMINFO.SELECT_KC(model_MES_TM_TMINFO, token);
            if (result.MES_RETURN.TYPE == "E")
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(result.MES_RETURN);
            }
            try
            {
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/导出模版.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 0;
                string tt = "工厂,库存地点,物料编码,物料描述,模具号,是否全检,全检标记,批次,物料标识卡条码,物料LOT表条码,材料配比代码,记录日期,入库日期,产品状态,类型,设备号,开始时间,结束时间,数量,单位,备注";
                string[] ttlist = tt.Split(',');
                IRow rowtt = sheet.CreateRow(rowcount++);
                int cellIndex = 0;
                for (int a = 0; a < ttlist.Length; a++)
                {
                    rowtt.CreateCell(cellIndex++).SetCellValue(ttlist[a]);
                }
                DataTable datalist = result.DATALIST;
                for (int i = 0; i < datalist.Rows.Count; i++)
                {
                    cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["KCDDGC"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["KCDD"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["WLH"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["WLMS"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["MOULD"].ToString());
                    if (Convert.ToInt32(datalist.Rows[i]["ISFIM"].ToString()) == 0)
                    {
                        row.CreateCell(cellIndex++).SetCellValue("否");
                    }
                    else
                    {
                        row.CreateCell(cellIndex++).SetCellValue("是");
                    }
                    if (Convert.ToInt32(datalist.Rows[i]["QJCOUNT"].ToString()) == 0)
                    {
                        row.CreateCell(cellIndex++).SetCellValue("");
                    }
                    else
                    {
                        row.CreateCell(cellIndex++).SetCellValue("X");
                    }
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["FPC"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["FTM"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["TM"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["CLPBDM"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["JLTIMESTRING"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["YKDATE"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["CPZTNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["CPTYPENAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["SBHMS"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["KSTIMESTRING"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["JSTIMESTRING"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(datalist.Rows[i]["SL"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["UNITSNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["REMARK"].ToString());

                }
                string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                FileStream file1 = new FileStream(string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), now), FileMode.Create);
                workbook.Write(file1);
                file1.Close();
                rst.TYPE = "S";
                rst.MESSAGE = now;
                AppClass.SetSession("EXPOST_ZS_KCMXSELECT", "库存台账明细导出");
            }
            catch
            {
                rst.TYPE = "E";
                rst.MESSAGE = "生成文件失败！";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string EXPOST_ZS_QJ_ERRORJL(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_RETURN_UI rst = new MES_RETURN_UI();

            MES_ZS_QJ_ERRORJL model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_ZS_QJ_ERRORJL>(datastring);
            model.STAFFID = STAFFID;
            MES_ZS_QJ_ERRORJL_SELECT result = mesModels.ZS_QJ_QJJL.SELECT_ERRORJL(model, token);

            if (result.MES_RETURN.TYPE == "E")
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(result.MES_RETURN);
            }
            try
            {
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/导出模版.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 0;
                string tt = "工厂,工作中心,设备描述,错误条码,错误信息,操作账号名,操作时间,操作人工号,操作人姓名";
                string[] ttlist = tt.Split(',');
                IRow rowtt = sheet.CreateRow(rowcount++);
                int cellIndex = 0;
                for (int a = 0; a < ttlist.Length; a++)
                {
                    rowtt.CreateCell(cellIndex++).SetCellValue(ttlist[a]);
                }
                MES_ZS_QJ_ERRORJL[] datalist = result.MES_ZS_QJ_ERRORJL;
                for (int i = 0; i < datalist.Length; i++)
                {
                    cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].GC);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].GZZXBH);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].SBMS);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].ERRORTM);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].ERRORINFO);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].CJRNAME);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].CJTIME);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].CZRGH);
                    row.CreateCell(cellIndex++).SetCellValue(datalist[i].CZRNAME);
                }
                string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                FileStream file1 = new FileStream(string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), now), FileMode.Create);
                workbook.Write(file1);
                file1.Close();
                rst.TYPE = "S";
                rst.MESSAGE = now;
                AppClass.SetSession("EXPOST_ZS_QJ_ERRORJL", "全检错误记录导出");
            }
            catch
            {
                rst.TYPE = "E";
                rst.MESSAGE = "生成文件失败！";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string EXPOST_TM_FH_SELECT_MB()
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            try
            {
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/导出模版.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 0;
                string tt = "条码";
                string[] ttlist = tt.Split(',');
                IRow rowtt = sheet.CreateRow(rowcount++);
                int cellIndex = 0;
                for (int a = 0; a < ttlist.Length; a++)
                {
                    rowtt.CreateCell(cellIndex++).SetCellValue(ttlist[a]);
                }
                string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                FileStream file1 = new FileStream(string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), now), FileMode.Create);
                workbook.Write(file1);
                file1.Close();
                rst.TYPE = "S";
                rst.MESSAGE = now;
                AppClass.SetSession("EXPOST_TM_FH_SELECT_MB", "导入模板");
            }
            catch
            {
                rst.TYPE = "E";
                rst.MESSAGE = "生成文件失败！";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string PMM_MOULD_SELECT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_PMM_MOULD model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_PMM_MOULD>(datastring);
            MES_PMM_MOULD_SELECT result = mesModels.PMM_MOULD.SELECT(model, STAFFID, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }

        [HttpPost]
        public void set_session(string datastring, string sessionname)
        {
            AppClass.SetSession(sessionname, datastring);
        }
        [HttpPost]
        public string get_session(string sessionname)
        {
            string session = AppClass.GetSession(sessionname).ToString();
            AppClass.remove_session(sessionname);
            return session;
        }
        [HttpPost]
        public string GET_TIMEForSBLIST()
        {
            //string token = AppClass.GetSession("token").ToString();
            string token = "";
            if (token == "")
            {
                if (Request.Cookies["token"] != null)
                {
                    if (!string.IsNullOrEmpty(Request.Cookies["token"].Value))
                    {
                        token = Request.Cookies["token"].Value;
                    }
                }
            }
            //return Convert.ToDateTime(mesModels.PUBLIC_FUNC.GET_TIME(token)).ToString("yyyy-MM-dd HH:mm");
            return token;
        }
        [HttpPost]
        public string ZS_SY_JL_INSERTQJQXJL(string datastring, string datastring1)
        {
            string token = AppClass.GetSession("token").ToString();
            if (token == "")
            {
                if (Request.Cookies["token"] != null)
                {
                    if (!string.IsNullOrEmpty(Request.Cookies["token"].Value))
                    {
                        token = Request.Cookies["token"].Value;
                    }
                }
            }
            //int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_ZS_SY_JL_QJQXJL model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_ZS_SY_JL_QJQXJL>(datastring);
            MES_ZS_SY_JL_QJQXJLMX[] model2 = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_ZS_SY_JL_QJQXJLMX[]>(datastring1);
            MES_RETURN_UI result = mesModels.ZS_SY_JL.INSERT_QJQXJL(model, model2, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        public string ZS_SY_JL_UPDATEQJQXJL(string datastring, string datastring1)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            if (token == "")
            {
                if (Request.Cookies["token"] != null)
                {
                    if (!string.IsNullOrEmpty(Request.Cookies["token"].Value))
                    {
                        token = Request.Cookies["token"].Value;
                    }
                }
            }
            //int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_ZS_SY_JL_QJQXJL model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_ZS_SY_JL_QJQXJL>(datastring);
            MES_ZS_SY_JL_QJQXJLMX[] model2 = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_ZS_SY_JL_QJQXJLMX[]>(datastring1);
            model.STAFFID = STAFFID;
            MES_RETURN_UI result = mesModels.ZS_SY_JL.UPDATE_QJQXJL(model, model2, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        public string ZS_SY_JL_SELECT_QJQXJL(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_ZS_SY_JL_QJQXJL model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_ZS_SY_JL_QJQXJL>(datastring);
            model.STAFFID = STAFFID;
            MES_ZS_SY_JL_SELECT result = mesModels.ZS_SY_JL.SELECT_QJQXJL(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }

        [HttpPost]
        public string EXPOST_ZS_JCJL(string datastring)
        {
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            string token = Session["token"].ToString();
            MES_RETURN_UI rst = new MES_RETURN_UI();
            MES_ZS_SY_JL_QJQXJL model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_ZS_SY_JL_QJQXJL>(datastring);
            model.STAFFID = STAFFID;
            MES_ZS_SY_JL_SELECT result = mesModels.ZS_SY_JL.SELECT_QJQXJL(model, token);
            if (result.MES_RETURN.TYPE == "E")
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(result.MES_RETURN);
            }
            try
            {
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/导出模版.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 0;
                string tt = "工厂,工作中心,设备描述,模具号,班次,类别,检测数,异常品数,不合格品数,库存单位";
                string[] ttlist = tt.Split(',');
                IRow rowtt = sheet.CreateRow(rowcount++);
                int cellIndex = 0;
                for (int a = 0; a < ttlist.Length; a++)
                {
                    rowtt.CreateCell(cellIndex++).SetCellValue(ttlist[a]);
                }
                DataTable datalist = result.DATALIST;
                double[] sl = new double[3] { 0, 0, 0 };
                for (int i = 0; i < datalist.Rows.Count; i++)
                {
                    cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["GC"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["GZZXMS"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["SBMS"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["MOULD"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["QJBCNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["JLMXLBNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(datalist.Rows[i]["JLSL"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(datalist.Rows[i]["QXSL"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(datalist.Rows[i]["QXNOHGSL"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["UNITSNAME"].ToString());
                    sl[0] = sl[0] + Convert.ToDouble(datalist.Rows[i]["JLSL"].ToString());
                    sl[1] = sl[1] + Convert.ToDouble(datalist.Rows[i]["QXSL"].ToString());
                    sl[2] = sl[2] + Convert.ToDouble(datalist.Rows[i]["QXNOHGSL"].ToString());
                }
                //cellIndex = 0;
                //IRow row1 = sheet.CreateRow(rowcount++);
                //row1.CreateCell(cellIndex++).SetCellValue("");
                //row1.CreateCell(cellIndex++).SetCellValue("");
                //row1.CreateCell(cellIndex++).SetCellValue("");
                //row1.CreateCell(cellIndex++).SetCellValue("");
                //row1.CreateCell(cellIndex++).SetCellValue("");
                //row1.CreateCell(cellIndex++).SetCellValue(sl[0]);
                //row1.CreateCell(cellIndex++).SetCellValue(sl[1]);
                //row1.CreateCell(cellIndex++).SetCellValue(sl[2]);
                //row1.CreateCell(cellIndex++).SetCellValue("");
                string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                FileStream file1 = new FileStream(string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), now), FileMode.Create);
                workbook.Write(file1);
                file1.Close();
                rst.TYPE = "S";
                rst.MESSAGE = now;
                AppClass.SetSession("EXPOST_ZS_JCJL", "检测记录查询导出");
            }
            catch
            {
                rst.TYPE = "E";
                rst.MESSAGE = "生成文件失败！";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        public string EXPOST_ZS_JCJLMX(string datastring)
        {
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            string token = Session["token"].ToString();
            MES_RETURN_UI rst = new MES_RETURN_UI();
            MES_ZS_SY_JL_QJQXJL model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_ZS_SY_JL_QJQXJL>(datastring);
            model.STAFFID = STAFFID;
            MES_ZS_SY_JL_SELECT result = mesModels.ZS_SY_JL.SELECT_QJQXJL(model, token);
            if (result.MES_RETURN.TYPE == "E")
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(result.MES_RETURN);
            }
            try
            {
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/导出模版.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 0;
                string tt = "工厂,工作中心,设备描述,模具号,检测日期,班次,物料编码,物料描述,检测开始,检测结束,类别,物料LOT表条码,生产开始,生产结束,检测数,异常品数,不合格品数,不良原因,备注";
                string[] ttlist = tt.Split(',');
                IRow rowtt = sheet.CreateRow(rowcount++);
                int cellIndex = 0;
                for (int a = 0; a < ttlist.Length; a++)
                {
                    rowtt.CreateCell(cellIndex++).SetCellValue(ttlist[a]);
                }
                DataTable datalist = result.DATALIST;
                double[] sl = new double[3] { 0, 0, 0 };
                for (int i = 0; i < datalist.Rows.Count; i++)
                {
                    cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["GC"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["GZZXMS"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["SBMS"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["MOULD"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["QJRQ"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["QJBCNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["WLH"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["WLMS"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["QJKSTIME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["QJJSTIME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["JLMXLBNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["TM"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["KSTIME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["JSTIME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(datalist.Rows[i]["JLSL"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(datalist.Rows[i]["QXSL"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(datalist.Rows[i]["QXNOHGSL"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["NOHGYYNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(datalist.Rows[i]["REMARK"].ToString());
                    sl[0] = sl[0] + Convert.ToDouble(datalist.Rows[i]["JLSL"].ToString());
                    sl[1] = sl[1] + Convert.ToDouble(datalist.Rows[i]["QXSL"].ToString());
                    sl[2] = sl[2] + Convert.ToDouble(datalist.Rows[i]["QXNOHGSL"].ToString());
                }
                cellIndex = 0;
                IRow row1 = sheet.CreateRow(rowcount++);
                //row1.CreateCell(cellIndex++).SetCellValue("");
                //row1.CreateCell(cellIndex++).SetCellValue("");
                //row1.CreateCell(cellIndex++).SetCellValue("");
                //row1.CreateCell(cellIndex++).SetCellValue("");
                //row1.CreateCell(cellIndex++).SetCellValue("");
                //row1.CreateCell(cellIndex++).SetCellValue("");
                //row1.CreateCell(cellIndex++).SetCellValue("");
                //row1.CreateCell(cellIndex++).SetCellValue("");
                //row1.CreateCell(cellIndex++).SetCellValue("");
                //row1.CreateCell(cellIndex++).SetCellValue("");
                //row1.CreateCell(cellIndex++).SetCellValue("");
                //row1.CreateCell(cellIndex++).SetCellValue("");
                //row1.CreateCell(cellIndex++).SetCellValue("");
                //row1.CreateCell(cellIndex++).SetCellValue(sl[0]);
                //row1.CreateCell(cellIndex++).SetCellValue(sl[1]);
                //row1.CreateCell(cellIndex++).SetCellValue(sl[2]);
                //row1.CreateCell(cellIndex++).SetCellValue("");
                //row1.CreateCell(cellIndex++).SetCellValue("");
                string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                FileStream file1 = new FileStream(string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), now), FileMode.Create);
                workbook.Write(file1);
                file1.Close();
                rst.TYPE = "S";
                rst.MESSAGE = now;
                AppClass.SetSession("EXPOST_ZS_JCJLMX", "检测记录明细查询导出");
            }
            catch
            {
                rst.TYPE = "E";
                rst.MESSAGE = "生成文件失败！";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }

    }
}
