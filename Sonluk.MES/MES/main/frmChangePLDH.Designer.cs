namespace Sonluk.MES.MES.main
{
    partial class frmChangePLDH
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChangePLDH));
            this.label1 = new System.Windows.Forms.Label();
            this.pldataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pldataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // pldataGridView
            // 
            resources.ApplyResources(this.pldataGridView, "pldataGridView");
            this.pldataGridView.AllowUserToAddRows = false;
            this.pldataGridView.AllowUserToDeleteRows = false;
            this.pldataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(241)))), ((int)(((byte)(246)))));
            this.pldataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pldataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pldataGridView.Name = "pldataGridView";
            this.pldataGridView.ReadOnly = true;
            this.pldataGridView.RowTemplate.Height = 23;
            this.pldataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.pldataGridView_CellClick);
            // 
            // frmChangePLDH
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(209)))), ((int)(((byte)(223)))));
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pldataGridView);
            this.Name = "frmChangePLDH";
            this.Shown += new System.EventHandler(this.frmChangePLDH_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pldataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView pldataGridView;
        private System.Windows.Forms.Label label1;
    }
}