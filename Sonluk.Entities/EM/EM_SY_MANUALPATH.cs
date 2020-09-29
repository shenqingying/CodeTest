using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.EM
{
    public class EM_SY_MANUALPATH
    {
        int _PATHID;

        public int PATHID
        {
            get { return _PATHID; }
            set { _PATHID = value; }
        }
        string _FILESIZE;

        public string FILESIZE
        {
            get { return _FILESIZE; }
            set { _FILESIZE = value; }
        }
        private int _ID;  //ID

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private string _CFLJ;  //存放路径

        public string CFLJ
        {
            get { return _CFLJ; }
            set { _CFLJ = value; }
        }
        private int _BBID;  //电子说明书版本ID

        public int BBID
        {
            get { return _BBID; }
            set { _BBID = value; }
        }
        private int _CJR;  //创建人

        public int CJR
        {
            get { return _CJR; }
            set { _CJR = value; }
        }
        private string _CJRNAME;  //创建人描述

        public string CJRNAME
        {
            get { return _CJRNAME; }
            set { _CJRNAME = value; }
        }
        private string _JLTIME;  //创建时间

        public string JLTIME
        {
            get { return _JLTIME; }
            set { _JLTIME = value; }
        }
        private int _ISACTION;  //是否激活

        public int ISACTION
        {
            get { return _ISACTION; }
            set { _ISACTION = value; }
        }
        private int _ISDELETE;  //是否删除

        public int ISDELETE
        {
            get { return _ISDELETE; }
            set { _ISDELETE = value; }
        }
        private string _FILENAME;

        public string FILENAME
        {
            get { return _FILENAME; }
            set { _FILENAME = value; }
        }
        string _MS;

        public string MS
        {
            get { return _MS; }
            set { _MS = value; }
        }

    }
}
