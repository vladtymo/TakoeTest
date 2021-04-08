using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace Client
{
    public class TopPeopleTestViewModel : INotifyPropertyChanged
    {
        //public SimpTest test;

        //public Test()
        //{
        //    StartCommand = new DelegateCommand(startCommand);
        //}

        //private DelegateCommand startCommand;
        //public ICommand StartCommand => startCommand;

        //public void Start()
        //{
        //    MessageBox.Show("Start test");
        //}

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }

    public class SimpTest : INotifyPropertyChanged //спрощений клас тесту
    {
        private int countQuestions;
        public int CountQuestions
        {
            get { return countQuestions; }
            set
            {
                countQuestions = value;
                OnPropertyChanged();
            }
        }

        private int lastPass;
        public int LastPass
        {
            get { return lastPass; }
            set
            {
                lastPass = value;
                OnPropertyChanged();
            }
        }

        ObservableCollection<UserTestResult> users = new ObservableCollection<UserTestResult>();

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    public class UserTestResult : INotifyPropertyChanged // результат конкретного користувача
    {
        private string fullName;
        public string FullName
        {
            get { return fullName; }
            set
            {
                if (fullName != value)
                {
                    fullName = value;
                    OnPropertyChanged();
                }
            }
        }

        private int countCurrentAnswers;
        public int CountCurrentAnswers
        {
            get { return countCurrentAnswers; }
            set
            {
                countCurrentAnswers = value;
                OnPropertyChanged();
            }
        }

        private TimeSpan timeResult;
        public TimeSpan TimeResult
        {
            get { return timeResult; }
            set
            {
                timeResult = value;
                OnPropertyChanged();
            }
        }
        private int mark;
        public int Mark
        {
            get { return mark; }
            set
            {
                if (mark != value)
                {
                    mark = value;
                    OnPropertyChanged();
                }
            }
        }
        private string authorName;
        public string AuthorName
        {
            get { return authorName; }
            set
            {
                authorName = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
