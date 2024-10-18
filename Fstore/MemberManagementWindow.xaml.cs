using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Fstore
{
    /// <summary>
    /// Interaction logic for MemberManagementWindow.xaml
    /// </summary>
    public partial class MemberManagementWindow : Window
    {
        public MemberManagementWindow()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            MemberDetailsWindow memberDetailsWindow = new MemberDetailsWindow();
            memberDetailsWindow.Show();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {

        }

        private void dgvMemberList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void dgvMemberList_MouseDoubleClick(System.Windows.RoutedEventArgs e) { }

        private void cboSearchCity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cboCountry_SelectionChanged(object sender, SelectionChangedEventArgs e) { }
    }
}
