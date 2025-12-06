using MottSchottkyAnalizer.Core.ViewModel;

namespace MottSchottkyAnalizer.Core.Dialogs;

public class DialogViewModel
{
    public event Action? OnChoose;

    public IRelayCommand SubmitCommand { get; init; }

    public IRelayCommand CancelCommand { get; init; }

    public bool DialogResult { get; private set; } = false;

    public DialogParameters Parameters { get; set; } = null!;

    public string Title => Parameters.Title;

    public DialogViewModel()
    {
        SubmitCommand = new RelayCommand(Submit);
        CancelCommand = new RelayCommand(Cancel);
    }

    public virtual void Submit()
    {
        DialogResult = true;
        OnChoose?.Invoke();
    }

    public virtual void Cancel()
    {
        DialogResult = false;
        OnChoose?.Invoke();
    }
}
