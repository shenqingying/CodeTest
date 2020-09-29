using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Sonluk.Filters
{
    public class LogAttribute : ActionFilterAttribute
    {
        public string Message { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            bool access = true;
            string[] negativeController = new string[1] { "Access" };
            string[] activeAction = new string[] { "Insert", "_Insert", "Update", "_Update", "Delete", "_Delete" };
            string controller = (filterContext.RouteData.Values["controller"]).ToString();
            string action = (filterContext.RouteData.Values["action"]).ToString();

            foreach (string negative in negativeController)
            {
                if (negative.Equals(controller))
                {
                    access = false;
                    break;
                }
            }

            if (access)
            {
                access = false;
                foreach (string active in activeAction)
                {
                    if (active.Equals(action))
                    {
                        access = true;
                        break;
                    }
                }
            }

            if (access)
            {
                var parameters = filterContext.ActionDescriptor.GetParameters();
                if (parameters.Count() > 0)
                {
                    try
                    {
                        string jsonString = "";
                        JavaScriptSerializer json = new JavaScriptSerializer();
                        string value;
                        foreach (var parameter in parameters)
                        {
                            if (parameter.ParameterType == typeof(string))
                            {
                                var orginalValue = filterContext.ActionParameters[parameter.ParameterName] as string;
                                value = orginalValue;
                            }
                            else
                            {
                                var orginalValue = filterContext.ActionParameters[parameter.ParameterName];
                                value = json.Serialize(orginalValue);
                            }

                            if (!value.Equals(""))
                                jsonString = jsonString + value + ";";
                        }

                        if (!jsonString.Equals(""))
                        {
                            //LogInfo log = new LogInfo();
                            //log.UID = (int)filterContext.HttpContext.Session["UID"];
                            //log.Name = (string)filterContext.HttpContext.Session["UserName"];
                            //log.Controller = controller;
                            //log.Action = action;
                            //log.Content = jsonString;
                            //EntityDataModels edm = new EntityDataModels();
                            //edm.Log.Insert(log);
                        }
                    }
                    catch
                    {

                    }
                }
            }
        }
    }
}