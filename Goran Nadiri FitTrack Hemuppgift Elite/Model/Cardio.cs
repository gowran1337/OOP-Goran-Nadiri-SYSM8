namespace Goran_Nadiri_FitTrack_Hemuppgift_Elite.Model
{
    public class Cardio : Workout
    {


        public Cardio(DateTime date, string workouttype, string duration, int caloriesburned, string notes, int reps)
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
            int duration = Convert.ToInt32(Duration);
            CaloriesBurned = duration * 11;

            return CaloriesBurned; // 11 kalorier/minut bränner joggning
        }
    }
}
