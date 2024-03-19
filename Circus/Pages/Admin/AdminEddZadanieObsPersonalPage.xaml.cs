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
    /// Логика взаимодействия для AdminEddZadanieObsPersonalPage.xaml
    /// </summary>
    public partial class AdminEddZadanieObsPersonalPage : Page
    {
        public static List<Exercise > exercises { get; set; }
        Exercise context_exx;
        public AdminEddZadanieObsPersonalPage(Exercise exercises)
        {
            InitializeComponent();
            context_exx = exercises;
            obspersTB.Text = context_exx.Workers.Surname.ToString() + " " + context_exx.Workers.Name.ToString() + " " + context_exx.Workers.Patronymic.ToString();
            obspersdescrTB.Text = context_exx.Description;
            comment_obspersTB.Text = context_exx.Comment;
        }

        private void savezadanieobspersBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder error = new StringBuilder();
                if (string.IsNullOrWhiteSpace(comment_obspersTB.Text))
                {
                    error.AppendLine("Заполните все поля!");
                }
                if (error.Length > 0)
                {
                    MessageBox.Show(error.ToString());
                }
                else
                {
                    context_exx.Comment = comment_obspersTB.Text.Trim();
                    context_exx.Name_Status = "Отложено";
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
