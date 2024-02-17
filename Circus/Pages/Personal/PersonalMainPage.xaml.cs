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

namespace Circus.Pages.Personal
{
    /// <summary>
    /// Логика взаимодействия для PersonalMainPage.xaml
    /// </summary>
    public partial class PersonalMainPage : Page
    {
        public static List<Exercise> exercise {  get; set; }
        public static Exercise ex { get; set; }
        public PersonalMainPage()
        {
            InitializeComponent();
            exercise = new List<Exercise>(DBConnection.circus.Exercise.Where(i => i.ID_Worker == DBConnection.loginedWorker.ID_Worker).ToList());
            exerciseLV.ItemsSource = exercise;
            this.DataContext = this;
        }

        private void exerciseLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (exerciseLV.SelectedItem is Exercise exercise)
            {

                var lb = sender as ListView;
                //nameDescriptionTB.Text = (lb.SelectedIndex + 1).ToString();
                //var vib = (lb.SelectedIndex);
                //nameDescriptionTB.Text = DBConnection.circus.Exercise.Where(i => i.ID_Exercise == vib).ToString();

            }
        }
    }
}
