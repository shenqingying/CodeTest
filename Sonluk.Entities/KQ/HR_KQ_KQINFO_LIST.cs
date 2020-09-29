using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.KQ
{
    public class HR_KQ_KQINFO_LIST
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _badgenumber;

        public string Badgenumber
        {
            get { return _badgenumber; }
            set { _badgenumber = value; }
        }
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _code;

        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }
        private string _DeptName;

        public string DeptName
        {
            get { return _DeptName; }
            set { _DeptName = value; }
        }
        private string _checktime;

        public string Checktime
        {
            get { return _checktime; }
            set { _checktime = value; }
        }
        private string _sn_name;

        public string Sn_name
        {
            get { return _sn_name; }
            set { _sn_name = value; }
        }
    }
}
