using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_SY_LANGUAGE_YM
    {
        private int _YMID;

        public int YMID
        {
            get { return _YMID; }
            set { _YMID = value; }
        }
        private string _YMAREA;

        public string YMAREA
        {
            get { return _YMAREA; }
            set { _YMAREA = value; }
        }
        private string _YMCONTROLLER;

        public string YMCONTROLLER
        {
            get { return _YMCONTROLLER; }
            set { _YMCONTROLLER = value; }
        }
        private string _YMVIEW;

        public string YMVIEW
        {
            get { return _YMVIEW; }
            set { _YMVIEW = value; }
        }
        private string _YMNAME;

        public string YMNAME
        {
            get { return _YMNAME; }
            set { _YMNAME = value; }
        }
        private string _YMREMARK;

        public string YMREMARK
        {
            get { return _YMREMARK; }
            set { _YMREMARK = value; }
        }
        private int _CJRID;

        public int CJRID
        {
            get { return _CJRID; }
            set { _CJRID = value; }
        }
        private int _XGRID;

        public int XGRID
        {
            get { return _XGRID; }
            set { _XGRID = value; }
        }
    }
}
