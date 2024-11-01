using Goran_Nadiri_FitTrack_Hemuppgift_Elite.Model;
using Goran_Nadiri_FitTrack_Hemuppgift_Elite.NVVM;
using Goran_Nadiri_FitTrack_Hemuppgift_Elite.View;
using System.Collections.ObjectModel;
using System.Windows;

namespace Goran_Nadiri_FitTrack_Hemuppgift_Elite.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        UserService userService;

        public ObservableCollection<User> Users;
        public ObservableCollection<Workout> Workouts => UserService.Instance.CurrentUser?.Workouts; // gör listan tillgänglig för sidan

        public RelayCommand SignInCommand => new RelayCommand(execute => SignIn()); // knappar från XAML fil översätts till funktion i denna
        public RelayCommand OpenRegisterWindowCommand => new RelayCommand(execute => OpenRegisterWindow());
        public RelayCommand ForgotPasswordCommand => new RelayCommand(execute => OpenForgotPasswordWindow());   
        public RelayCommand SignIn2FAcommand => new RelayCommand(execute => SignIn2FA());

        public MainWindowViewModel(UserService userService)
        {
            this.userService = userService;
            Users = userService.GetUsers();            
        }
       
        public void OpenForgotPasswordWindow()
        {
            ForgetPasswordWindow forgetPasswordWindow = new ForgetPasswordWindow(userService);
            forgetPasswordWindow.Show();
            Application.Current.MainWindow.Close();
        }

        public void SignIn()
        {
            var User = Users.FirstOrDefault(u => u.Username == LoginUsername && u.Password == LoginPassword
);// letar efter en user som har samma namn som inmatad text samt lösenord
            if (User != null && TheVerificationCode == EnteredVerificationCode)
            {
                if (LoginUsername == "admin")
                {
                    AdminWindow admin = new AdminWindow(UserService.Instance);
                    admin.Show();
                    Application.Current.MainWindow.Close();
                    return;
                }
                UserService.Instance.CurrentUser = User; // den som loggar in blir current user
                WorkoutWindow workoutWindow = new WorkoutWindow(UserService.Instance);//skickar data till nya fönstret via USERSERVICE
                workoutWindow.Show(); //öppnar ´workout fönstret
                
                Application.Current.MainWindow.Close();
            }
            
            else
            {
                MessageBox.Show("Invalid username or password or 2FA code", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public string GenerateFAcode()
        {
            Random TheVerificationCode = new Random();
            return TheVerificationCode.Next(99999, 1000000).ToString(); // skapar 6 siffriga koden
        }

        public void SignIn2FA()
        {
            TheVerificationCode = GenerateFAcode();
            MessageBox.Show($"Your verification code is {TheVerificationCode}", "Very secure person!", MessageBoxButton.OK);        
            
        }

        public void OpenRegisterWindow()
        {
            RegisterWindow registerWindow = new RegisterWindow(userService);
            registerWindow.Show();
            Application.Current.MainWindow.Close();

        }


        private string _password;
        private string _username; //properties
        private User _currentUser;
        private string _theVerificationCode;
        private string _enteredVerificationCode;

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

        public string EnteredVerificationCode
        {
            get => _enteredVerificationCode;
            set
            {
                if (_enteredVerificationCode != value)
                {
                    _enteredVerificationCode = value;
                    OnPropertyChanged();
                }
            }
        }
        public string TheVerificationCode
        {
            get => _theVerificationCode;
            set
            {
                if (_theVerificationCode != value)
                {
                    _theVerificationCode = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
