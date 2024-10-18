using System;
using System.Windows;
using System.Windows.Input;

namespace Fstore
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        // Dummy credentials for validation. Replace with actual user data retrieval logic
        private readonly string storedEmail = "admin@example.com";
        private readonly string storedPassword = "password123"; // In a real-world scenario, you'd hash the password

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string enteredEmail = txtEmail.Text.Trim();
            string enteredPassword = txtPassword.Password;

            // Basic validation: Check if fields are filled
            if (string.IsNullOrEmpty(enteredEmail) || string.IsNullOrEmpty(enteredPassword))
            {
                MessageBox.Show("Please enter both email and password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Check email format (basic check)
            if (!IsValidEmail(enteredEmail))
            {
                MessageBox.Show("Please enter a valid email address.", "Invalid Email", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Validate user credentials (in real application, you would validate against a database or API)
            if (enteredEmail == storedEmail && enteredPassword == storedPassword)
            {
                // If login is successful, open the MemberManagementWindow
                MemberManagementWindow memberManagement = new MemberManagementWindow();
                memberManagement.ShowDialog();

                // Close the login window
                this.Close();
            }
            else
            {
                // If login fails
                MessageBox.Show("Invalid email or password. Please try again.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            // Close the login window
            this.Close();
        }

        // Existing code...

        private void Register_Click(object sender, MouseButtonEventArgs e)
        {
            // Logic to navigate to the registration window
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.ShowDialog();
            this.Close();
        }

        private void ForgotPassword_Click(object sender, MouseButtonEventArgs e)
        {
            // Logic to navigate to the Forgot Password window
            ForgotPasswordWindow forgotPasswordWindow = new ForgotPasswordWindow();
            forgotPasswordWindow.ShowDialog();
            this.Close();
        }

        private bool IsValidEmail(string email)
        {
            // Basic email format check (this can be more advanced depending on your needs)
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void CloseWindow_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
