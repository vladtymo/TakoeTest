using DAL.Entities;
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

        //Foreign keys
        public int CategoryId { get; set; }

        //Navigation prop
        public virtual Category Category { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<Result> Results { get; set; }

        public Test()
        {
            Questions = new HashSet<Question>();
            Results = new HashSet<Result>();
        }
    }
}