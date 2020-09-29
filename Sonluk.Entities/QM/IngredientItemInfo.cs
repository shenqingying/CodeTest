using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.QM
{
    public class IngredientItemInfo
    {
        private string _SerialNumber;
        private string _Item;
        private string _Material;
        private string _MaterialDescription;
        private string _InspectionLot;
        private string _Batch;
        private string _Vendor;
        private string _VendorDescription;
        private string _VendorBatch;
        

        public string SerialNumber
        {
            get { return _SerialNumber; }
            set { _SerialNumber = value; }
        }
        public string Item
        {
            get { return _Item; }
            set { _Item = value; }
        }
        public string Material
        {
            get { return _Material; }
            set { _Material = value; }
        }
        public string MaterialDescription
        {
            get { return _MaterialDescription; }
            set { _MaterialDescription = value; }
        }
        public string InspectionLot
        {
            get { return _InspectionLot; }
            set { _InspectionLot = value; }
        }
        public string Batch
        {
            get { return _Batch; }
            set { _Batch = value; }
        }
        public string Vendor
        {
            get { return _Vendor; }
            set { _Vendor = value; }
        }
        public string VendorDescription
        {
            get { return _VendorDescription; }
            set { _VendorDescription = value; }
        }
        public string VendorBatch
        {
            get { return _VendorBatch; }
            set { _VendorBatch = value; }
        }
    }
}
