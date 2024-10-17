using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Goran_Nadiri_FitTrack_Hemuppgift_Elite.NVVM
{
    public class RelayCommand : ICommand
    {
        //Fält för att hålla referenser till metoder som definerar vad som ska göras
        private Action<object> execute;
        private Func<Object, bool> canExecute;

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Func<Object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        // bestämmer om kommandot kan köras eller inte
        public bool CanExecute(object? parameter)
        {
            return canExecute == null || canExecute(parameter);
        }
        //Kör den logik som tilldelats via execute metoden
        public void Execute(object? parameter)
        {
            execute(parameter);
        }
    }

}
    

