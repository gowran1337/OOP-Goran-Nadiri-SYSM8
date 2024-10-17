using Goran_Nadiri_FitTrack_Hemuppgift_Elite.NVVM;
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


        //public RelayCommand OpenRegisterWindowCommand => new RelayCommand(execute => OpenRegisterWindow);
        //public RelayCommand RegisterCommand => new RelayCommand()

        


        private void OpenRegisterWindow()
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
        }

    }
}
