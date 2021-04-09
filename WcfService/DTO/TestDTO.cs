using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfService.DTO
{
    [DataContract]
    [Serializable]
    public class TestDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public TimeSpan PassageTime { get; set; }

        [DataMember]
        public int CategoryId { get; set; }

        [DataMember]
        public QuestionDTO[] Questions { get; set; }
        [DataMember]
        public CategoryDTO Category { get; set; }
    }
}