namespace HospitalManagementSystem.Blazor;

public abstract class StateBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    public StateBase()
    {
    }

    protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null!)
    {
        if (object.Equals(storage, value))
        {
            return false;
        }

        storage = value;
        OnPropertyChanged(propertyName);
        return true;
    }

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null!)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
