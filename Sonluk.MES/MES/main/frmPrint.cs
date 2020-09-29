using Sonluk.MES.MES.Base;
using Sonluk.UI.Model.MES.TM_TMINFOService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using Sonluk.UI.Model.MES;


using System.IO;
using Sonluk.UI.Model.MES.SY_TYPEMXService;
using System.Runtime.InteropServices;
using Sonluk.MES.MES.publics;
namespace Sonluk.MES.MES.main
{
    public partial class frmPrint : basefrm
    {
        #region
       
       
        #endregion

        private const int rk_with = 210;
        private const int rk_height = 148;
         
        public frmPrint()
        {
            InitializeComponent();
        }
        public frmPrint(MES_TM_TMINFO_INSERT_GL model,Print_Type type,Rigth_Type rtype)
        {

            InitializeComponent();
            RigthType = rtype;
            MES_TM_TMINFO_INSERT_GL = model;
            //List<String> list = LocalPrinter.GetLocalPrinters(); //获得系统中的打印机列表
            //IList<comboxclass> cbnodes = new List<comboxclass>();
            rkbslabel.Visible = false;
            TMtextBox.Visible = false;
            //foreach (String s in list)
            //{
            //    //DYcomboBox.Items.Add(s); //将打印机名称添加到下拉框中
            //    comboxclass cb = new comboxclass();
            //    cb.Text = s;
            //    cb.Value = s;
            //    cbnodes.Add(cb);
            //}
            //DYcomboBox.DataSource = cbnodes.ToList();
            //DYcomboBox.ValueMember = "value";
            //DYcomboBox.DisplayMember = "text";
            CPZTcomboBox.Visible = false;
            label5.Text = "数量:";
            label4.Text = "箱数:";
            tstextBox.Visible = true;
           
            if (type == Print_Type.lot )
            {
                tstextBox.Visible = false;
                TMtextBox.Select();
                if (rtype == Rigth_Type.gangketl_cc)
                {
                    rkbslabel.Visible = true;
                    TMtextBox.Visible = true;
                    //tstextBox.Visible = false;
                }
                else
                {
                    int h = 70;
                    label5.Location = new Point(label5.Location.X, label5.Location.Y - h);
                    tstextBox.Location = new Point(tstextBox.Location.X, tstextBox.Location.Y - h);
                    label4.Location = new Point(label4.Location.X, label4.Location.Y - h);
                    xstextBox.Location = new Point(xstextBox.Location.X, xstextBox.Location.Y - h);
                    label2.Location = new Point(label2.Location.X, label2.Location.Y - h);
                    fsnumericUpDown.Location = new Point(fsnumericUpDown.Location.X, fsnumericUpDown.Location.Y - h);
                    label6.Location = new Point(label6.Location.X, label6.Location.Y - h);
                    bztextBox.Location = new Point(bztextBox.Location.X, bztextBox.Location.Y - h);
                    //dybutton.Location = new Point(dybutton.Location.X, dybutton.Location.Y - h);                   
                    
                }
                CPZTcomboBox.Location = tstextBox.Location;
               
               label5.Text = "状态:";
               label4.Text = "数量:";
               MES_SY_TYPEMX TYPEMX = new MES_SY_TYPEMX();
               TYPEMX.TYPEID = 9;
               TYPEMX.GC = Convert.ToString(getGC("value"));
               CPZTcomboBox.DataSource =  ServicModel.SY_TYPEMX.SELECT( TYPEMX,getToken());
               CPZTcomboBox.Visible = true;
               CPZTcomboBox.DisplayMember = "MXNAME";
               CPZTcomboBox.ValueMember = "ID";
            }
            else if (type == Print_Type.rk)
            {
                tstextBox.Select();
                label5.Location = new Point(label5.Location.X, label5.Location.Y - 50);
                tstextBox.Location = new Point(tstextBox.Location.X, tstextBox.Location.Y - 50);
                label2.Location = new Point(label2.Location.X, label2.Location.Y - 50);
                label4.Location = new Point(label4.Location.X, label4.Location.Y - 50);
                xstextBox.Location = new Point(xstextBox.Location.X, xstextBox.Location.Y - 50);
                fsnumericUpDown.Location = new Point(fsnumericUpDown.Location.X, fsnumericUpDown.Location.Y - 50);
                
            }
            PrintType = type;
            RigthType = rtype;
            switch (type)
            {
                case Print_Type.rk:
                    this.Text = "打印入库标识";
                    break;
                case Print_Type.lot:
                    this.Text = "打印LOT";
                    break;
                default:
                    break;
            }
            
            MES_TM_TMINFO_INSERT_GL = model;

            //int width = printDialog1.PrinterSettings.DefaultPageSettings.PaperSize.Width;
            
        }




        public delegate void Block();
        public Block block;
        private void dybutton_Click(object sender, EventArgs e)
        {
            dybutton.Focus();
            bool mgs1 = Verify();
            if (mgs1 == false)
            {
                return;
            }
            MsgReturn mgs = GetTM();
            if (mgs.Pass == false)
            {
                MessageBox.Show(mgs.Msg, "消息框");
                return;
            }
            PrintInfo(Convert.ToInt32(fsnumericUpDown.Value), xstextBox.Text.Trim(), tstextBox.Text.Trim(), PrintList, RigthType, PrintType);//PrintType
            if (block != null)
            {
                block();

            }
            this.Close();
        }

        private void previewbutton_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        private void fhbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();

            
        }
        private MsgReturn GetTM()
        {
            MsgReturn msg = new MsgReturn();
            msg.Pass = false;
            msg.Msg = "生成条码失败！！！";
            
           MES_TM_TMINFO_INSERT_RETURN res = new MES_TM_TMINFO_INSERT_RETURN();
            if (PrintType == Print_Type.lot)
            {
                if (RigthType == Rigth_Type.gangketl_cc)
                {
                    res = Createbarcode(Convert.ToInt32(fsnumericUpDown.Value));
                }
                else
                {
                    res = Createbarcode(1);
                }
                 
            }
            else
            {
                 res = Createbarcode(1);
            }
            if (res.MES_RETURN.TYPE.Equals("S"))
            {
                PrintList = res.SELECT_MES_TM_TMINFO_PRINT; 
                msg.Pass = true;
            }
            else
            {
                msg.Msg = res.MES_RETURN.MESSAGE;
            }
           

            return msg;
        }

        private MES_TM_TMINFO_INSERT_RETURN Createbarcode(int TMcount)
        {
            MES_TM_TMINFO_INSERT_GL.MES_TM_TMINFO.TMCOUNT = TMcount;
            MES_TM_TMINFO_INSERT_GL.MES_TM_TMINFO.REMARK = bztextBox.Text.Trim();
            MES_TM_TMINFO_INSERT_GL.MES_TM_TMINFO.MAC = DeviceInfo.GetNetCardMAC().Substring(0, 17);
            if (PrintType == Print_Type.lot)
            {
                MES_TM_TMINFO_INSERT_GL.MES_TM_TMINFO.CPZT = Convert.ToInt32(CPZTcomboBox.SelectedValue);
                MES_TM_TMINFO_INSERT_GL.MES_TM_TMINFO.TMSX = (int)Print_Type.lot;
                MES_TM_TMINFO_INSERT_GL.MES_TM_TMINFO.TMLB = 1;
                MES_TM_TMINFO_INSERT_GL.MES_TM_TMINFO.SL = Convert.ToDecimal(xstextBox.Text.Trim());
            }
            else
            {
                MES_TM_TMINFO_INSERT_GL.MES_TM_TMINFO.CPZT = 80;
                MES_TM_TMINFO_INSERT_GL.MES_TM_TMINFO.TMLB = 2;
                MES_TM_TMINFO_INSERT_GL.MES_TM_TMINFO.TMSX = (int)Print_Type.rk;
                MES_TM_TMINFO_INSERT_GL.MES_TM_TMINFO.SL = Convert.ToDecimal(tstextBox.Text.Trim());
            }
            
            
            MES_TM_TMINFO_INSERT_GL.MES_TM_TMINFO.UPPERTM = TMtextBox.Text.Trim().ToUpper();
            MES_TM_TMINFO_INSERT_GL.MES_TM_TMINFO.GC = getGC("value");
            MES_TM_TMINFO_INSERT_RETURN r = ServicModel.TM_TMINFO.INSERT(MES_TM_TMINFO_INSERT_GL,0, getToken());
            
            //SELECT_MES_TM_TMINFO_PRINT[] res = ServicModel.TM_TMINFO.INSERT(MES_TM_TMINFO_INSERT_GL, getToken());
            return r;
        }
        //public void PrintInfo()
        //{
        //    string dyjname = PrintPublic.DefaultPrinter();//Adobe PDF    \\192.168.0.135\HP 1108

        //    switch (PrintType)
        //    {
        //        case Print_Type.rk:
        //            //PrintPublic.SetDefaultPrinter(@"\\192.168.0.135\HP 1108");

        //            for (int j  = 0; j < Convert.ToInt32(fsnumericUpDown.Value); j++)
        //            {
        //                for (int i = 0; i < PrintList.Length; i++)
        //                {
        //                    PrintHead = PrintList[i].MES_TM_TMINFO_LIST;
        //                    PrintChild = PrintList[i].MES_TM_TMINFO_LIST_CHILD;
        //                    CzlList = PrintList[i].CZR;
        //                    printDocument1.Print();
                            
        //                }
        //            }
                   
        //            break;
        //        case Print_Type.lot:
        //            //SetDefaultPrinter(@"Adobe PDF");
        //            for (int i = 0; i < PrintList.Length; i++)
        //            {
        //                PrintHead = PrintList[i].MES_TM_TMINFO_LIST;
        //                PrintChild = PrintList[i].MES_TM_TMINFO_LIST_CHILD;
        //                CzlList = PrintList[i].CZR;
        //                printDocument1.Print();
        //            }
        //            break;
        //        default:
        //            break;
        //    }
           
           
        //}

        public class comboxclass
        {
            string _text;

            public string Text
            {
                get { return _text; }
                set { _text = value; }
            }
            string _value;

            public string Value
            {
                get { return _value; }
                set { _value = value; }
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            
           //switch (PrintType)
           // {
           //     case Print_Type.rk:
           //         DrawRK(e);
           //         break;
           //     case Print_Type.lot:
           //         DrawLot(e);
           //         break;
           //     default:
           //         break;
           // }
            
        }
        //private void DrawLot(PrintPageEventArgs e)
        //{
        //    Pen blackPen = new Pen(Color.Black, 1);
        //    Font font22 = new Font(q(Msg_Type.fonttype), 22);
        //    Font font14 = new Font(q(Msg_Type.fonttype), 14);
        //    Font font9 = new Font(q(Msg_Type.fonttype), 12);
        //    Font font7 = new Font(q(Msg_Type.fonttype), 10);
        //    Font font5 = new Font(q(Msg_Type.fonttype), 8);
        //    Brush bru = Brushes.Black;
        //    Graphics g = e.Graphics;//画布
        //    StringFormat strFormat = new StringFormat();
        //    strFormat.LineAlignment = StringAlignment.Center;//垂直居中
        //    strFormat.Alignment = StringAlignment.Center;//水平居中

        //    StringFormat strFormat1 = new StringFormat();
        //    strFormat.LineAlignment = StringAlignment.Center;//垂直居中
        //    strFormat.Alignment = StringAlignment.Center;//水平居中
        //    int width = 272;
        //    int xmargin = 5;
        //    int hrowmargin = 20;
        //    int rowmargin = 18;
        //    int grid = width / 2;
        //    int bzHeight = 11 * rowmargin + 20 + PrintChild.Length * 60;
        //    Rectangle recHead = new Rectangle(0, 10, width , hrowmargin);//矩形
        //    g.DrawString(PrintHead.GCDYMS, font14, bru, recHead, strFormat);
        //    g.DrawString("编号: JS4501A", font5, bru,0, hrowmargin + 12);
        //    g.DrawString("LOT表", font7, bru, 110, hrowmargin + 10);
        //    for (int i = 0; i < 10; i++)
        //    {
        //        g.DrawLine(blackPen, 0, rowmargin*(i+2) + 10, width , rowmargin*(i+2) + 10);
        //    }
        //    for (int i = 0; i < 3; i++)
        //    {
        //        if (i != 1)
        //        {
        //            g.DrawLine(blackPen, grid * i, rowmargin * 2 + 10, grid * i, bzHeight + 125);
        //        }
        //        else
        //        {
        //            g.DrawLine(blackPen, width / 4, rowmargin * 2 + 10, width / 4, rowmargin * 11 + 10);
        //        }
                
        //    }
        //    g.DrawLine(blackPen, 0, bzHeight + 125, width, bzHeight + 125);

        //    string[] contentArr = { "物料编码", PrintHead.WLH, "物料描述", PrintHead.WLMS, "工厂批次", PrintHead.PC, "生产日期", PrintHead.SCDATE + "/" + PrintHead.BCMS, "提供方", PrintHead.GZZXBH + "-" + PrintHead.GZZXMS, "设备号", PrintHead.SBHMS, "数量" + PrintHead.UNITSNAME, xstextBox.Text, "产品状态", PrintHead.CPZTNAME, "操作工", CzlList};

        //    for (int i = 0; i < contentArr.Length; i++)
        //    {
        //        int index = i % 2 == 0 ? 0 : 1;
        //        if (index == 0)
        //        {
        //            g.DrawString(contentArr[i], font7, bru, new Rectangle(width/4 * index, rowmargin * 2 + 12 + rowmargin * (i / 2), width/4*3, rowmargin), strFormat1);
        //        }
        //        else
        //        {
        //            g.DrawString(contentArr[i], font7, bru, new Rectangle(width/4 * index, rowmargin * 2 + 12 + rowmargin * (i / 2), width/4*3, rowmargin), strFormat1);
        //        }
               
        //    }

        //    for (int i = 0; i < PrintChild.Length; i++)
        //    {
        //        g.DrawString("下层码: " + PrintChild[i].TM, font5, bru, 5, 11 * rowmargin + 15 + 60 * i);
        //        g.DrawString("物料: " + PrintChild[i].WLH + "/" + PrintChild[i].WLMS, font5, bru, 5, 11 * rowmargin + 30 + 60 * i);
        //        if (string.IsNullOrEmpty(PrintChild[i].GYS) == true && string.IsNullOrEmpty(PrintChild[i].GYSMS) == true && string.IsNullOrEmpty(PrintChild[i].GYSPC) == true)
        //        {
        //            g.DrawString("供应商: ", font5, bru, 5, 11 * rowmargin + 45 + 60 * i);
        //        }
        //        else
        //        {
        //            g.DrawString("供应商: " + PrintChild[i].GYS + "-" + PrintChild[i].GYSMS + "/" + PrintChild[i].GYSPC, font5, bru, 5, 11 * rowmargin + 45 + 60 * i);
        //        }
        //        if (string.IsNullOrEmpty(PrintChild[i].SBHMS) == true && string.IsNullOrEmpty(PrintChild[i].CLCJ) == true && string.IsNullOrEmpty(PrintChild[i].GYSPC) == true)
        //        {
        //            g.DrawString("质量信息: ", font5, bru, 5, 11 * rowmargin + 60 + 60 * i);
        //        }
        //        else
        //        {
        //            g.DrawString("质量信息: " + PrintChild[i].SBHMS + "/" + PrintChild[i].CLCJ + "/" + PrintChild[i].GYSPC, font5, bru, 5, 11 * rowmargin + 60 + 60 * i);
        //        }

        //    }
            


        //    g.DrawString("备注:" + PrintHead.REMARK, font5, bru, 5, bzHeight);
        //    byte[] bytes = ServicModel.BarCode.CreateBarCode(PrintHead.TM, "QRCODE", 80, 80, 1);
        //    MemoryStream ms = new MemoryStream(bytes);
        //    Image returnImage = Image.FromStream(ms);

        //    g.DrawImage(returnImage, 10, bzHeight + 20, 80, 80);
        //    g.DrawString(PrintHead.TM, font7, bru, 10, bzHeight + 20 + 80);

        //    this.Close();

        //}
        //private void DrawRK(PrintPageEventArgs e)
        //{
           
        //    Pen blackPen = new Pen(Color.Black, 1);
        //    Font font22 = new Font(q(Msg_Type.fonttype), 22);
        //    Font font14 = new Font(q(Msg_Type.fonttype), 14);
        //    Font font9 = new Font(q(Msg_Type.fonttype), 12);
        //    Font font7 = new Font(q(Msg_Type.fonttype), 10);
        //     Font font5 = new Font(q(Msg_Type.fonttype), 5);
        //    Brush bru = Brushes.Black;
        //    Graphics g = e.Graphics;//画布
        //    StringFormat strFormat = new StringFormat();
        //    strFormat.LineAlignment = StringAlignment.Center;//垂直居中
        //    strFormat.Alignment = StringAlignment.Center;//水平居中
        //    StringFormat strFormat1 = new StringFormat();
        //    strFormat1.LineAlignment = StringAlignment.Center;//垂直居中
        //    strFormat1.Alignment = StringAlignment.Near;//水平居中
        //    g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;//抗锯齿           
        //    int width = printDialog1.PrinterSettings.DefaultPageSettings.PaperSize.Width;
        //    width = 827;
        //    int height = 565;
        //    int xmargin = 5;
        //    int rowmargin = 40;
        //    Rectangle recHead = new Rectangle(xmargin, 10, width - 10, rowmargin);//矩形
        //    Rectangle recHead1 = new Rectangle(xmargin, 10 + 25, width - 10, rowmargin);//矩形
        //    string a = PrintHead.GCDYMS;
            
        //    g.DrawString(PrintHead.GCDYMS, font22, bru, recHead, strFormat);
        //    g.DrawString("物料库存标识(自制)", font14, bru, recHead1, strFormat);
        //    for (int i = 0; i < 5; i++)
        //    {
        //        g.DrawLine(blackPen, 0, rowmargin + rowmargin * (i + 1), width - 28, rowmargin + rowmargin * (i + 1));
        //    }
        //    //for (int i = 0; i < 6; i++)
        //    //{
        //    //    g.DrawLine(blackPen, 0 + width / 6 * i,  rowmargin * (1 + 1), 0 + width / 6 * i,  rowmargin * (1 + 2));
        //    //}
        //    string[] contentArr = { "工厂", PrintHead.GC, "生产日期", PrintHead.SCDATE + "/" + PrintHead.BCMS, "状态", "合格", "物料编码", PrintHead.WLH, "物料描述", PrintHead.WLMS, "物料属性", PrintHead.PC, "该托数量/箱数",tstextBox.Text + PrintHead.UNITSNAME + "/" + xstextBox.Text + "箱" ,"参考信息",PrintHead.ERPNO + "/"  +  PrintHead.GZZXMS + "/" + PrintHead.SBHMS};



        //    int grid = width / 6;

        //    //g.DrawString("工厂", font9, bru, 2, 95);
        //    //g.DrawString(PrintHead.GCMS, font9, bru, 2 + width / 6, 95);
        //    //g.DrawString("生产日期", font9, bru, 2 + width / 6 * 2, 95);
        //    //g.DrawString(PrintHead.SCDATE + "/" + PrintHead.BCMS, font9,bru, 2 + width / 6 * 3, 95);
        //    //g.DrawString("状态", font9, bru, 2 + width / 6 * 4, 95);
        //    //g.DrawString("合格", font9, bru, 2 + width / 6 * 5, 95);
        //    //g.DrawString(contentArr[0], font9, bru, new Rectangle(0, rowmargin * 2, grid, rowmargin * 3), strFormat1);
        //    int rowmargin1 =10;
        //    int topheight = 80;
        //    //第一行
        //    for (int i = 0; i < 6; i++)
        //    {
        //        g.DrawString(contentArr[i], font9, bru, new Rectangle(grid * i,  43 + rowmargin, grid, rowmargin), strFormat1);
        //    }
        //    //第二行
        //    for (int i = 0; i < 3; i++)
        //    {
        //        g.DrawString(contentArr[6 + i], font9, bru, new Rectangle(grid * i,3+ rowmargin * 3, grid, rowmargin), strFormat1);
        //    }
        //    g.DrawString(contentArr[9], font9, bru, new Rectangle(grid * 3, 3 + rowmargin * 3, grid*3 , rowmargin), strFormat1);
        //    //第三行
        //    g.DrawString(contentArr[10], font9, bru, new Rectangle(0,3+ rowmargin * 4, grid, rowmargin), strFormat1);
        //    g.DrawString(contentArr[11], font9, bru, new Rectangle(grid, 3+ rowmargin * 4, grid * 3, rowmargin), strFormat1);
        //    g.DrawString(contentArr[12], font9, bru, new Rectangle(grid * 3,3+ rowmargin * 4, grid * 4, rowmargin), strFormat1);
        //    g.DrawString(contentArr[13], font9, bru, new Rectangle(grid * 4,3+  rowmargin * 4, grid * 6, rowmargin), strFormat1);
        //    //第四行
        //    g.DrawString(contentArr[14], font9, bru, new Rectangle(0, 40 + rowmargin * 4, grid, rowmargin), strFormat1);
        //    g.DrawString(contentArr[15], font9, bru, new Rectangle(grid, 40 + rowmargin * 4, grid*5 , rowmargin), strFormat1);

        //    g.DrawLine(blackPen, 0, 2 * rowmargin, 0, height );
        //    g.DrawLine(blackPen, width / 6, 2 * rowmargin, width / 6, rowmargin * 2 + rowmargin * 4);
        //    g.DrawLine(blackPen, width / 6 * 2, 2 * rowmargin, width / 6 * 2, rowmargin * 2 + rowmargin * 2);
        //    g.DrawLine(blackPen, width / 6 * 3, 2 * rowmargin, width / 6 * 3, rowmargin * 2 + rowmargin * 3);
        //    g.DrawLine(blackPen, width / 6 * 4, 2 * rowmargin, width / 6 * 4, 2 * rowmargin + rowmargin);
        //    g.DrawLine(blackPen, width / 6 * 4, 2 * rowmargin + 2 * rowmargin, width / 6 * 4, 2 * rowmargin + rowmargin * 3);
        //    g.DrawLine(blackPen, width / 6 * 5, 2 * rowmargin, width / 6 * 5, 2 * rowmargin + rowmargin);
        //    g.DrawLine(blackPen, width - 28, 2 * rowmargin, width - 28,  height);
        //    g.DrawLine(blackPen, 0, height , width - 28, height );

        //    byte[] bytes = ServicModel.BarCode.CreateBarCode(PrintHead.TM, "QRCODE",120, 120, 1);
        //    MemoryStream ms = new MemoryStream(bytes);
        //    Image returnImage = Image.FromStream(ms);

        //    g.DrawImage(returnImage, grid * 4, rowmargin * 6 + 20, 120,120);
        //    g.DrawString(PrintHead.TM, font9, bru, grid * 4 + 7, rowmargin * 6 + 20 + 120);
        //    for (int i = 0; i < PrintChild.Length; i++)
        //    {
        //        g.DrawString("下层码: " + PrintChild[i].TM, font7, bru, 5, 6 * rowmargin + 20 + 90*i);
        //        g.DrawString("物料: " + PrintChild[i].WLH + "/" + PrintChild[i].WLMS, font7, bru, 5, 6 * rowmargin + 40 + 90 * i);
        //        if (string.IsNullOrEmpty(PrintChild[i].GYS) == true && string.IsNullOrEmpty(PrintChild[i].GYSMS) == true && string.IsNullOrEmpty(PrintChild[i].GYSPC) == true)
        //        {
        //            g.DrawString("供应商: " , font7, bru, 5, 6 * rowmargin + 60 + 90 * i);
        //        }
        //        else
        //        {
        //            g.DrawString("供应商: " + PrintChild[i].GYS + "-" + PrintChild[i].GYSMS + "/" + PrintChild[i].GYSPC, font7, bru, 5, 6 * rowmargin + 60 + 90 * i);
        //        }
        //        if (string.IsNullOrEmpty(PrintChild[i].SBHMS) == true &&string.IsNullOrEmpty(PrintChild[i].CLCJ) == true&&string.IsNullOrEmpty(PrintChild[i].GYSPC) == true)
        //        {
        //            g.DrawString("质量信息: ", font7, bru, 5, 6 * rowmargin + 80 + 90 * i);    
        //        }
        //        else
        //        {
        //            g.DrawString("质量信息: " + PrintChild[i].SBHMS + "/" + PrintChild[i].CLCJ + "/" + PrintChild[i].GYSPC, font7, bru, 5, 6 * rowmargin + 80 + 90 * i);            
        //        }
                    
        //    }
        //    int bzHeight = 6 * rowmargin + 20 + PrintChild.Length * 90;
            

        //    g.DrawString("备注:" + PrintHead.REMARK, font7, bru, 5, bzHeight);





        //    this.Close();
        //    //物料库存标识(自制)
        //}

        private void xstextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            judge.isNum(xstextBox, e);

        }

        private void tstextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            judge.isNum(tstextBox, e);
        }


        private bool Verify()
        {
            bool judge = true;
            if (PrintType == Print_Type.rk )
            {
                if (string.IsNullOrEmpty(tstextBox.Text))
                {
                    MessageBox.Show("产出托数不能为空", "消息框");
                    tstextBox.Select();
                    return false;
                }
                if (string.IsNullOrEmpty(xstextBox.Text))
                {
                    MessageBox.Show("产出箱数不能为空", "消息框");
                    xstextBox.Select();
                    return false;;
                }
                if (string.IsNullOrEmpty(fsnumericUpDown.Value.ToString()))
                {
                    if (Convert.ToInt32(fsnumericUpDown.Value) == 0)
                    {
                        ShowMeg("打印分数必须大于0");
                        
                        fsnumericUpDown.Select();
                        return false;
                    }
                    MessageBox.Show("打印分数不能为空");
                    fsnumericUpDown.Select();
                    return false; ;
                }
            }
            else if (PrintType == Print_Type.lot)
            {
                if (RigthType == Rigth_Type.gangketl_cc)
                {
                    if (string.IsNullOrEmpty(TMtextBox.Text))
                    {
                        MessageBox.Show("必须扫描入库标识条码", "消息框");
                        TMtextBox.Select();
                        return false; ;
                    }
                }
               
                if (string.IsNullOrEmpty(xstextBox.Text))
                {
                    MessageBox.Show("产出数量不能为空", "消息框");
                    xstextBox.Select();
                    return false; ;
                }
                if (string.IsNullOrEmpty(fsnumericUpDown.Value.ToString()))
                {
                    if (Convert.ToInt32(fsnumericUpDown.Value) == 0)
                    {
                        ShowMeg("打印分数必须大于0");
                        fsnumericUpDown.Select();
                        return false;
                    }
                    MessageBox.Show("打印份数不能为空", "消息框");
                    fsnumericUpDown.Select();
                    return false; ;
                }
            }
            return judge;
        }

        private void TMtextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MES_TM_TMINFO model = new MES_TM_TMINFO();
                model.GC = MES_TM_TMINFO_INSERT_GL.MES_TM_TMINFO.GC;
                model.TM = TMtextBox.Text.Trim().ToUpper();
                SELECT_MES_TM_TMINFO_BYTM res = ServicModel.TM_TMINFO.SELECT_BYTM(model, 0, getToken());
                //MES_TM_TMINFO model = new MES_TM_TMINFO();
                //model.GC = MES_TM_TMINFO_INSERT_GL.MES_TM_TMINFO.GC;
                //model.TM = TMtextBox.Text.Trim().ToUpper();
                //model.RWBH = MES_TM_TMINFO_INSERT_GL.MES_TM_TMINFO.RWBH;
                //SELECT_MES_TM_TMINFO_BYTM res = ReadphTM(model, 2);
                if (res.MES_RETURN.TYPE.Equals("S"))
                {
                    if (res.MES_TM_TMINFO_LIST[0].TMLB != 2)
	                {
                        ShowMeg("请扫描领用表条码");
	                } 
                }
                else
                {
                    ShowMeg(res.MES_RETURN.MESSAGE);
                }

            }
        }
       


    }
   


    

}
