namespace Sonluk.MES.MES.main
{
    partial class frmPrint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrint));
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.dybutton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.xstextBox = new System.Windows.Forms.TextBox();
            this.TMtextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CPZTcomboBox = new System.Windows.Forms.ComboBox();
            this.fsnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.rkbslabel = new System.Windows.Forms.Label();
            this.bztextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tstextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
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
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // dybutton
            // 
            this.dybutton.Location = new System.Drawing.Point(375, 292);
            this.dybutton.Name = "dybutton";
            this.dybutton.Size = new System.Drawing.Size(140, 40);
            this.dybutton.TabIndex = 3;
            this.dybutton.Text = "打印";
            this.dybutton.UseVisualStyleBackColor = true;
            this.dybutton.Click += new System.EventHandler(this.dybutton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font(q(Msg_Type.fonttype), 10F);
            this.label5.Location = new System.Drawing.Point(28, 196);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 14);
            this.label5.TabIndex = 10;
            this.label5.Text = "数  量:";
            // 
            // xstextBox
            // 
            this.xstextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(241)))), ((int)(((byte)(246)))));
            this.xstextBox.Font = new System.Drawing.Font(q(Msg_Type.fonttype), 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xstextBox.Location = new System.Drawing.Point(249, 190);
            this.xstextBox.Name = "xstextBox";
            this.xstextBox.Size = new System.Drawing.Size(88, 25);
            this.xstextBox.TabIndex = 17;
            this.xstextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.xstextBox_KeyPress);
            // 
            // TMtextBox
            // 
            this.TMtextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(241)))), ((int)(((byte)(246)))));
            this.TMtextBox.Font = new System.Drawing.Font(q(Msg_Type.fonttype), 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TMtextBox.Location = new System.Drawing.Point(31, 140);
            this.TMtextBox.Name = "TMtextBox";
            this.TMtextBox.Size = new System.Drawing.Size(484, 25);
            this.TMtextBox.TabIndex = 18;
            this.TMtextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TMtextBox_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font(q(Msg_Type.fonttype), 10F);
            this.label2.Location = new System.Drawing.Point(365, 196);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "份  数:";
            // 
            // CPZTcomboBox
            // 
            this.CPZTcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CPZTcomboBox.Font = new System.Drawing.Font(q(Msg_Type.fonttype), 13F);
            this.CPZTcomboBox.FormattingEnabled = true;
            this.CPZTcomboBox.Location = new System.Drawing.Point(78, 12);
            this.CPZTcomboBox.Name = "CPZTcomboBox";
            this.CPZTcomboBox.Size = new System.Drawing.Size(88, 25);
            this.CPZTcomboBox.TabIndex = 16;
            // 
            // fsnumericUpDown
            // 
            this.fsnumericUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(241)))), ((int)(((byte)(246)))));
            this.fsnumericUpDown.Font = new System.Drawing.Font(q(Msg_Type.fonttype), 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fsnumericUpDown.Location = new System.Drawing.Point(436, 190);
            this.fsnumericUpDown.Name = "fsnumericUpDown";
            this.fsnumericUpDown.Size = new System.Drawing.Size(79, 25);
            this.fsnumericUpDown.TabIndex = 2;
            this.fsnumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // rkbslabel
            // 
            this.rkbslabel.AutoSize = true;
            this.rkbslabel.Font = new System.Drawing.Font(q(Msg_Type.fonttype), 10F);
            this.rkbslabel.Location = new System.Drawing.Point(28, 106);
            this.rkbslabel.Name = "rkbslabel";
            this.rkbslabel.Size = new System.Drawing.Size(98, 14);
            this.rkbslabel.TabIndex = 7;
            this.rkbslabel.Text = "入库标识条码:";
            // 
            // bztextBox
            // 
            this.bztextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(241)))), ((int)(((byte)(246)))));
            this.bztextBox.Font = new System.Drawing.Font(q(Msg_Type.fonttype), 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bztextBox.Location = new System.Drawing.Point(87, 240);
            this.bztextBox.Name = "bztextBox";
            this.bztextBox.Size = new System.Drawing.Size(428, 25);
            this.bztextBox.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font(q(Msg_Type.fonttype), 18F);
            this.label1.Location = new System.Drawing.Point(231, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "条码打印";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font(q(Msg_Type.fonttype), 10F);
            this.label4.Location = new System.Drawing.Point(190, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 14);
            this.label4.TabIndex = 9;
            this.label4.Text = "箱  数:";
            // 
            // tstextBox
            // 
            this.tstextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(241)))), ((int)(((byte)(246)))));
            this.tstextBox.Font = new System.Drawing.Font(q(Msg_Type.fonttype), 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tstextBox.Location = new System.Drawing.Point(87, 190);
            this.tstextBox.Name = "tstextBox";
            this.tstextBox.Size = new System.Drawing.Size(88, 25);
            this.tstextBox.TabIndex = 13;
            this.tstextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tstextBox_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font(q(Msg_Type.fonttype), 10F);
            this.label6.Location = new System.Drawing.Point(28, 244);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 14);
            this.label6.TabIndex = 14;
            this.label6.Text = "备  注:";
            // 
            // frmPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(209)))), ((int)(((byte)(223)))));
            this.ClientSize = new System.Drawing.Size(547, 382);
            this.Controls.Add(this.dybutton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.xstextBox);
            this.Controls.Add(this.TMtextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CPZTcomboBox);
            this.Controls.Add(this.fsnumericUpDown);
            this.Controls.Add(this.rkbslabel);
            this.Controls.Add(this.bztextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tstextBox);
            this.Controls.Add(this.label6);
            this.MaximizeBox = false;
            this.Name = "frmPrint";
            this.Text = "条码打印";
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
        protected System.Windows.Forms.Label rkbslabel;
        protected System.Windows.Forms.Label label4;
        protected System.Windows.Forms.Label label5;
        protected System.Windows.Forms.TextBox tstextBox;
        protected System.ComponentModel.BackgroundWorker backgroundWorker1;
        protected System.Windows.Forms.Label label6;
        protected System.Windows.Forms.TextBox bztextBox;
        protected System.Windows.Forms.ComboBox CPZTcomboBox;
        protected System.Windows.Forms.TextBox xstextBox;
        protected System.Windows.Forms.TextBox TMtextBox;
    }
}