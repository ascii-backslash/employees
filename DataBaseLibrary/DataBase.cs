using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// Класс для работы с базой данных, заданной по строке подключения.
    /// </summary>
    public class DataBase
    {
        private SqlConnection sqlConnection;
        private SqlDataAdapter dataAdapter;
        private SqlCommand sqlCommand;

        /// <summary>
        /// Возвращает или задаёт объект типа <seealso cref="DataTable"/>.
        /// </summary>
        public DataTable Table { get; set; }

        /// <summary>
        /// Инициализирует объект для работы с базой данных.
        /// </summary>
        /// <param name="connectionString">Строка подключения.</param>
        /// <param name="_tableName">Имя таблицы в этой базе данных.</param>
        public DataBase(string connectionString)
        {
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                dataAdapter = new SqlDataAdapter();
                Table = new DataTable();
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        /// <summary>
        /// Заполняет таблицу компаниями из базы данных.
        /// </summary>
        public void FillTableCompanies()
        {
            try
            {
                Table = new DataTable();
                dataAdapter = new SqlDataAdapter("SELECT * FROM [Company]", sqlConnection);
                dataAdapter.Fill(Table);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Добавляет компанию в базу данных.
        /// </summary>
        /// <param name="company">Объект компании.</param>
        public void InsertCompany(Company company)
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("INSERT INTO [Company] VALUES(@Name, @Info, @ParentId)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Name", company.Name);
                sqlCommand.Parameters.AddWithValue("@Info", company.Info);
                sqlCommand.Parameters.AddWithValue("@ParentId", company.ParentId);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Обновляет данные о компании в базе данных.
        /// </summary>
        /// <param name="company">Объект компании.</param>
        public void UpdateCompany(Company company)
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("UPDATE [Company] SET Name=@Name, Info=@Info, ParentId=@ParentId WHERE Id=@Id", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Id", company.Id);
                sqlCommand.Parameters.AddWithValue("@Name", company.Name);
                sqlCommand.Parameters.AddWithValue("@Info", company.Info);
                sqlCommand.Parameters.AddWithValue("@ParentId", company.ParentId);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Удаляет компанию из базы данных.
        /// </summary>
        /// <param name="company">Объект компании.</param>
        public void DeleteCompany(Company company)
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("DELETE FROM [Company] WHERE Id=@Id", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Id", company.Id);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Заполняет таблицу сотрудниками из базы данных.
        /// </summary>
        public void FillTableEmployees()
        {
            try
            {
                Table = new DataTable();
                dataAdapter = new SqlDataAdapter("SELECT * FROM [Employee]", sqlConnection);
                dataAdapter.Fill(Table);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Добавляет сотрудника в базу данных.
        /// </summary>
        /// <param name="employee">Объект сотрудника.</param>
        public void InsertEmployee(Employee employee)
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("INSERT INTO [Employee] VALUES(@Name, @Surname, @Patronymic, @Birthday, @Sex, @Position, @PhoneNumber, @Email, @DateOfHiring, @Address, @Note, @CompanyId)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Name", employee.Name);
                sqlCommand.Parameters.AddWithValue("@Surname", employee.Surname);
                sqlCommand.Parameters.AddWithValue("@Patronymic", employee.Patronymic);
                sqlCommand.Parameters.AddWithValue("@Birthday", employee.Birthday);
                sqlCommand.Parameters.AddWithValue("@Sex", employee.Sex);
                sqlCommand.Parameters.AddWithValue("@Position", employee.Position);
                sqlCommand.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
                sqlCommand.Parameters.AddWithValue("@Email", employee.Email);
                sqlCommand.Parameters.AddWithValue("@DateOfHiring", employee.DateOfHiring);
                sqlCommand.Parameters.AddWithValue("@Address", employee.Address);
                sqlCommand.Parameters.AddWithValue("@Note", employee.Note);
                sqlCommand.Parameters.AddWithValue("@CompanyId", employee.CompanyId);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Обновляет запись сотрудника компании.
        /// </summary>
        /// <param name="employee">Объект сотрудника.</param>
        public void UpdateEmployee(Employee employee)
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("UPDATE [Employee] SET Name=@Name, Surname=@Surname, Patronymic=@Patronymic, Birthday=@Birthday, Sex=@Sex, Position=@Position, PhoneNumber=@PhoneNumber, Email=@Email, DateOfHiring=@DateOfHiring, Address=@Address, Note=@Note WHERE Id=@Id", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Id", employee.Id);
                sqlCommand.Parameters.AddWithValue("@Name", employee.Name);
                sqlCommand.Parameters.AddWithValue("@Surname", employee.Surname);
                sqlCommand.Parameters.AddWithValue("@Patronymic", employee.Patronymic);
                sqlCommand.Parameters.AddWithValue("@Birthday", employee.Birthday);
                sqlCommand.Parameters.AddWithValue("@Sex", employee.Sex);
                sqlCommand.Parameters.AddWithValue("@Position", employee.Position);
                sqlCommand.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
                sqlCommand.Parameters.AddWithValue("@Email", employee.Email);
                sqlCommand.Parameters.AddWithValue("@DateOfHiring", employee.DateOfHiring);
                sqlCommand.Parameters.AddWithValue("@Address", employee.Address);
                sqlCommand.Parameters.AddWithValue("@Note", employee.Note);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Удаляет работника из базы данных.
        /// </summary>
        /// <param name="employee">Объект работника.</param>
        public void DeleteEmployee(Employee employee)
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("DELETE FROM [Employee] WHERE Id=@Id", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Id", employee.Id);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
