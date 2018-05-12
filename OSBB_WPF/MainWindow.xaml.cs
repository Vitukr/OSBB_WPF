using OSBB_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OSBB_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
        }

        private void ButtonAnnouncement_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var userName = TextBoxLogin.Text.Trim();
                var password = TextBoxPassword.Text.Trim();
                var data = WebService.UseWebClient<AnnouncementApi>(@"http://vysoft.top/api/AnnouncementsApi", userName, password);
                DataGridData.DataContext = data;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void ButtonContribution_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var userName = TextBoxLogin.Text.Trim();
                var password = TextBoxPassword.Text.Trim();
                var data = WebService.UseWebClient<ContributionApi>(@"http://vysoft.top/api/ContributionsApi", userName, password);  
                DataGridData.DataContext = data;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
