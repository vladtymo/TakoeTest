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
    public class ShowResultViewModel :INotifyPropertyChanged
    {
        DelegateCommand okCommand;
        public ICommand OkCommand => okCommand;
        public ShowResultViewModel(int mark, int rightAnswer, TimeSpan time, Action action)
        {
            okCommand = new DelegateCommand(action);
            Mark = mark.ToString();
            Answer = rightAnswer.ToString();
            Time = time.ToString();
        }
        private string mark;

        public string Mark
        {
            get { return mark; }
            set 
            {
                mark = value;
                OnPropertyChanged();
            }
        }
        private string answer;

        public string Answer
        {
            get { return answer; }
            set 
            { 
                answer = value;
                OnPropertyChanged();
            }
        }
        private string time;

        public string Time
        {
            get { return time; }
            set
            {
                time = value;
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
