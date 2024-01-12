﻿using System.Collections;
using System.ComponentModel;

namespace RevitSolutionTemplate.Core.Common.ViewModels;

public class ErrorsViewModel : INotifyDataErrorInfo
{
    private readonly Dictionary<string, List<string>> _propertyErrors = new();

    public bool HasErrors => _propertyErrors.Any();

    public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

    public IEnumerable? GetErrors(string propertyName)
    {
        if (!_propertyErrors.TryGetValue(propertyName, out List<string> errors))
        {
            return null;
        }

        return errors;
    }

    public void AddError(string propertyName, string errorMessage)
    {
        if (!_propertyErrors.ContainsKey(propertyName))
        {
            _propertyErrors.Add(propertyName, new List<string>());
        }

        _propertyErrors[propertyName].Add(errorMessage);
        OnErrorsChanged(propertyName);

    }

    public void ClearErrors(string propertyName)
    {
        if (_propertyErrors.Remove(propertyName))
        {
            OnErrorsChanged(propertyName);
        }
    }

    private void OnErrorsChanged(string propertyName)
    {
        ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
    }
}
