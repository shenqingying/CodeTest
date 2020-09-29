using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sonluk.PC.Models.WMS
{
    public class TABLE_COLS
    {
        private string _field;
        private string _title;
        private string _titletype;

        public string Field { get => _field; set => _field = value; }
        public string Title { get => _title; set => _title = value; }
        public string Titletype { get => _titletype; set => _titletype = value; }
    }
}