using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MM
{
    public class POInfoClassify
    {
        string _werk;

        public string Werk
        {
            get { return _werk; }
            set { _werk = value; }
        }
        bool _isAufnr;

        public bool IsAufnr
        {
            get { return _isAufnr; }
            set { _isAufnr = value; }
        }
        List<POInfo> _nodes;

        public List<POInfo> Nodes
        {
            get { return _nodes; }
            set { _nodes = value; }
        }
    }
}
