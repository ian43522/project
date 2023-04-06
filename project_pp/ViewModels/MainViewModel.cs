using project_pp.Utils;

namespace project_pp.ViewModels;
public class MainViewModel : ViewModelBase
{
    private readonly NavigationStore _navigationStore;

    public MainViewModel(NavigationStore navigationStore, NavigationService<LoginViewModel> navigationLogin)
    {
        _navigationStore = navigationStore;
        _navigationStore.CurrentViewModelChanged += () => RaisePropertyChanged(nameof(CurrentViewModel));

        navigationLogin.Navigate();
    }
    public ViewModelBase CurrentViewModel { get => _navigationStore.CurrentViewModel; }
}
