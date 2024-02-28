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

        private void backBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void profileBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.ProfilePage());
        }

        private void vihodBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AuthorizationPage());
        }

        public void Text()
        {
            opisanieTB.Text = "   Цирковой спектакль «Ночь, улица, фонарь, аптека…» - невероятный коктейль классики русской литературы и российского цирка.\n   Вы увидите симбиоз художественного мастерства и самых разнообразных жанров современного цирка: безупречная дрессура, морские хищники и сложнейшие акробатические трюки.";
        }
    }
}
