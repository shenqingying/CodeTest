namespace Sonluk.MES.MES.main
{
    partial class frmManagerRY
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManagerRY));
            this.RYdataGridView = new System.Windows.Forms.DataGridView();
            this.SMtextBox = new System.Windows.Forms.TextBox();
            this.TTlabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.RYdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // RYdataGridView
            // 
            resources.ApplyResources(this.RYdataGridView, "RYdataGridView");
            this.RYdataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(241)))), ((int)(((byte)(246)))));
            this.RYdataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RYdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RYdataGridView.Name = "RYdataGridView";
            this.RYdataGridView.RowTemplate.Height = 23;
            this.RYdataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RYdataGridView_CellContentClick);
            this.RYdataGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.RYdataGridView_EditingControlShowing);
            // 
            // SMtextBox
            // 
            resources.ApplyResources(this.SMtextBox, "SMtextBox");
            this.SMtextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(241)))), ((int)(((byte)(246)))));
            this.SMtextBox.Name = "SMtextBox";
            this.SMtextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SMtextBox_KeyDown);
            // 
            // TTlabel
            // 
            resources.ApplyResources(this.TTlabel, "TTlabel");
            this.TTlabel.Name = "TTlabel";
            // 
            // frmManagerRY
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(209)))), ((int)(((byte)(223)))));
            this.Controls.Add(this.RYdataGridView);
            this.Controls.Add(this.SMtextBox);
            this.Controls.Add(this.TTlabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmManagerRY";
            this.Load += new System.EventHandler(this.frmManagerRY_Load);
            this.Shown += new System.EventHandler(this.frmManagerRY_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.RYdataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TTlabel;
        private System.Windows.Forms.TextBox SMtextBox;
        private System.Windows.Forms.DataGridView RYdataGridView;
    }
}