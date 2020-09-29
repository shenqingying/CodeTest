using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sonluk.UI.Model.CRM;

namespace Sonluk.Mobile.Models
{
    public class CRMModels
    {
        private CRM_KH _CRM_KH;

        public CRM_KH CRM_KH
        {
            get {
                if (_CRM_KH == null)
                    _CRM_KH = new CRM_KH();
                return _CRM_KH; }
            set { _CRM_KH = value; }
        }

        private CRM_HG _CRM_HG;

        public CRM_HG CRM_HG
        {
            get
            {
                if (_CRM_HG == null)
                    _CRM_HG = new CRM_HG();
                return _CRM_HG;
            }
            set { _CRM_HG = value; }
        }


        private KH_KH _KH_KH;

        public KH_KH KH_KH
        {
            get {
                if (_KH_KH == null)
                    _KH_KH = new KH_KH();
                
                return _KH_KH; }
            set { _KH_KH = value; }
        }

        private KH_LXR _KH_LXR;

        public KH_LXR KH_LXR
        {
            get {
                if (_KH_LXR == null)
                    _KH_LXR = new KH_LXR();

                return _KH_LXR;
            }
            set { _KH_LXR = value; }
        }

        private KH_GXQY _KH_GXQY;

        public KH_GXQY KH_GXQY
        {
            get {
                if (_KH_GXQY == null)
                    _KH_GXQY = new KH_GXQY();
                return _KH_GXQY; }
            set { _KH_GXQY = value; }
        }

        private HG_WJJL _HG_WJJL;

        public HG_WJJL HG_WJJL
        {
            get {
                if (_HG_WJJL == null)
                    _HG_WJJL = new HG_WJJL();
                return _HG_WJJL; }
            set { _HG_WJJL = value; }
        }

        private KH_KHQTXX _KH_KHQTXX;

        public KH_KHQTXX KH_KHQTXX
        {
            get {
                if (_KH_KHQTXX == null)
                    _KH_KHQTXX = new KH_KHQTXX();
                return _KH_KHQTXX; }
            set { _KH_KHQTXX = value; }
        }

        private KH_GROUP _KH_GROUP;

        public KH_GROUP KH_GROUP
        {
            get {
                if (_KH_GROUP == null)
                    _KH_GROUP = new KH_GROUP();
                return _KH_GROUP; }
            set { _KH_GROUP = value; }
        }

        private HG_TYPE _HG_TYPE;

        public HG_TYPE HG_TYPE
        {
            get {
                if (_HG_TYPE == null)
                    _HG_TYPE = new HG_TYPE();
                return _HG_TYPE; }
            set { _HG_TYPE = value; }
        }

        private HG_DICT _HG_DICT;

        public HG_DICT HG_DICT
        {
            get {
                if (_HG_DICT == null)
                    _HG_DICT = new HG_DICT();
                return _HG_DICT; }
            set { _HG_DICT = value; }
        }

        private KH_HZHB _KH_HZHB;

        public KH_HZHB KH_HZHB
        {
            get {
                if (_KH_HZHB == null)
                    _KH_HZHB = new KH_HZHB();
                return _KH_HZHB; }
            set { _KH_HZHB = value; }
        }

        private KH_GROUP_KH _KH_GROUP_KH;

        public KH_GROUP_KH KH_GROUP_KH
        {
            get {
                if (_KH_GROUP_KH == null)
                    _KH_GROUP_KH = new KH_GROUP_KH();
                return _KH_GROUP_KH; }
            set { _KH_GROUP_KH = value; }
        }

        private CRM_Login _CRM_Login;

        public CRM_Login CRM_Login
        {
            get {
                if (_CRM_Login == null)
                    _CRM_Login = new CRM_Login();
                return _CRM_Login; }
            set { _CRM_Login = value; }
        }



    }
}