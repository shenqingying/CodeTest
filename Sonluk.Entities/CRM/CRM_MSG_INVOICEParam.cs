using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_MSG_INVOICEParam
    {
        string _MC;

        public string MC
        {
            get { return _MC; }
            set { _MC = value; }
        }
        string _FPHM;

        public string FPHM
        {
            get { return _FPHM; }
            set { _FPHM = value; }
        }
        string _JSRQ_BEGIN;

        public string JSRQ_BEGIN
        {
            get { return _JSRQ_BEGIN; }
            set { _JSRQ_BEGIN = value; }
        }
        string _JSRQ_END;

        public string JSRQ_END
        {
            get { return _JSRQ_END; }
            set { _JSRQ_END = value; }
        }


    }
}
