using Sonluk.UI.Model.LE.TRA.PackageService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.LE.TRA
{
    public class Package
    {
        private PackageSoapClient client = new PackageSoapClient("PackageSoap", AppConfig.Settings("RemoteAddress") + "LE/TRA/Package.asmx");

        public IList<PackageInfo> Type()
        {
            return client.Type();
        }
    }
}
