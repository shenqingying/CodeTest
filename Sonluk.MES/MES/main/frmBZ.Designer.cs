namespace Sonluk.MES.MES.main
{
    partial class frmBZ
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
            this.qhsbhbutton = new System.Windows.Forms.Button();
            this.qrccbutton = new System.Windows.Forms.Button();
            this.LSdataGridView = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.BOMdataGridView = new System.Windows.Forms.DataGridView();
            this.WLLBlabel1 = new System.Windows.Forms.Label();
            this.GDHlabel = new System.Windows.Forms.Label();
            this.WLXXlabel = new System.Windows.Forms.Label();
            this.MESlabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.ryglbutton = new System.Windows.Forms.Button();
            this.sbhtextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.czrytextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gctextBox = new System.Windows.Forms.TextBox();
            this.gzzxtextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SMtextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rwdlabel = new System.Windows.Forms.Label();
            this.tskclabel1 = new System.Windows.Forms.Label();
            this.tpmlabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.LSdataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BOMdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // zybutton
            // 
            this.zybutton.Location = new System.Drawing.Point(1255, 32);
            this.zybutton.Size = new System.Drawing.Size(144, 86);
            // 
            // qhsbhbutton
            // 
            this.qhsbhbutton.Font = new System.Drawing.Font(q(Msg_Type.fonttype), 13F);
            this.qhsbhbutton.Location = new System.Drawing.Point(989, 715);
            this.qhsbhbutton.Name = "qhsbhbutton";
            this.qhsbhbutton.Size = new System.Drawing.Size(150, 82);
            this.qhsbhbutton.TabIndex = 34;
            this.qhsbhbutton.Text = "设备号切换";
            this.qhsbhbutton.UseVisualStyleBackColor = true;
            this.qhsbhbutton.Click += new System.EventHandler(this.qhsbhbutton_Click);
            // 
            // qrccbutton
            // 
            this.qrccbutton.Font = new System.Drawing.Font(q(Msg_Type.fonttype), 13F);
            this.qrccbutton.Location = new System.Drawing.Point(222, 715);
            this.qrccbutton.Name = "qrccbutton";
            this.qrccbutton.Size = new System.Drawing.Size(150, 82);
            this.qrccbutton.TabIndex = 33;
            this.qrccbutton.Text = "确认关联";
            this.qrccbutton.UseVisualStyleBackColor = true;
            this.qrccbutton.Click += new System.EventHandler(this.dylotbutton_Click);
            // 
            // LSdataGridView
            // 
            this.LSdataGridView.AllowUserToAddRows = false;
            this.LSdataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LSdataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.LSdataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LSdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LSdataGridView.Location = new System.Drawing.Point(34, 520);
            this.LSdataGridView.Name = "LSdataGridView";
            this.LSdataGridView.RowTemplate.Height = 23;
            this.LSdataGridView.Size = new System.Drawing.Size(792, 150);
            this.LSdataGridView.TabIndex = 27;
            this.LSdataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.LSdataGridView_CellContentClick);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font(q(Msg_Type.fonttype), 13F);
            this.label10.Location = new System.Drawing.Point(31, 485);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 18);
            this.label10.TabIndex = 26;
            this.label10.Text = "投料信息:";
            // 
            // BOMdataGridView
            // 
            this.BOMdataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.BOMdataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.BOMdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BOMdataGridView.Location = new System.Drawing.Point(34, 359);
            this.BOMdataGridView.Name = "BOMdataGridView";
            this.BOMdataGridView.RowTemplate.Height = 23;
            this.BOMdataGridView.Size = new System.Drawing.Size(568, 107);
            this.BOMdataGridView.TabIndex = 25;
            // 
            // WLLBlabel1
            // 
            this.WLLBlabel1.AutoSize = true;
            this.WLLBlabel1.Font = new System.Drawing.Font(q(Msg_Type.fonttype), 13F);
            this.WLLBlabel1.Location = new System.Drawing.Point(592, 247);
            this.WLLBlabel1.Name = "WLLBlabel1";
            this.WLLBlabel1.Size = new System.Drawing.Size(89, 18);
            this.WLLBlabel1.TabIndex = 24;
            this.WLLBlabel1.Text = "物料类别:";
            // 
            // GDHlabel
            // 
            this.GDHlabel.AutoSize = true;
            this.GDHlabel.Font = new System.Drawing.Font(q(Msg_Type.fonttype), 13F);
            this.GDHlabel.Location = new System.Drawing.Point(31, 247);
            this.GDHlabel.Name = "GDHlabel";
            this.GDHlabel.Size = new System.Drawing.Size(71, 18);
            this.GDHlabel.TabIndex = 23;
            this.GDHlabel.Text = "工单号:";
            // 
            // WLXXlabel
            // 
            this.WLXXlabel.AutoSize = true;
            this.WLXXlabel.Font = new System.Drawing.Font(q(Msg_Type.fonttype), 13F);
            this.WLXXlabel.Location = new System.Drawing.Point(283, 247);
            this.WLXXlabel.Name = "WLXXlabel";
            this.WLXXlabel.Size = new System.Drawing.Size(89, 18);
            this.WLXXlabel.TabIndex = 22;
            this.WLXXlabel.Text = "物料信息:";
            // 
            // MESlabel
            // 
            this.MESlabel.AutoSize = true;
            this.MESlabel.Font = new System.Drawing.Font(q(Msg_Type.fonttype), 13F);
            this.MESlabel.Location = new System.Drawing.Point(283, 211);
            this.MESlabel.Name = "MESlabel";
            this.MESlabel.Size = new System.Drawing.Size(80, 18);
            this.MESlabel.TabIndex = 21;
            this.MESlabel.Text = "MES工单:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font(q(Msg_Type.fonttype), 13F);
            this.label9.Location = new System.Drawing.Point(31, 319);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(161, 18);
            this.label9.TabIndex = 20;
            this.label9.Text = "下层物料相关信息:";
            // 
            // ryglbutton
            // 
            this.ryglbutton.Font = new System.Drawing.Font(q(Msg_Type.fonttype), 13F);
            this.ryglbutton.Location = new System.Drawing.Point(1012, 97);
            this.ryglbutton.Name = "ryglbutton";
            this.ryglbutton.Size = new System.Drawing.Size(127, 73);
            this.ryglbutton.TabIndex = 19;
            this.ryglbutton.Text = "操作人员管理";
            this.ryglbutton.UseVisualStyleBackColor = true;
            this.ryglbutton.Click += new System.EventHandler(this.ryglbutton_Click);
            // 
            // sbhtextBox
            // 
            this.sbhtextBox.Font = new System.Drawing.Font(q(Msg_Type.fonttype), 13F);
            this.sbhtextBox.Location = new System.Drawing.Point(431, 143);
            this.sbhtextBox.Name = "sbhtextBox";
            this.sbhtextBox.ReadOnly = true;
            this.sbhtextBox.Size = new System.Drawing.Size(111, 27);
            this.sbhtextBox.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font(q(Msg_Type.fonttype), 13F);
            this.label4.Location = new System.Drawing.Point(336, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 18);
            this.label4.TabIndex = 11;
            this.label4.Text = "设备号:";
            // 
            // czrytextBox
            // 
            this.czrytextBox.Font = new System.Drawing.Font(q(Msg_Type.fonttype), 13F);
            this.czrytextBox.Location = new System.Drawing.Point(431, 97);
            this.czrytextBox.Name = "czrytextBox";
            this.czrytextBox.ReadOnly = true;
            this.czrytextBox.Size = new System.Drawing.Size(372, 27);
            this.czrytextBox.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font(q(Msg_Type.fonttype), 13F);
            this.label3.Location = new System.Drawing.Point(336, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "操作人员:";
            // 
            // gctextBox
            // 
            this.gctextBox.Font = new System.Drawing.Font(q(Msg_Type.fonttype), 13F);
            this.gctextBox.Location = new System.Drawing.Point(126, 143);
            this.gctextBox.Name = "gctextBox";
            this.gctextBox.ReadOnly = true;
            this.gctextBox.Size = new System.Drawing.Size(204, 27);
            this.gctextBox.TabIndex = 8;
            // 
            // gzzxtextBox
            // 
            this.gzzxtextBox.Font = new System.Drawing.Font(q(Msg_Type.fonttype), 13F);
            this.gzzxtextBox.Location = new System.Drawing.Point(126, 97);
            this.gzzxtextBox.Name = "gzzxtextBox";
            this.gzzxtextBox.ReadOnly = true;
            this.gzzxtextBox.Size = new System.Drawing.Size(204, 27);
            this.gzzxtextBox.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font(q(Msg_Type.fonttype), 13F);
            this.label6.Location = new System.Drawing.Point(31, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 18);
            this.label6.TabIndex = 6;
            this.label6.Text = "工厂:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font(q(Msg_Type.fonttype), 13F);
            this.label2.Location = new System.Drawing.Point(31, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "工作中心:";
            // 
            // SMtextBox
            // 
            this.SMtextBox.Font = new System.Drawing.Font(q(Msg_Type.fonttype), 24F);
            this.SMtextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.SMtextBox.Location = new System.Drawing.Point(210, 32);
            this.SMtextBox.Name = "SMtextBox";
            this.SMtextBox.Size = new System.Drawing.Size(929, 44);
            this.SMtextBox.TabIndex = 1;
            this.SMtextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SMtextBox_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font(q(Msg_Type.fonttype), 30F);
            this.label1.Location = new System.Drawing.Point(27, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "投料主页";
            // 
            // rwdlabel
            // 
            this.rwdlabel.AutoSize = true;
            this.rwdlabel.Font = new System.Drawing.Font(q(Msg_Type.fonttype), 13F);
            this.rwdlabel.Location = new System.Drawing.Point(31, 211);
            this.rwdlabel.Name = "rwdlabel";
            this.rwdlabel.Size = new System.Drawing.Size(71, 18);
            this.rwdlabel.TabIndex = 35;
            this.rwdlabel.Text = "任务单:";
            // 
            // tskclabel1
            // 
            this.tskclabel1.AutoSize = true;
            this.tskclabel1.Font = new System.Drawing.Font(q(Msg_Type.fonttype), 13F);
            this.tskclabel1.Location = new System.Drawing.Point(283, 280);
            this.tskclabel1.Name = "tskclabel1";
            this.tskclabel1.Size = new System.Drawing.Size(89, 18);
            this.tskclabel1.TabIndex = 36;
            this.tskclabel1.Text = "特殊库存:";
            // 
            // tpmlabel
            // 
            this.tpmlabel.AutoSize = true;
            this.tpmlabel.Font = new System.Drawing.Font(q(Msg_Type.fonttype), 13F);
            this.tpmlabel.Location = new System.Drawing.Point(31, 280);
            this.tpmlabel.Name = "tpmlabel";
            this.tpmlabel.Size = new System.Drawing.Size(71, 18);
            this.tpmlabel.TabIndex = 37;
            this.tpmlabel.Text = "托盘码:";
            // 
            // frmBZ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 694);
            this.Controls.Add(this.tpmlabel);
            this.Controls.Add(this.tskclabel1);
            this.Controls.Add(this.rwdlabel);
            this.Controls.Add(this.qhsbhbutton);
            this.Controls.Add(this.qrccbutton);
            this.Controls.Add(this.LSdataGridView);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.BOMdataGridView);
            this.Controls.Add(this.WLLBlabel1);
            this.Controls.Add(this.GDHlabel);
            this.Controls.Add(this.WLXXlabel);
            this.Controls.Add(this.MESlabel);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.ryglbutton);
            this.Controls.Add(this.sbhtextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.czrytextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gctextBox);
            this.Controls.Add(this.gzzxtextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SMtextBox);
            this.Controls.Add(this.label1);
            this.Name = "frmBZ";
            this.Text = "投料主页";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTL2_Load);
            this.Shown += new System.EventHandler(this.frmTL2_Shown);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.SMtextBox, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.gzzxtextBox, 0);
            this.Controls.SetChildIndex(this.gctextBox, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.czrytextBox, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.sbhtextBox, 0);
            this.Controls.SetChildIndex(this.ryglbutton, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.MESlabel, 0);
            this.Controls.SetChildIndex(this.WLXXlabel, 0);
            this.Controls.SetChildIndex(this.GDHlabel, 0);
            this.Controls.SetChildIndex(this.WLLBlabel1, 0);
            this.Controls.SetChildIndex(this.BOMdataGridView, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.LSdataGridView, 0);
            this.Controls.SetChildIndex(this.qrccbutton, 0);
            this.Controls.SetChildIndex(this.qhsbhbutton, 0);
            this.Controls.SetChildIndex(this.rwdlabel, 0);
            this.Controls.SetChildIndex(this.tskclabel1, 0);
            this.Controls.SetChildIndex(this.tpmlabel, 0);
            this.Controls.SetChildIndex(this.zybutton, 0);
            ((System.ComponentModel.ISupportInitialize)(this.LSdataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BOMdataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SMtextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox gzzxtextBox;
        private System.Windows.Forms.TextBox gctextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox czrytextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox sbhtextBox;
        private System.Windows.Forms.Button ryglbutton;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label MESlabel;
        private System.Windows.Forms.Label WLXXlabel;
        private System.Windows.Forms.Label GDHlabel;
        private System.Windows.Forms.Label WLLBlabel1;
        private System.Windows.Forms.DataGridView BOMdataGridView;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView LSdataGridView;
        private System.Windows.Forms.Button qrccbutton;
        private System.Windows.Forms.Button qhsbhbutton;
        private System.Windows.Forms.Label rwdlabel;
        private System.Windows.Forms.Label tskclabel1;
        private System.Windows.Forms.Label tpmlabel;
    }
}