using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Sonluk.PC.APPCLASS;
using Sonluk.PC.Models;
using Sonluk.UI.Model.HR.SY_DEPTService;
using Sonluk.UI.Model.HR.SY_DUTYService;
using Sonluk.UI.Model.HR.SY_GSService;
using Sonluk.UI.Model.HR.SY_TYPEMXService;
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
    public class ZZJGController : Controller
    {
        //
        // GET: /HR/ZZJG/
        HRModels hrmodels = new HRModels();
        string HRFile = System.Configuration.ConfigurationManager.AppSettings["HRFile"];
        string HRFile2 = System.Configuration.ConfigurationManager.AppSettings["HRFile2"];
        public ActionResult GSMANAGE()
        {
            AppClass.SetSession("location", 126);
            return View();
        }
        public ActionResult DEPTMANAGE()
        {
            AppClass.SetSession("location", 127);
            return View();
        }
        public ActionResult DUTYMANAGE()
        {
            AppClass.SetSession("location", 170);
            return View();
        }
        public ActionResult DEPT_REPORT_BZKHREPORT()
        {
            AppClass.SetSession("location", 10005);
            return View();
        }
        [HttpPost]
        public string GET_GS(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_SY_GS model_HR_SY_GS = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_SY_GS>(datastring);
            HR_SY_GS_SELECT rst = hrmodels.SY_GS.SELECT(model_HR_SY_GS, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string SET_GS(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_SY_GS model_HR_SY_GS = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_SY_GS>(datastring);
            model_HR_SY_GS.CJR = STAFFID;
            MES_RETURN_UI rst = hrmodels.SY_GS.INSERT(model_HR_SY_GS, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string GET_GS_BY_ROLE()
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_SY_GS_SELECT rst = hrmodels.SY_GS.SELECT_BY_ROLE(STAFFID, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string SET_GS_UPDATE(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_SY_GS model_HR_SY_GS = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_SY_GS>(datastring);
            model_HR_SY_GS.XGR = STAFFID;
            MES_RETURN_UI rst = hrmodels.SY_GS.UPDATE(model_HR_SY_GS, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string GS_DELETE(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_SY_GS model_HR_SY_GS = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_SY_GS>(datastring);
            model_HR_SY_GS.XGR = STAFFID;
            MES_RETURN_UI rst = hrmodels.SY_GS.DELETE(model_HR_SY_GS, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string DEPT_SELECT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_SY_DEPT model_HR_SY_DEPT = new HR_SY_DEPT();
            HR_SY_DEPT_SELECT rst = hrmodels.SY_DEPT.SELECT(model_HR_SY_DEPT, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string GET_TYPEMX(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_SY_TYPEMX model_HR_SY_TYPEMX = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_SY_TYPEMX>(datastring);
            HR_SY_TYPEMX_SELECT rst = hrmodels.SY_TYPEMX.SELECT(model_HR_SY_TYPEMX, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string DEPT_INSERT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_SY_DEPT model_HR_SY_DEPT = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_SY_DEPT>(datastring);
            model_HR_SY_DEPT.CJR = STAFFID;
            MES_RETURN_UI rst = hrmodels.SY_DEPT.INSERT(model_HR_SY_DEPT, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string DEPT_SELECT_LB(string datastring, int LB)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_SY_DEPT model_HR_SY_DEPT = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_SY_DEPT>(datastring);
            model_HR_SY_DEPT.STAFFID = STAFFID;
            HR_SY_DEPT_SELECT rst = hrmodels.SY_DEPT.SELECT_LB(model_HR_SY_DEPT, LB, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string EXPOST_BZKHREPORT(string datastring, int LB)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_SY_DEPT model_HR_SY_DEPT = new HR_SY_DEPT();
            model_HR_SY_DEPT.STAFFID = STAFFID;
            HR_SY_DEPT_SELECT result = hrmodels.SY_DEPT.SELECT_LB(model_HR_SY_DEPT, LB, token);
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
                string tt = "公司,部门,编制人数,";
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
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["GSNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["DEPTNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToInt32(dtinfo.Rows[i]["DEPTBZRS"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToInt32(dtinfo.Rows[i]["GSBMRYCOUNT"].ToString()));
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
        public string DEPT_UPDATE(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_SY_DEPT model_HR_SY_DEPT = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_SY_DEPT>(datastring);
            model_HR_SY_DEPT.XGR = STAFFID;
            MES_RETURN_UI rst = hrmodels.SY_DEPT.UPDATE(model_HR_SY_DEPT, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string DEPT_DELETE(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_SY_DEPT model_HR_SY_DEPT = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_SY_DEPT>(datastring);
            MES_RETURN_UI rst = hrmodels.SY_DEPT.DELETE(model_HR_SY_DEPT, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string SELECT_DEPT_RYCOUNT(int DEPTID)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_SY_DEPT_SELECT rst = hrmodels.SY_DEPT.SELECT_RYCOUNT(DEPTID, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string SELECT_BY_ROLE_LD(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_SY_DEPT model_HR_SY_DEPT = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_SY_DEPT>(datastring);
            model_HR_SY_DEPT.STAFFID = STAFFID;
            HR_SY_DEPT_SELECT rst = hrmodels.SY_DEPT.SELECT_BY_ROLE_LD(model_HR_SY_DEPT, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string UPDATE_FID(int DEPTID, int FID)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_RETURN_UI rst = hrmodels.SY_DEPT.UPDATE_FID(DEPTID, FID, STAFFID, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string DUTY_SELECT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_SY_DUTY model_HR_SY_DUTY = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_SY_DUTY>(datastring);
            HR_SY_DUTY_SELECT rst = hrmodels.SY_DUTY.SELECT(model_HR_SY_DUTY, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string DUTY_INSERT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_SY_DUTY model_HR_SY_DUTY = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_SY_DUTY>(datastring);
            model_HR_SY_DUTY.CJR = STAFFID;
            MES_RETURN_UI rst = hrmodels.SY_DUTY.INSERT(model_HR_SY_DUTY, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string DUTY_UPDATE(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_SY_DUTY model_HR_SY_DUTY = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_SY_DUTY>(datastring);
            model_HR_SY_DUTY.XGR = STAFFID;
            MES_RETURN_UI rst = hrmodels.SY_DUTY.UPDATE(model_HR_SY_DUTY, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string DUTY_DELETE(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_SY_DUTY model_HR_SY_DUTY = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_SY_DUTY>(datastring);
            MES_RETURN_UI rst = hrmodels.SY_DUTY.DELETE(model_HR_SY_DUTY, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string Data_UPDATE_HRYYZZImg(string PICNAME, string GS)        //上传营业执照照片
        {
            var file = Request.Files[0];

            string fileName = "YYZZ_" + PICNAME;
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();
            string today = DateTime.Now.Day.ToString();
            string FileFolder = year + "-" + month + "-" + today;

            string gotname = file.FileName;
            string[] name = gotname.Split('.');

            int count = name.Length - 1;
            string FFNAME = HRFile + @"\upload\img" + @"\YYZZ\" + FileFolder;
            string Path_Data = HRFile + @"\upload\img" + @"\YYZZ\" + FileFolder + @"\" + fileName + "." + name[count];
            string Path = HRFile2 + @"\\upload\\img" + @"\\YYZZ\\" + FileFolder + @"\\" + fileName + "." + name[count];
            string netpath = System.Configuration.ConfigurationManager.AppSettings["HRNETPATH"] + @"img\/" + @"YYZZ\/" + FileFolder + @"\/" + fileName + "." + name[count];
            if (!Directory.Exists(FFNAME))
            {
                Directory.CreateDirectory(FFNAME);
                file.SaveAs(Path);
            }
            else
            {
                file.SaveAs(Path);
            }
            FileInfo fi = new FileInfo(Path);
            if (fi.Exists == true)
            {
                string token = AppClass.GetSession("token").ToString();
                HR_SY_GS model_HR_SY_GS = new HR_SY_GS();
                model_HR_SY_GS.GS = GS;
                model_HR_SY_GS.GSYYZZ = Path_Data;
                hrmodels.SY_GS.UPDATE_YYZZ(model_HR_SY_GS, token);

                string json = "{\"code\":0,\"res\":\"" + netpath + "\",\"locapath\":\"" + Path + "\"}";
                return json;
            }
            else
            {
                return "";
            }

        }
        [HttpPost]
        public string Data_load_YYZZ(string srcdata)
        {
            string netpath = System.Configuration.ConfigurationManager.AppSettings["HRNETPATH"];
            if (srcdata != "")
            {
                string[] p = srcdata.Split('\\');
                int count = p.Length - 1;
                string path = p[count - 3] + @"/" + p[count - 2] + @"/" + p[count - 1] + @"/" + p[count];
                srcdata = netpath + path;
            }
            return srcdata;
        }
        [HttpPost]
        public string EXPOST_DEPT()
        {
            string token = AppClass.GetSession("token").ToString();
            HR_SY_DEPT model_HR_SY_DEPT = new HR_SY_DEPT();
            HR_SY_DEPT_SELECT model_rst = hrmodels.SY_DEPT.SELECT(model_HR_SY_DEPT, token);
            MES_RETURN_UI rst = new MES_RETURN_UI();
            try
            {
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/部门导出.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 1;
                List<HR_SY_DEPT_LIST> alldata = new List<HR_SY_DEPT_LIST>();
                for (int i = 0; i < model_rst.HR_SY_DEPT_LIST.Length; i++)
                {
                    if (model_rst.HR_SY_DEPT_LIST[i].FID != 0)
                    {
                        alldata.Add(model_rst.HR_SY_DEPT_LIST[i]);
                    }
                }
                for (int i = 0; i < alldata.Count; i++)
                {
                    int cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(alldata[i].GS));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(alldata[i].GSNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(alldata[i].DEPTNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(alldata[i].DEPTBZRS));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(alldata[i].DEPTBMLBNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(alldata[i].DEPTFZRNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(alldata[i].DEPTNO));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(alldata[i].DEPTCBZX));
                    if (alldata[i].ISACTION == 1)
                    {
                        row.CreateCell(cellIndex++).SetCellValue("启用");
                    }
                    else
                    {
                        row.CreateCell(cellIndex++).SetCellValue("关闭");
                    }
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(alldata[i].FDEPTNAME));
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
        public ActionResult EXPORT_DOWNLOAD_DEPT(string filename)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", "部门导出.xlsx");
        }
    }
}
