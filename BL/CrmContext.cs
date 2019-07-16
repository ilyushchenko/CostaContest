using System.Data.Entity;
using BL.Models;

namespace BL
{
    /// <summary>
    /// �������� ���� ������
    /// </summary>
    internal partial class CrmContext : DbContext
    {
        public CrmContext()
            : base("name=CrmConnection")
        {
        }

        /// <summary>
        /// ��������� �������
        /// </summary>
        public virtual DbSet<Department> Departments { get; set; }

        /// <summary>
        /// ��������� �����������
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
