using DAL.Entities;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class UserService : IUserService
    {
        UnitOfWork unit;
        public UserService()
        {
            unit = new UnitOfWork();
        }

        public bool IsExistNickname(string nickname) => unit.UserRepos.Get(u => u.Nickname == nickname).Count() != 0;
        public bool IsExistEmail(string email) => unit.UserRepos.Get(u => u.Email == email).Count() != 0;

        public bool IsRightPassword(string pass, out string mess)
        {
            mess = String.Empty;

            if (pass.Length < 8)
            {
                mess = "Count of password must be min 8";
                return false;
            }

            bool isOneSmallLetter = false;
            bool isOneBigLetter = false;
            bool isOneDigit = false;

            foreach (var ch in pass)
            {
                if (char.IsDigit(ch))
                    isOneDigit = true;

                else if (char.IsLower(ch))
                    isOneSmallLetter = true;

                else if (char.IsUpper(ch))
                    isOneBigLetter = true;
            }

            if (!isOneSmallLetter)
            {
                mess = "Password must have min one small letter";
                return false;
            }
            if (!isOneBigLetter)
            {
                mess = "Password must have min one big letter";
                return false;
            }
            if (!isOneDigit)
            {
                mess = "Password must have min one digit";
                return false;
            }

            return true;
        }
        public bool IsRightPasswordInUser(User user, string password) => user.Password == password;

        public User GetUserByNickAndPass(string nick, string pass) => unit.UserRepos.Get(u => u.Nickname == nick && u.Password == pass).SingleOrDefault();
        public User GetUserByNick(string nick) => unit.UserRepos.Get(u => u.Nickname == nick).SingleOrDefault();
        public User GetUserByEmail(string email) => unit.UserRepos.Get(u => u.Email == email).SingleOrDefault();

        public void AddNewUser(User user)
        {
            unit.UserRepos.Insert(user);
            unit.Save();
        }
    }
}
