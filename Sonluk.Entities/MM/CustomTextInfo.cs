using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MM
{
    public class CustomTextInfo
    {
        private string _ID;
        private string _Title;
        private string _Content;

       
        public string ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }
        public string Content
        {
            get { return _Content; }
            set { _Content = value; }
        }
    }
}
