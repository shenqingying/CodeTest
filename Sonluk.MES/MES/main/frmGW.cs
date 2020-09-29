using Sonluk.MES.MES.Base;
using Sonluk.UI.Model.MES.SY_GZZXService;
using Sonluk.UI.Model.MES.TM_CZRService;
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
    public partial class frmGW : basefrm
    {
        MES_SY_GZZX_GW[] gwArr;

        public MES_SY_GZZX_GW[] GwArr
        {
            get { return gwArr; }
            set { gwArr = value; }
        }
        int ryID;

        public int RyID
        {
            get { return ryID; }
            set { ryID = value; }
        }
        public frmGW()
        {
            InitializeComponent();
        }
        public frmGW(MES_SY_GZZX_GW[] list, int ID)
        {
            InitializeComponent();
            //this.Height = 800;
            ryID = ID;

            //panel1.Location = new Point(100, 140);
            //panel1.Size = new Size(rect.Width - 200, rect.Height - 100);
            //panel1.AutoScroll = true;
            ////p1.BackColor = Color.Green;
            //for (int i = 0; i < list.Length; i++)
            //{
            //    Button btn = new Button();
            //    //factory.configButton(btn, new Size(100, 100), new Point(0 + rect.Width / 8 * (i % 8), 0 + i / 8 * 140), list[i].SBMS, (i + 1) * 10);
            //    btn.Size = new Size(100, 100);
            //    btn.Location = new Point(0 + rect.Width / 4 * (i % 4), 0 + i / 4 * 140);
            //    btn.Text = list[i].SBMS;
            //    btn.Font = new System.Drawing.Font(q(Msg_Type.fonttype), 13);
            //    btn.Tag = list[i].SBBH;
            //    btn.Click += new System.EventHandler(this.btn_Click);

            //    if (i == list.Length - 1)
            //    {
            //        Panel p2 = new Panel();
            //        p2.Size = new Size(100, 100);
            //        p2.Location = new Point(0, i / 4 * 140 + 200);
            //        panel1.Controls.Add(p2);
            //    }
            //    panel1.Controls.Add(btn);
            //}



            for (int i = 0; i < list.Length; i++)
            {

                Button btn = new Button();
                factory.configButton(btn, new Size(130, 60), new Point(30 + 800 / 4 * (i % 4), 20 + i / 4 * 80), list[i].MXNAME,list[i].ID);
                btn.FlatStyle = FlatStyle.Popup;
                btn.Click += new System.EventHandler(this.btn_Click);

                //this.Controls.Add(btn);
                panel1.Controls.Add(btn);
            }
        }
        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            MES_TM_CZR node = new MES_TM_CZR();
            node.ID = ryID;
            node.GWID = Convert.ToInt32(btn.Tag);
            Sonluk.UI.Model.MES.TM_CZRService.MES_RETURN returns = ServicModel.TM_CZR.UPDATE_GW(node, getToken());
            if (returns.TYPE.Equals("S"))
            {
                
                if (MessageBox.Show( q(Msg_Type.msgxgcg), q(Msg_Type.msgtitle), MessageBoxButtons.OK) == DialogResult.OK)//"修改成功"
                {
                    this.Close();
                }
            }
        }
    }
}
