using Sonluk.MES.MES.Base;
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
    public partial class frmZSLotSub : basefrm
    {
        private int type;
        public delegate void Block(string content);
        public Block block;
        public int _cave;
        public frmZSLotSub()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type">1:密封圈 无腔号    2:绝缘圈 颜色</param>
        public frmZSLotSub(int lx,string wjhStr,int cave)
        {
            InitializeComponent();
            type = lx;
            _cave = cave;
            configUI(wjhStr);
        }
        public void configUI(string wjhStr){
            if (type == 1)
            {
                this.Text = "无腔号选择";
                
                int magr = 5;
                int topmargin = 10;
                int btnheight = 60;
                int col = 8;
                int btnWidth = (this.Width - 14 * magr) / col ;
                
                for (int i = 0; i < _cave; i++)
                {
                    Button btn = new Button();
                    //magr + rect.Width / 4 * (i % 4)

                    factory.configButton(btn, new Size(btnWidth, btnheight), new Point(magr + (magr + btnWidth) * (i % col), topmargin + i / col * (btnheight + topmargin)), (i + 1) + "#", 0);
                    btn.FlatStyle = FlatStyle.Popup;
                    btn.Click += new System.EventHandler(this.btn_Click_type1);
                    //this.Controls.Add(btn);
                    panel1.Controls.Add(btn);
                    
                }
                if (!string.IsNullOrEmpty(wjhStr))
                {
                    string content = wjhStr.Substring(1, wjhStr.Length - 2);
                    string[] arr = content.Split(',');
                    for (int i = 0; i < arr.Length; i++)
                    {
                        foreach (Control c in panel1.Controls)
                        {
                            if (c is Button)
                            {
                                Button btn1 = (Button)c;
                                if (Convert.ToString(c.Text) == arr[i])
                                {                                   
                                        btn1.BackColor = Color.Red;
                                        btn1.ForeColor = Color.White;
                                        btn1.Tag = 1;
                                        break;
                                }


                            }


                        }
                    }
                    
                }
            }
            else
            {
                this.Text = "颜色选择";
                
                int topmargin = 50;
                int btnheight = 60;
                int col = 1;
                this.Width = 400;
                //int btnWidth = (this.Width - 6 * magr) / col;
                int btnWidth = 200;
                int magr = this.Width / 2 - btnWidth / 2;
                //string[] arr = new string[]{"红","绿","黑","蓝"};
                List<MES_SY_TYPEMXLIST> cpztlist = GetDictionaryMX(33).ToList();
                for (int i = 0; i < cpztlist.Count; i++)
                {
                    Button btn = new Button();
                    //magr + rect.Width / 4 * (i % 4)

                    factory.configButton(btn, new Size(btnWidth, btnheight), new Point(magr + (magr + btnWidth) * (i % col), topmargin + i / col * (btnheight + topmargin)), cpztlist[i].MXNAME, 0);
                    btn.FlatStyle = FlatStyle.Popup;
                    btn.Click += new System.EventHandler(this.btn_Click_type2);
                    
                    if (!string.IsNullOrEmpty(cpztlist[i].MXREMARK))
                    {
                        string[] strArr = cpztlist[i].MXREMARK.Split(',');
                        if (strArr.Length == 3)
                        {
                            try
                            {
                                int r = Convert.ToInt32(strArr[0]);
                                int g = Convert.ToInt32(strArr[1]);
                                int b = Convert.ToInt32(strArr[2]);
                                if (r >= 0 && r<=255 && g>= 0 && g<=255 && b >=0 && b<=255)
                                {
                                    btn.BackColor = Color.FromArgb(Convert.ToInt32(strArr[0]), Convert.ToInt32(strArr[1]), Convert.ToInt32(strArr[2]));
                                }
                                else
                                {
                                    btn_setstyle(btn, cpztlist[i].MXNAME);
                                }
                                
                            }
                            catch (Exception)
                            {
                                btn_setstyle(btn, cpztlist[i].MXNAME);
                               
                            }
                           
                        }
                        
                    }
                    else
                    {
                        btn_setstyle(btn, cpztlist[i].MXNAME);
                    }

                    //this.Controls.Add(btn);
                    panel1.Controls.Add(btn);

                }
                qrbutton.Visible = false;
                qxbutton2.Visible = false;
            }
           
        }
        public void btn_setstyle(Button btn,string text)
        {
            switch (text)
            {
                case "红":
                    btn.BackColor = Color.Red;
                    break;
                case "绿":
                    btn.BackColor = Color.Green;
                    break;
                case "黑":
                    btn.BackColor = Color.Black;
                    
                    break;
                default:
                    break;
            }
            btn.ForeColor = Color.White;
        }



        private void btn_Click_type1(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string mqh = Convert.ToString(btn.Text);
            foreach (Control c in panel1.Controls)
            {
                if (c is Button)
                {
                    Button btn1 = (Button)c;
                    if (Convert.ToString(c.Text) == mqh)
                    {
                        if (Convert.ToInt32(btn1.Tag) == 0)
                        {
                            btn1.BackColor = Color.Red;
                            btn1.ForeColor = Color.White;
                            btn1.Tag = 1;
                        }
                        else
                        {
                            btn1.UseVisualStyleBackColor = true;
                            btn1.ForeColor = Color.Black;
                            btn1.BackColor = Color.FromArgb(190, 209, 223);
                            btn1.Tag = 0;
                            
                        }
                        
                    }
                    else
                    {
                        btn1.UseVisualStyleBackColor = true;
                    }

                }


            }
        }
        private void btn_Click_type2(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (block != null)
            {
                block(btn.Text);
                this.Close();
            }
        }

        private void qrbutton_Click(object sender, EventArgs e)
        {
            string mqh = "";
            List<string> mqhlist = new List<string>();
            foreach (Control c in panel1.Controls)
            {
                
                if (c is Button)
                {
                    Button btn1 = (Button)c;
                    if (Convert.ToInt32(btn1.Tag) == 1)
                    {
                        mqhlist.Add(btn1.Text);
                    }

                }
            }
           
               
            for (int i = 0; i < mqhlist.Count; i++)
            {
                if (i == 0)
                {
                    if (mqhlist.Count == 1)
                    {
                        mqh = "[" + mqhlist[i] + "]";
                    }
                    else
                    {
                        mqh = "[" + mqhlist[i] + ",";
                    }
                    
                }
                else if (i == mqhlist.Count - 1)
                {                    
                    mqh += mqhlist[i] + "]";
                }
                else
                {
                    mqh += mqhlist[i] + ",";
                }
            }

            if (block != null)
            {
                block(mqh);
                this.Close();
            }
            //MessageBox.Show(mqh);


        }

        private void qxbutton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
