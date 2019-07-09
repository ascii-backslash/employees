namespace Employees
{
    partial class EmployeeEditorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeEditorForm));
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.employeeNameEditTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.employeeSurnameEditTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.employeePatronymicEditTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.employeeSexSelector = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.employeePositionEditTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.employeeHiringDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.eployeePhoneNumberEditTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.employeeEmailEditTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.employeeAddressEditTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.employeeNoteEditTextBox = new System.Windows.Forms.TextBox();
            this.employeeBirthdayDateTimePicker = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(369, 491);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(108, 41);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(255, 491);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(108, 41);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "Ок";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Имя:";
            // 
            // employeeNameEditTextBox
            // 
            this.employeeNameEditTextBox.Location = new System.Drawing.Point(28, 44);
            this.employeeNameEditTextBox.MaxLength = 50;
            this.employeeNameEditTextBox.Name = "employeeNameEditTextBox";
            this.employeeNameEditTextBox.Size = new System.Drawing.Size(191, 22);
            this.employeeNameEditTextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Фамилия:";
            // 
            // employeeSurnameEditTextBox
            // 
            this.employeeSurnameEditTextBox.Location = new System.Drawing.Point(28, 89);
            this.employeeSurnameEditTextBox.MaxLength = 50;
            this.employeeSurnameEditTextBox.Name = "employeeSurnameEditTextBox";
            this.employeeSurnameEditTextBox.Size = new System.Drawing.Size(191, 22);
            this.employeeSurnameEditTextBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Отчество:";
            // 
            // employeePatronymicEditTextBox
            // 
            this.employeePatronymicEditTextBox.Location = new System.Drawing.Point(28, 134);
            this.employeePatronymicEditTextBox.MaxLength = 50;
            this.employeePatronymicEditTextBox.Name = "employeePatronymicEditTextBox";
            this.employeePatronymicEditTextBox.Size = new System.Drawing.Size(191, 22);
            this.employeePatronymicEditTextBox.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Дата рождения:";
            // 
            // employeeSexSelector
            // 
            this.employeeSexSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.employeeSexSelector.FormattingEnabled = true;
            this.employeeSexSelector.Items.AddRange(new object[] {
            "Мужской",
            "Женский"});
            this.employeeSexSelector.Location = new System.Drawing.Point(28, 224);
            this.employeeSexSelector.Name = "employeeSexSelector";
            this.employeeSexSelector.Size = new System.Drawing.Size(191, 24);
            this.employeeSexSelector.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Пол:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(283, 204);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "Должность:";
            // 
            // employeePositionEditTextBox
            // 
            this.employeePositionEditTextBox.Location = new System.Drawing.Point(286, 224);
            this.employeePositionEditTextBox.MaxLength = 50;
            this.employeePositionEditTextBox.Name = "employeePositionEditTextBox";
            this.employeePositionEditTextBox.Size = new System.Drawing.Size(191, 22);
            this.employeePositionEditTextBox.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(283, 249);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 17);
            this.label7.TabIndex = 1;
            this.label7.Text = "Дата устройства:";
            // 
            // employeeHiringDateTimePicker
            // 
            this.employeeHiringDateTimePicker.Location = new System.Drawing.Point(286, 269);
            this.employeeHiringDateTimePicker.Name = "employeeHiringDateTimePicker";
            this.employeeHiringDateTimePicker.Size = new System.Drawing.Size(191, 22);
            this.employeeHiringDateTimePicker.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(286, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(191, 179);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 251);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 17);
            this.label8.TabIndex = 1;
            this.label8.Text = "Телефон:";
            // 
            // eployeePhoneNumberEditTextBox
            // 
            this.eployeePhoneNumberEditTextBox.Location = new System.Drawing.Point(28, 271);
            this.eployeePhoneNumberEditTextBox.MaxLength = 20;
            this.eployeePhoneNumberEditTextBox.Name = "eployeePhoneNumberEditTextBox";
            this.eployeePhoneNumberEditTextBox.Size = new System.Drawing.Size(191, 22);
            this.eployeePhoneNumberEditTextBox.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 296);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 17);
            this.label9.TabIndex = 1;
            this.label9.Text = "E-mail:";
            // 
            // employeeEmailEditTextBox
            // 
            this.employeeEmailEditTextBox.Location = new System.Drawing.Point(27, 316);
            this.employeeEmailEditTextBox.MaxLength = 50;
            this.employeeEmailEditTextBox.Name = "employeeEmailEditTextBox";
            this.employeeEmailEditTextBox.Size = new System.Drawing.Size(191, 22);
            this.employeeEmailEditTextBox.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 341);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 17);
            this.label10.TabIndex = 1;
            this.label10.Text = "Адрес:";
            // 
            // employeeAddressEditTextBox
            // 
            this.employeeAddressEditTextBox.Location = new System.Drawing.Point(27, 361);
            this.employeeAddressEditTextBox.MaxLength = 50;
            this.employeeAddressEditTextBox.Name = "employeeAddressEditTextBox";
            this.employeeAddressEditTextBox.Size = new System.Drawing.Size(191, 22);
            this.employeeAddressEditTextBox.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(25, 386);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 17);
            this.label11.TabIndex = 1;
            this.label11.Text = "Заметка:";
            // 
            // employeeNoteEditTextBox
            // 
            this.employeeNoteEditTextBox.Location = new System.Drawing.Point(28, 406);
            this.employeeNoteEditTextBox.MaxLength = 255;
            this.employeeNoteEditTextBox.Multiline = true;
            this.employeeNoteEditTextBox.Name = "employeeNoteEditTextBox";
            this.employeeNoteEditTextBox.Size = new System.Drawing.Size(191, 126);
            this.employeeNoteEditTextBox.TabIndex = 2;
            // 
            // employeeBirthdayDateTimePicker
            // 
            this.employeeBirthdayDateTimePicker.Location = new System.Drawing.Point(28, 179);
            this.employeeBirthdayDateTimePicker.Name = "employeeBirthdayDateTimePicker";
            this.employeeBirthdayDateTimePicker.Size = new System.Drawing.Size(191, 22);
            this.employeeBirthdayDateTimePicker.TabIndex = 7;
            // 
            // EmployeeEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 556);
            this.Controls.Add(this.employeeBirthdayDateTimePicker);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.employeeHiringDateTimePicker);
            this.Controls.Add(this.employeeSexSelector);
            this.Controls.Add(this.employeePositionEditTextBox);
            this.Controls.Add(this.employeeNoteEditTextBox);
            this.Controls.Add(this.employeeAddressEditTextBox);
            this.Controls.Add(this.employeeEmailEditTextBox);
            this.Controls.Add(this.eployeePhoneNumberEditTextBox);
            this.Controls.Add(this.employeePatronymicEditTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.employeeSurnameEditTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.employeeNameEditTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EmployeeEditorForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактор работников...";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox employeeNameEditTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox employeeSurnameEditTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox employeePatronymicEditTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox employeeSexSelector;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox employeePositionEditTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker employeeHiringDateTimePicker;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox eployeePhoneNumberEditTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox employeeEmailEditTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox employeeAddressEditTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox employeeNoteEditTextBox;
        private System.Windows.Forms.DateTimePicker employeeBirthdayDateTimePicker;
    }
}