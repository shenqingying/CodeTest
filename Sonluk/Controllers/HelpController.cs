using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Reflection;
using Sonluk.Models;

namespace Sonluk.Controllers
{
    public class HelpController : Controller
    {
        SettingModels models = new SettingModels();

        //
        // GET: /Help/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Help/About
        public ActionResult About()
        {
            ViewBag.UserVersion = ConfigurationManager.AppSettings["UserVersion"];
            ViewBag.Version =  ConfigurationManager.AppSettings["Version"];
            ViewBag.ReleaseDate = ConfigurationManager.AppSettings["ReleaseDate"];
            Assembly asm = Assembly.Load("Sonluk");
            ViewBag.UI = asm.GetName().Version.ToString();
            ViewBag.Server = models.Version.Read();
            return View();
        }


        //
        // GET: /Help/UserManual
        public ActionResult UserManual()
        {
            return View();
        }

    }
}
