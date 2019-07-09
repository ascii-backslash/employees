using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace DAL
{
    /// <summary>
    /// Класс "Компания" с полями, идентичными названиям стобцов в таблице базы данных.
    /// </summary>
    public class Company
    {
        /// <summary>
        /// Возвращает или задаёт уникальный номер компании.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Возвращает или задаёт имя компании.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Возвращает или задаёт информацию о компании.
        /// </summary>
        public string Info { get; set; }
        /// <summary>
        /// Возвращает или задаёт уникальный номер компании-родителя.
        /// </summary>
        public int? ParentId { get; set; }
        
        /// <summary>
        /// Инициализирует объект класса с полями по умолчанию.
        /// </summary>
        public Company()
        {
            
        }
        /// <summary>
        /// Инициализирует объект значениями, хранящимися в строке таблицы.
        /// </summary>
        /// <param name="dataRow">Строка с данными.</param>
        public Company(DataRow dataRow)
        {
            try
            {
                this.Id = Convert.ToInt32(dataRow["Id"]);
                this.Name = dataRow["Name"].ToString();
                this.Info = dataRow["Info"].ToString();

                if (!DBNull.Value.Equals(dataRow["ParentId"]))
                    this.ParentId = (int?)dataRow["ParentId"];
                else
                    this.ParentId = null;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        /// <summary>
        /// Возвращает всю хранящуюся информацию о компании в виде строки.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Name + " " + this.Info;
        }
    }
}
