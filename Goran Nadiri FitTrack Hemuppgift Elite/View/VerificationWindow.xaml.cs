using Goran_Nadiri_FitTrack_Hemuppgift_Elite.Model;
using Goran_Nadiri_FitTrack_Hemuppgift_Elite.ViewModel;
using System.Windows;

namespace Goran_Nadiri_FitTrack_Hemuppgift_Elite.View
{
    /// <summary>
    /// Interaction logic for VerificationWindow.xaml
    /// </summary>
    public partial class VerificationWindow : Window
    {

        public VerificationWindow(UserService userService, string TheVerificationCode)
        {
            InitializeComponent();
            VerificationWindowViewModel verificationWindowViewModel = new VerificationWindowViewModel(userService);
            this.DataContext = verificationWindowViewModel;

        }
    }
}
