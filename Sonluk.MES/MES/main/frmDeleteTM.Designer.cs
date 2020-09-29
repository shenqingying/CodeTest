namespace Sonluk.MES.MES.main
{
    partial class frmDeleteTM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDeleteTM));
            this.label8 = new System.Windows.Forms.Label();
            this.smtextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ytmtextBox = new System.Windows.Forms.TextBox();
            this.ytmwllbtextBox = new System.Windows.Forms.TextBox();
            this.tlsstextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.czrtextBox = new System.Windows.Forms.TextBox();
            this.qrbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // smtextBox
            // 
            resources.ApplyResources(this.smtextBox, "smtextBox");
            this.smtextBox.Name = "smtextBox";
            this.smtextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.smtextBox_KeyDown);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // ytmtextBox
            // 
            resources.ApplyResources(this.ytmtextBox, "ytmtextBox");
            this.ytmtextBox.Name = "ytmtextBox";
            this.ytmtextBox.ReadOnly = true;
            // 
            // ytmwllbtextBox
            // 
            resources.ApplyResources(this.ytmwllbtextBox, "ytmwllbtextBox");
            this.ytmwllbtextBox.Name = "ytmwllbtextBox";
            this.ytmwllbtextBox.ReadOnly = true;
            // 
            // tlsstextBox
            // 
            resources.ApplyResources(this.tlsstextBox, "tlsstextBox");
            this.tlsstextBox.Name = "tlsstextBox";
            this.tlsstextBox.ReadOnly = true;
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // czrtextBox
            // 
            resources.ApplyResources(this.czrtextBox, "czrtextBox");
            this.czrtextBox.Name = "czrtextBox";
            this.czrtextBox.ReadOnly = true;
            this.czrtextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.czrtextBox_KeyDown);
            // 
            // qrbutton
            // 
            resources.ApplyResources(this.qrbutton, "qrbutton");
            this.qrbutton.Name = "qrbutton";
            this.qrbutton.UseVisualStyleBackColor = true;
            this.qrbutton.Click += new System.EventHandler(this.qrbutton_Click);
            // 
            // frmDeleteTM
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.qrbutton);
            this.Controls.Add(this.czrtextBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tlsstextBox);
            this.Controls.Add(this.ytmwllbtextBox);
            this.Controls.Add(this.ytmtextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.smtextBox);
            this.Controls.Add(this.label8);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmDeleteTM";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox smtextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ytmtextBox;
        private System.Windows.Forms.TextBox ytmwllbtextBox;
        private System.Windows.Forms.TextBox tlsstextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox czrtextBox;
        private System.Windows.Forms.Button qrbutton;
    }
}