using Goran_Nadiri_FitTrack_Hemuppgift_Elite.Model;
using Goran_Nadiri_FitTrack_Hemuppgift_Elite.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace Goran_Nadiri_FitTrack_Hemuppgift_Elite.View
{
    /// <summary>
    /// Interaction logic for ForgetPasswordWindow.xaml
    /// </summary>
    public partial class ForgetPasswordWindow : Window
    {
        public ForgetPasswordWindow(UserService userService)
        {
            InitializeComponent();
            ForgetPasswordViewModel forgetPasswordViewModel = new ForgetPasswordViewModel(userService);
            this.DataContext = forgetPasswordViewModel;
        }
    }
}
