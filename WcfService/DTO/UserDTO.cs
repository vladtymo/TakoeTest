using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfService.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Fullname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public int Gender { get; set; }
    }
}