using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfService.DTO
{
    [DataContract]
    public class ResultDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int RightAnswers { get; set; }
        [DataMember]
        public TimeSpan SpentTime { get; set; }

        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public int TestId { get; set; }

        [DataMember]
        public UserDTO User { get; set; }
        [DataMember]
        public TestDTO Test { get; set; }
    }
}