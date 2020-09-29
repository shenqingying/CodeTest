using Sonluk.UI.Model.FICO.FM_ElectricInvoiceService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.FICO
{
    public class FM_ElectricInvoice
    {
        private FM_ElectricInvoiceSoapClient client = new FM_ElectricInvoiceSoapClient("FM_ElectricInvoiceSoap", AppConfig.Settings("RemoteAddress") + "FICO/FM_ElectricInvoice.asmx");

        public int Create(FICO_FM_ElectricInvoice model, string ptoken)
        {
            return client.Create(model, ptoken);
        }
        public int Update(FICO_FM_ElectricInvoice model, string ptoken)
        {
            return client.Update(model, ptoken);
        }
        public FICO_FM_ElectricInvoice[] ReadByParam(FICO_FM_ElectricInvoice model, string ptoken)
        {
            return client.ReadByParam(model, ptoken);
        }
        public int ReadBySCAN(FICO_FM_ElectricInvoice model, string ptoken)
        {
            return client.ReadBySCAN(model, ptoken);
        }
        public int Delete(int ID, string ptoken)
        {
            return client.Delete(ID, ptoken);
        }
    }
}
