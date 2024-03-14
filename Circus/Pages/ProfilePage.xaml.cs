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

namespace Circus.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        public ProfilePage()
        {
            InitializeComponent();
            string surname = DBConnection.loginedWorker.Surname;
            string name = DBConnection.loginedWorker.Name;
            string patronumic = DBConnection.loginedWorker.Patronymic;
            string fio = $"{surname} {name} {patronumic}";
            nameProfileTB.Text = fio;


            surnameTB.Text = DBConnection.loginedWorker.Surname;
            nameTB.Text = DBConnection.loginedWorker.Name;
            patrnameTB.Text = DBConnection.loginedWorker.Patronymic;
            bhTB.Text = Convert.ToString(DBConnection.loginedWorker.BH);
            roleTB.Text = DBConnection.loginedWorker.Role.Name_Role;
            loginTB.Text = Convert.ToString(DBConnection.loginedWorker.Login);
            passwordTB.Text = Convert.ToString(DBConnection.loginedWorker.Password);

            CheckConditionAndToggleButtonVisibility();
            this.DataContext = this;
        }

        private void backBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void CheckConditionAndToggleButtonVisibility()
        {
            if (DBConnection.loginedWorker.ID_Role == 1)
            {
                AdminPhoto.Visibility = Visibility.Visible; // Показать кнопку
            }
            else
            {
                AdminPhoto.Visibility = Visibility.Collapsed; // Скрыть кнопку
            }

            if (DBConnection.loginedWorker.ID_Role == 3)
            {
                ArtistPhoto.Visibility = Visibility.Visible; // Показать кнопку
            }
            else
            {
                ArtistPhoto.Visibility = Visibility.Collapsed; // Скрыть кнопку
            }

            if (DBConnection.loginedWorker.ID_Role == 2)
            {
                AnimalPhoto.Visibility = Visibility.Visible; // Показать кнопку
            }
            else
            {
                AnimalPhoto.Visibility = Visibility.Collapsed; // Скрыть кнопку
            }

            if (DBConnection.loginedWorker.ID_Role == 4)
            {
                ObsPersPhoto.Visibility = Visibility.Visible; // Показать кнопку
            }
            else
            {
                ObsPersPhoto.Visibility = Visibility.Collapsed; // Скрыть кнопку
            }
        }
    }
}
