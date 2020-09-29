using Sonluk.MES.MES.Base;
using Sonluk.UI.Model.MES.SY_GCService;
using Sonluk.UI.Model.MES.SY_MATERIAL_GROUPService;
using Sonluk.UI.Model.MES.SY_MATERIALService;
using Sonluk.UI.Model.MES.SY_TYPEMXService;
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

    public partial class frmSGSM_Puls : baseview
    {
        List<MES_SY_MATERIAL_LIST> _MES_SY_MATERIAL_LIST;

        public List<MES_SY_MATERIAL_LIST> MES_SY_MATERIAL_LIST
        {
            get { return _MES_SY_MATERIAL_LIST; }
            set { _MES_SY_MATERIAL_LIST = value; }
        }
        int[] _wllbArr;

        public int[] WllbArr
        {
            get { return _wllbArr; }
            set { _wllbArr = value; }
        }
        public frmSGSM_Puls(int[] wllbArr)
        {
            InitializeComponent();

            WllbArr = wllbArr;
            dataGridView1.AutoGenerateColumns = false;
            MES_SY_GC gcmodel = new MES_SY_GC();
            gcmodel.STAFFID = Convert.ToInt32(getUserInfo("staffid"));
            MES_SY_GC[] gcArr = ServicModel.SY_GC.SELECT_BY_ROLE(gcmodel, getToken());
            for (int i = 0; i < gcArr.Length; i++)
            {
                gcArr[i].GCMS = gcArr[i].GC + "-" + gcArr[i].GCMS;
            }
            List<MES_SY_GC> gcList = gcArr.ToList();
            MES_SY_GC choiceModel = new MES_SY_GC();
            choiceModel.GCMS = q(Msg_Type.titlechoice);//"==请选择==";
            choiceModel.GC = "0";
            gcList.Insert(0, choiceModel);
            gccomboBox.DisplayMember = "GCMS";
            gccomboBox.ValueMember = "GC";
            gccomboBox.DataSource = gcList;
            if (gcList.Count == 2)
            {
                gccomboBox.SelectedValue = gcList[1].GC;
            }
        }

        private void cxbutton_Click(object sender, EventArgs e)
        {
            MES_SY_MATERIAL model = new MES_SY_MATERIAL();
            if (!Convert.ToString(gccomboBox.SelectedValue).Equals("0"))
            {
                model.GC = Convert.ToString(gccomboBox.SelectedValue);
            }
            if (!Convert.ToString(wllbcomboBox.SelectedValue).Equals("0"))
            {
                model.WLLB = Convert.ToInt32(wllbcomboBox.SelectedValue);
            }
            else
            {
                ShowMeg(q(Msg_Type.msgwllbnoempty));//"物料类别不能为空"
                return;
            }
            if (!Convert.ToString(wlzcomboBox.SelectedValue).Equals("0"))
            {
                model.WLGROUP = Convert.ToString(wlzcomboBox.SelectedValue);
            }
            if (!string.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                model.WLH = textBox1.Text.Trim();
            }
            if (!Convert.ToString(dcxhcomboBox.SelectedValue).Equals("0"))
            {
                model.DCXH = Convert.ToInt32(dcxhcomboBox.SelectedValue);
            }
            if (!Convert.ToString(dcdjcomboBox.SelectedValue).Equals("0"))
            {
                model.DCDJ = Convert.ToInt32(dcdjcomboBox.SelectedValue);
            }
            MES_SY_MATERIAL_SELECT res = ServicModel.SY_MATERIAL.SELECT_ACTION(model, getToken());
            if (res.MES_RETURN.TYPE.Equals("S"))
            {
                dataGridView1.DataSource = res.MES_SY_MATERIAL.ToList();
                MES_SY_MATERIAL_LIST = res.MES_SY_MATERIAL.ToList();
                dataGridView1.ClearSelection();
            }
            else
            {
                ShowMeg(q(Msg_Type.msgnodata),1500);//"没有查询到数据"
            }
        }

        private void gccomboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            object obj = cb.SelectedValue;
            if (obj is string)
            {
                MES_SY_TYPEMX typeModel = new MES_SY_TYPEMX();
                typeModel.TYPEID = 4;
                typeModel.GC = Convert.ToString(obj);
                MES_SY_TYPEMXLIST[] wllbArr = ServicModel.SY_TYPEMX.SELECT(typeModel, getToken());                
                List<MES_SY_TYPEMXLIST> wllblist = wllbArr.ToList();
                MES_SY_TYPEMXLIST choicwllb = new MES_SY_TYPEMXLIST();
                choicwllb.ID = 0;
                choicwllb.MXNAME = q(Msg_Type.titlechoice);//"==请选择==";
                wllblist.Insert(0, choicwllb);
                wllbcomboBox.DisplayMember = "MXNAME";
                wllbcomboBox.ValueMember = "ID";
                if (WllbArr.Length != 0)
                {
                    List<MES_SY_TYPEMXLIST> nodes = new List<MES_SY_TYPEMXLIST>();

                    for (int i = 0; i < wllblist.Count; i++)
                    {
                        for (int j = 0; j < WllbArr.Length; j++)
                        {
                            if (wllblist[i].ID == WllbArr[j])
                            {
                                MES_SY_TYPEMXLIST node = new MES_SY_TYPEMXLIST();
                                node.ID = wllblist[i].ID;
                                node.MXNAME = wllblist[i].MXNAME;
                                nodes.Add(node);
                            }
                        }
                       
                       
                    }
                    nodes.Insert(0,choicwllb);
                    wllbcomboBox.DataSource = nodes;
                    if (nodes.Count == 2)
                    {
                        wllbcomboBox.SelectedValue = nodes[1].ID;
                    }
                }
                else
                {
                    wllbcomboBox.DataSource = wllblist;
                }

               
                
            

                MES_SY_MATERIAL_GROUP groupModel = new MES_SY_MATERIAL_GROUP();
                groupModel.GC = Convert.ToString(obj);
                MES_SY_MATERIAL_GROUP_SELECT res = ServicModel.SY_MATERIAL_GROUP.SELECT_USER(groupModel, getToken());
                if (res.MES_RETURN.TYPE.Equals("S"))
                {
                    List<MES_SY_MATERIAL_GROUP> grouplist = res.MES_SY_MATERIAL_GROUP.ToList();
                    groupModel.WLGROUPNAME = q(Msg_Type.titlechoice);//"==请选择==";
                    groupModel.WLGROUP = "0";
                    grouplist.Insert(0, groupModel);
                    wlzcomboBox.DataSource = grouplist;
                    wlzcomboBox.DisplayMember = "WLGROUPNAME";
                    wlzcomboBox.ValueMember = "WLGROUP";

                }
                else
                {
                    List<MES_SY_MATERIAL_GROUP> grouplist = new List<MES_SY_MATERIAL_GROUP>();
                    groupModel.WLGROUPNAME = q(Msg_Type.titlechoice);//"==请选择==";
                    groupModel.WLGROUP = "0";
                    grouplist.Insert(0, groupModel);
                    wlzcomboBox.DataSource = grouplist;
                    wlzcomboBox.DisplayMember = "WLGROUPNAME";
                    wlzcomboBox.ValueMember = "WLGROUP";
                }

                MES_SY_TYPEMX dcxhModel = new MES_SY_TYPEMX();
                dcxhModel.TYPEID = 6;
                dcxhModel.GC = Convert.ToString(obj);
                MES_SY_TYPEMXLIST[] dcxhres = ServicModel.SY_TYPEMX.SELECT(dcxhModel, getToken());
                List<MES_SY_TYPEMXLIST> dcxhlist = dcxhres.ToList();
                MES_SY_TYPEMXLIST dcxhnode = new MES_SY_TYPEMXLIST();
                dcxhnode.MXNAME = q(Msg_Type.titlechoice);//"==请选择==";
                dcxhnode.ID = 0;
                dcxhlist.Insert(0, dcxhnode);
                dcxhcomboBox.DataSource = dcxhlist;
                dcxhcomboBox.DisplayMember = "MXNAME";
                dcxhcomboBox.ValueMember = "ID";

                MES_SY_TYPEMX dcdjModel = new MES_SY_TYPEMX();
                dcdjModel.TYPEID = 7;
                dcdjModel.GC = Convert.ToString(obj);
                MES_SY_TYPEMXLIST[] dcdjres = ServicModel.SY_TYPEMX.SELECT(dcdjModel, getToken());
                List<MES_SY_TYPEMXLIST> dcdjlist = dcdjres.ToList();
                MES_SY_TYPEMXLIST dcdjnode = new MES_SY_TYPEMXLIST();
                dcdjnode.MXNAME = q(Msg_Type.titlechoice);//"==请选择==";
                dcdjnode.ID = 0;
                dcdjlist.Insert(0, dcdjnode);
                dcdjcomboBox.DataSource = dcdjlist;
                dcdjcomboBox.DisplayMember = "MXNAME";
                dcdjcomboBox.ValueMember = "ID";
            }
        }
        private void wllbcomboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            object obj = cb.SelectedValue;
            if (obj is int)
            {
                MES_SY_MATERIAL_GROUP groupModel = new MES_SY_MATERIAL_GROUP();
                if (!Convert.ToString(gccomboBox.SelectedValue).Equals("S"))
	            {
                    groupModel.GC = Convert.ToString(gccomboBox.SelectedValue);
	            }
                //groupModel.GC = Convert.ToString(obj);
                groupModel.WLLB = Convert.ToInt32(wllbcomboBox.SelectedValue);
                //groupModel.WLLB = 
                MES_SY_MATERIAL_GROUP_SELECT res = ServicModel.SY_MATERIAL_GROUP.SELECT_USER(groupModel, getToken());

                if (res.MES_RETURN.TYPE.Equals("S"))
                {
                    List<MES_SY_MATERIAL_GROUP> grouplist = res.MES_SY_MATERIAL_GROUP.ToList();
                    groupModel.WLGROUPNAME = q(Msg_Type.titlechoice);//"==请选择==";
                    groupModel.WLGROUP = "0";
                    grouplist.Insert(0, groupModel);
                    wlzcomboBox.DataSource = grouplist;
                    wlzcomboBox.DisplayMember = "WLGROUPNAME";
                    wlzcomboBox.ValueMember = "WLGROUP";

                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            judge.isNum(textBox1, e);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (this.dataGridView1.CurrentCell.OwningColumn.Name == "btn")
                {
                    int index = dataGridView1.CurrentRow.Index;
                    frmSGSMsub_sudian form = new frmSGSMsub_sudian(MES_SY_MATERIAL_LIST[index], 378);
                    show(form);
                }
            }
            
           
        }

        private void wlzcomboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            //ComboBox cb = (ComboBox)sender;
            //object obj = cb.SelectedValue;
            //if (obj is string)
            //{
            //    MES_SY_MATERIAL_GROUP groupModel = new MES_SY_MATERIAL_GROUP();
            //    groupModel.GC = Convert.ToString(obj);
            //    MES_SY_MATERIAL_GROUP_SELECT res = ServicModel.SY_MATERIAL_GROUP.SELECT_USER(groupModel, getToken());

            //    if (res.MES_RETURN.TYPE.Equals("S"))
            //    {
            //        List<MES_SY_MATERIAL_GROUP> grouplist = res.MES_SY_MATERIAL_GROUP.ToList();
            //        groupModel.WLGROUPNAME = "==请选择==";
            //        groupModel.WLGROUP = "0";
            //        grouplist.Insert(0, groupModel);
            //        wlzcomboBox.DataSource = grouplist;
            //        wlzcomboBox.DisplayMember = "WLGROUPNAME";
            //        wlzcomboBox.ValueMember = "WLGROUP";

            //    }
            //}
        }
    }
}
