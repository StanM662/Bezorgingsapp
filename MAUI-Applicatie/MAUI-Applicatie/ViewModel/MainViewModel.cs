namespace MAUI_Applicatie.ViewModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

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

