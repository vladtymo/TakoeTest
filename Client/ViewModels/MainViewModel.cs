using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Client
{
    public class MainViewModel : INotifyPropertyChanged
    {
        CreateNewTestWindow createTestWindow;

        public HomeViewModel homeVM { get; set; }
        public LastTestViewModel lastTestVM { get; set; }
        public ShowTestViewModel showTestVM { get; set; }

        private RelayCommand homeViewCommand;
        private RelayCommand lastTestViewCommand;
        private RelayCommand showTestViewCommand;
        private DelegateCommand openCreateTestWindowCommand;

        public ICommand HomeViewCommand => homeViewCommand;
        public ICommand LastTestViewCommand => lastTestViewCommand;
        public ICommand ShowTestViewCommand => showTestViewCommand;
        public ICommand OpenCreateTestWindowCommand => openCreateTestWindowCommand;

        public MainViewModel()
        {
            homeVM = new HomeViewModel();
            lastTestVM = new LastTestViewModel();
            showTestVM = new ShowTestViewModel();


            CurrentView = homeVM;


            homeViewCommand = new RelayCommand(o =>
            {
                CurrentView = homeVM;
            });
            lastTestViewCommand = new RelayCommand(o =>
            {
                CurrentView = lastTestVM;
            });
            showTestViewCommand = new RelayCommand(o =>
            {
                CurrentView = showTestVM;
            });
            openCreateTestWindowCommand = new DelegateCommand(openCreateTestWinow);
        }

        private object currentView;
        public object CurrentView
        {
            get { return currentView; }
            set
            {
                currentView = value;
                OnPropertyChanged();
            }
        }


        public void openCreateTestWinow()
        {
            createTestWindow = new CreateNewTestWindow();
            createTestWindow.ShowDialog();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
