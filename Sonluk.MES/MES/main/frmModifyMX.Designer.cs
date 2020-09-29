namespace Sonluk.MES.MES.main
{
    partial class frmModifyMX
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModifyMX));
            this.shbutton = new System.Windows.Forms.Button();
            this.tjbutton = new System.Windows.Forms.Button();
            this.contentlistBox = new System.Windows.Forms.ListBox();
            this.contenttextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // shbutton
            // 
            resources.ApplyResources(this.shbutton, "shbutton");
            this.shbutton.Name = "shbutton";
            this.shbutton.UseVisualStyleBackColor = true;
            this.shbutton.Click += new System.EventHandler(this.shbutton_Click);
            // 
            // tjbutton
            // 
            resources.ApplyResources(this.tjbutton, "tjbutton");
            this.tjbutton.Name = "tjbutton";
            this.tjbutton.UseVisualStyleBackColor = true;
            this.tjbutton.Click += new System.EventHandler(this.tjbutton_Click);
            // 
            // contentlistBox
            // 
            resources.ApplyResources(this.contentlistBox, "contentlistBox");
            this.contentlistBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(241)))), ((int)(((byte)(246)))));
            this.contentlistBox.FormattingEnabled = true;
            this.contentlistBox.Name = "contentlistBox";
            // 
            // contenttextBox
            // 
            resources.ApplyResources(this.contenttextBox, "contenttextBox");
            this.contenttextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(241)))), ((int)(((byte)(246)))));
            this.contenttextBox.Name = "contenttextBox";
            // 
            // frmModifyMX
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(209)))), ((int)(((byte)(223)))));
            this.Controls.Add(this.shbutton);
            this.Controls.Add(this.tjbutton);
            this.Controls.Add(this.contentlistBox);
            this.Controls.Add(this.contenttextBox);
            this.Name = "frmModifyMX";
            this.Shown += new System.EventHandler(this.frmModifyMX_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox contenttextBox;
        private System.Windows.Forms.ListBox contentlistBox;
        private System.Windows.Forms.Button tjbutton;
        private System.Windows.Forms.Button shbutton;
    }
}