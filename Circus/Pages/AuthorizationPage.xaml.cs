using Circus.DB;
using System;
using System.Collections.Generic;
using System.Data.Common;
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

namespace Circus.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public static List<Workers> workers {  get; set; }
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void entranceBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int login = Convert.ToInt32(loginTB.Text.Trim());
                int password = Convert.ToInt32(passwordTB.Password.Trim());

                var workers = DBConnection.circus.Workers.ToList();
                var curret_worker = workers.FirstOrDefault(i => i.Login == login && i.Password == password);
                DBConnection.loginedWorker = curret_worker;

                if (curret_worker != null && curret_worker.Role.Name_Role == "Администратор")
                    MessageBox.Show("АДМИН!");
                else if (curret_worker != null && curret_worker.Role.Name_Role == "Артист")
                    MessageBox.Show("АКТЕР!");
                else if (curret_worker != null && curret_worker.Role.Name_Role == "Дрессировщик")
                    MessageBox.Show("ДРЕССИРОВЩИК!");
                else if (curret_worker != null && curret_worker.Role.Name_Role == "Обслуживающий персонал")
                    NavigationService.Navigate(new Pages.Personal.PersonalMainPage());
                else
                    MessageBox.Show("Введенные данные некорректны!");
            }
            catch { MessageBox.Show("Возникла ошибка входа!"); }
        }
    }
}
