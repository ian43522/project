using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace project_pp.ViewModels;
/// <summary>
/// Base view model. Implements logic used by every view model.
/// </summary>
public abstract class ViewModelBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    /// <summary>
    /// Raises <see cref="PropertyChanged"/> event for property.
    /// </summary>
    /// <param name="propertyName">Name of changed property. Should be null if method called from that property.</param>
    protected void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
