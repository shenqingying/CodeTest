using Sonluk.PC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web;

namespace Sonluk.PC.APPCLASS
{
    public class AppClass
    {
        string section = System.Configuration.ConfigurationManager.AppSettings["RemoteAddress"]+"API/";
        public static object GetSession(string name)
        {
            if (HttpContext.Current.Session[name] == null)
                return "";
            else
                return HttpContext.Current.Session[name];
        }
        public static void remove_session(string name)
        {
            HttpContext.Current.Session.Remove(name);
        }
        /// <summary>
        /// 设置session
        /// </summary>
        /// <param name="name">session 名</param>
        /// <param name="val">session 值</param>
        public static void SetSession(string name, object val)
        {
            HttpContext.Current.Session.Remove(name);
            HttpContext.Current.Session.Add(name, val);
        }


        public string CRM_Gettoken()
        {
            if (HttpContext.Current.Session["token"] == null)
                return "";
            else
                return HttpContext.Current.Session["token"].ToString();
        }
        public int CRM_GetStaffid()
        {
            if (HttpContext.Current.Session["STAFFID"] == null)
                return 0;
            else
                return Convert.ToInt32(HttpContext.Current.Session["STAFFID"]);
        }
        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <returns></returns>
        public string GetTimeStamp()
        {
            TimeSpan ts = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }
        public static string ModelConvertString(object obj)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        }
        public Stream Apidy(string apihsm, string mysql, string ContentType, List<APIHEADERS> APIHEADER)
        {
            APIHEADERS model_APIHEADERS = new APIHEADERS();
            model_APIHEADERS.KEY = "ptoken";
            model_APIHEADERS.VALUES = CRM_Gettoken();
            APIHEADER.Add(model_APIHEADERS);
            string url = section + apihsm;
            string headers = "";
            for (int a = 0; a < APIHEADER.Count; a++)
            {
                if (headers == "")
                {
                    headers = APIHEADER[a].KEY + "=" + APIHEADER[a].VALUES;
                }
                else
                {
                    headers = headers + "&" + APIHEADER[a].KEY + "=" + APIHEADER[a].VALUES;
                }
            }
            if (headers != "")
            {
                url = url + "?" + headers;
            }
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = ContentType;
            req.UserAgent = "PostmanRuntime/7.18.0";
            byte[] data = Encoding.UTF8.GetBytes(mysql);
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
            }
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            return stream;
        }

        public string API_RETURN_STRING_json(string apihsm, string body, string APIHEADERS)
        {
            string result = "";
            Stream stream = Apidy(apihsm, body, "application/json", Newtonsoft.Json.JsonConvert.DeserializeObject<List<APIHEADERS>>(APIHEADERS));
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }

        #region 用于作为前端和API桥梁的控制器方法

        /// <summary>
        /// 获取前台传入的Json数据，单参数调用API，传回Json结果（需要Token存在）
        /// </summary>
        /// <param name="TPost">传出参数的类型</param>
        /// <param name="TResult">返回结果的类型</param>
        /// <param name="postStr">Json化后的传出参数</param>
        /// <param name="client">调用API的函数（传出数据，Token）</param>
        /// <returns></returns>
        public static string EasyCall<TPost, TResult>(string postStr, Func<TPost, string, TResult> client)
        {
            try
            {
                TResult rstModel = client(Newtonsoft.Json.JsonConvert.DeserializeObject<TPost>(postStr), GetSession("token").ToString());
                return Newtonsoft.Json.JsonConvert.SerializeObject(rstModel);
            }
            catch (Exception e)
            {
                return EasyError<TResult>(e);
            }
        }

        /// <summary>
        /// 获取前台传入的Json数据，单参数调用API，传回Json结果（需要Token，STAFFID存在）
        /// </summary>
        /// <param name="TPost">传出参数的类型</param>
        /// <param name="TResult">返回结果的类型</param>
        /// <param name="postStr">Json化后的传出参数</param>
        /// <param name="client">调用API的函数（传出数据，STAFFID，Token）</param>
        /// <returns></returns>
        public static string EasyCall<TPost, TResult>(string postStr, Func<TPost, int, string, TResult> client)
        {
            try
            {
                TResult rstModel = client(Newtonsoft.Json.JsonConvert.DeserializeObject<TPost>(postStr), Convert.ToInt32(GetSession("STAFFID")), GetSession("token").ToString());
                return Newtonsoft.Json.JsonConvert.SerializeObject(rstModel);
            }
            catch (Exception e)
            {
                return EasyError<TResult>(e);
            }
        }

        /// <summary>
        /// 获取前台传入的类型数据，单参数调用API，传回Json结果（需要Token存在）
        /// </summary>
        /// <param name="TPost">传出参数的类型</param>
        /// <param name="TResult">返回结果的类型</param>
        /// <param name="postStr">传出参数的内容</param>
        /// <param name="client">调用API的函数（传出数据，Token）</param>
        /// <returns></returns>
        public static string EasyCall<TPost, TResult>(TPost postData, Func<TPost, string, TResult> client)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(client(postData, GetSession("token").ToString()));
            }
            catch (Exception e)
            {
                return EasyError<TResult>(e);
            }
        }

        /// <summary>
        /// 获取前台传入的类型数据，单参数调用API，传回Json结果（需要Token，STAFFID存在）
        /// </summary>
        /// <param name="TPost">传出参数的类型</param>
        /// <param name="TResult">返回结果的类型</param>
        /// <param name="postStr">传出参数的内容</param>
        /// <param name="client">调用API的函数（传出数据，STAFFID，Token）</param>
        /// <returns></returns>
        public static string EasyCall<TPost, TResult>(TPost postData, Func<TPost, int, string, TResult> client)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(client(postData, Convert.ToInt32(GetSession("STAFFID")), GetSession("token").ToString()));
            }
            catch (Exception e)
            {
                return EasyError<TResult>(e);
            }
        }

        /// <summary>
        /// 双参数调用API，传回结果（需要Token存在）
        /// </summary>
        /// <param name="TPost1">传出参数1的类型</param>
        /// <param name="TPost2">传出参数2的类型</param>
        /// <param name="TResult">返回结果的类型</param>
        /// <param name="post1">传出参数1的内容</param>
        /// <param name="post2">传出参数2的内容</param>
        /// <param name="client">调用API的函数</param>
        /// <param name="error">调用API出错的函数</param>
        /// <returns></returns>
        public static TResult EasyCall<TPost1, TPost2, TResult>(TPost1 postData1, TPost2 postData2, Func<TPost1, TPost2, string, TResult> client, Func<Exception, TResult> error)
        {
            try
            {
                return client(postData1, postData2, GetSession("token").ToString());
            }
            catch (Exception e)
            {
                return error(e);
            }
        }

        //通用错误返回
        protected static string EasyError<TResult>(Exception e)
        {
            EasyCall_Return rst = new EasyCall_Return();
            rst.MES_RETURN = new EasyCall_Return_Child();
            rst.MES_RETURN.TYPE = "E";
            rst.MES_RETURN.MESSAGE = "服务器异常：" + e.Message;

            if (typeof(TResult).GetProperty("MES_RETURN") == null)
            {
                if (typeof(TResult).GetProperty("TYPE") == null && typeof(TResult).GetProperty("MESSAGE") == null)
                {
                    return Newtonsoft.Json.JsonConvert.SerializeObject(rst.MES_RETURN.MESSAGE);
                }
                else
                {
                    return Newtonsoft.Json.JsonConvert.SerializeObject(rst.MES_RETURN);
                }
            }
            else
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
            }
        }

        //返回结构体
        protected class EasyCall_Return
        {
            public EasyCall_Return_Child MES_RETURN { get; set; }
        }
        protected class EasyCall_Return_Child
        {
            public string TYPE { get; set; }
            public string MESSAGE { get; set; }
        }

        #endregion

        #region 获取父级全名

        public static string getFullName()
        {
            StackTrace st = new StackTrace(true);
            MethodBase mb = st.GetFrame(1).GetMethod();
            return mb.DeclaringType.FullName + "." + mb.Name;
        }

        #endregion
    }
}