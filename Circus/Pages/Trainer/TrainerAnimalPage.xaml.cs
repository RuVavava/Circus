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

namespace Circus.Pages.Trainer
{
    /// <summary>
    /// Логика взаимодействия для TrainerAnimalPage.xaml
    /// </summary>
    public partial class TrainerAnimalPage : Page
    {
        public static List<Cell> cells { get; set; }
        public TrainerAnimalPage()
        {
            InitializeComponent();
            cells = new List<Cell>(DBConnection.circus.Cell.ToList());
            animalsLV.ItemsSource = cells;
        }

        private void profileBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.ProfilePage());
        }

        private void raspisBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.Trainer.TrainerMainPage());
        }

        private void animalsBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.Trainer.TrainerAnimalPage());
        }

        private void backBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AuthorizationPage());
        }
    }
}
