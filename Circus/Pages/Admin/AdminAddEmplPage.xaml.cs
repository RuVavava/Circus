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
    /// Логика взаимодействия для AdminAddEmplPage.xaml
    /// </summary>
    public partial class AdminAddEmplPage : Page
    {
        public static List<Workers> workers { get; set; }
        public static List<Role> roles { get; set; }
        public static List<Gender> genders { get; set; }
        public static Workers worker = new Workers();
        public AdminAddEmplPage()
        {
            InitializeComponent();
            workers = DBConnection.circus.Workers.ToList();
            roles = DBConnection.circus.Role.ToList();
            genders = DBConnection.circus.Gender.ToList();
            this.DataContext = this;
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
                    worker.Surname = surnameTB.Text.Trim();
                    worker.Name = nameTB.Text.Trim();
                    worker.Patronymic = patrnameTB.Text.Trim();
                    worker.BH = bhTB.SelectedDate;
                    worker.Login = Convert.ToInt16(loginTB.Text.Trim());
                    worker.Password = Convert.ToInt16(passwordTB.Text.Trim());
                    var a = roleTB.SelectedItem as Role;
                    worker.ID_Role = a.ID_Role;

                    var b = genderTB.SelectedItem as Gender;
                    worker.ID_Gender = b.ID_Gender;

                    DBConnection.circus.Workers.Add(worker);
                    DBConnection.circus.SaveChanges();
                    NavigationService.Navigate(new Pages.Admin.AdminEmployeesPages());
                }
            }
            catch
            {
                MessageBox.Show("Заполните все поля!");
            }
        }
    }
}
