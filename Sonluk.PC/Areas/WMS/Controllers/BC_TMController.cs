using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using RestSharp;
using Sonluk.API.SDK.Http;
using Sonluk.PC.APPCLASS;
using Sonluk.PC.Models;
using Sonluk.PC.Models.WMS;
using Sonluk.UI.Model.MES.MM_CKService;
using Sonluk.UI.Model.MES.SY_GCService;
using Sonluk.UI.Model.MES.TM_TMINFOService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Sonluk.UI.Model.WMS.WMS_JPDService;
using System.Data;
using System.Text.RegularExpressions;
using Sonluk.UI.Model.MODEL;
using Sonluk.UI.Model.WMS.BC_TMService;

namespace Sonluk.PC.Areas.WMS.Controllers
{
    public class BC_TMController : Controller
    {
        //
        // GET: /WMS/BC_TM/
        string token = "";
        string section = System.Configuration.ConfigurationManager.AppSettings["RemoteAddress"];
        string FileSavePath = System.Configuration.ConfigurationManager.AppSettings["FileSavePath"];
        AppClass appClass = new AppClass();
        SHttp sHttp = new SHttp();
        MESModels mesModels = new MESModels();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SCBSRK_MANAGE()
        {
            return View();
        }
        public ActionResult REPLACE_TBM()
        {
            AppClass.SetSession("location", 10118);
            return View();
        }
        public ActionResult RKBS_F_MANAGE()
        {
            AppClass.SetSession("location", 10117);
            return View();
        }
        public ActionResult RKBS_F_ZH_MANAGE()
        {
            AppClass.SetSession("location", 10117);
            return View();
        }

        public ActionResult RKBS_B_MANAGE()
        {
            AppClass.SetSession("location", 10119);
            return View();
        }
        public ActionResult RKBS_B_ZH_MANAGE()
        {
            AppClass.SetSession("location", 10119);
            return View();
        }
        public ActionResult RKBS_PRINT()
        {

            string token = AppClass.GetSession("token").ToString();
            string printinfo = Request.QueryString["RKBS_PRINT"];
            if (string.IsNullOrEmpty(printinfo))
            {
                printinfo = "";
            }
            SELECT_MES_TM_TMINFO_PRINT_LIST rst = mesModels.TM_TMINFO.SELECT_PRINT_RKBS(token, printinfo);
            ViewData.Model = rst.SELECT_MES_TM_TMINFO_PRINT;
            return View();
        }

        [HttpPost]
        public string READ_TMINFO(string data)
        {
            token = appClass.CRM_Gettoken();
            var url = section + "api/WMS/BC_TM/READ";
            var restClient = new RestClient(url);
            var restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Sonluk-Token", token);
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.AddBody(data);
            var response = restClient.Execute(restRequest);
            var jsonData = (JObject)JsonConvert.DeserializeObject(response.Content);
            return Newtonsoft.Json.JsonConvert.SerializeObject(jsonData);
        }
        [HttpPost]
        public string Read_Check(string data)
        {
            token = appClass.CRM_Gettoken();
            var url = section + "api/WMS/BC_TM/";
            var restClient = new RestClient(url);
            var restRequest = new RestRequest(Method.GET);
            restRequest.AddHeader("Sonluk-Token", token);
            restRequest.AddParameter("data", data);
            var restResponse = restClient.Execute(restRequest);
            var jsonData = (JObject)JsonConvert.DeserializeObject(restResponse.Content);
            return Newtonsoft.Json.JsonConvert.SerializeObject(jsonData);
        }
        [HttpPost]
        public string REPLACR_TPM(string model)
        {
            token = appClass.CRM_Gettoken();
            var url = section + "api/WMS/BC_TM/REPLACR_TPM";
            var restClient = new RestClient(url);
            var restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Sonluk-Token", token);
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.AddBody(model);
            var response = restClient.Execute(restRequest);
            var jsonData = (JObject)JsonConvert.DeserializeObject(response.Content);
            return Newtonsoft.Json.JsonConvert.SerializeObject(jsonData);
        }
        [HttpPost]
        public string DOWNLOAD_EXCEL(string model)
        {
            token = appClass.CRM_Gettoken();
            var url = section + "api/WMS/BC_TM/REPLACR_TPM";
            var restClient = new RestClient(url);
            var restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Sonluk-Token", token);
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.AddBody(model);
            var response = restClient.Execute(restRequest);
            var jsonData = (JObject)JsonConvert.DeserializeObject(response.Content);
            return Newtonsoft.Json.JsonConvert.SerializeObject(jsonData);
        }

        public ActionResult YHXQXF()
        {
            Session["location"] = 20001;
            return View();
        }


        [HttpPost]
        public string JPXX_READ_YH_CK(string data, string CKID)
        {
            string model = sHttp.SApiPost("WMS", "SAP/ZBC01/ZBCFUN_JPXX_READ_YH_CK?CKID=" + CKID, data);
            return model;
        }

        [HttpPost]
        public string SELECT_BY_ROLE_ASSEMBLE(string WERKS)
        {
            token = appClass.CRM_Gettoken();
            MES_MM_CK model = new MES_MM_CK();
            if (WERKS == "1000")
            {
                model.ROLENAME = "1000-验货仓库";
            }
            else if (WERKS == "4000")
            {
                model.ROLENAME = "4000-验货仓库";
            }
            else
            {
                model.ROLENAME = "1000-验货仓库";
            }

            MES_MM_CK_SELECT data = mesModels.MM_CK.SELECT_BY_ROLE_ASSEMBLE(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        public ActionResult WL_CHANGE()
        {
            Session["location"] = 20002;
            return View();
        }

        [HttpPost]
        public string ZHPZ_READ(string IV_MBLNR, string CKID)
        {
            string model = sHttp.SApiPost("WMS", "SAP/ZBC01/ZBCFUN_ZHPZ_READ?CKID=" + CKID + "&IV_MBLNR=" + IV_MBLNR, "");
            return model;
        }

        [HttpPost]
        public string SelectTM_TMINFO_CKID_CXLB(string data, string CKID)
        {
            string model = sHttp.SApiPost("WMS", "MES/TM/SelectTM_TMINFO_CKID_CXLB?CXLB=3&CKID=" + CKID, data);
            return model;
        }

        [HttpPost]
        public string UPDATE_ZHPZ(string data)
        {
            string model = sHttp.SApiPost("WMS", "WMS/BC_TM/UPDATE_ZHPZ", data);
            return model;
        }

        public ActionResult CPHWBS()
        {
            Session["location"] = 20003;
            token = appClass.CRM_Gettoken();
            MES_SY_GC cx_gc = new MES_SY_GC();
            cx_gc.STAFFID = appClass.CRM_GetStaffid();
            MES_SY_GC[] GC = mesModels.SY_GC.SELECT_BY_ROLE(cx_gc, token);
            ViewBag.GC = GC;
            return View();
        }

        [HttpPost]
        public string ZBCFUN_GLPZ_READ(string data)
        {
            string model = sHttp.SApiPost("WMS", "SAP/ZBC01/ZBCFUN_GLPZ_READ", data);
            return model;
        }
        [HttpPost]
        public string SELECT_LB_kcbs_wck(string data)
        {
            string model = sHttp.SApiPost("WMS", "MES/TM/SELECT_LB_kcbs_wck", data);
            return model;
        }
        [HttpPost]
        public string INSERT_WLKCBS_WLPZ(string data)
        {
            string model = sHttp.SApiPost("WMS", "MES/TM/INSERT_WLKCBS_WLPZ", data);
            return model;
        }
        [HttpPost]
        public string DELETE_TM_LOG(string data)
        {
            string model = sHttp.SApiPost("WMS", "MES/TM/DELETE_TM_LOG", data);
            return model;
        }
        [HttpPost]
        public string GET_YGNAME(string GH)
        {
            string model = sHttp.SApiPost("WMS", "PUBLCFUN/PUBLIC/GET_YGNAME?GH=" + GH, "");
            return model;
        }
        [HttpPost]
        public string Read_KCDD_ByGC_BySTAFFID(string GC)
        {
            token = appClass.CRM_Gettoken();
            MES_MM_CK cx_kcdd = new MES_MM_CK();
            cx_kcdd.STAFFID = appClass.CRM_GetStaffid();
            cx_kcdd.GC = GC;
            MES_MM_CK_SELECT KCDD = mesModels.MM_CK.SELECT_BY_STAFFID(cx_kcdd, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(KCDD);
        }
        [HttpPost]
        public string TM_DAOCHU(string data)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            DaoRuMsg msg = new DaoRuMsg();
            try
            {
                MES_TM_TMINFO_LIST[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_TM_TMINFO_LIST[]>(data);


                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/WMS/ExportFile/成品货物标识导出模板.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet worksheet1 = workbook.GetSheet("成品货物标识");
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
                    row.CreateCell(0).SetCellValue(model[i].TM);
                    row.CreateCell(1).SetCellValue(model[i].WLH);
                    row.CreateCell(2).SetCellValue(model[i].WLMS);
                    row.CreateCell(3).SetCellValue(model[i].PC);
                    row.CreateCell(4).SetCellValue(model[i].NOBILL);
                    row.CreateCell(5).SetCellValue(model[i].NOBILLMX);
                    row.CreateCell(6).SetCellValue(Convert.ToDouble(model[i].DCSLBS.ToString()));
                    row.CreateCell(7).SetCellValue(Convert.ToDouble(model[i].DCSLMBSL.ToString()));
                    row.CreateCell(8).SetCellValue(Convert.ToDouble(model[i].ALLBOXCOUNT.ToString()));
                    row.CreateCell(9).SetCellValue(model[i].GC);
                    row.CreateCell(10).SetCellValue(model[i].KCDDNAME);
                    row.CreateCell(11).SetCellValue(model[i].WLPZND);
                    row.CreateCell(12).SetCellValue(model[i].WLPZBH);
                    row.CreateCell(13).SetCellValue(model[i].WLPZHXMH);
                    row.CreateCell(14).SetCellValue(Convert.ToDouble(model[i].RESDUESL.ToString()));
                    row.CreateCell(15).SetCellValue(Convert.ToDouble(model[i].SL.ToString()));
                    row1++;
                }
                worksheet1.ForceFormulaRecalculation = true;
                string now = DateTime.Now.ToString("yyyy-MM");
                FileStream file1 = new FileStream(string.Format(@"{0}/Areas/WMS/ExportFile/{1}.xlsx", Server.MapPath("~"), now), FileMode.Create);
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

        public ActionResult Data_DaoChu_TM_File(string filename)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/WMS/ExportFile/{1}.xlsx", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", filename + "-成品货物标识.xlsx");
        }

        [HttpPost]
        public string Post_Print_TM(string data)
        {
            WebMSG webmsg = new WebMSG();
            try
            {
                MES_TM_TMINFO_LIST[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_TM_TMINFO_LIST[]>(data);
                Session["PRINTTM"] = model;
                webmsg.KEY = 1;
                webmsg.MSG = "";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }
            catch (Exception e)
            {
                webmsg.KEY = 0;
                webmsg.MSG = e.Message;
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }
        }

        public ActionResult PRINT_TM(int count)
        {
            token = appClass.CRM_Gettoken();

            if (Session["PRINTTM"] != null)
            {
                MES_TM_TMINFO_LIST[] data = (MES_TM_TMINFO_LIST[])Session["PRINTTM"];
                List<PrintTM> TM = new List<PrintTM>();
                string WLPZ = "XXXXXXXX";  //初始值，总之跟正常的物料凭证不一样就行
                int WPLZcount = -1; //表示当前循坏的是物料凭证的第几行
                for (int i = 0; i < data.Length; i++)
                {
                    if (data[i].WLPZBH != WLPZ)
                    {
                        //首行或者物料凭证不一样了，需要往一级结构添加数据
                        WPLZcount++;
                        WLPZ = data[i].WLPZBH;

                        PrintTM temp = new PrintTM();
                        temp.TMTT = new MES_TM_TMINFO_LIST();
                        temp.TMTT.WLPZBH = data[i].WLPZBH;
                        temp.TMTT.JLTIME = data[i].JLTIME;
                        temp.TMTT.GCDYMS = data[i].GCDYMS;
                        temp.TMMX = new List<MES_TM_TMINFO_LIST>();
                        temp.TMMX.Add(data[i]);
                        TM.Add(temp);
                    }
                    else
                    {
                        //物料凭证跟上一行一样，往二级结构添加数据
                        TM[WPLZcount].TMMX.Add(data[i]);
                    }
                }

                ViewBag.data = TM;
                ViewBag.Count = count;
            }
            else
            {
                List<PrintTM> TM = new List<PrintTM>();
                ViewBag.data = TM;
            }

            return View();
        }

        [HttpPost]
        public string API_RETURN_STRING_json(string apihsm, string body, string APIHEADER)
        {
            return appClass.API_RETURN_STRING_json(apihsm, body, APIHEADER);
        }

        [HttpPost]
        public string TM_EXPORT(string data)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            DaoRuMsg msg = new DaoRuMsg();
            try
            {
                token = appClass.CRM_Gettoken();
                var url = section + "api/WMS/BC_TM/READ";
                var restClient = new RestClient(url);
                var restRequest = new RestRequest(Method.POST);
                restRequest.AddHeader("Sonluk-Token", token);
                restRequest.RequestFormat = DataFormat.Json;
                restRequest.AddBody(data);
                var response = restClient.Execute(restRequest);
                var jsonData = (JObject)JsonConvert.DeserializeObject(response.Content);

                var result = jsonData["data"];

                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/WMS/ExportFile/套标码导出模板.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet worksheet1 = workbook.GetSheet("套标码");
                if (worksheet1 == null)
                {
                    msg.Msg = "err";
                    msg.Info = "工作薄中没有工作表";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }

                //worksheet1.AddMergedRegion(new CellRangeAddress(1, 2, 3, 4));
                int row1 = 1;
                for (int i = 0; i < result.Count(); i++)
                {
                    NPOI.SS.UserModel.IRow row = worksheet1.CreateRow(row1);
                    row.CreateCell(0).SetCellValue(result[i]["TPM"].ToString());
                    row.CreateCell(1).SetCellValue(result[i]["DXM"].ToString());
                    row.CreateCell(2).SetCellValue(result[i]["NHM"].ToString());
                    row1++;
                }

                for (int columnNum = 0; columnNum <= result.Count(); columnNum++)
                {
                    int columnWidth = worksheet1.GetColumnWidth(columnNum) / 256;
                    for (int rowNum = 1; rowNum <= worksheet1.LastRowNum; rowNum++)
                    {
                        IRow currentRow;
                        //当前行未被使用过
                        if (worksheet1.GetRow(rowNum) == null)
                        {
                            currentRow = worksheet1.CreateRow(rowNum);
                        }
                        else
                        {
                            currentRow = worksheet1.GetRow(rowNum);
                        }

                        if (currentRow.GetCell(columnNum) != null)
                        {
                            ICell currentCell = currentRow.GetCell(columnNum);
                            int length = Encoding.Default.GetBytes(currentCell.ToString()).Length;
                            if (columnWidth < length)
                            {
                                columnWidth = length;
                            }
                        }
                    }
                    worksheet1.SetColumnWidth(columnNum, columnWidth * 256);
                }

                worksheet1.ForceFormulaRecalculation = true;
                string now = DateTime.Now.ToString("yyyy-MM");
                FileStream file1 = new FileStream(string.Format(@"{0}/Areas/WMS/ExportFile/{1}.xlsx", Server.MapPath("~"), now), FileMode.Create);
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

        public ActionResult EXPORT_TM_File(string filename)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/WMS/ExportFile/{1}.xlsx", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", filename + "-套标码.xlsx");
        }


        public ActionResult XSCK_GZSQ()
        {
            AppClass.SetSession("location", 20004);
            return View();
        }
        public ActionResult XSCK_READ()
        {
            return View();
        }
        [HttpPost]
        public string CREATE_JHD_TQGZ(string data)
        {
            string model = sHttp.SApiPost("WMS", "WMS/WMS_JPD/CREATE_JHD_TQGZ", data);
            return model;
        }
        [HttpPost]
        public string UPDATE_JHD_TQGZ(string data)
        {
            string model = sHttp.SApiPost("WMS", "WMS/WMS_JPD/UPDATE_JHD_TQGZ", data);
            return model;
        }
        [HttpPost]
        public string READ_JHD_TQGZ(string data)
        {
            string model = sHttp.SApiPost("WMS", "WMS/WMS_JPD/READ_JHD_TQGZ", data);
            return model;
        }

        [HttpPost]
        public string READ_JH_JHJPINFO(string VBELN)
        {
            string model = sHttp.SApiPost("WMS", "BC/BarCode/READ_JH_JHJPINFO?VBELN=" + VBELN, "");
            return model;
        }

        [HttpPost]
        public string Data_DaoRu_MDBS()
        {
            token = appClass.CRM_Gettoken();
            DaoRuMsg msg = new DaoRuMsg();
            msg.Info = "E";
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
                    string[] sheet = { "过账授权" };

                    DataTable data1 = ExcelToDataTable(savePath, sheet[0], true);      //过账授权
                    System.IO.File.Delete(savePath);
                    #region 数据校验
                    if (data1 != null)
                    {
                        if (data1.Columns.Contains("交货单") == false || data1.Columns.Contains("开放状态") == false)
                        {
                            msg.Msg = "请使用指定的导入模版！";
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
                                        if (data1.Rows[i]["交货单"].ToString().Length != 8)
                                        {
                                            msg.Msg = "过账授权第" + (i + 2) + "行交货单格式不正确！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (data1.Rows[i]["开放状态"].ToString() != "已开放" && data1.Rows[i]["开放状态"].ToString() != "未开放")
                                        {
                                            msg.Msg = "过账授权第" + (i + 2) + "行开放状态内容不正确！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
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

                    #region 过账授权
                    List<WMS_JPD_JHD_TQGZ> modellist = new List<WMS_JPD_JHD_TQGZ>();
                    for (int i = 0; i < data1.Rows.Count; i++)
                    {
                        WMS_JPD_JHD_TQGZ temp = new WMS_JPD_JHD_TQGZ();
                        temp.JHD = data1.Rows[i]["交货单"].ToString();

                        switch (data1.Rows[i]["开放状态"].ToString())
                        {
                            case "已开放":
                                temp.KFZT = 2;
                                break;
                            case "未开放":
                                temp.KFZT = 1;
                                break;
                            default:
                                temp.KFZT = 0;
                                break;
                        }
                        modellist.Add(temp);

                    }
                    string datastring = Newtonsoft.Json.JsonConvert.SerializeObject(modellist);
                    string model = sHttp.SApiPost("WMS", "WMS/WMS_JPD/CREATE_JHD_TQGZ", datastring);

                    msg.Info = "S";
                    msg.data = model;
                    #endregion
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
        public string TQGZ_DAOCHU(string data)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            DaoRuMsg msg = new DaoRuMsg();
            try
            {
                WMS_JPD_JHD_TQGZ[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<WMS_JPD_JHD_TQGZ[]>(data);


                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/WMS/ExportFile/过账授权导出模板.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet worksheet1 = workbook.GetSheet("过账授权");
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
                    int count = 0;
                    NPOI.SS.UserModel.IRow row = worksheet1.CreateRow(row1);
                    row.CreateCell(count++).SetCellValue(model[i].JHD);
                    row.CreateCell(count++).SetCellValue(model[i].XSZZ);
                    row.CreateCell(count++).SetCellValue(model[i].XSZZNAME);
                    row.CreateCell(count++).SetCellValue(model[i].SDF);
                    row.CreateCell(count++).SetCellValue(model[i].SDFNAME);
                    row.CreateCell(count++).SetCellValue(model[i].KFZT == 1 ? "未开放" : "已开放");
                    row.CreateCell(count++).SetCellValue(model[i].CJTIME);
                    row.CreateCell(count++).SetCellValue(model[i].CJRNAME);
                    row.CreateCell(count++).SetCellValue(model[i].XGTIME);
                    row.CreateCell(count++).SetCellValue(model[i].XGRNAME);
                    row1++;
                }
                worksheet1.ForceFormulaRecalculation = true;
                string now = DateTime.Now.ToString("yyyy-MM");
                FileStream file1 = new FileStream(string.Format(@"{0}/Areas/WMS/ExportFile/{1}.xlsx", Server.MapPath("~"), now), FileMode.Create);
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

        public ActionResult Data_DaoChu_TQGZ_File(string filename)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/WMS/ExportFile/{1}.xlsx", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", filename + "-过账授权.xlsx");
        }

        public DataTable ExcelToDataTable(string fileName, string sheetName, bool isFirstRowColumn)
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

                if (sheetName != null)
                {
                    sheet = workbook.GetSheet(sheetName);
                    if (sheet == null) //如果没有找到指定的sheetName对应的sheet，则尝试获取第一个sheet
                    {
                        sheet = workbook.GetSheetAt(0);
                    }
                }
                else
                {
                    sheet = workbook.GetSheetAt(0);
                }
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
                            //if (row.GetCell(j) != null) //同理，没有数据的单元格都默认是""
                            //    dataRow[j] = row.GetCell(j).ToString();
                            ICell cell = row.GetCell(j);

                            if (cell != null)
                            {
                                string cellValue = "";
                                if (cell.CellType == CellType.Numeric)
                                {
                                    short format = cell.CellStyle.DataFormat;
                                    if (format == 14 || format == 176 || format == 177)
                                    {
                                        cellValue = cell.DateCellValue.ToString("yyyy-MM-dd");
                                    }
                                    else
                                    {
                                        cellValue = row.GetCell(j).ToString();
                                    }
                                }
                                else
                                {
                                    cellValue = row.GetCell(j).ToString();
                                }
                                dataRow[j] = cellValue;
                            }
                        }
                        data.Rows.Add(dataRow);
                    }
                }

                return data;
            }
            catch (Exception)
            {
                //MessageBox.Show("Exception: " + ex.Message);
                return null;
            }
        }

        public ActionResult EXPORT_DOWNLOAD_TQGZ_xls(string filename, string filenameout)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/WMS/ExportFile/{1}.xlsx", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            return File(arrFile, "application/vnd.ms-excel", filenameout + ".xlsx");
        }

        public ActionResult WLDZB()
        {
            AppClass.SetSession("location", 20005);
            token = appClass.CRM_Gettoken();
            MES_SY_GC cx_gc = new MES_SY_GC();
            cx_gc.STAFFID = appClass.CRM_GetStaffid();
            MES_SY_GC[] GC = mesModels.SY_GC.SELECT_BY_ROLE(cx_gc, token);
            ViewBag.GC = GC;
            return View();
        }
        [HttpPost]
        public string MES_TMINFO_SELECT_LB(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            MES_TM_TMINFO model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_TM_TMINFO>(cxdata);
            model.STAFFID = appClass.CRM_GetStaffid();
            SELECT_MES_TM_TMINFO_BYTM data = mesModels.TM_TMINFO.SELECT_LB(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }
        [HttpPost]
        public string WLDZB_DAOCHU(string data)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            DaoRuMsg msg = new DaoRuMsg();
            try
            {
                MES_TM_TMINFO_LIST[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_TM_TMINFO_LIST[]>(data);


                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/WMS/ExportFile/车间物流对账表导出模板.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet worksheet1 = workbook.GetSheet("物流对账表");
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
                    int count = 0;
                    NPOI.SS.UserModel.IRow row = worksheet1.CreateRow(row1);
                    row.CreateCell(count++).SetCellValue(model[i].TM);
                    row.CreateCell(count++).SetCellValue(model[i].ZHNO);
                    row.CreateCell(count++).SetCellValue(model[i].WLH);
                    row.CreateCell(count++).SetCellValue(model[i].WLMS);
                    row.CreateCell(count++).SetCellValue(model[i].PC);
                    row.CreateCell(count++).SetCellValue(model[i].GC);
                    row.CreateCell(count++).SetCellValue(model[i].KCDDNAME);
                    row.CreateCell(count++).SetCellValue(model[i].CKNO);
                    row.CreateCell(count++).SetCellValue(model[i].AREANO);
                    row.CreateCell(count++).SetCellValue(model[i].LGPLA);
                    row.CreateCell(count++).SetCellValue(model[i].HJCM);
                    row.CreateCell(count++).SetCellValue(model[i].RESDUESL.ToString());
                    row.CreateCell(count++).SetCellValue(model[i].JHZ);
                    row.CreateCell(count++).SetCellValue(model[i].SOBKZ);
                    row.CreateCell(count++).SetCellValue(model[i].SONUM);
                    row.CreateCell(count++).SetCellValue(model[i].ISZC == 0 ? "否" : "是");
                    row.CreateCell(count++).SetCellValue(model[i].GZZXBH);
                    row.CreateCell(count++).SetCellValue(model[i].JLTIME);
                    row.CreateCell(count++).SetCellValue(model[i].XGTIME);
                    row.CreateCell(count++).SetCellValue(model[i].WLPZBH);
                    row.CreateCell(count++).SetCellValue(model[i].WLPZHXMH);
                    row.CreateCell(count++).SetCellValue(model[i].WLPZND);
                    row.CreateCell(count++).SetCellValue(model[i].SL.ToString());
                    row.CreateCell(count++).SetCellValue(model[i].JZ.ToString());
                    row.CreateCell(count++).SetCellValue(model[i].CKDJH);
                    string RKZT = "";
                    switch (model[i].RKZT)
                    {
                        case 1:
                            RKZT = "车间发出";
                            break;
                        case 2:
                            RKZT = "物流入库";
                            break;
                        default:
                            RKZT = "";
                            break;
                    }
                    row.CreateCell(count++).SetCellValue(RKZT);
                    row1++;
                }
                worksheet1.ForceFormulaRecalculation = true;
                string now = DateTime.Now.ToString("yyyy-MM");
                FileStream file1 = new FileStream(string.Format(@"{0}/Areas/WMS/ExportFile/{1}.xlsx", Server.MapPath("~"), now), FileMode.Create);
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

        public ActionResult Data_DaoChu_WLDZB_File(string filename)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/WMS/ExportFile/{1}.xlsx", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", filename + "-车间物流对账表导出模板.xlsx");
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
        public string EXPOST_TITLE_LIST(string titlelist, string datastring)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            TABLE_COLS[] model_title = Newtonsoft.Json.JsonConvert.DeserializeObject<TABLE_COLS[]>(titlelist);
            DataTable model_datatable = Newtonsoft.Json.JsonConvert.DeserializeObject<DataTable>(datastring);
            try
            {
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/HR/ExportFile/导出模版.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 0;
                IRow rowtt = sheet.CreateRow(rowcount++);
                int cellIndex = 0;
                for (int a = 0; a < model_title.Length; a++)
                {
                    rowtt.CreateCell(cellIndex++).SetCellValue(model_title[a].Title);
                }
                for (int i = 0; i < model_datatable.Rows.Count; i++)
                {
                    cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    for (int a = 0; a < model_title.Length; a++)
                    {
                        if (string.IsNullOrEmpty(model_title[a].Titletype))
                        {
                            row.CreateCell(cellIndex++).SetCellValue(model_datatable.Rows[i][model_title[a].Field].ToString());
                        }
                        else
                        {
                            if (model_title[a].Titletype == "int")
                            {
                                row.CreateCell(cellIndex++).SetCellValue(Convert.ToInt32(model_datatable.Rows[i][model_title[a].Field].ToString()));
                            }
                        }
                    }
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



        public ActionResult JHZCCX()
        {
            AppClass.SetSession("location", 20005);
            return View();
        }

        [HttpPost]
        public string READ_JH_JHZC(string data)
        {
            string model = sHttp.SApiPost("WMS", "WMS/BC_TM/READ_JH_JHZC", data);
            return model;
        }

        [HttpPost]
        public string JHZC_DAOCHU(string data)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            DaoRuMsg msg = new DaoRuMsg();
            try
            {
                WMS_BC_TM_JH_JHZC[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<WMS_BC_TM_JH_JHZC[]>(data);


                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/WMS/ExportFile/内销交货转储查询导出模板.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet worksheet1 = workbook.GetSheet("交货转储");
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
                    int count = 0;
                    NPOI.SS.UserModel.IRow row = worksheet1.CreateRow(row1);
                    row.CreateCell(count++).SetCellValue(model[i].JHNO);
                    row.CreateCell(count++).SetCellValue(model[i].JHMXNO);
                    row.CreateCell(count++).SetCellValue(model[i].JPDNO);
                    row.CreateCell(count++).SetCellValue(model[i].JPDMXNO);
                    row.CreateCell(count++).SetCellValue(model[i].WLH);
                    row.CreateCell(count++).SetCellValue(model[i].WLMS);
                    row.CreateCell(count++).SetCellValue(model[i].TPM);
                    row.CreateCell(count++).SetCellValue(model[i].DXM);
                    row.CreateCell(count++).SetCellValue(model[i].NHM);
                    row.CreateCell(count++).SetCellValue(model[i].QXBS);
                    row.CreateCell(count++).SetCellValue(model[i].LTBS);
                    row.CreateCell(count++).SetCellValue(model[i].SDF);
                    row.CreateCell(count++).SetCellValue(model[i].SDFNAME);
                    row.CreateCell(count++).SetCellValue(model[i].SDFADDRESS);
                    row.CreateCell(count++).SetCellValue(model[i].FHSL.ToString());
                    row.CreateCell(count++).SetCellValue(model[i].DW);
                    row.CreateCell(count++).SetCellValue(model[i].JHZ);
                    row.CreateCell(count++).SetCellValue(model[i].TSKCBJ);
                    row.CreateCell(count++).SetCellValue(model[i].TSKC);
                    row.CreateCell(count++).SetCellValue(model[i].CHARG);
                    row.CreateCell(count++).SetCellValue(model[i].GC);
                    row.CreateCell(count++).SetCellValue(model[i].KCDDNAME);
                    
                    row1++;
                }
                worksheet1.ForceFormulaRecalculation = true;
                string now = DateTime.Now.ToString("yyyy-MM");
                FileStream file1 = new FileStream(string.Format(@"{0}/Areas/WMS/ExportFile/{1}.xlsx", Server.MapPath("~"), now), FileMode.Create);
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

        public ActionResult Data_DaoChu_JHZC_File(string filename)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/WMS/ExportFile/{1}.xlsx", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", filename + "-内销交货转储查询导出模板.xlsx");
        }



    }
}
