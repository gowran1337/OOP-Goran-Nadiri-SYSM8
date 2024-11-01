using Goran_Nadiri_FitTrack_Hemuppgift_Elite.Model;
using Goran_Nadiri_FitTrack_Hemuppgift_Elite.NVVM;
using System.Collections.ObjectModel;
using System.Windows;
using Workout = Goran_Nadiri_FitTrack_Hemuppgift_Elite.Model.Workout;

namespace Goran_Nadiri_FitTrack_Hemuppgift_Elite.View
{
    internal class WorkoutWindowViewModel : ViewModelBase
    {  
        public ObservableCollection<Workout> Workouts => UserService.Instance.CurrentUser?.Workouts; // hämtar listan workouts så man kan använda sig av den
        public string Username => UserService.Instance.CurrentUser?.Username; // hämtar username så den kan displayas

        public RelayCommand OpenAddWorkOutWindowCommand => new RelayCommand(execute => OpenWorkOutWindow());
        public RelayCommand UserDetailsCommand => new RelayCommand(execute => OpenUserDetailsWindow());
        public RelayCommand AppInfoCommand => new RelayCommand(execute => ShowAppInfo());
        public RelayCommand RemoveWorkOutCommand => new RelayCommand(execute => RemoveWorkout());
        public RelayCommand ShowWorkoutDetailsCommand => new RelayCommand(execute => OpenWorkoutDetailsWindow());
        public RelayCommand SignOutCommand => new RelayCommand(execute => SignOut());

        public WorkoutWindowViewModel(UserService instance)
        {

        }

        public void SignOut()
        {
            MainWindow mainwindow = new();
            mainwindow.Show();
            foreach (Window window in Application.Current.Windows)  //loopar igenom fönster
            {
                if (window is WorkoutWindow) // stänger fönstret om det är detta fönstret
                {
                    window.Close();
                    break;
                }
            }
        }
        public void OpenWorkoutDetailsWindow()
        {
            WorkoutDetailsWindow workoutDetailsWindow = new(UserService.Instance);
            workoutDetailsWindow.Show();

            
        }

        public void OpenUserDetailsWindow()
        {
            UserDetailsWindow userDetailsWindow = new(UserService.Instance);
            userDetailsWindow.Show();

            
        }

        public void OpenWorkOutWindow()
        {
            AddWorkoutWindow addWorkoutWindow = new(UserService.Instance);
            addWorkoutWindow.Show();

            
        }

        public void ShowAppInfo()
        {
            MessageBox.Show("Thank you for choosing our app! Here you can track all your workouts with endless possibilities (barely any)" +
                "below you can see your workout and even add and remove them (wow!!)" +
                "We are a definitly legit and good company!" +
                "stay tuned for our premium features which are: coloured name titles and bug fixes! only 400kr/month!! (3 months uppsägningstid) ",
                "You are cool!", MessageBoxButton.OK);
        }
        public void RemoveWorkout()
        {
            if (SelectedWorkout != null)
            {
                Workouts.Remove(SelectedWorkout);
                MessageBox.Show("Workout removed successfully!", "Success", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show("Please select a workout to remove.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        
        private User _currentUser;
        
        private DateTime _date;
        private Workout _cardio;
        private Workout _strength;
        private Workout _workouts;
        
        private Workout _selectedWorkout;

        public User CurrentUser
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






    }
}
