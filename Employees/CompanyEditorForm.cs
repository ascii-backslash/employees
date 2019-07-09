using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DAL;

namespace Employees
{
    public partial class CompanyEditorForm : Form
    {
        Company refCompany;
        /// <summary>
        /// Форма для добавления или редактирования компании.
        /// </summary>
        /// <param name="company">Ссылка на объект компании.</param>
        /// <param name="addMode">Режим работы формы.</param>
        public CompanyEditorForm(ref Company company)
        {
            InitializeComponent();

            //  Подстраиваем вид формы под задачу.
            switch (company.Id)
            {
                case 0:
                    this.Text = "Добавить компанию...";
                    break;
                default:
                    this.Text = "Редактировать компанию...";
                    break;
            }

            //  Сохраняем ссылку на объект компании.
            this.refCompany = company;            
            //  Заполняем поле имени компании.
            this.companyNameEditTextBox.Text = refCompany.Name;        
            //  Заполняем поле информации о компании.
            this.companyInfoEditTextBox.Text = refCompany.Info;
        }
        
        private void okButton_Click(object sender, EventArgs e)
        {
            if (companyNameEditTextBox.TextLength > 0)
            {
                this.refCompany.Name = companyNameEditTextBox.Text;
                this.refCompany.Info = companyInfoEditTextBox.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Требуется заполнить хотя бы имя компании!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }          
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }       
    }
}