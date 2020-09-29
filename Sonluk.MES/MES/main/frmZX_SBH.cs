using Sonluk.MES.MES.Base;
using Sonluk.UI.Model.MES.SY_GZZX_SBHService;
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
    public partial class frmZX_SBH : basefrm
    {
        public frmZX_SBH()
        {
            InitializeComponent();

            MES_SY_GZZX_SBH model = new MES_SY_GZZX_SBH();
            model.GC = getGC("value");
            model.STAFFID = Convert.ToInt16(getUserInfo("staffid"));
            model.WLLBNAME = "素电";
            MES_SY_GZZX_SBH[] list = ServicModel.SY_GZZX_SBH.SELECT_BY_STAFFID(model, getToken());


        }



    }
}
