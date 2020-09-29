using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.HR
{
    public class HR_BOOK_BOOKINFO_SELECT
    {
        List<HR_BOOK_BOOKINFO_LIST> _HR_BOOK_BOOKINFO_LIST;

        public List<HR_BOOK_BOOKINFO_LIST> HR_BOOK_BOOKINFO_LIST
        {
            get { return _HR_BOOK_BOOKINFO_LIST; }
            set { _HR_BOOK_BOOKINFO_LIST = value; }
        }
        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
