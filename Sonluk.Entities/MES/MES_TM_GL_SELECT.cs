using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_TM_GL_SELECT
    {
        private List<MES_TM_GL> _MES_TM_GL;

        public List<MES_TM_GL> MES_TM_GL
        {
            get { return _MES_TM_GL; }
            set { _MES_TM_GL = value; }
        }
        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
