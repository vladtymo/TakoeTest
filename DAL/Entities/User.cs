using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Nickname { get; set; }
        [Required]
        public string Fullname { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public int Gender { get; set; }

        //Navigation
        public virtual ICollection<Result> Results { get; set; }

        public User()
        {
            Results = new HashSet<Result>();
        }
    }
}
