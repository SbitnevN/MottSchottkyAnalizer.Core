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
        _execute = execute;
    }

    public bool CanExecute(T? parameter)
    {
        return _canExecute?.Invoke(parameter) ?? true;
    }

    public void Execute(T? parameter)
    {
        _execute.Invoke(parameter);
    }

    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }
}

public class RelayCommand : IRelayCommand
{
    private readonly Action _execute = null!;
    private readonly Func<bool>? _canExecute;

    public RelayCommand(Action execute, Func<bool>? canExecute = null)
    {
        ArgumentNullException.ThrowIfNull(execute);
        _canExecute = canExecute;
        _execute = execute;
    }

    public bool CanExecute()
    {
        return _canExecute?.Invoke() ?? true;
    }

    public void Execute()
    {
        _execute?.Invoke();
    }

    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }
}