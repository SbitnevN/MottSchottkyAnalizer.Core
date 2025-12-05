using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MottSchottkyAnalizer.Core.ViewModel;

public class Notifiable<T> : INotifyPropertyChanged, INotifyPropertyChanging
{
    public event PropertyChangedEventHandler? PropertyChanged;

    public event PropertyChangingEventHandler? PropertyChanging;

    public T? Value { get; set; }

    public void Set(T? value, [CallerMemberName] string? propertyName = null)
    {
        if (Equals(Value, value))
            return;

        OnPropertyChanging(propertyName);
        Value = value;
        OnPropertyChanged(propertyName);
    }

    public bool TrySet(T? value, [CallerMemberName] string? propertyName = null)
    {
        if (Equals(Value, value))
            return false;

        OnPropertyChanging(propertyName);
        Value = value;
        OnPropertyChanged(propertyName);
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

    public static implicit operator T?(Notifiable<T?> value)
    {
        return value.Value;
    }
}
