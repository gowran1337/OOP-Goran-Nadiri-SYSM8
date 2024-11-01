using Goran_Nadiri_FitTrack_Hemuppgift_Elite.Model;
using Goran_Nadiri_FitTrack_Hemuppgift_Elite.ViewModel;
using System.Windows;

namespace Goran_Nadiri_FitTrack_Hemuppgift_Elite.View
{
    /// <summary>
    /// Interaction logic for WorkoutDetailsWindow.xaml
    /// </summary>
    public partial class WorkoutDetailsWindow : Window
    {

        private UserService userService;

        public WorkoutDetailsWindow(UserService userService)
        {
            InitializeComponent();
            DataContext = new WorkoutDetailsWindowViewModel();
        }
    }
}
