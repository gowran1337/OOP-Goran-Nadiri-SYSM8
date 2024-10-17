using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Goran_Nadiri_FitTrack_Hemuppgift_Elite.Model
{
    internal class Data
    {
        public abstract class Person
        {
            public string UserName { get; set; }
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
            public string Date { get; set; }

        }
    }
}
