using Sonluk.PC.APPCLASS;
using Sonluk.PC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sonluk.UI.Model.HR.KQ_JQGLService;
using Sonluk.UI.Model.HR.KQ_JQGLMXService;
using Sonluk.UI.Model.MODEL;
using System.IO;
using System.Data;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using System.Text.RegularExpressions;
using Sonluk.UI.Model.HR.RY_RYINFOService;
using Sonluk.UI.Model.HR.XZGL_KKGLService;
using Sonluk.UI.Model.HR.SY_GSService;
using Sonluk.UI.Model.HR.KQ_BDService;
using Sonluk.UI.Model.HR.KQ_DEPTKQService;
using Sonluk.UI.Model.HR.KQ_PBFZService;
using Sonluk.UI.Model.HR.KQ_DEPTID_FZIDService;
using Sonluk.UI.Model.HR.KQ_PBFZ_BZIDService;
using Sonluk.UI.Model.HR.KQ_BZService;
using Sonluk.UI.Model.HR.KQ_BZ_BDIDService;
using Sonluk.UI.Model.HR.KQ_RYID_BZIDService;
using Sonluk.UI.Model.HR.KQ_WCDJService;
using Sonluk.UI.Model.HR.KQ_GSKQService;
using Sonluk.UI.Model.HR.KQ_KQINFOService;
using Sonluk.UI.Model.HR.KQ_YCKQService;
using Sonluk.UI.Model.HR.KQ_QJService;
using Sonluk.UI.Model.HR.SY_TYPEMXService;
using NPOI.SS.Util;
using Sonluk.UI.Model.HR.SY_DEPTService;

namespace Sonluk.PC.Areas.HR.Controllers
{
    public class KQGLController : Controller
    {
        //
        // GET: /HR/KQGL/
        HRModels hrmodels = new HRModels();
        CRMModels crmmodels = new CRMModels();
        AppClass appclass = new AppClass();
        string FileSavePath = System.Configuration.ConfigurationManager.AppSettings["FileSavePath"];
        string HRFile = System.Configuration.ConfigurationManager.AppSettings["HRFile"];
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult KQ_JQGL()
        {
            AppClass.SetSession("location", 135);
            return View();
        }
        public ActionResult KQ_JQGLMX()
        {
            AppClass.SetSession("location", 135);
            return View();
        }
        public ActionResult KQ_JQGLREPORT()
        {
            AppClass.SetSession("location", 135);
            return View();
        }
        public ActionResult KQ_BDMANAGE()
        {
            AppClass.SetSession("location", 144);
            return View();
        }
        public ActionResult KQ_DEPTKQ_SELECT()
        {
            AppClass.SetSession("location", 145);
            return View();
        }
        public ActionResult KQ_DEPTKQ_MANAGE()
        {
            AppClass.SetSession("location", 146);
            return View();
        }
        public ActionResult KQ_DEPT_MANAGE()
        {
            AppClass.SetSession("location", 147);
            return View();
        }
        public ActionResult KQ_PBFZ_MANAGE()
        {
            AppClass.SetSession("location", 148);
            return View();
        }
        public ActionResult KQ_BZ_MANAGE()
        {
            AppClass.SetSession("location", 149);
            return View();
        }
        public ActionResult KQ_RY_MANAGE()
        {
            AppClass.SetSession("location", 10000);
            return View();
        }
        public ActionResult KQ_YSKQJL()
        {
            AppClass.SetSession("location", 10001);
            return View();
        }
        public ActionResult KQ_YSKQJL_check()
        {
            AppClass.SetSession("location", 10001);
            return View();
        }
        public ActionResult KQ_WCDJ_MANAGE()
        {
            AppClass.SetSession("location", 10003);
            return View();
        }
        public ActionResult KQ_YCKQ_MANAGE()
        {
            AppClass.SetSession("location", 10004);
            return View();
        }
        public ActionResult KQ_QJ_MANAGE()
        {
            AppClass.SetSession("location", 10009);
            return View();
        }
        public ActionResult KQ_QJ_REPORT()
        {
            AppClass.SetSession("location", 10018);
            return View();
        }
        [HttpPost]
        public string Data_Update_JQGL(string data)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_KQ_JQGL model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_KQ_JQGL>(data);
            model.XGR = STAFFID;
            MES_RETURN_UI result = hrmodels.KQ_JQGL.UPDATE(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }

        [HttpPost]
        public string Data_Select_JQGL(string data)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_KQ_JQGL model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_KQ_JQGL>(data);
            model.STAFFID = STAFFID;
            HR_KQ_JQGL_SELECT result = hrmodels.KQ_JQGL.SELECT(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }

        [HttpPost]
        public string Data_Delete_JQGL(string data)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_KQ_JQGL model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_KQ_JQGL>(data);
            MES_RETURN_UI result = hrmodels.KQ_JQGL.DELETE(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }


        [HttpPost]
        public string Data_Update_JQGLMX(string data)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_KQ_JQGLMX model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_KQ_JQGLMX>(data);
            model.XGR = STAFFID;
            MES_RETURN_UI result = hrmodels.KQ_JQGLMX.UPDATE(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }

        [HttpPost]
        public string Data_Select_JQGLMX(string data)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_KQ_JQGLMX model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_KQ_JQGLMX>(data);
            model.STAFFID = STAFFID;
            HR_KQ_JQGLMX_SELECT result = hrmodels.KQ_JQGLMX.SELECT(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        public string KQ_JQGLMX_SELECT_REPORT(string start, string end, int LB)
        {
            string[] START = start.Split('-');
            string[] END = end.Split('-');
            HR_KQ_JQGLMX cxmodel = new HR_KQ_JQGLMX();
            cxmodel.KSKQYEAR = START[0];
            cxmodel.KSKQMONTH = START[1];
            cxmodel.JSKQYEAR = END[0];
            cxmodel.JSKQMONTH = END[1];

            string token = AppClass.GetSession("token").ToString();
            HR_KQ_JQGLMX_SELECT result = hrmodels.KQ_JQGLMX.SELECT_REPORT(cxmodel, LB, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        public string XZGL_KKGL_AUTOINSERT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_XZGL_KKGL model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_XZGL_KKGL>(datastring);
            model.CJR = STAFFID;
            MES_RETURN_UI result = hrmodels.XZGL_KKGL.AUTOINSERT(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        public string Data_DaoRu_JQGLMX(string time, string start, string end, string ms, string GS)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            //HR_SY_GS_SELECT rst_HR_SY_GS_SELECT = hrmodels.SY_GS.SELECT_BY_ROLE(STAFFID, token);
            string allgs = GS;
            //for (int i = 0; i < rst_HR_SY_GS_SELECT.HR_SY_GS_LIST.Length; i++)
            //{
            //    if (allgs == "")
            //    {
            //        allgs = rst_HR_SY_GS_SELECT.HR_SY_GS_LIST[i].GS;
            //    }
            //    else
            //    {
            //        allgs = allgs + "," + rst_HR_SY_GS_SELECT.HR_SY_GS_LIST[i].GS;
            //    }
            //}
            MES_RETURN_UI msg = new MES_RETURN_UI();
            try
            {
                if (GS == "")
                {
                    msg.TYPE = "E";
                    msg.MESSAGE = "公司不能为空！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }
                if (time == "")
                {
                    msg.TYPE = "E";
                    msg.MESSAGE = "月份不可为空！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }
                if (start == "" || end == "")
                {
                    msg.TYPE = "E";
                    msg.MESSAGE = "考勤周期不可为空！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }
                string YEAR = time.Split('-')[0];
                string MONTH = time.Split('-')[1];
                var file = Request.Files[0];
                //string date = DateTime.Now.ToString("yyyyMMddHHmmss");
                //string fileName = date + "_" + KHID;
                string year = DateTime.Now.Year.ToString();
                string month = DateTime.Now.Month.ToString();
                string gotname = file.FileName;
                //string[] name = gotname.Split('.');
                //int count = name.Length - 1;
                //string savePath = @"E:\CRM\Areas\CRM\upload\" + year + @"\" + month + @"\" + fileName + "." + name[count];
                string savePath = FileSavePath + @"\excel\" + year + @"\" + month + @"\" + gotname;
                if (Directory.Exists(FileSavePath + @"\excel\" + year + @"\" + month) == false)
                {
                    Directory.CreateDirectory(FileSavePath + @"\excel\" + year + @"\" + month);
                }
                file.SaveAs(savePath);
                FileInfo fi = new FileInfo(savePath);
                if (fi.Exists == true)
                {
                    string[] sheet = { "考勤汇总" };
                    DataTable data1 = ExcelToDataTable(savePath, 0, true);
                    if (data1 != null)
                    {
                        if (data1.Columns.Contains("出勤天数") == false || data1.Columns.Contains("病假天数") == false || data1.Columns.Contains("事假天数") == false || data1.Columns.Contains("产假天数") == false || data1.Columns.Contains("婚假天数") == false)
                        {
                            msg.TYPE = "E";
                            msg.MESSAGE = "请使用新增模版！";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                        else
                        {
                            try
                            {
                                data1.DefaultView.Sort = "工号 ASC";
                                data1 = data1.DefaultView.ToTable();
                                if (data1.Rows.Count > 0)
                                {
                                    for (int a = 1; a < data1.Rows.Count; a++)
                                    {
                                        if (data1.Rows[a]["工号"].ToString().Trim() != "")
                                        {
                                            if (data1.Rows[a - 1]["工号"].ToString().Trim() == data1.Rows[a]["工号"].ToString().Trim())
                                            {
                                                msg.TYPE = "E";
                                                msg.MESSAGE = "工号 " + data1.Rows[a]["工号"].ToString().Trim() + " 重复！";
                                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                            }
                                        }
                                    }
                                    for (int i = 0; i < data1.Rows.Count; i++)
                                    {
                                        if (data1.Rows[i]["工号"].ToString().Length != 5)
                                        {
                                            msg.TYPE = "E";
                                            msg.MESSAGE = "考勤汇总第" + (i + 2) + "行工号格式不正确！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        HR_RY_RYINFO model = new HR_RY_RYINFO();
                                        model.GH = data1.Rows[i]["工号"].ToString();
                                        model.ALLGS = allgs;
                                        HR_RY_RYINFO_SELECT staffdata = hrmodels.RY_RYINFO.SELECT(model, token);
                                        if (staffdata.HR_RY_RYINFO_LIST.Length == 0)
                                        {
                                            msg.TYPE = "E";
                                            msg.MESSAGE = "考勤汇总第" + (i + 2) + "行工号不存在！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (Regex.IsMatch(data1.Rows[i]["出勤天数"].ToString(), @"^[0-9]+([.]{1}[0-9]{1,2})?$") == false && data1.Rows[i]["出勤天数"].ToString() != "")
                                        {
                                            msg.TYPE = "E";
                                            msg.MESSAGE = "考勤汇总第" + (i + 2) + "行出勤天数格式不正确！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (Regex.IsMatch(data1.Rows[i]["病假天数"].ToString(), @"^[0-9]+([.]{1}[0-9]{1,2})?$") == false && data1.Rows[i]["病假天数"].ToString() != "")
                                        {
                                            msg.TYPE = "E";
                                            msg.MESSAGE = "考勤汇总第" + (i + 2) + "行病假天数格式不正确！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (Regex.IsMatch(data1.Rows[i]["事假天数"].ToString(), @"^[0-9]+([.]{1}[0-9]{1,2})?$") == false && data1.Rows[i]["事假天数"].ToString() != "")
                                        {
                                            msg.TYPE = "E";
                                            msg.MESSAGE = "考勤汇总第" + (i + 2) + "行事假天数格式不正确！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (Regex.IsMatch(data1.Rows[i]["产假天数"].ToString(), @"^[0-9]+([.]{1}[0-9]{1,2})?$") == false && data1.Rows[i]["产假天数"].ToString() != "")
                                        {
                                            msg.TYPE = "E";
                                            msg.MESSAGE = "考勤汇总第" + (i + 2) + "行产假天数格式不正确！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (Regex.IsMatch(data1.Rows[i]["婚假天数"].ToString(), @"^[0-9]+([.]{1}[0-9]{1,2})?$") == false && data1.Rows[i]["婚假天数"].ToString() != "")
                                        {
                                            msg.TYPE = "E";
                                            msg.MESSAGE = "考勤汇总第" + (i + 2) + "行婚假天数格式不正确！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (Regex.IsMatch(data1.Rows[i]["丧假天数"].ToString(), @"^[0-9]+([.]{1}[0-9]{1,2})?$") == false && data1.Rows[i]["丧假天数"].ToString() != "")
                                        {
                                            msg.TYPE = "E";
                                            msg.MESSAGE = "考勤汇总第" + (i + 2) + "行丧假天数格式不正确！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (Regex.IsMatch(data1.Rows[i]["工伤假天数"].ToString(), @"^[0-9]+([.]{1}[0-9]{1,2})?$") == false && data1.Rows[i]["工伤假天数"].ToString() != "")
                                        {
                                            msg.TYPE = "E";
                                            msg.MESSAGE = "考勤汇总第" + (i + 2) + "行工伤假天数格式不正确！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (Regex.IsMatch(data1.Rows[i]["哺乳假天数"].ToString(), @"^[0-9]+([.]{1}[0-9]{1,2})?$") == false && data1.Rows[i]["哺乳假天数"].ToString() != "")
                                        {
                                            msg.TYPE = "E";
                                            msg.MESSAGE = "考勤汇总第" + (i + 2) + "行哺乳假天数格式不正确！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (Regex.IsMatch(data1.Rows[i]["年休假天数"].ToString(), @"^[0-9]+([.]{1}[0-9]{1,2})?$") == false && data1.Rows[i]["年休假天数"].ToString() != "")
                                        {
                                            msg.TYPE = "E";
                                            msg.MESSAGE = "考勤汇总第" + (i + 2) + "行年休假天数格式不正确！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (Regex.IsMatch(data1.Rows[i]["护理假天数"].ToString(), @"^[0-9]+([.]{1}[0-9]{1,2})?$") == false && data1.Rows[i]["护理假天数"].ToString() != "")
                                        {
                                            msg.TYPE = "E";
                                            msg.MESSAGE = "考勤汇总第" + (i + 2) + "行护理假天数格式不正确！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (Regex.IsMatch(data1.Rows[i]["公差"].ToString(), @"^[0-9]+([.]{1}[0-9]{1,2})?$") == false && data1.Rows[i]["公差"].ToString() != "")
                                        {
                                            msg.TYPE = "E";
                                            msg.MESSAGE = "考勤汇总第" + (i + 2) + "行公差格式不正确！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (Regex.IsMatch(data1.Rows[i]["旷工"].ToString(), @"^[0-9]+([.]{1}[0-9]{1,2})?$") == false && data1.Rows[i]["旷工"].ToString() != "")
                                        {
                                            msg.TYPE = "E";
                                            msg.MESSAGE = "考勤汇总第" + (i + 2) + "行旷工格式不正确！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                    }
                                }
                                else
                                {
                                    msg.TYPE = "E";
                                    msg.MESSAGE = "无导入数据！";
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
                    }
                    HR_KQ_JQGL TTmodel = new HR_KQ_JQGL();
                    TTmodel.KQYEAR = YEAR;
                    TTmodel.KQMONTH = MONTH;
                    TTmodel.GS = GS;
                    TTmodel.STAFFID = STAFFID;
                    HR_KQ_JQGL_SELECT TTcxdata = hrmodels.KQ_JQGL.SELECT(TTmodel, token);
                    if (TTcxdata.HR_KQ_JQGL_LIST.Length != 0)
                    {
                        msg.TYPE = "E";
                        msg.MESSAGE = "该数据已经存在";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }


                    TTmodel.KQZQKS = start;
                    TTmodel.KQZQJS = end;
                    TTmodel.KQNAME = ms;
                    TTmodel.CJR = STAFFID;
                    MES_RETURN_UI TTresult = hrmodels.KQ_JQGL.INSERT(TTmodel, token);
                    if (TTresult.TYPE == "E")
                    {
                        msg.TYPE = "E";
                        msg.MESSAGE = TTresult.MESSAGE;
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }

                    for (int i = 0; i < data1.Rows.Count; i++)
                    {
                        #region

                        HR_RY_RYINFO cxmodel = new HR_RY_RYINFO();
                        cxmodel.GH = data1.Rows[i]["工号"].ToString();
                        HR_RY_RYINFO_SELECT staffdata = hrmodels.RY_RYINFO.SELECT(cxmodel, token);



                        HR_KQ_JQGLMX model = new HR_KQ_JQGLMX();
                        model.RYID = staffdata.HR_RY_RYINFO_LIST[0].RYID;
                        model.JQGLID = TTresult.TID;
                        model.CHUQ = Convert.ToDecimal(ismath(data1.Rows[i]["出勤天数"].ToString().Trim()));
                        model.BINJ = Convert.ToDecimal(ismath(data1.Rows[i]["病假天数"].ToString().Trim()));
                        model.SHIJ = Convert.ToDecimal(ismath(data1.Rows[i]["事假天数"].ToString().Trim()));
                        model.CHANJ = Convert.ToDecimal(ismath(data1.Rows[i]["产假天数"].ToString().Trim()));
                        model.HUNJ = Convert.ToDecimal(ismath(data1.Rows[i]["婚假天数"].ToString().Trim()));
                        model.SANGJ = Convert.ToDecimal(ismath(data1.Rows[i]["丧假天数"].ToString().Trim()));
                        model.GONGSJ = Convert.ToDecimal(ismath(data1.Rows[i]["工伤假天数"].ToString().Trim()));
                        model.BURJ = Convert.ToDecimal(ismath(data1.Rows[i]["哺乳假天数"].ToString().Trim()));
                        model.HULJ = Convert.ToDecimal(ismath(data1.Rows[i]["护理假天数"].ToString().Trim()));
                        model.NIANXJ = Convert.ToDecimal(ismath(data1.Rows[i]["年休假天数"].ToString().Trim()));
                        model.GONGC = Convert.ToDecimal(ismath(data1.Rows[i]["公差"].ToString().Trim()));
                        model.KUANGG = Convert.ToDecimal(ismath(data1.Rows[i]["旷工"].ToString().Trim()));

                        model.CJR = STAFFID;
                        MES_RETURN_UI result = hrmodels.KQ_JQGLMX.INSERT(model, token);


                        if (result.TYPE == "E")
                        {
                            msg.TYPE = "E";
                            msg.MESSAGE = "新增考勤汇总的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                        #endregion
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
        public string Data_DaoChu_JQGL(string start, string end, int LB)
        {
            string token = AppClass.GetSession("token").ToString();
            DaoRuMsg msg = new DaoRuMsg();
            try
            {
                string[] START = start.Split('-');
                string[] END = end.Split('-');
                HR_KQ_JQGLMX cxmodel = new HR_KQ_JQGLMX();
                cxmodel.KSKQYEAR = START[0];
                cxmodel.KSKQMONTH = START[1];
                cxmodel.JSKQYEAR = END[0];
                cxmodel.JSKQMONTH = END[1];
                HR_KQ_JQGLMX_SELECT result = hrmodels.KQ_JQGLMX.SELECT_REPORT(cxmodel, LB, token);
                if (result.MES_RETURN.TYPE == "E")
                {
                    msg.Msg = "err";
                    msg.Info = "查询数据失败";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }
                HR_KQ_JQGLMX_LIST[] model = result.HR_KQ_JQGLMX_LIST;
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/考勤汇总表导出模版.xls", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new HSSFWorkbook(file);
                ISheet worksheet1 = workbook.GetSheet("考勤汇总表");
                if (worksheet1 == null)
                {
                    msg.Msg = "err";
                    msg.Info = "工作薄中没有工作表";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }
                //worksheet1.AddMergedRegion(new CellRangeAddress(1, 2, 3, 4));
                int row1 = 1;
                for (int i = 0; i < model.Length; i++)
                {
                    NPOI.SS.UserModel.IRow row = worksheet1.CreateRow(row1);
                    row.CreateCell(0).SetCellValue(model[i].GH);
                    row.CreateCell(1).SetCellValue(model[i].YGNAME);
                    row.CreateCell(2).SetCellValue(model[i].DEPTNAME);
                    row.CreateCell(3).SetCellValue(model[i].YGTYPENAME);
                    row.CreateCell(4).SetCellValue(model[i].CHUQ.ToString());
                    row.CreateCell(5).SetCellValue(model[i].BINJ.ToString());
                    row.CreateCell(6).SetCellValue(model[i].SHIJ.ToString());
                    row.CreateCell(7).SetCellValue(model[i].CHANJ.ToString());
                    row.CreateCell(8).SetCellValue(model[i].HUNJ.ToString());
                    row.CreateCell(9).SetCellValue(model[i].SANGJ.ToString());
                    row.CreateCell(10).SetCellValue(model[i].GONGSJ.ToString());
                    row.CreateCell(11).SetCellValue(model[i].BURJ.ToString());
                    row.CreateCell(12).SetCellValue(model[i].NIANXJ.ToString());
                    row.CreateCell(13).SetCellValue(model[i].HULJ.ToString());
                    row.CreateCell(14).SetCellValue(model[i].GONGC.ToString());
                    row.CreateCell(15).SetCellValue(model[i].KUANGG.ToString());
                    row1++;
                }
                worksheet1.ForceFormulaRecalculation = true;
                string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                FileStream file1 = new FileStream(string.Format(@"{0}/Areas/HR/ExportFile/{1}.xls", Server.MapPath("~"), now), FileMode.Create);
                workbook.Write(file1);
                file1.Close();

                msg.Msg = now;
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
            catch (Exception e)
            {
                msg.Msg = "err";
                msg.Info = e.ToString();
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
        }
        public ActionResult EXPORT_READ_KQ_JQGLREPORT(string filename)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/HR/ExportFile/{1}.xls", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", "假情明细.xls");
        }
        public ActionResult EXPORT_READ_KQ_DOWNLOAD_DAORUMB()
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/HR/ExportFile/考勤汇总表模版.xlsx", Server.MapPath("~"));
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            //System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", "考勤汇总表模版.xlsx");
        }

        public decimal ismath(string isdmath)
        {
            if (isdmath == "")
            {
                return 0;
            }
            else
            {
                return Convert.ToDecimal(isdmath);
            }
        }
        [HttpPost]
        public string EXPOST_KQ_JQGLMX(string datastring)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_KQ_JQGLMX model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_KQ_JQGLMX>(datastring);
            model.STAFFID = STAFFID;
            HR_KQ_JQGLMX_SELECT rst_HR_KQ_JQGLMX_SELECT = hrmodels.KQ_JQGLMX.SELECT(model, token);
            if (rst_HR_KQ_JQGLMX_SELECT.MES_RETURN.TYPE == "E")
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(rst_HR_KQ_JQGLMX_SELECT.MES_RETURN);
            }
            try
            {
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/导出模版.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 0;
                string tt = "月份,工号,姓名,公司,部门,员工类别,出勤天数,病假天数,事假天数,产假天数,婚假天数,丧假天数,工伤假天数,哺乳假天数,护理假天数,年休假天数,公差,旷工";
                string[] ttlist = tt.Split(',');
                IRow rowtt = sheet.CreateRow(rowcount++);
                int cellIndex = 0;
                for (int a = 0; a < ttlist.Length; a++)
                {
                    rowtt.CreateCell(cellIndex++).SetCellValue(ttlist[a]);
                }
                for (int i = 0; i < rst_HR_KQ_JQGLMX_SELECT.HR_KQ_JQGLMX_LIST.Length; i++)
                {
                    cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue(rst_HR_KQ_JQGLMX_SELECT.HR_KQ_JQGLMX_LIST[i].KQYEAR + "-" + rst_HR_KQ_JQGLMX_SELECT.HR_KQ_JQGLMX_LIST[i].KQMONTH);
                    row.CreateCell(cellIndex++).SetCellValue(rst_HR_KQ_JQGLMX_SELECT.HR_KQ_JQGLMX_LIST[i].GH);
                    row.CreateCell(cellIndex++).SetCellValue(rst_HR_KQ_JQGLMX_SELECT.HR_KQ_JQGLMX_LIST[i].YGNAME);
                    row.CreateCell(cellIndex++).SetCellValue(rst_HR_KQ_JQGLMX_SELECT.HR_KQ_JQGLMX_LIST[i].GSNAME);
                    row.CreateCell(cellIndex++).SetCellValue(rst_HR_KQ_JQGLMX_SELECT.HR_KQ_JQGLMX_LIST[i].DEPTNAME);
                    row.CreateCell(cellIndex++).SetCellValue(rst_HR_KQ_JQGLMX_SELECT.HR_KQ_JQGLMX_LIST[i].YGTYPENAME);
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(rst_HR_KQ_JQGLMX_SELECT.HR_KQ_JQGLMX_LIST[i].CHUQ));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(rst_HR_KQ_JQGLMX_SELECT.HR_KQ_JQGLMX_LIST[i].BINJ));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(rst_HR_KQ_JQGLMX_SELECT.HR_KQ_JQGLMX_LIST[i].SHIJ));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(rst_HR_KQ_JQGLMX_SELECT.HR_KQ_JQGLMX_LIST[i].CHANJ));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(rst_HR_KQ_JQGLMX_SELECT.HR_KQ_JQGLMX_LIST[i].HUNJ));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(rst_HR_KQ_JQGLMX_SELECT.HR_KQ_JQGLMX_LIST[i].SANGJ));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(rst_HR_KQ_JQGLMX_SELECT.HR_KQ_JQGLMX_LIST[i].GONGSJ));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(rst_HR_KQ_JQGLMX_SELECT.HR_KQ_JQGLMX_LIST[i].BURJ));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(rst_HR_KQ_JQGLMX_SELECT.HR_KQ_JQGLMX_LIST[i].HULJ));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(rst_HR_KQ_JQGLMX_SELECT.HR_KQ_JQGLMX_LIST[i].NIANXJ));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(rst_HR_KQ_JQGLMX_SELECT.HR_KQ_JQGLMX_LIST[i].GONGC));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(rst_HR_KQ_JQGLMX_SELECT.HR_KQ_JQGLMX_LIST[i].KUANGG));
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
        public ActionResult EXPORT_DOWNLOAD_KQ_JQGLMX(string filename)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", "考勤明细数据.xlsx");
        }
        [HttpPost]
        public string KQ_BD_INSERT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_KQ_BD model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_KQ_BD>(datastring);
            model.CJR = STAFFID;
            MES_RETURN_UI result = hrmodels.KQ_BD.INSERT(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        public string KQ_BD_SELECT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_KQ_BD model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_KQ_BD>(datastring);
            HR_KQ_BD_SELECT result = hrmodels.KQ_BD.SELECT(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        public string KQ_BD_UPDATE(string datastring, int LB)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_KQ_BD model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_KQ_BD>(datastring);
            model.XGR = STAFFID;
            MES_RETURN_UI result = hrmodels.KQ_BD.UPDATE(model, LB, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        public string KQ_DEPTKQ_INSERT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_KQ_DEPTKQ model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_KQ_DEPTKQ>(datastring);
            model.CJR = STAFFID;
            MES_RETURN_UI result = hrmodels.KQ_DEPTKQ.INSERT(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        public string KQ_DEPTKQ_UPDATE(string datastring, int LB)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_KQ_DEPTKQ model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_KQ_DEPTKQ>(datastring);
            model.XGR = STAFFID;
            MES_RETURN_UI result = hrmodels.KQ_DEPTKQ.UPDATE(model, LB, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        public string KQ_DEPTKQ_UPDATE_PL(string datastring, int LB)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_RETURN_UI result = new MES_RETURN_UI();
            HR_KQ_DEPTKQ[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_KQ_DEPTKQ[]>(datastring);
            for (int a = 0; a < model.Length; a++)
            {
                model[a].XGR = STAFFID;
                result = hrmodels.KQ_DEPTKQ.UPDATE(model[a], LB, token);
                if (result.TYPE == "E")
                {
                    return Newtonsoft.Json.JsonConvert.SerializeObject(result);
                }
            }
            result.TYPE = "S";
            result.MESSAGE = "";
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        public string KQ_DEPTKQ_SELECT_LB(string datastring, int LB)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_KQ_DEPTKQ model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_KQ_DEPTKQ>(datastring);
            model.STAFFID = STAFFID;
            HR_KQ_DEPTKQ_SELECT result = hrmodels.KQ_DEPTKQ.SELECT(model, LB, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        public string EXPOST_DEPTKQ(string datastring)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_KQ_DEPTKQ model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_KQ_DEPTKQ>(datastring);
            model.STAFFID = STAFFID;
            HR_KQ_DEPTKQ_SELECT result = hrmodels.KQ_DEPTKQ.SELECT(model, 1, token);
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
                string tt = "部门,工号,姓名,日期,上班时间,下班时间,工作时间,日期标记,加班小时,备注";
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
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["DEPTNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["GH"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["YGNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["KQRQ"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["KQSBTIME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["KQXBTIME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["WORKTIME"].ToString());
                    int RQBJ = Convert.ToInt32(dtinfo.Rows[i]["RQBJ"].ToString());
                    if (RQBJ == 0)
                    {
                        row.CreateCell(cellIndex++).SetCellValue("正常");
                    }
                    else if (RQBJ == 1)
                    {
                        row.CreateCell(cellIndex++).SetCellValue("加班");
                    }
                    else if (RQBJ == 2)
                    {
                        row.CreateCell(cellIndex++).SetCellValue("节假日");
                    }
                    else
                    {
                        row.CreateCell(cellIndex++).SetCellValue("调休");
                    }
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["JIABHOUR"].ToString()));
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

        [HttpPost]
        public string js_worktime(string ks, string js, int FREETIME)
        {
            DateTime dt1 = Convert.ToDateTime(ks.Substring(0, 16));
            dt1 = dt1.AddMinutes(FREETIME);
            DateTime dt2 = Convert.ToDateTime(js.Substring(0, 16));
            TimeSpan dt3 = dt2 - dt1;
            //return dt3.Hours.ToString("00") + ":" + dt3.Minutes.ToString("00") + ":" + dt3.Seconds.ToString("00");
            return dt3.Hours.ToString("00") + ":" + dt3.Minutes.ToString("00");
        }
        [HttpPost]
        public string KQ_PBFZ_INSERT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_KQ_PBFZ model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_KQ_PBFZ>(datastring);
            model.CJR = STAFFID;
            MES_RETURN_UI result = hrmodels.KQ_PBFZ.INSERT(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        public string KQ_PBFZ_UPDATE(string datastring, int LB)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_KQ_PBFZ model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_KQ_PBFZ>(datastring);
            model.XGR = STAFFID;
            MES_RETURN_UI result = hrmodels.KQ_PBFZ.UPDATE(model, LB, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        public string KQ_PBFZ_SELECT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_KQ_PBFZ model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_KQ_PBFZ>(datastring);
            HR_KQ_PBFZ_SELECT result = hrmodels.KQ_PBFZ.SELECT(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        public string KQ_PBFZ_BZID_INSERT(string datastring)
        {
            MES_RETURN_UI result = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            HR_KQ_PBFZ_BZID[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_KQ_PBFZ_BZID[]>(datastring);
            if (model.Length > 0)
            {
                HR_KQ_PBFZ_BZID model_HR_KQ_PBFZ_BZID = new HR_KQ_PBFZ_BZID();
                model_HR_KQ_PBFZ_BZID.FZID = model[0].FZID;
                result = hrmodels.KQ_PBFZ_BZID.UPDATE(model_HR_KQ_PBFZ_BZID, 1, token);
                if (result.TYPE == "E")
                {
                    return Newtonsoft.Json.JsonConvert.SerializeObject(result);
                }
            }
            for (int a = 0; a < model.Length; a++)
            {
                result = hrmodels.KQ_PBFZ_BZID.INSERT(model[a], token);
                if (result.TYPE == "E")
                {
                    return Newtonsoft.Json.JsonConvert.SerializeObject(result);
                }
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        public string KQ_PBFZ_BZID_UPDATE(string datastring, int LB)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_KQ_PBFZ_BZID model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_KQ_PBFZ_BZID>(datastring);
            MES_RETURN_UI result = hrmodels.KQ_PBFZ_BZID.UPDATE(model, LB, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        public string KQ_PBFZ_BZID_SELECT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_KQ_PBFZ_BZID model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_KQ_PBFZ_BZID>(datastring);
            HR_KQ_PBFZ_BZID_SELECT result = hrmodels.KQ_PBFZ_BZID.SELECT(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        public string KQ_DEPTID_FZID_UPDATE(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_KQ_DEPTID_FZID model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_KQ_DEPTID_FZID>(datastring);
            MES_RETURN_UI result = hrmodels.KQ_DEPTID_FZID.UPDATE(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        public string KQ_DEPTID_FZID_SELECT(string datastring, int LB)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_KQ_DEPTID_FZID model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_KQ_DEPTID_FZID>(datastring);
            HR_KQ_DEPTID_FZID_SELECT result = hrmodels.KQ_DEPTID_FZID.SELECT(model, LB, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        public string KQ_BZ_SELECT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_KQ_BZ model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_KQ_BZ>(datastring);
            HR_KQ_BZ_SELECT result = hrmodels.KQ_BZ.SELECT(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        public string KQ_BZ_INSERT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_KQ_BZ model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_KQ_BZ>(datastring);
            model.CJR = STAFFID;
            MES_RETURN_UI result = hrmodels.KQ_BZ.INSERT(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        public string KQ_BZ_UPDATE(string datastring, int LB)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_KQ_BZ model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_KQ_BZ>(datastring);
            model.XGR = STAFFID;
            MES_RETURN_UI result = hrmodels.KQ_BZ.UPDATE(model, LB, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        public string KQ_BZ_BDID_INSERT(string datastring)
        {
            MES_RETURN_UI result = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            HR_KQ_BZ_BDID[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_KQ_BZ_BDID[]>(datastring);
            if (model.Length > 0)
            {
                HR_KQ_BZ_BDID model_HR_KQ_BZ_BDID = new HR_KQ_BZ_BDID();
                model_HR_KQ_BZ_BDID.BZID = model[0].BZID;
                result = hrmodels.KQ_BZ_BDID.UPDATE(model_HR_KQ_BZ_BDID, 1, token);
                if (result.TYPE == "E")
                {
                    return Newtonsoft.Json.JsonConvert.SerializeObject(result);
                }
            }
            else
            {
                result.TYPE = "S";
            }
            for (int a = 0; a < model.Length; a++)
            {
                result = hrmodels.KQ_BZ_BDID.INSERT(model[a], token);
                if (result.TYPE == "E")
                {
                    return Newtonsoft.Json.JsonConvert.SerializeObject(result);
                }
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        public string KQ_BZ_BDID_SELECT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_KQ_BZ_BDID model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_KQ_BZ_BDID>(datastring);
            HR_KQ_BZ_BDID_SELECT result = hrmodels.KQ_BZ_BDID.SELECT(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        public string KQ_RYID_BZID_UPDATE(string datastring, int LB)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_KQ_RYID_BZID model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_KQ_RYID_BZID>(datastring);
            MES_RETURN_UI result = hrmodels.KQ_RYID_BZID.UPDATE(model, LB, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        public string KQ_RYID_BZID_SELECT(string datastring, int LB)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_KQ_RYID_BZID model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_KQ_RYID_BZID>(datastring);
            HR_KQ_RYID_BZID_SELECT result = hrmodels.KQ_RYID_BZID.SELECT(model, LB, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        public string KQ_WCDJ_SELECT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_KQ_WCDJ model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_KQ_WCDJ>(datastring);
            HR_KQ_WCDJ_SELECT result = hrmodels.KQ_WCDJ.SELECT(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        public string KQ_WCDJ_INSERT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_KQ_WCDJ model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_KQ_WCDJ>(datastring);
            model.CJR = STAFFID;
            MES_RETURN_UI result = hrmodels.KQ_WCDJ.INSERT(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        public string KQ_WCDJ_UPDATE(string datastring, int LB)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_KQ_WCDJ model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_KQ_WCDJ>(datastring);
            model.XGR = STAFFID;
            MES_RETURN_UI result = hrmodels.KQ_WCDJ.UPDATE(model, LB, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        public string EXPOST_WCDJ(string datastring, int LB)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_KQ_WCDJ model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_KQ_WCDJ>(datastring);
            HR_KQ_WCDJ_SELECT result = hrmodels.KQ_WCDJ.SELECT(model, token);
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
                string tt = "工号,姓名,公司,部门,外出日期,外出时间,返回时间,事由";
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
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["DEPTNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["WCRQ"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["WCTIME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["BACKTIME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["WCSY"].ToString());
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
        public string KQ_GSKQ_SELECT(string datastring, int LB)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_KQ_GSKQ model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_KQ_GSKQ>(datastring);
            model.STAFFID = STAFFID;
            HR_KQ_GSKQ_SELECT result = hrmodels.KQ_GSKQ.SELECT(model, LB, token);
            //if (result.MES_RETURN.TYPE == "S")
            //{
            //    result.DATALIST.DefaultView.Sort = "KQRQ,KQSBTIME ASC";
            //    result.DATALIST = result.DATALIST.DefaultView.ToTable();
            //}
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        public string EXPOST_GSKQ(string datastring, int LB)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_KQ_GSKQ model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_KQ_GSKQ>(datastring);
            model.STAFFID = STAFFID;
            HR_KQ_GSKQ_SELECT result = hrmodels.KQ_GSKQ.SELECT(model, LB, token);
            //if (result.MES_RETURN.TYPE == "S")
            //{
            //    result.DATALIST.DefaultView.Sort = "KQRQ,KQSBTIME ASC";
            //    result.DATALIST = result.DATALIST.DefaultView.ToTable();
            //}
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
                string tt = "归属部门,工号,姓名,日期,上班时间,下班时间,工作时间,是否外出,外出次数";
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
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["DEPTNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["GH"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["YGNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["KQRQ"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["KQSBTIME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["KQXBTIME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["WORKTIME"].ToString());
                    if (Convert.ToInt32(dtinfo.Rows[i]["WCCOUNT"].ToString()) > 0)
                    {
                        row.CreateCell(cellIndex++).SetCellValue("是");
                    }
                    else
                    {
                        row.CreateCell(cellIndex++).SetCellValue("否");
                    }
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToInt32(dtinfo.Rows[i]["WCCOUNT"].ToString()));
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
        public string KQ_KQINFO_SELECT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            HR_KQ_KQINFO model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_KQ_KQINFO>(datastring);
            HR_KQ_KQINFO_SELECT result = hrmodels.KQ_KQINFO.SELECT(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        public string EXPOST_KQ_KQINFO(string datastring)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_KQ_KQINFO model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_KQ_KQINFO>(datastring);
            HR_KQ_KQINFO_SELECT result = hrmodels.KQ_KQINFO.SELECT(model, token);
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
                string tt = "人员编号,姓名,部门,考勤时间,设备序列号";
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
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["Badgenumber"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["Name"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["DeptName"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["Checktime"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["Sn_name"].ToString());
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
        public string KQ_YCKQ_SELECT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_KQ_YCKQ model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_KQ_YCKQ>(datastring);
            model.STAFFID = STAFFID;
            HR_KQ_YCKQ_SELECT result = hrmodels.KQ_YCKQ.SELECT(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        public string EXPOST_YCKQ(string datastring)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_KQ_YCKQ model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_KQ_YCKQ>(datastring);
            model.STAFFID = STAFFID;
            HR_KQ_YCKQ_SELECT result = hrmodels.KQ_YCKQ.SELECT(model, token);
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
                string tt = "工号,姓名,公司,归属部门,异常考勤时间";
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
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["KQTIME"].ToString());
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
        public string KQ_QJ_SELECT(string datastring, int LB)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_KQ_QJ model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_KQ_QJ>(datastring);
            model.STAFFID = STAFFID;
            HR_KQ_QJ_SELECT result = hrmodels.KQ_QJ.SELECT(model, LB, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        public string KQ_QJ_INSERT(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_KQ_QJ model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_KQ_QJ>(datastring);
            model.CJR = STAFFID;
            MES_RETURN_UI result = hrmodels.KQ_QJ.INSERT(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        public string KQ_QJ_UPDATE(string datastring, int LB)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_KQ_QJ model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_KQ_QJ>(datastring);
            model.XGR = STAFFID;
            MES_RETURN_UI result = hrmodels.KQ_QJ.UPDATE(model, LB, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        public string KQ_QJ_TIMEJS(string KSDATE, string JSDATE)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            DateTime dtime1 = Convert.ToDateTime(KSDATE);
            DateTime dtime2 = Convert.ToDateTime(JSDATE);
            TimeSpan dtimes = dtime2 - dtime1;
            int daycountall = dtimes.Days + 1;
            //if (DAYCOUNT != "")
            //{
            //    double daycount2 = Convert.ToDouble(DAYCOUNT);
            //    if (daycountall - daycount2 <= 0.5 && daycountall - daycount2 >= 0)
            //    {
            //        if ((daycount2 * 10) % 5 != 0)
            //        {
            //            rst.TYPE = "E";
            //            rst.MESSAGE = "日期天数需要为0.5的倍数！";
            //            rst.BH = daycountall.ToString();
            //        }
            //        else
            //        {
            //            rst.TYPE = "S";
            //            rst.MESSAGE = DAYCOUNT;
            //        }
            //    }
            //    else
            //    {
            //        rst.TYPE = "E";
            //        rst.MESSAGE = "日期天数与起始日期结束日期不相符！";
            //        rst.BH = daycountall.ToString();
            //    }
            //}
            //else
            //{
            //    rst.TYPE = "S";
            //    rst.MESSAGE = daycountall.ToString();
            //}

            return Newtonsoft.Json.JsonConvert.SerializeObject(daycountall);
        }

        [HttpPost]
        public string EXPOST_QJINFO(string datastring, int LB)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_KQ_QJ model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_KQ_QJ>(datastring);
            model.STAFFID = STAFFID;
            HR_KQ_QJ_SELECT result = hrmodels.KQ_QJ.SELECT(model, LB, token);
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
                string tt = "公司,归属部门,工号,姓名,假别,天数,开始日期,结束日期";
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
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["GSBMNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["GH"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["YGNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["QJLBNAME"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(dtinfo.Rows[i]["DAYCOUNT"].ToString()));
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["KSDATE"].ToString());
                    row.CreateCell(cellIndex++).SetCellValue(dtinfo.Rows[i]["JSDATE"].ToString());
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

        public ActionResult EXPORT_MBLOAD_QJINFO()
        {
            string token = AppClass.GetSession("token").ToString();
            MES_RETURN_UI rst = new MES_RETURN_UI();
            byte[] arrFile = null;
            try
            {
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/导出模版.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 0;
                string tt = "工号,姓名,假别,天数,开始日期,结束日期";
                string[] ttlist = tt.Split(',');
                IRow rowtt = sheet.CreateRow(rowcount++);
                int cellIndex = 0;
                for (int a = 0; a < ttlist.Length; a++)
                {
                    rowtt.CreateCell(cellIndex++).SetCellValue(ttlist[a]);
                }
                string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                FileStream file1 = new FileStream(string.Format(@"{0}/Areas/HR/ExportFile/{1}.xls", Server.MapPath("~"), now), FileMode.Create);
                workbook.Write(file1);
                file1.Close();
                string path = string.Format(@"{0}/Areas/HR/ExportFile/{1}.xls", Server.MapPath("~"), now);
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    arrFile = new byte[fs.Length];
                    fs.Read(arrFile, 0, arrFile.Length);
                }
                System.IO.File.Delete(path);
                rst.TYPE = "S";
                rst.MESSAGE = now;
            }
            catch
            {
                rst.TYPE = "E";
                rst.MESSAGE = "生成文件失败！";
            }
            return File(arrFile, "application/vnd.ms-excel", "假情录入导入模板.xlsx");
        }

        [HttpPost]
        public string Data_DaoRu_QJINFO()
        {
            MES_RETURN_UI msg = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
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
                    DataTable data1 = ExcelToDataTable(savePath, 0, true);
                    try
                    {
                        System.IO.File.Delete(savePath);
                    }
                    catch (Exception)
                    {
                        //throw;
                    }
                    if (data1 != null)
                    {
                        if (data1.Columns.Contains("工号") == false || data1.Columns.Contains("姓名") == false || data1.Columns.Contains("假别") == false || data1.Columns.Contains("天数") == false || data1.Columns.Contains("开始日期") == false || data1.Columns.Contains("结束日期") == false)
                        {
                            msg.TYPE = "E";
                            msg.MESSAGE = "请使用新增模版！";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                        try
                        {
                            if (data1.Rows.Count > 0)
                            {
                                data1.Columns.Add("RYID", typeof(int));
                                data1.Columns.Add("QJLBID", typeof(int));
                                for (int i = 0; i < data1.Rows.Count; i++)
                                {
                                    if (data1.Rows[i]["工号"].ToString().Trim() != "")
                                    {
                                        if (data1.Rows[i]["工号"].ToString().Length != 5)
                                        {
                                            msg.TYPE = "E";
                                            msg.MESSAGE = "模板第" + (i + 2) + "行工号格式不正确！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (data1.Rows[i]["姓名"].ToString().Trim() == "")
                                        {
                                            msg.TYPE = "E";
                                            msg.MESSAGE = "模板第" + (i + 2) + "行姓名格为空！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        HR_RY_RYINFO model = new HR_RY_RYINFO();
                                        model.GH = data1.Rows[i]["工号"].ToString();
                                        model.YGNAME = data1.Rows[i]["姓名"].ToString().Trim();
                                        HR_RY_RYINFO_SELECT staffdata = hrmodels.RY_RYINFO.SELECT(model, token);
                                        if (staffdata.HR_RY_RYINFO_LIST.Length == 0)
                                        {
                                            msg.TYPE = "E";
                                            msg.MESSAGE = "模板第" + (i + 2) + "行工号姓名不存在！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        else
                                        {
                                            data1.Rows[i]["RYID"] = staffdata.HR_RY_RYINFO_LIST[0].RYID;
                                        }
                                        if (data1.Rows[i]["假别"].ToString().Trim() == "")
                                        {
                                            msg.TYPE = "E";
                                            msg.MESSAGE = "模板第" + (i + 2) + "行假别为空！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        else
                                        {
                                            HR_SY_TYPEMX model_HR_SY_TYPEMX = new HR_SY_TYPEMX();
                                            model_HR_SY_TYPEMX.TYPEID = 46;
                                            model_HR_SY_TYPEMX.MXNAME = data1.Rows[i]["假别"].ToString().Trim();
                                            HR_SY_TYPEMX_SELECT rst_HR_SY_TYPEMX_SELECT = hrmodels.SY_TYPEMX.SELECT(model_HR_SY_TYPEMX, token);
                                            if (rst_HR_SY_TYPEMX_SELECT.MES_RETURN.TYPE == "E")
                                            {
                                                rst_HR_SY_TYPEMX_SELECT.MES_RETURN.MESSAGE = "模板第" + (i + 2) + "行" + rst_HR_SY_TYPEMX_SELECT.MES_RETURN.MESSAGE;
                                                return Newtonsoft.Json.JsonConvert.SerializeObject(rst_HR_SY_TYPEMX_SELECT.MES_RETURN);
                                            }
                                            else
                                            {
                                                if (rst_HR_SY_TYPEMX_SELECT.HR_SY_TYPEMX.Length == 0)
                                                {
                                                    msg.TYPE = "E";
                                                    msg.MESSAGE = "模板第" + (i + 2) + "行假别不存在，请检查！";
                                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                                }
                                                else
                                                {
                                                    data1.Rows[i]["QJLBID"] = rst_HR_SY_TYPEMX_SELECT.HR_SY_TYPEMX[0].ID;
                                                }
                                            }
                                        }
                                        if (data1.Rows[i]["开始日期"].ToString().Trim() == "")
                                        {
                                            msg.TYPE = "E";
                                            msg.MESSAGE = "模板第" + (i + 2) + "行开始日期为空！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        else
                                        {
                                            if (data1.Rows[i]["开始日期"].ToString().Trim().Length != 10)
                                            {
                                                msg.TYPE = "E";
                                                msg.MESSAGE = "模板第" + (i + 2) + "行开始日期存在问题！";
                                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                            }
                                            else
                                            {
                                                try
                                                {
                                                    Convert.ToDateTime(data1.Rows[i]["开始日期"].ToString().Trim());
                                                }
                                                catch (Exception)
                                                {
                                                    msg.TYPE = "E";
                                                    msg.MESSAGE = "模板第" + (i + 2) + "行开始日期存在问题！";
                                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                                }
                                            }
                                        }
                                        if (data1.Rows[i]["结束日期"].ToString().Trim() == "")
                                        {
                                            msg.TYPE = "E";
                                            msg.MESSAGE = "模板第" + (i + 2) + "行结束日期为空！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        else
                                        {
                                            if (data1.Rows[i]["结束日期"].ToString().Trim().Length != 10)
                                            {
                                                msg.TYPE = "E";
                                                msg.MESSAGE = "模板第" + (i + 2) + "行结束日期存在问题！";
                                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                            }
                                            else
                                            {
                                                try
                                                {
                                                    Convert.ToDateTime(data1.Rows[i]["结束日期"].ToString().Trim());
                                                }
                                                catch (Exception)
                                                {
                                                    msg.TYPE = "E";
                                                    msg.MESSAGE = "模板第" + (i + 2) + "行结束日期存在问题！";
                                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                                }
                                                DateTime dtime1 = Convert.ToDateTime(data1.Rows[i]["开始日期"].ToString().Trim());
                                                DateTime dtime2 = Convert.ToDateTime(data1.Rows[i]["结束日期"].ToString().Trim());
                                                if (dtime1 > dtime2)
                                                {
                                                    msg.TYPE = "E";
                                                    msg.MESSAGE = "模板第" + (i + 2) + "行开始日期需要大于结束日期！";
                                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                                }
                                                if (data1.Rows[i]["开始日期"].ToString().Trim().Substring(0, 7) != data1.Rows[i]["结束日期"].ToString().Trim().Substring(0, 7))
                                                {
                                                    msg.TYPE = "E";
                                                    msg.MESSAGE = "模板第" + (i + 2) + "行开始日期与结束日期需要在同一个月！";
                                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                                }
                                            }
                                        }
                                        if (data1.Rows[i]["天数"].ToString().Trim() == "")
                                        {
                                            msg.TYPE = "E";
                                            msg.MESSAGE = "模板第" + (i + 2) + "行天数为空！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        else
                                        {
                                            try
                                            {
                                                Convert.ToDouble(data1.Rows[i]["天数"].ToString().Trim());
                                            }
                                            catch (Exception)
                                            {
                                                msg.TYPE = "E";
                                                msg.MESSAGE = "模板第" + (i + 2) + "行天数存在问题！";
                                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                            }
                                            double daycount = Convert.ToDouble(data1.Rows[i]["天数"].ToString().Trim());
                                            DateTime dtime1 = Convert.ToDateTime(data1.Rows[i]["开始日期"].ToString().Trim());
                                            DateTime dtime2 = Convert.ToDateTime(data1.Rows[i]["结束日期"].ToString().Trim());
                                            TimeSpan dtimes = dtime2 - dtime1;
                                            int daycountall = dtimes.Days + 1;
                                            //if (daycountall - daycount <= 0.5 && daycountall - daycount >= 0)
                                            //{
                                            if ((daycount * 10) % 5 != 0)
                                            {
                                                msg.TYPE = "E";
                                                msg.MESSAGE = "模板第" + (i + 2) + "行日期天数需要为0.5的倍数！";
                                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                            }
                                            //}
                                            //else
                                            //{
                                            //    msg.TYPE = "E";
                                            //    msg.MESSAGE = "模板第" + (i + 2) + "行日期天数与起始日期结束日期不相符！";
                                            //    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                            //}
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
                    for (int i = 0; i < data1.Rows.Count; i++)
                    {
                        if (data1.Rows[i]["工号"].ToString().Trim() != "")
                        {
                            HR_KQ_QJ model_HR_KQ_QJ = new HR_KQ_QJ();
                            model_HR_KQ_QJ.RYID = Convert.ToInt32(data1.Rows[i]["RYID"].ToString().Trim());
                            model_HR_KQ_QJ.KSDATE = data1.Rows[i]["开始日期"].ToString().Trim();
                            model_HR_KQ_QJ.JSDATE = data1.Rows[i]["结束日期"].ToString().Trim();
                            HR_KQ_QJ_SELECT rst_HR_KQ_QJ_SELECT = hrmodels.KQ_QJ.SELECT(model_HR_KQ_QJ, 2, token);
                            if (rst_HR_KQ_QJ_SELECT.MES_RETURN.TYPE == "E")
                            {
                                rst_HR_KQ_QJ_SELECT.MES_RETURN.MESSAGE = "模板第" + (i + 2) + "行" + rst_HR_KQ_QJ_SELECT.MES_RETURN.MESSAGE;
                                return Newtonsoft.Json.JsonConvert.SerializeObject(rst_HR_KQ_QJ_SELECT.MES_RETURN);
                            }
                            else
                            {
                                if (Convert.ToInt32(rst_HR_KQ_QJ_SELECT.DATALIST.Rows[0][0].ToString()) > 0)
                                {
                                    msg.TYPE = "E";
                                    msg.MESSAGE = "模板第" + (i + 2) + "行存在冲突记录，请检查！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                            }
                        }
                    }
                    for (int i = 0; i < data1.Rows.Count; i++)
                    {
                        if (data1.Rows[i]["工号"].ToString().Trim() != "")
                        {
                            HR_KQ_QJ model_HR_KQ_QJ = new HR_KQ_QJ();
                            model_HR_KQ_QJ.RYID = Convert.ToInt32(data1.Rows[i]["RYID"].ToString().Trim());
                            model_HR_KQ_QJ.QJLBID = Convert.ToInt32(data1.Rows[i]["QJLBID"].ToString().Trim());
                            model_HR_KQ_QJ.DAYCOUNT = Convert.ToDecimal(data1.Rows[i]["天数"].ToString().Trim());
                            model_HR_KQ_QJ.KSDATE = data1.Rows[i]["开始日期"].ToString().Trim();
                            model_HR_KQ_QJ.JSDATE = data1.Rows[i]["结束日期"].ToString().Trim();
                            model_HR_KQ_QJ.CJR = STAFFID;
                            msg = hrmodels.KQ_QJ.INSERT(model_HR_KQ_QJ, token);
                            if (msg.TYPE == "E")
                            {
                                msg.MESSAGE = "模板第" + (i + 2) + "行" + msg.MESSAGE;
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
        public string EXPOST_QJINFO_REPORT(string KQMONTH, int DEPTID)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            HR_KQ_QJ model = new HR_KQ_QJ();
            model.KQMONTH = KQMONTH;
            model.DEPTID = DEPTID;
            HR_KQ_QJ_SELECT result = hrmodels.KQ_QJ.SELECT(model, 3, token);
            if (result.MES_RETURN.TYPE == "E")
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(result.MES_RETURN);
            }
            HR_SY_DEPT model_HR_SY_DEPT = new HR_SY_DEPT();
            model_HR_SY_DEPT.DEPTID = DEPTID;
            HR_SY_DEPT_SELECT rst_HR_SY_DEPT_SELECT = hrmodels.SY_DEPT.SELECT(model_HR_SY_DEPT, token);
            if (rst_HR_SY_DEPT_SELECT.MES_RETURN.TYPE == "E")
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(rst_HR_SY_DEPT_SELECT.MES_RETURN);
            }
            if (rst_HR_SY_DEPT_SELECT.HR_SY_DEPT_LIST.Length == 0)
            {
                rst.TYPE = "E";
                rst.MESSAGE = "无部门数据请检查！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
            }
            try
            {
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/导出模版.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                sheet.FitToPage = false;
                workbook.RemoveSheetAt(0);
                int limitcount = 32;
                string YGTYPENAME = "";
                int rowcount = 0;
                int countfg = 0;
                int lzcount = 0;
                int allcount = 0;
                ICellStyle style = workbook.CreateCellStyle();
                style.BorderBottom = BorderStyle.Thin;
                style.BorderLeft = BorderStyle.Thin;
                style.BorderRight = BorderStyle.Thin;
                style.BorderTop = BorderStyle.Thin;
                style.VerticalAlignment = VerticalAlignment.Center;
                style.Alignment = HorizontalAlignment.Center;


                ICellStyle style1 = workbook.CreateCellStyle();
                IFont font = workbook.CreateFont();
                font.FontHeightInPoints = 16;
                font.FontName = "宋体";
                style1.SetFont(font);

                ICellStyle style2 = workbook.CreateCellStyle();
                style2.VerticalAlignment = VerticalAlignment.Center;
                style2.Alignment = HorizontalAlignment.Center;

                int cellcount = 0;
                if (result.DATALIST.Rows.Count > 0)
                {
                    DataRow dr = result.DATALIST.NewRow();
                    for (int a = 0; a < result.DATALIST.Rows.Count; a++)
                    {
                        if (YGTYPENAME == "")
                        {
                            workbook.CreateSheet(result.DATALIST.Rows[a]["YGTYPENAME"].ToString());
                            sheet = workbook.GetSheet(result.DATALIST.Rows[a]["YGTYPENAME"].ToString());
                            sheet.FitToPage = false;
                            sheet.PrintSetup.Landscape = true;
                            sheet.PrintSetup.PaperSize = 9;
                            sheet.SetMargin(MarginType.LeftMargin, (double)0.5);
                            sheet.SetMargin(MarginType.RightMargin, (double)0.5);
                            sheet.SetMargin(MarginType.BottomMargin, (double)0.5);
                            sheet.SetMargin(MarginType.TopMargin, (double)0.5);
                            cellcount = 0;
                            sheet.SetColumnWidth(cellcount++, 7 * 256);
                            sheet.SetColumnWidth(cellcount++, 7 * 256);
                            sheet.SetColumnWidth(cellcount++, 6 * 256);
                            sheet.SetColumnWidth(cellcount++, 9 * 256);
                            sheet.SetColumnWidth(cellcount++, 9 * 256);
                            sheet.SetColumnWidth(cellcount++, 6 * 256);
                            sheet.SetColumnWidth(cellcount++, 6 * 256);
                            sheet.SetColumnWidth(cellcount++, 6 * 256);
                            sheet.SetColumnWidth(cellcount++, 6 * 256);
                            sheet.SetColumnWidth(cellcount++, 6 * 256);
                            sheet.SetColumnWidth(cellcount++, 6 * 256);
                            sheet.SetColumnWidth(cellcount++, 6 * 256);
                            sheet.SetColumnWidth(cellcount++, 6 * 256);
                            sheet.SetColumnWidth(cellcount++, 6 * 256);
                            sheet.SetColumnWidth(cellcount++, 6 * 256);
                            sheet.SetColumnWidth(cellcount++, 6 * 256);
                            sheet.SetColumnWidth(cellcount++, 13 * 256);
                            sheet.SetColumnWidth(cellcount++, 5 * 256);
                            sheet.SetColumnWidth(cellcount++, 16 * 256);
                            YGTYPENAME = result.DATALIST.Rows[a]["YGTYPENAME"].ToString();
                            rowcount = 0;
                            IRow row = sheet.CreateRow(rowcount++);
                            //row.CreateCell(4).SetCellValue("中银(宁波)电池有限公司");
                            row.CreateCell(4).SetCellValue(result.DATALIST.Rows[a]["GSNAME"].ToString());
                            row.GetCell(4).CellStyle = style1;
                            row.CreateCell(10).SetCellValue("员工出勤统计表(" + result.DATALIST.Rows[a]["YGTYPENAME"].ToString() + "）");
                            row.GetCell(10).CellStyle = style1;
                            row = sheet.CreateRow(rowcount++);
                            //row.CreateCell(0).SetCellValue("归属部门：" + result.DATALIST.Rows[a]["GSBMNAME"].ToString());
                            row.CreateCell(0).SetCellValue("归属部门：" + rst_HR_SY_DEPT_SELECT.HR_SY_DEPT_LIST[0].DEPTNAME);
                            row.CreateCell(16).SetCellValue(DateTime.Now.ToString("yyyy") + "年" + DateTime.Now.ToString("MM") + "月" + DateTime.Now.ToString("dd") + "日");
                            sheet.AddMergedRegion(new CellRangeAddress(rowcount, rowcount + 1, 0, 0));
                            sheet.AddMergedRegion(new CellRangeAddress(rowcount, rowcount + 1, 1, 1));
                            sheet.AddMergedRegion(new CellRangeAddress(rowcount, rowcount + 1, 2, 2));
                            sheet.AddMergedRegion(new CellRangeAddress(rowcount, rowcount + 1, 3, 3));
                            sheet.AddMergedRegion(new CellRangeAddress(rowcount, rowcount + 1, 4, 4));
                            sheet.AddMergedRegion(new CellRangeAddress(rowcount, rowcount, 5, 15));
                            sheet.AddMergedRegion(new CellRangeAddress(rowcount, rowcount, 16, 17));
                            sheet.AddMergedRegion(new CellRangeAddress(rowcount, rowcount + 1, 18, 18));
                            row = sheet.CreateRow(rowcount++);
                            for (int b = 0; b < 19; b++)
                            {
                                row.CreateCell(b).SetCellValue("");
                            }
                            row.CreateCell(0).SetCellValue("工号");
                            row.CreateCell(1).SetCellValue("姓名");
                            row.CreateCell(2).SetCellValue("性别");
                            row.CreateCell(3).SetCellValue("出勤天数");
                            row.CreateCell(4).SetCellValue("加班天数");
                            row.CreateCell(5).SetCellValue("假别");
                            row.CreateCell(16).SetCellValue("借调部门");
                            row.CreateCell(18).SetCellValue("备注");
                            for (int b = 0; b < 19; b++)
                            {
                                row.GetCell(b).CellStyle = style;
                            }
                            row = sheet.CreateRow(rowcount++);
                            for (int b = 0; b < 19; b++)
                            {
                                row.CreateCell(b).SetCellValue("");
                            }
                            row.CreateCell(5).SetCellValue("病");
                            row.CreateCell(6).SetCellValue("事");
                            row.CreateCell(7).SetCellValue("产");
                            row.CreateCell(8).SetCellValue("婚");
                            row.CreateCell(9).SetCellValue("丧");
                            row.CreateCell(10).SetCellValue("工伤");
                            row.CreateCell(11).SetCellValue("哺乳");
                            row.CreateCell(12).SetCellValue("年休");
                            row.CreateCell(13).SetCellValue("护理");
                            row.CreateCell(14).SetCellValue("公差");
                            row.CreateCell(15).SetCellValue("旷");
                            row.CreateCell(16).SetCellValue("部门");
                            row.CreateCell(17).SetCellValue("天数");
                            for (int b = 0; b < 19; b++)
                            {
                                row.GetCell(b).CellStyle = style;
                            }
                        }
                        else if (YGTYPENAME != result.DATALIST.Rows[a]["YGTYPENAME"].ToString())
                        {
                            if (countfg < limitcount)
                            {
                                countfg = countfg + 1;
                            }
                            else
                            {
                                sheet.SetRowBreak(rowcount - 1);
                                countfg = 1;
                                IRow row1 = sheet.CreateRow(rowcount++);
                                row1.CreateCell(4).SetCellValue(result.DATALIST.Rows[a]["GSNAME"].ToString());
                                row1.GetCell(4).CellStyle = style1;
                                row1.CreateCell(10).SetCellValue("员工出勤统计表(" + result.DATALIST.Rows[a]["YGTYPENAME"].ToString() + "）");
                                row1.GetCell(10).CellStyle = style1;
                                row1 = sheet.CreateRow(rowcount++);
                                row1.CreateCell(0).SetCellValue("归属部门：" + rst_HR_SY_DEPT_SELECT.HR_SY_DEPT_LIST[0].DEPTNAME);
                                row1.CreateCell(16).SetCellValue(DateTime.Now.ToString("yyyy") + "年" + DateTime.Now.ToString("MM") + "月" + DateTime.Now.ToString("dd") + "日");
                                sheet.AddMergedRegion(new CellRangeAddress(rowcount, rowcount + 1, 0, 0));
                                sheet.AddMergedRegion(new CellRangeAddress(rowcount, rowcount + 1, 1, 1));
                                sheet.AddMergedRegion(new CellRangeAddress(rowcount, rowcount + 1, 2, 2));
                                sheet.AddMergedRegion(new CellRangeAddress(rowcount, rowcount + 1, 3, 3));
                                sheet.AddMergedRegion(new CellRangeAddress(rowcount, rowcount + 1, 4, 4));
                                sheet.AddMergedRegion(new CellRangeAddress(rowcount, rowcount, 5, 15));
                                sheet.AddMergedRegion(new CellRangeAddress(rowcount, rowcount, 16, 17));
                                sheet.AddMergedRegion(new CellRangeAddress(rowcount, rowcount + 1, 18, 18));
                                row1 = sheet.CreateRow(rowcount++);
                                for (int b = 0; b < 19; b++)
                                {
                                    row1.CreateCell(b).SetCellValue("");
                                }
                                row1.CreateCell(0).SetCellValue("工号");
                                row1.CreateCell(1).SetCellValue("姓名");
                                row1.CreateCell(2).SetCellValue("性别");
                                row1.CreateCell(3).SetCellValue("出勤天数");
                                row1.CreateCell(4).SetCellValue("加班天数");
                                row1.CreateCell(5).SetCellValue("假别");
                                row1.CreateCell(16).SetCellValue("借调部门");
                                row1.CreateCell(18).SetCellValue("备注");
                                for (int b = 0; b < 19; b++)
                                {
                                    row1.GetCell(b).CellStyle = style;
                                }
                                row1 = sheet.CreateRow(rowcount++);
                                for (int b = 0; b < 19; b++)
                                {
                                    row1.CreateCell(b).SetCellValue("");
                                }
                                row1.CreateCell(5).SetCellValue("病");
                                row1.CreateCell(6).SetCellValue("事");
                                row1.CreateCell(7).SetCellValue("产");
                                row1.CreateCell(8).SetCellValue("婚");
                                row1.CreateCell(9).SetCellValue("丧");
                                row1.CreateCell(10).SetCellValue("工伤");
                                row1.CreateCell(11).SetCellValue("哺乳");
                                row1.CreateCell(12).SetCellValue("年休");
                                row1.CreateCell(13).SetCellValue("护理");
                                row1.CreateCell(14).SetCellValue("公差");
                                row1.CreateCell(15).SetCellValue("旷");
                                row1.CreateCell(16).SetCellValue("部门");
                                row1.CreateCell(17).SetCellValue("天数");
                                for (int b = 0; b < 19; b++)
                                {
                                    row1.GetCell(b).CellStyle = style;
                                }
                            }

                            IRow rowhj = sheet.CreateRow(rowcount++);
                            cellcount = 0;
                            rowhj.CreateCell(0).SetCellValue("合计天数：");
                            if (dr["CHUQCOUNT"].ToString() != "")
                            {
                                rowhj.CreateCell(3).SetCellValue(Convert.ToDouble(dr["CHUQCOUNT"].ToString()));
                            }
                            else
                            {
                                rowhj.CreateCell(3).SetCellValue(0);
                            }
                            if (dr["JIABCOUNT"].ToString() != "")
                            {
                                rowhj.CreateCell(4).SetCellValue(Convert.ToDouble(dr["JIABCOUNT"].ToString()));
                            }
                            else
                            {
                                rowhj.CreateCell(4).SetCellValue(0);
                            }
                            if (dr["BINGJCOUNT"].ToString() != "")
                            {
                                rowhj.CreateCell(5).SetCellValue(Convert.ToDouble(dr["BINGJCOUNT"].ToString()));
                            }
                            else
                            {
                                rowhj.CreateCell(5).SetCellValue(0);
                            }
                            if (dr["SHIJCOUNT"].ToString() != "")
                            {
                                rowhj.CreateCell(6).SetCellValue(Convert.ToDouble(dr["SHIJCOUNT"].ToString()));
                            }
                            else
                            {
                                rowhj.CreateCell(6).SetCellValue(0);
                            }
                            if (dr["CHANJCOUNT"].ToString() != "")
                            {
                                rowhj.CreateCell(7).SetCellValue(Convert.ToDouble(dr["CHANJCOUNT"].ToString()));
                            }
                            else
                            {
                                rowhj.CreateCell(7).SetCellValue(0);
                            }
                            if (dr["HUNJCOUNT"].ToString() != "")
                            {
                                rowhj.CreateCell(8).SetCellValue(Convert.ToDouble(dr["HUNJCOUNT"].ToString()));
                            }
                            else
                            {
                                rowhj.CreateCell(8).SetCellValue(0);
                            }
                            if (dr["SANGJCOUNT"].ToString() != "")
                            {
                                rowhj.CreateCell(9).SetCellValue(Convert.ToDouble(dr["SANGJCOUNT"].ToString()));
                            }
                            else
                            {
                                rowhj.CreateCell(9).SetCellValue(0);
                            }
                            if (dr["GONGSJCOUNT"].ToString() != "")
                            {
                                rowhj.CreateCell(10).SetCellValue(Convert.ToDouble(dr["GONGSJCOUNT"].ToString()));
                            }
                            else
                            {
                                rowhj.CreateCell(10).SetCellValue(0);
                            }
                            if (dr["BURJCOUNT"].ToString() != "")
                            {
                                rowhj.CreateCell(11).SetCellValue(Convert.ToDouble(dr["BURJCOUNT"].ToString()));
                            }
                            else
                            {
                                rowhj.CreateCell(11).SetCellValue(0);
                            }
                            if (dr["NIANXJCOUNT"].ToString() != "")
                            {
                                rowhj.CreateCell(12).SetCellValue(Convert.ToDouble(dr["NIANXJCOUNT"].ToString()));
                            }
                            else
                            {
                                rowhj.CreateCell(12).SetCellValue(0);
                            }
                            if (dr["HULIJCOUNT"].ToString() != "")
                            {
                                rowhj.CreateCell(13).SetCellValue(Convert.ToDouble(dr["HULIJCOUNT"].ToString()));
                            }
                            else
                            {
                                rowhj.CreateCell(13).SetCellValue(0);
                            }
                            if (dr["GONGCJCOUNT"].ToString() != "")
                            {
                                rowhj.CreateCell(14).SetCellValue(Convert.ToDouble(dr["GONGCJCOUNT"].ToString()));
                            }
                            else
                            {
                                rowhj.CreateCell(14).SetCellValue(0);
                            }
                            if (dr["KUANGGCOUNT"].ToString() != "")
                            {
                                rowhj.CreateCell(15).SetCellValue(Convert.ToDouble(dr["KUANGGCOUNT"].ToString()));
                            }
                            else
                            {
                                rowhj.CreateCell(15).SetCellValue(0);
                            }
                            for (int b = 3; b < 16; b++)
                            {
                                rowhj.GetCell(b).CellStyle = style2;
                            }
                            rowhj = sheet.CreateRow(rowcount++);
                            rowhj.CreateCell(0).SetCellValue("合计人数： " + allcount + "人，离职 " + lzcount + "人");
                            rowhj = sheet.CreateRow(rowcount++);
                            rowhj = sheet.CreateRow(rowcount++);
                            rowhj.CreateCell(0).SetCellValue("考勤员：");
                            rowhj.CreateCell(10).SetCellValue("核对：");
                            dr = result.DATALIST.NewRow();
                            lzcount = 0;
                            allcount = 0;

                            workbook.CreateSheet(result.DATALIST.Rows[a]["YGTYPENAME"].ToString());
                            sheet = workbook.GetSheet(result.DATALIST.Rows[a]["YGTYPENAME"].ToString());
                            countfg = 0;
                            sheet.FitToPage = false;
                            sheet.PrintSetup.Landscape = true;
                            sheet.PrintSetup.PaperSize = 9;
                            sheet.SetMargin(MarginType.LeftMargin, (double)0.5);
                            sheet.SetMargin(MarginType.RightMargin, (double)0.5);
                            sheet.SetMargin(MarginType.BottomMargin, (double)0.5);
                            sheet.SetMargin(MarginType.TopMargin, (double)0.5);
                            cellcount = 0;
                            sheet.SetColumnWidth(cellcount++, 7 * 256);
                            sheet.SetColumnWidth(cellcount++, 7 * 256);
                            sheet.SetColumnWidth(cellcount++, 6 * 256);
                            sheet.SetColumnWidth(cellcount++, 9 * 256);
                            sheet.SetColumnWidth(cellcount++, 9 * 256);
                            sheet.SetColumnWidth(cellcount++, 6 * 256);
                            sheet.SetColumnWidth(cellcount++, 6 * 256);
                            sheet.SetColumnWidth(cellcount++, 6 * 256);
                            sheet.SetColumnWidth(cellcount++, 6 * 256);
                            sheet.SetColumnWidth(cellcount++, 6 * 256);
                            sheet.SetColumnWidth(cellcount++, 6 * 256);
                            sheet.SetColumnWidth(cellcount++, 6 * 256);
                            sheet.SetColumnWidth(cellcount++, 6 * 256);
                            sheet.SetColumnWidth(cellcount++, 6 * 256);
                            sheet.SetColumnWidth(cellcount++, 6 * 256);
                            sheet.SetColumnWidth(cellcount++, 6 * 256);
                            sheet.SetColumnWidth(cellcount++, 13 * 256);
                            sheet.SetColumnWidth(cellcount++, 5 * 256);
                            sheet.SetColumnWidth(cellcount++, 16 * 256);
                            YGTYPENAME = result.DATALIST.Rows[a]["YGTYPENAME"].ToString();
                            rowcount = 0;
                            IRow row = sheet.CreateRow(rowcount++);
                            row.CreateCell(4).SetCellValue(result.DATALIST.Rows[a]["GSNAME"].ToString());
                            row.GetCell(4).CellStyle = style1;
                            row.CreateCell(10).SetCellValue("员工出勤统计表(" + result.DATALIST.Rows[a]["YGTYPENAME"].ToString() + "）");
                            row.GetCell(10).CellStyle = style1;
                            row = sheet.CreateRow(rowcount++);
                            row.CreateCell(0).SetCellValue("归属部门：" + rst_HR_SY_DEPT_SELECT.HR_SY_DEPT_LIST[0].DEPTNAME);
                            row.CreateCell(16).SetCellValue(DateTime.Now.ToString("yyyy") + "年" + DateTime.Now.ToString("MM") + "月" + DateTime.Now.ToString("dd") + "日");
                            sheet.AddMergedRegion(new CellRangeAddress(rowcount, rowcount + 1, 0, 0));
                            sheet.AddMergedRegion(new CellRangeAddress(rowcount, rowcount + 1, 1, 1));
                            sheet.AddMergedRegion(new CellRangeAddress(rowcount, rowcount + 1, 2, 2));
                            sheet.AddMergedRegion(new CellRangeAddress(rowcount, rowcount + 1, 3, 3));
                            sheet.AddMergedRegion(new CellRangeAddress(rowcount, rowcount + 1, 4, 4));
                            sheet.AddMergedRegion(new CellRangeAddress(rowcount, rowcount, 5, 15));
                            sheet.AddMergedRegion(new CellRangeAddress(rowcount, rowcount, 16, 17));
                            sheet.AddMergedRegion(new CellRangeAddress(rowcount, rowcount + 1, 18, 18));
                            row = sheet.CreateRow(rowcount++);
                            for (int b = 0; b < 18; b++)
                            {
                                row.CreateCell(b).SetCellValue("");
                            }
                            row.CreateCell(0).SetCellValue("工号");
                            row.CreateCell(1).SetCellValue("姓名");
                            row.CreateCell(2).SetCellValue("性别");
                            row.CreateCell(3).SetCellValue("出勤天数");
                            row.CreateCell(4).SetCellValue("加班天数");
                            row.CreateCell(5).SetCellValue("假别");
                            row.CreateCell(16).SetCellValue("借调部门");
                            row.CreateCell(18).SetCellValue("备注");
                            for (int b = 0; b < 19; b++)
                            {
                                row.GetCell(b).CellStyle = style;
                            }
                            row = sheet.CreateRow(rowcount++);
                            for (int b = 0; b < 19; b++)
                            {
                                row.CreateCell(b).SetCellValue("");
                            }
                            row.CreateCell(5).SetCellValue("病");
                            row.CreateCell(6).SetCellValue("事");
                            row.CreateCell(7).SetCellValue("产");
                            row.CreateCell(8).SetCellValue("婚");
                            row.CreateCell(9).SetCellValue("丧");
                            row.CreateCell(10).SetCellValue("工伤");
                            row.CreateCell(11).SetCellValue("哺乳");
                            row.CreateCell(12).SetCellValue("年休");
                            row.CreateCell(13).SetCellValue("护理");
                            row.CreateCell(14).SetCellValue("公差");
                            row.CreateCell(15).SetCellValue("旷");
                            row.CreateCell(16).SetCellValue("部门");
                            row.CreateCell(17).SetCellValue("天数");
                            for (int b = 0; b < 19; b++)
                            {
                                row.GetCell(b).CellStyle = style;
                            }
                        }
                        if (countfg < limitcount)
                        {
                            countfg = countfg + 1;
                        }
                        else
                        {
                            sheet.SetRowBreak(rowcount - 1);
                            countfg = 1;
                            IRow row = sheet.CreateRow(rowcount++);
                            row.CreateCell(4).SetCellValue(result.DATALIST.Rows[a]["GSNAME"].ToString());
                            row.GetCell(4).CellStyle = style1;
                            row.CreateCell(10).SetCellValue("员工出勤统计表(" + result.DATALIST.Rows[a]["YGTYPENAME"].ToString() + "）");
                            row.GetCell(10).CellStyle = style1;
                            row = sheet.CreateRow(rowcount++);
                            row.CreateCell(0).SetCellValue("归属部门：" + rst_HR_SY_DEPT_SELECT.HR_SY_DEPT_LIST[0].DEPTNAME);
                            row.CreateCell(16).SetCellValue(DateTime.Now.ToString("yyyy") + "年" + DateTime.Now.ToString("MM") + "月" + DateTime.Now.ToString("dd") + "日");
                            sheet.AddMergedRegion(new CellRangeAddress(rowcount, rowcount + 1, 0, 0));
                            sheet.AddMergedRegion(new CellRangeAddress(rowcount, rowcount + 1, 1, 1));
                            sheet.AddMergedRegion(new CellRangeAddress(rowcount, rowcount + 1, 2, 2));
                            sheet.AddMergedRegion(new CellRangeAddress(rowcount, rowcount + 1, 3, 3));
                            sheet.AddMergedRegion(new CellRangeAddress(rowcount, rowcount + 1, 4, 4));
                            sheet.AddMergedRegion(new CellRangeAddress(rowcount, rowcount, 5, 15));
                            sheet.AddMergedRegion(new CellRangeAddress(rowcount, rowcount, 16, 17));
                            sheet.AddMergedRegion(new CellRangeAddress(rowcount, rowcount + 1, 18, 18));
                            row = sheet.CreateRow(rowcount++);
                            for (int b = 0; b < 19; b++)
                            {
                                row.CreateCell(b).SetCellValue("");
                            }
                            row.CreateCell(0).SetCellValue("工号");
                            row.CreateCell(1).SetCellValue("姓名");
                            row.CreateCell(2).SetCellValue("性别");
                            row.CreateCell(3).SetCellValue("出勤天数");
                            row.CreateCell(4).SetCellValue("加班天数");
                            row.CreateCell(5).SetCellValue("假别");
                            row.CreateCell(16).SetCellValue("借调部门");
                            row.CreateCell(18).SetCellValue("备注");
                            for (int b = 0; b < 19; b++)
                            {
                                row.GetCell(b).CellStyle = style;
                            }
                            row = sheet.CreateRow(rowcount++);
                            for (int b = 0; b < 19; b++)
                            {
                                row.CreateCell(b).SetCellValue("");
                            }
                            row.CreateCell(5).SetCellValue("病");
                            row.CreateCell(6).SetCellValue("事");
                            row.CreateCell(7).SetCellValue("产");
                            row.CreateCell(8).SetCellValue("婚");
                            row.CreateCell(9).SetCellValue("丧");
                            row.CreateCell(10).SetCellValue("工伤");
                            row.CreateCell(11).SetCellValue("哺乳");
                            row.CreateCell(12).SetCellValue("年休");
                            row.CreateCell(13).SetCellValue("护理");
                            row.CreateCell(14).SetCellValue("公差");
                            row.CreateCell(15).SetCellValue("旷");
                            row.CreateCell(16).SetCellValue("部门");
                            row.CreateCell(17).SetCellValue("天数");
                            for (int b = 0; b < 19; b++)
                            {
                                row.GetCell(b).CellStyle = style;
                            }
                        }
                        IRow rowh = sheet.CreateRow(rowcount++);
                        for (int b = 0; b < 19; b++)
                        {
                            rowh.CreateCell(b).SetCellValue("");
                            rowh.GetCell(b).CellStyle = style;
                        }
                        cellcount = 0;
                        rowh.CreateCell(cellcount++).SetCellValue(result.DATALIST.Rows[a]["GH"].ToString());
                        rowh.CreateCell(cellcount++).SetCellValue(result.DATALIST.Rows[a]["YGNAME"].ToString());
                        rowh.CreateCell(cellcount++).SetCellValue(result.DATALIST.Rows[a]["XB"].ToString());
                        rowh.CreateCell(cellcount++).SetCellValue(Convert.ToDouble(result.DATALIST.Rows[a]["CHUQCOUNT"].ToString()));
                        if (dr["CHUQCOUNT"].ToString() == "")
                        {
                            dr["CHUQCOUNT"] = Convert.ToDecimal(result.DATALIST.Rows[a]["CHUQCOUNT"].ToString());
                        }
                        else
                        {
                            dr["CHUQCOUNT"] = Convert.ToDecimal(dr["CHUQCOUNT"].ToString()) + Convert.ToDecimal(result.DATALIST.Rows[a]["CHUQCOUNT"].ToString());
                        }
                        rowh.CreateCell(cellcount++).SetCellValue(Convert.ToDouble(result.DATALIST.Rows[a]["JIABCOUNT"].ToString()));
                        if (dr["JIABCOUNT"].ToString() == "")
                        {
                            dr["JIABCOUNT"] = Convert.ToDecimal(result.DATALIST.Rows[a]["JIABCOUNT"].ToString());
                        }
                        else
                        {
                            dr["JIABCOUNT"] = Convert.ToDecimal(dr["JIABCOUNT"].ToString()) + Convert.ToDecimal(result.DATALIST.Rows[a]["JIABCOUNT"].ToString());
                        }

                        if (Convert.ToDecimal(result.DATALIST.Rows[a]["BINGJCOUNT"].ToString().Trim()) > 0)
                        {
                            rowh.CreateCell(cellcount++).SetCellValue(Convert.ToDouble(result.DATALIST.Rows[a]["BINGJCOUNT"].ToString()));
                            if (dr["BINGJCOUNT"].ToString() == "")
                            {
                                dr["BINGJCOUNT"] = Convert.ToDecimal(result.DATALIST.Rows[a]["BINGJCOUNT"].ToString());
                            }
                            else
                            {
                                dr["BINGJCOUNT"] = Convert.ToDecimal(dr["BINGJCOUNT"].ToString()) + Convert.ToDecimal(result.DATALIST.Rows[a]["BINGJCOUNT"].ToString());
                            }
                        }
                        else
                        {
                            cellcount++;
                        }

                        if (Convert.ToDecimal(result.DATALIST.Rows[a]["SHIJCOUNT"].ToString().Trim()) > 0)
                        {
                            rowh.CreateCell(cellcount++).SetCellValue(Convert.ToDouble(result.DATALIST.Rows[a]["SHIJCOUNT"].ToString()));
                            if (dr["SHIJCOUNT"].ToString() == "")
                            {
                                dr["SHIJCOUNT"] = Convert.ToDecimal(result.DATALIST.Rows[a]["SHIJCOUNT"].ToString());
                            }
                            else
                            {
                                dr["SHIJCOUNT"] = Convert.ToDecimal(dr["SHIJCOUNT"].ToString()) + Convert.ToDecimal(result.DATALIST.Rows[a]["SHIJCOUNT"].ToString());
                            }
                        }
                        else
                        {
                            cellcount++;
                        }

                        if (Convert.ToDecimal(result.DATALIST.Rows[a]["CHANJCOUNT"].ToString().Trim()) > 0)
                        {
                            rowh.CreateCell(cellcount++).SetCellValue(Convert.ToDouble(result.DATALIST.Rows[a]["CHANJCOUNT"].ToString()));
                            if (dr["CHANJCOUNT"].ToString() == "")
                            {
                                dr["CHANJCOUNT"] = Convert.ToDecimal(result.DATALIST.Rows[a]["CHANJCOUNT"].ToString());
                            }
                            else
                            {
                                dr["CHANJCOUNT"] = Convert.ToDecimal(dr["CHANJCOUNT"].ToString()) + Convert.ToDecimal(result.DATALIST.Rows[a]["CHANJCOUNT"].ToString());
                            }
                        }
                        else
                        {
                            cellcount++;
                        }

                        if (Convert.ToDecimal(result.DATALIST.Rows[a]["HUNJCOUNT"].ToString().Trim()) > 0)
                        {
                            rowh.CreateCell(cellcount++).SetCellValue(Convert.ToDouble(result.DATALIST.Rows[a]["HUNJCOUNT"].ToString()));
                            if (dr["HUNJCOUNT"].ToString() == "")
                            {
                                dr["HUNJCOUNT"] = Convert.ToDecimal(result.DATALIST.Rows[a]["HUNJCOUNT"].ToString());
                            }
                            else
                            {
                                dr["HUNJCOUNT"] = Convert.ToDecimal(dr["HUNJCOUNT"].ToString()) + Convert.ToDecimal(result.DATALIST.Rows[a]["HUNJCOUNT"].ToString());
                            }
                        }
                        else
                        {
                            cellcount++;
                        }

                        if (Convert.ToDecimal(result.DATALIST.Rows[a]["SANGJCOUNT"].ToString().Trim()) > 0)
                        {
                            rowh.CreateCell(cellcount++).SetCellValue(Convert.ToDouble(result.DATALIST.Rows[a]["SANGJCOUNT"].ToString()));
                            if (dr["SANGJCOUNT"].ToString() == "")
                            {
                                dr["SANGJCOUNT"] = Convert.ToDecimal(result.DATALIST.Rows[a]["SANGJCOUNT"].ToString());
                            }
                            else
                            {
                                dr["SANGJCOUNT"] = Convert.ToDecimal(dr["SANGJCOUNT"].ToString()) + Convert.ToDecimal(result.DATALIST.Rows[a]["SANGJCOUNT"].ToString());
                            }
                        }
                        else
                        {
                            cellcount++;
                        }

                        if (Convert.ToDecimal(result.DATALIST.Rows[a]["GONGSJCOUNT"].ToString().Trim()) > 0)
                        {
                            rowh.CreateCell(cellcount++).SetCellValue(Convert.ToDouble(result.DATALIST.Rows[a]["GONGSJCOUNT"].ToString()));
                            if (dr["GONGSJCOUNT"].ToString() == "")
                            {
                                dr["GONGSJCOUNT"] = Convert.ToDecimal(result.DATALIST.Rows[a]["GONGSJCOUNT"].ToString());
                            }
                            else
                            {
                                dr["GONGSJCOUNT"] = Convert.ToDecimal(dr["GONGSJCOUNT"].ToString()) + Convert.ToDecimal(result.DATALIST.Rows[a]["GONGSJCOUNT"].ToString());
                            }
                        }
                        else
                        {
                            cellcount++;
                        }

                        if (Convert.ToDecimal(result.DATALIST.Rows[a]["BURJCOUNT"].ToString().Trim()) > 0)
                        {
                            rowh.CreateCell(cellcount++).SetCellValue(Convert.ToDouble(result.DATALIST.Rows[a]["BURJCOUNT"].ToString()));
                            if (dr["BURJCOUNT"].ToString() == "")
                            {
                                dr["BURJCOUNT"] = Convert.ToDecimal(result.DATALIST.Rows[a]["BURJCOUNT"].ToString());
                            }
                            else
                            {
                                dr["BURJCOUNT"] = Convert.ToDecimal(dr["BURJCOUNT"].ToString()) + Convert.ToDecimal(result.DATALIST.Rows[a]["BURJCOUNT"].ToString());
                            }
                        }
                        else
                        {
                            cellcount++;
                        }

                        if (Convert.ToDecimal(result.DATALIST.Rows[a]["NIANXJCOUNT"].ToString().Trim()) > 0)
                        {
                            rowh.CreateCell(cellcount++).SetCellValue(Convert.ToDouble(result.DATALIST.Rows[a]["NIANXJCOUNT"].ToString()));
                            if (dr["NIANXJCOUNT"].ToString() == "")
                            {
                                dr["NIANXJCOUNT"] = Convert.ToDecimal(result.DATALIST.Rows[a]["NIANXJCOUNT"].ToString());
                            }
                            else
                            {
                                dr["NIANXJCOUNT"] = Convert.ToDecimal(dr["NIANXJCOUNT"].ToString()) + Convert.ToDecimal(result.DATALIST.Rows[a]["NIANXJCOUNT"].ToString());
                            }
                        }
                        else
                        {
                            cellcount++;
                        }

                        if (Convert.ToDecimal(result.DATALIST.Rows[a]["HULIJCOUNT"].ToString().Trim()) > 0)
                        {
                            rowh.CreateCell(cellcount++).SetCellValue(Convert.ToDouble(result.DATALIST.Rows[a]["HULIJCOUNT"].ToString()));
                            if (dr["HULIJCOUNT"].ToString() == "")
                            {
                                dr["HULIJCOUNT"] = Convert.ToDecimal(result.DATALIST.Rows[a]["HULIJCOUNT"].ToString());
                            }
                            else
                            {
                                dr["HULIJCOUNT"] = Convert.ToDecimal(dr["HULIJCOUNT"].ToString()) + Convert.ToDecimal(result.DATALIST.Rows[a]["HULIJCOUNT"].ToString());
                            }
                        }
                        else
                        {
                            cellcount++;
                        }

                        if (Convert.ToDecimal(result.DATALIST.Rows[a]["GONGCJCOUNT"].ToString().Trim()) > 0)
                        {
                            rowh.CreateCell(cellcount++).SetCellValue(Convert.ToDouble(result.DATALIST.Rows[a]["GONGCJCOUNT"].ToString()));
                            if (dr["GONGCJCOUNT"].ToString() == "")
                            {
                                dr["GONGCJCOUNT"] = Convert.ToDecimal(result.DATALIST.Rows[a]["GONGCJCOUNT"].ToString());
                            }
                            else
                            {
                                dr["GONGCJCOUNT"] = Convert.ToDecimal(dr["GONGCJCOUNT"].ToString()) + Convert.ToDecimal(result.DATALIST.Rows[a]["GONGCJCOUNT"].ToString());
                            }
                        }
                        else
                        {
                            cellcount++;
                        }

                        if (Convert.ToDecimal(result.DATALIST.Rows[a]["KUANGGCOUNT"].ToString().Trim()) > 0)
                        {
                            rowh.CreateCell(cellcount++).SetCellValue(Convert.ToDouble(result.DATALIST.Rows[a]["KUANGGCOUNT"].ToString()));
                            if (dr["KUANGGCOUNT"].ToString() == "")
                            {
                                dr["KUANGGCOUNT"] = Convert.ToDecimal(result.DATALIST.Rows[a]["KUANGGCOUNT"].ToString());
                            }
                            else
                            {
                                dr["KUANGGCOUNT"] = Convert.ToDecimal(dr["KUANGGCOUNT"].ToString()) + Convert.ToDecimal(result.DATALIST.Rows[a]["KUANGGCOUNT"].ToString());
                            }
                        }
                        else
                        {
                            cellcount++;
                        }

                        if (result.DATALIST.Rows[a]["LZRQ"].ToString().Trim() == "")
                        {
                            rowh.CreateCell(18).SetCellValue(result.DATALIST.Rows[a]["LZRQ"].ToString());
                        }
                        else
                        {
                            rowh.CreateCell(18).SetCellValue(result.DATALIST.Rows[a]["LZRQ"].ToString() + " 离职");
                        }

                        if (result.DATALIST.Rows[a]["LZRQ"].ToString() != "")
                        {
                            lzcount = lzcount + 1;
                        }
                        allcount = allcount + 1;
                        for (int b = 0; b < 19; b++)
                        {
                            rowh.GetCell(b).CellStyle = style;
                        }
                    }
                    if (countfg < limitcount)
                    {
                        countfg = countfg + 1;
                    }
                    else
                    {
                        sheet.SetRowBreak(rowcount - 1);
                        countfg = 0;
                        IRow row = sheet.CreateRow(rowcount++);
                        row.CreateCell(4).SetCellValue(result.DATALIST.Rows[result.DATALIST.Rows.Count - 1]["GSNAME"].ToString());
                        row.GetCell(4).CellStyle = style1;
                        row.CreateCell(10).SetCellValue("员工出勤统计表(" + result.DATALIST.Rows[result.DATALIST.Rows.Count - 1]["YGTYPENAME"].ToString() + "）");
                        row.GetCell(10).CellStyle = style1;
                        row = sheet.CreateRow(rowcount++);
                        row.CreateCell(0).SetCellValue("归属部门：" + rst_HR_SY_DEPT_SELECT.HR_SY_DEPT_LIST[0].DEPTNAME);
                        row.CreateCell(16).SetCellValue(DateTime.Now.ToString("yyyy") + "年" + DateTime.Now.ToString("MM") + "月" + DateTime.Now.ToString("dd") + "日");
                        sheet.AddMergedRegion(new CellRangeAddress(rowcount, rowcount + 1, 0, 0));
                        sheet.AddMergedRegion(new CellRangeAddress(rowcount, rowcount + 1, 1, 1));
                        sheet.AddMergedRegion(new CellRangeAddress(rowcount, rowcount + 1, 2, 2));
                        sheet.AddMergedRegion(new CellRangeAddress(rowcount, rowcount + 1, 3, 3));
                        sheet.AddMergedRegion(new CellRangeAddress(rowcount, rowcount + 1, 4, 4));
                        sheet.AddMergedRegion(new CellRangeAddress(rowcount, rowcount, 5, 15));
                        sheet.AddMergedRegion(new CellRangeAddress(rowcount, rowcount, 16, 17));
                        sheet.AddMergedRegion(new CellRangeAddress(rowcount, rowcount + 1, 18, 18));
                        row = sheet.CreateRow(rowcount++);
                        for (int b = 0; b < 19; b++)
                        {
                            row.CreateCell(b).SetCellValue("");
                        }
                        row.CreateCell(0).SetCellValue("工号");
                        row.CreateCell(1).SetCellValue("姓名");
                        row.CreateCell(2).SetCellValue("性别");
                        row.CreateCell(3).SetCellValue("出勤天数");
                        row.CreateCell(4).SetCellValue("加班天数");
                        row.CreateCell(5).SetCellValue("假别");
                        row.CreateCell(16).SetCellValue("借调部门");
                        row.CreateCell(18).SetCellValue("备注");
                        for (int b = 0; b < 19; b++)
                        {
                            row.GetCell(b).CellStyle = style;
                        }
                        row = sheet.CreateRow(rowcount++);
                        for (int b = 0; b < 19; b++)
                        {
                            row.CreateCell(b).SetCellValue("");
                        }
                        row.CreateCell(5).SetCellValue("病");
                        row.CreateCell(6).SetCellValue("事");
                        row.CreateCell(7).SetCellValue("产");
                        row.CreateCell(8).SetCellValue("婚");
                        row.CreateCell(9).SetCellValue("丧");
                        row.CreateCell(10).SetCellValue("工伤");
                        row.CreateCell(11).SetCellValue("哺乳");
                        row.CreateCell(12).SetCellValue("年休");
                        row.CreateCell(13).SetCellValue("护理");
                        row.CreateCell(14).SetCellValue("公差");
                        row.CreateCell(15).SetCellValue("旷");
                        row.CreateCell(16).SetCellValue("部门");
                        row.CreateCell(17).SetCellValue("天数");
                        for (int b = 0; b < 19; b++)
                        {
                            row.GetCell(b).CellStyle = style;
                        }
                    }
                    IRow rowhj2 = sheet.CreateRow(rowcount++);
                    cellcount = 0;
                    rowhj2.CreateCell(0).SetCellValue("合计天数：");
                    if (dr["CHUQCOUNT"].ToString() != "")
                    {
                        rowhj2.CreateCell(3).SetCellValue(Convert.ToDouble(dr["CHUQCOUNT"].ToString()));
                    }
                    else
                    {
                        rowhj2.CreateCell(3).SetCellValue(0);
                    }
                    if (dr["JIABCOUNT"].ToString() != "")
                    {
                        rowhj2.CreateCell(4).SetCellValue(Convert.ToDouble(dr["JIABCOUNT"].ToString()));
                    }
                    else
                    {
                        rowhj2.CreateCell(4).SetCellValue(0);
                    }
                    if (dr["BINGJCOUNT"].ToString() != "")
                    {
                        rowhj2.CreateCell(5).SetCellValue(Convert.ToDouble(dr["BINGJCOUNT"].ToString()));
                    }
                    else
                    {
                        rowhj2.CreateCell(5).SetCellValue(0);
                    }
                    if (dr["SHIJCOUNT"].ToString() != "")
                    {
                        rowhj2.CreateCell(6).SetCellValue(Convert.ToDouble(dr["SHIJCOUNT"].ToString()));
                    }
                    else
                    {
                        rowhj2.CreateCell(6).SetCellValue(0);
                    }
                    if (dr["CHANJCOUNT"].ToString() != "")
                    {
                        rowhj2.CreateCell(7).SetCellValue(Convert.ToDouble(dr["CHANJCOUNT"].ToString()));
                    }
                    else
                    {
                        rowhj2.CreateCell(7).SetCellValue(0);
                    }
                    if (dr["HUNJCOUNT"].ToString() != "")
                    {
                        rowhj2.CreateCell(8).SetCellValue(Convert.ToDouble(dr["HUNJCOUNT"].ToString()));
                    }
                    else
                    {
                        rowhj2.CreateCell(8).SetCellValue(0);
                    }
                    if (dr["SANGJCOUNT"].ToString() != "")
                    {
                        rowhj2.CreateCell(9).SetCellValue(Convert.ToDouble(dr["SANGJCOUNT"].ToString()));
                    }
                    else
                    {
                        rowhj2.CreateCell(9).SetCellValue(0);
                    }
                    if (dr["GONGSJCOUNT"].ToString() != "")
                    {
                        rowhj2.CreateCell(10).SetCellValue(Convert.ToDouble(dr["GONGSJCOUNT"].ToString()));
                    }
                    else
                    {
                        rowhj2.CreateCell(10).SetCellValue(0);
                    }
                    if (dr["BURJCOUNT"].ToString() != "")
                    {
                        rowhj2.CreateCell(11).SetCellValue(Convert.ToDouble(dr["BURJCOUNT"].ToString()));
                    }
                    else
                    {
                        rowhj2.CreateCell(11).SetCellValue(0);
                    }
                    if (dr["NIANXJCOUNT"].ToString() != "")
                    {
                        rowhj2.CreateCell(12).SetCellValue(Convert.ToDouble(dr["NIANXJCOUNT"].ToString()));
                    }
                    else
                    {
                        rowhj2.CreateCell(12).SetCellValue(0);
                    }
                    if (dr["HULIJCOUNT"].ToString() != "")
                    {
                        rowhj2.CreateCell(13).SetCellValue(Convert.ToDouble(dr["HULIJCOUNT"].ToString()));
                    }
                    else
                    {
                        rowhj2.CreateCell(13).SetCellValue(0);
                    }
                    if (dr["GONGCJCOUNT"].ToString() != "")
                    {
                        rowhj2.CreateCell(14).SetCellValue(Convert.ToDouble(dr["GONGCJCOUNT"].ToString()));
                    }
                    else
                    {
                        rowhj2.CreateCell(14).SetCellValue(0);
                    }
                    if (dr["KUANGGCOUNT"].ToString() != "")
                    {
                        rowhj2.CreateCell(15).SetCellValue(Convert.ToDouble(dr["KUANGGCOUNT"].ToString()));
                    }
                    else
                    {
                        rowhj2.CreateCell(15).SetCellValue(0);
                    }
                    for (int b = 3; b < 16; b++)
                    {
                        rowhj2.GetCell(b).CellStyle = style2;
                    }
                    rowhj2 = sheet.CreateRow(rowcount++);
                    rowhj2.CreateCell(0).SetCellValue("合计人数： " + allcount + "人，离职 " + lzcount + "人");
                    rowhj2 = sheet.CreateRow(rowcount++);
                    rowhj2 = sheet.CreateRow(rowcount++);
                    rowhj2.CreateCell(0).SetCellValue("考勤员：");
                    rowhj2.CreateCell(10).SetCellValue("核对：");
                    string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                    FileStream file1 = new FileStream(string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), now), FileMode.Create);
                    workbook.Write(file1);
                    file1.Close();
                    rst.TYPE = "S";
                    rst.MESSAGE = now;
                }
                else
                {
                    rst.TYPE = "E";
                    rst.MESSAGE = "无数据！";
                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }

        [HttpPost]
        public string EXPOST_DEPTKQ_REPORT_EJKQB(string GS, int DEPTID, string GH, string KQMONTH, string DEPTNAME, string KQMONTHE)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            string GSNAME = "";
            if (KQMONTHE == "")
            {
                KQMONTHE = KQMONTH;
            }
            DateTime dtimes = Convert.ToDateTime(KQMONTH + "-01");
            DateTime dtimee = Convert.ToDateTime(KQMONTHE + "-01");
            int monthjg = (dtimee.Year - dtimes.Year) * 12 + (dtimee.Month - dtimes.Month);

            HR_KQ_DEPTKQ_SELECT result = new HR_KQ_DEPTKQ_SELECT();
            DataTable dtlist = new DataTable();
            DataTable dt_kqinfo = new DataTable();
            DataTable dt_qjinfo = new DataTable();
            for (int a = 0; a <= monthjg; a++)
            {
                HR_KQ_DEPTKQ model = new HR_KQ_DEPTKQ();
                model.DEPTID = DEPTID.ToString();
                //model.KQMONTH = KQMONTH;
                model.KQMONTH = Convert.ToDateTime(KQMONTH + "-01").AddMonths(a).ToString("yyyy-MM");
                model.STAFFID = STAFFID;
                model.GH = GH;
                HR_KQ_DEPTKQ_SELECT result1 = hrmodels.KQ_DEPTKQ.SELECT(model, 4, token);
                if (result1.MES_RETURN.TYPE == "E")
                {
                    return Newtonsoft.Json.JsonConvert.SerializeObject(result1.MES_RETURN);
                }
                if (a == 0)
                {
                    dtlist = result1.DATALIST.Clone();
                    dtlist.Columns.Add("KQMONTH", typeof(string));
                }
                result1.DATALIST.Columns.Add("KQMONTH", typeof(string));
                for (int b = 0; b < result1.DATALIST.Rows.Count; b++)
                {
                    result1.DATALIST.Rows[b]["KQMONTH"] = Convert.ToDateTime(KQMONTH + "-01").AddMonths(a).ToString("yyyy-MM");
                    dtlist.Rows.Add(result1.DATALIST.Rows[b].ItemArray);
                }
                //if (result1.DATALIST.Rows.Count == 0)
                //{
                //    rst.TYPE = "E";
                //    rst.MESSAGE = "无导出数据";
                //    return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                //}
                HR_KQ_DEPTKQ_SELECT result_KQINFO = hrmodels.KQ_DEPTKQ.SELECT(model, 5, token);
                if (result_KQINFO.MES_RETURN.TYPE == "E")
                {
                    return Newtonsoft.Json.JsonConvert.SerializeObject(result_KQINFO.MES_RETURN);
                }
                if (a == 0)
                {
                    dt_kqinfo = result_KQINFO.DATALIST.Clone();
                }
                for (int b = 0; b < result_KQINFO.DATALIST.Rows.Count; b++)
                {
                    dt_kqinfo.Rows.Add(result_KQINFO.DATALIST.Rows[b].ItemArray);
                }

                HR_KQ_QJ model_HR_KQ_QJ = new HR_KQ_QJ();
                model_HR_KQ_QJ.KQMONTH = KQMONTH;
                model_HR_KQ_QJ.DEPTID = DEPTID;
                HR_KQ_QJ_SELECT rst_HR_KQ_QJ_SELECT = hrmodels.KQ_QJ.SELECT(model_HR_KQ_QJ, 4, token);
                if (rst_HR_KQ_QJ_SELECT.MES_RETURN.TYPE == "E")
                {
                    return Newtonsoft.Json.JsonConvert.SerializeObject(rst_HR_KQ_QJ_SELECT.MES_RETURN);
                }
                if (a == 0)
                {
                    dt_qjinfo = rst_HR_KQ_QJ_SELECT.DATALIST.Clone();
                }
                for (int b = 0; b < rst_HR_KQ_QJ_SELECT.DATALIST.Rows.Count; b++)
                {
                    dt_qjinfo.Rows.Add(rst_HR_KQ_QJ_SELECT.DATALIST.Rows[b].ItemArray);
                }
            }
            DataRow[] drlist = dtlist.Select("", "GH,KQMONTH");
            DataTable dtlist1 = dtlist.Clone();
            for (int a = 0; a < dtlist.Rows.Count; a++)
            {
                dtlist1.Rows.Add(drlist[a].ItemArray);
            }
            result.DATALIST = dtlist1;

            HR_SY_GS model_HR_SY_GS = new HR_SY_GS();
            model_HR_SY_GS.GS = GS;
            HR_SY_GS_SELECT rst_HR_SY_GS_SELECT = hrmodels.SY_GS.SELECT(model_HR_SY_GS, token);
            if (rst_HR_SY_GS_SELECT.MES_RETURN.TYPE == "E")
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(rst_HR_SY_GS_SELECT.MES_RETURN);
            }
            else
            {
                if (rst_HR_SY_GS_SELECT.HR_SY_GS_LIST.Length > 0)
                {
                    GSNAME = rst_HR_SY_GS_SELECT.HR_SY_GS_LIST[0].GSNAME;
                }
                else
                {
                    rst.TYPE = "E";
                    rst.MESSAGE = "公司不存在！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                }
            }
            try
            {
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/导出模版.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                sheet.FitToPage = false;
                sheet.PrintSetup.Landscape = false;
                sheet.PrintSetup.PaperSize = 9;
                sheet.SetMargin(MarginType.LeftMargin, (double)0.2);
                sheet.SetMargin(MarginType.RightMargin, (double)0.2);
                sheet.SetMargin(MarginType.BottomMargin, (double)0.2);
                sheet.SetMargin(MarginType.TopMargin, (double)0.2);
                int cellcount = 0;
                sheet.SetColumnWidth(cellcount++, 7 * 256);
                sheet.SetColumnWidth(cellcount++, 11 * 256);
                sheet.SetColumnWidth(cellcount++, 28 * 256);
                sheet.SetColumnWidth(cellcount++, 11 * 256);
                sheet.SetColumnWidth(cellcount++, 18 * 256);
                sheet.SetColumnWidth(cellcount++, 26 * 256);
                //sheet.SetColumnWidth(cellcount++, 13 * 256);

                ICellStyle style1 = workbook.CreateCellStyle();
                IFont font = workbook.CreateFont();
                font.FontHeightInPoints = 16;
                font.FontName = "宋体";
                style1.SetFont(font);

                ICellStyle style2 = workbook.CreateCellStyle();
                font = workbook.CreateFont();
                font.FontHeightInPoints = 15;
                font.FontName = "宋体";
                style2.SetFont(font);

                ICellStyle style3 = workbook.CreateCellStyle();
                //style.BorderBottom = BorderStyle.Thin;
                //style.BorderLeft = BorderStyle.Thin;
                //style.BorderRight = BorderStyle.Thin;
                //style.BorderTop = BorderStyle.Thin;
                style3.VerticalAlignment = VerticalAlignment.Center;
                style3.Alignment = HorizontalAlignment.Center;
                font = workbook.CreateFont();
                font.FontHeightInPoints = 12;
                font.FontName = "宋体";
                style3.SetFont(font);

                ICellStyle style4 = workbook.CreateCellStyle();
                style4.BorderBottom = BorderStyle.Thin;
                style4.BorderLeft = BorderStyle.Thin;
                style4.BorderRight = BorderStyle.Thin;
                style4.BorderTop = BorderStyle.Thin;
                style4.VerticalAlignment = VerticalAlignment.Center;
                style4.Alignment = HorizontalAlignment.Center;
                font = workbook.CreateFont();
                font.FontHeightInPoints = 12;
                font.FontName = "宋体";
                style4.SetFont(font);

                ICellStyle style5 = workbook.CreateCellStyle();
                style5.BorderBottom = BorderStyle.Thin;
                style5.BorderLeft = BorderStyle.Thin;
                style5.BorderRight = BorderStyle.Thin;
                style5.BorderTop = BorderStyle.Thin;
                style5.VerticalAlignment = VerticalAlignment.Center;
                style5.Alignment = HorizontalAlignment.Left;
                font = workbook.CreateFont();
                font.FontHeightInPoints = 12;
                font.FontName = "宋体";
                style5.SetFont(font);
                style5.WrapText = true;


                int rowcount = 0;
                for (int a = 0; a < result.DATALIST.Rows.Count; a++)
                {
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(1).SetCellValue(GSNAME);
                    row.GetCell(1).CellStyle = style1;
                    row.CreateCell(4).SetCellValue(result.DATALIST.Rows[a]["KQMONTH"].ToString().Substring(0, 4) + "年员工考勤表（A0版）");
                    row.GetCell(4).CellStyle = style2;
                    row = sheet.CreateRow(rowcount++);
                    sheet.AddMergedRegion(new CellRangeAddress(rowcount - 1, rowcount - 1, 0, 5));
                    row.CreateCell(0).SetCellValue("月份：" + result.DATALIST.Rows[a]["KQMONTH"].ToString() + "     部门：" + DEPTNAME + "     工号：" + result.DATALIST.Rows[a]["GH"].ToString() + "     姓名：" + result.DATALIST.Rows[a]["YGNAME"].ToString());
                    row.GetCell(0).CellStyle = style3;
                    row = sheet.CreateRow(rowcount++);
                    //for (int b = 0; b < 7; b++)
                    //{
                    //    row.CreateCell(b).SetCellValue("");
                    //    row.GetCell(b).CellStyle = style4;
                    //}
                    row.CreateCell(0).SetCellValue("日期");
                    row.CreateCell(1).SetCellValue("上班时间");
                    row.CreateCell(2).SetCellValue("就餐时间");
                    row.CreateCell(3).SetCellValue("下班时间");
                    row.CreateCell(4).SetCellValue("加班时间（小时）");
                    //row.CreateCell(5).SetCellValue("本人签名");
                    row.CreateCell(5).SetCellValue("备注");
                    for (int b = 0; b < 6; b++)
                    {
                        row.GetCell(b).CellStyle = style4;
                    }
                    for (int c = 0; c < 31; c++)
                    {
                        row = sheet.CreateRow(rowcount++);
                        row.Height = 18 * 20;
                        DateTime dtime1 = Convert.ToDateTime(result.DATALIST.Rows[a]["KQMONTH"].ToString() + "-01");
                        DateTime dtime2 = dtime1.AddDays(c);
                        if (dtime2.ToString("yyyy-MM") != result.DATALIST.Rows[a]["KQMONTH"].ToString())
                        {
                            row.CreateCell(0).SetCellValue((c + 1).ToString() + "日");
                            row.CreateCell(1).SetCellValue("-");
                            row.CreateCell(2).SetCellValue("-");
                            row.CreateCell(3).SetCellValue("-");
                            row.CreateCell(4).SetCellValue("-");
                            row.CreateCell(5).SetCellValue("");
                        }
                        else
                        {
                            row.CreateCell(0).SetCellValue((c + 1).ToString() + "日");
                            row.CreateCell(1).SetCellValue("X");
                            row.CreateCell(2).SetCellValue("X");
                            row.CreateCell(3).SetCellValue("X");
                            row.CreateCell(4).SetCellValue("X");
                            row.CreateCell(5).SetCellValue("");
                            DateTime dtime_rzrq = Convert.ToDateTime(result.DATALIST.Rows[a]["RZDATE"].ToString());
                            if (dtime2 < dtime_rzrq)
                            {
                                row.CreateCell(1).SetCellValue("");
                                row.CreateCell(2).SetCellValue("");
                                row.CreateCell(3).SetCellValue("");
                                row.CreateCell(4).SetCellValue("");
                                row.CreateCell(5).SetCellValue("");
                            }
                            if (result.DATALIST.Rows[a]["LZRQ"].ToString() != "")
                            {
                                DateTime dtime3 = Convert.ToDateTime(result.DATALIST.Rows[a]["LZRQ"].ToString());
                                if (dtime2 >= dtime3)
                                {
                                    row.CreateCell(1).SetCellValue("辞职");
                                    row.CreateCell(2).SetCellValue("辞职");
                                    row.CreateCell(3).SetCellValue("辞职");
                                    row.CreateCell(4).SetCellValue("辞职");
                                    row.CreateCell(5).SetCellValue("");
                                }
                            }
                            row = report_ejkqb(row, c + 1, dt_kqinfo, result.DATALIST.Rows[a]["GH"].ToString(), result.DATALIST.Rows[a]["KQMONTH"].ToString(), dt_qjinfo);
                        }
                        for (int b = 0; b < 6; b++)
                        {
                            row.GetCell(b).CellStyle = style4;
                        }
                    }

                    row = sheet.CreateRow(rowcount++);
                    row.CreateCell(0).SetCellValue("注：");
                    row.GetCell(0).CellStyle = style4;
                    sheet.AddMergedRegion(new CellRangeAddress(rowcount - 1, rowcount - 1, 1, 5));
                    row.CreateCell(1).SetCellValue("节假日加班时间合计：     " + result.DATALIST.Rows[a]["JIABHOUR3"].ToString() + " 周末加班时间合计：     " + result.DATALIST.Rows[a]["JIABHOUR2"].ToString() + " 工作日加班时间合计：" + result.DATALIST.Rows[a]["JIABHOUR1"].ToString());
                    row.GetCell(1).CellStyle = style4;
                    for (int b = 2; b < 6; b++)
                    {
                        row.CreateCell(b).SetCellValue("");
                    }
                    for (int b = 1; b < 6; b++)
                    {
                        row.GetCell(b).CellStyle = style5;
                    }

                    row = sheet.CreateRow(rowcount++);
                    row.Height = 18 * 20;
                    sheet.AddMergedRegion(new CellRangeAddress(rowcount - 1, rowcount + 2, 0, 0));
                    sheet.AddMergedRegion(new CellRangeAddress(rowcount - 1, rowcount + 2, 1, 4));
                    sheet.AddMergedRegion(new CellRangeAddress(rowcount - 1, rowcount + 2, 5, 5));
                    row.CreateCell(0).SetCellValue("说明");
                    row.GetCell(0).CellStyle = style4;
                    row.CreateCell(1).SetCellValue("1、正常上班记“上班、下班、就餐、加班时间”；休息日记“×”；事假记“S”；病假记“B”；产假记“C”；婚假记“H”；年休假记“N”；工伤记“G”；出差记“A”；诚信服务记“A”；护理假记“L”；丧假记“D”；哺乳假记“R”；旷工记“旷”。");
                    row.CreateCell(5).SetCellValue("本人签字：");
                    for (int b = 2; b < 6; b++)
                    {
                        row.CreateCell(b).SetCellValue("");
                    }
                    row.CreateCell(5).SetCellValue("本人签字：");
                    for (int b = 1; b < 6; b++)
                    {
                        row.GetCell(b).CellStyle = style5;
                    }

                    row = sheet.CreateRow(rowcount++);
                    row.Height = 18 * 20;
                    for (int b = 0; b < 6; b++)
                    {
                        row.CreateCell(b).SetCellValue("");
                    }
                    row.GetCell(0).CellStyle = style4;
                    for (int b = 1; b < 6; b++)
                    {
                        row.GetCell(b).CellStyle = style5;
                    }

                    row = sheet.CreateRow(rowcount++);
                    row.Height = 18 * 20;
                    for (int b = 0; b < 6; b++)
                    {
                        row.CreateCell(b).SetCellValue("");
                    }
                    row.GetCell(0).CellStyle = style4;
                    for (int b = 1; b < 6; b++)
                    {
                        row.GetCell(b).CellStyle = style5;
                    }

                    row = sheet.CreateRow(rowcount++);
                    row.Height = 18 * 20;
                    for (int b = 0; b < 6; b++)
                    {
                        row.CreateCell(b).SetCellValue("");
                    }
                    row.GetCell(0).CellStyle = style4;
                    for (int b = 1; b < 6; b++)
                    {
                        row.GetCell(b).CellStyle = style5;
                    }

                    //row = sheet.CreateRow(rowcount++);
                    //row.Height = 30 * 20;
                    //sheet.AddMergedRegion(new CellRangeAddress(rowcount - 1, rowcount - 1, 1, 6));
                    //for (int b = 0; b < 7; b++)
                    //{
                    //    row.CreateCell(b).SetCellValue("");
                    //}
                    //row.GetCell(0).CellStyle = style4;
                    //row.CreateCell(1).SetCellValue("2、对于有调动变换部门的、有迟到早退现象的或哺乳假期间的，请在备注栏中做记录，且请原部门领导确认签字；");
                    //for (int b = 1; b < 7; b++)
                    //{
                    //    row.GetCell(b).CellStyle = style5;
                    //}

                    //row = sheet.CreateRow(rowcount++);
                    //row.Height = 18 * 20;
                    //sheet.AddMergedRegion(new CellRangeAddress(rowcount - 1, rowcount - 1, 1, 6));
                    //for (int b = 0; b < 7; b++)
                    //{
                    //    row.CreateCell(b).SetCellValue("");
                    //}
                    //row.GetCell(0).CellStyle = style4;
                    //row.CreateCell(1).SetCellValue("3、“本人签名”一栏，签名确认方式为每周签一次；");
                    //for (int b = 1; b < 7; b++)
                    //{
                    //    row.GetCell(b).CellStyle = style5;
                    //}

                    //row = sheet.CreateRow(rowcount++);
                    //row.Height = 18 * 20;
                    //sheet.AddMergedRegion(new CellRangeAddress(rowcount - 1, rowcount - 1, 1, 6));
                    //for (int b = 0; b < 7; b++)
                    //{
                    //    row.CreateCell(b).SetCellValue("");
                    //}
                    //row.GetCell(0).CellStyle = style4;
                    //row.CreateCell(1).SetCellValue("4、本表由部门考勤员统一管理，随人员调动而带离；");
                    //for (int b = 1; b < 7; b++)
                    //{
                    //    row.GetCell(b).CellStyle = style5;
                    //}

                    //row = sheet.CreateRow(rowcount++);
                    //row.Height = 18 * 20;
                    //row.CreateCell(0).SetCellValue("         考勤员:");
                    //row.GetCell(0).CellStyle = style3;

                    sheet.SetRowBreak(rowcount - 1);
                }
                string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                FileStream file1 = new FileStream(string.Format(@"{0}/Areas/HR/ExportFile/{1}.xlsx", Server.MapPath("~"), now), FileMode.Create);
                workbook.Write(file1);
                file1.Close();
                rst.TYPE = "S";
                rst.MESSAGE = now;
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = "生成文件失败！" + e.Message;
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }


        public IRow report_ejkqb(IRow row, int RQ, DataTable kqinfo, string GH, string KQMONTH, DataTable qjinfo)
        {
            string token = AppClass.GetSession("token").ToString();
            string rqDATE = KQMONTH + "-" + RQ.ToString("00");
            DataRow[] dr1 = qjinfo.Select("KSDATE<='" + rqDATE + "' AND JSDATE>='" + rqDATE + "' AND GH='" + GH + "'");
            if (dr1.Length > 0)
            {
                HR_KQ_DEPTKQ model = new HR_KQ_DEPTKQ();
                model.KQRQKS = rqDATE;
                HR_KQ_DEPTKQ_SELECT result = hrmodels.KQ_DEPTKQ.SELECT(model, 6, token);
                if (result.MES_RETURN.TYPE == "S")
                {
                    int isholidday = 0;
                    if (result.DATALIST.Rows.Count > 0)
                    {
                        //if (result.DATALIST.Rows[0]["ISJJR"].ToString() == "1")
                        //{
                        //    isholidday = 1;
                        //}
                        //else
                        //{
                        //    isholidday = 0;
                        //}
                        isholidday = Convert.ToInt32(result.DATALIST.Rows[0]["ISJJR"].ToString());
                    }
                    else
                    {
                        isholidday = 0;
                    }
                    if (isholidday == 0 || isholidday == 2)
                    {
                        int isweekend = Convert.ToInt32(Convert.ToDateTime(rqDATE).DayOfWeek);
                        if ((isweekend != 0 && isweekend != 6) || isholidday == 2)
                        {
                            string bj = "";
                            if (dr1[0]["QJLBID"].ToString() == "229")
                            {
                                bj = "S";
                            }
                            else if (dr1[0]["QJLBID"].ToString() == "228")
                            {
                                bj = "B";
                            }
                            else if (dr1[0]["QJLBID"].ToString() == "230")
                            {
                                bj = "C";
                            }
                            else if (dr1[0]["QJLBID"].ToString() == "231")
                            {
                                bj = "H";
                            }
                            else if (dr1[0]["QJLBID"].ToString() == "226")
                            {
                                bj = "N";
                            }
                            else if (dr1[0]["QJLBID"].ToString() == "233")
                            {
                                bj = "G";
                            }
                            else if (dr1[0]["QJLBID"].ToString() == "227")
                            {
                                bj = "A";
                            }
                            else if (dr1[0]["QJLBID"].ToString() == "236")
                            {
                                bj = "旷";
                            }
                            else if (dr1[0]["QJLBID"].ToString() == "235")
                            {
                                bj = "L";
                            }
                            else if (dr1[0]["QJLBID"].ToString() == "232")
                            {
                                bj = "D";
                            }
                            else if (dr1[0]["QJLBID"].ToString() == "234")
                            {
                                bj = "R";
                            }
                            if (bj != "")
                            {
                                row.CreateCell(1).SetCellValue(bj);
                                row.CreateCell(2).SetCellValue(bj);
                                row.CreateCell(3).SetCellValue(bj);
                                row.CreateCell(4).SetCellValue(bj);
                            }
                        }
                    }
                }
            }
            DataRow[] dr = kqinfo.Select("KQRQ='" + KQMONTH + "-" + RQ.ToString("00") + "' AND GH='" + GH + "'");
            if (dr.Length > 0)
            {
                row.CreateCell(1).SetCellValue(dr[0]["KQSBTIME"].ToString().Substring(11, 5));
                row.CreateCell(2).SetCellValue("休息： " + dr[0]["FREETIME"].ToString() + " 分钟");
                row.CreateCell(3).SetCellValue(dr[0]["KQXBTIME"].ToString().Substring(11, 5));
                row.CreateCell(4).SetCellValue(dr[0]["JIABHOUR"].ToString());
                row.CreateCell(5).SetCellValue(dr[0]["REMARK"].ToString());
            }
            return row;
        }
    }
}
