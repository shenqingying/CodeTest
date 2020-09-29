using Sonluk.UI.Model.BC;
using Sonluk.UI.Model.FIVES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sonluk.PC.Models
{
    public class FIVESModels
    {
        SY_DEPTPUSHRY _SY_DEPTPUSHRY;

        public SY_DEPTPUSHRY SY_DEPTPUSHRY
        {
            get
            {
                if (_SY_DEPTPUSHRY == null)
                {
                    _SY_DEPTPUSHRY = new SY_DEPTPUSHRY();
                } return _SY_DEPTPUSHRY;
            }
            set { _SY_DEPTPUSHRY = value; }
        }

        BarCode _BarCode;

        public BarCode BarCode
        {
            get
            {
                if (_BarCode == null)
                {
                    _BarCode = new BarCode();
                } return _BarCode;
            }
            set { _BarCode = value; }
        }
        SY_RELATIONSHIPBIND _SY_RELATIONSHIPBIND;

        public SY_RELATIONSHIPBIND SY_RELATIONSHIPBIND
        {
            get
            {
                if (_SY_RELATIONSHIPBIND == null)
                {
                    _SY_RELATIONSHIPBIND = new SY_RELATIONSHIPBIND();
                } return _SY_RELATIONSHIPBIND;
            }
            set { _SY_RELATIONSHIPBIND = value; }
        }
        SY_STAFF_DEP _SY_STAFF_DEP;

        public SY_STAFF_DEP SY_STAFF_DEP
        {
            get
            {
                if (_SY_STAFF_DEP == null)
                {
                    _SY_STAFF_DEP = new SY_STAFF_DEP();
                } return _SY_STAFF_DEP;
            }
            set { _SY_STAFF_DEP = value; }
        }
        STAFF_DEP _STAFF_DEP;

        public STAFF_DEP STAFF_DEP
        {
            get
            {
                if (_STAFF_DEP == null)
                {
                    _STAFF_DEP = new STAFF_DEP();
                }
                return _STAFF_DEP;
            }
            set { _STAFF_DEP = value; }
        }


        SY_TYPE _SY_TYPE;

        public SY_TYPE SY_TYPE
        {
            get
            {
                if (_SY_TYPE == null)
                {
                    _SY_TYPE = new SY_TYPE();
                }
                return _SY_TYPE; }
            set { _SY_TYPE = value; }
        }
        CHECK_INFO _CHECK_INFO;

        public CHECK_INFO CHECK_INFO
        {
            get {
                if (_CHECK_INFO == null)
                {
                    _CHECK_INFO = new CHECK_INFO();
                }
                return _CHECK_INFO; }
            set { _CHECK_INFO = value; }
        }
        CHECK_INFODETAIL _CHECK_INFODETAIL;

        public CHECK_INFODETAIL CHECK_INFODETAIL
        {
            get {
                if (_CHECK_INFODETAIL == null)
                {
                    _CHECK_INFODETAIL = new CHECK_INFODETAIL();
                }
                return _CHECK_INFODETAIL; }
            set { _CHECK_INFODETAIL = value; }
        }
        SY_CHECKDETAILCATEGROY _SY_CHECKDETAILCATEGROY;

        public SY_CHECKDETAILCATEGROY SY_CHECKDETAILCATEGROY
        {
            get {
                if (_SY_CHECKDETAILCATEGROY == null)
                {
                    _SY_CHECKDETAILCATEGROY = new SY_CHECKDETAILCATEGROY();
                }
                return _SY_CHECKDETAILCATEGROY; }
            set { _SY_CHECKDETAILCATEGROY = value; }
        }
        SY_CHECKDETAILS _SY_CHECKDETAILS;

        public SY_CHECKDETAILS SY_CHECKDETAILS
        {
            get
            {
                if (_SY_CHECKDETAILS == null)
                {
                    _SY_CHECKDETAILS = new SY_CHECKDETAILS();
                } return _SY_CHECKDETAILS;
            }
            set { _SY_CHECKDETAILS = value; }
        }
        SY_CHECKGROUP _SY_CHECKGROUP;

        public SY_CHECKGROUP SY_CHECKGROUP
        {
            get
            {
                if (_SY_CHECKGROUP == null)
                {
                    _SY_CHECKGROUP = new SY_CHECKGROUP();
                } return _SY_CHECKGROUP;
            }
            set { _SY_CHECKGROUP = value; }
        }
        SY_CHECKGROUP_DEPARTMENT _SY_CHECKGROUP_DEPARTMENT;

        public SY_CHECKGROUP_DEPARTMENT SY_CHECKGROUP_DEPARTMENT
        {
            get
            {
                if (_SY_CHECKGROUP_DEPARTMENT == null)
                {
                    _SY_CHECKGROUP_DEPARTMENT = new SY_CHECKGROUP_DEPARTMENT();
                } return _SY_CHECKGROUP_DEPARTMENT;
            }
            set { _SY_CHECKGROUP_DEPARTMENT = value; }
        }
        SY_CHECKGROUP_STAFF _SY_CHECKGROUP_STAFF;

        public SY_CHECKGROUP_STAFF SY_CHECKGROUP_STAFF
        {
            get
            {
                if (_SY_CHECKGROUP_STAFF == null)
                {
                    _SY_CHECKGROUP_STAFF = new SY_CHECKGROUP_STAFF();
                } return _SY_CHECKGROUP_STAFF;
            }
            set { _SY_CHECKGROUP_STAFF = value; }
        }
        SY_CHECKPOINT _SY_CHECKPOINT;

        public SY_CHECKPOINT SY_CHECKPOINT
        {
            get
            {
                if (_SY_CHECKPOINT == null)
                {
                    _SY_CHECKPOINT = new SY_CHECKPOINT();
                } return _SY_CHECKPOINT;
            }
            set { _SY_CHECKPOINT = value; }
        }
        SY_CHECKPOINT_CHECKDETAIL _SY_CHECKPOINT_CHECKDETAIL;

        public SY_CHECKPOINT_CHECKDETAIL SY_CHECKPOINT_CHECKDETAIL
        {
            get
            {
                if (_SY_CHECKPOINT_CHECKDETAIL == null)
                {
                    _SY_CHECKPOINT_CHECKDETAIL = new SY_CHECKPOINT_CHECKDETAIL();
                } return _SY_CHECKPOINT_CHECKDETAIL;
            }
            set { _SY_CHECKPOINT_CHECKDETAIL = value; }
        }
        SY_CHECKPOINT_POINTCATEGROY _SY_CHECKPOINT_POINTCATEGROY;

        public SY_CHECKPOINT_POINTCATEGROY SY_CHECKPOINT_POINTCATEGROY
        {
            get
            {
                if (_SY_CHECKPOINT_POINTCATEGROY == null)
                {
                    _SY_CHECKPOINT_POINTCATEGROY = new SY_CHECKPOINT_POINTCATEGROY();
                } return _SY_CHECKPOINT_POINTCATEGROY;
            }
            set { _SY_CHECKPOINT_POINTCATEGROY = value; }
        }
        SY_CHECKPOINTCATEGROY _SY_CHECKPOINTCATEGROY;

        public SY_CHECKPOINTCATEGROY SY_CHECKPOINTCATEGROY
        {
            get
            {
                if (_SY_CHECKPOINTCATEGROY == null)
                {
                    _SY_CHECKPOINTCATEGROY = new SY_CHECKPOINTCATEGROY();
                } return _SY_CHECKPOINTCATEGROY;
            }
            set { _SY_CHECKPOINTCATEGROY = value; }
        }
        SY_DICT _SY_DICT;

        public SY_DICT SY_DICT
        {
            get
            {
                if (_SY_DICT == null)
                {
                    _SY_DICT = new SY_DICT();
                } return _SY_DICT;
            }
            set { _SY_DICT = value; }
        }
        SY_POINTCATEGROY_DETAIL _SY_POINTCATEGROY_DETAIL;

        public SY_POINTCATEGROY_DETAIL SY_POINTCATEGROY_DETAIL
        {
            get
            {
                if (_SY_POINTCATEGROY_DETAIL == null)
                {
                    _SY_POINTCATEGROY_DETAIL = new SY_POINTCATEGROY_DETAIL();
                } return _SY_POINTCATEGROY_DETAIL;
            }
            set { _SY_POINTCATEGROY_DETAIL = value; }
        }
        SY_PRINCIPALCATEGROY _SY_PRINCIPALCATEGROY;

        public SY_PRINCIPALCATEGROY SY_PRINCIPALCATEGROY
        {
            get
            {
                if (_SY_PRINCIPALCATEGROY == null)
                {
                    _SY_PRINCIPALCATEGROY = new SY_PRINCIPALCATEGROY();
                } return _SY_PRINCIPALCATEGROY;
            }
            set { _SY_PRINCIPALCATEGROY = value; }
        }
        SY_STATION _SY_STATION;

        public SY_STATION SY_STATION
        {
            get
            {
                if (_SY_STATION == null)
                {
                    _SY_STATION = new SY_STATION();
                } return _SY_STATION;
            }
            set { _SY_STATION = value; }
        }
    }
}