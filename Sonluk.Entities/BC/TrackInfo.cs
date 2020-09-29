using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.BC
{
    public class TrackInfo
    {
        private ZSL_BCS109 es_109;
        private List<ZSL_BCST100> et_return;

        public List<ZSL_BCST100> ET_RETURN
        {
            get { return et_return; }
            set { et_return = value; }
        }

        public ZSL_BCS109 ES_109
        {
            get { return es_109; }
            set { es_109 = value; }
        }

    }
}
