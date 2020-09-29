using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;  

namespace Sonluk.MES.MES
{
    public class IniFile
    {
        private string _Section_Configuration;

        public string Section_Configuration
        {
            get { _Section_Configuration = "MES_CONFIGURATION"; return _Section_Configuration; }
            set { _Section_Configuration = value; }
        }
        private string _Section_UserInfo;

        public string Section_UserInfo
        {
            get { _Section_UserInfo = "UserInfo"; return _Section_UserInfo; }
            set { _Section_UserInfo = value; }
        }
        private string _Section_Print;

        public string Section_Print
        {
            get { _Section_Print = "MES_PRINT"; return _Section_Print; }
            set { _Section_Print = value; }
        }
        private string _Section_Verson;

        public string Section_Verson
        {
            get { _Section_Verson = "Verson"; return _Section_Verson; }
            set { _Section_Verson = value; }
        }
        private string _Section_Remote;

        public string Section_Remote
        {
            get { _Section_Remote = "Remote"; return _Section_Remote; }
            set { _Section_Remote = value; }
        }
      
      
        private string _Section_Machine;

        public string Section_Machine
        {
            get
            {
                _Section_Machine = "MES_SY_MACHINEINFO";
                return _Section_Machine; }
            set { _Section_Machine = value; }
        }
        private string _Section_token;

       

       

      
        public string Section_token
        {
            get { _Section_token = "token"; return _Section_token; }
            set { _Section_token = value; }
        }
        string _Section_GC;

        public string Section_GC
        {
            get { _Section_GC = "GC"; return _Section_GC; }
            set { _Section_GC = value; }
        }
      

            public string Path;

            public IniFile()
            {
                //string path = Environment.CurrentDirectory + @"\Config.ini";  //指定ini文件的路径  
                this.Path = Environment.CurrentDirectory + @"\Config.ini";
            }

            #region 声明读写INI文件的API函数

            [DllImport("kernel32")]
            private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

            [DllImport("kernel32")]
            private static extern int GetPrivateProfileString(string section, string key, string defVal, StringBuilder retVal, int size, string filePath);

            [DllImport("kernel32")]
            private static extern int GetPrivateProfileString(string section, string key, string defVal, Byte[] retVal, int size, string filePath);

            #endregion

            /// <summary>  
            /// 写INI文件  
            /// </summary>  
            /// <param name="section">段落</param>  
            /// <param name="key">键</param>  
            /// <param name="iValue">值</param>  
            public void IniWriteValue(string section, string key, string iValue)
            {
                WritePrivateProfileString(section, key, iValue, this.Path);
            }

            /// <summary>  
            /// 读取INI文件  
            /// </summary>  
            /// <param name="section">段落</param>  
            /// <param name="key">键</param>  
            /// <returns>返回的键值</returns>  
            public string IniReadValue(string section, string key)
            {
                StringBuilder temp = new StringBuilder(255);

                int i = GetPrivateProfileString(section, key, "", temp, 255, this.Path);
                return temp.ToString();
            }

            /// <summary>  
            /// 读取INI文件  
            /// </summary>  
            /// <param name="Section">段，格式[]</param>  
            /// <param name="Key">键</param>  
            /// <returns>返回byte类型的section组或键值组</returns>  
            public byte[] IniReadValues(string section, string key)
            {
                byte[] temp = new byte[255];

                int i = GetPrivateProfileString(section, key, "", temp, 255, this.Path);
                return temp;
            }
        }  
    
}
