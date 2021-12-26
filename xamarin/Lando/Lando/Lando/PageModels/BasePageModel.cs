using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Lando.PageModels
{
    public abstract class BasePageModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public virtual Task InitializeAsync()
        {
            return Task.CompletedTask;
        }

        public virtual Task OnAppeared()
        {
            return Task.CompletedTask;
        }
        public virtual Task OnDissapeared()
        {
            return Task.CompletedTask;
        }
    }
}
