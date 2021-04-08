using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Client
{
    /// <summary>
    /// Interaction logic for TestIntroWindow.xaml
    /// </summary>
    public partial class TestIntroWindow : Window
    {
        public TestIntroWindow()
        {
            InitializeComponent();
            SimpTest simpTest = new SimpTest() { CountQuestions = 10, LastPass = 7 };
            this.DataContext = simpTest;
            listTopPeopleTest.Items.Add(new UserTestResult() { AuthorName = "Koval Kolya", FullName = "Oleksandr Zhyhula", TimeResult = new TimeSpan(0, 15, 25), CountCurrentAnswers = 10, Mark = 10 });
            listTopPeopleTest.Items.Add(new UserTestResult() { AuthorName = "Batka", FullName = "Oleksandr Chernij", TimeResult = new TimeSpan(0, 12, 20), CountCurrentAnswers = 9, Mark = 9 });
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Test Started");
        }
    }
}
