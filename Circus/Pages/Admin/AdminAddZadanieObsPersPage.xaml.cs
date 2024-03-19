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
    /// Логика взаимодействия для AdminAddZadanieObsPersPage.xaml
    /// </summary>
    public partial class AdminAddZadanieObsPersPage : Page
    {
        public static List<Workers> obspersonal { get; set; }
        public static Exercise exx = new Exercise();
        public AdminAddZadanieObsPersPage()
        {
            InitializeComponent();
            obspersonal = DB.DBConnection.circus.Workers.Where(i => i.ID_Role == 4).ToList();
            this.DataContext = this;

        }

        private void savezadanieobspersBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder error = new StringBuilder();
                if (string.IsNullOrWhiteSpace(obspersCB.Text) || string.IsNullOrWhiteSpace(obspersdescrTB.Text))
                {
                    error.AppendLine("Заполните все поля!");
                }
                if (error.Length > 0)
                {
                    MessageBox.Show(error.ToString());
                }
                else
                {
                    var a = obspersCB.SelectedItem as Workers;
                    exx.ID_Worker = a.ID_Worker;

                    exx.Description= obspersdescrTB.Text;
                    exx.Name_Status = "Новое";
                    exx.Comment = "";

                    DBConnection.circus.Exercise.Add(exx);
                    DBConnection.circus.SaveChanges();
                    NavigationService.Navigate(new Pages.Admin.AdminObslPersPage());
                }
            }
            catch
            {
                MessageBox.Show("Заполните все поля!");
            }
        }

        private void backBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.Admin.AdminObslPersPage());
        }
    }
}
