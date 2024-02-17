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
using System.Windows.Shapes;

namespace Circus.Pages.Personal
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public static List<Exercise> exercise { get; set; }
        public static Exercise exxx { get; set; }
        Exercise contextex;
        public Window1(Exercise exercise)
        {
            InitializeComponent();
            contextex = exercise;
            exxx = exercise;
        }
    }
}
