namespace Sonluk.MES.MES.main
{
    partial class frmSelectRWList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectRWList));
            this.label1 = new System.Windows.Forms.Label();
            this.ListdataGridView = new System.Windows.Forms.DataGridView();
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
            resources.ApplyResources(this.ListdataGridView, "ListdataGridView");
            this.ListdataGridView.AllowUserToAddRows = false;
            this.ListdataGridView.AllowUserToDeleteRows = false;
            this.ListdataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(241)))), ((int)(((byte)(246)))));
            this.ListdataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListdataGridView.Name = "ListdataGridView";
            this.ListdataGridView.ReadOnly = true;
            this.ListdataGridView.RowTemplate.Height = 23;
            // 
            // frmSelectRWList
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(209)))), ((int)(((byte)(223)))));
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ListdataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmSelectRWList";
            this.Shown += new System.EventHandler(this.frmSelectRWList_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.ListdataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ListdataGridView;
        private System.Windows.Forms.Label label1;
    }
}