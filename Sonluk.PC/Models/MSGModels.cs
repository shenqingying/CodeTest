using Sonluk.UI.Model.MSG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sonluk.PC.Models
{
    public class MSGModels
    {

        SYS_SYSINFO _SYS_SYSINFO;

        public SYS_SYSINFO SYS_SYSINFO
        {
            get
            {
                if (_SYS_SYSINFO == null)
                {
                    _SYS_SYSINFO = new SYS_SYSINFO();
                }
                return _SYS_SYSINFO;
            }
            set { _SYS_SYSINFO = value; }
        }

        SYS_STAFF _SYS_STAFF;

        public SYS_STAFF SYS_STAFF
        {
            get
            {
                if (_SYS_STAFF == null)
                {
                    _SYS_STAFF = new SYS_STAFF();
                }
                return _SYS_STAFF;
            }
            set { _SYS_STAFF = value; }
        }
        SEND_INFO _SEND_INFO;

        public SEND_INFO SEND_INFO
        {
            get
            {
                if (_SEND_INFO == null)
                {
                    _SEND_INFO = new SEND_INFO();
                }
                return _SEND_INFO;
            }
            set { _SEND_INFO = value; }
        }
        MSG_TYPE _MSG_TYPE;

        public MSG_TYPE MSG_TYPE
        {
            get
            {
                if (_MSG_TYPE == null)
                {
                    _MSG_TYPE = new MSG_TYPE();
                }
                return _MSG_TYPE;
            }
            set { _MSG_TYPE = value; }
        }
        MSG_SENDWAY _MSG_SENDWAY;

        public MSG_SENDWAY MSG_SENDWAY
        {
            get
            {
                if (_MSG_SENDWAY == null)
                {
                    _MSG_SENDWAY = new MSG_SENDWAY();
                }
                return _MSG_SENDWAY;
            }
            set { _MSG_SENDWAY = value; }
        }
        MSGTYPE_WAY _MSGTYPE_WAY;

        public MSGTYPE_WAY MSGTYPE_WAY
        {
            get
            {
                if (_MSGTYPE_WAY == null)
                {
                    _MSGTYPE_WAY = new MSGTYPE_WAY();
                }
                return _MSGTYPE_WAY;
            }
            set { _MSGTYPE_WAY = value; }
        }





    }
}