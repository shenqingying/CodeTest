using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Xml;
namespace Sonluk.MES.MES.publics
{
    public class OperationConfig
    {
        /// <summary>
        ///  添加键为keyName、值为keyValue的项
        /// </summary>
        /// <param name="keyName"></param>
        /// <param name="keyValue"></param>
        public void addItem(string keyName, string keyValue)
        {
            //添加配置文件的项，键为keyName，值为keyValue
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Add(keyName, keyValue);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
        /// <summary>
        /// 判断键为keyName的项是否存在：
        /// </summary>
        /// <param name="keyName"></param>
        /// <returns></returns>
        public bool existItem(string keyName)
        {
            //判断配置文件中是否存在键为keyName的项
            foreach (string key in ConfigurationManager.AppSettings)
            {
                if (key == keyName)
                {
                    //存在
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 获取键为keyName的项的值：
        /// </summary>
        /// <param name="keyName"></param>
        /// <returns></returns>
        public string valueItem(string keyName)
        {
            //返回配置文件中键为keyName的项的值
            return ConfigurationManager.AppSettings[keyName];
        }

        /// <summary>
        /// 修改键为keyName的项的值：
        /// </summary>
        /// <param name="keyName"></param>
        /// <param name="newKeyValue"></param>
        public void modifyItem(string keyName, string newKeyValue)
        {
            //修改配置文件中键为keyName的项的值
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings[keyName].Value = newKeyValue;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
        /// <summary>
        /// 删除键为keyName的项：
        /// </summary>
        /// <param name="keyName"></param>
        public void removeItem(string keyName)
        {
            //删除配置文件键为keyName的项
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove(keyName);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }


        /// <summary>
         /// 修改AppSettings中配置
         /// </summary>
         /// <param name="key">key值</param>
         /// <param name="value">相应值</param>
         public static bool SetConfigValue(string key, string value)
         {
             try
             {
                 Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                 if (config.AppSettings.Settings[key] != null)
                     config.AppSettings.Settings[key].Value = value;
                 else
                     config.AppSettings.Settings.Add(key, value);
                 config.Save(ConfigurationSaveMode.Modified);
                 ConfigurationManager.RefreshSection("appSettings");
                 return true;
             }
             catch
             {
                 return false;
             }
         }
         public bool ChangeConfig(string AppKey, string AppValue)
         {
             bool result = true;
             try
             {
                 XmlDocument xDoc = new XmlDocument();
                 //获取App.config文件绝对路径
                 String basePath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
                 basePath = basePath.Substring(0, basePath.Length - 10);
                 String path = basePath + "App.config";
                 xDoc.Load(path);

                 XmlNode xNode;
                 XmlElement xElem1;
                 XmlElement xElem2;
                 //修改完文件内容，还需要修改缓存里面的配置内容，使得刚修改完即可用
                 //如果不修改缓存，需要等到关闭程序，在启动，才可使用修改后的配置信息
                 Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                 xNode = xDoc.SelectSingleNode("//appSettings");
                 xElem1 = (XmlElement)xNode.SelectSingleNode("//add[@key='" + AppKey + "']");
                 if (xElem1 != null)
                 {
                     xElem1.SetAttribute("value", AppValue);
                     cfa.AppSettings.Settings[AppKey].Value = AppValue;
                 }
                 else
                 {
                     xElem2 = xDoc.CreateElement("add");
                     xElem2.SetAttribute("key", AppKey);
                     xElem2.SetAttribute("value", AppValue);
                     xNode.AppendChild(xElem2);
                     cfa.AppSettings.Settings.Add(AppKey, AppValue);
                 }
                 //改变缓存中的配置文件信息（读取出来才会是最新的配置）
                 cfa.Save();
                 ConfigurationManager.RefreshSection("appSettings");
                 xDoc.Save(path);
             }
             catch (Exception ex)
             {
                 //_log.Error("修改App.config文件出错：" + ex.Message);
                 result = false;
             }
             return result;
         }


    }
}
