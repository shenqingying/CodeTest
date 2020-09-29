using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sonluk.PC.Models;
using Sonluk.PC.APPCLASS;
using Sonluk.UI.Model.CRM.MSG_INVOICEService;
using Sonluk.UI.Model.CRM.MSG_NOTICETTService;
using Sonluk.UI.Model.CRM.KH_KHService;
using Sonluk.UI.Model.CRM.HG_STAFFService;
using System.IO;
using System.Data;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using System.Text.RegularExpressions;

namespace Sonluk.PC.Areas.CRM.Controllers
{
    public class MSGController : Controller
    {
        //
        // GET: /CRM/MSG/
        CRMModels crmModels = new CRMModels();
        AppClass appClass = new AppClass();
        WebMSG webmsg = new WebMSG();
        string token = "";
        string FileSavePath = System.Configuration.ConfigurationManager.AppSettings["FileSavePath"];
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Select_Invoice()
        {
            Session["location"] = 68;
            DateTime enddate = DateTime.Now;
            DateTime startdate = new DateTime(enddate.Year, enddate.Month, 1);
            ViewBag.enddate = enddate.ToString("yyyy-MM-dd");
            ViewBag.startdate = startdate.ToString("yyyy-MM-dd");
            return View();
        }

        public ActionResult Select_Notice()
        {
            Session["location"] = 69;
            DateTime enddate = DateTime.Now;
            DateTime startdate = new DateTime(enddate.Year, enddate.Month, 1);
            ViewBag.enddate = enddate.ToString("yyyy-MM-dd");
            ViewBag.startdate = startdate.ToString("yyyy-MM-dd");
            return View();
        }

        public ActionResult Insert_Notice()
        {
            return View();
        }

        public ActionResult Update_Notice()
        {
            return View();
        }

        public ActionResult Show_Notice(int NoticeTTid)
        {
            token = appClass.CRM_Gettoken();
            CRM_MSG_NOTICETTList data = crmModels.MSG_NOTICE.ReadTTbyTTID(NoticeTTid, token);




            return View();
        }

        public ActionResult SH_Notice()
        {
            Session["location"] = 70;
            DateTime enddate = DateTime.Now;
            DateTime startdate = new DateTime(enddate.Year, enddate.Month, 1);
            ViewBag.enddate = enddate.ToString("yyyy-MM-dd");
            ViewBag.startdate = startdate.ToString("yyyy-MM-dd");
            return View();
        }

        [HttpPost]
        public string Data_Insert_Invoice(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_MSG_INVOICE model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_MSG_INVOICE>(data);
            model.CJR = appClass.CRM_GetStaffid();
            model.ISACTIVE = 1;
            int i = crmModels.MSG_INVOICE.Create(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "新增成功";
            else
                webmsg.MSG = "新增失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Select_Invoice(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_MSG_INVOICEParam model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_MSG_INVOICEParam>(cxdata);
            CRM_MSG_INVOICEList[] data = crmModels.MSG_INVOICE.ReadByParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Update_Invoice(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_MSG_INVOICE model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_MSG_INVOICE>(data);
            model.XGR = appClass.CRM_GetStaffid();
            int i = crmModels.MSG_INVOICE.Update(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "修改成功！";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Delete_Invoice(int InvoiceID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.MSG_INVOICE.Delete(InvoiceID, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Insert_NoticeTT(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_MSG_NOTICETT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_MSG_NOTICETT>(data);
            model.NOTICE = HttpUtility.UrlDecode(model.NOTICE);
            model.CJR = appClass.CRM_GetStaffid();
            model.ISACTIVE = 1;
            int i = crmModels.MSG_NOTICE.CreateTT(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "新增成功！";
            else
                webmsg.MSG = "新建失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Select_NoticeTT(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_MSG_NOTICETTParam model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_MSG_NOTICETTParam>(cxdata);
            CRM_MSG_NOTICETTList[] data = crmModels.MSG_NOTICE.ReadTT(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Select_NoticeTTbyTTID(int NoticeTTid)
        {
            token = appClass.CRM_Gettoken();
            CRM_MSG_NOTICETTList data = crmModels.MSG_NOTICE.ReadTTbyTTID(NoticeTTid, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Update_NoticeTT(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_MSG_NOTICETT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_MSG_NOTICETT>(data);
            model.NOTICE = HttpUtility.UrlDecode(model.NOTICE);
            model.XGR = appClass.CRM_GetStaffid();
            int i = crmModels.MSG_NOTICE.UpdateTT(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "修改成功！";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Back_NoticeTT(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_MSG_NOTICETTList[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_MSG_NOTICETTList[]>(data);
            for (int i = 0; i < model.Length; i++)
            {
                int ii = crmModels.MSG_NOTICE.UpdateIsactive(model[i].NOTICETTID, 1, token);
                if (ii <= 0)
                {
                    webmsg.KEY = 0;
                    webmsg.MSG = "第" + (i + 1) + "条数据回退失败！";
                }
            }
            webmsg.KEY = 1;
            webmsg.MSG = "回退成功！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_SH_NoticeTT(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_MSG_NOTICETTList[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_MSG_NOTICETTList[]>(data);
            for (int i = 0; i < model.Length; i++)
            {
                int ii = crmModels.MSG_NOTICE.UpdateIsactive(model[i].NOTICETTID, 3, token);
                if (ii <= 0)
                {
                    webmsg.KEY = 0;
                    webmsg.MSG = "第" + (i + 1) + "条数据审核失败！";
                }
            }
            webmsg.KEY = 1;
            webmsg.MSG = "审核成功！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Submit_NoticeTT(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_MSG_NOTICETTList[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_MSG_NOTICETTList[]>(data);
            for (int i = 0; i < model.Length; i++)
            {
                int ii = crmModels.MSG_NOTICE.UpdateIsactive(model[i].NOTICETTID, 2, token);
                if (ii <= 0)
                {
                    webmsg.KEY = 0;
                    webmsg.MSG = "第" + (i + 1) + "条数据提交失败！";
                }
            }

            webmsg.KEY = 1;
            webmsg.MSG = "提交成功！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Delete_NoticeTT(int NoticeTTid)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.MSG_NOTICE.DeleteTT(NoticeTTid, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }


        [HttpPost]
        public string Data_Insert_NoticeMX_KH(string data, int NOTICETTID)
        {
            token = appClass.CRM_Gettoken();
            CRM_KH_KHList[] KHmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_KH_KHList[]>(data);
            for (int i = 0; i < KHmodel.Length; i++)
            {
                CRM_HG_STAFF staff = crmModels.HG_STAFF.ReadBySTAFFNO(KHmodel[i].SAPSN, token);

                CRM_MSG_NOTICEMX model = new CRM_MSG_NOTICEMX();
                model.NOTICETTID = NOTICETTID;
                model.USERID = staff.STAFFID;

                CRM_MSG_NOTICEMX[] cxdata = crmModels.MSG_NOTICE.ReadMXbyParam(model, token);
                if (cxdata.Length > 0)
                {
                    webmsg.KEY = 0;
                    webmsg.MSG = "第" + (i + 1) + "行数据重复！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }

            }
            for (int i = 0; i < KHmodel.Length; i++)
            {
                CRM_HG_STAFF staff = crmModels.HG_STAFF.ReadBySTAFFNO(KHmodel[i].SAPSN, token);

                CRM_MSG_NOTICEMX model = new CRM_MSG_NOTICEMX();
                model.NOTICETTID = NOTICETTID;
                model.USERID = staff.STAFFID;
                model.USERLX = 1107;
                model.ISACTIVE = 1;

                int ii = crmModels.MSG_NOTICE.CreateMX(model, token);
                if (ii <= 0)
                {
                    webmsg.KEY = ii;
                    webmsg.MSG = "第" + (i + 1) + "行数据新建失败！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
            }
            webmsg.KEY = 1;
            webmsg.MSG = "新建成功！";

            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Insert_NoticeMX_AllJXS(int NOTICETTID)
        {
            token = appClass.CRM_Gettoken();

            CRM_Report_KHModel cxmodel = new CRM_Report_KHModel();
            cxmodel.KHLX = 1;
            CRM_KH_KHList[] KHmodel = crmModels.KH_KH.ReadUser_KH(cxmodel, token);
            for (int i = 0; i < KHmodel.Length; i++)
            {
                CRM_HG_STAFF staff = crmModels.HG_STAFF.ReadBySTAFFNO(KHmodel[i].SAPSN, token);
                CRM_MSG_NOTICEMX model = new CRM_MSG_NOTICEMX();
                model.NOTICETTID = NOTICETTID;
                model.USERID = staff.STAFFID;
                CRM_MSG_NOTICEMX[] cxdata = crmModels.MSG_NOTICE.ReadMXbyParam(model, token);
                if (cxdata.Length > 0)
                {
                    webmsg.KEY = 0;
                    webmsg.MSG = "数据重复！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
            }
            for (int i = 0; i < KHmodel.Length; i++)
            {
                CRM_HG_STAFF staff = crmModels.HG_STAFF.ReadBySTAFFNO(KHmodel[i].SAPSN, token);
                CRM_MSG_NOTICEMX model = new CRM_MSG_NOTICEMX();
                model.NOTICETTID = NOTICETTID;
                model.USERID = staff.STAFFID;
                model.USERLX = 1107;
                model.ISACTIVE = 1;
                int ii = crmModels.MSG_NOTICE.CreateMX(model, token);
                if (ii <= 0)
                {
                    webmsg.KEY = ii;
                    webmsg.MSG = "第" + (i + 1) + "行数据新建失败！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
            }
            webmsg.KEY = 1;
            webmsg.MSG = "新建成功！";

            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Insert_NoticeMX_STAFF(string data, int NOTICETTID)
        {
            token = appClass.CRM_Gettoken();
            CRM_HG_STAFFList[] KHmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_HG_STAFFList[]>(data);
            for (int i = 0; i < KHmodel.Length; i++)
            {
                CRM_MSG_NOTICEMX model = new CRM_MSG_NOTICEMX();
                model.NOTICETTID = NOTICETTID;
                model.USERID = KHmodel[i].STAFFID;
                CRM_MSG_NOTICEMX[] cxdata = crmModels.MSG_NOTICE.ReadMXbyParam(model, token);
                if (cxdata.Length > 0)
                {
                    webmsg.KEY = 0;
                    webmsg.MSG = "第" + (i + 1) + "行数据重复！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
            }
            for (int i = 0; i < KHmodel.Length; i++)
            {
                CRM_MSG_NOTICEMX model = new CRM_MSG_NOTICEMX();
                model.NOTICETTID = NOTICETTID;
                model.USERID = KHmodel[i].STAFFID;
                model.USERLX = 1108;
                model.ISACTIVE = 1;
                int ii = crmModels.MSG_NOTICE.CreateMX(model, token);
                if (ii <= 0)
                {
                    webmsg.KEY = ii;
                    webmsg.MSG = "第" + (i + 1) + "行数据新建失败！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
            }
            webmsg.KEY = 1;
            webmsg.MSG = "新建成功！";

            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_SelectUser_KH(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_Report_KHModel model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_Report_KHModel>(cxdata);
            CRM_KH_KHList[] data = crmModels.KH_KH.ReadUser_KH(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_SelectUser_STAFF(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_Report_STAFFModel model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_Report_STAFFModel>(cxdata);
            CRM_HG_STAFFList[] data = crmModels.HG_STAFF.ReadUser_STAFF(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Select_NoticeMX_KH(int NoticeTTID)
        {
            token = appClass.CRM_Gettoken();
            CRM_MSG_NOTICEMXList_KH[] data = crmModels.MSG_NOTICE.ReadMXbyTTID_KH(NoticeTTID, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Select_NoticeMX_STAFF(int NoticeTTID)
        {
            token = appClass.CRM_Gettoken();
            CRM_MSG_NOTICEMXList_STAFF[] data = crmModels.MSG_NOTICE.ReadMXbyTTID_STAFF(NoticeTTID, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Update_NoticeMX(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_MSG_NOTICEMX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_MSG_NOTICEMX>(data);
            int i = crmModels.MSG_NOTICE.UpdateMX(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "修改成功！";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Delete_NoticeMX(int NOTICEMXID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.MSG_NOTICE.DeleteMX(NOTICEMXID, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Report_InvoiceByKHID()
        {
            token = appClass.CRM_Gettoken();
            CRM_HG_STAFF staff = crmModels.HG_STAFF.ReadBySTAFFID(appClass.CRM_GetStaffid(), token);
            CRM_KH_KH kehu = crmModels.KH_KH.ReadBySAPSN(staff.STAFFNO, token);
            CRM_MSG_INVOICEList[] data = crmModels.MSG_INVOICE.ReadByKHID(kehu.KHID, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Report_NoticeBySTAFFID()
        {
            token = appClass.CRM_Gettoken();
            CRM_HG_STAFF staff = crmModels.HG_STAFF.ReadBySTAFFID(appClass.CRM_GetStaffid(), token);
            CRM_MSG_NOTICETTList[] data = crmModels.MSG_NOTICE.ReadBySTAFFID(appClass.CRM_GetStaffid(), staff.USERLX, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public int Data_Update_InvoiceCount(int INVOICEID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.MSG_INVOICE.AddCount(INVOICEID, token);
            return i;
        }

        [HttpPost]
        public int Data_Update_NoticeMXCount(int NOTICETTID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.MSG_NOTICE.AddCount(NOTICETTID, appClass.CRM_GetStaffid(), token);
            return i;
        }

        public string Data_DaoRu_Invoice()
        {
            token = appClass.CRM_Gettoken();
            DaoRuMsg msg = new DaoRuMsg();
            try
            {
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
                    string[] sheet = { "发票" };


                    //开始做数据校验

                    DataTable data1 = ExcelToDataTable(savePath, sheet[0], true);      //发票
                    #region
                    if (data1 != null)
                    {
                        if (data1.Columns.Contains("发票号码") == false || data1.Columns.Contains("发票数量") == false || data1.Columns.Contains("快递单号") == false)
                        {
                            msg.Msg = "请使用发票新增模版！";
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
                                        bool sap404 = false;
                                        if (data1.Rows[i]["客户SAP编号"].ToString() != "" && crmModels.KH_KH.ReadBySAPSN(data1.Rows[i]["客户SAP编号"].ToString(),token).KHID == 0)
                                            sap404 = true;
                                        if (sap404)
                                        {
                                            msg.Msg = "发票第" + (i + 2) + "行客户SAP编号不存在！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (Regex.IsMatch(data1.Rows[i]["发票数量"].ToString(), @"^\d+$") == false)
                                        {
                                            msg.Msg = "发票第" + (i + 2) + "行发票数量必须为全数字！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (data1.Rows[i]["寄送日期"].ToString() != "")
                                        {
                                            try
                                            {
                                                DateTime myDT = Convert.ToDateTime(data1.Rows[i]["寄送日期"].ToString());

                                            }
                                            catch
                                            {
                                                msg.Msg = "发票第" + (i + 2) + "行寄送日期格式错误！";
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
                    //发票
                    for (int i = 0; i < data1.Rows.Count; i++)
                    {
                        #region

                        CRM_KH_KH KHmodel = crmModels.KH_KH.ReadBySAPSN(data1.Rows[i]["客户SAP编号"].ToString(), token);

                        CRM_MSG_INVOICE model = new CRM_MSG_INVOICE();
                        model.KHID = KHmodel.KHID;
                        model.FPHM = data1.Rows[i]["发票号码"].ToString().Trim();
                        model.FPSL = Convert.ToInt32(data1.Rows[i]["发票数量"].ToString().Trim());
                        model.KDDH = data1.Rows[i]["快递单号"].ToString().Trim();
                        model.JSRQ = Convert.ToDateTime(data1.Rows[i]["寄送日期"].ToString()).ToString("yyyy-MM-dd");
                        model.BEIZ = data1.Rows[i]["备注"].ToString().Trim();
                        model.ISACTIVE = 1;
                        model.CJR = appClass.CRM_GetStaffid();


                        int id = crmModels.MSG_INVOICE.Create(model, token);
                        if (id <= 0)
                        {
                            msg.Msg = "新增发票的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
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
                            if (row.GetCell(j) != null) //同理，没有数据的单元格都默认是""
                                dataRow[j] = row.GetCell(j).ToString();
                        }
                        data.Rows.Add(dataRow);
                    }
                }

                return data;
            }
            catch //(Exception ex)
            {
                //MessageBox.Show("Exception: " + ex.Message);
                return null;
            }
        }


    }
}
