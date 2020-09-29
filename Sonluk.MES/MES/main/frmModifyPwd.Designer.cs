namespace Sonluk.MES.MES.main
{
    partial class frmModifyPwd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModifyPwd));
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.comfirmpwdtextBox = new System.Windows.Forms.TextBox();
            this.newpwdtextBox = new System.Windows.Forms.TextBox();
            this.oldpwdtextBox = new System.Windows.Forms.TextBox();
            this.usernametextBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comfirmpwdtextBox
            // 
            resources.ApplyResources(this.comfirmpwdtextBox, "comfirmpwdtextBox");
            this.comfirmpwdtextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(241)))), ((int)(((byte)(246)))));
            this.comfirmpwdtextBox.Name = "comfirmpwdtextBox";
            // 
            // newpwdtextBox
            // 
            resources.ApplyResources(this.newpwdtextBox, "newpwdtextBox");
            this.newpwdtextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(241)))), ((int)(((byte)(246)))));
            this.newpwdtextBox.Name = "newpwdtextBox";
            // 
            // oldpwdtextBox
            // 
            resources.ApplyResources(this.oldpwdtextBox, "oldpwdtextBox");
            this.oldpwdtextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(241)))), ((int)(((byte)(246)))));
            this.oldpwdtextBox.Name = "oldpwdtextBox";
            // 
            // usernametextBox1
            // 
            resources.ApplyResources(this.usernametextBox1, "usernametextBox1");
            this.usernametextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(241)))), ((int)(((byte)(246)))));
            this.usernametextBox1.Name = "usernametextBox1";
            this.usernametextBox1.ReadOnly = true;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // frmModifyPwd
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comfirmpwdtextBox);
            this.Controls.Add(this.newpwdtextBox);
            this.Controls.Add(this.oldpwdtextBox);
            this.Controls.Add(this.usernametextBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmModifyPwd";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox usernametextBox1;
        private System.Windows.Forms.TextBox oldpwdtextBox;
        private System.Windows.Forms.TextBox newpwdtextBox;
        private System.Windows.Forms.TextBox comfirmpwdtextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}