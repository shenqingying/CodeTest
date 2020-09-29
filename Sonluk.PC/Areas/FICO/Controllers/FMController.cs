using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using RestSharp;
using Sonluk.PC.APPCLASS;
using Sonluk.PC.Models;
using Sonluk.UI.Model.FICO.FM_ElectricInvoiceService;
using Sonluk.UI.Model.HR.SY_GSService;
using Sonluk.UI.Model.MES.SY_GCService;
using Sonluk.UI.Model.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Sonluk.PC.Areas.FICO.Controllers
{
    public class FMController : Controller
    {
        //
        // GET: /FICO/FM/
        string token = "";
        AppClass appClass = new AppClass();
        CRMModels crmModels = new CRMModels();
        WebMSG webmsg = new WebMSG();
        MESModels mesmodels = new MESModels();
        HRModels hrmodels = new HRModels();
        string FileSavePath = System.Configuration.ConfigurationManager.AppSettings["FileSavePath"];
        string FileSavePath2 = System.Configuration.ConfigurationManager.AppSettings["FileSavePath2"];
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ElectricInvoice()
        {
            Session["location"] = 11000;
            ViewBag.STAFFNAME = Session["NAME"];
            ViewBag.YEAR = DateTime.Now.Year;

            token = appClass.CRM_Gettoken();
            int STAFFID = Convert.ToInt32(Session["STAFFID"].ToString());
            HR_SY_GS_SELECT GCData = hrmodels.SY_GS.SELECT_BY_ROLE(STAFFID, token);
            ViewBag.GCData = GCData;
            return View();
        }
        public ActionResult ElectricInvoiceForEdit()
        {
            Session["location"] = 11001;
            ViewBag.STAFFNAME = Session["NAME"];
            ViewBag.YEAR = DateTime.Now.Year;

            token = appClass.CRM_Gettoken();
            int STAFFID = Convert.ToInt32(Session["STAFFID"].ToString());
            HR_SY_GS_SELECT GCData = hrmodels.SY_GS.SELECT_BY_ROLE(STAFFID, token);
            ViewBag.GCData = GCData;

            return View();
        }
        public ActionResult Select_ElectricInvoice()
        {
            Session["location"] = 11002;
            token = appClass.CRM_Gettoken();
            int STAFFID = Convert.ToInt32(Session["STAFFID"].ToString());
            HR_SY_GS_SELECT GCData = hrmodels.SY_GS.SELECT_BY_ROLE(STAFFID, token);
            ViewBag.GCData = GCData;
            return View();
        }
        [HttpPost]
        public string Insert_Invoice(string data)
        {

            token = appClass.CRM_Gettoken();
            FICO_FM_ElectricInvoice model = Newtonsoft.Json.JsonConvert.DeserializeObject<FICO_FM_ElectricInvoice>(data);

            FICO_FM_ElectricInvoice nnModel = new FICO_FM_ElectricInvoice();
            nnModel.FPDM = model.FPDM;
            nnModel.FPHM = model.FPHM;
            int x = crmModels.FM_ElectricInvoice.ReadBySCAN(nnModel, token);
            if (x > 0)
            {
                webmsg.KEY = x;
                webmsg.MSG = "发票重复报销,请检查数据";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }

            model.CJR = appClass.CRM_GetStaffid();
            model.XGR = appClass.CRM_GetStaffid();
            model.ISACTIVE = 1;
            try
            {

                int i = crmModels.FM_ElectricInvoice.Create(model, token);
                if (i > 0)
                {
                    webmsg.KEY = i;
                    webmsg.MSG = "新增成功！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
                else
                {
                    webmsg.KEY = i;
                    webmsg.MSG = "新增失败！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
            }
            catch (Exception E)
            {
                return E.Message;
            }

        }
        [HttpPost]
        public string Get_Invoice(string data)
        {
            token = appClass.CRM_Gettoken();
            FICO_FM_ElectricInvoice model = Newtonsoft.Json.JsonConvert.DeserializeObject<FICO_FM_ElectricInvoice>(data);
            try
            {
                FICO_FM_ElectricInvoice[] nnModel = crmModels.FM_ElectricInvoice.ReadByParam(model, token);
                return Newtonsoft.Json.JsonConvert.SerializeObject(nnModel);
            }
            catch (Exception E)
            {
                return E.Message;
            }
            //return Newtonsoft.Json.JsonConvert.SerializeObject(1);
            // 
        }
        [HttpPost]
        public string Delete_Invoice(int ID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.FM_ElectricInvoice.Delete(ID, token);
            if (i > 0)
            {
                webmsg.KEY = i;
                webmsg.MSG = "删除成功！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }
            else
            {
                webmsg.KEY = i;
                webmsg.MSG = "删除失败！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }
        }
        [HttpPost]
        public string Update_Invoice(string data)
        {
            token = appClass.CRM_Gettoken();
            FICO_FM_ElectricInvoice model = Newtonsoft.Json.JsonConvert.DeserializeObject<FICO_FM_ElectricInvoice>(data);


            model.XGR = appClass.CRM_GetStaffid();
            model.ISACTIVE = 1;
            int i = crmModels.FM_ElectricInvoice.Update(model, token);
            if (i > 0)
            {
                webmsg.KEY = i;
                webmsg.MSG = "更新成功";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }
            else
            {
                webmsg.KEY = i;
                webmsg.MSG = "更新失败";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }
        }
        [HttpPost]
        public int Get_InvoiceForSCAN(string data)
        {
            token = appClass.CRM_Gettoken();
            FICO_FM_ElectricInvoice model = Newtonsoft.Json.JsonConvert.DeserializeObject<FICO_FM_ElectricInvoice>(data);
            try
            {
                int i = crmModels.FM_ElectricInvoice.ReadBySCAN(model, token);
                return i;
            }
            catch (Exception e)
            {
                throw e;
            }



        }
        [HttpPost]
        public string FileExport_INVOICE(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            DaoRuMsg msg = new DaoRuMsg();
            //   int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_RETURN_UI rst = new MES_RETURN_UI();
            try
            {
                FICO_FM_ElectricInvoice cxmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<FICO_FM_ElectricInvoice>(cxdata);
                FICO_FM_ElectricInvoice[] model = crmModels.FM_ElectricInvoice.ReadByParam(cxmodel, token);
                FileStream file = new FileStream(FileSavePath + @"\ExcelTemplate/电子发票.xls", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new HSSFWorkbook(file);
                ISheet worksheet1 = workbook.GetSheetAt(0);
                if (worksheet1 == null)
                {
                    msg.Msg = "errr";
                    msg.Info = "Excel中没有工作表";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }
                int row1 = 0;
                for (int i = 0; i < model.Length; i++)
                {
                    int cellIndex = 0;
                    NPOI.SS.UserModel.IRow row = worksheet1.CreateRow(row1 + 1);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].FPDM);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].FPHM);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].KPRQ);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].JYM);
                    row.CreateCell(cellIndex++).SetCellValue((model[i].AMOUNT).ToString());
                    row.CreateCell(cellIndex++).SetCellValue(model[i].SELLERID);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].PZBH);

                    row.CreateCell(cellIndex++).SetCellValue(model[i].BXR);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].CJSJ);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].CJRDES);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].KJND);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].BEIZ);

                    row1++;
                }
                for (int columnNum = 0; columnNum <= model.Length; columnNum++)
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
                string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                FileStream file1 = new FileStream(FileSavePath + @"\upload\" + now + ".xls", FileMode.Create);
                workbook.Write(file1);
                file1.Close();
                rst.TYPE = "S";
                rst.MESSAGE = now + ".xls";
                return Newtonsoft.Json.JsonConvert.SerializeObject(rst);



            }
            catch (Exception e)
            {
                msg.Msg = "err";
                msg.Info = e.ToString();
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
        }
        public ActionResult EXPORT_DOWNLOAD(string filename, string filenameout)
        {
            byte[] arrFile = null;
            //   string path = string.Format(@"{0}/Areas/CRM/ExcelTemplate/{1}.xlsx", Server.MapPath("~"), filename);
            string path = FileSavePath + @"\upload\" + filename;
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", filenameout + ".xls");
        }
        [HttpPost]
        public string DR_ElectricInvoice()
        {
            token = appClass.CRM_Gettoken();
            DaoRuMsg mr = new DaoRuMsg();
            //   DaoRuMsg mr = new DaoRuMsg();
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
                DataTable data = ExcelToDataTable(savePath, 0, true);

                for (int i = 0; i < data.Rows.Count; i++)
                {
                    if (data.Rows[i]["发票"].ToString() == "")
                    {
                        mr.Info = "E";
                        mr.Msg = "第" + (i + 1) + "行发票代码不能为空";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(mr);
                    }
                    if (data.Rows[i]["发票"].ToString().Trim().Length != 20)
                    {
                        mr.Info = "E";
                        mr.Msg = "第" + (i + 1) + "行发票代码长度不正确";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(mr);
                    }
                    FICO_FM_ElectricInvoice model = new FICO_FM_ElectricInvoice();
                    model.FPHM = data.Rows[i]["发票"].ToString().Trim().Substring(0, 12);
                    model.FPDM = data.Rows[i]["发票"].ToString().Trim().Substring(12);

                    int x = crmModels.FM_ElectricInvoice.ReadBySCAN(model, token);
                    if (x > 0)
                    {
                        mr.Info = "E";
                        mr.Msg = "第" + (i + 1) + "行发票重复，请检查数据.";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(mr);
                    }
                }
                for (int i = 0; i < data.Rows.Count; i++)
                {

                    if (data.Rows[i]["发票"].ToString().Trim().Length != 20)
                    {
                        mr.Info = "E";
                        mr.Msg = "发票格式不正确";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(mr);
                    }
                    else
                    {
                        FICO_FM_ElectricInvoice model = new FICO_FM_ElectricInvoice();
                        model.KPRQ = data.Rows[i]["开票日期"].ToString().Trim().Replace(".", "-");
                        model.BXR = data.Rows[i]["经办人"].ToString().Trim();
                        model.FPDM = data.Rows[i]["发票"].ToString().Trim().Substring(0, 12);
                        model.FPHM = data.Rows[i]["发票"].ToString().Trim().Substring(12);
                        model.JYM = "";
                        model.ISACTIVE = 1;
                        model.BEIZ = "期初数据,含税金额" + data.Rows[i]["金额"].ToString().Trim();
                        model.CJR = appClass.CRM_GetStaffid();
                        model.XGR = appClass.CRM_GetStaffid();
                        int j = crmModels.FM_ElectricInvoice.Create(model, token);
                        if (j < 0)
                        {
                            mr.Msg = "err";
                            mr.Info = "存入数据错误，请联系管理员";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(mr);
                        }
                    }
                }
                mr.Info = "S";
                mr.Msg = "导入成功";
                return Newtonsoft.Json.JsonConvert.SerializeObject(mr);
            }
            mr.Msg = "S";
            mr.Info = "导入成功";
            return Newtonsoft.Json.JsonConvert.SerializeObject(mr);
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
                                string cellValue = cell.StringCellValue.Trim();
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
                                    if (format == 14)
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
               //throw;
                //MessageBox.Show("Exception: " + ex.Message);
                return null;
            }
        }



        public string GetBlockchainInvoice(string url)
        {
            token = appClass.CRM_Gettoken();
            var queryUri = new Uri(url);
            if (!queryUri.Host.Equals("bcfp.shenzhen.chinatax.gov.cn", StringComparison.OrdinalIgnoreCase))
            {
                webmsg.KEY = 0;
                webmsg.MSG = "不是深圳电子普通发票的域名";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }
            var collection = HttpUtility.ParseQueryString(queryUri.Query);
            var rurl = $"{queryUri.Scheme}://{queryUri.Host}/dzswj/bers_ep_web/query_bill_detail";

            var restClient = new RestClient(rurl);
            var restRequest = new RestRequest(Method.POST);
            restRequest.AddParameter("bill_num", collection["bill_num"]);
            restRequest.AddParameter("total_amount", collection["total_amount"]);
            restRequest.AddParameter("tx_hash", collection["hash"]);
            var restResponse = restClient.Execute(restRequest);
            var jsonData = (JObject)JsonConvert.DeserializeObject(restResponse.Content);
            if(jsonData["retcode"].ToString() == "0")
            {
                var record = jsonData["bill_record"];
                var time = record.Value<long>("time");
                DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
                long lTime = long.Parse(time + "0000000");
                TimeSpan toNow = new TimeSpan(lTime);
                FICO_FM_ElectricInvoice MODEL = new FICO_FM_ElectricInvoice();
                MODEL.FPDM = record["bill_code"].ToString();
                MODEL.FPHM = record["bill_num"].ToString();
                MODEL.AMOUNT = record.Value<int>("amount") * 0.01m;
                MODEL.KPRQ = dtStart.Add(toNow).ToString("yyyy-MM-dd");
                MODEL.SELLERID = record["seller_taxpayer_id"].ToString();
                webmsg.KEY = 1;
                webmsg.MSG = Newtonsoft.Json.JsonConvert.SerializeObject(MODEL);
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }
            else
            {
                webmsg.KEY = 0;
                webmsg.MSG = string.Format("服务端响应错误{0}", jsonData["retmsg"]);
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }

        }

        public string VerifyInvoice(string url)
        {
            token = appClass.CRM_Gettoken();
            var queryUri = new Uri(url);
            if (!queryUri.Host.Equals("bcfp.shenzhen.chinatax.gov.cn", StringComparison.OrdinalIgnoreCase))
            {
                webmsg.KEY = 0;
                webmsg.MSG = "不是深圳电子普通发票的域名";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }
            var collection = HttpUtility.ParseQueryString(queryUri.Query);
            var rurl = $"{queryUri.Scheme}://{queryUri.Host}/dzswj/bers_ep_web/query_bill_detail";

            var restClient = new RestClient(rurl);
            var restRequest = new RestRequest(Method.POST);
            restRequest.AddParameter("bill_num", collection["bill_num"]);
            restRequest.AddParameter("total_amount", collection["total_amount"]);
            restRequest.AddParameter("tx_hash", collection["hash"]);
            var restResponse = restClient.Execute(restRequest);
            var jsonData = (JObject)JsonConvert.DeserializeObject(restResponse.Content);
            if (jsonData["retcode"].ToString() == "0")
            {
                var record = jsonData["bill_record"];

                FICO_FM_ElectricInvoice nMODEL = new FICO_FM_ElectricInvoice();
                nMODEL.FPDM = record["bill_code"].ToString();
                nMODEL.FPHM = record["bill_num"].ToString();
                FICO_FM_ElectricInvoice[] nnModel = crmModels.FM_ElectricInvoice.ReadByParam(nMODEL, token);
                //验证发票是否重复
                if (nnModel.Length > 0)
                {
                    webmsg.KEY = 2;
                    webmsg.MSG = Newtonsoft.Json.JsonConvert.SerializeObject(nnModel);
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }

                var time = record.Value<long>("time");
                DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
                long lTime = long.Parse(time + "0000000");
                TimeSpan toNow = new TimeSpan(lTime);
                FICO_FM_ElectricInvoice MODEL = new FICO_FM_ElectricInvoice();
                MODEL.FPDM = record["bill_code"].ToString();
                MODEL.FPHM = record["bill_num"].ToString();
                MODEL.AMOUNT = record.Value<int>("amount") * 0.01m;
                MODEL.KPRQ = dtStart.Add(toNow).ToString("yyyy-MM-dd");
                MODEL.SELLERID = record["seller_taxpayer_id"].ToString();
                webmsg.KEY = 1;
                webmsg.MSG = Newtonsoft.Json.JsonConvert.SerializeObject(MODEL);
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);

            }
            else
            {
                webmsg.KEY = 0;
                webmsg.MSG = string.Format("服务端响应错误{0}", jsonData["retmsg"]);
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }
        }

    }
}
