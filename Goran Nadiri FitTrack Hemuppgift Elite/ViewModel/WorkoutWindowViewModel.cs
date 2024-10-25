using Goran_Nadiri_FitTrack_Hemuppgift_Elite.Model;
using Goran_Nadiri_FitTrack_Hemuppgift_Elite.NVVM;
using Goran_Nadiri_FitTrack_Hemuppgift_Elite.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using static Goran_Nadiri_FitTrack_Hemuppgift_Elite.Model.Data;
using Workout = Goran_Nadiri_FitTrack_Hemuppgift_Elite.Model.Workout;

namespace Goran_Nadiri_FitTrack_Hemuppgift_Elite.View
{
    internal class WorkoutWindowViewModel : ViewModelBase
    {
        UserService userService;
        public ObservableCollection<User> Users;

        public RelayCommand OpenAddWorkOutWindowCommand => new RelayCommand(execute => OpenWorkOutWindow());
        public RelayCommand UserDetailsCommand => new RelayCommand(execute => OpenUserDetailsWindow());
        public RelayCommand AppInfoCommand => new RelayCommand(execute => ShowAppInfo());

        public WorkoutWindowViewModel(UserService userService)
        {

            this.userService = userService;
            Users = userService.GetUsers();

        }

        public void OpenUserDetailsWindow()
        {
            UserDetailsWindow userDetailsWindow = new(userService);
            userDetailsWindow.Show();
        }

        public void OpenWorkOutWindow()
        {
            AddWorkoutWindow addWorkoutWindow = new(userService);
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

        //public Workout Workoutz
        //{
        //    get => _workoutz;
        //    set
        //    {
        //        if (_workoutz != value)
        //        {
        //            _workoutz = value;
        //            OnPropertyChanged();
        //        }

        //    }

        //}
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
