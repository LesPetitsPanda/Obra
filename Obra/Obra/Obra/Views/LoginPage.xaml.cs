using Obra.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Obra.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
          Content = CreateLoginForm();
        }
        View CreateLoginForm()
        {
            var usernameEntry = new Entry { Placeholder = "Username" };
            var passwordEntry = new Entry
            {
                Placeholder = "Password",
                IsPassword = true,
                VerticalOptions = LayoutOptions.Center

            };

            return new StackLayout
            {
                Children = {
      usernameEntry,
      passwordEntry
    }
            };
        }
        private void PressMeButton_Clicked(object sender, EventArgs e)
        {
      
            
        }

    }
}