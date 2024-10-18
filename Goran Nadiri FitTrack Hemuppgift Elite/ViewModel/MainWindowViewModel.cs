using Goran_Nadiri_FitTrack_Hemuppgift_Elite.NVVM;
using Goran_Nadiri_FitTrack_Hemuppgift_Elite.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goran_Nadiri_FitTrack_Hemuppgift_Elite.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {
        internal static ObservableCollection<Model.Data.User> Users { get; set; } = new ObservableCollection<Model.Data.User>();


        public RelayCommand OpenRegisterWindow => new RelayCommand(execute => OpenRegisterWindow1());
        

        private void OpenRegisterWindow1()
        {
           
           RegisterWindow registerWindow = new RegisterWindow();
           registerWindow.Show();
          //kod för att stänga main window
        }

    }
}
