using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WcfService;

namespace Client
{
    public class LogInViewModel : INotifyPropertyChanged
    {
        private RegisterWindow registerWindow;
        private LogInWindow logInWindow;
        private UserService userService;

        private string fullName = "";
        public string FullName
        {
            get => fullName;
            set
            {
                fullName = value;
                OnPropertyChanged();
            }
        }
        private string nickName = "";
        public string NickName
        {
            get => nickName;
            set
            {
                nickName = value;
                OnPropertyChanged();
            }
        }
        private string password = "";
        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }
        private string email = "";
        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }
        private int gender = -1;
        public int Gender
        {
            get => gender;
            set
            {
                gender = value;
                OnPropertyChanged();
            }
        }
        private string date = "";
        public string Date
        {
            get => date;
            set
            {
                if (value != null)
                {
                    date = value;
                    OnPropertyChanged();
                }
            }
        }


        private Command openRegisterWindowCommand;
        private Command cancelCommand;
        private Command registerCommand;
        private Command loginCommand;
        public ICommand OpenRegisterWindowCommand => openRegisterWindowCommand;
        public ICommand CancelCommand => cancelCommand;
        public ICommand RegisterCommand => registerCommand;
        public ICommand LoginCommand => loginCommand;
        public LogInViewModel()
        {
            openRegisterWindowCommand = new DelegateCommand(OpenRegisterWindow);
            cancelCommand = new DelegateCommand(Cancel);
            loginCommand = new DelegateCommand(Login);
            registerCommand = new DelegateCommand(Register, Permission);
            userService = new UserService();

            PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(NickName) || args.PropertyName == nameof(FullName) || args.PropertyName == nameof(Password)
                          || args.PropertyName == nameof(Email) || args.PropertyName == nameof(Gender) || args.PropertyName == nameof(Date))
                {
                    registerCommand.RaiseCanExecuteChanged();
                }
            };
        }
        public void OpenRegisterWindow()
        {
            if (registerWindow == null)
                registerWindow = new RegisterWindow();
            CloseWindow();
            registerWindow.ShowDialog();
        }
        public void Cancel()
        {
            if (logInWindow == null)
                logInWindow = new LogInWindow();
            CloseWindow();
            logInWindow.ShowDialog();
        }
        private void CloseWindow()
        {
            foreach (Window item in Application.Current.Windows)
            {
                if (item.DataContext == this) item.Close();
            }
        }
        public void Register()
        {
            User user = new User() { Fullname = fullName, Nickname = nickName, BirthDate = DateTime.Parse(date), Email = email, Gender = gender, Password = password };
            userService.AddNewUser(user);
            //MessageBox.Show($"{user.Fullname}, {user.Nickname} {user.BirthDate}, {user.Email}, {user.Password}, {user.Gender}");
            if (logInWindow == null)
                logInWindow = new LogInWindow();
            CloseWindow();
            logInWindow.ShowDialog();
        }
        public bool Permission()
        {
            if (NickName.Length == 0 || FullName.Length == 0 || Email.Length == 0 || Password.Length < 8 || Gender == -1 || Date.Length == 0)
                return false;
            return true;
        }
        public void Login()
        {
            MessageBox.Show("LOGIN");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
