using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.EM
{
    public class EM_SY_XTBB
    {
        private int _SYTYPE;

        public int SYTYPE
        {
            get { return _SYTYPE; }
            set { _SYTYPE = value; }
        }
        private int _BBID;  //版本ID

        public int BBID
        {
            get { return _BBID; }
            set { _BBID = value; }
        }
        private string _REMARK;  //版本备注

        public string REMARK
        {
            get { return _REMARK; }
            set { _REMARK = value; }
        }
        private string _CFLJ;  //存放路径

        public string CFLJ
        {
            get { return _CFLJ; }
            set { _CFLJ = value; }
        }
        private int _ISZXBB;  //是否最新版本

        public int ISZXBB
        {
            get { return _ISZXBB; }
            set { _ISZXBB = value; }
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

    }
}
