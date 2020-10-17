using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smile.DAL.Repositories;
using Smile.Entities;

namespace Smile.BLL
{
    public static class EmployeesService
    {
        public static IEnumerable<Employee> ChooseEmployees(SmileData db, DateTime date, Language language,
           Character character)
        {
            var employees = db.Employees.Find(e =>
                e.Languages.Contains(language) &&
                e.Weekends.FirstOrDefault(w => w.Day == date) == null &&
                character.IsMale == e.IsMale);

            if(employees.Count() == 1)
                return employees;

            else
            {
                var count =  employees.Select(e=>e.Orders.Count).Min();
                return db.Employees.Find(e => e.Orders.Count == count);
            }
        }
        
    }
}
