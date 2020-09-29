using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
   public class CRM_HG_RIGHT 
    {
       public class TravelTrafficInfoComparer : IEqualityComparer<CRM_HG_RIGHT>
       {
           #region IEqualityComparer<User> 成员
           public bool Equals(CRM_HG_RIGHT x, CRM_HG_RIGHT y)
           {
               if (x.RIGHTID == y.RIGHTID)
                   return true;
               else
                   return false;
           }

           public int GetHashCode(CRM_HG_RIGHT obj)
           {
               return 0;
           }
           #endregion
       }  
        int _WX;

        public int WX
        {
            get { return _WX; }
            set { _WX = value; }
        }
        int _PC;

        public int PC
        {
            get { return _PC; }
            set { _PC = value; }
        }
        int _RIGHTID;

        public int RIGHTID
        {
            get { return _RIGHTID; }
            set { _RIGHTID = value; }
        }
        int _RGROUPID;

        public int RGROUPID
        {
            get { return _RGROUPID; }
            set { _RGROUPID = value; }
        }
        string _RIGHTNAME;

        public string RIGHTNAME
        {
            get { return _RIGHTNAME; }
            set { _RIGHTNAME = value; }
        }
        int _RIGHTNO;

        public int RIGHTNO
        {
            get { return _RIGHTNO; }
            set { _RIGHTNO = value; }
        }
        string _RIGHTADD;

        public string RIGHTADD
        {
            get { return _RIGHTADD; }
            set { _RIGHTADD = value; }
        }
        string _RIGHTMEMO;

        public string RIGHTMEMO
        {
            get { return _RIGHTMEMO; }
            set { _RIGHTMEMO = value; }
        }
        int _ISACTIVE;

        public int ISACTIVE
        {
            get { return _ISACTIVE; }
            set { _ISACTIVE = value; }
        }
        string _IMAGELJ;

        public string IMAGELJ
        {
            get { return _IMAGELJ; }
            set { _IMAGELJ = value; }
        }

    }
}
