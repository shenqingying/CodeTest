using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.System
{
    public class MessageInfo
    {
        private int _ID;
        private bool _Success;
        private string _Key;
        private string _Value;
        private int _Status;

        

        public MessageInfo() { 
        
        }
        public MessageInfo(int id,bool success)
        {
            _ID = id;
            _Success = success;
        }
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public bool Success
        {
            get { return _Success; }
            set { _Success = value; }
        }
        public string Key
        {
            get { return _Key; }
            set { _Key = value; }
        }
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }
        public int Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
    }
}
