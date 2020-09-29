namespace Sonluk.MES.MES.main
{
    partial class frmRWDSCAN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRWDSCAN));
            this.titlelabel = new System.Windows.Forms.Label();
            this.smtextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gclabel = new System.Windows.Forms.Label();
            this.gccomboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // titlelabel
            // 
            resources.ApplyResources(this.titlelabel, "titlelabel");
            this.titlelabel.Name = "titlelabel";
            // 
            // smtextBox
            // 
            resources.ApplyResources(this.smtextBox, "smtextBox");
            this.smtextBox.Name = "smtextBox";
            this.smtextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.smtextBox_KeyDown);
            this.smtextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.smtextBox_MouseDown);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // gclabel
            // 
            resources.ApplyResources(this.gclabel, "gclabel");
            this.gclabel.Name = "gclabel";
            // 
            // gccomboBox
            // 
            resources.ApplyResources(this.gccomboBox, "gccomboBox");
            this.gccomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gccomboBox.FormattingEnabled = true;
            this.gccomboBox.Name = "gccomboBox";
            // 
            // frmRWDSCAN
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(209)))), ((int)(((byte)(223)))));
            this.Controls.Add(this.gccomboBox);
            this.Controls.Add(this.gclabel);
            this.Controls.Add(this.titlelabel);
            this.Controls.Add(this.smtextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRWDSCAN";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox smtextBox;
        private System.Windows.Forms.Label titlelabel;
        private System.Windows.Forms.Label gclabel;
        private System.Windows.Forms.ComboBox gccomboBox;
    }
}