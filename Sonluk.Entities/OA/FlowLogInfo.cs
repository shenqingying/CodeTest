using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.OA
{
    public class FlowLogInfo
    {
        private string _ID;
        private string _Date;
        private string _SerialNumber;
        private string _Type; 
        private string _QualityNotification;
        private string _Template;
        private string _TemplateID;
        private string _Exception;
        private string _Remark;
        private int _Status;
       
        public string ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string Date
        {
            get { return _Date; }
            set { _Date = value; }
        }
        public string SerialNumber
        {
            get { return _SerialNumber; }
            set { _SerialNumber = value; }
        }
        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        public string QualityNotification
        {
            get { return _QualityNotification; }
            set { _QualityNotification = value; }
        }
        public string TemplateID
        {
            get { return _TemplateID; }
            set { _TemplateID = value; }
        }
        public string Template
        {
            get { return _Template; }
            set { _Template = value; }
        }
        public string Exception
        {
            get { return _Exception; }
            set { _Exception = value; }
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
    }
}
