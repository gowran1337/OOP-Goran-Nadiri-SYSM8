using Goran_Nadiri_FitTrack_Hemuppgift_Elite.Model;
using Goran_Nadiri_FitTrack_Hemuppgift_Elite.NVVM;
using Goran_Nadiri_FitTrack_Hemuppgift_Elite.View;
using Microsoft.Azure.Amqp.Framing;
using System.Collections.ObjectModel;
using System.Windows;
using Data = Goran_Nadiri_FitTrack_Hemuppgift_Elite.Model.Data;

namespace Goran_Nadiri_FitTrack_Hemuppgift_Elite.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        UserService userService;
        
        public ObservableCollection<User> Users;
        

        public RelayCommand SignInCommand => new RelayCommand(execute => SignIn());
        public RelayCommand OpenRegisterWindowCommand => new RelayCommand(execute => OpenRegisterWindow());
        public RelayCommand ForgotPasswordCommand => new RelayCommand(execute => OpenForgotPasswordWindow());

        public MainWindowViewModel(UserService userService)
        {
            this.userService = userService;
            Users = userService.GetUsers();
        }

        private void OpenForgotPasswordWindow()
        {
            ForgetPasswordWindow forgetPasswordWindow = new ForgetPasswordWindow(userService);
            forgetPasswordWindow.Show();
        }

        public void SignIn()
        {
            var User = Users.FirstOrDefault(u => u.Username == LoginUsername && u.Password == LoginPassword);
            if (User != null)
            {
                
                WorkoutWindow workoutWindow = new WorkoutWindow(userService);
                workoutWindow.Show();
                CurrentUser = User;
               
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void OpenRegisterWindow()
        {
           
           RegisterWindow registerWindow = new RegisterWindow(userService);
           registerWindow.Show();
          //kod för att stänga main window
        }
        private string _password;
        private string _username;
        private User _currentUser;

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
        public User CurrentUser
        {
            get => _currentUser;
            set
            {
                if (_currentUser != value)
                {
                    _currentUser = value;
                    OnPropertyChanged();
                }

            }

        }
    }
}
