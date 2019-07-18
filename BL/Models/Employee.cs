using BL.Extensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BL.Models
{
    [Table("Empoyee")]
    public class Employee
    {
        private string firstName;
        private string surName;
        private DateTime dateOfBirth;
        private string position;
        private string patronymic;
        private string docSeries;
        private string docNumber;
        private Department department;

        public Employee()
        {
            ID = -1;
            DateOfBirth = DateTime.Today;
        }

        public Employee(Department department)
        {
            ID = -1;
            DateOfBirth = DateTime.Today;
            Department = department;
        }

        /// <summary>
        /// Идентифакатор
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal ID { get; set; }

        /// <summary>
        /// Имя сотрудника
        /// </summary>
        [Required]
        [StringLength(50)]
        public string FirstName
        {
            get => firstName;
            set => firstName = value
                    .LessOrThrow(0, "Имя не должно быть пустым")
                    .GreaterOrThrow(50, "Имя не должно превышать 50 симаолов");
        }

        /// <summary>
        /// Фамилия сотрудника
        /// </summary>
        [Required]
        [StringLength(50)]
        public string SurName
        {
            get => surName;
            set => surName = value
                    .LessOrThrow(0, "Фамилия не должна быть пустой")
                    .GreaterOrThrow(50, "Фамилия не должна превышать 50 симаолов");
        }

        /// <summary>
        /// Отчество сотрудника
        /// </summary>
        [StringLength(50)]
        public string Patronymic
        {
            get => patronymic;
            set => patronymic = value?.GreaterOrThrow(50, "Отчество не должно превышать 50 симаолов");
        }

        /// <summary>
        /// Дата рождения сотрудника
        /// </summary>
        public DateTime DateOfBirth
        {
            get => dateOfBirth; set
            {
                if (value > DateTime.Today)
                {
                    throw new Exception("Дата рождения не может быть в будущем");
                }

                dateOfBirth = value;
            }
        }

        /// <summary>
        /// Серия документа
        /// </summary>
        [StringLength(4)]
        public string DocSeries
        {
            get => docSeries;
            set => docSeries = value?.GreaterOrThrow(4, "Серия не должна превышать 4 символа");
        }

        /// <summary>
        /// Номер документа
        /// </summary>
        [StringLength(6)]
        public string DocNumber
        {
            get => docNumber;
            set => docNumber = value?.GreaterOrThrow(6, "Номер не должен превышать 6 символов");
        }

        /// <summary>
        /// Должность
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Position
        {
            get => position;
            set => position = value
                .LessOrThrow(0, "Должность не должна быть пустой")
                .GreaterOrThrow(50, "Должность не должна превышать 50 симаолов");
        }

        /// <summary>
        /// Идентификатор отдела
        /// </summary>
        public Guid DepartmentID { get; set; }

        /// <summary>
        /// Отдел работы
        /// </summary>
        public virtual Department Department
        {
            get => department;
            set
            {
                department = value ?? throw new Exception("Необходимо указать отдел");
                DepartmentID = value.Id;
            }
        }

        /// <summary>
        /// Возраст сотрудника
        /// </summary>
        public int Age
        {
            get
            {
                var nowDate = DateTime.Today;
                var age = nowDate.Year - DateOfBirth.Year;
                if (DateOfBirth > nowDate.AddYears(-age)) age--;

                return age;
            }
        }
    }
}