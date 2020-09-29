using Sonluk.MES.MES.Base;
using Sonluk.UI.Model.MES.SY_TYPEMXService;
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
    public partial class frmModifyMX : basefrm
    {
        MES_SY_TYPEMXLIST[] _list;

        public MES_SY_TYPEMXLIST[] List
        {
            get { return _list; }
            set { _list = value; }
        }
        int _typeID;

        public int TypeID
        {
            get { return _typeID; }
            set { _typeID = value; }
        }
        int _index;

        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }
        public frmModifyMX()
        {
            InitializeComponent();
        }

        public frmModifyMX(int type)
        {
            InitializeComponent();
            TypeID = type;
            if (type == 12)
            {
                this.Text = q(Msg_Type.fieldscbzgl);//"生产班组管理";
            }
            else if (type == 13)
            {
                this.Text = q(Msg_Type.fieldslgl);//"数量管理";
            }
            
        }
        bool _judge;

        public bool Judge
        {
            get { return _judge; }
            set { _judge = value; }
        }
        public void configUI(int type){
            List = GetDictionaryMX(type);
            
            contentlistBox.DataSource = List;
            contentlistBox.DisplayMember = "MXNAME";
            contentlistBox.ValueMember = "ID";
            contentlistBox.ClearSelected();

            contentlistBox.SelectedIndexChanged += new EventHandler(contentlistBox_SelectedValueChanged);

            Index = 0;
        }
        private void tjbutton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(contenttextBox.Text.Trim()))
            {
                ShowMeg(q(Msg_Type.msgaddcontentnoempty));//"新增内容不能为空"
                return;
            }
            MES_SY_TYPEMX model = new MES_SY_TYPEMX();
            model.TYPEID = TypeID;
            model.GC = getGC("value");
            model.MXNAME = contenttextBox.Text.Trim();
            MES_RETURN_UI res = ServicModel.SY_TYPEMX.INSERT(model, getToken());
            if (res.TYPE.Equals("S"))
            {
                configUI(TypeID);
                if (MessageBox.Show(q(Msg_Type.msginsertsuccess),q(Msg_Type.msgtitle), MessageBoxButtons.OK) == DialogResult.OK)//"新增成功", "消息框"
                {
                    contenttextBox.Clear();                   
                }
                
            }
            else
            {
                ShowMeg(res.MESSAGE);
            }
        }
      
        private void shbutton_Click(object sender, EventArgs e)
        {
           MES_RETURN_UI res  = ServicModel.SY_TYPEMX.DELETE(List[Index].ID, getToken());
             if (res.TYPE.Equals("S"))
            {
                configUI(TypeID);
                if (MessageBox.Show(q(Msg_Type.msgdelsuccess),q(Msg_Type.msgtitle), MessageBoxButtons.OK) == DialogResult.OK)//"删除成功", "消息框"
                {
                    contenttextBox.Clear();                   
                }
                
            }
            else
            {
                ShowMeg(res.MESSAGE);
            }

        }

        private void contentlistBox_SelectedValueChanged(object sender, EventArgs e)
        {

            Index = contentlistBox.SelectedIndex;
            //if (Index >= 0)
            //{
            //    contenttextBox.Text = List[Index].MXNAME;
            //}
            
        }

        private void frmModifyMX_Shown(object sender, EventArgs e)
        {
            configUI(TypeID);
        }
    }
}
