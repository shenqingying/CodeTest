using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.PS
{
    public class NetworkRead
    {
        private NetworkINFO _E_network;
        private List<Ps_vorINFO> _E_vor;
        private List<Ps_trugINFO> _E_trug;
        private PS_MSG _ET_RETURN;

        public PS_MSG ET_RETURN
        {
            get { return _ET_RETURN; }
            set { _ET_RETURN = value; }
        }

        public List<Ps_trugINFO> E_trug
        {
            get { return _E_trug; }
            set { _E_trug = value; }
        }

        public List<Ps_vorINFO> E_vor
        {
            get { return _E_vor; }
            set { _E_vor = value; }
        }

        public NetworkINFO E_network
        {
            get { return _E_network; }
            set { _E_network = value; }
        }
    }
}
