using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Answer
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsRight { get; set; }

        //Foreign keys
        public int QuestionId { get; set; }

        //Navigation prop
        public Question Question { get; set; }
    }
}