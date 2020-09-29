using Sonluk.PC.APPCLASS;
using Sonluk.PC.Areas.MES.Models;
using Sonluk.PC.Models;
using Sonluk.UI.Model.EM.EM_MISSIONService;
using Sonluk.UI.Model.EM.FILE_PATHService;
using Sonluk.UI.Model.EM.SY_DEVICE_CONTRACTService;
using Sonluk.UI.Model.EM.SY_DEVICEDETAILDOCService;
using Sonluk.UI.Model.EM.SY_DEVICEQRJLService;
using Sonluk.UI.Model.EM.SY_DEVICETYPEService;
using Sonluk.UI.Model.EM.SY_MANUALBBService;
using Sonluk.UI.Model.EM.SY_MANUALPATHService;
using Sonluk.UI.Model.EM.SY_MANUALService;
using Sonluk.UI.Model.EM.SY_PBService;
using Sonluk.UI.Model.EM.SY_SBBHDEVICETYPEService;
using Sonluk.UI.Model.EM.SY_SBBHMANUALService;
using Sonluk.UI.Model.EM.SY_SBBINDPBService;
using Sonluk.UI.Model.EM.SY_STAFF_EMTYPEService;
using Sonluk.UI.Model.EM.SY_STAFFIDBINDPBService;
using Sonluk.UI.Model.EM.SY_XTBBService;
using Sonluk.UI.Model.MES.MES_MMService;
using Sonluk.UI.Model.MES.SY_GCService;
using Sonluk.UI.Model.MES.SY_GZZX_SBHService;
using Sonluk.UI.Model.MES.SY_GZZXService;
using Sonluk.UI.Model.MES.SY_STAFFService;
using Sonluk.UI.Model.MES.SY_TYPEMXService;
using Sonluk.UI.Model.MODEL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Sonluk.PC.Areas.EM.Controllers
{
    public class SystemController : Controller
    {
        //
        // GET: /EM/System/
        MESModels mesModels = new MESModels();
        CRMModels crmModels = new CRMModels();
        HRModels hrmodels = new HRModels();
        EMModel emModel = new EMModel();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult XTBB()
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_SY_TYPEMX model = new MES_SY_TYPEMX();
            model.TYPEID = 25;
            MES_SY_TYPEMXLIST[] mxList = mesModels.SY_TYPEMX.SELECT(model, token);
            AppClass.SetSession("location", 230);
            Session["TITLENAME"] = "系统版本管理";
            ViewBag.mxList = mxList;
            return View();
        }
        public ActionResult Contact_Management()
        {
            string token = AppClass.GetSession("token").ToString();
            AppClass.SetSession("location", 234);
            //MES_SY_GZZX gzzxmodel = new MES_SY_GZZX();

            //MES_SY_GZZX[] rst_MES_SY_GZZX = mesModels.SY_GZZX.SELECT_USER(gzzxmodel, token);
            //ViewBag.gzzxArr = rst_MES_SY_GZZX;//
            return View();
        }
        public ActionResult SBBHDEVICEGUIDE()
        {
            string token = AppClass.GetSession("token").ToString();
            AppClass.SetSession("location", 235);

            MES_SY_GZZX gzzx = new MES_SY_GZZX();
            MES_SY_GZZX[] zx = mesModels.SY_GZZX.SELECT(gzzx, token);
            MES_SY_GZZX_SBH sbh = new MES_SY_GZZX_SBH();
            MES_SY_GZZX_SBH[] sb = mesModels.SY_GZZX_SBH.SELECT_ALL(sbh, token);
            MES_SY_GC gc = new MES_SY_GC();
            MES_SY_GC[] gcid = mesModels.SY_GC.read(gc, token);
            MES_SY_TYPEMX sbfl = new MES_SY_TYPEMX();
            sbfl.TYPEID = 14;
            MES_SY_TYPEMXLIST[] fl = mesModels.SY_TYPEMX.SELECT(sbfl, token);
            MODLEDataGather data = new MODLEDataGather();
            data.Sy_gc = gcid;
            data.Sy_gzzx = zx;
            data.Sy_gzzx_sbh = sb;
            data.Sy_typemxlist = fl;
            ViewData.Model = data;

            return View();
        }
     
        public ActionResult DEVICEGUIDE()
        {
            string token = AppClass.GetSession("token").ToString();
            AppClass.SetSession("location", 236);
            return View();
        }
        public ActionResult DEVICEGUIDEDETAIL()
        {
            string token = AppClass.GetSession("token").ToString();
            AppClass.SetSession("location", 237);
            return View();
        }
        public ActionResult DEVICERQJL()
        {
            string token = AppClass.GetSession("token").ToString();
            AppClass.SetSession("location", 238);
            return View();
        }
        public ActionResult PBGL()
        {
            string token = AppClass.GetSession("token").ToString();
            AppClass.SetSession("location", 239);
            return View();
        }
        public ActionResult MISSION_GL()
        {
            string token = AppClass.GetSession("token").ToString();
            AppClass.SetSession("location", 240);
            return View();
        }
        public ActionResult MISSION_Select()
        {
            string token = AppClass.GetSession("token").ToString();
            AppClass.SetSession("location", 241);
            return View();
        }
        public string Data_Select_Device(string GZZXBH, string GC, string WLLBNAME, string FSBBH)
        {

            string token = Session["token"].ToString();

            MES_SY_GZZX_SBH sbh = new MES_SY_GZZX_SBH();
            sbh.GZZXBH = GZZXBH;
            sbh.GC = GC;
            sbh.WLLBNAME = WLLBNAME;
            sbh.FSBBH = FSBBH;
            MES_SY_GZZX_SBH_SELECT data = mesModels.SY_GZZX_SBH.SELECT_BY_FSBBH(sbh, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }




        public string Insert_DEVICETYPE(string data)
        {
            string token = AppClass.GetSession("token").ToString();
            EM_SY_DEVICETYPE node = Newtonsoft.Json.JsonConvert.DeserializeObject<EM_SY_DEVICETYPE>(data);
            node.DMS = node.DMS.Trim();
            MES_RETURN_UI mr = emModel.SY_DEVICETYPE.Create(node, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(mr);
        }
        public string Update_DEVICETYPE(string data)
        {
            string token = AppClass.GetSession("token").ToString();
            EM_SY_DEVICETYPE node = Newtonsoft.Json.JsonConvert.DeserializeObject<EM_SY_DEVICETYPE>(data);
            MES_RETURN_UI mr = emModel.SY_DEVICETYPE.Update(node, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(mr);
        }
        public string Read_DEVICETYPE(string data)
        {
            string token = AppClass.GetSession("token").ToString();
            EM_SY_DEVICETYPE node = Newtonsoft.Json.JsonConvert.DeserializeObject<EM_SY_DEVICETYPE>(data);
            EM_SY_DEVICETYPE[] res = emModel.SY_DEVICETYPE.Read(node, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(res);
        }
        public string Delete_DEVICETYPE(int id)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_RETURN_UI mr = emModel.SY_DEVICETYPE.Delete(id, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(mr);
        }
        public string Insert_SY_SBBHMANUAL(string data,string SBBH)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_RETURN_UI mr = new MES_RETURN_UI();
            Sonluk.UI.Model.EM.SY_MANUALService.EM_SY_MANUAL[] manualList = Newtonsoft.Json.JsonConvert.DeserializeObject<Sonluk.UI.Model.EM.SY_MANUALService.EM_SY_MANUAL[]>(data);
            List<EM_SY_SBBHMANUAL> sbbhmanualList = new List<EM_SY_SBBHMANUAL>();
            for (int i = 0; i < manualList.Length; i++)
            {
                EM_SY_SBBHMANUAL node = new EM_SY_SBBHMANUAL();
                node.SBBH = SBBH;
                node.MANUALID = manualList[i].MANUALID;
                sbbhmanualList.Add(node);
            }
            for (int i = 0; i < sbbhmanualList.Count; i++)
            {
                EM_SY_SBBHMANUAL node = sbbhmanualList[i];
                EM_SY_SBBHMANUAL[] res = emModel.SY_SBBHMANUAL.Read(node,token);
                if (res.Length == 0)
                {
                   mr =  emModel.SY_SBBHMANUAL.Create(node, token);
                }
            }
            //MES_RETURN_UI mr = emModel.SY_SBBHMANUAL.Create(node, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(mr);
        }
        public string Update_SY_SBBHMANUAL(string data)
        {
            string token = AppClass.GetSession("token").ToString();
            EM_SY_SBBHMANUAL node = Newtonsoft.Json.JsonConvert.DeserializeObject<EM_SY_SBBHMANUAL>(data);
            MES_RETURN_UI mr = emModel.SY_SBBHMANUAL.Update(node, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(mr);
        }
        public string Read_SY_SBBHMANUAL(string data)
        {
            string token = AppClass.GetSession("token").ToString();
            EM_SY_SBBHMANUAL node = Newtonsoft.Json.JsonConvert.DeserializeObject<EM_SY_SBBHMANUAL>(data);
            EM_SY_SBBHMANUAL[] res = emModel.SY_SBBHMANUAL.Read(node, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(res);
        }
        public string Delete_SY_SBBHMANUAL(string data)
        {
            string token = AppClass.GetSession("token").ToString();
            EM_SY_SBBHMANUAL node = Newtonsoft.Json.JsonConvert.DeserializeObject<EM_SY_SBBHMANUAL>(data);
            MES_RETURN_UI mr = emModel.SY_SBBHMANUAL.Delete(node, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(mr);
        }
        public string Insert_SBBHDEVICETYPE(string data)
        {
            string token = AppClass.GetSession("token").ToString();
            EM_SY_SBBHDEVICETYPE node = Newtonsoft.Json.JsonConvert.DeserializeObject<EM_SY_SBBHDEVICETYPE>(data);
            EM_SY_SBBHDEVICETYPE node_del = new EM_SY_SBBHDEVICETYPE();
            node_del.SBBH = node_del.SBBH;
            emModel.SY_SBBHDEVICETYPE.Delete(node_del, token);
            MES_RETURN_UI mr = emModel.SY_SBBHDEVICETYPE.Create(node, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(mr);
        }
        public string Read_SBBHDEVICETYPE(string data)
        {
            string token = AppClass.GetSession("token").ToString();
            EM_SY_SBBHDEVICETYPE node = Newtonsoft.Json.JsonConvert.DeserializeObject<EM_SY_SBBHDEVICETYPE>(data);
            EM_SY_SBBHDEVICETYPELIST[] res = emModel.SY_SBBHDEVICETYPE.Read(node, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(res);
        }
        public string Insert_DEVICEDETAILDOC(string data)
        {
            string token = AppClass.GetSession("token").ToString();
            EM_SY_DEVICEDETAILDOC node = Newtonsoft.Json.JsonConvert.DeserializeObject<EM_SY_DEVICEDETAILDOC>(data);
            MES_RETURN_UI mr = emModel.SY_DEVICEDETAILDOC.Create(node, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(mr);
        }
        public string Update_DEVICEDETAILDOC(string data)
        {
            string token = AppClass.GetSession("token").ToString();
            EM_SY_DEVICEDETAILDOC node = Newtonsoft.Json.JsonConvert.DeserializeObject<EM_SY_DEVICEDETAILDOC>(data);
            MES_RETURN_UI mr = emModel.SY_DEVICEDETAILDOC.Update(node, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(mr);
        }
        public string Modify_SBBHMANUAL(string data, string SBBH)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_RETURN_UI mr = new MES_RETURN_UI();
            Sonluk.UI.Model.EM.SY_MANUALService.EM_SY_MANUAL[] nodes = Newtonsoft.Json.JsonConvert.DeserializeObject<Sonluk.UI.Model.EM.SY_MANUALService.EM_SY_MANUAL[]>(data);
            EM_SY_SBBHMANUAL sbbhnode = new EM_SY_SBBHMANUAL();
            sbbhnode.SBBH = SBBH;
            mr = emModel.SY_SBBHMANUAL.Delete(sbbhnode, token);
            if (data.Length == 0)
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(mr);
            }
            for (int i = 0; i < nodes.Length; i++)
            {
                EM_SY_SBBHMANUAL node = new EM_SY_SBBHMANUAL();
                node.SBBH = SBBH;
                node.MANUALID = nodes[i].MANUALID;
                node.XH = i + 1;
                mr = emModel.SY_SBBHMANUAL.Create(node, token);
            }
            //MES_RETURN_UI mr = emModel.SY_DEVICEDETAILDOC.Update(node, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(mr);
        }
        public string Read_DEVICEDETAILDOC(string data)
        {
            string token = AppClass.GetSession("token").ToString();
            EM_SY_DEVICEDETAILDOC node = Newtonsoft.Json.JsonConvert.DeserializeObject<EM_SY_DEVICEDETAILDOC>(data);
            EM_SY_DEVICEDETAILDOC[] res = emModel.SY_DEVICEDETAILDOC.Read(node, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(res);
        }
        public string Delete_DEVICEDETAILDOC(int id)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_RETURN_UI mr = emModel.SY_DEVICEDETAILDOC.Delete(id, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(mr);
        }
        public string Read_SY_DEVICEQRJL(string data)
        {
            string token = AppClass.GetSession("token").ToString();
            EM_SY_DEVICEQRJL node = Newtonsoft.Json.JsonConvert.DeserializeObject<EM_SY_DEVICEQRJL>(data);
            EM_SY_DEVICEQRJL[] res = emModel.SY_DEVICEQRJL.Read(node, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(res);
        }
        public string Create_PB(string data)
        {
            string token = AppClass.GetSession("token").ToString();
            EM_SY_PB node = Newtonsoft.Json.JsonConvert.DeserializeObject<EM_SY_PB>(data);
            MES_RETURN_UI res = emModel.SY_PB.Create(node, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(res);
        }
        public string Update_PB(string data)
        {
            string token = AppClass.GetSession("token").ToString();
            EM_SY_PB node = Newtonsoft.Json.JsonConvert.DeserializeObject<EM_SY_PB>(data);
            MES_RETURN_UI res = emModel.SY_PB.Update(node, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(res);
        }
        public string Read_PB(string data)
        {
            string token = AppClass.GetSession("token").ToString();
            EM_SY_PB node = Newtonsoft.Json.JsonConvert.DeserializeObject<EM_SY_PB>(data);
            EM_SY_PB[] res = emModel.SY_PB.Read(node, token);
            return AppClass.ModelConvertString(res);
        }
        public string Delete_PB(int PBID)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_RETURN_UI res = emModel.SY_PB.Delete(PBID, token);
            return AppClass.ModelConvertString(res);
        }
        public string Read_STAFFIDBINDPB(int PBID)
        {
            string token = AppClass.GetSession("token").ToString();
            EM_SY_STAFFIDBINDPB node = new EM_SY_STAFFIDBINDPB();
            node.PBID = PBID;
            EM_SY_STAFFIDBINDPB[] res = emModel.SY_STAFFIDBINDPB.Read(node, token);
            return AppClass.ModelConvertString(res);
        }
        public string Modify_STAFFIDBINDPB(string data,int PBID)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_SY_STAFF[] staffnodes = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_STAFF[]>(data);
            MES_RETURN_UI res = new MES_RETURN_UI();
            EM_SY_STAFFIDBINDPB delnode = new EM_SY_STAFFIDBINDPB();
            delnode.PBID = PBID;
            MES_RETURN_UI delres = emModel.SY_STAFFIDBINDPB.Delete(delnode, token);    
            if (staffnodes.Length == 0)
            {
                res = delres;
            }
            for (int i = 0; i < staffnodes.Length; i++)
            {
                EM_SY_STAFFIDBINDPB node = new EM_SY_STAFFIDBINDPB();
                node.PBID = PBID;
                node.STAFFID = staffnodes[i].STAFFID;
                res = emModel.SY_STAFFIDBINDPB.Create(node, token);
            }
            
            return Newtonsoft.Json.JsonConvert.SerializeObject(res);
        }
        public string Read_SBBINDPB(int PBID)
        {
            string token = AppClass.GetSession("token").ToString();
            EM_SY_SBBINDPB node = new EM_SY_SBBINDPB();
            node.PBID = PBID;
            EM_SY_SBBINDPB[] res = emModel.SY_SBBINDPB.Read(node, token);
            return AppClass.ModelConvertString(res);
        }
        public string Modify_SBBINDPB(string data, int PBID)
        {
            string token = AppClass.GetSession("token").ToString();
            EM_SY_SBBINDPB[] pbnodes = Newtonsoft.Json.JsonConvert.DeserializeObject<EM_SY_SBBINDPB[]>(data);
            MES_RETURN_UI res = new MES_RETURN_UI();
            EM_SY_SBBINDPB delnode = new EM_SY_SBBINDPB();
            delnode.PBID = PBID;
            MES_RETURN_UI delres = emModel.SY_SBBINDPB.Delete(delnode, token);
            if (pbnodes.Length == 0)
            {
                res = delres;
            }
            for (int i = 0; i < pbnodes.Length; i++)
            {
                EM_SY_SBBINDPB node = new EM_SY_SBBINDPB();
                node.PBID = PBID;
                node.SBBH = pbnodes[i].SBBH;
                res = emModel.SY_SBBINDPB.Create(node, token);
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(res);
        }



        public string SelectContact(int RYID)
        {
            string token = AppClass.GetSession("token").ToString();
            EM_SY_DEVICE_CONTRACT model = new EM_SY_DEVICE_CONTRACT();
            model.RYID = RYID;
            model.GC = "";
            model.GZZXBH = "";
            EM_SY_DEVICE_CONTRACT[] res = emModel.SY_DEVICE_CONTRACT.Read(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(res);
        }
        public string ModifyContact(string data, int RYID)
        {
            string token = AppClass.GetSession("token").ToString();
            EM_SY_DEVICE_CONTRACT[] nodes = Newtonsoft.Json.JsonConvert.DeserializeObject<EM_SY_DEVICE_CONTRACT[]>(data);
            EM_SY_DEVICE_CONTRACT deleteModel = new EM_SY_DEVICE_CONTRACT();
            deleteModel.RYID = RYID;
            MES_RETURN_UI delres = emModel.SY_DEVICE_CONTRACT.Delete(deleteModel, token);
            if (!delres.TYPE.Equals("S"))
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(delres.MESSAGE);
            }
            else
            {
                for (int i = 0; i < nodes.Length; i++)
                {
                    nodes[i].RYID = RYID;
                    MES_RETURN_UI res = emModel.SY_DEVICE_CONTRACT.Create(nodes[i], token);
                    if (!res.TYPE.Equals("S"))
                    {
                        return Newtonsoft.Json.JsonConvert.SerializeObject(res.MESSAGE);
                    }
                }
            }
            MES_RETURN_UI successRes = new MES_RETURN_UI();
            successRes.TYPE = "S";
            successRes.MESSAGE = "绑定成功!";
            return Newtonsoft.Json.JsonConvert.SerializeObject(successRes);
        }
        public string SELECT_XTBB(int ID)
        {
            string token = AppClass.GetSession("token").ToString();
            EM_SY_XTBB model = new EM_SY_XTBB();
            model.SYTYPE = ID;
            EM_SY_XTBB[] rst = emModel.SY_XTBB.Read(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        public ActionResult INSERT_EM()
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_SY_TYPEMX model = new MES_SY_TYPEMX();
            model.TYPEID = 24;
            MES_SY_TYPEMXLIST[] mxList = mesModels.SY_TYPEMX.SELECT(model, token);

            EM_SY_STAFF_EMTYPE rolemodel = new EM_SY_STAFF_EMTYPE();
            rolemodel.STAFFID = STAFFID;
            EM_SY_STAFF_EMTYPE[] roleList = emModel.SY_STAFF_EMTYPE.Read(rolemodel, token);


            AppClass.SetSession("location", 231);
            Session["TITLENAME"] = "添加电子指导书";
            ViewBag.mxList = mxList;
            ViewBag.roleList = roleList;
            return View();
        }
        public ActionResult SELECT_EM()
        {
            AppClass.SetSession("location", 232);
            Session["TITLENAME"] = "添加电子指导书";
            return View();
        }
        public ActionResult MODIFY_EM()
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_SY_TYPEMX model = new MES_SY_TYPEMX();
            model.TYPEID = 24;
            MES_SY_TYPEMXLIST[] mxList = mesModels.SY_TYPEMX.SELECT(model, token);

            
            model.TYPEID = 26;
            MES_SY_TYPEMXLIST[] languList = mesModels.SY_TYPEMX.SELECT(model, token);



            EM_SY_STAFF_EMTYPE rolemodel = new EM_SY_STAFF_EMTYPE();
            rolemodel.STAFFID = STAFFID;
            EM_SY_STAFF_EMTYPE[] roleList = emModel.SY_STAFF_EMTYPE.Read(rolemodel, token);
            ViewBag.mxList = mxList;
            ViewBag.roleList = roleList;
            ViewBag.langumxList = languList;
            AppClass.SetSession("location", 233);
            Session["TITLENAME"] = "修改电子指导书";
            return View();
        }



        public string UploadEMfile(string type, int typeID)
        {
            if (typeID == 0)
            {
                return "{\"code\":100,\"msg\":\"电子文档类别不能为空！！！\",\"scr\":\"\"}";
            }
            string res = "";
            switch (type)
            {
                case "包装作业指导书":
                    res = BZZY_DATA(typeID, type);
                    break;
                case "设备操作规程指导书":
                    res = SBZDS_DATA(typeID, type);
                    break;
                default:
                    break;
            }

            return res;
        }
        public string _SELECT_EMLIST(string in_tm)
        {

            return "";
        }
        /// <summary>
        /// 设备操作规程
        /// </summary>
        /// <param name="typeid"></param>
        /// <param name="typems"></param>
        /// <returns></returns>
        public string SBZDS_DATA(int typeid, string typems)
        {
            
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            var file = Request.Files[0];
            string name = file.FileName;
            Stream stream = file.InputStream;
            int bbid = 0;
            int langu = 0;
            string langums = "";
            string[] strList = name.Split(' ');
            if (strList.Length == 4)
            {
                MES_SY_TYPEMX languModel = new MES_SY_TYPEMX();
                languModel.TYPEID = 26;
                languModel.MXNAME = strList[2].Split('.')[0];
                string bb = strList[1];
                MES_SY_TYPEMXLIST[] langulist  = mesModels.SY_TYPEMX.SELECT(languModel, token);
                if (langulist.Length == 1)
                {
                    langu = langulist[0].ID;
                    langums = langulist[0].MXNAME;
                }
                else
                {
                   return "{\"code\":100,\"msg\":\"文件名中的语言版本不是有效的格式！！！\",\"scr\":\"\"}"; 
                }
               
                Sonluk.UI.Model.EM.SY_MANUALBBService.EM_SY_MANUALBB manualbbModel = new Sonluk.UI.Model.EM.SY_MANUALBBService.EM_SY_MANUALBB();
                Sonluk.UI.Model.EM.SY_MANUALService.EM_SY_MANUAL manualModel = new Sonluk.UI.Model.EM.SY_MANUALService.EM_SY_MANUAL();
                manualModel.TYPE = typeid;
                manualModel.MANUALMS = strList[0];
                Sonluk.UI.Model.EM.SY_MANUALService.EM_SY_MANUAL[] manualList = emModel.SY_MANUAL.Read(manualModel, token);
                if (manualList.Length == 0)
                {
                    manualModel.CJR = STAFFID;
                    MES_RETURN_UI rst = emModel.SY_MANUAL.Create(manualModel, token);
                    manualbbModel.MANUALID = Convert.ToInt32(rst.MESSAGE);

                }
                else
                {
                    manualbbModel.MANUALID = manualList[0].MANUALID;
                }

                //
                Sonluk.UI.Model.EM.SY_MANUALBBService.EM_SY_MANUALBB[] manualbblist = emModel.SY_MANUALBB.Read(manualbbModel, token);
                if (manualbblist.Length == 0)
                {
                    manualbbModel.BBNAME = bb;
                    manualbbModel.CJR = STAFFID;
                    manualbbModel.ISACTION = 1;
                    manualbbModel.LANGU = langu;
                    manualbbModel.LANGUMS = langums;
                    MES_RETURN_UI insertBBrst = emModel.SY_MANUALBB.Create(manualbbModel, token);
                    bbid = Convert.ToInt32(insertBBrst.MESSAGE);
                }
                else
                {
                    for (int i = 0; i < manualbblist.Length; i++)
                    {
                        Sonluk.UI.Model.EM.SY_MANUALBBService.EM_SY_MANUALBB node = manualbblist[i];
                        node.ISACTION = manualbblist[i].BBNAME == bb ? 1 : 0;
                        node.CJR = STAFFID;
                        MES_RETURN_UI rst = emModel.SY_MANUALBB.Update(node, token);
                    }
                    manualbbModel.BBNAME = bb;
                    Sonluk.UI.Model.EM.SY_MANUALBBService.EM_SY_MANUALBB[] manualbblist_s = emModel.SY_MANUALBB.Read(manualbbModel, token);
                    if (manualbblist_s.Length == 0)
                    {
                        manualbbModel.BBNAME = bb;
                        manualbbModel.CJR = STAFFID;
                        manualbbModel.ISACTION = 1;
                        manualbbModel.LANGU = langu;
                        manualbbModel.LANGUMS = langums;
                        MES_RETURN_UI insertBBrst = emModel.SY_MANUALBB.Create(manualbbModel, token);
                        bbid = Convert.ToInt32(insertBBrst.MESSAGE);
                    }
                    else if (manualbblist_s.Length == 1)
                    {
                        bbid = manualbblist_s[0].BBID;
                    }
                }

                //上传图片根据时间轴                              
                string[] arraystr = new string[] { DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString() };
                EM_SY_MANUALPATH pathmodel = new EM_SY_MANUALPATH();
                pathmodel.FILENAME = name;
                pathmodel.ISDELETE = 0;
                EM_SY_MANUALPATH[] pathList = emModel.SY_MANUALPATH.Read(pathmodel, token);
                if (pathList.Length == 1)
                {
                    return "{\"code\":100,\"msg\":\"查询到" + strList[0] + "版本为" + bb + "的相关信息已经存在请查看是否重复导入！！！\",\"scr\":\"\"}";
                }
                MES_RETURN_UI mr = emModel.FILE_PATH.Upload(typems, StreamToBytes(stream), name, arraystr);
                EM_SY_MANUALPATH manualpath = new EM_SY_MANUALPATH();
                if (!mr.TYPE.Equals("S"))
                {
                    return "{\"code\":100,\"msg\":\"上传失败！！！\",\"scr\":\"\"}";
                }

                EM_FILE_PATH file_path = emModel.FILE_PATH.Read(typems, token);
                manualpath.BBID = bbid;//得到版本的id
                manualpath.CFLJ = mr.MESSAGE;
                manualpath.CJR = STAFFID;
                manualpath.PATHID = file_path.PATHID;
                manualpath.ISACTION = 1;
                manualpath.FILENAME = name;
                manualpath.FILESIZE = (file.ContentLength / 1024.0).ToString(("f1")) + "kb";
                MES_RETURN_UI pathrst = emModel.SY_MANUALPATH.Create(manualpath, token);
                if (pathrst.TYPE.Equals("S"))
                {
                    return "{\"code\":0,\"msg\":\"上传成功！！！\",\"scr\":\"\"}";
                }
                else
                {
                    return "{\"code\":0,\"msg\":\"新增数据库信息失败！！！\",\"scr\":\"\"}";
                }



            }


            return "{\"code\":100,\"msg\":\"读取图片信息格式不正确！！！\",\"scr\":\"\"}"; ;
        }
        /// <summary>
        /// 包装作业指导书
        /// </summary>
        /// <returns></returns>
        public string BZZY_DATA(int typeid, string typems)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            var file = Request.Files[0];
            string name = file.FileName;
            Stream stream = file.InputStream;
            int bbid = 0;

            string[] strList = name.Split(' ');

            if (strList.Length > 1)
            {
                //string werks = "1000";  //现在默认暂时1000
                string werks = "";//工厂非必输
                string tm = strList[0];
                if (tm.Length != 10)
                {
                    return "{\"code\":100,\"msg\":\"条码" + tm + "长度不等于10位,请核实！！！\",\"scr\":\"\"}";
                }
                string bb = strList[1];
                if (bb.Length > 5)
                {
                    return "{\"code\":100,\"msg\":\"条码版本" + bb + "长度大于5位,请核实！！！\",\"scr\":\"\"}";
                }

                MES_SY_MATERIAL_INSERT_LIST wlxxrst = mesModels.MES_MM.GET_WLXXBYGROUP(werks, "", tm, "F02", token);
                if (wlxxrst.MES_RETURN.MESSAGE.Equals("无相关数据."))
                {
                    if (wlxxrst.MES_SY_MATERIAL.Length != 1)
                    {
                        return "{\"code\":100,\"msg\":\"没有查询到" + tm + "相关信息！！！\",\"scr\":\"\"}";

                    }
                }

                Sonluk.UI.Model.EM.SY_MANUALService.EM_SY_MANUAL manualModel = new Sonluk.UI.Model.EM.SY_MANUALService.EM_SY_MANUAL();
                manualModel.TM = tm;
                Sonluk.UI.Model.EM.SY_MANUALService.EM_SY_MANUAL[] manualList = emModel.SY_MANUAL.Read(manualModel, token);
                Sonluk.UI.Model.EM.SY_MANUALBBService.EM_SY_MANUALBB manualbbModel = new Sonluk.UI.Model.EM.SY_MANUALBBService.EM_SY_MANUALBB();
                if (manualList.Length == 0)
                {
                    manualModel.GC = werks;
                    manualModel.TYPE = typeid;
                    manualModel.MANUALMS = wlxxrst.MES_SY_MATERIAL[0].WLMS;
                    manualModel.CJR = STAFFID;
                    MES_RETURN_UI rst = emModel.SY_MANUAL.Create(manualModel, token);
                    manualbbModel.MANUALID = Convert.ToInt32(rst.MESSAGE);
                }
                else
                {
                    manualbbModel.MANUALID = manualList[0].MANUALID;
                }
                //manualbbModel.BBNAME = bb;
                Sonluk.UI.Model.EM.SY_MANUALBBService.EM_SY_MANUALBB[] manualbblist = emModel.SY_MANUALBB.Read(manualbbModel, token);
                if (manualbblist.Length == 0)
                {
                    manualbbModel.BBNAME = bb;
                    manualbbModel.CJR = STAFFID;
                    manualbbModel.ISACTION = 1;
                    manualbbModel.TM = tm + manualbbModel.BBNAME;
                    manualbbModel.LANGUMS = "";
                    manualbbModel.LANGU = 0;
                    MES_RETURN_UI insertBBrst = emModel.SY_MANUALBB.Create(manualbbModel, token);
                    bbid = Convert.ToInt32(insertBBrst.MESSAGE);
                }
                else
                {
                    for (int i = 0; i < manualbblist.Length; i++)
                    {
                        Sonluk.UI.Model.EM.SY_MANUALBBService.EM_SY_MANUALBB node = manualbblist[i];
                        node.ISACTION = manualbblist[i].BBNAME == bb ? 1 : 0;
                        node.CJR = STAFFID;
                        MES_RETURN_UI rst = emModel.SY_MANUALBB.Update(node, token);
                    }
                    manualbbModel.BBNAME = bb;
                    Sonluk.UI.Model.EM.SY_MANUALBBService.EM_SY_MANUALBB[] manualbblist_s = emModel.SY_MANUALBB.Read(manualbbModel, token);
                    if (manualbblist_s.Length == 0)
                    {
                        manualbbModel.BBNAME = bb;
                        manualbbModel.CJR = STAFFID;
                        manualbbModel.ISACTION = 1;
                        manualbbModel.TM = tm + manualbbModel.BBNAME;
                        manualbbModel.LANGUMS = "";
                        manualbbModel.LANGU = 0;
                        MES_RETURN_UI insertBBrst = emModel.SY_MANUALBB.Create(manualbbModel, token);
                        bbid = Convert.ToInt32(insertBBrst.MESSAGE);
                    }
                    else if (manualbblist_s.Length == 1)
                    {
                        bbid = manualbblist_s[0].BBID;
                    }
                }




                //上传图片根据时间轴                              
                string[] arraystr = new string[] { DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString() };
                EM_SY_MANUALPATH pathmodel = new EM_SY_MANUALPATH();
                pathmodel.FILENAME = name;
                pathmodel.ISDELETE = 0;
                EM_SY_MANUALPATH[] pathList = emModel.SY_MANUALPATH.Read(pathmodel, token);
                if (pathList.Length == 1)
                {
                    return "{\"code\":100,\"msg\":\"查询到" + tm + "版本为" + bb + "的相关信息已经存在请查看是否重复导入！！！\",\"scr\":\"\"}";
                }
                MES_RETURN_UI mr = emModel.FILE_PATH.Upload(typems, StreamToBytes(stream), name, arraystr);
                EM_SY_MANUALPATH manualpath = new EM_SY_MANUALPATH();
                if (!mr.TYPE.Equals("S"))
                {
                    return "{\"code\":100,\"msg\":\"上传失败！！！\",\"scr\":\"\"}";
                }
                EM_FILE_PATH file_path = emModel.FILE_PATH.Read(typems, token);
                manualpath.BBID = bbid;//得到版本的id
                manualpath.CFLJ = mr.MESSAGE;
                manualpath.CJR = STAFFID;
                manualpath.PATHID = file_path.PATHID;
                manualpath.ISACTION = 1;
                manualpath.FILENAME = name;
                manualpath.FILESIZE = (file.ContentLength / 1024.0).ToString(("f1")) + "kb";
                MES_RETURN_UI pathrst = emModel.SY_MANUALPATH.Create(manualpath, token);
                if (pathrst.TYPE.Equals("S"))
                {
                    return "{\"code\":0,\"msg\":\"上传成功！！！\",\"scr\":\"\"}";
                }
                else
                {
                    return "{\"code\":0,\"msg\":\"新增数据库信息失败！！！\",\"scr\":\"\"}";
                }
            }
            return "{\"code\":100,\"msg\":\"读取图片信息异常！！！\",\"scr\":\"\"}"; ;
        }
        [HttpPost]
        public string SELECTPATHbyID(int ID)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            EM_SY_MANUALPATH model = new EM_SY_MANUALPATH();
            model.ID = ID;
            EM_SY_MANUALPATH[] res = emModel.SY_MANUALPATH.Read(model, token);
            Session["downphoto"] = res[0];
            return Newtonsoft.Json.JsonConvert.SerializeObject(res);
        }
        public string SelectPathConvertUrl(int ID)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            int address = 0;
            string url = Request.Url.ToString();
            if (url.IndexOf("192.168") != -1 || url.IndexOf("localhost") != -1)
            {

            }
            else
            {
                address = 1;
            }

            MES_RETURN_UI rst = emModel.FILE_PATH.GetURLByReadID(ID, token);
            if (!rst.TYPE.Equals("E"))
            {
                if (address == 1)
                {
                    rst.TYPE = rst.MESSAGE;
                }
                else
                {

                }
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);

        }
        public string SelectManualBBbyMANUALID(int MANUALID)
        {
            string token = AppClass.GetSession("token").ToString();
            UI.Model.EM.SY_MANUALBBService.EM_SY_MANUALBB model = new UI.Model.EM.SY_MANUALBBService.EM_SY_MANUALBB();
            model.MANUALID = MANUALID;
            UI.Model.EM.SY_MANUALBBService.EM_SY_MANUALBB[] rst = emModel.SY_MANUALBB.Read(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        public string SelectManual(int emtype, string tm)
        {
            string token = AppClass.GetSession("token").ToString();
            UI.Model.EM.SY_MANUALService.EM_SY_MANUAL manualmodel = new UI.Model.EM.SY_MANUALService.EM_SY_MANUAL();
            if (tm == "设备操作规程指导书")
            {
                MES_SY_TYPEMX node= new MES_SY_TYPEMX();
                node.MXNAME = tm;
                node.TYPEID = 24;
                MES_SY_TYPEMXLIST[] res = mesModels.SY_TYPEMX.SELECT(node, token);
                emtype = mesModels.SY_TYPEMX.SELECT(node, token)[0].ID;
            }
            else
            {
                
                Regex regex = new Regex(@"^[0-9]*$");
                if (regex.IsMatch(tm))
                {
                    manualmodel.TM = tm;
                }
                else
                {
                    manualmodel.MANUALMS = tm;
                }            
            }
            manualmodel.TYPE = emtype;          
            UI.Model.EM.SY_MANUALService.EM_SY_MANUAL[] rst = emModel.SY_MANUAL.Read(manualmodel, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        public string DeleteManaual(int MANUALID)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_RETURN_UI manualrst = emModel.SY_MANUAL.Delete(MANUALID, token);
            if (!manualrst.TYPE.Equals("S"))
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(manualrst);
            }
            UI.Model.EM.SY_MANUALBBService.EM_SY_MANUALBB manualbbmodel = new UI.Model.EM.SY_MANUALBBService.EM_SY_MANUALBB();
            manualbbmodel.MANUALID = MANUALID;
            UI.Model.EM.SY_MANUALBBService.EM_SY_MANUALBB[] manualbblist = emModel.SY_MANUALBB.Read(manualbbmodel, token);
            EM_SY_MANUALPATH pathmodel = new EM_SY_MANUALPATH();
            List<string> filenameArr = new List<string>();
            for (int i = 0; i < manualbblist.Length; i++)
            {
                emModel.SY_MANUALBB.Delete(manualbblist[i].BBID, token);
                pathmodel.BBID = manualbblist[i].BBID;
                EM_SY_MANUALPATH[] pathrst = emModel.SY_MANUALPATH.Read(pathmodel, token);

                for (int j = 0; j < pathrst.Length; j++)
                {
                    emModel.SY_MANUALPATH.Delete(pathrst[j].ID, token);
                    EM_FILE_PATH path = emModel.FILE_PATH.Readbypathid(pathrst[j].PATHID, token);
                    filenameArr.Add(path.PATH + "//" + pathrst[j].CFLJ);
                }

            }

            MES_RETURN_UI rst = emModel.FILE_PATH.DeleteFileService(filenameArr.ToArray());



            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        public string UpdateManual(string data)
        {
            string token = AppClass.GetSession("token").ToString();
            UI.Model.EM.SY_MANUALService.EM_SY_MANUAL model = Newtonsoft.Json.JsonConvert.DeserializeObject<UI.Model.EM.SY_MANUALService.EM_SY_MANUAL>(data);
            MES_RETURN_UI rst = emModel.SY_MANUAL.Update(model, token);

            UI.Model.EM.SY_MANUALBBService.EM_SY_MANUALBB bbmodel = new UI.Model.EM.SY_MANUALBBService.EM_SY_MANUALBB();
            bbmodel.MANUALID = model.MANUALID;
            UI.Model.EM.SY_MANUALBBService.EM_SY_MANUALBB[] bbrst = emModel.SY_MANUALBB.Read(bbmodel, token);
            for (int i = 0; i < bbrst.Length; i++)
            {
                bbrst[i].TM = model.TM + bbrst[i].BBNAME;
                emModel.SY_MANUALBB.Update(bbrst[i], token);
            }




            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        public string UpdateManaualBB(string data)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            try
            {
                string token = AppClass.GetSession("token").ToString();
                UI.Model.EM.SY_MANUALBBService.EM_SY_MANUALBB model = Newtonsoft.Json.JsonConvert.DeserializeObject<UI.Model.EM.SY_MANUALBBService.EM_SY_MANUALBB>(data);
                if (model.ISACTION == 0)
                {
                    model.ISACTION = 1;
                    UI.Model.EM.SY_MANUALBBService.EM_SY_MANUALBB readmodel = new UI.Model.EM.SY_MANUALBBService.EM_SY_MANUALBB();
                    readmodel.MANUALID = model.MANUALID;
                    UI.Model.EM.SY_MANUALBBService.EM_SY_MANUALBB[] rstmodel = emModel.SY_MANUALBB.Read(readmodel, token);
                    for (int i = 0; i < rstmodel.Length; i++)
                    {
                        rstmodel[i].ISACTION = 0;
                        emModel.SY_MANUALBB.Update(rstmodel[i], token);
                    }
                }
                else
                {
                    model.ISACTION = 0;

                }
                emModel.SY_MANUALBB.Update(model, token);
                rst.TYPE = "S";

            }
            catch (Exception e)
            {

                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
            }



            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        public string DeleteManaualBB(int BBID)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_RETURN_UI rst = emModel.SY_MANUALBB.Delete(BBID, token);
            EM_SY_MANUALPATH pathmodel = new EM_SY_MANUALPATH();
            pathmodel.BBID = BBID;
            List<string> filenameArr = new List<string>();
            EM_SY_MANUALPATH[] pathrst = emModel.SY_MANUALPATH.Read(pathmodel, token);

            for (int i = 0; i < pathrst.Length; i++)
            {
                emModel.SY_MANUALPATH.Delete(pathrst[i].ID, token);
                EM_FILE_PATH path = emModel.FILE_PATH.Readbypathid(pathrst[i].PATHID, token);
                filenameArr.Add(path.PATH + "//" + pathrst[i].CFLJ);
            }



            rst = emModel.FILE_PATH.DeleteFileService(filenameArr.ToArray());
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        public string SelectEM_SY_MANUALPATHByBBID(int BBID)
        {
            string token = AppClass.GetSession("token").ToString();
            EM_SY_MANUALPATH model = new EM_SY_MANUALPATH();
            model.BBID = BBID;
            EM_SY_MANUALPATH[] rst = emModel.SY_MANUALPATH.Read(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }

        public string DeleteEM_SY_MANUALPATH(string data)
        {
            string token = AppClass.GetSession("token").ToString();
            EM_SY_MANUALPATH model = Newtonsoft.Json.JsonConvert.DeserializeObject<EM_SY_MANUALPATH>(data);
            string[] filename = new string[1] { model.CFLJ };
            emModel.FILE_PATH.DeleteFileService(filename);

            MES_RETURN_UI rst = emModel.SY_MANUALPATH.Delete(model.ID, token);
            List<string> filenameArr = new List<string>();

            EM_FILE_PATH path = emModel.FILE_PATH.Readbypathid(model.PATHID, token);
            filenameArr.Add(path.PATH + "//" + model.CFLJ);




            rst = emModel.FILE_PATH.DeleteFileService(filenameArr.ToArray());

            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }

        public string MISSION_Read(string data)
        {
            //ZSD_XBZ_MAINRESULT  //ZSD_XBZ_MAINRESULT 
            string token = AppClass.GetSession("token").ToString();
            EM_MISSION_IMPORT model = Newtonsoft.Json.JsonConvert.DeserializeObject<EM_MISSION_IMPORT>(data);
            ZSD_XBZ_MAINRESULT node = new ZSD_XBZ_MAINRESULT();
            node.EM_MISSION_IMPORT = model;
            ZSD_XBZ_MAINRESULT res = emModel.EM_MISSION.ZSD_XBZ_MAIN_Read(node, token);
            for (int i = 0; i < res.ET_TABLE_PLUS.Length; i++)
            {
                UI.Model.EM.SY_MANUALService.EM_SY_MANUAL manualmodel = new UI.Model.EM.SY_MANUALService.EM_SY_MANUAL();
                manualmodel.TM = res.ET_TABLE_PLUS[i].MATNR;
                manualmodel.ISDELETE = 0;
                //manualmodel.TYPENAME = "包装作业指导书";
                UI.Model.EM.SY_MANUALService.EM_SY_MANUAL[] manuallist = emModel.SY_MANUAL.Read(manualmodel,token);
                if (manuallist.Length == 1)
                {
                    res.ET_TABLE_PLUS[i].BBNAME = manuallist[0].BBNAME;
                    res.ET_TABLE_PLUS[i].BBUPDATETIME = manuallist[0].JLTIME;
                }
                else
                {
                    res.ET_TABLE_PLUS[i].BBNAME = "";
                    res.ET_TABLE_PLUS[i].BBUPDATETIME = "";
                }
                //emModel.SY_MANUALBB.Read()
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(res);
        }
        public string MISSION_Read_Unfinish(string data)
        {
            //string token = AppClass.GetSession("token").ToString();
            EM_MISSION_IMPORT model = Newtonsoft.Json.JsonConvert.DeserializeObject<EM_MISSION_IMPORT>(data);
            ZSD_XBZ_MAINRESULT node = new ZSD_XBZ_MAINRESULT();
            node.EM_MISSION_IMPORT = new EM_MISSION_IMPORT();
            node.EM_MISSION_IMPORT.MATNR = model.MATNR;
            node.EM_MISSION_IMPORT.STATUSSTR = "1,2";
            //node.EM_MISSION_IMPORT.
            string res = AppClass.EasyCall<ZSD_XBZ_MAINRESULT, ZSL_SDT075_PLUS[]>(node, (postdata, token) => { return emModel.EM_MISSION.ZSD_XBZ_MAIN_Read(postdata, token).ET_TABLE_PLUS; });
            return res;        
        }
        public string MISSION_Update(string data,string STATUS)
        {
            string token = AppClass.GetSession("token").ToString();
            string xgr = Session["NAME"].ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            ZSL_SDT075[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<ZSL_SDT075[]>(data);
            for (int i = 0; i < model.Length; i++)
            {
                model[i].XGR = xgr;
                if (model[i].STATUS == "1" && STATUS == "2")
                {
                       //model[i].MATNR
                    UI.Model.EM.SY_MANUALService.EM_SY_MANUAL manualmodel = new UI.Model.EM.SY_MANUALService.EM_SY_MANUAL();
                    manualmodel.TM = model[i].MATNR;
                    UI.Model.EM.SY_MANUALService.EM_SY_MANUAL[] manualrst = emModel.SY_MANUAL.Read(manualmodel, token);
                    if (manualrst.Length == 1)
                    {
                        int manualid = manualrst[0].MANUALID;
                        UI.Model.EM.SY_MANUALBBService.EM_SY_MANUALBB bbmodel = new UI.Model.EM.SY_MANUALBBService.EM_SY_MANUALBB();
                        bbmodel.MANUALID = manualid;
                        //bbmodel.CJR = STAFFID;
                        //bbmodel.CJRNAME = xgr;
                        //bbmodel.ISACTION = 0;                       
                        UI.Model.EM.SY_MANUALBBService.EM_SY_MANUALBB[] bbrst = emModel.SY_MANUALBB.Read(bbmodel,token);
                        for (int j  = 0;j < bbrst.Length; j++)
                        {
                           
                            bbrst[j].ISACTION = 0;
                            bbrst[j].CJR = STAFFID;
                            emModel.SY_MANUALBB.Update(bbrst[j], token);
                        }
                    }
                }
                model[i].STATUS = STATUS;
            }
            ZSD_XBZ_MAINRESULT node = new ZSD_XBZ_MAINRESULT();
            node.EM_MISSION_IMPORT = new EM_MISSION_IMPORT();
            //node.EM_MISSION_IMPORT.FUNTYPE = "U";
            node.ET_TABLE = model;
            node.MES_RETURN = new UI.Model.EM.EM_MISSIONService.MES_RETURN();
            ZSD_XBZ_MAINRESULT res = emModel.EM_MISSION.ZSD_XBZ_MAIN_UPDATE(node, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(res);
        }

        public string MISSION_MX_SELECT(string data)
        {
            string token = AppClass.GetSession("token").ToString();
            ZSD_XBZ_CHANGEINFORESULT res = emModel.EM_MISSION.ZSD_XBZ_CHANGEINFO_Read(data, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(res);
        }









        public ActionResult ReadByTm(string tm)
        {
            string token = AppClass.GetSession("token").ToString();
            //if (tm.Length == 10)
            //{
            //    MES_SY_TYPEMX model = new MES_SY_TYPEMX();
            //    model.TYPEID = 24;
            //    model.MXNAME = "包装作业指导书";
            //    MES_SY_TYPEMXLIST[] mxList = mesModels.SY_TYPEMX.SELECT(model, token);
            //    tm = tm + "-" + mxList[0].ID;
            //}
           

            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            EM_SY_MANUALPATH_SELECT res = emModel.SY_MANUALPATH.ReadBYTM(tm, token, STAFFID);
            //return Newtonsoft.Json.JsonConvert.SerializeObject(res);
            ViewBag.EM_SY_MANUALPATH_SELECT = res;
            return View();
        }
        public FileResult downphoto()
        {
            string token = AppClass.GetSession("token").ToString();
            EM_SY_MANUALPATH pathmodel = (EM_SY_MANUALPATH)Session["downphoto"];
            UI.Model.EM.SY_MANUALBBService.EM_SY_MANUALBB bbmodel = new UI.Model.EM.SY_MANUALBBService.EM_SY_MANUALBB();
            bbmodel.BBID = pathmodel.BBID;
            bbmodel = emModel.SY_MANUALBB.Read(bbmodel, token)[0];
            UI.Model.EM.SY_MANUALService.EM_SY_MANUAL manualmodel = new UI.Model.EM.SY_MANUALService.EM_SY_MANUAL();
            manualmodel.MANUALID = bbmodel.MANUALID;
            manualmodel = emModel.SY_MANUAL.Read(manualmodel, token)[0];

            EM_FILE_PATH pathrst = emModel.FILE_PATH.Read(manualmodel.TYPENAME, token);
            string fileURL = pathrst.PATH + pathmodel.CFLJ;
            string name = pathmodel.FILENAME;
            FileInfo fileInfo = new FileInfo(fileURL);
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=" + Server.UrlEncode(name));//文件名
            Response.AddHeader("content-length", fileInfo.Length.ToString());//文件大小
            Response.ContentType = "application/octet-stream";
            Response.ContentEncoding = System.Text.Encoding.Default;
            Response.WriteFile(fileURL);
            return null;
        }

       




















        public byte[] StreamToBytes(Stream stream)
        {

            byte[] bytes = new byte[stream.Length];

            stream.Read(bytes, 0, bytes.Length);

            // 设置当前流的位置为流的开始 

            stream.Seek(0, SeekOrigin.Begin);

            return bytes;

        }
        public string UP()
        {
            try
            {
                string path = @"\\192.168.8.39\zwk";
                string path2 = @"E:\5";
                DirectoryInfo root = new DirectoryInfo(path);
                FileInfo[] files = root.GetFiles();
                for (int i = 0; i < files.Length; i++)
                {
                    if (files[i].Exists)
                    {
                        files[i].CopyTo(path2 + "\\" + files[i].Name, true);
                    }
                }
                return files.Length.ToString();
            }
            catch (Exception e)
            {
                
                return e.Message;
            }
           
           

            
        }
    }
}
