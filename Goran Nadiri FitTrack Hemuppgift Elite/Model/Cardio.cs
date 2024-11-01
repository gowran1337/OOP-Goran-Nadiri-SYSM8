namespace Goran_Nadiri_FitTrack_Hemuppgift_Elite.Model
{
    public class Cardio : Workout
    {


        public Cardio(DateTime date, string workouttype, string duration, int caloriesburned, string notes, string reps)
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
            int duration = Convert.ToInt32(Duration);// gör inmatade stringen "duration" till en int
            CaloriesBurned = duration * 11;
            OnPropertyChanged(nameof(CaloriesBurned));

            return CaloriesBurned; // 11 kalorier/minut bränner joggning
        }
        private string _duration;


        public string Duration
        {
            get => _duration;
            set
            {
                if (_duration != value)
                {
                    _duration = value;
                    OnPropertyChanged();
                    CalculateCaloriesBurned(); // Calls the override method
                }
            }
        }
    }
}
