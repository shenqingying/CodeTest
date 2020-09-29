namespace Sonluk.MES.MES.main
{
    partial class frmZSLotSub
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
            this.qrbutton = new System.Windows.Forms.Button();
            this.qxbutton2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // qrbutton
            // 
            this.qrbutton.Font = new System.Drawing.Font(q(Msg_Type.fonttype), 13F);
            this.qrbutton.Location = new System.Drawing.Point(603, 494);
            this.qrbutton.Name = "qrbutton";
            this.qrbutton.Size = new System.Drawing.Size(103, 45);
            this.qrbutton.TabIndex = 0;
            this.qrbutton.Text = "确认";
            this.qrbutton.UseVisualStyleBackColor = true;
            this.qrbutton.Click += new System.EventHandler(this.qrbutton_Click);
            // 
            // qxbutton2
            // 
            this.qxbutton2.Font = new System.Drawing.Font(q(Msg_Type.fonttype), 13F);
            this.qxbutton2.Location = new System.Drawing.Point(736, 494);
            this.qxbutton2.Name = "qxbutton2";
            this.qxbutton2.Size = new System.Drawing.Size(103, 45);
            this.qxbutton2.TabIndex = 1;
            this.qxbutton2.Text = "取消";
            this.qxbutton2.UseVisualStyleBackColor = true;
            this.qxbutton2.Click += new System.EventHandler(this.qxbutton2_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(-1, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(885, 463);
            this.panel1.TabIndex = 2;
            // 
            // frmZSLotSub
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 564);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.qxbutton2);
            this.Controls.Add(this.qrbutton);
            this.Name = "frmZSLotSub";
            this.Text = "无腔号选择";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button qrbutton;
        private System.Windows.Forms.Button qxbutton2;
        private System.Windows.Forms.Panel panel1;
    }
}