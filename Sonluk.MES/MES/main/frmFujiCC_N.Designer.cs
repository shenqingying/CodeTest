namespace Sonluk.MES.MES.main
{
    partial class frmFujiCC_N
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFujiCC_N));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gctextBox = new System.Windows.Forms.TextBox();
            this.gzzxtextBox = new System.Windows.Forms.TextBox();
            this.rqtextBox = new System.Windows.Forms.TextBox();
            this.totalpanel = new System.Windows.Forms.Panel();
            this.sxbutton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // zybutton
            // 
            resources.ApplyResources(this.zybutton, "zybutton");
            this.zybutton.Image = global::Sonluk.MES.Properties.Resources.logo;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
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
            // gctextBox
            // 
            resources.ApplyResources(this.gctextBox, "gctextBox");
            this.gctextBox.Name = "gctextBox";
            this.gctextBox.ReadOnly = true;
            // 
            // gzzxtextBox
            // 
            resources.ApplyResources(this.gzzxtextBox, "gzzxtextBox");
            this.gzzxtextBox.Name = "gzzxtextBox";
            this.gzzxtextBox.ReadOnly = true;
            // 
            // rqtextBox
            // 
            resources.ApplyResources(this.rqtextBox, "rqtextBox");
            this.rqtextBox.Name = "rqtextBox";
            this.rqtextBox.ReadOnly = true;
            // 
            // totalpanel
            // 
            resources.ApplyResources(this.totalpanel, "totalpanel");
            this.totalpanel.Name = "totalpanel";
            // 
            // sxbutton
            // 
            resources.ApplyResources(this.sxbutton, "sxbutton");
            this.sxbutton.Name = "sxbutton";
            this.sxbutton.UseVisualStyleBackColor = true;
            this.sxbutton.Click += new System.EventHandler(this.sxbutton_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 30000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmFujiCC_N
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sxbutton);
            this.Controls.Add(this.totalpanel);
            this.Controls.Add(this.rqtextBox);
            this.Controls.Add(this.gzzxtextBox);
            this.Controls.Add(this.gctextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmFujiCC_N";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmFujiCC_Load);
            this.Shown += new System.EventHandler(this.frmFujiCC_Shown);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.gctextBox, 0);
            this.Controls.SetChildIndex(this.gzzxtextBox, 0);
            this.Controls.SetChildIndex(this.rqtextBox, 0);
            this.Controls.SetChildIndex(this.totalpanel, 0);
            this.Controls.SetChildIndex(this.zybutton, 0);
            this.Controls.SetChildIndex(this.sxbutton, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox gctextBox;
        private System.Windows.Forms.TextBox gzzxtextBox;
        private System.Windows.Forms.TextBox rqtextBox;
        private System.Windows.Forms.Panel totalpanel;
        private System.Windows.Forms.Button sxbutton;
        private System.Windows.Forms.Timer timer1;
    }
}