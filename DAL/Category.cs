using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Test> Tests { get; set; }

        public Category()
        {
            Tests = new HashSet<Test>();
        }
    }
}
