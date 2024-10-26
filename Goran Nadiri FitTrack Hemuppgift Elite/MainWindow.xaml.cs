using Goran_Nadiri_FitTrack_Hemuppgift_Elite.Model;
using Goran_Nadiri_FitTrack_Hemuppgift_Elite.ViewModel;
using System.Windows;

namespace Goran_Nadiri_FitTrack_Hemuppgift_Elite
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static object ViewModel;

        public MainWindow()
        {
            InitializeComponent();
            UserService userService = new UserService();

            MainWindowViewModel viewModel = new MainWindowViewModel(userService);
            DataContext = viewModel;
        }
    }
}