using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.Print
{
    public class ControlInfo
    {
        private int _ID;
        private string _Type;
        private int _Layout;
        private string _Value;
        private string _Style;
        private int _Status;

        
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        public int Layout
        {
            get { return _Layout; }
            set { _Layout = value; }
        }
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }
        public string Style
        {
            get { return _Style; }
            set { _Style = value; }
        }
        public int Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
    }
}
