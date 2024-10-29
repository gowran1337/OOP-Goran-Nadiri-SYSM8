using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace Goran_Nadiri_FitTrack_Hemuppgift_Elite.Model
{
    public abstract class Workout
    {
        public DateTime Date { get; set; }
        public string WorkoutType { get; set; }
        public string Duration { get; set; }
        public int CaloriesBurned { get; set; }
        public string Notes { get; set; }
        public int Reps {  get; set; }
        public abstract int CalculateCaloriesBurned();
       
        public Workout(DateTime date, string workouttype, string duration, int caloriesBurned, string notes, int reps)
        {
            Date = date;
            WorkoutType = workouttype;
            Duration = duration;
            CaloriesBurned = caloriesBurned;
            Notes = notes;
            Reps = reps;
        }
    }

    
}
