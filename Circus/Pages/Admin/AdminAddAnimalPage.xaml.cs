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
    /// Логика взаимодействия для AdminAddAnimalPage.xaml
    /// </summary>
    public partial class AdminAddAnimalPage : Page
    {
        public static List<Cell> cells { get; set; }
        public static List<Gender> genders { get; set; }
        public static Cell cell = new Cell();
        public AdminAddAnimalPage()
        {
            InitializeComponent();
            genders = DBConnection.circus.Gender.ToList();
            cells = DBConnection.circus.Cell.ToList();
            this.DataContext = this;
        }

        private void savenewAEmplBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder error = new StringBuilder();
                if (string.IsNullOrWhiteSpace(nameAnimalTB.Text) || string.IsNullOrWhiteSpace(ageAnimalTB.Text) ||
                        string.IsNullOrWhiteSpace(careTB.Text) || string.IsNullOrWhiteSpace(genderTB.Text) || string.IsNullOrWhiteSpace(foodTB.Text))
                {
                    error.AppendLine("Заполните все поля!");
                }
                if (error.Length > 0)
                {
                    MessageBox.Show(error.ToString());
                }
                else
                {
                    cell.Name_Animal = nameAnimalTB.Text.Trim();
                    cell.Age_Animal = Convert.ToInt16(ageAnimalTB.Text.Trim());
                    cell.View_Animal = viewAnimalTB.Text.Trim();
                    cell.Care = careTB.Text.Trim();
                    cell.Food = foodTB.Text.Trim();
                    var b = genderTB.SelectedItem as Gender;
                    cell.ID_Gender = b.ID_Gender;

                    DBConnection.circus.Cell.Add(cell);
                    DBConnection.circus.SaveChanges();
                    NavigationService.Navigate(new Pages.Admin.AdminAnimalsPage());
                }
            }
            catch
            {
                MessageBox.Show("Заполните все поля!");
            }
        }

        private void deliteAEmplBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.Admin.AdminAnimalsPage());
        }
    }
}
