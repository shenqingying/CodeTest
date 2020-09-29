using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sonluk.UI.Model.MM;

namespace Sonluk.Models
{
    public class MMModels
    {
        private PurchaseOrder _PurchaseOrder;
        private ScheduleRequisition _ScheduleRequisition;

        public PurchaseOrder PurchaseOrder
        {
            get
            {
                if (_PurchaseOrder == null)
                    _PurchaseOrder = new PurchaseOrder();
                return _PurchaseOrder;
            }
            set { _PurchaseOrder = value; }
        }

        public ScheduleRequisition ScheduleRequisition
        {
            get
            {
                if (_ScheduleRequisition == null)
                    _ScheduleRequisition = new ScheduleRequisition();
                return _ScheduleRequisition;
            }
            set { _ScheduleRequisition = value; }
        }
    }
}