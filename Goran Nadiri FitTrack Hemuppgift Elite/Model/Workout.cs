using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goran_Nadiri_FitTrack_Hemuppgift_Elite.Model
{
    public abstract class Workout
    {
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string Duration { get; set; }
        public int CaloriesBurned { get; set; }
        public string Notes { get; set; }

        public abstract int CalculateCaloriesBurned();




    }
}
