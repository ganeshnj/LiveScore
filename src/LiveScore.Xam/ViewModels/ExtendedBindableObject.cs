using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace LiveScore.Xam.ViewModels
{
    public class ExtendedBindableObject : BindableObject, INotifyPropertyChanged
    {
        protected bool SetProperty<T>(ref T backingStore, T value,
                   [CallerMemberName]string propertyName = "",
                   Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
