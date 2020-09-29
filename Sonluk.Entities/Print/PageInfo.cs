using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.Print
{
    public class PageInfo<T>
    {
        private int _Index;
        private int _TotalPage;   
        private List<T> _Children;
        private int _Status;
        
        public int Index
        {
            get { return _Index; }
            set { _Index = value; }
        }
        public int TotalPage
        {
            get { return _TotalPage; }
            set { _TotalPage = value; }
        }
        public List<T> Children
        {
            get { return _Children; }
            set { _Children = value; }
        }
        public int Status
        {
            get { return _Status; }
            set { _Status = value; }
        }   

    }
}
