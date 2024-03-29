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
            string surname = DBConnection.loginedWorker.Surname;
            string name = DBConnection.loginedWorker.Name;
            string patronumic = DBConnection.loginedWorker.Patronymic;
            string fio = $"{surname} {name} {patronumic} ";
            name1TB.Text = fio;
            
            Refresh();
            this.DataContext = this;
        }

        private void exerciseLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (exerciseLV.SelectedItem is Exercise exercise)
            {
                exx = exercise;
                Refresh();
                this.DataContext = this;
                NavigationService.Navigate(new Pages.Personal.PersonalMainPage());

            }
        }

        private void saveStatusBTN_Click(object sender, RoutedEventArgs e)
        {

            Exercise exercise = exx;

            if (nameStatusCB.SelectedIndex == 0)
                exx.Name_Status = "В работе";
            else if (nameStatusCB.SelectedIndex == 1)
                exx.Name_Status = "Выполнено";
            else if (nameStatusCB.SelectedIndex == 2)
                exx.Name_Status = "Отложено";
            exx.Comment = nameCommentTB.Text;
            DBConnection.circus.SaveChanges();
            Refresh();


        }

        public void Refresh()
        {
            string surname = DBConnection.loginedWorker.Surname;
            string name = DBConnection.loginedWorker.Name;
            string patronumic = DBConnection.loginedWorker.Patronymic;
            string fio = $"{surname} {name} {patronumic} ";
            name1TB.Text = fio;

            exercise = new List<Exercise>(DBConnection.circus.Exercise.Where(i => i.ID_Worker == DBConnection.loginedWorker.ID_Worker).ToList());
            exerciseLV.ItemsSource = exercise;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("ОК");
        }

        private void vihodBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AuthorizationPage());
        }

        private void profileBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.ProfilePage());
        }
    }
}
