using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.QM
{
    public class QNItemInfo
    {
        private string _SerialNumber;

        
        private string _CodeGroup;
        private string _CauseCode;
        private string _CauseDescription;

        private string _DefectType;
        private string _DefectReason; 
        private int _DefectQty;
        

        public string SerialNumber
        {
            get { return _SerialNumber; }
            set { _SerialNumber = value; }
        }
        public string CauseCode
        {
            get { return _CauseCode; }
            set { _CauseCode = value; }
        }
        public string CodeGroup
        {
            get { return _CodeGroup; }
            set { _CodeGroup = value; }
        }
        public string CauseDescription
        {
            get { return _CauseDescription; }
            set { _CauseDescription = value; }
        }
        public string DefectType
        {
            get { return _DefectType; }
            set { _DefectType = value; }
        }
        public string DefectReason
        {
            get { return _DefectReason; }
            set { _DefectReason = value; }
        }
        public int DefectQty
        {
            get { return _DefectQty; }
            set { _DefectQty = value; }
        }

    }
}
