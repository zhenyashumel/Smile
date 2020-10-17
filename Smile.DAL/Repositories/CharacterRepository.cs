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
    public class CharacterRepository:IRepository<Character>
    {
        private SmileContext db;

        public CharacterRepository(SmileContext context)
        {
            db = context;
        }
        public IEnumerable<Character> GetAll()
        {
            return db.Characters.ToList();
        }

        public Character Get(int id)
        {
            return db.Characters.FirstOrDefault(e => e.Id == id);
        }

        public void Create(Character item)
        {
            db.Characters.Add(item);
            db.SaveChanges();
        }

        public void Update(Character item)
        {
            var character = db.Characters.Find(item.Id);

            db.Entry(character).CurrentValues.SetValues(item);
            db.Entry(character).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var character = db.Characters.Find(id);
            if (character != null)
                db.Characters.Remove(character);
            db.SaveChanges();
        }

        public IEnumerable<Character> Find(Func<Character, bool> predicate)
        {
            return db.Characters.Where(predicate).ToList();
        }
    }
}
