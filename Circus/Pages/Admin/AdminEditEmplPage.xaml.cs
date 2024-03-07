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

using Circus.DB;

namespace Circus.Pages.Admin
{
    /// <summary>
    /// Логика взаимодействия для AdminEditEmplPage.xaml
    /// </summary>
    public partial class AdminEditEmplPage : Page
    {
        public static List<Workers> workers { get; set; }
        public static List<Role> roles { get; set; }
        public static List<Gender> genders { get; set; }
        Workers context_worker;
        public AdminEditEmplPage(Workers worker)
        {
            InitializeComponent();
            context_worker = worker;
            OutputInfo();
        }

        private void deliteAEmplBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void savenewAEmplBTN_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                StringBuilder error = new StringBuilder();
                if (string.IsNullOrWhiteSpace(surnameTB.Text) || string.IsNullOrWhiteSpace(nameTB.Text) || string.IsNullOrWhiteSpace(patrnameTB.Text) ||
                        bhTB.SelectedDate == null || string.IsNullOrWhiteSpace(genderTB.Text) || string.IsNullOrWhiteSpace(loginTB.Text) ||
                        string.IsNullOrWhiteSpace(passwordTB.Text))
                {
                    error.AppendLine("Заполните все поля!");
                }
                if (bhTB.SelectedDate != null && (DateTime.Now - (DateTime)bhTB.SelectedDate).TotalDays < 365 * 18 + 4)
                {
                    error.AppendLine("Сотрудник не может быть младше 18 лет.");
                }
                if (error.Length > 0)
                {
                    MessageBox.Show(error.ToString());
                }
                else
                {
                    context_worker.Surname = surnameTB.Text;
                    context_worker.Name = nameTB.Text;
                    context_worker.Patronymic = patrnameTB.Text;
                    context_worker.Login = Convert.ToInt16(loginTB.Text);
                    context_worker.Password = Convert.ToInt16(passwordTB.Text);

                    var a = roleTB.SelectedItem as Role;
                    context_worker.ID_Role = a.ID_Role;

                    var b = genderTB.SelectedItem as Gender;
                    context_worker.ID_Gender = b.ID_Gender;

                    DBConnection.circus.SaveChanges();
                    NavigationService.Navigate(new Pages.Admin.AdminEmployeesPages());
                }
            }
            catch
            {
                MessageBox.Show("Заполните все поля!");
            }

        }

        private void OutputInfo()
        {
            roles = DBConnection.circus.Role.ToList();
            genders = DBConnection.circus.Gender.ToList();

            surnameTB.Text = context_worker.Surname;
            nameTB.Text = context_worker.Name;
            patrnameTB.Text = context_worker.Patronymic;
            bhTB.Text = Convert.ToString(context_worker.BH);
            roleTB.ItemsSource = context_worker.Role.Name_Role;
            genderTB.ItemsSource = context_worker.Gender.Name_Gender;
            loginTB.Text = Convert.ToString(context_worker.Login);
            passwordTB.Text = Convert.ToString(context_worker.Password);

            this.DataContext = this;

        }
    }
}
