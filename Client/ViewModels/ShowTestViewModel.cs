using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Client
{
    public class ShowTestViewModel : INotifyPropertyChanged
    {
        //

        //
        public ObservableCollection<TestInfo> Tests = new ObservableCollection<TestInfo>();

        public ShowTestViewModel()
        {
            for (int i = 0; i < 10; i++)
            {
                Tests.Add(new TestInfo() { Name = "New Test" });
                Tests.Add(new TestInfo() { Name = "Old Test" });
                Tests.Add(new TestInfo() { Name = "My Test" });
                Tests.Add(new TestInfo() { Name = "Test" });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
    public class TestInfo : INotifyPropertyChanged
    {
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
        PassingTestWindow passingTest;
        private RelayCommand startTestCommand;
        public ICommand StartTestCommand => startTestCommand;
        public TestInfo()
        {
            startTestCommand = new RelayCommand(o =>
            {
                passingTest = new PassingTestWindow(Name);
                passingTest.ShowDialog();
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
