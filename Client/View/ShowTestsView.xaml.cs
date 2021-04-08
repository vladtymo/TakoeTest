﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Client
{
    /// <summary>
    /// Interaction logic for ShowTestsView.xaml
    /// </summary>
    public partial class ShowTestsView : UserControl
    {
        ObservableCollection<string> a = new ObservableCollection<string>();
        ShowTestViewModel viewModel = new ShowTestViewModel();
        public ShowTestsView()
        {
            InitializeComponent();
            this.DataContext = viewModel;
            list.ItemsSource = viewModel.Tests;
        }

    }
}
