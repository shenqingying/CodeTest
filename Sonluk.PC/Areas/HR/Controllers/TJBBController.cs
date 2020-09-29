using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Sonluk.PC.APPCLASS;
using Sonluk.PC.Models;
using Sonluk.UI.Model.HR.RY_RYINFO_RSDAService;
using Sonluk.UI.Model.HR.RY_RYINFOService;
using Sonluk.UI.Model.HR.SY_CHANGEINFOService;
using Sonluk.UI.Model.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sonluk.PC.Areas.HR.Controllers
{
    public class TJBBController : Controller
    {
        //
        // GET: /HR/TJBB/
        HRModels hrmodels = new HRModels();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TJ_GLBB()
        {
            AppClass.SetSession("location", 185);
            return View();
        }
        public ActionResult GSMX_CXBB()
        {
            AppClass.SetSession("location", 189);
            return View();
        }
        public ActionResult WJWG_CXBB()
        {
            AppClass.SetSession("location", 190);
            return View();
        }
        public ActionResult WBZW_CXBB()
        {
            AppClass.SetSession("location", 196);
            return View();
        }
        public ActionResult BIRTH_CXBB()
        {
            AppClass.SetSession("location", 197);
            return View();
        }
        public ActionResult TJBB_CHANGEINFO_RYINFO()
        {
            AppClass.SetSession("location", 10010);
            return View();
        }
        public ActionResult TJBB_ZCREPORT()
        {
            AppClass.SetSession("location", 10019);
            return View();
        }
        [HttpPost]
        public string GET_YGINFO(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_RY_RYINFO model_HR_RY_RYINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_RYINFO>(datastring);
            HR_RY_RYINFO_SELECT rst = hrmodels.RY_RYINFO.SELECT(model_HR_RY_RYINFO, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string EXPOST_TJBB(string datastring, string JZDATE, int WZGL)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            HR_RY_RYINFO model_HR_RY_RYINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_RYINFO>(datastring);
            HR_RY_RYINFO_SELECT rst_HR_RY_RYINFO_SELECT = hrmodels.RY_RYINFO.SELECT(model_HR_RY_RYINFO, token);
            if (rst_HR_RY_RYINFO_SELECT.MES_RETURN.TYPE != "S")
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(rst_HR_RY_RYINFO_SELECT.MES_RETURN);
            }
            HR_RY_RYINFO_LIST[] model_HR_RY_RYINFO_LIST = rst_HR_RY_RYINFO_SELECT.HR_RY_RYINFO_LIST;
            try
            {
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/工龄计算报表导出.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 1;
                for (int i = 0; i < model_HR_RY_RYINFO_LIST.Length; i++)
                {
                    double gl = getMonthNumber_YEAR(model_HR_RY_RYINFO_LIST[i].RZDATE, JZDATE);
                    if (gl >= WZGL)
                    {
                        int cellIndex = 0;
                        IRow row = sheet.CreateRow(rowcount++);
                        row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].GH));
                        row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].YGNAME));
                        row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].ZZTYPENAME));
                        row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].ZZNO));
                        row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].RZDATE));
                        row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(getMonthNumber(model_HR_RY_RYINFO_LIST[i].RZDATE, JZDATE)));
                        row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].GLQSR));
                        row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(getMonthNumber(model_HR_RY_RYINFO_LIST[i].GLQSR, JZDATE)));
                        row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].BIRTHDAT));
                        row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].EDUCACTIONNAME));
                        row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].XB));
                        row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].GSNAME));
                        row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].DEPTNAME));
                        row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].GSBMNAME));
                        row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].YGTYPENAME));
                        row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].ZZZTNAME));
                        row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].PHONENUMBER));
                    }
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
        public ActionResult EXPORT_DOWNLOAD_TJBB(string filename)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", "工龄计算报表导出.xlsx");
        }
        public string getMonthNumber(string date1, string date2)
        {
            string[] newdate1 = date1.Split('-');
            string[] newdate2 = date2.Split('-');
            int year1 = Convert.ToInt32(newdate1[0]);
            int year2 = Convert.ToInt32(newdate2[0]);
            int month1 = Convert.ToInt32(newdate1[1]);
            int month2 = Convert.ToInt32(newdate2[1]);
            int len = (year2 - year1) * 12 + (month2 - month1);

            int day = Convert.ToInt32(newdate2[2]) - Convert.ToInt32(newdate1[2]);
            if (day < 0)
            {
                len -= 1;
            }
            double year = Math.Floor((double)len / 12);
            int month = len % 12;
            return year + "年" + month + "月";
        }
        public double getMonthNumber_YEAR(string date1, string date2)
        {
            string[] newdate1 = date1.Split('-');
            string[] newdate2 = date2.Split('-');
            int year1 = Convert.ToInt32(newdate1[0]);
            int year2 = Convert.ToInt32(newdate2[0]);
            int month1 = Convert.ToInt32(newdate1[1]);
            int month2 = Convert.ToInt32(newdate2[1]);
            int len = (year2 - year1) * 12 + (month2 - month1);

            int day = Convert.ToInt32(newdate2[2]) - Convert.ToInt32(newdate1[2]);
            if (day < 0)
            {
                len -= 1;
            }
            double year = Math.Floor((double)len / 12);
            return year;
        }
        [HttpPost]
        public string SELECT_GSGL(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_RY_RYINFO model_HR_RY_RYINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_RYINFO>(datastring);
            HR_RY_RYINFO_SELECT rst = hrmodels.RY_RYINFO.SELECT_GSGL(model_HR_RY_RYINFO, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string SELECT_WJGL(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_RY_RYINFO model_HR_RY_RYINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_RYINFO>(datastring);
            HR_RY_RYINFO_SELECT rst = hrmodels.RY_RYINFO.SELECT_WJGL(model_HR_RY_RYINFO, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string SELECT_WBZW(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_RY_RYINFO model_HR_RY_RYINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_RYINFO>(datastring);
            HR_RY_RYINFO_SELECT rst = hrmodels.RY_RYINFO.SELECT_WBZW(model_HR_RY_RYINFO, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string EXPOST_GSGLBB(string alldata)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_RY_RYINFO_LIST[] model_HR_RY_RYINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_RYINFO_LIST[]>(alldata);
            try
            {
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/导出模版.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 0;
                string tt = "工号,姓名,公司,归属部门,岗位,工伤发生日,工伤级数,医疗起始日,医疗截止日";
                string[] ttlist = tt.Split(',');
                IRow rowtt = sheet.CreateRow(rowcount++);
                int cellIndex = 0;
                for (int a = 0; a < ttlist.Length; a++)
                {
                    rowtt.CreateCell(cellIndex++).SetCellValue(ttlist[a]);
                }
                for (int i = 0; i < model_HR_RY_RYINFO.Length; i++)
                {
                    cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO[i].GH));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO[i].YGNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO[i].GSNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO[i].DEPTNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO[i].JOBSNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO[i].GSDATE));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO[i].GSLEVELNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO[i].YLKSDATE));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO[i].YLJSDATE));
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
        public ActionResult EXPORT_DOWNLOAD_GSGLBB(string filename)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", "工伤明细查询报表.xlsx");
        }
        [HttpPost]
        public string EXPOST_WJGLBB(string alldata)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_RY_RYINFO_LIST[] model_HR_RY_RYINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_RYINFO_LIST[]>(alldata);
            try
            {
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/导出模版.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 0;
                string tt = "工号,姓名,公司,归属部门,违纪发生日期";
                string[] ttlist = tt.Split(',');
                IRow rowtt = sheet.CreateRow(rowcount++);
                int cellIndex = 0;
                for (int a = 0; a < ttlist.Length; a++)
                {
                    rowtt.CreateCell(cellIndex++).SetCellValue(ttlist[a]);
                }
                for (int i = 0; i < model_HR_RY_RYINFO.Length; i++)
                {
                    cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO[i].GH));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO[i].YGNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO[i].GSNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO[i].DEPTNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO[i].FSDATE));
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
        public ActionResult EXPORT_DOWNLOAD_WJGLBB(string filename)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", "违纪违规查询报表.xlsx");
        }
        [HttpPost]
        public string EXPOST_WBZWBB(string alldata)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_RY_RYINFO_LIST[] model_HR_RY_RYINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_RYINFO_LIST[]>(alldata);
            try
            {
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/导出模版.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 0;
                string tt = "工号,姓名,公司,归属部门,职务名称,聘用单位,聘用日期,截止日期";
                string[] ttlist = tt.Split(',');
                IRow rowtt = sheet.CreateRow(rowcount++);
                int cellIndex = 0;
                for (int a = 0; a < ttlist.Length; a++)
                {
                    rowtt.CreateCell(cellIndex++).SetCellValue(ttlist[a]);
                }
                for (int i = 0; i < model_HR_RY_RYINFO.Length; i++)
                {
                    cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO[i].GH));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO[i].YGNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO[i].GSNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO[i].GSBMNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO[i].WBZWNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO[i].WBZWDW));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO[i].WBPYRQ));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO[i].WBJZRQ));
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
        public ActionResult EXPORT_DOWNLOAD_WBZWBB(string filename)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", "外部职务明细查询报表.xlsx");
        }
        [HttpPost]
        public string EXPOST_BIRTHDAY(string alldata)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_RY_RYINFO_LIST[] model_HR_RY_RYINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_RYINFO_LIST[]>(alldata);
            try
            {
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/导出模版.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 0;
                string tt = "工号,姓名,公司,归属部门,员工类别,在职状态,性别,入职日期,出生日期";
                string[] ttlist = tt.Split(',');
                IRow rowtt = sheet.CreateRow(rowcount++);
                int cellIndex = 0;
                for (int a = 0; a < ttlist.Length; a++)
                {
                    rowtt.CreateCell(cellIndex++).SetCellValue(ttlist[a]);
                }
                for (int i = 0; i < model_HR_RY_RYINFO.Length; i++)
                {
                    cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO[i].GH));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO[i].YGNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO[i].GSNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO[i].GSBMNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO[i].YGTYPENAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO[i].ZZZTNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO[i].XB));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO[i].RZDATE));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO[i].BIRTHDAT));
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
        public ActionResult EXPORT_DOWNLOAD_BIRTHDAY(string filename)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", "生气花名册查询报表.xlsx");
        }

        [HttpPost]
        public string SY_CHANGEINFO_SELECT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_SY_CHANGEINFO model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_SY_CHANGEINFO>(datastring);
            HR_SY_CHANGEINFO_SELECT result = hrmodels.SY_CHANGEINFO.SELECT(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        public string EXPOST_TJBB_CHANGEINFO_RYINFO(string datastring)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_SY_CHANGEINFO model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_SY_CHANGEINFO>(datastring);
            HR_SY_CHANGEINFO_SELECT result = hrmodels.SY_CHANGEINFO.SELECT(model, token);
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
                string tt = "工号,修改数据库表,修改字段,旧值,新值,登录账号名,修改时间,操作系统";
                string[] ttlist = tt.Split(',');
                IRow rowtt = sheet.CreateRow(rowcount++);
                int cellIndex = 0;
                for (int a = 0; a < ttlist.Length; a++)
                {
                    rowtt.CreateCell(cellIndex++).SetCellValue(ttlist[a]);
                }
                DataTable dtinfo = result.DATALIST;
                for (int i = 0; i < dtinfo.Rows.Count; i++)
                {
                    cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["GH"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["CHANGETABLE"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["CHANGEZD"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["OLDINFO"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["NEWINFO"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["STAFFUSER"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["CHANGETIME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["CHANGESY"].ToString());
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
        public string RY_ZC_SELECT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_RY_ZC model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_ZC>(datastring);
            HR_RY_ZC_SELECT result = hrmodels.RY_RYINFO_RSDA.RY_ZC_SELECT(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        public string EXPOST_TJBB_RY_ZC_SELECT(string datastring)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_RY_ZC model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_ZC>(datastring);
            HR_RY_ZC_SELECT result = hrmodels.RY_RYINFO_RSDA.RY_ZC_SELECT(model, token);
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
                string tt = "来源,职称名称,职称系列,获取日期,机关（部门）,证件编号,复审日期,聘用日期,聘用系列,聘用等级,工号,姓名,公司,归属部门,备注";
                string[] ttlist = tt.Split(',');
                IRow rowtt = sheet.CreateRow(rowcount++);
                int cellIndex = 0;
                for (int a = 0; a < ttlist.Length; a++)
                {
                    rowtt.CreateCell(cellIndex++).SetCellValue(ttlist[a]);
                }
                DataTable dtinfo = result.DATALIST;
                for (int i = 0; i < dtinfo.Rows.Count; i++)
                {
                    cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["ZCLBNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["ZCNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["ZCXLNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["ZCDATE"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["ZCJGBM"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["ZCNO"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["FSDATE"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["PYRQ"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["PYXLNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["PYLEVELNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["GH"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["YGNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["GSNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["GSBMNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["REMARK"].ToString());
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
    }
}
