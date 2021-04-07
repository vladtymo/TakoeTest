using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfService.DTO
{
    public class QuestionDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public double Value { get; set; }

        //Foreign keys
        public int TestId { get; set; }

        //Navigation
        public TestDTO Test { get; set; }
    }
}