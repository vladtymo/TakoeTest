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
    /// Interaction logic for CreateNewTestWindow.xaml
    /// </summary>
    public partial class CreateNewTestWindow : Window
    {
        CreateNewTestViewModel viewModel = new CreateNewTestViewModel();
        public CreateNewTestWindow()
        {
            InitializeComponent();
            this.DataContext = viewModel;
            list.ItemsSource = viewModel.parts;
            listA.ItemsSource = viewModel.answers;
            cbName.ItemsSource = viewModel.prices;
        }
    }
}
