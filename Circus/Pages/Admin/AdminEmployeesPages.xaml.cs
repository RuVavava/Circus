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
    /// Логика взаимодействия для AdminEmployeesPages.xaml
    /// </summary>
    public partial class AdminEmployeesPages : Page
    {
        public static List<Workers> workers { get; set; }
        public AdminEmployeesPages()
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

            workers = new List<Workers>(DBConnection.circus.Workers.ToList());
            workersLV.ItemsSource = workers;
        }

        //----------------------------------------------------------------------------------------------------
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

        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchTB.Text.Length > 0)
            {
                workersLV.ItemsSource = new List<Workers>(DBConnection.circus.Workers.
                    Where(i => i.Surname.ToLower().StartsWith(SearchTB.Text.Trim().ToLower()) ||
                    i.Name.ToLower().StartsWith(SearchTB.Text.Trim().ToLower()) ||
                    i.Patronymic.ToLower().StartsWith(SearchTB.Text.Trim().ToLower())));

            }
            else
            {
                workersLV.ItemsSource = new List<Workers>(DBConnection.circus.Workers.ToList());
            }
        }

        private void deliteAEmplBTN_Click(object sender, RoutedEventArgs e)
        {
            if (workersLV.SelectedItem is Workers workers)
            {
                DBConnection.circus.Workers.Remove(workers);
                DBConnection.circus.SaveChanges();
            }
            Refresh();
        }

        private void newAEmplBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.Admin.AdminAddEmplPage());
        }

    }
}
