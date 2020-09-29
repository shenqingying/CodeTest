using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;
using Sonluk.Models;
using Sonluk.UI.Model.BC.BarCodeService;

namespace Sonluk.Areas.BC.Controllers
{
    public class BarCodeController : Controller
    {
        BCModels models = new BCModels();
        //
        // GET: /BC/BarCode/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BarCode(string code,string format,string width,string height,string pure)
        {
            //string code = Request.QueryString["code"];
            //string format = Request.QueryString["format"];
            //int width = Convert.ToInt32(Request.QueryString["width"].ToString());
            //int height =  Convert.ToInt32(Request.QueryString["height"].ToString());
            //int pure = Convert.ToInt32(Request.QueryString["pure"].ToString());
            
            Byte[] objcode = models.BarCode.CreateBarCode(code,format,Convert.ToInt32(width),Convert.ToInt32(height),Convert.ToInt32(pure));

            Response.ContentType = "image/jpeg";
            Response.Clear();
            Response.BufferOutput = true;
            Response.BinaryWrite(objcode);
            Response.Flush();
            return View();
        }

        public ActionResult BarCodeMgr()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult PickingtaskConfig()
        {
            IList<ScreenInfo> nodes = models.BarCode.ScreenInfoRead();

            return View(nodes.ToList());
        }
        [AllowAnonymous]
        public bool PickingtaskSet(string warhouse)
        {
            HttpCookie cookie = new HttpCookie("PickingtaskConfig");
            cookie.Value = warhouse;
            cookie.Path = "/";
            cookie.Expires = DateTime.MaxValue;
            Response.Cookies.Add(cookie);

            return true;
        }
        [AllowAnonymous]
        public ActionResult Pickingtask()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult _PickingtaskList()
        {
            string iv_lgnum = "";
            HttpCookie cookie = Request.Cookies.Get("PickingtaskConfig");
            ScreenInfo node = models.BarCode.ScreenInfoRead(Convert.ToInt32(cookie.Value));
            iv_lgnum = node.Location;
            return PartialView(models.BarCode.ZBCFUN_CKGDP_DISPLAY(System.DateTime.Now.ToString("yyyy-MM-dd"), iv_lgnum));
        }
        //
        // GET: /BC/_BarCodeTHZF/
        [HttpPost]
        public string _BarCodeTHZF(string srwlm, string tgwlm, string fcode)
        {
            return models.BarCode.ZBCFUN_TBM_ZFTH(srwlm, tgwlm, fcode);
        }

        public bool ScreenInfoSet(string screenid,string message)
        {
            HttpCookie cookie = new HttpCookie("PickingtaskConfig");
            cookie.Value = screenid.ToString();
            cookie.Path = "/";
            cookie.Expires = DateTime.MaxValue;
            Response.Cookies.Add(cookie);

            ScreenInfo node = models.BarCode.ScreenInfoRead(Convert.ToInt32(screenid));
            node.MContent = message;
            models.BarCode.ScreenInfoUpdate(node);

            return true;
        }

        public string ScreenInfoGet(string screenid)
        {

            ScreenInfo node = models.BarCode.ScreenInfoRead(Convert.ToInt32(screenid));

            return node.MContent;
        }

        public ActionResult ScreenMsg()
        {
            string screenid = "";
            HttpCookie cookie = Request.Cookies.Get("PickingtaskConfig");
            screenid = cookie.Value;
            ScreenInfo node = models.BarCode.ScreenInfoRead(Convert.ToInt32(screenid));
            if (node != null)
            {
                ViewBag.PickingtaskMessage = node.MContent;
            }

            IList<ScreenInfo> nodes = models.BarCode.ScreenInfoRead();

            return View(nodes.ToList());
        }


        public IList<ScreenInfo> ScreenInfoRead()
        {
            IList<ScreenInfo> nodes = models.BarCode.ScreenInfoRead();

            for (int i = nodes.Count; i >= 0; i--)
            { 
                if(nodes[i].Status!=1)
                {
                    nodes.RemoveAt(i);
                }
            }

            return nodes;
        }

        public ActionResult _PickingtaskMessage()
        {
            string screenid = "";
            HttpCookie cookie = Request.Cookies.Get("PickingtaskConfig");
            screenid = cookie.Value;
            return PartialView(models.BarCode.ScreenInfoRead(Convert.ToInt32(screenid)));
        }

        public ActionResult Picking()
        {
            return View();
        }

        public ActionResult _PickingList(string IV_LGNUM, string IV_JPD, string IV_CJRQ_S, string IV_CJRQ_E, string IV_VBELN)
        {
            List<ZSL_BCS107> nodes = models.BarCode.PickingListREAD(IV_LGNUM, IV_JPD, IV_CJRQ_S, IV_CJRQ_E, IV_VBELN).ToList();
            return PartialView(nodes);
        }

        [HttpPost]
        public void AnalysePrintData(IList<ZSL_BCS107> itemNodes)
        {
            Session["ZSL_BCS107"] = itemNodes;
        }

        public ActionResult PickingPrint()
        {
            //string pageSize = "";
            //HttpCookie cookie = Request.Cookies.Get("IQCPMPageSize");
            IList<ZSL_BCS107> itemNodes = (IList<ZSL_BCS107>)Session["ZSL_BCS107"];

            return View(itemNodes);
        }
    }
}
