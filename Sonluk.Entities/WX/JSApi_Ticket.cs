using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.WX
{
    public class JSApi_Ticket
    {
        public JSApi_Ticket()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        string _errcode;
        string _errmsg;
        string _ticket;
        string _expires_in;

        /// <summary>
        /// 获取到的凭证 
        /// </summary>
        public string errcode
        {
            get { return _errcode; }
            set { _errcode = value; }
        }
        public string errmsg
        {
            get { return _errmsg; }
            set { _errmsg = value; }
        }
        public string ticket
        {
            get { return _ticket; }
            set { _ticket = value; }
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
