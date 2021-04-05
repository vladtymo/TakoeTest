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
    public class CreateNewTestViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<PartOfTest> parts = new ObservableCollection<PartOfTest>();
        public ObservableCollection<Answer> answers = new ObservableCollection<Answer>();
        public ObservableCollection<int> prices = new ObservableCollection<int>();

        private RelayCommand removeCommand;
        public ICommand RemoveCommand => removeCommand;
        private DelegateCommand addPartCommand;
        public ICommand AddPartCommand => addPartCommand;
        private DelegateCommand addAnswerCommand;
        public ICommand AddAnswer => addAnswerCommand;
        private DelegateCommand saveCommand;
        public ICommand SaveCommand => saveCommand;
        private DelegateCommand cancelCommand;

        public ICommand CancelCommand => cancelCommand;

        public CreateNewTestViewModel()
        {
            for (int i = 0; i < 10; i++)
            {
                prices.Add(i + 1);
            }
            removeCommand = new RelayCommand(obj =>
            {
                int index = (int)obj;
                if (index != -1)
                {

                    answers.RemoveAt(index);
                    selectedPart.Answers.Clear();
                    for (int i = 0; i < answers.Count; i++)
                    {
                        answers[i].Index = i;
                        selectedPart.Answers.Add(answers[i]);
                    }
                }
            });
            addPartCommand = new DelegateCommand(addPart);
            addAnswerCommand = new DelegateCommand(addAnswer);
            saveCommand = new DelegateCommand(save);
            cancelCommand = new DelegateCommand(cancel);
        }

        private bool visibility = false;
        public bool Visibility
        {
            get { return visibility; }
            set
            {
                visibility = value;
                OnPropertyChanged();
            }
        }
        private PartOfTest selectedPart;

        public PartOfTest SelectedPart
        {
            get { return selectedPart; }
            set
            {
                selectedPart = value;
                OnPropertyChanged();
                Question = selectedPart.Question;
                answers.Clear();
                SelectePrice = selectedPart.Price;
                foreach (var item in selectedPart.Answers)
                {
                    answers.Add(item);
                }
            }
        }
        private string question;

        public string Question
        {
            get { return question; }
            set
            {
                question = value;
                OnPropertyChanged();
                SelectedPart.Question = Question;
            }
        }
        private int selectePrice;

        public int SelectePrice
        {
            get { return selectePrice; }
            set
            {
                selectePrice = value;
                OnPropertyChanged();
                SelectedPart.Price = selectePrice;
            }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }


        public void addPart()
        {
            parts.Add(new PartOfTest());
            Visibility = true;
        }
        public void addAnswer()
        {
            answers.Add(new Answer() { Index = answers.Count });
            selectedPart.Answers.Add(answers[answers.Count - 1]);
        }
        public void save()
        {
            MessageBox.Show("Save new test");
        }
        public void cancel()
        {
            MessageBox.Show("Cancel");
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
    public class Answer : INotifyPropertyChanged
    {
        private int index = -1;
        public int Index
        {
            get { return index; }
            set
            {
                index = value;
                OnPropertyChanged();
            }
        }
        private string text;
        public string Text
        {
            get { return text; }
            set
            {
                text = value;
                OnPropertyChanged();
            }
        }

        private bool isRight;

        public bool IsRight
        {
            get { return isRight; }
            set
            {
                isRight = value;
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
    public class PartOfTest : INotifyPropertyChanged
    {
        public ObservableCollection<Answer> Answers = new ObservableCollection<Answer>();
        private string question;
        public string Question
        {
            get { return question; }
            set
            {
                question = value;
                OnPropertyChanged();
            }
        }
        private int price;

        public int Price
        {
            get { return price; }
            set 
            {
               price = value;
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
