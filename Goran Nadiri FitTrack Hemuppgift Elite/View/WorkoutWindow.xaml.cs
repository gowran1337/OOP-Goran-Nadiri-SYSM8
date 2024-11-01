﻿using Goran_Nadiri_FitTrack_Hemuppgift_Elite.Model;
using System.Windows;

namespace Goran_Nadiri_FitTrack_Hemuppgift_Elite.View
{
  
    public partial class WorkoutWindow : Window
    {
        private UserService userService;

        public WorkoutWindow(UserService userService)
        {
            InitializeComponent();
            DataContext = new WorkoutWindowViewModel(UserService.Instance);
            
        }
    }
}
