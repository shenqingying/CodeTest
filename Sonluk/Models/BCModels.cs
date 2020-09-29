using Sonluk.UI.Model.BC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sonluk.Models
{
    public class BCModels
    {
        private Enqueue _Enqueue;
        private User _User;
        private BarCode _BarCode;

        public Enqueue Enqueue
        {
            get
            {
                if (_Enqueue == null)
                    _Enqueue = new Enqueue();
                return _Enqueue;
            }
            set { _Enqueue = value; }
        }

        public User User
        {
            get
            {
                if (_User == null)
                    _User = new User();
                return _User;
            }
            set { _User = value; }
        }

        public BarCode BarCode
        {
            get
            {
                if (_BarCode == null)
                    _BarCode = new BarCode();
                return _BarCode;
            }
            set { _BarCode = value; }
        }
    }
}