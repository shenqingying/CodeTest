using Newtonsoft.Json;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Sonluk.PC.APPCLASS;
using Sonluk.PC.Models;
using Sonluk.UI.Model.CRM.HG_STAFFService;
using Sonluk.UI.Model.MODEL;
using Sonluk.UI.Model.PS.CNFHService;
using Sonluk.UI.Model.PS.NetWorkService;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Sonluk.PC.Areas.PS.Controllers
{
    public class PSController : Controller
    {
        //
        // GET: /PS/PS/
        PSModels psModels = new PSModels();
        KQModels kqModels = new KQModels();
        CRMModels cmrmodele = new CRMModels();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult OutSource_in()
        {
            AppClass.SetSession("location", 224);
            Session["TITLENAME"] = "外协接收";
            return View();
        }

        public ActionResult ljCX()
        {
            Session["TITLENAME"] = "零件报工查询";
            AppClass.SetSession("location", 220);
            return View();
        }
        public ActionResult QualifiedPart()
        {
            AppClass.SetSession("location", 221);
            Session["TITLENAME"] = "合格零件报工";
            //AppClass.SetSession("location", 200);
            return View();
        }
        public ActionResult ScrapPart()
        {
            AppClass.SetSession("location", 222);
            Session["TITLENAME"] = "报废零件报工";
            return View();
        }
        public ActionResult OutSource_out()
        {
            AppClass.SetSession("location", 223);
            Session["TITLENAME"] = "外协发出";
            return View();
        }

        public ActionResult JGFH()
        {
            AppClass.SetSession("location", 225);
                   

            return View();
        }
        //
        public ActionResult PS_CALENDAR()
        {
            AppClass.SetSession("location", 229);
            Session["TITLENAME"] = "维护加工日历";
            return View();
        }
        public ActionResult CNYJ()
        {
            AppClass.SetSession("location", 226);
            return View();
        }
        public string SelectCNYJ(int i_rows)
        {
            ZSL_NetworkList res = psModels.CNFH.NETWORKWARNING(i_rows);
            return Newtonsoft.Json.JsonConvert.SerializeObject(res);
        }
        public string SELECTCALENDAR(string ksdate,string jsdate){
            ZSL_CALENDARList res = psModels.CNFH.ZPSFUG_Q_CALENDAR(ksdate, jsdate);

            return Newtonsoft.Json.JsonConvert.SerializeObject(res);
        }
        public string MODIFYCALENDAR(string data, string I_CALENDAY, string I_WORKDAY,string isworkday)
        {
            ZSL_CALENDARList node = new ZSL_CALENDARList();
           //ZSL_WORKDAY    ZSL_CALENDAR
           if (I_CALENDAY == "X")
           {
              ZSL_CALENDAR zsl_calendar = Newtonsoft.Json.JsonConvert.DeserializeObject<ZSL_CALENDAR>(data);
              ZSL_CALENDARList node_res = psModels.CNFH.ZPSFUG_Q_CALENDAR(zsl_calendar.CDATE, zsl_calendar.CDATE);
              ZSL_CALENDAR node_calendar = node_res.ZSL_CALENDAR[0];
              if (isworkday == "X")
              {
                  node_calendar.ISWORKDAY = node_calendar.ISWORKDAY == "X" ? "" : "X";
              }
              else
              {
                  node_calendar.ISHOILDAY = node_calendar.ISHOILDAY == "X" ? "" : "X";
              }
              List<ZSL_CALENDAR> calendarlist = new List<ZSL_CALENDAR>();
               calendarlist.Add(node_calendar);
               List<ZSL_WORKDAY> workdaylist = new List<ZSL_WORKDAY>();
               node.ZSL_WORKDAY = workdaylist.ToArray();
               node.ZSL_CALENDAR = calendarlist.ToArray();

           }
           else if (I_WORKDAY == "X")
           {
               ZSL_WORKDAY[] ZSL_WORKDAY = Newtonsoft.Json.JsonConvert.DeserializeObject<ZSL_WORKDAY[]>(data);
               node.ZSL_WORKDAY = ZSL_WORKDAY;
               List<ZSL_CALENDAR> calendarlist = new List<ZSL_CALENDAR>();
               node.ZSL_CALENDAR = calendarlist.ToArray();
           }
           Sonluk.UI.Model.PS.CNFHService.PS_MSG ps_msg = psModels.CNFH.ZPSFUG_M_CALENDAR(node, I_CALENDAY, I_WORKDAY);
           return Newtonsoft.Json.JsonConvert.SerializeObject(ps_msg);
        }
        public ActionResult UpdateNetwork()
        {
            WBSPARMS node = psModels.CNFH.ReadWBSPARMS();
            // PS_CXFHCS c = new PS_CXFHCS();
            // c.I_BASEDATA = "X";
            // c.I_TEMPDATA = "X";
            // c.I_DAYDATA = "X";
            // c.I_MONTHDATA = "X";
            // c.I_WEEKDATA= "X";
            //ZSL_GXFHTABLE r =  psModels.CNFH.GXFHTABLE(c);
            ViewBag.WBS = node.ET_PRPS;
            ViewBag.TCNRFPT = node.ET_TCNRFPT;
            AppClass.SetSession("location", 227);
            return View();
        }

        public ActionResult LJjdcx()
        {
            return View();
        }

        public ActionResult Verify(string action)
        {
            ActionResult art;
            if (action == "CX")
            {
                art = RedirectToAction("ljCX", "PS");
            }
            else
            {
                art = RedirectToAction("SignIn", "Access", new { area = "" });
            }
            return art;
        }
        public ActionResult Insert_GZCN()
        {
            return View();
        }
        public ActionResult Modify_GZCN()
        {
            AppClass.SetSession("location", 228);
            
            return View();
        }
        public string ZPSFUG_Q_GZCN(string gxms)
        {
            ZSL_GZCNList res = psModels.CNFH.ZPSFUG_Q_GZCN(gxms);
            return Newtonsoft.Json.JsonConvert.SerializeObject(res); 
        }
        public string ZPSFUG_M_GZCN(string gzcn, string t435t,string flag)
        {
            T435T[] T435Tarr = Newtonsoft.Json.JsonConvert.DeserializeObject<T435T[]>(t435t);
            ZSL_GZCN gzcns = Newtonsoft.Json.JsonConvert.DeserializeObject<ZSL_GZCN>(gzcn);
            List<ZSL_GZ_VLSCH> nodes = new List<ZSL_GZ_VLSCH>();

            for (int i = 0; i < T435Tarr.Length; i++)
            {
                ZSL_GZ_VLSCH node = new ZSL_GZ_VLSCH();
                node.GZMS = gzcns.GZMS;
                node.VLSCH = T435Tarr[i].VLSCH;
                nodes.Add(node);
            }
            Sonluk.UI.Model.PS.CNFHService.PS_MSG ps_msg = psModels.CNFH.ZPSFUG_M_GZCN(gzcns, nodes.ToArray(), flag);

            return Newtonsoft.Json.JsonConvert.SerializeObject(ps_msg); 
        }
        public ActionResult Select_GZCN()
        {
            return View();
        }
        public string SelectFHDATA(string ks, string js, int type,int ts)
        {
            PS_CXFHCS model = new PS_CXFHCS();
           
            if (type == 1)
            {
                model.I_DAYDATA = "X";
            }
            else if (type == 2)
            {
                model.I_WEEKDATA = "X";
            }
            else if (type == 3)
            {
                model.I_MONTHDATA = "X";
            }
            model.I_DAY = ks;
            model.I_DAY1 = js;
            ZSL_GXFHTABLE res = psModels.CNFH.GXFHTABLE(model);
            return Newtonsoft.Json.JsonConvert.SerializeObject(res);
        }
        public string ZPSFUG_Q_GZCNREPORT(string ks, string js,string flag)
        {
           GZCNREPORT res = psModels.CNFH.ZPSFUG_Q_GZCNREPORT(ks, js,flag);
           return Newtonsoft.Json.JsonConvert.SerializeObject(res);
        }



        public string SYNCCNDATA(){
            return Newtonsoft.Json.JsonConvert.SerializeObject(psModels.CNFH.SYNCCNDATA());
        }
        public string JGHFMODIFY(string data)
        {
            List<ZSL_GXCN> nodes = new List<ZSL_GXCN>();
            if (!string.IsNullOrEmpty(data))
            {
                nodes = Newtonsoft.Json.JsonConvert.DeserializeObject<ZSL_GXCN[]>(data).ToList();
            }
            CNFHLIST rst = psModels.CNFH.ModifyCNFH(nodes);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);

        }
       
        public string SELECTNETWORK(string pspnr, string data)
        {
            SelectKv[] kvdata = Newtonsoft.Json.JsonConvert.DeserializeObject<SelectKv[]>(data);
            List<ET_TCNRFPT> nodes = new List<ET_TCNRFPT>();
            for (int i = 0; i < kvdata.Length; i++)
            {
                ET_TCNRFPT node = new ET_TCNRFPT();
                node.RFPNT = kvdata[i].Value;
                nodes.Add(node);
            }
            //ET_TCNRFPT[] p = 

            ZSL_NetworkList rst = psModels.CNFH.SELECTJGNETWORK(pspnr, nodes);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);

        }
        public string UpdateNetworkSap(string data)
        {
            ZSL_NETWORK[] networkList = Newtonsoft.Json.JsonConvert.DeserializeObject<ZSL_NETWORK[]>(data);
            Sonluk.UI.Model.PS.CNFHService.PS_MSG res = psModels.CNFH.UpdateNetwork(networkList);
            return Newtonsoft.Json.JsonConvert.SerializeObject(res);

        }

        [HttpPost]
        public ActionResult _ljCXlist(string in_wlh)
        {
            string token = AppClass.GetSession("token").ToString();
            NetworkRead network = psModels.NetWork.read(in_wlh, token);
            ViewData.Model = network;
            return View();
        }


        [HttpPost]
        public ActionResult _QualifiedPartlist(string in_wlh)
        {
            string token = AppClass.GetSession("token").ToString();
            NetworkRead network = psModels.NetWork.read(in_wlh, token);
            ViewData.Model = network;
            return View();
        }



        [HttpPost]
        public ActionResult _ScrapPartlist(string in_wlh)
        {
            string token = AppClass.GetSession("token").ToString();
            NetworkRead network = psModels.NetWork.read(in_wlh, token);
            ViewData.Model = network;
            return View();
        }

        [HttpPost]
        public string _Stafflist(string in_wlh)
        {
            string token = AppClass.GetSession("token").ToString();
            string staffname = psModels.NetWork.StaffINFO(in_wlh, token);
            if (staffname == "")
            {
                return "";
            }
            else
            {
                return in_wlh + "_" + staffname;
            }
        }

        [HttpPost]
        public string StaffCardID(string in_wlh)
        {
            string token = AppClass.GetSession("token").ToString();
            string staffID = kqModels.KQinfo.StaffCardID(in_wlh);
            string staffname = "";
            if (staffID == "")
            {
                staffname = "";
            }
            else
            {
                staffname = psModels.NetWork.StaffINFO(staffID.Substring(4, 5), token);
            }
            return staffname;
        }

        [HttpPost]
        public string confirm(string lb_wlh, string in_Vornr, string in_Arbpl, string in_hgsl, string in_Zmeins, string in_sjgs, string in_ygh, string AUERU, string Grund, string Ltxa1, string KTSCH)
        {
            string token = AppClass.GetSession("token").ToString();
            Ps_work ps_work = new Ps_work();
            ps_work.Aufnr = lb_wlh;
            ps_work.Vornr = in_Vornr;
            ps_work.Arbpl = in_Arbpl;
            ps_work.OpRz1 = in_hgsl;
            ps_work.Opre1 = in_Zmeins;
            ps_work.Grund = Grund;
            ps_work.Ismnw = in_sjgs;
            //ps_work.Pernr = in_ygh;
            ps_work.Aueru = AUERU;
            ps_work.Leknw = AUERU;
            ps_work.Iedd = DateTime.Now.ToString("yyyyMMdd");
            ps_work.Ltxa1 = Ltxa1;
            ps_work.KTSCH = KTSCH;

            Ps_staff ps_staff = new Ps_staff();
            ps_staff.Inits = in_ygh;


            CRM_HG_STAFF staff = cmrmodele.HG_STAFF.ReadBySTAFFID(Convert.ToInt32(Session["STAFFID"]), AppClass.GetSession("token").ToString());
            ps_staff.Rufnm = staff.STAFFNO;

            string rst = psModels.NetWork.confirm(ps_work, ps_staff, token);
            return rst;
        }
        public string CNYJEXPORT(string datastring)
        {
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_RETURN_UI rst = new MES_RETURN_UI();
            try
            {

                ZSL_NETWORK[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<ZSL_NETWORK[]>(datastring);
                FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/PS/ExportFile/网络预警模版.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowcount = 1;
                for (int i = 0; i < model.Length; i++)
                {
                    int cellIndex = 0;
                    IRow row = sheet.CreateRow(rowcount++);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].AUFNR);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].KTEXT);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].GSTRP);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].GLTRP);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].LTXA1);
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(model[i].REMAINING));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(model[i].YJ));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(model[i].ZMENGE));
                    row.CreateCell(cellIndex++).SetCellValue(Convert.ToDouble(model[i].CYCLE));
                    row.CreateCell(cellIndex++).SetCellValue(model[i].PSPID);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].POST1);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].POSID);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].POST2);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].ZMAKTX);
                    row.CreateCell(cellIndex++).SetCellValue(model[i].ZMATNR);

                }

                string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                FileStream file1 = new FileStream(string.Format(@"{0}/Areas/PS/ExportFile/{1}.xlsx", Server.MapPath("~"), now + STAFFID + "13"), FileMode.Create);
                workbook.Write(file1);
                file1.Close();
                rst.TYPE = "S";
                rst.MESSAGE = now + STAFFID + "13";
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = "导出失败！";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst); ;
        }
        public ActionResult EXPORT_CNYJ(string filename)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/PS/ExportFile/{1}.xlsx", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", "网络预警导出.xlsx");
        }


        [HttpPost]
        public string NetWork_read(string in_wlh)
        {
            string token = AppClass.GetSession("token").ToString();
            NetworkRead network = psModels.NetWork.read(in_wlh, token);
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(network);
            return json;
        }


        class SelectKv
        {
            string _name;

            public string Name
            {
                get { return _name; }
                set { _name = value; }
            }
            string _value;

            public string Value
            {
                get { return _value; }
                set { _value = value; }
            }
        }
    }
}
