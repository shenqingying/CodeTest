using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sonluk.PC.Models
{
    public class LayuiTree
    {


        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        

        private int xsqyid;

        public int XSQYID             //销售区域ID
        {
            get { return xsqyid; }
            set { xsqyid = value; }
        }



        private string _name;

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        string _title;

        public string title
        {
            get { return _title; }
            set { _title = value; }
        }



        private bool _spread;

        public bool spread
        {
            get { return _spread; }
            set { _spread = value; }
        }



        private string _href;

        public string href
        {
            get { return _href; }
            set { _href = value; }
        }


        private int pid;

        public int Pid
        {
            get { return pid; }
            set { pid = value; }
        }


        private int khjlid;        //客户经理ID

        public int Khjlid
        {
            get { return khjlid; }
            set { khjlid = value; }
        }

        


        private int fgldid;

        public int Fgldid     //分管领导ID
        {
            get { return fgldid; }
            set { fgldid = value; }
        }

        private string gmemo;

        public string Gmemo    //说明
        {
            get { return gmemo; }
            set { gmemo = value; }
        }




    }

}