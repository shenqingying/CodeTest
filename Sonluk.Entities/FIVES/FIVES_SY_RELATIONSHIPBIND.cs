using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.FIVES
{
    public class FIVES_SY_RELATIONSHIPBIND
    {
        private int _OBJ1;  //对象1

        public int OBJ1
        {
            get { return _OBJ1; }
            set { _OBJ1 = value; }
        }
        private int _OBJ2;  //对象2

        public int OBJ2
        {
            get { return _OBJ2; }
            set { _OBJ2 = value; }
        }
        private int _TYPE;  //关联类型

        public int TYPE
        {
            get { return _TYPE; }
            set { _TYPE = value; }
        }
        private int _ACTION;  //激活状态

        public int ACTION
        {
            get { return _ACTION; }
            set { _ACTION = value; }
        }

    }
}
