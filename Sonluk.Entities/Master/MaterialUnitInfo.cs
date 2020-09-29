using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.Master
{
    public class MaterialUnitInfo
    {
        private string _MaterialDescription; 
        private string _Base;
        private decimal _BasePrice;
        private string _Target;
        private string _TargetDescription;
        private decimal _Rate;

        private decimal _GrossWeight;
        private decimal _Volume;

        




        public string MaterialDescription
        {
            get { return _MaterialDescription; }
            set { _MaterialDescription = value; }
        }
        public string Base
        {
            get { return _Base; }
            set { _Base = value; }
        }
        public decimal BasePrice
        {
            get { return _BasePrice; }
            set { _BasePrice = value; }
        }
        public string Target
        {
            get { return _Target; }
            set { _Target = value; }
        }
        public string TargetDescription
        {
            get { return _TargetDescription; }
            set { _TargetDescription = value; }
        }
        public decimal Rate
        {
            get { return _Rate; }
            set { _Rate = value; }
        }
        public decimal GrossWeight
        {
            get { return _GrossWeight; }
            set { _GrossWeight = value; }
        }
        public decimal Volume
        {
            get { return _Volume; }
            set { _Volume = value; }
        } 
        

    }
}
