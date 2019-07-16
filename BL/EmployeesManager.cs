using BL.Models;
using BL.Repositories;
using System;
using System.Data.Entity;
using System.Linq;

namespace BL
{
    public class EmployeesManager
    {
        CrmContext _context;

        public EmployeesManager()
        {
            //TODO: Inject
            _context = Factory.Instance;
        }

        /// <summary>
        /// Возвращаем сотрудника по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор сотрудника</param>
        /// <returns></returns>
        public Employee GetById(decimal id)
        {
            return _context.Employees.FirstOrDefault(e => e.ID == id);
        }

        /// <summary>
        /// Создает сотрудника
        /// </summary>
        /// <param name="employee">Экземпляр сотрудника</param>
        /// <returns></returns>
        public bool Create(Employee employee)
        {
            try
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Обновляет информауию о сотруднике
        /// </summary>
        /// <param name="employee">Экземпляр сотрудника</param>
        /// <returns></returns>
        public bool Update(Employee employee)
        {
            try
            {
                _context.Entry<Employee>(employee).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

    }
}
