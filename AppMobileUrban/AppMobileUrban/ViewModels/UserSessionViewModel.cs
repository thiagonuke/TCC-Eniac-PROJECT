using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace AppMobileUrban.ViewModels
{
    using System.ComponentModel;
    using Xamarin.Forms;

    public class UserSessionViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public UserSessionViewModel()
        {
            LoadUserSession();
        }

        private void LoadUserSession()
        {
            if (Application.Current.Properties.ContainsKey("Nome"))
            {
                Name = Application.Current.Properties["Nome"] as string;
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
