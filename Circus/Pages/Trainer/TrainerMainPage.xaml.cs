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

namespace Circus.Pages.Trainer
{
    /// <summary>
    /// Логика взаимодействия для TrainerMainPage.xaml
    /// </summary>
    public partial class TrainerMainPage : Page
    {
        public TrainerMainPage()
        {
            InitializeComponent();
        }

        private void profileBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.ProfilePage());
        }

        private void raspisBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.Trainer.TrainerMainPage());
        }

        private void sotrudnikiBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void animalBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AuthorizationPage());
        }
    }
}
