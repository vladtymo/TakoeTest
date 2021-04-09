using Client.ClassesViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for PassingTestWindow.xaml
    /// </summary>
    public partial class PassingTestWindow : Window
    {
        PassingTestViewModel viewModel;
        public PassingTestWindow(TestViewModel model)
        {
            InitializeComponent();
            viewModel = new PassingTestViewModel(model);
            this.DataContext = viewModel;
            list.ItemsSource = viewModel.Answers;
            viewModel.ClosingRequest += (sender, e) => this.Close();
        }
    }

}
