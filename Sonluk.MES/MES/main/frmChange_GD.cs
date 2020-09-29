using Sonluk.MES.MES.Base;
using Sonluk.MES.MES.model;
using Sonluk.UI.Model.MES.PD_SCRWService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using System.Drawing;
namespace Sonluk.MES.MES.main
{
    public partial class frmChange_GD : basefrm
    {
        private MES_PD_SCRW_LIST[] _rwList;

        public MES_PD_SCRW_LIST[] RwList
        {
            get { return _rwList; }
            set { _rwList = value; }
        }
        private IList<GDclass> _GDclassLst;

        public IList<GDclass> GDclassLst
        {
            get { return _GDclassLst; }
            set { _GDclassLst = value; }
        }
        public frmChange_GD()
        {
            int SC_width = 600;
            InitializeComponent();
            #region UI
            TTlabel.Text = q(Msg_Type.fieldrwreplace);//"任务切换";
            //TTlabel.Location = new Point(10, 24);
            //TTlabel.Size = new Size(SC_width - 20, 40);
            TTlabel.Font = new Font(q(Msg_Type.fonttype), 18);
            TTlabel.TextAlign = ContentAlignment.MiddleCenter;

            GDdataGridView.Location = new Point(10, TTlabel.Bounds.Y + 40);
            GDdataGridView.Size = new Size(SC_width - 35, 320);

            QRbutton.Location = new Point(10,GDdataGridView.Bounds.Y + 320 + 40);
            QRbutton.Size = new Size(100, 60);
            QRbutton.Text = q(Msg_Type.fieldconfirm);//"确认";
            QRbutton.Font = new System.Drawing.Font(q(Msg_Type.fonttype), 16);

            QXbutton.Location = new Point(SC_width-160, GDdataGridView.Bounds.Y + 320 + 40);
            QXbutton.Size = new Size(100, 60);
            QXbutton.Text = q(Msg_Type.fieldcancel);//"取消";
            QXbutton.Font = new System.Drawing.Font(q(Msg_Type.fonttype), 16);
            #endregion
        }
        public frmChange_GD(MES_PD_SCRW_LIST[] list,string shebeihao,Rigth_Type rtype)
        {
         
            SBHID = shebeihao;
            RwList = list;
            RigthType = rtype;
            int SC_width = 740;
            InitializeComponent();
            #region UI
            //TTlabel.Text = "工单切换信息确认";
            //TTlabel.Location = new Point(10, 24);
            //TTlabel.Size = new Size(SC_width - 20, 40);
            //TTlabel.Font = new Font(q(Msg_Type.fonttype), 18);
          
            //factory.configLabel(TTlabel, new Size(SC_width - 20, 40), new Point(10, 24), new Font(q(Msg_Type.fonttype), 18), "任务切换");

            TTlabel.Text = q(Msg_Type.fieldrwreplace);//"任务切换";
            //TTlabel.Location = new Point(10, 24);
            //TTlabel.Size = new Size(SC_width - 20, 40);
            TTlabel.Font = new Font(q(Msg_Type.fonttype), 18);
            TTlabel.TextAlign = ContentAlignment.MiddleCenter;

            //GDdataGridView.Location = new Point(35, TTlabel.Bounds.Y + 40);
            //GDdataGridView.Size = new Size(SC_width - 35, 320);
           
            //QRbutton.Location = new Point(10, GDdataGridView.Bounds.Y + 320 + 40);
            //QRbutton.Size = new Size(100, 60);
            //QRbutton.Text = "确认";
            //QRbutton.Font = new System.Drawing.Font(q(Msg_Type.fonttype), 16);

            factory.configButton(QRbutton, new Size(100, 60), new Point(10, GDdataGridView.Bounds.Y + 320 + 40), q(Msg_Type.fieldconfirm), null);//

            //QXbutton.Location = new Point(SC_width - 160, GDdataGridView.Bounds.Y + 320 + 40);
            //QXbutton.Size = new Size(100, 60);
            //QXbutton.Text = "取消";
            //QXbutton.Font = new System.Drawing.Font(q(Msg_Type.fonttype), 16);

            factory.configButton(QXbutton, new Size(100, 60), new Point(SC_width - 160, GDdataGridView.Bounds.Y + 320 + 40), q(Msg_Type.fieldcancel), null);//"取消"
            GDdataGridView.BorderStyle = BorderStyle.None;
            #endregion
            
            bulidDataGrid();
            bingDataGrid();
            //GDdataGridView.DataSource = list;
            GDdataGridView.ReadOnly = true;
            QRbutton.Visible = false;
            QXbutton.Visible = false;
        }
        public delegate void ChangeGDdelegate(MES_PD_SCRW_LIST list, string shebeihaoID);
        public ChangeGDdelegate changeGDdelegate;
        private void QRbutton_Click(object sender, EventArgs e)
        {
            if (changeGDdelegate != null)
            {
                int index = GDdataGridView.CurrentRow.Index;
                changeGDdelegate(RwList[index], SBHID);
                this.Close();
                return;
            }
            if (GDdataGridView.SelectedRows.Count == 1)
            {
                int index = GDdataGridView.CurrentRow.Index;
                frmTL2_1 form = new frmTL2_1(RwList[index], SBHID, RigthType);
                push(form,this);
            }
            else
            {
                int index = GDdataGridView.CurrentCell.RowIndex;
                if (index >= 0)
                {
                     index = GDdataGridView.CurrentCell.RowIndex;
                     frmTL2_1 form = new frmTL2_1(RwList[index], SBHID, RigthType);
                    push(form,this);
                }else{
                    //MessageBox.Show("切换工单必须选择一行", "消息框");
                    ShowMeg(q(Msg_Type.msggdchocierow));
                }
               
            }
            
        }

        private void QXbutton_Click(object sender, EventArgs e)
        {

        }

        private void bulidDataGrid(){
            string[] cols = { q(Msg_Type.fieldrwd), q(Msg_Type.fieldgddm), q(Msg_Type.fieldmesgd), q(Msg_Type.fielderpgd), q(Msg_Type.fieldwlxx), q(Msg_Type.fieldwllb), q(Msg_Type.fieldbcms) };//"任务单","工单代码","MES工单号","ERP工单","物料信息","物料类别","班次描述"
            string[] colss = {"rwd", "id", "gdh","erpno", "wlxx", "wllb" ,"bc"};
            string[] vcols = { q(Msg_Type.fieldgddm) };//"工单代码"
            DataGridBuild(cols,colss,GDdataGridView,vcols);
        }
        private void bingDataGrid()
        {
            GDclassLst = new List<GDclass>();
            for (int i = 0; i < RwList.Length; i++)
            {
                GDclass model = new GDclass();
                model.Rwd = RwList[i].RWBH;
                model.Id = RwList[i].RWBH;
                model.Wllb = RwList[i].WLLBNAME;
                model.Wlxx = RwList[i].WLH + "/" + RwList[i].WLMS;
                model.Erpno = RwList[i].ERPNO;
                model.Gdh = RwList[i].GDDH;
                model.Bc = RwList[i].BCMS;
                GDclassLst.Add(model);
            }
            GDdataGridView.DataSource = GDclassLst;
            GDdataGridView.ClearSelection();
            GDdataGridView.Columns[q(Msg_Type.fieldbcms)].DisplayIndex = 0;//"班次描述"
        }


        public class GDclass
        {
           
            string _rwd;

            public string Rwd
            {
                get { return _rwd; }
                set { _rwd = value; }
            }
            string _erpno;

            public string Erpno
            {
                get { return _erpno; }
                set { _erpno = value; }
            }
            string _id;

            public string Id
            {
                get { return _id; }
                set { _id = value; }
            }
            string _gdh;

            public string Gdh
            {
                get { return _gdh; }
                set { _gdh = value; }
            }
            string _wlxx;

            public string Wlxx
            {
                get { return _wlxx; }
                set { _wlxx = value; }
            }
            string _wllb;

            public string Wllb
            {
                get { return _wllb; }
                set { _wllb = value; }
            }
            string _bc;

            public string Bc
            {
                get { return _bc; }
                set { _bc = value; }
            }
           
        }

        private void GDdataGridView_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmChange_GD_Load(object sender, EventArgs e)
        {
            GDdataGridView.ClearSelection();
            GDdataGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(187, 255, 102);
            GDdataGridView.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        //private void GDdataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    int index = GDdataGridView.CurrentRow.Index;
        //    frmTL2 form = new frmTL2(RwList[index], SBHID);
        //    push(form);
        //}
        public delegate void Block(MES_PD_SCRW_LIST list, string sbh);
        public Block block;
        private void GDdataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                int index = GDdataGridView.CurrentRow.Index;

                if (block != null)
                {
                    block(RwList[index], SBHID);
                    this.Close();
                }
            }
           
           
        }


    }
}
