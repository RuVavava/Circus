using Circus.DB;
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
    /// Логика взаимодействия для ArtistRaspisaniePage.xaml
    /// </summary>
    public partial class ArtistRaspisaniePage : Page
    {
        public static List<Schedule_Artist> schedule_Artists {  get; set; }
        public ArtistRaspisaniePage()
        {
            InitializeComponent();
            string surname = DBConnection.loginedWorker.Surname;
            string name = DBConnection.loginedWorker.Name;
            string patronumic = DBConnection.loginedWorker.Patronymic;
            string fio = $"{surname} {name} {patronumic} ";
            nameTB.Text = fio;

            schedule_Artists = new List<Schedule_Artist>(DBConnection.circus.Schedule_Artist.Where(i => i.ID_Artist == DBConnection.loginedWorker.ID_Worker).ToList());
            raspisanieLV.ItemsSource = schedule_Artists;
        }

        private void profileBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProfilePage());
        }

        private void raspisBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Artist.ArtistRaspisaniePage());
        }

        private void zajavkaBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ArtistVSEAplicationssPage());
        }

        private void animalBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }
    }
}
