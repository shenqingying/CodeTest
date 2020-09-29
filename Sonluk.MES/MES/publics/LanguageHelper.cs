using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Sonluk.MES.MES.publics
{
    public class LanguageHelper
    {
        public String_Zh zhlangu = new String_Zh();
        public String_Vi vilangu = new String_Vi();
        protected IniFile ini = new IniFile();

        #region SetAllLang
        /// <summary>
        /// Set language
        /// </summary>
        /// <param name="lang">language:zh-CN, en-US vi-VN</param>
        public static void SetAllLang(string lang)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lang);
            Form frm = null;

            string name = "basefrm";

            frm = (Form)Assembly.Load("Sonluk.MES").CreateInstance(name);

            if (frm != null)
            {
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager();
                resources.ApplyResources(frm, "$this");
                AppLang(frm, resources);
            }
        }
        #endregion

        #region SetLang
        /// <summary>
        ///
        /// </summary>
        /// <param name="lang">language:zh-CN, en-US</param>
        /// <param name="form">the form you need to set</param>
        /// <param name="formType">the type of the form </param>
        public static void SetLang(string lang, Form form, Type formType)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lang);
            if (form != null)
            {
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(formType);
                resources.ApplyResources(form, "$this");
                AppLang(form, resources);
            }
        }
        #endregion

        #region AppLang for control
        /// <summary>
        ///  loop set the propery of the control
        /// </summary>
        /// <param name="control"></param>
        /// <param name="resources"></param>
        private static void AppLang(Control control, System.ComponentModel.ComponentResourceManager resources)
        {
            if (control is MenuStrip)
            {
                resources.ApplyResources(control, control.Name);
                MenuStrip ms = (MenuStrip)control;
                if (ms.Items.Count > 0)
                {
                    foreach (ToolStripMenuItem c in ms.Items)
                    {
                        AppLang(c, resources);
                    }
                }
            }

            foreach (Control c in control.Controls)
            {
                resources.ApplyResources(c, c.Name);
                AppLang(c, resources);
            }
        }
        #endregion

        #region AppLang for menuitem
        /// <summary>
        /// set the toolscript
        /// </summary>
        /// <param name="item"></param>
        /// <param name="resources"></param>
        private static void AppLang(ToolStripMenuItem item, System.ComponentModel.ComponentResourceManager resources)
        {
            if (item is ToolStripMenuItem)
            {
                resources.ApplyResources(item, item.Name);
                ToolStripMenuItem tsmi = (ToolStripMenuItem)item;
                if (tsmi.DropDownItems.Count > 0)
                {
                    foreach (ToolStripMenuItem c in tsmi.DropDownItems)
                    {
                        AppLang(c, resources);
                    }
                }
            }
        }
        #endregion
        public  string q(Sonluk.MES.MES.Base.basefrm.Msg_Type msgtype)
        {
            string inilangu = ini.IniReadValue(ini.Section_UserInfo, "langu");
            if (string.IsNullOrEmpty(inilangu)) inilangu = "zh-CN";
            string field = msgtype.ToString();
            string msg = "";
            switch (inilangu)
            {
                case "zh-CN":
                    msg = zhlangu.GetType().GetField(field).GetValue(zhlangu).ToString();
                    break;
                case "vi-VN":
                    msg = vilangu.GetType().GetField(field).GetValue(vilangu).ToString();
                    break;
                default:

                    break;
            }
            return msg;
        }
    }
}
