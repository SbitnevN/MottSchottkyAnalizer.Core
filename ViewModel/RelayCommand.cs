using System.Windows.Input;

namespace MottSchottkyAnalizer.Core.ViewModel;

public class RelayCommand<T> : IRelayCommand<T>
{
    private readonly Action<T?> _execute = null!;
    private readonly Func<T?, bool>? _canExecute;

    public RelayCommand(Action<T?> execute, Func<T?, bool>? canExecute = null)
    {
        ArgumentNullException.ThrowIfNull(execute);
        _canExecute = canExecute;
    }

    public bool CanExecute(T? parameter)
    {
        return _canExecute?.Invoke(parameter) ?? true;
    }

    public void Execute(T? parameter)
    {
        _execute(parameter);
    }

    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }
}