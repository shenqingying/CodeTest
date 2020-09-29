using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.FIVES
{
    public class FIVES_SY_CHECKGROUP
    {
        private int _GID;  //分组ID

        public int GID
        {
            get { return _GID; }
            set { _GID = value; }
        }
        private string _GMS;  //分组名称

        public string GMS
        {
            get { return _GMS; }
            set { _GMS = value; }
        }
        private int _FID;  //上级分组

        public int FID
        {
            get { return _FID; }
            set { _FID = value; }
        }
        private string _REMARK;  //备注

        public string REMARK
        {
            get { return _REMARK; }
            set { _REMARK = value; }
        }
        private int _ACTION;  //是否激活

        public int ACTION
        {
            get { return _ACTION; }
            set { _ACTION = value; }
        }
        private bool _ISDELETE;  //是否删除

        public bool ISDELETE
        {
            get { return _ISDELETE; }
            set { _ISDELETE = value; }
        }

    }
}
