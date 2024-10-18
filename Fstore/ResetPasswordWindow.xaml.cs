using System.Windows;

namespace Fstore
{
    public partial class ResetPasswordWindow : Window
    {
        public ResetPasswordWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            // Logic for resetting the password
            string password = txtPassword.Password;
            string rePassword = txtRePassword.Password;

            if (password != rePassword)
            {
                MessageBox.Show("Passwords do not match. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Perform the reset password operation...
            MessageBox.Show("Password has been successfully reset.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Close the window
        }
    }
}
