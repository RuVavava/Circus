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
    /// Логика взаимодействия для AdminEditAnimalPage.xaml
    /// </summary>
    public partial class AdminEditAnimalPage : Page
    {
        public static List<Cell> cells { get; set; }
        public static List<Gender> genders { get; set; }
        Cell contect_cell;

        public AdminEditAnimalPage(Cell cel_animal)
        {
            InitializeComponent();
            contect_cell = cel_animal;
            OutputInfo();
            this.DataContext = this;
        }

        private void deliteAEmplBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminAnimalsPage());
        }

        private void OutputInfo()
        {
            genders = DBConnection.circus.Gender.ToList();

            nameAnimalTB.Text = contect_cell.Name_Animal;
            viewAnimalTB.Text = contect_cell.View_Animal;
            genderTB.Text = contect_cell.Gender.Name_Gender;
            ageAnimalTB.Text = contect_cell.Age_Animal.ToString();
            careTB.Text = contect_cell.Care;
            foodTB.Text = contect_cell.Food;

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
                    contect_cell.Name_Animal = nameAnimalTB.Text.Trim();
                    contect_cell.Age_Animal = Convert.ToInt16(ageAnimalTB.Text.Trim());
                    contect_cell.View_Animal = viewAnimalTB.Text.Trim();
                    contect_cell.Care = careTB.Text.Trim();
                    contect_cell.Food = foodTB.Text.Trim();
                    var b = genderTB.SelectedItem as Gender;
                    contect_cell.ID_Gender = b.ID_Gender;

                    DBConnection.circus.SaveChanges();
                    NavigationService.Navigate(new Pages.Admin.AdminAnimalsPage());
                }
            }
            catch
            {
                MessageBox.Show("Заполните все поля!");
            }
        }
    }
}
