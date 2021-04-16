using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfService.DTO
{
    [DataContract]
    public class AnswerDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Text { get; set; }
        [DataMember]
        public bool IsRight { get; set; }

        [DataMember]
        public int QuestionId { get; set; }

        //[DataMember]
        //public QuestionDTO Question { get; set; }
    }
}