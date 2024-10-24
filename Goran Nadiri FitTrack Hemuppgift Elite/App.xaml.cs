using Goran_Nadiri_FitTrack_Hemuppgift_Elite.Model;
using Goran_Nadiri_FitTrack_Hemuppgift_Elite.ViewModel;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Goran_Nadiri_FitTrack_Hemuppgift_Elite
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            UserService userService = new UserService();
            MainWindowViewModel window = new MainWindowViewModel(userService);
            
        }
    }

}
