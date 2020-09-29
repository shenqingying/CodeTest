using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.LE
{
    public class GoodsInfo
    {
        private int _ID;
        private string _Name;
        private string _Material;
        private int _TypeID;
        private string _Type;
        private decimal _Quantity;
        private int _UnitID; 
        private string _Unit;
        private decimal _GrossWeight;
        private decimal _NetWeight;
        private int _WeightUnitID;
        private string _WeightUnit;
        private decimal _Volume;
        private int _VolumeUnitID;
        private string _VolumeUnit; 
        private PackageInfo _Package;
        
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public string Material
        {
            get { return _Material; }
            set { _Material = value; }
        }
        public int TypeID
        {
            get { return _TypeID; }
            set { _TypeID = value; }
        }
        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        public decimal Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }
        public int UnitID
        {
            get { return _UnitID; }
            set { _UnitID = value; }
        }
        public string Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }
        public decimal GrossWeight
        {
            get { return _GrossWeight; }
            set { _GrossWeight = value; }
        }
        public decimal NetWeight
        {
            get { return _NetWeight; }
            set { _NetWeight = value; }
        }
        public int WeightUnitID
        {
            get { return _WeightUnitID; }
            set { _WeightUnitID = value; }
        }
        public string WeightUnit
        {
            get { return _WeightUnit; }
            set { _WeightUnit = value; }
        }
        public decimal Volume
        {
            get { return _Volume; }
            set { _Volume = value; }
        }
        public int VolumeUnitID
        {
            get { return _VolumeUnitID; }
            set { _VolumeUnitID = value; }
        }
        public string VolumeUnit
        {
            get { return _VolumeUnit; }
            set { _VolumeUnit = value; }
        }
        public PackageInfo Package
        {
            get { return _Package; }
            set { _Package = value; }
        }
    }
}
