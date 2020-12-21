namespace Forms
{
    partial class courierUI
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
            this.label1 = new System.Windows.Forms.Label();
            this.courierBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lateshipmentsView = new System.Windows.Forms.ListView();
            this.notdoneListView = new System.Windows.Forms.ListView();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Moje zásielky";
            // 
            // courierBox
            // 
            this.courierBox.FormattingEnabled = true;
            this.courierBox.Location = new System.Drawing.Point(12, 64);
            this.courierBox.Name = "courierBox";
            this.courierBox.Size = new System.Drawing.Size(166, 21);
            this.courierBox.TabIndex = 2;
            this.courierBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(9, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Vyberte kuriéra";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lateshipmentsView);
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(596, 403);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Meškajúce zásielky";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(182, 33);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(8, 8);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(184, 9);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(604, 429);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.notdoneListView);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(596, 403);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "Na doručenie";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lateshipmentsView
            // 
            this.lateshipmentsView.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lateshipmentsView.HideSelection = false;
            this.lateshipmentsView.Location = new System.Drawing.Point(15, 12);
            this.lateshipmentsView.Name = "lateshipmentsView";
            this.lateshipmentsView.Size = new System.Drawing.Size(575, 385);
            this.lateshipmentsView.TabIndex = 1;
            this.lateshipmentsView.UseCompatibleStateImageBehavior = false;
            this.lateshipmentsView.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
            // 
            // notdoneListView
            // 
            this.notdoneListView.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.notdoneListView.HideSelection = false;
            this.notdoneListView.Location = new System.Drawing.Point(11, 9);
            this.notdoneListView.Name = "notdoneListView";
            this.notdoneListView.Size = new System.Drawing.Size(575, 385);
            this.notdoneListView.TabIndex = 2;
            this.notdoneListView.UseCompatibleStateImageBehavior = false;
            this.notdoneListView.SelectedIndexChanged += new System.EventHandler(this.notdoneListView_SelectedIndexChanged);
            // 
            // courierUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.courierBox);
            this.Controls.Add(this.label1);
            this.Name = "courierUI";
            this.Text = "Kuriér";
            this.Load += new System.EventHandler(this.courierUI_Load);
            this.tabPage1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox courierBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListView lateshipmentsView;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListView notdoneListView;
    }
}