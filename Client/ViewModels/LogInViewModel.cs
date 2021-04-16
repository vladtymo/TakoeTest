using AutoMapper;
using Client.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Client.UserServiceReference;
using System.Threading;
using Client.TestServiceReference;

namespace Client
{
    public class LogInViewModel : ViewModelBase
    {
        private RegisterWindow registerWindow;
        private LogInWindow logInWindow;
        private UserServiceClient userService;
        private IMapper mapper;

        private bool isErrorMessage = false;

        public bool IsErrorMessage
        {
            get { return isErrorMessage; }
            set
            {
                isErrorMessage = value;
                OnPropertyChanged();
            }
        }
        private string errorMessage ="Incorrect Login";

        public string ErrorMessage
        {
            get { return errorMessage; }
            set 
            {
                errorMessage = value;
                OnPropertyChanged();
            }
        }


        // Я (Коля) виніс цей об'єкт сюди для того щоб він завчасно не видалився. Воно працює - не лізь, будь ласка.
        // Цей об'єкт хоче жити. Не знищуй його
        MainWindow mainWind;

        private UserViewModel userViewModel;
        public UserViewModel UserViewModel
        {
            get => userViewModel;
            set => SetProperty(ref userViewModel, value);
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
            TestServiceClient tmp1 = new TestServiceClient();
            var tmp = tmp1.GetAllTests();

            openRegisterWindowCommand = new DelegateCommand(OpenRegisterWindow);
            cancelCommand = new DelegateCommand(Cancel);
            loginCommand = new DelegateCommand(Login);
            registerCommand = new DelegateCommand(Register, Permission);
            userService = new UserServiceClient();
            userViewModel = new UserViewModel();

            IConfigurationProvider config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<UserDTO, UserViewModel>()
                    .ForMember(dst => dst.FullName, opt => opt.MapFrom(src => src.Fullname))
                    .ForMember(dst => dst.NickName, opt => opt.MapFrom(src => src.Nickname))
                    .ForMember(dst => dst.Password, opt => opt.MapFrom(src => src.Password))
                    .ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.Email))
                    .ForMember(dst => dst.Gender, opt => opt.MapFrom(src => src.Gender))
                    .ForMember(dst => dst.Date, opt => opt.MapFrom(src => src.BirthDate.ToString()));

                    cfg.CreateMap<UserViewModel, UserDTO>()
                    .ForMember(dst => dst.Fullname, opt => opt.MapFrom(src => src.FullName))
                    .ForMember(dst => dst.Nickname, opt => opt.MapFrom(src => src.NickName))
                    .ForMember(dst => dst.Password, opt => opt.MapFrom(src => src.Password))
                    .ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.Email))
                    .ForMember(dst => dst.Gender, opt => opt.MapFrom(src => src.Gender))
                    .ForMember(dst => dst.BirthDate, opt => opt.MapFrom(src => src.Date));
                });
            mapper = new Mapper(config);

            userViewModel.PropertyChanged += (sender, args) =>
                        {
                            if (args.PropertyName == nameof(UserViewModel.NickName)
                            || args.PropertyName == nameof(UserViewModel.FullName)
                            || args.PropertyName == nameof(UserViewModel.Password)
                            || args.PropertyName == nameof(UserViewModel.Email)
                            || args.PropertyName == nameof(UserViewModel.Gender)
                            || args.PropertyName == nameof(UserViewModel.Date))
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
            UserDTO user = mapper.Map<UserDTO>(userViewModel);
            userService.AddNewUser(user);
            if (logInWindow == null)
                logInWindow = new LogInWindow();
            CloseWindow();
            logInWindow.ShowDialog();
        }
        public bool Permission()
        {
            if (UserViewModel.NickName.Length == 0 || UserViewModel.FullName.Length == 0
                || UserViewModel.Email.Length == 0 || UserViewModel.Password.Length < 8
                || UserViewModel.Gender == -1 || UserViewModel.Date.Length == 0)
                return false;
            return true;
        }
        public async void Login()
        {
            UserDTO user = await userService.GetUserByEmailOrNicknameAsync(userViewModel.NickName);
            if (user == null)
            {
                _ = Task.Run(() =>
                  {
                      ErrorMessage = "Incorrect Login";
                      IsErrorMessage = true;
                      Thread.Sleep(1500);
                      IsErrorMessage = false;
                  });
            }
            else
            {
                if (userService.IsRightPasswordInUser(user, userViewModel.Password))
                {
                    mainWind = new MainWindow(mapper.Map<UserViewModel>(user));
                    CloseWindow();
                    mainWind.ShowDialog();
                }
                else
                {
                    _ = Task.Run(() =>
                    {
                        ErrorMessage = "Incorrect Login";
                        IsErrorMessage = true;
                        Thread.Sleep(1500);
                        IsErrorMessage = false;
                    });
                }
            }
        }
    }
}
