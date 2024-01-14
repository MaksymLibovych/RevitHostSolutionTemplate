using System.ComponentModel;

namespace RevitSolutionTemplate.Framework.Wpf.ViewModels;

public abstract class ViewModelBase : INotifyPropertyChanged, IDisposable
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Dispose() { }
}
