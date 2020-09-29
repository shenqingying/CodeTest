using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sonluk.WX.Models.QY
{
    public class UserID
    {
        public UserID()
        {

        }

        string _errcode;
        string _errmsg;
        string _UserId;
        string _DeviceId;
        string _OpenId;
        string _user_ticket;
        string _expires_in;

        public string UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }
        public string DeviceId
        {
            get { return _DeviceId; }
            set { _DeviceId = value; }
        }
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

        public string OpenId
        {
            get { return _OpenId; }
            set { _OpenId = value; }
        }
        public string user_ticket
        {
            get { return _user_ticket; }
            set { _user_ticket = value; }
        }
        public string expires_in
        {
            get { return _expires_in; }
            set { _expires_in = value; }
        }




    }
}