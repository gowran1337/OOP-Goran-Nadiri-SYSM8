using System.Windows;
using Goran_Nadiri_FitTrack_Hemuppgift_Elite.Model;
using Goran_Nadiri_FitTrack_Hemuppgift_Elite.ViewModel;

namespace Goran_Nadiri_FitTrack_Hemuppgift_Elite.View
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow(UserService userService)
        {
            InitializeComponent();
            RegisterWindowViewModel RegViewModel = new RegisterWindowViewModel(UserService.Instance);
            this.DataContext = RegViewModel;
        }
    }
}
