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
    /// Логика взаимодействия для OlimpListWindow.xaml
    /// </summary>
    public partial class OlimpListWindow : Window
    {
        public OlimpListWindow()
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
            var registeredOlympics = App.Context.Olimp_Registration
                .Where(reg => reg.ID_User == App._Olimp_Users.ID)
                .Select(reg => reg.ID_Olimp)
                .ToList();

            var LVfill = App.Context.Olimp_Olimp
                .Where(olimp => !registeredOlympics.Contains(olimp.ID))
                .OrderByDescending(o => o.DateOfEvent)
                .ToList();

            lv_Olimps.ItemsSource = LVfill;

            if (LVfill.Count > 0)
            {
                lv_Olimps.Visibility = Visibility.Visible;
                EmptyMessage.Visibility = Visibility.Collapsed;
            }
            else
            {
                lv_Olimps.Visibility = Visibility.Collapsed;
                EmptyMessage.Visibility = Visibility.Visible;
            }
        }
        private void But_Reg_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var button = (sender as Button).DataContext as Olimp_Olimp;
                if (button != null)
                {
                    if (MessageBox.Show("Ты точно хочешь принять участие в данной олимпиаде?", "Регистрация", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        var Regs = new Olimp_Registration
                        {
                            ID_Olimp = button.ID,
                            ID_User = App._Olimp_Users.ID
                        };
                        App.Context.Olimp_Registration.Add(Regs);
                        App.Context.SaveChanges();
                        MessageBox.Show("Ждем тебя на олимпиаде, солнце!", "Успешно");
                        ListViewFull();
                    }
                }
                else MessageBox.Show("Ой, что-то пошло не так! Попробуйте ещё раз!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ой, что-то пошло не так: {ex.Message}! Попробуйте ещё раз!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            UserWindow userWindow = new UserWindow();
            userWindow.Show();
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
                .Where(olimp => !App.Context.Olimp_Registration
                    .Any(reg => reg.ID_User == App._Olimp_Users.ID && reg.ID_Olimp == olimp.ID))
                .ToList();

            lv_Olimps.ItemsSource = filteredOlympics;
        }
        private void but_Remove_Click(object sender, RoutedEventArgs e)
        {
            cb_diff.SelectedItem = null;
            cb_cat.SelectedItem = null;
            cb_sub.SelectedItem = null;

            ListViewFull();
            but_Remove.Visibility = Visibility.Collapsed;
        }
    }
}
