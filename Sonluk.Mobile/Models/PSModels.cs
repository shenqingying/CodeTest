﻿using Sonluk.UI.Model.PS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sonluk.Mobile.Models
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
    }
}