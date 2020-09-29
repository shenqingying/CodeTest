namespace Sonluk.MES.MES.main
{
    partial class frmFujiCC
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
            this.zybutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.zybutton.Location = new System.Drawing.Point(842, 34);
            this.zybutton.Size = new System.Drawing.Size(140, 40);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font(q(Msg_Type.fonttype), 10F);
            this.label1.Location = new System.Drawing.Point(20, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "工厂:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font(q(Msg_Type.fonttype), 10F);
            this.label2.Location = new System.Drawing.Point(252, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "工作中心:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font(q(Msg_Type.fonttype), 10F);
            this.label3.Location = new System.Drawing.Point(501, 50);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "日期:";
            // 
            // gctextBox
            // 
            this.gctextBox.Font = new System.Drawing.Font(q(Msg_Type.fonttype), 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gctextBox.Location = new System.Drawing.Point(67, 45);
            this.gctextBox.Name = "gctextBox";
            this.gctextBox.ReadOnly = true;
            this.gctextBox.Size = new System.Drawing.Size(179, 25);
            this.gctextBox.TabIndex = 3;
            // 
            // gzzxtextBox
            // 
            this.gzzxtextBox.Font = new System.Drawing.Font(q(Msg_Type.fonttype), 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gzzxtextBox.Location = new System.Drawing.Point(327, 45);
            this.gzzxtextBox.Name = "gzzxtextBox";
            this.gzzxtextBox.ReadOnly = true;
            this.gzzxtextBox.Size = new System.Drawing.Size(169, 25);
            this.gzzxtextBox.TabIndex = 4;
            // 
            // rqtextBox
            // 
            this.rqtextBox.Font = new System.Drawing.Font(q(Msg_Type.fonttype), 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rqtextBox.Location = new System.Drawing.Point(548, 45);
            this.rqtextBox.Name = "rqtextBox";
            this.rqtextBox.ReadOnly = true;
            this.rqtextBox.Size = new System.Drawing.Size(128, 25);
            this.rqtextBox.TabIndex = 5;
            // 
            // totalpanel
            // 
            this.totalpanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.totalpanel.AutoScroll = true;
            this.totalpanel.Location = new System.Drawing.Point(23, 89);
            this.totalpanel.Name = "totalpanel";
            this.totalpanel.Size = new System.Drawing.Size(950, 593);
            this.totalpanel.TabIndex = 6;
            // 
            // sxbutton
            // 
            this.sxbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sxbutton.Font = new System.Drawing.Font(q(Msg_Type.fonttype), 13F);
            this.sxbutton.Location = new System.Drawing.Point(696, 34);
            this.sxbutton.Name = "sxbutton";
            this.sxbutton.Size = new System.Drawing.Size(140, 40);
            this.sxbutton.TabIndex = 7;
            this.sxbutton.Text = "刷新";
            this.sxbutton.UseVisualStyleBackColor = true;
            this.sxbutton.Click += new System.EventHandler(this.sxbutton_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 30000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmFujiCC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 694);
            this.Controls.Add(this.sxbutton);
            this.Controls.Add(this.totalpanel);
            this.Controls.Add(this.rqtextBox);
            this.Controls.Add(this.gzzxtextBox);
            this.Controls.Add(this.gctextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font(q(Msg_Type.fonttype), 9F);
            this.Name = "frmFujiCC";
            this.Text = "负极产出";
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