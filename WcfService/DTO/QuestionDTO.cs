using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfService.DTO
{
    [DataContract]
    public class QuestionDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Text { get; set; }
        [DataMember]
        public double Value { get; set; }

        [DataMember]
        public int TestId { get; set; }

        [DataMember]
        public IEnumerable<AnswerDTO> Answers { get; set; }

        [DataMember]
        public TestDTO Test { get; set; }
    }
}