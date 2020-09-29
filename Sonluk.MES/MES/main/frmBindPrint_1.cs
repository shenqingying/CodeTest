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
    public partial class frmBindPrint_1 : basefrm
    {
        List<tableClass> _printTable;
        string _print;

        public string Print
        {
            get { return _print; }
            set { _print = value; }
        }

        public List<tableClass> PrintTable
        {
            get { return _printTable; }
            set { _printTable = value; }
        }

       
        public frmBindPrint_1()
        {
            InitializeComponent();
            MES_SY_TYPEMXLIST[] res = GetDictionaryMX(18);

            PrintTable = new List<tableClass>();
            for (int i = 0; i < res.Length; i++)
            {
                tableClass node = new tableClass();
                node.DYGS = res[i].MXNAME;
                node.XH = (i + 1).ToString();
                string key = "" ;
                if (res[i].ID == 418)
                {
                    key = "A5";
                }
                else if (res[i].ID == 419)
                {
                    key = "LOT";
                }

                node.PRINT = ini.IniReadValue(ini.Section_Print, key);
                PrintTable.Add(node);
            }
            dataGridView1.DataSource = PrintTable;
            dataGridView1.ClearSelection();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                int index = this.dataGridView1.CurrentRow.Index;
                tableClass node = PrintTable[index];
                string colname = this.dataGridView1.CurrentCell.OwningColumn.Name;
                if (colname.Equals("add"))
                {
                    string printStyle = "";
                    if (node.DYGS == "A5纸")//"A5纸"   q(Msg_Type.fieldA5paper)
                    {
                        printStyle = q(Msg_Type.fieldA5);//"A5";
                    }
                    else if (node.DYGS == "LOT表")//"LOT表"  q(Msg_Type.fieldLotB)
                    {
                        printStyle = q(Msg_Type.fieldLot);//"LOT";
                    }
                    frmPrintList f = new frmPrintList(index,printStyle);
                    f.block = bindprint;
                    show(f);
                }
                else if (colname.Equals("del"))
                {


                    if (MessageBox.Show(string.Format(q(Msg_Type.msgwhetherdeleteprint), node.DYGS), q(Msg_Type.msgtitle), MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        //"确认删除"+node.DYGS+"绑定的打印机吗？"
                        node.PRINT = "";
                        if (node.DYGS == "A5纸")//"A5纸"  q(Msg_Type.fieldA5paper)
                        {
                            ini.IniWriteValue(ini.Section_Print,"A5","");
                        }
                        else if (node.DYGS == "LOT表") //""  q(Msg_Type.fieldLotB)
                        {
                            ini.IniWriteValue(ini.Section_Print, "LOT", "");
                        }
                       
                        PrintTable.RemoveAt(index);
                        PrintTable.Insert(index, node);
                        dataGridView1.DataSource = new List<tableClass>();
                        dataGridView1.DataSource = PrintTable;
                        dataGridView1.ClearSelection();
                        //ShowMeg("删除绑定成功");
                    }
                    
                   

                }
                else if (colname.Equals("test"))
                {
                    if (!string.IsNullOrEmpty(node.PRINT))
                    {
                        if (node.DYGS == "A5纸")//"A5纸"  q(Msg_Type.fieldA5paper)
                        {
                            Print = q(Msg_Type.msgtestA5);//"A5纸打印测试";

                        }
                        else if (node.DYGS == "LOT表")//"LOT表"  q(Msg_Type.fieldLotB)
                        {
                            Print = q(Msg_Type.msgtestRM);//"热敏纸打印测试";
                        }
                        printDocument1.PrinterSettings.PrinterName = node.PRINT;
                        printDocument1.Print();
                    }
                    else
                    {
                        //ShowMeg(node.DYGS + q(Msg_Type.msgunbindprint));//"没有绑定打印机"
                        ShowMeg(q(Msg_Type.msgunbindprint));
                    }
                }
                
            }
        }
        public void bindprint()
        {
            MES_SY_TYPEMXLIST[] res = GetDictionaryMX(18);

            PrintTable = new List<tableClass>();
            for (int i = 0; i < res.Length; i++)
            {
                tableClass node = new tableClass();
                node.DYGS = res[i].MXNAME;
                node.XH = (i + 1).ToString();
                string key = "";
                if (res[i].ID == 418)
                {
                    key = "A5";
                }
                else if (res[i].ID == 419)
                {
                    key = "LOT";
                }

                node.PRINT = ini.IniReadValue(ini.Section_Print, key);
                PrintTable.Add(node);
            }
            dataGridView1.DataSource = PrintTable;
            dataGridView1.ClearSelection();
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font font = new Font(q(Msg_Type.fonttype), 25);
            Brush bru = Brushes.Blue;
            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Center;//垂直居中
            format.Alignment = StringAlignment.Center;//水平居中
            if (Print.Equals(q(Msg_Type.msgtestA5)))//"A5纸打印测试"
            {
                e.Graphics.DrawString(Print, font, bru, new Rectangle(0, 20, 827, 40), format);
            }
            else if (Print.Equals(q(Msg_Type.msgtestRM)))//"热敏纸打印测试"
            {
                e.Graphics.DrawString(Print, font, bru, new Rectangle(0, 0, 272, 600), format);

            }
        }

        private void frmBindPrint_1_Shown(object sender, EventArgs e)
        {
            //dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }


        
    }
    public class tableClass
    {
        string _XH;

        public string XH
        {
            get { return _XH; }
            set { _XH = value; }
        }
        string _DYGS;

        public string DYGS
        {
            get { return _DYGS; }
            set { _DYGS = value; }
        }
        string _PRINT;

        public string PRINT
        {
            get { return _PRINT; }
            set { _PRINT = value; }
        }
    }

}
