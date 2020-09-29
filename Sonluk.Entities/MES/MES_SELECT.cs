using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_SELECT<T>
    {
        public List<T> TList { get; set; }
        public List<string> Others { get; set; }
        public MES_RETURN MES_RETURN { get; set; }
    }
}
