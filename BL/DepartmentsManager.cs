using BL.Models;
using BL.Repositories;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

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
        /// Предоставляет коллекцию всех отделов асинхронно
        /// </summary>
        /// <returns></returns>
        public Task<Department[]> GetDepartmentsAsync()
        {
            return _context.Departments.ToArrayAsync();
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

        /// <summary>
        /// Создает отдел
        /// </summary>
        /// <param name="department">Экземпляр отдела</param>
        /// <returns></returns>
        public bool Create(Department department)
        {
            try
            {
                _context.Departments.Add(department);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Обновляет информауию об отделе
        /// </summary>
        /// <param name="department">Экземпляр отдела</param>
        /// <returns></returns>
        public bool Update(Department department)
        {
            try
            {
                _context.Entry<Department>(department).State = EntityState.Modified;
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
