using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sonluk.Mobile.Models
{
    public class MobileMenuInfo
    {
        private int _ID;
        private string _Node;
        private string _Uri;
        private List<MobileMenuInfo> _Children;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public MobileMenuInfo(){}

        public MobileMenuInfo(string node)
        {
            _Node = node;
        }

        public MobileMenuInfo(string node, string uri)
        {
            _Node = node;
            _Uri = uri;
        }

        public string Node
        {
            get { return _Node; }
            set { _Node = value; }
        }

        public string Uri
        {
            get { return _Uri; }
            set { _Uri = value; }
        }

        public List<MobileMenuInfo> Children
        {
            get { return _Children; }
            set { _Children = value; }
        }
    }
}