using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;

namespace Employees
{
    public partial class EmployeeEditorForm : Form
    {
        Employee refEmployee;

        public EmployeeEditorForm(ref Employee employee)
        {
            InitializeComponent();

            refEmployee = employee;

            switch (employee.Id)
            {
                case 0:
                    this.Text = "Добавить работника...";
                    break;
                default:
                    this.Text = "Редактировать работника...";
                    break;
            }

            this.employeeNameEditTextBox.Text = employee.Name;
            this.employeeSurnameEditTextBox.Text = employee.Surname;
            this.employeePatronymicEditTextBox.Text = employee.Patronymic;
            this.employeePositionEditTextBox.Text = employee.Position;
            this.employeeHiringDateTimePicker.Value = Convert.ToDateTime(employee.DateOfHiring);
            this.employeeBirthdayDateTimePicker.Value = Convert.ToDateTime(employee.Birthday);
            this.employeeSexSelector.SelectedItem = employeeSexSelector.Items[employeeSexSelector.Items.IndexOf(employee.Sex.ToString())];
            this.eployeePhoneNumberEditTextBox.Text = employee.PhoneNumber;
            this.employeeEmailEditTextBox.Text = employee.Email;
            this.employeeAddressEditTextBox.Text = employee.Address;
            this.employeeNoteEditTextBox.Text = employee.Note;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (employeeNameEditTextBox.TextLength > 0 && employeeSurnameEditTextBox.TextLength > 0 && employeePositionEditTextBox.TextLength > 0 && employeeAddressEditTextBox.TextLength > 0)
            {
                this.refEmployee.Name = employeeNameEditTextBox.Text;
                this.refEmployee.Surname = employeeSurnameEditTextBox.Text;
                this.refEmployee.Patronymic = employeePatronymicEditTextBox.Text;
                this.refEmployee.Position = employeePositionEditTextBox.Text;
                this.refEmployee.DateOfHiring = employeeHiringDateTimePicker.Value;
                this.refEmployee.Birthday = employeeBirthdayDateTimePicker.Value;
                this.refEmployee.Sex = (Sexes)Enum.Parse(typeof(Sexes), employeeSexSelector.SelectedItem.ToString());
                this.refEmployee.PhoneNumber = eployeePhoneNumberEditTextBox.Text;
                this.refEmployee.Email = employeeEmailEditTextBox.Text;
                this.refEmployee.Address = employeeAddressEditTextBox.Text;
                this.refEmployee.Note = employeeNoteEditTextBox.Text;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Требуется заполнить все обязательные поля!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}