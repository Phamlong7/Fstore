using System;
using System.Windows;
using System.Net.Mail;
using System.Net;
using System.Data.SqlClient;
using System.Windows.Controls; // For database interaction

namespace Fstore
{
    public partial class ForgotPasswordWindow : Page
    {
        public ForgotPasswordWindow()
        {
            InitializeComponent();
        }

        // Logic for sending a password reset link
        private void SendResetLink_Click(object sender, RoutedEventArgs e)
        {
            string email = emailTextBox.Text.Trim();

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please enter an email address.");
                return;
            }

            // Validate if email exists in the database
            if (IsEmailRegistered(email))
            {
                try
                {
                    // Generate reset token (could be a GUID)
                    string resetToken = Guid.NewGuid().ToString();

                    // Save the token in the database against the user (you would also need a "reset_token" column in the users table)
                    SaveResetToken(email, resetToken);

                    // Send reset email
                    SendPasswordResetEmail(email, resetToken);

                    MessageBox.Show("Password reset link has been sent to your email address.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error sending reset link: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Email not found. Please enter a registered email address.");
            }
        }

        // Logic for checking if email is registered in the database
        private bool IsEmailRegistered(string email)
        {
            bool isRegistered = false;

            // Assuming you have an SQL Server database connection
            string connectionString = "your_connection_string_here"; // Replace with your actual connection string

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Users WHERE Email = @Email"; // Replace with your actual table name
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);

                int count = (int)cmd.ExecuteScalar();
                if (count > 0)
                {
                    isRegistered = true;
                }
            }

            return isRegistered;
        }

        // Save the reset token in the database
        private void SaveResetToken(string email, string resetToken)
        {
            string connectionString = "your_connection_string_here"; // Replace with your actual connection string

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE Users SET ResetToken = @ResetToken WHERE Email = @Email"; // Replace with your actual table and column names
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ResetToken", resetToken);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.ExecuteNonQuery();
            }
        }

        // Send the password reset email
        private void SendPasswordResetEmail(string email, string resetToken)
        {
            string resetLink = $"https://yourapp.com/resetpassword?token={resetToken}"; // Replace with your actual reset link

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("no-reply@yourapp.com"); // Replace with your actual sender email
            mail.To.Add(email);
            mail.Subject = "Password Reset Request";
            mail.Body = $"Click the link below to reset your password:\n{resetLink}";

            SmtpClient smtpClient = new SmtpClient("smtp.your-email-provider.com"); // Replace with your SMTP provider
            smtpClient.Port = 587; // Adjust port if needed
            smtpClient.Credentials = new NetworkCredential("your-email@yourdomain.com", "your-email-password"); // Replace with your email credentials
            smtpClient.EnableSsl = true;

            smtpClient.Send(mail);
        }

        // Navigate back to the login window
        private void BackToLogin_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Assuming you have a LoginWindow, replace this with your actual login window navigation
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            Window.GetWindow(this).Close();
        }
    }
}
