using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.BC
{
    public class MODEL_ZBCFUN_POITEM_READ
    {
        private List<ZSL_BCST100> _ET_RETURN;

        public List<ZSL_BCST100> ET_RETURN
        {
            get { return _ET_RETURN; }
            set { _ET_RETURN = value; }
        }

        private ZSL_BCS002 _ES_POITEM;

        public ZSL_BCS002 ES_POITEM
        {
            get { return _ES_POITEM; }
            set { _ES_POITEM = value; }
        }
    }
}
