using Goran_Nadiri_FitTrack_Hemuppgift_Elite.Model;
using Goran_Nadiri_FitTrack_Hemuppgift_Elite.NVVM;
using Goran_Nadiri_FitTrack_Hemuppgift_Elite.View;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows;

namespace Goran_Nadiri_FitTrack_Hemuppgift_Elite.ViewModel
{
    public class RegisterWindowViewModel : ViewModelBase
    {

        UserService userService;
        public ObservableCollection<User> Users { get; set; }

        public RelayCommand RegisterCommand => new RelayCommand(execute => Register()); //översätter knappen från XAML filen till en funktion här i viewmodel

        public RegisterWindowViewModel(UserService userService)
        {
            this.userService = userService;
            Users = userService.GetUsers();
        }


        public RegisterWindowViewModel()
        {                                                   

        }
        public bool IsUsernameTaken(string username) //metod för att se om username redan finns
        {
            return Users.Any(user => user.Username.Equals(username));
        }

        private void Register()
        {
            if // kollar att textboxarna inte är tomma
                (string.IsNullOrWhiteSpace(Username)
                || string.IsNullOrWhiteSpace(Password)
                || string.IsNullOrEmpty(SecurityAnswer))
            {
                MessageBox.Show("Fill in all blank spaces", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (Password.Length < 8)
            {
                MessageBox.Show("Password must contain 8 characters", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else if (!Password.Any(char.IsDigit))
            {
                MessageBox.Show("Password must contain a digit", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (!ContainsSpecialCharacters(Password))
            {
                MessageBox.Show("Password must contain a special character", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (Password != ConfirmPassword)
            {
                MessageBox.Show("Passwords do not match", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (IsUsernameTaken(Username))
            {
                MessageBox.Show("Username already taken", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            else
            {
                var newUser = new User() // skapar kontot
                {
                    Username = Username,
                    Password = Password,
                    Country = Country,
                    SecurityQuestion = SecurityQuestion,
                    SecurityAnswer = SecurityAnswer
                };

                Users.Add(newUser);
                //userService.AddUser(newUser);
                MessageBox.Show("New user created!", "Succsess!", MessageBoxButton.OK);
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();

            }
            foreach (Window window in Application.Current.Windows)  //loopar igenom fönster
            {
                if (window is RegisterWindow) // stänger fönstret om det är detta fönstret
                {
                    window.Close();
                    break;
                }
            }
        }
        private string _username; //properties för alla strings, detta gör det möjligt att läsa in det som står i bindings i XAML filen
        private string _password;
        private string _country;
        private string _securityQuestion;
        private string _securityAnswer;
        private string _confirmPassword;
        private string _currentUser;


        public string Username
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
        public string Password
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
        public string Country
        {
            get => _country;
            set
            {
                if (_country != value)
                {
                    _country = value;
                    OnPropertyChanged();
                }
            }
        }
        public string SecurityQuestion
        {
            get => _securityQuestion;
            set
            {
                if (_securityQuestion != value)
                {
                    _securityQuestion = value;
                    OnPropertyChanged();
                }
            }
        }
        public string SecurityAnswer
        {
            get => _securityAnswer;
            set
            {
                if (value != _securityAnswer)
                {
                    _securityAnswer = value;
                    OnPropertyChanged();
                }
            }
        }
        public string ConfirmPassword
        {
            get => _confirmPassword;
            set
            {
                if (value != _confirmPassword)
                {
                    _confirmPassword = value;
                    OnPropertyChanged();
                }
            }
        }

        public string CurrentUser
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



        static bool ContainsSpecialCharacters(string Password)
        {
            // Define a regular expression for special characters
            string pattern = @"[!@#$%^&*(),.?""':;{}|<>]";
            // Check if the string contains at least one special character
            return Regex.IsMatch(Password, pattern);
        }


    }
}
