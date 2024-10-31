using Goran_Nadiri_FitTrack_Hemuppgift_Elite.Model;
using Goran_Nadiri_FitTrack_Hemuppgift_Elite.NVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Goran_Nadiri_FitTrack_Hemuppgift_Elite.ViewModel
{
    public class AddWorkoutWindowViewModel : ViewModelBase
    {
        UserService userService;

        public ObservableCollection<User> Users;


        public RelayCommand AddWorkoutCommand => new RelayCommand(execute => AddWorkout());

        public AddWorkoutWindowViewModel(UserService userService)
        {
            this.userService = userService;
            Users = userService.GetUsers();
        }

        public void AddWorkout() //if else för cardio eller strenght
        {



            if (string.IsNullOrWhiteSpace(Notes?.Trim()) || string.IsNullOrWhiteSpace(Duration)
                || SelectedDate == null)
            {
                MessageBox.Show("Fill in all blank spaces", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {

                var newWorkout = new Cardio(SelectedDate,
                    WorkoutType,
                    Duration,
                   CaloriesBurned, Notes,
                    Reps
                    );

                //userService.AddWorkout(newWorkout);
                MessageBox.Show("Workout added");






            }
        }




        private string _notes;
        private string _duration;
        private string _workoutType;
        private DateTime _selectedDate;
        private string _currentUser;
        private int _reps;
        private int _caloriesburned;

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
        public int Reps
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
