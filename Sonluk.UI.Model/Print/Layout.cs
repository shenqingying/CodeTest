using Sonluk.UI.Model.Print.LayoutService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.Print
{
    public class Layout
    {
        private LayoutSoapClient client = new LayoutSoapClient("LayoutSoap", AppConfig.Settings("RemoteAddress") + "Print/Layout.asmx");

        public int Create(LayoutInfo node)
        {
            return client.Create(node);
        }

        public bool Update(LayoutInfo node)
        {
            return client.Update(node);
        }

        public IList<LayoutInfo> Read()
        {
            return client.Read();
        }

        public LayoutInfo Read(int ID)
        {
            return client.ReadByID(ID);
        }

        public LayoutInfo Read(string doc, string mac)
        {
            return client.ReadByDocMac(doc,mac);
        }

        public bool Delete(int ID)
        {
            return client.Delete(ID);
        }

    }
}
