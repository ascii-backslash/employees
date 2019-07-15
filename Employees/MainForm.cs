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
    public partial class MainForm : Form
    {
        private List<Company> companies = new List<Company>();
        private List<Employee> employees = new List<Employee>();

        private DataBase dataBase = new DataBase(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Work\Employees\Employees\EmployeesData.mdf;Integrated Security=True");   
        
        /// <summary>
        /// При старте программы будет выполнена загрузка списков из базы данных и заполнение TreeView.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            UploadDataFromDataBase();
            FillTreeViewFromCompanyList();

            companyTreeView.Focus();
        }

        /// <summary>
        /// Загружает данные из базы данных в списки компаний и работников.
        /// </summary>
        private void UploadDataFromDataBase()
        {
            //  Очищаем списки.
            companies.Clear();
            employees.Clear();

            companies = dataBase.GetAll<Company>();
            employees = dataBase.GetAll<Employee>();
        }
        /// <summary>
        /// Заполняет дерево компаниями из списка компаний.
        /// </summary>
        private void FillTreeViewFromCompanyList()
        {
            companyTreeView.Nodes.Clear();
            //  Идём по списку компаний.
            foreach (Company company in companies)
            {
                //  Если у компании нет родительской.
                if (company.ParentId == null)
                {
                    //  Создаём дерево.
                    TreeNode tree = new TreeNode();
                    tree.Text = company.Name;
                    tree.Tag = company.Id;
                    //  Выстраиваем его поддерево из дочерних компаний.
                    PopulateSubLevelOfNode(ref tree, company.Id);
                    //  Добавляем узел в TreeView.
                    companyTreeView.Nodes.Add(tree);
                }
            }
            //  Раскроем дерево.
            companyTreeView.ExpandAll();
        }
        /// <summary>
        /// Выстраивает поддерево компаний для заданного узла.
        /// </summary>
        /// <param name="parent">Ссылка на узел, для которого будет построено поддерево.</param>
        /// <param name="id">Уникальный номер родительской компании.</param>
        private void PopulateSubLevelOfNode(ref TreeNode parent, int id)
        {
            Predicate<Company> predicate = delegate (Company company) { return company.ParentId == id; };
            //  Если у компании есть дочерние.
            if (companies.Exists(predicate))
            {
                //  Идём по списку компаний.
                foreach (Company company in companies)
                {
                    //  Если найдена дочерняя компания.
                    if (company.ParentId == id)
                    {
                        //  Создать её узел.
                        TreeNode node = new TreeNode();
                        node.Text = company.Name;
                        node.Tag = company.Id;
                        //  Выстроить её дерево компаний.
                        PopulateSubLevelOfNode(ref node, company.Id);
                        //  Добавить в родительский узел.
                        parent.Nodes.Add(node);
                    }
                }
            }
        }
        /// <summary>
        /// Удаляет работников всех дочерних компаний.
        /// </summary>
        /// <param name="Id">Уникальный номер компании, у дочерних компаний которой будут удалены работники.</param>
        private void DeleteChildCompaniesEmployees(int id)
        {
            //  Идём по списку компаний.
            foreach (Company company in companies)
            {
                //  Если дочерняя компания найдена.
                if (company.ParentId == id)
                {
                    //  Проверим, есть ли у неё свои дочерние компании.
                    Predicate<Company> childCompany = delegate (Company otherCompany) { return otherCompany.ParentId == company.Id; };
                    if (companies.Exists(childCompany))
                    {
                        // Если есть, удалим сначала их работников.
                        DeleteChildCompaniesEmployees(company.Id);
                    }
                    //  Удалим работников из базы данных.
                    foreach (Employee employee in employees)
                    {
                        if (employee.CompanyId == company.Id)
                        {
                            dataBase.DeleteEmployee(employee);
                        }
                    }
                    //  Удалим работников этой компании из списка работников.
                    Predicate<Employee> employeesOfCompany = delegate (Employee employee) { return employee.CompanyId == company.Id; };
                    employees.RemoveAll(employeesOfCompany);
                }
            }
        }
        /// <summary>
        /// Удаляет все дочерние компании из списка компаний.
        /// </summary>
        /// <param name="tree">Дерево компаний. Из его узлов извлекаются Id компаний. Сами узлы не удаляются.</param>
        private void DeleteChildCompanies(TreeNode tree)
        {
            //  Идём по узлам дерева.
            foreach (TreeNode node in tree.Nodes)
            {
                //  Если найдено под-дерево.
                if (node.Nodes.Count > 0)
                {
                    //  Удалить дочерние компании этого дерева.
                    DeleteChildCompanies(node);
                }
                //  Удалить компанию, хранящуюся в узле.
                Predicate<Company> childCompany = delegate (Company company) { return company.Id == (int)node.Tag; };
                Company deletableCompany = companies.Find(childCompany);
                dataBase.DeleteCompany(deletableCompany);
                companies.Remove(deletableCompany);
            }
        }
        /// <summary>
        /// Очищает и заполняет DataGridView работниками выбранной компании.
        /// </summary>
        private void RefreshDataGridView()
        {
            if (companyTreeView.SelectedNode != null)
            {
                employeeDataGridView.Rows.Clear();
                employeeDataGridView.Columns.Clear();

                employeeDataGridView.Columns.Add("Name", "Имя");
                employeeDataGridView.Columns.Add("Surname", "Фамилия");
                employeeDataGridView.Columns.Add("Patronymic", "Отчество");
                employeeDataGridView.Columns.Add("Age", "Возраст");
                employeeDataGridView.Columns.Add("Sex", "Пол");
                employeeDataGridView.Columns.Add("Position", "Должность");
                employeeDataGridView.Columns.Add("PhoneNumber", "Телефон");
                employeeDataGridView.Columns.Add("Email", "E-mail");
                employeeDataGridView.Columns.Add("DateOfHiring", "Дата приёма");
                employeeDataGridView.Columns.Add("Address", "Адрес");
                employeeDataGridView.Columns.Add("Note", "Примечание");

                foreach (Employee employee in employees)
                {
                    if (employee.CompanyId == (int)companyTreeView.SelectedNode.Tag)
                    {
                        employeeDataGridView.Rows.Add(employee.Name, employee.Surname, employee.Patronymic, employee.Age, employee.Sex, employee.Position, employee.PhoneNumber, employee.Email, employee.DateOfHiring.Date.ToLongDateString(), employee.Address, employee.Note);
                        employeeDataGridView.Rows[employeeDataGridView.Rows.Count - 1].Tag = employee.Id;
                    }
                }
            }
        }

        /// <summary>
        /// Добавляет новую компанию.
        /// </summary>
        private void addCompanyButton_Click(object sender, EventArgs e)
        {
            Company company = new Company();

            // Если родительская компания выбрана в TreeView.
            if (companyTreeView.SelectedNode != null)
            {
                company.ParentId = (int)companyTreeView.SelectedNode.Tag;
            }
            else
            {
                // Если не выбрана.
                company.ParentId = null;
            }
            //  Вызываем форму редактора компаний.
            if (new CompanyEditorForm(ref company).ShowDialog() == DialogResult.OK)
            {
                //  Добавляем компанию в базу.
                dataBase.Insert(company);
                //  Обновляем и выводим новые данные.
                UploadDataFromDataBase();
                FillTreeViewFromCompanyList();
            }
        }
        /// <summary>
        /// Редактирует выбранную компанию.
        /// </summary>
        private void editCompanyButton_Click(object sender, EventArgs e)
        {
            if (companyTreeView.SelectedNode != null)
            {
                Predicate<Company> selectedCompany = delegate (Company company) { return company.Id == (int)companyTreeView.SelectedNode.Tag; };
                Company editableCompany = companies.Find(selectedCompany);

                if (new CompanyEditorForm(ref editableCompany).ShowDialog() == DialogResult.OK)
                {
                    dataBase.UpdateCompany(editableCompany);
                    companyInfoTextBox.Clear();
                    UploadDataFromDataBase();
                    FillTreeViewFromCompanyList();
                }    
            }
            else
            {
                MessageBox.Show("Выберите компанию для редактирования!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        /// <summary>
        /// Удаляет выбранную компанию.
        /// </summary>
        private void deleteCompanyButton_Click(object sender, EventArgs e)
        {
            if (companyTreeView.SelectedNode != null)
            {
                Predicate<Company> parentCompany = delegate (Company company) { return company.Id == (int)companyTreeView.SelectedNode.Tag; };               
                Predicate<Employee> parentCompanyEmployees = delegate (Employee employee) { return employee.CompanyId == (int)companyTreeView.SelectedNode.Tag; };

                //  Удаляем родительскую компанию.
                Company deletableParentCompany = companies.Find(parentCompany);
                dataBase.DeleteCompany(deletableParentCompany);
                companies.Remove(deletableParentCompany);

                //  Удаляем работников родительской компании из базы данных.
                foreach (Employee deletableEmployee in employees)
                {
                    if (deletableEmployee.CompanyId == (int)companyTreeView.SelectedNode.Tag)
                    {
                        dataBase.DeleteEmployee(deletableEmployee);
                    }
                }
                //  Удаляем работников из списка работников.
                employees.RemoveAll(parentCompanyEmployees);                         
                //  Удаляем работников дочерних компаний.
                DeleteChildCompaniesEmployees((int)companyTreeView.SelectedNode.Tag);
                //  Удаляем дочерние компании.
                DeleteChildCompanies(companyTreeView.SelectedNode);
                //  Удаляем узел из TreeView.
                companyTreeView.Nodes.Remove(companyTreeView.SelectedNode);
                //  Снимаем выделение на TreeView.
                companyTreeView.SelectedNode = null;
                //  Очищаем блок информации о компании.
                companyInfoTextBox.Clear();
                //  Очищаем DataGrid.
                employeeDataGridView.Rows.Clear();
                employeeDataGridView.Columns.Clear();
            }
            else
            {
                MessageBox.Show("Выберите компанию для удаления!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }      

        /// <summary>
        /// Добавляет сотрудника в выбранную компанию.
        /// </summary>
        private void addEmployeeButton_Click(object sender, EventArgs e)
        {
            if (companyTreeView.SelectedNode != null)
            {
                Employee employee = new Employee();

                employee.CompanyId = (int)companyTreeView.SelectedNode.Tag;

                if (new EmployeeEditorForm(ref employee).ShowDialog() == DialogResult.OK)
                {
                    dataBase.Insert(employee);
                    employees.Add(employee);
                    RefreshDataGridView();
                }
            }
            else
            {
                MessageBox.Show("Выберите компанию, для которой будет добавлен сотрудник!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        /// <summary>
        /// Редактирует выбранного сотрудника компании.
        /// </summary>
        private void editEmployeeButton_Click(object sender, EventArgs e)
        {
            try
            {
                Predicate<Employee> selectedEmployee = delegate (Employee employee) { return employee.Id == (int)employeeDataGridView.SelectedRows[0].Tag; };
                Employee editableEmployee = employees.Find(selectedEmployee);

                if (new EmployeeEditorForm(ref editableEmployee).ShowDialog() == DialogResult.OK)
                {
                    dataBase.UpdateEmployee(editableEmployee);
                    RefreshDataGridView();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Выберите работника для редактирования!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        /// <summary>
        /// Удаляет выбранный объект сотрудника компании.
        /// </summary>
        private void deleteEmployeeButton_Click(object sender, EventArgs e)
        {
            try
            {
                Predicate<Employee> selectedEmployee = delegate (Employee employee) { return employee.Id == (int)employeeDataGridView.SelectedRows[0].Tag; };
                Employee deletableEmployee = employees.Find(selectedEmployee);

                dataBase.DeleteEmployee(deletableEmployee);
                employees.RemoveAll(selectedEmployee);

                RefreshDataGridView();
            }
            catch (Exception)
            {
                MessageBox.Show("Выберите работника для удаления!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// При выборе компании в TreeView выводит информацию о ней и список сотрудников.
        /// </summary>
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Predicate<Company> selectedCompany = delegate (Company _company) { return _company.Id == (int)companyTreeView.SelectedNode.Tag; };
            companyInfoTextBox.Text = companies.Find(selectedCompany).Info;

            RefreshDataGridView();
        }
        /// <summary>
        /// Служит для снятия выделения с компании в TreeView и очистки DataGrid.
        /// </summary>
        private void treeView1_Click(object sender, EventArgs e)
        {
            employeeDataGridView.Rows.Clear();
            employeeDataGridView.Columns.Clear();
            companyTreeView.SelectedNode = null;
            companyInfoTextBox.Clear();
        }
    }
}