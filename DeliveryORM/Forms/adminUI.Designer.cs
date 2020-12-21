namespace Forms
{
    partial class adminUI
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.deleteB = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.userList = new System.Windows.Forms.ListView();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.shipmentView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detailButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.doneBox = new System.Windows.Forms.ComboBox();
            this.DoneView = new System.Windows.Forms.ListView();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.stateView = new System.Windows.Forms.ListView();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.courierBox = new System.Windows.Forms.ComboBox();
            this.LateCView = new System.Windows.Forms.ListView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shipmentView)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tabControl1.ItemSize = new System.Drawing.Size(60, 18);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1117, 459);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.Controls.Add(this.deleteB);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.userList);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1109, 433);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Užívatelia";
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // deleteB
            // 
            this.deleteB.Location = new System.Drawing.Point(15, 128);
            this.deleteB.Name = "deleteB";
            this.deleteB.Size = new System.Drawing.Size(147, 41);
            this.deleteB.TabIndex = 4;
            this.deleteB.Text = "Zrušiť užívateľa";
            this.deleteB.UseVisualStyleBackColor = true;
            this.deleteB.Click += new System.EventHandler(this.deleteB_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label1.Location = new System.Drawing.Point(185, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 22);
            this.label1.TabIndex = 3;
            this.label1.Text = "Zoznam užívateľov";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // userList
            // 
            this.userList.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.userList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.userList.HideSelection = false;
            this.userList.Location = new System.Drawing.Point(189, 31);
            this.userList.Name = "userList";
            this.userList.Size = new System.Drawing.Size(903, 396);
            this.userList.TabIndex = 2;
            this.userList.UseCompatibleStateImageBehavior = false;
            this.userList.SelectedIndexChanged += new System.EventHandler(this.userList_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(15, 78);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(147, 44);
            this.button2.TabIndex = 1;
            this.button2.Text = "Aktualizovať užívateľa";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.updateUser_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 41);
            this.button1.TabIndex = 0;
            this.button1.Text = "Vložiť užívateľa";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.addUser_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage2.Controls.Add(this.tabControl2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1109, 433);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Zásielky";
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Controls.Add(this.tabPage6);
            this.tabControl2.Location = new System.Drawing.Point(15, 3);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1088, 410);
            this.tabControl2.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage3.Controls.Add(this.shipmentView);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1080, 381);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Všetky";
            this.tabPage3.Click += new System.EventHandler(this.tabPage3_Click);
            // 
            // shipmentView
            // 
            this.shipmentView.AllowUserToAddRows = false;
            this.shipmentView.AllowUserToDeleteRows = false;
            this.shipmentView.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.shipmentView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.shipmentView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.shipmentView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.detailButton});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.shipmentView.DefaultCellStyle = dataGridViewCellStyle2;
            this.shipmentView.Location = new System.Drawing.Point(10, 37);
            this.shipmentView.Name = "shipmentView";
            this.shipmentView.ReadOnly = true;
            this.shipmentView.Size = new System.Drawing.Size(749, 325);
            this.shipmentView.TabIndex = 5;
            this.shipmentView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.shipmentView_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // detailButton
            // 
            this.detailButton.HeaderText = "Detail zásielky";
            this.detailButton.Name = "detailButton";
            this.detailButton.ReadOnly = true;
            this.detailButton.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.detailButton.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label2.Location = new System.Drawing.Point(6, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(217, 22);
            this.label2.TabIndex = 4;
            this.label2.Text = "Zoznam všetkých zásielok";
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage4.Controls.Add(this.doneBox);
            this.tabPage4.Controls.Add(this.DoneView);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1080, 381);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Ukončené";
            this.tabPage4.Click += new System.EventHandler(this.tabPage4_Click);
            // 
            // doneBox
            // 
            this.doneBox.FormattingEnabled = true;
            this.doneBox.Location = new System.Drawing.Point(6, 6);
            this.doneBox.Name = "doneBox";
            this.doneBox.Size = new System.Drawing.Size(233, 24);
            this.doneBox.TabIndex = 1;
            this.doneBox.SelectedIndexChanged += new System.EventHandler(this.doneBox_SelectedIndexChanged);
            // 
            // DoneView
            // 
            this.DoneView.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.DoneView.HideSelection = false;
            this.DoneView.Location = new System.Drawing.Point(6, 40);
            this.DoneView.Name = "DoneView";
            this.DoneView.Size = new System.Drawing.Size(577, 330);
            this.DoneView.TabIndex = 0;
            this.DoneView.UseCompatibleStateImageBehavior = false;
            this.DoneView.SelectedIndexChanged += new System.EventHandler(this.DoneView_SelectedIndexChanged);
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage5.Controls.Add(this.stateView);
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1080, 381);
            this.tabPage5.TabIndex = 2;
            this.tabPage5.Text = "Kontrola kuriérov";
            // 
            // stateView
            // 
            this.stateView.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.stateView.HideSelection = false;
            this.stateView.Location = new System.Drawing.Point(6, 6);
            this.stateView.Name = "stateView";
            this.stateView.Size = new System.Drawing.Size(1068, 369);
            this.stateView.TabIndex = 0;
            this.stateView.UseCompatibleStateImageBehavior = false;
            this.stateView.SelectedIndexChanged += new System.EventHandler(this.stateView_SelectedIndexChanged);
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage6.Controls.Add(this.courierBox);
            this.tabPage6.Controls.Add(this.LateCView);
            this.tabPage6.Location = new System.Drawing.Point(4, 25);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(1080, 381);
            this.tabPage6.TabIndex = 3;
            this.tabPage6.Text = "Oneskorené";
            this.tabPage6.Click += new System.EventHandler(this.tabPage6_Click);
            // 
            // courierBox
            // 
            this.courierBox.FormattingEnabled = true;
            this.courierBox.Location = new System.Drawing.Point(6, 7);
            this.courierBox.Name = "courierBox";
            this.courierBox.Size = new System.Drawing.Size(231, 24);
            this.courierBox.TabIndex = 2;
            this.courierBox.SelectedIndexChanged += new System.EventHandler(this.courierBox_SelectedIndexChanged);
            // 
            // LateCView
            // 
            this.LateCView.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.LateCView.HideSelection = false;
            this.LateCView.Location = new System.Drawing.Point(6, 37);
            this.LateCView.Name = "LateCView";
            this.LateCView.Size = new System.Drawing.Size(1068, 338);
            this.LateCView.TabIndex = 1;
            this.LateCView.UseCompatibleStateImageBehavior = false;
            this.LateCView.SelectedIndexChanged += new System.EventHandler(this.LateCView_SelectedIndexChanged);
            // 
            // adminUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 493);
            this.Controls.Add(this.tabControl1);
            this.Name = "adminUI";
            this.Text = "Administrácia";
            this.Load += new System.EventHandler(this.adminUI_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shipmentView)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView userList;
        private System.Windows.Forms.Button deleteB;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView shipmentView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewButtonColumn detailButton;
        private System.Windows.Forms.ListView DoneView;
        private System.Windows.Forms.ComboBox doneBox;
        private System.Windows.Forms.ListView stateView;
        private System.Windows.Forms.ListView LateCView;
        private System.Windows.Forms.ComboBox courierBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}