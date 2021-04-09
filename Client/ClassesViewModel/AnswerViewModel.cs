using Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ClassesViewModel
{
    public class AnswerViewModel : ViewModelBase
    {
        private int index = -1;
        public int Index
        {
            get => index;
            set => SetProperty(ref index, value);
        }

        private string text;
        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        private bool isRight;
        public bool IsRight
        {
            get => isRight;
            set => SetProperty(ref isRight, value);
        }
    }
}
