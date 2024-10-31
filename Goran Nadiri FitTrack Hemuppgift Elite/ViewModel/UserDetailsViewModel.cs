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


        public bool IsUsernameTaken(string username)//KANSKE INTE FUNKAR
        {
            return Users.Any(user => user.Username.Equals(username));
        }

        public void UpdateUserInfo() // lägg till logik för att inte kunna ha ett användarnamn som redan finns
        {
            if(NewUsername.Length < 3)
            {
                MessageBox.Show("Username must contain atleast 5 characters", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (IsUsernameTaken(NewUsername)) ///KANSKE INTE FUNKAR
            {
                MessageBox.Show("Username already taken", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            else if(NewPassword1.Length < 5 || !string.IsNullOrEmpty(NewPassword1))
            {
                MessageBox.Show("Password must contain atleast 5 characters", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if(NewPassword1 != ConfirmNewPassword1)
            {
                MessageBox.Show("Passwords do not match", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (!string.IsNullOrEmpty(NewUsername))
                {
                    
                }
            }
        }






        private string _newUsername;
        private string _newPassword1;
        private string _confirmNewPassword1;
        private string _newCountry;

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
