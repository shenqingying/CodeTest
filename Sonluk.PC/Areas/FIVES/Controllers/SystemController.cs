using Sonluk.PC.APPCLASS;
using Sonluk.PC.Areas.MES.Models;
using Sonluk.PC.Models;
using Sonluk.UI.Model.CRM.HG_DEPTService;
using Sonluk.UI.Model.HR.SY_DEPTService;
using Sonluk.UI.Model.MODEL;
using Sonluk.UI.Model.S5.STAFF_DEPService;
using Sonluk.UI.Model.S5.SY_CHECKDETAILSService;
using Sonluk.UI.Model.S5.SY_DICTService;
using Sonluk.UI.Model.S5.SY_RELATIONSHIPBINDService;
using Sonluk.UI.Model.S5.SY_STAFF_DEPService;
using Sonluk.UI.Model.S5.SY_TYPEService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Sonluk.PC.Areas.FIVES.Controllers
{
    public class SystemController : Controller
    {
        //
        // GET: /FIVES/System/
        FIVESModels fivesmodels = new FIVESModels();
        HRModels hrmodels = new HRModels();
        AppClass appClass = new AppClass();
        CRMModels crmModels = new CRMModels();
        string token = "";
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Dictionary()
        {
            Session["location"] = 205;
            return View();
        }
        public ActionResult CheckPoint()
        {
            Session["location"] = 206;
            token = appClass.CRM_Gettoken();
            HR_SY_DEPT_SELECT r = hrmodels.SY_DEPT.SELECT(new HR_SY_DEPT(), token);
            ViewBag.DEPList = r;
            FIVES_SY_DICT model = new FIVES_SY_DICT();
            FIVES_SY_TYPE TYPEmodel = new FIVES_SY_TYPE();
            TYPEmodel.TYPENAME = "检查频率";
            FIVES_SY_TYPE[] TYPEDATA = fivesmodels.SY_TYPE.Read(TYPEmodel, token);
            model.TYPEID = TYPEDATA[0].TYPEID;
            FIVES_SY_DICT[] RES = fivesmodels.SY_DICT.Read(model, token);
            ViewBag.RES = RES;

            FIVES_SY_DICT cxmodel = new FIVES_SY_DICT();
            FIVES_SY_TYPE TYPEmodel2 = new FIVES_SY_TYPE();
            TYPEmodel2.TYPENAME = "检查类型";
            FIVES_SY_TYPE[] TYPEDATA2 = fivesmodels.SY_TYPE.Read(TYPEmodel2, token);
            model.TYPEID = TYPEDATA2[0].TYPEID;
            FIVES_SY_DICT[] JCRES = fivesmodels.SY_DICT.Read(model, token);
          
            List<FIVES_SY_DICT> ListJcres = JCRES.ToList();
            for (int i = JCRES.Length - 1; i >= 0; i--)
            {
                if (JCRES[i].DICNAME == "抽检")
                {
                    ListJcres[i].DICID = 0;
                }
                if (JCRES[i].DICNAME == "巡检")
                {
                    ListJcres[i].DICID = 0;
                }
            }
            FIVES_SY_DICT[] JCRES_set = ListJcres.ToArray();
            ViewBag.JCRES = JCRES_set;
            return View();
        }
        public ActionResult CheckDetails()
        {
            token = appClass.CRM_Gettoken();
            Session["location"] = 207;
            FIVES_SY_DICT model = new FIVES_SY_DICT();
            model.TYPEID = 4;
            FIVES_SY_DICT[] res = fivesmodels.SY_DICT.Read(model, token);
            ViewBag.DICT = res;
            return View();
        }

        public ActionResult CheckXMFL()
        {
            token = appClass.CRM_Gettoken();
            Session["location"] = 210;
            return View();
        }
        public ActionResult CheckPointFL()
        {
            token = appClass.CRM_Gettoken();
            Session["location"] = 211;
            return View();
        }
        public ActionResult CheckPointPrint()
        {
            List<Sonluk.UI.Model.S5.SY_CHECKPOINTService.FIVES_SY_CHECKPOINT_CREATE> nodes = (List<Sonluk.UI.Model.S5.SY_CHECKPOINTService.FIVES_SY_CHECKPOINT_CREATE>)AppClass.GetSession("CheckPoint_PrintList");
            ViewBag.Nodes = nodes;
            return View();
        }
        public ActionResult STAFF_DEP()
        {
            token = appClass.CRM_Gettoken();
            Session["location"] = 208;
            MODEK_StaffManage model = new MODEK_StaffManage();

            CRM_HG_DEPT[] rst_CRM_HG_DEPT = crmModels.HG_DEPT.Read(token);
            HR_SY_DEPT_SELECT res = hrmodels.SY_DEPT.SELECT(new HR_SY_DEPT(), token);
            AppClass.SetSession("five_dep", res);
            model.CRM_HG_DEPT = rst_CRM_HG_DEPT;
            ViewData.Model = model;
            return View();

        }
        public ActionResult STAFF_DEP_ACCESS()
        {
            token = appClass.CRM_Gettoken();
            Session["location"] = 216;
            MODEK_StaffManage model = new MODEK_StaffManage();

           
            HR_SY_DEPT_SELECT res = hrmodels.SY_DEPT.SELECT(new HR_SY_DEPT(), token);
           if(res.MES_RETURN.TYPE == "S")
            {

            }
            ViewData.Model = res;

            FIVES_SY_DICT cxmodel = new FIVES_SY_DICT();
            FIVES_SY_TYPE TYPEmodel2 = new FIVES_SY_TYPE();
            TYPEmodel2.TYPENAME = "检查类型";
            FIVES_SY_TYPE[] TYPEDATA2 = fivesmodels.SY_TYPE.Read(TYPEmodel2, token);
            cxmodel.TYPEID = TYPEDATA2[0].TYPEID;
            FIVES_SY_DICT[] JCRES = fivesmodels.SY_DICT.Read(cxmodel, token);
            List<FIVES_SY_DICT> JCLIST = JCRES.ToList();


            FIVES_SY_DICT CXMODEL2 = new FIVES_SY_DICT();
            CXMODEL2.DICNAME = "通知";
            FIVES_SY_DICT[] JCRES2 = fivesmodels.SY_DICT.Read(CXMODEL2, token);
            JCLIST.Add(JCRES2[0]);

            FIVES_SY_DICT[] JCRESULT = JCLIST.ToArray();
            ViewBag.JCRESULT = JCRESULT;

            return View();

        }

        public ActionResult BarCode(string code, string format, string width, string height, string pure)
        {
            //string code = Request.QueryString["code"];
            //string format = Request.QueryString["format"];
            //int width = Convert.ToInt32(Request.QueryString["width"].ToString());
            //int height =  Convert.ToInt32(Request.QueryString["height"].ToString());
            //int pure = Convert.ToInt32(Request.QueryString["pure"].ToString());
            string URL = System.Configuration.ConfigurationManager.AppSettings["FIVESURL"];
            code = URL + code;
            Byte[] objcode = fivesmodels.BarCode.CreateBarCode(code, format, Convert.ToInt32(width), Convert.ToInt32(height), Convert.ToInt32(pure));

            Response.ContentType = "image/jpeg";
            Response.Clear();
            Response.BufferOutput = true;
            Response.BinaryWrite(objcode);
            Response.Flush();
            return View();
        }
        public string POST_CheckPointPrint(string data)
        {

            token = appClass.CRM_Gettoken();
            int[] pointArr = Newtonsoft.Json.JsonConvert.DeserializeObject<int[]>(data);
            //Sonluk.UI.Model.S5.SY_CHECKPOINTService.FIVES_SY_CHECKPOINTList[] pointArr = Newtonsoft.Json.JsonConvert.DeserializeObject<Sonluk.UI.Model.S5.SY_CHECKPOINTService.FIVES_SY_CHECKPOINTList[]>(data);
            List<Sonluk.UI.Model.S5.SY_CHECKPOINTService.FIVES_SY_CHECKPOINT_CREATE> nodes = new List<UI.Model.S5.SY_CHECKPOINTService.FIVES_SY_CHECKPOINT_CREATE>();
            for (int i = 0; i < pointArr.Length; i++)
            {
                nodes.Add(fivesmodels.SY_CHECKPOINT.Select_CHECKPOINT_byPointid(pointArr[i], token));
            }

            string res = "E";
            if (nodes.Count > 0)
            {
                res = "S";
                AppClass.SetSession("CheckPoint_PrintList", nodes);
            }
            return res;

        }
        public string SY_DICT_Read(string data)
        {
            token = appClass.CRM_Gettoken();
            FIVES_SY_DICT model = Newtonsoft.Json.JsonConvert.DeserializeObject<FIVES_SY_DICT>(data);
            FIVES_SY_DICT[] res = fivesmodels.SY_DICT.Read(model, token);
            //HR_SY_DEPT_SELECT r = hrmodels.SY_DEPT.SELECT(new HR_SY_DEPT(), token);

            return Newtonsoft.Json.JsonConvert.SerializeObject(res);
        }
        public string DEPT_SELECT()
        {
            token = appClass.CRM_Gettoken();
            //HR_SY_DEPT model = Newtonsoft.Json.JsonConvert.DeserializeObject<HR_SY_DEPT>(data);
            HR_SY_DEPT model = new HR_SY_DEPT();
            HR_SY_DEPT_SELECT res = hrmodels.SY_DEPT.SELECT(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(res);
        }
        public string Dictionary_Select_LB()
        {
            if (Session["token"] != null)
            {
                token = Session["token"].ToString();
            }
            FIVES_SY_TYPE model = new FIVES_SY_TYPE();
            FIVES_SY_TYPE[] result = fivesmodels.SY_TYPE.Read(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        public string Dictionary_Update_LB(string data)
        {
            token = appClass.CRM_Gettoken();
            FIVES_SY_TYPE model = Newtonsoft.Json.JsonConvert.DeserializeObject<FIVES_SY_TYPE>(data);
            MES_RETURN_UI rst = fivesmodels.SY_TYPE.Update(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        public string Dictionary_Delete_LB(int TYPEID)
        {
            token = appClass.CRM_Gettoken();
            MES_RETURN_UI rst = fivesmodels.SY_TYPE.Delete(TYPEID, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        public string Dictionary_Create_LB(string data)
        {
            token = appClass.CRM_Gettoken();
            FIVES_SY_TYPE model = Newtonsoft.Json.JsonConvert.DeserializeObject<FIVES_SY_TYPE>(data);
            MES_RETURN_UI rst = fivesmodels.SY_TYPE.Create(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }

        public string Dictionary_Update_MX(string data)
        {
            token = appClass.CRM_Gettoken();
            FIVES_SY_DICT model = Newtonsoft.Json.JsonConvert.DeserializeObject<FIVES_SY_DICT>(data);
            MES_RETURN_UI rst = fivesmodels.SY_DICT.Update(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        public string Dictionary_Delete_MX(int DICID)
        {
            token = appClass.CRM_Gettoken();
            MES_RETURN_UI rst = fivesmodels.SY_DICT.Delete(DICID, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        public string Dictionary_Create_MX(string data)
        {
            token = appClass.CRM_Gettoken();
            FIVES_SY_DICT model = Newtonsoft.Json.JsonConvert.DeserializeObject<FIVES_SY_DICT>(data);
            MES_RETURN_UI rst = fivesmodels.SY_DICT.Create(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        public string Dictionary_Select_MX(int TYPEID)
        {
            token = appClass.CRM_Gettoken();
            FIVES_SY_DICT model = new FIVES_SY_DICT();
            model.TYPEID = TYPEID;
            FIVES_SY_DICT[] result = fivesmodels.SY_DICT.Read(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }


        public string CheckDetails_Select(int CatagroyID)
        {
            token = appClass.CRM_Gettoken();
            FIVES_SY_CHECKDETAILS model = new FIVES_SY_CHECKDETAILS();
            model.CATEGROYID = CatagroyID;
            FIVES_SY_CHECKDETAILSList[] result = fivesmodels.SY_CHECKDETAILS.Read(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        public string CheckDetails_Create(string data)
        {
            token = appClass.CRM_Gettoken();
            FIVES_SY_CHECKDETAILS model = Newtonsoft.Json.JsonConvert.DeserializeObject<FIVES_SY_CHECKDETAILS>(data);
            MES_RETURN_UI result = fivesmodels.SY_CHECKDETAILS.Create(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        public string CheckDetails_Update(string data)
        {
            token = appClass.CRM_Gettoken();
            FIVES_SY_CHECKDETAILS model = Newtonsoft.Json.JsonConvert.DeserializeObject<FIVES_SY_CHECKDETAILS>(data);
            MES_RETURN_UI result = fivesmodels.SY_CHECKDETAILS.Update(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        public string CheckDetails_Delete(int DETAILID)
        {
            token = appClass.CRM_Gettoken();
            MES_RETURN_UI result = fivesmodels.SY_CHECKDETAILS.Delete(DETAILID, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
        public string CheckPoint_Create(string checkpointStruct, string gwArr, string detailArr)
        {
            MES_RETURN_UI mr = new MES_RETURN_UI();
            token = appClass.CRM_Gettoken();
            Sonluk.UI.Model.S5.SY_CHECKPOINTService.FIVES_SY_CHECKPOINT_CREATE model = new Sonluk.UI.Model.S5.SY_CHECKPOINTService.FIVES_SY_CHECKPOINT_CREATE();
            Sonluk.UI.Model.S5.SY_CHECKPOINTService.FIVES_SY_CHECKPOINT checkpoint = Newtonsoft.Json.JsonConvert.DeserializeObject<Sonluk.UI.Model.S5.SY_CHECKPOINTService.FIVES_SY_CHECKPOINT>(checkpointStruct);
            Sonluk.UI.Model.S5.SY_CHECKPOINTService.FIVES_SY_DICT[] gw = Newtonsoft.Json.JsonConvert.DeserializeObject<Sonluk.UI.Model.S5.SY_CHECKPOINTService.FIVES_SY_DICT[]>(gwArr);
            Sonluk.UI.Model.S5.SY_CHECKPOINTService.FIVES_SY_DICT[] mx = Newtonsoft.Json.JsonConvert.DeserializeObject<Sonluk.UI.Model.S5.SY_CHECKPOINTService.FIVES_SY_DICT[]>(detailArr);

            MES_RETURN_UI checkpointMR = fivesmodels.SY_CHECKPOINT.Create(checkpoint, token);
            if (!checkpointMR.TYPE.Equals("S"))
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(checkpointMR); ;
            }
            int pointid = Convert.ToInt32(checkpointMR.MESSAGE);
            string gwStr = "检验点-岗位";
            string flStr = "检验点-检验点分类";
            FIVES_SY_DICT dictModel = new FIVES_SY_DICT();
            dictModel.TYPEID = 5;
            dictModel.DICNAME = gwStr;
            FIVES_SY_DICT[] gwData = fivesmodels.SY_DICT.Read(dictModel, token);
            dictModel.DICNAME = flStr;
            FIVES_SY_DICT[] flData = fivesmodels.SY_DICT.Read(dictModel, token);
            int gwID = gwData.Length == 1 ? gwData[0].DICID : 0;
            int flID = flData.Length == 1 ? flData[0].DICID : 0;
            if (gwID == 0 || flID == 0)
            {
                mr.TYPE = "E";
                mr.MESSAGE = "获取岗位、分类ID失败";
                return Newtonsoft.Json.JsonConvert.SerializeObject(mr);
            }

            FIVES_SY_RELATIONSHIPBIND reModel = new FIVES_SY_RELATIONSHIPBIND();
            reModel.TYPE = gwID;
            reModel.OBJ1 = pointid;
            reModel.ACTION = 1;
            for (int i = 0; i < gw.Length; i++)
            {
                reModel.OBJ2 = gw[i].DICID;
                MES_RETURN_UI reMr = fivesmodels.SY_RELATIONSHIPBIND.Create(reModel, token);
                if (!reMr.TYPE.Equals("S"))
                {
                    return Newtonsoft.Json.JsonConvert.SerializeObject(reMr);
                }
            }
            reModel.TYPE = flID;
            for (int i = 0; i < mx.Length; i++)
            {
                reModel.OBJ2 = mx[i].DICID;
                MES_RETURN_UI reMr = fivesmodels.SY_RELATIONSHIPBIND.Create(reModel, token);
                if (!reMr.TYPE.Equals("S"))
                {
                    return Newtonsoft.Json.JsonConvert.SerializeObject(reMr);
                }
            }
            mr.TYPE = "S";
            return Newtonsoft.Json.JsonConvert.SerializeObject(mr);
        }

        public string CheckPoint_Update(string checkpointStruct, string gwArr, string detailArr)
        {
            MES_RETURN_UI mr = new MES_RETURN_UI();
            token = appClass.CRM_Gettoken();
            Sonluk.UI.Model.S5.SY_CHECKPOINTService.FIVES_SY_CHECKPOINT_CREATE model = new Sonluk.UI.Model.S5.SY_CHECKPOINTService.FIVES_SY_CHECKPOINT_CREATE();
            Sonluk.UI.Model.S5.SY_CHECKPOINTService.FIVES_SY_CHECKPOINT checkpoint = Newtonsoft.Json.JsonConvert.DeserializeObject<Sonluk.UI.Model.S5.SY_CHECKPOINTService.FIVES_SY_CHECKPOINT>(checkpointStruct);
            Sonluk.UI.Model.S5.SY_CHECKPOINTService.FIVES_SY_DICT[] gw = Newtonsoft.Json.JsonConvert.DeserializeObject<Sonluk.UI.Model.S5.SY_CHECKPOINTService.FIVES_SY_DICT[]>(gwArr);
            Sonluk.UI.Model.S5.SY_CHECKPOINTService.FIVES_SY_DICT[] mx = Newtonsoft.Json.JsonConvert.DeserializeObject<Sonluk.UI.Model.S5.SY_CHECKPOINTService.FIVES_SY_DICT[]>(detailArr);
            MES_RETURN_UI checkpointMR = fivesmodels.SY_CHECKPOINT.Update(checkpoint, token);
            if (!checkpointMR.TYPE.Equals("S"))
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(mr); ;
            }
            string gwStr = "检验点-岗位";
            string flStr = "检验点-检验点分类";
            FIVES_SY_DICT dictModel = new FIVES_SY_DICT();
            dictModel.TYPEID = 5;
            dictModel.DICNAME = gwStr;
            FIVES_SY_DICT[] gwData = fivesmodels.SY_DICT.Read(dictModel, token);
            dictModel.DICNAME = flStr;
            FIVES_SY_DICT[] flData = fivesmodels.SY_DICT.Read(dictModel, token);
            int gwID = gwData.Length == 1 ? gwData[0].DICID : 0;
            int flID = flData.Length == 1 ? flData[0].DICID : 0;
            if (gwID == 0 || flID == 0)
            {
                mr.TYPE = "E";
                mr.MESSAGE = "获取岗位、分类ID失败";
                return Newtonsoft.Json.JsonConvert.SerializeObject(mr);
            }
            FIVES_SY_RELATIONSHIPBIND delModel = new FIVES_SY_RELATIONSHIPBIND();
            delModel.OBJ1 = checkpoint.POINTID;
            delModel.TYPE = gwID;
            fivesmodels.SY_RELATIONSHIPBIND.Delete_OBJ1(delModel, token);
            delModel.TYPE = flID;
            fivesmodels.SY_RELATIONSHIPBIND.Delete_OBJ1(delModel, token);

            FIVES_SY_RELATIONSHIPBIND reModel = new FIVES_SY_RELATIONSHIPBIND();
            reModel.TYPE = gwID;
            reModel.OBJ1 = checkpoint.POINTID;
            reModel.ACTION = 1;
            for (int i = 0; i < gw.Length; i++)
            {
                reModel.OBJ2 = gw[i].DICID;
                MES_RETURN_UI reMr = fivesmodels.SY_RELATIONSHIPBIND.Create(reModel, token);
                if (!reMr.TYPE.Equals("S"))
                {
                    return Newtonsoft.Json.JsonConvert.SerializeObject(reMr);
                }
            }
            reModel.TYPE = flID;
            for (int i = 0; i < mx.Length; i++)
            {
                reModel.OBJ2 = mx[i].DICID;
                MES_RETURN_UI reMr = fivesmodels.SY_RELATIONSHIPBIND.Create(reModel, token);
                if (!reMr.TYPE.Equals("S"))
                {
                    return Newtonsoft.Json.JsonConvert.SerializeObject(reMr);
                }
            }
            mr.TYPE = "S";
            return Newtonsoft.Json.JsonConvert.SerializeObject(mr);



        }
        public string CheckPoint_Print(int pointid)
        {
            return "";
        }
        public string CheckPoint_Delete(int pointid)
        {
            MES_RETURN_UI mr = new MES_RETURN_UI();
            token = appClass.CRM_Gettoken();
            //MES_RETURN_UI mr = fivesmodels.SY_CHECKPOINT.Delete_ALL(pointid, token);
            MES_RETURN_UI mmr = fivesmodels.SY_CHECKPOINT.Delete(pointid, token);
            if (!mmr.TYPE.Equals("S"))
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(mmr);
            }
            string gwStr = "检验点-岗位";
            string flStr = "检验点-检验点分类";
            FIVES_SY_DICT dictModel = new FIVES_SY_DICT();
            dictModel.TYPEID = 5;
            dictModel.DICNAME = gwStr;
            FIVES_SY_DICT[] gwData = fivesmodels.SY_DICT.Read(dictModel, token);
            dictModel.DICNAME = flStr;
            FIVES_SY_DICT[] flData = fivesmodels.SY_DICT.Read(dictModel, token);
            int gwID = gwData.Length == 1 ? gwData[0].DICID : 0;
            int flID = flData.Length == 1 ? flData[0].DICID : 0;
            if (gwID == 0 || flID == 0)
            {
                mr.TYPE = "E";
                mr.MESSAGE = "获取岗位、分类ID失败";
                return Newtonsoft.Json.JsonConvert.SerializeObject(mr);
            }
            FIVES_SY_RELATIONSHIPBIND delModel = new FIVES_SY_RELATIONSHIPBIND();
            delModel.OBJ1 = pointid;
            delModel.TYPE = gwID;
            fivesmodels.SY_RELATIONSHIPBIND.Delete_OBJ1(delModel, token);
            delModel.TYPE = flID;
            fivesmodels.SY_RELATIONSHIPBIND.Delete_OBJ1(delModel, token);
            mr.TYPE = "S";
            return Newtonsoft.Json.JsonConvert.SerializeObject(mr);
        }
        public string CheckPoint_Select(int Depid)
        {
            token = appClass.CRM_Gettoken();
            Sonluk.UI.Model.S5.SY_CHECKPOINTService.FIVES_SY_CHECKPOINT model = new Sonluk.UI.Model.S5.SY_CHECKPOINTService.FIVES_SY_CHECKPOINT();
            model.DID = Depid;
            try
            {

                Sonluk.UI.Model.S5.SY_CHECKPOINTService.FIVES_SY_CHECKPOINTList[] res = fivesmodels.SY_CHECKPOINT.ReadaddDepName(model, token);
                return Newtonsoft.Json.JsonConvert.SerializeObject(res);
            }
            catch (Exception e)
            {
                return e.Message;
            }


        }
        public string CheckPoint_SelectByStaffid(int pointID)
        {
            token = appClass.CRM_Gettoken();
            Sonluk.UI.Model.S5.SY_CHECKPOINTService.FIVES_SY_CHECKPOINT_CREATE res = fivesmodels.SY_CHECKPOINT.Select_CHECKPOINT_byPointid(pointID, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(res);
        }
        public string SY_DEPT_SELECT()
        {
            HR_SY_DEPT_SELECT res = (HR_SY_DEPT_SELECT)AppClass.GetSession("five_dep");
            return Newtonsoft.Json.JsonConvert.SerializeObject(res);
        }
        public string SY_DEPT_SELECTByStaffID(int staffid)
        {
            token = appClass.CRM_Gettoken();
            FIVES_SY_STAFF_DEP node = new FIVES_SY_STAFF_DEP();
            node.STAFFID = staffid;
            FIVES_SY_STAFF_DEPList[] res = fivesmodels.SY_STAFF_DEP.Read(node, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(res);
        }
        [HttpPost]
        public string STAFF_DEPBySTAFFID(int staffid)
        {
            token = appClass.CRM_Gettoken();
            FIVES_STAFF_DEP node = new FIVES_STAFF_DEP();
            node.STAFFID =  staffid;
            FIVES_STAFF_DEP[] res = fivesmodels.STAFF_DEP.Read(node, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(res);
        }
        public string STAFF_DEP_Create(string data, int staffid)
        {
            token = appClass.CRM_Gettoken();
            FIVES_SY_STAFF_DEP[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<FIVES_SY_STAFF_DEP[]>(data);
            MES_RETURN_UI res = fivesmodels.SY_STAFF_DEP.Update_All(model, staffid, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(res);
        }
        public string STAFF_DEP_Update(string data)
        {
            token = appClass.CRM_Gettoken();
            FIVES_SY_STAFF_DEP model = Newtonsoft.Json.JsonConvert.DeserializeObject<FIVES_SY_STAFF_DEP>(data);
            MES_RETURN_UI res = fivesmodels.SY_STAFF_DEP.Update(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(res);
        }

        public string CreateFL_MX(string mxdata, int FLID, string TYPEMS)
        {
            token = appClass.CRM_Gettoken();
            FIVES_SY_CHECKDETAILS[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<FIVES_SY_CHECKDETAILS[]>(mxdata);
            FIVES_SY_DICT dictmodel = new FIVES_SY_DICT();
            dictmodel.DICNAME = TYPEMS;
            dictmodel.TYPEID = 5;
            FIVES_SY_DICT[] dictres = fivesmodels.SY_DICT.Read(dictmodel, token);
            int typeID = dictres.Length == 1 ? dictres[0].DICID : 0;

            FIVES_SY_RELATIONSHIPBIND node = new FIVES_SY_RELATIONSHIPBIND();
            node.OBJ1 = FLID;
            node.TYPE = typeID;
            for (int i = 0; i < model.Length; i++)
            {
                node.OBJ2 = model[i].DETAILID;
                MES_RETURN_UI mr = fivesmodels.SY_RELATIONSHIPBIND.Create(node, token);
                if (!mr.TYPE.Equals("S"))
                {
                    return Newtonsoft.Json.JsonConvert.SerializeObject(mr);
                }
            }
            MES_RETURN_UI m = new MES_RETURN_UI();
            m.TYPE = "S";
            return Newtonsoft.Json.JsonConvert.SerializeObject(m);
        }

        public string SelectFL_MX(int FLID, string TYPMEMS)
        {
            token = appClass.CRM_Gettoken();
            FIVES_SY_DICT dictmodel = new FIVES_SY_DICT();
            dictmodel.DICNAME = TYPMEMS;
            dictmodel.TYPEID = 5;
            FIVES_SY_DICT[] dictres = fivesmodels.SY_DICT.Read(dictmodel, token);
            int typeID = dictres.Length == 1 ? dictres[0].DICID : 0;
            FIVES_SY_RELATIONSHIPBIND model = new FIVES_SY_RELATIONSHIPBIND();
            model.OBJ1 = FLID;
            model.TYPE = typeID;
            FIVES_SY_RELATIONSHIPBINDList[] res = fivesmodels.SY_RELATIONSHIPBIND.Read(model, token);


            //Sonluk.UI.Model.S5.SY_CHECKPOINTService.FIVES_SY_CHECKPOINT_CREATE r =  fivesmodels.SY_CHECKPOINT.Select_CHECKPOINT_byParms(56, 273, token);



            return Newtonsoft.Json.JsonConvert.SerializeObject(res);
        }
        public string UpdateFL_MX(int FLID, string TYPEMS, string mxdata)
        {
            token = appClass.CRM_Gettoken();
            FIVES_SY_DICT dictmodel = new FIVES_SY_DICT();
            dictmodel.DICNAME = TYPEMS;
            dictmodel.TYPEID = 5;
            FIVES_SY_DICT[] dictres = fivesmodels.SY_DICT.Read(dictmodel, token);
            int typeID = dictres.Length == 1 ? dictres[0].DICID : 0;

            FIVES_SY_RELATIONSHIPBIND delmodel = new FIVES_SY_RELATIONSHIPBIND();
            delmodel.OBJ1 = FLID;
            delmodel.TYPE = typeID;
            MES_RETURN_UI delres = fivesmodels.SY_RELATIONSHIPBIND.Delete_OBJ1(delmodel, token);
            if (!delres.TYPE.Equals("S"))
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(delres);
            }
            //create
            FIVES_SY_CHECKDETAILS[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<FIVES_SY_CHECKDETAILS[]>(mxdata);
            FIVES_SY_RELATIONSHIPBIND node = new FIVES_SY_RELATIONSHIPBIND();
            node.OBJ1 = FLID;
            node.TYPE = typeID;
            node.ACTION = 1;
            for (int i = 0; i < model.Length; i++)
            {
                node.OBJ2 = model[i].DETAILID;
                MES_RETURN_UI mr = fivesmodels.SY_RELATIONSHIPBIND.Create(node, token);
                if (!mr.TYPE.Equals("S"))
                {
                    return Newtonsoft.Json.JsonConvert.SerializeObject(mr);
                }
            }
            MES_RETURN_UI m = new MES_RETURN_UI();
            m.TYPE = "S";
            return Newtonsoft.Json.JsonConvert.SerializeObject(m);
        }

        public string RELATIONSHIPBIND_Read(int OBJ1, string TYPEMS)
        {
            token = appClass.CRM_Gettoken();
            FIVES_SY_DICT dictModel = new FIVES_SY_DICT();
            dictModel.TYPEID = 5;
            dictModel.DICNAME = TYPEMS;
            FIVES_SY_DICT[] Data = fivesmodels.SY_DICT.Read(dictModel, token);
            int typeID = Data[0].DICID;
            FIVES_SY_RELATIONSHIPBIND model = new FIVES_SY_RELATIONSHIPBIND();
            model.OBJ1 = OBJ1;
            model.TYPE = typeID;
            FIVES_SY_RELATIONSHIPBINDList[] res = fivesmodels.SY_RELATIONSHIPBIND.Read(model, token);

            return Newtonsoft.Json.JsonConvert.SerializeObject(res);
        }
        [HttpPost]
        public string Create_STAFF_DEP(string data)
        {
            token = appClass.CRM_Gettoken();
            FIVES_STAFF_DEP model = Newtonsoft.Json.JsonConvert.DeserializeObject<FIVES_STAFF_DEP>(data);
            MES_RETURN_UI m = fivesmodels.STAFF_DEP.Create(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(m);
        }
        [HttpPost]
        public string Delete_STAFF_DEP(string data)
        {
            token = appClass.CRM_Gettoken();
            FIVES_STAFF_DEP model = Newtonsoft.Json.JsonConvert.DeserializeObject<FIVES_STAFF_DEP>(data);
            MES_RETURN_UI m = fivesmodels.STAFF_DEP.Delete(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(m);
        }
    }
}
