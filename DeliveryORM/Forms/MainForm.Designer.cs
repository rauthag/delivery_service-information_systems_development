namespace Forms
{
    partial class MainForm
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
            this.adminB = new System.Windows.Forms.Button();
            this.customerB = new System.Windows.Forms.Button();
            this.courierB = new System.Windows.Forms.Button();
            this.exitB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // adminB
            // 
            this.adminB.Location = new System.Drawing.Point(12, 12);
            this.adminB.Name = "adminB";
            this.adminB.Size = new System.Drawing.Size(181, 66);
            this.adminB.TabIndex = 0;
            this.adminB.Text = "Admin";
            this.adminB.UseVisualStyleBackColor = true;
            this.adminB.Click += new System.EventHandler(this.adminB_Click);
            // 
            // customerB
            // 
            this.customerB.Location = new System.Drawing.Point(218, 12);
            this.customerB.Name = "customerB";
            this.customerB.Size = new System.Drawing.Size(181, 66);
            this.customerB.TabIndex = 1;
            this.customerB.Text = "Zákazník";
            this.customerB.UseVisualStyleBackColor = true;
            this.customerB.Click += new System.EventHandler(this.customerB_Click);
            // 
            // courierB
            // 
            this.courierB.Location = new System.Drawing.Point(423, 12);
            this.courierB.Name = "courierB";
            this.courierB.Size = new System.Drawing.Size(181, 66);
            this.courierB.TabIndex = 2;
            this.courierB.Text = "Kuriér";
            this.courierB.UseVisualStyleBackColor = true;
            this.courierB.Click += new System.EventHandler(this.courierB_Click);
            // 
            // exitB
            // 
            this.exitB.Location = new System.Drawing.Point(621, 12);
            this.exitB.Name = "exitB";
            this.exitB.Size = new System.Drawing.Size(181, 66);
            this.exitB.TabIndex = 3;
            this.exitB.Text = "Ukončiť";
            this.exitB.UseVisualStyleBackColor = true;
            this.exitB.Click += new System.EventHandler(this.exitB_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 95);
            this.Controls.Add(this.exitB);
            this.Controls.Add(this.courierB);
            this.Controls.Add(this.customerB);
            this.Controls.Add(this.adminB);
            this.Name = "MainForm";
            this.Text = "DeliveryApp";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button adminB;
        private System.Windows.Forms.Button customerB;
        private System.Windows.Forms.Button courierB;
        private System.Windows.Forms.Button exitB;
    }
}

