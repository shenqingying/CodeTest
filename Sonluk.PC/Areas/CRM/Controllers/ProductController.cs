using Sonluk.PC.APPCLASS;
using Sonluk.PC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sonluk.UI.Model.CRM.PRODUCT_GROUPService;
using Sonluk.UI.Model.CRM.PRODUCT_KHGROUPService;
using Sonluk.UI.Model.CRM.PRODUCT_PRODUCTGROUPService;
using Sonluk.UI.Model.CRM.PRODUCT_PRODUCTService;
using Sonluk.UI.Model.CRM.PRODUCT_WARNService;
using System.IO;
using Sonluk.UI.Model.CRM.KH_KHService;
using System.Data;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using System.Text.RegularExpressions;

namespace Sonluk.PC.Areas.CRM.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /CRM/Product/
        CRMModels crmModels = new CRMModels();
        AppClass appClass = new AppClass();
        WebMSG webmsg = new WebMSG();
        string token = "";
        string FileSavePath = System.Configuration.ConfigurationManager.AppSettings["FileSavePath"];
        string FileSavePath2 = System.Configuration.ConfigurationManager.AppSettings["FileSavePath2"];
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Insert_Product()
        {
            return View();
        }

        public ActionResult Select_Product()
        {
            Session["location"] = 71;
            return View();
        }

        public ActionResult Update_Product()
        {
            return View();
        }


        public ActionResult Select_ProductType()
        {
            Session["location"] = 72;
            return View();
        }

        [HttpPost]
        public string Data_Insert_Product(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_PRODUCT_PRODUCT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_PRODUCT_PRODUCT>(data);
            model.CJR = appClass.CRM_GetStaffid();
            model.ISACTIVE = 1;
            int i = crmModels.PRODUCT_PRODUCT.Create(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "新增成功";
            else
                webmsg.MSG = "新增失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Select_ProductByParam(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_PRODUCT_PRODUCT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_PRODUCT_PRODUCT>(cxdata);
            CRM_PRODUCT_PRODUCT[] data = crmModels.PRODUCT_PRODUCT.ReadByParam(model, token);
            string netpath = System.Configuration.ConfigurationManager.AppSettings["NETPATH"];
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].ML != "")
                {
                    string[] p = data[i].ML.Split('\\');
                    int count = p.Length - 1;
                    string path = p[count - 2] + @"/" + p[count - 1] + @"/" + p[count];
                    data[i].ML = netpath + path;
                }
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Select_ProductByID(int PRODUCTID)
        {
            token = appClass.CRM_Gettoken();
            CRM_PRODUCT_PRODUCT data = crmModels.PRODUCT_PRODUCT.ReadByID(PRODUCTID, token);
            string netpath = System.Configuration.ConfigurationManager.AppSettings["NETPATH"];
            if (data.ML != "")
            {
                string[] p = data.ML.Split('\\');
                int count = p.Length - 1;
                string path = p[count - 2] + @"/" + p[count - 1] + @"/" + p[count];
                data.ML = netpath + path;
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Update_Product(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_PRODUCT_PRODUCT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_PRODUCT_PRODUCT>(data);
            model.XGR = appClass.CRM_GetStaffid();
            if (model.ML == "")
                model.ML = crmModels.PRODUCT_PRODUCT.ReadByID(model.PRODUCTID, token).ML;
            int i = crmModels.PRODUCT_PRODUCT.Update(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "修改成功！";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Delete_Product(int PRODUCTID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.PRODUCT_PRODUCT.Delete(PRODUCTID, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Insert_ProductImg(int PRODUCTID)        //上传产品照片
        {
            var file = Request.Files[0];

            string date = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss.fff");
            string fileName = "cp_" + date;
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();

            string gotname = file.FileName;
            string[] name = gotname.Split('.');

            int count = name.Length - 1;
            string Path_Data = FileSavePath + @"\upload\img" + @"\CP\" + fileName + "." + name[count];
            string Path = FileSavePath2 + @"\\upload\\img" + @"\\CP\\" + fileName + "." + name[count];
            string netpath = System.Configuration.ConfigurationManager.AppSettings["NETPATH"] + @"img\/" + @"CP\/" + fileName + "." + name[count];
            file.SaveAs(Path);
            FileInfo fi = new FileInfo(Path);
            if (fi.Exists == true)
            {
                if (PRODUCTID != 0)
                {
                    token = appClass.CRM_Gettoken();
                    CRM_PRODUCT_PRODUCT data = crmModels.PRODUCT_PRODUCT.ReadByID(PRODUCTID, token);
                    data.ML = Path_Data;
                    crmModels.PRODUCT_PRODUCT.Update(data, token);
                }


                string json = "{\"code\":0,\"res\":\"" + netpath + "\",\"locapath\":\"" + Path + "\"}";
                return json;
            }
            else
            {
                return "";
            }

        }




        public ActionResult Insert_YJProduct()
        {
            return View();
        }

        public ActionResult Select_YJProduct()
        {
            Session["location"] = 73;
            return View();
        }

        public ActionResult Update_YJProduct()
        {
            return View();
        }

        [HttpPost]
        public string Data_Insert_YJProduct(string data, string KH)
        {
            token = appClass.CRM_Gettoken();
            CRM_PRODUCT_WARN model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_PRODUCT_WARN>(data);
            CRM_KH_KHList[] KHmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_KH_KHList[]>(KH);
            model.CJR = appClass.CRM_GetStaffid();
            model.ISACTIVE = 1;
            for (int i = 0; i < KHmodel.Length; i++)
            {
                model.KHID = KHmodel[i].KHID;
                int ii = crmModels.PRODUCT_WARN.Create(model, token);
                if (ii <= 0)
                {
                    webmsg.KEY = ii;
                    webmsg.MSG = "第" + (i + 1) + "行数据新建失败！请检查是否重复";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
            }
            webmsg.KEY = 1;
            webmsg.MSG = "新建成功！";

            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Select_YJProductByID(int PROWARNID)
        {
            token = appClass.CRM_Gettoken();
            CRM_PRODUCT_WARN data = crmModels.PRODUCT_WARN.ReadByID(PROWARNID, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Select_YJProductByParam(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_PRODUCT_WARN model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_PRODUCT_WARN>(cxdata);
            CRM_PRODUCT_WARN[] data = crmModels.PRODUCT_WARN.ReadByParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Update_YJProduct(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_PRODUCT_WARN model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_PRODUCT_WARN>(data);
            model.XGR = appClass.CRM_GetStaffid();
            int i = crmModels.PRODUCT_WARN.Update(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "修改成功！";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Update_YJProducts(string data, double YJXS)
        {
            token = appClass.CRM_Gettoken();
            CRM_PRODUCT_WARN[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_PRODUCT_WARN[]>(data);

            for (int i = 0; i < model.Length; i++)
            {
                model[i].XGR = appClass.CRM_GetStaffid();
                model[i].YJXS = YJXS;
                int ii = crmModels.PRODUCT_WARN.Update(model[i], token);
                if (ii <= 0)
                {
                    webmsg.KEY = ii;
                    webmsg.MSG = "第" + i + "行数据修改失败！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
            }
            webmsg.KEY = 1;
            webmsg.MSG = "修改成功！";

            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Delete_YJProduct(int PROWARNID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.PRODUCT_WARN.Delete(PROWARNID, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }










        public ActionResult Select_ProductGroup()
        {
            Session["location"] = 74;
            return View();
        }
        public ActionResult Update_ProductGroup()    //暂时没用
        {
            return View();
        }
        public ActionResult ProductToGroup()
        {
            Session["location"] = 77;
            return View();
        }
        public ActionResult DaoRu_ProductGroup()
        {
            Session["location"] = 75;
            return View();
        }
        public ActionResult SetKH_ProductGroup()
        {
            Session["location"] = 76;
            return View();
        }

        [HttpPost]
        public string Data_Insert_ProductGroup(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_PRODUCT_GROUP model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_PRODUCT_GROUP>(data);
            model.CJR = appClass.CRM_GetStaffid();
            model.ISACTIVE = 1;
            int i = crmModels.PRODUCT_GROUP.Create(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "新增成功";
            else
                webmsg.MSG = "新增失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Select_ProductGroup()
        {
            token = appClass.CRM_Gettoken();
            CRM_PRODUCT_GROUP[] data = crmModels.PRODUCT_GROUP.Read(token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Update_ProductGroup(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_PRODUCT_GROUP model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_PRODUCT_GROUP>(data);
            int i = crmModels.PRODUCT_GROUP.Update(model, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "修改成功";
            else
                webmsg.MSG = "修改失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Delete_ProductGroup(int GROUPID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.PRODUCT_GROUP.Delete(GROUPID, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }



        [HttpPost]
        public string Data_Insert_ProductToGroup(string data, int GROUPID)
        {
            token = appClass.CRM_Gettoken();
            CRM_PRODUCT_PRODUCT[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_PRODUCT_PRODUCT[]>(data);
            for (int i = 0; i < model.Length; i++)
            {
                int ii = crmModels.PRODUCT_PRODUCTGROUP.Create(model[i].PRODUCTID, GROUPID, token);
                if (ii <= 0)
                {
                    webmsg.KEY = ii;
                    webmsg.MSG = "第" + (i + 1) + "行数据新建失败！请检查是否重复";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
            }
            webmsg.KEY = 1;
            webmsg.MSG = "新建成功！";

            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Select_ProductToGroup(string CPMC, int GROUPID)
        {
            token = appClass.CRM_Gettoken();
            CRM_PRODUCT_PRODUCTGROUP model = new CRM_PRODUCT_PRODUCTGROUP();
            model.CPMC = CPMC;
            model.GROUPID = GROUPID;
            CRM_PRODUCT_PRODUCTGROUP[] data = crmModels.PRODUCT_PRODUCTGROUP.Read(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Delete_ProductToGroup(int PRODUCTID, int GROUPID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.PRODUCT_PRODUCTGROUP.Delete(PRODUCTID, GROUPID, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }



        [HttpPost]
        public string Data_Insert_KHToGroup(string data, int GROUPID)
        {
            token = appClass.CRM_Gettoken();
            CRM_KH_KHList[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_KH_KHList[]>(data);
            for (int i = 0; i < model.Length; i++)
            {
                int ii = crmModels.PRODUCT_KHGROUP.Create(model[i].KHID, GROUPID, token);
                if (ii <= 0)
                {
                    webmsg.KEY = ii;
                    webmsg.MSG = "第" + (i + 1) + "行数据新建失败！请检查是否重复";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
            }
            webmsg.KEY = 1;
            webmsg.MSG = "新建成功！";

            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_Select_KHToGroup(string SAPSN, string KHMC, int GROUPID)
        {
            token = appClass.CRM_Gettoken();
            CRM_PRODUCT_KHGROUP model = new CRM_PRODUCT_KHGROUP();
            model.SAPSN = SAPSN;
            model.KHMC = KHMC;
            model.GROUPID = GROUPID;
            CRM_PRODUCT_KHGROUP[] data = crmModels.PRODUCT_KHGROUP.Read(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Delete_KHToGroup(int KHID, int GROUPID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.PRODUCT_KHGROUP.Delete(KHID, GROUPID, token);
            webmsg.KEY = i;
            if (i > 0)
                webmsg.MSG = "删除成功！";
            else
                webmsg.MSG = "删除失败！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }



        public string Data_DaoRu_ProductGroup()
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
                    string[] sheet = { "产品", "产品组", "客户产品组" };


                    //开始做数据校验

                    DataTable data1 = ExcelToDataTable(savePath, sheet[0], true);      //产品
                    #region
                    if (data1 != null)
                    {
                        if (data1.Columns.Contains("产品类型") == false || data1.Columns.Contains("产品系列") == false || data1.Columns.Contains("产品型号") == false)
                        {
                            msg.Msg = "请使用产品新增模版！";
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
                                        int cplx = crmModels.HG_DICT.ReadByDICNAMEandFID(data1.Rows[i]["产品类型"].ToString(), 53, 0, token);
                                        if (cplx == 0)
                                        {
                                            msg.Msg = "产品第" + (i + 2) + "行产品类型不存在！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        int cpxl = crmModels.HG_DICT.ReadByDICNAMEandFID(data1.Rows[i]["产品系列"].ToString(), 54, cplx, token);
                                        if (cpxl == 0)
                                        {
                                            msg.Msg = "产品第" + (i + 2) + "行产品系列不存在！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        int cpxh = crmModels.HG_DICT.ReadByDICNAMEandFID(data1.Rows[i]["产品型号"].ToString(), 55, cpxl, token);
                                        if (cpxh == 0)
                                        {
                                            msg.Msg = "产品第" + (i + 2) + "行产品型号不存在！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (data1.Rows[i]["产品名称"].ToString() == "")
                                        {
                                            msg.Msg = "产品第" + (i + 2) + "行产品名称不可为空！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (data1.Rows[i]["产品图片"].ToString() == "")
                                        {
                                            msg.Msg = "产品第" + (i + 2) + "行产品图片不可为空！";
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

                    DataTable data2 = ExcelToDataTable(savePath, sheet[1], true);      //产品组
                    #region
                    if (data2 != null)
                    {
                        if (data2.Columns.Contains("产品组") == false || data2.Columns.Contains("产品品号") == false)
                        {
                            msg.Msg = "请使用产品新增模版！";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                        else
                        {
                            try
                            {
                                //做数据验证
                                if (data2.Rows.Count > 0)
                                {
                                    for (int i = 0; i < data2.Rows.Count; i++)
                                    {

                                        int cpz = crmModels.PRODUCT_GROUP.ReadByIDGroupName(data2.Rows[i]["产品组"].ToString(), token);
                                        if (cpz == 0)
                                        {
                                            msg.Msg = "产品组第" + (i + 2) + "行产品组不存在！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        CRM_PRODUCT_PRODUCT cx = new CRM_PRODUCT_PRODUCT();
                                        cx.CPPH = data2.Rows[i]["产品品号"].ToString();
                                        CRM_PRODUCT_PRODUCT[] cp = crmModels.PRODUCT_PRODUCT.ReadByParam(cx, token);
                                        if (cp.Length == 0)
                                        {
                                            msg.Msg = "产品组第" + (i + 2) + "行产品品号不存在！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }
                                        if (cp.Length != 1)
                                        {
                                            msg.Msg = "产品组第" + (i + 2) + "行产品品号存在复数目标！";
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

                    DataTable data3 = ExcelToDataTable(savePath, sheet[2], true);      //客户产品组
                    #region
                    if (data3 != null)
                    {
                        if (data3.Columns.Contains("产品组") == false || data3.Columns.Contains("客户编号") == false || data3.Columns.Contains("客户SAP编号") == false)
                        {
                            msg.Msg = "请使用产品新增模版！";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                        else
                        {
                            try
                            {
                                //做数据验证
                                if (data3.Rows.Count > 0)
                                {
                                    for (int i = 0; i < data3.Rows.Count; i++)
                                    {
                                        int cpz = crmModels.PRODUCT_GROUP.ReadByIDGroupName(data3.Rows[i]["产品组"].ToString(), token);
                                        if (cpz == 0)
                                        {
                                            msg.Msg = "客户产品组第" + (i + 2) + "行产品组不存在！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }

                                        if (data3.Rows[i]["客户编号"].ToString() == "" && data3.Rows[i]["客户SAP编号"].ToString() == "")
                                        {
                                            msg.Msg = "客户产品组第" + (i + 2) + "行客户编号不可为空！";
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                        }

                                        if (data3.Rows[i]["客户编号"].ToString() != "")
                                        {
                                            CRM_KH_KH kh_model = crmModels.KH_KH.ReadByCRMID(data3.Rows[i]["客户编号"].ToString(), token);
                                            if (kh_model.KHID == 0)
                                            {
                                                msg.Msg = "客户产品组第" + (i + 2) + "行客户编号不存在！";
                                                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                            }
                                        }

                                        if (data3.Rows[i]["客户SAP编号"].ToString() != "")
                                        {
                                            CRM_KH_KH kh_model = crmModels.KH_KH.ReadBySAPSN(data3.Rows[i]["客户SAP编号"].ToString(), token);
                                            if (kh_model.KHID == 0)
                                            {
                                                msg.Msg = "客户产品组第" + (i + 2) + "行客户SAP编号不存在！";
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
                    //产品
                    for (int i = 0; i < data1.Rows.Count; i++)
                    {
                        #region
                        CRM_PRODUCT_PRODUCT model = new CRM_PRODUCT_PRODUCT();
                        model.CPLX = crmModels.HG_DICT.ReadByDICNAMEandFID(data1.Rows[i]["产品类型"].ToString().Trim(), 53, 0, token);
                        model.CPXL = crmModels.HG_DICT.ReadByDICNAMEandFID(data1.Rows[i]["产品系列"].ToString().Trim(), 54, model.CPLX, token);
                        model.CPXH = crmModels.HG_DICT.ReadByDICNAMEandFID(data1.Rows[i]["产品型号"].ToString().Trim(), 55, model.CPXL, token);
                        model.CPPH = data1.Rows[i]["产品品号"].ToString().Trim();
                        model.CPMC = data1.Rows[i]["产品名称"].ToString().Trim();
                        model.CODE = data1.Rows[i]["条形码"].ToString().Trim();
                        model.DDDW = data1.Rows[i]["订单单位"].ToString().Trim();
                        model.BZDW = data1.Rows[i]["标准单位"].ToString().Trim();
                        model.RATE = Convert.ToInt32(data1.Rows[i]["转换率"].ToString().Trim());
                        model.ML = FileSavePath + @"\upload\img" + @"\CP\" + data1.Rows[i]["产品图片"].ToString().Trim();
                        model.ML_MOB = "";
                        model.BEIZ = "";
                        model.ISACTIVE = 1;
                        model.CJR = appClass.CRM_GetStaffid();

                        int id = crmModels.PRODUCT_PRODUCT.Create(model, token);
                        if (id <= 0)
                        {
                            msg.Msg = "新增产品的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                        #endregion
                    }
                    //产品组
                    for (int i = 0; i < data2.Rows.Count; i++)
                    {
                        #region
                        CRM_PRODUCT_PRODUCT cx = new CRM_PRODUCT_PRODUCT();
                        cx.CPPH = data2.Rows[i]["产品品号"].ToString();
                        CRM_PRODUCT_PRODUCT[] cp = crmModels.PRODUCT_PRODUCT.ReadByParam(cx, token);
                        int cpz = crmModels.PRODUCT_GROUP.ReadByIDGroupName(data2.Rows[i]["产品组"].ToString(), token);
                        int id = crmModels.PRODUCT_PRODUCTGROUP.Create(cp[0].PRODUCTID, cpz, token);
                        if (id <= 0)
                        {
                            msg.Msg = "新增产品组的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                        }
                        #endregion
                    }
                    //客户产品组
                    for (int i = 0; i < data3.Rows.Count; i++)
                    {
                        #region
                        int cpz = crmModels.PRODUCT_GROUP.ReadByIDGroupName(data3.Rows[i]["产品组"].ToString(), token);



                        CRM_KH_KH kh_model = new CRM_KH_KH();
                        if (data3.Rows[i]["客户编号"].ToString() != "")
                        {
                            kh_model = crmModels.KH_KH.ReadByCRMID(data3.Rows[i]["客户编号"].ToString(), token);
                        }
                        else
                        {
                            kh_model = crmModels.KH_KH.ReadBySAPSN(data3.Rows[i]["客户SAP编号"].ToString(), token);
                        }


                        int id = crmModels.PRODUCT_KHGROUP.Create(kh_model.KHID, cpz, token);
                        if (id <= 0)
                        {
                            msg.Msg = "新增客户产品组的第" + (i + 2) + "行出现问题，请记录当前报错信息并联系管理员";
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
