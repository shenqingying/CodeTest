using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sonluk.Models
{
    public class SettingModels
    {
        private Sonluk.UI.Model.Setting.Version _Version;

        public Sonluk.UI.Model.Setting.Version Version
        {
            get
            {
                if (_Version == null)
                    _Version = new Sonluk.UI.Model.Setting.Version();
                return _Version;
            }
            set { _Version = value; }
        }
    }
}