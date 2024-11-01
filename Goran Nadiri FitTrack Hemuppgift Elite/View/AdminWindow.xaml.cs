using Goran_Nadiri_FitTrack_Hemuppgift_Elite.Model;
using Goran_Nadiri_FitTrack_Hemuppgift_Elite.ViewModel;
using System.Windows;

namespace Goran_Nadiri_FitTrack_Hemuppgift_Elite.View
{
    public partial class AdminWindow : Window
    {
        private UserService userService;

        public AdminWindow(UserService userService)
        {
            InitializeComponent();
            DataContext = new AdminWindowViewModel(UserService.Instance);

        }
    }
}
