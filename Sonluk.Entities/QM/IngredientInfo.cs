using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.QM
{
    public class IngredientInfo
    {
        private string _SerialNumber;
        private string _CreateDate;
        private string _Creator;

        public string SerialNumber
        {
            get { return _SerialNumber; }
            set { _SerialNumber = value; }
        }
        public string CreateDate
        {
            get { return _CreateDate; }
            set { _CreateDate = value; }
        }
        public string Creator
        {
            get { return _Creator; }
            set { _Creator = value; }
        }
    }
}
