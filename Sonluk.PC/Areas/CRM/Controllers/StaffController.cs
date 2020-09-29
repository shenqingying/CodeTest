using Newtonsoft.Json;
using Sonluk.PC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sonluk.UI.Model.CRM.HG_STAFFService;
using Sonluk.UI.Model.CRM.HG_DICTService;
using Sonluk.UI.Model.CRM.HG_DEPTService;
using Sonluk.UI.Model.CRM.HG_BZGZSJService;
using Sonluk.UI.Model.CRM.KQ_GZRLService;
using Sonluk.UI.Model.CRM.HG_KQDZService;
using Sonluk.UI.Model.CRM.HG_RYKQService;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;
using System.Data;
using System.Web.Security;
using Sonluk.PC.APPCLASS;
using Sonluk.UI.Model.CRM.COST_CBZXService;

namespace Sonluk.PC.Areas.CRM.Controllers
{
    public class StaffController : Controller
    {
        //
        // GET: /CRM/Staff/

        CRMModels crmModels = new CRMModels();
        string token = "";
        string FileSavePath = System.Configuration.ConfigurationManager.AppSettings["FileSavePath"];
        AppClass appclass = new AppClass();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Insert()
        {
            Session["location"] = 9;
            //return PartialView("Insert");
            return View();
        }

        public ActionResult Select()
        {
            token = appclass.CRM_Gettoken();
            Session["location"] = 10;
            //return PartialView("Select");

            CRM_HG_DEPT[] DEPTdata = crmModels.HG_DEPT.Read(token);
            ViewBag.DEPTdata = DEPTdata;

            CRM_HG_DICT[] JOB = crmModels.HG_DICT.Read(13, 0, token);
            CRM_HG_DICT[] POST = crmModels.HG_DICT.Read(14, 0, token);
            CRM_HG_DICT[] XUELI = crmModels.HG_DICT.Read(16, 0, token);
            CRM_HG_DICT[] STAFFTYPE = crmModels.HG_DICT.Read(33, 0, token);

            ViewBag.JOB = JOB;
            ViewBag.POST = POST;
            ViewBag.XUELI = XUELI;
            ViewBag.STAFFTYPE = STAFFTYPE;



            return View();
        }

        public ActionResult Daoru()
        {
            Session["location"] = 11;
            //return PartialView("Daoru");
            return View();
        }

        public ActionResult Manager()
        {
            Session["location"] = 45;
            //return PartialView("Confirm");
            return View();
        }

        public ActionResult Confirm()
        {
            Session["location"] = 12;
            //return PartialView("Confirm");
            return View();
        }

        public ActionResult Update()
        {
            token = appclass.CRM_Gettoken();
            CRM_HG_DICT[] FGLD = crmModels.HG_DICT.Read(81, 0, token);
            CRM_HG_DICT[] SF = crmModels.HG_DICT.Read(82, 0, token);
            CRM_COST_CBZX[] CBZX = crmModels.COST_CBZX.ReadByParam(new CRM_COST_CBZX(), token);
            ViewBag.FGLD = FGLD;
            ViewBag.SF = SF;
            ViewBag.CBZX = CBZX;
            return PartialView("Update");
        }

        [HttpPost]
        public int Data_Insert(string data)          //新增人员信息
        {
            //JavaScriptSerializer js = new JavaScriptSerializer();
            //crmModels = js.Deserialize<CRMModels>(data);

            //crmModels = ParseFromJson<CRMModels>(data);

            token = appclass.CRM_Gettoken();

            CRM_HG_STAFF crmmodel = JsonConvert.DeserializeObject<CRM_HG_STAFF>(data);
            crmmodel.STAFFPW = FormsAuthentication.HashPasswordForStoringInConfigFile(crmmodel.STAFFPW, "MD5").ToLower();
            crmmodel.USERLX = 1108;
            int id = crmModels.HG_STAFF.Create(crmmodel, token);

            return id;
        }

        [HttpPost]
        public string Data_Load_Dropdown(int typeid, int fid)         //下拉框选项加载
        {
            token = appclass.CRM_Gettoken();
            CRM_HG_DICT[] list = crmModels.HG_DICT.Read(typeid, fid, token);
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(list);

            return json;
        }

        [HttpPost]
        public string Data_Select_Depart()             //查询出部门     部门下拉框专用
        {
            token = appclass.CRM_Gettoken();
            CRM_HG_DEPT[] data = crmModels.HG_DEPT.Read(token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public string Data_Select_DepartmentByStaffid()
        {
            token = appclass.CRM_Gettoken();
            CRM_HG_DEPT[] data = crmModels.HG_DEPT.ReadByStaffid(Convert.ToInt32(Session["STAFFID"]), token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Select_DEPT()             //查询出所有权限内的部门
        {
            token = appclass.CRM_Gettoken();
            CRM_HG_DEPT[] data = crmModels.HG_DEPT.ReadByStaffid(Convert.ToInt32(Session["STAFFID"]), token);
            LayuiTree[] result = new LayuiTree[data.Length];

            for (int i = 0; i < data.Length; i++)           //把查询出来的数据转换成layui属性列表要求的格式
            {
                result[i] = new LayuiTree();
                result[i].Id = data[i].DEPID;
                result[i].Pid = data[i].PDEPID;
                result[i].title = data[i].DEPNAME;
                //result[i].Khjlid = data[i].KHJLID;
                //result[i].Fgldid = data[i].FGLDID;
                //result[i].Gmemo = data[i].GMEMO;
            }
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(result);
            return s;
        }

        [HttpPost]
        public string Data_Select_Banci()             //查询出班次     班次下拉框专用
        {
            token = appclass.CRM_Gettoken();
            CRM_HG_BZGZSJ[] data = crmModels.HG_BZGZSJ.Read(0, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public string Data_Select_Rili()             //查询出日历     日历下拉框专用
        {
            token = appclass.CRM_Gettoken();
            CRM_KQ_GZRL[] data = crmModels.KQ_GZRL.Read("", 0, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public string Data_Select(string data)          //查询人员列表
        {
            token = appclass.CRM_Gettoken();
            Sonluk.UI.Model.CRM.HG_STAFFService.CRM_Report_STAFFModel report_model = JsonConvert.DeserializeObject<Sonluk.UI.Model.CRM.HG_STAFFService.CRM_Report_STAFFModel>(data);
            report_model.STAFFID = appclass.CRM_GetStaffid();
            Sonluk.UI.Model.CRM.HG_STAFFService.CRM_HG_STAFFList[] list = crmModels.HG_STAFF.Report(report_model, "staff", token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(list);
            return s;
        }

        [HttpPost]
        public string Data_Select_ByID(int id)           //打开编辑页面时加载客户基本信息
        {
            token = appclass.CRM_Gettoken();
            //Sonluk.UI.Model.CRM.HG_STAFFService.CRM_HG_STAFFList[] list = crmModels.HG_STAFF.Read(id, token);
            Sonluk.UI.Model.CRM.HG_STAFFService.CRM_HG_STAFF model = crmModels.HG_STAFF.ReadBySTAFFID(id, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(model);
            return s;
        }

        [HttpPost]
        public int Data_Delete(int id)                //删除人员信息,只是逻辑删除
        {
            token = appclass.CRM_Gettoken();
            int i = crmModels.HG_STAFF.Delete(id, token);
            return i;
        }

        [HttpPost]
        public int Data_Update(string data)            //修改客户信息
        {
            token = appclass.CRM_Gettoken();
            Sonluk.UI.Model.CRM.HG_STAFFService.CRM_HG_STAFF model = JsonConvert.DeserializeObject<Sonluk.UI.Model.CRM.HG_STAFFService.CRM_HG_STAFF>(data);
            int count = crmModels.HG_STAFF.Update(model, token);
            return count;
        }
        [HttpPost]
        public string Data_Select_KQDZ(int id)                //查询考勤地址
        {
            token = appclass.CRM_Gettoken();

            CRM_HG_KQDZ[] data = crmModels.HG_KQDZ.ReadBySTAFFID(id, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);

            return s;
        }
        [HttpPost]
        public string Data_Select_address_name(string KQDZ)                //根据考勤地址名称查询考勤地址
        {
            token = appclass.CRM_Gettoken();

            CRM_HG_KQDZ[] data = crmModels.HG_KQDZ.ReadBylikeKQDZ(KQDZ, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);

            return s;
        }
        [HttpPost]
        public int Data_RYKQ_Insert(int STAFFID, int KQDZID)          //人员考勤信息
        {
            //JavaScriptSerializer js = new JavaScriptSerializer();
            //crmModels = js.Deserialize<CRMModels>(data);

            //crmModels = ParseFromJson<CRMModels>(data);
            token = appclass.CRM_Gettoken();
            int id = crmModels.HG_RYKQ.Create(STAFFID, KQDZID, token);

            return id;
        }
        [HttpPost]
        public int Data_RYKQ_Delete(int STAFFID, int KQDZID)          //人员考勤信息删除
        {
            //JavaScriptSerializer js = new JavaScriptSerializer();
            //crmModels = js.Deserialize<CRMModels>(data);

            //crmModels = ParseFromJson<CRMModels>(data);
            token = appclass.CRM_Gettoken();
            int id = crmModels.HG_RYKQ.Delete(STAFFID, KQDZID, token);

            return id;
        }

        [HttpPost]
        public string Data_Select_KQDZLIST(string data)          //查询未审核的考勤地址
        {
            token = appclass.CRM_Gettoken();
            Sonluk.UI.Model.CRM.HG_KQDZService.CRM_HG_KQDZList model = JsonConvert.DeserializeObject<Sonluk.UI.Model.CRM.HG_KQDZService.CRM_HG_KQDZList>(data);
            Sonluk.UI.Model.CRM.HG_KQDZService.CRM_HG_KQDZList[] list = crmModels.HG_KQDZ.Report(model, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(list);
            return s;
        }

        [HttpPost]
        public int Data_KQDZ_Update(string data)            //考勤地址修改、审核
        {
            token = appclass.CRM_Gettoken();
            Sonluk.UI.Model.CRM.HG_KQDZService.CRM_HG_KQDZ model = JsonConvert.DeserializeObject<Sonluk.UI.Model.CRM.HG_KQDZService.CRM_HG_KQDZ>(data);
            int count = crmModels.HG_KQDZ.Update(model, token);
            return count;
        }

        [HttpPost]
        public int Data_Delete_KQDZ(int id)                //删除考勤地址,只是逻辑删除
        {
            token = appclass.CRM_Gettoken();
            int i = crmModels.HG_KQDZ.Delete(id, token);
            return i;
        }

        [HttpPost]
        public int Data_KQDZ_Create(string data, string SF, string CS)            //考勤地址新增
        {
            token = appclass.CRM_Gettoken();

            Sonluk.UI.Model.CRM.HG_KQDZService.CRM_HG_KQDZ model = JsonConvert.DeserializeObject<Sonluk.UI.Model.CRM.HG_KQDZService.CRM_HG_KQDZ>(data);
            model.STAFFID = Convert.ToInt32(Session["STAFFID"]);
            model.SF = crmModels.HG_DICT.ReadByDICNAME(SF, 1, token);
            model.CS = crmModels.HG_DICT.ReadByDICNAME(CS, 2, token);

            int count = crmModels.HG_KQDZ.Create(model, token);
            return count;
        }

        [HttpPost]
        public string Data_Delete_File(string name)
        {
            //Thread.Sleep(5000);
            try
            {
                string path = FileSavePath + @"\upload\" + name;
                System.IO.File.Delete(path);
                return "";
            }
            catch
            {
                return "";
            }

        }

        [HttpPost]
        public string Data_DaoRu(int type)
        {
            string s = "";
            switch (type)
            {
                case 1:                 //新增人员主数据
                    s = Data_DaoRu_Staff_Insert();
                    break;
                case 2:                 //修改人员主数据
                    s = Data_DaoRu_Staff_Update();
                    break;
                case 3:                 //新增人员考勤地址
                //s = Data_DaoRu_QT_Insert();
                //break;
                case 4:                 //修改人员考勤地址
                //s = Data_DaoRu_QT_Update();
                //break;
                default:

                    break;
            }


            return s;
        }

        //<summary>
        //批量新增人员主数据
        //</summary>
        //<returns></returns>
        public string Data_DaoRu_Staff_Insert()
        {
            token = appclass.CRM_Gettoken();
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
            file.SaveAs(savePath);
            FileInfo fi = new FileInfo(savePath);
            if (fi.Exists == true)
            {
                string[] sheet = { "人员" };
                DaoRuMsg msg = new DaoRuMsg();

                //开始做数据校验
                DataTable data1 = ExcelToDataTable(savePath, sheet[0], true);      //人员

                #region
                if (data1 != null)
                {
                    if (data1.Columns.Contains("人员类型") == false || data1.Columns.Contains("姓名") == false || data1.Columns.Contains("人员编号") == true)
                    {
                        msg.Msg = "请使用人员新增模版！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                    else
                    {
                        //做数据验证
                        if (data1.Rows.Count > 0)
                        {
                            for (int i = 0; i < data1.Rows.Count; i++)
                            {

                                if (data1.Rows[i]["人员类型"].ToString() == "")
                                {
                                    msg.Msg = "人员第" + i + 2 + "行人员类型不能为空！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                int STAFFLX = crmModels.HG_DICT.ReadByDICNAME(data1.Rows[i]["人员类型"].ToString(), 33, token);
                                if (STAFFLX == 0)
                                //if (data1.Rows[i]["人员类型"].ToString() != "业务员" && data1.Rows[i]["人员类型"].ToString() != "办公室人员" && data1.Rows[i]["人员类型"].ToString() != "直营卖场促销员" && data1.Rows[i]["人员类型"].ToString() != "客户业务员" && data1.Rows[i]["人员类型"].ToString() != "管理人员")
                                {
                                    msg.Msg = "人员第" + i + 2 + "行人员类型错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                if (data1.Rows[i]["性别"].ToString() != "男" && data1.Rows[i]["性别"].ToString() != "女")
                                {
                                    msg.Msg = "人员第" + i + 2 + "行性别错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                if (data1.Rows[i]["婚姻状况"].ToString() != "未婚" && data1.Rows[i]["婚姻状况"].ToString() != "已婚")
                                {
                                    msg.Msg = "人员第" + i + 2 + "行婚姻状况错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                int DEPID = crmModels.HG_DEPT.ReadByName(data1.Rows[i]["部门"].ToString(), token).DEPID;
                                if (DEPID == 0)
                                {
                                    msg.Msg = "人员第" + i + 2 + "行部门不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                int BZID = crmModels.HG_BZGZSJ.ReadByBZNAME(data1.Rows[i]["班次"].ToString(), token).BZID;
                                if (BZID == 0)
                                {
                                    msg.Msg = "人员第" + i + 2 + "行班次不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }

                                int BBID = crmModels.KQ_GZRL.Read(data1.Rows[i]["日历版本"].ToString(), 0, token)[0].BBID;
                                if (BBID == 0)
                                {
                                    msg.Msg = "人员第" + i + 2 + "行日历版本不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                int STAFFZZMM = crmModels.HG_DICT.ReadByDICNAME(data1.Rows[i]["政治面貌"].ToString(), 15, token);
                                if (STAFFZZMM == 0)
                                {
                                    msg.Msg = "人员第" + i + 2 + "行政治面貌不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                int STAFFXL = crmModels.HG_DICT.ReadByDICNAME(data1.Rows[i]["学历"].ToString(), 16, token);
                                if (STAFFXL == 0)
                                {
                                    msg.Msg = "人员第" + i + 2 + "行学历不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }

                                //int STAFFZWJB = crmModels.HG_DICT.ReadByDICNAME(data1.Rows[i]["职务"].ToString(), 13, token);
                                //if (STAFFZWJB == 0)
                                //{
                                //    msg.Msg = "人员第" + i + 2 + "行职务不存在！";
                                //    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                //}

                                int STAFFGW = crmModels.HG_DICT.ReadByDICNAME(data1.Rows[i]["岗位"].ToString(), 14, token);
                                if (STAFFGW == 0)
                                {
                                    msg.Msg = "人员第" + i + 2 + "行岗位不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }


                            }
                        }

                    }
                }
                #endregion


                //能到这儿就说明数据是没问题的了...大概，然后才进行数据库写入
                #region
                for (int i = 0; i < data1.Rows.Count; i++)
                {
                    CRM_HG_STAFF model = new CRM_HG_STAFF();

                    //switch (data1.Rows[i]["人员类型"].ToString())
                    //{
                    //    case "驻外业务员":
                    //        model.STAFFLX = 1;
                    //        break;
                    //    case "办公室人员":
                    //        model.STAFFLX = 2;
                    //        break;
                    //    case "直营卖场促销员":
                    //        model.STAFFLX = 3;
                    //        break;
                    //    case "客户业务员":
                    //        model.STAFFLX = 4;
                    //        break;
                    //}
                    model.STAFFLX = crmModels.HG_DICT.ReadByDICNAME(data1.Rows[i]["人员类型"].ToString(), 33, token);
                    model.STAFFNAME = data1.Rows[i]["姓名"].ToString();
                    model.STAFFNO = data1.Rows[i]["工号"].ToString();
                    model.DEPID = crmModels.HG_DEPT.ReadByName(data1.Rows[i]["部门"].ToString(), token).DEPID;
                    model.STAFFZZMM = crmModels.HG_DICT.ReadByDICNAME(data1.Rows[i]["政治面貌"].ToString(), 15, token);
                    switch (data1.Rows[i]["性别"].ToString())
                    {
                        case "男":
                            model.STAFFSEX = 1;
                            break;
                        case "女":
                            model.STAFFSEX = 2;
                            break;
                    }
                    model.STAFFXL = crmModels.HG_DICT.ReadByDICNAME(data1.Rows[i]["学历"].ToString(), 16, token);
                    switch (data1.Rows[i]["婚姻状况"].ToString())
                    {
                        case "未婚":
                            model.STAFFHYZK = 1;
                            break;
                        case "已婚":
                            model.STAFFHYZK = 2;
                            break;
                    }
                    model.STAFFEMAIL = data1.Rows[i]["邮箱地址"].ToString();
                    model.STAFFTEL = data1.Rows[i]["联系电话"].ToString();
                    model.STAFFJG = data1.Rows[i]["籍贯"].ToString();
                    model.STAFFSFZH = data1.Rows[i]["身份证号"].ToString();
                    model.STAFFSR = data1.Rows[i]["生日"].ToString();
                    model.STAFFRZSJ = data1.Rows[i]["入职时间"].ToString();
                    model.STAFFMPSJ = data1.Rows[i]["调入民品部时间"].ToString();
                    model.STAFFCZDZ = data1.Rows[i]["常住地址"].ToString();
                    model.STAFFBYYX = data1.Rows[i]["毕业院校"].ToString();
                    model.STAFFZWJB = crmModels.HG_DICT.ReadByDICNAME(data1.Rows[i]["职位"].ToString(), 13, token);
                    model.STAFFGW = crmModels.HG_DICT.ReadByDICNAME(data1.Rows[i]["岗位"].ToString(), 14, token);
                    model.BZID = crmModels.HG_BZGZSJ.ReadByBZNAME(data1.Rows[i]["班次"].ToString(), token).BZID;
                    model.BBID = crmModels.KQ_GZRL.Read(data1.Rows[i]["日历版本"].ToString(), 0, token)[0].BBID;
                    model.STAFFWORK = data1.Rows[i]["工作内容"].ToString();
                    model.STAFFMEMO = data1.Rows[i]["备注"].ToString();
                    model.ISACTIVE = 1;
                    model.STAFFKHLXID = 0;
                    model.STAFFUSER = "";
                    model.STAFFPW = "";
                    model.STAFFMOBILE = "";
                    model.XH = "";
                    model.USERLX = 1108;
                    int id = crmModels.HG_STAFF.Create(model, token);
                    if (id <= 0)
                    {
                        msg.Msg = "人员的第" + i + 2 + "行出现问题，请记录当前报错信息并联系管理员";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                }
                #endregion
                msg.Msg = "新增成功！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
            else
            {
                return "{}";
            }

        }

        //<summary>
        //批量修改人员主数据
        //</summary>
        //<returns></returns>
        public string Data_DaoRu_Staff_Update()
        {
            token = appclass.CRM_Gettoken();
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
            file.SaveAs(savePath);
            FileInfo fi = new FileInfo(savePath);
            if (fi.Exists == true)
            {
                string[] sheet = { "人员" };
                DaoRuMsg msg = new DaoRuMsg();

                //开始做数据校验
                DataTable data1 = ExcelToDataTable(savePath, sheet[0], true);      //人员

                #region
                if (data1 != null)
                {
                    if (data1.Columns.Contains("人员类型") == false || data1.Columns.Contains("姓名") == false || data1.Columns.Contains("人员编号") == false)
                    {
                        msg.Msg = "请使用人员修改模版！";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                    else
                    {
                        //做数据验证
                        if (data1.Rows.Count > 0)
                        {
                            for (int i = 0; i < data1.Rows.Count; i++)
                            {
                                if (data1.Rows[i]["人员编号"].ToString() == "")
                                {
                                    msg.Msg = "人员第" + i + 2 + "行人员编号不能为空！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }

                                int STAFFID = crmModels.HG_STAFF.ReadBySTAFFID(Convert.ToInt32(data1.Rows[i]["人员编号"]), token).STAFFID;
                                if (STAFFID == 0)
                                {
                                    msg.Msg = "人员第" + i + 2 + "行人员编号不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }


                                if (data1.Rows[i]["人员类型"].ToString() == "")
                                {
                                    msg.Msg = "人员第" + i + 2 + "行人员类型不能为空！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }

                                int STAFFLX = crmModels.HG_DICT.ReadByDICNAME(data1.Rows[i]["人员类型"].ToString(), 33, token);
                                if (STAFFLX == 0)
                                //if (data1.Rows[i]["人员类型"].ToString() != "业务员" && data1.Rows[i]["人员类型"].ToString() != "办公室人员" && data1.Rows[i]["人员类型"].ToString() != "直营卖场促销员" && data1.Rows[i]["人员类型"].ToString() != "客户业务员" && data1.Rows[i]["人员类型"].ToString() != "管理人员")
                                {
                                    msg.Msg = "人员第" + i + 2 + "行人员类型错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                if (data1.Rows[i]["性别"].ToString() != "男" && data1.Rows[i]["性别"].ToString() != "女")
                                {
                                    msg.Msg = "人员第" + i + 2 + "行性别错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                if (data1.Rows[i]["婚姻状况"].ToString() != "未婚" && data1.Rows[i]["婚姻状况"].ToString() != "已婚")
                                {
                                    msg.Msg = "人员第" + i + 2 + "行婚姻状况错误！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                int DEPID = crmModels.HG_DEPT.ReadByName(data1.Rows[i]["部门"].ToString(), token).DEPID;
                                if (DEPID == 0)
                                {
                                    msg.Msg = "人员第" + i + 2 + "行部门不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                int BZID = crmModels.HG_BZGZSJ.ReadByBZNAME(data1.Rows[i]["班次"].ToString(), token).BZID;
                                if (BZID == 0)
                                {
                                    msg.Msg = "人员第" + i + 2 + "行班次不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }

                                int BBID = crmModels.KQ_GZRL.Read(data1.Rows[i]["日历版本"].ToString(), 0, token)[0].BBID;
                                if (BBID == 0)
                                {
                                    msg.Msg = "人员第" + i + 2 + "行日历版本不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                int STAFFZZMM = crmModels.HG_DICT.ReadByDICNAME(data1.Rows[i]["政治面貌"].ToString(), 15, token);
                                if (STAFFZZMM == 0)
                                {
                                    msg.Msg = "人员第" + i + 2 + "行政治面貌不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }
                                int STAFFXL = crmModels.HG_DICT.ReadByDICNAME(data1.Rows[i]["学历"].ToString(), 16, token);
                                if (STAFFXL == 0)
                                {
                                    msg.Msg = "人员第" + i + 2 + "行学历不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }

                                //int STAFFZWJB = crmModels.HG_DICT.ReadByDICNAME(data1.Rows[i]["职务"].ToString(), 13, token);
                                //if (STAFFZWJB == 0)
                                //{
                                //    msg.Msg = "人员第" + i + 2 + "行职务不存在！";
                                //    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                //}

                                int STAFFGW = crmModels.HG_DICT.ReadByDICNAME(data1.Rows[i]["岗位"].ToString(), 14, token);
                                if (STAFFGW == 0)
                                {
                                    msg.Msg = "人员第" + i + 2 + "行岗位不存在！";
                                    return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                                }


                            }
                        }

                    }
                }
                #endregion


                //能到这儿就说明数据是没问题的了...大概，然后才进行数据库写入
                #region
                for (int i = 0; i < data1.Rows.Count; i++)
                {
                    CRM_HG_STAFF model = new CRM_HG_STAFF();

                    model = crmModels.HG_STAFF.ReadBySTAFFID(Convert.ToInt32(data1.Rows[i]["人员编号"]), token);

                    model.STAFFLX = crmModels.HG_DICT.ReadByDICNAME(data1.Rows[i]["人员类型"].ToString(), 33, token);
                    //switch (data1.Rows[i]["人员类型"].ToString())
                    //{
                    //    case "驻外业务员":
                    //        model.STAFFLX = 1;
                    //        break;
                    //    case "办公室人员":
                    //        model.STAFFLX = 2;
                    //        break;
                    //    case "直营卖场促销员":
                    //        model.STAFFLX = 3;
                    //        break;
                    //    case "客户业务员":
                    //        model.STAFFLX = 4;
                    //        break;
                    //}
                    model.STAFFNAME = data1.Rows[i]["姓名"].ToString();
                    model.STAFFNO = data1.Rows[i]["工号"].ToString();
                    model.DEPID = crmModels.HG_DEPT.ReadByName(data1.Rows[i]["部门"].ToString(), token).DEPID;
                    model.STAFFZZMM = crmModels.HG_DICT.ReadByDICNAME(data1.Rows[i]["政治面貌"].ToString(), 15, token);
                    switch (data1.Rows[i]["性别"].ToString())
                    {
                        case "男":
                            model.STAFFSEX = 1;
                            break;
                        case "女":
                            model.STAFFSEX = 2;
                            break;
                    }
                    model.STAFFXL = crmModels.HG_DICT.ReadByDICNAME(data1.Rows[i]["学历"].ToString(), 16, token);
                    switch (data1.Rows[i]["婚姻状况"].ToString())
                    {
                        case "未婚":
                            model.STAFFHYZK = 1;
                            break;
                        case "已婚":
                            model.STAFFHYZK = 2;
                            break;
                    }
                    model.STAFFEMAIL = data1.Rows[i]["邮箱地址"].ToString();
                    model.STAFFTEL = data1.Rows[i]["联系电话"].ToString();
                    model.STAFFJG = data1.Rows[i]["籍贯"].ToString();
                    model.STAFFSFZH = data1.Rows[i]["身份证号"].ToString();
                    model.STAFFSR = data1.Rows[i]["生日"].ToString();
                    model.STAFFRZSJ = data1.Rows[i]["入职时间"].ToString();
                    model.STAFFMPSJ = data1.Rows[i]["调入民品部时间"].ToString();
                    model.STAFFCZDZ = data1.Rows[i]["常住地址"].ToString();
                    model.STAFFBYYX = data1.Rows[i]["毕业院校"].ToString();
                    model.STAFFZWJB = crmModels.HG_DICT.ReadByDICNAME(data1.Rows[i]["职位"].ToString(), 13, token);
                    model.STAFFGW = crmModels.HG_DICT.ReadByDICNAME(data1.Rows[i]["岗位"].ToString(), 14, token);
                    model.BZID = crmModels.HG_BZGZSJ.ReadByBZNAME(data1.Rows[i]["班次"].ToString(), token).BZID;
                    model.BBID = crmModels.KQ_GZRL.Read(data1.Rows[i]["日历版本"].ToString(), 0, token)[0].BBID;
                    model.STAFFWORK = data1.Rows[i]["工作内容"].ToString();
                    model.STAFFMEMO = data1.Rows[i]["备注"].ToString();
                    //model.ISACTIVE = 1;
                    int id = crmModels.HG_STAFF.Update(model, token);
                    if (id <= 0)
                    {
                        msg.Msg = "人员的第" + i + 2 + "行出现问题，请记录当前报错信息并联系管理员";
                        return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
                    }
                }
                #endregion
                msg.Msg = "修改成功！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
            else
            {
                return "{}";
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

        [HttpPost]
        public string Data_FileUpload_Staff_DaoChu(string data)
        {
            token = appclass.CRM_Gettoken();
            try
            {
                CRM_HG_STAFFList[] model = JsonConvert.DeserializeObject<CRM_HG_STAFFList[]>(data);


                FileStream file = new FileStream(FileSavePath + @"\ExcelTemplate/人员导出模版.xls", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new HSSFWorkbook(file);
                ISheet worksheet1 = workbook.GetSheet("人员");

                if (worksheet1 == null)
                    return "工作薄中没有工作表";

                int row1 = 0;
                for (int i = 0; i < model.Length; i++)
                {


                    NPOI.SS.UserModel.IRow row = worksheet1.CreateRow(row1 + 1);
                    row.CreateCell(0).SetCellValue(model[i].STAFFID);
                    string STAFFLXDES = crmModels.HG_DICT.ReadByDICID(model[i].STAFFLX, token).DICNAME;
                    row.CreateCell(1).SetCellValue(STAFFLXDES);
                    //switch (model[i].STAFFLX)
                    //{
                    //    case 1:
                    //        row.CreateCell(1).SetCellValue("驻外业务员");
                    //        break;
                    //    case 2:
                    //        row.CreateCell(1).SetCellValue("办公室人员");
                    //        break;
                    //    case 3:
                    //        row.CreateCell(1).SetCellValue("直营卖场促销员");
                    //        break;
                    //    case 4:
                    //        row.CreateCell(1).SetCellValue("客户业务员");
                    //        break;
                    //}
                    row.CreateCell(2).SetCellValue(model[i].STAFFNAME);
                    row.CreateCell(3).SetCellValue(model[i].STAFFNO);
                    string DEPNAME = crmModels.HG_DEPT.ReadByDEPID(model[i].DEPID, token).DEPNAME;
                    row.CreateCell(4).SetCellValue(DEPNAME);
                    string STAFFZZMMDES = crmModels.HG_DICT.ReadByDICID(model[i].STAFFZZMM, token).DICNAME;
                    row.CreateCell(5).SetCellValue(STAFFZZMMDES);
                    switch (model[i].STAFFSEX)
                    {
                        case 1:
                            row.CreateCell(6).SetCellValue("男");
                            break;
                        case 2:
                            row.CreateCell(6).SetCellValue("女");
                            break;
                    }
                    string STAFFXLDES = crmModels.HG_DICT.ReadByDICID(model[i].STAFFXL, token).DICNAME;
                    row.CreateCell(7).SetCellValue(STAFFXLDES);
                    switch (model[i].STAFFHYZK)
                    {
                        case 1:
                            row.CreateCell(8).SetCellValue("未婚");
                            break;
                        case 2:
                            row.CreateCell(8).SetCellValue("已婚");
                            break;
                    }
                    row.CreateCell(9).SetCellValue(model[i].STAFFEMAIL);
                    row.CreateCell(10).SetCellValue(model[i].STAFFTEL);
                    row.CreateCell(11).SetCellValue(model[i].STAFFJG);
                    row.CreateCell(12).SetCellValue(model[i].STAFFSFZH);
                    row.CreateCell(13).SetCellValue(model[i].STAFFSR);
                    row.CreateCell(14).SetCellValue(model[i].STAFFRZSJ);
                    row.CreateCell(15).SetCellValue(model[i].STAFFMPSJ);
                    row.CreateCell(16).SetCellValue(model[i].STAFFCZDZ);
                    row.CreateCell(17).SetCellValue(model[i].STAFFBYYX);
                    string STAFFZWJBDES = crmModels.HG_DICT.ReadByDICID(model[i].STAFFZWJB, token).DICNAME;
                    row.CreateCell(18).SetCellValue(STAFFZWJBDES);
                    string STAFFGWDES = crmModels.HG_DICT.ReadByDICID(model[i].STAFFGW, token).DICNAME;
                    row.CreateCell(19).SetCellValue(STAFFGWDES);
                    string BZNAME = crmModels.HG_BZGZSJ.ReadByBZID(model[i].BZID, token).BZNAME;
                    row.CreateCell(20).SetCellValue(BZNAME);
                    string MS = crmModels.KQ_GZRL.Read("", model[i].BBID, token)[0].MS;
                    row.CreateCell(21).SetCellValue(MS);
                    row.CreateCell(22).SetCellValue(model[i].STAFFWORK);
                    row.CreateCell(23).SetCellValue(model[i].STAFFMEMO);

                    row1++;


                }


                worksheet1.ForceFormulaRecalculation = true;

                string now = DateTime.Now.ToString("yyyyMMddHHmmss");
                FileStream file1 = new FileStream(FileSavePath + @"\upload\" + now + ".xls", FileMode.Create);
                workbook.Write(file1);
                file1.Close();
                DaoRuMsg msg = new DaoRuMsg();
                msg.Msg = now + ".xls";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }
            catch //(Exception e)
            {
                DaoRuMsg msg = new DaoRuMsg();
                msg.Msg = "err";
                return Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            }


        }


        [HttpPost]
        public string Data_Select_ALLSTAFF_ToDDL()
        {
            token = appclass.CRM_Gettoken();
            CRM_Report_STAFFModel model = new CRM_Report_STAFFModel();
            model.ISACTIVE = 1;
            CRM_HG_STAFFList[] data = crmModels.HG_STAFF.Report(model, "staff", token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public string Data_Select_ByParam(string cxdata)
        {
            token = appclass.CRM_Gettoken();
            CRM_HG_STAFF model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_HG_STAFF>(cxdata);
            CRM_HG_STAFFList[] data = crmModels.HG_STAFF.ReadByParam(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }


    }
}
