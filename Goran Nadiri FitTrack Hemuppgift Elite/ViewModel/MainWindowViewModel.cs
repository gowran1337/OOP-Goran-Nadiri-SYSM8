using Goran_Nadiri_FitTrack_Hemuppgift_Elite.Model;
using Goran_Nadiri_FitTrack_Hemuppgift_Elite.NVVM;
using Goran_Nadiri_FitTrack_Hemuppgift_Elite.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Goran_Nadiri_FitTrack_Hemuppgift_Elite.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {
        UserService userService = new UserService();
        internal static ObservableCollection<Model.Data.User> Users;
        //internal static ObservableCollection<Model.Data.User> Users { get; set; } = new ObservableCollection<Model.Data.User>();

        public RelayCommand SignIn => new RelayCommand(execute => SignInCommand());
        public RelayCommand OpenRegisterWindow => new RelayCommand(execute => OpenRegisterWindowCommand());

        public MainWindowViewModel(UserService userService)
        {
            this.userService = userService;
            
        }


        public MainWindowViewModel()
        {
            Users = new ObservableCollection<Model.Data.User>();
            Users = userService.GetUsers();
        }
        private void SignInCommand()
        {
            var User = Users.FirstOrDefault(u => u.Username == LoginUsername && u.Password == LoginPassword);
            if (User != null)
            {
                WorkoutWindow workoutWindow = new WorkoutWindow();
                workoutWindow.Show(); 
                    
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void OpenRegisterWindowCommand()
        {
           
           RegisterWindow registerWindow = new RegisterWindow();
           registerWindow.Show();
          //kod för att stänga main window
        }
        private string _password;
        private string _username;

        public string LoginUsername
        {
            get => _username;
            set
            {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanged();
                }

            }

        }
        public string LoginPassword
        {
            get => _password;
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
