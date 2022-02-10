using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace Obra.ViewModels
{ 
    public class HomePageModel : INotifyPropertyChanged
    {
        public ICommand LoginCommand { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        async void LoginCommandLabel()
        {
             
        }
        public HomePageModel()
        {
            LoginCommand = new Xamarin.Forms.Command(LoginCommandLabel);
        }
    }
}
