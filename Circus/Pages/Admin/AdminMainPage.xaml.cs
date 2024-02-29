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
    /// Логика взаимодействия для AdminMainPage.xaml
    /// </summary>
    public partial class AdminMainPage : Page
    {
        public AdminMainPage()
        {
            InitializeComponent();
            Text();
        }

        public void Text()
        {
            opisanieTB.Text = "   Цирковой спектакль «Ночь, улица, фонарь, аптека…» - невероятный коктейль классики русской литературы и российского цирка.\n   Вы увидите симбиоз художественного мастерства и самых разнообразных жанров современного цирка: безупречная дрессура, морские хищники и сложнейшие акробатические трюки.";
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
    }
}
