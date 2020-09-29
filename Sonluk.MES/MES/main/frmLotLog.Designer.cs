namespace Sonluk.MES.MES.main
{
    partial class frmLotLog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLotLog));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.allradioButton2 = new System.Windows.Forms.RadioButton();
            this.rwdradioButton1 = new System.Windows.Forms.RadioButton();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.JLdataGridView = new System.Windows.Forms.DataGridView();
            this.cbox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.th = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.设备号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.生码时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.打印 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dybutton = new System.Windows.Forms.Button();
            this.fxbutton = new System.Windows.Forms.Button();
            this.qcbutton = new System.Windows.Forms.Button();
            this.qxbutton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.JLdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // allradioButton2
            // 
            resources.ApplyResources(this.allradioButton2, "allradioButton2");
            this.allradioButton2.Name = "allradioButton2";
            this.allradioButton2.TabStop = true;
            this.allradioButton2.UseVisualStyleBackColor = true;
            this.allradioButton2.CheckedChanged += new System.EventHandler(this.allradioButton2_CheckedChanged);
            this.allradioButton2.Click += new System.EventHandler(this.allradioButton2_Click);
            // 
            // rwdradioButton1
            // 
            resources.ApplyResources(this.rwdradioButton1, "rwdradioButton1");
            this.rwdradioButton1.Name = "rwdradioButton1";
            this.rwdradioButton1.TabStop = true;
            this.rwdradioButton1.UseVisualStyleBackColor = true;
            this.rwdradioButton1.Click += new System.EventHandler(this.rwdradioButton1_Click);
            // 
            // numericUpDown1
            // 
            resources.ApplyResources(this.numericUpDown1, "numericUpDown1");
            this.numericUpDown1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(241)))), ((int)(((byte)(246)))));
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // JLdataGridView
            // 
            resources.ApplyResources(this.JLdataGridView, "JLdataGridView");
            this.JLdataGridView.AllowUserToAddRows = false;
            this.JLdataGridView.AllowUserToOrderColumns = true;
            this.JLdataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(241)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.JLdataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.JLdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.JLdataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cbox,
            this.th,
            this.TM,
            this.设备号,
            this.生码时间,
            this.打印});
            this.JLdataGridView.Name = "JLdataGridView";
            this.JLdataGridView.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 11F);
            this.JLdataGridView.RowTemplate.Height = 35;
            this.JLdataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.JLdataGridView_CellClick);
            this.JLdataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.JLdataGridView_CellContentClick);
            // 
            // cbox
            // 
            this.cbox.DataPropertyName = "CBOX";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.NullValue = false;
            this.cbox.DefaultCellStyle = dataGridViewCellStyle2;
            this.cbox.Frozen = true;
            resources.ApplyResources(this.cbox, "cbox");
            this.cbox.Name = "cbox";
            // 
            // th
            // 
            this.th.DataPropertyName = "TH";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.th.DefaultCellStyle = dataGridViewCellStyle3;
            resources.ApplyResources(this.th, "th");
            this.th.Name = "th";
            this.th.ReadOnly = true;
            this.th.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TM
            // 
            this.TM.DataPropertyName = "TM";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TM.DefaultCellStyle = dataGridViewCellStyle4;
            resources.ApplyResources(this.TM, "TM");
            this.TM.Name = "TM";
            this.TM.ReadOnly = true;
            this.TM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 设备号
            // 
            this.设备号.DataPropertyName = "SBHMS";
            resources.ApplyResources(this.设备号, "设备号");
            this.设备号.Name = "设备号";
            this.设备号.ReadOnly = true;
            this.设备号.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 生码时间
            // 
            this.生码时间.DataPropertyName = "JLTIME";
            resources.ApplyResources(this.生码时间, "生码时间");
            this.生码时间.Name = "生码时间";
            this.生码时间.ReadOnly = true;
            this.生码时间.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 打印
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.NullValue = "Print";
            this.打印.DefaultCellStyle = dataGridViewCellStyle5;
            resources.ApplyResources(this.打印, "打印");
            this.打印.Name = "打印";
            // 
            // dybutton
            // 
            resources.ApplyResources(this.dybutton, "dybutton");
            this.dybutton.Name = "dybutton";
            this.dybutton.UseVisualStyleBackColor = true;
            this.dybutton.Click += new System.EventHandler(this.dybutton_Click);
            // 
            // fxbutton
            // 
            resources.ApplyResources(this.fxbutton, "fxbutton");
            this.fxbutton.Name = "fxbutton";
            this.fxbutton.UseVisualStyleBackColor = true;
            this.fxbutton.Click += new System.EventHandler(this.fxbutton_Click);
            // 
            // qcbutton
            // 
            resources.ApplyResources(this.qcbutton, "qcbutton");
            this.qcbutton.Name = "qcbutton";
            this.qcbutton.UseVisualStyleBackColor = true;
            this.qcbutton.Click += new System.EventHandler(this.qcbutton_Click);
            // 
            // qxbutton
            // 
            resources.ApplyResources(this.qxbutton, "qxbutton");
            this.qxbutton.Name = "qxbutton";
            this.qxbutton.UseVisualStyleBackColor = true;
            this.qxbutton.Click += new System.EventHandler(this.qxbutton_Click);
            // 
            // frmLotLog
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.allradioButton2);
            this.Controls.Add(this.rwdradioButton1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.JLdataGridView);
            this.Controls.Add(this.dybutton);
            this.Controls.Add(this.fxbutton);
            this.Controls.Add(this.qcbutton);
            this.Controls.Add(this.qxbutton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLotLog";
            this.Shown += new System.EventHandler(this.frmLotLog_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.JLdataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button dybutton;
        private System.Windows.Forms.Button fxbutton;
        private System.Windows.Forms.Button qcbutton;
        private System.Windows.Forms.Button qxbutton;
        private System.Windows.Forms.DataGridView JLdataGridView;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RadioButton rwdradioButton1;
        private System.Windows.Forms.RadioButton allradioButton2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cbox;
        private System.Windows.Forms.DataGridViewTextBoxColumn th;
        private System.Windows.Forms.DataGridViewTextBoxColumn TM;
        private System.Windows.Forms.DataGridViewTextBoxColumn 设备号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 生码时间;
        private System.Windows.Forms.DataGridViewButtonColumn 打印;
    }
}