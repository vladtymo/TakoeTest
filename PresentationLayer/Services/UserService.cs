using DAL.Entities;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer
{
    class UserService
    {
        UnitOfWork unit;

        public UserService()
        {
            unit = new UnitOfWork();
        }

        //Exists
        public bool IsExistNickname(string nickname) => unit.UserRepos.Get(u => u.Nickname == nickname).Count() != 0;
        public bool IsExistEmail(string email) => unit.UserRepos.Get(u => u.Email == email).Count() != 0;

        //Checks
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

            if(!isOneSmallLetter)
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

        //Get users
        public User GetUserByNickAndPass(string nick, string pass) => unit.UserRepos.Get(u => u.Nickname == nick && u.Password == pass).SingleOrDefault();
        public User GetUserByNick(string nick) => unit.UserRepos.Get(u => u.Nickname == nick).SingleOrDefault();
        public User GetUserByEmail(string email) => unit.UserRepos.Get(u => u.Email == email).SingleOrDefault();

        //Add
        public void AddNewUser(User user)
        {
            unit.UserRepos.Insert(user);
            unit.Save();
        }
    }
}
