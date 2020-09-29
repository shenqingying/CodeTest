using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.Account
{
    public class AccountInfo
    {
        private int _SN;
        private string _ID;
        private bool _SignIn; 
        private int _Type;
        private string _Name;
        private string _Menu;       
        private string _EMail;
        private string _Telphone;
        private int _ExternalSignIn;
        private int _Status;
        private string _Message;
        private int _Group;
        private string _PurGroup;
        private string _MessageDetails;
        private AuthorizationInfo _SAPAuthorization;      
        private RouteInfo _Route;
        private List<string> _Authorization;

        public AccountInfo() { }

        public AccountInfo(string ID,string name) {
            _ID = ID;
            _Name = name;
        
        }
        public int SN
        {
            get { return _SN; }
            set { _SN = value; }
        }
        public string ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public bool SignIn
        {
            get { return _SignIn; }
            set { _SignIn = value; }
        }
        public int Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        public string Menu
        {
            get { return _Menu; }
            set { _Menu = value; }
        }
        
        public string EMail
        {
            get { return _EMail; }
            set { _EMail = value; }
        }
        public string Telphone
        {
            get { return _Telphone; }
            set { _Telphone = value; }
        }
        public int ExternalSignIn
        {
            get { return _ExternalSignIn; }
            set { _ExternalSignIn = value; }
        }
        public int Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        public string Message
        {
            get { return _Message; }
            set { _Message = value; }
        }
        public int Group
        {
            get { return _Group; }
            set { _Group = value; }
        }
        public string PurGroup
        {
            get { return _PurGroup; }
            set { _PurGroup = value; }
        }
        public string MessageDetails
        {
            get { return _MessageDetails; }
            set { _MessageDetails = value; }
        }
        public AuthorizationInfo SAPAuthorization
        {
            get { return _SAPAuthorization; }
            set { _SAPAuthorization = value; }
        }
        
        public RouteInfo Route
        {
            get { return _Route; }
            set { _Route = value; }
        }
        public List<string> Authorization
        {
            get { return _Authorization; }
            set { _Authorization = value; }
        }


    }
}
