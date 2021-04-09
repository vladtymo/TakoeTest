using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfService.DTO
{
    [DataContract]
    [Serializable]
    public class UserDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nickname { get; set; }
        [DataMember]
        public string Fullname { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public DateTime BirthDate { get; set; }
        [DataMember]
        public int Gender { get; set; }
    }
}