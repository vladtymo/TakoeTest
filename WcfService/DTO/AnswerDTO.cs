using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfService.DTO
{
    public class AnswerDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsRight { get; set; }

        public int QuestionId { get; set; }

        public QuestionDTO Question { get; set; }
    }
}