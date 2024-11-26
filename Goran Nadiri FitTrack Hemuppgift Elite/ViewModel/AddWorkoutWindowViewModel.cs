 using Goran_Nadiri_FitTrack_Hemuppgift_Elite.Model;
using Goran_Nadiri_FitTrack_Hemuppgift_Elite.NVVM;
using Goran_Nadiri_FitTrack_Hemuppgift_Elite.View;
using System.Collections.ObjectModel;
using System.Windows;

namespace Goran_Nadiri_FitTrack_Hemuppgift_Elite.ViewModel
{
    public class AddWorkoutWindowViewModel : ViewModelBase
    {
        UserService userService;

        public ObservableCollection<User> Users;
        public RelayCommand AddWorkoutCommand => new RelayCommand(execute => AddWorkout());
        public RelayCommand BackCommand => new RelayCommand(execute => Back());

        public AddWorkoutWindowViewModel(UserService userService)
        {
            this.userService = userService;
            Users = userService.GetUsers();
        }

        public void Back()
        {
            foreach (Window window in Application.Current.Windows)  //loopar igenom fönster
            {
                
                if (window is AddWorkoutWindow) // stänger fönstret om det är detta fönstret
                {
                    window.Close();
                    break;
                }
            }
        }
        Workout newWorkout;
        public void AddWorkout() //if else för cardio eller strenght
        {
            if (string.IsNullOrWhiteSpace(Notes?.Trim()) || string.IsNullOrWhiteSpace(Duration)
                || SelectedDate == null)
            {
                MessageBox.Show("Fill in all blank spaces", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (!IsNumeric(Duration))
            {
                MessageBox.Show("Use numbers", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (!IsNumeric(Reps))
            {
                MessageBox.Show("Input number of reps (using numbers)", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }         
            {
                if (WorkoutType == "Cardio")
                {                   
                     newWorkout = new Cardio(SelectedDate, WorkoutType, Duration, CaloriesBurned, Notes, Reps);
                    CaloriesBurned = newWorkout.CalculateCaloriesBurned(); // anropar metoden för att räkna ut caliroes burned
                }
                else if (WorkoutType == "Strength")
                {
                     newWorkout = new Strength(SelectedDate, WorkoutType, Duration, CaloriesBurned, Notes, Reps);
                    CaloriesBurned = newWorkout.CalculateCaloriesBurned();
                }
                else
                {
                    MessageBox.Show("Invalid workout type", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                UserService.Instance.CurrentUser?.Workouts.Add(newWorkout);
                MessageBox.Show("Workout added successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        bool IsNumeric(string input) // metod for att se till att bara siffror matas i textboxen
        {
            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
        private string _notes;
        private string _duration;
        private string _workoutType;
        private DateTime _selectedDate = DateTime.Today;
        private string _currentUser;
        private string _reps;
        private int _caloriesburned;
        private string _strength;
        private string _workoutTypes;
        
        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                if (_selectedDate != value)
                {
                    _selectedDate = value;
                    OnPropertyChanged();
                }

            }

        }
        public string WorkoutType
        {
            get => _workoutType;
            set
            {
                if (_workoutType != value)
                {
                    _workoutType = value;
                    OnPropertyChanged();
                }

            }
        }
        public string WorkoutTypes
        {
            get => _workoutTypes;
            set
            {
                if (_workoutTypes != value)
                {
                    _workoutTypes = value;
                    OnPropertyChanged();
                }

            }
        }
        public string Strength
        {
            get => _strength;
            set
            {
                if (_strength != value)
                {
                    _strength = value;
                    OnPropertyChanged();
                }

            }

        }
        public string Reps
        {
            get => _reps;
            set
            {
                if (_reps != value)
                {
                    _reps = value;
                    OnPropertyChanged();
                }

            }

        }
        public int CaloriesBurned
        {
            get => _caloriesburned;
            set
            {
                if (_caloriesburned != value)
                {
                    _caloriesburned = value;
                    OnPropertyChanged();
                }

            }

        }
        public string Duration
        {
            get => _duration;
            set
            {
                if (_duration != value)
                {
                    _duration = value;
                    OnPropertyChanged();
                }

            }

        }
        public string Notes
        {
            get => _notes;
            set
            {
                if (_notes != value)
                {
                    _notes = value;
                    OnPropertyChanged();
                }

            }

        }
        public string CurrentUser
        {
            get => _currentUser;
            set
            {
                if (_currentUser != value)
                {
                    _currentUser = value;
                    OnPropertyChanged();
                }

            }

        }




    }
}
