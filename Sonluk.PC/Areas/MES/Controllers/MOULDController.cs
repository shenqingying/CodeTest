using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Sonluk.PC.APPCLASS;
using Sonluk.PC.Models;
using Sonluk.UI.Model.MES.PMM_MOULDService;
using Sonluk.UI.Model.MES.PMM_MTCService;
using Sonluk.UI.Model.MES.PMM_QRService;
using Sonluk.UI.Model.MES.PMM_STAFFService;
using Sonluk.UI.Model.MES.PMM_SYSService;
using Sonluk.UI.Model.MES.SY_GCService;
using Sonluk.UI.Model.MES.SY_GZZX_SBHService;
using Sonluk.UI.Model.MES.SY_GZZX_WLLBService;
using Sonluk.UI.Model.MES.SY_GZZXService;
using Sonluk.UI.Model.MES.SY_MATERIALService;
using Sonluk.UI.Model.MES.SY_TYPEMXService;
using Sonluk.UI.Model.MES.ZS_SY_CLPBService;
using Sonluk.UI.Model.MODEL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Sonluk.PC.Areas.MES.Controllers
{
    public class MOULDController : Controller
    {
        MESModels mesModels = new MESModels();
        const string PreMenuName = "模具维护";
        const string CookieName = "Sonluk.MES.MOULD";
        const string SecurityKey = "fa5$F^D&";

        // GET: /MES/MOULD/
        public ActionResult Index()
        {
            AppClass.SetSession("location", 0);
            return View();
        }
        public ActionResult MT_MOULD()
        {
            AppClass.SetSession("location", 10033);
            ViewBag.PreMenu = PreMenuName;
            return View();
        }
        public ActionResult MT_MOULDW()
        {
            AppClass.SetSession("location", 10048);
            ViewBag.PreMenu = PreMenuName;
            return View();
        }
        public ActionResult MT_MOULDS()
        {
            AppClass.SetSession("location", 10047);
            ViewBag.PreMenu = PreMenuName;
            return View();
        }
        public ActionResult MT_QLTY()
        {
            AppClass.SetSession("location", 10034);
            ViewBag.PreMenu = PreMenuName;
            return View();
        }
        public ActionResult MT_CONFIRM()
        {
            AppClass.SetSession("location", 10035);
            ViewBag.PreMenu = PreMenuName;
            return View();
        }
        public ActionResult REP_NEW()
        {
            AppClass.SetSession("location", 10036);
            ViewBag.PreMenu = PreMenuName;
            return View();
        }
        public ActionResult REP_ALTER_CFMS()
        {
            AppClass.SetSession("location", 10037);
            ViewBag.PreMenu = PreMenuName;
            return View();
        }
        public ActionResult REP_CFM_MM()
        {
            AppClass.SetSession("location", 10038);
            ViewBag.PreMenu = PreMenuName;
            return View();
        }
        public ActionResult REP_CFM_WT()
        {
            AppClass.SetSession("location", 10039);
            ViewBag.PreMenu = PreMenuName;
            return View();
        }
        public ActionResult REP_CFM_QC()
        {
            AppClass.SetSession("location", 10040);
            ViewBag.PreMenu = PreMenuName;
            return View();
        }
        public ActionResult REP_CFM_TEC()
        {
            AppClass.SetSession("location", 10041);
            ViewBag.PreMenu = PreMenuName;
            return View();
        }
        public ActionResult REP_ALTER_CFME()
        {
            AppClass.SetSession("location", 10042);
            ViewBag.PreMenu = PreMenuName;
            return View();
        }
        public ActionResult REP_SEARCH()
        {
            AppClass.SetSession("location", 10043);
            ViewBag.PreMenu = PreMenuName;
            return View();
        }
        public ActionResult BIGSCREEN()
        {
            if (!AppendCookie(CookieName) || GetCookie(CookieName, "BIGSCREEN_refresh") == null) ViewBag.DefaultCount = 30;
            else ViewBag.DefaultCount = GetCookie(CookieName, "BIGSCREEN_refresh");
            if (!AppendCookie(CookieName) || GetCookie(CookieName, "BIGSCREEN_TableRows") == null) ViewBag.DefaultTR = 20;
            else ViewBag.DefaultTR = GetCookie(CookieName, "BIGSCREEN_TableRows");
            return View();
        }
        public ActionResult BIGSCREEN_CONFIG()
        {
            AppClass.SetSession("location", 10044);
            ViewBag.PreMenu = PreMenuName;
            return View();
        }
        public ActionResult MT_STAFF()
        {
            AppClass.SetSession("location", 10045);
            ViewBag.PreMenu = PreMenuName;
            return View();
        }

        #region 通用 Get 和 Post

        public ActionResult Export_Download(string filename, string filenameout)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/MES/ExportFile/{1}", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", filenameout);
        }

        [HttpPost]
        public string GetSYSConfig(string KEY)
        {
            MES_PMM_SYS model = new MES_PMM_SYS();
            model.KEY = KEY;
            model.STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            return AppClass.EasyCall<MES_PMM_SYS, MES_PMM_SYS>(model, mesModels.PMM_SYS.SELECT);
        }

        [HttpPost]
        public string SetSYSConfig(string KEY, string VALUE)
        {
            MES_PMM_SYS model = new MES_PMM_SYS();
            model.KEY = KEY;
            model.VALUE = VALUE;
            model.STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            return AppClass.EasyCall<MES_PMM_SYS, MES_RETURN_UI>(model, mesModels.PMM_SYS.UPDATE);
        }

        [HttpPost]
        public void SetCookie(string KEY, string VALUE)
        {
            if (KEY == "MES_MOULD_BIGSCREEN_refresh") AppendCookie(CookieName, "BIGSCREEN_refresh", VALUE);
        }

        [HttpPost]
        public string GetCookie(string KEY)
        {
            if (!AppendCookie(CookieName)) return "";
            switch (KEY)
            {
                case "MES_MOULD_BIGSCREEN_refresh":
                    return GetCookie(CookieName, KEY);
                case "BIGSCREEN_TableRows":
                    return GetCookie(CookieName, KEY);
                case "BIGSCREEN":
                    return GetCookie(CookieName, KEY, "UTF-8");
                default:
                    return "";
            }
        }

        #endregion

        #region 通用 List

        [HttpPost]
        public string GCList()
        {
            MES_SY_GC model = new MES_SY_GC();
            model.STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            return AppClass.EasyCall<MES_SY_GC, MES_SY_GC[]>(model, mesModels.SY_GC.SELECT_BY_ROLE);
        }

        [HttpPost]
        public string GZZXList(string GC)
        {
            MES_SY_GZZX model = new MES_SY_GZZX();
            model.GC = GC;
            model.STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            return AppClass.EasyCall<MES_SY_GZZX, MES_SY_GZZX[]>(model, mesModels.SY_GZZX.SELECT_BY_ROLE);
        }

        [HttpPost]
        public string BATList(string GC)
        {
            MES_SY_TYPEMX model = new MES_SY_TYPEMX();
            model.GC = GC;
            model.TYPEID = 6;
            return AppClass.EasyCall<MES_SY_TYPEMX, MES_SY_TYPEMXLIST[]>(model, mesModels.SY_TYPEMX.SELECT);
        }

        [HttpPost]
        public string SBList(string GC, string GZZXBH)
        {
            MES_SY_GZZX_SBH model = new MES_SY_GZZX_SBH();
            model.GC = GC;
            model.GZZXBH = GZZXBH;
            return AppClass.EasyCall<MES_SY_GZZX_SBH, MES_SY_GZZX_SBH[]>(model, mesModels.SY_GZZX_SBH.SELECT);
        }

        [HttpPost]
        public string WLLBList(string GC, string GZZXBH)
        {
            MES_SY_GZZX_WLLB model = new MES_SY_GZZX_WLLB();
            model.GC = GC;
            model.GZZXBH = GZZXBH;
            return AppClass.EasyCall<MES_SY_GZZX_WLLB, MES_SY_GZZX_WLLB[]>(model, (postData, token) => { return mesModels.SY_GZZX_WLLB.SELECT(postData, token).MES_SY_GZZX_WLLB; });
        }

        [HttpPost]
        public string WLList(string GC, int WLLB)
        {
            MES_SY_MATERIAL model = new MES_SY_MATERIAL();
            model.GC = GC;
            model.WLLB = WLLB;
            return AppClass.EasyCall<MES_SY_MATERIAL, MES_SY_MATERIAL_LIST[]>(model, (postData, token) => { return mesModels.SY_MATERIAL.SELECT(postData, token).MES_SY_MATERIAL; });
        }

        [HttpPost]
        public string MATCHCODEList(string GC)
        {
            MES_ZS_SY_CLPB model = new MES_ZS_SY_CLPB();
            model.GC = GC;
            model.LB = 1;
            model.STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            return AppClass.EasyCall<MES_ZS_SY_CLPB, MES_ZS_SY_CLPB[]>(model, (postData, token) => { return mesModels.ZS_SY_CLPB.SELECT(postData, token).MES_ZS_SY_CLPB; });
        }

        [HttpPost]
        public string QCODEList()
        {
            MES_PMM_QR model = new MES_PMM_QR();
            model.QISACTION = 1;
            return AppClass.EasyCall<MES_PMM_QR, MES_PMM_QR[]>(model, (postData, token) => { return mesModels.PMM_QR.QLTY_SELECT(postData, token).MES_PMM_QR; });
        }

        [HttpPost]
        public string RCODEList(int QID = 0)
        {
            MES_PMM_QR model = new MES_PMM_QR();
            model.RISACTION = 1;
            if (QID != 0) model.QID = QID;
            return AppClass.EasyCall<MES_PMM_QR, MES_PMM_QR[]>(model, (postData, token) => { return mesModels.PMM_QR.REP_SELECT(postData, token).MES_PMM_QR; });
        }

        [HttpPost]
        public string MOULDList(string GC, string GZZXBH)
        {
            Sonluk.UI.Model.MES.PMM_MOULDService.MES_PMM_MOULD model = new Sonluk.UI.Model.MES.PMM_MOULDService.MES_PMM_MOULD();
            model.GC = GC;
            model.GZZXBH = GZZXBH;
            return AppClass.EasyCall<Sonluk.UI.Model.MES.PMM_MOULDService.MES_PMM_MOULD, Sonluk.UI.Model.MES.PMM_MOULDService.MES_PMM_MOULD[]>(model, (postData, STAFFID, token) => { return mesModels.PMM_MOULD.SELECT(postData, STAFFID, token).MES_PMM_MOULD; });
        }

        #endregion

        #region MT_MOULD

        [HttpPost]
        public string MT_MOULD_Search(string datastring)
        {
            return AppClass.EasyCall<Sonluk.UI.Model.MES.PMM_MOULDService.MES_PMM_MOULD, MES_PMM_MOULD_SELECT>(datastring, mesModels.PMM_MOULD.SELECT);
        }

        [HttpPost]
        public string MT_MOULD_Update(string datastring)
        {
            return AppClass.EasyCall<Sonluk.UI.Model.MES.PMM_MOULDService.MES_PMM_MOULD, MES_RETURN_UI>(datastring, mesModels.PMM_MOULD.UPDATE);
        }

        [HttpPost]
        public string MT_MOULD_Add(string datastring)
        {
            return AppClass.EasyCall<Sonluk.UI.Model.MES.PMM_MOULDService.MES_PMM_MOULD, MES_RETURN_UI>(datastring, mesModels.PMM_MOULD.INSERT);
        }

        [HttpPost]
        public string MT_MOULD_Delete(string datastring)
        {
            return AppClass.EasyCall<string, MES_RETURN_UI>(datastring, mesModels.PMM_MOULD.DELETE);
        }

        [HttpPost]
        public string MT_MOULD_Export(string datastring)
        {
            Sonluk.UI.Model.MES.PMM_MOULDService.MES_PMM_MOULD[] rst_MES_PMM_MOULD = Newtonsoft.Json.JsonConvert.DeserializeObject<Sonluk.UI.Model.MES.PMM_MOULDService.MES_PMM_MOULD[]>(datastring);
            MES_RETURN_UI rst = new MES_RETURN_UI();
            try
            {
                //工作簿初始化
                IWorkbook mworkbook = new XSSFWorkbook();
                ISheet msheet = mworkbook.CreateSheet("模具维护");

                //标题栏样式
                ICellStyle style = mworkbook.CreateCellStyle();
                style.Alignment = HorizontalAlignment.Center;
                style.VerticalAlignment = VerticalAlignment.Center;
                style.BorderBottom = BorderStyle.Thin;
                style.BorderLeft = BorderStyle.Thin;
                style.BorderRight = BorderStyle.Thin;
                style.BorderTop = BorderStyle.Thin;
                style.WrapText = true;

                //数据栏样式1
                ICellStyle styleA = mworkbook.CreateCellStyle();
                styleA.Alignment = HorizontalAlignment.Center;
                styleA.VerticalAlignment = VerticalAlignment.Center;
                styleA.BorderBottom = BorderStyle.Thin;
                styleA.BorderLeft = BorderStyle.Thin;
                styleA.BorderRight = BorderStyle.Thin;
                styleA.BorderTop = BorderStyle.Thin;

                //数据栏样式2
                ICellStyle styleB = mworkbook.CreateCellStyle();
                styleB.Alignment = HorizontalAlignment.Left;
                styleB.VerticalAlignment = VerticalAlignment.Center;
                styleB.BorderBottom = BorderStyle.Thin;
                styleB.BorderLeft = BorderStyle.Thin;
                styleB.BorderRight = BorderStyle.Thin;
                styleB.BorderTop = BorderStyle.Thin;

                //单元格初始化
                for (int i = 0; i < 1; i++)
                {
                    IRow row = msheet.CreateRow(i);
                    row.HeightInPoints = 30;
                    for (int j = 0; j < 18; j++) row.CreateCell(j).CellStyle = style;
                }
                for (int i = 1; i < rst_MES_PMM_MOULD.Length + 1; i++)
                {
                    IRow row = msheet.CreateRow(i);
                    for (int j = 0; j < 18; j++) row.CreateCell(j).CellStyle = styleA;
                    row.GetCell(7).CellStyle = styleB;
                    row.GetCell(16).CellStyle = styleB;
                }

                //设置列宽
                msheet.SetColumnWidth(5, 15 * 256);
                msheet.SetColumnWidth(6, 20 * 256);
                msheet.SetColumnWidth(7, 30 * 256);

                //设置标题栏
                string[] titleList = { "模具编号", "模具名称", "工厂", "工作中心", "工作中心描述", "应用设备名称", "物料编码", "物料描述", "物料类别", "材料配比", "型腔数量", "每箱数量(只)", "每箱净重(kg)", "是否过全检机", "是否可挑号", "规格型号", "备注", "模具状态" };
                for (int i = 0; i < 18; i++) msheet.GetRow(0).GetCell(i).SetCellValue(titleList[i]);

                //数据填充
                for (int i = 0; i < rst_MES_PMM_MOULD.Length; i++)
                {
                    string ISFIM = Convert.ToString(rst_MES_PMM_MOULD[i].ISFIM);
                    string ISNPA = Convert.ToString(rst_MES_PMM_MOULD[i].ISNPA);
                    if (ISFIM == "1") ISFIM = "是";
                    else ISFIM = "否";
                    if (ISNPA == "1") ISNPA = "是";
                    else ISNPA = "否";
                    int j = 0;
                    IRow row = msheet.GetRow(i + 1);
                    row.GetCell(j++).SetCellValue(rst_MES_PMM_MOULD[i].MID);
                    row.GetCell(j++).SetCellValue(rst_MES_PMM_MOULD[i].MOULD);
                    row.GetCell(j++).SetCellValue(rst_MES_PMM_MOULD[i].GC);
                    row.GetCell(j++).SetCellValue(rst_MES_PMM_MOULD[i].GZZXBH);
                    row.GetCell(j++).SetCellValue(rst_MES_PMM_MOULD[i].GZZXMS);
                    row.GetCell(j++).SetCellValue(rst_MES_PMM_MOULD[i].SBMS);
                    row.GetCell(j++).SetCellValue(rst_MES_PMM_MOULD[i].WLH);
                    row.GetCell(j++).SetCellValue(rst_MES_PMM_MOULD[i].WLMS);
                    row.GetCell(j++).SetCellValue(rst_MES_PMM_MOULD[i].WLLBNAME);
                    row.GetCell(j++).SetCellValue(rst_MES_PMM_MOULD[i].MATCHCODENAME);
                    row.GetCell(j++).SetCellValue(rst_MES_PMM_MOULD[i].CAVE);
                    row.GetCell(j++).SetCellValue(rst_MES_PMM_MOULD[i].CASENUM);
                    row.GetCell(j++).SetCellValue(rst_MES_PMM_MOULD[i].CASEWET.ToString());
                    row.GetCell(j++).SetCellValue(ISFIM);
                    row.GetCell(j++).SetCellValue(ISNPA);
                    row.GetCell(j++).SetCellValue(rst_MES_PMM_MOULD[i].MXNAME);
                    row.GetCell(j++).SetCellValue(rst_MES_PMM_MOULD[i].NOTES);
                    row.GetCell(j++).SetCellValue(rst_MES_PMM_MOULD[i].STATUS);
                }

                string now = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                string filename = now + "模具维护.xlsx";
                string path = string.Format(@"{0}/Areas/MES/ExportFile/{1}", Server.MapPath("~"), filename);
                //open
                FileStream file_o = new FileStream(path, FileMode.Create, FileAccess.Write);
                mworkbook.Write(file_o);
                //close
                file_o.Close();
                rst.TYPE = "S";
                rst.MESSAGE = filename;
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = "导出失败：" + e.Message;
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }

        #endregion

        #region MT_QLTY

        [HttpPost]
        public string MT_QLTY_Search_QLTY(string datastring)
        {
            return AppClass.EasyCall<MES_PMM_QR, MES_PMM_QR_SELECT>(datastring, mesModels.PMM_QR.QLTY_SELECT);
        }

        [HttpPost]
        public string MT_QLTY_Update_QLTY(string datastring)
        {
            return AppClass.EasyCall<MES_PMM_QR, MES_RETURN_UI>(datastring, mesModels.PMM_QR.QLTY_UPDATE);
        }

        [HttpPost]
        public string MT_QLTY_Add_QLTY(string datastring)
        {
            return AppClass.EasyCall<MES_PMM_QR, MES_RETURN_UI>(datastring, mesModels.PMM_QR.QLTY_INSERT);
        }

        [HttpPost]
        public string MT_QLTY_Delete_QLTY(string datastring)
        {
            return AppClass.EasyCall<int, MES_RETURN_UI>(datastring, mesModels.PMM_QR.QLTY_DELETE);
        }

        [HttpPost]
        public string MT_QLTY_Search_REP(string datastring)
        {
            return AppClass.EasyCall<MES_PMM_QR, MES_PMM_QR_SELECT>(datastring, mesModels.PMM_QR.REP_SELECT);
        }

        [HttpPost]
        public string MT_QLTY_Update_REP(string datastring)
        {
            return AppClass.EasyCall<MES_PMM_QR, MES_RETURN_UI>(datastring, mesModels.PMM_QR.REP_UPDATE);
        }

        [HttpPost]
        public string MT_QLTY_Add_REP(string datastring)
        {
            return AppClass.EasyCall<MES_PMM_QR, MES_RETURN_UI>(datastring, mesModels.PMM_QR.REP_INSERT);
        }

        [HttpPost]
        public string MT_QLTY_Delete_REP(string datastring)
        {
            return AppClass.EasyCall<int, MES_RETURN_UI>(datastring, mesModels.PMM_QR.REP_DELETE);
        }

        [HttpPost]
        public string MT_QLTY_Search_QR(string datastring)
        {
            return AppClass.EasyCall<int, MES_PMM_QR_SELECT>(datastring, mesModels.PMM_QR.QR_SELECT_BY_QCODE);
        }

        [HttpPost]
        public string MT_QLTY_Cover_QR(string datastring)
        {
            return AppClass.EasyCall<MES_PMM_QR, MES_RETURN_UI>(datastring, mesModels.PMM_QR.QR_COVER);
        }

        [HttpPost]
        public string MT_QLTY_Delete_QR(string datastring)
        {
            return AppClass.EasyCall<MES_PMM_QR, MES_RETURN_UI>(datastring, mesModels.PMM_QR.QR_DELETE);
        }

        #endregion

        #region MT_STAFF

        [HttpPost]
        public string MT_STAFF_Search(string datastring)
        {
            return AppClass.EasyCall<MES_PMM_STAFF, MES_PMM_STAFF_SELECT>(datastring, mesModels.PMM_STAFF.SELECT);
        }

        [HttpPost]
        public string MT_STAFF_Cover(string datastring)
        {
            return AppClass.EasyCall<MES_PMM_STAFF, MES_RETURN_UI>(datastring, mesModels.PMM_STAFF.COVER);
        }

        [HttpPost]
        public string MT_STAFF_Delete(string datastring)
        {
            return AppClass.EasyCall<MES_PMM_STAFF, MES_RETURN_UI>(datastring, mesModels.PMM_STAFF.DELETE);
        }

        #endregion

        #region REP_NEW 和 REP_ALTER_CFMS 和 REP_ALTER_CFME 和 REP_SEARCH

        [HttpPost]
        public string REP_NEW_Add(string datastring)
        {
            return AppClass.EasyCall<MES_PMM_MTC, MES_RETURN_UI>(datastring, (postData, token) =>
           {
               postData.STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
               return mesModels.PMM_MTC.INSERT(postData, token);
           });
        }

        [HttpPost]
        public string REP_NEW_Start(string datastring)
        {
            return AppClass.EasyCall<MES_PMM_MTC, MES_RETURN_UI>(datastring, (postData, token) =>
           {
               postData.STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
               return mesModels.PMM_MTC.UPDATE_START(postData, token);
           });
        }

        [HttpPost]
        public string REP_ALTER_CFMS_Update(string datastring)
        {
            return AppClass.EasyCall<MES_PMM_MTC, MES_RETURN_UI>(datastring, (postData, token) =>
            {
                postData.STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
                return mesModels.PMM_MTC.UPDATE_SAVE(postData, token);
            });
        }

        [HttpPost]
        public string REP_ALTER_CFMS_Back(string datastring)
        {
            return AppClass.EasyCall<MES_PMM_MTC, MES_RETURN_UI>(datastring, (postData, token) =>
            {
                postData.STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
                return mesModels.PMM_MTC.UPDATE_BACK(postData, token);
            });
        }

        [HttpPost]
        public string REP_ALTER_CFMS_Search(string datastring)
        {
            return AppClass.EasyCall<MES_PMM_MTC, MES_PMM_MTC_SELECT>(datastring, (postData, token) =>
            {
                postData.STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
                return mesModels.PMM_MTC.SELECT(postData, token);
            });
        }

        [HttpPost]
        public string REP_ALTER_CFMS_Delete(string datastring)
        {
            return AppClass.EasyCall<MES_PMM_MTC, MES_RETURN_UI>(datastring, (postData, token) =>
            {
                postData.STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
                return mesModels.PMM_MTC.DELETE(postData, token);
            });
        }

        [HttpPost]
        public string REP_ALTER_CFME_Back(string datastring)
        {
            return AppClass.EasyCall<MES_PMM_MTC, MES_RETURN_UI>(datastring, (postData, token) =>
            {
                postData.STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
                return mesModels.PMM_MTC.UPDATE_CFMBACK(postData, token);
            });
        }

        [HttpPost]
        public string REP_SEARCH_Search(string datastring)
        {
            return AppClass.EasyCall<MES_PMM_MTC, MES_PMM_MTC_SELECT>(datastring, (postData, token) =>
            {
                postData.STATUS = "维修中，维修完成，审核中，不合格，全部合格";
                postData.STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
                return mesModels.PMM_MTC.SELECT(postData, token);
            });
        }

        [HttpPost]
        public string REP_SEARCH_Export(string datastring)
        {
            MES_PMM_MTC[] rst_MES_PMM_MTC = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_PMM_MTC[]>(datastring);
            MES_RETURN_UI rst = new MES_RETURN_UI();
            try
            {
                //工作簿初始化
                IWorkbook mworkbook = new XSSFWorkbook();
                ISheet msheet = mworkbook.CreateSheet("维护流程");

                //标题栏样式
                ICellStyle style = mworkbook.CreateCellStyle();
                style.Alignment = HorizontalAlignment.Center;
                style.VerticalAlignment = VerticalAlignment.Center;
                style.BorderBottom = BorderStyle.Thin;
                style.BorderLeft = BorderStyle.Thin;
                style.BorderRight = BorderStyle.Thin;
                style.BorderTop = BorderStyle.Thin;
                style.WrapText = true;

                //数据栏样式
                ICellStyle styleA = mworkbook.CreateCellStyle();
                styleA.Alignment = HorizontalAlignment.Center;
                styleA.VerticalAlignment = VerticalAlignment.Center;
                styleA.BorderBottom = BorderStyle.Thin;
                styleA.BorderLeft = BorderStyle.Thin;
                styleA.BorderRight = BorderStyle.Thin;
                styleA.BorderTop = BorderStyle.Thin;

                //单元格初始化，并设置标题栏
                string[] titleList = { "模具号", "腔号", "质量问题代码", "质量问题", "维修内容代码", "维修内容", "责任机修", "发起时间", "维修进度", "机修确认时间", "班组确认", "班组确认人", "班组确认时间", "班组备注", "品管确认", "检验员确认人", "检验员确认时间", "检验员备注", "技术确认", "测试员", "技术部确认时间", "技术部备注", "状态" };
                int widthNum = titleList.Length; //表单宽度（格）
                for (int i = 0; i < 1; i++)
                {
                    IRow row = msheet.CreateRow(i);
                    row.HeightInPoints = 30;
                    for (int j = 0; j < widthNum; j++) row.CreateCell(j).CellStyle = style;
                }
                for (int i = 1; i < rst_MES_PMM_MTC.Length + 1; i++)
                {
                    IRow row = msheet.CreateRow(i);
                    for (int j = 0; j < widthNum; j++) row.CreateCell(j).CellStyle = styleA;
                }
                for (int i = 0; i < titleList.Length; i++) msheet.GetRow(0).GetCell(i).SetCellValue(titleList[i]);

                //设置列宽
                msheet.SetColumnWidth(3, 20 * 256);
                msheet.SetColumnWidth(4, 30 * 256);
                msheet.SetColumnWidth(5, 50 * 256);
                msheet.SetColumnWidth(7, 18 * 256);
                msheet.SetColumnWidth(9, 18 * 256);
                msheet.SetColumnWidth(10, 11 * 256);
                msheet.SetColumnWidth(12, 18 * 256);
                msheet.SetColumnWidth(14, 11 * 256);
                msheet.SetColumnWidth(16, 18 * 256);
                msheet.SetColumnWidth(18, 11 * 256);
                msheet.SetColumnWidth(20, 18 * 256);

                //数据填充
                for (int i = 0; i < rst_MES_PMM_MTC.Length; i++)
                {
                    string CAVE = "";
                    string RCODE = "";
                    string RNAME = "";
                    string MMCFM = rst_MES_PMM_MTC[i].MMCFM.ToString();
                    string WTCFM = rst_MES_PMM_MTC[i].WTCFM.ToString();
                    string QCCFM = rst_MES_PMM_MTC[i].QCCFM.ToString();
                    string TECCFM = rst_MES_PMM_MTC[i].TECCFM.ToString();

                    if (rst_MES_PMM_MTC[i].MES_PMM_MTC_CAVE != null)
                    {
                        for (int k = 0; k < rst_MES_PMM_MTC[i].MES_PMM_MTC_CAVE.Length; k++)
                        {
                            if (k == 0) CAVE = Convert.ToString(rst_MES_PMM_MTC[i].MES_PMM_MTC_CAVE[k].CAVENO);
                            else CAVE = CAVE + "、" + Convert.ToString(rst_MES_PMM_MTC[i].MES_PMM_MTC_CAVE[k].CAVENO);
                        }
                    }
                    if (rst_MES_PMM_MTC[i].MES_PMM_MTC_REP != null)
                    {
                        for (int k = 0; k < rst_MES_PMM_MTC[i].MES_PMM_MTC_REP.Length; k++)
                        {
                            if (k == 0)
                            {
                                RCODE = Convert.ToString(rst_MES_PMM_MTC[i].MES_PMM_MTC_REP[k].RCODE);
                                RNAME = Convert.ToString(rst_MES_PMM_MTC[i].MES_PMM_MTC_REP[k].RNAME);
                            }
                            else
                            {
                                RCODE = RCODE + "、" + Convert.ToString(rst_MES_PMM_MTC[i].MES_PMM_MTC_REP[k].RCODE);
                                RNAME = RNAME + "、" + Convert.ToString(rst_MES_PMM_MTC[i].MES_PMM_MTC_REP[k].RNAME);
                            }
                        }
                    }
                    if (MMCFM == "1") MMCFM = "维修完成";
                    else if (MMCFM == "0") MMCFM = "正在维修";
                    else MMCFM = "";
                    if (WTCFM == "1") WTCFM = "确认合格";
                    else if (WTCFM == "0") WTCFM = "确认不合格";
                    else WTCFM = "";
                    if (QCCFM == "1") QCCFM = "确认合格";
                    else if (QCCFM == "0") QCCFM = "确认不合格";
                    else QCCFM = "";
                    if (TECCFM == "1" && rst_MES_PMM_MTC[i].TECNOTES == "无需确认") TECCFM = "无需确认";
                    else if (TECCFM == "1") TECCFM = "确认合格";
                    else if (TECCFM == "0") TECCFM = "确认不合格";
                    else TECCFM = "";

                    int j = 0;
                    IRow row = msheet.GetRow(i + 1);
                    row.GetCell(j++).SetCellValue(rst_MES_PMM_MTC[i].MES_PMM_MOULD.MOULD);
                    row.GetCell(j++).SetCellValue(CAVE);
                    row.GetCell(j++).SetCellValue(rst_MES_PMM_MTC[i].QCODE);
                    row.GetCell(j++).SetCellValue(rst_MES_PMM_MTC[i].QNAME);
                    row.GetCell(j++).SetCellValue(RCODE);
                    row.GetCell(j++).SetCellValue(RNAME);
                    row.GetCell(j++).SetCellValue(rst_MES_PMM_MTC[i].MMSTAFFNAME);
                    row.GetCell(j++).SetCellValue(rst_MES_PMM_MTC[i].DATES > DateTime.Parse("1800-1-1") ? rst_MES_PMM_MTC[i].DATES.ToString() : "");
                    row.GetCell(j++).SetCellValue(MMCFM);
                    row.GetCell(j++).SetCellValue(rst_MES_PMM_MTC[i].MMDATE > DateTime.Parse("1800-1-1") ? rst_MES_PMM_MTC[i].MMDATE.ToString() : "");
                    row.GetCell(j++).SetCellValue(WTCFM);
                    row.GetCell(j++).SetCellValue(rst_MES_PMM_MTC[i].WTSTAFFNAME);
                    row.GetCell(j++).SetCellValue(rst_MES_PMM_MTC[i].WTDATE > DateTime.Parse("1800-1-1") ? rst_MES_PMM_MTC[i].WTDATE.ToString() : "");
                    row.GetCell(j++).SetCellValue(rst_MES_PMM_MTC[i].WTNOTES);
                    row.GetCell(j++).SetCellValue(QCCFM);
                    row.GetCell(j++).SetCellValue(rst_MES_PMM_MTC[i].QCSTAFFNAME);
                    row.GetCell(j++).SetCellValue(rst_MES_PMM_MTC[i].QCDATE > DateTime.Parse("1800-1-1") ? rst_MES_PMM_MTC[i].QCDATE.ToString() : "");
                    row.GetCell(j++).SetCellValue(rst_MES_PMM_MTC[i].QCNOTES);
                    row.GetCell(j++).SetCellValue(TECCFM);
                    row.GetCell(j++).SetCellValue(rst_MES_PMM_MTC[i].TECSTAFFNAME);
                    row.GetCell(j++).SetCellValue(rst_MES_PMM_MTC[i].TECDATE > DateTime.Parse("1800-1-1") ? rst_MES_PMM_MTC[i].TECDATE.ToString() : "");
                    row.GetCell(j++).SetCellValue(rst_MES_PMM_MTC[i].TECNOTES);
                    row.GetCell(j++).SetCellValue(rst_MES_PMM_MTC[i].STATUS);
                }

                string now = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                string filename = now + "维护流程.xlsx";
                string path = string.Format(@"{0}/Areas/MES/ExportFile/{1}", Server.MapPath("~"), filename);
                //open
                FileStream file_o = new FileStream(path, FileMode.Create, FileAccess.Write);
                mworkbook.Write(file_o);
                //close
                file_o.Close();
                rst.TYPE = "S";
                rst.MESSAGE = filename;
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = "导出失败：" + e.Message;
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }

        #endregion

        #region REP_CFM

        [HttpPost]
        public string REP_CFM_Search_MM(string GC) { return REP_CFM_Search("MM", GC); }

        [HttpPost]
        public string REP_CFM_Update_MM(string datastring)
        {
            return AppClass.EasyCall<MES_PMM_MTC, MES_RETURN_UI>(datastring, (postData, token) =>
            {
                postData.STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
                return mesModels.PMM_MTC.UPDATE_MM(postData, token);
            });
        }

        [HttpPost]
        public string REP_CFM_Search_WT(string GC) { return REP_CFM_Search("WT", GC); }

        [HttpPost]
        public string REP_CFM_Update_WT(string datastring)
        {
            return AppClass.EasyCall<MES_PMM_MTC, MES_RETURN_UI>(datastring, (postData, token) =>
            {
                postData.STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
                return mesModels.PMM_MTC.UPDATE_WT(postData, token);
            });
        }

        [HttpPost]
        public string REP_CFM_Search_QC(string GC) { return REP_CFM_Search("QC", GC); }

        [HttpPost]
        public string REP_CFM_Update_QC(string datastring)
        {
            return AppClass.EasyCall<MES_PMM_MTC, MES_RETURN_UI>(datastring, (postData, token) =>
            {
                postData.STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
                return mesModels.PMM_MTC.UPDATE_QC(postData, token);
            });
        }

        [HttpPost]
        public string REP_CFM_Search_TEC(string GC) { return REP_CFM_Search("TEC", GC); }

        [HttpPost]
        public string REP_CFM_Update_TEC(string datastring)
        {
            return AppClass.EasyCall<MES_PMM_MTC, MES_RETURN_UI>(datastring, (postData, token) =>
            {
                postData.STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
                return mesModels.PMM_MTC.UPDATE_TEC(postData, token);
            });
        }

        [HttpPost]
        public string REP_CFM_Update_BACK(string datastring)
        {
            return AppClass.EasyCall<MES_PMM_MTC, MES_RETURN_UI>(datastring, (postData, token) =>
            {
                postData.STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
                return mesModels.PMM_MTC.UPDATE_CFMBACK(postData, token);
            });
        }

        private string REP_CFM_Search(string OPERATE, string GC)
        {
            MES_PMM_MTC postData = new MES_PMM_MTC();
            postData.MES_PMM_MOULD = new UI.Model.MES.PMM_MTCService.MES_PMM_MOULD();
            postData.DATESS = Convert.ToDateTime("1800/1/1");
            postData.DATESE = Convert.ToDateTime("1800/1/1");
            postData.DATEES = Convert.ToDateTime("1800/1/1");
            postData.DATEEE = Convert.ToDateTime("1800/1/1");
            postData.OPERATE = OPERATE;
            postData.MES_PMM_MOULD.GC = GC;
            postData.STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            return AppClass.EasyCall<MES_PMM_MTC, MES_PMM_MTC_SELECT>(postData, mesModels.PMM_MTC.SELECT);
        }

        #endregion

        #region BIGSCREEN

        [HttpPost]
        public void BIGSCREEN_Set(string datastring, string TableRows = "20")
        {
            //MES_PMM_MTC inputData = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_PMM_MTC>(datastring);
            //AppClass.SetSession("MES_MOULD_BIGSCREEN", inputData);

            if (!AppendCookie(CookieName)) Response.AppendCookie(new HttpCookie(CookieName));
            AppendCookie(CookieName, "BIGSCREEN", datastring, "UTF-8");
            AppendCookie(CookieName, "BIGSCREEN_TableRows", TableRows);
            AppendCookie(CookieName, "TOKEN", Convert.ToString(AppClass.GetSession("token")));
        }

        [HttpPost]
        public string BIGSCREEN_Refresh()
        {
            //if (Session["MES_MOULD_BIGSCREEN"] == null) return "";
            //MES_PMM_MTC postData = (MES_PMM_MTC)AppClass.GetSession("MES_MOULD_BIGSCREEN");
            //postData.STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            //return AppClass.EasyCall<MES_PMM_MTC, MES_PMM_MTC_SELECT>(postData, mesModels.PMM_MTC.SELECT);

            if (!AppendCookie(CookieName)) return "";
            return AppClass.EasyCall<MES_PMM_MTC, MES_PMM_MTC_SELECT>(HttpUtility.UrlDecode(Request.Cookies[CookieName].Values.Get("BIGSCREEN"), Encoding.GetEncoding("UTF-8")), (postData, token) =>
           {
               string localtoken = GetCookie(CookieName, "token");
               return mesModels.PMM_MTC.SELECT(postData, localtoken);
           });
        }

        #endregion

        #region 工具

        /// <summary>
        /// 增加或修改COOKIE的键值对（同时验证COOKIE是否存在）
        /// </summary>
        /// <param name="NAME">COOKIE名</param>
        /// <param name="KEY">键（不填则只是验证COOKIE是否存在）</param>
        /// <param name="VALUE">值</param>
        /// <param name="CODE">编码（不填则不编码）</param>
        /// <returns></returns>
        protected bool AppendCookie(string NAME, string KEY = "", string VALUE = "", string CODE = "")
        {
            HttpCookie cookie = Request.Cookies[NAME];
            if (cookie == null) return false;
            else if (KEY != "")
            {
                if (cookie.Values.Get("Expires") == null)
                {
                    cookie.Expires = DateTime.Now.Add(new TimeSpan(1, 0, 0, 0, 0));
                    cookie.Values.Add("Expires", cookie.Expires.ToString());
                }
                else
                {
                    cookie.Expires = Convert.ToDateTime(cookie.Values.Get("Expires"));
                }
                string NEWVALUE = CODE == "" ? VALUE : HttpUtility.UrlEncode(VALUE, Encoding.GetEncoding(CODE));
                if (cookie.Values.Get(KEY) == null) cookie.Values.Add(KEY, NEWVALUE);
                else cookie.Values.Set(KEY, NEWVALUE);
                Response.AppendCookie(cookie);
            }
            return true;
        }

        protected string GetCookie(string NAME, string KEY, string CODE = "")
        {
            HttpCookie cookie = Request.Cookies[NAME];
            if (CODE == "") return cookie.Values.Get(KEY);
            else return HttpUtility.UrlDecode(cookie.Values.Get(KEY), Encoding.GetEncoding(CODE));
        }

        #endregion
    }
}
