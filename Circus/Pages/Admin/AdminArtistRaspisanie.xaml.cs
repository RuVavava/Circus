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
    /// Логика взаимодействия для AdminArtistRaspisanie.xaml
    /// </summary>
    public partial class AdminArtistRaspisanie : Page
    {
        public static List<Workers> artists { get; set; }
        public static List<Schedule_Artist> schedule_Artists { get; set; }
        public static List<Event> events { get; set; }
        public static Schedule_Artist sc = new Schedule_Artist();
        public AdminArtistRaspisanie()
        {
            InitializeComponent();
            artists = DB.DBConnection.circus.Workers.Where(i => i.ID_Role == 2).ToList();
            events = DB.DBConnection.circus.Event.ToList();
            this.DataContext = this;
        }

        private void savenewAEmplBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder error = new StringBuilder();
                if (string.IsNullOrWhiteSpace(artistCB.Text) || string.IsNullOrWhiteSpace(eventCB.Text) ||
                        string.IsNullOrWhiteSpace(dateeventTB.Text))
                {
                    error.AppendLine("Заполните все поля!");
                }
                if (error.Length > 0)
                {
                    MessageBox.Show(error.ToString());
                }
                else
                {
                    var a = artistCB.SelectedItem as Workers;
                    sc.ID_Artist = a.ID_Worker;

                    var b = eventCB.SelectedItem as Event;
                    sc.ID_Event = b.ID_Event;

                    sc.Date = dateeventTB.SelectedDate;

                    sc.Time = (timeeventTB.SelectedTime.Value);
                    sc.Hour = Convert.ToInt16(houreventTB.Text.Trim());

                    DBConnection.circus.Schedule_Artist.Add(sc);
                    DBConnection.circus.SaveChanges();
                    NavigationService.Navigate(new Pages.Admin.AdminArtistPage());
                }
            }
            catch
            {
                MessageBox.Show("Заполните все поля!");
            }
        }
    }
}
