using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using Sonluk.PC.APPCLASS;
using Sonluk.PC.Models;
using Sonluk.UI.Model.HR.ADMINISTRATION_DORMService;
using Sonluk.UI.Model.HR.ADMINISTRATION_YHRYService;
using Sonluk.UI.Model.HR.BOOK_BOOKINFOService;
using Sonluk.UI.Model.HR.DA_DAINFOService;
using Sonluk.UI.Model.HR.RY_RYINFOService;
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
    public class HRXZGLController : Controller
    {
        //
        // GET: /HR/HRXZGL/
        HRModels hrmodels = new HRModels();
        string HRFile = System.Configuration.ConfigurationManager.AppSettings["HRFile"];
        string HRFile2 = System.Configuration.ConfigurationManager.AppSettings["HRFile2"];
        public ActionResult RONGYGL()
        {
            AppClass.SetSession("location", 191);
            return View();
        }
        public ActionResult XZGL_JSDA()
        {
            AppClass.SetSession("location", 193);
            return View();
        }
        public ActionResult BOOKZL()
        {
            AppClass.SetSession("location", 194);
            return View();
        }
        public ActionResult BOOKJY()
        {
            AppClass.SetSession("location", 195);
            return View();
        }
        public ActionResult YHRY_MANAGE()
        {
            AppClass.SetSession("location", 10014);
            return View();
        }
        public ActionResult DORM_MANAGE()
        {
            AppClass.SetSession("location", 10015);
            return View();
        }
        public ActionResult LIVE_MANAGE()
        {
            AppClass.SetSession("location", 10016);
            return View();
        }
        public ActionResult LIVEMX_REPORT()
        {
            return View();
        }
        public ActionResult YCRY_REPORT()
        {
            AppClass.SetSession("location", 10017);
            return View();
        }
        [HttpPost]
        public string EXPOST_RONGY(string alldata)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_RY_RONGY_LIST[] model_HR_RY_RONGY = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_RY_RONGY_LIST[]>(alldata);
            try
            {
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/导出模版.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 0;
                string tt = "荣誉类别,荣誉名称,颁奖单位,荣誉级别,获奖日期,关联员工,起始日期,结束日期,存放位置,备注";
                string[] ttlist = tt.Split(',');
                IRow rowtt = sheet.CreateRow(rowcount++);
                int cellIndex = 0;
                for (int a = 0; a < ttlist.Length; a++)
                {
                    rowtt.CreateCell(cellIndex++).SetCellValue(ttlist[a]);
                }
                for (int i = 0; i < model_HR_RY_RONGY.Length; i++)
                {
                    cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RONGY[i].RONGYLBNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RONGY[i].RONGYNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RONGY[i].BJDW));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RONGY[i].RONGYJBNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RONGY[i].HJRQ));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RONGY[i].YGNAMEALL));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RONGY[i].YXQKS));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RONGY[i].YXQJS));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RONGY[i].ZZJG));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_RY_RONGY[i].REMARK));
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
        public ActionResult EXPORT_DOWNLOAD_RONGY(string filename)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", "荣誉信息导出.xlsx");
        }
        [HttpPost]
        public string Data_UPLOAD_RONGYImg(int RONGYID)        //上传荣誉照片
        {
            var file = Request.Files[0];
            string picname = file.FileName;
            string[] fjname = picname.Split('.');

            string fileName = "RONGY_" + RONGYID + "_" + fjname[0];
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();
            string today = DateTime.Now.Day.ToString();
            string FileFolder = year + "-" + month + "-" + today;

            string gotname = file.FileName;
            string[] name = gotname.Split('.');

            int count = name.Length - 1;
            string FFNAME = HRFile + @"\upload\img" + @"\RONGY\" + FileFolder;
            string Path_Data = HRFile + @"\upload\img" + @"\RONGY\" + FileFolder + @"\" + fileName + "." + name[count];
            string Path = HRFile2 + @"\\upload\\img" + @"\\RONGY\\" + FileFolder + @"\\" + fileName + "." + name[count];
            string netpath = System.Configuration.ConfigurationManager.AppSettings["HRNETPATH"] + @"img\/" + @"RONGY\/" + FileFolder + @"\/" + fileName + "." + name[count];
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
                int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
                HR_RY_RONGY model_HR_RY_RONGY = new HR_RY_RONGY();
                model_HR_RY_RONGY.RONGYID = RONGYID;
                model_HR_RY_RONGY.FILEURL = Path_Data;
                model_HR_RY_RONGY.CJR = STAFFID;
                hrmodels.RY_RYINFO.INSERT_RONGY_FILE(model_HR_RY_RONGY, token);

                string json = "{\"code\":0,\"res\":\"" + netpath + "\",\"locapath\":\"" + Path + "\"}";
                return json;
            }
            else
            {
                return "";
            }

        }
        [HttpPost]
        public string Data_load_RONGYImg(string srcdata)
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
        public string SELECT_RONGY_FILE(int RONGYID)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_RY_RONGY_SELECT rst = hrmodels.RY_RYINFO.SELECT_RONGY_FILE(RONGYID, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string DELETE_RONGY_FILE(int RYFILEID)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_RETURN_UI rst = hrmodels.RY_RYINFO.DELETE_RONGY_FILE(RYFILEID, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string SELECT_DAINFO(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_DA_DAINFO model_HR_DA_DAINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_DA_DAINFO>(datastring);
            HR_DA_DAINFO_SELECT rst = hrmodels.DA_DAINFO.SELECT_DAINFO(model_HR_DA_DAINFO, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string INSERT_DAINFO(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_DA_DAINFO model_HR_DA_DAINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_DA_DAINFO>(datastring);
            model_HR_DA_DAINFO.CJR = STAFFID;
            MES_RETURN_UI rst = hrmodels.DA_DAINFO.INSERT_DAINFO(model_HR_DA_DAINFO, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string UPDATE_DAINFO(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_DA_DAINFO model_HR_DA_DAINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_DA_DAINFO>(datastring);
            model_HR_DA_DAINFO.XGR = STAFFID;
            MES_RETURN_UI rst = hrmodels.DA_DAINFO.UPDATE_DAINFO(model_HR_DA_DAINFO, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string DELETE_DAINFO(int DAID)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_RETURN_UI rst = hrmodels.DA_DAINFO.DELETE_DAINFO(DAID, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string INSERT_DADM(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_DA_DADM model_HR_DA_DADM = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_DA_DADM>(datastring);
            MES_RETURN_UI rst = hrmodels.DA_DAINFO.INSERT_DADM(model_HR_DA_DADM, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string SELECT_DADM(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_DA_DADM model_HR_DA_DADM = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_DA_DADM>(datastring);
            HR_DA_DADM_SELECT rst = hrmodels.DA_DAINFO.SELECT_DADM(model_HR_DA_DADM, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string UPDATE_DADM(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_DA_DADM model_HR_DA_DADM = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_DA_DADM>(datastring);
            MES_RETURN_UI rst = hrmodels.DA_DAINFO.UPDATE_DADM(model_HR_DA_DADM, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string DELETE_DADM(int DADMID)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_RETURN_UI rst = hrmodels.DA_DAINFO.DELETE_DADM(DADMID, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string INSERT_DAJYJL(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_DA_DAJYJL model_HR_DA_DAJYJL = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_DA_DAJYJL>(datastring);
            model_HR_DA_DAJYJL.CJR = STAFFID;
            MES_RETURN_UI rst = hrmodels.DA_DAINFO.INSERT_DAJYJL(model_HR_DA_DAJYJL, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string SELECT_DAJYJL(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_DA_DAJYJL model_HR_DA_DAJYJL = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_DA_DAJYJL>(datastring);
            HR_DA_DAJYJL_SELECT rst = hrmodels.DA_DAINFO.SELECT_DAJYJL(model_HR_DA_DAJYJL, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string UPDATE_DAJYJL(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_DA_DAJYJL model_HR_DA_DAJYJL = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_DA_DAJYJL>(datastring);
            model_HR_DA_DAJYJL.XGR = STAFFID;
            MES_RETURN_UI rst = hrmodels.DA_DAINFO.UPDATE_DAJYJL(model_HR_DA_DAJYJL, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string EXPOST_DAINFO(string alldata)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_DA_DAINFO_LIST[] model_HR_DA_DAINFO_LIST = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_DA_DAINFO_LIST[]>(alldata);
            try
            {
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/导出模版.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 0;
                string tt = "档案号,案卷名称,档案形式,类别,档案代码,名称,接收日期,图纸,文件,总张数,保管期限,来源,条目一,条目二,密级,文件状态,备注";
                string[] ttlist = tt.Split(',');
                IRow rowtt = sheet.CreateRow(rowcount++);
                int cellIndex = 0;
                for (int a = 0; a < ttlist.Length; a++)
                {
                    rowtt.CreateCell(cellIndex++).SetCellValue(ttlist[a]);
                }
                for (int i = 0; i < model_HR_DA_DAINFO_LIST.Length; i++)
                {
                    cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_DA_DAINFO_LIST[i].DANO));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_DA_DAINFO_LIST[i].AJNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_DA_DAINFO_LIST[i].DAXSNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_DA_DAINFO_LIST[i].DALBNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_DA_DAINFO_LIST[i].DADM));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_DA_DAINFO_LIST[i].DADMNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_DA_DAINFO_LIST[i].DAJSRQ));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_DA_DAINFO_LIST[i].TZCOUNT));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_DA_DAINFO_LIST[i].WJCOUNT));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_DA_DAINFO_LIST[i].ALLCOUNT));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_DA_DAINFO_LIST[i].BGQXNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_DA_DAINFO_LIST[i].LYNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_DA_DAINFO_LIST[i].TM1));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_DA_DAINFO_LIST[i].TM2));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_DA_DAINFO_LIST[i].DAMJNAME));
                    if (model_HR_DA_DAINFO_LIST[i].DAZT == 1)
                    {
                        row.CreateCell(cellIndex++).SetCellValue("在案");
                    }
                    else
                    {
                        row.CreateCell(cellIndex++).SetCellValue("借出");
                    }
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_DA_DAINFO_LIST[i].REMARK));
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
        public ActionResult EXPORT_DOWNLOAD_DAINFO(string filename)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", "技术档案信息导出.xlsx");
        }
        [HttpPost]
        public string INSERT_BOOKINFO(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_BOOK_BOOKINFO model_HR_BOOK_BOOKINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_BOOK_BOOKINFO>(datastring);
            model_HR_BOOK_BOOKINFO.CJR = STAFFID;
            MES_RETURN_UI rst = hrmodels.BOOK_BOOKINFO.INSERT_BOOKINFO(model_HR_BOOK_BOOKINFO, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string SELECT_BOOKINFO(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_BOOK_BOOKINFO model_HR_BOOK_BOOKINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_BOOK_BOOKINFO>(datastring);
            HR_BOOK_BOOKINFO_SELECT rst = hrmodels.BOOK_BOOKINFO.SELECT_BOOKINFO(model_HR_BOOK_BOOKINFO, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string UPDATE_BOOKINFO(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_BOOK_BOOKINFO model_HR_BOOK_BOOKINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_BOOK_BOOKINFO>(datastring);
            model_HR_BOOK_BOOKINFO.XGR = STAFFID;
            MES_RETURN_UI rst = hrmodels.BOOK_BOOKINFO.UPDATE_BOOKINFO(model_HR_BOOK_BOOKINFO, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string LOGOUT_BOOKINFO(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_BOOK_BOOKINFO model_HR_BOOK_BOOKINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_BOOK_BOOKINFO>(datastring);
            MES_RETURN_UI rst = hrmodels.BOOK_BOOKINFO.LOGOUT_BOOKINFO(model_HR_BOOK_BOOKINFO, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string EXPOST_BOOKINFO(string alldata)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_BOOK_BOOKINFO_LIST[] model_HR_BOOK_BOOKINFO_LIST = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_BOOK_BOOKINFO_LIST[]>(alldata);
            try
            {
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/导出模版.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 0;
                string tt = "条码,书名,出版社,作者,类型,价格,库存,入库日期,备注,操作人,操作时间";
                string[] ttlist = tt.Split(',');
                IRow rowtt = sheet.CreateRow(rowcount++);
                int cellIndex = 0;
                for (int a = 0; a < ttlist.Length; a++)
                {
                    rowtt.CreateCell(cellIndex++).SetCellValue(ttlist[a]);
                }
                for (int i = 0; i < model_HR_BOOK_BOOKINFO_LIST.Length; i++)
                {
                    cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_BOOK_BOOKINFO_LIST[i].BOOKNO));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_BOOK_BOOKINFO_LIST[i].BOOKNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_BOOK_BOOKINFO_LIST[i].CBS));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_BOOK_BOOKINFO_LIST[i].ZZ));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_BOOK_BOOKINFO_LIST[i].LXNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_BOOK_BOOKINFO_LIST[i].PRICE));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_BOOK_BOOKINFO_LIST[i].KC));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_BOOK_BOOKINFO_LIST[i].RKDATE));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_BOOK_BOOKINFO_LIST[i].REMARK));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_BOOK_BOOKINFO_LIST[i].XGRNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_BOOK_BOOKINFO_LIST[i].XGRTIME));
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
        public ActionResult EXPORT_DOWNLOAD_BOOKINFO(string filename)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", "图书资料信息导出.xlsx");
        }
        [HttpPost]
        public string Data_DaoRu_BOOKINFO()
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
                    string[] sheet = { "图书资料导入" };


                    //开始做数据校验

                    DataTable data1 = ExcelToDataTable(savePath, 0, true);      //专项附加扣除
                    #region
                    if (data1 != null)
                    {
                        if (data1.Columns.Contains("条码") == false || data1.Columns.Contains("书名") == false || data1.Columns.Contains("出版社") == false || data1.Columns.Contains("作者") == false || data1.Columns.Contains("类型") == false || data1.Columns.Contains("价格") == false || data1.Columns.Contains("备注") == false)
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
                                    for (int a = 1; a < data1.Rows.Count; a++)
                                    {
                                        if (data1.Rows[a]["条码"].ToString().Trim() != "")
                                        {
                                            if (data1.Rows[a - 1]["条码"].ToString().Trim() == data1.Rows[a]["条码"].ToString().Trim())
                                            {
                                                msg.Msg = "条码 " + data1.Rows[a]["条码"].ToString().Trim() + " 重复！";
                                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                            }
                                        }
                                    }
                                    for (int i = 0; i < data1.Rows.Count; i++)
                                    {
                                        if (data1.Rows[i]["条码"].ToString() == "")
                                        {
                                            msg.Msg = "图书资料导入第" + (i + 2) + "行条码未输！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (data1.Rows[i]["书名"].ToString() == "")
                                        {
                                            msg.Msg = "图书资料导入第" + (i + 2) + "行书名未输！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (data1.Rows[i]["出版社"].ToString() == "")
                                        {
                                            msg.Msg = "图书资料导入第" + (i + 2) + "行出版社未输！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (data1.Rows[i]["作者"].ToString() == "")
                                        {
                                            msg.Msg = "图书资料导入第" + (i + 2) + "行作者未输！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (data1.Rows[i]["类型"].ToString() == "")
                                        {
                                            msg.Msg = "图书资料导入第" + (i + 2) + "行类型未输！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        else
                                        {
                                            HR_SY_TYPEMX model_HR_SY_TYPEMX = new HR_SY_TYPEMX();
                                            model_HR_SY_TYPEMX.TYPEID = 44;
                                            model_HR_SY_TYPEMX.MXNAME = data1.Rows[i]["类型"].ToString();
                                            HR_SY_TYPEMX_SELECT rst = hrmodels.SY_TYPEMX.SELECT(model_HR_SY_TYPEMX, token);
                                            if (rst.HR_SY_TYPEMX.Length == 0)
                                            {
                                                msg.Msg = "图书资料导入第" + (i + 2) + "行类型不存在！";
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
                        HR_BOOK_BOOKINFO model_HR_BOOK_BOOKINFO = new HR_BOOK_BOOKINFO();
                        model_HR_BOOK_BOOKINFO.BOOKNO = data1.Rows[i]["条码"].ToString();
                        model_HR_BOOK_BOOKINFO.BOOKNAME = data1.Rows[i]["书名"].ToString();
                        model_HR_BOOK_BOOKINFO.CBS = data1.Rows[i]["出版社"].ToString();
                        model_HR_BOOK_BOOKINFO.ZZ = data1.Rows[i]["作者"].ToString();
                        HR_SY_TYPEMX model_HR_SY_TYPEMX = new HR_SY_TYPEMX();
                        model_HR_SY_TYPEMX.MXNAME = data1.Rows[i]["类型"].ToString();
                        HR_SY_TYPEMX_SELECT rst = hrmodels.SY_TYPEMX.SELECT(model_HR_SY_TYPEMX, token);
                        model_HR_BOOK_BOOKINFO.LX = rst.HR_SY_TYPEMX[0].ID;
                        model_HR_BOOK_BOOKINFO.PRICE = data1.Rows[i]["价格"].ToString();
                        model_HR_BOOK_BOOKINFO.RKDATE = DateTime.Now.ToString("yyyy-MM-dd");
                        model_HR_BOOK_BOOKINFO.REMARK = data1.Rows[i]["备注"].ToString();
                        model_HR_BOOK_BOOKINFO.CJR = STAFFID;
                        MES_RETURN_UI result = hrmodels.BOOK_BOOKINFO.INSERT_BOOKINFO(model_HR_BOOK_BOOKINFO, token);


                        if (result.TYPE == "E")
                        {
                            msg.Msg = "工会导入的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
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
        public ActionResult EXPORT_MBLOAD_BOOKINFO()
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            byte[] arrFile = null;
            try
            {
                string file = string.Format(@"{0}/Areas/HR/ExportFile/中银HR系统_图书资料采集表.xlsx", Server.MapPath("~"));
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
            return File(arrFile, "application/vnd.ms-excel", "中银HR系统_图书资料采集表.xlsx");
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
        public string BOOK_LOOK_JY(string datastring, int RYID, string JYDATE)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_RETURN_UI rst = new MES_RETURN_UI();
            HR_BOOK_BOOKINFO[] model_HR_BOOK_BOOKINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_BOOK_BOOKINFO[]>(datastring);
            for (int i = 0; i < model_HR_BOOK_BOOKINFO.Length; i++)
            {
                model_HR_BOOK_BOOKINFO[i].CJR = STAFFID;
                model_HR_BOOK_BOOKINFO[i].RYID = RYID;
                model_HR_BOOK_BOOKINFO[i].JYDATE = JYDATE;
                rst = hrmodels.BOOK_BOOKINFO.JY_BOOK(model_HR_BOOK_BOOKINFO[i], token);
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string BOOK_LOOK_GH(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_BOOK_BOOKINFO model_HR_BOOK_BOOKINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_BOOK_BOOKINFO>(datastring);
            model_HR_BOOK_BOOKINFO.XGR = STAFFID;
            MES_RETURN_UI rst = hrmodels.BOOK_BOOKINFO.GH_BOOK(model_HR_BOOK_BOOKINFO, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string SELECT_BOOK_LOOK(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_BOOK_BOOKINFO model_HR_BOOK_BOOKINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_BOOK_BOOKINFO>(datastring);
            HR_BOOK_BOOKINFO_SELECT rst = hrmodels.BOOK_BOOKINFO.SELECT_BOOK_LOOK(model_HR_BOOK_BOOKINFO, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string SELECT_BOOK_LOOK_JY(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_BOOK_BOOKINFO model_HR_BOOK_BOOKINFO = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_BOOK_BOOKINFO>(datastring);
            HR_BOOK_BOOKINFO_SELECT rst = hrmodels.BOOK_BOOKINFO.SELECT_BOOK_LOOK_JY(model_HR_BOOK_BOOKINFO, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string EXPOST_BOOK_LOOK(string alldata)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_BOOK_BOOKINFO_LIST[] model_HR_BOOK_BOOKINFO_LIST = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_BOOK_BOOKINFO_LIST[]>(alldata);
            try
            {
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/导出模版.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 0;
                string tt = "条码,书名,工号,姓名,借阅日期,归还日期";
                string[] ttlist = tt.Split(',');
                IRow rowtt = sheet.CreateRow(rowcount++);
                int cellIndex = 0;
                for (int a = 0; a < ttlist.Length; a++)
                {
                    rowtt.CreateCell(cellIndex++).SetCellValue(ttlist[a]);
                }
                for (int i = 0; i < model_HR_BOOK_BOOKINFO_LIST.Length; i++)
                {
                    cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_BOOK_BOOKINFO_LIST[i].BOOKNO));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_BOOK_BOOKINFO_LIST[i].BOOKNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_BOOK_BOOKINFO_LIST[i].GH));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_BOOK_BOOKINFO_LIST[i].YGNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_BOOK_BOOKINFO_LIST[i].JYDATE));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_BOOK_BOOKINFO_LIST[i].GHDATE));
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
        public ActionResult EXPORT_DOWNLOAD_BOOK_LOOK(string filename)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", "图书借阅信息导出.xlsx");
        }
        [HttpPost]
        public string EXPOST_BOOK_LOOK_BOOK(string alldata)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_BOOK_BOOKINFO_LIST[] model_HR_BOOK_BOOKINFO_LIST = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_BOOK_BOOKINFO_LIST[]>(alldata);
            try
            {
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/导出模版.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 0;
                string tt = "条码,书名,出版社,作者,价格,借阅数";
                string[] ttlist = tt.Split(',');
                IRow rowtt = sheet.CreateRow(rowcount++);
                int cellIndex = 0;
                for (int a = 0; a < ttlist.Length; a++)
                {
                    rowtt.CreateCell(cellIndex++).SetCellValue(ttlist[a]);
                }
                for (int i = 0; i < model_HR_BOOK_BOOKINFO_LIST.Length; i++)
                {
                    cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_BOOK_BOOKINFO_LIST[i].BOOKNO));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_BOOK_BOOKINFO_LIST[i].BOOKNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_BOOK_BOOKINFO_LIST[i].CBS));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_BOOK_BOOKINFO_LIST[i].ZZ));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_BOOK_BOOKINFO_LIST[i].PRICE));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_BOOK_BOOKINFO_LIST[i].BOOKCOUNT));
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
        public ActionResult EXPORT_DOWNLOAD_BOOK_LOOK_BOOK(string filename)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", "借阅图书报表导出.xlsx");
        }
        [HttpPost]
        public string EXPOST_BOOK_LOOK_RY(string alldata)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_BOOK_BOOKINFO_LIST[] model_HR_BOOK_BOOKINFO_LIST = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_BOOK_BOOKINFO_LIST[]>(alldata);
            try
            {
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/导出模版.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 0;
                string tt = "工号,姓名,借阅数";
                string[] ttlist = tt.Split(',');
                IRow rowtt = sheet.CreateRow(rowcount++);
                int cellIndex = 0;
                for (int a = 0; a < ttlist.Length; a++)
                {
                    rowtt.CreateCell(cellIndex++).SetCellValue(ttlist[a]);
                }
                for (int i = 0; i < model_HR_BOOK_BOOKINFO_LIST.Length; i++)
                {
                    cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_BOOK_BOOKINFO_LIST[i].GH));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_BOOK_BOOKINFO_LIST[i].YGNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_BOOK_BOOKINFO_LIST[i].BOOKCOUNT));
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
        public ActionResult EXPORT_DOWNLOAD_BOOK_LOOK_RY(string filename)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", "借阅人员报表导出.xlsx");
        }
        [HttpPost]
        public string ADMINISTRATION_YHRY_INSERT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_ADMINISTRATION_YHRY model_HR_ADMINISTRATION_YHRY = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_ADMINISTRATION_YHRY>(datastring);
            model_HR_ADMINISTRATION_YHRY.CJR = STAFFID;
            MES_RETURN_UI rst = hrmodels.ADMINISTRATION_YHRY.INSERT(model_HR_ADMINISTRATION_YHRY, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string ADMINISTRATION_YHRY_UPDATE(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_ADMINISTRATION_YHRY model_HR_ADMINISTRATION_YHRY = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_ADMINISTRATION_YHRY>(datastring);
            model_HR_ADMINISTRATION_YHRY.XGR = STAFFID;
            MES_RETURN_UI rst = hrmodels.ADMINISTRATION_YHRY.UPDATE(model_HR_ADMINISTRATION_YHRY, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string ADMINISTRATION_YHRY_SELECT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_ADMINISTRATION_YHRY model_HR_ADMINISTRATION_YHRY = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_ADMINISTRATION_YHRY>(datastring);
            HR_ADMINISTRATION_YHRY_SELECT rst = hrmodels.ADMINISTRATION_YHRY.SELECT(model_HR_ADMINISTRATION_YHRY, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string EXPOST_HRXZGL_YHRY(string datastring)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_ADMINISTRATION_YHRY model_HR_ADMINISTRATION_YHRY = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_ADMINISTRATION_YHRY>(datastring);
            HR_ADMINISTRATION_YHRY_SELECT rst_HR_ADMINISTRATION_YHRY_SELECT = hrmodels.ADMINISTRATION_YHRY.SELECT(model_HR_ADMINISTRATION_YHRY, token);
            if (rst_HR_ADMINISTRATION_YHRY_SELECT.MES_RETURN.TYPE == "E")
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(rst_HR_ADMINISTRATION_YHRY_SELECT.MES_RETURN);
            }
            try
            {
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/导出模版.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);

                sheet.FitToPage = false;
                sheet.PrintSetup.Landscape = true;

                sheet.PrintSetup.PaperSize = 9;
                sheet.SetMargin(MarginType.LeftMargin, (double)0.6);
                sheet.SetMargin(MarginType.RightMargin, (double)0.6);
                sheet.SetMargin(MarginType.BottomMargin, (double)0.6);
                sheet.SetMargin(MarginType.TopMargin, (double)0.6);

                ICellStyle style1 = workbook.CreateCellStyle();
                IFont font = workbook.CreateFont();
                font.FontHeightInPoints = 16;
                font.FontName = "宋体";
                style1.SetFont(font);
                style1.VerticalAlignment = VerticalAlignment.Center;
                style1.Alignment = HorizontalAlignment.Center;


                ICellStyle style2 = workbook.CreateCellStyle();
                style2.BorderBottom = BorderStyle.Thin;
                style2.BorderLeft = BorderStyle.Thin;
                style2.BorderRight = BorderStyle.Thin;
                style2.BorderTop = BorderStyle.Thin;
                style2.VerticalAlignment = VerticalAlignment.Center;
                style2.Alignment = HorizontalAlignment.Center;
                font = workbook.CreateFont();
                font.FontHeightInPoints = 12;
                font.FontName = "宋体";
                style2.SetFont(font);

                ICellStyle style3 = workbook.CreateCellStyle();
                style3.BorderBottom = BorderStyle.Thin;
                style3.BorderLeft = BorderStyle.Thin;
                style3.BorderRight = BorderStyle.Thin;
                style3.BorderTop = BorderStyle.Thin;
                style3.VerticalAlignment = VerticalAlignment.Center;
                style3.Alignment = HorizontalAlignment.Left;
                font = workbook.CreateFont();
                font.FontHeightInPoints = 11;
                font.FontName = "宋体";
                style3.SetFont(font);


                int cellcount = 0;
                sheet.SetColumnWidth(cellcount++, 5 * 256);
                sheet.SetColumnWidth(cellcount++, 9 * 256);
                sheet.SetColumnWidth(cellcount++, 9 * 256);
                sheet.SetColumnWidth(cellcount++, 30 * 256);
                sheet.SetColumnWidth(cellcount++, 10 * 256);
                sheet.SetColumnWidth(cellcount++, 10 * 256);
                sheet.SetColumnWidth(cellcount++, 17 * 256);
                sheet.SetColumnWidth(cellcount++, 13 * 256);
                sheet.SetColumnWidth(cellcount++, 11 * 256);
                sheet.SetColumnWidth(cellcount++, 10 * 256);
                sheet.SetColumnWidth(cellcount++, 10 * 256);


                int rowcount = 0;
                string tt = "序号,姓名,职务级别,职务描述,性别,公司简称,归属部门,政治面貌,出生日期,HR工号,备注";
                string[] ttlist = tt.Split(',');
                IRow row = sheet.CreateRow(rowcount++);
                sheet.AddMergedRegion(new CellRangeAddress(rowcount - 1, rowcount - 1, 0, 10));
                row.CreateCell(0).SetCellValue("                                  与会人员清单" + "              导出时间" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                row.GetCell(0).CellStyle = style1;
                row = sheet.CreateRow(rowcount++);
                int cellIndex = 0;
                for (int a = 0; a < ttlist.Length; a++)
                {
                    row.CreateCell(cellIndex++).SetCellValue(ttlist[a]);
                    row.GetCell(a).CellStyle = style2;
                }
                for (int i = 0; i < rst_HR_ADMINISTRATION_YHRY_SELECT.DATALIST.Rows.Count; i++)
                {
                    cellIndex = 0;
                    row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue((i + 1).ToString());
                    row.CreateCell(cellIndex++).SetCellValue(rst_HR_ADMINISTRATION_YHRY_SELECT.DATALIST.Rows[i]["XM"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(rst_HR_ADMINISTRATION_YHRY_SELECT.DATALIST.Rows[i]["ZWLEVELNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(rst_HR_ADMINISTRATION_YHRY_SELECT.DATALIST.Rows[i]["ZWMS"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(rst_HR_ADMINISTRATION_YHRY_SELECT.DATALIST.Rows[i]["XB"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(rst_HR_ADMINISTRATION_YHRY_SELECT.DATALIST.Rows[i]["GSNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(rst_HR_ADMINISTRATION_YHRY_SELECT.DATALIST.Rows[i]["GSBMNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(rst_HR_ADMINISTRATION_YHRY_SELECT.DATALIST.Rows[i]["ZZMMNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(rst_HR_ADMINISTRATION_YHRY_SELECT.DATALIST.Rows[i]["CSRQ"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(rst_HR_ADMINISTRATION_YHRY_SELECT.DATALIST.Rows[i]["GH"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(rst_HR_ADMINISTRATION_YHRY_SELECT.DATALIST.Rows[i]["REMARK"].ToString());
                    
                    for (int a = 0; a < 11; a++)
                    {
                        row.GetCell(a).CellStyle = style3;
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
        [HttpPost]
        public string ADMINISTRATION_DORM_INSERT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_ADMINISTRATION_DORM_DORM model_HR_ADMINISTRATION_DORM_DORM = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_ADMINISTRATION_DORM_DORM>(datastring);
            model_HR_ADMINISTRATION_DORM_DORM.CJR = STAFFID;
            MES_RETURN_UI rst = hrmodels.ADMINISTRATION_DORM.INSERT(model_HR_ADMINISTRATION_DORM_DORM, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string ADMINISTRATION_DORM_UPDATE(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_ADMINISTRATION_DORM_DORM model_HR_ADMINISTRATION_DORM_DORM = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_ADMINISTRATION_DORM_DORM>(datastring);
            model_HR_ADMINISTRATION_DORM_DORM.XGR = STAFFID;
            MES_RETURN_UI rst = hrmodels.ADMINISTRATION_DORM.UPDATE(model_HR_ADMINISTRATION_DORM_DORM, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string ADMINISTRATION_DORM_SELECT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_ADMINISTRATION_DORM_DORM model_HR_ADMINISTRATION_DORM_DORM = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_ADMINISTRATION_DORM_DORM>(datastring);
            HR_ADMINISTRATION_DORM_DORM_SELECT rst = hrmodels.ADMINISTRATION_DORM.SELECT(model_HR_ADMINISTRATION_DORM_DORM, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string ADMINISTRATION_DORM_ROOM_INSERT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_ADMINISTRATION_DORM_ROOM model_HR_ADMINISTRATION_DORM_ROOM = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_ADMINISTRATION_DORM_ROOM>(datastring);
            model_HR_ADMINISTRATION_DORM_ROOM.CJR = STAFFID;
            MES_RETURN_UI rst = hrmodels.ADMINISTRATION_DORM.ROOM_INSERT(model_HR_ADMINISTRATION_DORM_ROOM, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string ADMINISTRATION_DORM_ROOM_UPDATE(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_ADMINISTRATION_DORM_ROOM model_HR_ADMINISTRATION_DORM_ROOM = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_ADMINISTRATION_DORM_ROOM>(datastring);
            model_HR_ADMINISTRATION_DORM_ROOM.XGR = STAFFID;
            MES_RETURN_UI rst = hrmodels.ADMINISTRATION_DORM.ROOM_UPDATE(model_HR_ADMINISTRATION_DORM_ROOM, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string ADMINISTRATION_DORM_ROOM_SELECT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_ADMINISTRATION_DORM_ROOM model_HR_ADMINISTRATION_DORM_ROOM = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_ADMINISTRATION_DORM_ROOM>(datastring);
            HR_ADMINISTRATION_DORM_ROOM_SELECT rst = hrmodels.ADMINISTRATION_DORM.ROOM_SELECT(model_HR_ADMINISTRATION_DORM_ROOM, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string ADMINISTRATION_DORM_LIVE_INSERT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_ADMINISTRATION_DORM_LIVE model_HR_ADMINISTRATION_DORM_LIVE = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_ADMINISTRATION_DORM_LIVE>(datastring);
            model_HR_ADMINISTRATION_DORM_LIVE.CJR = STAFFID;
            MES_RETURN_UI rst = hrmodels.ADMINISTRATION_DORM.LIVE_INSERT(model_HR_ADMINISTRATION_DORM_LIVE, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string ADMINISTRATION_DORM_LIVE_UPDATE(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_ADMINISTRATION_DORM_LIVE model_HR_ADMINISTRATION_DORM_LIVE = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_ADMINISTRATION_DORM_LIVE>(datastring);
            model_HR_ADMINISTRATION_DORM_LIVE.XGR = STAFFID;
            MES_RETURN_UI rst = hrmodels.ADMINISTRATION_DORM.LIVE_UPDATE(model_HR_ADMINISTRATION_DORM_LIVE, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string ADMINISTRATION_DORM_LIVE_SELECT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_ADMINISTRATION_DORM_LIVE model_HR_ADMINISTRATION_DORM_LIVE = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_ADMINISTRATION_DORM_LIVE>(datastring);
            HR_ADMINISTRATION_DORM_LIVE_SELECT rst = hrmodels.ADMINISTRATION_DORM.LIVE_SELECT(model_HR_ADMINISTRATION_DORM_LIVE, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string EXPOST_ADMINISTRATION_DORM_ROOM(string datastring)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_ADMINISTRATION_DORM_ROOM model_HR_ADMINISTRATION_DORM_ROOM = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_ADMINISTRATION_DORM_ROOM>(datastring);
            HR_ADMINISTRATION_DORM_ROOM_SELECT result = hrmodels.ADMINISTRATION_DORM.ROOM_SELECT(model_HR_ADMINISTRATION_DORM_ROOM, token);
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
                string tt = "宿舍名称,房间号,房间类型,入住人员,房屋类型,房间备注,额定数,入住数,剩余数,房间状态,宿舍备注";
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
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["DORMNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["ROOMNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["ROOMTYPENAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["LIVENAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["DORMJG"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["REMARK"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["ROOMRYCOUNT"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["LIVECOUNT"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToInt32(dtinfo.Rows[i]["ROOMRYCOUNT"].ToString()) - Convert.ToInt32(dtinfo.Rows[i]["ROOMRYCOUNT"].ToString()));
                    int RQBJ = Convert.ToInt32(dtinfo.Rows[i]["ROOMZT"].ToString());
                    if (RQBJ == 1)
                    {
                        row.CreateCell(cellIndex++).SetCellValue("空房");
                    }
                    else if (RQBJ == 2)
                    {
                        row.CreateCell(cellIndex++).SetCellValue("未满");
                    }
                    else
                    {
                        row.CreateCell(cellIndex++).SetCellValue("满房");
                    }
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["DORMREMARK"].ToString());
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
        public string EXPOST_ADMINISTRATION_DORM_LIVE(string datastring)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_ADMINISTRATION_DORM_LIVE model_HR_ADMINISTRATION_DORM_LIVE = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_ADMINISTRATION_DORM_LIVE>(datastring);
            HR_ADMINISTRATION_DORM_LIVE_SELECT result = hrmodels.ADMINISTRATION_DORM.LIVE_SELECT(model_HR_ADMINISTRATION_DORM_LIVE, token);
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
                string tt = "宿舍名称,房间号,房间类型,姓名,证件号码,户籍地址,公司,归属部门,房屋类型,住宿状态,住宿费,入住日期,搬离日期,HR工号,联系电话,性别,学历,备注,房间备注";
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
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["DORMNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["ROOMNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["ROOMTYPENAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["LIVENAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["ZZNO"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["HJADDRESS"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["GSNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["GSBMNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["DORMJG"].ToString());
                    int LIVETYPE = Convert.ToInt32(dtinfo.Rows[i]["LIVETYPE"].ToString());
                    if (LIVETYPE == 1)
                    {
                        row.CreateCell(cellIndex++).SetCellValue("入住");
                    }
                    else
                    {
                        row.CreateCell(cellIndex++).SetCellValue("搬离");
                    }
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["LIVEJG"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["LIVEINRQ"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["LIVEOUTRQ"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["GH"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["LIVEPHONENUMBER"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["LIVEXB"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["LIVEXLNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["REMARK"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["ROOMREMARK"].ToString());
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
