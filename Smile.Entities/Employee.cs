using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smile.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsMale { get; set; } //1-male, 0-female
        public virtual ICollection<Weekend> Weekends { get; set; }
        public virtual ICollection<Language> Languages { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public string Contact { get; set; }
        public Employee()
        {
            Weekends = new List<Weekend>();
            Languages = new List<Language>();
            Orders = new List<Order>();
        }

    }
}
