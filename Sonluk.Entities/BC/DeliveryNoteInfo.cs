using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.BC
{
    public class DeliveryNoteInfo
    {
        private ZSL_SDS011 o_jh;
        private List<ZSL_SDS012> t_jh;
        private string _O_MESSAGE;

        public string O_MESSAGE
        {
            get { return _O_MESSAGE; }
            set { _O_MESSAGE = value; }
        }
        public ZSL_SDS011 O_jh
        {
            get { return o_jh; }
            set { o_jh = value; }
        }

        public List<ZSL_SDS012> T_jh
        {
            get { return t_jh; }
            set { t_jh = value; }
        }       
    }
}
