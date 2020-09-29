using Newtonsoft.Json;
using Sonluk.Models;
using Sonluk.UI.Model.LE.TRA.GoodsService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sonluk.Areas.LE.Controllers
{
    public class GoodsController : Controller
    {
        LETRAModels models = new LETRAModels();

        //
        // GET: /LE/Goods/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /LE/Goods/_Type
        public ActionResult _Type()
        {
            return PartialView(models.Goods.Type());
        }

        //
        // GET: /LE/Goods/_Read
        public string _Read(string serialNumber)
        {
            return JsonConvert.SerializeObject(models.Goods.Read(serialNumber));
        }

        //
        // GET: /LE/Goods/_Update
        public int _Update(GoodsInfo node)
        {
            return models.Goods.Update(node);
        }
    }
}
