namespace Sonluk.MES.MES.main
{
    partial class frmFindGZZX
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFindGZZX));
            this.fhbutton = new System.Windows.Forms.Button();
            this.gccomboBox = new System.Windows.Forms.ComboBox();
            this.grouplabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.gzzxcomboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // fhbutton
            // 
            resources.ApplyResources(this.fhbutton, "fhbutton");
            this.fhbutton.Name = "fhbutton";
            this.fhbutton.UseVisualStyleBackColor = true;
            this.fhbutton.Click += new System.EventHandler(this.fhbutton_Click);
            // 
            // gccomboBox
            // 
            resources.ApplyResources(this.gccomboBox, "gccomboBox");
            this.gccomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gccomboBox.FormattingEnabled = true;
            this.gccomboBox.Name = "gccomboBox";
            this.gccomboBox.SelectedValueChanged += new System.EventHandler(this.gccomboBox_SelectedValueChanged);
            // 
            // grouplabel
            // 
            resources.ApplyResources(this.grouplabel, "grouplabel");
            this.grouplabel.Name = "grouplabel";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // gzzxcomboBox
            // 
            resources.ApplyResources(this.gzzxcomboBox, "gzzxcomboBox");
            this.gzzxcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gzzxcomboBox.FormattingEnabled = true;
            this.gzzxcomboBox.Name = "gzzxcomboBox";
            this.gzzxcomboBox.SelectedIndexChanged += new System.EventHandler(this.gzzxcomboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // frmFindGZZX
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(209)))), ((int)(((byte)(223)))));
            this.Controls.Add(this.fhbutton);
            this.Controls.Add(this.gccomboBox);
            this.Controls.Add(this.grouplabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gzzxcomboBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFindGZZX";
            this.Load += new System.EventHandler(this.frmFindGZZX_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label grouplabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox gccomboBox;
        private System.Windows.Forms.Button fhbutton;
        private System.Windows.Forms.ComboBox gzzxcomboBox;
    }
}