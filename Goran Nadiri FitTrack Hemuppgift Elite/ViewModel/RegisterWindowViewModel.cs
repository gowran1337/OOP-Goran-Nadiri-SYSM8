using Goran_Nadiri_FitTrack_Hemuppgift_Elite.Model;
using Goran_Nadiri_FitTrack_Hemuppgift_Elite.NVVM;
using Goran_Nadiri_FitTrack_Hemuppgift_Elite.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Goran_Nadiri_FitTrack_Hemuppgift_Elite.ViewModel
{
    public class RegisterWindowViewModel : ViewModelBase
    {  
       
       UserService userService = new UserService();
        public ObservableCollection<Model.Data.User> Users { get; set; }

        public RelayCommand RegisterCommand => new RelayCommand(execute => Register()); 

        
      

        public RegisterWindowViewModel() 
        {                                                   //konstruktor för att skapa User
           Users = new ObservableCollection<Model.Data.User>();
           Users = userService.GetUsers();
        }



        private void Register()
        {
            if(string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password) || string.IsNullOrEmpty(SecurityAnswer))
            {
                MessageBox.Show("Fill in all blank spaces", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
            var newUser = new Model.Data.User()
            {
                Username = this.Username,
                Password = this.Password,
                Country = this.Country,
                SecurityQuestion = this.SecurityQuestion,
                SecurityAnswer = this.SecurityAnswer
            };

            Users.Add(newUser);
            //userService.AddUser(newUser);

            }

            
            
        }



        private string _username;
        private string _password;
        private string _country;
        private string _securityQuestion;
        private string _securityAnswer;
        
        public string Username
        {
            get => _username;
            set
            {
                if(_username != value)
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
                if(_password != value)
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
                if(_country != value)
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
                if(value != _securityAnswer)
                {
                    _securityAnswer = value;
                    OnPropertyChanged();
                }
            }
        }



    }
}
