using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sonluk.WX.Models.WX
{
    public class OpenID
    {
        public OpenID()
        {

        }

        private string _access_token;

        public string Access_token
        {
            get { return _access_token; }
            set { _access_token = value; }
        }



        private string _expires_in;

        public string Expires_in
        {
            get { return _expires_in; }
            set { _expires_in = value; }
        }



        private string _refresh_token;

        public string Refresh_token
        {
            get { return _refresh_token; }
            set { _refresh_token = value; }
        }



        private string _openid;

        public string Openid
        {
            get { return _openid; }
            set { _openid = value; }
        }


        private string _scope;

        public string Scope
        {
            get { return _scope; }
            set { _scope = value; }
        }



        private string _errcode;

        public string Errcode
        {
            get { return _errcode; }
            set { _errcode = value; }
        }



        private string _errmsg;

        public string Errmsg
        {
            get { return _errmsg; }
            set { _errmsg = value; }
        }



    }
}