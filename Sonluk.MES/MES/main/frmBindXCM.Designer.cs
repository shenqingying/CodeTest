namespace Sonluk.MES.MES.main
{
    partial class frmBindXCM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBindXCM));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.BomdataGridView = new System.Windows.Forms.DataGridView();
            this.ZEILE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WERKS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MATNR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHARG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WLDL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.状态 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SMtextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.wlpzlabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gyslabel = new System.Windows.Forms.Label();
            this.wlxxlabel = new System.Windows.Forms.Label();
            this.cglabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.XH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WLXX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WLLB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.删除 = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.BomdataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BomdataGridView
            // 
            resources.ApplyResources(this.BomdataGridView, "BomdataGridView");
            this.BomdataGridView.AllowUserToAddRows = false;
            this.BomdataGridView.AllowUserToDeleteRows = false;
            this.BomdataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(241)))), ((int)(((byte)(246)))));
            this.BomdataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.BomdataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.BomdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BomdataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ZEILE,
            this.WERKS,
            this.MATNR,
            this.CHARG,
            this.WLDL,
            this.状态});
            this.BomdataGridView.Name = "BomdataGridView";
            this.BomdataGridView.ReadOnly = true;
            this.BomdataGridView.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 11F);
            this.BomdataGridView.RowTemplate.Height = 35;
            // 
            // ZEILE
            // 
            this.ZEILE.DataPropertyName = "ZEILE";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ZEILE.DefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.ZEILE, "ZEILE");
            this.ZEILE.Name = "ZEILE";
            this.ZEILE.ReadOnly = true;
            this.ZEILE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // WERKS
            // 
            this.WERKS.DataPropertyName = "WERKS";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.WERKS.DefaultCellStyle = dataGridViewCellStyle3;
            resources.ApplyResources(this.WERKS, "WERKS");
            this.WERKS.Name = "WERKS";
            this.WERKS.ReadOnly = true;
            this.WERKS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // MATNR
            // 
            this.MATNR.DataPropertyName = "MATNR";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MATNR.DefaultCellStyle = dataGridViewCellStyle4;
            resources.ApplyResources(this.MATNR, "MATNR");
            this.MATNR.Name = "MATNR";
            this.MATNR.ReadOnly = true;
            this.MATNR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CHARG
            // 
            this.CHARG.DataPropertyName = "CHARG";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CHARG.DefaultCellStyle = dataGridViewCellStyle5;
            resources.ApplyResources(this.CHARG, "CHARG");
            this.CHARG.Name = "CHARG";
            this.CHARG.ReadOnly = true;
            this.CHARG.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // WLDL
            // 
            this.WLDL.DataPropertyName = "WLDL";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.WLDL.DefaultCellStyle = dataGridViewCellStyle6;
            resources.ApplyResources(this.WLDL, "WLDL");
            this.WLDL.Name = "WLDL";
            this.WLDL.ReadOnly = true;
            this.WLDL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 状态
            // 
            this.状态.DataPropertyName = "状态";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.状态.DefaultCellStyle = dataGridViewCellStyle7;
            resources.ApplyResources(this.状态, "状态");
            this.状态.Name = "状态";
            this.状态.ReadOnly = true;
            this.状态.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SMtextBox
            // 
            resources.ApplyResources(this.SMtextBox, "SMtextBox");
            this.SMtextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(241)))), ((int)(((byte)(246)))));
            this.SMtextBox.Name = "SMtextBox";
            this.SMtextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SMtextBox_KeyDown);
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.wlpzlabel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.gyslabel);
            this.groupBox1.Controls.Add(this.wlxxlabel);
            this.groupBox1.Controls.Add(this.cglabel);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // wlpzlabel
            // 
            resources.ApplyResources(this.wlpzlabel, "wlpzlabel");
            this.wlpzlabel.Name = "wlpzlabel";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // gyslabel
            // 
            resources.ApplyResources(this.gyslabel, "gyslabel");
            this.gyslabel.Name = "gyslabel";
            // 
            // wlxxlabel
            // 
            resources.ApplyResources(this.wlxxlabel, "wlxxlabel");
            this.wlxxlabel.Name = "wlxxlabel";
            // 
            // cglabel
            // 
            resources.ApplyResources(this.cglabel, "cglabel");
            this.cglabel.Name = "cglabel";
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.dataGridView2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // dataGridView2
            // 
            resources.ApplyResources(this.dataGridView2, "dataGridView2");
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(241)))), ((int)(((byte)(246)))));
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("微软雅黑", 9F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.XH,
            this.TM,
            this.WLXX,
            this.WLLB,
            this.删除});
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 11F);
            this.dataGridView2.RowTemplate.Height = 35;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // XH
            // 
            this.XH.DataPropertyName = "XH";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.XH.DefaultCellStyle = dataGridViewCellStyle9;
            resources.ApplyResources(this.XH, "XH");
            this.XH.Name = "XH";
            this.XH.ReadOnly = true;
            this.XH.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TM
            // 
            this.TM.DataPropertyName = "TM";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TM.DefaultCellStyle = dataGridViewCellStyle10;
            resources.ApplyResources(this.TM, "TM");
            this.TM.Name = "TM";
            this.TM.ReadOnly = true;
            this.TM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // WLXX
            // 
            this.WLXX.DataPropertyName = "WLMS";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.WLXX.DefaultCellStyle = dataGridViewCellStyle11;
            resources.ApplyResources(this.WLXX, "WLXX");
            this.WLXX.Name = "WLXX";
            this.WLXX.ReadOnly = true;
            this.WLXX.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // WLLB
            // 
            this.WLLB.DataPropertyName = "WLLBNAME";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.WLLB.DefaultCellStyle = dataGridViewCellStyle12;
            resources.ApplyResources(this.WLLB, "WLLB");
            this.WLLB.Name = "WLLB";
            this.WLLB.ReadOnly = true;
            this.WLLB.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 删除
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle13.NullValue = "Xóa";
            this.删除.DefaultCellStyle = dataGridViewCellStyle13;
            resources.ApplyResources(this.删除, "删除");
            this.删除.Name = "删除";
            this.删除.ReadOnly = true;
            this.删除.Text = "Delete";
            this.删除.UseColumnTextForButtonValue = true;
            // 
            // frmBindXCM
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(209)))), ((int)(((byte)(223)))));
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BomdataGridView);
            this.Controls.Add(this.SMtextBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.MaximizeBox = false;
            this.Name = "frmBindXCM";
            this.Shown += new System.EventHandler(this.frmBindXCM_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.BomdataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SMtextBox;
        private System.Windows.Forms.Label wlpzlabel;
        private System.Windows.Forms.Label gyslabel;
        private System.Windows.Forms.Label wlxxlabel;
        private System.Windows.Forms.Label cglabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView BomdataGridView;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ZEILE;
        private System.Windows.Forms.DataGridViewTextBoxColumn WERKS;
        private System.Windows.Forms.DataGridViewTextBoxColumn MATNR;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHARG;
        private System.Windows.Forms.DataGridViewTextBoxColumn WLDL;
        private System.Windows.Forms.DataGridViewTextBoxColumn 状态;
        private System.Windows.Forms.DataGridViewTextBoxColumn XH;
        private System.Windows.Forms.DataGridViewTextBoxColumn TM;
        private System.Windows.Forms.DataGridViewTextBoxColumn WLXX;
        private System.Windows.Forms.DataGridViewTextBoxColumn WLLB;
        private System.Windows.Forms.DataGridViewButtonColumn 删除;
    }
}