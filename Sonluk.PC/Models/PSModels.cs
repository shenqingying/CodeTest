using Sonluk.UI.Model.PS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sonluk.PC.Models
{
    public class PSModels
    {
        private NetWork _NetWork;

        public NetWork NetWork
        {
            get
            {
                if (_NetWork == null)
                    _NetWork = new NetWork();
                return _NetWork;
            }
            set { _NetWork = value; }
        }

        private ComponentMove _ComponentMove;

        public ComponentMove ComponentMove
        {
            get
            {
                if (_ComponentMove == null)
                    _ComponentMove = new ComponentMove();
                return _ComponentMove;
            }
            set { _ComponentMove = value; }
        }
        CNFH _CNFH;

        public CNFH CNFH
        {
            get
            {
                if (_CNFH == null)
                {
                    _CNFH = new CNFH();
                } return _CNFH;
            }
            set { _CNFH = value; }
        }
    }
}