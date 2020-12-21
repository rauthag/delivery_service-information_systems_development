namespace Forms
{
    partial class customerUI
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
            this.CreateShipmentButt = new System.Windows.Forms.Button();
            this.ShipmentsView = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.customerBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CreateShipmentButt
            // 
            this.CreateShipmentButt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.CreateShipmentButt.Location = new System.Drawing.Point(20, 397);
            this.CreateShipmentButt.Name = "CreateShipmentButt";
            this.CreateShipmentButt.Size = new System.Drawing.Size(183, 41);
            this.CreateShipmentButt.TabIndex = 1;
            this.CreateShipmentButt.Text = "Vytvoriť zásielku";
            this.CreateShipmentButt.UseVisualStyleBackColor = true;
            this.CreateShipmentButt.Click += new System.EventHandler(this.CreateShipmentButt_Click);
            // 
            // ShipmentsView
            // 
            this.ShipmentsView.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ShipmentsView.HideSelection = false;
            this.ShipmentsView.Location = new System.Drawing.Point(235, 37);
            this.ShipmentsView.Name = "ShipmentsView";
            this.ShipmentsView.Size = new System.Drawing.Size(643, 401);
            this.ShipmentsView.TabIndex = 2;
            this.ShipmentsView.UseCompatibleStateImageBehavior = false;
            this.ShipmentsView.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label1.Location = new System.Drawing.Point(231, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 22);
            this.label1.TabIndex = 4;
            this.label1.Text = "Moje zásielky";
            // 
            // customerBox
            // 
            this.customerBox.FormattingEnabled = true;
            this.customerBox.Location = new System.Drawing.Point(16, 37);
            this.customerBox.Name = "customerBox";
            this.customerBox.Size = new System.Drawing.Size(187, 21);
            this.customerBox.TabIndex = 5;
            this.customerBox.SelectedIndexChanged += new System.EventHandler(this.customerBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label2.Location = new System.Drawing.Point(12, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 22);
            this.label2.TabIndex = 6;
            this.label2.Text = "Vyberte zákazníka";
            // 
            // customerUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.customerBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ShipmentsView);
            this.Controls.Add(this.CreateShipmentButt);
            this.Name = "customerUI";
            this.Text = "Zákazník";
            this.Load += new System.EventHandler(this.customerUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CreateShipmentButt;
        private System.Windows.Forms.ListView ShipmentsView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox customerBox;
        private System.Windows.Forms.Label label2;
    }
}