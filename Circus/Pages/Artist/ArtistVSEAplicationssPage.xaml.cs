using Circus.DB;
using Circus.Pages.Admin;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Circus.Pages.Artist
{
    /// <summary>
    /// Логика взаимодействия для ArtistVSEAplicationssPage.xaml
    /// </summary>
    public partial class ArtistVSEAplicationssPage : Page
    {
        public static List<DB.Application> application_a { get; set; }
        public ArtistVSEAplicationssPage()
        {
            InitializeComponent();
            string surname = DBConnection.loginedWorker.Surname;
            string name = DBConnection.loginedWorker.Name;
            string patronumic = DBConnection.loginedWorker.Patronymic;
            string fio = $"{surname} {name} {patronumic} ";
            nameTB.Text = fio;

            application_a = new List<DB.Application>(DBConnection.circus.Application.Where(i => i.ID_Artiat == DBConnection.loginedWorker.ID_Worker).ToList());
            applicationsLV.ItemsSource = application_a;
        }

        private void newappBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ArtistApplicationPage());
        }

        private void profileBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProfilePage());
        }

        private void raspisBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ArtistRaspisaniePage());
        }

        private void zajavkaBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ArtistVSEAplicationssPage());
        }

        private void backBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }
    }
}
