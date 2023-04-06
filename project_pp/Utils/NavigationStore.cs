using System;
using project_pp.ViewModels;

namespace project_pp.Utils;
public class NavigationStore
{
    private ViewModelBase? _currentViewModel;

    public ViewModelBase? CurrentViewModel
    {
        get => _currentViewModel;
        set
        {
            _currentViewModel = value;
            CurrentViewModelChanged?.Invoke();
        }
    }
    public event Action? CurrentViewModelChanged;
}

