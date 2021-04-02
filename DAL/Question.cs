using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public double Value { get; set; }

        //Foreign keys
        public int CategoryId { get; set; }

        //Navigation
        public IEnumerable<Answer> Answers { get; set; }
        public Category Category { get; set; }

        public Question()
        {
            Answers = new HashSet<Answer>();
        }
    }
}
