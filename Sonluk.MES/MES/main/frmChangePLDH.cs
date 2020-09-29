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
    public partial class frmChangePLDH : basefrm
    {
        public delegate void SendSelectRow(ZSL_BCT304_LOT model);
        public SendSelectRow sendSelectRow;
        ZSL_BCT304_LOT[] _pldhList;

        public ZSL_BCT304_LOT[] PldhList
        {
            get { return _pldhList; }
            set { _pldhList = value; }
        }
        string _sbbh;

        public string Sbbh
        {
            get { return _sbbh; }
            set { _sbbh = value; }
        }
        string _pldh;

        public string Pldh
        {
            get { return _pldh; }
            set { _pldh = value; }
        }
        List<DataGridclass> _dvList;

        public List<DataGridclass> DvList
        {
            get { return _dvList; }
            set { _dvList = value; }
        }
        public frmChangePLDH()
        {
            
        }
        public frmChangePLDH(ZSL_BCT304_LOT[] model,string sbh,string pldh)
        {
            InitializeComponent();
            PldhList = model;
            Sbbh = sbh;
            Pldh = pldh;
            string[] cols = { q(Msg_Type.fieldpldh), q(Msg_Type.fieldpfdh), q(Msg_Type.fieldqyrq), q(Msg_Type.fieldjsrq) };//"配料单号", "配方单号", "启用日期", "结束日期"
            string[] colss = { "pldh", "pfdh", "qyrq", "jsrq"};
            string[] vcols = {};
           
            DataGridBuild(cols, colss, pldataGridView, vcols);
            DvList = new List<DataGridclass>();
            for (int i = 0; i < PldhList.Length; i++)
            {
                DataGridclass node = new DataGridclass();
                node.Pldh = PldhList[i].PLDH;
                node.Pfdh = PldhList[i].PFDH;
                node.Qyrq = PldhList[i].QYRQ;
                node.Jsrq = PldhList[i].JSRQ;
                DvList.Add(node);
            }
            pldataGridView.DataSource = DvList;

        }
       
        private void pldataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                int index = pldataGridView.CurrentRow.Index;
                if (sendSelectRow != null)
                {
                    sendSelectRow(PldhList[index]);
                    this.Close();
                }
            }
           
        }
        public class DataGridclass
        {
            string _pldh;

            public string Pldh
            {
                get { return _pldh; }
                set { _pldh = value; }
            }
            string _pfdh;

            public string Pfdh
            {
                get { return _pfdh; }
                set { _pfdh = value; }
            }
            string _qyrq;

            public string Qyrq
            {
                get { return _qyrq; }
                set { _qyrq = value; }
            }
            string _jsrq;

            public string Jsrq
            {
                get { return _jsrq; }
                set { _jsrq = value; }
            }
        }

        private void frmChangePLDH_Shown(object sender, EventArgs e)
        {
            pldataGridView.ClearSelection();
            pldataGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(187, 255, 102);
            pldataGridView.DefaultCellStyle.SelectionForeColor = Color.Black;
            
            if (string.IsNullOrEmpty(Pldh) == false)
            {
                for (int i = 0; i < pldataGridView.Rows.Count; i++)
                {
                    string a = pldataGridView.Rows[i].Cells[0].Value.ToString();
                    if (Pldh == Convert.ToString(pldataGridView.Rows[i].Cells[0].Value))
                    {
                        pldataGridView.CurrentCell = pldataGridView.Rows[i].Cells[0];
                        pldataGridView.Rows[i].Selected = true;
                    }    
                    
                }
            }
           
        }
    }
}
