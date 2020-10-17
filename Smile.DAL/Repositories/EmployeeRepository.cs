using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smile.DAL.Interfaces;
using Smile.Entities;

namespace Smile.DAL.Repositories
{
    public class EmployeeRepository:IRepository<Employee>
    {
        private SmileContext db;

        public EmployeeRepository(SmileContext context)
        {
            db = context;
        }
        public IEnumerable<Employee> GetAll()
        {
            return db.Employees.Include(s=>s.Languages).Include(s=>s.Weekends).ToList();
        }

        public Employee Get(int id)
        {
            return db.Employees.FirstOrDefault(e => e.Id == id);
        }

        public void Create(Employee item)
        {
            db.Employees.Add(item);
            db.SaveChanges();
        }

        public void Update(Employee item)
        {
            var employee = db.Employees.Find(item.Id);

            db.Entry(employee).CurrentValues.SetValues(item);
            db.Entry(employee).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var employee = db.Employees.Find(id);
            if (employee != null)
                db.Employees.Remove(employee);
            db.SaveChanges();
        }

        public IEnumerable<Employee> Find(Func<Employee, bool> predicate)
        {
            return db.Employees.Include(s=>s.Languages).Include(s => s.Weekends).Where(predicate).ToList();
        }
    }
}
