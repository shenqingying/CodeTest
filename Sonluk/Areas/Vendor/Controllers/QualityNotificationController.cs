using Sonluk.Models;
using Sonluk.UI.Model.OA.PendingService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Sonluk.Areas.Vendor.Controllers
{
    public class QualityNotificationController : Controller
    {
        OAModels models = new OAModels();

        //
        // GET: /Vendor/QualityNotification/
        public ActionResult Index()
        {
            string url = Request.Url.ToString();
            string address = Request.UserHostAddress;
            string account = ((UI.Model.Account.AccessService.AccountInfo)Session["Account"]).ID;
            //IList<PendingInfo> list = models.Pending.Read("V" + account, 0, 100, url);
            return View(models.Pending.Read("V" + account, 0, 100, address));
        }
    }
}
