using Goran_Nadiri_FitTrack_Hemuppgift_Elite.Model;
using Goran_Nadiri_FitTrack_Hemuppgift_Elite.NVVM;
using Goran_Nadiri_FitTrack_Hemuppgift_Elite.View;
using System.Collections.ObjectModel;
using System.Windows;

namespace Goran_Nadiri_FitTrack_Hemuppgift_Elite.ViewModel
{
    internal class AdminWindowViewModel : ViewModelBase
    {


        public RelayCommand SignOutCommand => new RelayCommand(execute => SignOut());
        public RelayCommand RemoveCommand => new RelayCommand(execute => Remove());

        public ObservableCollection<Workout> Workouts => UserService.Instance.CurrentUser?.Workouts; // hämtar listan workouts så man kan använda sig av den   
        public ObservableCollection<Workout> AllWorkouts { get; set; }
        private UserService userService;
        public AdminWindowViewModel(UserService userService)
        {
            this.userService = userService;
            AllWorkouts = userService.GetAllWorkouts();
        }

        private void Remove()
        {
            if (SelectedWorkout != null)
            {
                // Find the user who owns this workout
                var userWithWorkout = userService.Users.FirstOrDefault(user => user.Workouts.Contains(SelectedWorkout));
                if (userWithWorkout != null)
                {
                    // Remove from user's workout list and from the AllWorkouts collection
                    userWithWorkout.Workouts.Remove(SelectedWorkout);
                    AllWorkouts.Remove(SelectedWorkout);
                    MessageBox.Show("Workout removed successfully!", "Success", MessageBoxButton.OK);
                }
            }
        }
        private void SignOut()
        {
            MainWindow mainwindow = new();
            mainwindow.Show();

            foreach (Window window in Application.Current.Windows)  //loopar igenom fönster
            {
                if (window is AdminWindow) // stänger fönstret om det är detta fönstret
                {
                    window.Close();
                    break;
                }
            }
        }

        private User _username;
        private string _notes;
        private string _duration;
        private string _workoutType;
        private DateTime _selectedDate = DateTime.Today;
        private string _currentUser;
        private string _reps;
        private int _caloriesburned;
        private string _strength;
        private string _workoutTypes;
        private DateTime _date;
        private Workout _cardio;
        private Workout _workouts;

        private Workout _selectedWorkout;



        public User Username
        {
            get => _username;
            set
            {
                if (_username != value)
                {
                    _username = value;
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
        public Workout SelectedWorkout
        {
            get => _selectedWorkout;
            set
            {
                if (_selectedWorkout != value)
                {
                    _selectedWorkout = value;
                    OnPropertyChanged();
                }
            }
        }

        public Workout Cardio
        {
            get => _cardio;
            set
            {
                if (_cardio != value)
                {
                    _cardio = value;
                    OnPropertyChanged();
                }
            }
        }

        public DateTime Date
        {
            get => _date;
            set
            {
                if (_date != value)
                {
                    _date = value;
                    OnPropertyChanged();
                }
            }
        }

        
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
