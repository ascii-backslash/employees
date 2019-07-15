using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

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
        /// Возвращает список объектов указанного класса из базы данных.
        /// </summary>
        /// <typeparam name="T">Класс возвращаемых объектов.</typeparam>
        /// <returns></returns>
        public List<T> GetAll<T>() where T : class

        {
            //  Определяем класс объекта.
            Type type = typeof(T);
            //  Пытаемся найти подходящий public конструктор, принимающий DataRow в качестве параметра.
            ConstructorInfo constructorInfo = type.GetConstructor(new Type[] { typeof(DataRow) });
            //  Если конструктор найден.
            if (constructorInfo != null)
            {
                DataTable table = new DataTable();
                dataAdapter = new SqlDataAdapter("SELECT * FROM [" + type.Name + "]", sqlConnection);
                dataAdapter.Fill(table);

                List<T> objectsList = new List<T>();

                //  Пробегаемся по строкам таблицы БД и заполняем объектами список.
                foreach (DataRow dataRow in table.Rows)
                {
                    //  Вызываем найденный конструктор и заполняем список.
                    objectsList.Add((T)constructorInfo.Invoke(new object[] { dataRow } ));
                }

                return objectsList;
            }
            else return null;
        }
        /// <summary>
        /// Добавляет заданный объект указанного класса в базу данных.
        /// </summary>
        /// <typeparam name="T">Класс объекта.</typeparam>
        /// <param name="entity">Объект класса.</param>
        public void Insert<T>(T entity) where T : class
        {
            try
            {
                //  Определяем класс объекта.
                Type type = typeof(T);
                //  Заполняем массив свойств этого объекта.
                PropertyInfo[] propertyInfos = type.GetProperties();
                //  Создаём массив строк имён свойств (Все свойства, кроме Id).
                string[] propertyNames = new string[propertyInfos.Length - 1];
                //  Бежим по массиву свойств объекта, начиная со второго.
                for (int i = 1; i < propertyInfos.Length; i++)
                {
                    propertyNames[i - 1] = "@" + propertyInfos[i].Name;
                }
                //  Формируем SQL-запрос.
                string cmdText = "INSERT INTO [" + type.Name + "] VALUES(" + string.Join(", ", propertyNames) + ")";

                sqlConnection.Open();
                sqlCommand = new SqlCommand(cmdText, sqlConnection);
                //  Добавляем необходимые параметры в запрос.
                for (int i = 1; i < propertyInfos.Length; i++)
                {
                    object value = type.InvokeMember(propertyInfos[i].Name, BindingFlags.GetProperty, null, entity, null);
                    sqlCommand.Parameters.AddWithValue(propertyNames[i - 1], value ?? DBNull.Value);
                }
                //  Выполняем запрос.
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update<T>()
        {
            try
            {

            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Delete<T>()
        {
            try
            {

            }
            catch (Exception)
            {
                throw;
            }
        }
        public T Get<T>()
        {
            return default(T);
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
