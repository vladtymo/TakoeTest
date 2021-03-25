using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EntityFramework
{
    class Initializer : DropCreateDatabaseIfModelChanges<TestDb>
    {
        protected override void Seed(TestDb context)
        {
            base.Seed(context);

            context.Users.Add(new Entities.User() { Nickname = "admin1", Email = "kovalkola2@gmail.com", IsMale = true, BirthDate = new DateTime(2004, 12, 18), Password = "qwerty" });
            context.Users.Add(new Entities.User() { Nickname = "admin2", Email = "romanmartyniuk92@gmail.com", IsMale = true, BirthDate = new DateTime(2000, 01, 01), Password = "qwerty" });
            context.Users.Add(new Entities.User() { Nickname = "admin3", Email = "yuriy.budnyk@gmail.com", IsMale = true, BirthDate = new DateTime(1998, 23, 15), Password = "qwerty" });
        }
    }
}
