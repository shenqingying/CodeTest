using Sonluk.MES.MES.Base;
using Sonluk.UI.Model.MES.PD_SCRWService;
using Sonluk.UI.Model.MES.SY_GZZXService;
using Sonluk.UI.Model.MES.SY_TYPEMXService;
using Sonluk.UI.Model.MES.TM_CZRService;
using Sonluk.UI.Model.MODEL;
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
    public partial class frmManagerRY : basefrm
    {
        MES_TM_CZR_SELECT_CZR_NOW _czrList;

        public MES_TM_CZR_SELECT_CZR_NOW CzrList
        {
            get { return _czrList; }
            set { _czrList = value; }
        }
        IList<RYGLclass> _RYArr;

        public IList<RYGLclass> RYArr
        {
            get { return _RYArr; }
            set { _RYArr = value; }
        }
        MES_PD_SCRW_LIST _MES_PD_SCRW_LIST;

        public MES_PD_SCRW_LIST MES_PD_SCRW_LIST
        {
            get { return _MES_PD_SCRW_LIST; }
            set { _MES_PD_SCRW_LIST = value; }
        }
        MES_SY_GZZX_GW[] _gwArr;

        public MES_SY_GZZX_GW[] GwArr
        {
            get { return _gwArr; }
            set { _gwArr = value; }
        }
        int _czlb;

        public int Czlb
        {
            get { return _czlb; }
            set { _czlb = value; }
        }
        public frmManagerRY()
        {
            int SC_width = 688;
            //int SC_height = 690;
            //int width = Screen.PrimaryScreen.Bounds.Width;
            //int hegin = Screen.PrimaryScreen.Bounds.Height;
            InitializeComponent();
            #region UI
           
            factory.configLabel(TTlabel, new Size(SC_width - 20, 40), new Point(10, 24), q(Msg_Type.fieldrygl));//"操作人员管理"
            TTlabel.TextAlign = ContentAlignment.MiddleCenter;

           

            factory.configText(SMtextBox, new Size(SC_width - 60, 40), new Point(10, TTlabel.Location.Y + 40 + 10), new Font(q(Msg_Type.fonttype), 18), "");



            factory.configGridView(RYdataGridView, new Size(SC_width - 35, 600 - SMtextBox.Location.Y - 100), new Point(35, SMtextBox.Location.Y + 40 + 10), new Font(q(Msg_Type.fonttype), 9), new DataTable());
            #endregion

        }
        public frmManagerRY(MES_TM_CZR_SELECT_CZR_NOW list,MES_PD_SCRW_LIST rwlist,int czlb)
        {
            InitializeComponent();
            _czrList = list;
            _MES_PD_SCRW_LIST = rwlist;
            Czlb = czlb;
            int SC_width = 680;
            //int SC_height = 600;

            factory.configLabel(TTlabel, new Size(SC_width - 20, 40), new Point(10, 24), q(Msg_Type.fieldrygl));//"操作人员管理"
            TTlabel.TextAlign = ContentAlignment.MiddleCenter;
            factory.configText(SMtextBox, new Size(SC_width - 35, 40), new Point(10, TTlabel.Location.Y + 40 + 10), new Font(q(Msg_Type.fonttype), 18), "");
            factory.configGridView(RYdataGridView, new Size(SC_width - 35, 600 - SMtextBox.Location.Y - 100), new Point(10, SMtextBox.Location.Y + 40 + 10), new Font(q(Msg_Type.fonttype), 9), new DataTable());
            configDataRYgrid();
           
            RYdataGridView.ReadOnly = true;

        }
        public void configDataRYgrid()
        {
            string[] cols = { q(Msg_Type.fieldxh),q(Msg_Type.fieldgh),q(Msg_Type.fieldname),q(Msg_Type.fieldgw),q(Msg_Type.fieldrydm),q(Msg_Type.fielddelete),q(Msg_Type.fieldxggw) };
                                         //"序号", "工号", "姓名", "岗位","人员代码","删除","修改岗位"
            string[] colss = { "xh", "czrgh", "czrname", "gwname", "id" ,"del","xggw"};
            string[] vcols = {q(Msg_Type.fieldrydm) };//"人员代码"
            DataRYGridBuild(cols, colss, RYdataGridView, vcols);

            DatagridgetData();
        }
        public void DatagridgetData()
        {
            RYArr = new List<RYGLclass>();
            for (int i = 0; i < _czrList.MES_TM_CZR.Length; i++)
            {
                RYGLclass node = new RYGLclass();
                node.Id = _czrList.MES_TM_CZR[i].ID;
                node.Xh = i + 1;
                node.Czrgh = _czrList.MES_TM_CZR[i].CZRGH;
                node.Czrname = _czrList.MES_TM_CZR[i].CZRNAME;
                node.Gwname = _czrList.MES_TM_CZR[i].GWNAME;
                RYArr.Add(node);
            }
            RYdataGridView.DataSource = RYArr.ToList();
        }
        public void DataRYGridBuild(string[] cols, string[] colss, DataGridView datagridGiew, string[] vcols)
        {
            IList<TPYEMX> nodes = new List<TPYEMX>();
            TPYEMX node = new TPYEMX();
            node.ID = 0;
            node.MXNAME = q(Msg_Type.titlechoice); //"请选择";//
            nodes.Add(node);
            MES_SY_TYPEMXLIST[] arr = ReadTYPEMX(8);
            for (int j = 0; j < arr.Length; j++)
            {
                TPYEMX node1 = new TPYEMX();
                node1.ID = arr[j].ID;
                node1.MXNAME = arr[j].MXNAME;
                nodes.Add(node1);
            }
            for (int i = 0; i < cols.Length; i++)
            {
                //DataGridViewButtonColumn
                if (cols[i] == "XXXXXX")
                {
                    
                    DataGridViewComboBoxColumn acCode = new DataGridViewComboBoxColumn();
                    
                    acCode.Name = cols[i];
                    acCode.DataPropertyName = colss[i];//对应数据源的字段
                    acCode.HeaderText = cols[i];
                    acCode.Width = 80;
                    datagridGiew.Columns.Add(acCode);
                   
                    acCode.DataSource = nodes.ToList(); //这里需要设置一下combox的itemsource,以便combox根据数据库中对应的值自动显示信息
                    acCode.DisplayMember = "MXNAME";
                    acCode.ValueMember = "ID";
                }
                else if (cols[i] == q(Msg_Type.fielddelete) || cols[i] == q(Msg_Type.fieldxggw))// "删除"  "修改岗位"
                {
                    DataGridViewButtonColumn acCode = new DataGridViewButtonColumn();
                    acCode.Name = cols[i];
                    acCode.UseColumnTextForButtonValue = true;
                    acCode.Text = cols[i];       
                    acCode.HeaderText = cols[i];
                    datagridGiew.Columns.Add(acCode);
                }
                else
                {
                    DataGridViewTextBoxColumn acCode = new DataGridViewTextBoxColumn();
                    acCode.Name = cols[i];
                    acCode.DataPropertyName = colss[i];
                    acCode.HeaderText = cols[i];

                    if (cols[i] == q(Msg_Type.fieldwlxx)){//"物料信息"
                        acCode.Width = 200;
                        datagridGiew.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    }
                        
                    else{
                        acCode.Width = 100;
                        datagridGiew.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                        
                    //判断不显示的在 全部字段里面有没有 有的话 就隐藏该字段
                    if (vcols.Count(p => p == cols[i]) > 0)
                    {
                        acCode.Visible = false;
                    }
                    datagridGiew.Columns.Add(acCode);
                }
               
            }
            datagridGiew.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            datagridGiew.RowTemplate.Height = 35;
            datagridGiew.RowTemplate.DefaultCellStyle.Font = new Font(q(Msg_Type.fonttype), 11);
            //datagridGiew.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            foreach (DataGridViewColumn item in datagridGiew.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }


        public class RYGLclass
        {
            int _xh;

            public int Xh
            {
                get { return _xh; }
                set { _xh = value; }
            }
            string _czrgh;

            public string Czrgh
            {
                get { return _czrgh; }
                set { _czrgh = value; }
            }
            string _czrname;

            public string Czrname
            {
                get { return _czrname; }
                set { _czrname = value; }
            }
            string _gwname;

            public string Gwname
            {
                get { return _gwname; }
                set { _gwname = value; }
            }

           

          
            int _id;

            public int Id
            {
                get { return _id; }
                set { _id = value; }
            }
        }


        private void RYdataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
           
            //判断要处理的DataGridViewComboBoxColumn名称，若符合条件，编辑控件被强制转换为ComboBox以处理，添加SelectedIndexChanged事件
            //if (this.RYdataGridView.CurrentCell.OwningColumn.Name == "岗位")
            //{
            //    ((ComboBox)e.Control).SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);
            //}
        }
        private void RYdataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.RYdataGridView.CurrentCell.OwningColumn.Name == q(Msg_Type.fielddelete))//"删除"
            {
                int id = Convert.ToInt32(this.RYdataGridView.CurrentRow.Cells[q(Msg_Type.fieldrydm)].Value);//"人员代码"
                MES_RETURN_UI res = ServicModel.TM_CZR.UPDATE_LEAVE(id, getToken());
                if (res.TYPE.Equals("S"))
                {
                    MES_TM_CZR model = new MES_TM_CZR();
                    model.GC = _MES_PD_SCRW_LIST.GC;
                   
                  
                    //model.CZRGH = SMtextBox.Text.Trim();
                    //model.GWID = 0;
                    model.CZLB = Czlb;
                    if (Czlb == 1)
                    {
                        model.RWBH = _MES_PD_SCRW_LIST.RWBH;

                    }
                    else if (Czlb == 2)
                    {
                        model.SBBH = _MES_PD_SCRW_LIST.SBBH;
                    }
                    
                    _czrList = ServicModel.TM_CZR.SELECT_CZR_NOW(model, getToken());
                    DatagridgetData();
                  
                     
                    
                }
                else
                {
                    //MessageBox.Show(res.MESSAGE, "消息框");
                    ShowMeg(res.MESSAGE);
                }
            }
            else if (this.RYdataGridView.CurrentCell.OwningColumn.Name == q(Msg_Type.fieldxggw))//"修改岗位"
            {
                MES_SY_GZZX model = new MES_SY_GZZX();
                model.GC = getGC("value");
                model.GZZXBH = Convert.ToString(getUserInfo("gzzxvalue"));

                MES_SY_GZZX_GW_LIST gwList = ServicModel.SY_GZZX.SELECT_GZZX_GW(model, getToken());
                if (gwList.MES_RETURN.TYPE.Equals("S"))
                {
                    GwArr = gwList.MES_SY_GZZX_GW;
                }
                else
                {
                    //MessageBox.Show(gwList.MES_RETURN.MESSAGE, "消息框");
                    ShowMeg(gwList.MES_RETURN.MESSAGE);
                }


                 int id = Convert.ToInt32(this.RYdataGridView.CurrentRow.Cells[q(Msg_Type.fieldrydm)].Value);//"人员代码"
                 frmGW form = new frmGW(GwArr, id);
                 show(form);
                
                 MES_TM_CZR rymodel = new MES_TM_CZR();
                 rymodel.GC = MES_PD_SCRW_LIST.GC;
                 if (Czlb == 1)
                 {
                     rymodel.RWBH = MES_PD_SCRW_LIST.RWBH;
                 }
                 else if (Czlb == 2)
                 {
                     rymodel.SBBH = MES_PD_SCRW_LIST.SBBH;
                 }
                 
                 rymodel.CZLB = Czlb;
                 _czrList = ServicModel.TM_CZR.SELECT_CZR_NOW(rymodel, getToken());
                 DatagridgetData();
            }



        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ID = Convert.ToInt16(this.RYdataGridView.CurrentRow.Cells[q(Msg_Type.fieldrydm)].Value);//"人员代码"
            ComboBox cb = (ComboBox)sender;
            object obj = cb.SelectedValue;
            MES_TM_CZR node = new MES_TM_CZR();
            if (obj is TPYEMX)
            {
                TPYEMX m = (TPYEMX)obj;
                node.ID = ID;
                node.GWID = m.ID;
            }
            else
            {
                node.ID = ID;
                node.GWID = Convert.ToInt32(obj);
            }
            Sonluk.UI.Model.MES.TM_CZRService.MES_RETURN returns = ServicModel.TM_CZR.UPDATE_GW(node, getToken());
            if (returns.TYPE.Equals("S"))
            {
                //MessageBox.Show("修改成功", "消息框");
                ShowMeg(q(Msg_Type.msgxgcg));
            }
            this.RYdataGridView.EndEdit();
        }


        private void SMtextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                    
                    MES_TM_CZR model = new MES_TM_CZR();
                    if (Czlb == 1)
                    {
                        model.RWBH = _MES_PD_SCRW_LIST.RWBH;
                        model.CZLB = Czlb;

                    }
                    else if (Czlb == 2)
                    {
                        model.SBBH = _MES_PD_SCRW_LIST.SBBH;
                        model.CZLB = Czlb;
                    }
                    model.GC = _MES_PD_SCRW_LIST.GC;
                    model.CZRGH = SMtextBox.Text.Trim();
                    model.GWID = 0;
                    MES_RETURN_UI res = AddCzr(model);
                    if (res.TYPE.Equals("S"))
                    {
                        _czrList = ServicModel.TM_CZR.SELECT_CZR_NOW(model, getToken());
                        DatagridgetData();
                    }
                    else
                    {
                        //MessageBox.Show(res.MESSAGE, "消息框");
                        ShowMeg(res.MESSAGE);
                    }
                    SMtextBox.Clear();
             
             

            }
        }

        private void frmManagerRY_Shown(object sender, EventArgs e)
        {
           
        }

        private void frmManagerRY_Load(object sender, EventArgs e)
        {
            RYdataGridView.ClearSelection();
        }

       

        
        
    }
}
