using System.Collections.ObjectModel;
using static Goran_Nadiri_FitTrack_Hemuppgift_Elite.Model.Data;

namespace Goran_Nadiri_FitTrack_Hemuppgift_Elite.Model
{
    public class UserService
    {
        public ObservableCollection<User> Users { get; } = new ObservableCollection<User>(); //skapar listan Users
        public ObservableCollection<User> GetUsers() { return Users; }
        public ObservableCollection<Workout> GetWorkouts() { return CurrentUser.Workouts; }

        
        public User CurrentUser { get; set; }

        public UserService()
        {
            Users.Add(new User()
            {
                Username = "1",
                Password = "1",
                Country = "Arabien",
                SecurityQuestion = "Favorit frukt?",
                SecurityAnswer = "äpple",

                Workouts = new ObservableCollection<Workout>() {
                    new Cardio()
                    {
                        Date = DateTime.Now,
                        Duration = " 90",
                        Notes = "Ett ajjajeb pass",
                        Type = "Cardio",

                    }
            }
            });        
        }

        public void AddUser(User newUser)
        {
            Users.Add(newUser);
        }
  
        public void AddWorkout(Workout newWorkout)
        {
            
            if (CurrentUser != null)
            {
                CurrentUser.Workouts.Add(newWorkout);
            }
        }







    }
    public class Data
    {
     

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
            public string Duration {  get; set; }
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
