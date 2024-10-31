using System.Collections.ObjectModel;


namespace Goran_Nadiri_FitTrack_Hemuppgift_Elite.Model
{
    public class UserService
    {

        private static UserService _instance;

        public static UserService Instance => _instance ??= new UserService();


        public ObservableCollection<User> Users { get; } = new ObservableCollection<User>(); //skapar listan Users


        //public ObservableCollection<Workout> Workouts { get; } = new ObservableCollection<Workout>();
        public ObservableCollection<User> GetUsers() { return Users; }




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
                Workouts = new ObservableCollection<Workout>{new Cardio(DateTime.Now, "Cardio", "90", 300, "överbra", 30),
                new Strength(DateTime.Now, "Strength", "50", 300, "dunder pass", 40)}

            });



        }


        public void AddUser(User newUser)
        {
            Users.Add(newUser);
        }

        //    public void AddWorkout(Workout newWorkout)
        //    {

        //        if (CurrentUser != null)
        //        {
        //            CurrentUser.Workouts.Add(newWorkout);
        //        }
        //    }



        //}
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
                public DateTime Date { get; set; }
                public string Type { get; set; }
                public string Duration { get; set; }
                public int CaloriesBurned { get; set; }
                public string Notes { get; set; }
                public int Reps { get; set; }


                public abstract int CalculateCaloriesBurned();




            }

        }
    }
}
