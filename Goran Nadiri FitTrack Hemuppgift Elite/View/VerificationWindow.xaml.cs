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

        public VerificationWindow(UserService userService, string verificationCode)
        {
            InitializeComponent();
            var viewModel = new VerificationWindowViewModel(userService);
            viewModel.TheVerificationCode = verificationCode; // Set the verification code in the ViewModel
            DataContext = viewModel; // Set DataContext for data binding
        }
    }
}
