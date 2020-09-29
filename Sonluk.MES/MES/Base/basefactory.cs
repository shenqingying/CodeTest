using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sonluk.MES.MES.Base
{
    public class basefactory
    {
        Font defaultfont = new Font("宋体",16);
        Font tablefont = new Font("宋体", 9);
        public void configLabel(Label lb, Size size, Point point, string text)
        {
           
            this.configLabel(lb, size, point,defaultfont, text);
        }
        public void configLabel(Label lb, Size size, Point point, Font font, string text)
        {
            lb.Text = text;
            this.configControl(lb, size, point, font);
        }


        public void configButton(Button btn, Size size, Point point, string text,object tag)
        {
            this.configButton(btn, size, point,defaultfont, text,tag);
        }
        public void configButton(Button btn, Size size, Point point, Font font, string text,object tag)
        {
            if (tag != null) btn.Tag = tag;
            btn.Text = text;
            this.configControl(btn, size, point, font);
        }
        public void configRadionButton(RadioButton rbtn, Size size, Point point, string text)
        {
            
            this.configRadionButton(rbtn, size, point,defaultfont, text);
        }
        public void configRadionButton(RadioButton rbtn, Size size, Point point,Font font, string text)
        {
            rbtn.Text = text;
            this.configControl(rbtn,size,point,font);
        }
        public void configGridView(DataGridView dg, Size size, Point point, Font font,DataTable dt)
        {
            dg.DataSource = dt;
            this.configControl(dg, size, point, tablefont);
        }
        
        public void configText(TextBox tb, Size size, Point point,string text)
        {
            this.configText(tb, size, point, defaultfont,text);
        }
        public void configText(TextBox tb, Size size, Point point, Font font,string text)
        {

            this.configControl(tb, size, point, defaultfont);
            tb.Font = font;
            if (string.IsNullOrEmpty(text) == false) tb.Text = text;
         
        }


        public void configCommbox(ComboBox cb, Size size, Point point, object DataSource, string key, string value)
        {
            this.configCommbox(cb, size, point, defaultfont, DataSource, key, value);
        }
        public void configCommbox(ComboBox cb, Size size, Point point, Font font,object DataSource,string key,string value)
        {
            cb.DataSource = DataSource;
            cb.ValueMember = key;
            cb.DisplayMember = value;
            this.configControl(cb, size, point, font);
        }


        public  void configControl(Control ctr, Size size, Point point, Font font)
        {
            ctr.Size = size;
            ctr.Location = point;
            ctr.Font = font;
        }
        public void configControl(Control ctr, Size size, Point point)
        {
            //ctr.Font = new Font(q(Msg_Type.fonttype), 16);
            this.configControl(ctr, size, point, defaultfont);
        }
    }
}
