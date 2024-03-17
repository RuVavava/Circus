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
    /// Логика взаимодействия для TrainerMainPage.xaml
    /// </summary>
    public partial class TrainerMainPage : Page
    {
        public static List<Schedule_Trainer> raspisanie { get; set; }
        public static Schedule_Trainer st { get; set; }
        public TrainerMainPage()
        {
            InitializeComponent();
            OutPutInfo();
            this.DataContext = this;
        }

        private void profileBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.ProfilePage());
        }

        private void raspisBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.Trainer.TrainerMainPage());
        }


        private void animalBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AuthorizationPage());
        }

        private void OutPutInfo()
        {
            string surname = DBConnection.loginedWorker.Surname;
            string name = DBConnection.loginedWorker.Name;
            string patronumic = DBConnection.loginedWorker.Patronymic;
            string fio = $"{surname} {name} {patronumic} ";
            nameTB.Text = fio;

            raspisanie = new List<Schedule_Trainer>(DBConnection.circus.Schedule_Trainer.Where(i => i.ID_Trainer == DBConnection.loginedWorker.ID_Worker).ToList());
            raspisanieLV.ItemsSource = raspisanie;

        }

        private void raspisanieLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (raspisanieLV.SelectedItem is Schedule_Trainer schedule_Trainer)
            {
                st = schedule_Trainer;
                OutPutInfo();
                this.DataContext = this;
                NavigationService.Navigate(new Pages.Trainer.TrainerMainPage());

            }
        }

        private void anmalsBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.Trainer.TrainerAnimalPage());
        }

        private void okBTN_Click(object sender, RoutedEventArgs e)
        {
            Schedule_Trainer schedule_Trainer = st;

            if (nameStatusCB.SelectedIndex == 0)
                st.Name_Status = "В работе";
            else if (nameStatusCB.SelectedIndex == 1)
                st.Name_Status = "Выполнено";
            DBConnection.circus.SaveChanges();
            OutPutInfo();
        }

        private void newAEmplBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.Trainer.TrainerAddRaspisaniePage());
        }
    }
}
