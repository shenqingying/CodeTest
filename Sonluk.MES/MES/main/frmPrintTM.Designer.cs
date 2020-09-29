namespace Sonluk.MES.MES.main
{
    partial class frmPrintTM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrintTM));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tmtextBox = new System.Windows.Forms.TextBox();
            this.fsnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.dybutton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fsnumericUpDown)).BeginInit();
            this.SuspendLayout();
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
            // tmtextBox
            // 
            resources.ApplyResources(this.tmtextBox, "tmtextBox");
            this.tmtextBox.Name = "tmtextBox";
            this.tmtextBox.ReadOnly = true;
            this.tmtextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tmtextBox_KeyDown);
            // 
            // fsnumericUpDown
            // 
            resources.ApplyResources(this.fsnumericUpDown, "fsnumericUpDown");
            this.fsnumericUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(241)))), ((int)(((byte)(246)))));
            this.fsnumericUpDown.Name = "fsnumericUpDown";
            this.fsnumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dybutton
            // 
            resources.ApplyResources(this.dybutton, "dybutton");
            this.dybutton.Name = "dybutton";
            this.dybutton.UseVisualStyleBackColor = true;
            this.dybutton.Click += new System.EventHandler(this.dybutton_Click);
            // 
            // frmPrintTM
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(209)))), ((int)(((byte)(223)))));
            this.Controls.Add(this.dybutton);
            this.Controls.Add(this.fsnumericUpDown);
            this.Controls.Add(this.tmtextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "frmPrintTM";
            ((System.ComponentModel.ISupportInitialize)(this.fsnumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tmtextBox;
        private System.Windows.Forms.NumericUpDown fsnumericUpDown;
        private System.Windows.Forms.Button dybutton;
    }
}