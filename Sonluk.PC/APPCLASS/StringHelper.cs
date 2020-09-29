using Sonluk.UI.Model.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sonluk.PC.APPCLASS
{
    public class StringHelper
    {

        #region Layui 返回

        /// <summary>
        /// Layui默认返回格式，单参数，适合返回上传信息
        /// </summary>
        /// <param name="msg">返回内容</param>
        /// <returns></returns>
        public static string LayResp(string msg)
        {
            return string.Format("{0}\"msg\":\"{1}\"{2}", "{", msg, "}");
        }

        /// <summary>
        /// Layui默认返回格式，双参数，适合返回上传信息加判断
        /// </summary>
        /// <param name="code">状态码（用于判断）</param>
        /// <param name="msg">返回内容</param>
        /// <returns></returns>
        public static string LayResp(int code, string msg)
        {
            return string.Format("{0}\"code\":{1},\"msg\":\"{2}\"{3}", "{", code, msg, "}");
        }

        /// <summary>
        /// Layui默认返回格式，完整参数，适用于表格异步数据接口
        /// </summary>
        /// <param name="code">状态码（用于判断，默认0为成功）</param>
        /// <param name="msg">状态信息</param>
        /// <param name="count">数据总数</param>
        /// <param name="data">数据表（List）</param>
        /// <returns></returns>
        public static string LayResp<Type>(int code, string msg, int count, Type data)
        {
            return string.Format("{0}\"code\":{1},\"msg\":\"{2}\",\"count\":{3},\"data\":{4}{5}", "{", code, msg, count, Newtonsoft.Json.JsonConvert.SerializeObject(data), "}");
        }

        /// <summary>
        /// Layui默认返回格式（成功返回），单参数，适用于表格异步数据接口
        /// </summary>
        /// <param name="data">数据表（List）</param>
        /// <returns></returns>
        public static string LayResp<Type>(Type data)
        {
            return string.Format("{0}\"code\":0,\"msg\":\"Success\",\"count\":0,\"data\":{1}{2}", "{", Newtonsoft.Json.JsonConvert.SerializeObject(data), "}");
        }

        /// <summary>
        /// Layui默认返回格式（成功返回），双参数，适用于表格异步数据接口
        /// </summary>
        /// <param name="count">数据总数</param>
        /// <param name="data">数据表（List）</param>
        /// <returns></returns>
        public static string LayResp<Type>(int count, Type data)
        {
            return string.Format("{0}\"code\":0,\"msg\":\"Success\",\"count\":{1},\"data\":{2}{3}", "{", count, Newtonsoft.Json.JsonConvert.SerializeObject(data), "}");
        }

        #endregion

        #region JS 对象

        /// <summary>
        /// 将MES_RETURN转为包含MES_RETURN的JS对象并序列化
        /// </summary>
        /// <param name="TYPE">MES_RETURN.TYPE</param>
        /// <param name="MESSAGE">MES_RETURN.MESSAGE</param>
        /// <returns></returns>
        public static string JS_OBJ_MES_RETURN(string TYPE, string MESSAGE)
        {
            return string.Format("{0}\"MES_RETURN\":{1}\"TYPE\":\"{2}\",\"MESSAGE\":\"{3}\"{4}{5}", "{", "{", TYPE, MESSAGE, "}", "}");
        }

        /// <summary>
        /// 将MES_RETURN转为包含MES_RETURN的JS对象并序列化
        /// </summary>
        /// <param name="MES_RETURN_UI">MES_RETURN_UI</param>
        /// <returns></returns>
        public static string JS_OBJ_MES_RETURN(MES_RETURN_UI MES_RETURN_UI)
        {
            return string.Format("{0}\"MES_RETURN\":{1}\"TYPE\":\"{2}\",\"MESSAGE\":\"{3}\"{4}{5}", "{", "{", MES_RETURN_UI.TYPE, MES_RETURN_UI.MESSAGE, "}", "}");
        }

        /// <summary>
        /// 将MES_RETURN转为JS对象并序列化
        /// </summary>
        /// <param name="TYPE">TYPE</param>
        /// <param name="MESSAGE">MESSAGE</param>
        /// <returns></returns>
        public static string JS_MES_RETURN(string TYPE, string MESSAGE)
        {
            return string.Format("{0}\"TYPE\":\"{1}\",\"MESSAGE\":\"{2}\"{3}", "{", TYPE, MESSAGE, "}");
        }

        /// <summary>
        /// 将MES_RETURN转为JS对象并序列化
        /// </summary>
        /// <param name="MES_RETURN_UI">MES_RETURN_UI</param>
        /// <returns></returns>
        public static string JS_MES_RETURN(MES_RETURN_UI MES_RETURN_UI)
        {
            return string.Format("{0}\"TYPE\":\"{1}\",\"MESSAGE\":\"{2}\"{3}", "{", MES_RETURN_UI.TYPE, MES_RETURN_UI.MESSAGE, "}");
        }

        #endregion

    }
}