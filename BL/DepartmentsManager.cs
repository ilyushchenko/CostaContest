using BL.Models;
using BL.Repositories;
using System;
using System.Linq;

namespace BL
{
    public class DepartmentsManager
    {
        CrmContext _context;

        public DepartmentsManager()
        {
            //TODO: Inject
            _context = Factory.Instance;
        }

        /// <summary>
        /// Предоставляет коллекцию всех отделов
        /// </summary>
        /// <returns></returns>
        public Department[] GetDepartments()
        {
            return _context.Departments.ToArray();
        }


        /// <summary>
        /// Возвращает отделение по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор отдела</param>
        /// <returns></returns>
        public Department GetById(Guid id)
        {
            return _context.Departments.FirstOrDefault(d => d.Id == id);
        }
    }
}
