using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public TimeSpan PassageTime { get; set; }
        public IEnumerable<Question> Questions { get; set; }

        //Foreign keys
        public int CategoryId { get; set; }

        //Navigation prop
        public Category Category { get; set; }

        public Test()
        {
            Questions = new HashSet<Question>();
        }
    }
}