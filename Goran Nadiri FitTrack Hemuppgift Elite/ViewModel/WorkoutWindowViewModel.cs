using Goran_Nadiri_FitTrack_Hemuppgift_Elite.Model;
using Goran_Nadiri_FitTrack_Hemuppgift_Elite.NVVM;
using System.Collections.ObjectModel;
using System.Windows;
using Workout = Goran_Nadiri_FitTrack_Hemuppgift_Elite.Model.Workout;

namespace Goran_Nadiri_FitTrack_Hemuppgift_Elite.View
{
    internal class WorkoutWindowViewModel : ViewModelBase
    {

        //UserService userService;
        //public ObservableCollection<User> Users;
        
        public ObservableCollection<Workout> Workouts => UserService.Instance.CurrentUser?.Workouts;

        public RelayCommand OpenAddWorkOutWindowCommand => new RelayCommand(execute => OpenWorkOutWindow());
        public RelayCommand UserDetailsCommand => new RelayCommand(execute => OpenUserDetailsWindow());
        public RelayCommand AppInfoCommand => new RelayCommand(execute => ShowAppInfo());


        public WorkoutWindowViewModel(UserService instance)
        {

           
            

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

        //private Workout _workoutz;
        private User _currentUser;
        private string _type;
        private DateTime _date;
        private Workout _cardio;
        private Workout _strength;
        private Workout _workouts;
        private string _duration;
        private string _workouttypes;

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
        public string WorkoutTypes
        {
            get => _workouttypes;
            set
            {
                if (_workouttypes != value)
                {
                    _workouttypes = value;
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


        public string Type
        {
            get => _type;
            set
            {
                if (_type != value)
                {
                    _type = value;
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
        //public Workout Workouts1
        //{
        //    get => _workouts1;
        //    set
        //    {
        //        if (_workouts != value)
        //        {
        //            _workouts = value;
        //            OnPropertyChanged();
        //        }
        //    }
        //}


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
