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
    public class WeekendsRepository:IRepository<Weekend>
    {
        private SmileContext db;

        public WeekendsRepository(SmileContext context)
        {
            db = context;
        }
        public IEnumerable<Weekend> GetAll()
        {
            return db.Weekends.Include(s => s.Employees).ToList();
        }

        public Weekend Get(int id)
        {
            return db.Weekends.FirstOrDefault(e => e.Id == id);
        }

        public void Create(Weekend item)
        {
            db.Weekends.Add(item);
            db.SaveChanges();
        }

        public void Update(Weekend item)
        {
            var weekend = db.Weekends.Find(item.Id);

            db.Entry(weekend).CurrentValues.SetValues(item);
            db.Entry(weekend).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var weekend = db.Weekends.Find(id);
            if (weekend != null)
                db.Weekends.Remove(weekend);
            db.SaveChanges();
        }

        public IEnumerable<Weekend> Find(Func<Weekend, bool> predicate)
        {
            return db.Weekends.Include(s => s.Employees).Where(predicate).ToList();
        }
    }
}
