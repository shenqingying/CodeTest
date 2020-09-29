using Sonluk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sonluk.UI.Model.Print.LayoutService;
using Sonluk.Utility;
using Sonluk.Filters;

namespace Sonluk.Areas.Print.Controllers
{
    public class LayoutController : Controller
    {
        PrintModels models = new PrintModels();

        //
        // GET: /Print/Layout/
        [Authorization]
        public ActionResult Index()
        {
            return View(models.Layout.Read());
        }

        //
        // GET: /Print/Layout/Edit
        public ActionResult Edit(int ID, string status)
        {
            LayoutInfo node;
            if (ID == 0)
                node = new LayoutInfo();
            else
                node = models.Layout.Read(ID);

            if (status != null && status.Equals("copy"))
            {
                node.ID = 0;
                node.Doc = "";
                node.Name = "";
            }

            return View(node);
        }

        //
        // POST: /Print/Layout/Save
        [HttpPost]
        public int Save(LayoutInfo node)
        {
            if (node.ID > 0)
            {
                models.Layout.Update(node);
            }
            else
            {
                node.ID=models.Layout.Create(node);
            }

            return node.ID;
        }

        //
        // GET: /Print/Layout/Save
        public int Delete(int ID)
        {
            if (!models.Layout.Delete(ID))
                ID = 0;

            return ID;
        }

        //
        // GET:/Print/Layout/Print/
        public ActionResult Print(string doc, string mac, string data, string quickPrint)
        {
            if (Session["Print.ConsignmentNote.JSON"] != null)
                ViewBag.Data = Session["Print.ConsignmentNote.JSON"];
            else
                ViewBag.Data = "";

            if (Session["ConsignmentNote_CHK"] != null)
                ViewBag.Message = Session["ConsignmentNote_CHK"];
            else
                ViewBag.Message = "";

            ViewBag.Name = "";
            ViewBag.QuickPrint = quickPrint;
            ViewBag.doc = doc;
            return View(models.Layout.Read(doc, mac));
        }

        //
        // POST: /Print/Layout/UploadBackground
        [HttpPost]
        public void UploadBackground(HttpPostedFileBase file)
        {
            try
            {
                //string fileName;
                //string filePath;
                //fileName = node.File.FileName;
                //if (fileName.LastIndexOf(@"\") > -1)
                //{
                //    fileName = fileName.Substring(fileName.LastIndexOf(@"\") + 1);
                //}
                //filePath = ConfigurationManager.AppSettings["TempletBackgroundPath"];
                //if (!Directory.Exists(filePath))
                //{
                //    Directory.CreateDirectory(filePath);
                //}
                //filePath = filePath + "/" + fileName;
                //node.Value = fileName;
                //node.File.SaveAs(filePath);
                Response.Write("<script>window.parent.readBySO();</script>");
            }
            catch (Exception e)
            {
                Logger.Write("Print.LayoutController", e.Message.ToString());
                Response.Write("<script>window.parent.importError();</script>");
            }


        }



    }
}
