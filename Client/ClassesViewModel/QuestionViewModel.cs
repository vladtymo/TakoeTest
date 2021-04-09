using Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ClassesViewModel
{
    public class QuestionViewModel : ViewModelBase
    {
        public ObservableCollection<AnswerViewModel> Answers = new ObservableCollection<AnswerViewModel>();
        private string question;
        private int price;
        public string Question
        {
            get => question;
            set => SetProperty(ref question, value);
        }

        public int Price
        {
            get => price;
            set => SetProperty(ref price, value);
        }
    }
}
