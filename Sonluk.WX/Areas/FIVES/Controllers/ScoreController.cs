using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sonluk.UI.Model.S5.SY_CHECKPOINTService;
using Sonluk.WX.Models;
using Sonluk.WX.APPCLASS;
using Sonluk.UI.Model.CRM.CRM_LoginService;
using Sonluk.UI.Model.CRM.HG_STAFFService;
using Sonluk.UI.Model.S5.CHECK_INFOService;
using Sonluk.UI.Model.S5.CHECK_INFODETAILService;
using Sonluk.UI.Model.MODEL;
using Sonluk.WX.Areas.CRM.Controllers;
using Sonluk.UI.Model.CRM.WX_OPENIDService;
using Sonluk.UI.Model.S5.SY_STAFF_DEPService;
using Sonluk.UI.Model.S5.SY_DICTService;
using Sonluk.UI.Model.HR.SY_DEPTService;



namespace Sonluk.WX.Areas.FIVES.Controllers
{
    public class ScoreController : Controller
    {
        //
        // GET: /FIVES/Score/
        HRModels hrmodels = new HRModels();
        FIVESModels fivesmodel = new FIVESModels();
        AppClass appclass = new AppClass();
        CRMModels crmmodel = new CRMModels();
        WebMSG webmsg = new WebMSG();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FIVESurl(int POINTID)
        {
            string url = System.Configuration.ConfigurationManager.AppSettings["FIVES_url"];
            Response.Redirect(url + "&POINTID=" + POINTID.ToString());
            return View();
        }

        public ActionResult Create_Score()
        {
            string Account = System.Configuration.ConfigurationManager.AppSettings["apiAccount"];
            string Secret = System.Configuration.ConfigurationManager.AppSettings["apiSecret"];
            CRM_LoginInfo login = crmmodel.CRM_Login.Login(Account, Secret, "", "", 1, 0);
            string token = login.TokenInfo.access_token;
            Session["token"] = token;
            Session["NAME"] = " ";

            //CRM_HG_STAFF staffdata1 = crmmodel.HG_STAFF.ReadBySTAFFID(login.TokenInfo.STAFFID, login.TokenInfo.access_token);

            int StaffID = 0;
            string code = Request.QueryString["code"];
            string statedata = Request.QueryString["state"];

            //code = "sbLSoXZ7PmsiP_2b7GBIPTv10qY1X608eI9QC0U-uOY";
            //statedata = "QY_56";

            string[] statedata1 = statedata.Split('_');
            string state = statedata1[0];
            int POINTID = Convert.ToInt32(statedata1[1]);

            string openid = "";
            string userid = "";

            PublicController otherController = DependencyResolver.Current.GetService<PublicController>();
            //string result = otherController.ToExcel(data, 4, token);

            if (code != null)               //有code
            {
                if (state == "WX")                             //微信公众号登录
                {
                    Session["state"] = "WX";

                    string[] data = otherController.GetWebToken(code);
                    if (data[0] == "ok")                                      //成功获取openid
                    {

                        openid = data[1];
                        Session["openid"] = openid;
                        CRM_WX_OPENID openidModel = new CRM_WX_OPENID();
                        openidModel.OPENID = openid;
                        CRM_WX_OPENID[] openidData = crmmodel.WX_OPENID.ReadByParam(openidModel, token);
                        if (openidData.Length == 0)
                        {
                            ViewBag.MSG = "您没有权限";
                            return View("Error");
                        }
                        StaffID = openidData[0].STAFFID;

                        CRM_HG_STAFF staffdata = crmmodel.HG_STAFF.ReadBySTAFFID(StaffID, token);

                        string appid = System.Configuration.ConfigurationManager.AppSettings["AppID"];


                        CRM_LoginInfo tokeninfo = crmmodel.CRM_Login.Login("", "", openid, appid, 0, 1);
                        if (tokeninfo.TokenInfo.access_token == null)
                        {
                            ViewBag.MSG = "获取token失败";
                            return View("Error");
                        }
                        else
                        {
                            Session["MENUINFO"] = tokeninfo.JURISDICTION_GROUP;
                            Session["STAFFID"] = StaffID;
                            Session["NAME"] = staffdata.STAFFNAME;
                            Session["USERLX"] = staffdata.USERLX;
                        }

                    }
                    else                                                    //获取openid失败
                    {
                        ViewBag.MSG = data[1];
                        return View("Error");
                    }
                }
                else if (state == "QY")                       //企业微信登录
                {
                    Session["state"] = "QY";

                    string[] data = otherController.GetQYwebToken(code);
                    if (data[0] == "ok")                                    //成功获取userid或openid
                    {
                        userid = data[1];
                        Session["openid"] = userid;
                        CRM_WX_OPENID openidModel = new CRM_WX_OPENID();
                        openidModel.OPENID = userid;
                        CRM_WX_OPENID[] openidData = crmmodel.WX_OPENID.ReadByParam(openidModel, token);
                        if (openidData.Length == 0)
                        {
                            ViewBag.MSG = "您没有权限";
                            return View("Error");
                        }
                        StaffID = openidData[0].STAFFID;

                        CRM_HG_STAFF staffdata = crmmodel.HG_STAFF.ReadBySTAFFID(StaffID, token);


                        string corpid = System.Configuration.ConfigurationManager.AppSettings["CorpID"];

                        CRM_LoginInfo tokeninfo = crmmodel.CRM_Login.Login("", "", userid, corpid, 0, 1);
                        if (tokeninfo.TokenInfo.access_token == null)
                        {
                            ViewBag.MSG = "获取token失败";
                            return View("Error");
                        }
                        else
                        {
                            Session["MENUINFO"] = tokeninfo.JURISDICTION_GROUP;
                            Session["STAFFID"] = StaffID;
                            Session["NAME"] = staffdata.STAFFNAME;
                            Session["USERLX"] = staffdata.USERLX;
                        }



                    }
                    else                                                     //获取userid或openid失败
                    {
                        ViewBag.MSG = data[1];
                        return View("Error");
                    }
                }
                else                                         //不太可能发生的情况
                {
                    ViewBag.MSG = "登录失败";
                    return View("Error");
                }
            }
            else                        //没有code
            {


                ViewBag.MSG = "请退出并重新登录";
                return View("Error");

            }







            //StaffID = 79;
            FIVES_SY_CHECKPOINT_CREATE data5s = fivesmodel.SY_CHECKPOINT.Select_CHECKPOINT_byParms(POINTID, StaffID, token);
            if (data5s.MES_RETURN.TYPE == "S")
            {

                ViewBag.data = data5s;
                return View();


            }
            else      //没有权限
            {
                ViewBag.MSG = data5s.MES_RETURN.MESSAGE;
                return View("Error");
            }


        }

        public ActionResult Create_Score_DJ()
        {
            string Account = System.Configuration.ConfigurationManager.AppSettings["apiAccount"];
            string Secret = System.Configuration.ConfigurationManager.AppSettings["apiSecret"];
            CRM_LoginInfo login = crmmodel.CRM_Login.Login(Account, Secret, "", "", 1, 0);
            string token = login.TokenInfo.access_token;
            Session["token"] = token;
            Session["NAME"] = " ";

            //CRM_HG_STAFF staffdata1 = crmmodel.HG_STAFF.ReadBySTAFFID(login.TokenInfo.STAFFID, login.TokenInfo.access_token);

            int StaffID = 0;
            string code = Request.QueryString["code"];
            string statedata = Request.QueryString["state"];

            //code = "sbLSoXZ7PmsiP_2b7GBIPTv10qY1X608eI9QC0U-uOY";
            //statedata = "QY_56";

            string[] statedata1 = statedata.Split('_');
            string state = statedata1[0];
            int POINTID = Convert.ToInt32(statedata1[1]);

            string openid = "";
            string userid = "";

            PublicController otherController = DependencyResolver.Current.GetService<PublicController>();
            //string result = otherController.ToExcel(data, 4, token);

            if (code != null)               //有code
            {
                if (state == "WX")                             //微信公众号登录
                {
                    Session["state"] = "WX";

                    //if (Session["openid"] == null)
                    //{
                    string[] data = otherController.GetWebToken(code);
                    if (data[0] == "ok")                                      //成功获取openid
                    {

                        openid = data[1];
                        Session["openid"] = openid;
                        CRM_WX_OPENID openidModel = new CRM_WX_OPENID();
                        openidModel.OPENID = openid;
                        CRM_WX_OPENID[] openidData = crmmodel.WX_OPENID.ReadByParam(openidModel, token);
                        if (openidData.Length == 0)
                        {
                            ViewBag.MSG = "您没有权限";
                            return View("Error");
                        }
                        StaffID = openidData[0].STAFFID;

                        CRM_HG_STAFF staffdata = crmmodel.HG_STAFF.ReadBySTAFFID(StaffID, token);

                        string appid = System.Configuration.ConfigurationManager.AppSettings["AppID"];


                        CRM_LoginInfo tokeninfo = crmmodel.CRM_Login.Login("", "", openid, appid, 0, 1);
                        if (tokeninfo.TokenInfo.access_token == null)
                        {
                            ViewBag.MSG = "获取token失败";
                            return View("Error");
                        }
                        else
                        {
                            Session["MENUINFO"] = tokeninfo.JURISDICTION_GROUP;
                            Session["STAFFID"] = StaffID;
                            Session["NAME"] = staffdata.STAFFNAME;
                            Session["USERLX"] = staffdata.USERLX;
                        }

                    }
                    else                                                    //获取openid失败
                    {
                        ViewBag.MSG = data[1];
                        return View("Error");
                    }
                    //}

                }
                else if (state == "QY")                       //企业微信登录
                {
                    Session["state"] = "QY";

                    string[] data = otherController.GetQYwebToken(code);
                    if (data[0] == "ok")                                    //成功获取userid或openid
                    {
                        userid = data[1];
                        Session["openid"] = userid;
                        CRM_WX_OPENID openidModel = new CRM_WX_OPENID();
                        openidModel.OPENID = userid;
                        CRM_WX_OPENID[] openidData = crmmodel.WX_OPENID.ReadByParam(openidModel, token);
                        if (openidData.Length == 0)
                        {
                            ViewBag.MSG = "您没有权限";
                            return View("Error");
                        }
                        StaffID = openidData[0].STAFFID;

                        CRM_HG_STAFF staffdata = crmmodel.HG_STAFF.ReadBySTAFFID(StaffID, token);


                        string corpid = System.Configuration.ConfigurationManager.AppSettings["CorpID"];

                        CRM_LoginInfo tokeninfo = crmmodel.CRM_Login.Login("", "", userid, corpid, 0, 1);
                        if (tokeninfo.TokenInfo.access_token == null)
                        {
                            ViewBag.MSG = "获取token失败";
                            return View("Error");
                        }
                        else
                        {
                            Session["MENUINFO"] = tokeninfo.JURISDICTION_GROUP;
                            Session["STAFFID"] = StaffID;
                            Session["NAME"] = staffdata.STAFFNAME;
                            Session["USERLX"] = staffdata.USERLX;
                        }



                    }
                    else                                                     //获取userid或openid失败
                    {
                        ViewBag.MSG = data[1];
                        return View("Error");
                    }
                }
                else                                         //不太可能发生的情况
                {
                    ViewBag.MSG = "登录失败";
                    return View("Error");
                }
            }
            else                        //没有code
            {


                ViewBag.MSG = "请退出并重新登录";
                return View("Error");

            }







            //StaffID = 79;
            FIVES_SY_CHECKPOINT_CREATE data5s = fivesmodel.SY_CHECKPOINT.Select_CHECKPOINT_byParms(POINTID, StaffID, token);
            if (data5s.MES_RETURN.TYPE == "S")
            {

                //if (data5s.FIVES_SY_STAFF_DEPList.DJSTATUS == 0)
                //{
                //    ViewBag.MSG = "您没有权限";
                //    return View("Error");
                //}
                if (data5s.FIVES_SY_CHECKPOINT.DJ == 0)
                {
                    ViewBag.MSG = "您没有权限";
                    return View("Error");
                }


                Sonluk.UI.Model.S5.SY_DICTService.FIVES_SY_DICT MODEL = new Sonluk.UI.Model.S5.SY_DICTService.FIVES_SY_DICT();
                Sonluk.UI.Model.S5.SY_TYPEService.FIVES_SY_TYPE TypeMODEL = new Sonluk.UI.Model.S5.SY_TYPEService.FIVES_SY_TYPE();

                switch (data5s.FIVES_STAFF_DEP.DEPTID)
                {
                    case 11:
                        MODEL.TYPEID = 9;
                        break;
                    case 13:
                        TypeMODEL.TYPENAME = "食堂点检人员";
                        Sonluk.UI.Model.S5.SY_TYPEService.FIVES_SY_TYPE[] TypeData = fivesmodel.SY_TYPE.Read(TypeMODEL, token);
                        MODEL.TYPEID = TypeData[0].TYPEID;
                        break;
                    case 33:
                        TypeMODEL.TYPENAME = "机房点检人员";
                        Sonluk.UI.Model.S5.SY_TYPEService.FIVES_SY_TYPE[] TypeData1 = fivesmodel.SY_TYPE.Read(TypeMODEL, token);
                        MODEL.TYPEID = TypeData1[0].TYPEID;
                        break;
                    default:

                        MODEL.TYPEID = 9;

                        break;
                }




                Sonluk.UI.Model.S5.SY_DICTService.FIVES_SY_DICT[] SHOWNAME = fivesmodel.SY_DICT.Read(MODEL, token);

                ViewBag.SHOWNAME = SHOWNAME;

                ViewBag.data = data5s;

                ViewBag.AppID = System.Configuration.ConfigurationManager.AppSettings["AppID"];


                ViewBag.NAME = Session["NAME"];

                return View();

            }
            else      //没有权限
            {
                ViewBag.MSG = data5s.MES_RETURN.MESSAGE;
                return View("Error");
            }



        }

        public ActionResult Select_Score()
        {
            string token = appclass.CRM_Gettoken();
            DateTime now = DateTime.Now;
            ViewBag.startdate = now.AddDays(-7).ToString("yyyy-MM-dd");
            ViewBag.enddate = now.ToString("yyyy-MM-dd");

            Sonluk.UI.Model.S5.STAFF_DEPService.FIVES_STAFF_DEP cxmodel = new Sonluk.UI.Model.S5.STAFF_DEPService.FIVES_STAFF_DEP();
            cxmodel.STAFFID = appclass.CRM_GetStaffid();
            Sonluk.UI.Model.S5.STAFF_DEPService.FIVES_STAFF_DEP[] STAFF_DEP = fivesmodel.STAFF_DEP.Read(cxmodel, token);

            var query = (from c in STAFF_DEP where c.TYPENAME != "通知" select new { c.TYPEID, c.TYPENAME }).ToList();
            List<Sonluk.UI.Model.S5.SY_DICTService.FIVES_SY_DICT> RMODELIST = new List<Sonluk.UI.Model.S5.SY_DICTService.FIVES_SY_DICT>();
            foreach (var item in query)
            {
                Sonluk.UI.Model.S5.SY_DICTService.FIVES_SY_DICT NEWMODEL = new UI.Model.S5.SY_DICTService.FIVES_SY_DICT();
                NEWMODEL.DICID = item.TYPEID;
                NEWMODEL.DICNAME = item.TYPENAME;
                RMODELIST.Add(NEWMODEL);
            }
            Sonluk.UI.Model.S5.SY_DICTService.FIVES_SY_DICT[] RMODEL = RMODELIST.ToArray();

            ViewBag.RMODEL = RMODEL;

            return View();
        }

        public ActionResult Select_Score_DJ()
        {
            string token = appclass.CRM_Gettoken();
            DateTime now = DateTime.Now;
            ViewBag.startdate = now.AddDays(-7).ToString("yyyy-MM-dd");
            ViewBag.enddate = now.ToString("yyyy-MM-dd");


            Sonluk.UI.Model.S5.STAFF_DEPService.FIVES_STAFF_DEP cxmodel = new Sonluk.UI.Model.S5.STAFF_DEPService.FIVES_STAFF_DEP();
            cxmodel.STAFFID = appclass.CRM_GetStaffid();
            Sonluk.UI.Model.S5.STAFF_DEPService.FIVES_STAFF_DEP[] STAFF_DEP = fivesmodel.STAFF_DEP.Read(cxmodel, token);
            ViewBag.STAFF_DEP = STAFF_DEP;

            return View();
        }

        public ActionResult Select_Score_Part(string cxdata)
        {
            string token = appclass.CRM_Gettoken();

            Sonluk.UI.Model.S5.STAFF_DEPService.FIVES_STAFF_DEP cxmodel = new Sonluk.UI.Model.S5.STAFF_DEPService.FIVES_STAFF_DEP();
            cxmodel.STAFFID = appclass.CRM_GetStaffid();
            Sonluk.UI.Model.S5.STAFF_DEPService.FIVES_STAFF_DEP[] STAFF_DEP = fivesmodel.STAFF_DEP.Read(cxmodel, token);
            ViewBag.STAFF_DEP = STAFF_DEP;
            int NUM = 0;
            for (int i = 0; i < STAFF_DEP.Length; i++)
            {
                if (STAFF_DEP[i].TYPENAME == "消防点检" && STAFF_DEP[i].DEPTNAME == "总经办")
                {
                    NUM = 1;
                }
            }
            FIVES_CHECK_INFOList model = Newtonsoft.Json.JsonConvert.DeserializeObject<FIVES_CHECK_INFOList>(cxdata);
            if (NUM == 0)
            {
                model.STAFFID = appclass.CRM_GetStaffid();
            }
            else
            {
                model.STAFFID = 0;
                model.HG = 2;
            }

            FIVES_CHECK_INFOList[] data = fivesmodel.CHECK_INFO.Read(model, token);
            ViewBag.TTdata = data;
            return View();
        }

        public ActionResult Select_Score_MXPart(int INFOID)
        {
            string token = appclass.CRM_Gettoken();
            FIVES_CHECK_INFODETAIL model = new FIVES_CHECK_INFODETAIL();
            model.INFOID = INFOID;
            Sonluk.UI.Model.S5.CHECK_INFODETAILService.FIVES_CHECK_INFODETAILList[] data = fivesmodel.CHECK_INFODETAIL.Read(model, token);
            ViewBag.MXdata = data;
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }

        public ActionResult Success()
        {
            return View();
        }

        public ActionResult Update_Score(int INFOID)
        {
            string token = appclass.CRM_Gettoken();

            FIVES_CHECK_INFOList model = new FIVES_CHECK_INFOList();
            model.INFOID = INFOID;
            FIVES_CHECK_INFOList[] TTdata = fivesmodel.CHECK_INFO.Read(model, token);
            ViewBag.TTdata = TTdata[0];

            FIVES_CHECK_INFODETAIL model2 = new FIVES_CHECK_INFODETAIL();
            model2.INFOID = INFOID;
            Sonluk.UI.Model.S5.CHECK_INFODETAILService.FIVES_CHECK_INFODETAILList[] MXdata = fivesmodel.CHECK_INFODETAIL.Read(model2, token);
            ViewBag.MXdata = MXdata;

            FIVES_SY_CHECKPOINT_CREATE data = fivesmodel.SY_CHECKPOINT.Select_CHECKPOINT_byParms(TTdata[0].OPINTID, TTdata[0].STAFFID, token);
            ViewBag.data = data;
            return View();
        }
        public ActionResult Auto_CreateScore()
        {
            string token = appclass.CRM_Gettoken();
            Sonluk.UI.Model.S5.SY_DICTService.FIVES_SY_DICT MODEL = new Sonluk.UI.Model.S5.SY_DICTService.FIVES_SY_DICT();
            MODEL.TYPEID = 9;
            Sonluk.UI.Model.S5.SY_DICTService.FIVES_SY_DICT[] SHOWNAME = fivesmodel.SY_DICT.Read(MODEL, token);
            HR_SY_DEPT_SELECT r = hrmodels.SY_DEPT.SELECT(new HR_SY_DEPT(), token);
            ViewBag.DEPList = r;



            ViewBag.SHOWNAME = SHOWNAME;
            return View();
        }

        [HttpPost]
        public string Data_SelectMXbyPOINTID(int POINTID)
        {
            string token = appclass.CRM_Gettoken();
            FIVES_SY_CHECKPOINT_CREATE data = fivesmodel.SY_CHECKPOINT.Select_CHECKPOINT_byParms(POINTID, appclass.CRM_GetStaffid(), token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }
        public bool isNumberic(string message, out int result)
        {
            System.Text.RegularExpressions.Regex rex =
            new System.Text.RegularExpressions.Regex(@"^\d+$");
            result = -1;
            if (rex.IsMatch(message))
            {
                result = int.Parse(message);
                return true;
            }
            else
                return false;
        }
        public string GetWeekFirstDayMon(DateTime datetime)
        {
            //星期一为第一天  
            int weeknow = Convert.ToInt32(datetime.DayOfWeek);
            //因为是以星期一为第一天，所以要判断weeknow等于0时，要向前推6天。  
            weeknow = (weeknow == 0 ? (7 - 1) : (weeknow - 1));
            int daydiff = (-1) * weeknow;
            //本周第一天  
            string FirstDay = datetime.AddDays(daydiff).ToString("yyyy-MM-dd");
            return FirstDay;
        }
        public string GetWeekLastDaySun(DateTime datetime)
        {
            //星期天为最后一天  
            int weeknow = Convert.ToInt32(datetime.DayOfWeek);
            weeknow = (weeknow == 0 ? 7 : weeknow);
            int daydiff = (7 - weeknow);
            //本周最后一天  
            string LastDay = datetime.AddDays(daydiff).ToString("yyyy-MM-dd");
            return LastDay;
        }

        [HttpPost]
        public string Data_Create_CHECK_INFO(string TTdata, string MXdata, int POINTID)
        {
            string token = appclass.CRM_Gettoken();

            FIVES_SY_CHECKPOINT CHEmodel = new FIVES_SY_CHECKPOINT();
            CHEmodel.POINTID = POINTID;
            FIVES_SY_CHECKPOINT[] CHEdata = fivesmodel.SY_CHECKPOINT.Read(CHEmodel, token);
            if (CHEdata.Length > 0 && CHEdata[0].DJ != 0)
            {
                Sonluk.UI.Model.S5.SY_DICTService.FIVES_SY_DICT DICmodel = new UI.Model.S5.SY_DICTService.FIVES_SY_DICT();
                DICmodel.DICID = CHEdata[0].FREQUENCY;
                Sonluk.UI.Model.S5.SY_DICTService.FIVES_SY_DICT[] DICdata = fivesmodel.SY_DICT.Read(DICmodel, token);
                int Count;
                switch (DICdata[0].DICMEMO.Split('.')[0])
                {
                    case "DAY":
                        if (true == isNumberic(DICdata[0].DICMEMO.Split('.')[1], out Count))//判定是字符串还是数字
                        {
                            //Count代表每日可以新增的次数。
                            FIVES_CHECK_INFOList Temp_TTmodel = new FIVES_CHECK_INFOList();
                            Temp_TTmodel.OPINTID = POINTID;
                            Temp_TTmodel.KSTIME = DateTime.Now.ToString("yyyy-MM-dd");
                            Temp_TTmodel.JSTIME = DateTime.Now.ToString("yyyy-MM-dd");
                            Temp_TTmodel.HG = 2;
                            FIVES_CHECK_INFOList[] Temp_TTdata = fivesmodel.CHECK_INFO.Read(Temp_TTmodel, token);
                            if (Temp_TTdata.Length > (Count - 1))
                            {
                                webmsg.KEY = 0;
                                webmsg.MSG = "当前检验点每天检验次数不能超过" + Count + "次";
                                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                            }
                            else
                            {
                                INSERT_CHECK_INFO(TTdata, MXdata, POINTID);
                            }
                        }
                        //如果是字符串，每日不限制次数
                        else
                        {
                            INSERT_CHECK_INFO(TTdata, MXdata, POINTID);
                        }
                        break;
                    case "WEEK":
                        if (true == isNumberic(DICdata[0].DICMEMO.Split('.')[1], out Count))//判定是字符串还是数字
                        {
                            //Count代表每日可以新增的次数。
                            FIVES_CHECK_INFOList Temp_TTmodel = new FIVES_CHECK_INFOList();
                            Temp_TTmodel.OPINTID = POINTID;
                            Temp_TTmodel.KSTIME = GetWeekFirstDayMon(DateTime.Now);
                            Temp_TTmodel.JSTIME = GetWeekLastDaySun(DateTime.Now);
                            Temp_TTmodel.HG = 2;
                            FIVES_CHECK_INFOList[] Temp_TTdata = fivesmodel.CHECK_INFO.Read(Temp_TTmodel, token);
                            if (Temp_TTdata.Length > (Count - 1))
                            {
                                webmsg.KEY = 0;
                                webmsg.MSG = "当前检验点每周检验次数不能超过" + Count + "次";
                                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                            }
                            else
                            {
                                INSERT_CHECK_INFO(TTdata, MXdata, POINTID);
                            }
                        }
                        //如果是字符串，每周不限制次数
                        else
                        {
                            INSERT_CHECK_INFO(TTdata, MXdata, POINTID);
                        }
                        break;
                    case "MONTH":
                        if (true == isNumberic(DICdata[0].DICMEMO.Split('.')[1], out Count))//判定是字符串还是数字
                        {
                            //Count代表每月可以新增的次数。
                            FIVES_CHECK_INFOList Temp_TTmodel = new FIVES_CHECK_INFOList();
                            Temp_TTmodel.OPINTID = POINTID;
                            //获取当前月份第一天
                            Temp_TTmodel.KSTIME = DateTime.Now.AddDays(1 - DateTime.Now.Day).Date.ToString("yyyy-MM-dd");
                            //获取当前月份最后一天
                            Temp_TTmodel.JSTIME = DateTime.Now.AddDays(1 - DateTime.Now.Day).Date.AddMonths(1).AddSeconds(-1).ToString("yyyy-MM-dd");
                            Temp_TTmodel.HG = 2;
                            FIVES_CHECK_INFOList[] Temp_TTdata = fivesmodel.CHECK_INFO.Read(Temp_TTmodel, token);
                            //获取当前检验点当前月的记录
                            var query = (from c in Temp_TTdata where c.JLTIME.Substring(0, 7) == DateTime.Now.ToString("yyyy-MM") select c).ToList();

                            if (query.Count > (Count - 1))
                            {
                                webmsg.KEY = 0;
                                webmsg.MSG = "当前检验点每月检验次数不能超过" + Count + "次";
                                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                            }
                            else
                            {
                                INSERT_CHECK_INFO(TTdata, MXdata, POINTID);
                            }
                        }
                        //如果是字符串，每日不限制次数
                        else
                        {
                            INSERT_CHECK_INFO(TTdata, MXdata, POINTID);
                        }
                        break;
                    case "YEAR":
                        if (true == isNumberic(DICdata[0].DICMEMO.Split('.')[1], out Count))//判定是字符串还是数字
                        {
                            //Count代表每年可以新增的次数。
                            FIVES_CHECK_INFOList Temp_TTmodel = new FIVES_CHECK_INFOList();
                            Temp_TTmodel.OPINTID = POINTID;
                            //获取当前年份第一天
                            Temp_TTmodel.KSTIME = DateTime.Now.AddMonths(1 - DateTime.Now.Month).AddDays(1 - DateTime.Now.Day).Date.ToString("yyyy-MM-dd");
                            //获取当前月份最后一天
                            Temp_TTmodel.JSTIME = DateTime.Now.AddMonths(1 - DateTime.Now.Month).AddDays(1 - DateTime.Now.Day).Date.AddYears(1).AddSeconds(-1).ToString("yyyy-MM-dd");
                            Temp_TTmodel.HG = 2;
                            FIVES_CHECK_INFOList[] Temp_TTdata = fivesmodel.CHECK_INFO.Read(Temp_TTmodel, token);
                            //获取当前检验点当前年的记录
                            var query = (from c in Temp_TTdata where c.JLTIME.Substring(0, 4) == DateTime.Now.ToString("yyyy") select c).ToList();

                            if (query.Count > (Count - 1))
                            {
                                webmsg.KEY = 0;
                                webmsg.MSG = "当前检验点每年检验次数不能超过" + Count + "次";
                                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                            }
                            else
                            {
                                INSERT_CHECK_INFO(TTdata, MXdata, POINTID);
                            }
                        }
                        //如果是字符串，每日不限制次数
                        else
                        {
                            INSERT_CHECK_INFO(TTdata, MXdata, POINTID);
                        }
                        break;
                    default:
                        FIVES_CHECK_INFOList Temp_TTmodel1 = new FIVES_CHECK_INFOList();
                        Temp_TTmodel1.OPINTID = POINTID;
                        Temp_TTmodel1.JLTIME = DateTime.Now.ToString("yyyy-MM-dd");
                        FIVES_CHECK_INFOList[] Temp_TTdata1 = fivesmodel.CHECK_INFO.Read(Temp_TTmodel1, token);
                        if (Temp_TTdata1.Length > 1)
                        {
                            webmsg.KEY = 0;
                            webmsg.MSG = "当前检验点每天检验次数不能超过1次";
                            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                        }
                        break;
                }
                webmsg.KEY = 1;
                webmsg.MSG = "新建成功！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }
            else
            {
                INSERT_CHECK_INFO(TTdata, MXdata, POINTID);
                webmsg.KEY = 1;
                webmsg.MSG = "新建成功！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }
        }

        public string INSERT_CHECK_INFO(string TTdata, string MXdata, int POINTID)
        {
            string token = appclass.CRM_Gettoken();

            FIVES_CHECK_INFO TTmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<FIVES_CHECK_INFO>(TTdata);
            FIVES_SY_RELATIONSHIPBINDList[] MXmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<FIVES_SY_RELATIONSHIPBINDList[]>(MXdata);

            FIVES_CHECK_INFODETAIL[] MXmodel2 = new FIVES_CHECK_INFODETAIL[MXmodel.Length];

            FIVES_SY_CHECKPOINT_CREATE PointData = fivesmodel.SY_CHECKPOINT.Select_CHECKPOINT_byParms(POINTID, appclass.CRM_GetStaffid(), token);
            string remark = "";

            TTmodel.STAFFID = appclass.CRM_GetStaffid();
            TTmodel.STAFFNAME = appclass.CRM_GetStaffName();
            TTmodel.ACTION = 1;
            TTmodel.SHOWTIME = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");//点检时间
            if (PointData.FIVES_SY_CHECKPOINT.ISNEED == 2)
            {
                TTmodel.SHOWNAME = appclass.CRM_GetStaffid();
                TTmodel.SHOWNAMEMS = appclass.CRM_GetStaffName();
            }

            MES_RETURN_UI TTres = fivesmodel.CHECK_INFO.Create(TTmodel, token);
            if (TTres.TYPE != "S")
            {
                webmsg.KEY = 0;
                webmsg.MSG = TTres.MESSAGE;
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }

            for (int i = 0; i < MXmodel2.Length; i++)
            {
                MXmodel2[i] = new FIVES_CHECK_INFODETAIL();
                MXmodel2[i].INFOID = Convert.ToInt32(TTres.MESSAGE);
                MXmodel2[i].TYPEID = MXmodel[i].OBJ2;
                MXmodel2[i].TYPEMS = MXmodel[i].OBJ2NAME;
                MXmodel2[i].REMARK = MXmodel[i].REMARK;
                MXmodel2[i].ACTION = 1;
                remark = remark + MXmodel[i].OBJ2NAME + "(" + MXmodel[i].REMARK + ")\n";
            }
            MES_RETURN_UI MXres = fivesmodel.CHECK_INFODETAIL.Create(MXmodel2, token);
            if (MXres.TYPE != "S")
            {
                webmsg.KEY = 0;
                webmsg.MSG = MXres.MESSAGE;
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }

            webmsg.KEY = 1;
            webmsg.MSG = "新建成功！";

            if (TTmodel.HG == 1)
            {
                //不合格

                Sonluk.UI.Model.S5.SY_DICTService.FIVES_SY_DICT DICTmodel = new Sonluk.UI.Model.S5.SY_DICTService.FIVES_SY_DICT();
                DICTmodel.DICNAME = "通知";
                Sonluk.UI.Model.S5.SY_DICTService.FIVES_SY_DICT[] JCRES = fivesmodel.SY_DICT.Read(DICTmodel, token);

                FIVES_SY_CHECKPOINT POINTmodel = new FIVES_SY_CHECKPOINT();
                POINTmodel.POINTID = POINTID;
                FIVES_SY_CHECKPOINT[] POINTdata = fivesmodel.SY_CHECKPOINT.Read(POINTmodel, token);


                Sonluk.UI.Model.S5.STAFF_DEPService.FIVES_STAFF_DEP cxmodel = new Sonluk.UI.Model.S5.STAFF_DEPService.FIVES_STAFF_DEP();
                cxmodel.DEPTID = POINTdata[0].DID;
                cxmodel.TYPEID = JCRES[0].DICID;
                Sonluk.UI.Model.S5.STAFF_DEPService.FIVES_STAFF_DEP[] staff = fivesmodel.STAFF_DEP.Read(cxmodel, token);

                CRM_HG_STAFF STAFFdata = crmmodel.HG_STAFF.ReadBySTAFFID(appclass.CRM_GetStaffid(), token);
                try
                {

                    for (int i = 0; i < staff.Length; i++)
                    {

                        WX_MSG WXMSG = new WX_MSG();
                        WXMSG.data = new Data();
                        WXMSG.miniprogram = new MiniProgram();
                        WXMSG.text = new TEXT();

                        WXMSG.data.first = new KeyWord();
                        WXMSG.data.first.value = PointData.FIVES_SY_CHECKPOINT.POINTMS;

                        WXMSG.data.keyword1 = new KeyWord();
                        WXMSG.data.keyword1.value = "点检不合格";

                        WXMSG.data.keyword3 = new KeyWord();
                        WXMSG.data.keyword3.value = PointData.FIVES_SY_CHECKPOINT.POINTMS;

                        WXMSG.data.keyword4 = new KeyWord();
                        WXMSG.data.keyword4.value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                        WXMSG.data.keyword5 = new KeyWord();
                        WXMSG.data.keyword5.value = "操作人：" + STAFFdata.STAFFNAME;

                        WXMSG.data.remark = new KeyWord();
                        WXMSG.data.remark.value = remark;
                        WX_MSG_RETURN MSG_RETURN = crmmodel.WX_OPENID.SendMSG(staff[i].STAFFID, WXMSG, "AppID", "设备异常提醒");
                    }
                }
                catch (Exception E)
                {
                    webmsg.KEY = 0;
                    webmsg.MSG = E.Message;
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        [HttpPost]
        public string Data_SelectCheckMXbyINFOID(int INFOID)
        {
            string token = appclass.CRM_Gettoken();
            FIVES_CHECK_INFODETAIL model = new FIVES_CHECK_INFODETAIL();
            model.INFOID = INFOID;
            Sonluk.UI.Model.S5.CHECK_INFODETAILService.FIVES_CHECK_INFODETAILList[] data = fivesmodel.CHECK_INFODETAIL.Read(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Delete_CHECK_INFO(int INFOID)
        {
            string token = appclass.CRM_Gettoken();
            MES_RETURN_UI res = fivesmodel.CHECK_INFO.Delete(INFOID, token);
            if (res.TYPE != "S")
            {
                webmsg.KEY = 0;
                webmsg.MSG = res.MESSAGE;
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }

            webmsg.KEY = 1;
            webmsg.MSG = "删除成功！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }

        public ActionResult GetCode(string place, int POINTID)
        {
            string Account = System.Configuration.ConfigurationManager.AppSettings["apiAccount"];
            string Secret = System.Configuration.ConfigurationManager.AppSettings["apiSecret"];
            CRM_LoginInfo login = crmmodel.CRM_Login.Login(Account, Secret, "", "", 1, 0);
            string token = login.TokenInfo.access_token;
            Session["token"] = token;
            CRM_HG_STAFF staffdata = crmmodel.HG_STAFF.ReadBySTAFFID(login.TokenInfo.STAFFID, token);
            Session["NAME"] = staffdata.STAFFNAME;


            string url = "";
            FIVES_SY_CHECKPOINT CP = new FIVES_SY_CHECKPOINT();
            CP.POINTID = POINTID;
            FIVES_SY_CHECKPOINT[] CPdata = fivesmodel.SY_CHECKPOINT.Read(CP, token);
            if (CPdata.Length != 1)
            {
                ViewBag.MSG = "检验点无效_" + CPdata.Length.ToString();
                return View("Error");
            }
            else
            {
                if (CPdata[0].DJ != 0)
                {
                    //点检
                    url = System.Configuration.ConfigurationManager.AppSettings["Code5s_url_DJ"];
                }
                else
                {
                    //抽检、巡检
                    url = System.Configuration.ConfigurationManager.AppSettings["Code5s_url"];
                }
            }



            if (place == "WX")
            {
                string appid = System.Configuration.ConfigurationManager.AppSettings["AppID"];
                string redirect_uri = HttpUtility.UrlEncode(url);

                //string scope = "snsapi_base";           //不弹出授权页面，直接跳转，只能获取用户openid
                string scope = "snsapi_userinfo";      //弹出授权页面，可通过openid拿到昵称、性别、所在地

                string code = "https://open.weixin.qq.com/connect/oauth2/authorize?appid="
                    + appid + "&redirect_uri=" + redirect_uri + "&response_type=code&scope=" + scope + "&state=WX_" + POINTID.ToString() + "#wechat_redirect";

                Response.Redirect(code);
                return View();
            }
            else if (place == "QY")
            {
                string AgentId = System.Configuration.ConfigurationManager.AppSettings["AgentId"];
                string CorpID = System.Configuration.ConfigurationManager.AppSettings["CorpID"];
                string redirect_uri = HttpUtility.UrlEncode(url);
                //string scope = "snsapi_base";
                string scope = "snsapi_privateinfo";


                string code = "https://open.weixin.qq.com/connect/oauth2/authorize?appid="
                    + CorpID + "&redirect_uri=" + redirect_uri + "&response_type=code&scope=" + scope + "&agentid=" + AgentId + "&state=QY_" + POINTID.ToString() + "#wechat_redirect";

                Response.Redirect(code);

                return View();
            }
            else
            {
                //非微信登录
                ViewBag.MSG = "系统错误";
                return View("Error");
            }

        }

        [HttpPost]
        public string getOPINTMS(string data)
        {
            string token = appclass.CRM_Gettoken();
            Sonluk.UI.Model.S5.SY_CHECKPOINTService.FIVES_SY_CHECKPOINT model = Newtonsoft.Json.JsonConvert.DeserializeObject<FIVES_SY_CHECKPOINT>(data);
            Sonluk.UI.Model.S5.SY_CHECKPOINTService.FIVES_SY_CHECKPOINTList[] res = fivesmodel.SY_CHECKPOINT.ReadaddDepName(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(res);
        }
        [HttpPost]
        public string getDEPT(int TYPEID)
        {
            string token = appclass.CRM_Gettoken();
            Sonluk.UI.Model.S5.STAFF_DEPService.FIVES_STAFF_DEP CXMODEL = new Sonluk.UI.Model.S5.STAFF_DEPService.FIVES_STAFF_DEP();
            CXMODEL.TYPEID = TYPEID;
            CXMODEL.STAFFID = appclass.CRM_GetStaffid();
            Sonluk.UI.Model.S5.STAFF_DEPService.FIVES_STAFF_DEP[] res = fivesmodel.STAFF_DEP.Read(CXMODEL, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(res);
        }
        [HttpPost]
        public string Auto_Create_CHECK_INFO(int DID, int POINTID, int SHOWNAME, int Num1, int Num2, string date)
        {
            string dstr = Convert.ToDateTime(date).AddHours(DateTime.Now.Hour).AddSeconds(DateTime.Now.Second).AddMinutes(DateTime.Now.Minute).AddMilliseconds(DateTime.Now.Millisecond).ToString("yyyy-MM-dd h:mm:ss.ff");
            string token = appclass.CRM_Gettoken();

            FIVES_SY_CHECKPOINT MODEL = new FIVES_SY_CHECKPOINT();

            if (POINTID == 0)
            {
                MODEL.DID = DID;//全部新增
            }
            else
            {
                MODEL.POINTID = POINTID;//单点新增
            }
            FIVES_SY_CHECKPOINT[] data = fivesmodel.SY_CHECKPOINT.Read(MODEL, token);

            //全部新增
            if (POINTID == 0)
            {
                int Temp_Minutes = 0, Temp_Seconds = 0;

                FIVES_CHECK_INFOList TEMP_model = new FIVES_CHECK_INFOList();
                TEMP_model.DEPARTID = DID;
                TEMP_model.KSTIME = date;
                TEMP_model.JSTIME = date;
                TEMP_model.HG = 2;
                FIVES_CHECK_INFOList[] CXdata = fivesmodel.CHECK_INFO.Read(TEMP_model, token);

                int[] TempCxList = new int[CXdata.Length];
                for (int i = 0; i < CXdata.Length; i++)
                {
                    TempCxList[0] = CXdata[0].OPINTID;
                }
                //linq 中Contains前面只能接受数组，后面是条件
                var TempList = (from c in data where !TempCxList.Contains(c.POINTID) select c).ToList();//去除掉今天已经新增过的检查点


                for (int i = 0; i < TempList.Count; i++)
                {
                    FIVES_CHECK_INFOList model = new FIVES_CHECK_INFOList();
                    model.OPINTID = data[i].POINTID;
                    model.KSTIME = DateTime.Now.ToString("yyyy-MM-dd");
                    model.JSTIME = DateTime.Now.ToString("yyyy-MM-dd");
                    FIVES_CHECK_INFOList[] res = fivesmodel.CHECK_INFO.Read(model, token);

                    FIVES_SY_CHECKPOINT_CREATE PointData = fivesmodel.SY_CHECKPOINT.Select_CHECKPOINT_byParms(data[i].POINTID, appclass.CRM_GetStaffid(), token);

                    FIVES_CHECK_INFO TTmodel = new FIVES_CHECK_INFO();
                    TTmodel.SHOWNAME = SHOWNAME;
                    Sonluk.UI.Model.S5.SY_DICTService.FIVES_SY_DICT DICTMODEL = new Sonluk.UI.Model.S5.SY_DICTService.FIVES_SY_DICT();
                    DICTMODEL.DICID = SHOWNAME;
                    Sonluk.UI.Model.S5.SY_DICTService.FIVES_SY_DICT[] DICTdata = fivesmodel.SY_DICT.Read(DICTMODEL, token);
                    TTmodel.SHOWNAMEMS = DICTdata[0].DICNAME;


                    Temp_Minutes = Temp_Minutes + new Random().Next(Num1, Num2);
                    Temp_Seconds = new Random().Next(0, 59);
                    TTmodel.JLTIME = dstr;
                    TTmodel.SHOWTIME = date + " " + DateTime.Now.AddMinutes(Temp_Minutes).AddSeconds(Temp_Seconds).ToString("hh:mm:ss");//随机时间
                    TTmodel.ACTION = 2;//自动生成标记
                    TTmodel.TYPEID = PointData.FIVES_STAFF_DEP.TYPEID;
                    TTmodel.TYPEMS = PointData.FIVES_STAFF_DEP.TYPENAME;
                    TTmodel.SCOREID = 4;
                    TTmodel.SCOREMS = "0";
                    TTmodel.STAFFID = appclass.CRM_GetStaffid();
                    TTmodel.STAFFNAME = appclass.CRM_GetStaffName();
                    TTmodel.REMARK = "";
                    TTmodel.GC = "";
                    TTmodel.DEPARTID = PointData.FIVES_STAFF_DEP.DEPTID;
                    TTmodel.DEPARTMS = PointData.FIVES_STAFF_DEP.DEPTNAME;
                    TTmodel.POSITION = "鄞州区双鹿电池(通途路北)";
                    TTmodel.OPINTID = data[i].POINTID;
                    TTmodel.OPINTMS = PointData.FIVES_SY_CHECKPOINT.POINTMS;
                    TTmodel.WORKSHOPID = 0;
                    TTmodel.OPINTLOCATION = PointData.FIVES_SY_CHECKPOINT.LOCATIONMS;
                    if (PointData.LASTCHECKINFODETAIL.Length > 0)
                    {
                        TTmodel.HG = 1;
                    }
                    else
                    {
                        TTmodel.HG = 0;
                    }
                    MES_RETURN_UI TTres = fivesmodel.CHECK_INFO.Create(TTmodel, token);
                    if (TTres.TYPE != "S")
                    {
                        continue;
                    }
                    if (PointData.LASTCHECKINFODETAIL.Length > 0)
                    {
                        FIVES_CHECK_INFODETAIL[] MXmodel = new FIVES_CHECK_INFODETAIL[PointData.LASTCHECKINFODETAIL.Length];
                        for (int j = 0; j < PointData.LASTCHECKINFODETAIL.Length; j++)
                        {
                            MXmodel[j] = new FIVES_CHECK_INFODETAIL();
                            MXmodel[j].INFOID = Convert.ToInt32(TTres.MESSAGE);
                            MXmodel[j].TYPEID = PointData.LASTCHECKINFODETAIL[j].TYPEID;
                            MXmodel[j].TYPEMS = PointData.LASTCHECKINFODETAIL[j].TYPEMS;
                            MXmodel[j].SCROEID = PointData.LASTCHECKINFODETAIL[j].SCROEID;
                            MXmodel[j].SCROEMS = "";
                            MXmodel[j].JLTIME = date;
                            MXmodel[j].REMARK = PointData.LASTCHECKINFODETAIL[j].REMARK;
                            MXmodel[j].ACTION = 2;//自动生成标记
                                                  //   MXmodel.ISDELETE = 0;
                        }
                        MES_RETURN_UI MXres = fivesmodel.CHECK_INFODETAIL.Create(MXmodel, token);
                        if (MXres.TYPE != "S")
                        {
                            webmsg.KEY = 0;
                            webmsg.MSG = MXres.MESSAGE;
                            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                        }
                    }
                }
                webmsg.KEY = 1;
                webmsg.MSG = "批量生成成功！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }
            //单个新增
            #region
            else
            {
                int Temp_Minutes = 0, Temp_Seconds = 0;
                for (int i = 0; i < data.Length; i++)
                {

                    FIVES_CHECK_INFOList TEMP_model = new FIVES_CHECK_INFOList();
                    TEMP_model.DEPARTID = DID;
                    TEMP_model.OPINTID = POINTID;
                    TEMP_model.KSTIME = date;
                    TEMP_model.JSTIME = date;
                    FIVES_CHECK_INFOList[] CXdata = fivesmodel.CHECK_INFO.Read(TEMP_model, token);
                    if (CXdata.Length > 0)
                    {
                        webmsg.KEY = 0;
                        webmsg.MSG = "当天检验点今天已新增，不允许重复添加";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                    }



                    FIVES_SY_CHECKPOINT_CREATE PointData = fivesmodel.SY_CHECKPOINT.Select_CHECKPOINT_byParms(data[i].POINTID, appclass.CRM_GetStaffid(), token);

                    FIVES_CHECK_INFO TTmodel = new FIVES_CHECK_INFO();
                    TTmodel.SHOWNAME = SHOWNAME;
                    Sonluk.UI.Model.S5.SY_DICTService.FIVES_SY_DICT DICTMODEL = new Sonluk.UI.Model.S5.SY_DICTService.FIVES_SY_DICT();
                    DICTMODEL.DICID = SHOWNAME;
                    Sonluk.UI.Model.S5.SY_DICTService.FIVES_SY_DICT[] DICTdata = fivesmodel.SY_DICT.Read(DICTMODEL, token);
                    TTmodel.SHOWNAMEMS = DICTdata[0].DICNAME;


                    Temp_Minutes = Temp_Minutes + new Random().Next(Num1, Num2);
                    Temp_Seconds = new Random().Next(0, 59);
                    TTmodel.JLTIME = dstr;
                    TTmodel.SHOWTIME = date + " " + DateTime.Now.AddMinutes(Temp_Minutes).AddSeconds(Temp_Seconds).ToString("hh:mm:ss");//随机时间
                    TTmodel.ACTION = 2;//自动生成标记
                    TTmodel.TYPEID = PointData.FIVES_STAFF_DEP.TYPEID;
                    TTmodel.TYPEMS = PointData.FIVES_STAFF_DEP.TYPENAME;
                    TTmodel.SCOREID = 4;
                    TTmodel.SCOREMS = "0";
                    TTmodel.STAFFID = appclass.CRM_GetStaffid();
                    TTmodel.STAFFNAME = appclass.CRM_GetStaffName();
                    TTmodel.REMARK = "";
                    TTmodel.GC = "";
                    TTmodel.DEPARTID = PointData.FIVES_STAFF_DEP.DEPTID;
                    TTmodel.DEPARTMS = PointData.FIVES_STAFF_DEP.DEPTNAME;
                    TTmodel.POSITION = "鄞州区双鹿电池(通途路北)";
                    TTmodel.OPINTID = data[i].POINTID;
                    TTmodel.OPINTMS = PointData.FIVES_SY_CHECKPOINT.POINTMS;
                    TTmodel.WORKSHOPID = 0;
                    TTmodel.OPINTLOCATION = PointData.FIVES_SY_CHECKPOINT.LOCATIONMS;
                    if (PointData.LASTCHECKINFODETAIL.Length > 0)
                    {
                        TTmodel.HG = 1;
                    }
                    else
                    {
                        TTmodel.HG = 0;
                    }

                    MES_RETURN_UI TTres = fivesmodel.CHECK_INFO.Create(TTmodel, token);
                    if (TTres.TYPE != "S")
                    {
                        webmsg.KEY = 0;
                        webmsg.MSG = "新增失败";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                    }
                    if (PointData.LASTCHECKINFODETAIL.Length > 0)
                    {
                        FIVES_CHECK_INFODETAIL[] MXmodel = new FIVES_CHECK_INFODETAIL[PointData.LASTCHECKINFODETAIL.Length];
                        for (int j = 0; j < PointData.LASTCHECKINFODETAIL.Length; j++)
                        {
                            MXmodel[j] = new FIVES_CHECK_INFODETAIL();
                            MXmodel[j].INFOID = Convert.ToInt32(TTres.MESSAGE);
                            MXmodel[j].TYPEID = PointData.LASTCHECKINFODETAIL[j].TYPEID;
                            MXmodel[j].TYPEMS = PointData.LASTCHECKINFODETAIL[j].TYPEMS;
                            MXmodel[j].SCROEID = PointData.LASTCHECKINFODETAIL[j].SCROEID;
                            MXmodel[j].SCROEMS = "";
                            MXmodel[j].JLTIME = date;
                            MXmodel[j].REMARK = PointData.LASTCHECKINFODETAIL[j].REMARK;
                            MXmodel[j].ACTION = 2;//自动生成标记
                                                  //   MXmodel.ISDELETE = 0;
                        }
                        MES_RETURN_UI MXres = fivesmodel.CHECK_INFODETAIL.Create(MXmodel, token);
                        if (MXres.TYPE != "S")
                        {
                            webmsg.KEY = 0;
                            webmsg.MSG = MXres.MESSAGE;
                            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                        }
                    }
                }
                webmsg.KEY = 1;
                webmsg.MSG = "新建成功！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }
            #endregion

            //}
            //catch (Exception e)
            //{
            //    webmsg.KEY = 0;
            //    webmsg.MSG = e.Message;
            //    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            //}
        }
        [HttpPost]
        public string AUTO_HG(string data)
        {
            string token = appclass.CRM_Gettoken();
            FIVES_CHECK_INFO TTmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<FIVES_CHECK_INFO>(data);
            DateTime d = Convert.ToDateTime(TTmodel.JLTIME);
            if (d.Date != DateTime.Now.Date)
            {
                webmsg.KEY = 0;
                webmsg.MSG = "当前点检区域数据不属于今天，不允许更改";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }

            FIVES_CHECK_INFODETAIL MXmodel = new FIVES_CHECK_INFODETAIL();
            MXmodel.INFOID = TTmodel.INFOID;
            Sonluk.UI.Model.S5.CHECK_INFODETAILService.FIVES_CHECK_INFODETAILList[] MXdata = fivesmodel.CHECK_INFODETAIL.Read(MXmodel, token);
            if (MXdata.Length == 0)
            {
                webmsg.KEY = 0;
                webmsg.MSG = "当前点检区域没有不合格明细,已合格";
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }
            for (int i = 0; i < MXdata.Length; i++)
            {
                MES_RETURN_UI MXmr = fivesmodel.CHECK_INFODETAIL.Delete(MXdata[i].DETAILID, token);
                if (MXmr.TYPE != "S")
                {
                    webmsg.KEY = 0;
                    webmsg.MSG = MXmr.MESSAGE;
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
            }

            TTmodel.HG = 0;
            TTmodel.REMARK = DateTime.Now.ToString("yyyyMMdd") + "已整改";
            MES_RETURN_UI TTmr = fivesmodel.CHECK_INFO.Update(TTmodel, token);
            if (TTmr.TYPE != "S")
            {
                webmsg.KEY = 0;
                webmsg.MSG = TTmr.MESSAGE;
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }
            else
            {
                webmsg.KEY = 1;
                webmsg.MSG = TTmr.MESSAGE;
                return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
            }
        }

    }
}
