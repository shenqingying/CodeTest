using Sonluk.Models;
using Sonluk.UI.Model.LE.TRA.ReceiverService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sonluk.Areas.LE.Controllers
{
    public class ReceiverController : Controller
    {
        LETRAModels models = new LETRAModels();

        //
        // GET: /LE/Receiver/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /LE/Receiver/_List
        public ActionResult _List(int city)
        {
            return PartialView(models.Receiver.Read(city));
        }

        //
        // GET: /LE/Receiver/_List
        public ActionResult _Search(string keyword)
        {
            return PartialView(models.Receiver.Select(keyword));
        }

        //
        // GET: /LE/Receiver/_Exists
        public bool _Exists(string serialNumber)
        {
            return models.Receiver.Exists(serialNumber);
        }

        //
        // GET: /LE/Receiver/_Edit
        public ActionResult _Edit(string serialNumber)
        {
            return PartialView(models.Receiver.Read(serialNumber));
        }

        //
        // GET: /LE/Receiver/_Update
        public int _Update(CompanyInfo node)
        {
            return models.Receiver.Update(node);
        }

    }
}
