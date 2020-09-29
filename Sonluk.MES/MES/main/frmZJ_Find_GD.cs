using Sonluk.MES.MES.Base;
using Sonluk.UI.Model.MES.SY_PFDHService;
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
    public partial class frmZJ_Find_GD : basefrm
    {
        ZSL_BCST024_PO[] _list;

        public ZSL_BCST024_PO[] List
        {
            get { return _list; }
            set { _list = value; }
        }
        List<GridClass> _dirdArr;

        public List<GridClass> DirdArr
        {
            get { return _dirdArr; }
            set { _dirdArr = value; }
        }
        public frmZJ_Find_GD()
        {
            InitializeComponent();
        }
        public frmZJ_Find_GD(ZSL_BCST024_PO[] model)
        {
            InitializeComponent();
            DirdArr = new List<GridClass>();
            List = model;
            string[] cols = { q(Msg_Type.fieldgd),q(Msg_Type.fieldgdxx) };//"工单", "工单信息"
            string[] colss = { "gd", "gdxx"};
            string[] vcols = { };

            DataGridBuild(cols, colss, dataGridView1, vcols);
            //DvList = new List<DataGridclass>();
            for (int i = 0; i < List.Length; i++)
            {
                GridClass node = new GridClass();
                node.Gd = List[i].AUFNR;
                node.Gdxx = List[i].MATNR + "/" + List[i].MAKTX;               
                DirdArr.Add(node);
            }
            dataGridView1.DataSource = DirdArr;
        }
        public class GridClass
        {
            string _gd;

            public string Gd
            {
                get { return _gd; }
                set { _gd = value; }
            }
            string _gdxx;

            public string Gdxx
            {
                get { return _gdxx; }
                set { _gdxx = value; }
            }

          

        }
        private void frmZJ_Find_GD_Shown(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(187, 255, 102);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
        }
        public delegate void Block(int row);
        public Block block;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridView1.CurrentRow.Index;
            if (block != null)
            {
                block(index);
                this.Close();
            }
        }
    }
}
