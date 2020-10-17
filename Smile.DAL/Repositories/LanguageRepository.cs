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
    public class LanguageRepository: IRepository<Language>
    {
        private SmileContext db;

        public LanguageRepository(SmileContext context)
        {
            db = context;
        }
        public IEnumerable<Language> GetAll()
        {
            return db.Languages.Include(s => s.Employees).ToList();
        }

        public Language Get(int id)
        {
            return db.Languages.FirstOrDefault(e => e.Id == id);
        }

        public void Create(Language item)
        {
            db.Languages.Add(item);
            db.SaveChanges();
        }

        public void Update(Language item)
        {
            var language = db.Languages.Find(item.Id);

            db.Entry(language).CurrentValues.SetValues(item);
            db.Entry(language).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var language = db.Languages.Find(id);
            if (language != null)
                db.Languages.Remove(language);
            db.SaveChanges();
        }

        public IEnumerable<Language> Find(Func<Language, bool> predicate)
        {
            return db.Languages.Include(s => s.Employees).Where(predicate).ToList();
        }
    }
}
