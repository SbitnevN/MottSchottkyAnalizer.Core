using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MottSchottkyAnalizer.Core.ViewModel;

public class ViewModelBase : INotifyPropertyChanged, INotifyPropertyChanging
{
    public event PropertyChangedEventHandler? PropertyChanged;

    public event PropertyChangingEventHandler? PropertyChanging;

    public bool Set<T>(ref T storage, T value, [CallerMemberName] string? propertyName = null)
    {
        if (Equals(storage, value))
            return false;

        OnPropertyChanging(propertyName);
        storage = value;
        OnPropertyChanged(propertyName);
        return true;
    }

    public bool Set<T>(ref T storage, T value, Action<T>? onChanged, [CallerMemberName] string? propertyName = null)
    {
        if (!Set(ref storage, value, propertyName))
            return false;

        onChanged?.Invoke(value);
        return true;
    }

    protected virtual void OnPropertyChanging(string? propertyName)
    {
        PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));
    }

    protected virtual void OnPropertyChanged(string? propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
