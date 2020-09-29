using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_MSG_NOTICETTParam
    {
        string _TITLE;

        public string TITLE
        {
            get { return _TITLE; }
            set { _TITLE = value; }
        }
        string _NOTICE;

        public string NOTICE
        {
            get { return _NOTICE; }
            set { _NOTICE = value; }
        }
        string _CJSJ_BEGIN;

        public string CJSJ_BEGIN
        {
            get { return _CJSJ_BEGIN; }
            set { _CJSJ_BEGIN = value; }
        }
        string _CJSJ_END;

        public string CJSJ_END
        {
            get { return _CJSJ_END; }
            set { _CJSJ_END = value; }
        }
        int _ISACTIVE;

        public int ISACTIVE
        {
            get { return _ISACTIVE; }
            set { _ISACTIVE = value; }
        }

    }
}
