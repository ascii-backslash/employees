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
    /// Класс "Работник" с полями, идентичными названиям столбцов в таблице базы данных.
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Возвращает или задаёт уникальный номер данного работника.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Возвращает или задаёт имя данного работника.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Возвращает или задаёт фамилию данного работника.
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Возвращает или задаёт отчество данного работника.
        /// </summary>
        public string Patronymic { get; set; }
        /// <summary>
        /// Возвращает или задаёт дату рождения данного работника.
        /// </summary>
        public DateTime Birthday { get; set; }
        /// <summary>
        /// Возвращает возраст работника.
        /// </summary>
        public int Age
        {
            get
            {
                int age = DateTime.Now.Year - this.Birthday.Year;
                if (DateTime.Now.DayOfYear < this.Birthday.DayOfYear) age--;
                return age;
            }
        }
        /// <summary>
        /// Возвращает или задаёт пол данного работника.
        /// </summary>
        public Sexes Sex { get; set; }
        /// <summary>
        /// Возвращает или задаёт адрес электронной почты данного работника.
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Возвращает или задаёт дату устройства на работу.
        /// </summary>
        public DateTime DateOfHiring { get; set; }
        /// <summary>
        /// Возвращает или задаёт номер телефона данного работника.
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Возвращает или задаёт адрес проживания данного работника.
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Возвращает или задаёт заметку о данном работнике.
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        /// Возвращает или задаёт должность данного работника.
        /// </summary>
        public string Position { get; set; }
        /// <summary>
        /// Возвращает или задаёт уникальный номер компании, к которой относится данный работник.
        /// </summary>
        public int CompanyId { get; set; }
        
        /// <summary>
        /// Инициализирует объект класса с полями по умолчанию.
        /// </summary>
        public Employee()
        {
            try
            {
                this.Birthday = DateTime.Today;
                this.DateOfHiring = DateTime.Today;
                this.Sex = Sexes.Мужской;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Инициализирует объект значениями, хранящимися в строке таблицы.
        /// </summary>
        /// <param name="dataRow">Строка с данными.</param>
        public Employee(DataRow dataRow)
        {
            try
            {
                this.Id = Convert.ToInt32(dataRow["Id"]);
                this.Name = dataRow["Name"].ToString();
                this.Surname = dataRow["Surname"].ToString();
                this.Patronymic = dataRow["Patronymic"].ToString();
                this.Birthday = Convert.ToDateTime(dataRow["Birthday"].ToString());
                this.Sex = (Sexes)Convert.ToInt32(dataRow["Sex"]);
                this.Email = dataRow["Email"].ToString();
                this.DateOfHiring = Convert.ToDateTime(dataRow["DateOfHiring"].ToString());
                this.PhoneNumber = dataRow["PhoneNumber"].ToString();
                this.Address = dataRow["Address"].ToString();
                this.Note = dataRow["Note"].ToString();
                this.Position = dataRow["Position"].ToString();
                this.CompanyId = Convert.ToInt32(dataRow["CompanyId"]);
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        /// <summary>
        /// Возвращает всю хранящуюся информацию о работнике в виде строки.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Name + " " + this.Surname + " " + this.Patronymic + " " + this.Birthday.Date.ToString("yyyyMMdd") + " " + this.Sex + " " + this.Position + " " + this.PhoneNumber + " " + this.Email + " " + this.DateOfHiring.Date.ToString("yyyyMMdd") + " " + this.Address + " " + this.Note;
        }
    }
}
