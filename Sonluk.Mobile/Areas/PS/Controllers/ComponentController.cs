using Newtonsoft.Json;
using Sonluk.Mobile.APPCLASS;
using Sonluk.Mobile.Models;
using Sonluk.UI.Model.PS.ComponentMoveService;
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

namespace Sonluk.Mobile.Areas.PS.Controllers
{
    public class ComponentController : Controller
    {
        //
        // GET: /PS/Component/
        PSModels psmodels = new PSModels();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult cgds()
        {
            Session["TITLENAME"] = "采购点收";
            return View();
        }


        [HttpPost]
        public ActionResult _cgdslist(string in_bl)
        {
            string token = AppClass.GetSession("token").ToString();
            PS_ZPSFUG_Q_CGDS ps = psmodels.ComponentMove.Component_DSXX(in_bl, token);
            ViewData.Model = ps;
            return View();
        }
        [HttpPost]
        public string cgds_read(string in_bl)
        {
            string token = AppClass.GetSession("token").ToString();
            PS_ZPSFUG_Q_CGDS ps = psmodels.ComponentMove.Component_DSXX(in_bl, token);
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(ps);
            return json;
        }

        [HttpPost]
        public string _cgdssave(string ERFMG, string MENGE, string EBELN, string EBELP, string AUFNR, string VORNR, string LARNT, string ARBPL, string WERKS, string MEINS)
        {
            string token = AppClass.GetSession("token").ToString();
            string BKTXT = Session["NAME"].ToString();
            string INITS = Session["ID"].ToString();
            ZSL_PSS_INC_CGDS i_in = new ZSL_PSS_INC_CGDS();
            i_in.ERFMG = ERFMG;
            i_in.MENGE = MENGE;
            i_in.EBELN = EBELN;
            i_in.EBELP = EBELP;
            i_in.BKTXT = BKTXT;
            i_in.AUFNR = AUFNR;
            i_in.VORNR = VORNR;
            i_in.INITS = INITS;
            i_in.LARNT = LARNT;
            i_in.ARBPL = ARBPL;
            i_in.WERKS = WERKS;
            i_in.MEINS = MEINS;


            string rst = psmodels.ComponentMove.Component_ljds(i_in, token);
            rst = rst.Replace("\"", "");
            return rst;
        }

        public ActionResult ComponentPutaway()
        {
            Session["TITLENAME"] = "零件上架";
            return View();
        }

        [HttpPost]
        public string NetWorkRead(string in_bl)
        {
            string token = AppClass.GetSession("token").ToString();
            PS_ZPSFUG_Q_LJSJ networkinfo = psmodels.NetWork.NetWork_READ_main(in_bl, token);
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(networkinfo);
            return json;
        }


        [HttpPost]
        public string Component_LJSJ(string AUFNR, string MENGE, string NLPLA, string ZMATNR, string POSID, string ARBPL, string LARNT, string VORNR, string LGNUM, string LGTYP, string LGBER, string LPTYP, string WERKS, string LGORT)
        {
            string token = AppClass.GetSession("token").ToString();
            string rst = "";
            PS_componentputaway ps_componentputaway = new PS_componentputaway();
            ps_componentputaway.RUFNM = Session["ID"].ToString();
            ps_componentputaway.AUFNR = AUFNR;
            ps_componentputaway.MENGE = MENGE;
            ps_componentputaway.NLPLA = NLPLA;
            ps_componentputaway.ZMATNR = ZMATNR;
            ps_componentputaway.POSID = POSID;
            ps_componentputaway.ARBPL = ARBPL;
            ps_componentputaway.LARNT = LARNT;
            ps_componentputaway.VORNR = VORNR;
            ps_componentputaway.LGNUM = LGNUM;
            ps_componentputaway.LGTYP = LGTYP;
            ps_componentputaway.LGBER = LGBER;
            ps_componentputaway.LPTYP = LPTYP;
            ps_componentputaway.WERKS = WERKS;
            ps_componentputaway.LGORT = LGORT;

            rst = psmodels.ComponentMove.ComponentPutAway(ps_componentputaway, token);
            rst = rst.Replace("\"", "");
            return rst;
        }

        public ActionResult ComponentSoldout()
        {
            Session["TITLENAME"] = "零件下架";
            return View();
        }

        [HttpPost]
        public string ComponentSoldout_read(string in_bl)
        {
            string token = AppClass.GetSession("token").ToString();
            PS_ZPSFUG_Q_LJXJ ps_ljxj = new PS_ZPSFUG_Q_LJXJ();
            string SENUM = in_bl.Substring(0, 10);
            string ZROWSNUM = in_bl.Substring(10, 4);
            ps_ljxj = psmodels.ComponentMove.ComponentSoldout_read(SENUM, ZROWSNUM, token);
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(ps_ljxj);
            return json;
        }

        [HttpPost]
        public string ComponentSoldout(string RSNUM, string RSPOS, string MATNR, string SENUM, string ZROWSNUM, string LGPLA, string VERME, string MENGE, string LGBER, string LPTYP, string LGNUM, string WERKS, string LGORT, string LGTYP, string ZJUDGE)
        {
            string token = AppClass.GetSession("token").ToString();
            ZSL_PSS_INC_LJXJ ps_i = new ZSL_PSS_INC_LJXJ();
            ps_i.RSNUM = RSNUM;
            ps_i.RSPOS = RSPOS;
            ps_i.MATNR = MATNR;
            ps_i.SENUM = SENUM;
            ps_i.ZROWSNUM = ZROWSNUM;
            ps_i.LGPLA = LGPLA;
            ps_i.VERME = VERME;
            ps_i.MENGE = MENGE;
            ps_i.LGBER = LGBER;
            ps_i.LPTYP = LPTYP;
            ps_i.LGNUM = LGNUM;
            ps_i.WERKS = WERKS;
            ps_i.LGORT = LGORT;
            ps_i.LGTYP = LGTYP;
            ps_i.ZJUDGE = ZJUDGE;
            ps_i.ZUSER = Session["NAME"].ToString();

            //ZSL_PSS_IN_LJXJ ps_t = new ZSL_PSS_IN_LJXJ();
            //ps_t.MENGE = MENGE;
            //ps_t.LGPLA = LGPLA;
            //ps_t.VERME = VERME;
            Sonluk.UI.Model.PS.ComponentMoveService.PS_MSG ps_msg = psmodels.ComponentMove.ComponentSoldout(ps_i, token);
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(ps_msg);
            return json;
        }



        [HttpPost]
        public string ComponentInventory_Network(string in_bl)
        {
            string token = AppClass.GetSession("token").ToString();
            PS_ZPSFUG_Q_WLCC ps = new PS_ZPSFUG_Q_WLCC();
            ps = psmodels.ComponentMove.ComponentInventory_Network(in_bl, token);
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(ps);
            return json;
        }

        [HttpPost]
        public string ComponentInventory_CM(string in_bl)
        {
            string token = AppClass.GetSession("token").ToString();
            PS_ZPSFUG_Q_CMCC component = psmodels.ComponentMove.ComponentInventory_CM(in_bl, token);
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(component);
            return json;
        }

        [HttpPost]
        public string ComPonentCM_GET(string in_bl)
        {
            string token = AppClass.GetSession("token").ToString();
            ComponentCM[] component = psmodels.ComponentMove.ComponentCM_GET(in_bl, token);
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(component);
            return json;
        }

        public ActionResult ComponentMoving()
        {
            Session["TITLENAME"] = "零件移仓";
            return View();
        }
        [HttpPost]
        public string ComponentMoving_all(string WERKS, string LGORT, string LGNUM, string LPTYP, string NLTYP, string NLBER, string NLPLA, string VLTYP, string VLBER, string VLPLA, string MATNR, string ANFME, string MEINS, string POSID, string BESTQ, string CHARG)
        {
            string token = AppClass.GetSession("token").ToString();
            ZSL_PSS_INC_LJYC i_in = new ZSL_PSS_INC_LJYC();
            i_in.WERKS = WERKS;
            i_in.LGORT = LGORT;
            i_in.LGNUM = LGNUM;
            i_in.LPTYP = LPTYP;
            i_in.NLTYP = NLTYP;
            i_in.NLBER = NLBER;
            i_in.NLPLA = NLPLA;
            i_in.VLTYP = VLTYP;
            i_in.VLBER = VLBER;
            i_in.VLPLA = VLPLA;
            i_in.MATNR = MATNR;
            i_in.ANFME = ANFME;
            i_in.MEINS = MEINS;
            i_in.POSID = POSID;
            i_in.BESTQ = BESTQ;
            i_in.CHARG = CHARG;


            Sonluk.UI.Model.PS.ComponentMoveService.PS_MSG ps_msg = psmodels.ComponentMove.ComponentMoving_all(i_in, token);
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(ps_msg);
            return json;
        }

        public string ComponentMoving_readwlXX(string in_bl)
        {
            string token = AppClass.GetSession("token").ToString();
            PS_wlXX[] ps = psmodels.NetWork.readwlXX(in_bl, "", token);
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(ps);
            return json;
        }

    }
}
