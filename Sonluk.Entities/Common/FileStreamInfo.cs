using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.Common
{
    public class FileStreamInfo
    {
        private string _Name;
        private string _Extension;
        private string _TattedCode;
        private byte[] _Bytes;

        
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public string Extension
        {
            get { return _Extension; }
            set { _Extension = value; }
        }
        public string TattedCode
        {
            get { return _TattedCode; }
            set { _TattedCode = value; }
        }
        public byte[] Bytes
        {
            get { return _Bytes; }
            set { _Bytes = value; }
        }
    }
}
