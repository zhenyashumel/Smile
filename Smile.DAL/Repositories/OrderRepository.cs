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
    public class OrderRepository:IRepository<Order>
    {
        private SmileContext db;

        public OrderRepository(SmileContext context)
        {
            db = context;
        }
        public IEnumerable<Order> GetAll()
        {
            return db.Orders.Include(s=>s.Character).Include(s => s.Employees).Include(s=>s.Language).ToList();
        }

        public Order Get(int id)
        {
            return db.Orders.Include(s => s.Character).Include(s => s.Employees).Include(s => s.Language).FirstOrDefault(e => e.Id == id);
        }

        public void Create(Order item)
        {
            db.Orders.Add(item);
            db.SaveChanges();
        }

        public void Update(Order item)
        {
            var order = db.Orders.Find(item.Id);

            db.Entry(order).CurrentValues.SetValues(item);
            db.Entry(order).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var order = db.Orders.Find(id);
            if (order != null)
                db.Orders.Remove(order);
            db.SaveChanges();
        }

        public IEnumerable<Order> Find(Func<Order, bool> predicate)
        {
            return db.Orders.Include(s=>s.Language).Include(s=>s.Character).Include(s => s.Employees).Where(predicate).ToList();
        }
    }
}
