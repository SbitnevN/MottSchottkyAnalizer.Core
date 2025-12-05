
using System.Windows.Input;

namespace MottSchottkyAnalizer.Core.ViewModel;

public interface IRelayCommand<T> : ICommand
{
    bool CanExecute(T? parameter);
    void Execute(T? parameter);

    bool ICommand.CanExecute(object? parameter) => CanExecute((T?)parameter);
    void ICommand.Execute(object? parameter) => Execute((T?)parameter);
}