using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfService.DTO
{
    public class ResultDTO
    {
        public int Id { get; set; }
        public int RightAnswers { get; set; }
        public TimeSpan SpentTime { get; set; }

        //Foreign Keys
        public int UserId { get; set; }
        public int TestId { get; set; }

        //Navigation
        public UserDTO User { get; set; }
        public TestDTO Test { get; set; }
    }
}