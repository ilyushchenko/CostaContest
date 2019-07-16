using System.Data.Entity;
using BL.Models;

namespace BL
{
    /// <summary>
    /// Контекст базы данных
    /// </summary>
    internal partial class CrmContext : DbContext
    {
        public CrmContext()
            : base("name=CrmConnection")
        {
        }

        /// <summary>
        /// Коллекция отделов
        /// </summary>
        public virtual DbSet<Department> Departments { get; set; }

        /// <summary>
        /// Коллекция сотрудников
        /// </summary>
        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .HasMany(e => e.SubDepartmenents)
                .WithOptional(e => e.ParentDepartmen)
                .HasForeignKey(e => e.ParentDepartmentId);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Empoyees)
                .WithRequired(e => e.Department)
                .HasForeignKey(e => e.DepartmentID)
                .WillCascadeOnDelete(false);
        }
    }
}
