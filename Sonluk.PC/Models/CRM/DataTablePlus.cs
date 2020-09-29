using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Sonluk.PC.Models.CRM
{
    public class DataTablePlus
    {

        string _TITLE;

        public string TITLE
        {
            get { return _TITLE; }
            set { _TITLE = value; }
        }


        DataTable _DATA;

        public DataTable DATA
        {
            get { return _DATA; }
            set { _DATA = value; }
        }


    }
}