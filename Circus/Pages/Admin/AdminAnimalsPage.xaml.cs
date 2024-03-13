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
    /// Логика взаимодействия для AdminAnimalsPage.xaml
    /// </summary>
    public partial class AdminAnimalsPage : Page
    {
        public static List<Cell> cells { get; set; }
        public AdminAnimalsPage()
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

            cells = new List<Cell>(DBConnection.circus.Cell.ToList());
            animalsLV.ItemsSource = cells;
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

        private void deliteAEmplBTN_Click(object sender, RoutedEventArgs e)
        {
            if (animalsLV.SelectedItem is Cell cells)
            {
                DBConnection.circus.Cell.Remove(cells);
                DBConnection.circus.SaveChanges();
            }
            Refresh();
        }

        private void newAEmplBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.Admin.AdminAddAnimalPage());
        }

        private void editAnimlBTN_Click(object sender, RoutedEventArgs e)
        {
            if (animalsLV.SelectedItem is Cell cells)
            {
                animalsLV.SelectedItem = null;
                NavigationService.Navigate(new Pages.Admin.AdminEditAnimalPage());
                Refresh();
            }
        }
    }
}
