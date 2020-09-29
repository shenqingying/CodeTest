using Sonluk.MES.MES.Base;
using Sonluk.UI.Model.MES.PD_SCRWService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sonluk.MES.MES.main
{
    public partial class frmNearDateRW : basefrm
    {
        MES_PD_SCRW_LIST[] _rwList;

        public MES_PD_SCRW_LIST[] RwList
        {
            get { return _rwList; }
            set { _rwList = value; }
        }

     
        public frmNearDateRW()
        {
            InitializeComponent();
           
        }
        public frmNearDateRW(MES_PD_SCRW_LIST[] list)
        {
            InitializeComponent();
            RwList = list;

            jldataGridView.AutoGenerateColumns = false;

            jldataGridView.DataSource = list.ToList();
            //jldataGridView.ClearSelection();
            jldataGridView.ClearSelection();
        }

    }
}
