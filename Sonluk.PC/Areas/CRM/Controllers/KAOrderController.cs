using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Sonluk.PC.APPCLASS;
using Sonluk.PC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sonluk.UI.Model.CRM.ORDER_TTService;
using Sonluk.UI.Model.CRM.SAP_ORDERService;
using Sonluk.UI.Model.CRM.KH_KHService;
using Sonluk.UI.Model.CRM.PRODUCT_PRODUCTService;
using Sonluk.UI.Model.CRM.PRODUCT_PRODUCT_HHService;
using System.Security.Cryptography;
using System.Text;
using Sonluk.UI.Model.CRM.HG_DICTService;
using Sonluk.UI.Model.CRM.PRODUCT_HHService;
using Sonluk.UI.Model.BC.WS_BC_DRFService;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Text.RegularExpressions;
using Sonluk.UI.Model.MODEL;
using Sonluk.UI.Model.CRM.ORDER_SHService;
using Sonluk.UI.Model.MES.SY_MATERIALService;
using System.Net;
using Newtonsoft.Json.Linq;
using Sonluk.UI.Model.CRM.PRODUCT_KBService;
using Sonluk.UI.Model.CRM.PRODUCT_KBMXService;
using Sonluk.UI.Model.MES.MM_CKService;
using Sonluk.UI.Model.CRM.CRM_DRFService;
using Sonluk.UI.Model.CRM.KH_HZHBService;

namespace Sonluk.PC.Areas.CRM.Controllers
{
    public class KAOrderController : Controller
    {

        AppClass appClass = new AppClass();
        string token = "";
        WebMSG webmsg = new WebMSG();
        CRMModels crmModels = new CRMModels();
        MESModels mesModels = new MESModels();
        string FileSavePath = System.Configuration.ConfigurationManager.AppSettings["FileSavePath"];
        string FileSavePath2 = System.Configuration.ConfigurationManager.AppSettings["FileSavePath2"];
        //
        // GET: /CRM/KAOrder/

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 订单查询打印
        /// </summary>
        /// <returns></returns>
        public ActionResult DDCXDY()
        {

            token = appClass.CRM_Gettoken();
            //int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            //CRM_HG_DICT node = new CRM_HG_DICT();
            //node.TYPEID = 112;
            //CRM_HG_DICT[] list = crmModels.HG_DICT.ReadByParam(node, STAFFID, token);
            //ViewBag.mxList = list;
            Session["location"] = 1000;
            return View();
        }
        public string Select_DDLY()
        {
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            CRM_HG_DICT node = new CRM_HG_DICT();
            node.TYPEID = 112;
            token = appClass.CRM_Gettoken();
            CRM_HG_DICT[] list = crmModels.HG_DICT.ReadByParam(node, STAFFID, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(list); ;
        }
        /// <summary>
        /// 收货报告
        /// </summary>
        /// <returns></returns>
        public ActionResult SHBG()
        {
            token = appClass.CRM_Gettoken();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            CRM_HG_DICT node = new CRM_HG_DICT();
            node.TYPEID = 112;
            CRM_HG_DICT[] list = crmModels.HG_DICT.ReadByParam(node, STAFFID, token);
            ViewBag.mxList = list;
            Session["location"] = 1001;
            return View();
        }
        /// <summary>
        /// 收货报告明细
        /// </summary>
        /// <returns></returns>
        public ActionResult SHBGMX()
        {
            token = appClass.CRM_Gettoken();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            CRM_HG_DICT node = new CRM_HG_DICT();
            node.TYPEID = 112;
            CRM_HG_DICT[] list = crmModels.HG_DICT.ReadByParam(node, STAFFID, token);
            ViewBag.mxList = list;
            Session["location"] = 1001;
            return View();
        }
        /// <summary>
        /// 货号信息维护
        /// </summary>
        /// <returns></returns>
        public ActionResult HHXXWH()
        {
            Session["location"] = 1002;

            token = appClass.CRM_Gettoken();
            CRM_HG_DICT MODEL = new CRM_HG_DICT();
            MODEL.TYPEID = 112;
            CRM_HG_DICT[] SY = crmModels.HG_DICT.ReadByParam(MODEL, appClass.CRM_GetStaffid(), token);
            ViewBag.SY = SY;
            DateTime now = DateTime.Now;
            ViewBag.startdate = now.ToString("yyyy-MM-dd");
            ViewBag.enddate = DateTime.MaxValue.ToString("yyyy-MM-dd");
            return View();
        }
        public ActionResult HHXXWH_KB()
        {
            token = appClass.CRM_Gettoken();
            CRM_HG_DICT MODEL = new CRM_HG_DICT();
            MODEL.TYPEID = 112;
            CRM_HG_DICT[] SY = crmModels.HG_DICT.ReadByParam(MODEL, appClass.CRM_GetStaffid(), token);
            ViewBag.SY = SY;
            return View();
        }
        public ActionResult DRF_LOGIN()
        {
            Session["location"] = 1003;
            return View();
        }
        public string KAOrderBJ(string ORDERTTID)
        {
            token = appClass.CRM_Gettoken();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            CRM_ORDER_TT node = new CRM_ORDER_TT();

            node.BJR = STAFFID;
            node.ORDERTTID = Convert.ToInt32(ORDERTTID);
            int res = crmModels.ORDER_TT.UpdateTT_BJ(node, token);
            return res.ToString();
        }

        public string KAOrderQR(int ORDERTTID)
        {
            token = appClass.CRM_Gettoken();
            CRM_ORDER_TT cxmodel = new CRM_ORDER_TT();
            cxmodel.ORDERTTID = ORDERTTID;
            CRM_ORDER_TT[] data = crmModels.ORDER_TT.ReadTTbyParam(cxmodel, 0, 0, 0, token);
            if (data.Length != 1)
            {
                webmsg.KEY = 0;
                webmsg.MSG = "确认失败，无法找到唯一的订单";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }

            crmModels.ORDER_TT.UpdateOrderIsactive(ORDERTTID, 60, token);

            data[0].QRR = appClass.CRM_GetStaffid();
            data[0].QRSJ = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            data[0].ORDERTTID = ORDERTTID;
            int id = crmModels.ORDER_TT.UpdateTT(data[0], token);

            webmsg.KEY = id;
            webmsg.MSG = "确认成功";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }





        [HttpPost]
        public ActionResult HHXXWH_PART(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_PRODUCT_HH model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_PRODUCT_HH>(cxdata);
            model.ISACTIVE = 1;
            CRM_PRODUCT_HH[] Data = crmModels.PRODUCT_HH.ReadByParam(model, appClass.CRM_GetStaffid(), token);
            ViewBag.Data = Data;
            return View();
        }
        [HttpPost]
        public ActionResult HHXXWH_PRODUCT_PART(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_PRODUCT_PRODUCT_HH[] HHdata = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_PRODUCT_PRODUCT_HH[]>(cxdata);
            ViewBag.HHdata = HHdata;
            return View();
        }
        [HttpPost]
        public ActionResult HHXXWH_PRODUCT_PART2(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_PRODUCT_PRODUCT_HH[] HHdata = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_PRODUCT_PRODUCT_HH[]>(cxdata);
            ViewBag.HHdata = HHdata;
            return View();
        }
        [HttpPost]
        public ActionResult HHXXWH_PRODUCT_PART3(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            MES_SY_MATERIAL_SELECT HHdata = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_MATERIAL_SELECT>(cxdata);
            ViewBag.HHdata = HHdata.MES_SY_MATERIAL;
            return View();

        }
        [HttpPost]
        public ActionResult HHXXWH_KB_Part(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_PRODUCT_KB model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_PRODUCT_KB>(cxdata);
            model.ISACTIVE = 1;
            CRM_PRODUCT_KB[] HHdata = crmModels.PRODUCT_KB.ReadByParam(model, token);
            ViewBag.HHdata = HHdata;
            return View();

        }
        public ActionResult SelectKADD(string data)
        {

            token = appClass.CRM_Gettoken();
            CRM_ORDER_TT selectdata = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_ORDER_TT>(data);
            selectdata.OrderST2 = 1;
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            STAFFID = 0;//校验 
            CRM_ORDER_TT[] res = crmModels.ORDER_TT.ReadTTbyParam(selectdata, STAFFID, 0, 1, token);
            ViewBag.TTdata = res;
            return PartialView();
        }
        public string SelectORDER_TT(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_ORDER_TT selectdata = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_ORDER_TT>(data);
            selectdata.OrderST2 = 1;
            selectdata.FuntionTYPE = "KA";
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            //STAFFID = 0;//校验 
            CRM_ORDER_TT[] res = crmModels.ORDER_TT.ReadTTbyParam(selectdata, STAFFID, 0, 1, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(res);
        }

        public ActionResult ShowPDF()
        {
            CRM_ORDER_TT[] ttdata = (CRM_ORDER_TT[])Session["KAOrerData"];
            List<string> pathList = (List<string>)Session["KAOrerPdfPath"];
            List<byte[]> streamlist = (List<byte[]>)Session["KAOderPdfStream"];
            string outputpath = appClass.GetTimeStamp() + ".pdf";
            PdfHelper.mergePDFFilesByStream(streamlist, AppDomain.CurrentDomain.BaseDirectory + "/Temp/Po/" + outputpath);

            ViewBag.TTdata = ttdata;
            ViewBag.pathList = pathList;
            ViewBag.outputpath = outputpath;

            return View();
        }
        public string Delect_PDF(string path)
        {
            string c = path.Split('/').Last();
            path = AppDomain.CurrentDomain.BaseDirectory + "/Temp/Po/" + path.Split('/').Last();
            System.IO.File.Delete(path);
            return "";
        }
        /// <summary>									
        /// FileContentResult方式下载									
        /// </summary>									
        /// <returns></returns>									
        public string GetFileByContent(string data)
        {
            string yc = "";
            try
            {
                List<string> pathList = new List<string>();
                List<byte[]> streamlist = new List<byte[]>();
                CRM_ORDER_TT[] ttdata = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_ORDER_TT[]>(data);
                token = appClass.CRM_Gettoken();
                for (int i = 0; i < ttdata.Length; i++)
                {

                    byte[] FileContent = crmModels.CRM_DRF.DownloadPDF(ttdata[i].PDFPATH, token);
                    int id = crmModels.ORDER_TT.AddPrintCount(ttdata[i].ORDERTTID, token);
                    //string downpath = AppDomain.CurrentDomain.BaseDirectory + "/Temp/PO/" + ttdata[i].PDFPATH;
                    //FileInfo fi = new FileInfo(downpath);
                    //if (!fi.Exists)
                    //{
                    //    MemoryStream memoryStream = new MemoryStream();
                    //    memoryStream.Write(FileContent, 0, FileContent.Length);
                    //    FileStream file = new FileStream(downpath, FileMode.Create);
                    //    file.Write(memoryStream.ToArray(), 0, (memoryStream.ToArray()).GetLength(0));
                    //    file.Close();

                    //}
                    if (FileContent == null)
                    {
                        yc = "网络有异常无法获取PDF信息";
                        return yc;
                    }
                    streamlist.Add(FileContent);
                    //pathList.Add(downpath);
                }

                Session["KAOrerPdfPath"] = pathList;
                Session["KAOderPdfStream"] = streamlist;
                Session["KAOrerData"] = ttdata;
            }
            catch (Exception e)
            {

                return e.Message;
            }

            return "";

        }
        public string DownFileByContent(string data)
        {
            //try
            //{
            //    List<string> pathList = new List<string>();
            //    CRM_ORDER_TT[] ttdata = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_ORDER_TT[]>(data);
            //    token = appClass.CRM_Gettoken();
            //    if (ttdata.Length > 0)
            //    {
            //        for (int i = 0; i < ttdata.Length; i++)
            //        {

            //            byte[] FileContent = crmModels.CRM_DRF.DownloadPDF(ttdata[i].PDFPATH, token);
            //            string downpath = AppDomain.CurrentDomain.BaseDirectory + "/Temp/PO/" + ttdata[i].PDFPATH;
            //            FileInfo fi = new FileInfo(downpath);
            //            if (!fi.Exists)
            //            {
            //                MemoryStream memoryStream = new MemoryStream();
            //                memoryStream.Write(FileContent, 0, FileContent.Length);
            //                FileStream file = new FileStream(downpath, FileMode.Create);
            //                file.Write(memoryStream.ToArray(), 0, (memoryStream.ToArray()).GetLength(0));
            //                file.Close();

            //            }
            //            pathList.Add(downpath);
            //        }
            //        string outputpath = appClass.GetTimeStamp() + ".pdf";
            //        string totalPath = AppDomain.CurrentDomain.BaseDirectory + "\\Temp\\Po\\" + outputpath;
            //        PdfHelper.mergePDFFiles(pathList, AppDomain.CurrentDomain.BaseDirectory + "/Temp/Po/" + outputpath);
            //        Session["downPDF"] = totalPath;
            //        Session["filename"] = outputpath;
            //        return totalPath;
            //    }               			
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
            return "";
        }
        public FileResult DownLoadPDF()
        {
            string path = (string)Session["downPDF"];
            byte[] bytes = PdfHelper.GetFileData(path);
            string filename = (string)Session["filename"];
            return File(bytes, "application/octet-stream", filename);

        }
        public string SELECT_ORDERSH_TT(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_ORDER_SH node = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_ORDER_SH>(data);
            CRM_ORDER_SH[] res = crmModels.ORDER_SH.Report(node, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(res);
        }
        public string SELECT_ORDERSH_MX(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_ORDER_SH node = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_ORDER_SH>(data);

            CRM_ORDER_SH[] res = crmModels.ORDER_SH.ReadByParam(node, token);

            return Newtonsoft.Json.JsonConvert.SerializeObject(res);
        }

        public string DR_SHBG(int type)
        {

            token = appClass.CRM_Gettoken();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_RETURN_UI mr = new MES_RETURN_UI();
            if (type == 0)
            {
                return "{\"code\":100,\"msg\":\"订单来源不能为空\",\"scr\":\"\"}";
            }
            var file = Request.Files[0];
            string msg = "";
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
                //开始做数据校验
                DataTable data = ExcelToDataTable(savePath, 0, true);
                try
                {
                    System.IO.File.Delete(savePath);//md5使用的时候暂时不删
                }
                catch //(Exception e)
                {
                    //throw;
                }
                if (data != null)
                {
                    List<CRM_ORDER_SH> drList = new List<CRM_ORDER_SH>();
                    List<string> strlist = new List<string>();
                    //string[] columnsName = new string[] { "店别 ", "订单号码 ", "货号 ", "品名 ", "单品开票价 ", "订单日期 ", "订购数量 ", "实收数量 ", "实际收货日 " };

                    string[] columnsName = new string[] { "店别", "订单号码", "货号", "品名", "单品开票价", "订单日期", "订购数量", "实收数量", "实际收货日" };
                    try
                    {
                        //做数据验证
                        if (data.Rows.Count > 0)
                        {

                            for (int i = 0; i < columnsName.Length; i++)
                            {
                                if (!data.Columns.Contains(columnsName[i]))
                                {
                                    return "{\"code\":100,\"msg\":\"请使用正确的收货报告的excel\",\"scr\":\"\"}";
                                }

                            }

                            List<CRM_ORDER_SH> nodes = new List<CRM_ORDER_SH>();
                            for (int i = 0; i < data.Rows.Count; i++)
                            {
                                if (data.Rows[i]["店别"].ToString().Split('.').Length == 1 && string.IsNullOrEmpty(data.Rows[i]["订单号码"].ToString()) && string.IsNullOrEmpty(data.Rows[i]["货号"].ToString()))
                                {
                                }
                                else
                                {
                                    int index = 0;
                                    CRM_ORDER_SH node = new CRM_ORDER_SH();

                                    if (data.Rows[i][columnsName[index]].ToString().Split('.').Length > 1)
                                    {
                                        node.OrderSrc = type;
                                        node.CJR = STAFFID;
                                        node.StoreNum = data.Rows[i][columnsName[index]].ToString().Split('.')[0];
                                        node.KHNAME = data.Rows[i][columnsName[index++]].ToString().Split('.')[1];
                                        node.KHPO = data.Rows[i][columnsName[index++]].ToString();
                                        node.ProdNum = data.Rows[i][columnsName[index++]].ToString();
                                        node.ProdName = data.Rows[i][columnsName[index++]].ToString();
                                        node.PRICE = Convert.ToDecimal(data.Rows[i][columnsName[index++]].ToString());
                                        node.OrderDate = Convert.ToDateTime(data.Rows[i][columnsName[index++]]).ToString("yyyy-MM-dd");//订单日期 
                                        node.DDSL = Convert.ToInt32(data.Rows[i][columnsName[index++]].ToString());
                                        node.SJSL = Convert.ToInt32(data.Rows[i][columnsName[index++]].ToString());
                                        node.SHDate = Convert.ToDateTime(data.Rows[i][columnsName[index]]).ToString("yyyy-MM-dd");//实际收货日 
                                        nodes.Add(node);
                                    }
                                    else
                                    {
                                        return "{\"code\":100,\"msg\":\"店号字段异常\",\"scr\":\"\"}";
                                    }
                                }
                            }
                            mr = crmModels.ORDER_SH.Modify(nodes, token);
                            msg = mr.MESSAGE;

                        }

                    }
                    catch (Exception e)
                    {
                        msg = e.Message;
                        //throw;
                    }

                }
            }
            if (mr.TYPE == "S")
            {
                return "{\"code\":200,\"msg\":\"" + msg + "\",\"scr\":\"\"}"; ;
            }

            return "{\"code\":100,\"msg\":\"" + msg + "\",\"scr\":\"\"}";
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
            catch //(Exception e)
            {
                // throw;
                //MessageBox.Show("Exception: " + ex.Message);
                return null;
            }
        }


        public ActionResult CreateOrder()
        {
            Session["location"] = 1004;
            token = appClass.CRM_Gettoken();
            CRM_PRODUCT_PRODUCT_HH cx_cxp = new CRM_PRODUCT_PRODUCT_HH();
            cx_cxp.ProdName = "促销品";
            CRM_PRODUCT_PRODUCT_HH[] CXP = crmModels.PRODUCT_PRODUCT_HH.ReadByParam(cx_cxp, token);
            ViewBag.CXP = CXP;
            MES_MM_CK model = new MES_MM_CK();
            model.ROLENAME = "1000-KA仓库";
            MES_MM_CK_SELECT data = mesModels.MM_CK.SELECT_BY_ROLE_ASSEMBLE(model, token);
            ViewBag.KCDD = data.MES_MM_CK;
            return View();
        }

        [HttpPost]
        public string Check_Order(string code, int Checked)
        {
            token = appClass.CRM_Gettoken();
            string MDBH = code.Substring(0, 3);
            string KHPO = code.Substring(3, 9);
            CRM_ORDER_TT cxmodel = new CRM_ORDER_TT();
            MDBH = MDBH.TrimStart('0');
            cxmodel.KHPO = KHPO;
            cxmodel.StoreNum = MDBH;
            CRM_ORDER_TT[] data = crmModels.ORDER_TT.ReadTTbyParam(cxmodel, 0, 0, 0, token);
            if (data.Length == 0)
            {
                webmsg.KEY = 0;
                webmsg.MSG = "找不到该订单信息";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }
            else if (data.Length > 1)
            {
                //有多行，需要返回前端去选择一行
                webmsg.KEY = 2;
                webmsg.MSG = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }
            else
            {
                //就一行
                webmsg.KEY = 1;
                webmsg.MSG = "";
                return Check_SAP_Order(Newtonsoft.Json.JsonConvert.SerializeObject(data[0]), Checked);

                //}

            }
        }

        [HttpPost]
        public string Check_SAP_Order(string datastr, int Checked)
        {
            token = appClass.CRM_Gettoken();
            CRM_ORDER_TT data = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_ORDER_TT>(datastr);


            if (data.KHID == 0)
            {
                //需要更新订单的信息
                WebMSG temp = CheckUpdate_ORDERTT(data);
                if (temp.KEY == 0)
                {
                    return Newtonsoft.Json.JsonConvert.SerializeObject(temp);
                }
            }






            if (data.SAPORDER == "")
            {
                //没有提交过SAP
                return Check_Checked(data.ORDERTTID, Checked);
            }
            else
            {
                //已经提过SAP，要去sap看一下是不是有异常状态

                ZSL_BCS111 IS_HEADDATA = new ZSL_BCS111();
                IS_HEADDATA.KUNAG = data.KHSAP;
                IS_HEADDATA.BSTNK = data.KHPO;
                MES_RETURN_UI result = crmModels.WS_BC_DRF.ZBCFUN_DRFDD_CHK(IS_HEADDATA, token);
                if (result.TYPE == "S")
                {
                    //SAP订单被删除，可以重新提
                    return Check_Checked(data.ORDERTTID, Checked);
                }
                else
                {
                    //SAP订单没有异常，说明订单是创建了的，需要返回报错
                    webmsg.KEY = 0;
                    webmsg.MSG = result.MESSAGE;
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }


            }
            //return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        public string Check_Checked(int ORDERTTID, int Checked)
        {
            token = appClass.CRM_Gettoken();
            CRM_ORDER_TT cxmodel = new CRM_ORDER_TT();
            cxmodel.ORDERTTID = ORDERTTID;
            CRM_ORDER_TT data = crmModels.ORDER_TT.ReadTTbyParam(cxmodel, 0, 0, 0, token)[0];
            CRM_ORDER_MX cxmx = new CRM_ORDER_MX();
            cxmx.ORDERTTID = data.ORDERTTID;
            CRM_ORDER_MX[] MXdata = crmModels.ORDER_TT.ReadMXbyParam(cxmx, token);

            if (data.StoreNews.Trim() != "")
            {
                //有快报，按（快报+货号）找物料
                for (int i = 0; i < MXdata.Length; i++)
                {

                    //本来是根据货号关联的物料来取，现在改成根据快报对应的物料取
                    CRM_PRODUCT_KBMX cx_conn = new CRM_PRODUCT_KBMX();
                    cx_conn.KBMC = data.StoreNews;
                    cx_conn.CPHH = MXdata[i].ProdNum;
                    cx_conn.OrderSrc = data.OrderSrc;
                    CRM_PRODUCT_KBMX[] Conn = crmModels.PRODUCT_KBMX.ReadByParam(cx_conn, token);

                    if (Checked == 1)
                    {
                        //勾了,这里要先去校验这个订单下的产品是否对应多个SAP物料
                        //if (Conn.Length > 1)
                        //{
                        //    webmsg.KEY = 0;
                        //    webmsg.MSG = "行项目" + MXdata[i].OrderItem + "存在多个关联的物料";
                        //    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                        //}
                        //else if (Conn.Length == 0)
                        //{
                        //    webmsg.KEY = 0;
                        //    webmsg.MSG = "行项目" + MXdata[i].OrderItem + "没有关联的物料";
                        //    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                        //}
                        if (Conn.Length != 1)
                        {
                            //有多行，需要返回前端去选择一行
                            webmsg.KEY = 3;
                            webmsg.MSG = "";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                        }
                    }

                    //更新订单明细里面与(快报+货号)一对一的SAP物料号
                    if (Conn.Length == 1)
                    {
                        if (MXdata[i].ISCXP == 0)// && MXdata[i].DDDW == ""   //更新非促销品的行项目 订单单位为空表示是未更新的，非促销且订单单位非空的话说明是被拆分的数据
                        {
                            CRM_KH_KHList KH = crmModels.KH_KH.Read(data.KHID, token);



                            //MXdata[i].PRODUCTID = Conn[0].PRODUCTID;
                            MXdata[i].CPPH = Conn[0].WLBM;
                            MXdata[i].CPMC = Conn[0].WLMS;
                            MXdata[i].DDDW = Conn[0].DDDW;
                            MXdata[i].KCDD = KH.KCDD == "" ? "2016" : KH.KCDD;
                            int ii = crmModels.ORDER_TT.UpdateMX_WLinfo(MXdata[i], 0, token);
                        }
                        else if (MXdata[i].ISCXP == 1)
                        {
                            //促销品的话直接删掉，还原成最开始的状态
                            int ii = crmModels.ORDER_TT.DeleteMX(MXdata[i].ORDERMXID, appClass.CRM_GetStaffid(), token);
                        }

                    }
                    else if (Conn.Length > 1)
                    {
                        MXdata[i].CPPH = "";
                        MXdata[i].CPMC = "";
                        MXdata[i].DDDW = "";
                        MXdata[i].KCDD = "";
                        int ii = crmModels.ORDER_TT.UpdateMX_WLinfo(MXdata[i], 0, token);
                    }

                }
            }
            else
            {
                //没有快报，按货号去找物料
                for (int i = 0; i < MXdata.Length; i++)
                {
                    //本来是根据货号关联的物料来取，现在改成根据快报对应的物料取
                    CRM_PRODUCT_PRODUCT_HH cx_conn = new CRM_PRODUCT_PRODUCT_HH();
                    cx_conn.ProdNum = MXdata[i].ProdNum;
                    cx_conn.OrderSrc = data.OrderSrc;
                    CRM_PRODUCT_PRODUCT_HH[] Conn = crmModels.PRODUCT_PRODUCT_HH.ReadByProNum(cx_conn, token);


                    if (Checked == 1)
                    {
                        //勾了,这里要先去校验这个订单下的产品是否对应多个SAP物料
                        //if (Conn.Length > 1)
                        //{
                        //    webmsg.KEY = 0;
                        //    webmsg.MSG = "行项目" + MXdata[i].OrderItem + "存在多个关联的物料";
                        //    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                        //}
                        //else if (Conn.Length == 0)
                        //{
                        //    webmsg.KEY = 0;
                        //    webmsg.MSG = "行项目" + MXdata[i].OrderItem + "没有关联的物料";
                        //    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                        //}
                        if (Conn.Length != 1)
                        {
                            //有多行，需要返回前端去选择一行
                            webmsg.KEY = 3;
                            webmsg.MSG = "";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                        }
                    }

                    //更新订单明细里面与货号一对一的SAP物料号
                    if (Conn.Length == 1)
                    {
                        if (MXdata[i].ISCXP == 0)// && MXdata[i].DDDW == ""   //更新非促销品的行项目 订单单位为空表示是未更新的，非促销且订单单位非空的话说明是被拆分的数据
                        {
                            CRM_KH_KHList KH = crmModels.KH_KH.Read(data.KHID, token);



                            //MXdata[i].PRODUCTID = Conn[0].PRODUCTID;
                            MXdata[i].CPPH = Conn[0].CPPH;
                            MXdata[i].CPMC = Conn[0].SAPMX;
                            MXdata[i].DDDW = Conn[0].DDDW;
                            MXdata[i].KCDD = KH.KCDD == "" ? "2016" : KH.KCDD;
                            int ii = crmModels.ORDER_TT.UpdateMX_WLinfo(MXdata[i], 0, token);
                        }
                        else if (MXdata[i].ISCXP == 1)
                        {
                            //促销品的话直接删掉，还原成最开始的状态
                            int ii = crmModels.ORDER_TT.DeleteMX(MXdata[i].ORDERMXID, appClass.CRM_GetStaffid(), token);
                        }

                    }
                    else if (Conn.Length > 1)
                    {
                        MXdata[i].CPPH = "";
                        MXdata[i].CPMC = "";
                        MXdata[i].DDDW = "";
                        MXdata[i].KCDD = "";
                        int ii = crmModels.ORDER_TT.UpdateMX_WLinfo(MXdata[i], 0, token);
                    }

                }
            }



            if (Checked == 1)
            {
                CRM_KH_XSQYSJ XSQY = crmModels.KH_HZHB.ReadBySAPSN(data.KHSAP, token);
                SAP_CompanyInfo[] HZHBdata = crmModels.SAP_ORDER.ShipToParty(data.KHSAP, XSQY.XSZZ, XSQY.FXQD, XSQY.CPZ, token);

                if (HZHBdata.Length == 1)
                {
                    //能到这儿，说明都是一对一的物料，可以创建订单了
                    return Create_Order(data.ORDERTTID, DateTime.Now.ToString("yyyy-MM-dd"), HZHBdata[0].SerialNumber);
                }
                else
                {
                    //有多个送达方,前端带出订单信息
                    webmsg.KEY = 3;
                    webmsg.MSG = "";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }


            }
            else
            {
                //没勾,前端带出订单信息
                webmsg.KEY = 3;
                webmsg.MSG = "";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }


            //if (Checked == 1)
            //{
            //    //勾了,这里要先去校验这个订单下的产品是否对应多个SAP物料
            //    CRM_ORDER_MX cxmx = new CRM_ORDER_MX();
            //    cxmx.ORDERTTID = data.ORDERTTID;
            //    CRM_ORDER_MX[] MXdata = crmModels.ORDER_TT.ReadMXbyParam(cxmx, token);
            //    for (int i = 0; i < MXdata.Length; i++)
            //    {
            //        CRM_PRODUCT_PRODUCT_HH cx_conn = new CRM_PRODUCT_PRODUCT_HH();
            //        cx_conn.ProdNum = MXdata[i].ProdNum;
            //        CRM_PRODUCT_PRODUCT_HH[] Conn = crmModels.PRODUCT_PRODUCT_HH.ReadByParam(cx_conn, token);
            //        if (Conn.Length > 1)
            //        {
            //            webmsg.KEY = 0;
            //            webmsg.MSG = "行项目" + MXdata[i].OrderItem + "存在多个关联的物料";
            //            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            //        }
            //        else if (Conn.Length == 0)
            //        {
            //            webmsg.KEY = 0;
            //            webmsg.MSG = "行项目" + MXdata[i].OrderItem + "没有关联的物料";
            //            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            //        }

            //    }

            //    //能到这儿，说明都是一对一的物料，可以创建订单了
            //    return Create_Order(data.ORDERTTID);


            //}
            //else
            //{
            //    //没勾,前端带出订单信息
            //    webmsg.KEY = 3;
            //    webmsg.MSG = "";
            //    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            //}

        }

        [HttpPost]
        public string Create_Order(int ORDERTTID, string date, string KUNNR)
        {
            token = appClass.CRM_Gettoken();

            try
            {
                CRM_ORDER_TT cxmodel = new CRM_ORDER_TT();
                cxmodel.ORDERTTID = ORDERTTID;
                CRM_ORDER_TT data = crmModels.ORDER_TT.ReadTTbyParam(cxmodel, 0, 0, 0, token)[0];

                //第一步先看订单有没有锁
                if (data.ISLOCK == 1)
                {
                    webmsg.KEY = 0;
                    webmsg.MSG = "订单被锁定，请稍后操作！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }



                //然后就锁掉
                crmModels.ORDER_TT.UpdateOrder_LOCK(ORDERTTID, 1, token);




                CRM_ORDER_MX cxmx = new CRM_ORDER_MX();
                cxmx.ORDERTTID = ORDERTTID;
                cxmx.ReadyForSAP = 1;
                CRM_ORDER_MX[] MXdata = crmModels.ORDER_TT.ReadMXbyParam(cxmx, token);
                //创建订单
                ZSL_BCS111 IS_HEADDATA = new ZSL_BCS111();
                IS_HEADDATA.KUNAG = data.KHSAP;
                IS_HEADDATA.KUNNR = KUNNR;
                IS_HEADDATA.BSTNK = data.KHPO;
                IS_HEADDATA.BSTDK = date;
                IS_HEADDATA.ORDERST = data.OrderST.ToString();

                ZSL_BCS112[] IT_ITEMDATA = new ZSL_BCS112[MXdata.Length];
                for (int i = 0; i < MXdata.Length; i++)
                {
                    IT_ITEMDATA[i] = new ZSL_BCS112();
                    IT_ITEMDATA[i].MATNR = MXdata[i].CPPH;
                    IT_ITEMDATA[i].KWMENG = Math.Abs(MXdata[i].DDSL);
                    IT_ITEMDATA[i].VRKME = MXdata[i].DDDW;
                    IT_ITEMDATA[i].POSNR = MXdata[i].OrderItem;
                    IT_ITEMDATA[i].LGORT = MXdata[i].KCDD == "" ? "2016" : MXdata[i].KCDD; ;
                    IT_ITEMDATA[i].FOC = MXdata[i].ISCXP == 1 ? "X" : "";
                }

                ZBCFUN_DRFDD_CRT_RETURN result = crmModels.WS_BC_DRF.ZBCFUN_DRFDD_CRT(IS_HEADDATA, IT_ITEMDATA, token);
                if (result.MES_RETURN.TYPE == "S")
                {
                    //回写SAP订单号
                    CRM_ORDER_TT ordermodel = new CRM_ORDER_TT();
                    ordermodel.ORDERTTID = ORDERTTID;
                    ordermodel.SUCCESS = 1;
                    ordermodel.SAPORDER = result.ES_ORDERDATA.VBELN;
                    ordermodel.KHPO = data.KHPO;
                    ordermodel.JHD = result.ES_ORDERDATA.VBELN_VL;
                    int i = crmModels.ORDER_TT.UpdateOrder_SAPORDER(ordermodel, token);

                    webmsg.KEY = 1;
                    webmsg.MSG = result.MES_RETURN.MESSAGE;
                }
                else
                {
                    webmsg.KEY = 0;
                    webmsg.MSG = result.MES_RETURN.MESSAGE;
                }


                crmModels.ORDER_TT.UpdateOrderIsactive(ORDERTTID, 60, token);

                data.QRR = appClass.CRM_GetStaffid();
                data.QRSJ = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                crmModels.ORDER_TT.UpdateTT(data, token);

                //最后不要忘了解锁订单
                crmModels.ORDER_TT.UpdateOrder_LOCK(ORDERTTID, 0, token);

                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }
            catch (Exception e)
            {
                //以防万一，catch里面解锁订单
                crmModels.ORDER_TT.UpdateOrder_LOCK(ORDERTTID, 0, token);
                webmsg.KEY = 0;
                webmsg.MSG = e.Message;
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }


        }
        [HttpPost]
        public string Select_ProductBySAPMC(string cxdate)
        {
            token = appClass.CRM_Gettoken();
            CRM_PRODUCT_PRODUCT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_PRODUCT_PRODUCT>(cxdate);
            CRM_PRODUCT_PRODUCT[] data = crmModels.PRODUCT_PRODUCT.ReadByParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Select_KAOrder(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_ORDER_TT cxmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_ORDER_TT>(cxdata);
            CRM_ORDER_TT[] data = crmModels.ORDER_TT.ReadTTbyParam(cxmodel, 0, 0, 0, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Select_KAOrderMX(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_ORDER_MX cxmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_ORDER_MX>(cxdata);
            CRM_ORDER_MX[] data = crmModels.ORDER_TT.ReadMXbyParam(cxmodel, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_UpdateMX_WLinfo(string data, string value)
        {
            //参数里面的value是以 物料编号|物料描述|订单单位 的格式拼接起来的
            token = appClass.CRM_Gettoken();
            CRM_ORDER_MX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_ORDER_MX>(data);


            if (value == "0")
            {
                model.CPPH = "";
                model.CPMC = "";
                model.DDDW = "";
                int i = crmModels.ORDER_TT.UpdateMX_WLinfo(model, appClass.CRM_GetStaffid(), token);
                if (i > 0)
                {
                    webmsg.KEY = i;
                    webmsg.MSG = "修改成功！";
                }
                else
                {
                    webmsg.KEY = 0;
                    webmsg.MSG = "修改失败！";
                }
            }
            else
            {
                string[] val = value.Split('|');
                if (val.Length != 3)
                {
                    webmsg.KEY = 0;
                    webmsg.MSG = "数据格式不正确！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
                model.CPPH = val[0].Trim();
                model.CPMC = val[1].Trim();
                model.DDDW = val[2].Trim();
                int i = crmModels.ORDER_TT.UpdateMX_WLinfo(model, appClass.CRM_GetStaffid(), token);
                if (i > 0)
                {
                    webmsg.KEY = i;
                    webmsg.MSG = "修改成功！";
                }
                else
                {
                    webmsg.KEY = 0;
                    webmsg.MSG = "修改失败！";
                }
            }



            //CRM_PRODUCT_PRODUCT_HH cxcp = new CRM_PRODUCT_PRODUCT_HH();
            //cxcp.ID = ID;
            //CRM_PRODUCT_PRODUCT_HH[] CP = crmModels.PRODUCT_PRODUCT_HH.ReadByParam(cxcp, token);

            //if (ID == 0)
            //{
            //    model.CPPH = "";
            //    model.CPMC = "";
            //    model.DDDW = "";
            //    int i = crmModels.ORDER_TT.UpdateMX_WLinfo(model, token);
            //    if (i > 0)
            //    {
            //        webmsg.KEY = i;
            //        webmsg.MSG = "修改成功！";
            //    }
            //    else
            //    {
            //        webmsg.KEY = 0;
            //        webmsg.MSG = "修改失败！";
            //    }
            //}
            //else
            //{
            //    if (CP.Length == 1)
            //    {
            //        model.CPPH = CP[0].CPPH;
            //        model.CPMC = CP[0].SAPMX;
            //        model.DDDW = CP[0].DDDW;
            //        int i = crmModels.ORDER_TT.UpdateMX_WLinfo(model, token);
            //        if (i > 0)
            //        {
            //            webmsg.KEY = i;
            //            webmsg.MSG = "修改成功！";
            //        }
            //        else
            //        {
            //            webmsg.KEY = 0;
            //            webmsg.MSG = "修改失败！";
            //        }
            //    }
            //    else
            //    {
            //        webmsg.KEY = 0;
            //        webmsg.MSG = "修改失败！";
            //    }
            //}



            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public ActionResult Select_KAOrderMX(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_ORDER_MX cxmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_ORDER_MX>(cxdata);
            CRM_ORDER_MX[] data = crmModels.ORDER_TT.ReadMXbyParam(cxmodel, token);
            ViewBag.MXdata = data;
            return View();
        }

        [HttpPost]
        public string Select_MultiProduct(string ProdNum, string StoreNews, int OrderSrc)
        {
            token = appClass.CRM_Gettoken();
            CRM_PRODUCT_PRODUCT_HH cxmodel1 = new CRM_PRODUCT_PRODUCT_HH();
            cxmodel1.ProdNum = ProdNum;
            cxmodel1.OrderSrc = OrderSrc;
            CRM_PRODUCT_PRODUCT_HH[] data1 = crmModels.PRODUCT_PRODUCT_HH.ReadByProNum(cxmodel1, token);




            List<CRM_PRODUCT_PRODUCT_HH> data = new List<CRM_PRODUCT_PRODUCT_HH>();
            for (int i = 0; i < data1.Length; i++)
            {
                CRM_PRODUCT_PRODUCT_HH temp = new CRM_PRODUCT_PRODUCT_HH();
                temp.CPPH = data1[i].CPPH;
                temp.SAPMX = data1[i].SAPMX;
                temp.DDDW = data1[i].DDDW;

                int tempint = 0;
                for (int j = 0; j < data.Count; j++)
                {
                    if (data[j].CPPH == data1[i].CPPH)
                    {
                        tempint = 1;
                    }
                }
                if (tempint == 0)
                    data.Add(temp);

            }

            if (StoreNews != "")
            {
                CRM_PRODUCT_KBMX cxmodel2 = new CRM_PRODUCT_KBMX();
                cxmodel2.KBMC = StoreNews;
                cxmodel2.CPHH = ProdNum;
                cxmodel2.OrderSrc = OrderSrc;
                CRM_PRODUCT_KBMX[] data2 = crmModels.PRODUCT_KBMX.ReadByParam(cxmodel2, token);

                for (int i = 0; i < data2.Length; i++)
                {
                    CRM_PRODUCT_PRODUCT_HH temp = new CRM_PRODUCT_PRODUCT_HH();
                    temp.CPPH = data2[i].WLBM;
                    temp.SAPMX = data2[i].WLMS;
                    temp.DDDW = data2[i].DDDW;

                    int tempint = 0;
                    for (int j = 0; j < data.Count; j++)
                    {
                        if (data[j].CPPH == data2[i].WLBM)
                        {
                            tempint = 1;
                        }
                    }
                    if (tempint == 0)
                        data.Add(temp);


                }

            }





            //ViewBag.data = data;
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        private WebMSG CheckUpdate_ORDERTT(CRM_ORDER_TT data)
        {
            token = appClass.CRM_Gettoken();
            //CRM_ORDER_TT cxmodel = new CRM_ORDER_TT();
            //cxmodel.ORDERTTID = ORDERTTID;
            //CRM_ORDER_TT data = crmModels.ORDER_TT.ReadTTbyParam(cxmodel, 0, 0, 0, token)[0];

            //根据订单来源的上级和门店编号查询客户
            CRM_HG_DICT cxdict = new CRM_HG_DICT();
            cxdict.DICID = data.OrderSrc;
            CRM_HG_DICT[] DICT = crmModels.HG_DICT.ReadByParam(cxdict, 0, token);
            if (DICT.Length != 0)
            {
                //!!!改改改 华东大润发的来源要同时查大润发的GID和欧尚的GID
                int found = 1;
                string[] PP_GID = DICT[0].PP.Split(',');
                for (int j = 0; j < PP_GID.Length; j++)
                {


                    CRM_Report_KHModel cxkh = new CRM_Report_KHModel();
                    cxkh.GID = Convert.ToInt32(PP_GID[j]);
                    cxkh.BEIZ = data.StoreNum;
                    CRM_KH_KHList[] KH = crmModels.KH_KH.Report(cxkh, 0, token);
                    if (KH.Length == 1)
                    {
                        data.KHID = KH[0].KHID;
                        data.KHSAP = KH[0].SAPSN;
                        data.SDFID = KH[0].SAPSN;
                        data.SDFNAME = KH[0].MC;

                        int i = crmModels.ORDER_TT.UpdateTT_KHinfo(data, token);

                        webmsg.KEY = 1;
                        return webmsg;
                    }
                    else if (KH.Length == 0)
                    {
                        found = 0;
                    }


                }

                if (found == 0)
                {
                    webmsg.KEY = 0;
                    webmsg.MSG = "找不到客户";
                }
                else
                {
                    webmsg.KEY = 0;
                    webmsg.MSG = "查询客户结果异常";
                }

                return webmsg;





            }
            else
            {
                webmsg.KEY = 0;
                webmsg.MSG = "更新客户信息失败";
                return webmsg;
            }



            //if (data.Length == 1)
            //{
            //    if (data[0].KHID == 0)
            //    {
            //        //说明订单从S1同步过来还没有更新过客户信息



            //    }
            //    else
            //    {
            //        //已经更新过客户信息，什么都不用干
            //    }
            //}
            //else
            //{

            //}
        }
        [HttpPost]
        public string Select_HHXXWH(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_PRODUCT_HH model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_PRODUCT_HH>(cxdata);
            model.ISACTIVE = 1;
            CRM_PRODUCT_HH[] data = crmModels.PRODUCT_HH.ReadByParam(model, appClass.CRM_GetStaffid(), token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }
        [HttpPost]
        public string Select_HHXXWH_KB(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_PRODUCT_KB model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_PRODUCT_KB>(cxdata);
            model.ISACTIVE = 1;
            CRM_PRODUCT_KB[] data = crmModels.PRODUCT_KB.ReadByParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Delete_OrderMX(int ORDERMXID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.ORDER_TT.DeleteMX(ORDERMXID, appClass.CRM_GetStaffid(), token);
            if (i > 0)
            {
                webmsg.KEY = i;
                webmsg.MSG = "删除成功";
            }
            else
            {
                webmsg.KEY = 0;
                webmsg.MSG = "删除失败";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Insert_HHXXWH(string data1, string data2)
        {
            token = appClass.CRM_Gettoken();
            CRM_PRODUCT_HH model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_PRODUCT_HH>(data1);

            CRM_PRODUCT_HH CXMODEL = new CRM_PRODUCT_HH();
            CXMODEL.SY = model.SY;
            CXMODEL.ProdNum = model.ProdNum;
            CRM_PRODUCT_HH[] CXDATA = crmModels.PRODUCT_HH.ReadByParam(CXMODEL, 0, token);

            if (CXDATA.Length > 0)
            {
                webmsg.KEY = 0;
                webmsg.MSG = "同一个订单来源+货号，不能重复创建";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }




            model.CJR = appClass.CRM_GetStaffid();
            model.XGR = appClass.CRM_GetStaffid();
            model.ISACTIVE = 1;
            int z = crmModels.PRODUCT_HH.Create(model, token);
            if (z > 0)
            {
                CRM_PRODUCT_PRODUCT_HH[] model2 = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_PRODUCT_PRODUCT_HH[]>(data2);

                for (int i = 0; i < model2.Length; i++)
                {
                    CRM_PRODUCT_PRODUCT_HH NMODEL = new CRM_PRODUCT_PRODUCT_HH();

                    NMODEL.CPPH = model2[i].CPPH;
                    NMODEL.HHID = z;
                    NMODEL.DDDW = model2[i].DDDW;
                    NMODEL.BEGINDATE = model2[i].BEGINDATE;
                    NMODEL.ENDDATE = model2[i].ENDDATE;

                    int x = crmModels.PRODUCT_PRODUCT_HH.Create(NMODEL, token);

                    if (x == 0)
                    {
                        webmsg.KEY = x;
                        webmsg.MSG = "新增失败";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                    }

                }

                webmsg.KEY = z;
                webmsg.MSG = "新增成功";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);


            }
            else
            {
                webmsg.KEY = z;
                webmsg.MSG = "新增失败";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }
        }
        [HttpPost]
        public string Delete_HHXXWH(int HHID)
        {
            token = appClass.CRM_Gettoken();
            CRM_PRODUCT_HH CXMODEL = new CRM_PRODUCT_HH();
            CXMODEL.HHID = HHID;
            CXMODEL.XGR = appClass.CRM_GetStaffid();
            int i = crmModels.PRODUCT_HH.Delete(CXMODEL, token);
            if (i > 0)
            {
                CRM_PRODUCT_PRODUCT_HH model = new CRM_PRODUCT_PRODUCT_HH();
                model.HHID = HHID;
                CRM_PRODUCT_PRODUCT_HH[] data = crmModels.PRODUCT_PRODUCT_HH.ReadByParam(model, token);
                for (int j = 0; j < data.Length; j++)
                {


                    int y = crmModels.PRODUCT_PRODUCT_HH.Delete(data[j].ID, token);
                    if (y < 0)
                    {
                        webmsg.KEY = y;
                        webmsg.MSG = "删除成功";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                    }

                }

                webmsg.KEY = i;
                webmsg.MSG = "删除成功";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }
            else
            {
                webmsg.KEY = i;
                webmsg.MSG = "删除失败";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }

        }
        [HttpPost]
        public string Update_HHXXWH(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_PRODUCT_HH model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_PRODUCT_HH>(data);
            model.XGR = appClass.CRM_GetStaffid();
            int i = crmModels.PRODUCT_HH.Update(model, token);
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
        public string Insert_WLHHGLB(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_PRODUCT_PRODUCT_HH model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_PRODUCT_PRODUCT_HH>(cxdata);
            model.ISDELETE = 0;
            int x = crmModels.PRODUCT_PRODUCT_HH.Create(model, token);

            CRM_PRODUCT_PRODUCT_HH NNMODEL = new CRM_PRODUCT_PRODUCT_HH();
            NNMODEL.HHID = model.HHID;
            CRM_PRODUCT_PRODUCT_HH[] DATA = crmModels.PRODUCT_PRODUCT_HH.ReadByParam(NNMODEL, token);



            return Newtonsoft.Json.JsonConvert.SerializeObject(DATA);
        }
        [HttpPost]
        public string Select_WLHHGLB(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_PRODUCT_PRODUCT_HH model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_PRODUCT_PRODUCT_HH>(cxdata);
            model.ISDELETE = 0;
            CRM_PRODUCT_PRODUCT_HH[] data = crmModels.PRODUCT_PRODUCT_HH.ReadByParam(model, token);

            //  HHXXWH_PRODUCT_PART(data)

            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }
        [HttpPost]
        public string Update_WLHHGLB(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_PRODUCT_PRODUCT_HH model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_PRODUCT_PRODUCT_HH>(cxdata);
            int i = crmModels.PRODUCT_PRODUCT_HH.Update(model, token);
            if (i > 0)
            {
                CRM_PRODUCT_PRODUCT_HH NNMODEL = new CRM_PRODUCT_PRODUCT_HH();
                NNMODEL.HHID = model.HHID;
                CRM_PRODUCT_PRODUCT_HH[] data = crmModels.PRODUCT_PRODUCT_HH.ReadByParam(NNMODEL, token);
                return Newtonsoft.Json.JsonConvert.SerializeObject(data);


                //webmsg.KEY = i;
                //webmsg.MSG = "更新成功";

            }
            else
            {
                webmsg.KEY = i;
                webmsg.MSG = "更新失败";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }

        }
        [HttpPost]
        public string Delete_WLHHGLB(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_PRODUCT_PRODUCT_HH model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_PRODUCT_PRODUCT_HH>(cxdata);
            int i = crmModels.PRODUCT_PRODUCT_HH.Delete(model.ID, token);
            CRM_PRODUCT_PRODUCT_HH NNMODEL = new CRM_PRODUCT_PRODUCT_HH();
            NNMODEL.HHID = model.HHID;
            NNMODEL.ISDELETE = 0;
            CRM_PRODUCT_PRODUCT_HH[] data = crmModels.PRODUCT_PRODUCT_HH.ReadByParam(NNMODEL, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }



        public void DCMD5(string path, List<string> list)
        {
            FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);
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
            for (int i = 0; i < list.Count; i++)
            {
                cellIndex = 0;
                IRow row = sheet.CreateRow(rowcount++);
                row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(list[i]));


            }
            string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
            FileStream file1 = new FileStream(path, FileMode.Create);
            workbook.Write(file1);
            file1.Close();
        }
        public string EXPORT_KAORDER_SELECT(string data, int type)
        {
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_RETURN_UI rst = new MES_RETURN_UI();

            try
            {
                if (type == 1)
                {
                    #region KA订单查询导出
                    CRM_ORDER_TT selectdata = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_ORDER_TT>(data);
                    selectdata.OrderST2 = 1;
                    selectdata.FuntionTYPE = "KA";
                    token = appClass.CRM_Gettoken();
                    STAFFID = appClass.CRM_GetStaffid();//校验 
                    CRM_ORDER_TT[] model = crmModels.ORDER_TT.ReadTTbyParam(selectdata, STAFFID, 0, 1, token);
                    FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/CRM/ExcelTemplate/KA订单查询导出.xlsx", FileMode.Open, FileAccess.Read);
                    IWorkbook workbook = new XSSFWorkbook(file);
                    ISheet sheet = workbook.GetSheetAt(0);
                    int rowcount = 1;
                    for (int i = 0; i < model.Length; i++)
                    {
                        int cellIndex = 0;
                        IRow row = sheet.CreateRow(rowcount++);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].OrderSrcDES);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].StoreNum);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].KHNAME);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].KHPO);
                        switch (model[i].OrderST)
                        {
                            case 1:
                                row.CreateCell(cellIndex++).SetCellValue("正常");
                                break;
                            case 2:
                                row.CreateCell(cellIndex++).SetCellValue("退货");
                                break;
                            case 3:
                                row.CreateCell(cellIndex++).SetCellValue("异动");
                                break;
                            case 4:
                                row.CreateCell(cellIndex++).SetCellValue("删除");
                                break;
                            case 5:
                                row.CreateCell(cellIndex++).SetCellValue("报错");
                                break;
                            default:
                                break;
                        }
                        row.CreateCell(cellIndex++).SetCellValue(model[i].PAY);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].OrderDate);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].DeliveryDate);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].StoreNews);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].BEIZ);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].DYSJ);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].SAPORDER);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].JHD);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].TBSJ);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].BJSJ);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].QRSJ);
                    }

                    string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                    FileStream file1 = new FileStream(string.Format(@"{0}/Areas/CRM/ExcelTemplate/{1}.xlsx", Server.MapPath("~"), now + STAFFID + "13"), FileMode.Create);
                    workbook.Write(file1);
                    file1.Close();
                    rst.TYPE = "S";
                    rst.MESSAGE = now + STAFFID + "13";
                    #endregion
                }
                else if (type == 2)
                {
                    #region 收货报告明细导出
                    token = appClass.CRM_Gettoken();
                    CRM_ORDER_SH node = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_ORDER_SH>(data);

                    CRM_ORDER_SH[] model = crmModels.ORDER_SH.ReadByParam(node, token);
                    FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/CRM/ExcelTemplate/收货报告明细导出.xlsx", FileMode.Open, FileAccess.Read);
                    IWorkbook workbook = new XSSFWorkbook(file);
                    ISheet sheet = workbook.GetSheetAt(0);
                    int rowcount = 1;
                    for (int i = 0; i < model.Length; i++)
                    {
                        int cellIndex = 0;
                        IRow row = sheet.CreateRow(rowcount++);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].OrderSrcDES);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].StoreNum);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].KHNAME);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].KHPO);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].OrderItem);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].ProdNum);
                        if (model[i].ProdName != "" && model[i].ProdSpec != "")
                        {
                            row.CreateCell(cellIndex++).SetCellValue(model[i].ProdName + "/" + model[i].ProdSpec);
                        }
                        else if (model[i].ProdName == "")
                        {
                            row.CreateCell(cellIndex++).SetCellValue(model[i].ProdSpec);
                        }
                        else if (model[i].ProdSpec == "")
                        {
                            row.CreateCell(cellIndex++).SetCellValue(model[i].ProdName);
                        }
                        row.CreateCell(cellIndex++).SetCellValue(model[i].BarCode);
                        row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(model[i].PRICE));
                        row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(model[i].DDSL));
                        row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(model[i].SJSL));
                        row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(model[i].DGJE));
                        row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(model[i].SJJE));
                        row.CreateCell(cellIndex++).SetCellValue(model[i].OrderDate);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].SHDate);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].SAPORDER);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].POSNR);
                        //row.CreateCell(cellIndex++).SetCellValue(model[i].CPPH);
                        //row.CreateCell(cellIndex++).SetCellValue(model[i].CPMC);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].JHD);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].CPPH);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].CPMC);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].JHSL);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].JHUnit);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].SJJHSL);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].BaseUnit);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].SDF);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].SDFNAME);
                        row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(model[i].HSJE));
                        row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(model[i].ZKL));
                        row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(model[i].ZKJE));
                        row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(model[i].SL));
                        row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(model[i].SE));
                        row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(model[i].KPJE));
                        row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(model[i].WSJE));
                        row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(model[i].DIFFERENCE));
                        //row.CreateCell(cellIndex++).SetCellValue(model[i].JHDItem);
                        //row.CreateCell(cellIndex++).SetCellValue(model[i].SDF);
                        //row.CreateCell(cellIndex++).SetCellValue(model[i].SDFNAME);
                        //row.CreateCell(cellIndex++).SetCellValue(model[i].JHSL);
                        //row.CreateCell(cellIndex++).SetCellValue(model[i].JHUnit);
                        //row.CreateCell(cellIndex++).SetCellValue(model[i].SJJHSL);
                        //row.CreateCell(cellIndex++).SetCellValue(model[i].BaseUnit);
                        //row.CreateCell(cellIndex++).SetCellValue(Convert.ToString(model[i].SL) + "%");
                        //row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(model[i].DGJE));
                        //row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(model[i].SJJE));
                        //row.CreateCell(cellIndex++).SetCellValue(model[i].ZKL + "%");
                        //row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(model[i].ZKJE));
                        //row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(model[i].HSJE));
                        //row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(model[i].DIFFERENCE));

                    }

                    string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                    FileStream file1 = new FileStream(string.Format(@"{0}/Areas/CRM/ExcelTemplate/{1}.xlsx", Server.MapPath("~"), now + STAFFID + "13"), FileMode.Create);
                    workbook.Write(file1);
                    file1.Close();
                    rst.TYPE = "S";
                    rst.MESSAGE = now + STAFFID + "13";
                    #endregion
                }
                else if (type == 3)
                {
                    #region 收货报告导出
                    token = appClass.CRM_Gettoken();
                    CRM_ORDER_SH node = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_ORDER_SH>(data);

                    CRM_ORDER_SH[] model = crmModels.ORDER_SH.Report(node, token);
                    FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/CRM/ExcelTemplate/收货报告导出.xlsx", FileMode.Open, FileAccess.Read);
                    IWorkbook workbook = new XSSFWorkbook(file);
                    ISheet sheet = workbook.GetSheetAt(0);
                    int rowcount = 1;
                    for (int i = 0; i < model.Length; i++)
                    {
                        int cellIndex = 0;
                        IRow row = sheet.CreateRow(rowcount++);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].OrderSrcDES);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].StoreNum);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].KHNAME);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].KHPO);
                        row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(model[i].DGJE));
                        row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(model[i].DDSL));
                        row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(model[i].SJJE));
                        row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(model[i].SJSL));
                        row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(model[i].ZKJE));
                        row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(model[i].KPJE));
                        row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(model[i].HSJE));
                        row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(model[i].SAPORDERSTR));
                        row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(model[i].JHDSTR));
                        row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(model[i].DIFFERENCE));
                    }

                    string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                    FileStream file1 = new FileStream(string.Format(@"{0}/Areas/CRM/ExcelTemplate/{1}.xlsx", Server.MapPath("~"), now + STAFFID + "13"), FileMode.Create);
                    workbook.Write(file1);
                    file1.Close();
                    rst.TYPE = "S";
                    rst.MESSAGE = now + STAFFID + "13";
                    #endregion
                }
                else if (type == 4)
                {
                    #region KA订单明细查询导出
                    token = appClass.CRM_Gettoken();

                    CRM_ORDER_MX selectdata = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_ORDER_MX>(data);
                    selectdata.STAFFID = appClass.CRM_GetStaffid();
                    selectdata.FuntionTYPE = "KA";
                    CRM_ORDER_MX[] model = crmModels.ORDER_TT.ReadMXbyParam(selectdata, token);

                    FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/CRM/ExcelTemplate/KA订单明细查询导出.xlsx", FileMode.Open, FileAccess.Read);
                    IWorkbook workbook = new XSSFWorkbook(file);
                    ISheet sheet = workbook.GetSheetAt(0);
                    int rowcount = 1;
                    for (int i = 0; i < model.Length; i++)
                    {
                        int cellIndex = 0;
                        IRow row = sheet.CreateRow(rowcount++);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].OrderSrcDES);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].StoreNum);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].KHNAME);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].KHPO);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].OrderItem);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].ProdNum);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].ProdName + " / " + model[i].ProdSpec);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].BarCode);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].DDSL);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].OrderUnit);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].SAPORDER);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].JHD);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].CPPH);
                        row.CreateCell(cellIndex++).SetCellValue(model[i].CPMC);
                    }

                    string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                    FileStream file1 = new FileStream(string.Format(@"{0}/Areas/CRM/ExcelTemplate/{1}.xlsx", Server.MapPath("~"), now + STAFFID + "13"), FileMode.Create);
                    workbook.Write(file1);
                    file1.Close();
                    rst.TYPE = "S";
                    rst.MESSAGE = now + STAFFID + "13";
                    #endregion
                }

            }
            catch (Exception)
            {
                rst.TYPE = "E";
                rst.MESSAGE = "导出失败！";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }

        public ActionResult EXPORT_KAORDER(string filename, string downloadname)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/CRM/ExcelTemplate/{1}.xlsx", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", downloadname);
        }



        public static string GetMd5Hash(string input)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                // Convert the input string to a byte array and compute the hash.
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Create a new Stringbuilder to collect the bytes
                // and create a string.
                StringBuilder sBuilder = new StringBuilder();

                // Loop through each byte of the hashed data 
                // and format each one as a hexadecimal string.
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                // Return the hexadecimal string.
                return sBuilder.ToString();
            }
        }


        [HttpPost]
        public string FileExport_HHXXWH(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            DaoRuMsg msg = new DaoRuMsg();
            //   int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_RETURN_UI rst = new MES_RETURN_UI();
            try
            {
                CRM_PRODUCT_HH cxmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_PRODUCT_HH>(cxdata);
                CRM_PRODUCT_HH[] model = crmModels.PRODUCT_HH.ReadByParam(cxmodel, appClass.CRM_GetStaffid(), token);
                FileStream file = new FileStream(FileSavePath + @"\ExcelTemplate/货号信息维护.xls", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new HSSFWorkbook(file);
                ISheet worksheet1 = workbook.GetSheet("货号信息维护");
                if (worksheet1 == null)
                {
                    msg.Msg = "errr";
                    msg.Info = "Excel中没有工作表";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }
                int row1 = 0;
                for (int i = 0; i < model.Length; i++)
                {
                    CRM_PRODUCT_HH node = new CRM_PRODUCT_HH();
                    node.HHID = model[i].HHID;
                    CRM_PRODUCT_HH[] List = crmModels.PRODUCT_HH.ReadByParam(node, 0, token);


                    NPOI.SS.UserModel.IRow row = worksheet1.CreateRow(row1 + 1);
                    row.CreateCell(0).SetCellValue(model[i].SYDES);
                    row.CreateCell(1).SetCellValue(model[i].ProdNum);
                    row.CreateCell(2).SetCellValue(model[i].BarCode);
                    row.CreateCell(3).SetCellValue(model[i].NameSpec);
                    row.CreateCell(4).SetCellValue(model[i].DGDW);
                    row.CreateCell(5).SetCellValue(model[i].SAPBM);

                    row1++;
                }
                worksheet1.ForceFormulaRecalculation = true;
                //string now = DateTime.Now.ToString("yyyyMMddHHmmss");
                //FileStream file1 = new FileStream(FileSavePath + @"\upload\" + now + ".xls", FileMode.Create);
                //workbook.Write(file1);
                //file1.Close();


                //msg.Msg = now + ".xls";


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

        [HttpPost]
        public string GET_DRFLOGIN_INFO()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(GET_DRFLOGIN_INFO_JS());
        }

        //public DataRow GET_DRFLOGIN_INFO_JS(DataRow dr, int account)
        //{
        //    string LB = "";
        //    if (account == 0)
        //    {
        //        LB = "华东大润发（碱性）";
        //    }
        //    else if (account == 1)
        //    {
        //        LB = "华东大润发(碳性)";
        //    }
        //    else if (account == 2)
        //    {
        //        LB = "华中大润发";
        //    }
        //    else if (account == 3)
        //    {
        //        LB = "华北大润发";
        //    }
        //    else if (account == 4)
        //    {
        //        LB = "华南大润发";
        //    }
        //    else if (account == 5)
        //    {
        //        LB = "东北大润发";
        //    }
        //    Sonluk.UI.Model.CRM.CRM_DRFService.CRM_DRF_RETURNMSG rst_CRM_DRF_RETURNMSG = crmModels.CRM_DRF.status(account);

        //    if (rst_CRM_DRF_RETURNMSG.Error == false)
        //    {
        //        if (rst_CRM_DRF_RETURNMSG.Data > 0)
        //        {
        //            dr[0] = LB;
        //            dr[1] = "抓取中";
        //            dr[2] = rst_CRM_DRF_RETURNMSG.Data;
        //        }
        //        else
        //        {
        //            dr[0] = LB;
        //            dr[1] = "请登录";
        //            dr[2] = rst_CRM_DRF_RETURNMSG.Data;
        //        }
        //    }
        //    else
        //    {
        //        dr[0] = LB;
        //        dr[1] = "登录失败";
        //        dr[2] = 0;
        //    }
        //    dr[3] = account;
        //    return dr;
        //}
        public DataTable GET_DRFLOGIN_INFO_JS()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("LB", typeof(string));
            dt.Columns.Add("ZT", typeof(string));
            dt.Columns.Add("DATA", typeof(int));
            dt.Columns.Add("ACCOUNT", typeof(int)); token = appClass.CRM_Gettoken();
            CRM_ORDER_DRF_USER MODEL_CRM_ORDER_DRF_USER = new CRM_ORDER_DRF_USER();
            MODEL_CRM_ORDER_DRF_USER.LB = 1;
            MODEL_CRM_ORDER_DRF_USER.USERACCOUNT = -1;
            CRM_ORDER_DRF_USER_SELECT rst_CRM_ORDER_DRF_USER_SELECT = crmModels.CRM_DRF.SELECT_USER_SYNC(MODEL_CRM_ORDER_DRF_USER, token);
            if (rst_CRM_ORDER_DRF_USER_SELECT.MES_RETURN.TYPE != "S")
            {
                return dt;
            }
            for (int a = 0; a < rst_CRM_ORDER_DRF_USER_SELECT.CRM_ORDER_DRF_USER.Length; a++)
            {
                DataRow dr = dt.NewRow();
                Sonluk.UI.Model.CRM.CRM_DRFService.CRM_DRF_RETURNMSG rst_CRM_DRF_RETURNMSG = crmModels.CRM_DRF.status(rst_CRM_ORDER_DRF_USER_SELECT.CRM_ORDER_DRF_USER[a].USERACCOUNT);
                if (rst_CRM_DRF_RETURNMSG.Error == false)
                {
                    if (rst_CRM_DRF_RETURNMSG.Data > 0)
                    {
                        dr[0] = rst_CRM_ORDER_DRF_USER_SELECT.CRM_ORDER_DRF_USER[a].REMARK;
                        dr[1] = "抓取中";
                        dr[2] = rst_CRM_DRF_RETURNMSG.Data;
                    }
                    else
                    {
                        dr[0] = rst_CRM_ORDER_DRF_USER_SELECT.CRM_ORDER_DRF_USER[a].REMARK;
                        dr[1] = "请登录";
                        dr[2] = rst_CRM_DRF_RETURNMSG.Data;
                    }
                }
                else
                {
                    dr[0] = rst_CRM_ORDER_DRF_USER_SELECT.CRM_ORDER_DRF_USER[a].REMARK;
                    dr[1] = "登录失败";
                    dr[2] = 0;
                }
                dr[3] = rst_CRM_ORDER_DRF_USER_SELECT.CRM_ORDER_DRF_USER[a].USERACCOUNT;
                dt.Rows.Add(dr);
            }
            return dt;
        }
        [HttpPost]
        public string DRF_LOGIN_JT(int account)
        {
            Byte[] objcode = crmModels.CRM_DRF.SCREENSHOT(account);
            string qd = Convert.ToBase64String(objcode);
            return Newtonsoft.Json.JsonConvert.SerializeObject(qd);
        }
        [HttpPost]
        public string DRF_LOGIN_YZM(int ACCOUNT, string AUTH)
        {
            Sonluk.UI.Model.CRM.CRM_DRFService.CRM_DRF_RETURNMSG rst_CRM_DRF_RETURNMSG = crmModels.CRM_DRF.setAuth(AUTH, ACCOUNT);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_CRM_DRF_RETURNMSG);
        }

        [HttpPost]
        public string Select_MesWL(string cxdata)
        {
            token = AppClass.GetSession("token").ToString();
            MES_SY_MATERIAL model_MES_SY_MATERIAL = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_MATERIAL>(cxdata);
            model_MES_SY_MATERIAL.GC = "1000";
            MES_SY_MATERIAL_SELECT rst_MES_SY_MATERIAL_SELECT = mesModels.SY_MATERIAL.SELECT_ACTION(model_MES_SY_MATERIAL, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst_MES_SY_MATERIAL_SELECT);
        }

        [HttpPost]
        public string GET_SY_MATERIAL_DW_SELECT(string datastring)
        {
            token = AppClass.GetSession("token").ToString();
            MES_SY_MATERIAL_DW model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_MATERIAL_DW>(datastring);
            MES_SY_MATERIAL_DW_SELECT rst = mesModels.SY_MATERIAL.DW_SELECT(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }

        public string PostFunction(string ModelStr, string URL)
        {

            string serviceAddress = URL;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serviceAddress);

            request.Method = "POST";
            request.ContentType = "application/json";                          //otKEk1FYKxWN_RQEmMhwNBbnOpKQ
            string strContent = ModelStr;
            using (StreamWriter dataStream = new StreamWriter(request.GetRequestStream()))
            {
                dataStream.Write(strContent);
                dataStream.Close();
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string encoding = response.ContentEncoding;
            if (encoding == null || encoding.Length < 1)
            {
                encoding = "UTF-8"; //默认编码  
            }
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encoding));
            string retString = reader.ReadToEnd();
            //解析josn
            JObject jo = JObject.Parse(retString);
            //Response.Write(jo["message"]["mmmm"].ToString());
            return Newtonsoft.Json.JsonConvert.SerializeObject(jo);
        }

        public ActionResult GYtest()
        {

            return View();
        }

        [HttpPost]
        public string GY_ReadOrder(string start_date, string end_date, string page_size, string platform_code)
        {
            string signContent = "";
            string requestContent = "";
            string sign = "";
            string appkey = "140347";
            string method = "gy.erp.trade.get";
            string sessionkey = "26c2bf368084490aa9d875f14ee7d4d8";

            //string page_size = "100";
            //string start_date = "2019-10-29 17:00:00";
            //string end_date = "2019-10-30 08:00:00";
            string date_type = "0";




            string url = "http://v2.api.guanyierp.com/rest/erp_open";
            string baseContent = "{"
               + "\"appkey\":\"" + appkey + "\","
               + "\"method\":\"" + method + "\","
                //+ "\"page_no\":" + page + ","
               + "\"page_size\":" + page_size + ","
                //+ "\"start_date\":" + start_date + ","
                //+ "\"end_date\":" + end_date + ","
               + "\"date_type\":" + date_type + ","
               + "\"sessionkey\":\"" + sessionkey + "\"";
            //if (!string.IsNullOrWhiteSpace(shopcode))
            //{
            //    baseContent += "," + "\"shop_code\":\"" + shopcode + "\"";
            //}
            //if (!string.IsNullOrWhiteSpace(djbh))
            //{
            //    baseContent += "," + "\"code\":\"" + djbh + "\"";
            //}
            if (!string.IsNullOrWhiteSpace(start_date))
            {
                baseContent += "," + "\"start_date\":\"" + start_date + "\"";
            }
            if (!string.IsNullOrWhiteSpace(end_date))
            {
                baseContent += "," + "\"end_date\":\"" + end_date + "\"";
            }
            if (!string.IsNullOrWhiteSpace(platform_code))
            {
                baseContent += "," + "\"platform_code\":\"" + platform_code + "\"";
            }
            //if (!string.IsNullOrWhiteSpace(whcode))
            //{
            //    baseContent += "," + "\"warehouse_code\":\"" + whcode + "\"";
            //}
            //if (!string.IsNullOrWhiteSpace(delivery))
            //{
            //    baseContent += "," + "\"delivery\":\"" + delivery + "\"";
            //}
            baseContent += "signplace";
            baseContent += "}";

            signContent = baseContent.Replace("signplace", "");
            sign = Sign(signContent);

            requestContent = baseContent.Replace("signplace", "," + "\"sign\":\"" + sign + "\"");

            return PostFunction(requestContent, url);
        }

        public String Sign(string json)
        {
            string secret = "ae93ff23304740dd902dc20d486244ac";//AppPara.CERPSECRET;
            //将sign字段与值去掉
            //json.remove("sign");
            StringBuilder enValue = new StringBuilder();
            //前后加上secret
            enValue.Append(secret);
            //enValue.Append(json.toString());
            enValue.Append(json.ToString());
            enValue.Append(secret);
            // 使用MD5加密
            byte[] bytes = encryptMD5(enValue.ToString());
            // 把二进制转化为大写的十六进制
            return byte2hex(bytes);
        }

        private byte[] encryptMD5(String data)
        {
            byte[] bytes = null;
            try
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                bytes = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(data));

                //MessageDigest md = MessageDigest.getInstance("MD5");
                //bytes = md.digest(data.getBytes("UTF-8"));
            }
            catch //(Exception e)
            {
                //new clsWriterErr().writerErr("clsCERPSystemDB", "encryptMD5", e);
            }
            return bytes;
        }
        private String byte2hex(byte[] bytes)
        {
            string md5Str = "0123456789ABCDEF";
            string sign = string.Empty;
            for (int i = 0; i < bytes.Length; i++)
            {
                int a = 0xf & bytes[i] >> 4;
                int b = bytes[i] & 0xf;
                sign += md5Str.Substring(0xf & bytes[i] >> 4, 1) + md5Str[bytes[i] & 0xf];
            }
            return sign.ToString();
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
        public ActionResult EXPORT_DOWNLOADForTemplate(string filename)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/CRM/ExcelTemplate/{1}.xls", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            // System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", filename + ".xls");
        }
        public string DR_KB(string KBMC)
        {

            token = appClass.CRM_Gettoken();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            //  MES_RETURN_UI mr = new MES_RETURN_UI();
            DaoRuMsg mr = new DaoRuMsg();
            //if (OrderSrc == 0)
            //{
            //    mr.Msg = "订单来源不能为空";
            //    mr.Info = "E";
            //    return Newtonsoft.Json.JsonConvert.SerializeObject(mr);
            //}
            if (string.IsNullOrEmpty(KBMC))
            {
                mr.Msg = "快报名称不能为空";
                mr.Info = "E";
                return Newtonsoft.Json.JsonConvert.SerializeObject(mr);
            }
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
                //开始做数据校验
                DataTable data = ExcelToDataTable(savePath, 0, true);

                List<Int32> HH_list = new List<Int32>();
                List<string> HH_list2 = new List<string>();
                List<Int32> HH_ID = new List<Int32>();
                #region
                if (data != null)
                {
                    string[] columnsName = new string[] { "货号", "物料编码", "订单单位" };
                    try
                    {
                        //做数据验证
                        if (data.Rows.Count > 0)
                        {
                            for (int i = 0; i < columnsName.Length; i++)
                            {
                                if (!data.Columns.Contains(columnsName[i]))
                                {
                                    mr.Msg = "请使用正确的快报excel";
                                    mr.Info = "E";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(mr);
                                }
                            }





                            for (int i = 0; i < data.Rows.Count; i++)
                            {

                                //CRM_PRODUCT_KB node = new CRM_PRODUCT_KB();

                                //node.OrderSrc = OrderSrc;
                                //node.CJR = STAFFID;

                                if (data.Rows[i]["订单来源"].ToString() == "")
                                {
                                    mr.Info = "E";
                                    mr.Msg = "第" + (i + 1) + "行订单来源不能为空";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(mr);
                                }



                                int OrderSrc = crmModels.HG_DICT.ReadByDICNAME(data.Rows[i]["订单来源"].ToString(), 112, token);
                                if (OrderSrc == 0)
                                {
                                    mr.Info = "E";
                                    mr.Msg = "第" + (i + 1) + "行订单来源名称不正确，请检查名称.";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(mr);
                                }


                                CRM_PRODUCT_HH model = new CRM_PRODUCT_HH();
                                model.SY = OrderSrc;
                                model.ProdNum = data.Rows[i]["货号"].ToString();
                                CRM_PRODUCT_HH[] Ty_date = crmModels.PRODUCT_HH.ReadByParam(model, STAFFID, token);
                                if (Ty_date.Length == 0)//检测在货号表中是否存在
                                {
                                    mr.Msg = "第" + (i + 1) + "行货号与订单来源不匹配，excel数据异常请检查";
                                    mr.Info = "E";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(mr);
                                }
                                //CRM_PRODUCT_KB VerifyModel = new CRM_PRODUCT_KB();
                                //VerifyModel.WLBM = data.Rows[i]["物料编码"].ToString();
                                //VerifyModel.CPHH = data.Rows[i]["货号"].ToString();
                                //VerifyModel.OrderSrc = OrderSrc;
                                //VerifyModel.KBMC = KBMC;
                                //CRM_PRODUCT_KB[] VerifryDate = crmModels.PRODUCT_KB.ReadByParam(VerifyModel, token);
                                //if (VerifryDate.Length > 0)
                                //{
                                //    mr.Msg = "第" + (i + 1) + "行订单来源+快报+货号+物料编码已经存在，不允许重复";
                                //    mr.Info = "E";
                                //    return Newtonsoft.Json.JsonConvert.SerializeObject(mr);
                                //}
                                MES_SY_MATERIAL_DW DWMODEL = new MES_SY_MATERIAL_DW();
                                DWMODEL.WLH = data.Rows[i]["物料编码"].ToString();
                                DWMODEL.MEINH = data.Rows[i]["订单单位"].ToString();
                                MES_SY_MATERIAL_DW_SELECT dwdate = mesModels.SY_MATERIAL.DW_SELECT(DWMODEL, token);//检测物料编码是否对应订单单位
                                if (dwdate.MES_SY_MATERIAL_DW.Length == 0)
                                {
                                    mr.Msg = "第" + (i + 1) + "行物料编码不和此订单单位对应，请检查数据";
                                    mr.Info = "E";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(mr);
                                }

                                HH_list.Add(Convert.ToInt32(data.Rows[i]["货号"].ToString()));
                                HH_list2.Add(data.Rows[i]["货号"].ToString() + data.Rows[i]["物料编码"].ToString());
                                HH_ID.Add(crmModels.HG_DICT.ReadByDICNAME(data.Rows[i]["订单来源"].ToString(), 112, token));
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        mr.Msg = e.Message;
                        mr.Info = "E";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(mr);
                        //throw;
                    }
                }
                #endregion


                HashSet<Int32> HH_hash = new HashSet<Int32>(HH_list);
                if (HH_list.Count() != HH_hash.Count())
                {
                    mr.Msg = "Excel货号重复，请检查数据";
                    mr.Info = "E";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(mr);
                }
                HashSet<string> HH_hash2 = new HashSet<string>(HH_list2);
                if (HH_list2.Count != HH_hash2.Count())
                {
                    mr.Msg = "Excel中订单来源+快报+货号+物料编码已经存在，不允许重复";
                    mr.Info = "E";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(mr);
                }

                HashSet<Int32> Hash_ID = new HashSet<int>(HH_ID);





                data.Columns.Add("OrderSrc", typeof(int));

                foreach (DataRow dr in data.Rows)
                {
                    dr["OrderSrc"] = crmModels.HG_DICT.ReadByDICNAME(dr["订单来源"].ToString(), 112, token);
                }


                data.DefaultView.Sort = "OrderSrc";
                DataTable TempTable = data.DefaultView.ToTable(); //根据订单来源DataTable进行排序


                foreach (var id in Hash_ID)
                {

                    DataTable LTable = SortDataTable(TempTable, id);
                    int num = Insert_Info(LTable, KBMC);
                    if (num == 0)
                    {
                        mr.Msg = "导入信息出现问题，请记录当前报错信息并联系管理员";
                        mr.Info = "E";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(mr);
                    }
                }

            }


            mr.Msg = "导入快报信息成功";
            mr.Info = "S";
            return Newtonsoft.Json.JsonConvert.SerializeObject(mr);
        }
        public int Insert_Info(DataTable data, string KBMC)
        {
            DaoRuMsg mr = new DaoRuMsg();
            //for (int y = 0; y < data.Rows.Count; y++)
            //{

            int OrderSrc = Convert.ToInt32(data.Rows[0]["OrderSrc"]);
            CRM_PRODUCT_KB nModel = new CRM_PRODUCT_KB();
            nModel.OrderSrc = OrderSrc;
            nModel.KBMC = KBMC;
            CRM_PRODUCT_KB[] ndata = crmModels.PRODUCT_KB.ReadByParam(nModel, token);
            if (ndata.Length > 0)
            {
                for (int j = 0; j < ndata.Length; j++)
                {
                    crmModels.PRODUCT_KBMX.DeleteByKBID(ndata[j].KBID, token);
                }
                ndata[0].XGR = appClass.CRM_GetStaffid();
                crmModels.PRODUCT_KB.Update(ndata[0], token);
                for (int i = 0; i < data.Rows.Count; i++) //数据到数据库
                {
                    CRM_PRODUCT_KBMX NNmodel = new CRM_PRODUCT_KBMX();
                    NNmodel.KBID = ndata[0].KBID;
                    NNmodel.CPHH = data.Rows[i]["货号"].ToString().Trim();
                    NNmodel.WLBM = data.Rows[i]["物料编码"].ToString().Trim();
                    NNmodel.DDDW = data.Rows[i]["订单单位"].ToString().Trim();
                    NNmodel.ISACTIVE = 1;
                    int j = crmModels.PRODUCT_KBMX.Create(NNmodel, token);

                    if (j == 0)
                    {
                        return j;
                        //mr.Msg = "导入信息的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                        //mr.Info = "E";
                        //return Newtonsoft.Json.JsonConvert.SerializeObject(mr);
                    }
                }
            }
            else
            {
                CRM_PRODUCT_KB model = new CRM_PRODUCT_KB();
                model.OrderSrc = OrderSrc;
                model.KBMC = KBMC;
                model.ISACTIVE = 1;
                model.CJR = appClass.CRM_GetStaffid();
                model.XGR = appClass.CRM_GetStaffid();
                int x = crmModels.PRODUCT_KB.Create(model, token);
                for (int i = 0; i < data.Rows.Count; i++) //数据到数据库
                {
                    CRM_PRODUCT_KBMX NNmodel = new CRM_PRODUCT_KBMX();
                    NNmodel.KBID = x;
                    NNmodel.CPHH = data.Rows[i]["货号"].ToString().Trim();
                    NNmodel.WLBM = data.Rows[i]["物料编码"].ToString().Trim();
                    NNmodel.DDDW = data.Rows[i]["订单单位"].ToString().Trim();
                    NNmodel.ISACTIVE = 1;
                    int j = crmModels.PRODUCT_KBMX.Create(NNmodel, token);

                    if (j == 0)
                    {
                        return j;
                        //mr.Msg = "导入信息的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                        //mr.Info = "E";
                        //return Newtonsoft.Json.JsonConvert.SerializeObject(mr);
                    }
                }
            }
            //}
            return 1;
        }

        public DataTable SortDataTable(DataTable dt, int Num)
        {
            DataView dv = dt.DefaultView;
            var query = (from table in dt.AsEnumerable()
                         where (Convert.ToInt32(table["OrderSrc"]) == Num)
                         select table);



            dv = query.AsDataView();

            return dv.ToTable();


        }



        [HttpPost]
        public string Data_Insert_OrderMX(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_ORDER_MX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_ORDER_MX>(data);
            int i = crmModels.ORDER_TT.CreateMX(model, token);
            if (i > 0)
            {
                webmsg.KEY = i;
                webmsg.MSG = "新增成功！";
            }
            else
            {
                webmsg.KEY = 0;
                webmsg.MSG = "新增失败！";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Insert_OrderMX_Multi(string data, int ORDERTTID, string FItem)
        {
            token = appClass.CRM_Gettoken();
            CRM_ORDER_MX[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_ORDER_MX[]>(data);

            CRM_ORDER_MX deletemodel = new CRM_ORDER_MX();
            deletemodel.ORDERTTID = ORDERTTID;
            deletemodel.FItem = FItem;
            int temp = crmModels.ORDER_TT.DeleteMXbyFItem(deletemodel, appClass.CRM_GetStaffid(), token);


            webmsg.KEY = 1;
            webmsg.MSG = "拆分完成！";
            for (int i = 0; i < model.Length; i++)
            {
                int id = crmModels.ORDER_TT.CreateMX(model[i], token);
                if (id <= 0)
                {
                    webmsg.KEY = 0;
                    webmsg.MSG = "拆分失败！";
                }
            }

            CRM_ORDER_MX cxmodel = new CRM_ORDER_MX();
            cxmodel.ORDERTTID = ORDERTTID;
            cxmodel.OrderItem = FItem;
            CRM_ORDER_MX[] data1 = crmModels.ORDER_TT.ReadMXbyParam(cxmodel, token);
            if (webmsg.KEY == 1 && model.Length != 0)
            {
                //
                if (data1.Length != 0)
                {
                    data1[0].CPPH = "";
                    data1[0].CPMC = "";
                    data1[0].KCDD = "";
                    data1[0].LB = 1;      //为区分是普通的编辑还是拆分时进行的自动修改
                    data1[0].ISCF = 1;
                    int ii = crmModels.ORDER_TT.UpdateMX_WLinfo(data1[0], appClass.CRM_GetStaffid(), token);
                }

            }
            else if (model.Length == 0 && data1.Length != 0)
            {
                //什么都没拆或者是原先拆了，现在删光了，如果是后者，需要把拆分标记去掉
                if (data1[0].ISCF == 1)
                {
                    data1[0].ISCF = 0;
                    int ii = crmModels.ORDER_TT.UpdateMX_WLinfo(data1[0], appClass.CRM_GetStaffid(), token);
                }
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public int Delete_KB(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_PRODUCT_KB model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_PRODUCT_KB>(cxdata);
            int i = crmModels.PRODUCT_KB.Delete(model.KBID, token);
            int x = crmModels.PRODUCT_KBMX.Delete(model.KBMXID, token);
            return i;
        }

        [HttpPost]
        public string Data_Select_KBMX(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_PRODUCT_KBMX cxmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_PRODUCT_KBMX>(cxdata);
            CRM_PRODUCT_KBMX[] data = crmModels.PRODUCT_KBMX.ReadByParam(cxmodel, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }


        public ActionResult SelectOrderMX(string cxdata)
        {
            token = appClass.CRM_Gettoken();



            return View();
        }

        [HttpPost]
        public string Data_Select_OrderMX(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_ORDER_MX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_ORDER_MX>(cxdata);
            model.FuntionTYPE = "KA";
            model.STAFFID = appClass.CRM_GetStaffid();
            CRM_ORDER_MX[] data = crmModels.ORDER_TT.ReadMXbyParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }
        // string Temp = "";
        //int TempID = 0;
        //Temp = TempTable.Rows[0]["OrderSrc"].ToString();
        //for (int q = 0; q < TempTable.Rows.Count; q++)
        //{

        //    CRM_PRODUCT_KB nModel = new CRM_PRODUCT_KB();
        //    nModel.OrderSrc = Convert.ToInt32(Temp);
        //    nModel.KBMC = KBMC;
        //    CRM_PRODUCT_KB[] ndata = crmModels.PRODUCT_KB.ReadByParam(nModel, token);


        //    #region 首行需要删除明细

        //    if (ndata.Length > 0) //判断首行,需要删除明细
        //    {
        //        if (q == 0)
        //        {
        //            for (int j = 0; j < ndata.Length; j++)
        //            {
        //                crmModels.PRODUCT_KBMX.DeleteByKBID(ndata[j].KBID, token);
        //            }
        //            ndata[0].XGR = appClass.CRM_GetStaffid();
        //            crmModels.PRODUCT_KB.Update(ndata[0], token);
        //        }


        //        if (Temp == TempTable.Rows[q]["OrderSrc"].ToString())//当前行的订单来源与首行形同
        //        {
        //            CRM_PRODUCT_KBMX NNmodel = new CRM_PRODUCT_KBMX();
        //            NNmodel.KBID = ndata[0].KBID;
        //            NNmodel.CPHH = data.Rows[q]["货号"].ToString().Trim();
        //            NNmodel.WLBM = data.Rows[q]["物料编码"].ToString().Trim();
        //            NNmodel.DDDW = data.Rows[q]["订单单位"].ToString().Trim();
        //            NNmodel.ISACTIVE = 1;
        //            int x = crmModels.PRODUCT_KBMX.Create(NNmodel, token);

        //            if (x == 0)
        //            {

        //                mr.Msg = "导入信息的第" + (q + 1) + "行出现问题，请记录当前报错信息并联系管理员";
        //                mr.Info = "E";
        //                return Newtonsoft.Json.JsonConvert.SerializeObject(mr);
        //            }
        //        }
        //        if (Temp != TempTable.Rows[q]["OrderSrc"].ToString()) //当前行与首行不相同
        //        {
        //            Temp = TempTable.Rows[q]["订单来源"].ToString();//更新变量

        //            CRM_PRODUCT_KB nnModel = new CRM_PRODUCT_KB();
        //            nnModel.OrderSrc = Convert.ToInt32(Temp);
        //            nnModel.KBMC = KBMC;
        //            CRM_PRODUCT_KB[] nnData = crmModels.PRODUCT_KB.ReadByParam(nnModel, token);

        //            if (nnData.Length > 0) //判断是否需要删除
        //            {
        //                for (int i = 0; i < nnData.Length; i++)
        //                {
        //                    crmModels.PRODUCT_KBMX.DeleteByKBID(nnData[i].KBID, token);
        //                }
        //                nnData[0].XGR = appClass.CRM_GetStaffid();
        //                crmModels.PRODUCT_KB.Update(nnData[0], token);

        //                CRM_PRODUCT_KBMX NNmodel = new CRM_PRODUCT_KBMX();
        //                NNmodel.KBID = nnData[0].KBID;
        //                NNmodel.CPHH = data.Rows[q]["货号"].ToString().Trim();
        //                NNmodel.WLBM = data.Rows[q]["物料编码"].ToString().Trim();
        //                NNmodel.DDDW = data.Rows[q]["订单单位"].ToString().Trim();
        //                NNmodel.ISACTIVE = 1;
        //                int j = crmModels.PRODUCT_KBMX.Create(NNmodel, token);
        //            }
        //            else
        //            {
        //                CRM_PRODUCT_KB NNmodel = new CRM_PRODUCT_KB();
        //                NNmodel.OrderSrc = Convert.ToInt32(Temp);
        //                NNmodel.KBMC = KBMC;
        //                NNmodel.ISACTIVE = 1;
        //                NNmodel.CJR = appClass.CRM_GetStaffid();
        //                NNmodel.XGR = appClass.CRM_GetStaffid();
        //                int z = crmModels.PRODUCT_KB.Create(NNmodel, token);

        //                CRM_PRODUCT_KBMX AAmodel = new CRM_PRODUCT_KBMX();
        //                AAmodel.KBID = z;
        //                AAmodel.CPHH = data.Rows[q]["货号"].ToString().Trim();
        //                AAmodel.WLBM = data.Rows[q]["物料编码"].ToString().Trim();
        //                AAmodel.DDDW = data.Rows[q]["订单单位"].ToString().Trim();
        //                AAmodel.ISACTIVE = 1;
        //                int j = crmModels.PRODUCT_KBMX.Create(AAmodel, token);
        //            }
        //        }
        //    }
        //    #endregion
        //    #region 首行不需要删除
        //    if (ndata.Length == 0)//判断首行不需要删除
        //    {

        //        if (q == 0)
        //        {
        //            CRM_PRODUCT_KB model = new CRM_PRODUCT_KB();
        //            model.OrderSrc = Convert.ToInt32(Temp);
        //            model.KBMC = KBMC;
        //            model.ISACTIVE = 1;
        //            model.CJR = appClass.CRM_GetStaffid();
        //            model.XGR = appClass.CRM_GetStaffid();
        //            TempID = crmModels.PRODUCT_KB.Create(model, token);
        //        }

        //        if (Temp == TempTable.Rows[q]["订单来源"].ToString())//当前订单来源与前面相同
        //        {
        //            CRM_PRODUCT_KBMX NNmodel = new CRM_PRODUCT_KBMX();
        //            NNmodel.KBID = TempID;
        //            NNmodel.CPHH = data.Rows[q]["货号"].ToString().Trim();
        //            NNmodel.WLBM = data.Rows[q]["物料编码"].ToString().Trim();
        //            NNmodel.DDDW = data.Rows[q]["订单单位"].ToString().Trim();
        //            NNmodel.ISACTIVE = 1;
        //            int j = crmModels.PRODUCT_KBMX.Create(NNmodel, token);
        //            if (j == 0)
        //            {
        //                mr.Msg = "导入信息的第" + (q + 1) + "行出现问题，请记录当前报错信息并联系管理员";
        //                mr.Info = "E";
        //                return Newtonsoft.Json.JsonConvert.SerializeObject(mr);
        //            }
        //        }
        //        if (Temp != TempTable.Rows[q]["订单来源"].ToString())//当前订单来源与前面不相同
        //        {
        //            Temp = TempTable.Rows[q]["订单来源"].ToString();//更新变量

        //            CRM_PRODUCT_KB nnModel = new CRM_PRODUCT_KB();
        //            nnModel.OrderSrc = Convert.ToInt32(Temp);
        //            nnModel.KBMC = KBMC;
        //            CRM_PRODUCT_KB[] nnData = crmModels.PRODUCT_KB.ReadByParam(nnModel, token);

        //            if (nnData.Length > 0) //判断是否需要删除
        //            {
        //                for (int i = 0; i < nnData.Length; i++)
        //                {
        //                    crmModels.PRODUCT_KBMX.DeleteByKBID(nnData[i].KBID, token);
        //                }
        //                nnData[0].XGR = appClass.CRM_GetStaffid();
        //                crmModels.PRODUCT_KB.Update(nnData[0], token);

        //                CRM_PRODUCT_KBMX NNmodel = new CRM_PRODUCT_KBMX();
        //                NNmodel.KBID = nnData[0].KBID;
        //                NNmodel.CPHH = data.Rows[q]["货号"].ToString().Trim();
        //                NNmodel.WLBM = data.Rows[q]["物料编码"].ToString().Trim();
        //                NNmodel.DDDW = data.Rows[q]["订单单位"].ToString().Trim();
        //                NNmodel.ISACTIVE = 1;
        //                int j = crmModels.PRODUCT_KBMX.Create(NNmodel, token);
        //            }
        //            else
        //            {
        //                CRM_PRODUCT_KB NNmodel = new CRM_PRODUCT_KB();
        //                NNmodel.OrderSrc = Convert.ToInt32(Temp);
        //                NNmodel.KBMC = KBMC;
        //                NNmodel.ISACTIVE = 1;
        //                NNmodel.CJR = appClass.CRM_GetStaffid();
        //                NNmodel.XGR = appClass.CRM_GetStaffid();
        //                int z = crmModels.PRODUCT_KB.Create(NNmodel, token);

        //                CRM_PRODUCT_KBMX AAmodel = new CRM_PRODUCT_KBMX();
        //                AAmodel.KBID = z;
        //                AAmodel.CPHH = data.Rows[q]["货号"].ToString().Trim();
        //                AAmodel.WLBM = data.Rows[q]["物料编码"].ToString().Trim();
        //                AAmodel.DDDW = data.Rows[q]["订单单位"].ToString().Trim();
        //                AAmodel.ISACTIVE = 1;
        //                int j = crmModels.PRODUCT_KBMX.Create(AAmodel, token);
        //            }
        //        }
        //    }
        //    #endregion
        //}








    }
}
