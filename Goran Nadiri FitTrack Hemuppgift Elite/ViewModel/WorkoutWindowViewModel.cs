using Goran_Nadiri_FitTrack_Hemuppgift_Elite.Model;
using Goran_Nadiri_FitTrack_Hemuppgift_Elite.NVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goran_Nadiri_FitTrack_Hemuppgift_Elite.ViewModel
{
    internal class WorkoutWindowViewModel
    {
        UserService userService;

        public ObservableCollection<User> Users;

        public RelayCommand OpenAddWorkOutWindowCommand=> new RelayCommand(execute => OpenWorkOutWindow());



        public WorkoutWindowViewModel(UserService userService)
        {
            this.userService = userService;
            Users = userService.GetUsers();
        }

        public void OpenWorkOutWindow()
        {

        }





    }
}
