using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Result
    {
        public int Id { get; set; }
        public int RightAnswers { get; set; }

        [NotMapped]
        public double Mark { get => RightAnswers / Test.Questions.Count() * 10; }
        public TimeSpan SpentTime { get; set; }

        //Foreign Keys
        public int UserId { get; set; }
        public int TestId { get; set; }

        //Navigation
        public virtual User User { get; set; }
        public virtual Test Test { get; set; }

        public Result(User user, Test test)
        {
            UserId = user.Id;
            TestId = test.Id;
        }

        public void AddRightAnswer() => RightAnswers++;
    }
}
