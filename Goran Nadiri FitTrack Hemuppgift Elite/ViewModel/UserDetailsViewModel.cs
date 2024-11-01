using Goran_Nadiri_FitTrack_Hemuppgift_Elite.Model;
using Goran_Nadiri_FitTrack_Hemuppgift_Elite.NVVM;
using System.Collections.ObjectModel;
using System.Windows;

namespace Goran_Nadiri_FitTrack_Hemuppgift_Elite.View
{
    internal class UserDetailsViewModel : ViewModelBase
    {
        private UserService userService;
        public ObservableCollection<User> Users { get; set; }

        public RelayCommand SaveCommand => new RelayCommand(execute => UpdateUserInfo());
        public RelayCommand ReturnCommand => new RelayCommand(execute => Return());

        public UserDetailsViewModel(UserService userService)
        {
            this.userService = userService;
            Users = userService.GetUsers();
        }
        public void Return()
        {
            foreach (Window window in Application.Current.Windows)  //loopar igenom fönster
            {
                if (window is UserDetailsWindow) // stänger fönstret om det är detta fönstret
                {
                    window.Close();
                    break;
                }
            }
        }

        public bool IsUsernameTaken(string username)
        {
          
            return Users.Any(user => user.Username.Equals(username)); // kollar ifall username redan finns i listan users
        }

        public void UpdateUserInfo()  //går att anpassa så att det går att ändra en individuell sak istället för att behöva ändra allt genom att dela upp i flera if satser
        {
            if (string.IsNullOrEmpty(NewUsername) || NewUsername.Length < 3)
            {
                MessageBox.Show("Username must contain atleast 3 characters", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var currentUser = UserService.Instance.CurrentUser; // sätter currentuser til samma värde som CurrentUser som hämtas från userservice
            if (NewUsername != null && IsUsernameTaken(NewUsername) && (currentUser == null || !currentUser.Username.Equals(NewUsername)))
            {
                MessageBox.Show("Username already taken", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            else if (string.IsNullOrEmpty(NewPassword1)|| NewPassword1.Length < 5)
            {
                MessageBox.Show("Password must contain atleast 5 characters", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (NewPassword1 != ConfirmNewPassword1)
            {
                MessageBox.Show("Passwords do not match", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                if (!string.IsNullOrEmpty(NewUsername))
                {
                    if (currentUser != null) //sätter dom nya värdena
                    {
                        currentUser.Username = NewUsername;
                        currentUser.Password = NewPassword1;
                        currentUser.Country = NewCountry;
                        MessageBox.Show("User info updated successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
        }





        private string _newUsername;
        private string _newPassword1;
        private string _confirmNewPassword1;
        private string _newCountry;
        private string _username;



        public string NewUsername
        {
            get => _newUsername;
            set
            {
                if (_newUsername != value)
                {
                    _newUsername = value;
                    OnPropertyChanged();
                }

            }

        }
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

        public string NewPassword1
        {
            get => _newPassword1;
            set
            {
                if (_newPassword1 != value)
                {
                    _newPassword1 = value;
                    OnPropertyChanged();
                }

            }

        }
        public string ConfirmNewPassword1
        {
            get => _confirmNewPassword1;
            set
            {
                if (_confirmNewPassword1 != value)
                {
                    _confirmNewPassword1 = value;
                    OnPropertyChanged();
                }

            }

        }
        public string NewCountry
        {
            get => _newCountry;
            set
            {
                if (_newCountry != value)
                {
                    _newCountry = value;
                    OnPropertyChanged();
                }

            }

        }

    }
}
