using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using mySQLConnect;
using mySQLConnectio;

namespace Obra.Pages
{
    public partial class RegisterProPage : Page
    {
        public RegisterProPage()
        {
            InitializeComponent();

        }
        private void Register_OnClick(object sender, RoutedEventArgs e)
        {
            pass.Text = usernameBox.Text;
            if (PasswordBox.Password != PasswordBoxAgain.Password)
            {
                PopupPasswordAgain.IsOpen = true;
            }
            if (PasswordBox.Password.Length <= 7)
            {
                PopupPassword.IsOpen = true;
            }
            if (SQLConnectUtility.checkIfDataExist(App.ConnectUtility.Connection, RowType.USERNAME, usernameBox.Text))
            {
                PopupUsername.IsOpen = true;
            }
            if (SQLConnectUtility.checkIfDataExist(App.ConnectUtility.Connection, RowType.EMAIL, "", emailBox.Text))
            {
                PopupEmail.IsOpen = true;
            }

            if (PopupEmail.IsOpen == false && PopupPassword.IsOpen == false && PopupUsername.IsOpen == false
                 && PopupPasswordAgain.IsOpen == false
                 && usernameBox.Text != null
                 && PasswordBox.Password != null
                 && emailBox.Text != null)
            {
                App.ConnectUtility.AddUser(usernameBox.Text, PasswordBox.Password, emailBox.Text);

            }

        }

        private void Popup_disabled(object sender, MouseButtonEventArgs e)
        {
            PopupPasswordAgain.IsOpen = false;
            PopupPassword.IsOpen = false;
            PopupUsername.IsOpen = false;
            PopupEmail.IsOpen = false;
        }

    }
}