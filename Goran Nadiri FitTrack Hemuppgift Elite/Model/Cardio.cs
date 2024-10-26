namespace Goran_Nadiri_FitTrack_Hemuppgift_Elite.Model
{
    public class Cardio : Workout
    {
        public override int CalculateCaloriesBurned()
        {
            int duration = Convert.ToInt32(Duration);
            CaloriesBurned = duration * 11;

            return CaloriesBurned; // 11 kalorier/minut bränner joggning
        }
    }
}
