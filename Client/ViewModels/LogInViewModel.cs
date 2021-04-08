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

namespace Client
{
    public class LogInViewModel : ViewModelBase
    {
        private RegisterWindow registerWindow;
        private LogInWindow logInWindow;
        private UserServiceClient userService;
        private IMapper mapper;

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
            openRegisterWindowCommand = new DelegateCommand(OpenRegisterWindow);
            cancelCommand = new DelegateCommand(Cancel);
            loginCommand = new DelegateCommand(Login);
            registerCommand = new DelegateCommand(Register);
            //registerCommand = new DelegateCommand(Register, Permission);
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

            PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(userViewModel.NickName) || args.PropertyName == nameof(userViewModel.FullName) || args.PropertyName == nameof(userViewModel.Password)
                          || args.PropertyName == nameof(userViewModel.Email) || args.PropertyName == nameof(userViewModel.Gender) || args.PropertyName == nameof(userViewModel.Date))
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
            if (userViewModel.NickName.Length == 0 || userViewModel.FullName.Length == 0 || userViewModel.Email.Length == 0 || userViewModel.Password.Length < 8
                || userViewModel.Gender == -1 || userViewModel.Date.Length == 0)
                return false;
            return true;
        }
        public async void Login()
        {
            UserDTO user = await userService.GetUserByNickAsync(userViewModel.NickName);
            if (user == null)
                user = await userService.GetUserByEmailAsync(userViewModel.NickName);
            if (user == null)
                MessageBox.Show("Invalid login");
            else
            {
                if (userService.IsRightPasswordInUser(user, userViewModel.Password))
                    MessageBox.Show("Ok. Prohodi dorohysha");
                else
                    MessageBox.Show("INVALID PASSWORD");
            }
        }
    }
}
