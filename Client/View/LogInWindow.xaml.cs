using System;
using System.Collections.Generic;
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
    /// Interaction logic for LogInWindow.xaml
    /// </summary>
    public partial class LogInWindow : Window
    {
        private LogInViewModel viewModel = new LogInViewModel();
        public LogInWindow()
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            {
                ((dynamic)this.DataContext).UserViewModel.Password = ((PasswordBox)sender).Password;
            }
        }

        private void Label_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
