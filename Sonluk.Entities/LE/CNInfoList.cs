using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.LE
{
    public class CNInfoList
    {
        List<CNInfo> _nodes;

        public List<CNInfo> Nodes
        {
            get { return _nodes; }
            set { _nodes = value; }
        }
        string _date;

        public string Date
        {
            get { return _date; }
            set { _date = value; }
        }
        string _name;//到站地点||收货人地点

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        string _name2;//到站地点

        public string Name2
        {
            get { return _name2; }
            set { _name2 = value; }
        }

    }
}
