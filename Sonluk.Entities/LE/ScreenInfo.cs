using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.LE
{
    public class ScreenInfo
    {
        private int _ScreenID;
        private string _Location;
        private int _Status;
        private string _MContent;
        private string _ScreenName;

        public int ScreenID
        {
            get { return _ScreenID; }
            set { _ScreenID = value; }
        }

        public string Location
        {
            get { return _Location; }
            set { _Location = value; }
        }

        public string MContent
        {
            get { return _MContent; }
            set { _MContent = value; }
        }

        public int Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        public string ScreenName
        {
            get { return _ScreenName; }
            set { _ScreenName = value; }
        }
    }
}
