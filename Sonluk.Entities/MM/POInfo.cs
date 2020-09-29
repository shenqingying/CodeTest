using Sonluk.Entities.Account;
using Sonluk.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MM
{
    public class POInfo
    {
        private POHeaderInfo _Header;
        private PurchasingGroupInfo _PurGroup;
        private CompanyInfo _Vendor;
        private CompanyInfo _Company;
        private List<CustomTextInfo> _CustomText;
        private List<POItemInfo> _Items;
        private int _Status;
        private int allLine;//用于统计行数工程类

        public int AllLine
        {
            get { return allLine; }
            set { allLine = value; }
        }

        public POHeaderInfo Header
        {
            get { return _Header; }
            set { _Header = value; }
        }
        public PurchasingGroupInfo PurGroup
        {
            get { return _PurGroup; }
            set { _PurGroup = value; }
        }
        public CompanyInfo Vendor
        {
            get { return _Vendor; }
            set { _Vendor = value; }
        }
        public CompanyInfo Company
        {
            get { return _Company; }
            set { _Company = value; }
        }
        public List<CustomTextInfo> CustomText
        {
            get { return _CustomText; }
            set { _CustomText = value; }
        }
        public List<POItemInfo> Items
        {
            get { return _Items; }
            set { _Items = value; }
        }
        public int Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
    }
}
