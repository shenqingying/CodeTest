using Sonluk.UI.Model.S5.SY_DICTService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sonluk.PC.Areas.FIVES.Models
{
    public class Model_FIVES_ALL
    {
        FIVES_SY_DICT[] _FIVES_SY_DICT;

        public FIVES_SY_DICT[] FIVES_SY_DICT
        {
            get { return _FIVES_SY_DICT; }
            set { _FIVES_SY_DICT = value; }
        }
    }
}