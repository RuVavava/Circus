﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public static Exercise exx { get; set; }
        Exercise contexexx;
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
                exx = exercise;
                this.DataContext = this;
                NavigationService.Navigate(new Pages.Personal.PersonalMainPage());

            }
        }

        private void saveStatusBTN_Click(object sender, RoutedEventArgs e)
        {
            var error = string.Empty;
            var validationContext = new ValidationContext(contexexx);
            var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();

            if (Validator.TryValidateObject(contexexx, validationContext, results, true))
            {
                foreach (var result in results)
                {
                    error += $"{result.ErrorMessage}\n";
                }
            }
            if (!string.IsNullOrWhiteSpace(error))
            {
                MessageBox.Show(error);
                return;
            }

            if (contexexx.ID_Exercise == 0)
            DBConnection.circus.Exercise.Add(contexexx);
            DBConnection.circus.SaveChanges();
            NavigationService.Navigate(new Pages.AuthorizationPage());
        }
    }
}
