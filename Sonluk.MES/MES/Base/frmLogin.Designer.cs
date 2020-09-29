using System.Drawing;
using System.Windows.Forms;
namespace Sonluk.MES.MES
{
    partial class frmLogin
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
        /// this.Width=System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
//this.Height=System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.langucomboBox = new System.Windows.Forms.ComboBox();
            this.pwdTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.userTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.canclebutton = new System.Windows.Forms.Button();
            this.loginbutton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // langucomboBox
            // 
            resources.ApplyResources(this.langucomboBox, "langucomboBox");
            this.langucomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.langucomboBox.FormattingEnabled = true;
            this.langucomboBox.Name = "langucomboBox";
            this.langucomboBox.SelectedIndexChanged += new System.EventHandler(this.langucomboBox_SelectedIndexChanged);
            // 
            // pwdTextBox
            // 
            resources.ApplyResources(this.pwdTextBox, "pwdTextBox");
            this.pwdTextBox.Name = "pwdTextBox";
            this.pwdTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pwdTextBox_KeyDown_1);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
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
            // userTextBox
            // 
            resources.ApplyResources(this.userTextBox, "userTextBox");
            this.userTextBox.Name = "userTextBox";
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
            // canclebutton
            // 
            resources.ApplyResources(this.canclebutton, "canclebutton");
            this.canclebutton.Name = "canclebutton";
            this.canclebutton.UseVisualStyleBackColor = true;
            this.canclebutton.Click += new System.EventHandler(this.canclebutton_Click);
            // 
            // loginbutton
            // 
            resources.ApplyResources(this.loginbutton, "loginbutton");
            this.loginbutton.Name = "loginbutton";
            this.loginbutton.UseVisualStyleBackColor = true;
            this.loginbutton.Click += new System.EventHandler(this.loginbutton_Click);
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.Image = global::Sonluk.MES.Properties.Resources.logo10;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // frmLogin
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.langucomboBox);
            this.Controls.Add(this.pwdTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.userTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.canclebutton);
            this.Controls.Add(this.loginbutton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.Activated += new System.EventHandler(this.frmLogin_Activated);
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.Shown += new System.EventHandler(this.frmLogin_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loginbutton;
        private System.Windows.Forms.Button canclebutton;
        private Label label2;
        private PictureBox pictureBox1;
        private Label label1;
        private TextBox userTextBox;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox pwdTextBox;
        private ComboBox langucomboBox;
    }
}