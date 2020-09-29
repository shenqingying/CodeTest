using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.WX
{
    public class QY_Access_Token
    {
        public QY_Access_Token()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        string _access_token;
        string _expires_in;
        string _errcode;
        string _errmsg;

        public string errmsg
        {
            get { return _errmsg; }
            set { _errmsg = value; }
        }
        public string errcode
        {
            get { return _errcode; }
            set { _errcode = value; }
        }


        /// <summary>
        /// 获取到的凭证 
        /// </summary>
        public string access_token
        {
            get { return _access_token; }
            set { _access_token = value; }
        }


        /// <summary>
        /// 凭证有效时间，单位：秒
        /// </summary>
        public string expires_in
        {
            get { return _expires_in; }
            set { _expires_in = value; }
        }



    }
}
