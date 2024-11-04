using OlimpiadaForYou.database;
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

namespace OlimpiadaForYou
{
    /// <summary>
    /// Логика взаимодействия для OlimpCreator.xaml
    /// </summary>
    public partial class OlimpCreator : Window
    {
        public OlimpCreator()
        {
            InitializeComponent();
            ListViewFull();

            var Difficulty = App.Context.Olimp_Difficulty.Select(p => p.Title).ToList();
            cb_diff.ItemsSource = Difficulty;

            var Category = App.Context.Olimp_Class.Select(p => p.Interval).ToList();
            cb_cat.ItemsSource = Category;

            var Subjects = App.Context.Olimp_Subject.Select(p => p.Title).ToList();
            cb_sub.ItemsSource = Subjects;
        }

        private void ListViewFull()
        {
            var LVfill = App.Context.Olimp_Olimp.Where(p => p.ID_Creator == App._Olimp_Users.ID).ToList();

            if (LVfill != null && LVfill.Count > 0)
            {
                lvList.ItemsSource = LVfill;
            }
            else
            {
                lvList.ItemsSource = null;
            }
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CreatorWindow creatorWindow = new CreatorWindow();
            creatorWindow.Show();
            this.Close();
        }

        private void but_Find_Click(object sender, RoutedEventArgs e)
        {
            but_Remove.Visibility = Visibility.Visible;

            var selectedDifficulty = cb_diff.SelectedItem as string;
            var selectedCategory = cb_cat.SelectedItem as string;
            var selectedSubject = cb_sub.SelectedItem as string;

            var query = App.Context.Olimp_Olimp.AsQueryable();

            if (!string.IsNullOrEmpty(selectedDifficulty))
            {
                query = query.Where(olimp => olimp.Olimp_Difficulty.Title == selectedDifficulty);
            }

            if (!string.IsNullOrEmpty(selectedCategory))
            {
                query = query.Where(olimp => olimp.Olimp_Class.Interval == selectedCategory);
            }

            if (!string.IsNullOrEmpty(selectedSubject))
            {
                query = query.Where(olimp => olimp.Olimp_Subject.Title == selectedSubject);
            }

            var filteredOlympics = query
                .Where(olimp => olimp.ID_Creator == App._Olimp_Users.ID)
                .ToList();

            lvList.ItemsSource = filteredOlympics;
        }
        private void but_Remove_Click(object sender, RoutedEventArgs e)
        {
            cb_diff.SelectedItem = null;
            cb_cat.SelectedItem = null;
            cb_sub.SelectedItem = null;

            ListViewFull();
            but_Remove.Visibility = Visibility.Collapsed;
        }

        private void But_Upd_Click(object sender, RoutedEventArgs e)
        {
            var selectedOlimp = (sender as Button).DataContext as Olimp_Olimp;
            UpdateOlimp updateOlimp = new UpdateOlimp(selectedOlimp);
            updateOlimp.Show();
            this.Close();
        }

        private void But_Del_Click(object sender, RoutedEventArgs e)
        {
            var selectedOlimp = (sender as Button).DataContext as Olimp_Olimp;
            if (selectedOlimp != null)
            {
                if (MessageBox.Show("Вы уверены, что хотите удалить эту олимпиаду?", "Подумайте ещё", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    var deleteOlimp = App.Context.Olimp_Olimp.Find(selectedOlimp.ID);
                    if (deleteOlimp != null)
                    {
                        var registrationsToDelete = App.Context.Olimp_Registration.Where(r => r.ID_Olimp == deleteOlimp.ID).ToList();
                        App.Context.Olimp_Registration.RemoveRange(registrationsToDelete);

                        App.Context.Olimp_Olimp.Remove(deleteOlimp);
                        App.Context.SaveChanges();

                        MessageBox.Show("Олимпиада и связанные с ней регистрации удалены.");
                    }
                }
            }
        }
    }
}
