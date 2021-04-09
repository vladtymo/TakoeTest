using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public double Value { get; set; }

        //Foreign keys
        public int TestId { get; set; }

        //Navigation
        public virtual IEnumerable<Answer> Answers { get; set; }
        public virtual Test Test { get; set; }

        public Question()
        {
            Answers = new HashSet<Answer>();
        }
    }
}
