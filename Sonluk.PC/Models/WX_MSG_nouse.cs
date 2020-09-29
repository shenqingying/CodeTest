using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sonluk.PC.Models
{
    public class WX_MSG_nouse
    {

        string _touser;

        public string touser
        {
            get { return _touser; }
            set { _touser = value; }
        }
        string _toparty;

        public string toparty
        {
            get { return _toparty; }
            set { _toparty = value; }
        }
        string _totag;

        public string totag
        {
            get { return _totag; }
            set { _totag = value; }
        }
        string _msgtype;

        public string msgtype
        {
            get { return _msgtype; }
            set { _msgtype = value; }
        }
        int _agentid;

        public int agentid
        {
            get { return _agentid; }
            set { _agentid = value; }
        }
        TEXT _text;

        public TEXT text
        {
            get { return _text; }
            set { _text = value; }
        }
        int _safe;

        public int safe
        {
            get { return _safe; }
            set { _safe = value; }
        }



        public class TEXT
        {
            string _content;

            public string content
            {
                get { return _content; }
                set { _content = value; }
            }
        }



    }
}