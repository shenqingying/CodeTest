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

    public partial class frmSGSM : baseview
    {
        List<MES_SY_MATERIAL_LIST> _MES_SY_MATERIAL_LIST;

        public List<MES_SY_MATERIAL_LIST> MES_SY_MATERIAL_LIST
        {
            get { return _MES_SY_MATERIAL_LIST; }
            set { _MES_SY_MATERIAL_LIST = value; }
        }
        public frmSGSM()
        {
            InitializeComponent();


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
            if (!Convert.ToString(wlzcomboBox.SelectedValue).Equals("0"))
            {
                model.WLGROUP = Convert.ToString(wlzcomboBox.SelectedValue);
            }
            if (!string.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                model.WLH = textBox1.Text.Trim();
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
                ShowMeg(q(Msg_Type.msgnodata), 1500);//"没有查询到数据"
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
                wllbcomboBox.DataSource = wllblist;
                wllbcomboBox.DisplayMember = "MXNAME";
                wllbcomboBox.ValueMember = "ID";

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
                    frmSGSMsub form = new frmSGSMsub(MES_SY_MATERIAL_LIST[index]);
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
