﻿using Goran_Nadiri_FitTrack_Hemuppgift_Elite.Model;
using Goran_Nadiri_FitTrack_Hemuppgift_Elite.ViewModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Goran_Nadiri_FitTrack_Hemuppgift_Elite
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal static object viewModel;

        public MainWindow()
        {
            InitializeComponent();
            UserService userService = new UserService();

            MainWindowViewModel viewModel = new MainWindowViewModel(userService);
            DataContext = viewModel;
        }
    }
}