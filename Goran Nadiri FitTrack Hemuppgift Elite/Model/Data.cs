using System.Collections.ObjectModel;


namespace Goran_Nadiri_FitTrack_Hemuppgift_Elite.Model
{
    public class UserService
    {
        private static UserService _instance;

        public static UserService Instance => _instance ??= new UserService();
        public ObservableCollection<User> Users { get; } = new ObservableCollection<User>(); //skapar listan Users
        public ObservableCollection<User> GetUsers() { return Users; }
        public User CurrentUser { get; set; }
        public User AllUsers { get; set; }

        public UserService()
        {
            Users.Add(new User() // skapar en user
            {
                Username = "1",
                Password = "1",
                Country = "Arabien",
                SecurityQuestion = "Favorit frukt?",
                SecurityAnswer = "äpple",
                Workouts = new ObservableCollection<Workout>{new Cardio(DateTime.Now, "Cardio", "90", 165, "överbra", "30"),
                new Strength(DateTime.Now, "Strength", "50", 53, "dunder pass", "40")}

            });

            Users.Add(new User()
            {
                Username = "Åsnan",
                Password = "1234",
                Country = "Sverige",
                SecurityQuestion = "Favorit film?",
                SecurityAnswer = "Det regnar köttbullar",
                Workouts = new ObservableCollection<Workout>{new Cardio(DateTime.Now, "Cardio", "97", 0, "super pass", "30"),
                new Strength(DateTime.Now, "Strength", "35", 323, "wow vilket pass", "42")}
            });

            Users.Add(new Manager()
            {
                Username = "admin",
                Password = "1234"
            });




        }
        public ObservableCollection<Workout> GetAllWorkouts()
        {//skapar en ny lista och loopar igenom users och dess workouts för att sedan lägga till workout i den nya listan
            var allWorkouts = new ObservableCollection<Workout>();
            foreach (var user in Users)
            {
                foreach (var workout in user.Workouts)
                {
                    allWorkouts.Add(workout);
                }
            }
            return allWorkouts;
        }
        public void AddUser(User newUser)
        {
            Users.Add(newUser);
        }

        public class Data
        {
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
