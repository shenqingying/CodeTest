using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_PMM_SYS
    {
        public string KEY { get; set; }
        public string VALUE { get; set; }
        public int STAFFID { get; set; }
        public MES_RETURN MES_RETURN { get; set; }
    }
}
