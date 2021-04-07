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
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            listTopPeopleTest.Items.Add(new TopPeopleTestViewModel() { FullName = "Good Man", Time = "12:15", CorrectAnswer = "10/10", Mark = "10" });
        }
    }
}
