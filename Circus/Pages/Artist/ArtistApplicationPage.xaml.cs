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

namespace Circus.Pages.Artist
{
    /// <summary>
    /// Логика взаимодействия для ArtistApplicationPage.xaml
    /// </summary>
    public partial class ArtistApplicationPage : Page
    {
        public static List<DB.Application> application_a { get; set; }
        public static DB.Application app = new DB.Application();
        public ArtistApplicationPage()
        {
            InitializeComponent();
            datezartistTB.Text = DateTime.Now.ToString();
        }

        private void savestatBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder error = new StringBuilder();
                if (string.IsNullOrWhiteSpace(DescriptionTBB.Text))
                {
                    error.AppendLine("Заполните все поля!");
                }
                if (error.Length > 0)
                {
                    MessageBox.Show(error.ToString());
                }
                else
                {
                    app.ID_Artiat = DBConnection.loginedWorker.ID_Worker;
                    app.Date_Application = DateTime.Now;
                    app.Description = DescriptionTBB.Text.Trim();
                    app.StatusApplication = "Новое";

                    DBConnection.circus.Application.Add(app);
                    DBConnection.circus.SaveChanges();
                    NavigationService.Navigate(new Pages.Artist.ArtistVSEAplicationssPage());
                }
            }
            catch
            {
                MessageBox.Show("Заполните все поля!");
            }
        }

        private void backBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ArtistVSEAplicationssPage());
        }
    }
}
