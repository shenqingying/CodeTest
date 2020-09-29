using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_DCBZ
    {
        public int RI { get; set; }
        public string DCXH { get; set; }
        public int DCXHRI { get; set; } //存储过程自动识别
        public List<MES_DCCCBZ> MES_DCCCBZ { get; set; }
        public List<MES_DCDXN> MES_DCDXN { get; set; }
    }

    public class MES_DCCCBZ
    {
        public int RI { get; set; }
        public string DCBZ { get; set; }
        public int DCBZRI { get; set; } //存储过程自动识别
        public string DCMAX { get; set; }
        public string DCMIN { get; set; }
    }

    public class MES_DCDXN
    {
        public int RI { get; set; }
        public string DCBZ { get; set; }
        public int DCBZRI { get; set; } //存储过程自动识别
        public string DCFDFS { get; set; }
        public string DCMAD { get; set; }
        public string SDLX { get; set; }
        public string SDLXRI { get; set; } //存储过程自动识别
    }
}
