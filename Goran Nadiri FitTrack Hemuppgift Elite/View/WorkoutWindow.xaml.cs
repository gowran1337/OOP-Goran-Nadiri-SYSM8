using Goran_Nadiri_FitTrack_Hemuppgift_Elite.Model;
using System.Windows;
using Goran_Nadiri_FitTrack_Hemuppgift_Elite.ViewModel;


namespace Goran_Nadiri_FitTrack_Hemuppgift_Elite.View
{
    /// <summary>
    /// Interaction logic for WorkoutWindow.xaml
    /// </summary>
    public partial class WorkoutWindow : Window
    {
        private UserService userService;


        public WorkoutWindow(UserService userService)
        {
            InitializeComponent();

            DataContext = new WorkoutWindowViewModel(UserService.Instance);
            
        }
    }
}
