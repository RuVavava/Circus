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
    /// Логика взаимодействия для AdminAddZadaniePage.xaml
    /// </summary>
    public partial class AdminAddZadaniePage : Page
    {
        public static List<Workers> artists { get; set; }
        public static List<DB.Application> application_a { get; set; }
        DB.Application conte_app;
        public AdminAddZadaniePage(DB.Application application)
        {
            InitializeComponent();
            conte_app = application;
            string surname = conte_app.Workers.Surname;
            string name = conte_app.Workers.Name;
            string patronumic = conte_app.Workers.Patronymic;
            string fio = $"{surname} {name} {patronumic} ";
            nameArtistTB.Text = fio;
            datezartistTB.Text = Convert.ToString(conte_app.Date_Application);
            DescriptionTBB.Text = conte_app.Description;


            this.DataContext = this;
        }

        private void savestatBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder error = new StringBuilder();
                if (string.IsNullOrWhiteSpace(DescriptionTBB.Text) || string.IsNullOrWhiteSpace(nameStatusCB.Text))
                {
                    error.AppendLine("Заполните все поля!");
                }
                if (error.Length > 0)
                {
                    MessageBox.Show(error.ToString());
                }
                else
                {
                    conte_app.Description = DescriptionTBB.Text.Trim();
                    if (nameStatusCB.SelectedIndex == 0)
                        conte_app.StatusApplication = "В работе";
                    else if (nameStatusCB.SelectedIndex == 1)
                        conte_app.StatusApplication = "Выполнено";
                    else if (nameStatusCB.SelectedIndex == 2)
                        conte_app.StatusApplication = "Отложено";

                    DBConnection.circus.SaveChanges();
                    NavigationService.Navigate(new Pages.Admin.AdminArtistPage());
                }
            }
            catch
            {
                MessageBox.Show("Заполните все поля!");
            }
        }

        private void backBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminArtistPage());
        }
    }
}
