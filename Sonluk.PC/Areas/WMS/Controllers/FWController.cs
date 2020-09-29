using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Sonluk.API.SDK.Http;
using Sonluk.PC.APPCLASS;
using Sonluk.PC.Models;
using Sonluk.UI.Model.MES.SY_TYPEMXService;
using Sonluk.UI.Model.MES.TM_TMINFOService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sonluk.PC.Areas.WMS.Controllers
{
    public class FWController : Controller
    {
        //
        // GET: /WMS/FW/
        CRMModels crmModels = new CRMModels();
        MESModels mesModels = new MESModels();
        AppClass appClass = new AppClass();
        SHttp sHttp = new SHttp();
        string token = "";
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TMPrint_GL()
        {
            Session["location"] = 21001;
            token = appClass.CRM_Gettoken();
            MES_SY_TYPEMX cx_ljxt = new MES_SY_TYPEMX();
            cx_ljxt.TYPEID = 43;
            MES_SY_TYPEMXLIST[] TYPE = mesModels.SY_TYPEMX.SELECT(cx_ljxt, token);
            ViewBag.TYPE = TYPE;


            cx_ljxt.TYPEID = 44;
            MES_SY_TYPEMXLIST[] PAPER = mesModels.SY_TYPEMX.SELECT(cx_ljxt, token);
            ViewBag.PAPER = PAPER;
            return View();
        }

        [HttpPost]
        public string Post_Print_TM(string data)
        {
            WebMSG webmsg = new WebMSG();
            try
            {
                List<MES_TM_TMINFO_TSDY> model = Newtonsoft.Json.JsonConvert.DeserializeObject<List<MES_TM_TMINFO_TSDY>>(data);
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

        public ActionResult TM_PRINT(int count)
        {
            List<MES_TM_TMINFO_TSDY> list = (List<MES_TM_TMINFO_TSDY>)Session["PRINTTM"];

            ViewBag.data = list;
            ViewBag.Count = count;
            return View();
        }


        [HttpPost]
        public string GN_TM_XM_GL(string XBID, string TM)
        {
            string model = sHttp.SApiPost("WMS", "MES/TM/GN_TM_XM_GL?XBID=" + XBID + "&TM=" + TM, "");
            return model;
        }

        [HttpPost]
        public string READ_TSDY(string data)
        {
            string model = sHttp.SApiPost("WMS", "MES/TM/READ_TSDY", data);
            return model;
        }

        public ActionResult TMPrint_CX()
        {
            Session["location"] = 21002;
            return View();
        }

        [HttpPost]
        public string TMPrint_DAOCHU(string data)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            DaoRuMsg msg = new DaoRuMsg();
            try
            {
                MES_TM_TMINFO_TSDY[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_TM_TMINFO_TSDY[]>(data);


                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/WMS/ExportFile/箱码数据查询打印导出模板.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet worksheet1 = workbook.GetSheet("箱码数据");
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
                    row.CreateCell(count++).SetCellValue(model[i].ERPNO);
                    row.CreateCell(count++).SetCellValue(model[i].WLH);
                    row.CreateCell(count++).SetCellValue(model[i].WLMS);
                    row.CreateCell(count++).SetCellValue(model[i].NOBILL);
                    row.CreateCell(count++).SetCellValue(model[i].NOBILLMX);
                    row.CreateCell(count++).SetCellValue(model[i].PC);
                    row.CreateCell(count++).SetCellValue(model[i].KHWLH);
                    row.CreateCell(count++).SetCellValue(model[i].KHWLMS);
                    row.CreateCell(count++).SetCellValue(model[i].KHWLGG);
                    row.CreateCell(count++).SetCellValue(model[i].TM);
                    row.CreateCell(count++).SetCellValue(model[i].XCTM);
                    row.CreateCell(count++).SetCellValue(model[i].SCDATE);
                    row.CreateCell(count++).SetCellValue(model[i].XZS.ToString());
                    row.CreateCell(count++).SetCellValue(model[i].UNITSNAME);
                    row.CreateCell(count++).SetCellValue(model[i].XBNAME);
                    row.CreateCell(count++).SetCellValue(model[i].CJRNAME);
                    row.CreateCell(count++).SetCellValue(model[i].CJTIME);
                    
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

        public ActionResult Data_DaoChu_TMPrint_File(string filename)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/WMS/ExportFile/{1}.xlsx", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", filename + "-箱码数据查询打印导出模板.xlsx");
        }

    }
}
