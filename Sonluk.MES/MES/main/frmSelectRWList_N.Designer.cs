namespace Sonluk.MES.MES.main
{
    partial class frmSelectRWList_N
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectRWList_N));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.ListdataGridView = new System.Windows.Forms.DataGridView();
            this.TH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PFDH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PLDH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.XFCDNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.XFPC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STATUS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ListdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // ListdataGridView
            // 
            this.ListdataGridView.AllowUserToAddRows = false;
            this.ListdataGridView.AllowUserToDeleteRows = false;
            resources.ApplyResources(this.ListdataGridView, "ListdataGridView");
            this.ListdataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(241)))), ((int)(((byte)(246)))));
            this.ListdataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ListdataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ListdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListdataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TH,
            this.PFDH,
            this.PLDH,
            this.XFCDNAME,
            this.XFPC,
            this.STATUS,
            this.btn});
            this.ListdataGridView.Name = "ListdataGridView";
            this.ListdataGridView.ReadOnly = true;
            this.ListdataGridView.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ListdataGridView.RowTemplate.Height = 35;
            this.ListdataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ListdataGridView_CellContentClick);
            // 
            // TH
            // 
            this.TH.DataPropertyName = "TH";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TH.DefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.TH, "TH");
            this.TH.Name = "TH";
            this.TH.ReadOnly = true;
            this.TH.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PFDH
            // 
            this.PFDH.DataPropertyName = "PFDH";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PFDH.DefaultCellStyle = dataGridViewCellStyle3;
            resources.ApplyResources(this.PFDH, "PFDH");
            this.PFDH.Name = "PFDH";
            this.PFDH.ReadOnly = true;
            this.PFDH.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PLDH
            // 
            this.PLDH.DataPropertyName = "PLDH";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.PLDH.DefaultCellStyle = dataGridViewCellStyle4;
            resources.ApplyResources(this.PLDH, "PLDH");
            this.PLDH.Name = "PLDH";
            this.PLDH.ReadOnly = true;
            this.PLDH.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // XFCDNAME
            // 
            this.XFCDNAME.DataPropertyName = "XFCDNAME";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.XFCDNAME.DefaultCellStyle = dataGridViewCellStyle5;
            resources.ApplyResources(this.XFCDNAME, "XFCDNAME");
            this.XFCDNAME.Name = "XFCDNAME";
            this.XFCDNAME.ReadOnly = true;
            this.XFCDNAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // XFPC
            // 
            this.XFPC.DataPropertyName = "XFPC";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.XFPC.DefaultCellStyle = dataGridViewCellStyle6;
            resources.ApplyResources(this.XFPC, "XFPC");
            this.XFPC.Name = "XFPC";
            this.XFPC.ReadOnly = true;
            this.XFPC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // STATUS
            // 
            this.STATUS.DataPropertyName = "STATUS";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.STATUS.DefaultCellStyle = dataGridViewCellStyle7;
            resources.ApplyResources(this.STATUS, "STATUS");
            this.STATUS.Name = "STATUS";
            this.STATUS.ReadOnly = true;
            this.STATUS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // btn
            // 
            resources.ApplyResources(this.btn, "btn");
            this.btn.Name = "btn";
            this.btn.ReadOnly = true;
            this.btn.Text = "Print";
            this.btn.UseColumnTextForButtonValue = true;
            // 
            // frmSelectRWList_N
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(209)))), ((int)(((byte)(223)))));
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ListdataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmSelectRWList_N";
            this.Shown += new System.EventHandler(this.frmSelectRWList_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.ListdataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ListdataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TH;
        private System.Windows.Forms.DataGridViewTextBoxColumn PFDH;
        private System.Windows.Forms.DataGridViewTextBoxColumn PLDH;
        private System.Windows.Forms.DataGridViewTextBoxColumn XFCDNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn XFPC;
        private System.Windows.Forms.DataGridViewTextBoxColumn STATUS;
        private System.Windows.Forms.DataGridViewButtonColumn btn;
    }
}