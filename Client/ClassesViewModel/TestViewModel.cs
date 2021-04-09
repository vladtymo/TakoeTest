using Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ClassesViewModel
{
    public class TestViewModel : ViewModelBase
    {
        public int Id { get; set; }

        private string name;
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public IEnumerable<QuestionViewModel> Questions { get; set; }
    }
}
