using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.DRF
{
    public class DRF_ordersHead_LIST
    {
        private int _ordersHeadid;

        public int ordersHeadid
        {
            get { return _ordersHeadid; }
            set { _ordersHeadid = value; }
        }
        private string _account;

        public string account
        {
            get { return _account; }
            set { _account = value; }
        }
        private string _OrderNum;

        public string OrderNum
        {
            get { return _OrderNum; }
            set { _OrderNum = value; }
        }
        private string _StoreNum;

        public string StoreNum
        {
            get { return _StoreNum; }
            set { _StoreNum = value; }
        }
        private string _StoreName;

        public string StoreName
        {
            get { return _StoreName; }
            set { _StoreName = value; }
        }
        private string _StoreAddr;

        public string StoreAddr
        {
            get { return _StoreAddr; }
            set { _StoreAddr = value; }
        }
        private string _StoreTel;

        public string StoreTel
        {
            get { return _StoreTel; }
            set { _StoreTel = value; }
        }
        private string _StoreFax;

        public string StoreFax
        {
            get { return _StoreFax; }
            set { _StoreFax = value; }
        }
        private string _OrderDate;

        public string OrderDate
        {
            get { return _OrderDate; }
            set { _OrderDate = value; }
        }
        private string _DeliveryDate;

        public string DeliveryDate
        {
            get { return _DeliveryDate; }
            set { _DeliveryDate = value; }
        }
        private string _StoreNews;

        public string StoreNews
        {
            get { return _StoreNews; }
            set { _StoreNews = value; }
        }
        private string _Remark;

        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }
        private string _headTime;

        public string HeadTime
        {
            get { return _headTime; }
            set { _headTime = value; }
        }
    }
}
