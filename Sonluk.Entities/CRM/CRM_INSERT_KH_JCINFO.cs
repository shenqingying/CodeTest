using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_INSERT_KH_JCINFO
    {
        int _TYPE;

        public int TYPE
        {
            get { return _TYPE; }
            set { _TYPE = value; }
        }
        CRM_KH_KH _S_KHINFO;

        public CRM_KH_KH S_KHINFO
        {
            get { return _S_KHINFO; }
            set { _S_KHINFO = value; }
        }
        //CRM_KH_LXR _T_LXR;

        //public CRM_KH_LXR T_LXR
        //{
        //    get { return _T_LXR; }
        //    set { _T_LXR = value; }
        //}
        CRM_KH_KHQTXX _T_KHQTXX;

        public CRM_KH_KHQTXX T_KHQTXX
        {
            get { return _T_KHQTXX; }
            set { _T_KHQTXX = value; }
        }
        //CRM_HG_WJJLTT _S_WJJLTT;

        //public CRM_HG_WJJLTT S_WJJLTT
        //{
        //    get { return _S_WJJLTT; }
        //    set { _S_WJJLTT = value; }
        //}
        //CRM_HG_WJJL _T_WJJL;

        //public CRM_HG_WJJL T_WJJL
        //{
        //    get { return _T_WJJL; }
        //    set { _T_WJJL = value; }
        //}
        //CRM_KH_GXCS _T_GXCS;

        //public CRM_KH_GXCS T_GXCS
        //{
        //    get { return _T_GXCS; }
        //    set { _T_GXCS = value; }
        //}
       
    }
}
