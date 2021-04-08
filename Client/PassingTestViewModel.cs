using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Client
{
    public class PassingTestViewModel : INotifyPropertyChanged
    {
        //lists for tessting
        List<Question> Questions;
        List<_Answer> _Answers;
        //
        private DateTime start;
        private DateTime end;
        private TimeSpan time;
        public ObservableCollection<_Answer> Answers = new ObservableCollection<_Answer>();
        private string selecteQuestion;

        public string SelecteQuestion
        {
            get { return selecteQuestion; }
            set
            {
                selecteQuestion = value;
                OnPropertyChanged();
            }
        }
        private int number;

        public int Number
        {
            get { return number; }
            set
            {
                number = value;
                OnPropertyChanged();
            }
        }
        private int allNumber;

        public int AllNumber
        {
            get { return allNumber; }
            set
            {
                allNumber = value;
                OnPropertyChanged();
            }
        }
        private string btnName;

        public string BtnName
        {
            get { return btnName; }
            set
            {
                btnName = value;
                OnPropertyChanged();
            }
        }
        private int mark;
        public int Mark 
        {
            get { return mark; }
            set
            {
                mark = value;
                OnPropertyChanged();
            }
        }
        public int RightAnswers { get; set; }

        DelegateCommand nextCommand;
        public ICommand NextCommand => nextCommand;
        DelegateCommand exitCommand;
        public ICommand ExitCommand => exitCommand;

        public PassingTestViewModel(string testName)
        {
            //
            Questions = new List<Question>()
            {
                new Question(){Text = "Hello?", AnswersId = new List<int>(){2,4,6,8}, Price = 2},
                new Question(){Text = "What is your teacher's name?", AnswersId = new List<int>(){1,3,5,7,9}, Price = 3 },
                new Question(){Text = "?", AnswersId = new List<int>(){10,11,12}, Price = 1}
            };
            _Answers = new List<_Answer>()
            {
                new _Answer(){Id=1, Text="Anton", IsRight=false},
                new _Answer(){Id=2, Text="Hello", IsRight=false},
                new _Answer(){Id=3, Text="Vlad", IsRight=true},
                new _Answer(){Id=4, Text="Goodbye", IsRight=false},
                new _Answer(){Id=5, Text="Ivan", IsRight=false},
                new _Answer(){Id=6, Text="Hi", IsRight=false},
                new _Answer(){Id=7, Text="Olia", IsRight=false},
                new _Answer(){Id=8, Text="Pruwet", IsRight=true},
                new _Answer(){Id=9, Text="Denis", IsRight=false},
                new _Answer(){Id=10, Text="...", IsRight=false},
                new _Answer(){Id=11, Text="?", IsRight=false},
                new _Answer(){Id=12, Text="*****!", IsRight=true},
            };
            //

            start = DateTime.Now;
            Mark = 0;
            RightAnswers = 0;
            BtnName = "Next";
            Number = 1;
            AllNumber = Questions.Count;
            SelecteQuestion = Questions[Number - 1].Text;
            foreach (var item in Questions[Number - 1].AnswersId)
            {
                Answers.Add(_Answers.Where(a => a.Id == item).FirstOrDefault());
            }
            nextCommand = new DelegateCommand(Next);
            exitCommand = new DelegateCommand(OnClosingRequest);
        }

        public void Next()
        {
            if (Questions.Count > Number)
            {
                CountRightAnswer();
                Number++;
                SelecteQuestion = Questions[Number - 1].Text;
                Answers.Clear();
                foreach (var item in Questions[Number - 1].AnswersId)
                {
                    Answers.Add(_Answers.Where(a => a.Id == item).FirstOrDefault());
                }
                if (Questions.Count == Number)
                    BtnName = "Save";
            }
            else
            {
                CountRightAnswer();
                end = DateTime.Now;
                time = end - start;
                //....
                MessageBox.Show($"Right answers: {RightAnswers} Mark: {Mark} Time: {time}");
                OnClosingRequest();
            }
        }
        private void CountRightAnswer()
        {
            bool check = false;
            foreach (var item in Answers)
            {
                if (item.IsEdit != item.IsRight)
                {
                    check = true;
                    break;
                }
            }
            if (!check)
            {
                Mark += Questions[Number - 1].Price;
                RightAnswers++;
            }
        }

        public event EventHandler ClosingRequest;

        protected void OnClosingRequest()
        {
            if (this.ClosingRequest != null)
            {
                this.ClosingRequest(this, EventArgs.Empty);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    //classes for tessting this viewModel
    public class Question
    {
        public string Text { get; set; }
        public int Price { get; set; }
        private List<int> answersId;

        public List<int> AnswersId
        {
            get { return answersId; }
            set { answersId = value; }
        }
    }
    public class _Answer
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsEdit { get; set; }
        public bool IsRight { get; set; }
    }
}
