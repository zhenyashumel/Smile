using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smile.Entities
{
    public class Language
    {
        public int Id { get; set; }
        public string Lang { get; set; }

        public ICollection<Employee> Employees  { get; set; }

        public Language()
        {
               Employees = new List<Employee>();
        }
    }
}
