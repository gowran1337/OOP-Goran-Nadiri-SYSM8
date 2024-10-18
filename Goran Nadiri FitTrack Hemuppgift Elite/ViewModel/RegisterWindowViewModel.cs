using Goran_Nadiri_FitTrack_Hemuppgift_Elite.NVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace Goran_Nadiri_FitTrack_Hemuppgift_Elite.ViewModel
{
    public class RegisterWindowViewModel : ViewModelBase
    {  //gör så att ändringar i UI ändrar data i filen model.data
        public static ObservableCollection<Model.Data.User> Users { get; set; } = new ObservableCollection<Model.Data.User>();
 
         //om knappen RegisterCommand som finns i XAML filen aktiveras, so executas metoden Register
        public RelayCommand RegisterCommand => new RelayCommand(execute => Register()); 

        
        public RegisterWindowViewModel() 
        {                                                                       //konstruktor för att skapa User
            Users = new ObservableCollection<Model.Data.User>();
            Users.Add(new Model.Data.User() { Username = "Zebri95", Password = "1337",
                      Country = "Arabien", SecurityQuestion = "Favorit frukt?", SecurityAnswer = "äpple" });
        }

        private void Register()
        {
            
        }



        private string _username;
        private string _password;
        
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



    }
}
