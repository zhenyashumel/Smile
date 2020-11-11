using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smile.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public float Raiting { get; set; }

        public int? CharacterId { get; set; }
        public Character Character { get; set; }

        public TimeSpan Time { get; set; }

        public string PhoneNumber { get; set; }

        public  bool InProgress { get; set; }

        public int? LanguageId { get; set; }
        public Language Language { get; set; }
        public Order()
        {
            Employees = new List<Employee>();
        }
    }
}
