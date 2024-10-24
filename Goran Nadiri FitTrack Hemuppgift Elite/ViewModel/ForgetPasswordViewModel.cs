using Goran_Nadiri_FitTrack_Hemuppgift_Elite.Model;
using Goran_Nadiri_FitTrack_Hemuppgift_Elite.NVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace Goran_Nadiri_FitTrack_Hemuppgift_Elite.ViewModel
{
    public class ForgetPasswordViewModel : ViewModelBase
    {
        UserService userService;
        public ObservableCollection<User> Users;

        public RelayCommand SubmitUsernameCommand => new RelayCommand(execute => SubmitUsername());
        public RelayCommand SubmitAnswerCommand => new RelayCommand(execute => SubmitAnswer());
        public RelayCommand ChangePasswordCommand => new RelayCommand(execute => ResetPassword());

        public ForgetPasswordViewModel(UserService userService)
        {
            this.userService = userService;
            Users = userService.GetUsers();
        }


        private void SubmitUsername()
        {
            var User = Users.FirstOrDefault(u => u.Username == ForgotUsername); //letar efter listan Users om det inmatade namnet är kopplat till det i listan
            if(User != null)
            {
                SecurityQuestion = User.SecurityQuestion;   //det kopplade namnets security question visas i nu i textboxen "securityquestion"
            }
            else
            {
                MessageBox.Show("This username does not exist", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
        private void SubmitAnswer()
        {
            var User = Users.FirstOrDefault(u => u.Username == ForgotUsername);
            if(User != null && User.SecurityAnswer == Answer)
            {
                ButtonPressable = true;
            }
            else
            {
                ButtonPressable = false;
            }
        }

        private void ResetPassword()
        {
            if // kollar att textboxarna inte är tomma
                (string.IsNullOrWhiteSpace(NewPassword)
                || string.IsNullOrWhiteSpace(NewPasswordConfirm))
            {
                MessageBox.Show("Fill in all blank spaces", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if(NewPassword.Length < 8)
            {
                MessageBox.Show("Password must contain 8 characters", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
               
            }
            else if (!NewPassword.Any(char.IsDigit))
                {
                MessageBox.Show ("Password must contain a digit", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            else if (!ContainsSpecialCharacters(NewPassword))
            {
                MessageBox.Show("Password must contain a special character", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if(NewPassword != NewPasswordConfirm)
            {
                MessageBox.Show("Passwords do not match", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            else
            {
                var User = Users.FirstOrDefault(u => u.Username == ForgotUsername);
                if (User != null)
                {
                    User.Password = NewPassword;
                    MessageBox.Show("Password has been successfully changed.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
        static bool ContainsSpecialCharacters(string NewPassword)
        {
            // Define a regular expression for special characters
            string pattern = @"[!@#$%^&*(),.?""':;{}|<>]";
            // Check if the string contains at least one special character
            return Regex.IsMatch(NewPassword, pattern);
        }



        private string _answer;
        private string _username;
        private string _securityQuestion;
        private bool _buttonPressable;
        private string _newPassword;
        private string _newPasswordConfirm;

        public string ForgotUsername
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
        public string SecurityQuestion
        {
            get => _securityQuestion;
            set
            {
                _securityQuestion = value;
                OnPropertyChanged();
            }
        }
        public string Answer
        {
            get => _answer;
            set
            {
                if (_answer != value)
                {
                    _answer = value;
                    OnPropertyChanged();
                }

            }

        }
        public bool ButtonPressable
        {
            get => _buttonPressable;
            set
            {
                if (_buttonPressable != value)
                {
                    _buttonPressable = value;
                    OnPropertyChanged();
                }

            }

        }

        public string NewPassword
        {
            get => _newPassword;
            set
            {
                if (_newPassword != value)
                {
                    _newPassword = value;
                    OnPropertyChanged();
                }

            }

        }
        public string NewPasswordConfirm
        {
            get => _newPasswordConfirm;
            set
            {
                if (_newPasswordConfirm != value)
                {
                    _newPasswordConfirm = value;
                    OnPropertyChanged();
                }

            }

        }

    }
}
