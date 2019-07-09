namespace Employees
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.companyTreeView = new System.Windows.Forms.TreeView();
            this.addCompanyButton = new System.Windows.Forms.Button();
            this.deleteCompanyButton = new System.Windows.Forms.Button();
            this.editCompanyButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.companyInfoTextBox = new System.Windows.Forms.TextBox();
            this.addEmployeeButton = new System.Windows.Forms.Button();
            this.deleteEmployeeButton = new System.Windows.Forms.Button();
            this.editEmployeeButton = new System.Windows.Forms.Button();
            this.employeeDataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeDataGridView)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // companyTreeView
            // 
            this.companyTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.companyTreeView.Location = new System.Drawing.Point(3, 18);
            this.companyTreeView.Name = "companyTreeView";
            this.companyTreeView.Size = new System.Drawing.Size(262, 403);
            this.companyTreeView.TabIndex = 0;
            this.companyTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.companyTreeView.Click += new System.EventHandler(this.treeView1_Click);
            // 
            // addCompanyButton
            // 
            this.addCompanyButton.Location = new System.Drawing.Point(12, 638);
            this.addCompanyButton.Name = "addCompanyButton";
            this.addCompanyButton.Size = new System.Drawing.Size(92, 44);
            this.addCompanyButton.TabIndex = 2;
            this.addCompanyButton.Text = "Добавить";
            this.addCompanyButton.UseVisualStyleBackColor = true;
            this.addCompanyButton.Click += new System.EventHandler(this.addCompanyButton_Click);
            // 
            // deleteCompanyButton
            // 
            this.deleteCompanyButton.Location = new System.Drawing.Point(110, 638);
            this.deleteCompanyButton.Name = "deleteCompanyButton";
            this.deleteCompanyButton.Size = new System.Drawing.Size(78, 44);
            this.deleteCompanyButton.TabIndex = 2;
            this.deleteCompanyButton.Text = "Удалить";
            this.deleteCompanyButton.UseVisualStyleBackColor = true;
            this.deleteCompanyButton.Click += new System.EventHandler(this.deleteCompanyButton_Click);
            // 
            // editCompanyButton
            // 
            this.editCompanyButton.Location = new System.Drawing.Point(194, 638);
            this.editCompanyButton.Name = "editCompanyButton";
            this.editCompanyButton.Size = new System.Drawing.Size(95, 44);
            this.editCompanyButton.TabIndex = 2;
            this.editCompanyButton.Text = "Изменить";
            this.editCompanyButton.UseVisualStyleBackColor = true;
            this.editCompanyButton.Click += new System.EventHandler(this.editCompanyButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.companyTreeView);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 424);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Компании:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.companyInfoTextBox);
            this.groupBox2.Location = new System.Drawing.Point(15, 442);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(265, 190);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Описание:";
            // 
            // companyInfoTextBox
            // 
            this.companyInfoTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.companyInfoTextBox.Location = new System.Drawing.Point(3, 18);
            this.companyInfoTextBox.Multiline = true;
            this.companyInfoTextBox.Name = "companyInfoTextBox";
            this.companyInfoTextBox.ReadOnly = true;
            this.companyInfoTextBox.Size = new System.Drawing.Size(259, 169);
            this.companyInfoTextBox.TabIndex = 6;
            // 
            // addEmployeeButton
            // 
            this.addEmployeeButton.Location = new System.Drawing.Point(1038, 638);
            this.addEmployeeButton.Name = "addEmployeeButton";
            this.addEmployeeButton.Size = new System.Drawing.Size(96, 44);
            this.addEmployeeButton.TabIndex = 2;
            this.addEmployeeButton.Text = "Добавить";
            this.addEmployeeButton.UseVisualStyleBackColor = true;
            this.addEmployeeButton.Click += new System.EventHandler(this.addEmployeeButton_Click);
            // 
            // deleteEmployeeButton
            // 
            this.deleteEmployeeButton.Location = new System.Drawing.Point(1140, 638);
            this.deleteEmployeeButton.Name = "deleteEmployeeButton";
            this.deleteEmployeeButton.Size = new System.Drawing.Size(85, 44);
            this.deleteEmployeeButton.TabIndex = 2;
            this.deleteEmployeeButton.Text = "Удалить";
            this.deleteEmployeeButton.UseVisualStyleBackColor = true;
            this.deleteEmployeeButton.Click += new System.EventHandler(this.deleteEmployeeButton_Click);
            // 
            // editEmployeeButton
            // 
            this.editEmployeeButton.Location = new System.Drawing.Point(1231, 638);
            this.editEmployeeButton.Name = "editEmployeeButton";
            this.editEmployeeButton.Size = new System.Drawing.Size(88, 44);
            this.editEmployeeButton.TabIndex = 2;
            this.editEmployeeButton.Text = "Изменить";
            this.editEmployeeButton.UseVisualStyleBackColor = true;
            this.editEmployeeButton.Click += new System.EventHandler(this.editEmployeeButton_Click);
            // 
            // employeeDataGridView
            // 
            this.employeeDataGridView.AllowUserToAddRows = false;
            this.employeeDataGridView.AllowUserToDeleteRows = false;
            this.employeeDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.employeeDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.employeeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.employeeDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.employeeDataGridView.Location = new System.Drawing.Point(3, 18);
            this.employeeDataGridView.MultiSelect = false;
            this.employeeDataGridView.Name = "employeeDataGridView";
            this.employeeDataGridView.ReadOnly = true;
            this.employeeDataGridView.RowTemplate.Height = 24;
            this.employeeDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.employeeDataGridView.Size = new System.Drawing.Size(1027, 599);
            this.employeeDataGridView.TabIndex = 6;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.employeeDataGridView);
            this.groupBox3.Location = new System.Drawing.Point(286, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1033, 620);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Сотрудники:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1331, 694);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.editEmployeeButton);
            this.Controls.Add(this.editCompanyButton);
            this.Controls.Add(this.deleteEmployeeButton);
            this.Controls.Add(this.deleteCompanyButton);
            this.Controls.Add(this.addEmployeeButton);
            this.Controls.Add(this.addCompanyButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Список сотрудников";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeDataGridView)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView companyTreeView;
        private System.Windows.Forms.Button addCompanyButton;
        private System.Windows.Forms.Button deleteCompanyButton;
        private System.Windows.Forms.Button editCompanyButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox companyInfoTextBox;
        private System.Windows.Forms.Button addEmployeeButton;
        private System.Windows.Forms.Button deleteEmployeeButton;
        private System.Windows.Forms.Button editEmployeeButton;
        private System.Windows.Forms.DataGridView employeeDataGridView;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}

