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
    /// Логика взаимодействия для TrainerAddRaspisaniePage.xaml
    /// </summary>
    public partial class TrainerAddRaspisaniePage : Page
    {
        public static List<Cell> cells { get; set; }
        public static List<Schedule_Trainer> schedule_Trainers { get; set; }
        public static Schedule_Trainer sc_t = new Schedule_Trainer();
        public TrainerAddRaspisaniePage()
        {
            InitializeComponent();
            cells = DB.DBConnection.circus.Cell.ToList();
            this.DataContext = this;
        }

        private void savenewAEmplBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder error = new StringBuilder();
                if (string.IsNullOrWhiteSpace(animalsCB.Text) || string.IsNullOrWhiteSpace(datetrTB.Text) ||
                        string.IsNullOrWhiteSpace(timetrTB.Text) || string.IsNullOrWhiteSpace(hourtrTB.Text))
                {
                    error.AppendLine("Заполните все поля!");
                }
                if (error.Length > 0)
                {
                    MessageBox.Show(error.ToString());
                }
                else
                {
                    sc_t.ID_Trainer = DBConnection.loginedWorker.ID_Worker;
                    var a = animalsCB.SelectedItem as Cell;
                    sc_t.ID_Cell = a.ID_Cell;

                    sc_t.Date = datetrTB.SelectedDate;

                    sc_t.Time = (timetrTB.SelectedTime.Value);
                    sc_t.Hour = Convert.ToInt16(hourtrTB.Text.Trim());
                    sc_t.Name_Status = "Не выполнено";

                    DBConnection.circus.Schedule_Trainer.Add(sc_t);
                    DBConnection.circus.SaveChanges();
                    NavigationService.Navigate(new Pages.Trainer.TrainerMainPage());
                }
            }
            catch
            {
                MessageBox.Show("Заполните все поля!");
            }
        }

        private void deliteAEmplBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.Trainer.TrainerMainPage());
        }
    }
}
