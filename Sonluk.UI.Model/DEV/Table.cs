using Sonluk.UI.Model.DEV.TableService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.DEV
{
    

    public class Table
    {
        private TableSoapClient client = new TableSoapClient("TableSoap", AppConfig.Settings("RemoteAddress") + "DEV/Table.asmx");

        public string Read(string name)
        {
            return client.Read(name);
        }
    }
}
