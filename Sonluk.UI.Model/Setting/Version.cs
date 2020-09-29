using Sonluk.UI.Model.Setting.VersionService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.Setting
{
    public class Version
    {
        private VersionSoapClient client = new VersionSoapClient("VersionSoap", AppConfig.Settings("RemoteAddress") + "Setting/Version.asmx");

        public string Read()
        {
            return client.Read();
        }
    }
}
