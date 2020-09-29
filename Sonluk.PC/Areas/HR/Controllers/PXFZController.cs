using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Sonluk.PC.APPCLASS;
using Sonluk.PC.Models;
using Sonluk.UI.Model.HR.PX_PXZTService;
using Sonluk.UI.Model.HR.RY_RYINFOService;
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
    public class PXFZController : Controller
    {
        //
        // GET: /HR/PX_PXZT/
        HRModels hrmodels = new HRModels();
        PSModels psModels = new PSModels();
        KQModels kqModels = new KQModels();
        string HRFile = System.Configuration.ConfigurationManager.AppSettings["HRFile"];
        string HRFile2 = System.Configuration.ConfigurationManager.AppSettings["HRFile2"];
        string FileSavePath = System.Configuration.ConfigurationManager.AppSettings["HRFile"];
        public ActionResult PXZT()
        {
            AppClass.SetSession("location", 192);
            return View();
        }
        public ActionResult PXMX()
        {
            return View();
        }
        [HttpPost]
        public string PXZT_INSERT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_PX_PXZT model_HR_PX_PXZT = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_PX_PXZT>(datastring);
            model_HR_PX_PXZT.CJR = STAFFID;
            MES_RETURN_UI rst = hrmodels.PX_PXZT.INSERT_PXZT(model_HR_PX_PXZT, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string PXZT_SELECT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_PX_PXZT model_HR_PX_PXZT = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_PX_PXZT>(datastring);
            model_HR_PX_PXZT.STAFFID = STAFFID;
            HR_PX_PXZT_SELECT rst = hrmodels.PX_PXZT.SELECT_PXZT(model_HR_PX_PXZT, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string UPDATE_PXZT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_PX_PXZT model_HR_PX_PXZT = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_PX_PXZT>(datastring);
            model_HR_PX_PXZT.XGR = STAFFID;
            MES_RETURN_UI rst = hrmodels.PX_PXZT.UPDATE_PXZT(model_HR_PX_PXZT, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string Data_Insert_HRfile(int PXZTID)        //上传文件
        {
            var file = Request.Files[0];

            string gotname = file.FileName;
            string[] name = gotname.Split('.');

            string fileName = name[0];
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();
            string today = DateTime.Now.Day.ToString();
            string FileFolder = year + "-" + month + "-" + today;

            int count = name.Length - 1;
            string FFNAME = HRFile + @"\upload\file" + @"\FILE\" + FileFolder;
            string Path_Data = HRFile + @"\upload\file" + @"\FILE\" + FileFolder + @"\" + fileName + "." + name[count];
            string Path = HRFile2 + @"\\upload\\file" + @"\\FILE\\" + FileFolder + @"\\" + fileName + "." + name[count];
            string netpath = System.Configuration.ConfigurationManager.AppSettings["HRNETPATH"] + @"file\/" + @"FILE\/" + FileFolder + @"\/" + fileName + "." + name[count];
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
                HR_PX_PXZT model_HR_PX_PXZT = new HR_PX_PXZT();
                model_HR_PX_PXZT.PXZTID = PXZTID;
                model_HR_PX_PXZT.FJURL = Path;
                model_HR_PX_PXZT.FJREMARK = fileName;
                model_HR_PX_PXZT.CJR = STAFFID;
                hrmodels.PX_PXZT.INSERT_PXZT_FJ(model_HR_PX_PXZT, token);

                string json = "{\"code\":0,\"res\":\"" + netpath + "\",\"locapath\":\"" + Path + "\"}";
                return json;
            }
            else
            {
                return "";
            }

        }
        [HttpPost]
        public string SELECT_PXZT_FJ(int PXZTID)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_PX_PXZT_SELECT rst = hrmodels.PX_PXZT.SELECT_PXZT_FJ(PXZTID, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        //[HttpPost]
        //public string Data_load_PIC(string srcdata)
        //{
        //    string netpath = System.Configuration.ConfigurationManager.AppSettings["HRNETPATH"];
        //    if (srcdata != "")
        //    {
        //        string[] p = srcdata.Split('\\');
        //        int count = p.Length - 1;
        //        string path = p[count - 3] + @"/" + p[count - 2] + @"/" + p[count - 1] + @"/" + p[count];
        //        srcdata = netpath + path;
        //    }
        //    byte[] arrFile = null;
        //    string path_data = string.Format(@"+srcdata+", Server.MapPath("~"));
        //    using (FileStream fs = new FileStream(path_data, FileMode.Open))
        //    {
        //        arrFile = new byte[fs.Length];
        //        fs.Read(arrFile, 0, arrFile.Length);
        //    }
        //    //System.IO.File.Delete(path);
        //    File(arrFile, "application/vnd.ms-excel", "考勤汇总表模版.xlsx");
        //    //return srcdata;
        //}
        [HttpPost]
        public string EXPORT_READ_KQ_DOWNLOAD_DAORUMB(string srcdata)
        {
            string netpath = System.Configuration.ConfigurationManager.AppSettings["HRNETPATH2"];
            string FILE = "";
            if (srcdata != "")
            {
                string[] p = srcdata.Split('\\');
                int count = p.Length - 1;
                string path = p[count - 6] + @"/" + p[count - 4] + @"/" + p[count - 2] + @"/" + p[count];
                srcdata = netpath + path;
                FILE = p[count];
            }
            //System.Net.WebClient webClient = new System.Net.WebClient();
            //webClient.Credentials = System.Net.CredentialCache.DefaultCredentials;
            //webClient.DownloadFile(srcdata, FILE);

            //File file
            //if (file.exists())
            //{
            //    renderFile(file);
            //}
            //else
            //{
            //    renderJson();
            //}  
            return srcdata;
        }
        [HttpPost]
        public string StaffCardID(string in_wlh)
        {
            in_wlh = in_wlh.TrimStart('0');
            string token = AppClass.GetSession("token").ToString();
            string staffID = kqModels.KQinfo.StaffCardID(in_wlh);
            if (staffID == "")
            {
                return "E";
            }
            else
            {
                return staffID.Substring(4, 5);
            }
        }
        [HttpPost]
        public string INSERT_PXZTMX(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_PX_PXZT model_HR_PX_PXZT = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_PX_PXZT>(datastring);
            model_HR_PX_PXZT.CJR = STAFFID;
            MES_RETURN_UI rst = hrmodels.PX_PXZT.INSERT_PXZTMX(model_HR_PX_PXZT, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string SELECT_PXZTMX(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_PX_PXZT model_HR_PX_PXZT = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_PX_PXZT>(datastring);
            HR_PX_PXZT_SELECT rst = hrmodels.PX_PXZT.SELECT_PXZTMX(model_HR_PX_PXZT, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string DELETE_PXZT(int PXZTID)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_RETURN_UI rst = hrmodels.PX_PXZT.DELETE_PXZT(PXZTID, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string DELETE_PXZT_FJ(int FJID)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_RETURN_UI rst = hrmodels.PX_PXZT.DELETE_PXZT_FJ(FJID, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string DELETE_PXZTMX(int PXZTMXID)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_RETURN_UI rst = hrmodels.PX_PXZT.DELETE_PXZTMX(PXZTMXID, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string Data_DaoRu_PXRY(int PXZTID)
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
                    string[] sheet = { "培训人员导入" };


                    //开始做数据校验

                    DataTable data1 = ExcelToDataTable(savePath, 0, true);
                    #region
                    if (data1 != null)
                    {
                        if (data1.Columns.Contains("工号") == false)
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
                            HR_PX_PXZT model = new HR_PX_PXZT();
                            model.RYID = staffdata.HR_RY_RYINFO_LIST[0].RYID;
                            model.PXZTID = PXZTID;
                            model.CJR = STAFFID;

                            MES_RETURN_UI result = hrmodels.PX_PXZT.INSERT_PXZTMX(model, token);


                            if (result.TYPE == "E")
                            {
                                msg.Msg = "培训人员导入的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
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
        public ActionResult EXPORT_MBLOAD_PXRY()
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            byte[] arrFile = null;
            try
            {
                string file = string.Format(@"{0}/Areas/HR/ExportFile/中银HR系统_培训人员登记表.xlsx", Server.MapPath("~"));
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
            return File(arrFile, "application/vnd.ms-excel", "中银HR系统_培训签到导入模板.xlsx");
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
        public string EXPOST_PXZT(string alldata)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_PX_PXZT_LIST[] model_HR_PX_PXZT = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_PX_PXZT_LIST[]>(alldata);
            try
            {
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/导出模版.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 0;
                string tt = "公司,部门,培训主题,起始日期,结束日期,培训老师,培训级别,培训单位,培训地点,培训结果,培训说明";
                string[] ttlist = tt.Split(',');
                IRow rowtt = sheet.CreateRow(rowcount++);
                int cellIndex = 0;
                for (int a = 0; a < ttlist.Length; a++)
                {
                    rowtt.CreateCell(cellIndex++).SetCellValue(ttlist[a]);
                }
                for (int i = 0; i < model_HR_PX_PXZT.Length; i++)
                {
                    cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_PX_PXZT[i].GSNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_PX_PXZT[i].DEPTNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_PX_PXZT[i].PXZTNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_PX_PXZT[i].PXKSRQ));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_PX_PXZT[i].PXJSRQ));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_PX_PXZT[i].PXTEACHER));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_PX_PXZT[i].PXLEVELNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_PX_PXZT[i].PXJS));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_PX_PXZT[i].PXADDRESS));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_PX_PXZT[i].PXRESULT));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_PX_PXZT[i].REMARK));
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
        public ActionResult EXPORT_DOWNLOAD_PXZT(string filename)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", "培训信息导出.xlsx");
        }
        [HttpPost]
        public string SELECT_PXZT_RY(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_PX_PXZT model_HR_PX_PXZT = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_PX_PXZT>(datastring);
            HR_PX_PXZT_SELECT rst = hrmodels.PX_PXZT.SELECT_PXZT_RY(model_HR_PX_PXZT, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string EXPOST_PXZT_RY(string alldata)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_PX_PXZT_LIST[] model_HR_PX_PXZT = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_PX_PXZT_LIST[]>(alldata);
            try
            {
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/导出模版.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 0;
                string tt = "工号,姓名,公司,部门,归属部门,培训主题,起始日期,结束日期,培训老师,培训级别,培训单位,培训地点,培训结果,培训说明";
                string[] ttlist = tt.Split(',');
                IRow rowtt = sheet.CreateRow(rowcount++);
                int cellIndex = 0;
                for (int a = 0; a < ttlist.Length; a++)
                {
                    rowtt.CreateCell(cellIndex++).SetCellValue(ttlist[a]);
                }
                for (int i = 0; i < model_HR_PX_PXZT.Length; i++)
                {
                    cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_PX_PXZT[i].GH));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_PX_PXZT[i].YGNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_PX_PXZT[i].GSNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_PX_PXZT[i].DEPTNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_PX_PXZT[i].GSBMNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_PX_PXZT[i].PXZTNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_PX_PXZT[i].PXKSRQ));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_PX_PXZT[i].PXJSRQ));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_PX_PXZT[i].PXTEACHER));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_PX_PXZT[i].PXLEVELNAME));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_PX_PXZT[i].PXJS));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_PX_PXZT[i].PXADDRESS));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_PX_PXZT[i].PXRESULT));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model_HR_PX_PXZT[i].REMARK));
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
        public ActionResult EXPORT_DOWNLOAD_PXZT_RY(string filename)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", "培训明细信息导出.xlsx");
        }
        public string Data_DaoRu_ZXFJKC(int PXZTID)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_RETURN_UI msg = new MES_RETURN_UI();
            try
            {
                var file = Request.Files[0];
                string year = DateTime.Now.Year.ToString();
                string month = DateTime.Now.Month.ToString();
                string gotname = file.FileName;
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
                        if (data1.Columns.Contains("工号") == false || data1.Columns.Contains("姓名") == false)
                        {
                            msg.TYPE = "E";
                            msg.MESSAGE = "请使用新模版！";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                        else
                        {
                            try
                            {
                                data1.Columns.Add("RYID", typeof(int));
                                if (data1.Rows.Count > 0)
                                {
                                    for (int i = 0; i < data1.Rows.Count; i++)
                                    {
                                        if (data1.Rows[i]["工号"].ToString().Trim() != "")
                                        {
                                            if (data1.Rows[i]["工号"].ToString().Trim().Length != 5)
                                            {
                                                msg.TYPE = "E";
                                                msg.MESSAGE = "第" + (i + 2) + "行(工号:" + data1.Rows[i]["工号"].ToString() + ")工号格式不正确！";
                                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                            }
                                            if (data1.Rows[i]["姓名"].ToString().Trim() == "")
                                            {
                                                msg.TYPE = "E";
                                                msg.MESSAGE = "第" + (i + 2) + "行(工号:" + data1.Rows[i]["工号"].ToString() + ")姓名格式不正确！";
                                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                            }
                                            HR_RY_RYINFO model = new HR_RY_RYINFO();
                                            model.GH = data1.Rows[i]["工号"].ToString().Trim();
                                            model.YGNAME = data1.Rows[i]["姓名"].ToString().Trim();
                                            HR_RY_RYINFO_SELECT staffdata = hrmodels.RY_RYINFO.SELECT(model, token);
                                            if (staffdata.HR_RY_RYINFO_LIST.Length == 0)
                                            {
                                                msg.TYPE = "E";
                                                msg.MESSAGE = "第" + (i + 2) + "行(工号:" + data1.Rows[i]["工号"].ToString() + ")工号不存在，请检查！";
                                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                            }
                                            else
                                            {
                                                data1.Rows[i]["RYID"] = staffdata.HR_RY_RYINFO_LIST[0].RYID;
                                            }
                                        }
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                msg.TYPE = "E";
                                msg.MESSAGE = e.ToString();
                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                            }
                        }
                    }
                    for (int i = 0; i < data1.Rows.Count; i++)
                    {
                        if (data1.Rows[i]["工号"].ToString().Trim() != "")
                        {
                            HR_PX_PXZT_BMRY model = new HR_PX_PXZT_BMRY();
                            model.RYID = Convert.ToInt32(data1.Rows[i]["RYID"].ToString());
                            model.PXZTID = PXZTID;
                            MES_RETURN_UI result = hrmodels.PX_PXZT.PXZT_BMRY_INSERT(model, token);
                            if (result.TYPE == "E")
                            {
                                msg.TYPE = "E";
                                msg.MESSAGE = "第" + (i + 2) + "行(工号:" + data1.Rows[i]["工号"].ToString() + ")出现问题，" + result.MESSAGE;
                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                            }
                        }
                    }
                    msg.TYPE = "S";
                    msg.MESSAGE = "新增成功！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }
                else
                {
                    msg.TYPE = "E";
                    msg.MESSAGE = "文件读取失败！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }
            }
            catch (Exception e)
            {
                msg.TYPE = "E";
                msg.MESSAGE = e.ToString();
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
        }
        [HttpPost]
        public string PX_PXZT_BMRY_SELECT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_PX_PXZT_BMRY model_HR_PX_PXZT_BMRY = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_PX_PXZT_BMRY>(datastring);
            HR_PX_PXZT_BMRY_SELECT rst = hrmodels.PX_PXZT.PXZT_BMRY_SELECT(model_HR_PX_PXZT_BMRY, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        [HttpPost]
        public string EXPOST_PXZT_BMRY(int PXZTID)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            try
            {
                HR_PX_PXZT_BMRY model_HR_PX_PXZT_BMRY = new HR_PX_PXZT_BMRY();
                model_HR_PX_PXZT_BMRY.PXZTID = PXZTID;
                model_HR_PX_PXZT_BMRY.LB = 2;
                HR_PX_PXZT_BMRY_SELECT rst_HR_PX_PXZT_BMRY_SELECT = hrmodels.PX_PXZT.PXZT_BMRY_SELECT(model_HR_PX_PXZT_BMRY, token);
                if (rst_HR_PX_PXZT_BMRY_SELECT.MES_RETURN.TYPE == "S")
                {
                    FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/导出模版.xlsx", FileMode.Open, FileAccess.Read);
                    IWorkbook workbook = new XSSFWorkbook(file);
                    ISheet sheet = workbook.GetSheetAt(0);
                    int rowcount = 0;
                    string tt = "工号,姓名,归属部门,状态";
                    string[] ttlist = tt.Split(',');
                    IRow rowtt = sheet.CreateRow(rowcount++);
                    int cellIndex = 0;
                    for (int a = 0; a < ttlist.Length; a++)
                    {
                        rowtt.CreateCell(cellIndex++).SetCellValue(ttlist[a]);
                    }
                    DataTable dtlist = rst_HR_PX_PXZT_BMRY_SELECT.DATALIST;
                    for (int i = 0; i < dtlist.Rows.Count; i++)
                    {
                        cellIndex = 0;
                        IRow row = sheet.CreateRow(rowcount++);
                        row.CreateCell(cellIndex++).SetCellValue(dtlist.Rows[i]["GH"].ToString());
                        row.CreateCell(cellIndex++).SetCellValue(dtlist.Rows[i]["YGNAME"].ToString());
                        row.CreateCell(cellIndex++).SetCellValue(dtlist.Rows[i]["GSBMNAME"].ToString());
                        row.CreateCell(cellIndex++).SetCellValue(dtlist.Rows[i]["ZT"].ToString());
                    }
                    string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                    FileStream file1 = new FileStream(string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), now), FileMode.Create);
                    workbook.Write(file1);
                    file1.Close();
                    rst.TYPE = "S";
                    rst.MESSAGE = now;
                }
                else
                {
                    return Newtonsoft.Json.JsonConvert.SerializeObject(rst_HR_PX_PXZT_BMRY_SELECT.MES_RETURN);
                }
            }
            catch
            {
                rst.TYPE = "E";
                rst.MESSAGE = "生成文件失败！";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }

        [HttpPost]
        public string EXPOST_MB_RYDR()
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            try
            {
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/导出模版.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 0;
                string tt = "工号,姓名";
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
