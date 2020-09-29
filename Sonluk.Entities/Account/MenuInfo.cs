using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.Account
{
    public class MenuInfo
    {
        private int _ID;
        private string _Node;
        private string _Uri;
        private List<MenuInfo> _Children;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public MenuInfo(){}

        public MenuInfo(string node)
        {
            _Node = node;
        }

        public MenuInfo(string node, string uri)
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

        public List<MenuInfo> Children
        {
            get { return _Children; }
            set { _Children = value; }
        }
    }
}
