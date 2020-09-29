using Sonluk.MES.MES.Base;
using Sonluk.UI.Model.MES.PD_SCRWService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Sonluk.MES.MES.main
{
    public partial class frmSelectRWList_N : basefrm
    {
        MES_PD_SCRW_LIST[] _dataArr;

        public MES_PD_SCRW_LIST[] DataArr
        {
            get { return _dataArr; }
            set { _dataArr = value; }
        }
        List<GridVrid> _jhList;

        public List<GridVrid> JhList
        {
            get { return _jhList; }
            set { _jhList = value; }
        }
        private List<int> _unfinish;

        public List<int> Unfinish
        {
            get { return _unfinish; }
            set { _unfinish = value; }
        }
        public frmSelectRWList_N()
        {
            InitializeComponent();
        }
        public frmSelectRWList_N(MES_PD_SCRW_LIST[] model,string sbh)
        {
            InitializeComponent();
            JhList = new List<GridVrid>();
            Unfinish = new List<int>();
            for (int i = 0; i < model.Length; i++)
            {               
                Unfinish.Add(model[i].ISACTION);              
            }
            //label1.Size = new Size(rect.Width, label1.Bounds.Height);
            label1.Text = q(Msg_Type.titlesbh) + sbh;//"设备号:"
            ListdataGridView.AutoGenerateColumns = false;
            DataArr = model;
            ListdataGridView.DataSource = DataArr.ToList();
          
            
            //string[] cols = {  "桶号", "配方号", "配料单号", "锌粉产地", "锌粉批号","完成状态"};
            //string[] colss = {  "Th", "Pfdh", "Pldh", "Xfcd", "Xfpc","status"};
            //string[] vcol = { };
            //string[] vcols = { "物料类别代码", "条码代码", "工厂" };
            //DataGridBuild(cols, colss, ListdataGridView, vcols);
            //configDatagrid(DataArr);

        }
        public void configDatagrid(MES_PD_SCRW_LIST[] model)
        {

            for (int i = 0; i < model.Length; i++)
            {
                GridVrid node = new GridVrid();
                //node.Xh = (i + 1).ToString();
                node.Th = model[i].TH;
                node.Pfdh = model[i].PFDH;
                node.Pldh = model[i].PLDH;
                node.Xfcd = model[i].XFCDNAME;
                node.Xfpc = model[i].XFPC;
                Unfinish.Add(model[i].ISACTION);
                JhList.Add(node);
            }

            ListdataGridView.DataSource = JhList;

        }
        public class GridVrid
        {
            // "序号", "桶号", "配方号", "配料单号", "锌粉产地","锌粉批号"
            int _th;

            public int Th
            {
                get { return _th; }
                set { _th = value; }
            }
            string _pfdh;

            public string Pfdh
            {
                get { return _pfdh; }
                set { _pfdh = value; }
            }
            string _pldh;

            public string Pldh
            {
                get { return _pldh; }
                set { _pldh = value; }
            }
            string _xfcd;

            public string Xfcd
            {
                get { return _xfcd; }
                set { _xfcd = value; }
            }
            string _xfpc;

            public string Xfpc
            {
                get { return _xfpc; }
                set { _xfpc = value; }
            }

        }

        private void frmSelectRWList_Shown(object sender, EventArgs e)
        {
            //GDdataGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(187, 255, 102);
           //ListdataGridView.Columns[6].InheritedStyle.SelectionBackColor = Color.Yellow;
            ListdataGridView.ClearSelection();
            ListdataGridView.Columns["STATUS"].DefaultCellStyle.BackColor = Color.Red;
            for (int i = 0; i < Unfinish.Count; i++)
            {
                if (Unfinish[i] == 2)
                {
                    ListdataGridView.Rows[i].Cells["STATUS"].Style.BackColor = Color.FromArgb(187, 255, 102);
                }
            }
        }

        private void ListdataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (this.ListdataGridView.CurrentCell.OwningColumn.Name == "btn")
                {
                    int index = ListdataGridView.CurrentRow.Index;
                    if (DataArr[index].ISACTION == 2)
                    {
                        frmFJprint form = new frmFJprint(DataArr[index]);
                        show(form);
                    }
                    else
                    {
                        //ShowMeg("只有完成投料的才能进行多次打印");
                        ShowMeg(q(Msg_Type.msgtimesprintbxwctl));
                    }
                }
            }
        }
    }
}
