using Sonluk.UI.Model.EM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sonluk.PC.Models
{
    public class EMModel
    {
        EM_MISSION _EM_MISSION;

        public EM_MISSION EM_MISSION
        {
            get
            {
                if (_EM_MISSION == null)
                {
                    _EM_MISSION = new EM_MISSION();
                } return _EM_MISSION;
            }
            set { _EM_MISSION = value; }
        }
        SY_PB _SY_PB;

        public SY_PB SY_PB
        {
            get
            {
                if (_SY_PB == null)
                {
                    _SY_PB = new SY_PB();
                } return _SY_PB;
            }
            set { _SY_PB = value; }
        }
        SY_SBBINDPB _SY_SBBINDPB;

        public SY_SBBINDPB SY_SBBINDPB
        {
            get
            {
                if (_SY_SBBINDPB == null)
                {
                    _SY_SBBINDPB = new SY_SBBINDPB();
                } return _SY_SBBINDPB;
            }
            set { _SY_SBBINDPB = value; }
        }
        SY_STAFFIDBINDPB _SY_STAFFIDBINDPB;

        public SY_STAFFIDBINDPB SY_STAFFIDBINDPB
        {
            get
            {
                if (_SY_STAFFIDBINDPB == null)
                {
                    _SY_STAFFIDBINDPB = new SY_STAFFIDBINDPB();
                } return _SY_STAFFIDBINDPB;
            }
            set { _SY_STAFFIDBINDPB = value; }
        }
        SY_SBBHMANUAL _SY_SBBHMANUAL;

        public SY_SBBHMANUAL SY_SBBHMANUAL
        {
            get
            {
                if (_SY_SBBHMANUAL == null)
                {
                    _SY_SBBHMANUAL = new SY_SBBHMANUAL();
                } return _SY_SBBHMANUAL;
            }
            set { _SY_SBBHMANUAL = value; }
        }
        SY_SBBHDEVICETYPE _SY_SBBHDEVICETYPE;

        public SY_SBBHDEVICETYPE SY_SBBHDEVICETYPE
        {
            get
            {
                if (_SY_SBBHDEVICETYPE == null)
                {
                    _SY_SBBHDEVICETYPE = new SY_SBBHDEVICETYPE();
                } return _SY_SBBHDEVICETYPE;
            }
            set { _SY_SBBHDEVICETYPE = value; }
        }
        SY_DEVICETYPE _SY_DEVICETYPE;

        public SY_DEVICETYPE SY_DEVICETYPE
        {
            get
            {
                if (_SY_DEVICETYPE == null)
                {
                    _SY_DEVICETYPE = new SY_DEVICETYPE();
                } return _SY_DEVICETYPE;
            }
            set { _SY_DEVICETYPE = value; }
        }
        SY_DEVICEDETAILDOC _SY_DEVICEDETAILDOC;

        public SY_DEVICEDETAILDOC SY_DEVICEDETAILDOC
        {
            get
            {
                if (_SY_DEVICEDETAILDOC == null)
                {
                    _SY_DEVICEDETAILDOC = new SY_DEVICEDETAILDOC();
                } return _SY_DEVICEDETAILDOC;
            }
            set { _SY_DEVICEDETAILDOC = value; }
        }
        SY_DEVICEQRJL _SY_DEVICEQRJL;

        public SY_DEVICEQRJL SY_DEVICEQRJL
        {
            get
            {
                if (_SY_DEVICEQRJL == null)
                {
                    _SY_DEVICEQRJL = new SY_DEVICEQRJL();
                } return _SY_DEVICEQRJL;
            }
            set { _SY_DEVICEQRJL = value; }
        }
        SY_INFOREPORT _SY_INFOREPORT;

        public SY_INFOREPORT SY_INFOREPORT
        {
            get
            {
                if (_SY_INFOREPORT == null)
                {
                    _SY_INFOREPORT = new SY_INFOREPORT();
                } return _SY_INFOREPORT;
            }
            set { _SY_INFOREPORT = value; }
        }
        SY_DEVICE_CONTRACT _SY_DEVICE_CONTRACT;

        public SY_DEVICE_CONTRACT SY_DEVICE_CONTRACT
        {
            get
            {
                if (_SY_DEVICE_CONTRACT == null)
                {
                    _SY_DEVICE_CONTRACT = new SY_DEVICE_CONTRACT();
                } return _SY_DEVICE_CONTRACT;
            }
            set { _SY_DEVICE_CONTRACT = value; }
        }
        FILE_PATH _FILE_PATH;

        public FILE_PATH FILE_PATH
        {
            get
            {
                if (_FILE_PATH == null)
                {
                    _FILE_PATH = new FILE_PATH();
                } return _FILE_PATH;
            }
            set { _FILE_PATH = value; }
        }
        SY_MANUAL _SY_MANUAL;

        public SY_MANUAL SY_MANUAL
        {
            get
            {
                if (_SY_MANUAL == null)
                {
                    _SY_MANUAL = new SY_MANUAL();
                } return _SY_MANUAL;
            }
            set { _SY_MANUAL = value; }
        }
        SY_MANUALBB _SY_MANUALBB;

        public SY_MANUALBB SY_MANUALBB
        {
            get
            {
                if (_SY_MANUALBB == null)
                {
                    _SY_MANUALBB = new SY_MANUALBB();
                } return _SY_MANUALBB;
            }
            set { _SY_MANUALBB = value; }
        }
        SY_MANUALPATH _SY_MANUALPATH;

        public SY_MANUALPATH SY_MANUALPATH
        {
            get
            {
                if (_SY_MANUALPATH == null)
                {
                    _SY_MANUALPATH = new SY_MANUALPATH();
                } return _SY_MANUALPATH;
            }
            set { _SY_MANUALPATH = value; }
        }
        SY_STAFF_EMTYPE _SY_STAFF_EMTYPE;

        public SY_STAFF_EMTYPE SY_STAFF_EMTYPE
        {
            get
            {
                if (_SY_STAFF_EMTYPE == null)
                {
                    _SY_STAFF_EMTYPE = new SY_STAFF_EMTYPE();
                } return _SY_STAFF_EMTYPE;
            }
            set { _SY_STAFF_EMTYPE = value; }
        }
        SY_XTBB _SY_XTBB;

        public SY_XTBB SY_XTBB
        {
            get
            {
                if (_SY_XTBB == null)
                {
                    _SY_XTBB = new SY_XTBB();
                } return _SY_XTBB;
            }
            set { _SY_XTBB = value; }
        }
    }
}