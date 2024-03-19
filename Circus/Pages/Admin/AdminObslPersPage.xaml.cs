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
using static System.Net.Mime.MediaTypeNames;

namespace Circus.Pages.Admin
{
    /// <summary>
    /// Логика взаимодействия для AdminObslPersPage.xaml
    /// </summary>
    public partial class AdminObslPersPage : Page
    {
        public static List<Workers> obspers { get; set; }
        public static List<Exercise> exercise { get; set; }
        Workers conte_obs;
        Exercise conte_exercise;
        public AdminObslPersPage()
        {
            InitializeComponent();
            obspers = new List<Workers>(DBConnection.circus.Workers.Where(i => i.ID_Role == 4).ToList());
            obspersLV.ItemsSource = obspers;
            this.DataContext = this;
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

        private void obspersLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (obspersLV.SelectedItem is Workers obspers)
            {
                conte_obs = obspers;

                exercise = new List<Exercise>(DBConnection.circus.Exercise.Where(i => i.ID_Worker == conte_obs.ID_Worker).ToList());
                zadachhLV.ItemsSource = exercise;

                this.DataContext = this;

            }
        }

        private void newZadanBTN_Click(object sender, RoutedEventArgs e) //Новое
        {
            NavigationService.Navigate(new Pages.Admin.AdminAddZadanieObsPersPage());
        }

        private void deliteZadanBTN_Click(object sender, RoutedEventArgs e) //Удалить
        {
            if (zadachhLV.SelectedItem is Exercise exc)
            {
                DBConnection.circus.Exercise.Remove(exc);
                DBConnection.circus.SaveChanges();
            }
            NavigationService.Navigate(new Pages.Admin.AdminObslPersPage());
        }

        private void editZadanBTN_Click(object sender, RoutedEventArgs e) //Редактировать
        {

            if (zadachhLV.SelectedItem is Exercise exercise)
            {
                zadachhLV.SelectedItem = null;
                NavigationService.Navigate(new Pages.Admin.AdminEddZadanieObsPersonalPage(exercise));
            }
        }
    }
}
