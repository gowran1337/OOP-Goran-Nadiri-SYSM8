using Goran_Nadiri_FitTrack_Hemuppgift_Elite.Model;
using Goran_Nadiri_FitTrack_Hemuppgift_Elite.NVVM;
using Goran_Nadiri_FitTrack_Hemuppgift_Elite.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Goran_Nadiri_FitTrack_Hemuppgift_Elite.ViewModel
{
    internal class WorkoutDetailsWindowViewModel : ViewModelBase 
    {
        public ObservableCollection<Workout> Workouts => UserService.Instance.CurrentUser?.Workouts;

        public RelayCommand SaveCommand => new RelayCommand(execute => Save());
        public RelayCommand EditCommand => new RelayCommand(execute => Edit());
        public RelayCommand ReturnCommand => new RelayCommand(execute => Return());

        private void Edit()
        {
            IsEditing = true;        
        }

        private void Save()
        {
            IsEditing = false; 

            
            MessageBox.Show("Changes saved successfully!", "Save", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void Return()
        {          
            foreach (Window window in Application.Current.Windows)  //loopar igenom fönster
            {
                if (window is WorkoutDetailsWindow) // stänger fönstret om det är detta fönstret
                {
                    window.Close();
                    break;
                }
            }
        }


        private string _duration;
        private DateTime _date;
        private Workout _cardio;
        private Workout _strength;
        private string _notes;
        private int _caloriesburned;
        private bool _isEditing = false;
        private Workout _selectedWorkout;

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

        public bool IsEditing
        {
            get => _isEditing;
            set
            {
                if (_isEditing != value)
                {
                    _isEditing = value;
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
        public Workout Strength
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
