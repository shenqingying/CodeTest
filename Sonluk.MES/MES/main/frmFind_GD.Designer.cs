using System;
namespace Sonluk.MES.MES.main
{
    partial class frmFind_GD
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
            this.GCtextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SBcomboBox = new System.Windows.Forms.ComboBox();
            this.GZZXcomboBox = new System.Windows.Forms.ComboBox();
            this.BTlabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // GCtextBox
            // 
            this.GCtextBox.Font = new System.Drawing.Font(q(Msg_Type.fonttype), 14F);
            this.GCtextBox.Location = new System.Drawing.Point(412, 166);
            this.GCtextBox.Name = "GCtextBox";
            this.GCtextBox.ReadOnly = true;
            this.GCtextBox.Size = new System.Drawing.Size(200, 29);
            this.GCtextBox.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font(q(Msg_Type.fonttype), 14F);
            this.button1.Location = new System.Drawing.Point(386, 391);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 35);
            this.button1.TabIndex = 7;
            this.button1.Text = "查询设备号";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font(q(Msg_Type.fonttype), 14F);
            this.label3.Location = new System.Drawing.Point(286, 314);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "设备";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font(q(Msg_Type.fonttype), 14F);
            this.label2.Location = new System.Drawing.Point(286, 240);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "工作中心";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font(q(Msg_Type.fonttype), 14F);
            this.label1.Location = new System.Drawing.Point(286, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "工厂";
            // 
            // SBcomboBox
            // 
            this.SBcomboBox.Font = new System.Drawing.Font(q(Msg_Type.fonttype), 14F);
            this.SBcomboBox.Location = new System.Drawing.Point(412, 306);
            this.SBcomboBox.Name = "SBcomboBox";
            this.SBcomboBox.Size = new System.Drawing.Size(200, 27);
            this.SBcomboBox.TabIndex = 3;
            // 
            // GZZXcomboBox
            // 
            this.GZZXcomboBox.Font = new System.Drawing.Font(q(Msg_Type.fonttype), 14F);
            this.GZZXcomboBox.Location = new System.Drawing.Point(412, 227);
            this.GZZXcomboBox.Name = "GZZXcomboBox";
            this.GZZXcomboBox.Size = new System.Drawing.Size(200, 27);
            this.GZZXcomboBox.TabIndex = 2;
            this.GZZXcomboBox.SelectedIndexChanged += new System.EventHandler(this.GZZXcomboBox_SelectedIndexChanged);
            // 
            // BTlabel
            // 
            this.BTlabel.BackColor = System.Drawing.SystemColors.Control;
            this.BTlabel.Font = new System.Drawing.Font(q(Msg_Type.fonttype), 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BTlabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BTlabel.Location = new System.Drawing.Point(12, 3);
            this.BTlabel.Name = "BTlabel";
            this.BTlabel.Size = new System.Drawing.Size(926, 96);
            this.BTlabel.TabIndex = 0;
            this.BTlabel.Text = "标题";
            this.BTlabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmFind_GD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 546);
            this.Controls.Add(this.GCtextBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SBcomboBox);
            this.Controls.Add(this.GZZXcomboBox);
            this.Controls.Add(this.BTlabel);
            this.Name = "frmFind_GD";
            this.Text = "frmFind_GD";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label BTlabel;
        private System.Windows.Forms.ComboBox GZZXcomboBox;
        private System.Windows.Forms.ComboBox SBcomboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox GCtextBox;
    }
}