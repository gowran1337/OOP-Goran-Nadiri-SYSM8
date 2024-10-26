using Goran_Nadiri_FitTrack_Hemuppgift_Elite.Model;
using Goran_Nadiri_FitTrack_Hemuppgift_Elite.NVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goran_Nadiri_FitTrack_Hemuppgift_Elite.ViewModel
{
    public class VerificationWindowViewModel : ViewModelBase    
    {
        UserService userService;
        public VerificationWindowViewModel(UserService userService)
        {
            this.userService = userService;
        }


        private string _theVerificationCode;
        private string _enteredVerificationCode;


        public string TheVerificationCode
        {
            get => _theVerificationCode;
            set
            {
                if (_theVerificationCode != value)
                {
                    _theVerificationCode = value;
                    OnPropertyChanged();
                }
            }
        }

        public string EnteredVerificationCode
        {
            get => _enteredVerificationCode;
            set
            {
                if (_enteredVerificationCode != value)
                {
                    _enteredVerificationCode = value;
                    OnPropertyChanged();
                }
            }
        }


    }
}
