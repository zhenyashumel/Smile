using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using Smile.Entities;

namespace Smile.DAL
{
    public class SmileContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Weekend> Weekends { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Order> Orders { get; set; }

        public SmileContext(string connectionString) : base(connectionString)
        {
            
        }

        public SmileContext()
        {
            
        }
    }
}
