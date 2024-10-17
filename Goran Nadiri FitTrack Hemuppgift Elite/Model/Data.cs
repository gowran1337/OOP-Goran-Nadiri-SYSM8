using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Goran_Nadiri_FitTrack_Hemuppgift_Elite.Model
{
    public class Data
    {
        public abstract class Person
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public abstract void SignIn();
        }

        public class User : Person
        {

            public string Country { get; set; }
            public string SecurityQuestion { get; set; }
            public string SecurityAnswer { get; set; }

            public override void SignIn()
            {

            }
        }

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
