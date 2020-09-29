namespace Sonluk.MES.MES.main
{
    partial class frmPrint_N
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrint_N));
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tmnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.dybutton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.xstextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.fsnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tstextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CPZTcomboBox = new System.Windows.Forms.ComboBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.qshtextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.tmnumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fsnumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // printPreviewDialog1
            // 
            resources.ApplyResources(this.printPreviewDialog1, "printPreviewDialog1");
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            // 
            // tmnumericUpDown
            // 
            resources.ApplyResources(this.tmnumericUpDown, "tmnumericUpDown");
            this.tmnumericUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(241)))), ((int)(((byte)(246)))));
            this.tmnumericUpDown.Name = "tmnumericUpDown";
            this.tmnumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tmnumericUpDown.Leave += new System.EventHandler(this.tmnumericUpDown_Leave);
            this.tmnumericUpDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tmnumericUpDown_MouseDown);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // dybutton
            // 
            resources.ApplyResources(this.dybutton, "dybutton");
            this.dybutton.Name = "dybutton";
            this.dybutton.UseVisualStyleBackColor = true;
            this.dybutton.Click += new System.EventHandler(this.dybutton_Click);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // xstextBox
            // 
            resources.ApplyResources(this.xstextBox, "xstextBox");
            this.xstextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(241)))), ((int)(((byte)(246)))));
            this.xstextBox.Name = "xstextBox";
            this.xstextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.xstextBox_KeyDown);
            this.xstextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.xstextBox_KeyPress);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // fsnumericUpDown
            // 
            resources.ApplyResources(this.fsnumericUpDown, "fsnumericUpDown");
            this.fsnumericUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(241)))), ((int)(((byte)(246)))));
            this.fsnumericUpDown.Name = "fsnumericUpDown";
            this.fsnumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.fsnumericUpDown.Leave += new System.EventHandler(this.fsnumericUpDown_Leave);
            this.fsnumericUpDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.fsnumericUpDown_MouseDown);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // tstextBox
            // 
            resources.ApplyResources(this.tstextBox, "tstextBox");
            this.tstextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(241)))), ((int)(((byte)(246)))));
            this.tstextBox.Name = "tstextBox";
            this.tstextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tstextBox_KeyPress);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // CPZTcomboBox
            // 
            resources.ApplyResources(this.CPZTcomboBox, "CPZTcomboBox");
            this.CPZTcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CPZTcomboBox.FormattingEnabled = true;
            this.CPZTcomboBox.Name = "CPZTcomboBox";
            // 
            // richTextBox1
            // 
            resources.ApplyResources(this.richTextBox1, "richTextBox1");
            this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(241)))), ((int)(((byte)(246)))));
            this.richTextBox1.Name = "richTextBox1";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // qshtextBox
            // 
            resources.ApplyResources(this.qshtextBox, "qshtextBox");
            this.qshtextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(241)))), ((int)(((byte)(246)))));
            this.qshtextBox.Name = "qshtextBox";
            this.qshtextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.qshtextBox_KeyPress);
            this.qshtextBox.Leave += new System.EventHandler(this.qshtextBox_Leave);
            this.qshtextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.qshtextBox_MouseDown);
            // 
            // frmPrint_N
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(209)))), ((int)(((byte)(223)))));
            this.Controls.Add(this.qshtextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.tmnumericUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dybutton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.xstextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CPZTcomboBox);
            this.Controls.Add(this.fsnumericUpDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tstextBox);
            this.Controls.Add(this.label6);
            this.MaximizeBox = false;
            this.Name = "frmPrint_N";
            ((System.ComponentModel.ISupportInitialize)(this.tmnumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fsnumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.NumericUpDown fsnumericUpDown;
        protected System.Windows.Forms.Button dybutton;
        protected System.Drawing.Printing.PrintDocument printDocument1;
        protected System.Windows.Forms.PrintDialog printDialog1;
        protected System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        protected System.Windows.Forms.Label label4;
        protected System.Windows.Forms.Label label5;
        protected System.Windows.Forms.TextBox tstextBox;
        protected System.ComponentModel.BackgroundWorker backgroundWorker1;
        protected System.Windows.Forms.Label label6;
        protected System.Windows.Forms.TextBox xstextBox;
        protected System.Windows.Forms.Label label3;
        protected System.Windows.Forms.NumericUpDown tmnumericUpDown;
        protected System.Windows.Forms.ComboBox CPZTcomboBox;
        private System.Windows.Forms.RichTextBox richTextBox1;
        protected System.Windows.Forms.Label label7;
        protected System.Windows.Forms.TextBox qshtextBox;
    }
}