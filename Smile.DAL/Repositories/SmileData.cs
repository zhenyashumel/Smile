using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smile.DAL.Interfaces;
using Smile.Entities;

namespace Smile.DAL.Repositories
{
    public class SmileData
    {
        private SmileContext _db;
        private IRepository<Employee> _employeeRepo;
        private IRepository<Language> _languageRepo;
        private IRepository<Weekend> _weekendRepo;
        private IRepository<Character> _characterRepo;
        private IRepository<Order> _orderRepo;
        private bool isDisposed = false;
        public SmileData(string connectionString)
        {
            _db = new SmileContext(connectionString);
        }

        public IRepository<Employee> Employees => _employeeRepo ?? (_employeeRepo = new EmployeeRepository(_db));

        public IRepository<Language> Languages => _languageRepo ?? (_languageRepo = new LanguageRepository(_db));
        public IRepository<Weekend> Weekends => _weekendRepo ?? (_weekendRepo = new WeekendsRepository(_db));
        public IRepository<Character> Characters => _characterRepo ?? (_characterRepo = new CharacterRepository(_db));
        public IRepository<Order> Orders => _orderRepo ?? (_orderRepo = new OrderRepository(_db));


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public virtual void Dispose(bool disposing)
        {
            if (isDisposed) return;
            if (disposing)
            {
                _db.Dispose();

            }
            isDisposed = true;
        }
        public void Save()
        {
            _db.SaveChanges();
        } 
    }
}
