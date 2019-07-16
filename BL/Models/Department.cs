using System;

namespace BL.Models
{
    public class Department
    {
        public Guid Id { get; set; }

        public Department ParentDepartmen {get;set;}

        public Guid ParentDepartmentId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }
    }
}
