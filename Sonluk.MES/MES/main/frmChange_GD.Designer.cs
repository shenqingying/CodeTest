namespace Sonluk.MES.MES.main
{
    partial class frmChange_GD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChange_GD));
            this.GDdataGridView = new System.Windows.Forms.DataGridView();
            this.TTlabel = new System.Windows.Forms.Label();
            this.QRbutton = new System.Windows.Forms.Button();
            this.QXbutton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GDdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // GDdataGridView
            // 
            resources.ApplyResources(this.GDdataGridView, "GDdataGridView");
            this.GDdataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(241)))), ((int)(((byte)(246)))));
            this.GDdataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GDdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GDdataGridView.MultiSelect = false;
            this.GDdataGridView.Name = "GDdataGridView";
            this.GDdataGridView.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 11F);
            this.GDdataGridView.RowTemplate.Height = 50;
            this.GDdataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GDdataGridView_CellClick);
            this.GDdataGridView.Paint += new System.Windows.Forms.PaintEventHandler(this.GDdataGridView_Paint);
            // 
            // TTlabel
            // 
            resources.ApplyResources(this.TTlabel, "TTlabel");
            this.TTlabel.Name = "TTlabel";
            // 
            // QRbutton
            // 
            resources.ApplyResources(this.QRbutton, "QRbutton");
            this.QRbutton.Name = "QRbutton";
            this.QRbutton.UseVisualStyleBackColor = true;
            this.QRbutton.Click += new System.EventHandler(this.QRbutton_Click);
            // 
            // QXbutton
            // 
            resources.ApplyResources(this.QXbutton, "QXbutton");
            this.QXbutton.Name = "QXbutton";
            this.QXbutton.UseVisualStyleBackColor = true;
            this.QXbutton.Click += new System.EventHandler(this.QXbutton_Click);
            // 
            // frmChange_GD
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(209)))), ((int)(((byte)(223)))));
            this.Controls.Add(this.QXbutton);
            this.Controls.Add(this.QRbutton);
            this.Controls.Add(this.GDdataGridView);
            this.Controls.Add(this.TTlabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmChange_GD";
            this.Load += new System.EventHandler(this.frmChange_GD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GDdataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label TTlabel;
        private System.Windows.Forms.DataGridView GDdataGridView;
        private System.Windows.Forms.Button QRbutton;
        private System.Windows.Forms.Button QXbutton;
    }
}