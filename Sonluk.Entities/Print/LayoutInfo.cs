using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.Print
{
    public class LayoutInfo
    {

        private int _ID;
        private string _Doc;
        private string _Mac;
        private string _Name;
        private string _Background;       
        private string _Style;
        private string _Remark;
        private int _Status;
        private List<ControlInfo> _Controls;


        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string Doc
        {
            get { return _Doc; }
            set { _Doc = value; }
        }
        public string Mac
        {
            get { return _Mac; }
            set { _Mac = value; }
        }
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public string Background
        {
            get { return _Background; }
            set { _Background = value; }
        }
        public string Style
        {
            get { return _Style; }
            set { _Style = value; }
        }
        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }
        public int Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        public List<ControlInfo> Controls
        {
            get { return _Controls; }
            set { _Controls = value; }
        }
    }
}
