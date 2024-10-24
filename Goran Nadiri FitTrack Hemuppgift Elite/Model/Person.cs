using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goran_Nadiri_FitTrack_Hemuppgift_Elite.Model
{
    public abstract class Person
    {
        public string Username { get; set; }
        public string Password { get; set; }


        public abstract void SignIn();
    }
}
