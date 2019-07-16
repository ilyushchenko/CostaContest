using System;

namespace BL.Models
{
    class Employee
    {
        public Guid Id { get; set; }

        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }
        public string SurName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string DocSeries { get; set; }
        public string DocNumber { get; set; }
        public string Position { get; set; }

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