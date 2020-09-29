using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MM
{
    public class ScheReqInfo
    {
        private string _SerialNumber;
        private string _Material;
        private string _SalesOrder;
        private int _SOItem;
        private string _PurGroup;
        private string _Remark;
        private string _Creator;
        private string _Date;
        private string _EndDate;
        private string _Time;

        private string _NodePPCtrl;
        private string _NodePPCtrlDate;
        private string _NodePPCtrlTime;
        private string _NodePur;
        private string _NodePurDate;
        private string _NodePurTime;
        private string _NodePurCtrl;
        private string _NodePurCtrlDate;
        private string _NodePurCtrlEndDate;
        private string _NodePurCtrlTime;

        private string _NodeComments;

        private string _ReleaseCode;
        private List<ScheduleLineInfo> _Items;


        private string _Status;
        private string _StatusDescription;

        public string SerialNumber
        {
            get { return _SerialNumber; }
            set { _SerialNumber = value; }
        }
        public string Material
        {
            get { return _Material; }
            set { _Material = value; }
        }
        public string SalesOrder
        {
            get { return _SalesOrder; }
            set { _SalesOrder = value; }
        }
        public int SOItem
        {
            get { return _SOItem; }
            set { _SOItem = value; }
        }
        public string PurGroup
        {
            get { return _PurGroup; }
            set { _PurGroup = value; }
        } 
        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }
        public string Creator
        {
            get { return _Creator; }
            set { _Creator = value; }
        }
        public string Date
        {
            get { return _Date; }
            set { _Date = value; }
        }
        public string EndDate
        {
            get { return _EndDate; }
            set { _EndDate = value; }
        }
        public string Time
        {
            get { return _Time; }
            set { _Time = value; }
        }
        public string NodePPCtrl
        {
            get { return _NodePPCtrl; }
            set { _NodePPCtrl = value; }
        }
        public string NodePPCtrlDate
        {
            get { return _NodePPCtrlDate; }
            set { _NodePPCtrlDate = value; }
        }
        public string NodePPCtrlTime
        {
            get { return _NodePPCtrlTime; }
            set { _NodePPCtrlTime = value; }
        }
        public string NodePur
        {
            get { return _NodePur; }
            set { _NodePur = value; }
        }
        public string NodePurDate
        {
            get { return _NodePurDate; }
            set { _NodePurDate = value; }
        }
        public string NodePurTime
        {
            get { return _NodePurTime; }
            set { _NodePurTime = value; }
        }
        public string NodePurCtrl
        {
            get { return _NodePurCtrl; }
            set { _NodePurCtrl = value; }
        }
        public string NodePurCtrlDate
        {
            get { return _NodePurCtrlDate; }
            set { _NodePurCtrlDate = value; }
        }
        public string NodePurCtrlTime
        {
            get { return _NodePurCtrlTime; }
            set { _NodePurCtrlTime = value; }
        }
        public string NodePurCtrlEndDate
        {
            get { return _NodePurCtrlEndDate; }
            set { _NodePurCtrlEndDate = value; }
        }

        public List<ScheduleLineInfo> Items
        {
            get { return _Items; }
            set { _Items = value; }
        }
        public string ReleaseCode
        {
            get { return _ReleaseCode; }
            set { _ReleaseCode = value; }
        }
        public string NodeComments
        {
            get { return _NodeComments; }
            set { _NodeComments = value; }
        }
        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        public string StatusDescription
        {
            get { return _StatusDescription; }
            set { _StatusDescription = value; }
        }
    }
}
