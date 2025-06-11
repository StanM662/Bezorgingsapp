using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace MAUI_Applicatie.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {

        }

        [RelayCommand]
        async Task Tap(string s)
        {
            await Shell.Current.GoToAsync(nameof(NewPage1));
        }
    }
}
