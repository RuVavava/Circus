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

namespace Circus.Pages.Admin
{
    /// <summary>
    /// Логика взаимодействия для AdminArtistPage.xaml
    /// </summary>
    public partial class AdminArtistPage : Page
    {
        public static List<Workers> artists { get; set; }
        public static List<DB.Application> application_a { get; set; }
        public static List<Schedule_Artist> schedule_Artists { get; set; }
        public static List<Event> events { get; set; }
        Workers conte_artist;
        public AdminArtistPage()
        {
            InitializeComponent();
            Refresh();
        }

        public void Refresh()
        {
            string surname = DBConnection.loginedWorker.Surname;
            string name = DBConnection.loginedWorker.Name;
            string patronumic = DBConnection.loginedWorker.Patronymic;
            string fio = $"{surname} {name} {patronumic} ";
            name1TB.Text = fio;

            artists = new List<Workers>(DBConnection.circus.Workers.Where(i => i.ID_Role == 3).ToList());
            artistsLV.ItemsSource = artists;
            this.DataContext = this;
        }

        private void artistsLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (artistsLV.SelectedItem is Workers artist)
            {
                conte_artist = artist;

                schedule_Artists = new List<Schedule_Artist>(DBConnection.circus.Schedule_Artist.Where(i => i.ID_Artist == conte_artist.ID_Worker).ToList());
                artistSchLV.ItemsSource = schedule_Artists;

                application_a = new List<DB.Application>(DBConnection.circus.Application.Where(i => i.ID_Artiat == conte_artist.ID_Worker).ToList());
                artistAplLV.ItemsSource = application_a;

                Refresh();
                this.DataContext = this;

            }
        }


        private void profileBTN_Click(object sender, RoutedEventArgs e) //Профиль
        {
            NavigationService.Navigate(new Pages.ProfilePage());
        }

        private void vihodBTN_Click(object sender, RoutedEventArgs e) //Выход
        {
            NavigationService.Navigate(new Pages.AuthorizationPage());
        }

        private void sotrudnikiBTN_Click(object sender, RoutedEventArgs e) //Сотрудники
        {
            NavigationService.Navigate(new Pages.Admin.AdminEmployeesPages());
        }

        private void mainBTN_Click(object sender, RoutedEventArgs e) //Главная
        {
            NavigationService.Navigate(new Pages.Admin.AdminMainPage());
        }

        private void animalBTN_Click(object sender, RoutedEventArgs e) //Животные
        {
            NavigationService.Navigate(new Pages.Admin.AdminAnimalsPage());
        }

        private void artistBTN_Click(object sender, RoutedEventArgs e) //Артысты
        {
            NavigationService.Navigate(new Pages.Admin.AdminArtistPage());
        }

        private void obspersBTN_Click(object sender, RoutedEventArgs e) //Персонал обсл
        {
            NavigationService.Navigate(new Pages.Admin.AdminObslPersPage());
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchTB.Text.Length > 0)
            {
                artistsLV.ItemsSource = new List<Workers>(DBConnection.circus.Workers.
                    Where(i => i.Surname.ToLower().StartsWith(SearchTB.Text.Trim().ToLower()) ||
                    i.Name.ToLower().StartsWith(SearchTB.Text.Trim().ToLower()) ||
                    i.Patronymic.ToLower().StartsWith(SearchTB.Text.Trim().ToLower()) && i.ID_Role == 2));

            }
            else
            {
                artistsLV.ItemsSource = new List<Workers>(DBConnection.circus.Workers.ToList());
            }
        }

        private void deliteAEmplBTN_Click(object sender, RoutedEventArgs e)
        {
            if (artistSchLV.SelectedItem is Schedule_Artist sc)
            {
                DBConnection.circus.Schedule_Artist.Remove(sc);
                DBConnection.circus.SaveChanges();
            }
            else if(artistAplLV.SelectedItem is DB.Application pl)
            {
                DBConnection.circus.Application.Remove(pl);
                DBConnection.circus.SaveChanges();
            }
            Refresh();
            NavigationService.Navigate(new Pages.Admin.AdminArtistPage());
        }

        private void newAEmplBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.Admin.AdminArtistRaspisanie());
        }

        private void editstatusArtistlBTN_Click(object sender, RoutedEventArgs e)
        {
            if (artistAplLV.SelectedItem is DB.Application pl)
            {
                NavigationService.Navigate(new Admin.AdminAddZadaniePage(pl));
            }
        }
    }
}
