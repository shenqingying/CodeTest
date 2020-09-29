using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sonluk.UI.Model.Account.AccessService;
using Sonluk.UI.Model.MM.PurchaseOrderService;
using Sonluk.UI.Model.BC.BarCodeService;
using Sonluk.Models;
using Sonluk.UI.Model.MES.SY_GCService;

namespace Sonluk.Areas.MM.Controllers
{
    public class ReportController : Controller
    {
        MMModels models = new MMModels();
        BCModels bcmodels = new BCModels();
        MESModels mesmoldes = new MESModels();
        //
        // GET: /MM/Report/

        public ActionResult Index()
        {
            return View();
        }

        //
        // POST: /MM/Report/AnalysePrintData
        [HttpPost]
        public string AnalysePrintData(string type, int status, IList<POItemInfo> itemNodes)
        {
            string pageSize = "";
            string message = "";
            HttpCookie cookie = Request.Cookies.Get("IQCPMPageSize");

            if (type == "RKBS")
            {

                if (itemNodes.Count > 0)
                {
                    //int count = itemNodes.ToList().FindIndex(p => string.IsNullOrEmpty(p.Material));
                    //if (count != -1)
                    //{
                    //    return "采购订单" + itemNodes[count].PONumber + "/" + itemNodes[count].Number + "没有物料号无法查询入库标识";
                    //}
                    Session["RKBS_PONumber"] = itemNodes[0].PONumber;
                    Session["RKBS_Number"] = itemNodes[0].Number;

                    if (itemNodes[0].Vendor == null)
                    {
                        AccountInfo account = (AccountInfo)Session["Account"];
                        itemNodes[0].Vendor = account.ID;
                    }
                    Session["RKBS_Vendor"] = itemNodes[0].Vendor;
                    Session["RKBS_NeedQty"] = itemNodes[0].DelivQty;
                    Session["RKBS_PcsInCtn"] = itemNodes[0].PcsInCtn;
                    Session["RKBS_PcsInPal"] = itemNodes[0].PcsInPal;
                    Session["RKBS_Material"] = itemNodes[0].Material;
                    Session["RKBS_MaterialDescription"] = itemNodes[0].MaterialDescription;
                }
            }
            else if (type == "RKBSZH")
            {
                if (itemNodes.Count > 0)
                {
                    IList<ZSL_BCS104> PLIST = new List<ZSL_BCS104>();
                    foreach (POItemInfo pi in itemNodes)
                    {
                        ZSL_BCS104 node = new ZSL_BCS104();
                        node.Ebeln = pi.PONumber;
                        node.Ebelp = pi.Number.ToString().PadLeft(5, '0');
                        PLIST.Add(node);
                    }

                    if (itemNodes[0].Vendor == null)
                    {
                        AccountInfo account = (AccountInfo)Session["Account"];
                        itemNodes[0].Vendor = account.ID;
                    }
                    int GLTS = 0;
                    string DYFS = "V";
                    string USER = itemNodes[0].Vendor;
                    string MODE = "Y";
                    int FS = 1;

                    message = models.PurchaseOrder.GenerateStorageIdentificationZH(GLTS, DYFS, USER, MODE, FS, PLIST).Trim();
                    if (message == "")
                        Session["RKBSZH_POLIST"] = models.PurchaseOrder.GetStorageIdentificationZHList(GLTS, DYFS, USER, MODE, FS, PLIST);
                }
            }
            else if (type == "RKBSGCL")
            {
                List<ZSL_BCS303_CT> nodes = new List<ZSL_BCS303_CT>();
                for (int i = 0; i < itemNodes.Count; i++)
                {
                    ZSL_BCS303_CT node = new ZSL_BCS303_CT();
                    node.Ebeln = itemNodes[i].PONumber.ToString();
                    node.Ebelp = itemNodes[i].Number.ToString();
                    nodes.Add(node);
                }


                ZMMFUN_PURBS_READ res = models.PurchaseOrder.ZMMFUN_PURBS_READ(nodes);
                if (res.MES_RETURN.TYPE.Equals("S"))
                {
                    Session["PRINTRKBS_GCL"] = models.PurchaseOrder.ZMMFUN_PURBS_READ(nodes);
                }
                else
                {

                    message = res.MES_RETURN.MESSAGE;
                }

                //Session["PRINTRKBS_GCL"] = res;

            }
            else
            {
                if (cookie != null)
                {
                    pageSize = cookie.Value;
                }
                if (itemNodes != null)
                {
                    //List<POInfoClassify> a = models.PurchaseOrder.AnalysePrintData(type, status, pageSize, itemNodes);
                    //object b = a[0].Children[0].Items[0].CustomText;
                    if (Session["Account"] != null && (type == "IQCPM" || type == "DeliveryF"))
                    {
                        AccountInfo account = (AccountInfo)Session["Account"];
                        foreach (var item in itemNodes)
                        {
                            if (string.IsNullOrEmpty(item.Vendor)) item.Vendor = account.ID;
                            if (string.IsNullOrEmpty(item.LNAME)) item.LNAME = account.Name;
                        }
                    }
                    Session["PrintData"] = models.PurchaseOrder.AnalysePrintData(type, status, pageSize, itemNodes, Session["crmtoken"] == null ? "" : Session["crmtoken"].ToString());
                }
                else
                {
                    message = "数据异常！";
                }
            }

            return message;
        }

        public ActionResult PurchaseOrder()
        {
            IList<PageInfoOfPOInfo> nodes = new List<PageInfoOfPOInfo>();
            if (Session["PrintData"] != null)
            {
                nodes = (IList<PageInfoOfPOInfo>)Session["PrintData"];
                //Session["PrintData"] = null;
            }
            return View(nodes);
        }


        // GET: /MM/Report/IQC
        public ActionResult IQC()
        {
            IList<POHeaderInfo> nodes = new List<POHeaderInfo>();
            if (Session["PrintData"] != null)
            {
                nodes = (IList<POHeaderInfo>)Session["PrintData"];
                Session["PrintData"] = null;
            }
            AccountInfo account = (AccountInfo)Session["Account"];
            ViewBag.Vendor = account.ID + "/" + account.Name;
            ViewBag.Printer = account.ID;
            return View(nodes);
        }


        // GET: /MM/Report/IQCPM
        public ActionResult IQCPM()
        {
            IList<PageInfoOfPOInfo> nodes = new List<PageInfoOfPOInfo>();
            if (Session["PrintData"] != null)
            {
                nodes = (IList<PageInfoOfPOInfo>)Session["PrintData"];
                //Session["PrintData"] = null;
            }

            //获取打印信息（供应商和供应商编号已移至条目内部获取，不从账号获取）
            AccountInfo account = (AccountInfo)Session["Account"];
            if (account.Group == 1)
            {
                //ViewBag.VendorNumber = account.ID;
                //ViewBag.Vendor = account.Name;
                ViewBag.Printer = account.ID;
            }
            else
            {
                //ViewBag.VendorNumber = "";
                //ViewBag.Vendor = "";
                ViewBag.Printer = account.Name;
            }

            //获取条码图片（已移至cshtml）
            //var TMImage = new Dictionary<string, string>();
            //foreach (var item in nodes)
            //{
            //    if (item.Children.Length > 0)
            //    {
            //        Byte[] objcode = mesmoldes.BarCode.CreateBarCode(item.Children[0].Header.SHNO, "CODE_128", 380, 100, 1);
            //        if (!TMImage.ContainsKey(item.Children[0].Header.SHNO)) TMImage.Add(item.Children[0].Header.SHNO, Convert.ToBase64String(objcode));
            //    }
            //}
            //ViewBag.TMImage = TMImage;

            //获取工厂全称已放到API
            //for (int i = 0; i < nodes.Count; i++)
            //{
            //    if (nodes[i].Children.Length > 0)
            //    {
            //        string gc = nodes[i].Children[0].Header.Company;
            //        MES_SY_GC gcmodel = new MES_SY_GC();
            //        gcmodel.GC = gc;
            //        string ptoken = Session["crmtoken"].ToString();
            //        MES_SY_GC[] gcres = mesmoldes.SY_GC.read(gcmodel, ptoken);
            //        if (gcres.Length > 0)
            //        {
            //            nodes[i].Children[0].Header.CompanyName = gcres[0].GCDYMS;
            //        }
            //    }
            //}

            return View(nodes);
        }


        //  GET: /MM/Report/Delivery
        public ActionResult Delivery()
        {
            IList<PageInfoOfPOInfo> nodes = new List<PageInfoOfPOInfo>();
            if (Session["PrintData"] != null)
            {
                nodes = (IList<PageInfoOfPOInfo>)Session["PrintData"];
            }
            AccountInfo account = (AccountInfo)Session["Account"];
            ViewBag.Vendor = account.ID + "/" + account.Name;
            ViewBag.Printer = account.ID;
            return View(nodes);
        }

        // 成品供应商送货单
        // GET: /MM/Report/DeliveryF
        public ActionResult DeliveryF()
        {
            IList<PageInfoOfPOInfo> nodes = new List<PageInfoOfPOInfo>();
            if (Session["PrintData"] != null)
            {
                nodes = (IList<PageInfoOfPOInfo>)Session["PrintData"];
            }

            //获取打印信息（供应商和供应商编号已移至条目内部获取，不从账号获取）
            AccountInfo account = (AccountInfo)Session["Account"];
            if (account.Group == 1)
            {
                //ViewBag.VendorNumber = account.ID;
                //ViewBag.Vendor = account.Name;
                ViewBag.Printer = account.ID;
            }
            else
            {
                //ViewBag.VendorNumber = "";
                //ViewBag.Vendor = "";
                ViewBag.Printer = account.Name;
            }

            return View(nodes);
        }
        //送货清单（工程类）zwk
        public ActionResult DeliveryGCL()
        {
            //string a = models.PurchaseOrder.ZMMFUN_GCDZ_READ("1000");
            IList<PageInfoOfPOInfo> nodes = new List<PageInfoOfPOInfo>();
            if (Session["PrintData"] != null)
            {
                nodes = (IList<PageInfoOfPOInfo>)Session["PrintData"];
            }

            AccountInfo account = (AccountInfo)Session["Account"];
            if (account.Group == 1)
            {
                ViewBag.VendorNumber = account.ID;
                ViewBag.Vendor = account.Name;
                ViewBag.Printer = account.ID;
            }
            else
            {
                ViewBag.VendorNumber = "";
                ViewBag.Vendor = "";
                ViewBag.Printer = account.Name;
            }

            return View(nodes);
        }
        //入库标识工程类
        public ActionResult RKBSGCL()
        {
            ZMMFUN_PURBS_READ node = new ZMMFUN_PURBS_READ();
            if (Session["PRINTRKBS_GCL"] != null)
            {
                node = (ZMMFUN_PURBS_READ)Session["PRINTRKBS_GCL"];
            }
            ViewBag.model = node;
            return View();
        }
        //
        // GET: /MM/Report/Config
        public ActionResult Config()
        {
            return View();
        }

        //
        // GET: /MM/Report/PageSize
        public bool PageSize(string size)
        {
            HttpCookie cookie = new HttpCookie("IQCPMPageSize");
            cookie.Value = size;
            cookie.Path = "/";
            cookie.Expires = DateTime.MaxValue;
            Response.Cookies.Add(cookie);

            return true;
        }


        //
        // GET: /MM/Report/Test
        public ActionResult Test()
        {
            return View();
        }


        public ActionResult RKBSPrint()
        {
            IList<FileStreamInfo> files = (IList<FileStreamInfo>)Session["RKBS_files"];

            return View(files);
        }

        public ActionResult RKBS()
        {
            ZSL_BCS007 zbc = bcmodels.BarCode.ZBCFUN_MAT_GET(Session["RKBS_Material"].ToString());

            //Int32 zsl = 1;

            ViewBag.RKBS_PONumber = Session["RKBS_PONumber"].ToString();
            ViewBag.RKBS_Number = Session["RKBS_Number"].ToString();
            ViewBag.RKBS_Vendor = Session["RKBS_Vendor"].ToString();
            ViewBag.RKBS_NeedQty = Session["RKBS_NeedQty"].ToString();
            ViewBag.RKBS_Material = Session["RKBS_Material"].ToString();
            ViewBag.RKBS_MaterialDescription = Session["RKBS_MaterialDescription"].ToString();
            //ViewBag.RKBS_ZPAR = zbc.Zpar;
            //ViewBag.RKBS_ZBON = zbc.Zbon;
            //ViewBag.RKBS_ZPKS = zbc.Zpks;
            //ViewBag.RKBS_ZPCS = zbc.Zpcs;

            //if (zbc.Zpar != 0)  zsl = zsl * zbc.Zpar;
            //if (zbc.Zbon != 0) zsl = zsl * zbc.Zbon;
            //if (zbc.Zpks != 0) zsl = zsl * zbc.Zpks;
            //if (zbc.Zpcs != 0) zsl = zsl * zbc.Zpcs;

            //ViewBag.RKBS_ZSL = zsl;
            ViewBag.RKBS_ZSL = Convert.ToInt32(Session["RKBS_PcsInPal"]);
            if (Session["RKBS_PcsInCtn"] != null)
            {
                if (Convert.ToInt32(Session["RKBS_PcsInCtn"]) != 0)
                    ViewBag.RKBS_ZPAR = Convert.ToInt32(Session["RKBS_PcsInPal"]) / Convert.ToInt32(Session["RKBS_PcsInCtn"]);
            }

            ViewBag.RKBS_LTBS = zbc.Zltbs == "Y" ? "Y" : "";
            ViewBag.RKBS_LTBST = ViewBag.RKBS_LTBS == "Y" ? "流通装" : "非流通装";
            ViewBag.RKBS_READONLY = ViewBag.RKBS_LTBS == "Y" ? "readonly" : "";

            return View();
        }

        public ActionResult RKBSZH()
        {
            IList<ZSL_BCS104> plist = (IList<ZSL_BCS104>)Session["RKBSZH_POLIST"];
            return View(plist);
        }

        [HttpPost]
        public string GenerateRKBS(string CG, string XM, string TPM, string GYS, int TS, int XS, int SL, string MODE, string LTBS)
        {
            string message = "";
            string CGXM = "";
            CGXM = CG + XM.PadLeft(5, '0');
            message = models.PurchaseOrder.GenerateStorageIdentification(CGXM, TPM, GYS, TS, XS, SL, MODE, LTBS);
            return message;
        }

        [HttpPost]
        public string GenerateRKBSZH(int GLTS, int FS, IList<ZSL_BCS104> itemNodes)
        {
            string message = "";

            AccountInfo account = (AccountInfo)Session["Account"];
            string DYFS = "V";
            string USER = account.ID;
            string MODE = "C";

            message = models.PurchaseOrder.GenerateStorageIdentificationZH(GLTS, DYFS, USER, MODE, FS, itemNodes);
            return message;
        }

        [HttpPost]
        public string PrepareRKBSData(string CG, string XM, string TPM, string GYS, int TS, int XS, int SL, string MODE, string LTBS)
        {
            string message = "";
            string CGXM = "";
            CGXM = CG + XM.PadLeft(5, '0');

            IList<FileStreamInfo> files = new List<FileStreamInfo>();

            files = models.PurchaseOrder.GetStorageIdentificationPDF(CGXM, TPM, GYS, TS, XS, SL, MODE, LTBS);
            Session["RKBS_files"] = files;
            return message;
        }

        [HttpPost]
        public string PrepareRKBSZHData(IList<ZSL_BCS104> itemNodes)
        {
            string message = "";

            AccountInfo account = (AccountInfo)Session["Account"];
            IList<FileStreamInfo> files = new List<FileStreamInfo>();
            int GLTS = 1;
            string DYFS = "V";
            string USER = account.ID;
            string MODE = "P";
            int FS = 1;

            files = models.PurchaseOrder.GetStorageIdentificationZHPDF(GLTS, DYFS, USER, MODE, FS, itemNodes);
            Session["RKBS_files"] = files;
            return message;
        }

        [HttpPost]
        public ActionResult _RKBSList(string CG, string XM, string TPM, string GYS, int TS, int XS, int SL, string MODE, string LTBS)
        {
            string CGXM = "";
            CGXM = CG + XM.PadLeft(5, '0');
            return PartialView(models.PurchaseOrder.GetStorageIdentificationList(CGXM, TPM, GYS, TS, XS, SL, MODE, LTBS));
        }

        [HttpPost]
        public ActionResult _RKBSZHList(IList<ZSL_BCS104> itemNodes)
        {
            //string message = "";

            AccountInfo account = (AccountInfo)Session["Account"];
            int GLTS = 1;
            string DYFS = "V";
            string USER = account.ID;
            string MODE = "Q";
            int FS = 1;

            return PartialView(models.PurchaseOrder.GetStorageIdentificationZHList(GLTS, DYFS, USER, MODE, FS, itemNodes));
        }

        [HttpPost]
        public string DeleteRKBS(string IV_TPM)
        {
            string message = "";
            AccountInfo account = (AccountInfo)Session["Account"];
            message = models.PurchaseOrder.ZBCFUN_RKBS_CHANGE(IV_TPM, "V", account.ID);

            return message;
        }
    }
}
