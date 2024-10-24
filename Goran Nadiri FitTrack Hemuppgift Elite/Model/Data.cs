using System.Collections.ObjectModel;

namespace Goran_Nadiri_FitTrack_Hemuppgift_Elite.Model
{
    public class UserService
    {
        public ObservableCollection<User> Users { get; } = new ObservableCollection<User>();

        public User CurrentUser { get; set; }
        
        public UserService()
        {
            Users.Add(new User()
            {
                Username = "Zebri95",
                Password = "1337",
                Country = "Arabien",
                SecurityQuestion = "Favorit frukt?",
                SecurityAnswer = "äpple"
            });
        }
        public ObservableCollection<User> GetUsers() { return Users; }

        public void AddUser(User newUser)
        {
            Users.Add(newUser);
        }

    }
    public class Data
    {
        //public abstract class Person
        //{
        //    public string Username { get; set; }
        //    public string Password { get; set; }
        //    public abstract void SignIn();
        //}

        //public class User : Person
        //{

        //    public string Country { get; set; }
        //    public string SecurityQuestion { get; set; }
        //    public string SecurityAnswer { get; set; } 
        //    public override void SignIn()
        //    {
        //        MessageBox.Show($"User {Username} has logged in!");
        //    }


        //}

        public class Admin : User
        {
            public void ManageAllWorkouts()
            {

            }
        }

        public abstract class Workout
        {
            public DateTime StartTime  { get; set; }
            public string Type {  get; set; }
            public TimeSpan Duration {  get; set; }
            public int CaloriesBurned { get; set; }
            public string Notes {  get; set; }

            public abstract int CalculateCaloriesBurned();
            
            
            
 
        }
        public class Cardio : Workout
        {
            public override int CalculateCaloriesBurned()
            {
                throw new NotImplementedException();
            }
        }
    }
}
