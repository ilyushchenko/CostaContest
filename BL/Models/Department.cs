using BL.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BL.Models
{
    [Table("Department")]
    public class Department
    {
        private string name;
        private string code;

        public Department()
        {
            SubDepartmenents = new List<Department>();
            Empoyees = new List<Employee>();
        }

        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Идентификатор родительского отдела
        /// </summary>
        public Guid? ParentDepartmentId { get; set; }

        /// <summary>
        /// Код отдела
        /// </summary>
        [StringLength(10)]
        public string Code { get => code; set => code = value.GreaterOrThrow(50, "Код не должен превышать 10 символов"); }

        /// <summary>
        /// Название отдела
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Name
        {
            get => name;
            set => name = value
                  .LessOrThrow(0, "Наименование не должно быть пустым")
                  .GreaterOrThrow(50, "наименование не должно превышать 50 симаолов");
        }

        public Department ParentDepartmen { get; set; }

        public virtual ICollection<Department> SubDepartmenents { get; set; }

        public virtual ICollection<Employee> Empoyees { get; set; }
    }
}
