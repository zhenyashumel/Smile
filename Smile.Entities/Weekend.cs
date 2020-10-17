using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smile.Entities
{
    public class Weekend
    {
        public int Id { get; set; }
        public DateTime Day { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }

        public Weekend()
        {
               Employees = new List<Employee>();
        }
    }
}
