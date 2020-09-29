using Sonluk.Models;
using Sonluk.UI.Model.BC.UserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sonluk.Areas.BC.Controllers
{
    public class UserController : Controller
    {
        BCModels models = new BCModels();

        //
        // GET: /BC/User/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /BC/User/Read
        [HttpPost]
        public string _Read(string signInName)
        {
            return (models.User.Read(signInName)).Address.FullName;
        }

    }
}
