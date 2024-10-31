using Goran_Nadiri_FitTrack_Hemuppgift_Elite.Model;
using System.Windows;

namespace Goran_Nadiri_FitTrack_Hemuppgift_Elite.View
{
    /// <summary>
    /// Interaction logic for UserDetailsWindow.xaml
    /// </summary>
    public partial class UserDetailsWindow : Window
    {
        public UserDetailsWindow()
        {
        }

        public UserDetailsWindow(UserService userService)
        {
            InitializeComponent();
            UserDetailsViewModel userDetailsViewModel = new(UserService.Instance);
            this.DataContext = userDetailsViewModel;
        }
    }
}
 