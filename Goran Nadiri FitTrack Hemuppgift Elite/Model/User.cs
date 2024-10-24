using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Goran_Nadiri_FitTrack_Hemuppgift_Elite.Model
{
    public class User : Person
    {
        public string Country { get; set; }
        public string SecurityQuestion { get; set; }
        public string SecurityAnswer { get; set; }


        public override void SignIn()
        {
            MessageBox.Show($"User {Username} has logged in!");
        }
    }
}
