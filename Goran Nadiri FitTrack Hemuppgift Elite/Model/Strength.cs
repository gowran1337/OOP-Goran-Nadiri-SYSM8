using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goran_Nadiri_FitTrack_Hemuppgift_Elite.Model
{
    public class Strength : Workout
    {
        public Strength(DateTime date, string workouttype, string duration, int caloriesburned, string notes, int reps)
       : base(date, workouttype, duration, caloriesburned, notes, reps)
        {
            Date = date;
            WorkoutType = workouttype;
            Duration = duration;
            CaloriesBurned = caloriesburned;
            Notes = notes;
            Reps = reps;    
            
        }

        public override int CalculateCaloriesBurned()
        {
            CaloriesBurned = Reps * 5;

            return CaloriesBurned;
        }
    }
}
