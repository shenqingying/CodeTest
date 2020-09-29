using Sonluk.PC.Areas.CRM.Models;
using Sonluk.PC.Models;
using Sonluk.UI.Model.CRM.BF_BFService;
using Sonluk.UI.Model.CRM.HG_DEPTService;
using Sonluk.UI.Model.CRM.HG_DICTService;
using Sonluk.UI.Model.CRM.HG_STAFFService;
using Sonluk.UI.Model.CRM.KH_GROUPService;
using Sonluk.UI.Model.CRM.KH_KHService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sonluk.UI.Model.CRM.BF_BFQDService;
using Sonluk.UI.Model.CRM.CRM_PENGDINGService;
using Sonluk.UI.Model.CRM.BF_BFJHMXService;
using Sonluk.UI.Model.CRM.KH_KHBFService;
using Sonluk.UI.Model.CRM.KH_BFService;
using Sonluk.PC.APPCLASS;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using System.Data;
using Sonluk.PC.Models.CRM;

namespace Sonluk.PC.Areas.CRM.Controllers
{
    public class BaiFangController : Controller
    {
        //
        // GET: /CRM/BaiFang/
        CRMModels crmModels = new CRMModels();
        AppClass appClass = new AppClass();
        string token = "";
        string FileSavePath = System.Configuration.ConfigurationManager.AppSettings["FileSavePath"];
        public ActionResult Index()
        {
            return View();
        }


        //public ActionResult Plan()
        //{
        //    if (Session["token"] != null)
        //    {
        //        CRM_KH_GROUP[] KH_GROUP = crmModels.KH_GROUP.Read(Session["token"].ToString());
        //        CRM_HG_DICT[] bfpc = crmModels.HG_DICT.Read(17, 0, Session["token"].ToString());
        //        CRM_HG_DEPT[] dept = crmModels.HG_DEPT.Read(Session["token"].ToString());
        //        BF_Plan_csh bf_plan = new BF_Plan_csh();
        //        bf_plan.KH_GROUP = KH_GROUP;
        //        bf_plan.BFJH = bfpc;
        //        bf_plan.DEPT = dept;
        //        ViewData.Model = bf_plan;
        //        Session["location"] = 17;
        //        return View();
        //    }
        //    else
        //    {
        //        ActionResult target;
        //        target = RedirectToAction("SignIn", "Public");
        //        return target;
        //    }

        //}

        //public ActionResult Assign()
        //{
        //    if (Session["token"] != null)
        //    {
        //        CRM_KH_GROUP[] KH_GROUP = crmModels.KH_GROUP.Read(Session["token"].ToString());
        //        CRM_HG_DICT[] bfpc = crmModels.HG_DICT.Read(17, 0, Session["token"].ToString());
        //        CRM_HG_DEPT[] dept = crmModels.HG_DEPT.Read(Session["token"].ToString());
        //        CRM_Report_STAFFModel ry_in = new CRM_Report_STAFFModel();
        //        CRM_HG_STAFFList[] ry_info = crmModels.HG_STAFF.Report(ry_in, Session["token"].ToString());
        //        BF_Plan_csh bf_plan = new BF_Plan_csh();
        //        bf_plan.KH_GROUP = KH_GROUP;
        //        bf_plan.BFJH = bfpc;
        //        bf_plan.DEPT = dept;
        //        bf_plan.STAFF = ry_info;
        //        ViewData.Model = bf_plan;
        //        Session["location"] = 18;
        //        return View();
        //    }
        //    else
        //    {
        //        ActionResult target;
        //        target = RedirectToAction("SignIn", "Public");
        //        return target;
        //    }
        //}

        //public ActionResult ToDo()
        //{
        //    if (Session["token"] != null)
        //    {
        //        CRM_KH_GROUP[] KH_GROUP = crmModels.KH_GROUP.Read(Session["token"].ToString());
        //        BF_Plan_csh bf_plan = new BF_Plan_csh();
        //        bf_plan.KH_GROUP = KH_GROUP;
        //        ViewData.Model = bf_plan;
        //        Session["location"] = 19;
        //        return View();
        //    }
        //    else
        //    {
        //        ActionResult target;
        //        target = RedirectToAction("SignIn", "Public");
        //        return target;
        //    }
        //}

        public ActionResult Log()
        {
            if (Session["token"] != null)
            {
                Session["location"] = 20;
                return View();
            }
            else
            {
                ActionResult target;
                target = RedirectToAction("SignIn", "Public");
                return target;
            }
        }

        public ActionResult Select_KeHu_ToBaiFang()
        {
            Session["location"] = 49;
            return View();
        }

        public ActionResult Insert_BaiFang()
        {

            return View();
        }

        public ActionResult Update_BaiFang()
        {

            return View();
        }

        public ActionResult BaiFangManage()
        {
            Session["location"] = 47;
            return View();
        }

        public ActionResult CX_BaiFang()
        {
            Session["location"] = 48;
            return View();
        }

        public ActionResult BaoBiao()
        {
            if (Session["token"] != null)
            {
                CRM_Report_STAFFModel ry_in = new CRM_Report_STAFFModel();
                CRM_HG_STAFFList[] ry_info = crmModels.HG_STAFF.Report(ry_in, "staff", Session["token"].ToString());
                BF_Plan_csh bf_plan = new BF_Plan_csh();
                bf_plan.STAFF = ry_info;
                ViewData.Model = bf_plan;
                Session["location"] = 21;
                return View();
            }
            else
            {
                ActionResult target;
                target = RedirectToAction("SignIn", "Public");
                return target;
            }
        }

        //[HttpPost]
        //public string Get_BFJH_fz(string KHLX, string CS)
        //{
        //    CRM_BF_BFJH bfjhcs = new CRM_BF_BFJH();
        //    bfjhcs.BFLX = 1;
        //    //bfjhcs.KHLX = Convert.ToInt32(KHLX);
        //    //bfjhcs.CS = Convert.ToInt32(CS);
        //    bfjhcs.ISACTIVE = 1;
        //    CRM_BF_BFJHList[] bfjh = crmModels.BF_BF.Read_BFJH(bfjhcs, Session["token"].ToString());
        //    for (int i = 0; i < bfjh.Length; i++)
        //    {
        //        //if (bfjh[i].KHLX == 1)
        //        //{
        //        //    bfjh[i].KHLXDES = "经销商";
        //        //}
        //        //else if (bfjh[i].KHLX == 2)
        //        //{
        //        //    bfjh[i].KHLXDES = "电商";
        //        //}
        //        //else if (bfjh[i].KHLX == 3)
        //        //{
        //        //    bfjh[i].KHLXDES = "直营卖场";
        //        //}
        //        //else if (bfjh[i].KHLX == 4)
        //        //{
        //        //    bfjh[i].KHLXDES = "B2B";
        //        //}
        //        //else if (bfjh[i].KHLX == 5)
        //        //{
        //        //    bfjh[i].KHLXDES = "网点终端";
        //        //}
        //        //else if (bfjh[i].KHLX == 6)
        //        //{
        //        //    bfjh[i].KHLXDES = "批发";
        //        //}
        //        //else if (bfjh[i].KHLX == 7)
        //        //{
        //        //    bfjh[i].KHLXDES = "LKA终端";
        //        //}
        //    }
        //    string json = Newtonsoft.Json.JsonConvert.SerializeObject(bfjh);
        //    return json;
        //}


        //[HttpPost]
        //public string add_bfjh_fz(string KHLX, string CS, string BFPC, string BFJHID)
        //{
        //    CRM_BF_BFJH bfjhcs = new CRM_BF_BFJH();
        //    bfjhcs.BFLX = 1;
        //    //bfjhcs.KHLX = Convert.ToInt32(KHLX);
        //    //bfjhcs.CS = Convert.ToInt32(CS);
        //    bfjhcs.ISACTIVE = 1;
        //    string rst = "";
        //    if (BFJHID != "")
        //    {
        //        //bfjhcs.BFPC = Convert.ToInt32(BFPC);
        //        bfjhcs.BFJHID = Convert.ToInt32(BFJHID);
        //        rst = crmModels.BF_BF.Update_BFJH(bfjhcs, Session["token"].ToString()).ToString();
        //    }
        //    else
        //    {
        //        CRM_BF_BFJHList[] bfjh = crmModels.BF_BF.Read_BFJH(bfjhcs, Session["token"].ToString());
        //        if (bfjh.Length > 0)
        //        {
        //            rst = "-1";
        //        }
        //        else
        //        {
        //            //bfjhcs.BFPC = Convert.ToInt32(BFPC);
        //            rst = crmModels.BF_BF.Create_BFJH(bfjhcs, Session["token"].ToString()).ToString();
        //        }
        //    }
        //    return rst;
        //}


        [HttpPost]
        public string del_bfjh_id(string BFJHID)
        {
            string rst = "";
            rst = crmModels.BF_BF.Delete_BFJH(Convert.ToInt32(BFJHID), Session["token"].ToString()).ToString();
            return rst;
        }

        [HttpPost]
        public string get_bfjh_ry(string dept, string gh, string yglx, string xm)
        {
            string rst = "";
            CRM_BF_STAFFList yg_in = new CRM_BF_STAFFList();
            yg_in.DEPID = Convert.ToInt32(dept);
            yg_in.STAFFNO = gh;
            yg_in.STAFFLX = Convert.ToInt32(yglx);
            yg_in.STAFFNAME = xm;
            CRM_BF_STAFFList[] yg_info = crmModels.BF_BF.Report_STAFF(yg_in, Session["token"].ToString());
            for (int i = 0; i < yg_info.Length; i++)
            {
                if (yg_info[i].STAFFLX == 1)
                {
                    yg_info[i].STAFFLXDES = "驻外业务员";
                }
                else if (yg_info[i].STAFFLX == 2)
                {
                    yg_info[i].STAFFLXDES = "办公室人员";
                }
                else if (yg_info[i].STAFFLX == 3)
                {
                    yg_info[i].STAFFLXDES = "直营卖场促销员";
                }
                else if (yg_info[i].STAFFLX == 4)
                {
                    yg_info[i].STAFFLXDES = "客户业务员";
                }
            }
            rst = Newtonsoft.Json.JsonConvert.SerializeObject(yg_info);
            return rst;
        }

        //[HttpPost]
        //public string add_bfjh_ry(string BFRYID, string BFPC)
        //{
        //    string rst = "";
        //    CRM_BF_BFJH bfjhcs = new CRM_BF_BFJH();
        //    bfjhcs.BFLX = 2;
        //    //bfjhcs.BFRYID = Convert.ToInt32(BFRYID);
        //    bfjhcs.ISACTIVE = 1;

        //    CRM_BF_BFJHList[] bfjh = crmModels.BF_BF.Read_BFJH(bfjhcs, Session["token"].ToString());
        //    if (bfjh.Length > 0)
        //    {
        //        bfjhcs.BFJHID = bfjh[0].BFJHID;
        //        //bfjhcs.BFPC = Convert.ToInt32(BFPC);
        //        rst = crmModels.BF_BF.Update_BFJH(bfjhcs, Session["token"].ToString()).ToString();
        //    }
        //    else
        //    {
        //        //bfjhcs.BFPC = Convert.ToInt32(BFPC);
        //        rst = crmModels.BF_BF.Create_BFJH(bfjhcs, Session["token"].ToString()).ToString();
        //    }
        //    return rst;
        //}

        //[HttpPost]
        //public string del_bfjh_ry(string BFRYID)
        //{
        //    string rst = "";
        //    CRM_BF_BFJH bfjhcs = new CRM_BF_BFJH();
        //    bfjhcs.BFLX = 2;
        //   // bfjhcs.BFRYID = Convert.ToInt32(BFRYID);
        //    bfjhcs.ISACTIVE = 1;
        //    CRM_BF_BFJHList[] bfjh = crmModels.BF_BF.Read_BFJH(bfjhcs, Session["token"].ToString());
        //    if (bfjh.Length > 0)
        //    {
        //        rst = crmModels.BF_BF.Delete_BFJH(bfjh[0].BFJHID, Session["token"].ToString()).ToString();
        //    }
        //    return rst;
        //}


        [HttpPost]
        public string get_bfjh_kh(string crmid, string khlx, string khfz, string mc)
        {
            string rst = "";
            CRM_BF_KHList kh_in = new CRM_BF_KHList();
            kh_in.CRMID = crmid;
            kh_in.KHLX = Convert.ToInt32(khlx);
            kh_in.CS = Convert.ToInt32(khfz);
            kh_in.MC = mc;
            CRM_BF_KHList[] kh_info = crmModels.BF_BF.Report_KH(kh_in, Session["token"].ToString());
            for (int i = 0; i < kh_info.Length; i++)
            {
                if (kh_info[i].KHLX == 1)
                {
                    kh_info[i].KHLXDES = "经销商";
                }
                else if (kh_info[i].KHLX == 2)
                {
                    kh_info[i].KHLXDES = "电商";
                }
                else if (kh_info[i].KHLX == 3)
                {
                    kh_info[i].KHLXDES = "直营卖场";
                }
                else if (kh_info[i].KHLX == 4)
                {
                    kh_info[i].KHLXDES = "B2B";
                }
                else if (kh_info[i].KHLX == 5)
                {
                    kh_info[i].KHLXDES = "网点终端";
                }
                else if (kh_info[i].KHLX == 6)
                {
                    kh_info[i].KHLXDES = "批发";
                }
                else if (kh_info[i].KHLX == 7)
                {
                    kh_info[i].KHLXDES = "LKA终端";
                }
            }
            rst = Newtonsoft.Json.JsonConvert.SerializeObject(kh_info);
            return rst;
        }

        //[HttpPost]
        //public string add_bfjh_kh(string KHID, string BFPC)
        //{
        //    string rst = "";
        //    CRM_BF_BFJH bfjhcs = new CRM_BF_BFJH();
        //    bfjhcs.BFLX = 3;
        //    //bfjhcs.KHID = Convert.ToInt32(KHID);
        //    bfjhcs.ISACTIVE = 1;

        //    CRM_BF_BFJHList[] bfjh = crmModels.BF_BF.Read_BFJH(bfjhcs, Session["token"].ToString());
        //    if (bfjh.Length > 0)
        //    {
        //        bfjhcs.BFJHID = bfjh[0].BFJHID;
        //        //bfjhcs.BFPC = Convert.ToInt32(BFPC);
        //        rst = crmModels.BF_BF.Update_BFJH(bfjhcs, Session["token"].ToString()).ToString();
        //    }
        //    else
        //    {
        //        //bfjhcs.BFPC = Convert.ToInt32(BFPC);
        //        rst = crmModels.BF_BF.Create_BFJH(bfjhcs, Session["token"].ToString()).ToString();
        //    }
        //    return rst;
        //}

        //[HttpPost]
        //public string del_bfjh_kh(string KHID)
        //{
        //    string rst = "";
        //    CRM_BF_BFJH bfjhcs = new CRM_BF_BFJH();
        //    bfjhcs.BFLX = 3;
        //    //bfjhcs.KHID = Convert.ToInt32(KHID);
        //    bfjhcs.ISACTIVE = 1;
        //    CRM_BF_BFJHList[] bfjh = crmModels.BF_BF.Read_BFJH(bfjhcs, Session["token"].ToString());
        //    if (bfjh.Length > 0)
        //    {
        //        rst = crmModels.BF_BF.Delete_BFJH(bfjh[0].BFJHID, Session["token"].ToString()).ToString();
        //    }
        //    return rst;
        //}

        [HttpPost]
        public string get_assign_kh(string CRMID, string KHLX, string GID, string MC)
        {
            string rst = "";
            CRM_Report_KHModel kh_in = new CRM_Report_KHModel();
            kh_in.CRMID = CRMID;
            kh_in.KHLX = Convert.ToInt32(KHLX);
            kh_in.GID = Convert.ToInt32(GID);
            kh_in.MC = MC;
            CRM_KH_KHList[] list = crmModels.KH_KH.Report(kh_in, Convert.ToInt32(Session["STAFFID"]), Session["token"].ToString());
            rst = Newtonsoft.Json.JsonConvert.SerializeObject(list);
            return rst;
        }

        [HttpPost]
        public string get_assign_ry()
        {
            string rst = "";
            CRM_Report_STAFFModel ry_in = new CRM_Report_STAFFModel();
            CRM_HG_STAFFList[] ry_info = crmModels.HG_STAFF.Report(ry_in, "staff", Session["token"].ToString());
            rst = Newtonsoft.Json.JsonConvert.SerializeObject(ry_info);
            return rst;
        }


        [HttpPost]
        public string add_assign_zdbf(string KHID, string BFRYID, string BFSJ, string CRMID, string KHMC, string KHLX)
        {
            string rst = "";
            CRM_BF_BFJH bfjhcs = new CRM_BF_BFJH();
            bfjhcs.BFLX = 4;
            //bfjhcs.KHID = Convert.ToInt32(KHID);
            //bfjhcs.BFRYID = Convert.ToInt32(BFRYID);
            //bfjhcs.BFSJ = BFSJ;
            bfjhcs.ISACTIVE = 1;
            rst = crmModels.BF_BF.Create_BFJH(bfjhcs, Session["token"].ToString()).ToString();


            CRM_BF_BFDJ bfdj_in = new CRM_BF_BFDJ();
            bfdj_in.BFJHID = Convert.ToInt32(rst);
            bfdj_in.BFRYID = Convert.ToInt32(BFRYID);
            bfdj_in.BFKH = Convert.ToInt32(KHID);
            bfdj_in.BFLX = 2;
            bfdj_in.CRMID = CRMID;
            bfdj_in.KHMC = KHMC;
            bfdj_in.KHLX = Convert.ToInt32(KHLX);
            bfdj_in.JHBFKSSJ = BFSJ;
            bfdj_in.JHBFJSSJ = BFSJ;
            //bfdj_in.BFPC = 0;
            bfdj_in.ISACTIVE = 1;
            rst = crmModels.BF_BF.Create_BFDJ(bfdj_in, Session["token"].ToString()).ToString();
            return rst;
        }


        [HttpPost]
        public string add_todo_xj(string KHID, string BFSJ, string CRMID, string KHMC, string KHLX, string BFLX)
        {

            if (Session["STAFFID"] != null)
            {
                int STAFFID = Convert.ToInt32(Session["STAFFID"].ToString());
                string rst = "";
                CRM_BF_BFJH bfjhcs = new CRM_BF_BFJH();
                bfjhcs.BFLX = 5;
                //bfjhcs.KHID = Convert.ToInt32(KHID);
                //bfjhcs.BFRYID = STAFFID;
                //bfjhcs.BFSJ = BFSJ;
                bfjhcs.ISACTIVE = 1;
                rst = crmModels.BF_BF.Create_BFJH(bfjhcs, Session["token"].ToString()).ToString();


                CRM_BF_BFDJ bfdj_in = new CRM_BF_BFDJ();
                bfdj_in.BFJHID = Convert.ToInt32(rst);
                bfdj_in.BFRYID = STAFFID;
                bfdj_in.BFKH = Convert.ToInt32(KHID);
                bfdj_in.BFLX = Convert.ToInt32(BFLX);
                bfdj_in.CRMID = CRMID;
                bfdj_in.KHMC = KHMC;
                bfdj_in.KHLX = Convert.ToInt32(KHLX);
                bfdj_in.JHBFKSSJ = BFSJ;
                bfdj_in.JHBFJSSJ = BFSJ;
                //bfdj_in.BFPC = 0;
                bfdj_in.ISACTIVE = 1;
                rst = crmModels.BF_BF.Create_BFDJ(bfdj_in, Session["token"].ToString()).ToString();
                return rst;
            }
            else
            {
                return "0";
            }
        }
        [HttpPost]
        public string get_dbrw_staff()
        {
            string rst = "";
            if (Session["STAFFID"] != null)
            {
                int STAFFID = Convert.ToInt32(Session["STAFFID"].ToString());
                CRM_BF_BFDJList bf_bfdj = new CRM_BF_BFDJList();
                bf_bfdj.BFRYID = STAFFID;
                bf_bfdj.ISACTIVE = 1;
                CRM_BF_BFDJList[] bf = crmModels.BF_BF.Report_BFDJ(bf_bfdj, Session["token"].ToString());
                rst = Newtonsoft.Json.JsonConvert.SerializeObject(bf);
                return rst;
            }
            else
            {
                return "0";
            }
        }


        [HttpPost]
        public string update_bfdj(string BFDJID, string XSQD, string BFDZ, string BFSJ, string LXR, string LXRTEL, string LXRZW, int BFMD, int BFJG, string XCBFSJ, string XCBFJH, string QTXX, string ISACTIVE, string BFJHID, string BFKH, string CRMID, string KHMC, string KHLX)
        {
            if (Session["STAFFID"] != null)
            {
                int STAFFID = Convert.ToInt32(Session["STAFFID"].ToString());
                string rst = "";
                CRM_BF_BFDJ bfdj = new CRM_BF_BFDJ();
                bfdj.BFDJID = Convert.ToInt32(BFDJID);
                bfdj.XSQD = XSQD;
                bfdj.BFDZ = BFDZ;
                // bfdj.BFSJ = BFSJ;
                bfdj.LXR = LXR;
                bfdj.LXRTEL = LXRTEL;
                bfdj.LXRZW = Convert.ToInt32(LXRZW);
                bfdj.BFMD = BFMD;
                bfdj.BFJG = BFJG;
                bfdj.XCBFSJ = XCBFSJ;
                bfdj.XCBFJH = XCBFJH;
                bfdj.QTXX = QTXX;
                bfdj.ISACTIVE = Convert.ToInt32(ISACTIVE);
                rst = crmModels.BF_BF.Update_BFDJ(bfdj, Session["token"].ToString()).ToString();

                if (XCBFSJ != "")
                {
                    CRM_BF_BFDJ bfdj_in = new CRM_BF_BFDJ();
                    bfdj_in.BFJHID = Convert.ToInt32(BFJHID);
                    bfdj_in.BFRYID = STAFFID;
                    bfdj_in.BFKH = Convert.ToInt32(BFKH);
                    bfdj_in.BFLX = 5;
                    bfdj_in.CRMID = CRMID;
                    bfdj_in.KHMC = KHMC;
                    bfdj_in.KHLX = Convert.ToInt32(KHLX);
                    bfdj_in.JHBFKSSJ = XCBFSJ;
                    bfdj_in.JHBFJSSJ = XCBFSJ;
                    //bfdj_in.BFPC = 0;
                    bfdj_in.ISACTIVE = 1;
                    rst = crmModels.BF_BF.Create_BFDJ(bfdj_in, Session["token"].ToString()).ToString();
                }
                return rst;
            }
            else
            {
                return "0";
            }
        }

        [HttpPost]
        public string get_bfrz_cx(string BFRYID, string STAFFNAME, string STAFFNO, string BFLX, string CRMID, string KHMC, string KHLX, string FROMDATE, string TODATE, string ISACTIVE)
        {
            string rst = "";
            CRM_BF_BFDJList bf_bfdj = new CRM_BF_BFDJList();
            bf_bfdj.BFRYID = Convert.ToInt32(BFRYID);
            //bf_bfdj.STAFFNAME = STAFFNAME;
            //bf_bfdj.STAFFNO = STAFFNO;
            bf_bfdj.BFLX = Convert.ToInt32(BFLX);
            bf_bfdj.CRMID = CRMID;
            bf_bfdj.KHMC = KHMC;
            bf_bfdj.KHLX = Convert.ToInt32(KHLX);
            //bf_bfdj.FROMDATE = FROMDATE;
            //bf_bfdj.TODATE = TODATE;
            bf_bfdj.ISACTIVE = Convert.ToInt32(ISACTIVE);
            CRM_BF_BFDJList[] bf = crmModels.BF_BF.Report_BFDJ(bf_bfdj, Session["token"].ToString());
            rst = Newtonsoft.Json.JsonConvert.SerializeObject(bf);
            return rst;

        }

        [HttpPost]
        public int Data_Insert_BFDJ(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_BF_BFDJ model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_BF_BFDJ>(data);
            model.JHBFKSSJ = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if (model.ISACTIVE == 1)
                model.JHBFJSSJ = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            else
                model.JHBFJSSJ = "";
            int i = crmModels.BF_BF.Create_BFDJ(model, token);
            return i;
        }

        //[HttpPost]
        //public string Data_Select_BFDJ(int staffid, int BFLX,string CRMID,string KHMC,int KHLX)
        //{
        //    token = appClass.CRM_Gettoken();
        //    CRM_BF_BFDJList model = new CRM_BF_BFDJList();
        //    model.STAFFNO = crmModels.HG_STAFF.ReadBySTAFFID(staffid, token).STAFFNO;
        //    model.BFLX = BFLX;
        //    model.CRMID = CRMID;
        //    model.KHMC = KHMC;
        //    model.KHLX = KHLX;
        //    CRM_BF_BFDJList[] data = crmModels.BF_BF.Report_BFDJ(model, token);
        //    string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
        //    return s;
        //}
        [HttpPost]
        public string Data_Select_BFDJ_BY_STAFFID(string bfdata, int isGun)
        {
            token = appClass.CRM_Gettoken();
            CRM_BF_BFDJ_PARAMS model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_BF_BFDJ_PARAMS>(bfdata);
            if (model.BFRYID == 0)
            {
                model.BFRYID = Convert.ToInt32(Session["STAFFID"]);
                isGun = 1;
            }

            CRM_BF_BFDJList[] data = crmModels.BF_BF.Read(model, isGun, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public string Data_Select_BFDJ_summary(string bfdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_BF_ReportParam model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_BF_ReportParam>(bfdata);
            CRM_BF_REPORTSUMMARY[] data = crmModels.BF_BF.Report_Summary(model, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public string Data_Select_BFDJ_detail(string bfdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_BF_ReportParam model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_BF_ReportParam>(bfdata);
            CRM_BF_REPORTDETAIL[] data = crmModels.BF_BF.Report_Detail(model, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public string Data_Select_BFDJ_BY_BFDJID(int BFDJID)
        {
            token = appClass.CRM_Gettoken();
            CRM_BF_BFDJ data = crmModels.BF_BF.ReadByBFDJID(BFDJID, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public int Data_Update_BFDJ(string data, int BFDJID)
        {
            token = appClass.CRM_Gettoken();
            CRM_BF_BFDJ newmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_BF_BFDJ>(data);
            CRM_BF_BFDJ djmodel = crmModels.BF_BF.ReadByBFDJID(BFDJID, token);
            djmodel.LXR = newmodel.LXR;
            djmodel.LXRTEL = newmodel.LXRTEL;
            djmodel.LXRZW = newmodel.LXRZW;
            djmodel.BFMD = newmodel.BFMD;
            djmodel.BFJG = newmodel.BFJG;
            djmodel.QTXX = newmodel.QTXX;
            djmodel.ISACTIVE = newmodel.ISACTIVE;
            if (newmodel.ISACTIVE == 1)
                djmodel.JHBFJSSJ = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            int i = crmModels.BF_BF.Update_BFDJ(djmodel, token);
            return i;
        }

        [HttpPost]
        public int Data_Delete_BFDJ(int BFDJID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.BF_BF.Delete_BFDJ(BFDJID, token);
            return i;
        }

        [HttpPost]
        public int Data_Insert_BFqudao(int BFDJID, string qudaoName)
        {
            token = appClass.CRM_Gettoken();
            CRM_BF_BFQD model = new CRM_BF_BFQD();
            model.BFDJID = BFDJID;
            model.QDID = crmModels.HG_DICT.ReadByDICNAME(qudaoName, 7, token);
            int i = crmModels.BF_BFQD.Create(model, token);
            return i;
        }

        [HttpPost]
        public string Data_Select_BFqudao(int BFDJID)
        {
            token = appClass.CRM_Gettoken();
            CRM_BF_BFQDLIST[] data = crmModels.BF_BFQD.ReadByBFDJID(BFDJID, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public int Data_Delete_BFqudao(int BFQDID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.BF_BFQD.Delete(BFQDID, token);
            return i;
        }


        //从零开始的拜访模块

        public ActionResult Backlog()
        {
            Session["location"] = 56;
            return View();
        }

        [HttpPost]
        public string Data_Select_BacklogTotal()
        {
            token = appClass.CRM_Gettoken();
            CRM_PENDING_SUMMARY[] data = crmModels.CRM_PENGING.Read_Summary(Convert.ToInt32(Session["STAFFID"]), token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public string Data_Select_backlogMX(int summaryid)
        {
            token = appClass.CRM_Gettoken();
            CRM_PENDING_DETAIL[] data = crmModels.CRM_PENGING.Read_Detail(Convert.ToInt32(Session["STAFFID"]), summaryid, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        public ActionResult ZXManage()         //专项活动
        {
            Session["location"] = 57;
            DateTime enddate = DateTime.Now;
            DateTime startdate = enddate.AddMonths(-3);
            ViewBag.enddate = enddate.ToString("yyyy-MM-dd");
            ViewBag.startdate = startdate.ToString("yyyy-MM-dd");
            return View();
        }

        public ActionResult Insert_ZX()
        {
            return View();
        }

        public ActionResult Update_ZX()
        {
            return View();
        }

        public ActionResult ZPManage()        //拜访指派
        {
            Session["location"] = 58;
            DateTime enddate = DateTime.Now;
            DateTime startdate = enddate.AddMonths(-3);
            ViewBag.enddate = enddate.ToString("yyyy-MM-dd");
            ViewBag.startdate = startdate.ToString("yyyy-MM-dd");
            return View();
        }

        public ActionResult Insert_ZP()
        {
            return View();
        }

        public ActionResult Update_ZP()
        {
            return View();
        }

        public ActionResult PlanManage()
        {
            Session["location"] = 59;
            return View();
        }

        public ActionResult BaiFangReportBySTAFF()
        {
            token = appClass.CRM_Gettoken();
            Session["location"] = 65;
            ViewBag.Department = crmModels.HG_DEPT.ReadByStaffid(Convert.ToInt32(Session["STAFFID"]), token);
            ViewBag.STAFF = crmModels.HG_STAFF.ReadSTAFF_KHGOURPBYSTAFFID(Convert.ToInt32(Session["STAFFID"]), token);
            ViewBag.STAFFLX = crmModels.HG_DICT.Read(33, 0, token);
            return View();
        }

        public ActionResult BaiFangReportByDate()
        {
            token = appClass.CRM_Gettoken();
            Session["location"] = 504;
            ViewBag.Department = crmModels.HG_DEPT.ReadByStaffid(Convert.ToInt32(Session["STAFFID"]), token);
            ViewBag.STAFF = crmModels.HG_STAFF.ReadSTAFF_KHGOURPBYSTAFFID(Convert.ToInt32(Session["STAFFID"]), token);
            ViewBag.STAFFLX = crmModels.HG_DICT.Read(33, 0, token);
            return View();
        }

        [HttpPost]
        public int Data_Insert_Plan(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_BF_BFJH model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_BF_BFJH>(data);
            model.STAFFID = Convert.ToInt32(Session["STAFFID"]);
            model.CJSJ = DateTime.Now.ToString();
            int i = crmModels.BF_BF.Create_BFJH(model, token);
            return i;
        }

        [HttpPost]
        public string Data_Select_Plan(int BFLX, string BFJHMC, string START, string END, int STAFFID)
        {
            token = appClass.CRM_Gettoken();
            CRM_BF_BFJHList[] data = crmModels.BF_BF.ReadByParams(BFLX, BFJHMC, START, END, STAFFID, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public string Data_Select_PlanByBFJHID(int BFJHID)
        {
            token = appClass.CRM_Gettoken();
            CRM_BF_BFJH data = crmModels.BF_BF.Read_BFJDByID(BFJHID, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public int Data_Update_Plan(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_BF_BFJH model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_BF_BFJH>(data);
            int i = crmModels.BF_BF.Update_BFJH(model, token);
            return i;
        }

        [HttpPost]
        public int Data_Delete_Plan(int BFJHID)
        {
            token = appClass.CRM_Gettoken();
            int i = crmModels.BF_BF.Delete_BFJH(BFJHID, token);
            return i;
        }

        [HttpPost]
        public int Data_Insert_PlanMX(string data, int BFJHID)
        {
            token = appClass.CRM_Gettoken();
            CRM_KH_KHList[] khmodel = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_KH_KHList[]>(data);
            CRM_BF_BFJHMX[] model = new CRM_BF_BFJHMX[khmodel.Length];
            for (int j = 0; j < model.Length; j++)
            {
                STAFFDUTY_KH[] staff = crmModels.HG_STAFF.ReadSTAFFBYKHIDANDDUTY(khmodel[j].KHID, 5, token);
                model[j] = new CRM_BF_BFJHMX();
                model[j].BFJHID = BFJHID;
                model[j].KHID = khmodel[j].KHID;
                model[j].KHMC = khmodel[j].MC;
                model[j].KHLX = khmodel[j].KHLX;
                model[j].ISACTIVE = 1;
                if (staff == null || staff.Length == 0)
                {
                    model[j].BFRYID = 0;
                }
                else
                {
                    model[j].BFRYID = staff[staff.Length - 1].STAFFID;
                }

                int i = crmModels.BF_BFJHMX.Create(model[j], token);
                if (i <= 0)
                    return 0;
            }

            return 1;
        }

        [HttpPost]
        public string Data_Select_PlanMX(int BFJHID)
        {
            token = appClass.CRM_Gettoken();
            CRM_BF_BFJHMXList[] data = crmModels.BF_BFJHMX.ReadbyBFJHID(BFJHID, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public int Data_Update_PlanMX(string data)
        {
            token = appClass.CRM_Gettoken();
            CRM_BF_BFJHMX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_BF_BFJHMX>(data);
            int i = crmModels.BF_BFJHMX.Update(model, token);
            return i;
        }

        [HttpPost]
        public int Data_Update_PlanMX_STAFF(string data, int STAFFID)
        {
            token = appClass.CRM_Gettoken();
            CRM_BF_BFJHMX model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_BF_BFJHMX>(data);
            model.BFRYID = STAFFID;
            int i = crmModels.BF_BFJHMX.Update(model, token);
            return i;
        }

        [HttpPost]
        public int Data_Delete_PlanMX(int BFJHMXID)
        {
            token = appClass.CRM_Gettoken();
            CRM_BF_BFJHMX model = new CRM_BF_BFJHMX();
            model.BFJHMXID = BFJHMXID;
            int i = crmModels.BF_BFJHMX.Delete(model, token);
            return i;
        }

        [HttpPost]
        public string Data_Select_STAFF_ToDDL()
        {
            token = appClass.CRM_Gettoken();
            CRM_HG_STAFF[] data = crmModels.HG_STAFF.ReadSTAFF_KHGOURPBYSTAFFID(Convert.ToInt32(Session["STAFFID"]), token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public string Data_Select_STAFF_ToDDL_ByDuty(int DUTYID)
        {
            token = appClass.CRM_Gettoken();
            CRM_HG_STAFF[] data = crmModels.HG_STAFF.ReadSTAFF_KHGroupByStaffidAndDuty(Convert.ToInt32(Session["STAFFID"]), DUTYID, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public int Data_Set_KH_KHBF(int KHID, int BFID)
        {
            token = appClass.CRM_Gettoken();
            CRM_KH_KHBFList model = new CRM_KH_KHBFList();
            model.KHID = KHID;
            model.BFID = 0;
            crmModels.KH_KHBF.Delete(model, token);
            //先把该客户已经有的频次删掉，然后再新增，确保一个客户只有一个频次
            model.BFID = BFID;
            int i = crmModels.KH_KHBF.Create(model, token);
            return i;
        }

        [HttpPost]
        public string Data_Select_KH_BF()       //查询出所有的拜访频次信息
        {
            token = appClass.CRM_Gettoken();
            CRM_KH_BF model = new CRM_KH_BF();
            model.ISACTIVE = 1;
            CRM_KH_BFList[] data = crmModels.KH_BF.Read(model, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public string Data_Select_KH_KHBF(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_KH_KHBF_Parms model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_KH_KHBF_Parms>(cxdata);
            CRM_KH_KHBFList[] data = crmModels.KH_KHBF.ReadByParms(model, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public int Data_Delete_KH_KHBF(int KHID, int BFID)
        {
            token = appClass.CRM_Gettoken();
            CRM_KH_KHBFList model = new CRM_KH_KHBFList();
            model.KHID = KHID;
            model.BFID = BFID;
            int i = crmModels.KH_KHBF.Delete(model, token);
            return i;
        }

        [HttpPost]
        public string Data_Report_BFDJ_Total(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_KHDJ_REPORT_PARAMS model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_KHDJ_REPORT_PARAMS>(cxdata);
            model.STAFFID = Convert.ToInt32(Session["STAFFID"]);
            CRM_KHDJ_REPORT_SUMMARY[] data = crmModels.BF_BF.ReadKHBF_BFDJ_SUMMARY(model, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public string Data_Report_BFDJ_Detail(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_KHDJ_REPORT_PARAMS model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_KHDJ_REPORT_PARAMS>(cxdata);
            model.STAFFID = Convert.ToInt32(Session["STAFFID"]);
            CRM_KHDJ_REPORT_DETAIL[] data = crmModels.BF_BF.ReadKHBF_BFDJ_DETAIL(model, token);
            string s = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return s;
        }

        [HttpPost]
        public string Data_DaoChu_BaiFang(string data)
        {
            token = appClass.CRM_Gettoken();
            PublicController otherController = DependencyResolver.Current.GetService<PublicController>();
            string result = otherController.ToExcel(data, 4, token);

            return result;
        }

        [HttpPost]
        public string Data_ReportBySTAFF_SummaryTotal(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_BF_REPORT_BYSTAFF_PARAMS model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_BF_REPORT_BYSTAFF_PARAMS>(cxdata);
            CRM_BF_REPORT_BYSTAFF_SUMMARYTOTAL[] data = crmModels.BF_BF.ReadKHBF_ReportByStaff_SummaryTotal(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_ReportBySTAFF_Summary(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_BF_REPORT_BYSTAFF_PARAMS model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_BF_REPORT_BYSTAFF_PARAMS>(cxdata);
            CRM_BF_REPORT_BYSTAFF_SUMMARY[] data = crmModels.BF_BF.ReadKHBF_ReportByStaff_Summary(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_ReportBySTAFF_Detail(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            CRM_BF_REPORT_BYSTAFF_PARAMS model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_BF_REPORT_BYSTAFF_PARAMS>(cxdata);
            CRM_BF_BFDJList[] data = crmModels.BF_BF.ReadKHBF_ReportByStaff_Detail(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public string Data_Daochu_BaiFangSummaryAndMX(string cxdata, string starttime, string endtime)
        {
            token = appClass.CRM_Gettoken();
            try
            {
                CRM_BF_REPORT_BYSTAFF_PARAMS data = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_BF_REPORT_BYSTAFF_PARAMS>(cxdata);
                CRM_BF_REPORT_BYSTAFF_SUMMARYTOTAL[] model = crmModels.BF_BF.ReadKHBF_ReportByStaff_SummaryTotal(data, token);


                FileStream file = new FileStream(FileSavePath + @"\ExcelTemplate/拜访报表-人员.xls", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new HSSFWorkbook(file);
                ISheet worksheet1 = workbook.GetSheet("汇总");
                ISheet worksheet2 = workbook.GetSheet("各类型拜访次数");
                ISheet worksheet3 = workbook.GetSheet("拜访明细");
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
                    row_hz.CreateCell(3).SetCellValue(model[i].TOTAL_COUNT);

                    row1++;


                    CRM_BF_REPORT_BYSTAFF_PARAMS cxmodel = new CRM_BF_REPORT_BYSTAFF_PARAMS();
                    cxmodel.STAFFID = model[i].STAFFID;
                    cxmodel.BEGINDATE = starttime;
                    cxmodel.ENDDATE = endtime;
                    CRM_BF_REPORT_BYSTAFF_SUMMARY[] BFCSdata = crmModels.BF_BF.ReadKHBF_ReportByStaff_Summary(cxmodel, token);
                    for (int j = 0; j < BFCSdata.Length; j++)
                    {

                        NPOI.SS.UserModel.IRow row_bfcs = worksheet2.CreateRow(row2);
                        row_bfcs.CreateCell(0).SetCellValue(model[i].STAFFNAME);
                        row_bfcs.CreateCell(1).SetCellValue(model[i].STAFFNO);
                        row_bfcs.CreateCell(2).SetCellValue(model[i].DEPNAME);
                        row_bfcs.CreateCell(3).SetCellValue(BFCSdata[j].BFLXDES);
                        row_bfcs.CreateCell(4).SetCellValue(BFCSdata[j].FINISHCOUNTS);


                        row2++;



                        CRM_BF_REPORT_BYSTAFF_PARAMS cxmodel2 = new CRM_BF_REPORT_BYSTAFF_PARAMS();
                        cxmodel2.BEGINDATE = starttime;
                        cxmodel2.ENDDATE = endtime;
                        cxmodel2.STAFFID = model[i].STAFFID;
                        cxmodel2.BFLX = BFCSdata[j].BFLX;

                        CRM_BF_BFDJList[] MXdata = crmModels.BF_BF.ReadKHBF_ReportByStaff_Detail(cxmodel2, token);
                        for (int k = 0; k < MXdata.Length; k++)
                        {
                            NPOI.SS.UserModel.IRow row_mx = worksheet3.CreateRow(row3);
                            row_mx.CreateCell(0).SetCellValue(MXdata[k].BFLXDES);
                            row_mx.CreateCell(1).SetCellValue(MXdata[k].BFJHMC);
                            row_mx.CreateCell(2).SetCellValue(MXdata[k].KHMC);
                            row_mx.CreateCell(3).SetCellValue(MXdata[k].CRMID);
                            row_mx.CreateCell(4).SetCellValue(MXdata[k].KHLXDES);
                            row_mx.CreateCell(5).SetCellValue(MXdata[k].STAFFNAME);
                            row_mx.CreateCell(6).SetCellValue(MXdata[k].JHBFJSSJ);
                            row_mx.CreateCell(7).SetCellValue(MXdata[k].BFDZ);
                            row_mx.CreateCell(8).SetCellValue(MXdata[k].LXR);
                            row_mx.CreateCell(9).SetCellValue(MXdata[k].LXRTEL);
                            row_mx.CreateCell(10).SetCellValue(MXdata[k].LXRZWDES);
                            row_mx.CreateCell(11).SetCellValue(MXdata[k].BFMDDES);
                            row_mx.CreateCell(12).SetCellValue(MXdata[k].BFJGDES);
                            row_mx.CreateCell(13).SetCellValue(MXdata[k].QTXX);
                            row_mx.CreateCell(14).SetCellValue(MXdata[k].KQJL + "米");
                            row_mx.CreateCell(15).SetCellValue(MXdata[k].KQISACTIVE == 1 ? "是" : "否");

                            row3++;
                        }


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


        [HttpPost]
        public string Data_ReportByDate_SummaryTotal(string cxdata)
        {
            token = appClass.CRM_Gettoken();
            DataTablePlus data = new DataTablePlus();
            CRM_BF_REPORT_BYSTAFF_PARAMS model = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_BF_REPORT_BYSTAFF_PARAMS>(cxdata);
            DataTable data1 = crmModels.BF_BF.ReadKHBF_ReportByDate_Summary(model, token);
            string title = data1.Columns[0].ColumnName;
            for (int i = 1; i < data1.Columns.Count; i++)
            {
                title = title + "," + data1.Columns[i].ColumnName;
            }
            data.DATA = data1;
            data.TITLE = title;
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }


        [HttpPost]
        public string Data_Daochu_BaiFangReport_Data(string data)
        {
            token = appClass.CRM_Gettoken();
            PublicController otherController = DependencyResolver.Current.GetService<PublicController>();
            string result = otherController.ToExcel(data, 11, token);

            return result;
        }














    }
}
