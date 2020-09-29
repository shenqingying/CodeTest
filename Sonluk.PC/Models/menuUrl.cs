using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sonluk.PC.Models
{
    public class menuUrl
    {
        private string _view;

        public string View
        {
            get { return _view; }
            set { _view = value; }
        }
        private string _controller;

        public string Controller
        {
            get { return _controller; }
            set { _controller = value; }
        }
        private string _area;

        public string Area
        {
            get { return _area; }
            set { _area = value; }
        }
    }
}