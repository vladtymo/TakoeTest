using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class TopPeopleTestViewModel : INotifyPropertyChanged
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

        private string time;
        public string Time
        {
            get { return time; }
            set
            {
                if (time != value)
                {
                    time = value;
                    OnPropertyChanged();
                }
            }
        }
        private string correctAnswer;
        public string CorrectAnswer
        {
            get { return correctAnswer; }
            set
            {
                if (correctAnswer != value)
                {
                    correctAnswer = value;
                    OnPropertyChanged();
                }
            }
        }
        private string mark;
        public string Mark
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
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
