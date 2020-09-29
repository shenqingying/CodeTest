using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;
using System.Text;
using Newtonsoft.Json;
using Sonluk.PC.Models;
using Sonluk.UI.Model.CRM.KQ_YGQJService;
using Sonluk.UI.Model.CRM.KQ_CCService;
using Sonluk.UI.Model.CRM.KQ_YCKQSMService;
using Sonluk.UI.Model.CRM_OAService;
using Sonluk.UI.Model.CRM.CRM_KQ_ReportService;
using Sonluk.UI.Model.CRM.OA_TRANSMITService;
using Sonluk.UI.Model.CRM.HG_STAFFService;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using Sonluk.PC.APPCLASS;
using Sonluk.UI.Model.CRM.KQ_GZRLMXService;
using Sonluk.UI.Model.CRM.KQ_QDService;
using Sonluk.UI.Model.CRM.HG_WJJLService;

namespace Sonluk.PC.Areas.CRM.Controllers
{
    public class KaoQinController : Controller
    {
        //
        // GET: /CRM/KaoQin/
        CRMModels crmModels = new CRMModels();
        AppClass appClass = new AppClass();
        string token = "";
        string FileSavePath = System.Configuration.ConfigurationManager.AppSettings["FileSavePath"];
        string FileSavePath2 = System.Configuration.ConfigurationManager.AppSettings["FileSavePath2"];
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult QingJia()
        {
            Session["location"] = 13;
            //return PartialView("QingJia");
            DateTime now = DateTime.Now;
            ViewBag.startdate = now.AddMonths(-2).ToString("yyyy-MM-dd");
            ViewBag.enddate = now.AddMonths(1).ToString("yyyy-MM-dd");
            return View();
        }

        public ActionResult HeXiao_QingJia()
        {
            Session["location"] = 46;
            return View();
        }

        [HttpPost]
        public int Data_Insert_QingJia(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_KQ_YGQJ model = JsonConvert.DeserializeObject<CRM_KQ_YGQJ>(data);
            int i = crmModels.KQ_YGQJ.Create(model, token);


            return i;
        }

        [HttpPost]
        public string Data_Select_QingJia(int STAFFID)
        {
            token = appClass.CRM_Gettoken();
            Sonluk.UI.Model.CRM.KQ_YGQJService.CRM_KQ_YGQJList[] data = crmModels.KQ_YGQJ.ReadBySTAFFID(STAFFID, 4, token);
            for (int i = 0; i < data.Length; i++)
            {
                DateTime date = new DateTime();

                date = Convert.ToDateTime(data[i].JHQJKSSJ);
                data[i].JHQJKSSJ = date.ToString("yyyy-MM-dd HH:mm:ss");

                date = Convert.ToDateTime(data[i].JHQJJSSJ);
                data[i].JHQJJSSJ = date.ToString("yyyy-MM-dd HH:mm:ss");

                date = Convert.ToDateTime(data[i].SJQJKSSJ);
                data[i].SJQJKSSJ = date.ToString("yyyy-MM-dd HH:mm:ss");

                date = Convert.ToDateTime(data[i].SJJSKSSJ);
                data[i].SJJSKSSJ = date.ToString("yyyy-MM-dd HH:mm:ss");

                date = Convert.ToDateTime(data[i].QJRQ);
                data[i].QJRQ = date.ToString("yyyy-MM-dd HH:mm:ss");
            }
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public int Data_Update_QingJia(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_KQ_YGQJ model = JsonConvert.DeserializeObject<CRM_KQ_YGQJ>(data);
            int i = crmModels.KQ_YGQJ.Update(model, token);
            return i;

        }

        [HttpPost]
        public int Data_Delete_QingJia(int YGQJID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.KQ_YGQJ.Delete(YGQJID, token);
            return i;
        }

        [HttpPost]
        public string Data_Select_QingJia_ByModel(string qjdata)
        {
            token = appClass.CRM_Gettoken();
            try
            {
                CRM_KQ_YGQJ model = JsonConvert.DeserializeObject<CRM_KQ_YGQJ>(qjdata);
                model.STAFFID = Convert.ToInt32(Session["STAFFID"]);
                Sonluk.UI.Model.CRM.KQ_YGQJService.CRM_KQ_YGQJList[] data = crmModels.KQ_YGQJ.Read(model, token);
                for (int i = 0; i < data.Length; i++)
                {
                    DateTime date = new DateTime();

                    date = Convert.ToDateTime(data[i].JHQJKSSJ);
                    data[i].JHQJKSSJ = date.ToString("yyyy-MM-dd HH:mm:ss");

                    date = Convert.ToDateTime(data[i].JHQJJSSJ);
                    data[i].JHQJJSSJ = date.ToString("yyyy-MM-dd HH:mm:ss");

                    date = Convert.ToDateTime(data[i].SJQJKSSJ);
                    data[i].SJQJKSSJ = date.ToString("yyyy-MM-dd HH:mm:ss");

                    date = Convert.ToDateTime(data[i].SJJSKSSJ);
                    data[i].SJJSKSSJ = date.ToString("yyyy-MM-dd HH:mm:ss");

                    date = Convert.ToDateTime(data[i].QJRQ);
                    data[i].QJRQ = date.ToString("yyyy-MM-dd HH:mm:ss");
                }
                string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                return s;
            }
            catch (Exception e)
            {
                return e.ToString();
            }

        }

        [HttpPost]
        public string Data_Select_QingJia_ByDepRight(string qjdata)
        {
            token = appClass.CRM_Gettoken();
            try
            {
                CRM_KQ_YGQJ model = JsonConvert.DeserializeObject<CRM_KQ_YGQJ>(qjdata);
                model.STAFFID = Convert.ToInt32(Session["STAFFID"]);
                model.ISACTIVE = 3;
                Sonluk.UI.Model.CRM.KQ_YGQJService.CRM_KQ_YGQJList[] data = crmModels.KQ_YGQJ.ReadByDepartRight(model, token);
                for (int i = 0; i < data.Length; i++)
                {
                    DateTime date = new DateTime();

                    date = Convert.ToDateTime(data[i].JHQJKSSJ);
                    data[i].JHQJKSSJ = date.ToString("yyyy-MM-dd HH:mm:ss");

                    date = Convert.ToDateTime(data[i].JHQJJSSJ);
                    data[i].JHQJJSSJ = date.ToString("yyyy-MM-dd HH:mm:ss");

                    date = Convert.ToDateTime(data[i].SJQJKSSJ);
                    data[i].SJQJKSSJ = date.ToString("yyyy-MM-dd HH:mm:ss");

                    date = Convert.ToDateTime(data[i].SJJSKSSJ);
                    data[i].SJJSKSSJ = date.ToString("yyyy-MM-dd HH:mm:ss");

                    date = Convert.ToDateTime(data[i].QJRQ);
                    data[i].QJRQ = date.ToString("yyyy-MM-dd HH:mm:ss");
                }
                string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                return s;
            }
            catch (Exception e)
            {
                return e.ToString();
            }

        }

        [HttpPost]
        public string Data_Submit_QingJia(string _basic, string _list, int DEP, int YGQJID)
        {
            token = appClass.CRM_Gettoken();
            CRM_OA_BASIC basic = JsonConvert.DeserializeObject<CRM_OA_BASIC>(_basic);
            basic.TemplateCode = crmModels.SYS_CS.Read(4, token)[0].CS.ToString();
            CRM_OA_QJList list = JsonConvert.DeserializeObject<CRM_OA_QJList>(_list);
            list.DEP = crmModels.HG_DEPT.ReadByDEPID(DEP, token).DEPNAME;

            MessageInfo info = crmModels.CRM_OA.Launch(basic, list, token);         //提交
            if (info.Key != "0" && info.Key != "-1")
            {
                CRM_KQ_YGQJ data = crmModels.KQ_YGQJ.ReadByYGQJID(YGQJID, token);
                data.ISACTIVE = 2;
                crmModels.KQ_YGQJ.Update(data, token);


                CRM_OA_TRANSMIT model = new CRM_OA_TRANSMIT();
                model.OAID = info.Key;
                model.OACSBH = YGQJID;
                model.OACSLB = 92;
                model.OAZT = 1;
                model.CJSJ = DateTime.Now.ToString("yyyy-MM-dd");
                crmModels.OA_TRANSMIT.Create(model, token);


            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(info);
        }

        public ActionResult ChuChai()
        {
            Session["location"] = 14;
            //return PartialView("ChuChai");
            DateTime now = DateTime.Now;
            ViewBag.startdate = now.AddMonths(-2).ToString("yyyy-MM-dd");
            ViewBag.enddate = now.AddMonths(1).ToString("yyyy-MM-dd");
            return View();
        }

        public ActionResult Insert_ChuChai()
        {
            Session["location"] = 43;
            return View();
        }

        public ActionResult Select_ChuChai()
        {
            Session["location"] = 44;
            return View();
        }

        public ActionResult Update_ChuChai()
        {

            return View();
        }

        public ActionResult HeXiao_ChuChai()
        {
            Session["location"] = 60;
            DateTime now = DateTime.Now;
            ViewBag.startdate = now.AddMonths(-2).ToString("yyyy-MM-dd");
            ViewBag.enddate = now.AddMonths(1).ToString("yyyy-MM-dd");
            return View();
        }

        public ActionResult HeXiao_Update_ChuChai()
        {
            return View();
        }

        [HttpPost]
        public string Data_Submit_ChuChai(string _basic, string _list, int CCID, int staffid, int type)
        {
            token = appClass.CRM_Gettoken();
            //先校验这个ccid对应的天数是否等于明细的条数
            CRM_KQ_CCTT CCdata = crmModels.KQ_CC.Read_TTbyCCID(CCID, token);
            CRM_KQ_CCMX[] mxmodel = crmModels.KQ_CC.Read_MXbyCCID(CCID, token);
            if (CCdata.SJCCTS * 2 > mxmodel.Length)
            {
                return "0";
            }

            CRM_OA_BASIC basic = JsonConvert.DeserializeObject<CRM_OA_BASIC>(_basic);
            basic.LoginName = crmModels.HG_STAFF.ReadBySTAFFID(staffid, token).STAFFNO;
            basic.TemplateCode = crmModels.SYS_CS.Read(5, token)[0].CS.ToString();
            CRM_OA_CC list = JsonConvert.DeserializeObject<CRM_OA_CC>(_list);
            //list.DEP = crmModels.HG_DEPT.ReadByDEPID(DEP, token).DEPNAME;
            list.CXFS = crmModels.HG_DICT.ReadByDICID(Convert.ToInt32(list.CXFS), token).DICNAME;
            switch (type)
            {
                case 1:
                    list.TITLE = "出差申请单";
                    break;
                case 2:
                    list.TITLE = "出差变更申请单";
                    break;
                case 3:
                    list.TITLE = "出差撤销申请单";
                    break;
                default:
                    list.TITLE = "";
                    break;
            }
            list.BEIZ = CCdata.BEIZ;
            if (list.QTCXFSJE == "0" || list.QTCXFSJE == "0.00")
                list.QTCXFSJE = "";

            list.CRM_OA_CC_SUBList = new CRM_OA_CC_SUB[mxmodel.Length];
            for (int i = 0; i < mxmodel.Length; i++)
            {
                list.CRM_OA_CC_SUBList[i] = new CRM_OA_CC_SUB();
                list.CRM_OA_CC_SUBList[i].DATE = mxmodel[i].DATE;
                string sjlx = "";   //上午或下午
                if (mxmodel[i].CCSJLX == 1)
                    sjlx = "上午";
                else if (mxmodel[i].CCSJLX == 2)
                    sjlx = "下午";
                list.CRM_OA_CC_SUBList[i].CCSJLXDES = sjlx;
                list.CRM_OA_CC_SUBList[i].DD = mxmodel[i].DD;
                list.CRM_OA_CC_SUBList[i].GZMB = mxmodel[i].GZMB;
            }


            MessageInfo info = crmModels.CRM_OA.Launch(basic, list, token);         //提交
            if (info.Key != "0" && info.Key != "-1")
            {
                CRM_KQ_CCTT data = crmModels.KQ_CC.Read_TTbyCCID(CCID, token);
                data.ISACTIVE = 2;
                crmModels.KQ_CC.Update_TT(data, token);


                CRM_OA_TRANSMIT model = new CRM_OA_TRANSMIT();
                model.OAID = info.Key;
                model.OACSBH = CCID;
                model.OACSLB = 93;
                model.OAZT = 1;
                model.CJSJ = DateTime.Now.ToString("yyyy-MM-dd");
                crmModels.OA_TRANSMIT.Create(model, token);


            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(info);
        }

        [HttpPost]
        public string Data_Submit_ChuChaiHeXiao(string _list, int CCID, int staffid)
        {
            token = appClass.CRM_Gettoken();
            CRM_OA_BASIC basic = new CRM_OA_BASIC();
            basic.LoginName = crmModels.HG_STAFF.ReadBySTAFFID(staffid, token).STAFFNO;
            basic.TemplateCode = crmModels.SYS_CS.Read(6, token)[0].CS.ToString();
            basic.Subject = "出差核销单(" + crmModels.HG_STAFF.ReadBySTAFFID(staffid, token).STAFFNAME;
            CRM_OA_CC list = JsonConvert.DeserializeObject<CRM_OA_CC>(_list);


            CRM_KQ_CCTT CCmodel = crmModels.KQ_CC.Read_TTbyCCID(CCID, token);
            if (CCmodel.ISACTIVE != 3 && CCmodel.ISACTIVE != 4)
            {
                MessageInfo msg = new MessageInfo();
                msg.Key = "0";
                msg.Value = "当前状态不可提交";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
            if (CCmodel.SJJE.ToString() == "")
            {
                MessageInfo msg = new MessageInfo();
                msg.Key = "0";
                msg.Value = "实际金额不可为空";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }

            //校验明细的目标完成情况是不是都填了
            CRM_KQ_CCMX[] MXmodel = crmModels.KQ_CC.Read_MXbyCCID(CCID, token);
            for (int i = 0; i < MXmodel.Length; i++)
            {
                if (MXmodel[i].MBWCQK == "")
                {
                    MessageInfo msg = new MessageInfo();
                    msg.Key = "0";
                    msg.Value = "请检查目标完成情况是否填写完整";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                }
            }

            list.BEIZ = CCmodel.BEIZ;
            if (list.QTCXFSJE == "0" || list.QTCXFSJE == "0.00")
                list.QTCXFSJE = "";

            CRM_KQ_CCMXList[] mxmodel = crmModels.KQ_CC.Read_MXQDbyCCID(CCID, token);
            list.CRM_OA_CC_SUBList = new CRM_OA_CC_SUB[mxmodel.Length];
            for (int i = 0; i < mxmodel.Length; i++)
            {
                list.CRM_OA_CC_SUBList[i] = new CRM_OA_CC_SUB();
                list.CRM_OA_CC_SUBList[i].DATE = mxmodel[i].DATE;
                string sjlx = "";   //上午或下午
                if (mxmodel[i].CCSJLX == 1)
                    sjlx = "上午";
                else if (mxmodel[i].CCSJLX == 2)
                    sjlx = "下午";
                list.CRM_OA_CC_SUBList[i].CCSJLXDES = sjlx;
                list.CRM_OA_CC_SUBList[i].DD = mxmodel[i].DD;
                list.CRM_OA_CC_SUBList[i].GZMB = mxmodel[i].GZMB;
                list.CRM_OA_CC_SUBList[i].MBWCQK = mxmodel[i].MBWCQK;
                list.CRM_OA_CC_SUBList[i].QDWZ = mxmodel[i].QDSJ + "   " + mxmodel[i].QDWZ;
            }

            CRM_HG_WJJL[] imgdata = crmModels.HG_WJJL.Read(9, CCID, token);
            string[] img = new string[imgdata.Length];
            for (int i = 0; i < imgdata.Length; i++)
            {
                img[i] = imgdata[i].ML;
            }
            list.IMG = img;

            MessageInfo info = crmModels.CRM_OA.Launch(basic, list, token);         //提交
            if (info.Key != "0" && info.Key != "-1")
            {
                CRM_KQ_CCTT data = crmModels.KQ_CC.Read_TTbyCCID(CCID, token);
                data.ISACTIVE = 5;
                crmModels.KQ_CC.Update_TT(data, token);


                CRM_OA_TRANSMIT model = new CRM_OA_TRANSMIT();
                model.OAID = info.Key;
                model.OACSBH = CCID;
                model.OACSLB = 105;
                model.OAZT = 3;
                model.CJSJ = DateTime.Now.ToString("yyyy-MM-dd");
                crmModels.OA_TRANSMIT.Create(model, token);


            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(info);
        }

        [HttpPost]
        public int Data_Insert_CCTT(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_KQ_CCTT model = JsonConvert.DeserializeObject<CRM_KQ_CCTT>(data);
            int i = crmModels.KQ_CC.Create_TT(model, token);
            return i;
        }

        [HttpPost]
        public string Data_Select_CCTT(int staffid, int status)
        {
            token = appClass.CRM_Gettoken();
            Sonluk.UI.Model.CRM.KQ_CCService.CRM_KQ_CCTTList[] data = crmModels.KQ_CC.Read_TTbySTAFFID(staffid, status, token);
            for (int i = 0; i < data.Length; i++)
            {
                DateTime date = new DateTime();

                date = Convert.ToDateTime(data[i].JHCCKSSJ);
                data[i].JHCCKSSJ = date.ToString("yyyy-MM-dd HH:mm:ss");

                date = Convert.ToDateTime(data[i].JHCCJSSJ);
                data[i].JHCCJSSJ = date.ToString("yyyy-MM-dd HH:mm:ss");

                date = Convert.ToDateTime(data[i].SJKSSJ);
                data[i].SJKSSJ = date.ToString("yyyy-MM-dd HH:mm:ss");

                date = Convert.ToDateTime(data[i].SJCCJSSJ);
                data[i].SJCCJSSJ = date.ToString("yyyy-MM-dd HH:mm:ss");

                date = Convert.ToDateTime(data[i].CCSQSJ);
                data[i].CCSQSJ = date.ToString("yyyy-MM-dd HH:mm:ss");
            }
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public string Data_Select_CCTT_ByCCID(int CCID)
        {
            token = appClass.CRM_Gettoken();
            CRM_KQ_CCTT data = crmModels.KQ_CC.Read_TTbyCCID(CCID, token);
            DateTime date = new DateTime();

            date = Convert.ToDateTime(data.JHCCKSSJ);
            data.JHCCKSSJ = date.ToString("yyyy-MM-dd HH:mm:ss");

            date = Convert.ToDateTime(data.JHCCJSSJ);
            data.JHCCJSSJ = date.ToString("yyyy-MM-dd HH:mm:ss");

            date = Convert.ToDateTime(data.SJKSSJ);
            data.SJKSSJ = date.ToString("yyyy-MM-dd HH:mm:ss");

            date = Convert.ToDateTime(data.SJCCJSSJ);
            data.SJCCJSSJ = date.ToString("yyyy-MM-dd HH:mm:ss");

            date = Convert.ToDateTime(data.CCSQSJ);
            data.CCSQSJ = date.ToString("yyyy-MM-dd HH:mm:ss");


            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public string Data_Select_CCTT_ByModel(string cxdata, int status)
        {
            token = appClass.CRM_Gettoken();
            CRM_KQ_CCTT model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_KQ_CCTT>(cxdata);
            model.STAFFID = Convert.ToInt32(Session["STAFFID"]);
            Sonluk.UI.Model.CRM.KQ_CCService.CRM_KQ_CCTTList[] data = crmModels.KQ_CC.Read_TTbyParam(model, status, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;


        }

        [HttpPost]
        public int Data_Update_CCTT(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_KQ_CCTT model = JsonConvert.DeserializeObject<CRM_KQ_CCTT>(data);
            int i = crmModels.KQ_CC.Update_TT(model, token);
            return i;
        }

        [HttpPost]
        public int Data_Delete_CCTT(int CCID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.KQ_CC.Delete_TT(CCID, token);
            return i;
        }

        [HttpPost]
        public int Data_Insert_CCMX(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_KQ_CCMX model = JsonConvert.DeserializeObject<CRM_KQ_CCMX>(data);
            int i = crmModels.KQ_CC.Create_MX(model, token);
            return i;
        }

        [HttpPost]
        public string Data_Select_CCMX(int ccid)
        {
            token = appClass.CRM_Gettoken();
            CRM_KQ_CCMX[] model = crmModels.KQ_CC.Read_MXbyCCID(ccid, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(model);
            return s;
        }

        [HttpPost]
        public string Data_Select_CCMXQD(int ccid)
        {
            token = appClass.CRM_Gettoken();
            CRM_KQ_CCMXList[] model = crmModels.KQ_CC.Read_MXQDbyCCID(ccid, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(model);
            return s;
        }

        [HttpPost]
        public int Data_Update_CCMX(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_KQ_CCMX model = JsonConvert.DeserializeObject<CRM_KQ_CCMX>(data);
            int i = crmModels.KQ_CC.Update_MX(model, token);
            return i;
        }

        [HttpPost]
        public int Data_Delete_CCMX(int MXID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.KQ_CC.Delete_MX(MXID, token);
            return i;
        }

        public ActionResult ChuChaiMX()
        {


            return View();
        }

        public ActionResult YiChang()
        {
            Session["location"] = 15;
            //return PartialView("YiChang");
            return View();
        }

        public ActionResult YiChang_HeXiao()
        {
            Session["location"] = 20;
            DateTime enddate = DateTime.Now;
            DateTime startdate = new DateTime(enddate.Year, enddate.Month, 1);
            ViewBag.enddate = enddate.ToString("yyyy-MM-dd");
            ViewBag.startdate = startdate.ToString("yyyy-MM-dd");
            return View();
        }

        [HttpPost]
        public int Data_Insert_YiChang(string data)
        {
            token = appClass.CRM_Gettoken();
            Sonluk.UI.Model.CRM.KQ_YCKQSMService.CRM_KQ_YCKQSMList model = JsonConvert.DeserializeObject<Sonluk.UI.Model.CRM.KQ_YCKQSMService.CRM_KQ_YCKQSMList>(data);
            //crmModels.KQ_QD.re

            model.ISACTIVE = 0;     //先传0，表示忽略该字段进行查询，查出来如果有，就不能继续新增
            int count = crmModels.KQ_YCKQSM.ReadByParam(model, token).Length;
            if (count != 0)
            {
                return -1;
            }

            model.ISACTIVE = 1;
            int i = crmModels.KQ_YCKQSM.Create(model, token);
            return i;
        }

        [HttpPost]
        public string Data_Select_YiChangBySTAFFID(int staffid)
        {
            token = appClass.CRM_Gettoken();
            Sonluk.UI.Model.CRM.KQ_YCKQSMService.CRM_KQ_YCKQSMList[] model = crmModels.KQ_YCKQSM.ReadBySTAFFID(staffid, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(model);
            return s;
        }
        
        [HttpPost]
        public string Data_Select_YiChang(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_KQ_YCKQSMList model = JsonConvert.DeserializeObject<CRM_KQ_YCKQSMList>(cxdata);
            Sonluk.UI.Model.CRM.KQ_YCKQSMService.CRM_KQ_YCKQSMList[] data = crmModels.KQ_YCKQSM.ReadByParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Selece_QueQin()                    //找出当前人员的两个月内的缺勤记录
        {
            token = appClass.CRM_Gettoken();
            string now = DateTime.Now.ToString("yyyy-MM-dd");
            string ago = DateTime.Now.AddMonths(-2).ToString("yyyy-MM-dd");
            CRM_KQ_QQList[] data = crmModels.CRM_KQ_Report.CRM_KQ_Detail_QQ(Convert.ToInt32(Session["STAFFID"]), ago, now, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public int Data_Update_YiChang(string data)
        {
            token = appClass.CRM_Gettoken();
            Sonluk.UI.Model.CRM.KQ_YCKQSMService.CRM_KQ_YCKQSM model = JsonConvert.DeserializeObject<Sonluk.UI.Model.CRM.KQ_YCKQSMService.CRM_KQ_YCKQSM>(data);
            int i = crmModels.KQ_YCKQSM.Update(model, token);
            return i;
        }

        [HttpPost]
        public int Data_Delete_YiChang(int YCKQID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.KQ_YCKQSM.Delete(YCKQID, token);
            return i;
        }

        [HttpPost]
        public string Data_HeXiao_YiChang(int YCKQID)
        {
            token = appClass.CRM_Gettoken();
            WebMSG webmsg = new WebMSG();
            int i = crmModels.KQ_YCKQSM.UpdateStatus(YCKQID, 31, token);
            webmsg.KEY = i;
            if (i > 0)
            {
                webmsg.MSG = "修改成功！";
            }
            else
            {
                webmsg.MSG = "修改失败！";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        public ActionResult Apply_yichang()
        {

            return View();
        }

        public ActionResult BaoBiao()
        {
            Session["location"] = 16;
            DateTime enddate = DateTime.Now;
            DateTime startdate = new DateTime(enddate.Year, enddate.Month, 1);
            ViewBag.enddate = enddate.ToString("yyyy-MM-dd");
            ViewBag.startdate = startdate.ToString("yyyy-MM-dd");
            //return PartialView("BaoBiao");
            return View();
        }

        public ActionResult BaoBiao_Personal()
        {
            Session["location"] = 51;
            DateTime enddate = DateTime.Now;
            DateTime startdate = new DateTime(enddate.Year, enddate.Month, 1);
            ViewBag.enddate = enddate.ToString("yyyy-MM-dd");
            ViewBag.startdate = startdate.ToString("yyyy-MM-dd");
            //return PartialView("BaoBiao");
            return View();
        }

        [HttpPost]
        public string Data_Selece_KaoQin(int STAFFLX, string STAFFNAME, string STAFFNO, string open, string end, int DEPID, int OnlyQQ)
        {
            token = appClass.CRM_Gettoken();
            CRM_KQ_COLLECTList[] data = crmModels.CRM_KQ_Report.CRM_KQ_REPORT_SUMMARY(0, DEPID, STAFFLX, STAFFNAME, STAFFNO, open, end, OnlyQQ, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public string Data_Selece_KaoQin_Personal(string open, string end)
        {
            token = appClass.CRM_Gettoken();
            string staffno = crmModels.HG_STAFF.ReadBySTAFFID(Convert.ToInt32(Session["STAFFID"]), token).STAFFNO;
            CRM_KQ_COLLECTList[] data = crmModels.CRM_KQ_Report.CRM_KQ_REPORT_SUMMARY(Convert.ToInt32(Session["STAFFID"]), 0, 0, "", staffno, open, end, 0, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public string Data_Select_KaoQin_QD(int staffid, string opentime, string endtime)
        {
            token = appClass.CRM_Gettoken();
            CRM_KQ_QDList[] data = crmModels.CRM_KQ_Report.CRM_KQ_Detail_QD(staffid, opentime, endtime, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public string Data_Select_KaoQin_CC(int staffid, string opentime, string endtime)
        {
            token = appClass.CRM_Gettoken();
            Sonluk.UI.Model.CRM.CRM_KQ_ReportService.CRM_KQ_CCTTList[] data = crmModels.CRM_KQ_Report.CRM_KQ_Detail_CC(staffid, opentime, endtime, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public string Data_Select_KaoQin_QJ(int staffid, string opentime, string endtime)
        {
            token = appClass.CRM_Gettoken();
            Sonluk.UI.Model.CRM.CRM_KQ_ReportService.CRM_KQ_YGQJList[] data = crmModels.CRM_KQ_Report.CRM_KQ_Detail_QJ(staffid, opentime, endtime, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public string Data_Select_KaoQin_YC(int staffid, string opentime, string endtime)
        {
            token = appClass.CRM_Gettoken();
            Sonluk.UI.Model.CRM.CRM_KQ_ReportService.CRM_KQ_YCKQSM[] data = crmModels.CRM_KQ_Report.CRM_KQ_Detail_YC(staffid, opentime, endtime, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public string Data_Select_KaoQin_QQ(int staffid, string opentime, string endtime)
        {
            token = appClass.CRM_Gettoken();
            CRM_KQ_QQList[] data = crmModels.CRM_KQ_Report.CRM_KQ_Detail_QQ(staffid, opentime, endtime, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public string Data_Cacu_Date(int bbid, string open, string end, bool bopen, bool bend)           //计算一个时间段内的工作日天数
        {
            token = appClass.CRM_Gettoken();
            Double d = crmModels.KQ_GZRLMX.CountDaysByGZRLMX(bbid, open, end, bopen, bend, token);
            return d.ToString();
        }

        [HttpPost]
        public string Data_Verify(int staffid, string open, string end, int ygqjid, int ccid)              //校验出差和请假有没有重复时间
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.KQ_YGQJ.Verify_QJ(open, end, staffid, token, ygqjid, ccid);
            if (i == 0)
                return "ok";
            if (i == 1)
                return "与请假时间冲突";
            if (i == 2)
                return "与出差时间冲突";
            if (i == 3)
                return "与请假出差时间冲突";
            else
                return "登录过期";
        }

        //[HttpPost]
        //public string Data_Select_STAFF_ByDepartment()
        //{
        //    token = appClass.CRM_Gettoken();
        //    crmModels

        //}

        [HttpPost]
        public string Data_Submit_YiChang(string data)
        {
            token = appClass.CRM_Gettoken();
            Sonluk.UI.Model.CRM.KQ_YCKQSMService.CRM_KQ_YCKQSMList[] checkdata = Newtonsoft.Json.JsonConvert.DeserializeObject<Sonluk.UI.Model.CRM.KQ_YCKQSMService.CRM_KQ_YCKQSMList[]>(data);

            CRM_OA_BASIC basic = new CRM_OA_BASIC();
            CRM_HG_STAFF staffmodel = crmModels.HG_STAFF.ReadBySTAFFID(Convert.ToInt32(Session["STAFFID"]), token);
            basic.LoginName = staffmodel.STAFFNO;
            basic.Subject = "异常考勤说明(" + staffmodel.STAFFNAME;
            basic.TemplateCode = crmModels.SYS_CS.Read(12, token)[0].CS.ToString();

            CRM_OA_YCKQSM list = new CRM_OA_YCKQSM();
            list.STAFFNAME = staffmodel.STAFFNAME;

            list.SMTABLEList = new SMTABLE[checkdata.Length];
            for (int i = 0; i < checkdata.Length; i++)
            {
                list.SMTABLEList[i] = new SMTABLE();
                list.SMTABLEList[i].SMRQ = checkdata[i].SMRQ;
                list.SMTABLEList[i].SMSXB = (checkdata[i].SMSXB == 1) ? "上班" : "下班";
                list.SMTABLEList[i].SMSX = checkdata[i].SMSX;
            }

            if (checkdata[0].KQQDID != 0)
            {
                list.QDSJ = checkdata[0].QDSJ;
                list.QDWZ = checkdata[0].QDWZ;
                list.KQJL = checkdata[0].KQJL + "米";
            }
            else
            {
                list.QDSJ = "没有考勤";
                list.QDWZ = "";
                list.KQJL = "";
            }




            MessageInfo info = crmModels.CRM_OA.Launch(basic, list, token);         //提交
            if (info.Key != "0" && info.Key != "-1")
            {

                for (int i = 0; i < checkdata.Length; i++)
                {
                    checkdata[i].ISACTIVE = 2;
                    crmModels.KQ_YCKQSM.Update(checkdata[i], token);

                    CRM_OA_TRANSMIT model = new CRM_OA_TRANSMIT();
                    model.OAID = info.Key;
                    model.OACSBH = checkdata[i].YCKQID;
                    model.OACSLB = 104;
                    model.OAZT = 1;
                    model.CJSJ = DateTime.Now.ToString("yyyy-MM-dd");
                    crmModels.OA_TRANSMIT.Create(model, token);
                }

            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(info);



        }


        [HttpPost]
        public string Data_DaoChu_KaoQinSummary(string data)
        {
            PublicController otherController = DependencyResolver.Current.GetService<PublicController>();
            string result = otherController.ToExcel(data, 3, "");

            return result;
        }

        [HttpPost]
        public string Data_Daochu_KaoQinSummaryAndSXB(string data, string starttime, string endtime)
        {
            token = appClass.CRM_Gettoken();
            try
            {
                CRM_KQ_COLLECTList[] model = JsonConvert.DeserializeObject<CRM_KQ_COLLECTList[]>(data);


                FileStream file = new FileStream(FileSavePath + @"\ExcelTemplate/考勤报表.xls", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new HSSFWorkbook(file);
                ISheet worksheet1 = workbook.GetSheet("汇总");
                ISheet worksheet2 = workbook.GetSheet("正常上下班");
                ISheet worksheet3 = workbook.GetSheet("缺勤记录");
                if (worksheet1 == null || worksheet2 == null || worksheet3 == null)
                    return "工作薄中没有工作表";
                //worksheet1.AddMergedRegion(new CellRangeAddress(1, 2, 3, 4));
                int row1 = 1, row2 = 1, row3 = 1;
                for (int i = 0; i < model.Length; i++)
                {
                    NPOI.SS.UserModel.IRow row_hz = worksheet1.CreateRow(row1);
                    row_hz.CreateCell(0).SetCellValue(model[i].STAFFNAME);
                    row_hz.CreateCell(1).SetCellValue(model[i].STAFFNO);
                    row_hz.CreateCell(2).SetCellValue(model[i].DEPNAME);
                    row_hz.CreateCell(3).SetCellValue(model[i].DAYCOUNTS);
                    row_hz.CreateCell(4).SetCellValue(model[i].ZCDAYCOUNTS);
                    row_hz.CreateCell(5).SetCellValue(model[i].CCDAYCOUNTS);
                    row_hz.CreateCell(6).SetCellValue(model[i].QJDAYCOUNTS);
                    row_hz.CreateCell(7).SetCellValue(model[i].YCDAYCOUNTS);
                    row_hz.CreateCell(8).SetCellValue(model[i].QQDAYCOUNTS);

                    row1++;


                    CRM_KQ_QDList[] QDdata = crmModels.CRM_KQ_Report.CRM_KQ_Detail_QD(model[i].STAFFID, starttime, endtime, token);
                    for (int j = 0; j < QDdata.Length; j++)
                    {

                        NPOI.SS.UserModel.IRow row_sxb = worksheet2.CreateRow(row2);
                        row_sxb.CreateCell(0).SetCellValue(QDdata[j].QDGSIDDES);
                        row_sxb.CreateCell(1).SetCellValue(QDdata[j].QDSJ);
                        string sxbdes = "";
                        if (QDdata[j].SXB == 1 || QDdata[j].SXB == 10)
                        {
                            sxbdes = "上班";
                        }
                        else
                        {
                            sxbdes = "下班";
                        }
                        row_sxb.CreateCell(2).SetCellValue(sxbdes);
                        row_sxb.CreateCell(3).SetCellValue(QDdata[j].QDWZ);
                        row_sxb.CreateCell(4).SetCellValue(QDdata[j].KQJL);
                        string isactivedes = "";
                        if (QDdata[j].ISACTIVE == 1)
                        {
                            isactivedes = "正常";
                        }
                        else
                        {
                            isactivedes = "不在范围内";
                        }
                        row_sxb.CreateCell(5).SetCellValue(isactivedes);

                        row2++;
                    }
                    CRM_KQ_QQList[] QQdata = crmModels.CRM_KQ_Report.CRM_KQ_Detail_QQ(model[i].STAFFID, starttime, endtime, token);
                    for (int j = 0; j < QQdata.Length; j++)
                    {
                        NPOI.SS.UserModel.IRow row_qq = worksheet3.CreateRow(row3);
                        row_qq.CreateCell(0).SetCellValue(QQdata[j].STAFFNAME);
                        row_qq.CreateCell(1).SetCellValue(QQdata[j].RQ);
                        row_qq.CreateCell(2).SetCellValue(QQdata[j].SBQD == 1 ? "正常" : "无");
                        row_qq.CreateCell(3).SetCellValue(QQdata[j].XBQD == 1 ? "正常" : "无");

                        row3++;
                    }
                }


                worksheet1.ForceFormulaRecalculation = true;
                worksheet2.ForceFormulaRecalculation = true;
                worksheet3.ForceFormulaRecalculation = true;
                string now = DateTime.Now.ToString("yyyyMMddHHmmss");
                FileStream file1 = new FileStream(FileSavePath + @"\upload\" + now + ".xls", FileMode.Create);
                workbook.Write(file1);
                file1.Close();
                DaoRuMsg msg = new DaoRuMsg();
                msg.Msg = now + ".xls";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
            catch (Exception e)
            {
                DaoRuMsg msg = new DaoRuMsg();
                msg.Msg = "err：" + e.ToString();
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }


        }

        public ActionResult Retreat_ChuChai()
        {
            Session["location"] = 64;
            DateTime now = DateTime.Now;
            ViewBag.startdate = now.AddMonths(-2).ToString("yyyy-MM-dd");
            ViewBag.enddate = now.AddMonths(1).ToString("yyyy-MM-dd");
            return View();
        }



        [HttpPost]
        public string Data_Modify_CCTT(int CCID, string beiz)
        {
            token = appClass.CRM_Gettoken();
            CRM_KQ_CCTT model = crmModels.KQ_CC.Read_TTbyCCID(CCID, token);
            model.BEIZ = beiz;
            int int1 = crmModels.KQ_CC.Update_TT(model, token);
            if (int1 <= 0)
            {
                MessageInfo msg = new MessageInfo();
                msg.Key = "0";
                msg.Value = "保存失败！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
            ////先校验这个ccid对应的天数是否等于明细的条数
            //CRM_KQ_CCMX[] mxmodel = crmModels.KQ_CC.Read_MXbyCCID(model.CCID, token);
            //if (model.SJCCTS * 2 > mxmodel.Length)
            //{
            //    MessageInfo msg = new MessageInfo();
            //    msg.Key = "0";
            //    msg.Value = "请确认明细数量与出差天数是否对应！";
            //    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            //}

            ////然后先保存
            //int id = crmModels.KQ_CC.Update_TT(model, token);
            //if (id <= 0)
            //{
            //    MessageInfo msg = new MessageInfo();
            //    msg.Key = "0";
            //    msg.Value = "保存失败，未发起OA流程";
            //    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            //}

            //开始做OA
            CRM_HG_STAFF staffmodel = crmModels.HG_STAFF.ReadBySTAFFID(Convert.ToInt32(Session["STAFFID"]), token);

            CRM_OA_BASIC basic = new CRM_OA_BASIC();
            basic.Subject = "出差撤销单(" + staffmodel.STAFFNAME + " ";
            basic.LoginName = crmModels.HG_STAFF.ReadBySTAFFID(staffmodel.STAFFID, token).STAFFNO;
            basic.TemplateCode = crmModels.SYS_CS.Read(5, token)[0].CS.ToString();

            CRM_OA_CC list = new CRM_OA_CC();
            list.CCSQSJ = model.CCSQSJ;
            list.STAFFNAME = model.CCRNAME;
            list.CCLXDES = crmModels.HG_DICT.ReadByDICID(Convert.ToInt32(model.CCLX), token).DICNAME;
            list.CCDD = model.CCDD;
            list.BQYCCDES = model.BQYCC == true ? "是" : "否";
            list.ZCYWCCDES = model.ZCYWCC == true ? "是" : "否";
            list.JHCCKSSJ = model.JHCCKSSJ;
            list.JHCCJSSJ = model.JHCCJSSJ;
            list.CXFS = crmModels.HG_DICT.ReadByDICID(Convert.ToInt32(model.CXFS), token).DICNAME;
            list.YJJE = model.YJJE.ToString();
            list.QTCXFSDES = crmModels.HG_DICT.ReadByDICID(Convert.ToInt32(model.QTCXFS), token).DICNAME;
            list.QTCXFSJE = model.QTCXFSJE.ToString();
            list.BEIZ = model.BEIZ;
            if (list.QTCXFSJE == "0" || list.QTCXFSJE == "0.00")
                list.QTCXFSJE = "";

            list.TITLE = "出差撤销单";


            CRM_KQ_CCMX[] mxmodel = crmModels.KQ_CC.Read_MXbyCCID(model.CCID, token);
            list.CRM_OA_CC_SUBList = new CRM_OA_CC_SUB[mxmodel.Length];
            for (int i = 0; i < mxmodel.Length; i++)
            {
                list.CRM_OA_CC_SUBList[i] = new CRM_OA_CC_SUB();
                list.CRM_OA_CC_SUBList[i].DATE = mxmodel[i].DATE;
                string sjlx = "";   //上午或下午
                if (mxmodel[i].CCSJLX == 1)
                    sjlx = "上午";
                else if (mxmodel[i].CCSJLX == 2)
                    sjlx = "下午";
                list.CRM_OA_CC_SUBList[i].CCSJLXDES = sjlx;
                list.CRM_OA_CC_SUBList[i].DD = mxmodel[i].DD;
                list.CRM_OA_CC_SUBList[i].GZMB = mxmodel[i].GZMB;
            }


            MessageInfo info = crmModels.CRM_OA.Launch(basic, list, token);         //提交
            if (info.Key != "0" && info.Key != "-1")
            {

                model.ISACTIVE = 2;
                crmModels.KQ_CC.Update_TT(model, token);


                CRM_OA_TRANSMIT TRANSMITmodel = new CRM_OA_TRANSMIT();
                TRANSMITmodel.OAID = info.Key;
                TRANSMITmodel.OACSBH = model.CCID;
                TRANSMITmodel.OACSLB = 1083;
                TRANSMITmodel.OAZT = 1;
                TRANSMITmodel.CJSJ = DateTime.Now.ToString("yyyy-MM-dd");
                crmModels.OA_TRANSMIT.Create(TRANSMITmodel, token);


            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(info);
        }

        [HttpPost]
        public string Data_SelectYCQD_ByDate(string QDRQ, int SXB)
        {
            token = appClass.CRM_Gettoken();
            CRM_KQ_QD[] data = crmModels.KQ_QD.ReadYCQD_ByDATE(QDRQ, SXB, Convert.ToInt32(Session["STAFFID"]), token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;

        }


    }
}
