using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels
{
    public class UserViewModel : ViewModelBase
    {
        private string fullName = "";
        private string nickName = "";
        private string password = "";
        private string email = "";
        private int gender = -1;
        private string date = "";

        public string FullName
        {
            get => fullName;
            set => SetProperty(ref fullName, value);
        }
        public string NickName
        {
            get => nickName;
            set => SetProperty(ref nickName, value);
        }
        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }
        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }
        public int Gender
        {
            get => gender;
            set => SetProperty(ref gender, value);
        }
        public string Date
        {
            get => date;
            set => SetProperty(ref date, value);
        }
    }
}
