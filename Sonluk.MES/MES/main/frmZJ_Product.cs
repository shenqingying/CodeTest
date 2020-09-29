using Sonluk.MES.MES.Base;
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
    public partial class frmZJ_Product : basefrm
    {
        public frmZJ_Product()
        {
            int margin = 15;
            int h = 21;

            InitializeComponent();
            #region UI

            //SMtextBox.Location = new Point(10,  24);
            //SMtextBox.Size = new Size(rect.Width * 6 / 10, 40);
            //SMtextBox.Font = new Font(q(Msg_Type.fonttype), 18);
            factory.configText(SMtextBox, new Size(rect.Width * 6 / 10, 40),new Point(10,24), new Font(q(Msg_Type.fonttype), 18), "");
            
            for (int i = 0; i < 20; i++)
            {
                Button btn = new Button();
                this.factory.configButton(btn, new Size(60, 60), new Point(20 + rect.Width / 12 * (i % 12), 75 + i / 12 * 75), (i + 1).ToString() + "#", (i + 1) * 10);
                //btn.Tag = (i + 1) * 10;
                //btn.UseVisualStyleBackColor = true;
                btn.Click += new System.EventHandler(this.btn_Click);              
                this.Controls.Add(btn);
                if (i == 0)
                {
                    btn_Click(btn, new EventArgs());

                }
            }
            //车号
            //chlabel.Location = new Point(50, 75 * 2 + 60 + 24 + 5 + 50);
            //chlabel.Size = new Size(rect.Width / 2 - 20, h);
            //chlabel.Font = new Font(q(Msg_Type.fonttype), 16);
            //chlabel.Text = "车号: 1#";

            factory.configLabel(chlabel, new Size(rect.Width / 2 - 20, h), new Point(50, 75 * 2 + 60 + 24 + 5 + 50), "车号: 1#");
            //今日累计桶数
            //jrljtslabel.Location = new Point(rect.Width / 2, chlabel.Location.Y);
            //jrljtslabel.Size = new Size(rect.Width / 2 - 20, h);
            //jrljtslabel.Font = new Font(q(Msg_Type.fonttype), 16);
            //jrljtslabel.Text = "今日累计桶数(桶):";

            factory.configLabel(jrljtslabel, new Size(rect.Width / 2 - 20, h), new Point(rect.Width / 2, chlabel.Location.Y), "今日累计桶数(桶):");
            //配方单号
            //pfdhlabel.Location = new Point(chlabel.Bounds.X, jrljtslabel.Bounds.Y + margin + h);
            //pfdhlabel.Size = new Size(100, h);
            //pfdhlabel.Text = "配方单号:";
            //pfdhlabel.Font = new Font(q(Msg_Type.fonttype), 16);

            factory.configLabel(pfdhlabel, new Size(100, h), new Point(chlabel.Bounds.X, jrljtslabel.Bounds.Y + margin + h), "配方单号:");

            //pfdhcomboBox.Location = new Point(pfdhlabel.Bounds.X + 120, pfdhlabel.Bounds.Y);
            //pfdhcomboBox.Font = new Font(q(Msg_Type.fonttype), 16);
            factory.configCommbox(pfdhcomboBox, pfdhcomboBox.Size, new Point(pfdhlabel.Bounds.X + 120, pfdhlabel.Bounds.Y), new DataTable(), "", "");
            //工单
            //gdlabel.Text = "工单: ";
            //gdlabel.Size = new Size(rect.Width / 2 - 20, h);
            //gdlabel.Font = new Font(q(Msg_Type.fonttype), 16);
            //gdlabel.Location = new Point(jrljtslabel.Bounds.X, pfdhlabel.Bounds.Y);

            factory.configLabel(gdlabel, new Size(rect.Width / 2 - 20, h), new Point(jrljtslabel.Bounds.X, pfdhlabel.Bounds.Y), "工单: ");
            //配料单号
            //pldhlabel.Text = "配料单号: ";
            //pldhlabel.Size = new Size(pfdhlabel.Bounds.Width, pfdhlabel.Bounds.Height);
            //pldhlabel.Location = new Point(pfdhlabel.Bounds.X, pfdhlabel.Bounds.Y + h + margin);
            //pldhlabel.Font = new Font(q(Msg_Type.fonttype), 16);

            factory.configLabel(pldhlabel, new Size(pfdhlabel.Bounds.Width, pfdhlabel.Bounds.Height), new Point(pfdhlabel.Bounds.X, pfdhlabel.Bounds.Y + h + margin), "配料单号: ");

            //pldhcomboBox.Location = new Point(pfdhcomboBox.Bounds.X, pfdhlabel.Bounds.Y  + margin + h);
            //pldhcomboBox.Font = new Font(q(Msg_Type.fonttype), 16);

            factory.configCommbox(pldhcomboBox, pldhcomboBox.Size, new Point(pfdhcomboBox.Bounds.X, pfdhlabel.Bounds.Y + margin + h), new DataTable(), "", "");

            //pfdhljtslabel.Text = "配方单号累计桶数（桶）:";
            //pfdhljtslabel.Size = new Size(rect.Width / 2 - 20, h);
            //pfdhljtslabel.Font = new Font(q(Msg_Type.fonttype), 16);
            //pfdhljtslabel.Location = new Point(jrljtslabel.Bounds.X, pldhlabel.Bounds.Y);

            factory.configLabel(pfdhljtslabel, new Size(rect.Width / 2 - 20, h), new Point(jrljtslabel.Bounds.X, pldhlabel.Bounds.Y), "配方单号累计桶数（桶）:");

            //thlabel.Text = "桶号:";
            //thlabel.Font = new Font(q(Msg_Type.fonttype), 16);
            //thlabel.Size = new Size(chlabel.Bounds.Width, chlabel.Bounds.Height);
            //thlabel.Location = new Point(chlabel.Bounds.X, pldhlabel.Bounds.Y + margin + h);

            factory.configLabel(thlabel, new Size(chlabel.Bounds.Width, chlabel.Bounds.Height), new Point(chlabel.Bounds.X, pldhlabel.Bounds.Y + margin + h), "桶号:");
            //pldhljtslabel.Text = "配料单号累计桶数:";
            //pldhljtslabel.Font = new Font(q(Msg_Type.fonttype), 16);
            //pldhljtslabel.Size = new Size(jrljtslabel.Bounds.Width, jrljtslabel.Bounds.Height);
            //pldhljtslabel.Location = new Point(pfdhljtslabel.Bounds.X, pfdhljtslabel.Bounds.Y + margin + h);

            factory.configLabel(pldhljtslabel, new Size(jrljtslabel.Bounds.Width, jrljtslabel.Bounds.Height), new Point(pfdhljtslabel.Bounds.X, pfdhljtslabel.Bounds.Y + margin + h), "配料单号累计桶数:");

            //scbzlabel.Text = "生产班组:";
            //scbzlabel.Font = new Font(q(Msg_Type.fonttype), 16);
            //scbzlabel.Size = new Size(pfdhlabel.Width, pfdhlabel.Height);
            //scbzlabel.Location = new Point(thlabel.Bounds.X, thlabel.Bounds.Y + margin + h);

            factory.configLabel(scbzlabel, new Size(pfdhlabel.Width, pfdhlabel.Height), new Point(thlabel.Bounds.X, thlabel.Bounds.Y + margin + h), "生产班组:");

            //scbzcomboBox.Location = new Point(pfdhcomboBox.Bounds.X, scbzlabel.Bounds.Y);
            //scbzcomboBox.Font = new Font(q(Msg_Type.fonttype), 16);

            factory.configCommbox(scbzcomboBox, scbzcomboBox.Size, new Point(pfdhcomboBox.Bounds.X, scbzlabel.Bounds.Y), new DataTable(), "", "");

            //sllabel.Text = "数量:";
            //sllabel.Font = new Font(q(Msg_Type.fonttype), 16);
            //sllabel.Size = new Size(chlabel.Bounds.Width, chlabel.Bounds.Height);
            //sllabel.Location = new Point(scbzlabel.Bounds.X, scbzlabel.Bounds.Y + margin + h);

            factory.configLabel(sllabel, new Size(chlabel.Bounds.Width, chlabel.Bounds.Height), new Point(scbzlabel.Bounds.X, scbzlabel.Bounds.Y + margin + h), "数量:");

            //radioButton1.Location = new Point(sllabel.Bounds.X, sllabel.Bounds.Y + h + 100);
            //radioButton1.Font = new Font(q(Msg_Type.fonttype), 16);

            factory.configRadionButton(radioButton1, radioButton1.Size, new Point(sllabel.Bounds.X, sllabel.Bounds.Y + h + 100), "半桶");

            //radioButton2.Location = new Point(radioButton1.Bounds.X + radioButton1.Bounds.Width  + 60, sllabel.Bounds.Y + h + 100);
            //radioButton2.Font = new Font(q(Msg_Type.fonttype), 16);

            factory.configRadionButton(radioButton2, radioButton2.Size, new Point(radioButton1.Bounds.X + radioButton1.Bounds.Width + 60, sllabel.Bounds.Y + h + 100), "一桶");

            //dybutton.Location = new Point(radioButton1.Bounds.X, radioButton1.Bounds.Y + h + 50);
            //dybutton.Size = new Size(200, 60);
            //dybutton.Font = new Font(q(Msg_Type.fonttype), 16);
            //dybutton.Text = "打印";

            factory.configButton(dybutton, new Size(200, 60), new Point(radioButton1.Bounds.X, radioButton1.Bounds.Y + h + 50), "打印", null);

            #endregion
        }

        private void dybutton_Click(object sender, EventArgs e)
        {

        }
        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int index = Convert.ToInt32(btn.Tag);
            foreach (Control c in this.Controls)
            {
                if (c is Button)
                {
                    Button btn1 = (Button)c;
                    if (Convert.ToInt32(c.Tag) == index)
                    {
                        btn1.BackColor = Color.Red;
                    }
                    else
                    {
                        btn1.UseVisualStyleBackColor = true;
                    }

                }
                

            }
            chlabel.Text = "车号: " + btn.Text;  
        }
    }
}
