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
    /// Логика взаимодействия для AdminTrainerWorkPage.xaml
    /// </summary>
    public partial class AdminTrainerWorkPage : Page
    {
        public static List<Schedule_Trainer> raspisanie { get; set; }
        public static List<Workers> trainers { get; set; }
        public AdminTrainerWorkPage()
        {
            InitializeComponent();
            Refresh();

        }

        private void backBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminAnimalsPage());
        }

        private void treinerCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = treinerCB.SelectedItem as Workers;
            raspisanieLV.ItemsSource = new List<Schedule_Trainer>(DBConnection.circus.Schedule_Trainer.Where(x => x.ID_Trainer == a.ID_Worker).ToList());
            this.DataContext = this;
        }

        private void deliteTrenirovkaBTN_Click(object sender, RoutedEventArgs e)
        {
            if (raspisanieLV.SelectedItem is Schedule_Trainer sc)
            {
                DBConnection.circus.Schedule_Trainer.Remove(sc);
                DBConnection.circus.SaveChanges();
            }
            Refresh();
            NavigationService.Navigate(new AdminTrainerWorkPage());
        }

        private void Refresh()
        {
            trainers = DB.DBConnection.circus.Workers.Where(i => i.ID_Role == 2).ToList();
            raspisanie = new List<Schedule_Trainer>(DBConnection.circus.Schedule_Trainer.ToList());
            raspisanieLV.ItemsSource = raspisanie;
            this.DataContext = this;
        }
    }
}
