using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.DRF
{
    public class DRF_orders_LIST
    {
        private int _orderid;

        public int orderid
        {
            get { return _orderid; }
            set { _orderid = value; }
        }
        private string _account;

        public string account
        {
            get { return _account; }
            set { _account = value; }
        }
        private int _orderNum;

        public int orderNum
        {
            get { return _orderNum; }
            set { _orderNum = value; }
        }
        private string _storeNum;

        public string storeNum
        {
            get { return _storeNum; }
            set { _storeNum = value; }
        }


        private string _time;

        public string time
        {
            get { return _time; }
            set { _time = value; }
        }
        private int _status;

        public int status
        {
            get { return _status; }
            set { _status = value; }
        }
        private int _orderDoneid;

        public int orderDoneid
        {
            get { return _orderDoneid; }
            set { _orderDoneid = value; }
        }
        private string _orderDataid;

        public string orderDataid
        {
            get { return _orderDataid; }
            set { _orderDataid = value; }
        }
        private string _content;

        public string content
        {
            get { return _content; }
            set { _content = value; }
        }
        private string _pdfPath;

        public string pdfPath
        {
            get { return _pdfPath; }
            set { _pdfPath = value; }
        }
        private int _ordersBasicid;

        public int ordersBasicid
        {
            get { return _ordersBasicid; }
            set { _ordersBasicid = value; }
        }
        private string _OrderAmount;

        public string OrderAmount
        {
            get { return _OrderAmount; }
            set { _OrderAmount = value; }
        }
    }
}
