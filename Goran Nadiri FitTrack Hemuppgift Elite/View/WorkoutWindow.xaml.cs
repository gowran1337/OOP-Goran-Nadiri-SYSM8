using Goran_Nadiri_FitTrack_Hemuppgift_Elite.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Goran_Nadiri_FitTrack_Hemuppgift_Elite.View
{
    /// <summary>
    /// Interaction logic for WorkoutWindow.xaml
    /// </summary>
    public partial class WorkoutWindow : Window
    {
        public WorkoutWindow()
        {
            InitializeComponent();
            WorkoutWindowViewModel WorkOutViewModel = new WorkoutWindowViewModel();
            this.DataContext = WorkOutViewModel;
    
        }
    }
}
