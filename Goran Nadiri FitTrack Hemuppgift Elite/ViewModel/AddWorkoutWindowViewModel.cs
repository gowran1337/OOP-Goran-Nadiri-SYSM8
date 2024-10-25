using Goran_Nadiri_FitTrack_Hemuppgift_Elite.Model;
using Goran_Nadiri_FitTrack_Hemuppgift_Elite.NVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public void AddWorkout()
        {
            if (string.IsNullOrWhiteSpace(Duration) || string.IsNullOrWhiteSpace(WorkoutType)
                || SelectedDate == null || string.IsNullOrWhiteSpace(Notes))
            {
                MessageBox.Show("Fill in all blank spaces", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                var newWorkout = new Cardio()
                {
                    //fortsätt här
                };
            }
        }




        private string _notes;
        private string _duration;
        private string _workoutType;
        private DateTime _selectedDate;

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




    }
}
