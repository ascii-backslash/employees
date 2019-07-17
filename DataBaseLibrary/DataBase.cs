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
        /// <summary>
        /// Производит обновление данных указанного объекта заданного класса в базе данных.
        /// </summary>
        /// <typeparam name="T">Класс объекта.</typeparam>
        /// <param name="entity">Объект класса.</param>
        public void Update<T>(T entity)
        {
            try
            {
                //  Определяем класс объекта.
                Type type = typeof(T);
                //  Заполняем массив свойств этого объекта.
                PropertyInfo[] propertyInfos = type.GetProperties();
                //  Создаём массив строк имён свойств.
                string[] propertyNames = new string[propertyInfos.Length];
                propertyNames[0] = "@" + propertyInfos[0].Name;
                
                //  Формируем SQL-запрос.
                string cmdText = "UPDATE [" + type.Name + "] SET ";
                //  Бежим по массиву свойств объекта, начиная со второго.
                for (int i = 1; i < propertyInfos.Length; i++)
                {
                    propertyNames[i] = "@" + propertyInfos[i].Name;
                    cmdText += propertyInfos[i].Name + "=" + propertyNames[i];
                    if ((i + 1) != propertyInfos.Length) cmdText += ", ";
                }
                cmdText += " WHERE Id=@Id";

                sqlConnection.Open();
                sqlCommand = new SqlCommand(cmdText, sqlConnection);
                //  Добавляем необходимые параметры в запрос.
                for (int i = 0; i < propertyInfos.Length; i++)
                {
                    object value = type.InvokeMember(propertyInfos[i].Name, BindingFlags.GetProperty, null, entity, null);
                    sqlCommand.Parameters.AddWithValue(propertyNames[i], value ?? DBNull.Value);
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
        /// <summary>
        /// Удаляет объект указанного класса по уникальному номеру из базы данных.
        /// </summary>
        /// <typeparam name="T">Класс объекта.</typeparam>
        /// <param name="Id">Уникальный номер.</param>
        public void Delete<T>(int Id) where T : class
        {
            try
            {
                Type type = typeof(T);
                sqlConnection.Open();
                sqlCommand = new SqlCommand("DELETE FROM [" + type.Name + "] WHERE Id=@Id", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Id", Id);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Возвращает объект заданного класса из таблицы данных по уникальному номеру.
        /// </summary>
        /// <typeparam name="T">Класс объекта.</typeparam>
        /// <param name="Id">Уникальный номер объекта.</param>
        /// <returns></returns>
        public T Get<T>(int Id) where T : class
        {
            //  Определяем класс объекта.
            Type type = typeof(T);
            //  Пытаемся найти подходящий public конструктор, принимающий DataRow в качестве параметра.
            ConstructorInfo constructorInfo = type.GetConstructor(new Type[] { typeof(DataRow) });
            //  Если конструктор найден.
            if (constructorInfo != null)
            {
                DataTable table = new DataTable();
                dataAdapter = new SqlDataAdapter("SELECT * FROM[" + type.Name + "] WHERE Id=" + Id, sqlConnection);
                dataAdapter.Fill(table);

                return (T)constructorInfo.Invoke(new object[] { table.Rows[0] });
            }
            else return default(T);
        }
    }
}
