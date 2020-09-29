using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.LE
{
    public class CityInfo
    {
        private string _SerialNumber;
        private int _ID;
        private string _Name;
        private int _ProvinceID;
        private string _Remark;
        

        private List<CityInfo> _Children;

        public List<CityInfo> Children
        {
            get { return _Children; }
            set { _Children = value; }
        }
        public string SerialNumber
        {
            get { return _SerialNumber; }
            set { _SerialNumber = value; }
        }
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
        public int ProvinceID
        {
            get { return _ProvinceID; }
            set { _ProvinceID = value; }
        }
        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }
    }
}
