using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Sonluk.PC.APPCLASS;
using Sonluk.PC.Areas.HR.Models;
using Sonluk.PC.Models;
using Sonluk.UI.Model.HR.RY_RYINFO_RSDAService;
using Sonluk.UI.Model.HR.RY_RYINFOService;
using Sonluk.UI.Model.HR.SY_TYPEMXService;
using Sonluk.UI.Model.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Sonluk.PC.Areas.HR.Controllers
{
    public class RYGLController : Controller
    {
        HRModels hrmodels = new HRModels();
        MESModels mesModels = new MESModels();
        string HRFile = System.Configuration.ConfigurationManager.AppSettings["HRFile"];
        string HRFile2 = System.Configuration.ConfigurationManager.AppSettings["HRFile2"];

        public ActionResult YPDJ()
        {
            AppClass.SetSession("location", 180);
            return View();
        }
        public ActionResult RYINFOGL()
        {
            string token = AppClass.GetSession("token").ToString();
            MODEL_RYINFO_PRINTF rst = new MODEL_RYINFO_PRINTF();
            HR_RY_RYINFO_LIST model = (HR_RY_RYINFO_LIST)Session["HR_RY_RYINFO_LIST"];
            rst.HR_RY_RYINFO_LIST = model;
            rst.LZYY = "";
            if (rst.HR_RY_RYINFO_LIST.ZZZTNAME == "离职" && rst.HR_RY_RYINFO_LIST.LZRQ != "")
            {
                HR_RY_RYINFO_CHANGEINFO model_HR_RY_RYINFO_CHANGEINFO = new HR_RY_RYINFO_CHANGEINFO();
                model_HR_RY_RYINFO_CHANGEINFO.RYID = rst.HR_RY_RYINFO_LIST.RYID;
                model_HR_RY_RYINFO_CHANGEINFO.CHANGERQ = rst.HR_RY_RYINFO_LIST.LZRQ;
                model_HR_RY_RYINFO_CHANGEINFO.CHANGELB = 26;
                HR_RY_CHANGEINFO_SELECT rst_HR_RY_CHANGEINFO_SELECT = hrmodels.RY_RYINFO.SELECT_RY_CHANGEINFO(model_HR_RY_RYINFO_CHANGEINFO, token);
                if (rst_HR_RY_CHANGEINFO_SELECT.MES_RETURN.TYPE == "S")
                {
                    if (rst_HR_RY_CHANGEINFO_SELECT.DATALIST.Rows.Count > 0)
                    {
                        rst.LZYY = rst_HR_RY_CHANGEINFO_SELECT.DATALIST.Rows[0]["CHANGGEYYNAME"].ToString();
                    }
                }
            }
            return View(rst);
        }
        public ActionResult RYINFO_CHECK()
        {
            string token = AppClass.GetSession("token").ToString();
            MODEL_RYINFO_PRINTF rst = new MODEL_RYINFO_PRINTF();
            HR_RY_RYINFO_LIST model = (HR_RY_RYINFO_LIST)Session["HR_RY_RYINFO_LIST"];
            rst.HR_RY_RYINFO_LIST = model;
            rst.LZYY = "";
            if (rst.HR_RY_RYINFO_LIST.ZZZTNAME == "离职" && rst.HR_RY_RYINFO_LIST.LZRQ != "")
            {
                HR_RY_RYINFO_CHANGEINFO model_HR_RY_RYINFO_CHANGEINFO = new HR_RY_RYINFO_CHANGEINFO();
                model_HR_RY_RYINFO_CHANGEINFO.RYID = rst.HR_RY_RYINFO_LIST.RYID;
                model_HR_RY_RYINFO_CHANGEINFO.CHANGERQ = rst.HR_RY_RYINFO_LIST.LZRQ;
                model_HR_RY_RYINFO_CHANGEINFO.CHANGELB = 26;
                HR_RY_CHANGEINFO_SELECT rst_HR_RY_CHANGEINFO_SELECT = hrmodels.RY_RYINFO.SELECT_RY_CHANGEINFO(model_HR_RY_RYINFO_CHANGEINFO, token);
                if (rst_HR_RY_CHANGEINFO_SELECT.MES_RETURN.TYPE == "S")
                {
                    if (rst_HR_RY_CHANGEINFO_SELECT.DATALIST.Rows.Count > 0)
                    {
                        rst.LZYY = rst_HR_RY_CHANGEINFO_SELECT.DATALIST.Rows[0]["CHANGGEYYNAME"].ToString();
                    }
                }
            }
            return View(rst);
        }
        public ActionResult RYINFOGL_MAIN()
        {
            AppClass.SetSession("location", 181);
            return View();
        }
        public ActionResult WS_RYINFOGL()
        {
            string token = AppClass.GetSession("token").ToString();
            MODEL_RYINFO_PRINTF rst = new MODEL_RYINFO_PRINTF();
            HR_RY_RYINFO_LIST model = (HR_RY_RYINFO_LIST)Session["HR_RY_RYINFO_LIST"];
            rst.HR_RY_RYINFO_LIST = model;
            rst.LZYY = "";
            if (rst.HR_RY_RYINFO_LIST.ZZZTNAME == "离职" && rst.HR_RY_RYINFO_LIST.LZRQ != "")
            {
                HR_RY_RYINFO_CHANGEINFO model_HR_RY_RYINFO_CHANGEINFO = new HR_RY_RYINFO_CHANGEINFO();
                model_HR_RY_RYINFO_CHANGEINFO.RYID = rst.HR_RY_RYINFO_LIST.RYID;
                model_HR_RY_RYINFO_CHANGEINFO.CHANGERQ = rst.HR_RY_RYINFO_LIST.LZRQ;
                model_HR_RY_RYINFO_CHANGEINFO.CHANGELB = 26;
                HR_RY_CHANGEINFO_SELECT rst_HR_RY_CHANGEINFO_SELECT = hrmodels.RY_RYINFO.SELECT_RY_CHANGEINFO(model_HR_RY_RYINFO_CHANGEINFO, token);
                if (rst_HR_RY_CHANGEINFO_SELECT.MES_RETURN.TYPE == "S")
                {
                    if (rst_HR_RY_CHANGEINFO_SELECT.DATALIST.Rows.Count > 0)
                    {
                        rst.LZYY = rst_HR_RY_CHANGEINFO_SELECT.DATALIST.Rows[0]["CHANGGEYYNAME"].ToString();
                    }
                }
            }
            return View(rst);
        }
        public ActionResult WS_RYINFO_CHECK()
        {
            string token = AppClass.GetSession("token").ToString();
            MODEL_RYINFO_PRINTF rst = new MODEL_RYINFO_PRINTF();
            HR_RY_RYINFO_LIST model = (HR_RY_RYINFO_LIST)Session["HR_RY_RYINFO_LIST"];
            rst.HR_RY_RYINFO_LIST = model;
            rst.LZYY = "";
            if (rst.HR_RY_RYINFO_LIST.ZZZTNAME == "离职" && rst.HR_RY_RYINFO_LIST.LZRQ != "")
            {
                HR_RY_RYINFO_CHANGEINFO model_HR_RY_RYINFO_CHANGEINFO = new HR_RY_RYINFO_CHANGEINFO();
                model_HR_RY_RYINFO_CHANGEINFO.RYID = rst.HR_RY_RYINFO_LIST.RYID;
                model_HR_RY_RYINFO_CHANGEINFO.CHANGERQ = rst.HR_RY_RYINFO_LIST.LZRQ;
                model_HR_RY_RYINFO_CHANGEINFO.CHANGELB = 26;
                HR_RY_CHANGEINFO_SELECT rst_HR_RY_CHANGEINFO_SELECT = hrmodels.RY_RYINFO.SELECT_RY_CHANGEINFO(model_HR_RY_RYINFO_CHANGEINFO, token);
                if (rst_HR_RY_CHANGEINFO_SELECT.MES_RETURN.TYPE == "S")
                {
                    if (rst_HR_RY_CHANGEINFO_SELECT.DATALIST.Rows.Count > 0)
                    {
                        rst.LZYY = rst_HR_RY_CHANGEINFO_SELECT.DATALIST.Rows[0]["CHANGGEYYNAME"].ToString();
                    }
                }
            }
            return View(rst);
        }
        public ActionResult WS_RYINFOGL_MAIN()
        {
            AppClass.SetSession("location", 184);
            return View();
        }
        public ActionResult RYINFO_RSDA()
        {
            AppClass.SetSession("location", 186);
            return View();
        }
        public ActionResult RYINFO_RSDA_EDIT()
        {
            MODEL_RYINFO_PRINTF rst = new MODEL_RYINFO_PRINTF();
            HR_RY_RYINFO_LIST model = (HR_RY_RYINFO_LIST)Session["HR_RY_RYINFO_LIST"];
            rst.HR_RY_RYINFO_LIST = model;
            return View(rst);
        }
        public ActionResult RYINFO_ISINGH()
        {
            AppClass.SetSession("location", 187);
            return View();
        }
        public ActionResult RYINFO_HTGL()
        {
            AppClass.SetSession("location", 188);
            return View();
        }

        public ActionResult RY_RYINFO_RLZREPORT()
        {
            AppClass.SetSession("location", 10006);
            return View();
        }

        [HttpPost]
        public string SELECT_YGINFO(string RZRQKS, string RZRQJS, string GS, string ALLGS,string GSBM)
        {
            string token = AppClass.GetSession("token").ToString();
            //HR_RY_RYINFO model_HR_RY_RYINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_RYINFO>(datastring);
            HR_RY_RYINFO model_HR_RY_RYINFO = new HR_RY_RYINFO();
            model_HR_RY_RYINFO.RZRQKS = RZRQKS;
            model_HR_RY_RYINFO.RZRQJS = RZRQJS;
            model_HR_RY_RYINFO.GS = GS;
            model_HR_RY_RYINFO.ALLGS = ALLGS;
            model_HR_RY_RYINFO.GSBM = GSBM;
            HR_RY_RYINFO_SELECT rst = hrmodels.RY_RYINFO.SELECT(model_HR_RY_RYINFO, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string RY_RYINFO_SELECT_LB(string datastring, int LB)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_RY_RYINFO model_HR_RY_RYINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_RYINFO>(datastring);
            model_HR_RY_RYINFO.STAFFID = STAFFID;
            HR_RY_RYINFO_SELECT rst = hrmodels.RY_RYINFO.SELECT_LB(model_HR_RY_RYINFO, LB, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string INSERT_YGINFO(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_RY_RYINFO model_HR_RY_RYINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_RYINFO>(datastring);
            model_HR_RY_RYINFO.CJR = STAFFID;
            HR_RY_RYINFO_SELECT rst = hrmodels.RY_RYINFO.INSERT(model_HR_RY_RYINFO, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string UPDATE_YGOINFO(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_RY_RYINFO model_HR_RY_RYINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_RYINFO>(datastring);
            model_HR_RY_RYINFO.XGR = STAFFID;
            MES_RETURN_UI rst = hrmodels.RY_RYINFO.UPDATE(model_HR_RY_RYINFO, token);
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
        public string GET_YGINFO(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_RY_RYINFO model_HR_RY_RYINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_RYINFO>(datastring);
            HR_RY_RYINFO_SELECT rst = hrmodels.RY_RYINFO.SELECT(model_HR_RY_RYINFO, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string EXPOST_RYDJ(string alldata)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            HR_RY_RYINFO_LIST[] model_HR_RY_RYINFO_LIST = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_RYINFO_LIST[]>(alldata);
            try
            {
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/应聘登记导出.xls", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new HSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 1;
                for (int i = 0; i < model_HR_RY_RYINFO_LIST.Length; i++)
                {
                    int cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].RZDATE));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].GH));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].YGNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].GSNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].DEPTNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].EDUCACTIONNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].ZY));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].XB));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].BIRTHDAT));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].PHONENUMBER));
                }
                string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                FileStream file1 = new FileStream(string.Format(@"{0}/Areas/HR/ExportFile/{1}.xls", Server.MapPath("~"), now), FileMode.Create);
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
        public ActionResult EXPORT_DOWNLOAD_RYDJ(string filename)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/HR/ExportFile/{1}.xls", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", "应聘登记导出.xls");
        }
        [HttpPost]
        public string POST_RYINFO_PRINTF(string datastring)
        {
            HR_RY_RYINFO_LIST model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_RYINFO_LIST>(datastring);
            AppClass.SetSession("HR_RY_RYINFO_LIST", model);
            MES_RETURN_UI rst = new MES_RETURN_UI();
            rst.TYPE = "S";
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string Data_Insert_HRImg(string PICNAME, int RYID)        //上传员工照片
        {
            var file = Request.Files[0];

            //string fileName = "PIC_" + PICNAME;
            string fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();
            string today = DateTime.Now.Day.ToString();
            string FileFolder = year + "-" + month + "-" + today;

            string gotname = file.FileName;
            string[] name = gotname.Split('.');

            int count = name.Length - 1;
            string FFNAME = HRFile + @"\upload\img" + @"\PIC\" + FileFolder;
            string Path_Data = HRFile + @"\upload\img" + @"\PIC\" + FileFolder + @"\" + fileName + "." + name[count];
            string Path = HRFile2 + @"\\upload\\img" + @"\\PIC\\" + FileFolder + @"\\" + fileName + "." + name[count];
            string netpath = System.Configuration.ConfigurationManager.AppSettings["HRNETPATH"] + @"img\/" + @"PIC\/" + FileFolder + @"\/" + fileName + "." + name[count];
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
                HR_RY_RYINFO model_HR_RY_RYINFO = new HR_RY_RYINFO();
                model_HR_RY_RYINFO.RYID = RYID;
                model_HR_RY_RYINFO.IMAGEURL = Path_Data;
                hrmodels.RY_RYINFO.UPDATE_PIC(model_HR_RY_RYINFO, token);

                string json = "{\"code\":0,\"res\":\"" + netpath + "\",\"locapath\":\"" + Path + "\"}";
                return json;
            }
            else
            {
                return "";
            }

        }
        [HttpPost]
        public string Data_load_PIC(string srcdata)
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
        public string UPDATE_ALL_YGOINFO(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_RY_RYINFO model_HR_RY_RYINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_RYINFO>(datastring);
            model_HR_RY_RYINFO.XGR = STAFFID;
            MES_RETURN_UI rst = hrmodels.RY_RYINFO.UPDATE_ALL(model_HR_RY_RYINFO, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string UPDATE_CHECK_YGINFO(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_RY_RYINFO model_HR_RY_RYINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_RYINFO>(datastring);
            model_HR_RY_RYINFO.XGR = STAFFID;
            MES_RETURN_UI rst = hrmodels.RY_RYINFO.UPDATE_CHECK(model_HR_RY_RYINFO, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string UPDATE_YGTYPE(string checkdata, string datachange, int YGTYPE, int ZZZT)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_RY_RYINFO[] model_HR_RY_RYINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_RYINFO[]>(checkdata);
            MES_RETURN_UI rst = hrmodels.RY_RYINFO.UPDATE_YGTYPE(model_HR_RY_RYINFO, YGTYPE, ZZZT, token);
            for (int i = 0; i < model_HR_RY_RYINFO.Length; i++)
            {
                HR_RY_RYINFO_CHANGEINFO model_HR_RY_RYINFO_CHANGEINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_RYINFO_CHANGEINFO>(datachange);
                model_HR_RY_RYINFO_CHANGEINFO.RYID = model_HR_RY_RYINFO[i].RYID;
                model_HR_RY_RYINFO_CHANGEINFO.CJR = STAFFID;
                hrmodels.RY_RYINFO.UPDATE_CHANGEINFO(model_HR_RY_RYINFO_CHANGEINFO, token);
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string UPDATE_DEPT(string checkdata, string datachange, int DEPT, int GSBM)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_RY_RYINFO[] model_HR_RY_RYINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_RYINFO[]>(checkdata);
            MES_RETURN_UI rst = hrmodels.RY_RYINFO.UPDATE_DEPT(model_HR_RY_RYINFO, DEPT, GSBM, token);
            for (int i = 0; i < model_HR_RY_RYINFO.Length; i++)
            {
                HR_RY_RYINFO_CHANGEINFO model_HR_RY_RYINFO_CHANGEINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_RYINFO_CHANGEINFO>(datachange);
                model_HR_RY_RYINFO_CHANGEINFO.RYID = model_HR_RY_RYINFO[i].RYID;
                model_HR_RY_RYINFO_CHANGEINFO.CJR = STAFFID;
                hrmodels.RY_RYINFO.UPDATE_CHANGEINFO(model_HR_RY_RYINFO_CHANGEINFO, token);
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string UPDATE_JOBS(string checkdata, string datachange, int JOBS)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_RY_RYINFO[] model_HR_RY_RYINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_RYINFO[]>(checkdata);
            MES_RETURN_UI rst = hrmodels.RY_RYINFO.UPDATE_JOBS(model_HR_RY_RYINFO, JOBS, token);
            for (int i = 0; i < model_HR_RY_RYINFO.Length; i++)
            {
                HR_RY_RYINFO_CHANGEINFO model_HR_RY_RYINFO_CHANGEINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_RYINFO_CHANGEINFO>(datachange);
                model_HR_RY_RYINFO_CHANGEINFO.RYID = model_HR_RY_RYINFO[i].RYID;
                model_HR_RY_RYINFO_CHANGEINFO.CJR = STAFFID;
                hrmodels.RY_RYINFO.UPDATE_CHANGEINFO(model_HR_RY_RYINFO_CHANGEINFO, token);
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string UPDATE_QUIT(string datastring, string datachange)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_RY_RYINFO model_HR_RY_RYINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_RYINFO>(datastring);
            HR_RY_RYINFO_CHANGEINFO model_HR_RY_RYINFO_CHANGEINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_RYINFO_CHANGEINFO>(datachange);
            model_HR_RY_RYINFO_CHANGEINFO.CJR = STAFFID;
            MES_RETURN_UI rst = hrmodels.RY_RYINFO.UPDATE_QUIT(model_HR_RY_RYINFO, token);
            hrmodels.RY_RYINFO.UPDATE_CHANGEINFO(model_HR_RY_RYINFO_CHANGEINFO, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string EXPOST_RYINFO(string alldata)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            HR_RY_RYINFO_LIST[] model_HR_RY_RYINFO_LIST = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_RYINFO_LIST[]>(alldata);
            try
            {
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/员工基本信息导出.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 1;
                for (int i = 0; i < model_HR_RY_RYINFO_LIST.Length; i++)
                {
                    int cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].GH));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].YGNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].YGTYPENAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].XB));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].ZZZTNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].RZDATE));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].GLQSR));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].DEPTNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].GSBMNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].GSNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].ZZTYPENAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].ZZNO));

                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].BIRTHDAT));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].HYZKNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].LZRQ));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].STUDEFSNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].EDUCACTIONNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].ZY));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].MZNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].GJNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].PHONENUMBER));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].JG));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].CJNO));

                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].LSNO));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].HJADDRESS));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].JZADDRESS));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].JZZYYQ));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].HYNO));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].HYYYQ));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].DUTYNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].JOBSNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].DUTYLEVEL));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].ZZMMNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].SFZYXRQ));

                    if (model_HR_RY_RYINFO_LIST[i].ISECRZ == 0)
                    {
                        row.CreateCell(cellIndex++).SetCellValue("否");
                    }
                    else
                    {
                        row.CreateCell(cellIndex++).SetCellValue("是");
                    }
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].ZWLEVELNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].EDUCACTIONSCHOOL));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].PHONESHORT));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].FPDATE));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].HJTYPENAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO_LIST[i].OFFICEPLACENAME));
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
        public ActionResult EXPORT_DOWNLOAD_RYINFO(string filename)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", "员工基本信息导出.xlsx");
        }
        [HttpPost]
        public string GET_JYJL(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_RY_JYJL model_HR_RY_JYJL = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_JYJL>(datastring);
            HR_RY_JYJL_SELECT rst = hrmodels.RY_RYINFO_RSDA.JYJL_SELECT(model_HR_RY_JYJL, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string INSERT_JYJL(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_RY_JYJL model_HR_RY_JYJL = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_JYJL>(datastring);
            model_HR_RY_JYJL.CJR = STAFFID;
            MES_RETURN_UI rst = hrmodels.RY_RYINFO_RSDA.JYJL_INSERT(model_HR_RY_JYJL, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string UPDATE_JYJL(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_RY_JYJL model_HR_RY_JYJL = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_JYJL>(datastring);
            model_HR_RY_JYJL.XGR = STAFFID;
            MES_RETURN_UI rst = hrmodels.RY_RYINFO_RSDA.JYJL_UPDATE(model_HR_RY_JYJL, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string DELETE_JYJL(int EDUID)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_RETURN_UI rst = hrmodels.RY_RYINFO_RSDA.JYJL_DELETE(EDUID, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string GET_GRJL(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_RY_GRJL model_HR_RY_GRJL = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_GRJL>(datastring);
            HR_RY_GRJL_SELECT rst = hrmodels.RY_RYINFO_RSDA.GRJL_SELECT(model_HR_RY_GRJL, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string INSERT_GRJL(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_RY_GRJL model_HR_RY_GRJL = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_GRJL>(datastring);
            model_HR_RY_GRJL.CJR = STAFFID;
            MES_RETURN_UI rst = hrmodels.RY_RYINFO_RSDA.GRJL_INSERT(model_HR_RY_GRJL, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string UPDATE_GRJL(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_RY_GRJL model_HR_RY_GRJL = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_GRJL>(datastring);
            model_HR_RY_GRJL.XGR = STAFFID;
            MES_RETURN_UI rst = hrmodels.RY_RYINFO_RSDA.GRJL_UPDATE(model_HR_RY_GRJL, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string DELETE_GRJL(int GRJLID)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_RETURN_UI rst = hrmodels.RY_RYINFO_RSDA.GRJL_DELETE(GRJLID, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string GET_HOMEGX(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_RY_HOMEGX model_HR_RY_HOMEGX = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_HOMEGX>(datastring);
            HR_RY_HOMEGX_SELECT rst = hrmodels.RY_RYINFO_RSDA.HOMEGX_SELECT(model_HR_RY_HOMEGX, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string INSERT_HOMEGX(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_RY_HOMEGX model_HR_RY_HOMEGX = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_HOMEGX>(datastring);
            model_HR_RY_HOMEGX.CJR = STAFFID;
            MES_RETURN_UI rst = hrmodels.RY_RYINFO_RSDA.HOMEGX_INSERT(model_HR_RY_HOMEGX, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string UPDATE_HOMEGX(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_RY_HOMEGX model_HR_RY_HOMEGX = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_HOMEGX>(datastring);
            model_HR_RY_HOMEGX.XGR = STAFFID;
            MES_RETURN_UI rst = hrmodels.RY_RYINFO_RSDA.HOMEGX_UPDATE(model_HR_RY_HOMEGX, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string DELETE_HOMEGX(int JTGXID)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_RETURN_UI rst = hrmodels.RY_RYINFO_RSDA.HOMEGX_DELETE(JTGXID, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string GET_GSGL(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_RY_GSGL model_HR_RY_GSGL = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_GSGL>(datastring);
            HR_RY_GSGL_SELECT rst = hrmodels.RY_RYINFO_RSDA.GSGL_SELECT(model_HR_RY_GSGL, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string INSERT_GSGL(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_RY_GSGL model_HR_RY_GSGL = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_GSGL>(datastring);
            model_HR_RY_GSGL.CJR = STAFFID;
            MES_RETURN_UI rst = hrmodels.RY_RYINFO_RSDA.GSGL_INSERT(model_HR_RY_GSGL, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string UPDATE_GSGL(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_RY_GSGL model_HR_RY_GSGL = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_GSGL>(datastring);
            model_HR_RY_GSGL.XGR = STAFFID;
            MES_RETURN_UI rst = hrmodels.RY_RYINFO_RSDA.GSGL_UPDATE(model_HR_RY_GSGL, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string DELETE_GSGL(int GSID)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_RETURN_UI rst = hrmodels.RY_RYINFO_RSDA.GSGL_DELETE(GSID, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string GET_WJGL(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_RY_WJGL model_HR_RY_WJGL = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_WJGL>(datastring);
            HR_RY_WJGL_SELECT rst = hrmodels.RY_RYINFO_RSDA.WJGL_SELECT(model_HR_RY_WJGL, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string INSERT_WJGL(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_RY_WJGL model_HR_RY_WJGL = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_WJGL>(datastring);
            model_HR_RY_WJGL.CJR = STAFFID;
            MES_RETURN_UI rst = hrmodels.RY_RYINFO_RSDA.WJGL_INSERT(model_HR_RY_WJGL, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string UPDATE_WJGL(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_RY_WJGL model_HR_RY_WJGL = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_WJGL>(datastring);
            model_HR_RY_WJGL.XGR = STAFFID;
            MES_RETURN_UI rst = hrmodels.RY_RYINFO_RSDA.WJGL_UPDATE(model_HR_RY_WJGL, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string DELETE_WJGL(int WJID)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_RETURN_UI rst = hrmodels.RY_RYINFO_RSDA.WJGL_DELETE(WJID, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string GET_HT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_RY_HT model_HR_RY_HT = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_HT>(datastring);
            HR_RY_HT_SELECT rst = hrmodels.RY_RYINFO_RSDA.HT_SELECT(model_HR_RY_HT, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string INSERT_HT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_RY_HT model_HR_RY_HT = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_HT>(datastring);
            model_HR_RY_HT.CJR = STAFFID;
            MES_RETURN_UI rst = hrmodels.RY_RYINFO_RSDA.HT_INSERT(model_HR_RY_HT, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string UPDATE_HT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_RY_HT model_HR_RY_HT = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_HT>(datastring);
            model_HR_RY_HT.XGR = STAFFID;
            MES_RETURN_UI rst = hrmodels.RY_RYINFO_RSDA.HT_UPDATE(model_HR_RY_HT, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string UPDATE_HTQCS(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_RY_HT model_HR_RY_HT = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_HT>(datastring);
            MES_RETURN_UI rst = hrmodels.RY_RYINFO_RSDA.HT_UPDATE_HTQCS(model_HR_RY_HT, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string DELETE_HT(int HTID)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_RETURN_UI rst = hrmodels.RY_RYINFO_RSDA.HT_DELETE(HTID, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string GET_ZC(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_RY_ZC model_HR_RY_ZC = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_ZC>(datastring);
            HR_RY_ZC_SELECT rst = hrmodels.RY_RYINFO_RSDA.ZC_SELECT(model_HR_RY_ZC, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string INSERT_ZC(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_RY_ZC model_HR_RY_ZC = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_ZC>(datastring);
            model_HR_RY_ZC.CJR = STAFFID;
            MES_RETURN_UI rst = hrmodels.RY_RYINFO_RSDA.ZC_INSERT(model_HR_RY_ZC, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string UPDATE_ZC(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_RY_ZC model_HR_RY_ZC = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_ZC>(datastring);
            model_HR_RY_ZC.XGR = STAFFID;
            MES_RETURN_UI rst = hrmodels.RY_RYINFO_RSDA.ZC_UPDATE(model_HR_RY_ZC, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string DELETE_ZC(int ZCID)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_RETURN_UI rst = hrmodels.RY_RYINFO_RSDA.ZC_DELETE(ZCID, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string GET_WBZW(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_RY_WBZW model_HR_RY_WBZW = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_WBZW>(datastring);
            HR_RY_WBZW_SELECT rst = hrmodels.RY_RYINFO_RSDA.WBZW_SELECT(model_HR_RY_WBZW, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string INSERT_WBZW(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_RY_WBZW model_HR_RY_WBZW = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_WBZW>(datastring);
            model_HR_RY_WBZW.CJR = STAFFID;
            MES_RETURN_UI rst = hrmodels.RY_RYINFO_RSDA.WBZW_INSERT(model_HR_RY_WBZW, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string UPDATE_WBZW(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_RY_WBZW model_HR_RY_WBZW = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_WBZW>(datastring);
            model_HR_RY_WBZW.XGR = STAFFID;
            MES_RETURN_UI rst = hrmodels.RY_RYINFO_RSDA.WBZW_UPDATE(model_HR_RY_WBZW, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string DELETE_WBZW(int WBZWID)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_RETURN_UI rst = hrmodels.RY_RYINFO_RSDA.WBZW_DELETE(WBZWID, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string UPDATE_ISINGH(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_RY_RYINFO model_HR_RY_RYINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_RYINFO>(datastring);
            model_HR_RY_RYINFO.XGR = STAFFID;
            MES_RETURN_UI rst = hrmodels.RY_RYINFO.UPDATE_ISINGH(model_HR_RY_RYINFO, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string UPDATE_DUTYNAME(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_RY_RYINFO model_HR_RY_RYINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_RYINFO>(datastring);
            MES_RETURN_UI rst = hrmodels.RY_RYINFO.UPDATE_DUTYNAME(model_HR_RY_RYINFO, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string Data_DaoRu_RYGH()
        {
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            string token = AppClass.GetSession("token").ToString();
            DaoRuMsg msg = new DaoRuMsg();
            try
            {
                var file = Request.Files[0];

                string year = DateTime.Now.Year.ToString();
                string month = DateTime.Now.Month.ToString();

                string gotname = file.FileName;

                string savePath = HRFile + @"\upload\excel\" + year + @"\" + month + @"\" + gotname;
                if (Directory.Exists(HRFile + @"\upload\excel\" + year + @"\" + month) == false)
                {
                    Directory.CreateDirectory(HRFile + @"\upload\excel\" + year + @"\" + month);
                }
                file.SaveAs(savePath);
                FileInfo fi = new FileInfo(savePath);


                if (fi.Exists == true)
                {
                    string[] sheet = { "工会导入" };


                    //开始做数据校验

                    DataTable data1 = ExcelToDataTable(savePath, 0, true);      //专项附加扣除
                    #region
                    if (data1 != null)
                    {
                        if (data1.Columns.Contains("工号") == false || data1.Columns.Contains("入会日期") == false)
                        {
                            msg.Msg = "请使用新增模版！";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                        else
                        {
                            try
                            {
                                //做数据验证
                                if (data1.Rows.Count > 0)
                                {
                                    for (int i = 0; i < data1.Rows.Count; i++)
                                    {
                                        if (data1.Rows[i]["工号"].ToString() != "")
                                        {
                                            if (data1.Rows[i]["工号"].ToString().Length != 5)
                                            {
                                                msg.Msg = "工会导入第" + (i + 2) + "行工号格式不正确！";
                                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                            }
                                            HR_RY_RYINFO model = new HR_RY_RYINFO();
                                            model.GH = data1.Rows[i]["工号"].ToString();
                                            HR_RY_RYINFO_SELECT staffdata = hrmodels.RY_RYINFO.SELECT(model, token);
                                            if (staffdata.HR_RY_RYINFO_LIST.Length == 0)
                                            {
                                                msg.Msg = "工会导入第" + (i + 2) + "行工号不存在！";
                                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                            }
                                            if (staffdata.HR_RY_RYINFO_LIST[0].ISINGH == 1)
                                            {
                                                msg.Msg = "工会导入第" + (i + 2) + "行工号员工已加入工会！";
                                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                            }
                                            if (staffdata.HR_RY_RYINFO_LIST[0].ZZZTNAME != "在职在岗")
                                            {
                                                msg.Msg = "工会导入第" + (i + 2) + "行工号员工非“在职在岗”状态！";
                                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                            }
                                            if (data1.Rows[i]["入会日期"].ToString() == "")
                                            {
                                                msg.Msg = "工会导入第" + (i + 2) + "入会日期未输！";
                                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                            }
                                            if (Regex.IsMatch(data1.Rows[i]["入会日期"].ToString(), @"(([0-9]{3}[1-9]|[0-9]{2}[1-9][0-9]{1}|[0-9]{1}[1-9][0-9]{2}|[1-9][0-9]{3})-(((0[13578]|1[02])-(0[1-9]|[12][0-9]|3[01]))|((0[469]|11)-(0[1-9]|[12][0-9]|30))|(02-(0[1-9]|[1][0-9]|2[0-8]))))|((([0-9]{2})(0[48]|[2468][048]|[13579][26])|((0[48]|[2468][048]|[3579][26])00))-02-29)") == false)
                                            {
                                                msg.Msg = "工会导入第" + (i + 2) + "行入会日期格式不正确！";
                                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                            }
                                        }
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                msg.Msg = e.ToString();
                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                            }



                        }
                    }
                    #endregion





                    //能到这儿就说明数据是没问题的了...大概，然后才进行数据库写入
                    #region

                    for (int i = 0; i < data1.Rows.Count; i++)
                    {
                        #region
                        if (data1.Rows[i]["工号"].ToString() != "")
                        {
                            HR_RY_RYINFO insert_model = new HR_RY_RYINFO();
                            insert_model.GH = data1.Rows[i]["工号"].ToString();
                            HR_RY_RYINFO_SELECT staffdata = hrmodels.RY_RYINFO.SELECT(insert_model, token);
                            HR_RY_RYINFO model = new HR_RY_RYINFO();
                            model.RYID = staffdata.HR_RY_RYINFO_LIST[0].RYID;
                            model.ISINGH = 1;
                            model.GHDATE = data1.Rows[i]["入会日期"].ToString();
                            model.XGR = STAFFID;

                            MES_RETURN_UI result = hrmodels.RY_RYINFO.UPDATE_ISINGH(model, token);


                            if (result.TYPE == "E")
                            {
                                msg.Msg = "工会导入的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                            }
                        }
                        #endregion
                    }


                    #endregion
                    msg.Msg = "新增成功！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }
                else
                {
                    msg.Msg = "文件读取失败！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }
            }
            catch (Exception e)
            {
                msg.Msg = e.ToString();
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
        }
        [HttpPost]
        public string EXPOST_RYGH(string alldata)
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
                string tt = "工号,姓名,公司,归属部门,在职状态,证照类型,证照号码,工会状态,入会日期,入职日期,员工类别,性别";
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
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO[i].ZZZTNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO[i].ZZTYPENAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO[i].ZZNO));
                    if (model_HR_RY_RYINFO[i].ISINGH == 1)
                    {
                        row.CreateCell(cellIndex++).SetCellValue(Convert.ToString("已入会"));
                    }
                    else
                    {
                        row.CreateCell(cellIndex++).SetCellValue(Convert.ToString("未入会"));
                    }
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO[i].GHDATE));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO[i].RZDATE));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO[i].YGTYPENAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO[i].XB));
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
        public ActionResult EXPORT_DOWNLOAD_RYGH(string filename)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", "工会信息导出.xlsx");
        }
        public ActionResult EXPORT_MBLOAD_RYGH()
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            byte[] arrFile = null;
            try
            {
                string file = string.Format(@"{0}/Areas/HR/ExportFile/中银HR系统_工会信息采集表.xlsx", Server.MapPath("~"));
                using (FileStream fs = new FileStream(file, FileMode.Open))
                {
                    arrFile = new byte[fs.Length];
                    fs.Read(arrFile, 0, arrFile.Length);
                }
                rst.TYPE = "S";
            }
            catch
            {
                rst.TYPE = "E";
                rst.MESSAGE = "文件无法下载！";
            }
            return File(arrFile, "application/vnd.ms-excel", "中银HR系统_工会信息采集表.xlsx");
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
        public string EXPOST_RYHT(string alldata)
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
                string tt = "工号,姓名,员工类别,在职状态,归属部门,部门,公司,证照号码,合同状态,初订日期,近期生效日,合同期限类型,合同期限,到期日,签订次数";
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
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO[i].YGTYPENAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO[i].ZZZTNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO[i].GSBMNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO[i].DEPTNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO[i].GSNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO[i].ZZNO));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO[i].HTZTNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO[i].QDRQ));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO[i].SXRQ));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO[i].HTQXLBNAME));
                    string htqx = model_HR_RY_RYINFO[i].HTQX;
                    if (htqx != "")
                    {
                        string[] htqxall = htqx.Split('/');
                        row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(htqxall[0] + '年' + htqxall[1] + '月' + htqxall[2] + '日'));
                    }
                    else
                    {
                        row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(""));
                    }
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO[i].DQR));
                    //HR_RY_HT model_HR_RY_HT = new HR_RY_HT();
                    //model_HR_RY_HT.RYID = model_HR_RY_RYINFO[i].RYID;
                    //HR_RY_HT_SELECT rst_HR_RY_HT = hrmodels.RY_RYINFO_RSDA.HT_SELECT(model_HR_RY_HT, token);
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RYINFO[i].HTQCS));
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
        public ActionResult EXPORT_DOWNLOAD_RYHT(string filename)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", "合同记录信息导出.xlsx");
        }
        [HttpPost]
        public string INSERT_RONGY(string datastring, string rydata)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_RY_RONGY model_HR_RY_RONGY = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_RONGY>(datastring);
            model_HR_RY_RONGY.CJR = STAFFID;
            MES_RETURN_UI rst = hrmodels.RY_RYINFO.INSERT_RONGY(model_HR_RY_RONGY, token);
            HR_RY_RYINFO[] model_HR_RY_RYINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_RYINFO[]>(rydata);
            if (model_HR_RY_RYINFO.Length > 0)
            {
                for (int i = 0; i < model_HR_RY_RYINFO.Length; i++)
                {
                    hrmodels.RY_RYINFO.INSERT_RONGY_RYID(rst.TID, model_HR_RY_RYINFO[i].RYID, token);
                }
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string SELECT_RONGY(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_RY_RONGY model_HR_RY_RONGY = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_RONGY>(datastring);
            HR_RY_RONGY_SELECT rst = hrmodels.RY_RYINFO.SELECT_RONGY(model_HR_RY_RONGY, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string DELETE_RONGY(int RONGYID)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_RETURN_UI rst = hrmodels.RY_RYINFO.DELETE_RONGY(RONGYID, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string UPDATE_RONGY(string datastring, string rydata)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_RY_RONGY model_HR_RY_RONGY = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_RONGY>(datastring);
            model_HR_RY_RONGY.XGR = STAFFID;
            MES_RETURN_UI rst = hrmodels.RY_RYINFO.UPDATE_RONGY(model_HR_RY_RONGY, token);
            hrmodels.RY_RYINFO.DELETE_RONGY_RYID(model_HR_RY_RONGY.RONGYID, token);
            HR_RY_RYINFO[] model_HR_RY_RYINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_RYINFO[]>(rydata);
            if (model_HR_RY_RYINFO.Length > 0)
            {
                for (int i = 0; i < model_HR_RY_RYINFO.Length; i++)
                {
                    hrmodels.RY_RYINFO.INSERT_RONGY_RYID(model_HR_RY_RONGY.RONGYID, model_HR_RY_RYINFO[i].RYID, token);
                }
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string SELECT_RONGY_RYID(int RYID)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_RY_RONGY_SELECT rst = hrmodels.RY_RYINFO.SELECT_RONGY_RYID(RYID, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string EXPOST_RLZREPORT(string datastring, int LB)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_RY_RYINFO model_HR_RY_RYINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_RYINFO>(datastring);
            model_HR_RY_RYINFO.STAFFID = STAFFID;
            HR_RY_RYINFO_SELECT result = hrmodels.RY_RYINFO.SELECT_LB(model_HR_RY_RYINFO, LB, token);
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
                string tt = "工号,姓名,公司,归属部门,部门,员工类别,入职日期,离职日期,身份证号,手机号码";
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
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["YGNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["GSNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["GSBMNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["DEPTNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["YGTYPENAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["RZDATE"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["LZRQ"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["ZZNO"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["PHONENUMBER"].ToString());
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
        public string SELECT_LZINFO(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_RY_RYINFO model_HR_RY_RYINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_RYINFO>(datastring);
            HR_RY_LZINFO_SELECT rst = hrmodels.RY_RYINFO.SELECT_LZINFO(model_HR_RY_RYINFO, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string RY_RYINFO_UPDATE_LB(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_RY_RYINFO model_HR_RY_RYINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_RYINFO>(datastring);
            MES_RETURN_UI rst = hrmodels.RY_RYINFO.UPDATE_LB(model_HR_RY_RYINFO, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string GET_TIME_NOW()
        {
            string token = AppClass.GetSession("token").ToString();
            return mesModels.PUBLIC_FUNC.GET_TIME(token);
        }
    }
}
