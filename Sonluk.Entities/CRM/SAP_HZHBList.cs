using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class SAP_HZHBList
    {
        List<SAP_KH> _ET_KH;

        public List<SAP_KH> ET_KH
        {
            get { return _ET_KH; }
            set { _ET_KH = value; }
        }
        List<SAP_HZHB> _ET_KHHZ;

        public List<SAP_HZHB> ET_KHHZ
        {
            get { return _ET_KHHZ; }
            set { _ET_KHHZ = value; }
        }
        List<SAP_KHXS> _ET_KHXS;

        public List<SAP_KHXS> ET_KHXS
        {
            get { return _ET_KHXS; }
            set { _ET_KHXS = value; }
        }
    }
}
